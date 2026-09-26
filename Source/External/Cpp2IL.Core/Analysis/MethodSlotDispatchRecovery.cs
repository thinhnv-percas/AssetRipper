using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: recovers a generic virtual or interface call, whose vtable index is read from the
/// <c>MethodInfo</c> the call site names rather than baked in as a constant.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="InterfaceDispatchRecovery"/> matches the shape where the compiler knew the slot: a
/// slow-path call carrying an immediate slot and a resolved interface. A <em>generic</em> virtual
/// call cannot have one, because the body is shared across instantiations, so the compiler reads
/// <c>method-&gt;slot</c> out of the usage it already names, indexes the receiver's vtable with it,
/// and hands the override it finds - together with the generic method's own <c>MethodInfo</c> - to
/// a runtime helper that inflates one for the other. The call then goes through the helper's
/// result.
/// </para>
/// <para>
/// So the slot never reaches the call's target, and a pass that walks back from the target finds
/// nothing. The shape is in the helper's arguments:
/// </para>
/// <code>
/// v1007 = methodof(ES3Reader::Read)
/// v468  = [v1007 + slot] &lt;&lt; 4
/// v1009 = [reader] + v468                      // receiver's klass, indexed by the slot
/// v1011 = 0x179CF80([v1009 + vtable + 8], methodof(ES3Reader::Read), ...)
///         IndirectCall [v1011 + virtualMethodPointer], ...
/// </code>
/// <para>
/// What settles it is that the slot read and the usage handed to the helper name the <em>same</em>
/// method: nothing else in a body reads one <c>MethodInfo</c>'s slot and passes that same
/// <c>MethodInfo</c> beside the result. The helper's own address is never used, so nothing here
/// depends on naming it - which matters, because <c>reports/RUNTIME_HELPER_IDENTIFICATION.md</c>
/// records that it cannot be named from its call sites alone.
/// </para>
/// <para>
/// The answer is the method the usage names. What the machine does at run time is find the
/// receiver's override and inflate it for these type arguments, which is exactly what
/// <c>callvirt</c> on that method means.
/// </para>
/// <para>
/// Both offsets are read from the measured table rather than written down. Writing one down has
/// been the same bug four times in this project, and <c>MethodInfo</c> in particular gained a field
/// in 2022 that moves everything after it.
/// </para>
/// </remarks>
public static class MethodSlotDispatchRecovery
{
    /// <summary>How far back the walk from the call target will look for the slot read.</summary>
    /// <remarks>
    /// The chain is a load, an add or two, a shift and the read - six is comfortable slack. It is
    /// bounded because the walk follows definitions and a rewritten graph can hold a cycle.
    /// </remarks>
    private const int DepthLimit = 8;

    public static bool Run(MethodAnalysisContext method)
    {
        var is32Bit = method.AppContext.Binary.is32Bit;

        if (!Il2CppMethodInfoUsefulOffsets.TryGetOffset("slot", is32Bit, out var slotOffset))
            return false;

        var entryPoints = new List<long>();

        foreach (var name in new[] { "methodPointer", "virtualMethodPointer" })
        {
            if (Il2CppMethodInfoUsefulOffsets.TryGetOffset(name, is32Bit, out var offset))
                entryPoints.Add(offset);
        }

        if (entryPoints.Count == 0)
            return false;

        var cfg = method.ControlFlowGraph;

        if (cfg is null)
            return false;

        var definitions = new Dictionary<LocalVariable, Instruction>();

        foreach (var block in cfg.Blocks)
        {
            foreach (var instruction in block.Instructions)
            {
                if (instruction.Destination is LocalVariable destination)
                    definitions[destination] = instruction;
            }
        }

        var changed = false;

        foreach (var block in cfg.Blocks.ToList())
        // A copy, because a tail call gains a Return in the block it sits in.
        foreach (var instruction in block.Instructions.ToList())
        {
            if (instruction.OpCode is not (OpCode.IndirectCall or OpCode.IndirectJump)
                || instruction.Operands.Count == 0)
                continue;

            if (DispatchedMethod(instruction.Operands[0], definitions, slotOffset, entryPoints, method) is not ({ } callee, { } inflated, var entryLoad))
                continue;

            // The register names are gone by the time this pass runs - copy propagation has put the
            // moved value in each argument slot, so the X0 slot holds a local whose home register is
            // X1. The slot order survives that and the names do not, so only the count is asked for.
            // Safe here because the call has just been rewritten from an indirect one and so has
            // never been remapped.
            if (method.AppContext.InstructionSet.CallingConventionResolver is not { } callingConventions
                || !callingConventions.HasRawArgumentLayout(instruction, method.AppContext, requireRegisterNames: false))
            {
                IsilDump.Trace(method, $"slot dispatch: {callee.FullName} identified but the call has no raw argument layout ({instruction.Operands.Count} operands)");
                continue;
            }

            var isTailCall = instruction.OpCode == OpCode.IndirectJump;

            instruction.OpCode = OpCode.Call; // the same operand layout, and the target is known now
            instruction.SetOperand(0, callee);
            callingConventions.RemapRawArguments(instruction, callee, method, requireRegisterNames: false);

            // il2cpp passes the inflated MethodInfo as the hidden final argument, and it is this
            // method's - so naming it that way is both more accurate and what frees the inflation
            // helper: with nothing left reading its result, the helper call and the whole slot
            // lookup are dead and the eliminator takes them. Leaving the local there instead keeps
            // a `Method not found` placeholder for a call the pass has just proved is scaffolding.
            var assembly = callee.DeclaringType?.DeclaringAssembly ?? method.DeclaringType?.DeclaringAssembly;

            for (var i = 1; i < instruction.Operands.Count && assembly != null; i++)
            {
                if (ReferenceEquals(instruction.Operands[i], inflated))
                    instruction.SetOperand(i, new RuntimeMethodInfoAnalysisContext(callee, assembly));
            }

            ExciseInflation(cfg, definitions, inflated, entryLoad);

            if (isTailCall)
                AppendReturn(block, instruction, callee, method);

            changed = true;
        }

        if (changed)
            DeadCodeEliminator.Run(method);

        return changed;
    }

