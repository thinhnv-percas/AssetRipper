using System;
using System.Collections.Generic;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: what kind of storage a memory operand's base pointer points into.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 042 measured that the frame an offset is measured in belongs to the <b>base pointer</b>
/// and not to the type: of the value-typed bases among the unresolved loads, 77 read at the raw
/// metadata offset and 29 at metadata plus the object header, and the two readings never both landed.
/// So the evidence separates them per load - but "whichever one lands" is a guess, and the thing that
/// would make it a rule is knowing where the pointer came from.
/// </para>
/// <para>
/// This answers that, and only that. It says nothing about which frame follows from which origin:
/// that mapping is a separate claim that has to be measured before it is written down, and this
/// classification is what makes measuring it possible. Everything it reports is read off the IR
/// rather than inferred - a local flagged as the receiver, a register the stack analyser named after
/// a frame offset, a type that is the runtime's own structure - so an origin is evidence, and where
/// there is none the answer is <see cref="Unknown"/>.
/// </para>
/// </remarks>
public static class BasePointerOrigin
{
    public const string This = "THIS";
    public const string StackSlot = "STACK_SLOT";
    public const string StaticField = "STATIC_FIELD";
    public const string InstanceField = "INSTANCE_FIELD";
    public const string ArrayElement = "ARRAY_ELEMENT";
    public const string ReturnBuffer = "RETURN_BUFFER";
    public const string GenericContext = "GENERIC_CONTEXT";
    public const string RuntimeStructure = "RUNTIME_STRUCTURE";
    public const string Parameter = "PARAMETER";
    public const string Allocation = "ALLOCATION";

    /// <summary>A register's value on entry, which nothing in this method defined.</summary>
    public const string EntryValue = "ENTRY_VALUE";

    /// <summary>Whatever a call returned; the callee decides what it points into.</summary>
    public const string CallResult = "CALL_RESULT";

    /// <summary>
    /// Read out of memory the analysis could not name. The pointer points at whatever was stored
    /// there, which is not the storage it was read from - so this is its own answer and not the
    /// origin of the load it came out of.
    /// </summary>
    public const string LoadedPointer = "LOADED_POINTER";

    public const string Unknown = "UNKNOWN";

    /// <summary>
    /// How far back a chain of copies is followed before the answer is <see cref="Unknown"/>.
    /// </summary>
    public const int DepthLimit = 16;

    /// <summary>
    /// Where the pointer in <paramref name="baseLocal"/> came from.
    /// </summary>
    /// <param name="baseLocal">The base of the memory operand.</param>
    /// <param name="definitions">Every instruction that defines a local.</param>
    /// <param name="describe">
    /// What the IR already knows about a local itself, before its definition is looked at: whether it
    /// is the receiver, a named stack slot, static field storage, a runtime structure, a parameter.
    /// Null when the local says nothing on its own.
    /// </param>
    /// <param name="isReturnBufferOf">
    /// Whether a call writes its return value through this local, which is what makes the local the
    /// caller-allocated buffer rather than an ordinary result.
    /// </param>
    public static string Of(
        LocalLike baseLocal,
        Func<LocalLike, IReadOnlyList<DefinitionLike>> definitions,
        Func<LocalLike, string?> describe,
        Func<LocalLike, DefinitionLike, bool> isReturnBufferOf,
        Func<LocalLike, string?> describeUndefined)
    {
        HashSet<LocalLike> visited = [];
        LocalLike current = baseLocal;

        for (int depth = 0; depth < DepthLimit; depth++)
        {
            if (!visited.Add(current))
            {
                // A copy cycle says nothing, and following it further says nothing either.
                return Unknown;
            }

            // What the local is in its own right outranks what defined it: a receiver is the receiver
            // however it was copied into place, and static field storage is named by its type.
            if (describe(current) is { } known)
            {
                return known;
            }

            IReadOnlyList<DefinitionLike> defining = definitions(current);

            if (defining.Count == 0)
            {
                // Nothing in this method defined it, so it arrived in the register - a parameter where
                // the IR says so, and otherwise the entry value of a register, which an unresolved
                // call routinely makes look defined.
                return describeUndefined(current) ?? EntryValue;
            }

            if (defining.Count > 1)
            {
                // A disagreement, and picking one of them would be exactly the guess this class
                // exists to avoid.
                return Unknown;
            }

            DefinitionLike definition = defining[0];

            if (isReturnBufferOf(current, definition))
            {
                return ReturnBuffer;
            }

            switch (definition.Kind)
            {
                case DefinitionKind.CopyOfLocal when definition.Source is { } copied:
                    current = copied;
                    continue;

                case DefinitionKind.FieldRead:
                    return InstanceField;

                case DefinitionKind.ArrayElementAddress:
                    return ArrayElement;

                case DefinitionKind.Allocation:
                    return Allocation;

                case DefinitionKind.GenericContextRead:
                    return GenericContext;

                case DefinitionKind.CallResult:
                    return CallResult;

                case DefinitionKind.LoadFromMemory:
                    return LoadedPointer;

                case DefinitionKind.OffsetFromLocal when definition.Source is { } origin:
                    // Adding a constant to a pointer does not change what it points into.
                    current = origin;
                    continue;

                default:
                    return Unknown;
            }
        }

        return Unknown;
    }

    /// <summary>A local, kept opaque so the walk can be tested without metadata behind it.</summary>
    public interface LocalLike;

    /// <summary>What a defining instruction is, as far as this walk cares.</summary>
    public enum DefinitionKind
    {
        /// <summary>Something this walk has no rule for.</summary>
        Other,

        /// <summary>A move from another local, which is followed.</summary>
        CopyOfLocal,

        /// <summary>A read of a field, so the pointer points into an object's field.</summary>
        FieldRead,

        /// <summary>An element address computed from an array and a scaled index.</summary>
        ArrayElementAddress,

        /// <summary>A newobj or newarr, so the pointer is into an object this method made.</summary>
        Allocation,

        /// <summary>A read out of the runtime generic context table.</summary>
        GenericContextRead,

        /// <summary>A call's return value.</summary>
        CallResult,

        /// <summary>A read of memory the analysis could not name.</summary>
        LoadFromMemory,

        /// <summary>A constant added to another pointer, which points into the same storage.</summary>
        OffsetFromLocal,
    }

    /// <summary>A defining instruction reduced to what the walk needs.</summary>
    public readonly record struct DefinitionLike(DefinitionKind Kind, LocalLike? Source);
}
