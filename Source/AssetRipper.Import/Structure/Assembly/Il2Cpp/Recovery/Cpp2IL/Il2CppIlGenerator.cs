// Vendored from Cpp2IL, Cpp2IL.Core/IlGenerator.cs at commit 291ce6cb95e9cbe661831c53d5ed8fff833d8318,
// which is the source the AssetRipper.Cpp2IL.Core 1.0.9 package this project references was built from
// (its nuspec names that commit). MIT licensed, copyright Samboy063.
//
// It is here because the generator has defects this project cannot fix from the outside, and no
// published package carries the fixes. Changes against the vendored original, each marked "AssetRipper:"
// at the point it applies:
//
//   1. A body can run off its own end. A block whose only successor is the exit block gets no bridge,
//      and the analysis warnings appended at the end finish on a call, so nothing guarantees a
//      terminator. Reading such a body walks past the last instruction, AsmResolver reports a stack
//      imbalance one byte past the final call, and the body is discarded.
//   2. Every metadata usage is a dead pointer. A load from a fixed address becomes a diagnostic and a
//      null pointer, so a string literal the metadata holds in full reaches the source as 0. Those
//      addresses are metadata usage slots and LibCpp2IL can read them back.
//   3. A field inside a value type field is not resolved at all. FsmColor holds a Color at 0x38, so a
//      load from 0x3C is that colour's g component; the generator emits the placeholder instead.
//      NestedFieldResolver finds those, and this file emits them.
//
// Keep the rest byte-for-byte with the original so the next update is a readable diff.

using System.Collections.Generic;
using System.Linq;
using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Utils.AsmResolver;
using LibCpp2IL;
using LibCpp2IL.Metadata;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery.Cpp2IL;

