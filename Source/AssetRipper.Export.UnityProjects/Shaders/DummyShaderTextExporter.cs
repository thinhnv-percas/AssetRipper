using AssetRipper.Assets;
using AssetRipper.SourceGenerated.Classes.ClassID_48;
using AssetRipper.SourceGenerated.Extensions;
using AssetRipper.SourceGenerated.Extensions.Enums.Shader.SerializedShader;
using AssetRipper.SourceGenerated.Subclasses.SerializedProperties;
using AssetRipper.SourceGenerated.Subclasses.SerializedProperty;

namespace AssetRipper.Export.UnityProjects.Shaders;

public sealed class DummyShaderTextExporter : ShaderExporterBase
{
	// This uses CGPROGRAM instead of HLSLPROGRAM because the latter was supposedly introduced in Unity 5.6.
	// https://github.com/UnityCommunity/UnityReleaseNotes/blob/7b417b8ff64415e1e509d8c345b829c7cc11b650/5.6-Beta/5.6.0b1.txt#L143
	private static string FallbackDummyShader { get; } = """

			SubShader{
				Tags { "RenderType" = "Opaque" }
				LOD 200
				CGPROGRAM
		#pragma surface surf Lambert
		#pragma target 3.0
				sampler2D _MainTex;
				struct Input
				{
					float2 uv_MainTex;
				};
				void surf(Input IN, inout SurfaceOutput o)
				{
					float4 c = tex2D(_MainTex, IN.uv_MainTex);
					o.Albedo = c.rgb;
				}
				ENDCG
			}

		""".Replace("\r", "");

	public override bool Export(IExportContainer container, IUnityObjectBase asset, string path, FileSystem fileSystem)
	{
		return ExportShader((IShader)asset, path, fileSystem);
	}

	public static bool ExportShader(IShader shader, string path, FileSystem fileSystem)
	{
		using Stream fileStream = fileSystem.File.Create(path);
		using InvariantStreamWriter writer = new(fileStream);
		return ExportShader(shader, writer);
	}

	public static bool ExportShader(IShader shader, TextWriter writer)
	{
		// Technically, this outputs invalid shader code for Unity 5.5 because HLSLPROGRAM was not introduced until Unity 5.6.
		// AssetRipper: the shader's own structure where the asset carries one. Falls through to the
		// single canned pass below only when it does not, so nothing that used to export stops.
		if (StructuredShaderTextExporter.TryExport(shader, writer))
		{
			return true;
		}

		if (shader.Has_ParsedForm())
		{
			writer.Write($"Shader \"{shader.ParsedForm.Name}\" {{\n");
			Export(shader.ParsedForm.PropInfo, writer);

			TemplateShader templateShader = TemplateList.GetBestTemplate(shader);
			writer.Write("\t//DummyShaderTextExporter\n");
			if (templateShader != null)
			{
				writer.Write(templateShader.ShaderText);
			}
			else
			{
				writer.WriteIndent(1);
				writer.Write(FallbackDummyShader);
			}
			writer.Write('\n');

			if (shader.ParsedForm.FallbackName != string.Empty)
			{
				writer.WriteIndent(1);
				writer.Write($"Fallback \"{shader.ParsedForm.FallbackName}\"\n");
			}
			if (shader.ParsedForm.CustomEditorName != string.Empty)
			{
				writer.WriteIndent(1);
				writer.Write($"//CustomEditor \"{shader.ParsedForm.CustomEditorName}\"\n");
			}
			writer.Write('}');
		}
		else
		{
			string header = shader.Script.String;
			int subshaderIndex = header.IndexOf("SubShader");
			if (subshaderIndex < 0)
			{
				return false;
			}
			writer.WriteString(header, 0, subshaderIndex);

			writer.Write("\t//DummyShaderTextExporter\n");
			writer.WriteIndent(1);
			writer.Write(FallbackDummyShader);

			writer.Write('}');
		}
		return true;
	}

