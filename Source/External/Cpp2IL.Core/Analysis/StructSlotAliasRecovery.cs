using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: a struct on the stack whose address is handed to a call is one piece of memory, and a
/// word inside it read after the hand-off is a field of it, not the value the word held before.
/// </summary>
/// <remarks>
/// <para>
/// The stack analysis names every slot after its own offset, so a 24-byte <c>List&lt;T&gt;.Enumerator</c>
/// at <c>stack_-48</c> has its element word at <c>stack_-38</c>, a local of its own. <c>foreach</c>
/// hands <c>&amp;stack_-48</c> to <c>MoveNext</c>, which writes the element through the pointer; the
/// ISIL says nothing wrote <c>stack_-38</c>, so SSA gives the loop body the element as it was
/// <em>before</em> the first <c>MoveNext</c>. The body compiles, reads like the source, and processes
/// the default element every time - the true alias the storage hazard classification exists to find,
/// one level finer than it looks: the two names are different slots, not versions of one.
/// </para>
/// <para>
/// A read is rewritten only where the order is a fact: the hand-off dominates the read, and the word's
/// own definition does not follow the hand-off - a word written after the call holds what was
/// written. A phi is never rewritten, since its inputs are read at the end of each predecessor. And a
/// word is inside the struct only by the struct's own size, never by guess.
/// </para>
/// <para>
/// The slot's own name has the offset-zero problem at its definition. A struct returned through a
/// hidden buffer is named word by word as the call's fields, so the word at offset zero - which is the
/// slot's name, and so the whole struct whose address is handed off - is defined as the <em>first
/// field</em>. Where that is so, the definition becomes the whole returned value.
/// </para>
/// </remarks>
public static class StructSlotAliasRecovery
{
    public static int InteriorReadsRecovered;

