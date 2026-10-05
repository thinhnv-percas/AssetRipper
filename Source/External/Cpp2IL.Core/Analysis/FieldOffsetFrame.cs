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
/// <item><b>A receiver</b> il2cpp hands a value type's own instance method points at the value's data.
/// The <i>method pointer</i> the metadata records for that method is another matter: before the code
/// generation module carried a separate adjustor thunk table (metadata 24.5 and 27.1), the recorded
/// pointer was the adjustor thunk with the body inlined into it, which takes the boxed object - so on
/// 2019.2 <c>Rect.set_x</c> lifts to a store at <c>[X0 + 0x10]</c> for a field the metadata records at
/// 0, and on 2022.3 <c>Ray.get_direction</c> lifts to loads at <c>[X0 + 0xC]</c>, <c>0x10</c> and
/// <c>0x14</c>, the field's own offsets (<see cref="MethodPointerReceiverIsBoxed"/>).</item>
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
    /// AssetRipper: whether the method pointer the metadata records for a value type's instance method
    /// takes the boxed object rather than the value's data.
    /// </summary>
    /// <remarks>
    /// Iteration 065. The code generation module gained its own adjustor thunk table in metadata 24.5
    /// and 27.1 (and not 27.0, which is why LibCpp2IL reads <c>adjustorThunkCount</c> under exactly that
    /// condition). From then on the method pointer is the unadjusted body and the thunk is a separate
    /// entry; before it, the method pointer table held the thunk itself. That is a fact of the binary,
    /// not of the method, and it decides which offset a trivial accessor's body names. Writing the boxed
    /// frame for every binary - which is what this file did until now - is right on the 2019.2 fixture
    /// and wrong on every 2022.3 one, where no struct accessor ever paired: Merge-Room's 61
    /// <c>Rect.m_Width</c>/<c>m_Height</c>/<c>m_XMin</c>/<c>m_YMin</c> compile errors are that.
    /// </remarks>
    public static bool MethodPointerReceiverIsBoxed(float metadataVersion)
        => !(metadataVersion >= 27.1f || (metadataVersion >= 24.5f && metadataVersion < 27f));

    /// <summary>
    /// AssetRipper: a metadata offset, restated as the displacement the body behind a recorded method
    /// pointer of the field's declaring type names off its receiver.
    /// </summary>
    public static long ToMethodPointerDisplacement(long offset, TypeAnalysisContext owner)
        => owner.IsValueType && MethodPointerReceiverIsBoxed(owner.AppContext.MetadataVersion)
            ? offset + HeaderSize(owner.AppContext.Binary.PointerSizeBytes)
            : offset;

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
