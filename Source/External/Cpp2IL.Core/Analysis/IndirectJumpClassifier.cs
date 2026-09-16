using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using LibCpp2IL;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: what each surviving <see cref="OpCode.IndirectJump"/> actually is, counted rather
/// than guessed at.
/// </summary>
/// <remarks>
/// <para>
/// An indirect jump reaches the generator as one placeholder whatever produced it, and the families
/// behind that one label want opposite work: a delegate tail-invoke is a call this pipeline already
/// knows how to resolve, a vtable slot needs the dispatch tables, a jump table needs its cases
/// recovered, and a register that was never written in this method needs nothing at all because it
/// is the caller's value. Naming them by count first is the same discipline every other family in
/// this project has needed - and it is measurement only: nothing here rewrites an instruction.
/// </para>
/// <para>
/// The names are the shapes that can be read off the IR, not semantics that would have to be
/// inferred. In particular nothing is called a switch table unless the target is computed by
/// arithmetic, and a shape the walk has no rule for is reported as the opcode that defined it rather
/// than folded into a general "unknown".
/// </para>
/// </remarks>
public static class IndirectJumpClassifier
{
    private static readonly Dictionary<string, int> KindCounts = [];
    private static readonly Dictionary<string, int> CallKindCounts = [];
    private static readonly Lock CountLock = new();

    /// <summary>A snapshot of what has been counted so far, most common first.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> Counts
    {
        get
        {
            lock (CountLock)
                return [.. KindCounts.OrderByDescending(pair => pair.Value)];
        }
    }

    /// <summary>The same, for indirect <em>calls</em>, with the vtable shape broken out by reason.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> CallCounts
    {
        get
        {
            lock (CountLock)
                return [.. CallKindCounts.OrderByDescending(pair => pair.Value)];
        }
    }

    private static void RecordCall(string kind)
    {
        lock (CountLock)
            CallKindCounts[kind] = CallKindCounts.GetValueOrDefault(kind) + 1;
    }

    public static void Reset()
    {
        Interlocked.Exchange(ref methodsSeen, 0);

        lock (CountLock)
        {
            KindCounts.Clear();
            CallKindCounts.Clear();
        }
    }

    /// <summary>How many methods this pass has been run on, so the counts can be read against it.</summary>
    /// <remarks>
    /// Analysis is not necessarily performed once per method - the diagnostics layer analyses a
    /// sample for real before the export does - and a count that does not say how many methods it
    /// covers cannot be compared with a count of placeholders in the output.
    /// </remarks>
    public static int MethodsSeen => methodsSeen;

    private static int methodsSeen;

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return;

        Interlocked.Increment(ref methodsSeen);

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();

