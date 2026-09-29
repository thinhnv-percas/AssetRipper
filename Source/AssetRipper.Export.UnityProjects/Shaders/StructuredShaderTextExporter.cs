using AssetRipper.Import.Logging;
using AssetRipper.SourceGenerated.Classes.ClassID_48;
using System.Text;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: writes the ShaderLab structure the asset really carries, with a replacement body for
/// the program stages only.
/// </summary>
/// <remarks>
/// <para>
/// The previous export gave <em>every</em> shader one canned unlit pass, whatever it had been. A
/// four-pass lit shader with a shadow caster and a one-pass unlit blit came out identical, and the
/// only honest verdict for such an output is <c>DUMMY</c> - which is what this project has reported
/// for it, and rightly.
/// </para>
/// <para>
/// Everything except the program bodies is in the asset: the subshaders, their LOD and tags, each
/// pass with its name, type, tags and render state, the keyword sets each variant was compiled for,
/// and the backend each program was compiled to. Writing that out is not a decompiler - it is
/// transcription - and it moves an exported shader from "nothing of its structure survived" to
/// "everything but the program text survived", which is a different artefact for a reader and for
/// Unity alike.
/// </para>
/// <para>
/// The program bodies are <em>not</em> reconstructed, and this does not pretend otherwise: each pass
/// carries the same replacement stage as before and a comment naming the backends its real programs
/// were compiled to. <c>shader_exact</c> stays 0, because none of these is exact.
/// </para>
/// </remarks>
public static class StructuredShaderTextExporter
{
	/// <summary>The replacement stage, written once per pass. It is not the shader's own program.</summary>
	private const string ReplacementProgram = """
					CGPROGRAM
					// AssetRipperReplacementProgram: this stage is NOT the shader's own.
					#pragma vertex vert
					#pragma fragment frag
					#include "UnityCG.cginc"
					struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; };
					struct v2f { float4 vertex : SV_POSITION; float2 uv : TEXCOORD0; };
					sampler2D _MainTex;
					v2f vert(appdata v) { v2f o; o.vertex = UnityObjectToClipPos(v.vertex); o.uv = v.uv; return o; }
					fixed4 frag(v2f i) : SV_Target { return tex2D(_MainTex, i.uv); }
					ENDCG
		""";

	/// <summary>
	/// Writes the shader, or returns false when the asset carries no parsed form to write from.
	/// </summary>
	public static bool TryExport(IShader shader, TextWriter writer)
	{
		ShaderSemanticModel? model;

		// AssetRipper: reading the structure is new code over a serialized form that varies by version,
		// and an exception out of it used to end the whole export rather than this one shader. The
		// contract is to fall through to the canned pass when the structure cannot be read, so a
		// failure to read it is exactly that case - reported, not fatal.
		try
		{
			model = ShaderSemanticModel.Read(shader);
		}
		catch (Exception exception)
		{
			Logger.Warning(LogCategory.Export,
				$"Shader structure could not be read for '{(shader.Has_ParsedForm() ? shader.ParsedForm.Name.String : shader.Name.String)}': {exception.Message}");
			return false;
		}

		if (model is null || model.SubShaders.Count == 0)
		{
			return false;
		}

		// Read once per shader: the probe caches, so the report and the exported text describe the
		// same decompression rather than two that could disagree.
		ShaderProgramProbe.ShaderEvidence evidence = ShaderProgramProbe.Probe(shader);

		writer.Write($"Shader \"{model.Name}\" {{\n");
		DummyShaderTextExporter.ExportProperties(shader, writer);
		writer.Write("\t// AssetRipper: the structure below is the shader's own - subshaders, passes, tags\n");
		writer.Write("\t// and render state are read from the asset. The program stages are NOT the\n");
		writer.Write("\t// shader's; each carries a replacement and the backends its real programs were\n");
		writer.Write("\t// compiled to.\n");

		foreach (var subShader in model.SubShaders)
		{
			writer.Write("\tSubShader {\n");
			WriteTags(writer, subShader.Tags, 2);

			if (subShader.Lod != 0)
			{
				writer.Write($"\t\tLOD {subShader.Lod}\n");
			}

			foreach (var pass in subShader.Passes)
			{
				WritePass(writer, shader, pass, evidence);
			}

			writer.Write("\t}\n");
		}

		if (model.FallbackName.Length > 0)
		{
			writer.Write($"\tFallback \"{model.FallbackName}\"\n");
		}

		if (model.CustomEditorName.Length > 0)
		{
			// Commented, as the previous export had it: the editor class is an Editor-only type that
			// no build carries, so naming it for real makes the shader fail to import.
			writer.Write($"\t//CustomEditor \"{model.CustomEditorName}\"\n");
		}

		writer.Write("}");
		return true;
	}

