using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: recognises the fast path of <c>List&lt;T&gt;.Add</c> that il2cpp inlined into its
/// caller, and puts the call back.
/// </summary>
/// <remarks>
/// <para>
/// The operation compiles to
/// <c>_version++; var items = _items; var size = _size; if (size &lt; items.Length) { _size = size + 1;
/// items[size] = item; } else AddWithResize(item);</c>, so a caller ends up naming three private
/// fields of <c>List&lt;T&gt;</c>. Iteration 055 measured those per call site rather than per member
/// name and found they are not three defects but one: every <c>_items</c> error reads the whole
/// backing array, every <c>_size</c> error is a store, and all of them belong to this one shape.
/// </para>
/// <para>
/// The anchor is the slow path's own call. <c>AddWithResize</c> is private to <c>List&lt;T&gt;</c>
/// and the framework calls it from <c>Add</c> and nowhere else, so a resolved call to it names the
/// operation, the receiver and the value outright - evidence the binary carries rather than a shape
/// guessed from an array write. That is what keeps an ordinary array store, a custom collection, an
/// indexer setter, <c>Insert</c>, <c>RemoveAt</c> and a dictionary write out of the family: none of
/// them reaches this pass at all. The structural checks that follow do not identify the operation -
/// they establish that the region about to be deleted is <em>this</em> receiver's fast path, which
/// is the one thing the call alone does not say.
/// </para>
/// <para>
/// Runs after <see cref="ArrayRecovery"/>, where <c>items.Length</c> is an <see cref="ArrayLength"/>
/// rather than a load at an offset, the field accesses have been folded into the instructions that
/// consumed them, and SSA has been destructed so the merge below carries no phi to repair. A pass
/// that matches a shape must be written against the shape at the point it runs.
/// </para>
/// </remarks>
public static class InlineListAddRecovery
{
    private const InlineOperationRecovery.Family Kind = InlineOperationRecovery.Family.ListAdd;

    /// <summary>
    /// The three questions this rule has to ask the metadata, behind a seam.
    /// </summary>
    /// <remarks>
    /// Everything else the rule does is control flow and dataflow over the graph, and that is the
    /// half worth testing - that an ordinary array write, a custom collection, an indexer setter and
    /// a dictionary write are all turned down for a reason that can be named. Behind this seam those
    /// tests need no metadata to run at all, which is the same arrangement
    /// <see cref="NestedFieldResolver"/> is written over and for the same reason.
    /// </remarks>
    public sealed class Recognisers
    {
        /// <summary>Whether a call's target operand is <c>List&lt;T&gt;.AddWithResize</c>.</summary>
        public required Func<IOperand, bool> IsAddWithResize { get; init; }

        /// <summary>Whether an operand reads the named field directly off the given local.</summary>
        public required Func<IOperand, LocalVariable, string, bool> IsFieldOf { get; init; }

        /// <summary>The <c>Add</c> to call in place of the given <c>AddWithResize</c> target.</summary>
        public required Func<IOperand, IOperand?> AddFor { get; init; }
    }

    /// <summary>The recognisers backed by the metadata, which is what the pipeline runs with.</summary>
    public static Recognisers Metadata { get; } = new()
    {
        IsAddWithResize = static operand => operand is MethodAnalysisContext method && IsAddWithResize(method),
        IsFieldOf = static (operand, receiver, name) => operand is FieldReference { ElementIndex: null } reference
            && reference.Field.Name == name
            && reference.ContainingFields.Count == 0
            && ReferenceEquals(reference.Local, receiver),
        AddFor = static operand => operand is MethodAnalysisContext method ? MethodNamed(method, "Add") : null,
    };

    /// <summary>
    /// The one place the list type is named.
    /// </summary>
    public static bool IsAddWithResize(MethodAnalysisContext method)
        => method.Name == "AddWithResize"
            && method.Parameters.Count == 1
            && !method.IsStatic
            && DefinitionOf(method.DeclaringType) is { } definition
            && definition.FullName is "System.Collections.Generic.List`1";

