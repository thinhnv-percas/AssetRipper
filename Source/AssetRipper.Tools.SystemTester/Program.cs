using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.IO.Files;
using AssetRipper.Processing;

namespace AssetRipper.Tools.SystemTester;

static class Program
{
	private const string TestsDirectory = "../../Tests";

	static int Main(string[] args)
	{
		if (args.Length == 1 && args[0] is "--help" or "-h")
		{
			WriteUsage();
			return 0;
		}

		if (!RipOptions.TryParse(args, out RipOptions options, out string? error))
		{
			Console.Error.WriteLine(error);
			WriteUsage();
			return 2;
		}

		Logger.Add(new ConsoleLogger(true));
		Logger.Add(new FileLogger(options.LogPath));
		Logger.LogSystemInformation("System Tester");
		Logger.BlankLine();

		if (options.Inputs.Count == 0)
		{
			RunTests();
			return 0;
		}

		Rip(options);
		return 0;
	}

	private static void WriteUsage()
	{
		Console.WriteLine("""
			Usage: AssetRipper.Tools.SystemTester [options] <input>...

			  <input>...              Files or folders to rip. With none, the Tests folder is walked instead.

			  --output <dir>          Where to write the Unity project. Default: <exe directory>/Ripped
			  --log <file>            Where to write the log. Default: AssetRipper.Tools.SystemTester.log
			  --script-level <0-3>    Script content level. 3 recovers IL2Cpp method bodies. Default: 2
			  --reconstruct-bodies    Attach approximate C# to bodies IL recovery cannot express. Slow.
			  --no-emit-offsets       Leave out the field offset and method address attributes.
			  --struct-db <dir>       IL2Cpp struct layout directory. Default: the usual locations.
			  -h, --help              This text.

			The output directory is deleted before the run.
			""");
	}

	/// <summary>
	/// What to rip and how. Exists so a Level 3 IL2Cpp run is one repeatable command rather than a
	/// sequence of clicks, on any operating system.
	/// </summary>
	private sealed class RipOptions
	{
		public List<string> Inputs { get; } = [];
		public string OutputPath { get; set; } = Path.Join(AppContext.BaseDirectory, "Ripped");
		public string LogPath { get; set; } = "AssetRipper.Tools.SystemTester.log";
		public ScriptContentLevel ScriptContentLevel { get; set; } = ScriptContentLevel.Level2;
		public bool ReconstructNativeBodies { get; set; }
		public bool EmitIl2CppOffsets { get; set; } = true;
		public string? StructDbPath { get; set; }

		public static bool TryParse(string[] args, out RipOptions options, out string? error)
		{
			options = new RipOptions();
			error = null;

			for (int i = 0; i < args.Length; i++)
			{
				switch (args[i])
				{
					case "--output" when i + 1 < args.Length:
						options.OutputPath = Path.GetFullPath(args[++i]);
						break;
					case "--log" when i + 1 < args.Length:
						options.LogPath = Path.GetFullPath(args[++i]);
						break;
					case "--script-level" when i + 1 < args.Length:
						string level = args[++i];
						if (!int.TryParse(level, out int number) || number is < 0 or > 3)
						{
							error = $"Script content level must be 0, 1, 2 or 3. Got '{level}'.";
							return false;
						}
						options.ScriptContentLevel = (ScriptContentLevel)number;
						break;
					case "--reconstruct-bodies":
						options.ReconstructNativeBodies = true;
						break;
					case "--no-emit-offsets":
						options.EmitIl2CppOffsets = false;
						break;
					case "--struct-db" when i + 1 < args.Length:
						options.StructDbPath = Path.GetFullPath(args[++i]);
						break;
					default:
						if (args[i].StartsWith('-'))
						{
							error = $"Unknown or incomplete option: {args[i]}";
							return false;
						}
						options.Inputs.Add(args[i]);
						break;
				}
			}

			string? logDirectory = Path.GetDirectoryName(Path.GetFullPath(options.LogPath));
			if (!string.IsNullOrEmpty(logDirectory))
			{
				Directory.CreateDirectory(logDirectory);
			}

			return true;
		}
	}

