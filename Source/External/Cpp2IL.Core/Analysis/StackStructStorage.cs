using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// What <see cref="StackStructStorage"/> needs to know about a struct on the stack, so the rule is testable without
/// metadata behind it.
/// </summary>
public interface IStackStructModel
{
    /// <summary>An identity for the struct type a slot version is typed as, or null when it is not a struct.</summary>
    object? StructKey(LocalVariable version);

    /// <summary>The size in bytes of the struct a slot version is typed as.</summary>
    long StructSize(LocalVariable version);

    /// <summary>The operand naming the member of <paramref name="storage"/> that starts exactly at <paramref name="offset"/>, or null.</summary>
    IOperand? Member(LocalVariable storage, long offset);

    /// <summary>The size in bytes of the member that starts at <paramref name="offset"/>, or 0.</summary>
    long MemberSize(LocalVariable storage, long offset);

    /// <summary>The struct-typed member containing <paramref name="offset"/>: where it starts and how big it is, or null.</summary>
    (long Start, long Size)? StructMemberContaining(LocalVariable storage, long offset);

    /// <summary>Whether a value of <paramref name="source"/>'s type is what the member at <paramref name="offset"/> holds.</summary>
    bool HoldsMember(LocalVariable storage, long offset, LocalVariable source);

    /// <summary>The type of the address of the member at <paramref name="offset"/>, for the local that receives it.</summary>
    TypeAnalysisContext? AddressType(LocalVariable storage, long offset);

    /// <summary>Gives <paramref name="version"/> the struct's type.</summary>
    void Retype(LocalVariable version, LocalVariable typed);
}

/// <summary>
/// AssetRipper: iteration 067 - a struct on the stack is one storage, and a store into a slot inside it is a store into
/// one of its members.
/// </summary>
/// <remarks>
/// <para>
/// The stack analysis names every slot after its own offset, so a struct built on the stack is a handful of unrelated
/// locals: an async method's kickoff writes <c>this</c>, its arguments, the builder and the state into
/// <c>stack_-60</c>, <c>stack_-58</c>, <c>stack_-78</c> and <c>stack_-80</c>, and hands <c>&amp;stack_-80</c> to
/// <c>Builder.Start(ref stateMachine)</c>. Nothing reads the inner slots by name, so they were dropped as dead and the
/// state machine started with no <c>this</c>. Keeping them as locals of their own (iteration 066) was worse: the
/// recovered body then copied the builder's private fields one by one.
/// </para>
/// <para>
/// A struct's slot is a slot whose address is taken and which some version types as a struct; its interior is every
/// slot inside the struct's size. The whole interior has to be explained before anything is rewritten - each store a
/// member store, a run of stores that copies one value into a struct member chunk by chunk, or the zeroing that opens
/// the struct's life - and nothing may read an interior slot by name, since that slot would then be something else
/// sharing the memory. If any of that fails the struct is left exactly as it was. The address of the struct plus a
/// constant, the way <c>&amp;stateMachine.&lt;&gt;t__builder</c> is formed (an <c>orr</c> on an aligned address), is
/// the address of the member at that offset.
/// </para>
/// <para>
/// Every store is judged by the width the instruction wrote (<see cref="StackAnalyzer.StackStoreWidth"/>), never by the
/// slot's name: a member store must write exactly the member, and a chunked copy must tile the member exactly with
/// every chunk reading the same source value at the same relative offset. A sixteen-byte vector store over four floats
/// is a copy of all four, not a write of the first.
/// </para>
/// </remarks>
public static class StackStructStorage
{
    public static int StructsRecovered;
    public static int MemberStoresRecovered;
    public static int MemberCopiesRecovered;
    public static int MemberAddressesRecovered;
    public static int StructsRejected;

    public static void Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return;

        IsilDump.Stage(method, "before StackStructStorage");

