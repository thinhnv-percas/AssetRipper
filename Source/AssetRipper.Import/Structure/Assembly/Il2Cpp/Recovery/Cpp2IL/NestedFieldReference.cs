using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery.Cpp2IL;

/// <summary>
/// A field reached through one or more value type fields — <c>fsmColor.value.g</c>, where
/// <c>value</c> is a <c>Color</c> and <c>g</c> is a float inside it.
/// </summary>
/// <remarks>
/// Cpp2IL's own <see cref="FieldReference"/> holds a single field, and its resolver gives up when an
/// offset lands in the interior of one rather than on its boundary. This is the operand
/// <see cref="NestedFieldResolver"/> puts in place instead, and that
/// <see cref="Il2CppIlGenerator"/> knows how to read and write.
/// </remarks>
/// <param name="local">The object the access starts from. Always a reference type.</param>
/// <param name="path">The fields to walk, outermost first. The last one is the field being accessed.</param>
/// <param name="offset">The offset in the object this access was resolved from, kept for diagnostics.</param>
public sealed class NestedFieldReference(LocalVariable local, IReadOnlyList<FieldAnalysisContext> path, int offset) : IOperand
{
	public LocalVariable Local { get; } = local;

	public IReadOnlyList<FieldAnalysisContext> Path { get; } = path;

	public int Offset { get; } = offset;

	public override string ToString()
		=> $"{Local.Name}.{string.Join('.', Path.Select(field => field.Name))} ({Path[^1].FieldType.FullName})";
}
