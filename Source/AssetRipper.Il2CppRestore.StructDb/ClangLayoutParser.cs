using System.Text.RegularExpressions;

namespace AssetRipper.Il2CppRestore.StructDb;

/// <summary>
/// Parses <c>clang -Xclang -fdump-record-layouts</c> output into <see cref="StructInfo"/>s — the ground
/// truth for native IL2CPP runtime struct layouts (guide §10.2), read straight out of the Unity Editor's
/// own bundled clang and the exact libil2cpp headers for that version, instead of guessed or ported from
/// another tool.
/// </summary>
/// <remarks>
/// This has not been run against a real clang dump — the guide quotes only small fragments of the real
/// output, not a full sample, and there is no clang available to generate one in the sandbox this was
/// written in. The regexes and the anonymous/named-aggregate handling below follow the guide's stated
/// rules as closely as those fragments allow; validate against a real <c>layouts.txt</c> before trusting
/// a generated struct DB (guide §10.4's own T2 round-trip — <c>static_assert</c> every <c>sizeof</c> and
/// <c>offsetof</c> back against clang — is exactly the check that would catch a parsing mistake here).
/// </remarks>
public static partial class ClangLayoutParser
{
	[GeneratedRegex(@"^\s*(\d+)\s*\|\s*(?:struct|class|union)\s+(\S+)\s*$", RegexOptions.Compiled)]
	private static partial Regex TopHeadPattern { get; }

	/// <summary>
	/// A member line: <c>offset | indent type-and-name</c>, optionally a bitfield (<c>offset:bitStart-bitEnd</c>).
	/// Split into (whitespace-indent, the rest) rather than trying to separate type from name in one
	/// regex — <see cref="SplitTypeAndName"/> does that half, since a field's name is always its last
	/// identifier-shaped token but the type before it can contain spaces, <c>*</c>, and <c>::</c>.
	/// </summary>
	[GeneratedRegex(@"^\s*(\d+)(?::(\d+)-(\d+))?\s*\|(\s+)(.+?)\s*$", RegexOptions.Compiled)]
	private static partial Regex MemberLinePattern { get; }

	[GeneratedRegex(@"\[sizeof=(\d+), dsize=\d+, align=(\d+)", RegexOptions.Compiled)]
	private static partial Regex SizePattern { get; }

	/// <summary>An anonymous aggregate's own type spelling: <c>Outer::(anonymous at file:line:col)</c>, optionally followed by a field name.</summary>
	[GeneratedRegex(@"^(?:struct|union|class)\s+\S+::\(anonymous at [^)]*\)\s*(\S+)?$", RegexOptions.Compiled)]
	private static partial Regex AnonymousAggregatePattern { get; }

	private static readonly Dictionary<string, int> PrimitiveSizes = new(StringComparer.Ordinal)
	{
		["bool"] = 1,
		["char"] = 1,
		["signed char"] = 1,
		["unsigned char"] = 1,
		["int8_t"] = 1,
		["uint8_t"] = 1,
		["short"] = 2,
		["unsigned short"] = 2,
		["int16_t"] = 2,
		["uint16_t"] = 2,
		["wchar_t"] = 2,
		["int"] = 4,
		["unsigned int"] = 4,
		["int32_t"] = 4,
		["uint32_t"] = 4,
		["float"] = 4,
		["long"] = 8,
		["unsigned long"] = 8,
		["long long"] = 8,
		["unsigned long long"] = 8,
		["int64_t"] = 8,
		["uint64_t"] = 8,
		["double"] = 8,
		["size_t"] = 8,
	};

