using System.Text;
using AssetRipper.SourceGenerated.Classes.ClassID_48;

namespace AssetRipper.Export.UnityProjects.Shaders;

/// <summary>
/// AssetRipper: one record per compiled sub-program a shader carries, with what was read out of it.
/// </summary>
/// <remarks>
/// The record says where the bytes are, what they decompressed to and what they turned out to be. It
/// never decodes something it has not established the encoding of: an <c>encoding</c> of
/// <c>UNKNOWN</c> with the bytes' position and length is a usable fact, and a plausible-looking
/// decode of bytes nobody has identified is not.
/// </remarks>
public static class ShaderProgramExtractor
{
	public static string ToJson(IReadOnlyList<ShaderProgramProbe.ShaderEvidence> shaders)
	{
		StringBuilder builder = new();
		builder.Append("[\n");
		bool firstShader = true;

		foreach (var shader in shaders)
		{
			foreach (var program in shader.SubPrograms)
			{
				if (!firstShader)
					builder.Append(",\n");

				firstShader = false;

				builder.Append("  {");
				builder.Append("\"shader\": ").Append(Quote(shader.Shader));
				builder.Append(", \"index\": ").Append(program.Index);
				builder.Append(", \"platform\": ").Append(program.Platform);
				builder.Append(", \"backend\": ").Append(Quote(program.Backend));
				builder.Append(", \"encoding\": ").Append(Quote(program.Encoding.ToString().ToUpperInvariant()));
				var (kind, recoverability) = CompiledShaderProgram.KindOf(program);
				builder.Append(", \"programKind\": ").Append(Quote(kind.ToString()));
				builder.Append(", \"recoverability\": ").Append(Quote(recoverability.ToString()));
				builder.Append(", \"compressed\": true");
				builder.Append(", \"blobShape\": ").Append(Quote(shader.BlobShape));
				builder.Append(", \"offset\": ").Append(program.Offset);
				builder.Append(", \"size\": ").Append(program.Length);
				builder.Append(", \"printableRatio\": ").Append(program.PrintableRatio.ToString(System.Globalization.CultureInfo.InvariantCulture));
				builder.Append(", \"markers\": [");

				for (int index = 0; index < program.Markers.Count; index++)
				{
					if (index > 0)
						builder.Append(", ");

					builder.Append(Quote(program.Markers[index]));
				}

				builder.Append(']');
				builder.Append(", \"headHex\": ").Append(Quote(program.HeadHex));
				builder.Append(", \"textOffset\": ").Append(program.TextOffset);
				builder.Append(", \"textLength\": ").Append(program.TextLength);
				builder.Append(", \"payload\": ").Append(
					program.Encoding == ShaderProgramProbe.ProgramEncoding.SourceText
						? Quote(PayloadFileName(shader.Shader, program))
						: "null");
				builder.Append('}');
			}

			if (shader.SubPrograms.Count == 0)
			{
				if (!firstShader)
					builder.Append(",\n");

				firstShader = false;

				builder.Append("  {");
				builder.Append("\"shader\": ").Append(Quote(shader.Shader));
				builder.Append(", \"index\": -1");
				builder.Append(", \"encoding\": ").Append(Quote(shader.HasBlob ? "UNKNOWN" : "NO_BLOB"));
				builder.Append(", \"blobShape\": ").Append(Quote(shader.BlobShape));
				builder.Append(", \"compressedBlobLength\": ").Append(shader.CompressedBlobLength);
				builder.Append(", \"platformCount\": ").Append(shader.PlatformCount);
				builder.Append(", \"failure\": ").Append(shader.Failure is { } failure ? Quote(failure) : "null");
				builder.Append('}');
			}
		}

		builder.Append("\n]\n");
		return builder.ToString();
	}

	/// <summary>
	/// Where one sub-program's recovered text is written, relative to the report.
	/// </summary>
	/// <remarks>
	/// The naming rule lives here and is called by both the report and whatever writes the files, so
	/// a record cannot come to name a path nothing wrote. The programs are separate files rather than
	/// inline strings because one fixture carries 3016 of them and a single JSON holding all their
	/// source is neither readable nor loadable.
	/// </remarks>
	public static string PayloadFileName(string shader, ShaderProgramProbe.SubProgramEvidence program)
	{
		StringBuilder builder = new("ShaderPrograms/");

		foreach (char character in shader)
			builder.Append(char.IsLetterOrDigit(character) ? character : '_');

		builder.Append('_').Append(program.Backend).Append('_').Append(program.Index).Append(".glsl");
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
						builder.Append("\\u").Append(((int)character).ToString("x4"));
					else
						builder.Append(character);
					break;
			}
		}

		builder.Append('"');
		return builder.ToString();
	}
}
