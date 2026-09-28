using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;

namespace Cpp2IL.Core.Analysis;

/// <summary>What kind of storage a recovered value lives in.</summary>
public enum StorageKind
{
    Unknown,

    /// <summary>The method's receiver.</summary>
    This,

    /// <summary>One of the method's parameters; a <c>ref</c>/<c>out</c> one is already an address.</summary>
    Parameter,

    /// <summary>A local the generator declares, defined or read more than once.</summary>
    Local,

    /// <summary>A register value defined once, read at most once and never addressed.</summary>
    Temporary,

    /// <summary>A stack slot the compiler spilled into, named by its frame offset.</summary>
    Spill,

    /// <summary>A stack address that survived as an offset rather than being named.</summary>
    Stack,

    /// <summary>A field of an object or of a value.</summary>
    Field,

    /// <summary>A class's static field storage.</summary>
    Static,

    /// <summary>One element of an array, or a member of one.</summary>
    ArrayElement,
}

/// <summary>
/// Where one recovered value lives, and everything about that storage a pass or a measurement has to
/// agree on.
/// </summary>
/// <param name="Kind">What kind of storage it is.</param>
/// <param name="AliasGroup">
/// The storage itself, as a key two identities share exactly when they name the same memory: every
/// SSA version of one stack slot is <c>stack:-58</c>, a parameter is <c>param:1</c> however many
/// lifted locals carry its name. Two identities in one group with different <see cref="Site"/>s are
/// one machine location spread over several IL locations.
/// </param>
/// <param name="Frame">Which coordinate an offset from this storage is measured in.</param>
/// <param name="Site">Where the generator puts it - the one answer <see cref="LocalStorage"/> gives.</param>
/// <param name="DefinitionSites">The indices of the instructions that write it.</param>
/// <param name="UseSites">The indices of the instructions that read it.</param>
/// <param name="AddressTaken">Whether its address is taken anywhere.</param>
/// <param name="Escapes">
/// Whether that address leaves the expression it was taken in - passed to a call, stored, or
/// returned - so something other than this body may read or write through it.
/// </param>
public sealed record StorageIdentity(
    StorageKind Kind,
    string AliasGroup,
    CoordinateFrame Frame,
    LocalStorageSite Site,
    IReadOnlyList<int> DefinitionSites,
    IReadOnlyList<int> UseSites,
    bool AddressTaken,
    bool Escapes);

/// <summary>
/// One machine location the generated method holds in more than one place, with its address taken.
/// </summary>
/// <remarks>
/// A write through the address reaches one of the places and a read of another does not see it,
/// which is the silent value loss of iterations 058 and 059 in its general form.
/// </remarks>
public sealed record StorageHazard(string AliasGroup, IReadOnlyList<LocalVariable> Locals, bool Escapes);

/// <summary>
/// AssetRipper: one answer to "where does this value live", for loads, stores, address-takes and
/// every measurement of them.
/// </summary>
/// <remarks>
/// <para>
/// The generator decides where a value lives in six places - loading an operand, storing one, taking
/// an address, a <c>Move</c>'s own store, zeroing a value type, composing an aggregate member by
/// member - and it decided it in more than one way. Iteration 058 found the address site taking
/// <c>ldloca</c> of an invented local where the value was a parameter, iteration 059 the store site,
/// and iteration 061 four more address sites (<c>initobj</c> zeroing, <c>MakeStruct</c>, a float
/// aggregate's first member, both directions) that indexed the invented-local map directly. Every one
/// of them compiled and read plausibly, and every one lost a value silently.
/// </para>
/// <para>
/// <see cref="LocalStorage.For"/> stays the single rule for the IL side, and this is built on it
/// rather than beside it: a second rule is how the two sides came to disagree. What this adds is the
/// machine side - which IL places are one location - and the facts a pass needs before it may move or
/// delete a store: whether the address was taken and whether it escapes.
/// </para>
/// <para>
/// Written over the ISIL and over names, with no metadata behind it, so the rules are testable the
/// way <see cref="PointerClassifier"/> and <see cref="LocalStorage"/> are.
/// </para>
/// </remarks>
public static class StorageIdentities
{
    private const string SpillPrefix = "stack_";

