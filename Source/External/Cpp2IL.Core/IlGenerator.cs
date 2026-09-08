using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;
using Cpp2IL.Core.Utils.AsmResolver;
using LibCpp2IL;
using LibCpp2IL.Metadata;

namespace Cpp2IL.Core;

public static class IlGenerator
{
    private const string HelpersNamespace = "Cpp2ILInjected";
    private const string HelpersTypeName = "Cpp2ILHelpers";
    private const string NoteIssueMethodName = "NoteDecompilerIssue";

    public static void InjectHelpersType(ApplicationAnalysisContext appContext)
    {
        var helpersType = appContext.InjectTypeIntoAllAssemblies(
            HelpersNamespace,
            HelpersTypeName,
            null,
            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Abstract | TypeAttributes.Sealed);

        helpersType.InjectMethodToAllAssemblies(
            NoteIssueMethodName,
            appContext.SystemTypes.SystemVoidType,
            MethodAttributes.Public | MethodAttributes.Static,
            [appContext.SystemTypes.SystemStringType]);
    }

    public static void GenerateIl(MethodAnalysisContext context, MethodDefinition definition)
    {
        var assembly = context.DeclaringType!.DeclaringAssembly;
        var module = definition.DeclaringModule!;
        var factory = module.CorLibTypeFactory;

        var noteIssueContext = assembly
            .GetTypeByFullName($"{HelpersNamespace}.{HelpersTypeName}")?.Methods.FirstOrDefault(m => m.Name == NoteIssueMethodName);

        var writeLine = noteIssueContext != null
            ? noteIssueContext.ToMethodDescriptor()
            : factory.CorLibScope
                .CreateTypeReference("System", "Console")
                .CreateMemberReference("WriteLine", MethodSignature.CreateStatic(factory.Void, [factory.String]));

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
        // AssetRipper: over every block, not ControlFlowGraph.Instructions, which is a walk from the
        // entry block and so misses an unreachable one. Code generation below emits every block, so a
        // local first seen in an unreachable one had no slot and the lookup threw, losing the body.
        foreach (var operand in context.ControlFlowGraph.Blocks.SelectMany(b => b.Instructions).SelectMany(i => i.Operands))
            CollectLocals(operand);

        // AssetRipper: recursive, because an index can itself be an element access - `a[b[i]]` hid the
        // inner array from this walk, and the lookup for a local with no slot threw and lost the body.
        void CollectLocals(IOperand operand)
        {
            switch (operand)
            {
                case LocalVariable local:
                    Declare(local);
                    break;
                case FieldReference field:
                    Declare(field.Local);
                    break;
                case MemoryOperand { Base: LocalVariable memoryBase } memory:
                    Declare(memoryBase);
                    if (memory.Index is LocalVariable memoryIndex)
                        Declare(memoryIndex);
                    break;
                case ArrayAccess arrayAccess:
                    Declare(arrayAccess.Array);
                    CollectLocals(arrayAccess.Index);
                    break;
                case ArrayLength arrayLength:
                    Declare(arrayLength.Array);
                    break;
                case AddressOf addressOf:
                    CollectLocals(addressOf.Target);
                    break;
            }
        }

        void Declare(LocalVariable local)
        {
            if (!context.Locals.Contains(local))
                context.Locals.Add(local);
        }

        // Map ISIL locals to IL
        Dictionary<LocalVariable, CilLocalVariable> locals = [];
        foreach (var local in context.Locals)
        {
            TypeSignature ilType;

            // Use object if type couldn't be determined, or if it's void, which no locals sig can hold
            if (local.Type != null && local.Type != context.AppContext.SystemTypes.SystemVoidType)
                ilType = local.Type.ToTypeSignature();
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
                var generated = GenerateInstructions(instruction, context, definition, locals, writeLine);
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
            instructions.Add(CilOpCodes.Ldstr, Diagnostic("Warning: " + warning));
            instructions.Add(CilOpCodes.Call, writeLine);
        }

        EnsureTerminated(context, instructions);
    }

    /// <summary>
    /// Guarantees the body ends in a terminating instruction.
    /// </summary>
    /// <remarks>
    /// A block whose only successor is the exit block gets no bridge branch, and the warnings appended
    /// above end in a call, so a body can otherwise run off its own end. That is not valid IL: reading
    /// it walks past the last instruction, which surfaces as a stack imbalance reported at an offset one
    /// byte past the final call, and the whole body is then discarded.
    /// </remarks>
    private static void EnsureTerminated(MethodAnalysisContext context, CilInstructionCollection instructions)
    {
        if (instructions.Count > 0 && instructions[^1].OpCode.Code is CilCode.Ret or CilCode.Throw or CilCode.Br or CilCode.Br_S or CilCode.Rethrow or CilCode.Endfinally)
            return;

        // The value a missing return would have produced is exactly what could not be recovered, so a
        // default stands in for it rather than the body being thrown away over it.
        if (!context.IsVoid)
            PushDefaultOf(context.ReturnType, instructions);

        instructions.Add(CilOpCodes.Ret);
    }

    /// <summary>
    /// AssetRipper: raised for every memory operand that becomes an <c>Unmanaged memory load</c>
    /// placeholder. Runs on the body-generation threads, so a handler has to be thread safe.
    /// </summary>
    public static Action<MethodAnalysisContext, IOperand>? UnresolvedMemoryLoad;

    /// <summary>
    /// AssetRipper: writes a call to a private framework method as the public one it is the inside of.
    /// </summary>
    /// <remarks>
    /// <para>
    /// il2cpp inlines the public wrapper, so the recovered code names the implementation:
    /// <c>Quaternion.Euler(0f, y, 0f)</c> comes back as <c>Quaternion.Internal_FromEulerRad(euler)</c>,
    /// which is private and so not a member an exported script can name.
    /// </para>
    /// <para>
    /// Unlike the field case this needs to know what the wrapper did — Euler takes degrees where the
    /// method it calls takes radians — so it is a table rather than a rule. The references are built
    /// by name rather than looked up in the model, because managed stripping removes the wrapper from
    /// the game's copy of the framework and the assembly the exported script is compiled against still
    /// has it.
    /// </para>
    /// </remarks>
    private static bool EmitInlinedFrameworkCall(MethodAnalysisContext target, Instruction instruction,
        MethodAnalysisContext context, MethodDefinition method, Dictionary<LocalVariable, CilLocalVariable> locals,
        IMethodDescriptor writeLine)
    {
        if (target is not { Name: "Internal_FromEulerRad", DeclaringType.FullName: "UnityEngine.Quaternion" }
            || instruction.OpCode != OpCode.Call || instruction.Operands.Count < 3)
        {
            return false;
        }

        var module = method.DeclaringModule!;
        var quaternion = target.DeclaringType!.ToTypeSignature();
        var vector3 = target.Parameters[0].ParameterType.ToTypeSignature();
        var single = module.CorLibTypeFactory.Single;

        var scale = vector3.ToTypeDefOrRef().CreateMemberReference("op_Multiply",
            MethodSignature.CreateStatic(vector3, [vector3, single]));
        var euler = quaternion.ToTypeDefOrRef().CreateMemberReference("Euler",
            MethodSignature.CreateStatic(quaternion, [vector3]));

        LoadOperand(instruction.Operands[2], context, method, locals, writeLine, target.Parameters[0].ParameterType);
        method.CilMethodBody!.Instructions.Add(CilOpCodes.Ldc_R4, RadiansToDegrees);
        method.CilMethodBody.Instructions.Add(CilOpCodes.Call, scale);
        method.CilMethodBody.Instructions.Add(CilOpCodes.Call, euler);

        StoreToOperand(instruction.Operands[1], context, method, locals, writeLine);
        return true;
    }

    private const float RadiansToDegrees = 57.29578f;

    /// <summary>AssetRipper: how many hidden static fields were read through their public property.</summary>
    public static int HiddenFieldsReadThroughAProperty;