public static class Il2CppIlGenerator
{
    public static void GenerateIl(MethodAnalysisContext context, MethodDefinition definition)
    {
        var assembly = context.DeclaringType!.DeclaringAssembly;
        var module = definition.DeclaringModule!;
        var importer = module.DefaultImporter;
        var factory = module.CorLibTypeFactory;

        var writeLine = factory.CorLibScope
            .CreateTypeReference("System", "Console")
            .CreateMemberReference("WriteLine", MethodSignature.CreateStatic(factory.Void, [factory.String]))
            .ImportWith(importer);

        var stringType = factory.CorLibScope.CreateTypeReference("System", "String");
        var stringCtor = stringType
            .CreateMemberReference(".ctor", MethodSignature.CreateStatic(stringType.ToTypeSignature(false), [factory.String]))
            .ImportWith(importer);

        // Change branch targets to instructions
        foreach (var instruction in context.ControlFlowGraph!.Blocks.SelectMany(block => block.Instructions))
        {
            if (instruction.Operands.Count > 0 && instruction.Operands[0] is Block target)
            {
                if (target.Instructions.Count > 0)
                    instruction.SetOperand(0, target.Instructions[0]);
            }
        }

        var body = new CilMethodBody()
        {
            InitializeLocals = true, // Without this ILSpy does: CompilerServices.Unsafe.SkipInit(out object obj);
            ComputeMaxStackOnBuild = false // There's stack imbalance somewhere, but this works for now
        };

        definition.CilMethodBody = body;

        // Make sure context.Locals actually has all locals (idk why it doesn't sometimes)
        foreach (var operand in context.ControlFlowGraph.Instructions.SelectMany(i => i.Operands))
        {
            LocalVariable? local = null;

            if (operand is FieldReference field)
                local = field.Local;

            if (operand is NestedFieldReference nested) // AssetRipper: change 3
                local = nested.Local;

            if (operand is LocalVariable local2)
                local = local2;

            if (operand is MemoryOperand memory && memory.Base is LocalVariable local3)
                local = local3;

            var elementOperand = operand is AddressOf { Target: ArrayAccess elementAddress } ? elementAddress : operand;

            if (elementOperand is ArrayAccess arrayAccess)
            {
                local = arrayAccess.Array;

                if (arrayAccess.Index is LocalVariable index && !context.Locals.Contains(index))
                    context.Locals.Add(index);
            }

            if (operand is ArrayLength arrayLength)
                local = arrayLength.Array;

            if (operand is AddressOf { Target: LocalVariable addressed })
                local = addressed;

            if (local != null && !context.Locals.Contains(local))
                context.Locals.Add(local);
        }

        // Map ISIL locals to IL
        Dictionary<LocalVariable, CilLocalVariable> locals = [];
        foreach (var local in context.Locals)
        {
            TypeSignature ilType;

            // Use object if type couldn't be determined
            if (local.Type != null)
                ilType = local.Type.ToTypeSignature(module);
            else
                ilType = module.CorLibTypeFactory.Object;

            var ilLocal = new CilLocalVariable(ilType);
            body.LocalVariables.Add(ilLocal);
            locals.Add(local, ilLocal);
        }

        /* foreach (var instruction in context.ControlFlowGraph!.Instructions)
        {
            body.Instructions.Add(CilOpCodes.Ldstr, instruction.ToString());
            body.Instructions.Add(CilOpCodes.Call, _importer!.ImportMethod(_writeLine!));
        }
        body.Instructions.Add(CilOpCodes.Ldstr, "-------------------------------------------------------------------------");
        body.Instructions.Add(CilOpCodes.Call, _importer!.ImportMethod(_writeLine!)); */

        // Generate IL
        Dictionary<Instruction, List<CilInstruction>> instructionMap = [];
        Dictionary<Block, CilInstruction> blockEntryMap = [];
        List<(CilInstruction BranchInstruction, Block TargetBlock)> pendingBlockBranchFixups = [];

        foreach (var block in context.ControlFlowGraph!.Blocks)
        {
            if (block == context.ControlFlowGraph.EntryBlock || block == context.ControlFlowGraph.ExitBlock)
                continue;

            if (block.Instructions.Count == 0)
                continue;

            foreach (var instruction in block.Instructions)
            {
                var generated = GenerateInstructions(instruction, context, definition, locals, writeLine, stringCtor);
                instructionMap.Add(instruction, generated);

                if (!blockEntryMap.ContainsKey(block) && generated.Count > 0)
                    blockEntryMap[block] = generated[0];
            }

            var lastInstruction = block.Instructions.Last();
            
            if (lastInstruction.OpCode == OpCode.ConditionalJump)
            {
                var trueTarget = TryResolveJumpTargetBlock(lastInstruction, context.ControlFlowGraph);
                var falseSuccessor = block.Successors.FirstOrDefault(s => s != trueTarget && s != context.ControlFlowGraph.ExitBlock);
                if (falseSuccessor == null) continue;
                var bridge = new CilInstruction(CilOpCodes.Br, new CilInstructionLabel());
                definition.CilMethodBody!.Instructions.Add(bridge);
                pendingBlockBranchFixups.Add((bridge, falseSuccessor));
            }

            else if (lastInstruction.OpCode != OpCode.Jump && lastInstruction.OpCode != OpCode.Return && lastInstruction.OpCode != OpCode.IndirectJump)
            {
                var successor = block.Successors.FirstOrDefault(s => s != context.ControlFlowGraph.ExitBlock);
                if (successor == null) continue;
                var bridge = new CilInstruction(CilOpCodes.Br, new CilInstructionLabel());
                definition.CilMethodBody!.Instructions.Add(bridge);
                pendingBlockBranchFixups.Add((bridge, successor));
            }
        }
        // Set IL branch targets
        foreach (var kvp in instructionMap)
        {
            var instruction = kvp.Key;
            var il = kvp.Value;

            if (instruction.OpCode == OpCode.Jump || instruction.OpCode == OpCode.ConditionalJump)
            {
                var ilBranch = il.First(i => i.OpCode == CilOpCodes.Br || i.OpCode == CilOpCodes.Brtrue);

                if (instruction.Operands[0] is Block targetBlock)
                {
                    context.AddWarning($"Branch target block not in cfg: {instruction} ({targetBlock})");
                    ilBranch.OpCode = CilOpCodes.Nop;
                    ilBranch.Operand = null;
                    continue;
                }

                var target = (Instruction)instruction.Operands[0];

                if (!instructionMap.ContainsKey(target))
                {
                    context.AddWarning($"Branch target not in ISIL to IL map: {instruction} --- {target}");
                    ilBranch.OpCode = CilOpCodes.Nop;
                    ilBranch.Operand = null;
                    continue;
                }

                ilBranch.Operand = new CilInstructionLabel(instructionMap[target][0]);
            }
        }
        
        foreach (var (branchInstruction, targetBlock) in pendingBlockBranchFixups)
        {
            var target = ResolveBlockEntryInstruction(targetBlock, blockEntryMap);
            if (target == null)
            {
                context.AddWarning($"Unable to resolve branch target block: {targetBlock}");
                branchInstruction.OpCode = CilOpCodes.Nop;
                branchInstruction.Operand = null;
                continue;
            }

            branchInstruction.Operand = new CilInstructionLabel(target);
        }

        // Add analysis warnings
        var instructions = body.Instructions;
        foreach (var warning in context.AnalysisWarnings)
        {
            instructions.Add(CilOpCodes.Ldstr, "Warning: " + warning);
            instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
        }

        EnsureTerminated(context, instructions); // AssetRipper: change 1
    }