    /// <returns>true when anything was rewritten, so the caller knows to tidy the graph.</returns>
    public static bool Run(ISILControlFlowGraph cfg, MethodAnalysisContext? method)
        => Run(cfg, method, Metadata);

    /// <returns>true when anything was rewritten, so the caller knows to tidy the graph.</returns>
    public static bool Run(ISILControlFlowGraph cfg, MethodAnalysisContext? method, Recognisers recognisers)
    {
        var rewroteAny = false;

        // ToList: a match detaches blocks, and the collection must not be walked while that happens.
        foreach (var block in cfg.Blocks.ToList())
        {
            foreach (var instruction in block.Instructions.ToList())
            {
                if (!IsAnchor(instruction, recognisers))
                    continue;

                InlineOperationRecovery.CountCandidate();

                if (TryRewrite(cfg, block, instruction, method, recognisers))
                    rewroteAny = true;
            }
        }

        return rewroteAny;
    }

    private static bool IsAnchor(Instruction instruction, Recognisers recognisers)
        // AddWithResize returns void, but a Call with an unused return operand is emitted too.
        => instruction.OpCode is OpCode.CallVoid or OpCode.Call
            && instruction.Operands.Count > 0
            && recognisers.IsAddWithResize(instruction.Operands[0]);

    private static bool TryRewrite(
        ISILControlFlowGraph cfg,
        Block slowBlock,
        Instruction call,
        MethodAnalysisContext? method,
        Recognisers recognisers)
    {
        var argumentStart = call.OpCode == OpCode.CallVoid ? 1 : 2;

        if (call.Operands.Count < argumentStart + 2)
            return Reject("call carries no receiver and value");

        if (call.Operands[argumentStart] is not LocalVariable receiver)
            return Reject("receiver is not a local");

        // The guard is the block the slow path is branched to from. Anything else - several
        // predecessors, or a predecessor that does not end in a two-way branch - means the region
        // is not the shape this rule deletes, whatever the call says.
        if (slowBlock.Predecessors.Count != 1)
            return Reject($"slow path has {slowBlock.Predecessors.Count} predecessors");

        var guard = slowBlock.Predecessors[0];

        if (guard.Instructions.Count == 0 || guard.Instructions[^1] is not { OpCode: OpCode.ConditionalJump } terminator)
            return Reject("guard does not end in a conditional branch");

        if (guard.Successors.Count != 2)
            return Reject($"guard has {guard.Successors.Count} successors");

        var fast = guard.Successors[0] == slowBlock ? guard.Successors[1] : guard.Successors[0];

        if (fast == slowBlock)
            return Reject("both edges of the guard reach the slow path");

        // The fast path must be this branch's alone, or deleting it takes code with it that another
        // edge still needs.
        if (fast.Predecessors.Count != 1 || fast.Predecessors[0] != guard)
            return Reject($"fast path has {fast.Predecessors.Count} predecessors");

        // The capacity test is what ties the region to this receiver: it reads this list's size and
        // the length of the array this list's _items holds.
        if (!GuardTestsCapacityOf(cfg, terminator, receiver, recognisers, out var itemsOfReceiver))
            return Reject(itemsOfReceiver ?? "no comparison against the receiver's size");

        // And the fast path must be the one that updates this receiver's size.
        if (!StoresTo(fast, receiver, "_size", recognisers))
            return Reject("fast path does not update the receiver's size");

        if (recognisers.AddFor(call.Operands[0]) is not { } add)
            return Reject("List<T>.Add not found on the declaring type");

        // The version bump is Add's own, so it goes with the call rather than staying beside it.
        DropVersionBump(guard, receiver, recognisers);

        call.SetOperand(0, add);

        // Every path now reaches the call. The loads that fed the capacity test, and the whole fast
        // path, are left with nothing reading them for the graph tidy-up to collect.
        terminator.OpCode = OpCode.Jump;
        terminator.SetOperands(slowBlock);

        guard.Successors.Remove(fast);
        fast.Predecessors.Remove(guard);
        guard.CalculateBlockType();

        if (method is not null)
            InlineOperationRecovery.CountMatch(Kind, method);

        return true;

        static bool Reject(string reason)
        {
            InlineOperationRecovery.CountRejection(Kind, reason);
            return false;
        }
    }