    /// <summary>
    /// AssetRipper: the public getter to read a non-public static field through, when the type has one.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A property whose getter does nothing but return a static field is inlined, so the recovered
    /// code names the field. That reads worse than the property and, in an exported script compiled
    /// against the real framework assemblies rather than the recovered ones, does not compile at all:
    /// <c>Quaternion.identityQuaternion</c> is private, so it is not a member the script can name.
    /// </para>
    /// <para>
    /// The pairing is a convention rather than something the metadata records — the framework's
    /// bodies are native, so there is no getter to read — but it is a narrow one: the property is
    /// public and static, has the field's exact type, and its name is a prefix of the field's.
    /// <c>identityQuaternion</c> is read through <c>identity</c>, <c>zeroVector</c> through
    /// <c>zero</c>, <c>positiveInfinityVector</c> through <c>positiveInfinity</c>.
    /// </para>
    /// </remarks>
    private static MethodAnalysisContext? PublicAccessorFor(FieldAnalysisContext field)
    {
        if ((field.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public)
            return null;

        var owner = field.DeclaringType;

        if (owner == null)
            return null;

        foreach (var property in owner.Properties)
        {
            if (property.Getter is not { IsStatic: true } getter
                || (getter.Attributes & MethodAttributes.MemberAccessMask) != MethodAttributes.Public
                || getter.Parameters.Count != 0)
                continue;

            if (property.Name.Length < 3 || property.Name.Length >= field.Name.Length
                || !field.Name.StartsWith(property.Name, StringComparison.Ordinal))
                continue;

            if (getter.ReturnType.FullName == field.FieldType.FullName)
                return getter;
        }

        return null;
    }

    // The instance property that returns each non-public instance field, measured once from the getter.
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<FieldAnalysisContext, MethodAnalysisContext?> InstanceAccessors = new();

    /// <summary>
    /// AssetRipper: the public instance property whose getter returns nothing but
    /// <paramref name="field"/>, or null when there is none.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A trivial property is inlined, so the field is what the body names: <c>button.onClick</c>
    /// recovers as <c>button.m_OnClick</c> and <c>stack.Count</c> as <c>stack._size</c>. Against the
    /// recovered assemblies that is fine; against the real ones it is a private member of a framework
    /// type, and the export is compiled against those.
    /// </para>
    /// <para>
    /// The pairing is measured rather than guessed from the name. <c>m_OnClick</c> and <c>onClick</c>
    /// differ by a convention, <c>_size</c> and <c>Count</c> by nothing at all, and a name rule that
    /// covered the second would pair fields with properties that merely sound alike. Reading the
    /// getter's own body is exact: a getter that is one field load and a return is that field's
    /// accessor, whatever either is called.
    /// </para>
    /// </remarks>
    private static MethodAnalysisContext? InstanceAccessorFor(FieldAnalysisContext field)
        => InstanceAccessors.GetOrAdd(field, static toMeasure =>
        {
            if ((toMeasure.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public
                || toMeasure.IsStatic || toMeasure.DeclaringType is not { } owner)
                return null;

            foreach (var property in owner.Properties)
            {
                if (property.Getter is not { IsStatic: false } getter
                    || (getter.Attributes & MethodAttributes.MemberAccessMask) != MethodAttributes.Public
                    || getter.Parameters.Count != 0 || getter.UnderlyingPointer == 0
                    || getter.ReturnType.FullName != toMeasure.FieldType.FullName)
                    continue;

                if (ReturnsNothingButTheField(getter, toMeasure))
                    return getter;
            }

            return null;
        });

    // Whether the getter's whole body is "load this field and return it".
    private static bool ReturnsNothingButTheField(MethodAnalysisContext getter, FieldAnalysisContext field)
    {
        if (field.BackingData?.FieldOffset is not { } fieldOffset)
            return false;

        var offset = (long)fieldOffset;

        List<Instruction> isil;

        try
        {
            isil = getter.AppContext.InstructionSet.GetIsilFromMethod(getter);
        }
        catch
        {
            return false;
        }

        var loaded = false;

        foreach (var instruction in isil)
        {
            switch (instruction.OpCode)
            {
                case OpCode.Nop or OpCode.Interrupt:
                    continue;

                // the field load, off the receiver register, at the field's own offset
                case OpCode.Move when !loaded && instruction.Operands is [Register, MemoryOperand { Index: null, Scale: 0 } source]
                    && source.Base is Register { Name: "X0" } && source.Addend == offset:
                    loaded = true;
                    continue;

                case OpCode.Return when loaded:
                    continue;

                default:
                    return false;
            }
        }

        return loaded;
    }

    // Limit so we don't run into the 16mb limit (see AsmResolver issue #775)
    private static string Diagnostic(string message) 
        => message.Length <= 250 ? message : message[..250] + "…";
    
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
        MethodDefinition method, Dictionary<LocalVariable, CilLocalVariable> locals, IMethodDescriptor writeLine)
    {
        var body = method.CilMethodBody!;
        var instructions = body.Instructions;
        var currentCount = instructions.Count;
        var startIndex = instructions.Count;

        var module = method.DeclaringModule!;

        // AssetRipper: one field store of a constant float, used to split a paired eight byte store.
        void EmitFieldStore(FieldReference target, float value)
        {
            if (!target.Field.IsStatic)
            {
                LoadLocal(target.Local, method, locals);
                LoadContainingFields(target, instructions);
            }

            instructions.Add(CilOpCodes.Ldc_R4, value);
            instructions.Add(target.Field.IsStatic ? CilOpCodes.Stsfld : CilOpCodes.Stfld, target.Field.ToFieldDescriptor());
        }

        // AssetRipper: one field store of a byte slice of a wider value, used to split a store wider than
        // its field when the value is computed rather than constant.
        void EmitSlicedFieldStore(FieldReference target, IOperand value, int byteOffset, int width)
        {
            if (!target.Field.IsStatic)
            {
                LoadLocal(target.Local, method, locals);
                LoadContainingFields(target, instructions);
            }

            LoadOperand(value, context, method, locals, writeLine);

            if (byteOffset > 0)
            {
                instructions.Add(CilOpCodes.Ldc_I4, byteOffset * 8);
                instructions.Add(CilOpCodes.Shr_Un);
            }

            if (width < 4)
            {
                instructions.Add(CilOpCodes.Ldc_I4, (1 << (width * 8)) - 1);
                instructions.Add(CilOpCodes.And);
            }

            if (target.Field.FieldType.FullName == "System.Boolean")
            {
                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Cgt_Un);
            }

            instructions.Add(target.Field.IsStatic ? CilOpCodes.Stsfld : CilOpCodes.Stfld, target.Field.ToFieldDescriptor());
        }

        // AssetRipper: one field store of a constant integer, used to split a store wider than its field.
        void EmitIntegerFieldStore(FieldReference target, long value)
        {
            if (!target.Field.IsStatic)
            {
                LoadLocal(target.Local, method, locals);
                LoadContainingFields(target, instructions);
            }

            if (PrimitiveFieldWidth(target.Field.FieldType) == 8)
                instructions.Add(CilOpCodes.Ldc_I8, value);
            else
                instructions.Add(CilOpCodes.Ldc_I4, (int)value);

            instructions.Add(target.Field.IsStatic ? CilOpCodes.Stsfld : CilOpCodes.Stfld, target.Field.ToFieldDescriptor());
        }

        switch (instruction.OpCode)
        {
            case OpCode.Invalid:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Invalid instruction: {instruction}"));
                instructions.Add(CilOpCodes.Call, writeLine);
                break;

            case OpCode.NotImplemented:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Not implemented instruction: {instruction.Operands[0]}"));
                instructions.Add(CilOpCodes.Call, writeLine);
                break;

            case OpCode.Interrupt:
            case OpCode.Nop:
                instructions.Add(CilOpCodes.Nop);
                break;

            case OpCode.Move:
                // AssetRipper: two adjacent float fields initialised by one eight byte store, which is
                // how a constructor sets a pair of them. The value is a double only by accident of its
                // width: it is the two floats side by side, and stored as a double the first field got
                // the pair's bit pattern as a number and the second got nothing at all.
                if (instruction.Operands is [FieldReference { Field.FieldType.FullName: "System.Single" } pairHead, DoubleLiteral pair]
                    && AdjacentSingleField(pairHead) is { } pairTail)
                {
                    var bits = BitConverter.DoubleToInt64Bits(pair.Value);

                    EmitFieldStore(pairHead, BitConverter.Int32BitsToSingle((int)bits));
                    EmitFieldStore(new FieldReference(pairTail, pairHead.Local, pairHead.Offset + 4), BitConverter.Int32BitsToSingle((int)(bits >> 32)));
                    break;
                }

                // AssetRipper: a store can be wider than the field its offset names. Two adjacent bools
                // are written by one strh, and taking the store at the head field's width dropped every
                // field past the first - `Movement.right` was never assigned anywhere in the class, so
                // the branch reading it was unreachable and the character could only move one way.
                if (instruction.Operands is [FieldReference { AccessSize: >= 2 } packedHead, { } packedValue]
                    && PackedFieldsCovered(packedHead) is { } packed)
                {
                    foreach (var (member, byteOffset, width) in packed)
                    {
                        var slot = new FieldReference(member, packedHead.Local, packedHead.Offset + byteOffset);

                        if (packedValue is Immediate constant)
                        {
                            var mask = width >= 8 ? -1L : (1L << (width * 8)) - 1;
                            EmitIntegerFieldStore(slot, (constant.Value >> (byteOffset * 8)) & mask);
                        }
                        else
                        {
                            EmitSlicedFieldStore(slot, packedValue, byteOffset, width);
                        }
                    }

                    break;
                }

                // AssetRipper: a value type local zeroed by an integer 0. The machine clears the slot,
                // and storing a 0 into it emitted `(Stack<object>.Enumerator)0` - a cast from an int to
                // a struct, which is not a conversion C# has. `initobj` is what zeroing a value type is.
                if (instruction.Operands is [LocalVariable { Type: { IsValueType: true } zeroed } zeroedLocal, Immediate { Value: 0 }]
                    && !IsFloat(zeroed) && PrimitiveFieldWidth(zeroed) == 0
                    && locals.TryGetValue(zeroedLocal, out var zeroedIl))
                {
                    instructions.Add(CilOpCodes.Ldloca, zeroedIl);
                    instructions.Add(CilOpCodes.Initobj, zeroed.ToTypeSignature().ToTypeDefOrRef());
                    break;
                }

                if (instruction.Operands[0] is FieldReference field) // stfld takes instance before value so LoadOperand StoreToOperand doesn't work
                {
                    if (!field.Field.IsStatic)
                    {
                        LoadLocal(field.Local, method, locals);
                        LoadContainingFields(field, instructions);
                    }

                    LoadOperand(instruction.Operands[1], context, method, locals, writeLine, field.Field.FieldType);
                    instructions.Add(field.Field.IsStatic ? CilOpCodes.Stsfld : CilOpCodes.Stfld, field.Field.ToFieldDescriptor());
                    break;
                }

                // stelem needs array and index before the value, so like stfld it can't go through LoadOperand/StoreToOperand.
                // This also lets ILSpy handle it as a proper array initializer
                if (instruction.Operands[0] is ArrayAccess { Array.Type: SzArrayTypeAnalysisContext { ElementType: { } stored } } target)
                {
                    LoadLocal(target.Array, method, locals);
                    LoadOperand(target.Index, context, method, locals, writeLine);
                    LoadOperand(instruction.Operands[1], context, method, locals, writeLine, stored);
                    instructions.Add(CilOpCodes.Stelem, stored.ToTypeSignature().ToTypeDefOrRef());
                    break;
                }

                LoadOperand(instruction.Operands[1], context, method, locals, writeLine, DestinationType(instruction.Operands[0]));
                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.NewArr:
                if (instruction.Operands is [_, SzArrayTypeAnalysisContext { ElementType: { } newArrayElement }, { } length])
                {
                    LoadOperand(length, context, method, locals, writeLine);
                    instructions.Add(CilOpCodes.Newarr, newArrayElement.ToTypeSignature().ToTypeDefOrRef());
                }
                else
                    instructions.Add(CilOpCodes.Ldnull);

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.Newobj:
                // Try and fuse our Newobj + the follow up constructor CallVoid into one IL newobj.
                // If we can't, just fall back to an Ldnull.
                if (FindConstructorCall(context, instruction) is { Operands: [MethodAnalysisContext found, _, ..] } constructorCall
                    && ConstructorFor(instruction.Operands.Count > 1 ? instruction.Operands[1] : null, found) is { } constructor)
                {
                    // Operands run [ctor, newObject, arguments..., methodInfo], so take only as many as
                    // the constructor declares (i.e. drop methodInfo)
                    var constructorArgs = constructorCall.Operands.Skip(ConstructorReceiverIndex(constructorCall) + 1).Take(constructor.Parameters.Count).ToList();
                    for (var i = 0; i < constructorArgs.Count; i++)
                        LoadOperand(constructorArgs[i], context, method, locals, writeLine, constructor.Parameters[i].ParameterType);

                    instructions.Add(CilOpCodes.Newobj, constructor.ToMethodDescriptor());
                    StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);

                    constructorCall.OpCode = OpCode.Nop;
                    constructorCall.SetOperands();
                }
                // AssetRipper: the constructor was inlined into the allocation; see InlinedConstructor.
                else if (instruction.Operands is [_, TypeAnalysisContext inlinedOwner]
                    && InlinedConstructor(context, instruction, inlinedOwner, out var inlinedStores) is { } inlinedCtor)
                {
                    for (var i = 0; i < inlinedStores.Count; i++)
                        LoadOperand(inlinedStores[i].Operands[1], context, method, locals, writeLine, inlinedCtor.Parameters[i].ParameterType);

                    instructions.Add(CilOpCodes.Newobj, inlinedCtor.ToMethodDescriptor());
                    StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);

                    foreach (var store in inlinedStores)
                    {
                        store.OpCode = OpCode.Nop;
                        store.SetOperands();
                    }

                    if (FindConstructorCall(context, instruction) is { } baseCall)
                    {
                        baseCall.OpCode = OpCode.Nop;
                        baseCall.SetOperands();
                    }
                }
                else if (instruction.Operands is [_, TypeAnalysisContext allocatedType] && allocatedType.Methods.FirstOrDefault(m => m is { Name: ".ctor", Parameters.Count: 0 }) is { } parameterlessCtor)
                {
                    // Nothing to fuse with, so the allocation was self-contained. The type is still right, so construct it bare.
                    instructions.Add(CilOpCodes.Newobj, parameterlessCtor.ToMethodDescriptor());
                    StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                }
                else
                {
                    instructions.Add(CilOpCodes.Ldnull);
                    StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                }
                break;

