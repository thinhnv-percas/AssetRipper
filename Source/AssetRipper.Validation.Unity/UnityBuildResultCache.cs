using System.Security.Cryptography;
using System.Text;

namespace AssetRipper.Validation.Unity;

/// <summary>What a cached build verdict is a verdict about.</summary>
/// <remarks>
/// All four parts, because each alone is routinely equal between two different projects: the same
/// editor, the same platform and the same packages describe every iteration of one fixture, and only
/// the project fingerprint tells two recoveries apart.
/// </remarks>
public sealed record BuildCacheKey(string UnityVersion, string Platform, string ProjectFingerprint, string PackageLockFingerprint)
{
	public static BuildCacheKey For(UnityBuildResult result) => new(
		result.UnityVersion ?? "",
		result.TargetPlatform,
		result.Fingerprint?.Project ?? "",
		result.Fingerprint?.PackageLock ?? "");

	public override string ToString() => $"{UnityVersion}|{Platform}|{ProjectFingerprint}|{PackageLockFingerprint}";
}

/// <summary>
/// Build results kept on disk, returned only for exactly the key they were stored under.
/// </summary>
/// <remarks>
/// A verdict is never reused across a changed fingerprint. The file name is a hash of the key, and the
/// key is stored inside the file as well and compared on load, so a hash collision, a renamed file or
/// a hand-edited cache cannot hand back a verdict about another project. An unavailable result is not
/// cached at all: it says nothing about the project.
/// </remarks>
public sealed class UnityBuildResultCache(string directory)
{
	private const string KeyLinePrefix = "// key: ";

	public bool Store(UnityBuildResult result)
	{
		if (result.Status == UnityBuildStatus.UnityNotAvailable || result.Fingerprint is null)
		{
			return false;
		}

		BuildCacheKey key = BuildCacheKey.For(result);
		Directory.CreateDirectory(directory);
		File.WriteAllText(PathFor(key), KeyLinePrefix + key + "\n" + result.ToJson());
		return true;
	}

	public bool TryLoad(BuildCacheKey key, [NotNullWhen(true)] out string? json)
	{
		json = null;
		string path = PathFor(key);

		if (!File.Exists(path))
		{
			return false;
		}

		string text = File.ReadAllText(path);
		int newline = text.IndexOf('\n');

		if (newline < 0 || text[..newline] != KeyLinePrefix + key)
		{
			return false;
		}

		json = text[(newline + 1)..];
		return true;
	}

	private string PathFor(BuildCacheKey key)
		=> Path.Combine(directory, Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(key.ToString()))) + ".json");
}
