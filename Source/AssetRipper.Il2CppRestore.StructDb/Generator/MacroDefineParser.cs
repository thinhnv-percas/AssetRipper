using System.Text.RegularExpressions;

namespace AssetRipper.Il2CppRestore.StructDb.Generator;

/// <summary>
/// Parses <c>clang -dM -E</c> output — a fixed, simple format (<c>#define NAME body</c>, one per line)
/// unlike the other two clang passes, so this one is high-confidence without a real sample to check
/// against (guide §10.2's third pass).
/// </summary>
public static partial class MacroDefineParser
{
	[GeneratedRegex(@"^#define\s+(\w+)(?:\([^)]*\))?\s*(.*)$", RegexOptions.Compiled)]
	private static partial Regex DefinePattern { get; }

	/// <summary>
	/// Only object-like macros the guide's example calls out (e.g. <c>IL2CPP_ZERO_LEN_ARRAY</c>) are
	/// worth keeping — function-like macros (name immediately followed by <c>(</c>, no space) don't
	/// resolve a field's type the way a plain constant does, and the standard library dumps thousands of
	/// them that have nothing to do with IL2CPP.
	/// </summary>
	public static Dictionary<string, string> Parse(string text, Func<string, bool>? nameFilter = null)
	{
		Dictionary<string, string> defines = [];
		foreach (string line in text.Split('\n'))
		{
			if (!line.StartsWith("#define ", StringComparison.Ordinal))
			{
				continue;
			}

			Match match = DefinePattern.Match(line);
			if (!match.Success)
			{
				continue;
			}

			string name = match.Groups[1].Value;
			// A function-like macro's name is immediately followed by '(' with no space in the source
			// text — re-check against the raw line rather than the already-normalized regex groups.
			if (line.Length > 8 + name.Length && line[8 + name.Length] == '(')
			{
				continue;
			}
			if (nameFilter is not null && !nameFilter(name))
			{
				continue;
			}

			defines[name] = match.Groups[2].Value.Trim();
		}
		return defines;
	}
}
