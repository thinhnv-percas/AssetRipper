using System;
using System.Collections.Generic;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: finds the chain of fields an access at a given offset and width actually reaches.
/// </summary>
/// <remarks>
/// <para>
/// Written over delegates rather than over <c>TypeAnalysisContext</c> so the search itself can be
/// stated as facts about layouts and tested without metadata behind it. The production instantiation
/// is in <c>MetadataResolver</c>.
/// </para>
/// <para>
/// The width is what an offset alone cannot supply. An offset that lands exactly on a field is not
/// proof that the field is what was accessed: <c>ItemDistinc</c>'s constructor stores four bytes at
/// the offset of a twenty-four byte <c>ObscuredInt</c>, and reading that as a store of the whole
/// field gives an <c>int</c> assigned to a struct - a stack type mismatch, which ILSpy then refuses
/// to fold a constructor's base call around, so the export grows a <c>base._002Ector()</c> no C# can
/// write. What the machine wrote is the struct's first member.
/// </para>
/// <para>
/// The two positions are not symmetric, and that is deliberate. At a relative offset of zero the
/// outer field is *also* a valid answer, so preferring the inner one needs evidence beyond the
/// offset - the width has to match the inner field exactly, and the outer offset must name only one
/// field. Past the start of a field the outer field is not a valid answer at all, so the offset is
/// the whole of the evidence and no width is required.
/// </para>
/// </remarks>
public static class NestedFieldResolver
{
    /// <summary>
    /// A safety bound, not a decision: a chain this deep is a layout no caller here is reading
    /// correctly, and the search would otherwise have no bound on a type graph it does not control.
    /// </summary>
    public const int MaximumDepth = 4;

    /// <summary>
    /// The fields reaching <paramref name="targetOffset"/>, outermost first, or null when the offset
    /// reaches none.
    /// </summary>
    /// <param name="accessSize">Bytes the access covers, or 0 when the lifter did not say. Zero means
    /// the width is no evidence either way, so a field the offset lands on is taken whole.</param>
    public static List<TField>? Find<TType, TField>(
        TType owner,
        long targetOffset,
        long accessSize,
        Func<TType, IEnumerable<(TField Field, long Offset)>> instanceFields,
        Func<TField, long> sizeOf,
        Func<TField, TType?> interiorOf)
        where TType : class
        => Find(owner, targetOffset, accessSize, instanceFields, sizeOf, interiorOf, [], 0);

    private static List<TField>? Find<TType, TField>(
        TType owner,
        long targetOffset,
        long accessSize,
        Func<TType, IEnumerable<(TField Field, long Offset)>> instanceFields,
        Func<TField, long> sizeOf,
        Func<TField, TType?> interiorOf,
        HashSet<(TType Type, long Offset)> visited,
        int depth)
        where TType : class
    {
        if (depth > MaximumDepth || targetOffset < 0)
            return null;

        // Keyed on the offset as well as the type: a self-referential layout revisits a type at a
        // *different* offset legitimately, and only revisiting it at the same one is a cycle.
        if (!visited.Add((owner, targetOffset)))
            return null;

        TField? containing = default;
        var containingOffset = -1L;
        var sharingTheOffset = 0;

        foreach (var (field, offset) in instanceFields(owner))
        {
            if (offset > targetOffset)
                continue;

            if (offset > containingOffset)
            {
                containing = field;
                containingOffset = offset;
                sharingTheOffset = 1;
            }
            else if (offset == containingOffset)
            {
                sharingTheOffset++;
            }
        }

        if (containing is null)
            return null;

        var relative = targetOffset - containingOffset;
        var interior = interiorOf(containing);

        if (relative != 0)
        {
            // Past the start of the field, so the field itself is not what was accessed. Only a value
            // type has an interior to descend into; anything else means the offset ran past the end
            // of the last field, where any answer would be a guess.
            if (interior is null)
                return null;

            var deeper = Find(interior, relative, accessSize, instanceFields, sizeOf, interiorOf, visited, depth + 1);

            if (deeper is null)
                return null;

            deeper.Insert(0, containing);
            return deeper;
        }

        var size = sizeOf(containing);

        // No width to go on, or the access covers the field: the field is the answer.
        if (accessSize <= 0 || size <= 0 || accessSize >= size)
            return [containing];

        // Narrower than the field it starts at, so it reached something inside. Two fields at this
        // offset means the layout overlaps and nothing here can say which was meant.
        if (interior is null || sharingTheOffset != 1)
            return [containing];

        var inner = Find(interior, 0, accessSize, instanceFields, sizeOf, interiorOf, visited, depth + 1);

        // The inner field has to account for the width exactly. Anything else is a partial write of
        // something this cannot name, and the outer field remains the honest answer.
        if (inner is null || sizeOf(inner[^1]) != accessSize)
            return [containing];

        inner.Insert(0, containing);
        return inner;
    }
}