	public static Dictionary<string, StructInfo> Parse(string text, int pointerSize)
	{
		Dictionary<string, StructInfo> result = [];
		StructInfo? current = null;
		int baseIndent = -1;
		// (indent at which this frame's children live, dotted-path prefix, is this frame a transparent/anonymous aggregate)
		List<(int ChildIndent, string Prefix, bool Transparent)> nestedFrames = [];
		// A run of consecutive bitfield lines shares one storage unit; tracked so BitOffset can be made
		// relative to where that run started rather than to each line's own (already-absolute) byte.
		int? bitfieldClusterStart = null;
		int bitfieldClusterOrdinal = 0;

		foreach (string rawLine in text.Split('\n'))
		{
			// A -fdump-record-layouts run also emits an "IRgen Record Layout" pass after the AST one;
			// re-parsing that as if it were more AST content corrupts whatever this already collected.
			if (rawLine.Contains("*** Dumping IRgen Record Layout"))
			{
				break;
			}

			if (rawLine.Contains("*** Dumping AST Record Layout"))
			{
				current = null;
				baseIndent = -1;
				nestedFrames.Clear();
				bitfieldClusterStart = null;
				bitfieldClusterOrdinal = 0;
				continue;
			}

			Match topHead = TopHeadPattern.Match(rawLine);
			if (topHead.Success && current is null)
			{
				current = new StructInfo { Name = topHead.Groups[2].Value };
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
				current = null; // End of this struct's block.
				continue;
			}

			Match memberMatch = MemberLinePattern.Match(rawLine);
			if (!memberMatch.Success)
			{
				continue;
			}

			int offset = int.Parse(memberMatch.Groups[1].Value);
			bool isBitfield = memberMatch.Groups[2].Success;
			int bitStart = isBitfield ? int.Parse(memberMatch.Groups[2].Value) : 0;
			int bitEnd = isBitfield ? int.Parse(memberMatch.Groups[3].Value) : 0;
			int indent = memberMatch.Groups[4].Value.Length;
			string typeAndName = memberMatch.Groups[5].Value;

			if (baseIndent < 0)
			{
				baseIndent = indent;
			}

			// Pop back to whichever open frame this line's indent actually belongs to.
			while (nestedFrames.Count > 0 && indent < nestedFrames[^1].ChildIndent)
			{
				nestedFrames.RemoveAt(nestedFrames.Count - 1);
			}

			string pathPrefix = nestedFrames.Count > 0 ? nestedFrames[^1].Prefix : "";
			bool parentIsOpaque = nestedFrames.Count > 0 && !nestedFrames[^1].Transparent;

			Match anon = AnonymousAggregatePattern.Match(typeAndName);
			if (anon.Success)
			{
				// Guide §10.2 trap #4: a truly anonymous member (line ends right at the ")") merges its
				// children directly into the enclosing struct with no prefix at all and is itself never a
				// field. An anonymous-TYPED member that still has its own field name (e.g. "... ) data")
				// is the opposite: an ordinary named field whose children get a "data." prefix.
				string? fieldName = anon.Groups[1].Success ? anon.Groups[1].Value : null;
				bool isUnion = typeAndName.TrimStart().StartsWith("union", StringComparison.Ordinal);

				if (fieldName is null)
				{
					nestedFrames.Add((indent + 1, pathPrefix, Transparent: true));
					// Nothing added as a field for the anonymous aggregate itself; its members (next
					// lines, deeper indent) will be picked up by the frame just pushed, and are marked
					// Union so callers know several of them can legitimately share one offset.
					if (isUnion)
					{
						MarkNextSiblingsAsUnion(current, offset);
					}
					continue;
				}
				else
				{
					nestedFrames.Add((indent + 1, pathPrefix.Length == 0 ? fieldName + "." : pathPrefix + fieldName + ".", Transparent: true));
					if (!parentIsOpaque)
					{
						current.Fields.Add(new StructField
						{
							Name = pathPrefix + fieldName,
							Type = isUnion ? "union" : "struct",
							Offset = offset,
							Union = isUnion,
						});
					}
					continue;
				}
			}

			(string type, string name) = SplitTypeAndName(typeAndName);
			if (name.Length == 0)
			{
				continue;
			}

			// A named nested aggregate field (e.g. "struct Il2CppAssemblyName aname") is opaque: it is a
			// single field here, and its own members belong to that type's OWN struct entry elsewhere in
			// the same clang output (guide §10.2 trap #3) — not flattened into this one. Still push a
			// frame so its (upcoming, deeper-indented) children are skipped rather than misread as this
			// struct's own direct fields.
			bool looksLikeExpandedAggregate = LooksLikeRecordType(type);
			if (looksLikeExpandedAggregate)
			{
				nestedFrames.Add((indent + 1, pathPrefix + name + ".", Transparent: false));
			}

			if (parentIsOpaque)
			{
				continue; // Inside a named nested aggregate's expansion — already accounted for as one field.
			}

			StructField field = new()
			{
				Name = pathPrefix + name,
				Type = type,
				Offset = offset,
			};

			if (isBitfield)
			{
				// Clang prints (byteOffset:bitStart-bitEnd) per line, both relative to that line's own
				// byte — the DB's own convention is relative to where the whole contiguous run of
				// bitfields started instead (guide §10.2 trap #6), which is what makes a Il2CppType-style
				// cluster come out as a clean 0/16/24/... within one 32-bit unit.
				bitfieldClusterStart ??= offset;
				field.Bits = bitEnd - bitStart + 1;
				field.BitOffset = (offset - bitfieldClusterStart.Value) * 8 + bitStart;
				field.BitOrdinal = bitfieldClusterOrdinal++;
				// The byte offset recorded for a bitfield member is the cluster's own start, not this
				// individual line's — every member of one cluster lives in the same storage unit.
				field.Offset = bitfieldClusterStart.Value;
			}
			else
			{
				bitfieldClusterStart = null;
				bitfieldClusterOrdinal = 0;
				field.Size = InferSize(type, pointerSize, result);
				if (type.TrimEnd().EndsWith('*'))
				{
					field.ArrayItemSize = InferSize(type.TrimEnd().TrimEnd('*').TrimEnd(), pointerSize, result);
				}
			}

			current.Fields.Add(field);
		}

		// A field naming a struct that is dumped LATER in the same clang output could not have its size
		// resolved on the first pass (structsSoFar didn't have it yet) — now that every block has been
		// read, retry those before leaving any as an unresolved 0 that a second clang probe never gets a
		// chance to fix.
		foreach (StructInfo info in result.Values)
		{
			foreach (StructField field in info.Fields)
			{
				if (field.Size == 0 && !field.IsBitfield)
				{
					field.Size = InferSize(field.Type, pointerSize, result);
				}
			}
		}

		return result;
	}

