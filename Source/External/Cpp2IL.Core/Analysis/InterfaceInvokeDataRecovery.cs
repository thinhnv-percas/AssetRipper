using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: an interface call that il2cpp compiled as a runtime lookup rather than as a table
/// read, recovered from the lookup's own arguments.
/// </summary>
/// <remarks>
/// <para>
/// Generated code reaches an interface method two ways. Where the receiver's class is known at
/// compile time the compiler emits the interface offset and the slot inline, which is what
/// <see cref="InterfaceDispatchRecovery"/> matches. Where it is not - shared generic code, or a
/// receiver typed as the interface - it calls a runtime helper with the receiver, the interface's
/// <c>Il2CppClass*</c> and the slot index, and calls through the <c>VirtualInvokeData</c> the helper
/// hands back. The helper is not exported and no managed method sits at its address, so the call
/// stays unresolved and the dispatch reaches the generator as an indirect call through a pointer
/// nothing could name.
/// </para>
/// <para>
/// Nothing here needs the helper's address, and nothing here may depend on one: an address is a
/// property of one build. What identifies the helper is the shape of its call site, and that shape
/// carries the whole answer - the second argument is the runtime class of an <em>interface</em>, the
/// third is an immediate smaller than that interface's method count, and what it returns is
/// dereferenced and called. Three independent conditions, each of which a call that is not this
/// helper fails.
/// </para>
/// <para>
/// The match runs <b>forwards</b>, from the lookup to the dispatch, rather than backwards from the
/// dispatch to the lookup. It has to: the helper has an inline fast path, so the pointer the
/// dispatch reads is a phi of the helper's result and a vtable address the compiler computed
/// itself, and a backward walk correctly refuses to pick one input of a merge. Walking forwards asks
/// a question that has one answer - what does this lookup's result reach - and both branches of that
/// merge are the same dispatch, which is why the fast path exists at all.
/// </para>
/// <para>
/// The slot is the index of the method within the interface, which is how the runtime uses it:
/// <c>vtable[interfaceOffset + slot]</c>, where the offset comes from the receiver's own class at run
/// time and the slot from the interface. So the interface method is exactly
/// <c>interface.Methods[slot]</c>, and that is what a C# source would have named - which
/// implementation runs is the receiver's business, not the call site's. On a generic interface the
/// methods belong to the definition and the call is instantiated on the arguments the operand
/// carries, the same way <see cref="DelegateInvokeRecovery"/> reaches a generic delegate's Invoke.
/// </para>
/// </remarks>
public static class InterfaceInvokeDataRecovery
{
    /// <summary>
    /// The operand index of the interface's runtime class: the second argument register.
    /// </summary>
    /// <remarks>
    /// A call's operand 0 is its target and operand 1 its return value, so the arguments begin at 2
    /// and are the raw register file - an unresolved call has no signature to name them by. The
    /// first is the receiver, the second the interface's class and the third the slot, which is what
    /// the helper's own prologue does with them: <c>ldr x21,[x0]</c>, <c>mov x20,x1</c>,
    /// <c>mov w19,w2</c>.
    /// </remarks>
    public const int InterfaceOperand = 3;

    /// <summary>The operand index of the slot: the third argument register.</summary>
    public const int SlotOperand = 4;

    /// <summary>How many interface dispatches have been recovered, for the recovery summary.</summary>
    public static int Recovered;


    public static bool Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return false;

        var instructions = graph.AllInstructions.ToList();

        // The lookups first: there are few of them and each one decides a dispatch, so the reverse
        // search - every indirect call, asking what produced its pointer - would be the expensive
        // direction as well as the one a merge defeats.
        var lookups = instructions
            .Where(IsLookupShape)
            .Select(lookup => (Lookup: lookup, Target: TargetOf(lookup)))
            .Where(pair => pair.Target is not null)
            .ToList();

        if (lookups.Count == 0)
            return false;

        var loads = new Dictionary<LocalVariable, MemoryOperand>();

