using System.Collections.Generic;
using System.Reflection;
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

    /// <summary>
    /// AssetRipper: how well <see cref="Layout"/> reproduces the offsets metadata actually carries.
    /// </summary>
    /// <remarks>
    /// A generic definition's metadata offsets are all zero, which is why the layout is computed at
    /// all - so there is nothing to check the computation against on the types it is used for. A
    /// *non*-generic type carries the real offsets, and the same walk has to reproduce them or it is
    /// wrong. Running it over every such type in the game is therefore an exact self-check, and the
    /// only one available: a layout that is quietly off by a field does not fail, it names the wrong
    /// field.
    /// </remarks>
    public static (int Reproduced, int Mismatched, int Incomplete) SelfCheck(ApplicationAnalysisContext appContext)
    {
        var reproduced = 0;
        var mismatched = 0;
        var incomplete = 0;

        foreach (var assembly in appContext.Assemblies)
        foreach (var type in assembly.Types)
        {
            if (type.GenericParameters.Count > 0 || type.IsValueType)
                continue;

            var expected = new List<(FieldAnalysisContext Field, long Offset)>();

            foreach (var field in type.Fields)
                if (!field.IsStatic && (field.Attributes & FieldAttributes.Literal) == 0
                    && field.BackingData?.FieldOffset is { } metadataOffset && metadataOffset > 0)
                    expected.Add((field, metadataOffset));

            if (expected.Count == 0)
                continue;

            var computed = Layout(type, null).ToDictionary(entry => entry.Field, entry => entry.Offset);
            var wrong = false;
            var missing = false;

            foreach (var (field, metadataOffset) in expected)
            {
                if (!computed.TryGetValue(field, out var offset))
                    missing = true;
                else if (offset != metadataOffset)
                    wrong = true;
            }

            if (wrong)
            {
                mismatched++;
                // AssetRipper: CPP2IL_DUMP_LAYOUT names the types the walk gets wrong, with the
                // offset metadata carries beside the one it computed. Every mismatch this ever
                // produced was diagnosable from that one line: `_paramName meta=90 got=10` said the
                // base chain had not been walked, and `m_HashStack meta=4010 got=18` said a fixed
                // buffer had been sized as its single field.
                if (System.Environment.GetEnvironmentVariable("CPP2IL_DUMP_LAYOUT") != null && mismatched <= 25)
                {
                    var detail = new List<string>();
                    foreach (var (field, metadataOffset) in expected)
                        detail.Add($"{field.Name}:{field.FieldType.Name} meta={metadataOffset:X} got={(computed.TryGetValue(field, out var o) ? o.ToString("X") : "-")}");
                    System.Console.Error.WriteLine($"layout mismatch: {type.FullName} base={type.BaseType?.FullName} [{string.Join(", ", detail)}]");
                }
            }
            else if (missing)
                incomplete++;
            else
                reproduced++;
        }

        return (reproduced, mismatched, incomplete);
    }

    private static IEnumerable<(FieldAnalysisContext Field, long Offset)> Layout(TypeAnalysisContext definition,
        IReadOnlyList<TypeAnalysisContext>? genericArguments)
    {
        var pointerSize = definition.AppContext.Binary.PointerSizeBytes;
        var laid = new List<(FieldAnalysisContext Field, long Offset)>();

        // AssetRipper: an object's instance fields start after its header and run base-first, so the
        // base chain has to be laid out before this type's own fields rather than being a reason to
        // give up. Bailing on any base with an instance field lost the layout of every generic type
        // that derives from one - `UserResourceCollectionItem<T> : UserResourceInventory<T>`, whose
        // `itemCollections` load came out as an unresolved `[this + 0x20]` and then `(List<T>)0`.
        LayoutInto(definition, genericArguments, pointerSize, 2L * pointerSize, laid);

        return laid;
    }

    /// <summary>
    /// AssetRipper: appends the instance fields of <paramref name="definition"/>'s base chain and then
    /// its own, and returns the offset one past the last of them, or null if any field could not be
    /// sized. A partial layout is no use: the fields after an unsized one would all be wrong, so the
    /// caller gets nothing rather than something.
    /// </summary>
    private static long? LayoutInto(TypeAnalysisContext definition, IReadOnlyList<TypeAnalysisContext>? genericArguments,
        int pointerSize, long offset, List<(FieldAnalysisContext Field, long Offset)> laid, int depth = 0)
    {
        if (depth >= MaximumInheritanceDepth)
            return null;

        // Every base, not only one that declares fields of its own: `ArgumentException`'s immediate
        // base `SystemException` declares none and `Exception` above it declares 0x80 bytes of them,
        // so gating the recursion on the immediate base put `_paramName` at 0x10 instead of 0x90.
        if (definition.BaseType is { } baseType)
        {
            var baseDefinition = baseType is GenericInstanceTypeAnalysisContext baseInstance ? baseInstance.GenericType : baseType;
            var baseArguments = ArgumentsFor(baseType, genericArguments);

            if (LayoutInto(baseDefinition, baseArguments, pointerSize, offset, laid, depth + 1) is not { } afterBase)
                return null;

            offset = afterBase;
        }

        foreach (var field in definition.Fields)
        {
            if (field.IsStatic || (field.Attributes & FieldAttributes.Literal) != 0)
                continue;

            if (GetSizeAndAlignment(Substitute(field.FieldType, genericArguments), pointerSize) is not var (size, alignment))
                return null;

            offset = (offset + alignment - 1) & ~(alignment - 1);
            laid.Add((field, offset));
            offset += size;
        }

        return offset;
    }

    private const int MaximumInheritanceDepth = 16;

    /// <summary>
    /// AssetRipper: a base type's own generic arguments, with the deriving type's substituted into
    /// them - the arguments of <c>Base&lt;T&gt;</c> seen from <c>Derived&lt;int&gt;</c> are
    /// <c>[int]</c>.
    /// </summary>
    private static IReadOnlyList<TypeAnalysisContext>? ArgumentsFor(TypeAnalysisContext baseType,
        IReadOnlyList<TypeAnalysisContext>? genericArguments)
        => baseType is GenericInstanceTypeAnalysisContext { GenericArguments: { } baseArguments }
            ? baseArguments.Select(argument => Substitute(argument, genericArguments)).ToList()
            : null;

    // AssetRipper: the argument a generic parameter stands for, when it is known.
    private static TypeAnalysisContext Substitute(TypeAnalysisContext fieldType, IReadOnlyList<TypeAnalysisContext>? genericArguments)
        => fieldType is GenericParameterTypeAnalysisContext { Index: var index } && genericArguments != null && index < genericArguments.Count
            ? genericArguments[index]
            : fieldType;

    private static (long Size, long Alignment)? GetSizeAndAlignment(TypeAnalysisContext fieldType, int pointerSize, int depth = 0)
    {
        if (fieldType is PointerTypeAnalysisContext || !fieldType.IsValueType)
            return (pointerSize, pointerSize);

        // A generic parameter is a pointer only when it stands for a reference type. At the top level
        // Substitute has already replaced it when the arguments are known, so one arriving here is
        // genuinely open; inside a struct, guessing would silently displace every field after it.
        if (fieldType is GenericParameterTypeAnalysisContext)
            return depth == 0 ? (pointerSize, pointerSize) : null;

        if (fieldType.IsEnumType && fieldType.Fields.FirstOrDefault(f => !f.IsStatic) is { } underlying)
            return GetSizeAndAlignment(underlying.FieldType, pointerSize, depth + 1);

        switch (fieldType.FullName)
        {
            case "System.Boolean" or "System.Byte" or "System.SByte": return (1, 1);
            case "System.Int16" or "System.UInt16" or "System.Char": return (2, 2);
            case "System.Int32" or "System.UInt32" or "System.Single": return (4, 4);
            case "System.Int64" or "System.UInt64" or "System.Double": return (8, 8);
            case "System.IntPtr" or "System.UIntPtr": return (pointerSize, pointerSize);
        }

        // AssetRipper: a user-defined value type is its own fields packed with no object header, so the
        // same walk sizes it. Bailing instead truncated the layout at the first struct field and lost
        // every field after it - which is what "generic instance, value type argument" was, 670 loads.
        if (StructSizeAndAlignment(fieldType, pointerSize, depth) is not var (packedSize, alignment))
            return null;

        // The walk gets alignment right - it is the widest member's - but not always the size: a fixed
        // buffer's size lives in an attribute rather than in its one field, and an explicit layout or
        // a pack attribute overrides the packing entirely. il2cpp records what the size really is, so
        // where that is available it wins; a struct with generic parameters is the exception, since
        // the definition's recorded size is not any instantiation's.
        if (fieldType.GenericParameters.Count == 0
            && MeasuredValueTypeSize(fieldType, pointerSize) is { } measured)
            return (measured, alignment);

        return (packedSize, alignment);
    }

    /// <summary>
    /// AssetRipper: the unboxed size of a value type as il2cpp recorded it, or null when it did not.
    /// </summary>
    /// <remarks>
    /// <c>instance_size</c> is the size of the *boxed* form, so the value's own data is that less the
    /// object header - the same two pointers every layout here starts after.
    /// </remarks>
    private static long? MeasuredValueTypeSize(TypeAnalysisContext valueType, int pointerSize)
    {
        if (valueType.Definition is not { } definition)
            return null;

        long instanceSize;

        try
        {
            instanceSize = definition.RawSizes.instance_size;
        }
        catch
        {
            return null;
        }

        var header = 2L * pointerSize;

        return instanceSize > header ? instanceSize - header : null;
    }

    private static (long Size, long Alignment)? StructSizeAndAlignment(TypeAnalysisContext structType, int pointerSize, int depth)
    {
        if (depth >= MaximumNestingDepth)
            return null;

        long size = 0;
        long alignment = 1;
        var any = false;

        foreach (var field in structType.Fields)
        {
            if (field.IsStatic || (field.Attributes & FieldAttributes.Literal) != 0)
                continue;

            if (GetSizeAndAlignment(field.FieldType, pointerSize, depth + 1) is not var (fieldSize, fieldAlignment))
                return null;

            size = (size + fieldAlignment - 1) & ~(fieldAlignment - 1);
            size += fieldSize;
            any = true;

            if (fieldAlignment > alignment)
                alignment = fieldAlignment;
        }

        // A struct with no instance fields still occupies space, and an explicit layout or a pack
        // attribute changes all of this. Neither is worth a guess.
        if (!any)
            return null;

        return ((size + alignment - 1) & ~(alignment - 1), alignment);
    }

    private const int MaximumNestingDepth = 8;
}
