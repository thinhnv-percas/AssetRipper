using System.Text.RegularExpressions;

namespace AssetRipper.Il2CppRestore.StructDb;

/// <summary>
/// Parses <c>clang -Xclang -fdump-record-layouts</c> output into <see cref="StructInfo"/>s — the ground
/// truth for native IL2CPP runtime struct layouts (guide §10.2), read straight out of the Unity Editor's
/// own bundled clang and the exact libil2cpp headers for that version, instead of guessed or ported from
/// another tool.
/// </summary>
public static partial class ClangLayoutParser
{
	[GeneratedRegex(@"^\s*(\d+)\s*\|\s*(?:struct|class|union)\s+(\S+)\s*$", RegexOptions.Compiled)]
	private static partial Regex HeadPattern { get; }

	[GeneratedRegex(@"^\s*(\d+)(?::(\d+)-(\d+))?\s*\|(\s+)(.+?)\s+(\w+)\s*$", RegexOptions.Compiled)]
	private static partial Regex FieldPattern { get; }

	[GeneratedRegex(@"\[sizeof=(\d+), dsize=\d+, align=(\d+)", RegexOptions.Compiled)]
	private static partial Regex SizePattern { get; }

	public static Dictionary<string, StructInfo> Parse(string text)
	{
		Dictionary<string, StructInfo> result = [];
		StructInfo? current = null;
		int baseIndent = -1;

		foreach (string rawLine in text.Split('\n'))
		{
			// Clang follows the AST layout dump with an IRgen layout dump for the same structs; reading
			// past this point re-parses the same structs under a different (LLVM-level) shape and
			// corrupts whatever the AST pass already collected.
			if (rawLine.Contains("*** Dumping IRgen Record Layout"))
			{
				break;
			}

			if (rawLine.Contains("*** Dumping AST Record Layout"))
			{
				current = null;
				baseIndent = -1;
				continue;
			}

			Match headMatch = HeadPattern.Match(rawLine);
			if (headMatch.Success && current is null)
			{
				current = new StructInfo { Name = headMatch.Groups[2].Value };
				result[current.Name] = current;
				continue;
			}

			if (current is null)
			{
				continue;
			}

			Match sizeMatch = SizePattern.Match(rawLine);
			if (sizeMatch.Success)
			{
				current.Size = int.Parse(sizeMatch.Groups[1].Value);
				current.Align = int.Parse(sizeMatch.Groups[2].Value);
				current = null; // end of this struct.
				continue;
			}

			Match fieldMatch = FieldPattern.Match(rawLine);
			if (!fieldMatch.Success)
			{
				continue;
			}

			int indent = fieldMatch.Groups[4].Value.Length;
			if (baseIndent < 0)
			{
				baseIndent = indent;
			}
			// A nested struct's own fields are dumped more deeply indented, right after it; skipping
			// them here is what keeps them from being attributed to the outer struct.
			if (indent > baseIndent)
			{
				continue;
			}

			current.Fields.Add(new StructField
			{
				Offset = int.Parse(fieldMatch.Groups[1].Value),
				Type = fieldMatch.Groups[5].Value.Trim(),
				Name = fieldMatch.Groups[6].Value,
				BitStart = fieldMatch.Groups[2].Success ? int.Parse(fieldMatch.Groups[2].Value) : -1,
				BitEnd = fieldMatch.Groups[3].Success ? int.Parse(fieldMatch.Groups[3].Value) : -1,
			});
		}

		// A field's size is the gap to the next field's offset (or to the struct's own size, for the
		// last one) — clang's layout dump gives offsets, not sizes, so this is the only way to get one.
		foreach (StructInfo info in result.Values)
		{
			for (int i = 0; i < info.Fields.Count; i++)
			{
				int nextOffset = i + 1 < info.Fields.Count ? info.Fields[i + 1].Offset : info.Size;
				info.Fields[i].Size = nextOffset - info.Fields[i].Offset;
			}
		}

		return result;
	}
}
