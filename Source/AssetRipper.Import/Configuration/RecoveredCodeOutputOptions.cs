namespace AssetRipper.Import.Configuration;

/// <summary>
/// How recovered C# is written out: the one policy every emission site consults, so a choice about the shape of the
/// output is made once rather than at each place that happens to write something.
/// </summary>
/// <remarks>
/// Both options act where the output is produced, never on the text afterwards. The attributes are a processing
/// layer that is either installed or not, so nothing is generated and then deleted; the qualification is a syntax
/// tree transform that resolves each name before it shortens it, so a <c>global::</c> that is needed stays.
/// The settings they are read from are stored flat (<see cref="ImportSettings.EmitIl2CppOffsets"/> and the export
/// settings' <c>SimplifyGlobalQualification</c>) because that is what the settings page and the saved settings file
/// bind to; this record is the grouping consumers receive.
/// </remarks>
public sealed record class RecoveredCodeOutputOptions
{
	/// <summary>
	/// Emit the <c>Cpp2ILInjected</c> attributes - <c>[Address]</c>, <c>[Token]</c>, <c>[FieldOffset]</c>, and
	/// <c>[Attribute]</c> for a custom attribute the metadata could not express - together with the attribute types
	/// they need. Off, none of them is generated and none of their types is declared; every attribute the game itself
	/// carries is unaffected. Only has an effect at <see cref="ScriptContentLevel.Level3"/>.
	/// </summary>
	public bool EmitCpp2ILInjectedAttributes { get; init; } = true;

	/// <summary>
	/// Drop a <c>global::</c> qualifier wherever the name without it resolves to the same namespace or type at that
	/// point in the file. Where anything else of that name is in scope the qualifier is kept.
	/// </summary>
	public bool SimplifyGlobalQualification { get; init; } = true;

	public static RecoveredCodeOutputOptions Default { get; } = new();

	/// <summary>The half that import settings own; the qualification is an export concern and keeps its default.</summary>
	public static RecoveredCodeOutputOptions From(ImportSettings settings) => new()
	{
		EmitCpp2ILInjectedAttributes = settings.EmitIl2CppOffsets,
	};
}