    /// <summary>
    /// The method a dispatch is to, or null where the call is not one.
    /// </summary>
    /// <remarks>
    /// The call's target must be an entry point read off some <c>MethodInfo</c>, and that
    /// <c>MethodInfo</c> must be the result of a call that was handed both a metadata usage and a
    /// value derived from that same usage's <c>slot</c>. The direct form - where the target is read
    /// straight off a value the slot indexed - is accepted as well, because a non-generic dispatch
    /// compiled this way needs no inflation and so no helper.
    /// </remarks>
    private static (MethodAnalysisContext Callee, LocalVariable Inflated, Instruction? EntryLoad)? DispatchedMethod(
        IOperand target,
        Dictionary<LocalVariable, Instruction> definitions,
        long slotOffset,
        List<long> entryPoints,
        MethodAnalysisContext method)
    {
        // The entry-point read reaches this pass in two shapes, because the pass runs twice: inside
        // SSA the load is its own instruction, and after copy propagation it has been folded into
        // the call's target operand. Matching only one is what a pass that never fires looks like.
        // The instruction that performed the entry-point read, where it is still its own. It is
        // dead once the dispatch is rewritten, and has to be named so that the excision below does
        // not mistake it for a live reader of the inflated MethodInfo.
        Instruction? entryLoad = target is LocalVariable holderLocal && definitions.TryGetValue(holderLocal, out var loadInstruction)
            && loadInstruction is { OpCode: OpCode.Move, Operands: [_, MemoryOperand] }
            ? loadInstruction
            : null;

        MemoryOperand? entry = target switch
        {
            MemoryOperand folded => folded,
            LocalVariable when entryLoad is { Operands: [_, MemoryOperand read] } => read,
            _ => null,
        };

        if (entry is not { Index: null, Scale: 0, Base: LocalVariable holder } slot
            || !entryPoints.Contains(slot.Addend))
        {
            IsilDump.Trace(method, $"slot dispatch: target {target} is not an entry-point read (entry points {string.Join(",", entryPoints)})");
            return null;
        }

        if (!definitions.TryGetValue(holder, out var producer))
        {
            IsilDump.Trace(method, $"slot dispatch: nothing defines {holder}");
            return null;
        }

        // The direct form: the target was read off something the slot itself indexed.
        if (producer.OpCode is not (OpCode.Call or OpCode.CallVoid))
            return SlotRead(producer, definitions, slotOffset) is { } direct ? (direct, holder, entryLoad) : null;

        // The helper form: one argument is the usage, another is derived from that usage's slot.
        for (var i = 1; i < producer.Operands.Count; i++)
        {
            if (producer.Operands[i] is not RuntimeMethodInfoAnalysisContext { RepresentedMethod: { } named })
                continue;

            for (var j = 1; j < producer.Operands.Count; j++)
            {
                if (j == i)
                    continue;

                var read = SlotRead(producer.Operands[j], definitions, slotOffset);

                if (read is null)
                    continue;

                if (ReferenceEquals(read, named))
                    return (named, holder, entryLoad);

                IsilDump.Trace(method, $"slot dispatch: slot read names {read.FullName} but the usage names {named.FullName} (same={ReferenceEquals(read, named)})");
            }
        }

        IsilDump.Trace(method, $"slot dispatch: no usage/slot pair among {producer.Operands.Count} operands of {producer.OpCode}");
        return null;

    }