	/// <summary>AssetRipper: the Properties block, which the structured exporter reuses verbatim.</summary>
	internal static void ExportProperties(IShader shader, TextWriter writer)
	{
		if (shader.Has_ParsedForm())
		{
			Export(shader.ParsedForm.PropInfo, writer);
		}
	}

	private static void Export(ISerializedProperties _this, TextWriter writer)
	{
		writer.WriteIndent(1);
		writer.Write("Properties {\n");
		foreach (ISerializedProperty prop in _this.Props)
		{
			Export(prop, writer);
		}
		writer.WriteIndent(1);
		writer.Write("}\n");
	}

	private static void Export(ISerializedProperty _this, TextWriter writer)
	{
		writer.WriteIndent(2);
		foreach (Utf8String attribute in _this.Attributes)
		{
			writer.Write($"[{attribute}] ");
		}
		SerializedPropertyFlag flags = (SerializedPropertyFlag)_this.Flags;
		if (flags.IsHideInInspector())
		{
			writer.Write("[HideInInspector] ");
		}
		if (flags.IsPerRendererData())
		{
			writer.Write("[PerRendererData] ");
		}
		if (flags.IsNoScaleOffset())
		{
			writer.Write("[NoScaleOffset] ");
		}
		if (flags.IsNormal())
		{
			writer.Write("[Normal] ");
		}
		if (flags.IsHDR())
		{
			writer.Write("[HDR] ");
		}
		if (flags.IsGamma())
		{
			writer.Write("[Gamma] ");
		}

		writer.Write($"{_this.Name} (\"{_this.Description}\", ");

		switch (_this.GetType_())
		{
			// Color and Vector are distinct in the serialized shader and distinct in ShaderLab: a
			// Color property gets the colour picker in the material inspector and is converted out
			// of gamma space when it is assigned, a Vector is four numbers. Writing both as Vector
			// discards a type the metadata carries.
			case SerializedPropertyType.Color:
				writer.Write("Color");
				break;

			case SerializedPropertyType.Vector:
				writer.Write("Vector");
				break;

			case SerializedPropertyType.Float:
				writer.Write("Float");
				break;

			case SerializedPropertyType.Range:
				writer.Write($"Range({_this.DefValue_1_.ToStringInvariant()}, {_this.DefValue_2_.ToStringInvariant()})");
				break;

			case SerializedPropertyType.Texture:
				switch (_this.DefTexture.TexDim)
				{
					case 1:
						writer.Write("any");
						break;
					case 2:
						writer.Write("2D");
						break;
					case 3:
						writer.Write("3D");
						break;
					case 4:
						writer.Write("Cube");
						break;
					case 5:
						writer.Write("2DArray");
						break;
					case 6:
						writer.Write("CubeArray");
						break;
					default:
						throw new NotSupportedException("Texture dimension isn't supported");

				}
				break;

			case SerializedPropertyType.Int:
				writer.Write("Int");
				break;

			default:
				throw new NotSupportedException($"Serialized property type {_this.Type} isn't supported");
		}
		writer.Write(") = ");

		switch (_this.GetType_())
		{
			case SerializedPropertyType.Color:
			case SerializedPropertyType.Vector:
				writer.Write($"({_this.DefValue_0_.ToStringInvariant()},{_this.DefValue_1_.ToStringInvariant()},{_this.DefValue_2_.ToStringInvariant()},{_this.DefValue_3_.ToStringInvariant()})");
				break;

			case SerializedPropertyType.Float:
			case SerializedPropertyType.Range:
			case SerializedPropertyType.Int:
				writer.Write(_this.DefValue_0_.ToStringInvariant());
				break;

			case SerializedPropertyType.Texture:
				writer.Write($"\"{_this.DefTexture.DefaultName}\" {{}}");
				break;

			default:
				throw new NotSupportedException($"Serialized property type {_this.Type} isn't supported");
		}
		writer.Write('\n');
	}
}
