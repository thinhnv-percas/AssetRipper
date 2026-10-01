using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: for every indirect dispatch that survives analysis, whether a runtime interface lookup
/// feeds it, by which path, and why the lookup did not resolve it.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 064. Iterations 062 and 063 recorded 505 surviving interface scan regions on Merge-Room as
/// "the interface class comes from the runtime generic context, which <see
/// cref="InterfaceInvokeDataRecovery.InterfaceOf"/> does not accept". Reading one -
/// <c>MoreMountains.Tools.ListExtensions.MMSwap&lt;T&gt;</c> - says the opposite: the class operand is
/// typed <c>Il2CppClass&lt;IList`1&lt;T&gt;&gt;</c> by <see cref="RgctxResolver"/> and the lookup names
/// slot 0 and 1, which is <c>get_Item</c> and <c>set_Item</c>. What does not match is the
/// <em>dispatch</em>: in a fully shared generic body the call does not go through
/// <c>VirtualInvokeData.methodPtr</c> but through <c>VirtualInvokeData.method-&gt;invoker_method</c>,
/// the runtime's reflection-style invoker, which takes the arguments as an array of pointers and
/// writes the result into a buffer. That is two loads from the lookup's result rather than one.
/// </para>
/// <para>
/// So this asks, of each surviving dispatch, the questions that separate the causes instead of naming
/// the family after the symptom: is the pointer reached from a lookup at all; through which path
/// (<see cref="DispatchPath"/>); where did the interface class come from (<see cref="ClassSource"/>);
/// and would the lookup's own arguments name a method. Nothing here rewrites anything.
/// </para>
/// </remarks>
public static class RuntimeInterfaceResolver
{
    /// <summary>How a dispatch's function pointer is reached from a lookup's result.</summary>
    public const string MethodPointerPath = "METHOD_POINTER";

    /// <summary><c>VirtualInvokeData.method-&gt;invoker_method</c>: the invoker of a fully shared body.</summary>
    public const string InvokerPath = "INVOKER_THROUGH_METHOD";

    /// <summary>Two loads from the lookup's result, the second at an offset that is not the invoker.</summary>
    public const string OtherTwoLoadPath = "TWO_LOADS_OTHER";

    /// <summary>No lookup-shaped call's result reaches the pointer.</summary>
    public const string NoLookup = "NO_LOOKUP";

    /// <summary>The interface class operand is a metadata usage.</summary>
    public const string FromMetadataUsage = "METADATA_USAGE";

    /// <summary>The interface class operand is a local loaded from a runtime generic context table.</summary>
    public const string FromRgctx = "RGCTX_ENTRY";

    /// <summary>The interface class operand is a class pointer local whose producer is not an RGCTX read.</summary>
    public const string FromTypedLocal = "TYPED_CLASS_LOCAL";

    /// <summary>Nothing establishes what the class operand is.</summary>
    public const string FromUnknown = "UNKNOWN_CLASS_SOURCE";

    private static readonly Dictionary<string, int> FamilyCounts = [];
    private static readonly Lock CountLock = new();
    private static readonly string? EvidencePath = System.Environment.GetEnvironmentVariable("CPP2IL_DUMP_INTERFACE_CALLS");

    /// <summary>What has been counted so far, most common first.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> Counts
    {
        get
        {
            lock (CountLock)
                return [.. FamilyCounts.OrderByDescending(pair => pair.Value)];
        }
    }

    public static void Reset()
    {
        lock (CountLock)
            FamilyCounts.Clear();
    }

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return;

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();
        var lookups = instructions.Where(InterfaceInvokeDataRecovery.IsLookupShape).ToList();

        if (lookups.Count == 0)
            return;

        var closures = lookups.ToDictionary(lookup => lookup, lookup => InterfaceInvokeDataRecovery.ForwardClosure(lookup.Destination, instructions));
        var loads = new Dictionary<LocalVariable, MemoryOperand>();

        foreach (var instruction in instructions)
        {
            if (instruction.OpCode == OpCode.Move
                && instruction.Operands.Count > 1
                && instruction.Destination is LocalVariable destination
                && instruction.Operands[1] is MemoryOperand { Index: null, Scale: 0 } load)
                loads[destination] = load;
        }

        var is32Bit = method.AppContext.Binary.is32Bit;
        long pointerSize = is32Bit ? 4 : 8;
        long? invoker = Il2CppMethodInfoUsefulOffsets.TryGetOffset("invoker_method", is32Bit, out var invokerOffset) ? invokerOffset : null;

