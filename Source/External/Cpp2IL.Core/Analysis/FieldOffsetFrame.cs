using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: converts a field offset between the two frames IL2CPP measures them in.
/// </summary>
/// <remarks>
/// <para>
/// An offset is a number of bytes from somewhere, and IL2CPP uses two somewheres. Il2CppDumper states
/// the shape outright: an object is <c>{ klass*, monitor*, fields }</c> where the two pointers are
/// emitted only for a reference type, so a class carries a two-pointer header and a value type carries
/// none.
/// </para>
/// <para>
/// The consequence is that the same offset means different things depending on where it came from:
/// </para>
/// <list type="bullet">
/// <item><b>Metadata</b> records a class's fields from the object - the header is already in the
/// number - and a value type's from the start of its own data. <c>Rect.m_XMin</c> is 0.</item>
/// <item><b>The computed layout</b> (<see cref="GenericInstanceFieldLayout"/>) lays every type out
/// from the object, header included, whatever it is. Measured on two games: of 598 and 458 non-generic
/// structs with recorded offsets, 547 and 435 reproduce at <c>metadata + header</c> and <b>none</b> at
/// the metadata offset itself.</item>
/// <item><b>A receiver</b> il2cpp hands a value type's own instance method points at the boxed
/// object's header, so <c>Rect.set_x</c> stores at <c>[X0 + 0x10]</c> for a field the metadata records
/// at 0.</item>
/// </list>
/// <para>
/// Mixing them is not hypothetical. <c>IlGenerator.OffsetOfInstanceField</c> took its offset from the
/// computed layout for a generic owner and from the metadata for every other, then added the header to
/// both - so for a generic value type the header landed twice and the accessor pairing could not match
/// whatever the body said. Naming the frames is what stops that composing silently.
/// </para>
/// </remarks>
public static class FieldOffsetFrame
{
    /// <summary>
    /// The header a value lives behind once it is an object: two pointers, klass and monitor.
    /// </summary>
    public static long HeaderSize(int pointerSize) => 2L * pointerSize;

    /// <summary>
    /// An offset from the computed layout, restated the way the metadata would have recorded it.
    /// </summary>
    /// <remarks>
    /// A no-op for a reference type, whose metadata offsets are object-relative already.
    /// </remarks>
    public static long FromComputedLayout(long offset, bool isValueType, int pointerSize)
        => isValueType ? offset - HeaderSize(pointerSize) : offset;

    /// <summary>
    /// A metadata offset, restated as the displacement a method's own receiver names.
    /// </summary>
    /// <remarks>
    /// The inverse of <see cref="FromComputedLayout"/>: a value type's receiver points at the boxed
    /// object, a class's at the object it already was.
    /// </remarks>
    public static long ToReceiverDisplacement(long offset, bool isValueType, int pointerSize)
        => isValueType ? offset + HeaderSize(pointerSize) : offset;

    /// <inheritdoc cref="FromComputedLayout(long, bool, int)"/>
    public static long FromComputedLayout(long offset, TypeAnalysisContext owner)
        => FromComputedLayout(offset, owner.IsValueType, owner.AppContext.Binary.PointerSizeBytes);

    /// <inheritdoc cref="ToReceiverDisplacement(long, bool, int)"/>
    public static long ToReceiverDisplacement(long offset, TypeAnalysisContext owner)
        => ToReceiverDisplacement(offset, owner.IsValueType, owner.AppContext.Binary.PointerSizeBytes);
}
