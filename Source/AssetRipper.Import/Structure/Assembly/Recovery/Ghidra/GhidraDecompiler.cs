using AssetRipper.Import.Logging;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Drives a headless Ghidra run over the game's native binary, using Il2Cpp metadata to name every
/// function first.
/// </summary>
/// <remarks>
/// Cpp2IL lifts machine code back to CIL, which yields real C# but only for a fraction of methods.
/// Ghidra instead decompiles to pseudo C, which is not C# but covers nearly every function and has
/// mature support for the architectures that Cpp2IL handles worst. The two are complementary.
/// </remarks>
public static class GhidraDecompiler
{
	private const string ScriptFileName = $"{GhidraHeadlessRunner.ScriptName}.java";

	/// <summary>
	/// Analyzes a binary and writes the decompiled output into <paramref name="outputDirectory"/>.
	/// </summary>
	/// <param name="context">The analysis context supplying the symbol names.</param>
	/// <param name="binaryPath">The game binary, such as GameAssembly.dll or libil2cpp.so.</param>
	/// <param name="outputDirectory">The directory to write the decompiled output into.</param>
	/// <returns>True if Ghidra ran to completion.</returns>
	public static bool TryDecompile(ApplicationAnalysisContext context, string binaryPath, string outputDirectory)
	{
		if (!GhidraInstallation.TryLocate(out GhidraInstallation? installation))
		{
			Logger.Warning(LogCategory.Import,
				$"Script content level 4 needs Ghidra, but no installation was found. Set the {GhidraInstallation.EnvironmentVariable} environment variable to a Ghidra installation directory.");
			return false;
		}

		if (!File.Exists(binaryPath))
		{
			Logger.Warning(LogCategory.Import, $"Cannot run Ghidra because the game binary was not found: {binaryPath}");
			return false;
		}

		Logger.Info(LogCategory.Import, $"Using Ghidra at {installation.Directory}");

		string workingDirectory = Path.Join(Path.GetTempPath(), $"AssetRipper_Ghidra_{Guid.NewGuid():N}");
		try
		{
			string scriptDirectory = Path.Join(workingDirectory, "scripts");
			string projectDirectory = Path.Join(workingDirectory, "project");
			Directory.CreateDirectory(scriptDirectory);
			Directory.CreateDirectory(projectDirectory);
			Directory.CreateDirectory(outputDirectory);

			if (!TryExtractScript(scriptDirectory))
			{
				return false;
			}

			string symbolFilePath = Path.Join(workingDirectory, "symbols.tsv");
			List<Il2CppSymbolTable.Entry> entries = Il2CppSymbolTable.Collect(context);
			using (StreamWriter writer = new(symbolFilePath))
			{
				Il2CppSymbolTable.Write(entries, writer);
			}
			Logger.Info(LogCategory.Import, $"Wrote {entries.Count} Il2Cpp symbols for Ghidra.");

			List<string> arguments = GhidraHeadlessRunner.BuildArguments(
				projectDirectory,
				"AssetRipper",
				binaryPath,
				scriptDirectory,
				symbolFilePath,
				outputDirectory);

			Logger.Info(LogCategory.Import, "Running Ghidra. Analyzing a full game binary usually takes an hour or more.");
			GhidraRunResult result = GhidraHeadlessRunner.Run(installation, arguments);

			if (result.Succeeded)
			{
				Logger.Info(LogCategory.Import,
					$"Ghidra decompiled {result.DecompiledCount} methods, {result.FailedCount} failed. Output written to {outputDirectory}");

				// Picked up during export to attach the recovered logic to each method.
				GhidraDecompilationIndex.Current = GhidraDecompilationIndex.TryReadFrom(outputDirectory);
				if (GhidraDecompilationIndex.Current is null)
				{
					Logger.Warning(LogCategory.Import, "Ghidra produced no decompilation index, so the output will not be attached to the exported scripts.");
				}
			}
			else
			{
				Logger.Error(LogCategory.Import, "Ghidra did not complete successfully.");
			}

			return result.Succeeded;
		}
		catch (Exception ex)
		{
			Logger.Error(LogCategory.Import, "Ghidra decompilation failed.", ex);
			return false;
		}
		finally
		{
			TryDeleteDirectory(workingDirectory);
		}
	}

	/// <summary>
	/// Writes the bundled Ghidra script into a directory that the analyzer can load it from.
	/// </summary>
	private static bool TryExtractScript(string scriptDirectory)
	{
		System.Reflection.Assembly assembly = typeof(GhidraDecompiler).Assembly;
		string? resourceName = Array.Find(assembly.GetManifestResourceNames(), static name => name.EndsWith(ScriptFileName, StringComparison.Ordinal));

		if (resourceName is null)
		{
			Logger.Error(LogCategory.Import, $"The bundled Ghidra script {ScriptFileName} is missing from this build.");
			return false;
		}

		using Stream? stream = assembly.GetManifestResourceStream(resourceName);
		if (stream is null)
		{
			Logger.Error(LogCategory.Import, $"Could not read the bundled Ghidra script {resourceName}.");
			return false;
		}

		using FileStream file = File.Create(Path.Join(scriptDirectory, ScriptFileName));
		stream.CopyTo(file);
		return true;
	}

	private static void TryDeleteDirectory(string directory)
	{
		try
		{
			if (Directory.Exists(directory))
			{
				Directory.Delete(directory, true);
			}
		}
		catch (IOException)
		{
			// Scratch data, not worth failing the import over.
		}
	}
}