	private static void WritePass(TextWriter writer, IShader shader, ShaderSemanticModel.PassModel pass, ShaderProgramProbe.ShaderEvidence? evidence)
	{
		// A UsePass or GrabPass names another pass rather than carrying one, so writing a body for it
		// would invent a pass the shader does not have.
		if (pass.Type == "Use")
		{
			// A UsePass with no name would not import; the pass it names is simply not recorded.
			if (pass.UseName.Length > 0)
			{
				writer.Write($"\t\tUsePass \"{pass.UseName}\"\n");
			}

			return;
		}

		if (pass.Type == "Grab")
		{
			writer.Write(pass.Name.Length > 0 ? $"\t\tGrabPass {{ \"{pass.Name}\" }}\n" : "\t\tGrabPass { }\n");
			return;
		}

		writer.Write("\t\tPass {\n");

		if (pass.Name.Length > 0)
		{
			writer.Write($"\t\t\tName \"{pass.Name}\"\n");
		}

		WriteTags(writer, pass.Tags, 3);

		// Only what differs from ShaderLab's own default is written, so a reader sees the state the
		// shader set rather than a wall of defaults it did not.
		if (!string.Equals(pass.State.Cull, "Back", StringComparison.Ordinal))
		{
			writer.Write($"\t\t\tCull {pass.State.Cull}\n");
		}

		if (!string.Equals(pass.State.ZWrite, "On", StringComparison.Ordinal))
		{
			writer.Write($"\t\t\tZWrite {pass.State.ZWrite}\n");
		}

		if (!string.Equals(pass.State.ZTest, "LEqual", StringComparison.OrdinalIgnoreCase))
		{
			writer.Write($"\t\t\tZTest {pass.State.ZTest}\n");
		}

		if (pass.State.AlphaToMask)
		{
			writer.Write("\t\t\tAlphaToMask On\n");
		}

		if (pass.State.Blend.Length > 0)
		{
			writer.Write($"\t\t\tBlend {pass.State.Blend}\n");
		}

		if (pass.State.ColorMask.Length > 0)
		{
			writer.Write($"\t\t\tColorMask {pass.State.ColorMask}\n");
		}

		if (pass.State.Offset.Length > 0)
		{
			writer.Write($"\t\t\tOffset {pass.State.Offset}\n");
		}

		if (pass.State.Stencil.Count > 0)
		{
			writer.Write("\t\t\tStencil {\n");

			foreach (string line in pass.State.Stencil)
			{
				writer.Write($"\t\t\t\t{line}\n");
			}

			writer.Write("\t\t\t}\n");
		}

		if (pass.Programs.Count > 0)
		{
			StringBuilder backends = new();

			foreach (var program in pass.Programs)
			{
				if (backends.Length > 0)
				{
					backends.Append(", ");
				}

				backends.Append(program.Stage).Append(' ').Append(program.VariantCount).Append(" variant(s) [")
					.Append(string.Join('/', program.Backends.Distinct())).Append("] blobs ")
					.Append(string.Join(',', program.BlobIndices.Take(8)));
			}

			writer.Write($"\t\t\t// real programs: {backends}\n");
		}

		if (RecoveredProgram(shader, pass, evidence) is { } recovered)
		{
			writer.Write(recovered);
		}
		else
		{
			writer.Write(ReplacementProgram.Replace("\r", ""));
		}

		writer.Write("\n\t\t}\n");
	}