    /// <summary>The storage of every local in <paramref name="instructions"/>.</summary>
    /// <param name="instructions">The method body, in any order; indices are the instructions' own.</param>
    /// <param name="parameterNames">The generated method's parameter names, in order.</param>
    /// <param name="parameterIsByReference">Whether each parameter is a managed reference.</param>
    /// <param name="isValueType">Whether a local's type is a value type, for its coordinate frame.</param>
    public static IReadOnlyDictionary<LocalVariable, StorageIdentity> Analyze(
        IEnumerable<Instruction> instructions,
        IReadOnlyList<string> parameterNames,
        IReadOnlyList<bool> parameterIsByReference,
        Func<LocalVariable, bool>? isValueType = null)
    {
        Dictionary<LocalVariable, List<int>> definitions = [];
        Dictionary<LocalVariable, List<int>> uses = [];
        HashSet<LocalVariable> addressTaken = [];
        HashSet<LocalVariable> escapes = [];

        foreach (var instruction in instructions)
        {
            var destination = instruction.Destination;

            for (var position = 0; position < instruction.Operands.Count; position++)
            {
                var operand = instruction.Operands[position];

                if (ReferenceEquals(operand, destination) && operand is LocalVariable written)
                {
                    Add(definitions, written, instruction.Index);
                    continue;
                }

                // A field or element written through is a read of the base, never a write of it.
                Walk(operand, local => Add(uses, local, instruction.Index), taken =>
                {
                    addressTaken.Add(taken);
                    if (AddressLeaves(instruction, position))
                        escapes.Add(taken);
                });
            }
        }

        var all = definitions.Keys.Concat(uses.Keys).Concat(addressTaken).Distinct();
        Dictionary<LocalVariable, StorageIdentity> result = [];

        foreach (var local in all)
        {
            var site = LocalStorage.For(local.Name, local.IsThis, parameterNames, parameterIsByReference);
            var defined = definitions.TryGetValue(local, out var d) ? d : [];
            var used = uses.TryGetValue(local, out var u) ? u : [];
            var taken = addressTaken.Contains(local);
            var valueType = isValueType?.Invoke(local) ?? false;

            var (kind, group) = site.Kind switch
            {
                LocalStorageKind.This => (StorageKind.This, "this"),
                LocalStorageKind.Parameter => (StorageKind.Parameter, $"param:{site.ParameterIndex}"),
                _ when local.Register.Name?.StartsWith(SpillPrefix, StringComparison.Ordinal) == true
                    => (StorageKind.Spill, "stack:" + local.Register.Name[SpillPrefix.Length..]),
                _ when defined.Count == 1 && used.Count <= 1 && !taken
                    => (StorageKind.Temporary, "local:" + local.Name),
                _ => (StorageKind.Local, "local:" + local.Name),
            };

            // A slot, a local and a by-value struct parameter hold the value itself; a reference, a
            // `ref` parameter and a class receiver point at an object, whose offsets carry the header.
            var frame = kind switch
            {
                StorageKind.Spill or StorageKind.Temporary or StorageKind.Local => valueType
                    ? CoordinateFrame.ValueRelative
                    : CoordinateFrame.Unknown,
                StorageKind.Parameter => valueType && !site.ByReference
                    ? CoordinateFrame.ValueRelative
                    : CoordinateFrame.Unknown,
                // il2cpp hands even a struct's own instance method a pointer to the boxed header.
                StorageKind.This => CoordinateFrame.ObjectRelative,
                _ => CoordinateFrame.Unknown,
            };

            result[local] = new StorageIdentity(kind, group, frame, site, defined, used, taken, escapes.Contains(local));
        }

        return result;
    }