        foreach (var dispatch in instructions)
        {
            if (dispatch.OpCode is not (OpCode.IndirectCall or OpCode.IndirectJump) || dispatch.Operands.Count == 0)
                continue;

            var (lookup, path) = Trace(dispatch.Operands[0], lookups, closures, loads, pointerSize, invoker);

            if (lookup is null)
                continue;

            var source = ClassSourceOf(lookup.Operands[InterfaceInvokeDataRecovery.InterfaceOperand], instructions);
            var contract = InterfaceInvokeDataRecovery.InterfaceOf(lookup.Operands[InterfaceInvokeDataRecovery.InterfaceOperand]);
            var target = contract is null ? null : InterfaceInvokeDataRecovery.MethodOfSlot(contract, lookup.Operands[InterfaceInvokeDataRecovery.SlotOperand]);
            var reason = contract is null ? "CLASS_NOT_AN_INTERFACE_POINTER"
                : target is null ? "SLOT_NAMES_NO_METHOD"
                : path == MethodPointerPath ? "LOOKUPS_DISAGREE_OR_LATE"
                : "DISPATCH_PATH_NOT_RECOVERED";

            var family = $"{path}:{source}:{reason}";

            lock (CountLock)
                FamilyCounts[family] = FamilyCounts.GetValueOrDefault(family) + 1;

            WriteEvidence(method, dispatch, lookup, target, family);
        }
    }

    /// <summary>
    /// Which lookup's result reaches <paramref name="pointerOperand"/>, and by which path.
    /// </summary>
    public static (Instruction? Lookup, string Path) Trace(
        IOperand pointerOperand,
        IReadOnlyList<Instruction> lookups,
        IReadOnlyDictionary<Instruction, HashSet<LocalVariable>> closures,
        IReadOnlyDictionary<LocalVariable, MemoryOperand> loads,
        long pointerSize,
        long? invokerOffset)
    {
        MemoryOperand? pointer = pointerOperand switch
        {
            MemoryOperand inlined => inlined,
            LocalVariable local when loads.TryGetValue(local, out var loaded) => loaded,
            _ => null,
        };

        if (pointer is not { Base: LocalVariable first, Index: null, Scale: 0 } outer)
            return (null, NoLookup);

        foreach (var lookup in lookups)
        {
            if (closures[lookup].Contains(first))
                return (lookup, MethodPointerPath);
        }

        // One more load: the pointer is read out of a structure the lookup's result points at.
        if (!loads.TryGetValue(first, out var inner) || inner is not { Base: LocalVariable second, Index: null, Scale: 0 })
            return (null, NoLookup);

        foreach (var lookup in lookups)
        {
            if (!closures[lookup].Contains(second))
                continue;

            return inner.Addend == pointerSize && invokerOffset is { } invoker && outer.Addend == invoker
                ? (lookup, InvokerPath)
                : (lookup, OtherTwoLoadPath);
        }

        return (null, NoLookup);
    }

    /// <summary>Where a lookup's interface class operand came from.</summary>
    public static string ClassSourceOf(IOperand operand, IReadOnlyList<Instruction> instructions)
    {
        if (operand is RuntimeClassTypeAnalysisContext)
            return FromMetadataUsage;

        if (operand is MemoryOperand { Base: LocalVariable { Type: RgctxTableTypeAnalysisContext or MethodRgctxTableTypeAnalysisContext } })
            return FromRgctx;

        if (operand is not LocalVariable local)
            return FromUnknown;

        var producer = PointerProvenance.Producer(local, l => [.. instructions.Where(i => ReferenceEquals(i.Destination, l))]);

        if (producer is { OpCode: OpCode.Move } && producer.Operands.Count > 1)
        {
            switch (producer.Operands[1])
            {
                case RuntimeClassTypeAnalysisContext:
                    return FromMetadataUsage;
                case MemoryOperand { Base: LocalVariable { Type: RgctxTableTypeAnalysisContext or MethodRgctxTableTypeAnalysisContext } }:
                    return FromRgctx;
                case MemoryOperand { Base: LocalVariable { Type: RuntimeMethodInfoAnalysisContext } }:
                    return "METHODINFO_FIELD";
                case MemoryOperand { Base: LocalVariable { Type: RuntimeClassTypeAnalysisContext } }:
                    return "CLASS_FIELD";
            }
        }

        return local.Type is RuntimeClassTypeAnalysisContext ? FromTypedLocal : FromUnknown;
    }

    private static void WriteEvidence(MethodAnalysisContext caller, Instruction dispatch, Instruction lookup, MethodAnalysisContext? target, string family)
    {
        if (string.IsNullOrEmpty(EvidencePath))
            return;

        var definition = (target as ConcreteGenericMethodAnalysisContext)?.BaseMethodContext ?? target;
        string[] row =
        [
            $"{caller.DeclaringType?.FullName}::{caller.Name}",
            dispatch.OpCode == OpCode.IndirectJump ? "TAIL" : "CALL",
            lookup.Operands[2].ToString() ?? "",
            lookup.Operands[InterfaceInvokeDataRecovery.InterfaceOperand].ToString() ?? "",
            lookup.Operands[InterfaceInvokeDataRecovery.SlotOperand].ToString() ?? "",
            definition is null ? "" : $"{definition.DeclaringType?.FullName}::{definition.Name}",
            definition is null ? "" : $"0x{definition.Definition?.token ?? 0:X8}",
            "RUNTIME_DISPATCH",
            "",
            "UNRESOLVED",
            family,
        ];

        lock (CountLock)
            System.IO.File.AppendAllText(EvidencePath, string.Join('\t', row.Select(cell => cell.Replace('\t', ' ').Replace('\n', ' '))) + "\n");
    }
}
