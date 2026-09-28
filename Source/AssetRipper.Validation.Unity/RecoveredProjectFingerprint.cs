using System.Security.Cryptography;
using System.Text;

namespace AssetRipper.Validation.Unity;

/// <summary>
/// A content hash of everything a Unity build reads from a recovered project.
/// </summary>
/// <remarks>
/// <para>
/// A build or runtime verdict is a statement about one exact project. Recovery changes between
/// iterations, so a verdict without the hash of what was built cannot be compared with anything and
/// cannot be safely reused: the cache in <see cref="UnityBuildResultCache"/> refuses a result whose
/// fingerprint differs, whatever else matches.
/// </para>
/// <para>
/// Paths are hashed relative to the project and in ordinal order, so the hash does not depend on the
/// order a file system enumerates. Unity's own caches - <c>Library/</c>, <c>Temp/</c>, <c>Logs/</c>,
/// <c>obj/</c>, <c>UserSettings/</c> - are excluded, because they are outputs of an import rather
/// than inputs to one, and so is the validation editor script this pipeline injects, which is not
/// part of the recovery.
/// </para>
/// </remarks>
public sealed record RecoveredProjectFingerprint(
	string Project,
	string ProjectSettings,
	string Packages,
	string PackageLock,
	string Scripts,
	string Assets,
	int FileCount)
{
	private static readonly string[] ExcludedRoots = ["Library", "Temp", "Logs", "obj", "UserSettings", "Build", "Builds"];

	public static RecoveredProjectFingerprint Compute(string projectPath)
	{
		string root = Path.GetFullPath(projectPath);
		List<string> files = [];

		foreach (string path in Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories))
		{
			string relative = Path.GetRelativePath(root, path).Replace('\\', '/');

			if (IsExcluded(relative))
			{
				continue;
			}

			files.Add(relative);
		}

		files.Sort(StringComparer.Ordinal);

		using IncrementalHash project = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
		using IncrementalHash settings = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
		using IncrementalHash packages = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
		using IncrementalHash packageLock = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
		using IncrementalHash scripts = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
		using IncrementalHash assets = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);

		foreach (string relative in files)
		{
			byte[] content = File.ReadAllBytes(Path.Combine(root, relative));
			byte[] entry = Entry(relative, content);
			project.AppendData(entry);

			if (relative.StartsWith("ProjectSettings/", StringComparison.Ordinal))
			{
				settings.AppendData(entry);
			}
			else if (relative.StartsWith("Packages/", StringComparison.Ordinal))
			{
				packages.AppendData(entry);

				if (relative == "Packages/packages-lock.json" || relative == "Packages/manifest.json")
				{
					packageLock.AppendData(entry);
				}
			}
			else if (relative.EndsWith(".cs", StringComparison.Ordinal) || relative.EndsWith(".asmdef", StringComparison.Ordinal))
			{
				scripts.AppendData(entry);
			}
			else
			{
				assets.AppendData(entry);
			}
		}

		return new RecoveredProjectFingerprint(
			Hex(project), Hex(settings), Hex(packages), Hex(packageLock), Hex(scripts), Hex(assets), files.Count);
	}

	public static bool IsExcluded(string relativePath)
	{
		string first = relativePath.Split('/')[0];

		if (ExcludedRoots.Contains(first, StringComparer.Ordinal))
		{
			return true;
		}

		return relativePath.StartsWith(ValidationScript.InstallFolder + "/", StringComparison.Ordinal)
			|| relativePath == ValidationScript.InstallFolder + ".meta";
	}

	private static byte[] Entry(string relative, byte[] content)
	{
		// The path and the content's own hash, length-prefixed, so no two different sets of files can
		// concatenate to the same stream.
		byte[] path = Encoding.UTF8.GetBytes(relative);
		byte[] digest = SHA256.HashData(content);
		byte[] entry = new byte[4 + path.Length + digest.Length];
		BitConverter.TryWriteBytes(entry.AsSpan(0, 4), path.Length);
		path.CopyTo(entry, 4);
		digest.CopyTo(entry, 4 + path.Length);
		return entry;
	}

	private static string Hex(IncrementalHash hash) => Convert.ToHexStringLower(hash.GetHashAndReset());
}
