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
		if (ShaderSemanticModel.Read(shader) is not { } model || model.SubShaders.Count == 0)
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
			for (int variant = 0; variant < program.BlobIndices.Count && variant < program.Backends.Count; variant++)
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
					.Append(", blob index ").Append(program.BlobIndices[variant]).Append('\n');

				foreach (string line in source.Replace("\r", "").Split('\n'))
				{
					built.Append("\t\t\t").Append(line).Append('\n');
				}

				built.Append("\t\t\tENDGLSL");
				return built.ToString();
			}
		}

		return null;
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
