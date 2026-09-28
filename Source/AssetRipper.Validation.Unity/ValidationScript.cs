using System.Reflection;

namespace AssetRipper.Validation.Unity;

/// <summary>
/// The editor script a headless build executes, installed into a project only for the length of a build.
/// </summary>
/// <remarks>
/// The script is not written at export time: an <c>Editor</c> folder needs <c>UnityEditor</c> to
/// compile, which the stub assemblies this project's own compile check builds against do not have, so
/// a script injected at export would read as a recovery defect in every measurement that compiles the
/// export. It goes in just before Unity is launched and comes out afterwards, and
/// <see cref="RecoveredProjectFingerprint"/> excludes its folder.
/// </remarks>
public static class ValidationScript
{
	public const string InstallFolder = "Assets/Editor/AssetRipperValidation";
	public const string FileName = "RecoveredBuildValidation.cs";
	public const string BuildMethod = "AssetRipper.Validation.RecoveredBuildValidation.BuildPlayer";
	public const string ImportMethod = "AssetRipper.Validation.RecoveredBuildValidation.ValidateImport";
	public const string Marker = "[RecoveredBuildValidation]";

	public static string Source
	{
		get
		{
			using Stream stream = typeof(ValidationScript).Assembly.GetManifestResourceStream(FileName)
				?? throw new InvalidOperationException($"{FileName} is not embedded; resources: {string.Join(", ", typeof(ValidationScript).Assembly.GetManifestResourceNames())}");
			using StreamReader reader = new(stream);
			return reader.ReadToEnd();
		}
	}

	/// <summary>Writes the script; returns the folder to remove afterwards, or null if it was already there.</summary>
	public static string? Install(string projectPath)
	{
		string folder = Path.Combine(projectPath, InstallFolder);
		bool existed = Directory.Exists(folder);
		Directory.CreateDirectory(folder);
		File.WriteAllText(Path.Combine(folder, FileName), Source);
		return existed ? null : folder;
	}

	public static void Remove(string? installedFolder)
	{
		if (installedFolder is null || !Directory.Exists(installedFolder))
		{
			return;
		}

		Directory.Delete(installedFolder, recursive: true);

		string meta = installedFolder + ".meta";
		if (File.Exists(meta))
		{
			File.Delete(meta);
		}
	}
}