        foreach (var instruction in instructions)
        {
            if (instruction.Operands.Count == 0)
                continue;

            if (instruction.OpCode == OpCode.IndirectJump)
            {
                Record(Classify(instruction.Operands[0], instructions));
            }
            else if (instruction.OpCode == OpCode.IndirectCall)
            {
                var kind = Classify(instruction.Operands[0], instructions);
                RecordCall(kind == "VTABLE_SLOT" ? VirtualDispatchReason(method, instruction.Operands[0], instructions) : kind);
            }
        }
    }

    /// <summary>
    /// AssetRipper: why <see cref="MetadataResolver.ResolveVirtualCalls"/> did not resolve a call that
    /// reads a vtable slot - asked by running that resolver's own arithmetic and its own slot lookup,
    /// not by restating either.
    /// </summary>
    /// <remarks>
    /// The families want different work and reach the generator as the same placeholder: a receiver
    /// whose class pointer was never typed is type-recovery work, an offset that does not divide is a
    /// layout constant being wrong, and a slot past the end of the vtable is metadata that is not
    /// there. A count of 233 says none of that.
    /// </remarks>
    private static string VirtualDispatchReason(MethodAnalysisContext method, IOperand target, List<Instruction> instructions)
    {
        if (SlotLoad(target, instructions) is not { } slotLoad)
            return "VTABLE_NO_SLOT_LOAD";

        if (slotLoad.Base is not LocalVariable klass)
            return "VTABLE_BASE_NOT_LOCAL";

        if (klass.Type is not RuntimeClassTypeAnalysisContext { RepresentedType: { } receiver })
        {
            // Naming the type it *is* rather than only what it is not: "not a class pointer" is a
            // family name, and this project has had to split one of those at every step. And where
            // the base is a MethodInfo the offset is the rest of the answer, because a call through
            // `methodInfo->methodPointer` is shared generic code invoking whichever instantiation the
            // runtime handed it - there is no static target, and counting it as a failed vtable
            // resolution says the opposite.
            if (klass.Type is RuntimeMethodInfoAnalysisContext)
                return MethodInfoPointerKind(slotLoad.Addend, method.AppContext.Binary.is32Bit);

            return klass.Type is null
                ? "VTABLE_BASE_UNTYPED"
                : "VTABLE_BASE_IS_" + klass.Type.GetType().Name.Replace("AnalysisContext", "");
        }

        var pointerSize = method.AppContext.Binary.PointerSizeBytes;
        var vtableOffset = (long)Il2CppClassUsefulOffsets.GetVtableOffset(method.AppContext.MetadataVersion, method.AppContext.Binary.is32Bit);
        var invokeDataSize = 2L * pointerSize;
        var offset = slotLoad.Addend - vtableOffset;

        if (offset < 0)
            return "VTABLE_OFFSET_BEFORE_TABLE";

        if (offset % invokeDataSize != 0)
            return "VTABLE_OFFSET_MISALIGNED";

        var slot = (int)(offset / invokeDataSize);

        return MetadataResolver.ResolveVTableSlot(method.AppContext, receiver, slot) is not null
            ? "VTABLE_RESOLVABLE"
            : "VTABLE_SLOT_UNRESOLVED";
    }

    /// <summary>
    /// Which of a <c>MethodInfo</c>'s three function pointers a call reads, named from the measured
    /// layout rather than from the offset it happens to be at on one build.
    /// </summary>
    /// <remarks>
    /// The three mean different things and want different work: <c>methodPointer</c> is the method's
    /// own entry point and resolves to a direct call, <c>virtualMethodPointer</c> is what dispatch
    /// would have chosen and needs the receiver, and <c>invoker_method</c> is the runtime's
    /// reflection-style trampoline, which names no managed target at all and is a runtime boundary
    /// rather than a failure. Unity 2022 inserted the second between the other two, so the offset a
    /// label is keyed on moves - reporting the raw offset instead names one build's layout and reads
    /// as a different family on the next.
    /// </remarks>
    private static string MethodInfoPointerKind(long addend, bool is32Bit)
    {
        foreach (string name in (string[])["methodPointer", "virtualMethodPointer", "invoker_method"])
        {
            if (Il2CppMethodInfoUsefulOffsets.TryGetOffset(name, is32Bit, out long offset) && offset == addend)
                return "METHODINFO_" + name.ToUpperInvariant();
        }

        return $"METHODINFO_UNNAMED_AT_0x{addend:X}";
    }

    /// <summary>The load the call reads its target from, whether folded into the call or one Move away.</summary>
    private static MemoryOperand? SlotLoad(IOperand target, List<Instruction> instructions)
    {
        if (target is MemoryOperand { Index: null, Scale: 0 } inlined)
            return inlined;

        if (target is not LocalVariable local)
            return null;

        var definition = instructions.FirstOrDefault(i => ReferenceEquals(i.Destination, local));

        return definition is { OpCode: OpCode.Move, Operands: [_, MemoryOperand { Index: null, Scale: 0 } loaded] } ? loaded : null;
    }

    private static void Record(string kind)
    {
        lock (CountLock)
            KindCounts[kind] = KindCounts.GetValueOrDefault(kind) + 1;
    }

    private static string Classify(IOperand target, List<Instruction> instructions)
    {
        // A local may have more than one definition once SSA has been destructed, so every definition
        // is classified and they have to agree; disagreement is its own answer rather than a coin toss.
        if (target is LocalVariable local)
        {
            var definitions = instructions.Where(i => ReferenceEquals(i.Destination, local)).ToList();

            if (definitions.Count == 0)
                return "ENTRY_VALUE";

            var kinds = definitions
                .Select(definition => definition.OpCode == OpCode.Move && definition.Operands.Count > 1
                    ? ClassifyDirect(definition.Operands[1])
                    : "DEFINED_BY_" + definition.OpCode)
                .Distinct()
                .ToList();

            return kinds.Count == 1 ? kinds[0] : "DEFINITIONS_DISAGREE";
        }

        return ClassifyDirect(target);
    }

    private static string ClassifyDirect(IOperand operand) => operand switch
    {
        FieldReference { Field.Name: "invoke_impl" or "method_ptr" } => "DELEGATE_INVOKE",
        FieldReference reference when IsRuntimeStructure(reference.Local.Type) => "VTABLE_SLOT",
        FieldReference => "MANAGED_FIELD",
        MemoryOperand { Base: LocalVariable based } when IsRuntimeStructure(based.Type) => "VTABLE_SLOT",
        MemoryOperand { Base: LocalVariable { Type: { } loadedBase } } => "LOADED_FROM_" + Describe(loadedBase),
        MemoryOperand => "LOADED_POINTER",
        LocalVariable => "COPY_OF_LOCAL",
        Immediate => "CONSTANT_TARGET",
        _ => "OTHER_" + operand.GetType().Name,
    };

    /// <summary>A short name for a base type, so a family can be split without printing full names.</summary>
    private static string Describe(TypeAnalysisContext type) =>
        type is RuntimeClassTypeAnalysisContext ? "Il2CppClass"
        : type is RuntimeMethodInfoAnalysisContext ? "Il2CppMethodInfo"
        : type is StaticFieldStorageTypeAnalysisContext ? "StaticFields"
        : type.IsDelegate ? "delegate"
        : type.IsValueType ? "valuetype"
        : "reference";

    /// <summary>
    /// A pointer into one of the runtime's own structures, which is where a dispatch table lives.
    /// </summary>
    private static bool IsRuntimeStructure(TypeAnalysisContext? type) =>
        type?.FullName is { } name
        && (name.StartsWith("Il2CppClass", System.StringComparison.Ordinal)
            || name.StartsWith("Il2CppMethodInfo", System.StringComparison.Ordinal)
            || name.StartsWith("Il2CppStaticFields", System.StringComparison.Ordinal));
}