	private static void MarkNextSiblingsAsUnion(StructInfo current, int offset)
	{
		// Retroactively flag any already-added field at this same offset — the union tag itself carries
		// no field, so the only signal that its members share storage is this shared offset.
		foreach (StructField f in current.Fields)
		{
			if (f.Offset == offset)
			{
				f.Union = true;
			}
		}
	}

	/// <summary>
	/// Splits "<c>const char * name</c>" into ("const char *", "name") — the name is always the last
	/// identifier-shaped token; everything before it is the type, however many words or <c>*</c>s long.
	/// </summary>
	private static (string Type, string Name) SplitTypeAndName(string typeAndName)
	{
		int lastSpace = typeAndName.TrimEnd().LastIndexOf(' ');
		if (lastSpace < 0)
		{
			return ("", typeAndName.Trim());
		}
		string name = typeAndName[(lastSpace + 1)..].Trim();
		string type = typeAndName[..lastSpace].Trim();

		// A field name is never itself punctuation-only (a bare "*" or "::Something") — if what looks
		// like the "name" is actually still part of the type (a bitfield's anonymous padding, or a
		// pointer with the * glued to the type), there is nothing usable to split further.
		if (name.Length == 0 || name is "*" || name.EndsWith(':'))
		{
			return (typeAndName.Trim(), "");
		}
		return (type, name);
	}

	/// <summary>
	/// Guide §10.2 trap #5: a function pointer's clang spelling can itself start with <c>struct</c> (its
	/// return type), e.g. <c>struct Il2CppIUnknown *(*)(Il2CppObject *)</c> — checking for a <c>(</c>
	/// before treating a leading "struct "/"class "/"union " as a record-type prefix is what keeps that
	/// from being misidentified as an aggregate.
	/// </summary>
	private static bool LooksLikeRecordType(string type)
	{
		if (type.Contains('('))
		{
			return false;
		}
		string trimmed = type.TrimEnd('*', ' ');
		return (trimmed.StartsWith("struct ", StringComparison.Ordinal)
			|| trimmed.StartsWith("class ", StringComparison.Ordinal)
			|| trimmed.StartsWith("union ", StringComparison.Ordinal))
			&& !type.TrimEnd().EndsWith('*'); // A struct POINTER field is opaque data, not an expanded aggregate.
	}

	/// <summary>
	/// Type-driven, not "next field's offset minus this one's" — guide §10.2 explicitly calls that
	/// approach out as wrong, since it silently folds compiler-inserted padding into the previous field's
	/// reported size (e.g. <c>int a; void* b;</c> on x64 would report <c>a</c> as 8 bytes, not 4).
	/// </summary>
	private static int InferSize(string type, int pointerSize, Dictionary<string, StructInfo> structsSoFar)
	{
		string trimmed = type.Trim();
		if (trimmed.EndsWith('*'))
		{
			return pointerSize;
		}

		string normalized = trimmed.Replace("const ", "").Replace("struct ", "").Replace("class ", "").Replace("union ", "").Trim();
		if (PrimitiveSizes.TryGetValue(normalized, out int primitiveSize))
		{
			return primitiveSize;
		}
		if (structsSoFar.TryGetValue(normalized, out StructInfo? known) && known.Size > 0)
		{
			return known.Size;
		}

		// A genuinely opaque scalar typedef or enum (guide §10.2's "hỏi thẳng clang" fallback: wrap it in
		// a probe struct and read that struct's own sizeof) needs a second clang invocation to resolve —
		// orchestrating that lives in StructDbGenerator, not here. 0 here means "unresolved", and the
		// generator's own verification pass (§10.4) is what catches a field that stayed that way.
		return 0;
	}
}
