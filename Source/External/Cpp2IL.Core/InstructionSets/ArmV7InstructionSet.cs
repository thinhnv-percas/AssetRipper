// AssetRipper: rewritten. Upstream's GetIsilFromMethod returned an empty list unconditionally, so no
// method body could ever be recovered from an armeabi-v7a build: the lifter is the first stage, and
// with no ISIL there is nothing to generate IL from and nothing for the decompiler to read. Android
// ships ARM code in ARM mode here, not Thumb, which is what the existing disassembler already
// assumes and what the generated code turns out to be.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.Il2CppApiFunctions;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;
using Gee.External.Capstone.Arm;

namespace Cpp2IL.Core.InstructionSets;

public class ArmV7InstructionSet : Cpp2IlInstructionSet
{
    /// <summary>Reading PC in ARM mode gives the address of the instruction plus eight.</summary>
    private const int PcReadOffset = 8;

    /// <summary>
    /// Value a register was given by a literal pool load, keyed by register name. ARM has no
    /// instruction that materialises an arbitrary 32 bit constant, so the compiler parks constants
    /// after the function and loads them with a PC relative <c>ldr</c>; the value is meaningless until
    /// it is read back out of the binary.
    /// </summary>
    [ThreadStatic]
    private static Dictionary<string, long>? literalValues;

    /// <summary>
    /// Absolute address a register is known to hold. Position independent code reaches a global in two
    /// steps — a literal load of an offset, then <c>add rD, pc, rD</c> — and only the sum is an
    /// address anything downstream can resolve.
    /// </summary>
    [ThreadStatic]
    private static Dictionary<string, ulong>? absoluteAddresses;

    /// <summary>
    /// Stack slot a register holds the address of, keyed by register name. A composite return value
    /// is written through such a pointer, and the words it covers are only ever read back by offset,
    /// so without this the call is not seen to have written them.
    /// </summary>
    [ThreadStatic]
    private static Dictionary<string, int>? stackAddresses;

    private static readonly ArmV7CallingConventionResolver CallingConventions = new();

    public override BaseCallingConventionResolver CallingConventionResolver => CallingConventions;

    private static Immediate Imm(long value) => new(value);

    private static Immediate Imm(ulong value) => new(unchecked((long)value));

    private static string RegisterName(ArmRegister? register) => register?.Id switch
    {
        null => "INVALID",
        ArmRegisterId.ARM_REG_SP or ArmRegisterId.ARM_REG_R13 => "SP",
        ArmRegisterId.ARM_REG_LR or ArmRegisterId.ARM_REG_R14 => "LR",
        ArmRegisterId.ARM_REG_PC or ArmRegisterId.ARM_REG_R15 => "PC",
        _ => register.Name.ToUpperInvariant(),
    };

    private static Register Reg(ArmRegister register) => new(null, RegisterName(register));

    private static bool IsPc(ArmRegister? register)
        => register?.Id is ArmRegisterId.ARM_REG_PC or ArmRegisterId.ARM_REG_R15;

    private static bool IsSp(ArmRegister? register)
        => register?.Id is ArmRegisterId.ARM_REG_SP or ArmRegisterId.ARM_REG_R13;

    public override BinarySlice GetRawBytesForMethod(MethodAnalysisContext context, bool isAttributeGenerator)
    {
        var slice = ArmV7Utils.TryGetMethodBodyBytesFast(context.AppContext.Binary, context.UnderlyingPointer, isAttributeGenerator);
        if (slice.Length > 0)
            return slice;

        var instructions = ArmV7Utils.GetArmV7MethodBodyAtVirtualAddress(context.AppContext.Binary, context.UnderlyingPointer);

        return new BinarySlice(instructions.SelectMany(i => i.Bytes).ToArray());
    }

    public override List<IOperand> GetParameterOperandsFromMethod(MethodAnalysisContext context)
    {
        return CallingConventions.ResolveForManaged(context).ToList();
    }

    public override List<Instruction> GetIsilFromMethod(MethodAnalysisContext context)
    {
        List<ArmInstruction> body;
        try
        {
            body = ArmV7Utils.GetArmV7MethodBodyAtVirtualAddress(context.AppContext.Binary, context.UnderlyingPointer);
        }
        catch
        {
            return [];
        }

        body = TrimToFunctionBody(body);

        // ThreadStatic initialisers only run on the first thread to touch them.
        (literalValues ??= new()).Clear();
        (absoluteAddresses ??= new()).Clear();
        (stackAddresses ??= new()).Clear();

        var instructions = new List<Instruction>();
        var addresses = new List<ulong>();

        foreach (var instruction in body)
            ConvertInstruction(instruction, instructions, addresses, context);

        if (instructions.Count > 0 && instructions[^1].OpCode != OpCode.Return)
        {
            var index = instructions[^1].Index + 1;
            instructions.Add(context.IsVoid
                ? new Instruction(index, OpCode.Return)
                : new Instruction(index, OpCode.Return, CallingConventions.ReturnRegister(context)));
        }

        ResolveBranchTargets(instructions, addresses);

        literalValues.Clear();
        absoluteAddresses.Clear();
        stackAddresses.Clear();

        return instructions;
    }