    public static int WholeDefinitionsRecovered;

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph || method.DominatorInfo is not { } dominators)
            return;

        var pointerSize = method.AppContext.Binary.PointerSizeBytes;

        Apply(graph, dominators,
            slot => slot.Type is { IsValueType: true } type && !type.IsEnumType && TypeSizes.UnboxedSize(type, pointerSize) is > 0 and var size
                ? size
                : null,
            (slot, offset) => MetadataResolver.ValueFieldAt(slot.Type!, offset) is { } field
                ? new FieldReference(field, slot, (int)offset)
                : null,
            (defined, source) => source is FieldReference { Offset: 0, ElementIndex: null, ContainingFields.Count: 0 } whole
                && whole.Local.Type is { } returned && defined.Type is { } slotType
                && SameDefinition(returned, slotType)
                ? whole.Local
                : null,
            (member, source) => member is FieldReference wanted
                && source is FieldReference { ElementIndex: null, ContainingFields.Count: 0 } copied
                && copied.Field.Name == wanted.Field.Name
                && copied.Local.Type is { } copiedType && wanted.Local.Type is { } slotType
                && SameDefinition(copiedType, slotType));
    }

    private static bool SameDefinition(TypeAnalysisContext a, TypeAnalysisContext b)
        => ReferenceEquals(Definition(a), Definition(b));

    private static TypeAnalysisContext Definition(TypeAnalysisContext type)
        => type is GenericInstanceTypeAnalysisContext instance ? instance.GenericType : type;

    /// <param name="structSize">The size of the struct a stack slot holds, or null when it is not a struct.</param>
    /// <param name="interior">The operand naming the member of a slot at a value-relative offset, or null.</param>
    /// <param name="wholeOf">For a slot defined from the offset-zero field of a value of the same struct, that value.</param>
    public static void Apply(ISILControlFlowGraph graph, DominatorInfo dominators,
        System.Func<LocalVariable, long?> structSize,
        System.Func<LocalVariable, long, IOperand?> interior,
        System.Func<LocalVariable, IOperand, LocalVariable?> wholeOf,
        System.Func<IOperand, IOperand, bool> sameMember)
    {
        var position = new Dictionary<Instruction, (Block Block, int Index)>();
        foreach (var block in graph.Blocks)
            for (var i = 0; i < block.Instructions.Count; i++)
                position[block.Instructions[i]] = (block, i);

        var definitions = new Dictionary<LocalVariable, Instruction>();
        foreach (var instruction in position.Keys)
            if (StorageIdentities.DestinationPosition(instruction) is var at and >= 0
                && at < instruction.Operands.Count
                && instruction.Operands[at] is LocalVariable defined)
                definitions.TryAdd(defined, instruction);

        // Where a slot's address is put in a register, the calls that take that register.
        var addressHolders = new Dictionary<LocalVariable, LocalVariable>();
        foreach (var instruction in position.Keys)
            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable holder, AddressOf { Target: LocalVariable slot }] }
                && StackOffsetOf(slot) is not null)
                addressHolders[holder] = slot;

        var handOffs = new List<(Instruction Call, LocalVariable Slot, long Size)>();
        foreach (var instruction in position.Keys)
        {
            if (instruction.OpCode is not (OpCode.Call or OpCode.CallVoid))
                continue;

            var first = instruction.OpCode == OpCode.CallVoid ? 1 : 2;
            for (var i = first; i < instruction.Operands.Count; i++)
            {
                var slot = instruction.Operands[i] switch
                {
                    AddressOf { Target: LocalVariable direct } when StackOffsetOf(direct) is not null => direct,
                    LocalVariable holder when addressHolders.TryGetValue(holder, out var held) => held,
                    _ => null,
                };

                if (slot != null && structSize(slot) is { } size)
                    handOffs.Add((instruction, slot, size));
            }
        }

        foreach (var (call, slot, size) in handOffs)
        {
            var slotOffset = StackOffsetOf(slot)!.Value;
            var (callBlock, callIndex) = position[call];

            if (definitions.TryGetValue(slot, out var slotDefinition)
                && slotDefinition.OpCode == OpCode.Move
                && slotDefinition.Operands.Count > 1
                && wholeOf(slot, ThroughCopies(slotDefinition.Operands[1], definitions)) is { } whole)
            {
                slotDefinition.SetOperand(1, whole);
                Interlocked.Increment(ref WholeDefinitionsRecovered);
            }

            foreach (var (instruction, (block, index)) in position)
            {
                if (instruction.OpCode == OpCode.Phi || !After(dominators, callBlock, callIndex, block, index))
                    continue;

                var destination = StorageIdentities.DestinationPosition(instruction);

                for (var operand = 0; operand < instruction.Operands.Count; operand++)
                {
                    if (operand == destination || instruction.Operands[operand] is not LocalVariable word)
                        continue;

                    if (StackOffsetOf(word) is not { } wordOffset || wordOffset <= slotOffset || wordOffset >= slotOffset + size)
                        continue;

                    // The word must be demonstrably a copy of this member: defined, before the hand-off,
                    // as the member at the same offset of a value of the same struct. A word with no
                    // definition, or one written after the hand-off, holds something this says nothing
                    // about - reading it as the member there named a string as an enumerator's element.
                    if (!definitions.TryGetValue(word, out var wordDefinition)
                        || wordDefinition is not { OpCode: OpCode.Move, Operands.Count: > 1 }
                        || (position.TryGetValue(wordDefinition, out var at) && After(dominators, callBlock, callIndex, at.Block, at.Index)))
                        continue;

                    if (interior(slot, wordOffset - slotOffset) is not { } member
                        || !sameMember(member, ThroughCopies(wordDefinition.Operands[1], definitions)))
                        continue;

                    instruction.SetOperand(operand, member);
                    Interlocked.Increment(ref InteriorReadsRecovered);
                }
            }
        }
    }

    /// <summary>
    /// What a value was copied from, through straight local-to-local moves. A struct is routinely copied
    /// out of the buffer it came back in, through one vector register and one integer one, so the slot
    /// that is iterated is defined as a copy of a copy of the returned value's first field.
    /// </summary>
    private static IOperand ThroughCopies(IOperand source, Dictionary<LocalVariable, Instruction> definitions)
    {
        for (var step = 0; step < 8 && source is LocalVariable copied
             && definitions.TryGetValue(copied, out var definition)
             && definition is { OpCode: OpCode.Move, Operands: [LocalVariable, var from] }; step++)
            source = from;

        return source;
    }

    /// <summary>The frame offset a stack slot local is named after, or null for anything else.</summary>
    public static long? StackOffsetOf(LocalVariable local)
    {
        var name = local.Register.Name;
        if (name is null || !name.StartsWith("stack_", System.StringComparison.Ordinal))
            return null;

        var text = name["stack_".Length..];
        var negative = text.StartsWith('-');
        if (negative)
            text = text[1..];

        return long.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var value)
            ? negative ? -value : value
            : null;
    }

    private static bool After(DominatorInfo dominators, Block earlierBlock, int earlierIndex, Block block, int index)
        => ReferenceEquals(block, earlierBlock) ? index > earlierIndex : dominators.Dominates(earlierBlock, block);
}
