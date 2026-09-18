using AssetRipper.SourceGenerated.Classes.ClassID_48;
using AssetRipper.SourceGenerated.Extensions;
using AssetRipper.SourceGenerated.Extensions.Enums.Shader;
using AssetRipper.SourceGenerated.Extensions.Enums.Shader.GpuProgramType;
using AssetRipper.SourceGenerated.Extensions.Enums.Shader.SerializedShader;
using System.Text;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: what a serialized shader asset actually carries, separated from what an exporter
/// chooses to write out.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="DummyShaderTextExporter"/> reconstructs the <c>Properties</c> block exactly and then
/// gives <em>every</em> shader the same replacement unlit pass. That compiles, so no material is
/// pink, so any check looking for pink materials reports success while the shading is wrong - and
/// the whole of the real structure is discarded on the way: how many subshaders there are, their
/// LOD and tags, how many passes each has, each pass's name, type and render state, which keywords
/// each program variant is compiled for, and which backend its program was compiled to.
/// </para>
/// <para>
/// None of that needs a decompiler. It is in the asset, and throwing it away is why an exported
/// shader could only ever be <c>DUMMY</c>: a reader cannot tell a one-pass unlit shader from a
/// four-pass lit one with a shadow caster. This reads it, so an exporter can write the structure it
/// really had and a measurement can say how much of a shader came back rather than only whether its
/// properties did.
/// </para>
/// <para>
/// It reads and does not decide: what to do about the program bodies is the exporter's business, and
/// the model reports the backends the programs were compiled to so that decision can be made on
/// evidence rather than on an assumption about HLSL.
/// </para>
/// </remarks>
public sealed class ShaderSemanticModel
{
	public required string Name { get; init; }
	public required string FallbackName { get; init; }
	public required string CustomEditorName { get; init; }
	public required IReadOnlyList<ShaderPropertyModel> Properties { get; init; }
	public required IReadOnlyList<SubShaderModel> SubShaders { get; init; }
	public required IReadOnlyList<string> Keywords { get; init; }

	/// <summary>How many programs there are, by the backend each was compiled to.</summary>
	public required IReadOnlyDictionary<string, int> ProgramsByBackend { get; init; }

	public int PassCount => SubShaders.Sum(subShader => subShader.Passes.Count);

	public sealed class ShaderPropertyModel
	{
		public required string Name { get; init; }
		public required string Description { get; init; }
		public required string Type { get; init; }
		public required IReadOnlyList<string> Attributes { get; init; }
	}

	public sealed class SubShaderModel
	{
		public required int Lod { get; init; }
		public required IReadOnlyDictionary<string, string> Tags { get; init; }
		public required IReadOnlyList<PassModel> Passes { get; init; }
	}

	public sealed class PassModel
	{
		public required string Name { get; init; }
		public required string Type { get; init; }
		public required string UseName { get; init; }
		public required IReadOnlyDictionary<string, string> Tags { get; init; }
		public required RenderStateModel State { get; init; }
		public required IReadOnlyList<ProgramModel> Programs { get; init; }
	}

	public sealed class RenderStateModel
	{
		public required string ZTest { get; init; }
		public required string ZWrite { get; init; }
		public required string Cull { get; init; }
		public required string Lighting { get; init; }
		public required bool AlphaToMask { get; init; }
		public required bool StencilIsDefault { get; init; }
	}

	public sealed class ProgramModel
	{
		public required string Stage { get; init; }
		public required int VariantCount { get; init; }

		/// <summary>The backends the variants were compiled to, e.g. <c>GLES3</c>.</summary>
		public required IReadOnlyList<string> Backends { get; init; }

		/// <summary>The keyword sets the variants are compiled for, one entry per variant.</summary>
		public required IReadOnlyList<IReadOnlyList<string>> KeywordSets { get; init; }
	}

	public static ShaderSemanticModel? Read(IShader shader)
	{
		if (!shader.Has_ParsedForm())
		{
			return null;
		}

		var form = shader.ParsedForm;
		List<string> keywords = [.. form.KeywordNames.Select(keyword => keyword.String)];
		Dictionary<string, int> backends = [];

		List<SubShaderModel> subShaders = [];

		foreach (var subShader in form.SubShaders)
		{
			List<PassModel> passes = [];

			foreach (var pass in subShader.Passes)
			{
				List<ProgramModel> programs = [];

				foreach (var (program, stage) in pass.GetProgramsWithType())
				{
					List<string> programBackends = [];
					List<IReadOnlyList<string>> keywordSets = [];

					foreach (var subProgram in program.SubPrograms)
					{
						string backend = ((ShaderGpuProgramType55)subProgram.GpuProgramType).ToString();
						programBackends.Add(backend);
						backends[backend] = backends.GetValueOrDefault(backend) + 1;

						keywordSets.Add([.. subProgram.KeywordIndices
							.Where(index => index < keywords.Count)
							.Select(index => keywords[index])]);
					}

					programs.Add(new ProgramModel
					{
						Stage = stage.ToString(),
						VariantCount = program.SubPrograms.Count,
						Backends = programBackends,
						KeywordSets = keywordSets,
					});
				}

				var state = pass.State;

				passes.Add(new PassModel
				{
					Name = state.Name.String,
					Type = pass.GetType_().ToString(),
					UseName = pass.UseName.String,
					Tags = TagsOf(state.Tags),
					State = new RenderStateModel
					{
						ZTest = state.ZTestValue.ToString(),
						ZWrite = state.ZWriteValue.ToString(),
						Cull = state.CullingValue.ToString(),
						Lighting = state.LightingValue,
						AlphaToMask = state.AlphaToMaskValue,
						StencilIsDefault = state.StencilIsDefault,
					},
					Programs = programs,
				});
			}

			subShaders.Add(new SubShaderModel
			{
				Lod = subShader.LOD,
				Tags = TagsOf(subShader.Tags),
				Passes = passes,
			});
		}

		return new ShaderSemanticModel
		{
			Name = form.Name.String,
			FallbackName = form.FallbackName.String,
			CustomEditorName = form.CustomEditorName.String,
			Properties = [.. form.PropInfo.Props.Select(property => new ShaderPropertyModel
			{
				Name = property.Name.String,
				Description = property.Description.String,
				Type = ((SerializedPropertyType)property.Type).ToString(),
				Attributes = [.. property.Attributes.Select(attribute => attribute.String)],
			})],
			SubShaders = subShaders,
			Keywords = keywords,
			ProgramsByBackend = backends,
		};
	}

