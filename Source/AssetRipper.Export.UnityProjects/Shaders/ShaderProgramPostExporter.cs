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
		WriteBlobMapping(gameData, settings, fileSystem);
		WriteVariantPrograms(gameData, settings, fileSystem);

		int programs = 0;
		int source = 0;
		int binary = 0;
		int metal = 0;
		int metalSource = 0;
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
					case ShaderProgramProbe.ProgramEncoding.MetalLibrary: metal++; break;
					case ShaderProgramProbe.ProgramEncoding.MetalSourceText: metalSource++; break;
					default: unknown++; break;
				}
			}
		}

		Logger.Info(LogCategory.Export,
			$"Shader programs: {programs} sub-programs across {evidence.Count} shaders - " +
			$"{source} shading-language source, {metalSource} Metal Shading Language source, {binary} binary, {metal} Metal library, " +
			$"{unknown} not established. " +
			$"Written to AuxiliaryFiles/{FileName}.");
	}

	/// <summary>
	/// Writes each recovered sub-program's source beside the report.
	/// </summary>
	/// <remarks>
	/// One shader at a time, fetching the bytes and letting them go again: holding every program of
	/// a game alive at once exhausted the container on the first fixture this was run against.
	/// </remarks>
	/// <summary>
	/// Writes every recovered variant, deduplicated by the bytes rather than by the keyword set.
	/// </summary>
	/// <remarks>
	/// A pass is compiled once per keyword set, and ShaderLab can carry one program per pass - so the
	/// exported pass holds one and this holds all of them, named by what they were compiled for. Two
	/// variants that compiled to the same program share one file: dropping the duplicates by identity
	/// keeps the set honest about how many distinct programs there are, where dropping them by
	/// keyword set would lose which keywords reach which program.
	/// </remarks>
	private static void WriteVariantPrograms(
		GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		string directory = fileSystem.Path.Join(settings.AuxiliaryFilesPath, "ShaderVariants");
		Dictionary<string, string> byContent = [];
		List<string> manifest = [];
		bool created = false;
		int written = 0;
		int shared = 0;
		long budget = 0;
		int omitted = 0;

		foreach (IUnityObjectBase asset in gameData.GameBundle.FetchAssets())
		{
			if (asset is not IShader shader)
			{
				continue;
			}

			var evidence = ShaderProgramProbe.Probe(shader);

			foreach (var row in ShaderBlobMapping.Read(shader))
			{
				if (row.ProgramEncoding is not ("SOURCETEXT" or "METALSOURCETEXT"))
				{
					continue;
				}

				var program = FindEntry(evidence, row);

				if (program is null || ShaderProgramProbe.TextOf(shader, program) is not { Length: > 0 } text)
				{
					continue;
				}

				// Identity is the program's content, by a hash that is the same in every process:
				// string.GetHashCode is randomised per run and 32 bits wide, so it neither names a
				// program across two rips nor rules out two programs sharing a file.
				string key = ShaderVariantGuards.ContentHash(text);
				string keywords = row.Keywords is null ? "_unknown" : row.Keywords.Count == 0 ? "_base" : string.Join('+', row.Keywords);

				if (byContent.TryGetValue(key, out string? existing))
				{
					shared++;
					manifest.Add(Row(row, keywords, existing, program, key));
					continue;
				}

				if (budget + text.Length > 128L * 1024 * 1024)
				{
					omitted++;
					continue;
				}

				if (!created)
				{
					fileSystem.Directory.Create(directory);
					created = true;
				}

				string extension = row.ProgramEncoding == "METALSOURCETEXT" ? "metal" : "glsl";
				string name = $"ShaderVariants/{Sanitise(row.Shader)}_{row.SubShader}_{row.Pass}_{row.Stage}_{row.Backend}_{row.BlobIndex}.{extension}";
				fileSystem.File.WriteAllText(fileSystem.Path.Join(settings.AuxiliaryFilesPath, name), text);
				byContent[key] = name;
				budget += text.Length;
				written++;
				manifest.Add(Row(row, keywords, name, program, key));
			}
		}

		if (manifest.Count == 0)
		{
			return;
		}

		fileSystem.File.WriteAllText(
			fileSystem.Path.Join(settings.AuxiliaryFilesPath, "ShaderVariants.json"),
			"[\n" + string.Join(",\n", manifest) + "\n]\n");

		Logger.Info(LogCategory.Export,
			$"Shader variants: {manifest.Count} recovered variant programs - {written} distinct, " +
			$"{shared} sharing a program with another variant, {omitted} past the write budget. " +
			"Written to AuxiliaryFiles/ShaderVariants.json.");
	}

	/// <summary>
	/// One variant, with the program's identity as the brief defines it: backend, stage, blob entry,
	/// the byte range inside the decompressed platform blob, and a hash of the content.
	/// </summary>
	private static string Row(ShaderBlobMapping.Row row, string keywords, string file, ShaderProgramProbe.SubProgramEvidence program, string contentHash)
		=> "  {\"shader\": \"" + Escape(row.Shader) + "\", \"subShader\": " + row.SubShader
			+ ", \"pass\": " + row.Pass + ", \"passName\": \"" + Escape(row.PassName)
			+ "\", \"stage\": \"" + row.Stage + "\", \"backend\": \"" + row.Backend
			+ "\", \"variant\": " + row.Variant + ", \"keywords\": \"" + Escape(keywords)
			+ "\", \"blobIndex\": " + row.BlobIndex + ", \"size\": " + row.ProgramSize
			+ ", \"platform\": " + program.Platform + ", \"offset\": " + program.Offset + ", \"length\": " + program.Length
			+ ", \"textOffset\": " + program.TextOffset + ", \"textLength\": " + program.TextLength
			+ ", \"contentHash\": \"" + contentHash + "\""
			+ ", \"file\": \"" + Escape(file) + "\"}";

	private static string Escape(string value)
		=> value.Replace("\\", "\\\\").Replace("\"", "\\\"");

	private static string Sanitise(string value)
	{
		System.Text.StringBuilder builder = new(value.Length);

		foreach (char character in value)
		{
			builder.Append(char.IsLetterOrDigit(character) ? character : '_');
		}

		return builder.ToString();
	}

	private static ShaderProgramProbe.SubProgramEvidence? FindEntry(
		ShaderProgramProbe.ShaderEvidence evidence, ShaderBlobMapping.Row row)
	{
		foreach (var program in evidence.SubPrograms)
		{
			if (program.Index == row.BlobIndex && program.Offset == row.ProgramOffset)
			{
				return program;
			}
		}

		return null;
	}

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
				if (program.Encoding is not (ShaderProgramProbe.ProgramEncoding.SourceText or ShaderProgramProbe.ProgramEncoding.MetalSourceText))
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

	/// <summary>
	/// Writes which blob entry each sub-program owns, program and parameter block alike.
	/// </summary>
	/// <remarks>
	/// The entry table interleaves the two, and the asset says which is which. Written whatever the
	/// outcome: a row whose program index resolves to a binary entry is a fact about the build, and
	/// the only way to tell it apart from a reading mistake is to have both indices beside the bytes.
	/// </remarks>
	private static void WriteBlobMapping(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		List<ShaderBlobMapping.Row> rows = [];

		foreach (IUnityObjectBase asset in gameData.GameBundle.FetchAssets())
		{
			if (asset is IShader shader)
			{
				rows.AddRange(ShaderBlobMapping.Read(shader));
			}
		}

		if (rows.Count == 0)
		{
			return;
		}

		fileSystem.File.WriteAllText(
			fileSystem.Path.Join(settings.AuxiliaryFilesPath, "ShaderBlobMapping.json"),
			ShaderBlobMapping.ToJson(rows));

		int withParameterBlob = 0;
		int programIsSource = 0;
		int parameterIsBinary = 0;

		foreach (var row in rows)
		{
			if (row.ParameterBlobIndex >= 0)
			{
				withParameterBlob++;
			}

			if (row.ProgramEncoding == "SOURCETEXT")
			{
				programIsSource++;
			}

			if (row.ParameterEncoding is "BINARY" or "PRINTABLENOMARKERS")
			{
				parameterIsBinary++;
			}
		}

		Logger.Info(LogCategory.Export,
			$"Shader blob mapping: {rows.Count} sub-program rows, {withParameterBlob} with a parameter " +
			$"blob index recorded, {programIsSource} whose program entry is shading-language source, " +
			$"{parameterIsBinary} whose parameter entry is binary. Written to AuxiliaryFiles/ShaderBlobMapping.json.");
	}
}
