using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: an interface call a fully shared generic body makes through the runtime invoker, put back
/// as the call - but only once every argument, and the result, is proven.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 065. In a fully shared body the call does not go through <c>VirtualInvokeData.methodPtr</c>;
/// it goes through <c>method-&gt;invoker_method(methodPointer, method, receiver, void** args, void* ret)</c>,
/// the runtime's reflection-style trampoline (<see cref="RuntimeInterfaceResolver"/> classifies the path).
/// Which interface method it is has always been known from the lookup's arguments. What was not known is
/// what it is called <em>with</em>: the arguments are an array of pointers in the frame, and each pointer
/// either addresses a frame slot the body stored the value in, or one of the <c>T</c>-sized buffers the
/// body allocated on the stack, whose contents move by <c>memcpy</c>. Emitting the call before those are
/// proven is emitting a call with invented arguments, so this does neither until they are.
/// </para>
/// <para>
/// The buffer model. A fully shared body sizes a temporary of its type parameter at run time:
/// <c>sp -= (Il2CppClass&lt;T&gt;.stack_slot_size + 15) &amp; ~15</c>. A pointer defined that way - and only that
/// way - is a <c>T</c> value's storage, and it is modelled as a <c>T</c> local when every use of it is one
/// the model explains: a <c>memset</c> of it to zero (<c>default(T)</c>), a <c>memcpy</c> between two such
/// buffers sized by the same class (<c>a = b</c>), a store of its address into the frame (an argument
/// array slot), or an operand of an invoker call. <c>memcpy</c> and <c>memset</c> are named by the binary's
/// own relocations (<see cref="NativeBoundary"/>), never by address. A buffer an invoker writes its result
/// into is modelled only when that invoker call is rewritten - otherwise the local would read a value the
/// call never assigned.
/// </para>
/// <para>
/// An argument's provenance is the store that reaches the call: the one in the call's own block before it,
/// or the last one in the nearest block that dominates the call, provided no other store to the same frame
/// address sits on a path between the two. A value in a frame slot is taken only for a parameter that is a
/// primitive or a reference, which one store writes whole. Anything short of that is
/// <c>UNKNOWN_ARGUMENT</c>, and the call is left as the indirect call it was.
/// </para>
/// </remarks>
public static class InvokerArgumentRecovery
{
    public const string Exact = "EXACT";
    public const string Buffer = "BUFFER";
    public const string UnknownArgument = "UNKNOWN_ARGUMENT";

    /// <summary>Invoker dispatches offered to the pass.</summary>
    public static int Sites;

    /// <summary>Invoker dispatches rewritten into the interface call.</summary>
    public static int Rewritten;

    /// <summary>Stack buffers modelled as a T local.</summary>
    public static int BuffersModelled;

    private static readonly ConcurrentDictionary<string, int> ArgumentCounts = new();
    private static readonly ConcurrentDictionary<string, int> RefusalCounts = new();
    private static readonly string? EvidencePath = System.Environment.GetEnvironmentVariable("CPP2IL_DUMP_INVOKER_ARGS");
    private static readonly System.Threading.Lock EvidenceLock = new();

    /// <summary>Arguments by provenance status, across every site.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> ArgumentStatuses => [.. ArgumentCounts.OrderByDescending(pair => pair.Value)];

    /// <summary>Why a site was left alone.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> Refusals => [.. RefusalCounts.OrderByDescending(pair => pair.Value)];

    private const int ReceiverOperand = 4; // target, result, X0 methodPointer, X1 method, X2 receiver
    private const int ArgsOperand = 5;     // X3
    private const int ReturnOperand = 6;   // X4

    private sealed record Argument(int Index, string Status, string Reason, IOperand? Pointer, IOperand? Value, Instruction? ArrayStore);

