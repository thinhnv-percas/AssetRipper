using System.Text.RegularExpressions;

namespace AssetRipper.Il2CppRestore.StructDb;

/// <summary>
/// Just enough of a Unity version (major.minor.patch) to pick the closest struct DB when there is no
/// exact match — see <see cref="StructDb.LoadNearest"/>. Deliberately not a general Unity-version
/// parser; AssetRipper's own richer version type lives in a different assembly this project does not
/// reference, to keep the struct DB usable stand-alone per the guide's "mang sang project khác" goal.
/// </summary>
public sealed partial record UnityVersionKey(int Major, int Minor, int Patch)
{
	[GeneratedRegex(@"(?<major>\d+)\.(?<minor>\d+)\.(?<patch>\d+)")]
	private static partial Regex Pattern { get; }

	public static UnityVersionKey? Parse(string text)
	{
		Match match = Pattern.Match(text);
		return match.Success
			? new UnityVersionKey(int.Parse(match.Groups["major"].Value), int.Parse(match.Groups["minor"].Value), int.Parse(match.Groups["patch"].Value))
			: null;
	}

	/// <summary>Parses the version out of a struct DB file name such as <c>2022.3.62f2-arm64.json</c>.</summary>
	public static UnityVersionKey? ParseFromFileName(string path) => Parse(Path.GetFileName(path));

	/// <summary>A crude "how far apart" measure — exact enough to prefer the same major.minor over a different one.</summary>
	public long DistanceTo(UnityVersionKey other) =>
		Math.Abs(Major - other.Major) * 1_000_000L + Math.Abs(Minor - other.Minor) * 1_000L + Math.Abs(Patch - other.Patch);
}