    /// <summary>
    /// Removes the <c>_version++</c> the inlined fast path performs, which <c>Add</c> performs itself.
    /// </summary>
    /// <remarks>
    /// Walks back from the guard only while each block has a single predecessor and a single
    /// successor, so the store removed is the one this region performed. Searching the whole body
    /// instead would take a second Add's bump on the same list with it, and if that one did not go on
    /// to match, its version would stop being incremented at all.
    /// </remarks>
    private static void DropVersionBump(Block guard, LocalVariable receiver, Recognisers recognisers)
    {
        var block = guard;

        for (var depth = 0; depth < 4 && block is not null; depth++)
        {
            foreach (var instruction in block.Instructions)
            {
                if (instruction.OpCode != OpCode.Move
                    || instruction.Operands.Count == 0
                    || !recognisers.IsFieldOf(instruction.Operands[0], receiver, "_version"))
                    continue;

                instruction.OpCode = OpCode.Nop;
                instruction.SetOperands();
                return;
            }

            block = block.Predecessors is [{ Successors.Count: 1 } single] ? single : null;
        }
    }

    /// <summary>
    /// Whether the branch is taken on <c>receiver._size &lt; receiver._items.Length</c>.
    /// </summary>
    /// <param name="failure">
    /// What the other half of a comparison against the receiver's size turned out to be, so a report
    /// can tell "the shape is not here" from "the shape is here and one half of it did not resolve".
    /// </param>
    private static bool GuardTestsCapacityOf(
        ISILControlFlowGraph cfg,
        Instruction terminator,
        LocalVariable receiver,
        Recognisers recognisers,
        out string? failure)
    {
        failure = null;

        if (terminator.Operands.Count < 2 || terminator.Operands[1] is not LocalVariable condition)
            return false;

        var definitions = DefinitionsIn(cfg);

        // The condition reaches the comparison through the inversions the lifter leaves behind: A64
        // has no branch on "not less than", so the guard is the negation of the capacity test.
        var current = condition;

        for (var depth = 0; depth < 8; depth++)
        {
            if (!definitions.TryGetValue(current, out var definition))
                return false;

            switch (definition.OpCode)
            {
                case OpCode.Not or OpCode.Move when definition.Operands.Count > 1 && definition.Operands[1] is LocalVariable next:
                    current = next;
                    continue;

                case OpCode.CheckLess or OpCode.CheckGreater or OpCode.CheckLessOrEqual or OpCode.CheckGreaterOrEqual:
                    if (definition.Operands.Count < 3)
                        return false;

                    var size = recognisers.IsFieldOf(definition.Operands[1], receiver, "_size")
                        ? definition.Operands[2]
                        : recognisers.IsFieldOf(definition.Operands[2], receiver, "_size")
                            ? definition.Operands[1]
                            : null;

                    if (size is null)
                        return false;

                    if (IsLengthOfTheReceiversItems(size, receiver, definitions, recognisers))
                        return true;

                    failure = $"size compared against {Describe(size, definitions)}";
                    return false;

                default:
                    return false;
            }
        }

        return false;
    }

    /// <summary>What the far side of a capacity test turned out to be, for the rejection breakdown.</summary>
    private static string Describe(IOperand operand, Dictionary<LocalVariable, Instruction> definitions)
    {
        if (operand is ArrayLength length)
        {
            return definitions.TryGetValue(length.Array, out var lengthDefinition)
                ? $"ArrayLength of a local defined by {lengthDefinition.OpCode} {DescribeShallow(lengthDefinition.Operands.Count > 1 ? lengthDefinition.Operands[1] : null)}"
                : "ArrayLength of a local defined outside the block";
        }

        if (operand is LocalVariable local)
        {
            return definitions.TryGetValue(local, out var definition)
                ? $"local defined by {definition.OpCode} {DescribeShallow(definition.Operands.Count > 1 ? definition.Operands[1] : null)}"
                : "local defined outside the block";
        }

        return DescribeShallow(operand);
    }