            // AssetRipper: the inlined hierarchy walk, recovered into the cast it was.
            case OpCode.IsInst:
                if (instruction.Operands is [_, TypeAnalysisContext checkedType, var checkedValue])
                {
                    LoadOperand(checkedValue, context, method, locals, writeLine);
                    instructions.Add(CilOpCodes.Isinst, checkedType.ToTypeSignature().ToTypeDefOrRef());
                }
                else
                    instructions.Add(CilOpCodes.Ldnull);

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.Box:
                if (instruction.Operands is [_, TypeAnalysisContext boxedType, var boxedValue])
                {
                    // il2cpp_value_box takes the value by address, but IL boxes it by value
                    LoadOperand(boxedValue is AddressOf { Target: LocalVariable byRef } ? byRef : boxedValue, context, method, locals, writeLine, boxedType);
                    instructions.Add(CilOpCodes.Box, boxedType.ToTypeSignature().ToTypeDefOrRef());
                }
                else
                    instructions.Add(CilOpCodes.Ldnull);

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            // AssetRipper: the ABI spread this value over several registers on the way in; each member
            // is stored back into its field, which is the value the call was really passed.
            case OpCode.MakeStruct:
                if (instruction.Operands is [LocalVariable composed, TypeAnalysisContext composedType, ..]
                    && locals.TryGetValue(composed, out var composedLocal))
                {
                    var composedFields = composedType.Fields.Where(f => !f.IsStatic).ToList();

                    for (var member = 0; member < composedFields.Count && member + 2 < instruction.Operands.Count; member++)
                    {
                        instructions.Add(CilOpCodes.Ldloca, composedLocal);
                        LoadOperand(instruction.Operands[member + 2], context, method, locals, writeLine, composedFields[member].FieldType);
                        instructions.Add(CilOpCodes.Stfld, composedFields[member].ToFieldDescriptor());
                    }
                }

                break;

            case OpCode.Throw:
                if (instruction.Operands is [TypeAnalysisContext exceptionType]
                    && exceptionType.Methods.FirstOrDefault(m => m.Name == ".ctor" && m.Parameters.Count == 0) is { } exceptionCtor)
                    instructions.Add(CilOpCodes.Newobj, exceptionCtor.ToMethodDescriptor());
                else if (instruction.Operands is [LocalVariable or FieldReference])
                    LoadOperand(instruction.Operands[0], context, method, locals, writeLine); // an already-constructed exception
                else
                    instructions.Add(CilOpCodes.Ldnull);

                instructions.Add(CilOpCodes.Throw);
                break;

            case OpCode.Phi:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Phi opcodes should not exist at this point in decompilation ({instruction})"));
                instructions.Add(CilOpCodes.Call, writeLine);
                break;

            case OpCode.Call:
            case OpCode.CallVoid:
                // The lifter resolves a call target, uses it, and then keeps only the address, so a
                // method the model knows perfectly well arrives here as a bare number. Looking it up
                // again turns a "Method not found" diagnostic into the call it actually is. Only an
                // unambiguous address is taken: identical bodies get folded onto one address, and
                // generic sharing puts dozens of methods there, where any single pick would be wrong.
                if (instruction.Operands[0] is Immediate resolvableAddress
                    && context.AppContext.MethodsByAddress.TryGetValue(resolvableAddress.UnsignedValue, out var candidates)
                    && candidates.Count == 1)
                {
                    instruction.SetOperand(0, candidates[0]);
                }