	/// <summary>
	/// The pass's own compiled program, written as ShaderLab can carry it, or null when none of its
	/// variants was read as source.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A GLES sub-program blob is HLSLcc's output and holds <em>both</em> stages of the pass, guarded
	/// by <c>#ifdef VERTEX</c> and <c>#ifdef FRAGMENT</c> - which is exactly the form Unity's
	/// <c>GLSLPROGRAM</c> block expects, so it goes in verbatim rather than being translated. That is
	/// why this is extraction and not decompilation.
	/// </para>
	/// <para>
	/// One variant is written, and the comment says which and how many there were. A pass compiled for
	/// several keyword sets has one program per set and ShaderLab cannot carry them all in one block;
	/// writing the first and saying so is honest, and silently writing one of many as though it were
	/// the pass would not be.
	/// </para>
	/// </remarks>
	private static string? RecoveredProgram(IShader shader, ShaderSemanticModel.PassModel pass, ShaderProgramProbe.ShaderEvidence? evidence)
	{
		if (evidence is null)
		{
			return null;
		}

		foreach (var program in pass.Programs)
		{
			// The base variant first - the one compiled with no keywords is what the pass does before
			// any of them are enabled, and writing whichever happened to be first in the table put a
			// keyword-specific program in the pass instead.
			List<int> order = [];

			for (int variant = 0; variant < program.BlobIndices.Count && variant < program.Backends.Count; variant++)
			{
				if (variant < program.KeywordSets.Count && program.KeywordSets[variant].Count == 0)
				{
					order.Add(variant);
				}
			}

			for (int variant = 0; variant < program.BlobIndices.Count && variant < program.Backends.Count; variant++)
			{
				if (!order.Contains(variant))
				{
					order.Add(variant);
				}
			}

			foreach (int variant in order)
			{
				string? source = ShaderProgramProbe.SourceFor(shader, program.Backends[variant], program.BlobIndices[variant]);

				if (source is not { Length: > 0 })
				{
					continue;
				}

				// Both stages live in the one blob, so a pass whose vertex program was recovered has
				// its fragment program too. Taking the first that reads as source and stopping is
				// what avoids writing the same text twice under two stage names.
				StringBuilder built = new();
				built.Append("\t\t\tGLSLPROGRAM\n");
				built.Append("\t\t\t// AssetRipperRecoveredProgram: ").Append(program.Backends[variant])
					.Append(", variant ").Append(variant + 1).Append(" of ").Append(program.VariantCount)
					.Append(", blob index ").Append(program.BlobIndices[variant]);

				if (variant < program.KeywordSets.Count)
				{
					built.Append(", keywords ").Append(
						program.KeywordSets[variant].Count == 0 ? "<none>" : string.Join('+', program.KeywordSets[variant]));
				}

				built.Append('\n');

				// Which keyword sets this pass was compiled for, so a reader knows the program below
				// is one of a set rather than the whole pass. Every one of them is written out under
				// AuxiliaryFiles/ShaderVariants.
				HashSet<string> sets = [];

				foreach (var keywords in program.KeywordSets)
				{
					sets.Add(keywords.Count == 0 ? "<none>" : string.Join('+', keywords));
				}

				built.Append("\t\t\t// variant keyword sets: ").Append(string.Join(" | ", sets.Take(12)));

				if (sets.Count > 12)
				{
					built.Append(" | … ").Append(sets.Count - 12).Append(" more");
				}

				built.Append('\n');

				// AssetRipper: every variant of this backend under a guard of its own keyword set, so a
				// material draws with the program its keywords select rather than with this one.
				var guarded = GuardedVariants(shader, program, program.Backends[variant]);
				if (guarded?.Text is { } text)
				{
					built.Append(text);
				}
				else
				{
					if (guarded is not null && program.KeywordSets.Count > 1)
					{
						built.Append("\t\t\t// AssetRipperVariantsNotEmbedded: ").Append(guarded.Reason).Append('\n');
					}

					foreach (string line in source.Replace("\r", "").Split('\n'))
					{
						built.Append("\t\t\t").Append(line).Append('\n');
					}
				}

				built.Append("\t\t\tENDGLSL");
				return built.ToString();
			}
		}

		return null;
	}