	private static Dictionary<string, string> TagsOf(AssetRipper.SourceGenerated.Subclasses.SerializedTagMap.ISerializedTagMap tags)
	{
		Dictionary<string, string> found = [];

		foreach (var tag in tags.Tags)
		{
			found[tag.Key.String] = tag.Value.String;
		}

		return found;
	}

	/// <summary>The model as JSON, for the measurement that reads it back.</summary>
	public string ToJson()
	{
		StringBuilder builder = new();
		builder.Append("{\n");
		builder.Append("  \"name\": ").Append(Quote(Name)).Append(",\n");
		builder.Append("  \"fallback\": ").Append(Quote(FallbackName)).Append(",\n");
		builder.Append("  \"customEditor\": ").Append(Quote(CustomEditorName)).Append(",\n");
		builder.Append("  \"keywords\": ").Append(Strings(Keywords)).Append(",\n");
		builder.Append("  \"programsByBackend\": {");

		var firstBackend = true;
		foreach (var (backend, count) in ProgramsByBackend.OrderBy(entry => entry.Key, StringComparer.Ordinal))
		{
			if (!firstBackend)
			{
				builder.Append(", ");
			}

			firstBackend = false;
			builder.Append(Quote(backend)).Append(": ").Append(count);
		}

		builder.Append("},\n  \"properties\": [");

		for (var index = 0; index < Properties.Count; index++)
		{
			if (index > 0)
			{
				builder.Append(", ");
			}

			var property = Properties[index];
			builder.Append("{\"name\": ").Append(Quote(property.Name))
				.Append(", \"type\": ").Append(Quote(property.Type))
				.Append(", \"attributes\": ").Append(Strings(property.Attributes)).Append('}');
		}

		builder.Append("],\n  \"subShaders\": [");

		for (var subShaderIndex = 0; subShaderIndex < SubShaders.Count; subShaderIndex++)
		{
			if (subShaderIndex > 0)
			{
				builder.Append(", ");
			}

			var subShader = SubShaders[subShaderIndex];
			builder.Append("{\"lod\": ").Append(subShader.Lod)
				.Append(", \"tags\": ").Append(Map(subShader.Tags))
				.Append(", \"passes\": [");

			for (var passIndex = 0; passIndex < subShader.Passes.Count; passIndex++)
			{
				if (passIndex > 0)
				{
					builder.Append(", ");
				}

				var pass = subShader.Passes[passIndex];
				builder.Append("{\"name\": ").Append(Quote(pass.Name))
					.Append(", \"type\": ").Append(Quote(pass.Type))
					.Append(", \"use\": ").Append(Quote(pass.UseName))
					.Append(", \"tags\": ").Append(Map(pass.Tags))
					.Append(", \"zTest\": ").Append(Quote(pass.State.ZTest))
					.Append(", \"zWrite\": ").Append(Quote(pass.State.ZWrite))
					.Append(", \"cull\": ").Append(Quote(pass.State.Cull))
					.Append(", \"lighting\": ").Append(Quote(pass.State.Lighting))
					.Append(", \"programs\": [");

				for (var programIndex = 0; programIndex < pass.Programs.Count; programIndex++)
				{
					if (programIndex > 0)
					{
						builder.Append(", ");
					}

					var program = pass.Programs[programIndex];
					builder.Append("{\"stage\": ").Append(Quote(program.Stage))
						.Append(", \"variants\": ").Append(program.VariantCount)
						.Append(", \"backends\": ").Append(Strings(program.Backends)).Append('}');
				}

				builder.Append("]}");
			}

			builder.Append("]}");
		}

		builder.Append("]\n}\n");
		return builder.ToString();
	}

	private static string Map(IReadOnlyDictionary<string, string> entries)
	{
		StringBuilder builder = new("{");
		var first = true;

		foreach (var (key, value) in entries.OrderBy(entry => entry.Key, StringComparer.Ordinal))
		{
			if (!first)
			{
				builder.Append(", ");
			}

			first = false;
			builder.Append(Quote(key)).Append(": ").Append(Quote(value));
		}

		return builder.Append('}').ToString();
	}

	private static string Strings(IReadOnlyList<string> values)
	{
		StringBuilder builder = new("[");

		for (var index = 0; index < values.Count; index++)
		{
			if (index > 0)
			{
				builder.Append(", ");
			}

			builder.Append(Quote(values[index]));
		}

		return builder.Append(']').ToString();
	}

	private static string Quote(string value)
	{
		StringBuilder builder = new(value.Length + 2);
		builder.Append('"');

		foreach (var character in value)
		{
			switch (character)
			{
				case '"': builder.Append("\\\""); break;
				case '\\': builder.Append("\\\\"); break;
				case '\n': builder.Append("\\n"); break;
				case '\r': builder.Append("\\r"); break;
				case '\t': builder.Append("\\t"); break;
				default:
					if (character < 0x20)
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

		return builder.Append('"').ToString();
	}
}
