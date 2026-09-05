using AssetRipper.IO.Files;
using System.Diagnostics.CodeAnalysis;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// An asset and the GUID Unity identifies it by, as recorded in its meta file.
/// </summary>
/// <param name="RelativePath">The asset's path relative to the package root, without the meta extension.</param>
/// <param name="Guid">The 32 character identifier from the meta file.</param>
public readonly record struct AssetIdentity(string RelativePath, string Guid);

/// <summary>
/// Reads the GUIDs a package assigns to its assets.
/// </summary>
public static class MetaGuidScanner
{
	private const string MetaExtension = ".meta";
	private const string GuidPrefix = "guid:";
	private const int GuidLength = 32;

	/// <summary>
	/// Reads the GUID out of a meta file.
	/// </summary>
	/// <remarks>
	/// The GUID is on its own line near the top. Reading line by line rather than parsing the whole
	/// document keeps this independent of the yaml a given Unity version writes.
	/// </remarks>
	public static bool TryReadGuid(TextReader reader, [NotNullWhen(true)] out string? guid)
	{
		while (reader.ReadLine() is string line)
		{
			ReadOnlySpan<char> trimmed = line.AsSpan().Trim();
			if (!trimmed.StartsWith(GuidPrefix, StringComparison.Ordinal))
			{
				continue;
			}

			ReadOnlySpan<char> value = trimmed[GuidPrefix.Length..].Trim();
			if (IsGuid(value))
			{
				guid = value.ToString();
				return true;
			}
		}

		guid = null;
		return false;
	}

	/// <summary>
	/// Whether a span is a Unity asset GUID.
	/// </summary>
	public static bool IsGuid(ReadOnlySpan<char> value)
	{
		if (value.Length != GuidLength)
		{
			return false;
		}

		foreach (char c in value)
		{
			if (!char.IsAsciiHexDigit(c))
			{
				return false;
			}
		}

		return true;
	}

	/// <summary>
	/// Finds every asset in a directory tree along with its GUID.
	/// </summary>
	/// <param name="root">The package root that returned paths are relative to.</param>
	/// <param name="fileSystem">
	/// Where to read from. An export may be written somewhere other than the local disk, and the same
	/// scan has to work against wherever that is.
	/// </param>
	public static List<AssetIdentity> Scan(string root, FileSystem? fileSystem = null)
	{
		fileSystem ??= LocalFileSystem.Instance;
		List<AssetIdentity> identities = [];

		if (!fileSystem.Directory.Exists(root))
		{
			return identities;
		}

		foreach (string metaPath in fileSystem.Directory.EnumerateFiles(root, $"*{MetaExtension}", SearchOption.AllDirectories))
		{
			string? guid;
			try
			{
				using StringReader reader = new(fileSystem.File.ReadAllText(metaPath));
				if (!TryReadGuid(reader, out guid))
				{
					continue;
				}
			}
			catch (IOException)
			{
				continue;
			}

			// The meta describes the file beside it, so its own extension comes off.
			string assetPath = metaPath[..^MetaExtension.Length];
			identities.Add(new AssetIdentity(GetRelativePath(root, assetPath), guid));
		}

		return identities;
	}

	/// <summary>
	/// The part of a path below a root, in the forward slash form Unity writes.
	/// </summary>
	public static string GetRelativePath(string root, string path)
	{
		string normalisedRoot = root.Replace('\\', '/').TrimEnd('/');
		string normalised = path.Replace('\\', '/');

		return normalised.StartsWith(normalisedRoot + '/', StringComparison.OrdinalIgnoreCase)
			? normalised[(normalisedRoot.Length + 1)..]
			: normalised;
	}
}