	static void RunTests()
	{
		if (!Directory.Exists(TestsDirectory))
		{
			Logger.Log(LogType.Warning, LogCategory.General, "Tests folder did not exist. Creating...");
			Directory.CreateDirectory(TestsDirectory);
			Logger.Info(LogCategory.General, "Created. Program will now exit.");
			return;
		}

		Logger.Info(LogCategory.General, $"Running tests in {Path.GetFullPath(TestsDirectory)}");
		Logger.BlankLine();

		int numTests = 0;
		int numSuccessful = 0;
		List<(string, string)> successfulTests = new();
		List<(string, string)> unsuccessfulTests = new();
		foreach (string versionPath in Directory.GetDirectories(TestsDirectory))
		{
			string versionName = Path.GetRelativePath(TestsDirectory, versionPath);
			foreach (string testPath in Directory.GetDirectories(versionPath))
			{
				string testName = Path.GetRelativePath(versionPath, testPath);
				Logger.Info(LogCategory.General, $"Found test: '{testName}' for Unity version: '{versionName}'");
				numTests++;
				string inputPath = Path.Join(testPath, "Input");
				if (!Directory.Exists(inputPath))
				{
					Logger.Log(LogType.Error, LogCategory.General, $"No input folder for '{testName}' on Unity version '{versionName}'");
					unsuccessfulTests.Add((versionName, testName));
				}
				else
				{
					try
					{
						string[] inputFiles = Directory.GetFiles(inputPath);
						string[] inputDirectories = Directory.GetDirectories(inputPath);
						string[] inputPaths = Combine(inputFiles, inputDirectories);
						RipOptions testOptions = new() { OutputPath = Path.Join(testPath, "Output") };
						testOptions.Inputs.AddRange(inputPaths);
						Rip(testOptions);
						Logger.Info(LogCategory.General, $"Completed test: '{testName}' for Unity version: '{versionName}'");
						Logger.BlankLine(2);
						numSuccessful++;
						successfulTests.Add((versionName, testName));
					}
					catch (Exception ex)
					{
						Logger.Log(LogType.Error, LogCategory.General, ex.ToString());
						Logger.BlankLine(2);
						unsuccessfulTests.Add((versionName, testName));
					}
				}
			}
		}

		Logger.Info(LogCategory.General, $"{numSuccessful}/{numTests} tests successfully completed");
		if (numSuccessful > 0)
		{
			Logger.Info(LogCategory.General, "Successful:");
			foreach ((string version, string test) in successfulTests)
			{
				Logger.Info(LogCategory.General, $"\t{version,-12} {test}");
			}
		}
		if (numSuccessful < numTests)
		{
			Logger.Info(LogCategory.General, "Unsuccessful:");
			foreach ((string version, string test) in unsuccessfulTests)
			{
				Logger.Info(LogCategory.General, $"\t{version,-12} {test}");
			}
		}
	}

	private static void Rip(RipOptions options)
	{
		FullConfiguration settings = new();
		settings.ImportSettings.ScriptContentLevel = options.ScriptContentLevel;
		settings.ImportSettings.EmitIl2CppOffsets = options.EmitIl2CppOffsets;
		settings.ImportSettings.ReconstructNativeBodies = options.ReconstructNativeBodies;
		settings.ImportSettings.Il2CppStructDbPath = options.StructDbPath;
		settings.ExportSettings.ScriptExportMode = ScriptExportMode.Decompiled;

		settings.LogConfigurationValues();

		ExportHandler exportHandler = new(settings);
		GameData gameData = exportHandler.LoadAndProcess(options.Inputs, LocalFileSystem.Instance);
		PrepareExportDirectory(options.OutputPath);
		exportHandler.Export(gameData, options.OutputPath, LocalFileSystem.Instance);

		Logger.Info(LogCategory.Export, $"Ripped to {options.OutputPath}");
	}


	private static void PrepareExportDirectory(string path)
	{
		if (Directory.Exists(path))
		{
			Logger.Info(LogCategory.Export, "Clearing export directory...");
			Directory.Delete(path, true);
		}
	}

	private static T[] Combine<T>(T[] array1, T[] array2)
	{
		ArgumentNullException.ThrowIfNull(array1);
		ArgumentNullException.ThrowIfNull(array2);

		T[] result = new T[array1.Length + array2.Length];
		for (int i = 0; i < array1.Length; i++)
		{
			result[i] = array1[i];
		}
		for (int j = 0; j < array2.Length; j++)
		{
			result[j + array1.Length] = array2[j];
		}
		return result;
	}
}