                if (instruction.Operands[0] is not MethodAnalysisContext targetMethod)
                {
                    if (instruction.Operands[0] is Immediate targetAddress)
                        instructions.Add(CilOpCodes.Ldstr, $"Method not found @{targetAddress.UnsignedValue:X}");
                    else // Probably key function. Just the target, the full operand dump is huge and blows the 16MB #US heap limit
                        instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Unknown call target operand: {instruction.Operands[0]}"));

                    instructions.Add(CilOpCodes.Call, writeLine);
                    break;
                }

                // AssetRipper: a framework method that only exists as the inside of a public one; see
                // EmitInlinedFrameworkCall.
                if (EmitInlinedFrameworkCall(targetMethod, instruction, context, method, locals, writeLine))
                    break;

                var importedMethod = targetMethod.ToMethodDescriptor();

                var thisParamIndex = instruction.OpCode == OpCode.Call ? 2 : 1;

                if (!targetMethod.IsStatic) // Load 'this' param
                {
                    // AssetRipper: an instance method on a value type takes its receiver by managed
                    // pointer, so say so - a static int's ToString() is called on the address of the
                    // field, not on a copy of it.
                    var receiverType = targetMethod.DeclaringType is { IsValueType: true } valueReceiver
                        ? new ByRefTypeAnalysisContext(valueReceiver)
                        : targetMethod.DeclaringType;

                    if ((instruction.Operands.Count - 1) >= thisParamIndex)
                        LoadOperand(instruction.Operands[thisParamIndex], context, method, locals, writeLine, receiverType);
                    else
                    {
                        instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Non static method called without 'this' param ({instruction})"));
                        instructions.Add(CilOpCodes.Call, writeLine);
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
                        LoadOperand(instruction.Operands[callParamIndex + i], context, method, locals, writeLine, parameterType);
                    else
                        PushDefaultOf(parameterType, instructions);
                }

                instructions.Add(CilOpCodes.Call, importedMethod);

                // the lifter's guess at whether the callee returns anything can disagree with the
                // signature we later resolved, so go by the signature and balance the stack
                if (!targetMethod.IsVoid)
                {
                    if (instruction.OpCode == OpCode.Call)
                        StoreToOperand(instruction.Operands[1], context, method, locals, writeLine);
                    else
                        instructions.Add(CilOpCodes.Pop);
                }

                break;

            case OpCode.IndirectCall:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Indirect call: {instruction.Operands[0]} (should have been resolved before IL gen)"));
                instructions.Add(CilOpCodes.Call, writeLine);
                break;

            case OpCode.Return:
                if (!context.IsVoid)
                {
                    if (instruction.Operands.Count == 1)
                        LoadOperand(instruction.Operands[0], context, method, locals, writeLine, context.ReturnType);
                    else
                        instructions.Add(CilOpCodes.Ldnull); // ret still pops a value even if we lost track of it
                }
                instructions.Add(CilOpCodes.Ret);
                break;

            case OpCode.Jump:
                instructions.Add(CilOpCodes.Br, new CilInstructionLabel());
                break;

            case OpCode.ConditionalJump:
                LoadOperand(instruction.Operands[1], context, method, locals, writeLine);
                instructions.Add(CilOpCodes.Brtrue, new CilInstructionLabel());
                break;

            case OpCode.IndirectJump:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Indirect jump: {instruction.Operands[0]} (should have been resolved before IL gen)"));
                instructions.Add(CilOpCodes.Call, writeLine);
                break;

            case OpCode.ShiftStack:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Stack shift: {instruction} (stack analysis should have removed these)"));
                instructions.Add(CilOpCodes.Call, writeLine);
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
            case OpCode.Modulo:

            case OpCode.ShiftLeft:
            case OpCode.ShiftRight:

            case OpCode.And:
            case OpCode.Or:
            case OpCode.Xor:
                // klass pointer read => GetType
                if (instruction.OpCode is OpCode.CheckEqual or OpCode.CheckNotEqual
                    && TryEmitExactTypeComparison(instruction, context, method, locals, writeLine))
                    break;

                // Float arithmetic on a promoted integer operand needs an explicit conversion, so both
                // operands are coerced to the (float) result type. A no-op when they already match.
                var floatConversion = FloatArithmeticConversion(instruction);
                var floatOperandType = FloatArithmeticType(instruction, context);

                // AssetRipper: the same where the destination is a register that also carried a whole
                // aggregate somewhere else in the method, so the local is typed as one. The operands
                // say what the arithmetic is: a float and a value named by the register holding its
                // first member add as floats. `position.x + step` read as `position + step` without it.
                if (floatOperandType == null && FloatComparisonType(instruction, context) is null
                    && instruction.OpCode is OpCode.Add or OpCode.Subtract or OpCode.Multiply or OpCode.Divide or OpCode.Modulo
                    && FloatArithmeticOperandType(instruction, context) is { } operandType)
                {
                    floatOperandType = operandType;
                    floatConversion = null;
                }

                // AssetRipper: a comparison has no float destination to take the type from, so it
                // takes it from whichever operand has one. Without it a float compared against a
                // value the ABI returned in vector registers read as a comparison of the whole
                // struct against a number, which is not a comparison at all.
                if (floatOperandType == null && FloatComparisonType(instruction, context) is { } comparisonType)
                {
                    floatOperandType = comparisonType;
                    floatConversion = comparisonType.FullName == "System.Double" ? CilOpCodes.Conv_R8 : CilOpCodes.Conv_R4;
                }

                // AssetRipper: arithmetic on an address or on a local nothing typed is arithmetic on a
                // native integer, and saying so is what keeps the IL well formed. Without it `sub` had a
                // managed pointer on one side and an object reference on the other, a shape no type
                // names, and ILSpy wrote it out as `(ref *(_003F*)(&obj7)) - (ref *(_003F*)obj5)` -
                // which is not C#. A comparison is left alone: `ceq` on two references is legitimate.
                var toNativeInt = floatOperandType == null && instruction.OpCode is not (>= OpCode.CheckEqual and <= OpCode.CheckLessOrEqual);

                LoadOperand(instruction.Operands[1], context, method, locals, writeLine, floatOperandType);
                if (floatConversion is { } conv1)
                    instructions.Add(conv1);
                else if (toNativeInt && NeedsNativeIntForArithmetic(instruction.Operands[1]))
                    instructions.Add(CilOpCodes.Conv_I);
                LoadOperand(instruction.Operands[2], context, method, locals, writeLine, floatOperandType);
                if (floatConversion is { } conv2)
                    instructions.Add(conv2);
                else if (toNativeInt && NeedsNativeIntForArithmetic(instruction.Operands[2]))
                    instructions.Add(CilOpCodes.Conv_I);

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
                    case OpCode.Modulo: instructions.Add(CilOpCodes.Rem); break;

                    case OpCode.ShiftLeft: instructions.Add(CilOpCodes.Shl); break;
                    case OpCode.ShiftRight: instructions.Add(CilOpCodes.Shr); break;

                    case OpCode.And: instructions.Add(CilOpCodes.And); break;
                    case OpCode.Or: instructions.Add(CilOpCodes.Or); break;
                    case OpCode.Xor: instructions.Add(CilOpCodes.Xor); break;
                }

                // AssetRipper: the result is a float and the destination local is typed as the whole
                // aggregate, so it is that aggregate's first member the register holds.
                if (floatOperandType != null && instruction.Operands[0] is LocalVariable arithmeticResult
                    && FloatAggregate.FirstMember(arithmeticResult.Type) is { } resultMember
                    && locals.TryGetValue(arithmeticResult, out var resultLocal))
                {
                    var scratch = new CilLocalVariable(floatOperandType.ToTypeSignature());
                    method.CilMethodBody!.LocalVariables.Add(scratch);

                    instructions.Add(CilOpCodes.Stloc, scratch);
                    instructions.Add(CilOpCodes.Ldloca, resultLocal);
                    instructions.Add(CilOpCodes.Ldloc, scratch);
                    instructions.Add(CilOpCodes.Stfld, resultMember.ToFieldDescriptor());
                    break;
                }

                StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
                break;

