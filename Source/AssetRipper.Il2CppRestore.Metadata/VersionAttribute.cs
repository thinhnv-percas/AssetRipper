namespace AssetRipper.Il2CppRestore.Metadata;

/// <summary>
/// Marks a field of a metadata struct as only existing for a range of metadata versions.
/// </summary>
/// <remarks>
/// The same struct's layout changes between Unity versions (fields added, removed, or reordered).
/// Rather than a forest of <c>if (version >= x)</c> checks scattered through reading code, each field
/// declares the version range it applies to and <see cref="VersionedReader"/> skips it entirely outside
/// that range — reading zero bytes for it, not a default value.
/// </remarks>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public sealed class VersionAttribute : Attribute
{
	/// <summary>
	/// The lowest metadata version this field exists at, or -1 for no lower bound.
	/// </summary>
	public double Min { get; set; } = -1;

	/// <summary>
	/// The highest metadata version this field exists at, or -1 for no upper bound.
	/// </summary>
	public double Max { get; set; } = -1;

	public bool Applies(double version) => (Min < 0 || version >= Min) && (Max < 0 || version <= Max);
}