    /// <summary>
    /// AssetRipper: change 1. Gives the body a terminator when nothing else has. Without one, reading
    /// the body walks past its last instruction and AsmResolver discards it as unbalanced.
    /// </summary>
    private static void EnsureTerminated(MethodAnalysisContext context, CilInstructionCollection instructions)
    {
        if (instructions.Count > 0 && instructions[^1].OpCode.Code is CilCode.Ret or CilCode.Throw or CilCode.Br or CilCode.Br_S or CilCode.Rethrow or CilCode.Endfinally)
            return;

        if (!context.IsVoid)
            PushDefaultOf(context.ReturnType, instructions);

        instructions.Add(CilOpCodes.Ret);
    }
    
    private static Block? TryResolveJumpTargetBlock(Instruction jumpInstruction, ISILControlFlowGraph cfg)
    {
        if (jumpInstruction.Operands.Count == 0)
            return null;

        if (jumpInstruction.Operands[0] is Block targetBlock)
            return targetBlock;

        if (jumpInstruction.Operands[0] is Instruction targetInstruction)
            return cfg.FindBlockByInstruction(targetInstruction);

        return null;
    }

    private static CilInstruction? ResolveBlockEntryInstruction(Block block,
        Dictionary<Block, CilInstruction> blockEntryMap, HashSet<Block>? visited = null)
    {
        if (blockEntryMap.TryGetValue(block, out var target))
            return target;

        visited ??= [];
        if (!visited.Add(block))
            return null;

        foreach (var successor in block.Successors)
        {
            var resolved = ResolveBlockEntryInstruction(successor, blockEntryMap, visited);
            if (resolved != null)
                return resolved;
        }
        return null;
    }

    private static List<CilInstruction> GenerateInstructions(Instruction instruction, MethodAnalysisContext context,
        MethodDefinition method, Dictionary<LocalVariable, CilLocalVariable> locals, MemberReference writeLine, MemberReference stringCtor)
    {
        var body = method.CilMethodBody!;
        var instructions = body.Instructions;
        var currentCount = instructions.Count;
        var startIndex = instructions.Count;

        var module = method.DeclaringModule!;
        var importer = module.DefaultImporter!;

        switch (instruction.OpCode)
        {
            case OpCode.Invalid:
                instructions.Add(CilOpCodes.Ldstr, $"Invalid instruction: {instruction}");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;

            case OpCode.NotImplemented:
                instructions.Add(CilOpCodes.Ldstr, $"Not implemented instruction: {instruction.Operands[0]}");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;

            case OpCode.Interrupt:
            case OpCode.Nop:
                instructions.Add(CilOpCodes.Nop);
                break;

            case OpCode.Move:
                // AssetRipper: change 3. Same reason as the FieldReference case below it.
                if (instruction.Operands[0] is NestedFieldReference nestedDestination)
                {
                    LoadLocal(nestedDestination.Local, method, locals);

                    for (var i = 0; i < nestedDestination.Path.Count - 1; i++)
                        instructions.Add(CilOpCodes.Ldflda, nestedDestination.Path[i].ToFieldDescriptor(module));

                    var nestedField = nestedDestination.Path[^1];
                    LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor, nestedField.FieldType);
                    instructions.Add(CilOpCodes.Stfld, nestedField.ToFieldDescriptor(module));
                    break;
                }

                if (instruction.Operands[0] is FieldReference field) // stfld takes instance before value so LoadOperand StoreToOperand doesn't work
                {
                    if (!field.Field.IsStatic)
                        LoadLocal(field.Local, method, locals);

                    LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor, field.Field.FieldType);
                    instructions.Add(field.Field.IsStatic ? CilOpCodes.Stsfld : CilOpCodes.Stfld, field.Field.ToFieldDescriptor(module));
                    break;
                }

