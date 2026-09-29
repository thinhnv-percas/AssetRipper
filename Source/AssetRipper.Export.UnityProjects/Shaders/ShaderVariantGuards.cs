using System.Security.Cryptography;
using System.Text;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: every compiled variant of a pass in one <c>GLSLPROGRAM</c>, each under a guard of the
/// exact keyword set it was compiled for.
/// </summary>
/// <remarks>
/// <para>
/// A pass compiled for several keyword sets has one program per set, and the engine picks the one
/// whose keywords match what the material (and the engine itself) enabled. Iteration 061 wrote one of
/// them per pass with no keyword handling, so the recovered project compiled exactly that one program
/// and every material of the shader drew with it: 4 of 9 bindings on one fixture and 6 of 30 on another
/// drew with the keywordless variant while their keywords selected another. The program was right and
/// the material still drew the wrong thing.
/// </para>
/// <para>
/// Nothing here chooses. Each guard is the variant's own keyword set, written as "these keywords
/// defined and every other keyword of the pass not" - so a keyword state selects the program the
/// original build compiled for exactly that state, or none. A state the original build never compiled
/// falls to an <c>#else</c> that says so (<c>VARIANT_SELECTION_UNKNOWN</c>): at run time Unity would
/// have picked a nearest match by its own rules, which this cannot reproduce, and writing the base
/// program there without saying so would be the heuristic the export must not contain.
/// </para>
/// <para>
/// Identical programs compiled for several keyword sets share one guard, so the text is one copy per
/// distinct program. A program is identified by its content, never by its blob index: iteration 061
/// found the index-to-program table read with the wrong stride, and an identity that rests on the table
/// alone inherits every error in it.
/// </para>
/// <para>
/// Each keyword is declared on its own with <c>multi_compile</c> or <c>multi_compile_local</c>, as the
/// asset's own keyword flags record its scope, because the variant table says
/// which combinations were compiled and not which keywords a directive grouped or whether a material
/// or the engine sets them; declaring every combination is what keeps a keyword the engine enables at
/// run time (the UI's clip rect) from being stripped. That is 2^n combinations, so a pass with more than
/// <see cref="MaximumKeywords"/> keywords is not embedded and says so.
/// </para>
/// </remarks>
public static class ShaderVariantGuards
{
	public const int MaximumKeywords = 8;
	public const int MaximumBytes = 1 << 20;

	public sealed record Variant(int Index, IReadOnlyList<string> Keywords, string Source);

	public sealed record Result(string? Text, string Reason, int DistinctPrograms, IReadOnlyList<string> Keywords);

	public static string ContentHash(string source)
		=> Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(source.Replace("\r", ""))))[..16].ToLowerInvariant();

	/// <param name="isLocal">
	/// The scope the shader asset records for a keyword: true for local, false for global, null when it
	/// records none. A keyword the engine sets - a shadow caster's <c>SHADOWS_DEPTH</c>, fog, instancing -
	/// is global, and declared local it would never be seen as enabled, so the program that pass needs
	/// would be unreachable. With no record the declaration is global, which a material keyword also
	/// reaches.
	/// </param>
	public static Result Build(IReadOnlyList<Variant> variants, string indent = "\t\t\t", Func<string, bool?>? isLocal = null)
	{
		if (variants.Count == 0)
			return new Result(null, "no variant with source", 0, []);

		List<string> keywords = [.. variants.SelectMany(variant => variant.Keywords).Distinct(StringComparer.Ordinal).Order(StringComparer.Ordinal)];

		// One guard per distinct program, in the order the table first reaches each.
		List<(string Hash, string Source, List<Variant> Sets)> programs = [];
		foreach (var variant in variants)
		{
			string hash = ContentHash(variant.Source);
			int existing = programs.FindIndex(program => program.Hash == hash);
			if (existing >= 0)
				programs[existing].Sets.Add(variant);
			else
				programs.Add((hash, variant.Source, [variant]));
		}

		if (programs.Count == 1)
			return new Result(null, "one distinct program", 1, keywords);

		if (keywords.Count > MaximumKeywords)
			return new Result(null, $"{keywords.Count} keywords exceed the {MaximumKeywords} that can be declared combinatorially", programs.Count, keywords);

		long bytes = programs.Sum(program => (long)program.Source.Length);
		if (bytes > MaximumBytes)
			return new Result(null, $"{bytes} bytes of distinct programs exceed {MaximumBytes}", programs.Count, keywords);

		StringBuilder text = new();
		text.Append(indent).Append("// AssetRipperRecoveredVariants: ").Append(programs.Count).Append(" distinct programs over ")
			.Append(variants.Count).Append(" keyword sets; keywords ").Append(string.Join(' ', keywords)).Append('\n');

		foreach (string keyword in keywords)
		{
			string directive = isLocal?.Invoke(keyword) == true ? "multi_compile_local" : "multi_compile";
			text.Append(indent).Append("#pragma ").Append(directive).Append(" __ ").Append(keyword).Append('\n');
		}

		for (int index = 0; index < programs.Count; index++)
		{
			var (hash, source, sets) = programs[index];
			string condition = string.Join(" || ", sets.Select(set => Guard(set.Keywords, keywords)));
			text.Append(indent).Append(index == 0 ? "#if " : "#elif ").Append(condition).Append('\n');

			foreach (var set in sets)
			{
				text.Append(indent).Append("// AssetRipperVariant: variant ").Append(set.Index + 1).Append(", content ").Append(hash)
					.Append(", keywords ").Append(set.Keywords.Count == 0 ? "<none>" : string.Join('+', set.Keywords)).Append('\n');
			}

			foreach (string line in source.Replace("\r", "").Split('\n'))
				text.Append(indent).Append(line).Append('\n');
		}

		text.Append(indent).Append("#else\n");
		text.Append(indent).Append("// AssetRipperVariantSelectionUnknown: the original build compiled no program for this keyword state\n");
		text.Append(indent).Append("#error VARIANT_SELECTION_UNKNOWN\n");
		text.Append(indent).Append("#endif\n");

		return new Result(text.ToString(), "embedded", programs.Count, keywords);
	}

	private static string Guard(IReadOnlyList<string> set, IReadOnlyList<string> all)
	{
		IEnumerable<string> terms = all.Select(keyword => set.Contains(keyword, StringComparer.Ordinal)
			? $"defined({keyword})"
			: $"!defined({keyword})");
		return "(" + string.Join(" && ", terms) + ")";
	}
}
