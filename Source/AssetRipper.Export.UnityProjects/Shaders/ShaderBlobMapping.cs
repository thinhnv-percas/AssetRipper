using System.Text;
using AssetRipper.SourceGenerated.Classes.ClassID_48;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: which blob entry every sub-program of every pass owns, and what each of them is.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 058 read the entry table at the head of a decompressed platform blob and found it
/// interleaved: some entries are GLSL source, some are small binary blocks, some are empty. The
/// serialized asset says which is which and nothing had read it. A sub-program owns <em>two</em>
/// entries - <c>BlobIndex</c> for its compiled code and <c>m_ParameterBlobIndices[tier][k]</c> for
/// its parameter block - so the interleaving is not a puzzle about the table, it is two tables of
/// indices into one store.
/// </para>
/// <para>
/// This writes the mapping out with the evidence beside it: the byte range each index resolves to and
/// what the bytes were read as. A claim about the table can then be checked against the asset rather
/// than against how plausible a decode looks.
/// </para>
/// </remarks>
public static class ShaderBlobMapping
{
	public sealed record Row(
		string Shader,
		int SubShader,
		int Pass,
		string PassName,
		string Stage,
		int Variant,
		string Backend,
		IReadOnlyList<string>? Keywords,
		int BlobIndex,
		int ParameterBlobIndex,
		string ProgramEncoding,
		int ProgramOffset,
		int ProgramSize,
		string ParameterEncoding,
		int ParameterOffset,
		int ParameterSize);

	public static List<Row> Read(IShader shader)
	{
		List<Row> rows = [];

		if (ShaderSemanticModel.Read(shader) is not { } model)
		{
			return rows;
		}

		var evidence = ShaderProgramProbe.Probe(shader);

		for (int subShader = 0; subShader < model.SubShaders.Count; subShader++)
		{
			var passes = model.SubShaders[subShader].Passes;

			for (int pass = 0; pass < passes.Count; pass++)
			{
				foreach (var program in passes[pass].Programs)
				{
					for (int variant = 0; variant < program.BlobIndices.Count; variant++)
					{
						string backend = variant < program.Backends.Count ? program.Backends[variant] : "?";
						int parameterBlob = variant < program.ParameterBlobIndices.Count
							? program.ParameterBlobIndices[variant]
							: -1;

						var code = Find(evidence, backend, program.BlobIndices[variant]);
						var parameters = parameterBlob < 0 ? null : Find(evidence, backend, parameterBlob);

						rows.Add(new Row(
							evidence.Shader,
							subShader,
							pass,
							passes[pass].Name,
							program.Stage,
							variant,
							backend,
							!program.KeywordsKnown ? null : variant < program.KeywordSets.Count ? program.KeywordSets[variant] : [],
							program.BlobIndices[variant],
							parameterBlob,
							code?.Encoding.ToString().ToUpperInvariant() ?? "NOT_IN_TABLE",
							code?.Offset ?? -1,
							code?.Length ?? -1,
							parameters?.Encoding.ToString().ToUpperInvariant() ?? (parameterBlob < 0 ? "NOT_RECORDED" : "NOT_IN_TABLE"),
							parameters?.Offset ?? -1,
							parameters?.Length ?? -1));
					}
				}
			}
		}

		return rows;
	}

	private static ShaderProgramProbe.SubProgramEvidence? Find(
		ShaderProgramProbe.ShaderEvidence evidence, string gpuProgramType, int blobIndex)
	{
		string? wanted = ShaderProgramProbe.PlatformNameOf(gpuProgramType);

		if (wanted is null)
		{
			return null;
		}

		foreach (var program in evidence.SubPrograms)
		{
			if (program.Index == blobIndex && string.Equals(program.Backend, wanted, StringComparison.Ordinal))
			{
				return program;
			}
		}

		return null;
	}

	public static string ToJson(IReadOnlyList<Row> rows)
	{
		StringBuilder builder = new();
		builder.Append("[\n");

		for (int index = 0; index < rows.Count; index++)
		{
			if (index > 0)
			{
				builder.Append(",\n");
			}

			var row = rows[index];
			builder.Append("  {");
			builder.Append("\"shader\": ").Append(Quote(row.Shader));
			builder.Append(", \"subShader\": ").Append(row.SubShader);
			builder.Append(", \"pass\": ").Append(row.Pass);
			builder.Append(", \"passName\": ").Append(Quote(row.PassName));
			builder.Append(", \"stage\": ").Append(Quote(row.Stage));
			builder.Append(", \"variant\": ").Append(row.Variant);
			builder.Append(", \"backend\": ").Append(Quote(row.Backend));
			if (row.Keywords is null)
			{
				// Not recorded by this version: null, which a reader cannot mistake for "no keywords".
				builder.Append(", \"keywords\": null");
			}
			else
			{
				builder.Append(", \"keywords\": [");

				for (int keyword = 0; keyword < row.Keywords.Count; keyword++)
				{
					if (keyword > 0)
					{
						builder.Append(", ");
					}

					builder.Append(Quote(row.Keywords[keyword]));
				}

				builder.Append(']');
			}
			builder.Append(", \"blobIndex\": ").Append(row.BlobIndex);
			builder.Append(", \"parameterBlobIndex\": ").Append(row.ParameterBlobIndex);
			builder.Append(", \"programEncoding\": ").Append(Quote(row.ProgramEncoding));
			builder.Append(", \"programOffset\": ").Append(row.ProgramOffset);
			builder.Append(", \"programSize\": ").Append(row.ProgramSize);
			builder.Append(", \"parameterEncoding\": ").Append(Quote(row.ParameterEncoding));
			builder.Append(", \"parameterOffset\": ").Append(row.ParameterOffset);
			builder.Append(", \"parameterSize\": ").Append(row.ParameterSize);
			builder.Append('}');
		}

		builder.Append("\n]\n");
		return builder.ToString();
	}

	private static string Quote(string value)
	{
		StringBuilder builder = new(value.Length + 2);
		builder.Append('"');

		foreach (char character in value)
		{
			switch (character)
			{
				case '"': builder.Append("\\\""); break;
				case '\\': builder.Append("\\\\"); break;
				case '\n': builder.Append("\\n"); break;
				case '\r': builder.Append("\\r"); break;
				case '\t': builder.Append("\\t"); break;
				default:
					if (character < 0x20 || character > 0x7E)
					{
						builder.Append("\\u").Append(((int)character).ToString("x4"));
					}
					else
					{
						builder.Append(character);
					}
					break;
			}
		}

		builder.Append('"');
		return builder.ToString();
	}
}
