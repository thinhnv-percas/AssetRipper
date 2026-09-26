using AssetRipper.Assets;
using AssetRipper.Export.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Processing;
using AssetRipper.SourceGenerated.Classes.ClassID_48;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: reads every shader's compiled program blobs and writes what they were found to be.
/// </summary>
/// <remarks>
/// The exported ShaderLab carries a replacement for each program stage and says so. What the real
/// program is has never been established in this project - "GLES means GLSL source" was recorded as
/// explicitly unconfirmed - so this opens the blobs and reports evidence. The report is written
/// whether or not anything was recognised: a shader whose blobs did not decompress is a fact about
/// the input, not a gap in the output.
/// </remarks>
public sealed class ShaderProgramPostExporter : IPostExporter
{
	private const string FileName = "ShaderPrograms.json";

	public void DoPostExport(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		List<ShaderProgramProbe.ShaderEvidence> evidence = [];

		foreach (IUnityObjectBase asset in gameData.GameBundle.FetchAssets())
		{
			if (asset is IShader shader)
				evidence.Add(ShaderProgramProbe.Probe(shader));
		}

		if (evidence.Count == 0)
			return;

		fileSystem.Directory.Create(settings.AuxiliaryFilesPath);
		string path = fileSystem.Path.Join(settings.AuxiliaryFilesPath, FileName);
		fileSystem.File.WriteAllText(path, ShaderProgramExtractor.ToJson(evidence));

		WriteRecoveredPrograms(gameData, evidence, settings, fileSystem);

		int programs = 0;
		int source = 0;
		int binary = 0;
		int unknown = 0;

		foreach (var shader in evidence)
		{
			foreach (var program in shader.SubPrograms)
			{
				programs++;

				switch (program.Encoding)
				{
					case ShaderProgramProbe.ProgramEncoding.SourceText: source++; break;
					case ShaderProgramProbe.ProgramEncoding.Binary: binary++; break;
					default: unknown++; break;
				}
			}
		}

		Logger.Info(LogCategory.Export,
			$"Shader programs: {programs} sub-programs across {evidence.Count} shaders - " +
			$"{source} shading-language source, {binary} binary, {unknown} not established. " +
			$"Written to AuxiliaryFiles/{FileName}.");
	}

	/// <summary>
	/// Writes each recovered sub-program's source beside the report.
	/// </summary>
	/// <remarks>
	/// One shader at a time, fetching the bytes and letting them go again: holding every program of
	/// a game alive at once exhausted the container on the first fixture this was run against.
	/// </remarks>
	private static void WriteRecoveredPrograms(
		GameData gameData,
		List<ShaderProgramProbe.ShaderEvidence> evidence,
		FullConfiguration settings,
		FileSystem fileSystem)
	{
		Dictionary<string, ShaderProgramProbe.ShaderEvidence> byName = [];

		foreach (var shader in evidence)
			byName[shader.Shader] = shader;

		string directory = fileSystem.Path.Join(settings.AuxiliaryFilesPath, "ShaderPrograms");
		bool created = false;

		// A budget rather than everything: one post-processing shader alone carries several thousand
		// keyword variants, and a game's full set runs to gigabytes of near-identical text. The report
		// still records where every program is and what it was read as, so nothing analytical is lost
		// by not writing them all out - and a rip that fills the disk is worse than one that says how
		// many programs it did not write.
		const long Budget = 128L * 1024 * 1024;
		long written = 0;
		int omitted = 0;

		foreach (IUnityObjectBase asset in gameData.GameBundle.FetchAssets())
		{
			if (asset is not IShader shader || !shader.Has_ParsedForm())
				continue;

			if (!byName.TryGetValue(shader.ParsedForm.Name.String, out var probed))
				continue;

			foreach (var program in probed.SubPrograms)
			{
				if (program.Encoding != ShaderProgramProbe.ProgramEncoding.SourceText)
					continue;

				if (ShaderProgramProbe.TextOf(shader, program) is not { Length: > 0 } text)
					continue;

				if (!created)
				{
					fileSystem.Directory.Create(directory);
					created = true;
				}

				if (written + text.Length > Budget)
				{
					omitted++;
					continue;
				}

				string name = ShaderProgramExtractor.PayloadFileName(probed.Shader, program);
				fileSystem.File.WriteAllText(fileSystem.Path.Join(settings.AuxiliaryFilesPath, name), text);
				written += text.Length;
			}
		}

		if (omitted > 0)
		{
			Logger.Info(LogCategory.Export,
				$"Shader programs: {omitted} recovered programs were not written out, the {Budget / (1024 * 1024)} MB " +
				"budget for extracted source having been reached. Their position and encoding are in the report.");
		}
	}
}
