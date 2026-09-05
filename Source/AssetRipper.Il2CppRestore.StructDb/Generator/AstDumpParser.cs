using System.Text.RegularExpressions;

namespace AssetRipper.Il2CppRestore.StructDb.Generator;

/// <summary>
/// Parses <c>clang -Xclang -ast-dump -fsyntax-only</c> text output for <c>EnumDecl</c>/<c>EnumConstantDecl</c>
/// and <c>TypedefDecl</c> nodes — the second of the guide's three clang passes (§10.2), needed because
/// <c>-fdump-record-layouts</c> alone only covers struct/union layout, not enum values or typedef targets.
/// </summary>
/// <remarks>
/// <b>Best-effort, unverified against a real dump.</b> The guide gives the general shape of clang's AST
/// dump tree (indentation with <c>|</c>/<c>`</c> connectors, a decl kind, then flags, then a name), but no
/// full sample — clang's exact punctuation varies across versions and node kinds enough that this should
/// be checked against a real <c>clang -Xclang -ast-dump</c> run before trusting its output. Guide §10.2
/// trap #7 (don't filter by "libil2cpp" appearing in the location string — most decls after the first in
/// a file print only <c>line:N:C</c>) and trap #5 (a function pointer's spelling can start with
/// <c>struct</c>; check for <c>(</c> first) are both applied here.
/// </remarks>
public static partial class AstDumpParser
{
	[GeneratedRegex(@"EnumDecl\b.*?\b(\w+)\s*$", RegexOptions.Compiled)]
	private static partial Regex EnumDeclPattern { get; }

	[GeneratedRegex(@"EnumConstantDecl\b.*?\s(\w+)\s+'[^']*'", RegexOptions.Compiled)]
	private static partial Regex EnumConstantPattern { get; }

	[GeneratedRegex(@"IntegerLiteral\b.*?'[^']*'\s+(-?\d+)\s*$", RegexOptions.Compiled)]
	private static partial Regex IntegerLiteralPattern { get; }

	[GeneratedRegex(@"TypedefDecl\b.*?\s(\w+)\s+'([^']*)'(?::'([^']*)')?\s*$", RegexOptions.Compiled)]
	private static partial Regex TypedefDeclPattern { get; }

	/// <summary>Depth of a dump-tree line, counted from its leading connector characters rather than raw whitespace (clang's <c>-ast-dump</c> uses <c>| </c>/<c>  </c>/<c>`-</c>/<c>|-</c> prefixes, not indentation alone).</summary>
	private static int DepthOf(string line)
	{
		int depth = 0;
		for (int i = 0; i + 1 < line.Length; i += 2)
		{
			char c = line[i];
			if (c is '|' or ' ')
			{
				depth++;
				continue;
			}
			break;
		}
		return depth;
	}

	public static Dictionary<string, string> ParseEnums(string text, Func<string, bool> nameFilter)
	{
		Dictionary<string, string> enums = [];
		string[] lines = text.Split('\n');

		for (int i = 0; i < lines.Length; i++)
		{
			Match enumMatch = EnumDeclPattern.Match(lines[i]);
			if (!enumMatch.Success)
			{
				continue;
			}
			string enumName = enumMatch.Groups[1].Value;
			if (!nameFilter(enumName))
			{
				continue;
			}

			int enumDepth = DepthOf(lines[i]);
			List<string> members = [];
			long nextImplicitValue = 0;

			for (int j = i + 1; j < lines.Length; j++)
			{
				int depth = DepthOf(lines[j]);
				if (depth <= enumDepth && (lines[j].Contains("Decl") || lines[j].Trim().Length == 0))
				{
					break; // Back out to a sibling/parent declaration — this enum's constants are done.
				}

				Match constantMatch = EnumConstantPattern.Match(lines[j]);
				if (!constantMatch.Success)
				{
					continue;
				}

				long value = nextImplicitValue;
				// An explicit initializer shows up as a child IntegerLiteral a line or two further in,
				// at a deeper indent than the EnumConstantDecl itself.
				for (int k = j + 1; k < lines.Length && DepthOf(lines[k]) > depth; k++)
				{
					Match literalMatch = IntegerLiteralPattern.Match(lines[k]);
					if (literalMatch.Success)
					{
						value = long.Parse(literalMatch.Groups[1].Value);
						break;
					}
				}

				members.Add($"{constantMatch.Groups[1].Value}={value}");
				nextImplicitValue = value + 1;
			}

			if (members.Count > 0)
			{
				enums[enumName] = string.Join(",", members);
			}
		}

		return enums;
	}

	public static Dictionary<string, string> ParseTypedefs(string text, Func<string, bool> nameFilter)
	{
		Dictionary<string, string> typedefs = [];

		foreach (string line in text.Split('\n'))
		{
			Match match = TypedefDeclPattern.Match(line);
			if (!match.Success)
			{
				continue;
			}

			string name = match.Groups[1].Value;
			if (!nameFilter(name))
			{
				continue;
			}

			string target = match.Groups[2].Value;
			// Trap #5: a function pointer's printed type can itself start with "struct" (its return
			// type) — e.g. "struct Il2CppIUnknown *(*)(Il2CppObject *)". Only strip a leading
			// struct/class/union keyword when there is no '(' anywhere in the spelling.
			bool isFunctionPointer = target.Contains('(');
			string typedefText = isFunctionPointer
				? $"typedef {target} {name};"
				: $"typedef {StripAggregateKeyword(target)} {name};";

			typedefs[name] = typedefText;
		}

		return typedefs;
	}

	private static string StripAggregateKeyword(string type) => type; // Kept as clang spells it (e.g. "struct MonitorData") — a rebuilt header needs the keyword to compile as a forward declaration.
}