        foreach (var instruction in instructions)
        {
            if (instruction.OpCode == OpCode.Move
                && instruction.Operands.Count > 1
                && instruction.Destination is LocalVariable destination
                && instruction.Operands[1] is MemoryOperand { Index: null, Scale: 0 } load)
                loads[destination] = load;
        }

        // A dispatch reached from two lookups that disagree is not a dispatch this pass knows, and
        // recording the disagreement is what keeps it from resolving to whichever came first.
        var byDispatch = new Dictionary<Instruction, MethodAnalysisContext?>();
        var lookupsOf = new Dictionary<Instruction, List<Instruction>>();

        foreach (var (lookup, target) in lookups)
        {
            var reached = ForwardClosure(lookup.Destination, instructions);

            foreach (var instruction in instructions)
            {
                if (instruction.OpCode != OpCode.IndirectCall || instruction.Operands.Count == 0)
                    continue;

                if (PointerLoad(instruction.Operands[0], loads) is not { Base: LocalVariable pointerBase } pointer
                    || pointer.Index is not null
                    || pointer.Scale != 0
                    || !reached.Contains(pointerBase))
                    continue;

                if (byDispatch.TryGetValue(instruction, out var already) && !ReferenceEquals(already, target))
                {
                    byDispatch[instruction] = null;
                    continue;
                }

                byDispatch[instruction] = target;

                if (!lookupsOf.TryGetValue(instruction, out var sources))
                    lookupsOf[instruction] = sources = [];

                sources.Add(lookup);
            }
        }

        var changed = false;

        foreach (var (dispatch, target) in byDispatch)
        {
            if (target is null)
                continue;

            dispatch.OpCode = OpCode.Call; // the same operand layout as IndirectCall, and it is resolved now
            dispatch.SetOperand(0, target);
            target.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(dispatch, target, method);

            // The lookup is what the dispatch used to need; once the call names its method nothing
            // reads it. It has to be removed here rather than left to dead code elimination, which
            // keeps an unresolved call for its side effects.
            foreach (var lookup in lookupsOf[dispatch])
            {
                lookup.OpCode = OpCode.Nop;
                lookup.SetOperands();
            }

            System.Threading.Interlocked.Increment(ref Recovered);
            changed = true;
        }