    private static void ConvertInstruction(ArmInstruction instruction, List<Instruction> instructions, List<ulong> addresses, MethodAnalysisContext context)
    {
        var address = (ulong)instruction.Address;
        var operands = Operands(instruction);
        var binary = context.AppContext.Binary;

        Instruction Add(ulong at, OpCode opCode, params List<IOperand> ops)
        {
            addresses.Add(at);
            var created = new Instruction(instructions.Count, opCode, ops);
            instructions.Add(created);
            return created;
        }

        void Forget(ArmRegister? register)
        {
            if (register is null)
                return;

            var name = RegisterName(register);
            literalValues!.Remove(name);
            absoluteAddresses!.Remove(name);
            stackAddresses!.Remove(name);
        }

        // The value at a fixed address, when it is inside the binary. Literal pools live in the
        // executable image, so this is a read of the image rather than of anything at run time.
        bool TryReadWord(ulong at, out long value)
        {
            value = 0;

            try
            {
                if (!binary.TryMapVirtualAddressToRaw(at, out var raw) || raw < 0 || raw + 4 > binary.RawLength)
                    return false;

                value = BitConverter.ToInt32(binary.GetRawBinaryContent().Slice((int)raw, 4).ToArray(), 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // The address a PC relative access reads from, if this operand is one.
        bool TryResolvePcRelative(ArmOperand operand, out ulong resolved)
        {
            resolved = 0;

            if (operand.Type != ArmOperandType.Memory || !IsPc(operand.Memory.Base))
                return false;

            var pc = address + PcReadOffset;

            if (operand.Memory.Index is null)
            {
                resolved = (ulong)((long)pc + operand.Memory.Displacement);
                return true;
            }

            // ldr rD, [pc, rN] where rN came from the pool itself: the sum is the real address.
            if (!literalValues!.TryGetValue(RegisterName(operand.Memory.Index), out var offset))
                return false;

            resolved = (ulong)((long)pc + (operand.IsSubtracted ? -offset : offset));
            return true;
        }

        IOperand MemOperand(ArmOperand operand, long extraOffset = 0)
        {
            var memory = operand.Memory;
            long displacement = memory.Displacement + extraOffset;

            if (TryResolvePcRelative(operand, out var pcRelative))
                return new MemoryOperand(addend: (long)pcRelative + extraOffset);

            if (IsSp(memory.Base) && memory.Index is null)
                return new StackOffset((int)displacement);

            if (memory.Base is not null && absoluteAddresses!.TryGetValue(RegisterName(memory.Base), out var absolute) && memory.Index is null)
                return new MemoryOperand(addend: (long)absolute + displacement);

            // A register holding a pool constant that is an address into the image, dereferenced: the
            // load is from that address. ARM64 reaches a metadata usage in one load and lands typed;
            // ARMv7 takes two, and without folding the first the second has an untyped base, which is
            // what leaves every static field read as a placeholder.
            if (memory.Base is not null && memory.Index is null
                && literalValues!.TryGetValue(RegisterName(memory.Base), out var literalBase)
                && literalBase > 0 && binary.TryMapVirtualAddressToRaw((ulong)literalBase, out _))
                return new MemoryOperand(addend: literalBase + displacement);

            if (memory.Base is null)
                return new MemoryOperand(addend: displacement);

            if (memory.Index is not null)
                return new MemoryOperand(Reg(memory.Base), Reg(memory.Index), displacement, 1 << memory.LeftShit);

            return new MemoryOperand(Reg(memory.Base), addend: displacement);
        }

        IOperand Convert(ArmOperand operand) => operand.Type switch
        {
            ArmOperandType.Register => IsPc(operand.Register) ? Imm(address + PcReadOffset) : Reg(operand.Register),
            ArmOperandType.Immediate or ArmOperandType.CImmediate or ArmOperandType.PImmediate => Imm(operand.Immediate),
            ArmOperandType.FloatingPoint => new DoubleLiteral(operand.FloatingPoint),
            ArmOperandType.Memory => MemOperand(operand),
            _ => Imm(0),
        };

        var flagN = new Register(null, "N");
        var flagZ = new Register(null, "Z");
        var flagC = new Register(null, "C");
        var flagV = new Register(null, "V");

        // Models op0 - op1, which CMP and the predicated forms are all defined in terms of.
        void EmitCompareFlags(IOperand op0, IOperand op1)
        {
            var temp1 = new Register(null, "TEMP1");
            var temp2 = new Register(null, "TEMP2");
            var temp3 = new Register(null, "TEMP3");
            var temp4 = new Register(null, "TEMP4");

            Add(address, OpCode.CheckLess, flagC, op0, op1); // arm's C is the inverse of a borrow
            Add(address, OpCode.Not, flagC, flagC);
            Add(address, OpCode.Subtract, temp1, op0, op1);
            Add(address, OpCode.CheckLess, flagN, temp1, Imm(0));
            Add(address, OpCode.CheckEqual, flagZ, temp1, Imm(0));
            Add(address, OpCode.Xor, temp2, op0, op1);
            Add(address, OpCode.Xor, temp3, op0, temp1);
            Add(address, OpCode.And, temp4, temp2, temp3);
            Add(address, OpCode.CheckLess, flagV, temp4, Imm(0));
        }

        void EmitResultFlags(IOperand result)
        {
            Add(address, OpCode.CheckLess, flagN, result, Imm(0));
            Add(address, OpCode.CheckEqual, flagZ, result, Imm(0));
            Add(address, OpCode.Move, flagC, Imm(0));
            Add(address, OpCode.Move, flagV, Imm(0));
        }

        IOperand EmitCondition(ArmConditionCode condition)
        {
            var temp = new Register(null, "TEMPCOND");
            var temp2 = new Register(null, "TEMPCOND2");

            switch (condition)
            {
                case ArmConditionCode.ARM_CC_EQ:
                    return flagZ;
                case ArmConditionCode.ARM_CC_NE:
                    Add(address, OpCode.Not, temp, flagZ);
                    return temp;
                case ArmConditionCode.ARM_CC_GE:
                    Add(address, OpCode.CheckEqual, temp, flagN, flagV);
                    return temp;
                case ArmConditionCode.ARM_CC_LT:
                    Add(address, OpCode.CheckEqual, temp, flagN, flagV);
                    Add(address, OpCode.Not, temp, temp);
                    return temp;
                case ArmConditionCode.ARM_CC_GT:
                    Add(address, OpCode.CheckEqual, temp, flagN, flagV);
                    Add(address, OpCode.Not, temp2, flagZ);
                    Add(address, OpCode.And, temp, temp, temp2);
                    return temp;
                case ArmConditionCode.ARM_CC_LE:
                    Add(address, OpCode.CheckEqual, temp, flagN, flagV);
                    Add(address, OpCode.Not, temp, temp);
                    Add(address, OpCode.Or, temp, temp, flagZ);
                    return temp;
                case ArmConditionCode.ARM_CC_HS: // unsigned >=
                    return flagC;
                case ArmConditionCode.ARM_CC_LO: // unsigned <
                    Add(address, OpCode.Not, temp, flagC);
                    return temp;
                case ArmConditionCode.ARM_CC_HI: // unsigned >
                    Add(address, OpCode.Not, temp, flagZ);
                    Add(address, OpCode.And, temp, flagC, temp);
                    return temp;
                case ArmConditionCode.ARM_CC_LS: // unsigned <=
                    Add(address, OpCode.Not, temp, flagC);
                    Add(address, OpCode.Or, temp, temp, flagZ);
                    return temp;
                case ArmConditionCode.ARM_CC_MI:
                    return flagN;
                case ArmConditionCode.ARM_CC_PL:
                    Add(address, OpCode.Not, temp, flagN);
                    return temp;
                case ArmConditionCode.ARM_CC_VS:
                    return flagV;
                case ArmConditionCode.ARM_CC_VC:
                    Add(address, OpCode.Not, temp, flagV);
                    return temp;
                default:
                    return Imm(1);
            }
        }

        void AddCallAt(ulong target)
        {
            if (context.AppContext.MethodsByAddress.TryGetValue(target, out var possibleMethods) && possibleMethods.Count > 0)
            {
                var ctx = possibleMethods[0];

                if (possibleMethods.Count > 1)
                {
                    // Several methods folded onto one address; take the widest signature so no
                    // argument is dropped.
                    var mostArguments = -1;
                    foreach (var method in possibleMethods)
                    {
                        var arguments = method.Parameters.Count + (method.IsStatic ? 0 : 1);
                        if (arguments > mostArguments)
                        {
                            mostArguments = arguments;
                            ctx = method;
                        }
                    }
                }

                var call = ctx.IsVoid
                    ? Add(address, OpCode.CallVoid, Imm(target))
                    : Add(address, OpCode.Call, Imm(target), CallingConventions.ReturnRegister(ctx));

                call.AddOperands(CallingConventions.ResolveForManaged(ctx));
                DefineHiddenReturnBuffer(ctx, call);
            }
            else
            {
                var call = Add(address, OpCode.Call, Imm(target), new Register(null, "R0"));
                call.AddOperands(CallingConventions.ResolveForUnmanaged(context.AppContext, target));
            }

            // A call clobbers the argument and result registers, so nothing tracked survives it.
            literalValues!.Clear();
            absoluteAddresses!.Clear();
        }

        // A composite return value is written into a caller supplied buffer, and the words of it are
        // read back one at a time by offset: vldr s16, [sp, #0xc] is the z of a Vector3 whose buffer
        // was handed over as add r0, sp, #4. Nothing in the ISIL says the call wrote those words, so
        // every read of them resolves to the same undefined value and two calls into the same buffer
        // become the same value — which is how a - b turns into a - a. Naming each word as written by
        // the call is what keeps the two apart.
        void DefineHiddenReturnBuffer(MethodAnalysisContext callee, Instruction call)
        {
            if (!CallingConventions.ReturnsViaHiddenBuffer(callee))
                return;

            if (CallingConventions.HiddenReturnBufferRegister(callee) is not { } bufferRegister)
                return;

            if (!stackAddresses!.TryGetValue(bufferRegister.Name, out var slot))
                return;

            var size = TypeSizes.UnboxedSize(callee.ReturnType, 4);

            // A word at a time, because that is the granularity the code reads them back at, and each
            // one written from the buffer at its own offset rather than from the whole value. The
            // buffer register is the call's destination, so once the analysis has typed it the offset
            // reads as the field it is — [Vector3 + 8] is that vector's z — instead of the whole
            // struct standing in for one of its components.
            for (var offset = 0; offset + 4 <= size; offset += 4)
                Add(address, OpCode.Move, new StackOffset(slot + offset), new MemoryOperand(bufferRegister, addend: offset));
        }

        void AddReturn()
        {
            if (context.IsVoid)
                Add(address, OpCode.Return);
            else
                Add(address, OpCode.Return, CallingConventions.ReturnRegister(context));
        }

        // Almost every ARM instruction can carry a condition. A conditional branch is a jump and is
        // handled as one; anything else conditional is the body guarded by a jump over it.
        var predicated = IsConditional(instruction) && instruction.Id is not (ArmInstructionId.ARM_INS_B or ArmInstructionId.ARM_INS_BL or ArmInstructionId.ARM_INS_BX or ArmInstructionId.ARM_INS_BLX);
        var skipAddress = address + 1;

        if (predicated)
        {
            var inverse = new Register(null, "TEMPPRED");
            Add(address, OpCode.Not, inverse, EmitCondition(instruction.Details.ConditionCode));
            Add(address, OpCode.ConditionalJump, Imm(skipAddress), inverse);
        }

        ConvertBody();

        if (predicated)
            Add(skipAddress, OpCode.Nop);

        void ConvertBody()
        {
            switch (instruction.Id)
            {
                case ArmInstructionId.ARM_INS_NOP:
                case ArmInstructionId.ARM_INS_DMB:
                case ArmInstructionId.ARM_INS_DSB:
                case ArmInstructionId.ARM_INS_ISB:
                case ArmInstructionId.ARM_INS_IT:
                case ArmInstructionId.ARM_INS_VMRS: // the flags it copies were emitted by the VCMP
                    Add(address, OpCode.Nop);
                    return;

                case ArmInstructionId.ARM_INS_MOV:
                case ArmInstructionId.ARM_INS_MOVW:
                case ArmInstructionId.ARM_INS_VMOV:
                case ArmInstructionId.ARM_INS_VCVT:
                case ArmInstructionId.ARM_INS_SXTB:
                case ArmInstructionId.ARM_INS_SXTH:
                case ArmInstructionId.ARM_INS_UXTB:
                case ArmInstructionId.ARM_INS_UXTH:
                    if (operands.Length < 2)
                        break;

                    // mov pc, lr is a return written as a move.
                    if (IsPc(RegisterOf(operands[0])))
                    {
                        AddReturn();
                        return;
                    }

                    Forget(RegisterOf(operands[0]));
                    Add(address, OpCode.Move, Convert(operands[0]), Convert(operands[1]));

                    if (RegisterOf(operands[0]) is { } movDestination)
                    {
                        var destination = RegisterName(movDestination);

                        if (operands[1].Type == ArmOperandType.Immediate && instruction.Id is ArmInstructionId.ARM_INS_MOV or ArmInstructionId.ARM_INS_MOVW)
                            literalValues![destination] = (uint)operands[1].Immediate;
                        else if (RegisterOf(operands[1]) is { } movSource)
                        {
                            var source = RegisterName(movSource);

                            if (literalValues!.TryGetValue(source, out var literal))
                                literalValues[destination] = literal;

                            if (absoluteAddresses!.TryGetValue(source, out var absolute))
                                absoluteAddresses[destination] = absolute;
                        }
                    }

                    if (instruction.Details.UpdateFlags)
                        EmitResultFlags(Convert(operands[0]));

                    return;

                case ArmInstructionId.ARM_INS_MOVT:
                {
                    // The top half of a constant the compiler built in two instructions.
                    if (operands.Length < 2 || RegisterOf(operands[0]) is not { } movtDestination || operands[1].Type != ArmOperandType.Immediate)
                        break;

                    var destination = RegisterName(movtDestination);
                    var low = literalValues!.TryGetValue(destination, out var known) ? known & 0xFFFF : 0;
                    var value = low | ((long)(uint)operands[1].Immediate << 16);

                    literalValues[destination] = value;
                    absoluteAddresses!.Remove(destination);
                    Add(address, OpCode.Move, Reg(movtDestination), Imm(value));
                    return;
                }

                case ArmInstructionId.ARM_INS_MVN:
                    if (operands.Length < 2)
                        break;

                    Forget(RegisterOf(operands[0]));
                    Add(address, OpCode.Not, Convert(operands[0]), Convert(operands[1]));
                    return;

                case ArmInstructionId.ARM_INS_LDR:
                case ArmInstructionId.ARM_INS_LDRB:
                case ArmInstructionId.ARM_INS_LDRH:
                case ArmInstructionId.ARM_INS_LDRSB:
                case ArmInstructionId.ARM_INS_LDRSH:
                case ArmInstructionId.ARM_INS_VLDR:
                {
                    if (operands.Length < 2 || RegisterOf(operands[0]) is not { } loadDestination)
                        break;

                    var destination = RegisterName(loadDestination);

                    // The source is resolved before the destination is forgotten: ldr r0, [pc, r0]
                    // builds its address out of the register it is about to overwrite, so forgetting
                    // first would throw away the only thing that makes the address knowable.
                    // Both [pc, #imm] and [pc, rN] are read out of the image. The first is a literal
                    // pool, where the word is the constant. The second is one step of the indirection
                    // that reaches a metadata usage slot, and the word there is the slot's address,
                    // which is what the load after it resolves against. Measured: stopping at the
                    // address instead of reading through it loses every typeof(T) in the method.
                    long literal = 0;
                    var isLiteralLoad = instruction.Id == ArmInstructionId.ARM_INS_LDR
                        && TryResolvePcRelative(operands[1], out var literalAddress)
                        && TryReadWord(literalAddress, out literal);
                    var source = isLiteralLoad ? null : Convert(operands[1]);

                    Forget(loadDestination);

                    // A literal pool load is the only way ARM materialises a wide constant, and the
                    // value is in the image, so read it rather than emitting a load nothing can follow.
                    if (isLiteralLoad)
                    {
                        literalValues![destination] = (uint)literal;
                        Add(address, OpCode.Move, Reg(loadDestination), Imm((uint)literal));
                        return;
                    }

                    Add(address, OpCode.Move, Reg(loadDestination), source!);
                    return;
                }

                case ArmInstructionId.ARM_INS_STR:
                case ArmInstructionId.ARM_INS_STRB:
                case ArmInstructionId.ARM_INS_STRH:
                case ArmInstructionId.ARM_INS_VSTR:
                    if (operands.Length < 2)
                        break;

                    Add(address, OpCode.Move, Convert(operands[1]), Convert(operands[0]));
                    return;

                case ArmInstructionId.ARM_INS_ADD:
                case ArmInstructionId.ARM_INS_SUB:
                case ArmInstructionId.ARM_INS_RSB:
                case ArmInstructionId.ARM_INS_AND:
                case ArmInstructionId.ARM_INS_ORR:
                case ArmInstructionId.ARM_INS_EOR:
                case ArmInstructionId.ARM_INS_BIC:
                case ArmInstructionId.ARM_INS_MUL:
                case ArmInstructionId.ARM_INS_LSL:
                case ArmInstructionId.ARM_INS_LSR:
                case ArmInstructionId.ARM_INS_ASR:
                case ArmInstructionId.ARM_INS_VADD:
                case ArmInstructionId.ARM_INS_VSUB:
                case ArmInstructionId.ARM_INS_VMUL:
                case ArmInstructionId.ARM_INS_VDIV:
                {
                    if (operands.Length < 2)
                        break;

                    var left = operands.Length >= 3 ? operands[1] : operands[0];
                    var right = operands.Length >= 3 ? operands[2] : operands[1];

                    // add rD, pc, rN completes a position independent address: the literal rN holds is
                    // an offset from this instruction's PC, and only the sum names anything.
                    if (instruction.Id == ArmInstructionId.ARM_INS_ADD && operands.Length >= 3 && RegisterOf(operands[0]) is { } addDestination)
                    {
                        var destination = RegisterName(addDestination);
                        var pcSide = IsPc(RegisterOf(left)) ? right : IsPc(RegisterOf(right)) ? left : null;

                        if (RegisterOf(pcSide) is { } pcSideRegister && literalValues!.TryGetValue(RegisterName(pcSideRegister), out var offset))
                        {
                            var absolute = address + PcReadOffset + (ulong)offset;
                            absoluteAddresses![destination] = absolute;
                            literalValues.Remove(destination);
                            Add(address, OpCode.Move, Reg(addDestination), Imm(absolute));
                            return;
                        }

                        // add rD, rN, #imm keeps walking a known address along.
                        if (right.Type == ArmOperandType.Immediate && RegisterOf(left) is { } leftRegister
                            && absoluteAddresses!.TryGetValue(RegisterName(leftRegister), out var known))
                        {
                            var moved = known + (ulong)right.Immediate;
                            absoluteAddresses[destination] = moved;
                            literalValues!.Remove(destination);
                            Add(address, OpCode.Move, Reg(addDestination), Imm(moved));
                            return;
                        }
                    }

                    Forget(RegisterOf(operands[0]));

                    // sp adjustments are stack frame movement, which ISIL says with ShiftStack.
                    if (IsSp(RegisterOf(operands[0])) && operands.Length >= 3
                        && IsSp(RegisterOf(operands[1])) && right.Type == ArmOperandType.Immediate)
                    {
                        var delta = instruction.Id == ArmInstructionId.ARM_INS_SUB ? -right.Immediate : right.Immediate;
                        Add(address, OpCode.ShiftStack, Imm(delta));
                        return;
                    }

                    // add rD, sp, #imm takes the address of a stack slot, which is how the caller hands
                    // over the buffer a composite return value is written into. Emitted as arithmetic on
                    // SP it would be a number, and the reads that follow could not be tied back to it.
                    if (instruction.Id is ArmInstructionId.ARM_INS_ADD or ArmInstructionId.ARM_INS_SUB
                        && operands.Length >= 3 && IsSp(RegisterOf(operands[1])) && !IsSp(RegisterOf(operands[0]))
                        && right.Type == ArmOperandType.Immediate)
                    {
                        var slot = new StackOffset(instruction.Id == ArmInstructionId.ARM_INS_SUB ? -right.Immediate : right.Immediate);
                        Add(address, OpCode.Move, Convert(operands[0]), new AddressOf(slot));

                        if (RegisterOf(operands[0]) is { } slotHolder)
                            stackAddresses![RegisterName(slotHolder)] = slot.Offset;

                        return;
                    }

                    var opCode = instruction.Id switch
                    {
                        ArmInstructionId.ARM_INS_ADD or ArmInstructionId.ARM_INS_VADD => OpCode.Add,
                        ArmInstructionId.ARM_INS_SUB or ArmInstructionId.ARM_INS_VSUB or ArmInstructionId.ARM_INS_RSB => OpCode.Subtract,
                        ArmInstructionId.ARM_INS_AND => OpCode.And,
                        ArmInstructionId.ARM_INS_ORR => OpCode.Or,
                        ArmInstructionId.ARM_INS_EOR => OpCode.Xor,
                        ArmInstructionId.ARM_INS_BIC => OpCode.And,
                        ArmInstructionId.ARM_INS_MUL or ArmInstructionId.ARM_INS_VMUL => OpCode.Multiply,
                        ArmInstructionId.ARM_INS_VDIV => OpCode.Divide,
                        ArmInstructionId.ARM_INS_LSL => OpCode.ShiftLeft,
                        _ => OpCode.ShiftRight,
                    };

                    // rsb subtracts the other way round.
                    var (first, second) = instruction.Id == ArmInstructionId.ARM_INS_RSB
                        ? (Convert(right), Convert(left))
                        : (Convert(left), Convert(right));

                    Add(address, opCode, Convert(operands[0]), first, second);

                    if (instruction.Details.UpdateFlags)
                        EmitResultFlags(Convert(operands[0]));

                    return;
                }

                case ArmInstructionId.ARM_INS_VMLA:
                {
                    // vmla dst, a, b is dst += a * b.
                    if (operands.Length < 3)
                        break;

                    var product = new Register(null, "TEMPVMLA");
                    Add(address, OpCode.Multiply, product, Convert(operands[1]), Convert(operands[2]));
                    Add(address, OpCode.Add, Convert(operands[0]), Convert(operands[0]), product);
                    return;
                }

                case ArmInstructionId.ARM_INS_VNEG:
                    if (operands.Length < 2)
                        break;

                    Add(address, OpCode.Negate, Convert(operands[0]), Convert(operands[1]));
                    return;

                case ArmInstructionId.ARM_INS_VSQRT:
                case ArmInstructionId.ARM_INS_VABS:
                case ArmInstructionId.ARM_INS_VRINTZ:
                case ArmInstructionId.ARM_INS_VRINTA:
                case ArmInstructionId.ARM_INS_VRINTN:
                case ArmInstructionId.ARM_INS_VRINTM:
                case ArmInstructionId.ARM_INS_VRINTP:
                {
                    // ISIL has no square root or rounding, so each becomes a call to the managed method
                    // that computes the same thing. Failing that, a move at least keeps the dataflow
                    // connected, which is what everything downstream reads; the value is then the
                    // operand, unrounded.
                    if (operands.Length < 2)
                        break;

                    var name = instruction.Id switch
                    {
                        ArmInstructionId.ARM_INS_VSQRT => "Sqrt",
                        ArmInstructionId.ARM_INS_VABS => "Abs",
                        ArmInstructionId.ARM_INS_VRINTZ => "Truncate",
                        ArmInstructionId.ARM_INS_VRINTM => "Floor",
                        ArmInstructionId.ARM_INS_VRINTP => "Ceiling",
                        _ => "Round",
                    };

                    var isDouble = RegisterOf(operands[0]) is { } destination && RegisterName(destination).StartsWith('D');

                    if (MathIntrinsics.Resolve(context.AppContext, name, isDouble, 1) is { } intrinsic)
                        Add(address, OpCode.Call, intrinsic, Convert(operands[0])).AddOperands([Convert(operands[1])]);
                    else
                        Add(address, OpCode.Move, Convert(operands[0]), Convert(operands[1]));

                    return;
                }

                case ArmInstructionId.ARM_INS_VMLS:
                {
                    // vmls dst, a, b is dst -= a * b.
                    if (operands.Length < 3)
                        break;

                    var subtracted = new Register(null, "TEMPVMLS");
                    Add(address, OpCode.Multiply, subtracted, Convert(operands[1]), Convert(operands[2]));
                    Add(address, OpCode.Subtract, Convert(operands[0]), Convert(operands[0]), subtracted);
                    return;
                }

                case ArmInstructionId.ARM_INS_CMP:
                case ArmInstructionId.ARM_INS_VCMP:
                case ArmInstructionId.ARM_INS_VCMPE:
                    if (operands.Length < 2)
                        break;

                    EmitCompareFlags(Convert(operands[0]), Convert(operands[1]));
                    return;

                case ArmInstructionId.ARM_INS_CMN:
                {
                    if (operands.Length < 2)
                        break;

                    var negated = new Register(null, "TEMPCMN");
                    Add(address, OpCode.Negate, negated, Convert(operands[1]));
                    EmitCompareFlags(Convert(operands[0]), negated);
                    return;
                }

                case ArmInstructionId.ARM_INS_TST:
                case ArmInstructionId.ARM_INS_TEQ:
                {
                    if (operands.Length < 2)
                        break;

                    var result = new Register(null, "TEMPTST");
                    Add(address, instruction.Id == ArmInstructionId.ARM_INS_TST ? OpCode.And : OpCode.Xor, result, Convert(operands[0]), Convert(operands[1]));
                    EmitResultFlags(result);
                    return;
                }

                case ArmInstructionId.ARM_INS_B:
                {
                    if (!TryGetBranchTarget(instruction, out var target))
                        break;

                    if (IsConditional(instruction))
                    {
                        Add(address, OpCode.ConditionalJump, Imm(target), EmitCondition(instruction.Details.ConditionCode));
                        return;
                    }

                    // A branch to another method's entry point is a tail call. Left as a jump it is a
                    // branch to an address this method does not contain, which resolves to nothing.
                    if (context.AppContext.MethodsByAddress.ContainsKey(target))
                    {
                        AddCallAt(target);
                        AddReturn();
                        return;
                    }

                    Add(address, OpCode.Jump, Imm(target));
                    return;
                }

                case ArmInstructionId.ARM_INS_CBZ:
                case ArmInstructionId.ARM_INS_CBNZ:
                {
                    if (operands.Length < 2 || !TryGetBranchTarget(instruction, out var target))
                        break;

                    var taken = new Register(null, "TEMPCBZ");
                    Add(address, instruction.Id == ArmInstructionId.ARM_INS_CBZ ? OpCode.CheckEqual : OpCode.CheckNotEqual, taken, Convert(operands[0]), Imm(0));
                    Add(address, OpCode.ConditionalJump, Imm(target), taken);
                    return;
                }

                case ArmInstructionId.ARM_INS_BL:
                {
                    if (!TryGetBranchTarget(instruction, out var target))
                        break;

                    AddCallAt(target);
                    return;
                }

                case ArmInstructionId.ARM_INS_BLX:
                {
                    if (operands.Length == 0)
                        break;

                    if (operands[0].Type == ArmOperandType.Immediate)
                    {
                        AddCallAt((ulong)(uint)operands[0].Immediate);
                        return;
                    }

                    var call = Add(address, OpCode.IndirectCall, Convert(operands[0]), new Register(null, "R0"));
                    call.AddOperands(CallingConventions.ResolveForUnmanaged(context.AppContext, 0));
                    literalValues!.Clear();
                    absoluteAddresses!.Clear();
                    return;
                }

                case ArmInstructionId.ARM_INS_BX:
                    if (RegisterOf(operands.Length > 0 ? operands[0] : null)?.Id is ArmRegisterId.ARM_REG_LR or ArmRegisterId.ARM_REG_R14)
                    {
                        AddReturn();
                        return;
                    }

                    if (operands.Length > 0)
                    {
                        Add(address, OpCode.IndirectJump, Convert(operands[0]));
                        return;
                    }

                    break;

                case ArmInstructionId.ARM_INS_PUSH:
                case ArmInstructionId.ARM_INS_VPUSH:
                    Add(address, OpCode.ShiftStack, Imm(-4 * operands.Length));
                    return;

                case ArmInstructionId.ARM_INS_POP:
                case ArmInstructionId.ARM_INS_VPOP:
                    // Popping into PC is the function returning.
                    if (WritesPc(instruction))
                    {
                        AddReturn();
                        return;
                    }

                    Add(address, OpCode.ShiftStack, Imm(4 * operands.Length));
                    return;

                case ArmInstructionId.ARM_INS_LDRD:
                case ArmInstructionId.ARM_INS_STRD:
                {
                    // A pair instruction moves two adjacent words. ISIL has no notion of a register
                    // pair, so it becomes the two moves it is, the second one a word further along.
                    if (operands.Length < 3)
                        break;

                    var memory = operands[2];

                    if (memory.Type != ArmOperandType.Memory)
                        break;

                    if (instruction.Id == ArmInstructionId.ARM_INS_LDRD)
                    {
                        Forget(RegisterOf(operands[0]));
                        Forget(RegisterOf(operands[1]));
                        Add(address, OpCode.Move, Convert(operands[0]), MemOperand(memory));
                        Add(address, OpCode.Move, Convert(operands[1]), MemOperand(memory, 4));
                    }
                    else
                    {
                        Add(address, OpCode.Move, MemOperand(memory), Convert(operands[0]));
                        Add(address, OpCode.Move, MemOperand(memory, 4), Convert(operands[1]));
                    }

                    return;
                }

                case ArmInstructionId.ARM_INS_ADC:
                case ArmInstructionId.ARM_INS_SBC:
                case ArmInstructionId.ARM_INS_RSC:
                {
                    // The carry in is a flag ISIL cannot add to an expression, so this is the plain
                    // arithmetic without it. Wrong by one bit on the boundary, right everywhere else.
                    if (operands.Length < 3)
                        break;

                    Forget(RegisterOf(operands[0]));

                    var (adcLeft, adcRight) = instruction.Id == ArmInstructionId.ARM_INS_RSC
                        ? (Convert(operands[2]), Convert(operands[1]))
                        : (Convert(operands[1]), Convert(operands[2]));

                    Add(address, instruction.Id == ArmInstructionId.ARM_INS_ADC ? OpCode.Add : OpCode.Subtract, Convert(operands[0]), adcLeft, adcRight);

                    if (instruction.Details.UpdateFlags)
                        EmitResultFlags(Convert(operands[0]));

                    return;
                }

                case ArmInstructionId.ARM_INS_MLA:
                case ArmInstructionId.ARM_INS_MLS:
                {
                    if (operands.Length < 4)
                        break;

                    Forget(RegisterOf(operands[0]));
                    var product = new Register(null, "TEMPMLA");
                    Add(address, OpCode.Multiply, product, Convert(operands[1]), Convert(operands[2]));
                    Add(address, instruction.Id == ArmInstructionId.ARM_INS_MLA ? OpCode.Add : OpCode.Subtract, Convert(operands[0]), Convert(operands[3]), product);
                    return;
                }

                case ArmInstructionId.ARM_INS_SMULL:
                case ArmInstructionId.ARM_INS_UMULL:
                {
                    // The low word is the product; the high word needs a shift ISIL cannot express on
                    // a 32 bit value, so it is left alone rather than given a wrong value.
                    if (operands.Length < 4)
                        break;

                    Forget(RegisterOf(operands[0]));
                    Forget(RegisterOf(operands[1]));
                    Add(address, OpCode.Multiply, Convert(operands[0]), Convert(operands[2]), Convert(operands[3]));
                    return;
                }

                case ArmInstructionId.ARM_INS_SMMUL:
                case ArmInstructionId.ARM_INS_SMULBB:
                case ArmInstructionId.ARM_INS_SMULBT:
                case ArmInstructionId.ARM_INS_SMULTB:
                case ArmInstructionId.ARM_INS_SMULTT:
                    if (operands.Length < 3)
                        break;

                    Forget(RegisterOf(operands[0]));
                    Add(address, OpCode.Multiply, Convert(operands[0]), Convert(operands[1]), Convert(operands[2]));
                    return;

                case ArmInstructionId.ARM_INS_CLZ:
                case ArmInstructionId.ARM_INS_RBIT:
                case ArmInstructionId.ARM_INS_REV:
                case ArmInstructionId.ARM_INS_REV16:
                    // No ISIL equivalent; a move keeps the dataflow rather than breaking the chain.
                    if (operands.Length < 2)
                        break;

                    Forget(RegisterOf(operands[0]));
                    Add(address, OpCode.Move, Convert(operands[0]), Convert(operands[1]));
                    return;

                case ArmInstructionId.ARM_INS_VLD1:
                case ArmInstructionId.ARM_INS_VST1:
                case ArmInstructionId.ARM_INS_VLDMIA:
                case ArmInstructionId.ARM_INS_VSTMIA:
                    // Vector loads and stores move more than one register at a time, which ISIL has no
                    // way to name. Treated as opaque so the surrounding code still reads.
                    Add(address, OpCode.Nop);
                    return;

                case ArmInstructionId.ARM_INS_STMIB:
                case ArmInstructionId.ARM_INS_STMDA:
                case ArmInstructionId.ARM_INS_LDMIB:
                case ArmInstructionId.ARM_INS_LDMDA:
                case ArmInstructionId.ARM_INS_STM:
                case ArmInstructionId.ARM_INS_STMDB:
                case ArmInstructionId.ARM_INS_LDM:
                case ArmInstructionId.ARM_INS_LDMDB:
                    if (WritesPc(instruction))
                    {
                        AddReturn();
                        return;
                    }

                    Add(address, OpCode.Nop);
                    return;
            }

            Add(address, OpCode.NotImplemented, new StringLiteral($"{instruction.Mnemonic} {instruction.Operand}"));
        }
    }

    /// <summary>
    /// Cuts the disassembly at the end of the function.
    /// </summary>
    /// <remarks>
    /// The disassembler runs from one method's entry point to the next one's, and ARM parks the
    /// function's literal pool in between. Decoding a pool as code gives plausible looking nonsense —
    /// on the test binary a burst of <c>smultbeq</c>, <c>strdeq</c> and <c>.byte</c> — which would
    /// otherwise be lifted as if it were part of the method. The end is the first unconditional flow
    /// ender that nothing later in the function branches past.
    /// </remarks>
    private static List<ArmInstruction> TrimToFunctionBody(List<ArmInstruction> body)
    {
        long furthestBranchTarget = 0;

        for (var i = 0; i < body.Count; i++)
        {
            var instruction = body[i];

            if (instruction.Id == ArmInstructionId.Invalid || instruction.IsSkippedData)
                return body.Take(i).ToList();

            if (IsBranch(instruction) && TryGetBranchTarget(instruction, out var target))
                furthestBranchTarget = Math.Max(furthestBranchTarget, (long)target);

            if (IsUnconditionalFlowEnd(instruction) && instruction.Address >= furthestBranchTarget)
                return body.Take(i + 1).ToList();
        }

        return body;
    }

    private static bool IsBranch(ArmInstruction instruction)
        => instruction.Id is ArmInstructionId.ARM_INS_B or ArmInstructionId.ARM_INS_BL
            or ArmInstructionId.ARM_INS_CBZ or ArmInstructionId.ARM_INS_CBNZ;

    private static bool TryGetBranchTarget(ArmInstruction instruction, out ulong target)
    {
        var operands = Operands(instruction);
        var last = operands.Length > 0 ? operands[^1] : null;

        if (last is { Type: ArmOperandType.Immediate })
        {
            target = (ulong)(uint)last.Immediate;
            return true;
        }

        target = 0;
        return false;
    }

    private static bool IsUnconditionalFlowEnd(ArmInstruction instruction)
    {
        if (IsConditional(instruction))
            return false;

        return instruction.Id switch
        {
            // A tail branch out of the function, as opposed to one within it, is caught by the caller
            // comparing the target against the addresses still to come.
            ArmInstructionId.ARM_INS_B => true,
            ArmInstructionId.ARM_INS_BX => true,
            ArmInstructionId.ARM_INS_POP or ArmInstructionId.ARM_INS_LDM => WritesPc(instruction),
            ArmInstructionId.ARM_INS_MOV => Operands(instruction) is [{ } destination, _] && IsPc(RegisterOf(destination)),
            _ => false,
        };
    }

    private static bool WritesPc(ArmInstruction instruction)
        => Operands(instruction).Any(operand => IsPc(RegisterOf(operand)));

    private static bool IsConditional(ArmInstruction instruction)
        => instruction.HasDetails
            && instruction.Details.ConditionCode is not (ArmConditionCode.ARM_CC_AL or ArmConditionCode.Invalid);

    private static ArmOperand[] Operands(ArmInstruction instruction)
        => instruction.HasDetails ? instruction.Details.Operands : [];

    /// <summary>
    /// The register an operand names, or null when it names something else. Capstone throws on
    /// <see cref="ArmOperand.Register"/> unless the operand really is a register, so nothing may read
    /// it without checking first.
    /// </summary>
    private static ArmRegister? RegisterOf(ArmOperand? operand)
        => operand is { Type: ArmOperandType.Register } ? operand.Register : null;

    private static void ResolveBranchTargets(List<Instruction> instructions, List<ulong> addresses)
    {
        foreach (var instruction in instructions)
        {
            if (instruction.OpCode is not (OpCode.Jump or OpCode.ConditionalJump))
                continue;

            if (instruction.Operands.Count == 0 || instruction.Operands[0] is not Immediate target)
                continue;

            var targetIndex = addresses.IndexOf(target.UnsignedValue);

            if (targetIndex < 0)
            {
                instruction.OpCode = OpCode.Invalid;
                instruction.SetOperands(new StringLiteral($"Jump target not found in method: 0x{target.UnsignedValue:X4}"));
                continue;
            }

            instruction.SetOperand(0, instructions[targetIndex]);
        }
    }

    public override BaseKeyFunctionAddresses CreateKeyFunctionAddressesInstance()
    {
        //TODO Fix
        return new Arm64KeyFunctionAddresses();
    }

    public override string PrintAssembly(MethodAnalysisContext context)
    {
        var sb = new StringBuilder();

        var instructions = ArmV7Utils.GetArmV7MethodBodyAtVirtualAddress(context.AppContext.Binary, context.UnderlyingPointer);

        var first = true;
        foreach (var instruction in instructions)
        {
            if (!first)
                sb.AppendLine();

            first = false;
            sb.Append("0x").Append(instruction.Address.ToString("X")).Append(" ").Append(instruction.Mnemonic).Append(" ").Append(instruction.Operand);
        }

        return sb.ToString();
    }
}