        try
        {
            Apply(graph, new MetadataModel(method.AppContext.Binary.PointerSizeBytes), StackAnalyzer.StackStoreWidth);
        }
        finally
        {
            // Every provisional store is decided now: a rewritten one is a member store, a root by its destination;
            // the rest die as they did before iteration 067.
            foreach (var instruction in graph.Blocks.SelectMany(block => block.Instructions))
                StackAnalyzer.ReleaseProvisionalStructStore(instruction);
        }
    }

    public static int Apply(ISILControlFlowGraph graph, IStackStructModel model, Func<Instruction, int> widthOf)
    {
        var instructions = graph.Blocks.SelectMany(block => block.Instructions.Select(instruction => (Block: block, Instruction: instruction))).ToList();

        var definitions = new Dictionary<LocalVariable, Instruction>();
        var multiplyDefined = new HashSet<LocalVariable>();
        var versions = new Dictionary<int, HashSet<LocalVariable>>();
        var addressTaken = new Dictionary<int, HashSet<LocalVariable>>();

        foreach (var (_, instruction) in instructions)
        {
            if (instruction.Destination is LocalVariable defined && !definitions.TryAdd(defined, instruction))
                multiplyDefined.Add(defined);

            foreach (var operand in instruction.Operands)
            {
                foreach (var local in LocalsIn(operand))
                    if (StackAnalyzer.SlotOffset(local.Register.Name) is { } slot and < 0)
                        Add(versions, slot, local);

                if (operand is AddressOf { Target: LocalVariable addressed } && StackAnalyzer.SlotOffset(addressed.Register.Name) is { } taken and < 0)
                    Add(addressTaken, taken, addressed);
            }
        }

        var candidates = new List<(int Start, long Size, LocalVariable Typed)>();
        foreach (var (start, taken) in addressTaken)
        {
            var typed = versions[start].Where(v => model.StructKey(v) is not null).ToList();
            if (typed.Count == 0 || typed.Select(model.StructKey).Distinct().Count() != 1)
                continue;

            // the version whose address is handed out names the storage; any typed one otherwise
            var storage = taken.FirstOrDefault(v => model.StructKey(v) is not null) ?? typed[0];
            var size = model.StructSize(storage);
            if (size > 0)
                candidates.Add((start, size, storage));
        }

        // two structs sharing memory are two lifetimes the analysis cannot separate
        candidates = candidates
            .Where(c => !candidates.Any(o => o.Start != c.Start && o.Start < c.Start + c.Size && c.Start < o.Start + o.Size))
            .ToList();

        var recovered = 0;
        foreach (var (start, size, storage) in candidates)
        {
            if (TryRecover(start, size, storage, instructions, definitions, multiplyDefined, versions[start], model, widthOf))
            {
                recovered++;
                Interlocked.Increment(ref StructsRecovered);
            }
            else
            {
                Interlocked.Increment(ref StructsRejected);
            }
        }

        return recovered;
    }

    private static bool TryRecover(int start, long size, LocalVariable storage,
        List<(Block Block, Instruction Instruction)> instructions,
        Dictionary<LocalVariable, Instruction> definitions, HashSet<LocalVariable> multiplyDefined,
        HashSet<LocalVariable> slotVersions, IStackStructModel model, Func<Instruction, int> widthOf)
    {
        bool Inside(LocalVariable local) => StackAnalyzer.SlotOffset(local.Register.Name) is { } slot && slot > start && slot < start + size;

        bool IsZero(IOperand operand)
            => operand is Immediate { Value: 0 }
               || operand is LocalVariable local && !multiplyDefined.Contains(local)
                  && definitions.TryGetValue(local, out var definition) && definition is { OpCode: OpCode.Move } && definition.Operands[1] is Immediate { Value: 0 };

        bool IsConstant(IOperand operand)
            => operand is Immediate
               || operand is LocalVariable local && !multiplyDefined.Contains(local)
                  && definitions.TryGetValue(local, out var definition) && definition is { OpCode: OpCode.Move } && definition.Operands[1] is Immediate;

        var storageKey = model.StructKey(storage);

        var interiorStores = new List<(Block Block, Instruction Instruction, long Offset)>();
        var rootStores = new List<(Block Block, Instruction Instruction)>();

        foreach (var (block, instruction) in instructions)
        {
            var destination = instruction.Destination as LocalVariable;
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                var operand = instruction.Operands[i];
                var isDestination = i == 0 && destination is not null && ReferenceEquals(operand, destination);

                if (isDestination)
                {
                    if (Inside(destination!))
                    {
                        if (instruction.OpCode != OpCode.Move)
                            return false; // arithmetic into a member's slot: not a store this pass can name
                        interiorStores.Add((block, instruction, StackAnalyzer.SlotOffset(destination!.Register.Name)!.Value - start));
                    }
                    else if (slotVersions.Contains(destination!) && instruction.OpCode == OpCode.Move)
                    {
                        rootStores.Add((block, instruction));
                    }

                    continue;
                }

                // an interior slot read by name is some other variable sharing the memory
                if (LocalsIn(operand).Any(Inside))
                    return false;

                // a version that is not the struct, read as a value rather than through its address
                if (operand is LocalVariable read && slotVersions.Contains(read) && model.StructKey(read) is null)
                    return false;
            }
        }

        var plan = new List<Action>();
        var rewrittenStores = 0;
        var rewrittenCopies = 0;

        // the zeroing that opens the struct's life: a zero at offset 0 and the zeros beside it in the same block
        var zeroRoots = rootStores.Where(store => IsZero(store.Instruction.Operands[1])).ToList();
        var zeroedBlocks = zeroRoots.Select(store => store.Block).ToHashSet();
        foreach (var (_, instruction) in zeroRoots)
        {
            var target = instruction;
            plan.Add(() => target.SetOperands([target.Operands[0], new Immediate(0)]));
        }

        // a constant written at offset 0 of a struct wider than any register is its first member, not the struct
        foreach (var (_, instruction) in rootStores.Where(store => !IsZero(store.Instruction.Operands[1])))
        {
            var value = instruction.Operands[1];

            // a constant first: type propagation routinely gives the immediate the struct's own type
            if (!IsConstant(value))
            {
                if (value is LocalVariable whole && Equals(model.StructKey(whole), storageKey))
                    continue;
                return false;
            }

            if (model.Member(storage, 0) is not { } first || model.StructMemberContaining(storage, 0) is not null
                || widthOf(instruction) != model.MemberSize(storage, 0))
                return false;

            var target = instruction;
            plan.Add(() => target.SetOperands([first, target.Operands[1]]));
            rewrittenStores++;
        }

        var remaining = new List<(Block Block, Instruction Instruction, long Offset)>();
        foreach (var store in interiorStores)
        {
            if (zeroedBlocks.Contains(store.Block) && IsZero(store.Instruction.Operands[1]))
            {
                var target = store.Instruction;
                plan.Add(() => { target.OpCode = OpCode.Nop; target.SetOperands(); });
                continue;
            }

            remaining.Add(store);
        }

        // direct member stores, and chunked copies into struct members
        var copies = new Dictionary<long, List<(Instruction Instruction, long Offset)>>();
        foreach (var (_, instruction, offset) in remaining)
        {
            if (model.StructMemberContaining(storage, offset) is { } container)
            {
                if (!copies.TryGetValue(container.Start, out var chunks))
                    copies[container.Start] = chunks = [];
                chunks.Add((instruction, offset));
                continue;
            }

            if (model.Member(storage, offset) is not { } member || widthOf(instruction) != model.MemberSize(storage, offset))
                return false;

            var target = instruction;
            plan.Add(() => target.SetOperands([member, target.Operands[1]]));
            rewrittenStores++;
        }

        foreach (var (memberStart, chunks) in copies)
        {
            var memberSize = model.StructMemberContaining(storage, memberStart)!.Value.Size;
            if (!TryChunkedCopy(chunks, memberStart, memberSize, storage, model, definitions, multiplyDefined, widthOf, out var source))
                return false;

            if (model.Member(storage, memberStart) is not { } member)
                return false;

            var ordered = chunks.OrderBy(chunk => chunk.Offset).ToList();
            var head = ordered[0].Instruction;
            plan.Add(() => head.SetOperands([member, source!]));
            foreach (var (instruction, _) in ordered.Skip(1))
            {
                var target = instruction;
                plan.Add(() => { target.OpCode = OpCode.Nop; target.SetOperands(); });
            }

            rewrittenCopies++;
        }

        // the address of the struct plus a constant is the address of the member there
        var addresses = 0;
        foreach (var (_, instruction) in instructions)
        {
            if (instruction.OpCode is not (OpCode.Or or OpCode.Add) || instruction.Operands.Count != 3
                || instruction.Operands[2] is not Immediate { Value: > 0 and var constant }
                || instruction.Destination is not LocalVariable destination)
                continue;

            if (!AddressesStruct(instruction.Operands[1], slotVersions, definitions, multiplyDefined))
                continue;

            // `orr` adds only where the bits it sets are known to be clear: the slot is 16-aligned relative to the stack
            if (instruction.OpCode == OpCode.Or && (constant >= 16 || (start & 15 & constant) != 0))
                continue;

            if (model.Member(storage, constant) is not { } member)
                continue;

            var target = instruction;
            var addressType = model.AddressType(storage, constant);
            plan.Add(() =>
            {
                target.OpCode = OpCode.Move;
                target.SetOperands([target.Operands[0], new AddressOf(member)]);
                destination.Type = addressType;
            });
            addresses++;
        }

        if (rewrittenStores + rewrittenCopies + addresses == 0 && zeroRoots.Count == 0)
            return false;

        foreach (var version in slotVersions)
            model.Retype(version, storage);

        foreach (var step in plan)
            step();

        Interlocked.Add(ref MemberStoresRecovered, rewrittenStores);
        Interlocked.Add(ref MemberCopiesRecovered, rewrittenCopies);
        Interlocked.Add(ref MemberAddressesRecovered, addresses);
        return true;
    }

    /// <summary>
    /// Whether the chunks stored into a struct member are one value copied a register at a time, and which value.
    /// </summary>
    private static bool TryChunkedCopy(List<(Instruction Instruction, long Offset)> chunks, long memberStart, long memberSize,
        LocalVariable storage, IStackStructModel model,
        Dictionary<LocalVariable, Instruction> definitions, HashSet<LocalVariable> multiplyDefined, Func<Instruction, int> widthOf,
        out LocalVariable? source)
    {
        source = null;
        var ordered = chunks.OrderBy(chunk => chunk.Offset).ToList();
        if (ordered[0].Offset != memberStart || ordered.Select(chunk => chunk.Offset).Distinct().Count() != ordered.Count)
            return false;

        for (var i = 0; i < ordered.Count; i++)
        {
            var (instruction, offset) = ordered[i];
            var relative = offset - memberStart;
            // the chunks must tile the member: each starts where the last one ended, and the last ends with the member
            var end = i + 1 < ordered.Count ? ordered[i + 1].Offset : memberStart + memberSize;
            if (widthOf(instruction) is var width && (width <= 0 || offset + width != end))
                return false;

            var stored = instruction.Operands[1];

            if (SourceOf(stored, definitions, multiplyDefined) is not ({ } value, var at) || at != relative)
                return false;

            if (source is null)
                source = value;
            else if (!ReferenceEquals(source, value))
                return false;
        }

        return source is not null && model.HoldsMember(storage, memberStart, source);
    }

    /// <summary>Follows copies back to the value a chunk was read out of, and the offset it was read at.</summary>
    private static (LocalVariable? Value, long Offset) SourceOf(IOperand operand,
        Dictionary<LocalVariable, Instruction> definitions, HashSet<LocalVariable> multiplyDefined)
    {
        for (var steps = 0; steps < 16; steps++)
        {
            switch (operand)
            {
                case FieldReference { ElementIndex: null, Local: { } whole } field:
                    return (whole, field.Offset);
                case MemoryOperand { Base: LocalVariable whole, Index: null, Addend: var addend }:
                    return (whole, addend);
                case LocalVariable local when !multiplyDefined.Contains(local)
                                              && definitions.TryGetValue(local, out var definition)
                                              && definition is { OpCode: OpCode.Move, Operands.Count: 2 }:
                    operand = definition.Operands[1];
                    continue;
                case LocalVariable local:
                    return (local, 0);
                default:
                    return (null, 0);
            }
        }

        return (null, 0);
    }

    private static bool AddressesStruct(IOperand operand, HashSet<LocalVariable> slotVersions,
        Dictionary<LocalVariable, Instruction> definitions, HashSet<LocalVariable> multiplyDefined)
    {
        for (var steps = 0; steps < 16; steps++)
        {
            switch (operand)
            {
                case AddressOf { Target: LocalVariable addressed }:
                    return slotVersions.Contains(addressed);
                case LocalVariable local when !multiplyDefined.Contains(local)
                                              && definitions.TryGetValue(local, out var definition)
                                              && definition is { OpCode: OpCode.Move, Operands.Count: 2 }:
                    operand = definition.Operands[1];
                    continue;
                default:
                    return false;
            }
        }

        return false;
    }

    private static IEnumerable<LocalVariable> LocalsIn(IOperand operand)
    {
        switch (operand)
        {
            case LocalVariable local:
                yield return local;
                break;
            case MemoryOperand memory:
                if (memory.Base is LocalVariable baseLocal)
                    yield return baseLocal;
                if (memory.Index is LocalVariable indexLocal)
                    yield return indexLocal;
                break;
            case FieldReference field:
                yield return field.Local;
                if (field.ElementIndex is LocalVariable index)
                    yield return index;
                break;
            case AddressOf { Target: var target }:
                foreach (var inner in LocalsIn(target))
                    yield return inner;
                break;
            case ArrayAccess access:
                yield return access.Array;
                if (access.Index is LocalVariable arrayIndex)
                    yield return arrayIndex;
                break;
        }
    }

    private static void Add(Dictionary<int, HashSet<LocalVariable>> map, int key, LocalVariable value)
    {
        if (!map.TryGetValue(key, out var set))
            map[key] = set = [];
        set.Add(value);
    }

    /// <summary>The production model: the struct's metadata, value-relative offsets.</summary>
    private sealed class MetadataModel(int pointerSize) : IStackStructModel
    {
        private static readonly HashSet<string> Primitives =
        [
            "System.Boolean", "System.Char", "System.SByte", "System.Byte", "System.Int16", "System.UInt16",
            "System.Int32", "System.UInt32", "System.Int64", "System.UInt64", "System.Single", "System.Double",
            "System.IntPtr", "System.UIntPtr", "System.Decimal",
        ];

        private static bool IsStruct(TypeAnalysisContext? type)
            => type is { IsValueType: true, IsEnumType: false } && !Primitives.Contains(type.FullName)
               && type is not GenericParameterTypeAnalysisContext;

        public object? StructKey(LocalVariable version)
            => IsStruct(version.Type) && version.Type is not GenericInstanceTypeAnalysisContext ? version.Type!.FullName : null;

        public long StructSize(LocalVariable version) => TypeSizes.UnboxedSize(version.Type!, pointerSize);

        private IEnumerable<FieldAnalysisContext> InstanceFields(LocalVariable storage)
            => storage.Type!.Fields.Where(field => !field.IsStatic && field.BackingData is not null);

        public IOperand? Member(LocalVariable storage, long offset)
            => InstanceFields(storage).FirstOrDefault(field => field.BackingData!.FieldOffset == offset) is { } field
                ? new FieldReference(field, storage, (int)offset)
                : null;

        public long MemberSize(LocalVariable storage, long offset)
            => InstanceFields(storage).FirstOrDefault(field => field.BackingData!.FieldOffset == offset) is { } field
                ? field.FieldType.IsValueType ? TypeSizes.UnboxedSize(field.FieldType, pointerSize) : pointerSize
                : 0;

        public (long Start, long Size)? StructMemberContaining(LocalVariable storage, long offset)
        {
            foreach (var field in InstanceFields(storage))
            {
                if (!IsStruct(field.FieldType))
                    continue;

                long fieldStart = field.BackingData!.FieldOffset;
                var fieldSize = TypeSizes.UnboxedSize(field.FieldType, pointerSize);
                if (fieldSize > 0 && offset >= fieldStart && offset < fieldStart + fieldSize)
                    return (fieldStart, fieldSize);
            }

            return null;
        }

        public bool HoldsMember(LocalVariable storage, long offset, LocalVariable source)
            => InstanceFields(storage).FirstOrDefault(field => field.BackingData!.FieldOffset == offset) is { } field
               && source.Type is { } sourceType && sourceType.FullName == field.FieldType.FullName;

        public TypeAnalysisContext? AddressType(LocalVariable storage, long offset)
            => InstanceFields(storage).FirstOrDefault(field => field.BackingData!.FieldOffset == offset)?.FieldType.MakeByReferenceType();

        public void Retype(LocalVariable version, LocalVariable typed) => version.Type = typed.Type;
    }
}
