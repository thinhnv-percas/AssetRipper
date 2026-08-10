using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// What to do about one package.
/// </summary>
/// <remarks>
/// Every field is optional and every one of them overrides something that is worked out automatically.
/// The file exists for the cases the automation cannot settle: a package whose ripped copy was not
/// found, or one whose version in the cache is not the version the game shipped with.
/// </remarks>
public sealed class PackageRemapEntry
{
	/// <summary>
	/// The package's name, as it appears in a manifest. This is the key the entry is matched by.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	/// <summary>
	/// The version to write into the project's manifest. Empty takes the version from the package.
	/// </summary>
	[JsonPropertyName("version")]
	public string Version { get; set; } = "";

	/// <summary>
	/// Where the ripped copy landed, relative to Assets. Empty leaves it to be found by shape.
	/// </summary>
	[JsonPropertyName("folder")]
	public string Folder { get; set; } = "";

	/// <summary>
	/// Leaves the package alone entirely.
	/// </summary>
	[JsonPropertyName("skip")]
	public bool Skip { get; set; }
}

/// <summary>
/// The package remapping settings that are per package rather than per run.
/// </summary>
/// <remarks>
/// This is written back after every run with what was actually found, so the file is a record of the
/// automation's decisions as much as a way to override them. Editing it and exporting again is how a
/// package the locator could not place gets handled.
/// </remarks>
public sealed class PackageRemapConfiguration
{
	public const string FileName = "AssetRipper.PackageRemapping.json";

	/// <summary>
	/// Whether to delete the ripped files the official packages replace.
	/// </summary>
	/// <remarks>
	/// Leaving them behind means Unity compiles the decompiled scripts alongside the package's assembly
	/// and every type exists twice, so the default is to delete. Only files that were actually paired
	/// with a package file are removed; anything the package has no counterpart for is left alone.
	/// </remarks>
	[JsonPropertyName("deleteRippedCopies")]
	public bool DeleteRippedCopies { get; set; } = true;

	[JsonPropertyName("packages")]
	public List<PackageRemapEntry> Packages { get; set; } = [];

	public PackageRemapEntry? Find(string name)
	{
		return Packages.FirstOrDefault(entry => string.Equals(entry.Name, name, StringComparison.OrdinalIgnoreCase));
	}

	/// <summary>
	/// Reads the configuration, or returns the defaults when there is none yet.
	/// </summary>
	public static PackageRemapConfiguration Load(string path)
	{
		try
		{
			return File.Exists(path)
				? JsonSerializer.Deserialize(File.ReadAllText(path), PackageRemapSerializerContext.Default.PackageRemapConfiguration) ?? new()
				: new();
		}
		catch (Exception)
		{
			// A malformed file should not stop an export. The defaults are what it would have said.
			return new();
		}
	}

	public void Save(string path)
	{
		try
		{
			File.WriteAllText(path, JsonSerializer.Serialize(this, PackageRemapSerializerContext.Default.PackageRemapConfiguration));
		}
		catch (IOException)
		{
		}
	}
}

/// <summary>
/// The parts of a package's own manifest that say what to write into a project's.
/// </summary>
public sealed class UnityPackageInfo
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("version")]
	public string Version { get; set; } = "";

	/// <summary>
	/// Reads a package's manifest, or returns null when there is nothing usable in it.
	/// </summary>
	public static UnityPackageInfo? Read(string packageJsonPath)
	{
		try
		{
			UnityPackageInfo? info = JsonSerializer.Deserialize(File.ReadAllText(packageJsonPath), PackageRemapSerializerContext.Default.UnityPackageInfo);
			return string.IsNullOrEmpty(info?.Name) ? null : info;
		}
		catch (Exception)
		{
			return null;
		}
	}
}

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata, WriteIndented = true)]
[JsonSerializable(typeof(PackageRemapConfiguration))]
[JsonSerializable(typeof(UnityPackageInfo))]
internal sealed partial class PackageRemapSerializerContext : JsonSerializerContext
{
}
