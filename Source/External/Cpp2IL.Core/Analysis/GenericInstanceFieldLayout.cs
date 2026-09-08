using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

//Resolves field offsets on generic types, which are all 0 in the metadata.
public static class GenericInstanceFieldLayout
{
    /// <param name="genericArguments">
    /// AssetRipper: the instance's arguments, so a field of the type's own generic parameter is sized
    /// as what it actually is. Empty leaves a generic parameter sized as a pointer, which is right for
    /// a reference type and wrong for a struct.
    /// </param>
    public static FieldAnalysisContext? FindFieldAtOffset(TypeAnalysisContext definition, long targetOffset,
        IReadOnlyList<TypeAnalysisContext>? genericArguments = null)
    {
        foreach (var (field, offset) in Layout(definition, genericArguments))
            if (offset == targetOffset)
                return field;

        return null;
    }

    /// <summary>
    /// AssetRipper: the offset of one named field, which is the same walk read the other way round.
    /// </summary>
    /// <remarks>
    /// Pairing a private field with the property that returns it means matching the offset the
    /// getter's body names against the field's own, and the metadata says 0 for every field of a
    /// generic type - so <c>List&lt;T&gt;.Count</c> could not be recognised as the accessor for
    /// <c>_size</c> without computing where <c>_size</c> is.
    /// </remarks>
    public static long? OffsetOfField(TypeAnalysisContext definition, FieldAnalysisContext target,
        IReadOnlyList<TypeAnalysisContext>? genericArguments = null)
    {
        foreach (var (field, offset) in Layout(definition, genericArguments))
            if (field == target)
                return offset;

        return null;
    }

    private static IEnumerable<(FieldAnalysisContext Field, long Offset)> Layout(TypeAnalysisContext definition,
        IReadOnlyList<TypeAnalysisContext>? genericArguments)
    {
        var pointerSize = definition.AppContext.Binary.PointerSizeBytes;

        // TODO Support anything outside the trivial case.
        for (var baseType = definition.BaseType; baseType != null; baseType = baseType.BaseType)
            if (baseType.Fields.Any(f => !f.IsStatic))
                yield break;

        var offset = 2L * pointerSize;

        foreach (var field in definition.Fields)
        {
            if (field.IsStatic)
                continue;

            if (GetSizeAndAlignment(Substitute(field.FieldType, genericArguments), pointerSize) is not var (size, alignment))
                yield break;

            offset = (offset + alignment - 1) & ~(alignment - 1);

            yield return (field, offset);

            offset += size;
        }
    }

    // AssetRipper: the argument a generic parameter stands for, when it is known.
    private static TypeAnalysisContext Substitute(TypeAnalysisContext fieldType, IReadOnlyList<TypeAnalysisContext>? genericArguments)
        => fieldType is GenericParameterTypeAnalysisContext { Index: var index } && genericArguments != null && index < genericArguments.Count
            ? genericArguments[index]
            : fieldType;

    private static (long Size, long Alignment)? GetSizeAndAlignment(TypeAnalysisContext fieldType, int pointerSize)
    {
        // TODO support user-defined value types
        if (fieldType is GenericParameterTypeAnalysisContext or PointerTypeAnalysisContext || !fieldType.IsValueType)
            return (pointerSize, pointerSize);

        if (fieldType.IsEnumType && fieldType.Fields.FirstOrDefault(f => !f.IsStatic) is { } underlying)
            return GetSizeAndAlignment(underlying.FieldType, pointerSize);

        return fieldType.FullName switch
        {
            "System.Boolean" or "System.Byte" or "System.SByte" => (1, 1),
            "System.Int16" or "System.UInt16" or "System.Char" => (2, 2),
            "System.Int32" or "System.UInt32" or "System.Single" => (4, 4),
            "System.Int64" or "System.UInt64" or "System.Double" => (8, 8),
            "System.IntPtr" or "System.UIntPtr" => (pointerSize, pointerSize),
            _ => null // an arbitrary struct needs its own layout computed, bail rather than guess
        };
    }
}