    /// <summary>The storage a memory operand names, given the identities of the locals it is built from.</summary>
    public static StorageIdentity OfOperand(IOperand operand, IReadOnlyDictionary<LocalVariable, StorageIdentity> locals)
    {
        switch (operand)
        {
            case LocalVariable local:
                return locals.TryGetValue(local, out var identity) ? identity : Unknown("local:" + local.Name);

            case AddressOf address:
                return OfOperand(address.Target, locals) with { AddressTaken = true };

            case FieldReference field when field.ElementIndex is not null:
                return Derived(StorageKind.ArrayElement,
                    $"elem:{Group(field.Local, locals)}[*].{field.Field?.Name ?? "?"}", CoordinateFrame.ValueRelative);

            case FieldReference field when field.Local.Type?.Name?.StartsWith("Il2CppStaticFields", StringComparison.Ordinal) == true:
                return Derived(StorageKind.Static,
                    $"static:{field.Local.Type!.FullName}.{field.Field?.Name ?? "?"}", CoordinateFrame.ValueRelative);

            case FieldReference field:
                return Derived(StorageKind.Field,
                    $"field:{Group(field.Local, locals)}.{field.Field?.Name ?? "?"}", CoordinateFrame.ObjectRelative);

            case ArrayAccess array:
                return Derived(StorageKind.ArrayElement, $"elem:{Group(array.Array, locals)}[*]", CoordinateFrame.ValueRelative);

            case StackOffset stack:
                return Derived(StorageKind.Stack, $"stack:{stack.Offset}", CoordinateFrame.ValueRelative);

            case MemoryOperand memory when memory.Base is LocalVariable @base:
                return Derived(StorageKind.Unknown, $"mem:{Group(@base, locals)}+{memory.Addend}", CoordinateFrame.Unknown);
        }

        return Unknown(operand.GetType().Name);
    }

    /// <summary>
    /// Every machine location held in more than one IL place while its address is taken.
    /// </summary>
    /// <remarks>
    /// A parameter is excluded when every local carrying its name resolves to the parameter itself -
    /// that is one place, however many names point at it.
    /// </remarks>
    public static IReadOnlyList<StorageHazard> Hazards(IReadOnlyDictionary<LocalVariable, StorageIdentity> identities)
    {
        List<StorageHazard> hazards = [];

        foreach (var group in identities.GroupBy(pair => pair.Value.AliasGroup))
        {
            if (!group.Any(pair => pair.Value.AddressTaken))
                continue;

            // One IL place per local unless the rule sends them all to the same parameter or receiver.
            var places = group.Select(pair => pair.Value.Site.Kind == LocalStorageKind.Local
                    ? "local:" + pair.Key.Name
                    : $"{pair.Value.Site.Kind}:{pair.Value.Site.ParameterIndex}")
                .Distinct()
                .Count();

            if (places > 1)
                hazards.Add(new StorageHazard(group.Key, group.Select(pair => pair.Key).ToList(),
                    group.Any(pair => pair.Value.Escapes)));
        }

        return hazards;
    }

    private static bool AddressLeaves(Instruction instruction, int position)
    {
        return instruction.OpCode switch
        {
            // A call's operands are its target and its return value before its arguments; an
            // address among the arguments is handed to code this body cannot see.
            OpCode.Call or OpCode.IndirectCall => position >= 2,
            OpCode.CallVoid => position >= 1,
            OpCode.Return => true,
            // Stored into memory: whoever reads that memory reaches the storage.
            OpCode.Move => position == 1 && instruction.Operands[0] is not LocalVariable,
            _ => false,
        };
    }

    private static void Walk(IOperand? operand, Action<LocalVariable> read, Action<LocalVariable> addressed)
    {
        switch (operand)
        {
            case LocalVariable local:
                read(local);
                break;
            case AddressOf { Target: LocalVariable target }:
                addressed(target);
                break;
            case AddressOf address:
                Walk(address.Target, read, addressed);
                break;
            case FieldReference field:
                read(field.Local);
                Walk(field.ElementIndex, read, addressed);
                break;
            case ArrayAccess array:
                read(array.Array);
                Walk(array.Index, read, addressed);
                break;
            case MemoryOperand memory:
                Walk(memory.Base, read, addressed);
                Walk(memory.Index, read, addressed);
                break;
        }
    }

    private static string Group(LocalVariable local, IReadOnlyDictionary<LocalVariable, StorageIdentity> locals)
        => locals.TryGetValue(local, out var identity) ? identity.AliasGroup : "local:" + local.Name;

    private static StorageIdentity Derived(StorageKind kind, string group, CoordinateFrame frame)
        => new(kind, group, frame, new LocalStorageSite(LocalStorageKind.Local, -1, false), [], [], false, false);

    private static StorageIdentity Unknown(string group)
        => Derived(StorageKind.Unknown, "unknown:" + group, CoordinateFrame.Unknown);

    private static void Add(Dictionary<LocalVariable, List<int>> map, LocalVariable local, int index)
    {
        if (!map.TryGetValue(local, out var list))
            map[local] = list = [];
        if (list.Count == 0 || list[^1] != index)
            list.Add(index);
    }
}