            case OpCode.Not:
            case OpCode.Negate:
                LoadOperand(instruction.Operands[1], context, method, locals, writeLine);

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
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Unknown instruction: {instruction}"));
                instructions.Add(CilOpCodes.Call, writeLine);
                break;
        }

        return instructions.ToList().GetRange(startIndex, instructions.Count - startIndex); // Return added IL
    }
    
    private static int ConstructorReceiverIndex(Instruction constructorCall) => constructorCall.OpCode == OpCode.CallVoid ? 1 : 2;

    /// <summary>
    /// AssetRipper: the constructor to emit for an allocation of <paramref name="allocated"/>, given
    /// the one the following call names.
    /// </summary>
    /// <remarks>
    /// They routinely differ. A trivial constructor is folded onto its base, so a closure's allocation
    /// is followed by a call to <c>System.Object..ctor</c> and fusing the two gave
    /// <c>(DisplayClass)new object()</c>; and generic sharing names one instantiation's constructor for
    /// every other, so a <c>Predicate&lt;Sound&gt;</c> was built by <c>Predicate&lt;object&gt;</c>'s and
    /// the delegate the caller then passed was of neither type.
    /// </remarks>
    private static MethodAnalysisContext? ConstructorFor(IOperand? allocated, MethodAnalysisContext found)
    {
        if (allocated is not TypeAnalysisContext allocatedType || ReferenceEquals(found.DeclaringType, allocatedType))
            return found;

        // Generic sharing names one instantiation's constructor for every other, so re-instantiate it
        // on the type actually being allocated.
        if (allocatedType is GenericInstanceTypeAnalysisContext instance
            && instance.GenericType.Methods.FirstOrDefault(m => m.Name == ".ctor" && m.Parameters.Count == found.Parameters.Count) is { } shared)
            return new ConcreteGenericMethodAnalysisContext(shared, instance.GenericArguments, []);

        // A trivial constructor is folded onto its base, so a closure's allocation is followed by a
        // call to System.Object..ctor and fusing the two gave (DisplayClass)new object().
        if (found is not { Parameters.Count: 0, DeclaringType.FullName: "System.Object" })
            return found;

        // Null rather than the base's constructor, so the caller can try the type's own; fusing them
        // is what gave (DisplayClass)new object().
        return allocatedType.Methods.FirstOrDefault(m => m is { Name: ".ctor", Parameters.Count: 0 });
    }

    /// <summary>
    /// AssetRipper: the constructor of <paramref name="allocatedType"/> that the stores after an
    /// allocation are the inside of, when there is one.
    /// </summary>
    /// <remarks>
    /// <para>
    /// il2cpp inlines a constructor whose body is a base call and a few field stores, which is every
    /// compiler-generated one: an iterator state machine's <c>.ctor(int &lt;&gt;1__state)</c> assigns
    /// its argument to <c>&lt;&gt;1__state</c> and nothing else. So the allocation is followed by
    /// <c>System.Object..ctor</c> and the stores, and the type's real constructor is never called.
    /// </para>
    /// <para>
    /// It matters beyond tidiness: a decompiler folds an iterator back into the <c>yield return</c>
    /// method it came from only if the kickoff method is <c>newobj &lt;Foo&gt;d__1(0); ret</c>. Written
    /// as an allocation plus a field store it is not that, so the state machine stays in the output as
    /// a class of its own, which is what a coroutine looks like when the fold does not happen.
    /// </para>
    /// <para>
    /// The match is by parameter name: a compiler-generated constructor names its parameter after the
    /// field it assigns. That is narrow enough not to fire on a constructor written by hand, whose
    /// parameters are named for what they mean rather than where they go.
    /// </para>
    /// </remarks>
    private static MethodAnalysisContext? InlinedConstructor(MethodAnalysisContext context, Instruction newobj,
        TypeAnalysisContext allocatedType, out List<Instruction> stores)
    {
        stores = [];

        if (newobj.Operands[0] is not LocalVariable allocated)
            return null;

        var instructions = context.ControlFlowGraph!.Instructions;
        var index = instructions.IndexOf(newobj);

        if (index < 0)
            return null;

        var fields = new List<FieldAnalysisContext>();

        for (var i = index + 1; i < instructions.Count && fields.Count < 8; i++)
        {
            var candidate = instructions[i];

            if (candidate.OpCode == OpCode.Nop)
                continue;

            // the base call the inlined constructor kept
            if (candidate is { OpCode: OpCode.CallVoid, Operands: [MethodAnalysisContext { Name: ".ctor" }, LocalVariable baseReceiver, ..] }
                && ReferenceEquals(baseReceiver, allocated))
                continue;

            if (candidate is { OpCode: OpCode.Move, Operands: [FieldReference stored, _] }
                && ReferenceEquals(stored.Local, allocated) && !stored.Field.IsStatic)
            {
                fields.Add(stored.Field);
                stores.Add(candidate);
                continue;
            }

            break;
        }

        if (fields.Count == 0)
            return null;

        foreach (var candidate in allocatedType.Methods)
        {
            if (candidate is not { IsStatic: false, Name: ".ctor" } || candidate.Parameters.Count != fields.Count)
                continue;

            var matches = true;

            for (var i = 0; i < fields.Count && matches; i++)
                matches = candidate.Parameters[i].ParameterName == fields[i].Name;

            if (matches)
                return candidate;
        }

        return null;
    }

    // Try find the follow up CallVoid for a constructor, after a Newobj.
    private static Instruction? FindConstructorCall(MethodAnalysisContext context, Instruction newobj)
    {
        var newObject = newobj.Operands[0];

        // The allocation and the constructor call routinely end up in different blocks
        var instructions = context.ControlFlowGraph!.Instructions;
        var index = instructions.IndexOf(newobj);

        if (index < 0)
            return null;

        for (var i = index + 1; i < instructions.Count; i++)
        {
            var candidate = instructions[i];

            if (candidate is not { OpCode: OpCode.Call or OpCode.CallVoid, Operands: [MethodAnalysisContext { Name: ".ctor" }, ..] })
                continue;

            var receiver = ConstructorReceiverIndex(candidate);

            if (candidate.Operands.Count > receiver && ReferenceEquals(candidate.Operands[receiver], newObject))
                return candidate;
        }

        return null;
    }

    private static CilOpCode? FloatArithmeticConversion(Instruction instruction)
    {
        if (instruction.OpCode is not (OpCode.Add or OpCode.Subtract or OpCode.Multiply or OpCode.Divide or OpCode.Modulo))
            return null;

        return (instruction.Operands[0] as LocalVariable)?.Type?.FullName switch
        {
            "System.Single" => CilOpCodes.Conv_R4,
            "System.Double" => CilOpCodes.Conv_R8,
            _ => null,
        };
    }

    /// <summary>
    /// AssetRipper: the float type this arithmetic produces, so its operands can be loaded as that.
    /// </summary>
    private static TypeAnalysisContext? FloatArithmeticType(Instruction instruction, MethodAnalysisContext context)
    {
        if (instruction.OpCode is not (OpCode.Add or OpCode.Subtract or OpCode.Multiply or OpCode.Divide or OpCode.Modulo))
            return null;

        return (instruction.Operands[0] as LocalVariable)?.Type?.FullName switch
        {
            "System.Single" => context.AppContext.SystemTypes.SystemSingleType,
            "System.Double" => context.AppContext.SystemTypes.SystemDoubleType,
            _ => null,
        };
    }

    /// <summary>
    /// AssetRipper: the float type an arithmetic instruction is in, taken from its operands, when one
    /// of them is a scalar float and the other a value named by the register holding its first member.
    /// </summary>
    private static TypeAnalysisContext? FloatArithmeticOperandType(Instruction instruction, MethodAnalysisContext context)
    {
        if (instruction.Operands.Count < 3)
            return null;

        TypeAnalysisContext? scalar = null;
        var aggregates = 0;

        for (var i = 1; i <= 2; i++)
        {
            switch (instruction.Operands[i])
            {
                case FloatLiteral:
                    scalar ??= context.AppContext.SystemTypes.SystemSingleType;
                    break;
                case DoubleLiteral:
                    scalar = context.AppContext.SystemTypes.SystemDoubleType;
                    break;
                case var operand when DestinationType(operand) is { } type && IsFloat(type):
                    scalar = type.FullName == "System.Double" ? type : scalar ?? type;
                    break;
                case var operand when DestinationType(operand) is { } type && FloatAggregate.MemberCount(type) >= 2:
                    aggregates++;
                    break;
            }
        }

        // AssetRipper: the destination can be the side that names the aggregate. A method returning a
        // Vector3 has its return value typed as one, and the machine computed a component straight
        // into it - `Vector3.one * scale / size` is three float operations, of which only the first
        // was recovered. The arithmetic is still float arithmetic and its result is still that
        // aggregate's first member; without this the division came out as `(Vector3)(num6 / ...)`,
        // which is not a conversion C# has.
        if (DestinationType(instruction.Operands[0]) is { } destination && FloatAggregate.MemberCount(destination) >= 2)
        {
            if (aggregates == 0 && scalar != null)
                return scalar;

            // AssetRipper: and when the operands are aggregates that disagree with the destination.
            // A register that carried a Quaternion earlier in the method gets typed as one, so a
            // Vector3 computed into it later reads as a Quaternion - and `bottomLeft + widthDistance
            // * n` came out as `(Vector3)((object)bottomLeft + (object)quaternion)`. The types
            // conflict, the destination is the one that is right, and the addition the machine did was
            // of first members either way. Same-typed aggregates are left alone, in case the operation
            // really was over the whole value.
            for (var i = 1; i <= 2; i++)
                if (DestinationType(instruction.Operands[i]) is { } operandType
                    && FloatAggregate.MemberCount(operandType) >= 2
                    && operandType.FullName != destination.FullName)
                    return scalar ?? context.AppContext.SystemTypes.SystemSingleType;
        }

        return aggregates > 0 ? scalar : null;
    }

    private static bool IsFloat(TypeAnalysisContext type) => type.FullName is "System.Single" or "System.Double";

    /// <summary>
    /// AssetRipper: whether an arithmetic operand reaches the stack as something arithmetic is not
    /// defined on - an address, or a local nothing typed, which is declared as <c>object</c>.
    /// </summary>
    private static bool NeedsNativeIntForArithmetic(IOperand operand) => operand switch
    {
        AddressOf => true,
        LocalVariable { Type: null } => true,
        LocalVariable { Type: { } type } => !type.IsValueType,
        FieldReference { Field.FieldType: { } fieldType } => !fieldType.IsValueType,
        _ => false,
    };

    /// <summary>
    /// AssetRipper: an integer type a conversion to float would be defined on.
    /// </summary>
    private static bool IsIntegral(TypeAnalysisContext? type) => type?.FullName is "System.SByte" or "System.Byte"
        or "System.Int16" or "System.UInt16" or "System.Int32" or "System.UInt32" or "System.Int64" or "System.UInt64";

    /// <summary>
    /// AssetRipper: the float type a comparison is between, taken from its operands.
    /// </summary>
    private static TypeAnalysisContext? FloatComparisonType(Instruction instruction, MethodAnalysisContext context)
    {
        if (instruction.OpCode is < OpCode.CheckEqual or > OpCode.CheckLessOrEqual || instruction.Operands.Count < 3)
            return null;

        TypeAnalysisContext? found = null;

        for (var i = 1; i <= 2; i++)
        {
            var type = instruction.Operands[i] switch
            {
                FloatLiteral => context.AppContext.SystemTypes.SystemSingleType,
                DoubleLiteral => context.AppContext.SystemTypes.SystemDoubleType,
                var operand when DestinationType(operand) is { } operandType && IsFloat(operandType) => operandType,

                // AssetRipper: a value the ABI keeps in several vector registers is named by the
                // register carrying its first member, so comparing one against a number is a
                // comparison of that member. Without this `position.x > 0` reads as `(nint)position > 0`.
                var operand when DestinationType(operand) is { } aggregate && FloatAggregate.FirstMember(aggregate) is { } first
                    => first.FieldType,

                _ => null,
            };

            // double wins: comparing a float against one widens rather than truncates
            if (type != null && (found == null || type.FullName == "System.Double"))
                found = type;
        }

        return found;
    }

    /// <summary>
    /// Reads the metadata usage stored at <paramref name="address"/>, if there is one. Never throws:
    /// a fixed address in a method body is only a guess at a usage slot, and most of them are not.
    /// </summary>
    private static MetadataUsage? ResolveGlobal(MethodAnalysisContext context, ulong address)
    {
        var lib = context.AppContext.LibCpp2IlContext;

        try
        {
            var direct = lib.GetAnyGlobalByAddress(address);
            if (direct?.IsValid == true)
                return direct;

            // Pre-27 metadata puts one indirection in the way: the address baked into the code is a
            // per-module pointer holding the address of the usage slot, and only that second address
            // is the one the usage dictionaries are keyed by. Post-27 GetAnyGlobalByAddress already
            // reads through the address itself, so this would be a second, wrong dereference.
            if (lib.Metadata.MetadataVersion >= 27f)
                return null;

            if (!lib.Binary.TryMapVirtualAddressToRaw(address, out var raw) || raw >= lib.Binary.RawLength)
                return null;

            var slot = lib.Binary.ReadPointerAtVirtualAddress(address);
            if (slot == 0)
                return null;

            var indirect = lib.GetAnyGlobalByAddress(slot);
            return indirect?.IsValid == true ? indirect : null;
        }
        catch
        {
            return null;
        }
    }

    private static string Describe(Il2CppMethodDefinition method)
        => $"{method.DeclaringType?.FullName}::{method.HumanReadableSignature}";

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

    private static void LoadOperand(IOperand operand, MethodAnalysisContext context, MethodDefinition method,
        Dictionary<LocalVariable, CilLocalVariable> locals, IMethodDescriptor writeLine,
        TypeAnalysisContext? expectedType = null)
    {
        var instructions = method.CilMethodBody!.Instructions;

        var module = method.DeclaringModule!;

        // A null reference reaches us as an integer zero, which would otherwise be emitted as a literal 0
        // and read back as a cast from a number.
        if (expectedType is { IsValueType: false } && IsZeroConstant(operand))
        {
            instructions.Add(CilOpCodes.Ldnull);
            return;
        }

        // AssetRipper: the same on the value type side. A struct the recovery did not manage to put
        // back together is zero in the register the ABI returns it in, and loading that as a literal
        // read back as `(Color)0` - a cast from a number to a struct. Zero for a value type is
        // `default`, which is what initobj says.
        if (expectedType is { IsValueType: true } wantedStruct && IsZeroConstant(operand)
            && !IsFloat(wantedStruct) && PrimitiveFieldWidth(wantedStruct) == 0
            && wantedStruct.FullName != "System.IntPtr" && wantedStruct.FullName != "System.UIntPtr")
        {
            var zeroed = new CilLocalVariable(wantedStruct.ToTypeSignature());
            method.CilMethodBody!.LocalVariables.Add(zeroed);

            instructions.Add(CilOpCodes.Ldloca, zeroed);
            instructions.Add(CilOpCodes.Initobj, wantedStruct.ToTypeSignature().ToTypeDefOrRef());
            instructions.Add(CilOpCodes.Ldloc, zeroed);
            return;
        }

        switch (operand)
        {
            // AssetRipper: an integer immediate stored where a float belongs is the float's bits. The
            // machine has no way to write a float constant other than to materialise its bit pattern
            // in an integer register and store that; a real conversion would be an scvtf. Read as a
            // number, -0.5f came back as 3.2044483E+09f.
            case Immediate { Value: >= 0 and <= uint.MaxValue } bits when expectedType is { } wantedFloat && IsFloat(wantedFloat):
                if (wantedFloat.FullName == "System.Double")
                    instructions.Add(CilOpCodes.Ldc_R8, BitConverter.Int64BitsToDouble(bits.Value));
                else
                    instructions.Add(CilOpCodes.Ldc_R4, BitConverter.Int32BitsToSingle((int)(uint)bits.Value));
                break;
            // AssetRipper: the same for a 32 bit integer. A register holding 0xFFFFFFFF stored into an
            // int field is -1; read as a number it is 4294967295, which does not fit in an int32, so
            // the load came out as an ldc.i8 and the field store was a type mismatch. Where that field
            // was an iterator's state, it also cost the yield-return fold: a decompiler wants the
            // state assignments to be constants of the field's own type.
            case Immediate { Value: > int.MaxValue and <= uint.MaxValue } wide when expectedType is { FullName: "System.Int32" or "System.UInt32" }:
                instructions.Add(CilOpCodes.Ldc_I4, unchecked((int)(uint)wide.Value));
                break;
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
                // AssetRipper: a value the ABI handed back in several vector registers is named by
                // its first register, which carries its first field. Where a float is wanted, that
                // field is what the register holds — not the whole struct to be cast.
                if (expectedType is { } wanted && IsFloat(wanted)
                    && FloatAggregate.FirstMember(local.Type) is { } firstMember
                    && locals.TryGetValue(local, out var addressable))
                {
                    instructions.Add(CilOpCodes.Ldloca, addressable);
                    instructions.Add(CilOpCodes.Ldfld, firstMember.ToFieldDescriptor());
                    break;
                }

                // AssetRipper: the lifter treats scvtf as a move, so a local holding an integer arrives at
                // a float destination with its integer type intact - ILSpy prints "Expected F4, but got
                // I4" and the assignment does not verify. The conversion the machine performed belongs
                // here, where the wanted type is in hand. An integer *immediate* is the opposite case and
                // is handled above: there the bits are the float, because materialise-and-store is the
                // only way to write a float constant.
                if (expectedType is { } wantedFloatType && IsFloat(wantedFloatType) && IsIntegral(local.Type))
                {
                    LoadLocal(local, method, locals);
                    instructions.Add(wantedFloatType.FullName == "System.Double" ? CilOpCodes.Conv_R8 : CilOpCodes.Conv_R4);
                    break;
                }

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
                LoadOperand(elementAddress.Index, context, method, locals, writeLine);
                instructions.Add(CilOpCodes.Ldelema,
                    ((SzArrayTypeAnalysisContext)elementAddress.Array.Type!).ElementType.ToTypeSignature().ToTypeDefOrRef());
                break;
            case ArrayAccess arrayAccess:
                LoadLocal(arrayAccess.Array, method, locals);
                LoadOperand(arrayAccess.Index, context, method, locals, writeLine);
                instructions.Add(CilOpCodes.Ldelem,
                    ((SzArrayTypeAnalysisContext)arrayAccess.Array.Type!).ElementType.ToTypeSignature().ToTypeDefOrRef());
                break;
            case FieldReference field:
                if (field.Field.IsStatic)
                {
                    // AssetRipper: an instance method on a value type takes its receiver by reference,
                    // and a property call cannot give one, so the address of the field is what it wants.
                    if (expectedType is ByRefTypeAnalysisContext or PointerTypeAnalysisContext)
                        instructions.Add(CilOpCodes.Ldsflda, field.Field.ToFieldDescriptor());
                    // prefer the public property over a hidden backing field; see PublicAccessorFor.
                    else if (PublicAccessorFor(field.Field) is { } accessor)
                    {
                        System.Threading.Interlocked.Increment(ref HiddenFieldsReadThroughAProperty);
                        instructions.Add(CilOpCodes.Call, accessor.ToMethodDescriptor());
                    }
                    else
                        instructions.Add(CilOpCodes.Ldsfld, field.Field.ToFieldDescriptor());
                }
                else
                {
                    LoadLocal(field.Local, method, locals);

                    // A field reached through value type fields needs those loaded first. ldfld takes a
                    // value type instance on the stack, so reads chain without needing addresses.
                    foreach (var containing in field.ContainingFields)
                        instructions.Add(CilOpCodes.Ldfld, containing.ToFieldDescriptor());

                    // AssetRipper: a trivial property is inlined, so the field is what the body names.
                    // Read it back through the property when one returns exactly it - `button.onClick`
                    // rather than `button.m_OnClick`, which is private on the real assembly the export
                    // is compiled against.
                    if (field.ContainingFields.Count == 0 && InstanceAccessorFor(field.Field) is { } instanceAccessor)
                    {
                        System.Threading.Interlocked.Increment(ref HiddenFieldsReadThroughAProperty);
                        instructions.Add(CilOpCodes.Callvirt, instanceAccessor.ToMethodDescriptor());
                    }
                    else
                        instructions.Add(CilOpCodes.Ldfld, field.Field.ToFieldDescriptor());
                }

                // AssetRipper: a field of a type the ABI keeps in several vector registers is named by
                // its first register, which carries its first member - so where a float is wanted, that
                // member is what it is, and `destination.x` beats a cast of the whole vector.
                if (expectedType is { } fieldWanted && IsFloat(fieldWanted) && FloatAggregate.FirstMember(field.Field.FieldType) is { } fieldMember)
                    instructions.Add(CilOpCodes.Ldfld, fieldMember.ToFieldDescriptor());

                break;
            case MemoryOperand memory:
                if (memory.Index == null && memory.Addend == 0 && memory.Scale == 0
                    && memory.Base is LocalVariable local2)
                {
                    LoadLocal(local2, method, locals);

                    // A load through a managed pointer (byref) dereferences it to yield the referent.
                    if (local2.Type is ByRefTypeAnalysisContext { ElementType: { } referent })
                        instructions.Add(referent.IsValueType
                            ? new CilInstruction(CilOpCodes.Ldobj, referent.ToTypeSignature().ToTypeDefOrRef())
                            : new CilInstruction(CilOpCodes.Ldind_Ref));
                    break;
                }

                // AssetRipper: the pointer to a class's static field storage, which is where a static
                // field lives. The analysis names a *load through* that pointer as the field it
                // reads, but the pointer itself is a value the code passes around — a static int
                // reached as `"" + Checker.scoreCounter` is `Int32.ToString` called on it — and left
                // alone it read as a load from nothing. The storage begins at the field at offset
                // zero, so that field is what it is: its value, or its address where one is wanted.
                if (memory is { Index: null, Scale: 0, Base: LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: { } staticOwner } } }
                    && Il2CppClassUsefulOffsets.IsStaticFieldsPtr((uint)memory.Addend, context.AppContext.Binary.is32Bit)
                    && staticOwner.Fields.FirstOrDefault(f => f.IsStatic
                        && (f.Attributes & FieldAttributes.Literal) == 0
                        && f.BackingData?.FieldOffset == 0) is { } storageHead)
                {
                    if (expectedType is ByRefTypeAnalysisContext or PointerTypeAnalysisContext)
                    {
                        instructions.Add(CilOpCodes.Ldsflda, storageHead.ToFieldDescriptor());
                    }
                    else if (PublicAccessorFor(storageHead) is { } storageAccessor)
                    {
                        // AssetRipper: the head of a type's static storage is its first static field,
                        // which for a type like Quaternion is the backing field of a public constant —
                        // read it through the property. See PublicAccessorFor.
                        System.Threading.Interlocked.Increment(ref HiddenFieldsReadThroughAProperty);
                        instructions.Add(CilOpCodes.Call, storageAccessor.ToMethodDescriptor());
                    }
                    else
                    {
                        instructions.Add(CilOpCodes.Ldsfld, storageHead.ToFieldDescriptor());
                    }

                    break;
                }

                // A load from a fixed address is usually a metadata usage slot: the il2cpp runtime
                // fills these in at startup with a string literal, an Il2CppClass*, a MethodInfo* or
                // a FieldInfo*. String literals are the only kind we can express in IL, so those
                // become ldstr; the rest keep the null-pointer placeholder but say what they are.
                if (memory.IsConstant && memory.Addend > 0)
                {
                    var global = ResolveGlobal(context, (ulong)memory.Addend);

                    if (global is { Type: MetadataUsageType.StringLiteral })
                    {
                        instructions.Add(CilOpCodes.Ldstr, global.AsLiteral());
                        break;
                    }

                    if (global != null)
                    {
                        instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Il2Cpp runtime handle: {DescribeGlobal(global)}"));
                        instructions.Add(CilOpCodes.Call, writeLine);
                        instructions.Add(CilOpCodes.Ldc_I4_0);
                        instructions.Add(CilOpCodes.Conv_I);
                        break;
                    }
                }

                // AssetRipper: this is the one place a memory operand is given up on, so it is the
                // only honest place to count them from. Classifying the CFG instead counts operands
                // that never reach the generator at all.
                UnresolvedMemoryLoad?.Invoke(context, operand);

                instructions.Add(CilOpCodes.Ldstr, Diagnostic("Unmanaged memory load: " + operand));
                instructions.Add(CilOpCodes.Call, writeLine);
                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Conv_I);
                break;
            case RuntimeMethodInfoAnalysisContext runtimeMethod:
                // A delegate constructor takes its target as a native pointer, which is exactly ldftn.
                if (expectedType?.FullName == "System.IntPtr")
                {
                    instructions.Add(CilOpCodes.Ldftn, runtimeMethod.RepresentedMethod.ToMethodDescriptor());
                    break;
                }

                //Not fully implemented, these basically shouldn't actually ever exist in the final IL.
                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Conv_I);
                break;
            case RuntimeFieldInfoAnalysisContext runtimeField:
                // fieldof(F), e.g. the handle InitializeArray takes.
                if (expectedType?.FullName == "System.RuntimeFieldHandle")
                {
                    instructions.Add(CilOpCodes.Ldtoken, runtimeField.RepresentedField.ToFieldDescriptor());
                    break;
                }

                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Conv_I);
                break;
            case RuntimeClassTypeAnalysisContext or RgctxTableTypeAnalysisContext
                or MethodRgctxTableTypeAnalysisContext or StaticFieldStorageTypeAnalysisContext:
                instructions.Add(CilOpCodes.Ldc_I4_0);
                instructions.Add(CilOpCodes.Conv_I);
                break;
            case TypeAnalysisContext type:
                //typeof(T)
                var corLibScope = module.CorLibTypeFactory.CorLibScope;
                var typeFromHandle = corLibScope
                    .CreateTypeReference("System", "Type")
                    .CreateMemberReference("GetTypeFromHandle", MethodSignature.CreateStatic(
                        corLibScope.CreateTypeReference("System", "Type").ToTypeSignature(false),
                        [corLibScope.CreateTypeReference("System", "RuntimeTypeHandle").ToTypeSignature(true)]));

                instructions.Add(CilOpCodes.Ldtoken, type.ToTypeSignature().ToTypeDefOrRef());
                instructions.Add(CilOpCodes.Call, typeFromHandle);
                break;
            default:
                instructions.Add(CilOpCodes.Ldstr, Diagnostic("Unknown operand: " + operand));
                instructions.Add(CilOpCodes.Call, writeLine);
                instructions.Add(CilOpCodes.Ldnull);
                break;
        }
    }
    
    private static bool TryEmitExactTypeComparison(Instruction instruction, MethodAnalysisContext context, MethodDefinition method,
        Dictionary<LocalVariable, CilLocalVariable> locals, IMethodDescriptor writeLine)
    {
        var left = instruction.Operands[1];
        var right = instruction.Operands[2];

        IOperand typeOperand;
        LocalVariable objLocal;

        if (left is TypeAnalysisContext && IsKlassPointerLoad(right, out var rightLocal))
            (typeOperand, objLocal) = (left, rightLocal);
        else if (right is TypeAnalysisContext && IsKlassPointerLoad(left, out var leftLocal))
            (typeOperand, objLocal) = (right, leftLocal);
        else
            return false;

        var module = method.DeclaringModule!;
        var instructions = method.CilMethodBody!.Instructions;

        var getType = module.CorLibTypeFactory.CorLibScope
            .CreateTypeReference("System", "Object")
            .CreateMemberReference("GetType", MethodSignature.CreateInstance(
                module.CorLibTypeFactory.CorLibScope.CreateTypeReference("System", "Type").ToTypeSignature(false)));

        LoadLocal(objLocal, method, locals);
        instructions.Add(CilOpCodes.Callvirt, getType);
        LoadOperand(typeOperand, context, method, locals, writeLine); // emits typeof(T)
        instructions.Add(CilOpCodes.Ceq);

        if (instruction.OpCode == OpCode.CheckNotEqual)
        {
            instructions.Add(CilOpCodes.Ldc_I4_0);
            instructions.Add(CilOpCodes.Ceq);
        }

        StoreToOperand(instruction.Operands[0], context, method, locals, writeLine);
        return true;
    }
    
    private static bool IsKlassPointerLoad(IOperand operand, out LocalVariable local)
    {
        if (operand is MemoryOperand { Index: null, Addend: 0, Scale: 0, Base: LocalVariable { Type.IsValueType: false } baseLocal })
        {
            local = baseLocal;
            return true;
        }

        local = null!;
        return false;
    }

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

    // AssetRipper: a bool field is as boolean as a bool local, and reading only the local left a
    // negated field as the bitwise complement of an integer: ~(isPaused ? 1u : 0u) == 0.
    private static bool IsBoolean(IOperand operand, MethodAnalysisContext context) =>
        DestinationType(operand) == context.AppContext.SystemTypes.SystemBooleanType;

    /// <summary>
    /// AssetRipper: the width in bytes of a primitive field type, or 0 for anything else.
    /// </summary>
    private static int PrimitiveFieldWidth(TypeAnalysisContext type) => type.FullName switch
    {
        "System.Boolean" or "System.Byte" or "System.SByte" => 1,
        "System.Int16" or "System.UInt16" or "System.Char" => 2,
        "System.Int32" or "System.UInt32" => 4,
        "System.Int64" or "System.UInt64" => 8,
        _ => 0,
    };

    /// <summary>
    /// AssetRipper: the primitive fields a store at <paramref name="head"/>'s offset covers, as
    /// (field, byte offset from the head, width), when the store reaches past the head field and the
    /// fields it reaches tile the range exactly. Null otherwise, which includes the ordinary case of a
    /// store no wider than the field it names.
    /// </summary>
    /// <remarks>
    /// The tiling requirement is what keeps this from guessing. A store that runs off the end of the
    /// declared fields, overlaps one, or lands on a field this cannot size is left to the normal path,
    /// which writes the head field and is at least right about that one.
    /// </remarks>
    private static List<(FieldAnalysisContext Field, int ByteOffset, int Width)>? PackedFieldsCovered(FieldReference head)
    {
        if (head.ContainingFields.Count > 0 || head.Field.IsStatic || head.Field.BackingData is not { } backing)
            return null;

        var headWidth = PrimitiveFieldWidth(head.Field.FieldType);

        if (headWidth == 0 || headWidth >= head.AccessSize)
            return null;

        var start = backing.FieldOffset;
        var covered = new List<(FieldAnalysisContext, int, int)>();
        var filled = 0;

        while (filled < head.AccessSize)
        {
            var wanted = start + filled;
            FieldAnalysisContext? found = null;

            foreach (var candidate in head.Field.DeclaringType!.Fields)
            {
                if (!candidate.IsStatic && candidate.BackingData?.FieldOffset == wanted)
                {
                    found = candidate;
                    break;
                }
            }

            if (found == null)
                return null;

            var width = PrimitiveFieldWidth(found.FieldType);

            if (width == 0 || filled + width > head.AccessSize)
                return null;

            covered.Add((found, filled, width));
            filled += width;
        }

        return covered.Count >= 2 ? covered : null;
    }

    /// <summary>
    /// AssetRipper: the <c>System.Single</c> field four bytes after this one, if there is one.
    /// </summary>
    private static FieldAnalysisContext? AdjacentSingleField(FieldReference field)
    {
        if (field.ContainingFields.Count > 0 || field.Field.IsStatic || field.Field.BackingData is not { } backing)
            return null;

        var wanted = backing.FieldOffset + 4;

        foreach (var candidate in field.Field.DeclaringType!.Fields)
        {
            if (!candidate.IsStatic && candidate.FieldType.FullName == "System.Single" && candidate.BackingData?.FieldOffset == wanted)
                return candidate;
        }

        return null;
    }

    private static bool IsZeroConstant(IOperand operand) => operand is Immediate { Value: 0 };
    
    private static TypeAnalysisContext? DestinationType(IOperand destination) =>
        destination switch
        {
            LocalVariable local => local.Type,
            FieldReference field => field.Field.FieldType,
            ArrayAccess { Array.Type: SzArrayTypeAnalysisContext array } => array.ElementType,
            _ => null
        };

    /// <summary>
    /// Walks down to the value type field a nested access sits in, leaving its address on the stack
    /// so the following stfld writes through it rather than into a copy. A no-op for a direct field.
    /// </summary>
    private static void LoadContainingFields(FieldReference field, CilInstructionCollection instructions)
    {
        foreach (var containing in field.ContainingFields)
            instructions.Add(CilOpCodes.Ldflda, containing.ToFieldDescriptor());
    }

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
        Dictionary<LocalVariable, CilLocalVariable> locals, IMethodDescriptor writeLine)
    {
        var instructions = method.CilMethodBody!.Instructions;

        switch (operand)
        {
            case LocalVariable local:
                instructions.Add(CilOpCodes.Stloc, locals[local]);
                break;

            case FieldReference field:
                var fieldDescriptor = field.Field.ToFieldDescriptor();

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
                LoadContainingFields(field, instructions);
                instructions.Add(CilOpCodes.Ldloc, scratch);
                instructions.Add(CilOpCodes.Stfld, fieldDescriptor);
                break;

            case ArrayAccess arrayAccess:
                // stelem needs array and index before the value, so the same trick as stfld
                var elementType = ((SzArrayTypeAnalysisContext)arrayAccess.Array.Type!).ElementType;
                var elementScratch = new CilLocalVariable(elementType.ToTypeSignature());
                method.CilMethodBody!.LocalVariables.Add(elementScratch);

                instructions.Add(CilOpCodes.Stloc, elementScratch);
                LoadLocal(arrayAccess.Array, method, locals);
                LoadOperand(arrayAccess.Index, context, method, locals, writeLine);
                instructions.Add(CilOpCodes.Ldloc, elementScratch);
                instructions.Add(CilOpCodes.Stelem, elementType.ToTypeSignature().ToTypeDefOrRef());
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
                instructions.Add(CilOpCodes.Ldstr, Diagnostic($"Store into unknown operand: {operand}"));
                instructions.Add(CilOpCodes.Call, writeLine);
                instructions.Add(CilOpCodes.Pop);
                break;
        }
    }
}