    public static bool Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph
            || method.AppContext.Binary.InstructionSetId != LibCpp2IL.DefaultInstructionSets.ARM_V8
            || method.AppContext.Binary.is32Bit)
            return false;

        if (!Il2CppMethodInfoUsefulOffsets.TryGetOffset("invoker_method", false, out var invokerOffset))
            return false;

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();
        var lookups = instructions.Where(InterfaceInvokeDataRecovery.IsLookupShape).ToList();
        if (lookups.Count == 0)
            return false;

        var closures = lookups.ToDictionary(lookup => lookup, lookup => InterfaceInvokeDataRecovery.ForwardClosure(lookup.Destination, instructions));
        var loads = new Dictionary<LocalVariable, MemoryOperand>();
        foreach (var instruction in instructions)
            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable destination, MemoryOperand { Index: null, Scale: 0 } load] })
                loads[destination] = load;

        var dispatches = new List<(Instruction Dispatch, Instruction Lookup, MethodAnalysisContext? Target)>();
        foreach (var dispatch in instructions)
        {
            if (dispatch.OpCode is not (OpCode.IndirectCall or OpCode.IndirectJump) || dispatch.Operands.Count == 0)
                continue;

            var (lookup, path) = RuntimeInterfaceResolver.Trace(dispatch.Operands[0], lookups, closures, loads, 8, invokerOffset);
            if (lookup is null || path != RuntimeInterfaceResolver.InvokerPath)
                continue;

            var contract = InterfaceInvokeDataRecovery.InterfaceOfLookup(method, lookup, instructions);
            var target = contract is null ? null : InterfaceInvokeDataRecovery.MethodOfSlot(contract, lookup.Operands[InterfaceInvokeDataRecovery.SlotOperand]);
            dispatches.Add((dispatch, lookup, target));
        }

        if (dispatches.Count == 0)
            return false;

        System.Threading.Interlocked.Add(ref Sites, dispatches.Count);

        var frame = new FrameMemory(graph, instructions);
        var invokerOperands = new HashSet<Instruction>(dispatches.Select(d => d.Dispatch));
        var buffers = Buffers(method, instructions, invokerOperands);

        // Decide every site against the buffer set, then withdraw any buffer a site that stays indirect
        // writes its result into, and decide again: the model must never read a value nobody assigned.
        Dictionary<Instruction, (Instruction Lookup, MethodAnalysisContext Target, List<Argument> Arguments, LocalVariable? Result)> plans = [];
        Dictionary<Instruction, string> refusals = [];
        Dictionary<Instruction, (Instruction Lookup, MethodAnalysisContext Target, List<Argument> Arguments)> refusedArguments = [];
        for (var round = 0; round < 8; round++)
        {
            plans.Clear();
            refusals.Clear();
            refusedArguments.Clear();

            foreach (var (dispatch, lookup, target) in dispatches)
            {
                if (target is null)
                {
                    refusals[dispatch] = "TARGET_NOT_NAMED_BY_THE_LOOKUP";
                    continue;
                }

                if (Plan(dispatch, target, frame, buffers, out var arguments, out var result) is { } refusal)
                {
                    refusals[dispatch] = refusal;
                    refusedArguments[dispatch] = (lookup, target, arguments);
                    continue;
                }

                plans[dispatch] = (lookup, target, arguments, result);
            }

            var withdrawn = buffers.Keys.Where(buffer => dispatches.Any(site => !plans.ContainsKey(site.Dispatch)
                && site.Dispatch.Operands.Count > ReturnOperand && ReferenceEquals(site.Dispatch.Operands[ReturnOperand], buffer))).ToList();
            if (withdrawn.Count == 0)
                break;

            foreach (var buffer in withdrawn)
                buffers.Remove(buffer);
        }

        foreach (var (dispatch, refusal) in refusals)
        {
            RefusalCounts.AddOrUpdate(refusal, 1, static (_, count) => count + 1);
            if (refusedArguments.TryGetValue(dispatch, out var evidence))
            {
                foreach (var argument in evidence.Arguments)
                    ArgumentCounts.AddOrUpdate(argument.Status, 1, static (_, count) => count + 1);
                WriteEvidence(method, evidence.Lookup, evidence.Target, evidence.Arguments, dispatch, refusal);
            }
        }

        if (plans.Count == 0)
            return false;

        // The buffers: a memset of one is default(T), a memcpy between two is an assignment.
        foreach (var instruction in instructions)
        {
            if (BufferCopy(method, instruction, buffers) is not { } copy)
                continue;

            instruction.OpCode = OpCode.Move;
            instruction.SetOperands(copy.Destination, copy.Source);
        }

        System.Threading.Interlocked.Add(ref BuffersModelled, buffers.Count);

        foreach (var (dispatch, (lookup, target, arguments, result)) in plans)
        {
            List<IOperand> operands = [target];
            if (!target.IsVoid)
                operands.Add(result!);
            operands.Add(dispatch.Operands[ReceiverOperand]);
            operands.AddRange(arguments.Select(argument => argument.Status == Buffer ? buffers[(LocalVariable)argument.Pointer!].Local : argument.Value!));

            var invokeData = PointerBaseOf(dispatch, loads);
            dispatch.OpCode = target.IsVoid ? OpCode.CallVoid : OpCode.Call;
            dispatch.SetOperands(operands);

            foreach (var argument in arguments)
            {
                if (argument.ArrayStore is { } store)
                {
                    store.OpCode = OpCode.Nop;
                    store.SetOperands();
                }

                ArgumentCounts.AddOrUpdate(argument.Status, 1, static (_, count) => count + 1);
            }

            WriteEvidence(method, lookup, target, arguments, dispatch, "REWRITTEN");

            // A lookup two dispatches share is emptied by the first rewrite, so it is read only while it still is one.
            if (invokeData is not null && lookup.OpCode == OpCode.Call && lookup.Operands.Count > InterfaceInvokeDataRecovery.SlotOperand
                && lookup.Operands[InterfaceInvokeDataRecovery.SlotOperand] is Immediate { Value: var slot }
                && InterfaceInvokeDataRecovery.TryGetSlot(slot, out var slotIndex))
                InterfaceDispatchRecovery.TryExciseResolvedLookupOutOfSsa(method, lookup, invokeData, slotIndex, graph.FindBlockByInstruction(dispatch));

            lookup.OpCode = OpCode.Nop;
            lookup.SetOperands();
            System.Threading.Interlocked.Increment(ref Rewritten);
        }

        return true;
    }

    // The invoke data pointer the dispatch's target was loaded through: [[invokeData + 8] + invoker].
    // Asked before the dispatch is rewritten, while its target operand is still that load.
    private static LocalVariable? PointerBaseOf(Instruction dispatch, IReadOnlyDictionary<LocalVariable, MemoryOperand> loads)
    {
        MemoryOperand? outer = dispatch.Operands[0] switch
        {
            MemoryOperand inlined => inlined,
            LocalVariable local when loads.TryGetValue(local, out var loaded) => loaded,
            _ => null,
        };

        return outer is { Base: LocalVariable method } && loads.TryGetValue(method, out var inner) && inner.Base is LocalVariable invokeData
            ? invokeData
            : null;
    }

    /// <summary>Why a site cannot be rewritten, or null with its arguments and result proven.</summary>
    private static string? Plan(Instruction dispatch, MethodAnalysisContext target, FrameMemory frame,
        Dictionary<LocalVariable, StackBuffer> buffers, out List<Argument> arguments, out LocalVariable? result)
    {
        arguments = [];
        result = null;

        if (dispatch.OpCode == OpCode.IndirectJump)
            return "TAIL_POSITION";

        if (dispatch.Operands.Count <= ReturnOperand)
            return "OPERANDS_NOT_THE_INVOKER_LAYOUT";

        string? refusal = null;

        if (target.Parameters.Count > 0)
        {
            var argsAddress = frame.AddressOf(dispatch.Operands[ArgsOperand]);

            // A one-element args array whose slot was only ever a copy of a register is folded onto that register
            // by copy propagation, and the dispatch then hands the address of the register's own local. The array
            // is that local's storage, so args[0] is its value at the call - and there is no args[1] to read.
            var heldArgs = dispatch.Operands[ArgsOperand] is AddressOf { Target: LocalVariable held } && argsAddress is null ? held : null;

            for (var index = 0; index < target.Parameters.Count; index++)
            {
                var parameter = target.Parameters[index].ParameterType;
                IOperand pointer;
                Instruction? arrayStore = null;

                if (heldArgs is not null)
                {
                    if (target.Parameters.Count != 1)
                    {
                        arguments.Add(new Argument(index, UnknownArgument, "ARGS_IN_A_LOCAL_HOLD_ONE_ELEMENT", null, null, null));
                        continue;
                    }

                    pointer = heldArgs;
                }
                else if (argsAddress is not { } array)
                {
                    arguments.Add(new Argument(index, UnknownArgument, "ARGS_NOT_A_FRAME_ADDRESS", null, null, null));
                    continue;
                }
                else if (frame.ReachingStore((array.Slot, array.Offset + 8L * index), dispatch) is not { } store)
                {
                    arguments.Add(new Argument(index, UnknownArgument, "NO_STORE_REACHES_ARGS[" + index + "]", null, null, null));
                    continue;
                }
                else
                {
                    arrayStore = store;
                    pointer = store.Operands[1];
                }

                if (pointer is LocalVariable bufferPointer && buffers.TryGetValue(bufferPointer, out var buffer))
                {
                    arguments.Add(SameType(buffer.Type, parameter)
                        ? new Argument(index, Buffer, "T_BUFFER", pointer, null, arrayStore)
                        : new Argument(index, UnknownArgument, "BUFFER_OF_ANOTHER_TYPE", pointer, null, arrayStore));
                    continue;
                }

                // The address of a local's own storage - a spill slot copy propagation folded onto the register it
                // was a copy of - is read by the callee as that local's value at the call.
                if (pointer is AddressOf { Target: LocalVariable pointee } && frame.AddressOf(pointer) is null)
                {
                    arguments.Add(WrittenByOneStore(parameter) && pointee.Type is { } pointeeType && SameType(pointeeType, parameter)
                        ? new Argument(index, Exact, "LOCAL_STORAGE", pointer, pointee, arrayStore)
                        : new Argument(index, UnknownArgument, "LOCAL_STORAGE_OF_ANOTHER_TYPE", pointer, null, arrayStore));
                    continue;
                }

                if (frame.AddressOf(pointer) is not { } valueAddress)
                {
                    arguments.Add(new Argument(index, UnknownArgument, "POINTER_NOT_A_FRAME_ADDRESS_OR_BUFFER", pointer, null, arrayStore));
                    continue;
                }

                if (!WrittenByOneStore(parameter))
                {
                    arguments.Add(new Argument(index, UnknownArgument, "PARAMETER_NOT_ONE_STORE_WIDE", pointer, null, arrayStore));
                    continue;
                }

                if (frame.ReachingStore(valueAddress, dispatch) is not { } valueStore)
                {
                    arguments.Add(new Argument(index, UnknownArgument, "NO_STORE_REACHES_THE_VALUE_SLOT", pointer, null, arrayStore));
                    continue;
                }

                if (frame.ValueReaching(valueStore, dispatch) is not { } value)
                {
                    arguments.Add(new Argument(index, UnknownArgument, "VALUE_REDEFINED_BEFORE_THE_CALL", pointer, null, arrayStore));
                    continue;
                }

                arguments.Add(new Argument(index, Exact, "FRAME_SLOT", pointer, value, arrayStore));
            }

            if (arguments.FirstOrDefault(argument => argument.Status == UnknownArgument) is { } unknown)
                refusal = UnknownArgument + ":" + unknown.Reason;
        }

        if (!target.IsVoid && refusal is null)
        {
            var (returned, reason) = PlanReturn(dispatch.Operands[ReturnOperand], target.ReturnType, frame, buffers);
            if (returned is not null)
                result = returned;
            else
                refusal = UnknownReturn + ":" + reason;
        }

        return refusal;
    }

    public const string UnknownReturn = "UNKNOWN_RETURN";

    /// <summary>
    /// AssetRipper: iteration 066 - where the invoker writes the return value, and the local that holds it afterwards.
    /// </summary>
    /// <remarks>
    /// The invoker stores the callee's result through its last argument: <c>*(T*)ret = method(...)</c> for a value,
    /// the object pointer for a reference. So the local that holds the result is the storage <c>ret</c> addresses -
    /// a <c>T</c> buffer (<see cref="Buffers"/>) or a named frame slot - and nothing is inferred from a size. A frame
    /// slot is taken only for a type one store writes whole, and only when every local naming the slot is one
    /// storage, so a read after the call is a read of what the call wrote. This runs out of SSA, so defining that
    /// local at the call is exactly the callee's store. Every other shape is refused with the reason it is not one.
    /// </remarks>
    private static (LocalVariable? Result, string Reason) PlanReturn(IOperand returnPointer, TypeAnalysisContext returnType, FrameMemory frame, Dictionary<LocalVariable, StackBuffer> buffers)
    {
        switch (returnPointer)
        {
            case LocalVariable pointer when buffers.TryGetValue(pointer, out var buffer):
                return SameType(buffer.Type, returnType) ? (buffer.Local, "T_BUFFER") : (null, "BUFFER_OF_ANOTHER_TYPE");
            case Immediate { Value: 0 }:
                return (null, "NULL_RETURN_POINTER");
            case AddressOf { Target: LocalVariable slot } when frame.AddressOf(returnPointer) is not null:
                if (!WrittenByOneStore(returnType))
                    return (null, returnType.IsValueType ? "STRUCT_ACROSS_FRAME_SLOTS" : "FRAME_SLOT_TYPE_NOT_ONE_STORE");
                if (!frame.IsOneStorage(slot))
                    return (null, "FRAME_SLOT_HAS_SEVERAL_STORAGES");
                return (slot, "FRAME_SLOT");
        }

        if (frame.AddressOf(returnPointer) is not null)
            return (null, "COMPUTED_FRAME_ADDRESS");

        if (returnPointer is LocalVariable local && frame.DefinitionOf(local) is { } definition)
            return (null, definition.OpCode == OpCode.StackAlloc ? "T_BUFFER_WITH_A_USE_THE_MODEL_DOES_NOT_EXPLAIN" : "POINTER_FROM_" + definition.OpCode.ToString().ToUpperInvariant());

        return (null, returnPointer is LocalVariable ? "POINTER_WITH_SEVERAL_DEFINITIONS_OR_NONE" : "POINTER_" + returnPointer.GetType().Name.ToUpperInvariant());
    }

    private static bool SameType(TypeAnalysisContext a, TypeAnalysisContext b)
        => ReferenceEquals(a, b) || a.FullName == b.FullName;

    // A primitive or a reference is written into its slot by one store; a struct is not.
    private static bool WrittenByOneStore(TypeAnalysisContext type)
        => !type.IsValueType || type.FullName is "System.Boolean" or "System.Byte" or "System.SByte" or "System.Int16"
            or "System.UInt16" or "System.Char" or "System.Int32" or "System.UInt32" or "System.Int64" or "System.UInt64"
            or "System.Single" or "System.Double" or "System.IntPtr" or "System.UIntPtr" || type.IsEnumType;

    private sealed record StackBuffer(TypeAnalysisContext Type, LocalVariable Local, TypeAnalysisContext Class);

    /// <summary>The stack buffers of a fully shared body that the model can explain, by pointer.</summary>
    private static Dictionary<LocalVariable, StackBuffer> Buffers(MethodAnalysisContext method, List<Instruction> instructions, HashSet<Instruction> invokers)
    {
        var found = new Dictionary<LocalVariable, StackBuffer>();
        if (!Il2CppClassUsefulOffsets.TryGetOffset("stack_slot_size", false, out var slotSize))
            return found;

        var definitions = instructions.Where(i => i.Destination is LocalVariable).GroupBy(i => (LocalVariable)i.Destination!).ToDictionary(g => g.Key, g => g.ToList());
        var counter = 0;

        foreach (var (pointer, defined) in definitions)
        {
            TypeAnalysisContext? type = null;
            LocalVariable? klass = null;

            foreach (var definition in defined)
            {
                // iteration 066: StackAnalyzer now recovers the allocation as what it is; the subtraction from a
                // frame slot's address is the shape it had before, kept for a body the analyser did not recognise
                var allocatedSize = definition switch
                {
                    { OpCode: OpCode.StackAlloc, Operands: [_, LocalVariable allocated] } => allocated,
                    { OpCode: OpCode.Subtract, Operands: [_, AddressOf { Target: LocalVariable }, LocalVariable subtracted] } => subtracted,
                    _ => null,
                };

                if (allocatedSize is not { } size
                    || Single(definitions, size) is not { OpCode: OpCode.And, Operands: [_, LocalVariable rounded, Immediate] }
                    || Single(definitions, rounded) is not { OpCode: OpCode.Add, Operands: [_, MemoryOperand { Base: LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: { } represented } } sizeOf, Index: null, Addend: var addend }, Immediate { Value: 15 }] }
                    || addend != slotSize
                    || type is not null && !SameType(type, represented))
                {
                    type = null;
                    break;
                }

                type = represented;
                klass = sizeOf;
            }

            if (type is null || klass is null)
                continue;

            found[pointer] = new StackBuffer(type, new LocalVariable($"buffer{counter++}", new Register(null, $"TBUF{counter}"), type), klass.Type!);
        }

        // Every use has to be one the model explains, or the buffer is memory something else may touch.
        foreach (var pointer in found.Keys.ToList())
        {
            foreach (var instruction in instructions)
            {
                if (!Uses(instruction, pointer))
                    continue;

                var explained = ReferenceEquals(instruction.Destination, pointer) && instruction.OpCode is OpCode.Subtract or OpCode.StackAlloc
                    // iteration 066: the allocation leaves the stack pointer at the buffer; that write is bookkeeping,
                    // and a read through the stack pointer afterwards is a use of the register, which is still checked
                    || instruction is { OpCode: OpCode.Move, Operands: [LocalVariable { Register.Name: StackAnalyzer.DynamicStackPointer }, LocalVariable spSource] }
                        && ReferenceEquals(spSource, pointer)
                    || invokers.Contains(instruction)
                    || instruction is { OpCode: OpCode.Move, Operands: [MemoryOperand { Base: LocalVariable }, LocalVariable stored] } && ReferenceEquals(stored, pointer)
                    // the same store once the frame pointer is resolved: the address written straight into a named slot
                    || instruction is { OpCode: OpCode.Move, Operands: [LocalVariable slot, LocalVariable storedInSlot] }
                        && ReferenceEquals(storedInSlot, pointer) && slot.Register.Name.StartsWith("stack_", System.StringComparison.Ordinal)
                    || CopyHelperUse(method, instruction, pointer, found)
                    // A lookup takes the receiver, the interface class and the slot; the raw register
                    // list past those three is whatever the registers last held, not an argument.
                    || InterfaceInvokeDataRecovery.IsLookupShape(instruction) && !ArgumentsMention(instruction, 2, pointer)
                        && !instruction.Operands.Any(operand => operand is MemoryOperand { } memory && (ReferenceEquals(memory.Base, pointer) || ReferenceEquals(memory.Index, pointer)));

                if (!explained)
                {
                    found.Remove(pointer);
                    break;
                }
            }
        }

        return found;
    }

    private static Instruction? Single(Dictionary<LocalVariable, List<Instruction>> definitions, LocalVariable local)
        => definitions.TryGetValue(local, out var defined) && defined.Count == 1 ? defined[0] : null;

    private static bool Uses(Instruction instruction, LocalVariable local)
        => instruction.Operands.Any(operand => ReferenceEquals(operand, local)
            || operand is MemoryOperand { } memory && (ReferenceEquals(memory.Base, local) || ReferenceEquals(memory.Index, local)));

    // A memset/memcpy whose C arguments involve this buffer as a pointer and nothing as a memory base;
    // the raw register list past the three C arguments is stale and not a use.
    private static bool CopyHelperUse(MethodAnalysisContext method, Instruction instruction, LocalVariable pointer, Dictionary<LocalVariable, StackBuffer> buffers)
    {
        if (CopyHelper(method, instruction) is not { } symbol)
            return false;

        var argBase = instruction.OpCode == OpCode.Call ? 2 : 1;
        for (var index = 0; index < instruction.Operands.Count; index++)
        {
            if (instruction.Operands[index] is MemoryOperand memory && (ReferenceEquals(memory.Base, pointer) || ReferenceEquals(memory.Index, pointer)))
                return false;
        }

        return symbol switch
        {
            "memset" => ReferenceEquals(instruction.Operands[argBase], pointer) || !ArgumentsMention(instruction, argBase, pointer),
            _ => true, // memcpy/memmove: checked when the copy is rewritten
        };
    }

    private static bool ArgumentsMention(Instruction instruction, int argBase, LocalVariable pointer)
        => Enumerable.Range(argBase, System.Math.Min(3, instruction.Operands.Count - argBase)).Any(index => ReferenceEquals(instruction.Operands[index], pointer));

    private static string? CopyHelper(MethodAnalysisContext method, Instruction instruction)
    {
        if (instruction.OpCode is not (OpCode.Call or OpCode.CallVoid) || instruction.Operands is not [Immediate { Value: var address }, ..])
            return null;

        var verdict = NativeBoundary.Of(method.AppContext, (ulong)address);
        return verdict.Kind == NativeBoundary.SystemApi && verdict.Symbol is "memcpy" or "memmove" or "memset" ? verdict.Symbol : null;
    }

    /// <summary>The assignment a memset or memcpy of modelled buffers is, or null.</summary>
    private static (LocalVariable Destination, IOperand Source)? BufferCopy(MethodAnalysisContext method, Instruction instruction, Dictionary<LocalVariable, StackBuffer> buffers)
    {
        if (CopyHelper(method, instruction) is not { } symbol)
            return null;

        var argBase = instruction.OpCode == OpCode.Call ? 2 : 1;
        if (instruction.Operands.Count < argBase + 3
            || instruction.Operands[argBase] is not LocalVariable destination
            || !buffers.TryGetValue(destination, out var into)
            || !SizedBy(instruction.Operands[argBase + 2], into))
            return null;

        if (symbol == "memset")
            return instruction.Operands[argBase + 1] is Immediate { Value: 0 } ? (into.Local, new Immediate(0)) : null;

        return instruction.Operands[argBase + 1] is LocalVariable source && buffers.TryGetValue(source, out var from) && SameType(from.Type, into.Type)
            ? (into.Local, from.Local)
            : null;
    }

    // The size argument is the class's stack_slot_size read off a class pointer of the same type.
    private static bool SizedBy(IOperand size, StackBuffer buffer)
        => Il2CppClassUsefulOffsets.TryGetOffset("stack_slot_size", false, out var slotSize)
            && size is MemoryOperand { Base: LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: { } sized } }, Index: null, Addend: var addend }
            && addend == slotSize && SameType(sized, buffer.Type);

    private static void WriteEvidence(MethodAnalysisContext caller, Instruction lookup, MethodAnalysisContext target, List<Argument> arguments, Instruction dispatch, string outcome)
    {
        if (string.IsNullOrEmpty(EvidencePath))
            return;

        var rows = new List<string>();
        var receiver = dispatch.Operands.Count > ReceiverOperand ? dispatch.Operands[ReceiverOperand].ToString() : "";
        if (arguments.Count == 0)
            arguments = [new Argument(-1, "-", "NO_ARGUMENTS", null, null, null)];

        foreach (var argument in arguments)
        {
            string[] row =
            [
                $"{caller.DeclaringType?.FullName}::{caller.Name}",
                $"{target.DeclaringType?.FullName}::{target.Name}",
                "invoker_method",
                receiver ?? "",
                lookup.Operands.Count > InterfaceInvokeDataRecovery.InterfaceOperand ? lookup.Operands[InterfaceInvokeDataRecovery.InterfaceOperand].ToString() ?? "" : "",
                argument.Index.ToString(),
                argument.Pointer?.ToString() ?? "",
                argument.Value?.ToString() ?? (argument.Status == Buffer ? "T buffer" : ""),
                argument.Status,
                argument.Reason,
                outcome,
            ];
            rows.Add(string.Join('\t', row.Select(cell => cell.Replace('\t', ' ').Replace('\n', ' '))));
        }

        lock (EvidenceLock)
            System.IO.File.AppendAllText(EvidencePath, string.Join("\n", rows) + "\n");
    }

    /// <summary>
    /// Frame memory as the analysis left it: addresses written as a stack slot plus a constant, and the
    /// stores into them.
    /// </summary>
    private sealed class FrameMemory(ISILControlFlowGraph graph, List<Instruction> instructions)
    {
        private readonly Dictionary<LocalVariable, List<Instruction>> definitions = instructions
            .Where(i => i.Destination is LocalVariable)
            .GroupBy(i => (LocalVariable)i.Destination!)
            .ToDictionary(g => g.Key, g => g.ToList());

        private DominatorInfo? dominators;

        /// <summary>The one instruction defining a local, or null.</summary>
        public Instruction? DefinitionOf(LocalVariable local)
            => definitions.TryGetValue(local, out var defined) && defined.Count == 1 ? defined[0] : null;

        /// <summary>Whether every local that names this slot's register is this local: one storage, read where it is written.</summary>
        public bool IsOneStorage(LocalVariable slot)
            => instructions.All(instruction => instruction.Operands.All(operand => Names(operand, slot)));

        private static bool Names(IOperand operand, LocalVariable slot) => operand switch
        {
            LocalVariable other => other.Register.Name != slot.Register.Name || ReferenceEquals(other, slot) || other.Name == slot.Name,
            AddressOf { Target: var target } => Names(target, slot),
            MemoryOperand memory => (memory.Base is null || Names(memory.Base, slot)) && (memory.Index is null || Names(memory.Index, slot)),
            _ => true,
        };

        /// <summary>The frame address an operand holds - a stack slot's register name and an offset - or null.</summary>
        public (string Slot, long Offset)? AddressOf(IOperand operand, int depth = 0)
        {
            if (depth > 6)
                return null;

            switch (operand)
            {
                // The stack analyser names a slot after its own offset in hex (`stack_-88 + 0x14` is
                // `stack_-74`), so every slot is one frame and an address is its offset in it.
                case AddressOf { Target: LocalVariable slot } when SlotOffset(slot.Register.Name) is { } frameOffset:
                    return ("frame", frameOffset);
                case LocalVariable local when definitions.TryGetValue(local, out var defined) && defined.Count == 1:
                    return defined[0] switch
                    {
                        { OpCode: OpCode.Move, Operands: [_, var source] } => AddressOf(source, depth + 1),
                        { OpCode: OpCode.Subtract, Operands: [_, var from, Immediate { Value: var less }] } when AddressOf(from, depth + 1) is { } a => (a.Slot, a.Offset - less),
                        { OpCode: OpCode.Add, Operands: [_, var from, Immediate { Value: var more }] } when AddressOf(from, depth + 1) is { } a => (a.Slot, a.Offset + more),
                        _ => null,
                    };
                default:
                    return null;
            }
        }

        private static long? SlotOffset(string name)
        {
            if (!name.StartsWith("stack_", System.StringComparison.Ordinal))
                return null;

            var digits = name["stack_".Length..];
            var negative = digits.StartsWith('-');
            return long.TryParse(negative ? digits[1..] : digits, System.Globalization.NumberStyles.HexNumber, null, out var value)
                ? negative ? -value : value
                : null;
        }

        // A store through a frame address, or - once the frame pointer is resolved to the stack (iteration 065) - a
        // store straight into the named slot itself, which is the same byte of the same frame.
        private (string Slot, long Offset)? StoredAt(Instruction instruction)
            => instruction switch
            {
                { OpCode: OpCode.Move, Operands: [MemoryOperand { Base: { } @base, Index: null, Scale: 0, Addend: var addend }, _] }
                    when AddressOf(@base) is { } at => (at.Slot, at.Offset + addend),
                { OpCode: OpCode.Move, Operands: [LocalVariable slot, _] } when SlotOffset(slot.Register.Name) is { } offset => ("frame", offset),
                _ => null,
            };

        /// <summary>The store into <paramref name="address"/> that reaches <paramref name="use"/>, or null.</summary>
        public Instruction? ReachingStore((string Slot, long Offset) address, Instruction use)
        {
            if (graph.FindBlockByInstruction(use) is not { } useBlock)
                return null;

            var index = useBlock.Instructions.IndexOf(use);
            for (var at = index - 1; at >= 0; at--)
                if (StoredAt(useBlock.Instructions[at]) == address)
                    return useBlock.Instructions[at];

            dominators ??= new DominatorInfo(graph);

            for (var block = Idom(useBlock); block is not null; block = Idom(block))
            {
                for (var at = block.Instructions.Count - 1; at >= 0; at--)
                {
                    if (StoredAt(block.Instructions[at]) != address)
                        continue;

                    // Nothing on a path from here to the use may store there as well.
                    var between = Between(block, useBlock);
                    if (between.Any(other => other.Instructions.Any(i => StoredAt(i) == address)))
                        return null;

                    // ...and nothing after the use in its own block that a loop could bring back round.
                    if (useBlock.Instructions.Skip(index + 1).Any(i => StoredAt(i) == address) && between.Contains(useBlock))
                        return null;

                    return block.Instructions[at];
                }
            }

            return null;
        }

        /// <summary>
        /// The operand that holds, at <paramref name="use"/>, what <paramref name="store"/> wrote - or null when that
        /// cannot be established.
        /// </summary>
        /// <remarks>
        /// A store straight into a named slot leaves the value in the slot, and <see cref="ReachingStore"/> has
        /// already established nothing else writes it on the way, so the slot itself is the answer. A store through
        /// an address copies a local, and out of SSA a local can be assigned again before the call: then the value
        /// the callee reads is not the local's value at the call, and naming the local would be a wrong argument.
        /// </remarks>
        public IOperand? ValueReaching(Instruction store, Instruction use)
        {
            if (store.Operands[0] is LocalVariable slot)
                return slot;

            var value = store.Operands[1];
            return value is LocalVariable local && WrittenBetween(local, store, use) ? null : value;
        }

        private bool WrittenBetween(LocalVariable local, Instruction store, Instruction use)
        {
            bool Writes(Instruction instruction) => ReferenceEquals(instruction.Destination, local);

            if (graph.FindBlockByInstruction(store) is not { } storeBlock || graph.FindBlockByInstruction(use) is not { } useBlock)
                return true;

            var from = storeBlock.Instructions.IndexOf(store);
            var to = useBlock.Instructions.IndexOf(use);

            if (storeBlock == useBlock && from < to)
                return storeBlock.Instructions.Skip(from + 1).Take(to - from - 1).Any(Writes);

            var between = Between(storeBlock, useBlock);
            return storeBlock.Instructions.Skip(from + 1).Any(Writes)
                || useBlock.Instructions.Take(to).Any(Writes)
                || Walk(storeBlock, static block => block.Successors).Contains(storeBlock) && storeBlock.Instructions.Take(from).Any(Writes)
                || between.Contains(useBlock) && useBlock.Instructions.Any(Writes)
                || between.Where(block => block != useBlock).Any(block => block.Instructions.Any(Writes));
        }

        private Block? Idom(Block block)
            => dominators!.ImmediateDominators.TryGetValue(block, out var idom) && idom != block ? idom : null;

        // Blocks reachable from `from` that can reach `to`, other than `from` itself.
        private static HashSet<Block> Between(Block from, Block to)
        {
            var forward = Walk(from, static block => block.Successors);
            var backward = Walk(to, static block => block.Predecessors);
            forward.IntersectWith(backward);
            forward.Remove(from);
            return forward;
        }

        private static HashSet<Block> Walk(Block start, System.Func<Block, List<Block>> next)
        {
            var seen = new HashSet<Block>();
            var queue = new Queue<Block>(next(start));
            while (queue.Count > 0)
            {
                var block = queue.Dequeue();
                if (seen.Add(block))
                    foreach (var following in next(block))
                        queue.Enqueue(following);
            }

            return seen;
        }
    }
}