    /// <summary>The method whose <c>slot</c> an operand was derived from, if any.</summary>
    private static MethodAnalysisContext? SlotRead(
        IOperand? operand,
        Dictionary<LocalVariable, Instruction> definitions,
        long slotOffset)
    {
        var seen = new HashSet<LocalVariable>();

        return Walk(operand, 0);

        MethodAnalysisContext? Walk(IOperand? current, int depth)
        {
            if (depth > DepthLimit)
                return null;

            switch (current)
            {
                case MemoryOperand memory:
                    // The read itself: `[MethodInfo<M> + slot]`, off a resolved metadata usage.
                    if (memory is { Index: null, Scale: 0 }
                        && memory.Addend == slotOffset
                        && memory.Base is LocalVariable { Type: RuntimeMethodInfoAnalysisContext { RepresentedMethod: { } represented } })
                        return represented;

                    return Walk(memory.Base, depth + 1) ?? Walk(memory.Index, depth + 1);

                case LocalVariable local:
                    if (!seen.Add(local) || !definitions.TryGetValue(local, out var definition))
                        return null;

                    // Only address arithmetic is followed through. A call is not: its result is
                    // whatever the callee returned, and reading through one would claim a dispatch
                    // on evidence that stops at the call.
                    if (definition.OpCode is not (OpCode.Move or OpCode.Add or OpCode.ShiftLeft or OpCode.Phi))
                        return null;

                    for (var i = 1; i < definition.Operands.Count; i++)
                    {
                        if (Walk(definition.Operands[i], depth + 1) is { } found)
                            return found;
                    }

                    return null;

                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// Removes the runtime inflation whose result the rewritten dispatch no longer needs.
    /// </summary>
    /// <remarks>
    /// Dead code elimination will not take it: the helper is an unresolved call, which the sweep
    /// treats as an effect and so as a root, however dead its result is. That is the right default -
    /// but this pass has just identified the call from its own arguments, so here it is known to be
    /// the runtime finding and inflating the override, which is what <c>callvirt</c> now expresses.
    /// Only ever removed once nothing reads its result, so a second dispatch through the same
    /// inflation keeps it until that one is rewritten too.
    /// </remarks>
    private static void ExciseInflation(
        ISILControlFlowGraph cfg,
        Dictionary<LocalVariable, Instruction> definitions,
        LocalVariable inflated,
        Instruction? entryLoad)
    {
        if (!definitions.TryGetValue(inflated, out var producer) || producer.OpCode is not (OpCode.Call or OpCode.CallVoid))
            return;

        // Inside SSA the entry-point read is still its own instruction, and it reads the very value
        // being freed. It is dead by construction - the dispatch that consumed it is now a Call - so
        // it is removed rather than counted as a use, or the excision can never fire at that
        // placement and fires only at the later one, which is how this pass first measured as inert.
        if (entryLoad is not null)
        {
            entryLoad.OpCode = OpCode.Nop;
            entryLoad.SetOperands();
        }

        foreach (var block in cfg.Blocks)
        {
            foreach (var instruction in block.Instructions)
            {
                if (ReferenceEquals(instruction, producer))
                    continue;

                for (var i = 0; i < instruction.Operands.Count; i++)
                {
                    if (Reads(instruction.Operands[i], inflated))
                        return;
                }
            }
        }

        producer.OpCode = OpCode.Nop;
        producer.SetOperands();

        static bool Reads(IOperand operand, LocalVariable local) => operand switch
        {
            LocalVariable candidate => ReferenceEquals(candidate, local),
            MemoryOperand memory => Reads(memory.Base, local) || (memory.Index is { } index && Reads(index, local)),
            AddressOf address => address.Target is { } inner && Reads(inner, local),
            _ => false,
        };
    }

    /// <summary>
    /// A dispatch in tail position is a call followed by a return, and the return has to be written
    /// out because the jump that used to end the block is gone.
    /// </summary>
    private static void AppendReturn(Block block, Instruction call, MethodAnalysisContext callee, MethodAnalysisContext caller)
    {
        var index = block.Instructions.IndexOf(call);

        if (index < 0)
            return;

        List<IOperand> operands = !caller.IsVoid && !callee.IsVoid && call.Operands.Count > 1
            ? [call.Operands[1]]
            : [];

        block.Instructions.Insert(index + 1, new Instruction(call.Index, OpCode.Return, operands));
    }
}