                // stelem needs array and index before the value, so like stfld it can't go through LoadOperand/StoreToOperand.
                // This also lets ILSpy handle it as a proper array initializer
                if (instruction.Operands[0] is ArrayAccess { Array.Type: SzArrayTypeAnalysisContext { ElementType: { } stored } } target)
                {
                    LoadLocal(target.Array, method, locals);
                    LoadOperand(target.Index, context, method, locals, writeLine, stringCtor);
                    LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor, stored);
                    instructions.Add(CilOpCodes.Stelem, importer.ImportTypeSignature(stored.ToTypeSignature(module)).ToTypeDefOrRef());
                    break;
                }

                LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor, DestinationType(instruction.Operands[0]));
                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.NewArr:
                if (instruction.Operands is [_, SzArrayTypeAnalysisContext { ElementType: { } newArrayElement }, { } length])
                {
                    LoadOperand(length, context, method, locals, writeLine, stringCtor);
                    instructions.Add(CilOpCodes.Newarr, importer.ImportTypeSignature(newArrayElement.ToTypeSignature(module)).ToTypeDefOrRef());
                }
                else
                    instructions.Add(CilOpCodes.Ldnull);

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.Newobj:
                // Try and fuse our Newobj + the follow up constructor CallVoid into one IL newobj.
                // If we can't, just fall back to an Ldnull.
                if (FindConstructorCall(context, instruction) is { Operands: [MethodAnalysisContext constructor, _, ..] } constructorCall)
                {
                    // Operands are [ctor, newObject, arguments..., methodInfo], so take only as many as
                    // the constructor declares (i.e. drop methodInfo)
                    var constructorArgs = constructorCall.Operands.Skip(2).Take(constructor.Parameters.Count).ToList();
                    for (var i = 0; i < constructorArgs.Count; i++)
                        LoadOperand(constructorArgs[i], context, method, locals, writeLine, stringCtor, constructor.Parameters[i].ParameterType);

                    instructions.Add(CilOpCodes.Newobj, importer.ImportMethod(constructor.ToMethodDescriptor(module)));
                    StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);

                    constructorCall.OpCode = OpCode.Nop;
                    constructorCall.SetOperands();
                }
                else
                {
                    instructions.Add(CilOpCodes.Ldnull);
                    StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                }
                break;

            case OpCode.Throw:
                if (instruction.Operands is [TypeAnalysisContext exceptionType]
                    && exceptionType.Methods.FirstOrDefault(m => m.Name == ".ctor" && m.Parameters.Count == 0) is { } exceptionCtor)
                    instructions.Add(CilOpCodes.Newobj, importer.ImportMethod(exceptionCtor.ToMethodDescriptor(module)));
                else
                    instructions.Add(CilOpCodes.Ldnull);

                instructions.Add(CilOpCodes.Throw);
                break;

            case OpCode.Phi:
                instructions.Add(CilOpCodes.Ldstr, $"Phi opcodes should not exist at this point in decompilation ({instruction})");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;

            case OpCode.Call:
            case OpCode.CallVoid:
                if (instruction.Operands[0] is not MethodAnalysisContext targetMethod)
                {
                    if (instruction.Operands[0] is Immediate targetAddress)
                        instructions.Add(CilOpCodes.Ldstr, $"Method not found @{targetAddress.UnsignedValue:X}");
                    else // Probably key function
                        instructions.Add(CilOpCodes.Ldstr, $"Unknown call target operand: {instruction}");

                    instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                    break;
                }

                var importedMethod = importer.ImportMethod(targetMethod.ToMethodDescriptor(module));

                var thisParamIndex = instruction.OpCode == OpCode.Call ? 2 : 1;

                if (!targetMethod.IsStatic) // Load 'this' param
                {
                    if ((instruction.Operands.Count - 1) >= thisParamIndex)
                        LoadOperand(instruction.Operands[thisParamIndex], context, method, locals, writeLine, stringCtor, targetMethod.DeclaringType);
                    else
                    {
                        instructions.Add(CilOpCodes.Ldstr, $"Non static method called without 'this' param ({instruction})");
                        instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                        instructions.Add(CilOpCodes.Ldnull);
                    }
                }

                // Load normal params
                var callParamIndex = instruction.OpCode == OpCode.Call ? (targetMethod.IsStatic ? 2 : 3) : (targetMethod.IsStatic ? 1 : 2);
                // A call whose target was only identified after lifting still carries the operands the
                // unknown-callee convention gave it, which may be fewer than the method actually takes.
                // The stack still has to match the signature, so anything missing gets a placeholder.
                var availableArgs = instruction.Operands.Count - callParamIndex;
                for (var i = 0; i < targetMethod.Parameters.Count; i++)
                {
                    var parameterType = targetMethod.Parameters[i].ParameterType;

                    if (i < availableArgs)
                        LoadOperand(instruction.Operands[callParamIndex + i], context, method, locals, writeLine, stringCtor, parameterType);
                    else
                        PushDefaultOf(parameterType, instructions);
                }

                instructions.Add(CilOpCodes.Call, importedMethod);

                if (instruction.OpCode == OpCode.Call) // Store return value
                    StoreToOperand(instruction.Operands[1], context, method, locals, writeLine);

                break;

            case OpCode.IndirectCall:
                instructions.Add(CilOpCodes.Ldstr, $"Indirect call: {instruction} (should have been resolved before IL gen)");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;

            case OpCode.Return:
                if (!context.IsVoid)
                {
                    if (instruction.Operands.Count == 1)
                        LoadOperand(instruction.Operands[0], context, method, locals, writeLine, stringCtor, context.ReturnType);
                    else
                        instructions.Add(CilOpCodes.Ldnull); // ret still pops a value even if we lost track of it
                }
                instructions.Add(CilOpCodes.Ret);
                break;

            case OpCode.Jump:
                instructions.Add(CilOpCodes.Br, new CilInstructionLabel());
                break;

            case OpCode.ConditionalJump:
                LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor);
                instructions.Add(CilOpCodes.Brtrue, new CilInstructionLabel());
                break;

            case OpCode.IndirectJump:
                instructions.Add(CilOpCodes.Ldstr, $"Indirect jump: {instruction} (should have been resolved before IL gen)");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;

            case OpCode.ShiftStack:
                instructions.Add(CilOpCodes.Ldstr, $"Stack shift: {instruction} (stack analysis should have removed these)");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;

            case OpCode.CheckEqual:
            case OpCode.CheckGreater:
            case OpCode.CheckLess:
            case OpCode.CheckNotEqual:
            case OpCode.CheckGreaterOrEqual:
            case OpCode.CheckLessOrEqual:

            case OpCode.Add:
            case OpCode.Subtract:
            case OpCode.Multiply:
            case OpCode.Divide:

            case OpCode.ShiftLeft:
            case OpCode.ShiftRight:

            case OpCode.And:
            case OpCode.Or:
            case OpCode.Xor:
                LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor);
                LoadOperand(instruction.Operands[2], context, method, locals, writeLine, stringCtor);

                switch (instruction.OpCode)
                {
                    case OpCode.CheckEqual: instructions.Add(CilOpCodes.Ceq); break;
                    case OpCode.CheckGreater: instructions.Add(CilOpCodes.Cgt); break;
                    case OpCode.CheckLess: instructions.Add(CilOpCodes.Clt); break;

                    // a != b  ==  (a == b) == 0
                    case OpCode.CheckNotEqual:
                        instructions.Add(CilOpCodes.Ceq);
                        instructions.Add(CilOpCodes.Ldc_I4_0);
                        instructions.Add(CilOpCodes.Ceq);
                        break;
                    // a >= b  ==  !(a < b)
                    case OpCode.CheckGreaterOrEqual:
                        instructions.Add(CilOpCodes.Clt);
                        instructions.Add(CilOpCodes.Ldc_I4_0);
                        instructions.Add(CilOpCodes.Ceq);
                        break;
                    // a <= b  ==  !(a > b)
                    case OpCode.CheckLessOrEqual:
                        instructions.Add(CilOpCodes.Cgt);
                        instructions.Add(CilOpCodes.Ldc_I4_0);
                        instructions.Add(CilOpCodes.Ceq);
                        break;

                    case OpCode.Add: instructions.Add(CilOpCodes.Add); break;
                    case OpCode.Subtract: instructions.Add(CilOpCodes.Sub); break;
                    case OpCode.Multiply: instructions.Add(CilOpCodes.Mul); break;
                    case OpCode.Divide: instructions.Add(CilOpCodes.Div); break;

                    case OpCode.ShiftLeft: instructions.Add(CilOpCodes.Shl); break;
                    case OpCode.ShiftRight: instructions.Add(CilOpCodes.Shr); break;

                    case OpCode.And: instructions.Add(CilOpCodes.And); break;
                    case OpCode.Or: instructions.Add(CilOpCodes.Or); break;
                    case OpCode.Xor: instructions.Add(CilOpCodes.Xor); break;
                }

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.Not:
            case OpCode.Negate:
                LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stringCtor);

                if (instruction.OpCode == OpCode.Negate)
                    instructions.Add(CilOpCodes.Neg);
                else if (IsBoolean(instruction.Operands[1], context))
                {
                    instructions.Add(CilOpCodes.Ldc_I4_0);
                    instructions.Add(CilOpCodes.Ceq);
                }
                else
                    instructions.Add(CilOpCodes.Not);

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            default:
                instructions.Add(CilOpCodes.Ldstr, $"Unknown instruction: {instruction}");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                break;
        }

        return instructions.ToList().GetRange(startIndex, instructions.Count - startIndex); // Return added IL
    }

    // Try find the follow up CallVoid for a constructor, after a Newobj.
    private static Instruction? FindConstructorCall(MethodAnalysisContext context, Instruction newobj)
    {
        var newObject = newobj.Operands[0];

        foreach (var block in context.ControlFlowGraph!.Blocks)
        {
            var index = block.Instructions.IndexOf(newobj);
            if (index < 0)
                continue;

            for (var i = index + 1; i < block.Instructions.Count; i++)
            {
                var candidate = block.Instructions[i];
                if (candidate is { OpCode: OpCode.CallVoid, Operands: [MethodAnalysisContext { Name: ".ctor" }, _, ..] }
                    && ReferenceEquals(candidate.Operands[1], newObject))
                    return candidate;
            }

            return null;
        }

        return null;
    }

    private static void LoadOperand(IOperand operand, MethodAnalysisContext context, MethodDefinition method,
        Dictionary<LocalVariable, CilLocalVariable> locals, MemberReference writeLine, MemberReference stringCtor,
        TypeAnalysisContext? expectedType = null)
    {
        var instructions = method.CilMethodBody!.Instructions;

        var module = method.DeclaringModule!;
        var importer = module.DefaultImporter!;

        // A null reference reaches us as an integer zero, which would otherwise be emitted as a literal 0
        // and read back as a cast from a number.
        if (expectedType is { IsValueType: false } && IsZeroConstant(operand))
        {
            instructions.Add(CilOpCodes.Ldnull);
            return;
        }

        switch (operand)
        {
            case Immediate { Value: >= int.MinValue and <= int.MaxValue } immediate:
                instructions.Add(CilOpCodes.Ldc_I4, (int)immediate.Value);
                break;
            case Immediate immediate:
                instructions.Add(CilOpCodes.Ldc_I8, immediate.Value);
                break;
            case FloatLiteral f:
                instructions.Add(CilOpCodes.Ldc_R4, f.Value);
                break;
            case DoubleLiteral d:
                instructions.Add(CilOpCodes.Ldc_R8, d.Value);
                break;
            case StringLiteral s:
                instructions.Add(CilOpCodes.Ldstr, s.Value);
                break;
            case LocalVariable local:
                LoadLocal(local, method, locals);
                break;
            case ArrayLength arrayLength:
                LoadLocal(arrayLength.Array, method, locals);
                instructions.Add(CilOpCodes.Ldlen);
                instructions.Add(CilOpCodes.Conv_I4);
                break;
            case AddressOf { Target: LocalVariable addressed }:
                instructions.Add(CilOpCodes.Ldloca, locals[addressed]);
                break;
            case AddressOf { Target: ArrayAccess elementAddress }:
                LoadLocal(elementAddress.Array, method, locals);
                LoadOperand(elementAddress.Index, context, method, locals, writeLine, stringCtor);
                instructions.Add(CilOpCodes.Ldelema,
                    importer.ImportTypeSignature(((SzArrayTypeAnalysisContext)elementAddress.Array.Type!).ElementType.ToTypeSignature(module)).ToTypeDefOrRef());
                break;
            case ArrayAccess arrayAccess:
                LoadLocal(arrayAccess.Array, method, locals);
                LoadOperand(arrayAccess.Index, context, method, locals, writeLine, stringCtor);
                instructions.Add(CilOpCodes.Ldelem,
                    importer.ImportTypeSignature(((SzArrayTypeAnalysisContext)arrayAccess.Array.Type!).ElementType.ToTypeSignature(module)).ToTypeDefOrRef());
                break;
            case FieldReference field:
                if (field.Field.IsStatic)
                {
                    instructions.Add(CilOpCodes.Ldsfld, field.Field.ToFieldDescriptor(module));
                    break;
                }

                LoadLocal(field.Local, method, locals);
                instructions.Add(CilOpCodes.Ldfld, field.Field.ToFieldDescriptor(module));
                break;
            // AssetRipper: change 3. ldfld takes a value type instance on the stack, so a read through
            // the fields a nested access sits inside is just those fields loaded in turn.
            case NestedFieldReference nested:
                LoadLocal(nested.Local, method, locals);

                foreach (FieldAnalysisContext step in nested.Path)
                    instructions.Add(CilOpCodes.Ldfld, step.ToFieldDescriptor(module));

                break;
            case MemoryOperand memory:
                if (memory.Index == null && memory.Addend == 0 && memory.Scale == 0
                    && memory.Base is LocalVariable local2)
                {
                    LoadLocal(local2, method, locals);
                    break;
                }

                // AssetRipper: change 2. A load from a fixed address is usually a metadata usage slot:
                // the il2cpp runtime fills these in at startup with a string literal, an Il2CppClass*, a
                // MethodInfo* or a FieldInfo*. String literals are the only kind expressible in IL, so
                // those become ldstr; the rest keep the null pointer but say what the handle is.
                if (memory.IsConstant && memory.Addend > 0)
                {
                    MetadataUsage? global = ResolveGlobal(context, (ulong)memory.Addend);

                    if (global is { Type: MetadataUsageType.StringLiteral })
                    {
                        instructions.Add(CilOpCodes.Ldstr, global.AsLiteral());
                        break;
                    }

                    if (global != null)
                    {
                        instructions.Add(CilOpCodes.Ldstr, $"Il2Cpp runtime handle: {DescribeGlobal(global)}");
                        instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                        instructions.Add(CilOpCodes.Ldc_I4_0);
                        instructions.Add(CilOpCodes.Conv_I);
                        break;
                    }
                }

                instructions.Add(CilOpCodes.Ldstr, "Unmanaged memory load: " + operand.ToString());
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Conv_I);
                break;
            case RuntimeMethodInfoAnalysisContext runtimeMethod:
                // A delegate constructor takes its target as a native pointer, which is exactly ldftn.
                if (expectedType?.FullName == "System.IntPtr")
                {
                    instructions.Add(CilOpCodes.Ldftn, importer.ImportMethod(runtimeMethod.RepresentedMethod.ToMethodDescriptor(module)));
                    break;
                }

                //Not fully implemented, these basically shouldn't actually ever exist in the final IL.
                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Conv_I);
                break;
            case TypeAnalysisContext type:
                if (type.Name == "T")
                {
                    // idk what to do here
                    instructions.Add(CilOpCodes.Ldstr, "<T>");
                    instructions.Add(CilOpCodes.Newobj, importer.ImportMethod(stringCtor));
                    break;
                }

                // Try to first get constructor without params
                var constructor = type.Methods.FirstOrDefault(m => m.Name == ".ctor" && m.Parameters.Count == 0);
                constructor ??= type.Methods.FirstOrDefault(m => m.Name == ".ctor");

                if (constructor == null)
                {
                    instructions.Add(CilOpCodes.Ldstr, $"Constructor not found for: {operand} (probably static type)");
                    instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                    instructions.Add(CilOpCodes.Ldnull);
                    break;
                }

                foreach (var param2 in constructor.Parameters)
                    instructions.Add(CilOpCodes.Ldstr, "Constructor param: " + param2);
                instructions.Add(CilOpCodes.Newobj, importer.ImportMethod(constructor.ToMethodDescriptor(module)));
                break;
            default:
                instructions.Add(CilOpCodes.Ldstr, "Unknown operand: " + operand.ToString());
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                instructions.Add(CilOpCodes.Ldnull);
                break;
        }
    }

    /// <summary>
    /// AssetRipper: change 2. Reads the metadata usage stored at <paramref name="address"/>, if there
    /// is one. Never throws: a fixed address in a method body is only a guess at a usage slot, and
    /// most of them are not one.
    /// </summary>
    private static MetadataUsage? ResolveGlobal(MethodAnalysisContext context, ulong address)
    {
        LibCpp2IlContext lib = context.AppContext.LibCpp2IlContext;

        try
        {
            MetadataUsage? direct = lib.GetAnyGlobalByAddress(address);

            if (direct?.IsValid == true)
                return direct;

            // Pre-27 metadata puts one indirection in the way: the address baked into the code is a
            // per-module pointer holding the address of the usage slot, and only that second address is
            // the one the usage dictionaries are keyed by. Post-27 GetAnyGlobalByAddress already reads
            // through the address itself, so this would be a second, wrong dereference.
            if (lib.Metadata.MetadataVersion >= 27f)
                return null;

            if (!lib.Binary.TryMapVirtualAddressToRaw(address, out long raw) || raw >= lib.Binary.RawLength)
                return null;

            ulong slot = lib.Binary.ReadPointerAtVirtualAddress(address);

            if (slot == 0)
                return null;

            MetadataUsage? indirect = lib.GetAnyGlobalByAddress(slot);
            return indirect?.IsValid == true ? indirect : null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>AssetRipper: change 2. Names a runtime handle that has no IL equivalent.</summary>
    private static string DescribeGlobal(MetadataUsage global)
    {
        try
        {
            return global.Type switch
            {
                MetadataUsageType.Type or MetadataUsageType.TypeInfo => $"typeof({global.AsType()})",
                MetadataUsageType.MethodDef => $"methodof({Describe(global.AsMethod())})",
                MetadataUsageType.MethodRef => $"methodof({global.AsGenericMethodRef()})",
                MetadataUsageType.FieldInfo => $"fieldof({global.AsField().DeclaringType?.FullName}.{global.AsField().Name})",
                _ => global.Type.ToString(),
            };
        }
        catch
        {
            return global.Type.ToString();
        }
    }

    private static string Describe(Il2CppMethodDefinition method)
        => $"{method.DeclaringType?.FullName}::{method.HumanReadableSignature}";

    private static void PushDefaultOf(TypeAnalysisContext type, CilInstructionCollection instructions)
    {
        //TODO Remove this, we should be handling arguments correctly in ISIL resolution, this is a hack to emit balanced stacks.
        //TODO At the *very* least we should emit a console.writeline saying that we did this.
        if (!type.IsValueType)
        {
            instructions.Add(CilOpCodes.Ldnull);
            return;
        }

        switch (type.FullName)
        {
            case "System.Single": instructions.Add(CilOpCodes.Ldc_R4, 0f); break;
            case "System.Double": instructions.Add(CilOpCodes.Ldc_R8, 0d); break;
            case "System.Int64" or "System.UInt64": instructions.Add(CilOpCodes.Ldc_I8, 0L); break;
            default: instructions.Add(CilOpCodes.Ldc_I4_0); break;
        }
    }

    private static bool IsBoolean(IOperand operand, MethodAnalysisContext context) =>
        operand is LocalVariable { Type: { } type } && type == context.AppContext.SystemTypes.SystemBooleanType;

    private static bool IsZeroConstant(IOperand operand) => operand is Immediate { Value: 0 };
    
    private static TypeAnalysisContext? DestinationType(IOperand destination) =>
        destination switch
        {
            LocalVariable local => local.Type,
            FieldReference field => field.Field.FieldType,
            NestedFieldReference nested => nested.Path[^1].FieldType, // AssetRipper: change 3
            ArrayAccess { Array.Type: SzArrayTypeAnalysisContext array } => array.ElementType,
            _ => null
        };

    private static void LoadLocal(LocalVariable local, MethodDefinition method, Dictionary<LocalVariable, CilLocalVariable> locals)
    {
        var instructions = method.CilMethodBody!.Instructions;

        if (local.IsThis)
        {
            instructions.Add(CilOpCodes.Ldarg_0);
            return;
        }

        var parameter = method.Parameters.FirstOrDefault(p => p.Name == local.Name);

        if (parameter != null)
            instructions.Add(CilOpCodes.Ldarg, parameter);
        else
            instructions.Add(CilOpCodes.Ldloc, locals[local]);
    }

    private static void StoreToOperand(IOperand operand, MethodAnalysisContext context, MethodDefinition method,
        Dictionary<LocalVariable, CilLocalVariable> locals, MemberReference writeLine)
    {
        var instructions = method.CilMethodBody!.Instructions;

        var module = method.DeclaringModule!;
        var importer = module.DefaultImporter!;

        switch (operand)
        {
            case LocalVariable local:
                instructions.Add(CilOpCodes.Stloc, locals[local]);
                break;

            case FieldReference field:
                var fieldDescriptor = field.Field.ToFieldDescriptor(module);

                if (field.Field.IsStatic)
                {
                    instructions.Add(CilOpCodes.Stsfld, fieldDescriptor);
                    break;
                }

                // stfld wants the object underneath the value, but the value is already on the stack, so
                // park it in a temporary while we load the object.
                var scratch = new CilLocalVariable(fieldDescriptor.Signature!.FieldType);
                method.CilMethodBody!.LocalVariables.Add(scratch);

                instructions.Add(CilOpCodes.Stloc, scratch);
                LoadLocal(field.Local, method, locals);
                instructions.Add(CilOpCodes.Ldloc, scratch);
                instructions.Add(CilOpCodes.Stfld, fieldDescriptor);
                break;

            // AssetRipper: change 3. Same trick, except the containing fields are taken by address so
            // the write lands in the object rather than in a copy of the value type.
            case NestedFieldReference nested:
                IFieldDescriptor nestedDescriptor = nested.Path[^1].ToFieldDescriptor(module);
                CilLocalVariable nestedScratch = new(nestedDescriptor.Signature!.FieldType);
                method.CilMethodBody!.LocalVariables.Add(nestedScratch);

                instructions.Add(CilOpCodes.Stloc, nestedScratch);
                LoadLocal(nested.Local, method, locals);

                for (int i = 0; i < nested.Path.Count - 1; i++)
                    instructions.Add(CilOpCodes.Ldflda, nested.Path[i].ToFieldDescriptor(module));

                instructions.Add(CilOpCodes.Ldloc, nestedScratch);
                instructions.Add(CilOpCodes.Stfld, nestedDescriptor);
                break;

            case ArrayAccess arrayAccess:
                // stelem needs array and index before the value, so the same trick as stfld
                var elementType = ((SzArrayTypeAnalysisContext)arrayAccess.Array.Type!).ElementType;
                var elementScratch = new CilLocalVariable(elementType.ToTypeSignature(module));
                method.CilMethodBody!.LocalVariables.Add(elementScratch);

                instructions.Add(CilOpCodes.Stloc, elementScratch);
                LoadLocal(arrayAccess.Array, method, locals);
                LoadOperand(arrayAccess.Index, context, method, locals, writeLine, writeLine);
                instructions.Add(CilOpCodes.Ldloc, elementScratch);
                instructions.Add(CilOpCodes.Stelem, importer.ImportTypeSignature(elementType.ToTypeSignature(module)).ToTypeDefOrRef());
                break;

            case MemoryOperand memory:
                if (memory.Index == null && memory.Addend == 0 && memory.Scale == 0
                    && memory.Base is LocalVariable local2)
                {
                    // Can pointer assignments just be ignored because it's C#? (Move [local], 123)
                    instructions.Add(CilOpCodes.Stloc, locals[local2]);
                    break;
                }
                instructions.Add(CilOpCodes.Pop);
                break;

            default:
                instructions.Add(CilOpCodes.Ldstr, $"Store into unknown operand: {operand}");
                instructions.Add(CilOpCodes.Call, importer.ImportMethod(writeLine));
                instructions.Add(CilOpCodes.Pop);
                break;
        }
    }
}