    private static string DescribeShallow(IOperand? operand) => operand switch
    {
        null => "nothing",
        FieldReference reference => $"field {reference.Field.Name}",
        ArrayLength => "ArrayLength",
        MemoryOperand memory => $"memory+0x{memory.Addend:X}",
        LocalVariable => "local",
        _ => operand.GetType().Name,
    };

    /// <summary>
    /// Whether an operand is the length of the array the receiver's <c>_items</c> holds, either read
    /// straight off the field or through the local it was loaded into inside this block.
    /// </summary>
    private static bool IsLengthOfTheReceiversItems(
        IOperand operand,
        LocalVariable receiver,
        Dictionary<LocalVariable, Instruction> definitions,
        Recognisers recognisers)
    {
        if (operand is not ArrayLength length)
            return false;

        if (recognisers.IsFieldOf(length.Array, receiver, "_items"))
            return true;

        return definitions.TryGetValue(length.Array, out var definition)
            && definition.OpCode == OpCode.Move
            && definition.Operands.Count > 1
            && recognisers.IsFieldOf(definition.Operands[1], receiver, "_items");
    }

    private static bool StoresTo(Block block, LocalVariable receiver, string field, Recognisers recognisers)
        => block.Instructions.Any(instruction =>
            instruction.OpCode == OpCode.Move
            && instruction.Operands.Count > 0
            && recognisers.IsFieldOf(instruction.Operands[0], receiver, field));

    /// <summary>
    /// The one definition of each local written anywhere in the body. A local written twice is left
    /// out: out of SSA a name can be reused, and reading the wrong definition is how a value that
    /// belongs to another expression gets accepted as this one's.
    /// </summary>
    /// <remarks>
    /// Whole-body rather than per-block because the compiler routinely hoists the backing-array load
    /// out of the guard - 104 of the test game's 131 candidate sites read a length whose local was
    /// defined in an earlier block. The receiver check is inside the definition, not in where it
    /// sits, so widening the search does not weaken what it proves.
    /// </remarks>
    private static Dictionary<LocalVariable, Instruction> DefinitionsIn(ISILControlFlowGraph cfg)
    {
        Dictionary<LocalVariable, Instruction> definitions = [];
        HashSet<LocalVariable> ambiguous = [];

        foreach (var instruction in cfg.AllInstructions)
        {
            if (instruction.Destination is not LocalVariable destination)
                continue;

            if (!definitions.TryAdd(destination, instruction))
                ambiguous.Add(destination);
        }

        foreach (var local in ambiguous)
            definitions.Remove(local);

        return definitions;
    }

    /// <summary>
    /// A sibling of <paramref name="sibling"/> by name, instantiated the same way.
    /// </summary>
    /// <remarks>
    /// A generic instance declares no members of its own, so the definition is what carries them and
    /// what comes back has to be closed again on the instance's own arguments - otherwise the call
    /// names <c>List&lt;T&gt;.Add</c> with T open, which is not a method C# can spell.
    /// </remarks>
    private static MethodAnalysisContext? MethodNamed(MethodAnalysisContext sibling, string name)
    {
        var instance = sibling.DeclaringType as GenericInstanceTypeAnalysisContext;

        if (DefinitionOf(sibling.DeclaringType) is not { } definition)
            return null;

        if (definition.Methods.FirstOrDefault(m => m.Name == name && m.Parameters.Count == 1 && !m.IsStatic) is not { } found)
            return null;

        return instance is null ? found : new ConcreteGenericMethodAnalysisContext(found, instance.GenericArguments, []);
    }

    private static TypeAnalysisContext? DefinitionOf(TypeAnalysisContext? type)
        => (type as GenericInstanceTypeAnalysisContext)?.GenericType ?? type;
}
