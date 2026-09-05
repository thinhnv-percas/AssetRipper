namespace AssetRipper.Il2CppRestore.Cli;

/// <summary>
/// Deliberately hand-rolled rather than pulling in a CLI argument library: this tool has five options
/// total, and every dependency here is one more thing this sandbox could not verify resolves against
/// the repo's private NuGet feed.
/// </summary>
public sealed class Options
{
	public required string MetadataPath { get; init; }
	public string? BinaryPath { get; init; }
	public string? StructDbDirectory { get; init; }
	public required string OutputPath { get; init; }
	public string? UnityVersion { get; init; }

	public static Options? Parse(string[] args)
	{
		string? metadataPath = null;
		string? binaryPath = null;
		string? structDbDirectory = null;
		string? outputPath = null;
		string? unityVersion = null;

		for (int i = 0; i < args.Length; i++)
		{
			switch (args[i])
			{
				case "--metadata" when i + 1 < args.Length:
					metadataPath = args[++i];
					break;
				case "--binary" when i + 1 < args.Length:
					binaryPath = args[++i];
					break;
				case "--structdb" when i + 1 < args.Length:
					structDbDirectory = args[++i];
					break;
				case "--out" when i + 1 < args.Length:
					outputPath = args[++i];
					break;
				case "--unity-version" when i + 1 < args.Length:
					unityVersion = args[++i];
					break;
				case "--help" or "-h":
					return null;
			}
		}

		if (metadataPath is null || outputPath is null)
		{
			return null;
		}

		return new Options
		{
			MetadataPath = metadataPath,
			BinaryPath = binaryPath,
			StructDbDirectory = structDbDirectory,
			OutputPath = outputPath,
			UnityVersion = unityVersion,
		};
	}

	public static void PrintUsage()
	{
		Console.WriteLine("""
			AssetRipper.Il2CppRestore.Cli

			Required:
			  --metadata <path>       Path to global-metadata.dat
			  --out <path>            Output directory (dummy .dlls, or an Assets/ folder when --binary is given)

			Optional:
			  --binary <path>         libil2cpp.so / GameAssembly.dll / libil2cpp.dylib. Omit to run "fields only" mode.
			  --structdb <dir>        Directory of struct DB json files (see StructDbGenerator). Improves field
			                          name resolution inside lifted method bodies; not required to run.
			  --unity-version <ver>   e.g. 2022.3.62f2 — used to pick the nearest struct DB and stamp output comments.
			""");
	}
}