	private static ShaderVariantGuards.Result? GuardedVariants(IShader shader, ShaderSemanticModel.ProgramModel program, string backend)
	{
		if (!program.KeywordsKnown)
		{
			return new ShaderVariantGuards.Result(null, "this version records no keyword names", 0, []);
		}

		List<int> indices = [];
		HashSet<string> keywords = new(StringComparer.Ordinal);

		for (int index = 0; index < program.BlobIndices.Count && index < program.Backends.Count && index < program.KeywordSets.Count; index++)
		{
			if (program.Backends[index] == backend)
			{
				indices.Add(index);
				keywords.UnionWith(program.KeywordSets[index]);
			}
		}

		// Decided from the table before a single program is decompressed.
		if (keywords.Count > ShaderVariantGuards.MaximumKeywords)
		{
			return new ShaderVariantGuards.Result(null,
				$"{keywords.Count} keywords exceed the {ShaderVariantGuards.MaximumKeywords} that can be declared combinatorially", 0, [.. keywords]);
		}

		List<ShaderVariantGuards.Variant> variants = [];
		Dictionary<string, string> programOfSet = new(StringComparer.Ordinal);

		foreach (int index in indices)
		{
			// Each hardware tier lists the keyword sets again. The engine picks a tier by the device, so
			// a set whose tiers compiled different programs has no one program this can write; taking
			// the first tier's would be choosing. Identical programs across tiers are one program.
			string key = string.Join('+', program.KeywordSets[index]);

			if (ShaderProgramProbe.SourceFor(shader, backend, program.BlobIndices[index]) is not { Length: > 0 } text)
			{
				continue;
			}

			if (programOfSet.TryGetValue(key, out string? earlier))
			{
				if (!string.Equals(ShaderVariantGuards.ContentHash(earlier), ShaderVariantGuards.ContentHash(text), StringComparison.Ordinal))
				{
					return new ShaderVariantGuards.Result(null,
						$"hardware tiers compiled different programs for keyword set {(key.Length == 0 ? "<none>" : key)}", 0, [.. keywords]);
				}

				continue;
			}

			programOfSet[key] = text;
			variants.Add(new ShaderVariantGuards.Variant(index, program.KeywordSets[index], text));
		}

		return ShaderVariantGuards.Build(variants, isLocal: KeywordScopes(shader));
	}

	/// <summary>
	/// The scope the serialized shader records for each keyword: bit 0 of its entry in
	/// <c>m_KeywordFlags</c>, parallel to <c>m_KeywordNames</c>. Measured against every source shader
	/// the fixtures ship before being used - 16 keywords, each local exactly when its source pragma is
	/// <c>_local</c> - and no other bit is set on any keyword of either fixture.
	/// </summary>
	private static Func<string, bool?>? KeywordScopes(IShader shader)
	{
		if (!shader.Has_ParsedForm())
		{
			return null;
		}

		var form = shader.ParsedForm;
		if (!form.Has_KeywordNames() || !form.Has_KeywordFlags() || form.KeywordFlags.Length != form.KeywordNames.Count)
		{
			return null;
		}

		Dictionary<string, bool> scopes = new(StringComparer.Ordinal);
		for (int index = 0; index < form.KeywordNames.Count; index++)
		{
			scopes.TryAdd(form.KeywordNames[index].String, (form.KeywordFlags[index] & 1) != 0);
		}

		return keyword => scopes.TryGetValue(keyword, out bool local) ? local : null;
	}

	private static void WriteTags(TextWriter writer, IReadOnlyDictionary<string, string> tags, int indent)
	{
		if (tags.Count == 0)
		{
			return;
		}

		writer.Write(new string('\t', indent));
		writer.Write("Tags { ");

		foreach (var (key, value) in tags)
		{
			writer.Write($"\"{key}\" = \"{value}\" ");
		}

		writer.Write("}\n");
	}
}
