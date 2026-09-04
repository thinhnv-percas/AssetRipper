using AssetRipper.Import.Logging;

namespace AssetRipper.Export.Configuration;

public sealed record class ExportSettings
{
	/// <summary>
	/// The file format that audio clips get exported in. Recommended: Ogg
	/// </summary>
	public AudioExportFormat AudioExportFormat { get; set; } = AudioExportFormat.Default;

	/// <summary>
	/// The file format that images (like textures) get exported in.
	/// </summary>
	public ImageExportFormat ImageExportFormat { get; set; } = ImageExportFormat.Png;

	/// <summary>
	/// The file format that images (like textures) get exported in.
	/// </summary>
	public LightmapTextureExportFormat LightmapTextureExportFormat { get; set; } = LightmapTextureExportFormat.Yaml;

	/// <summary>
	/// How are MonoScripts exported? Recommended: Decompiled
	/// </summary>
	public ScriptExportMode ScriptExportMode { get; set; } = ScriptExportMode.Hybrid;

	/// <summary>
	/// The C# language version of decompiled scripts.
	/// </summary>
	public ScriptLanguageVersion ScriptLanguageVersion { get; set; } = ScriptLanguageVersion.AutoSafe;

	/// <summary>
	/// If true, type references in scripts are fully qualified.
	/// </summary>
	public bool ScriptTypesFullyQualified { get; set; } = false;

	/// <summary>
	/// How to export shaders?
	/// </summary>
	public ShaderExportMode ShaderExportMode { get; set; } = ShaderExportMode.Dummy;

	/// <summary>
	/// Should sprites be exported as a texture? Recommended: Native
	/// </summary>
	public SpriteExportMode SpriteExportMode { get; set; } = SpriteExportMode.Yaml;

	/// <summary>
	/// How are text assets exported?
	/// </summary>
	public TextExportMode TextExportMode { get; set; } = TextExportMode.Parse;

	public bool ExportUnreadableAssets { get; set; } = false;

	/// <summary>
	/// If true, the original texture extension (when available) will be preferred over the selected <see cref="ImageExportFormat"/>.
	/// </summary>
	public bool PreferOriginalTextureExtension { get; set; } = true;

	public bool SaveSettingsToDisk { get; set; }

	/// <summary>
	/// Pre-fills the export path box, so a path used for every rip is typed once rather than every time.
	/// Empty leaves the box empty, as before.
	/// </summary>
	public string? DefaultExportPath { get; set; }

	/// <summary>
	/// Where to write the log file. Empty writes a timestamped file next to the executable, as before.
	/// </summary>
	/// <remarks>
	/// A fixed path makes the log easy to find and attach, which a timestamped name in the install
	/// directory is not. The <c>--log-path</c> command line argument still wins over this.
	/// </remarks>
	public string? LogPath { get; set; }

	public string? LanguageCode { get; set; }

	/// <summary>
	/// Where the official Unity packages live, usually a project's Library/PackageCache. When set, an
	/// export repoints its references at those packages instead of at the ripped copies of them.
	/// </summary>
	/// <remarks>
	/// Empty by default, because the guids it needs are not part of the game being ripped and there is
	/// nothing sensible to guess.
	/// </remarks>
	public string? OfficialPackageCachePath { get; set; }

	public void Log()
	{
		Logger.Info(LogCategory.General, $"{nameof(AudioExportFormat)}: {AudioExportFormat}");
		Logger.Info(LogCategory.General, $"{nameof(ImageExportFormat)}: {ImageExportFormat}");
		Logger.Info(LogCategory.General, $"{nameof(LightmapTextureExportFormat)}: {LightmapTextureExportFormat}");
		Logger.Info(LogCategory.General, $"{nameof(ScriptExportMode)}: {ScriptExportMode}");
		Logger.Info(LogCategory.General, $"{nameof(ScriptLanguageVersion)}: {ScriptLanguageVersion}");
		Logger.Info(LogCategory.General, $"{nameof(ShaderExportMode)}: {ShaderExportMode}");
		Logger.Info(LogCategory.General, $"{nameof(SpriteExportMode)}: {SpriteExportMode}");
		Logger.Info(LogCategory.General, $"{nameof(TextExportMode)}: {TextExportMode}");
		Logger.Info(LogCategory.General, $"{nameof(ExportUnreadableAssets)}: {ExportUnreadableAssets}");
		Logger.Info(LogCategory.General, $"{nameof(PreferOriginalTextureExtension)}: {PreferOriginalTextureExtension}");
		if (!string.IsNullOrWhiteSpace(DefaultExportPath))
		{
			Logger.Info(LogCategory.General, $"{nameof(DefaultExportPath)}: {DefaultExportPath}");
		}
		if (!string.IsNullOrWhiteSpace(LogPath))
		{
			Logger.Info(LogCategory.General, $"{nameof(LogPath)}: {LogPath}");
		}
		if (!string.IsNullOrWhiteSpace(OfficialPackageCachePath))
		{
			Logger.Info(LogCategory.General, $"{nameof(OfficialPackageCachePath)}: {OfficialPackageCachePath}");
		}
	}
}