        return changed;
    }

    /// <summary>The method a lookup names, or null when it names none.</summary>
    private static MethodAnalysisContext? TargetOf(Instruction lookup)
        => InterfaceOf(lookup.Operands[InterfaceOperand]) is { } contract
            ? MethodOfSlot(contract, lookup.Operands[SlotOperand])
            : null;

    /// <summary>
    /// Whether an instruction is a call to an address no managed method sits at, returning a value,
    /// with room for the three arguments the lookup takes.
    /// </summary>
    /// <remarks>
    /// A resolved call names a <see cref="MethodAnalysisContext"/>; this helper never does, because
    /// it is runtime code. Requiring the target to still be a raw address is what keeps the match
    /// from reaching a managed method that happens to return a pointer.
    /// </remarks>
    public static bool IsLookupShape(Instruction instruction)
        => instruction.OpCode is OpCode.Call
            && instruction.Operands.Count > SlotOperand
            && instruction.Operands[0] is Immediate
            && instruction.Destination is LocalVariable;

    /// <summary>
    /// Every local the value in <paramref name="produced"/> reaches through copies and merges.
    /// </summary>
    /// <remarks>
    /// Forwards, so a phi is followed rather than refused: an input of a merge is one way the value
    /// arrives, and the question here is where it can arrive, not which way it came. The reverse
    /// walk, <see cref="PointerProvenance"/>, is the one that must refuse a merge it cannot settle.
    /// </remarks>
    public static HashSet<LocalVariable> ForwardClosure(IOperand? produced, IReadOnlyList<Instruction> instructions)
    {
        var reached = new HashSet<LocalVariable>();

        if (produced is not LocalVariable start)
            return reached;

        reached.Add(start);

        // A copy can precede its source in program order once a loop is involved, so the sweep
        // repeats until it settles rather than running once.
        for (var pass = 0; pass < instructions.Count; pass++)
        {
            var grew = false;

            foreach (var instruction in instructions)
            {
                if (instruction.Destination is not LocalVariable destination || reached.Contains(destination))
                    continue;

                var carries = instruction.OpCode switch
                {
                    OpCode.Move => instruction.Operands.Count > 1 && instruction.Operands[1] is LocalVariable copied && reached.Contains(copied),
                    OpCode.Phi => instruction.Operands.Skip(1).OfType<LocalVariable>().Any(reached.Contains),
                    _ => false,
                };

                if (carries)
                    grew |= reached.Add(destination);
            }

            if (!grew)
                break;
        }

        return reached;
    }

    /// <summary>The load a dispatch reads its function pointer from, whether folded in or a Move away.</summary>
    private static MemoryOperand? PointerLoad(IOperand operand, IReadOnlyDictionary<LocalVariable, MemoryOperand> loads)
        => operand switch
        {
            MemoryOperand inlined => inlined,
            LocalVariable local when loads.TryGetValue(local, out var loaded) => loaded,
            _ => null,
        };

    /// <summary>
    /// The interface an operand names the runtime class of, or null when it names something else.
    /// </summary>
    /// <remarks>
    /// The class arrives two ways and both are the same fact: as the metadata usage itself, which is
    /// a <see cref="RuntimeClassTypeAnalysisContext"/> operand, and as a load of the usage slot,
    /// whose base is a local typed as one. An operand that is not a class pointer, or is the class
    /// of something that is not an interface, is not this shape.
    /// </remarks>
    public static TypeAnalysisContext? InterfaceOf(IOperand operand)
    {
        TypeAnalysisContext? represented = operand switch
        {
            RuntimeClassTypeAnalysisContext runtime => runtime.RepresentedType,
            LocalVariable { Type: RuntimeClassTypeAnalysisContext typed } => typed.RepresentedType,
            MemoryOperand { Base: LocalVariable { Type: RuntimeClassTypeAnalysisContext based } } => based.RepresentedType,
            _ => null,
        };

        return Definition(represented) is { IsInterface: true } ? represented : null;
    }

    /// <summary>
    /// The method an interface slot names, instantiated on the interface's own generic arguments.
    /// </summary>
    /// <remarks>
    /// A generic instance declares no members of its own - its methods belong to the definition - so
    /// the slot is looked up there and the result instantiated, which is the same two-step every
    /// other pass in this file needs on a generic instance. A slot outside the interface's methods
    /// is not this shape rather than a method to guess at.
    /// </remarks>
    public static MethodAnalysisContext? MethodOfSlot(TypeAnalysisContext contract, IOperand slotOperand)
    {
        if (slotOperand is not Immediate immediate || !TryGetSlot(immediate.Value, out var slot))
            return null;

        var instance = contract as GenericInstanceTypeAnalysisContext;
        var definition = instance?.GenericType ?? contract;
        var methods = definition.Methods;

        if (slot >= methods.Count)
            return null;

        var method = methods[slot];

        return instance is null ? method : new ConcreteGenericMethodAnalysisContext(method, instance.GenericArguments, []);
    }

    /// <summary>
    /// A slot is a small non-negative index; anything else is not a slot.
    /// </summary>
    /// <remarks>
    /// The bound matters as much as the sign. Every argument register is an operand of an unresolved
    /// call, so the third one holds a slot at a lookup and an address, a length or a pointer
    /// everywhere else - and a number that could not be a slot is the cheapest of the conditions
    /// that separate the two.
    /// </remarks>
    public static bool TryGetSlot(long value, out int slot)
    {
        slot = value < 0 || value > ushort.MaxValue ? 0 : (int)value;

        return value >= 0 && value <= ushort.MaxValue;
    }

    private static TypeAnalysisContext? Definition(TypeAnalysisContext? type)
        => type is GenericInstanceTypeAnalysisContext instance ? instance.GenericType : type;
}
