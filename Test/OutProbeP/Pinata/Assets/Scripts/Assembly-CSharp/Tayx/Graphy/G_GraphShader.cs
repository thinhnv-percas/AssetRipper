using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy
{
	[Token(Token = "0x200002E")]
	public class G_GraphShader
	{
		[Token(Token = "0x400013C")]
		public const int ArrayMaxSizeFull = 512;

		[Token(Token = "0x400013D")]
		public const int ArrayMaxSizeLight = 128;

		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x10")]
		public int ArrayMaxSize;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x18")]
		public float[] Array;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x20")]
		public Image Image;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x28")]
		private string Name;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x30")]
		private string Name_Length;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x38")]
		public float Average;

		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x3C")]
		private int averagePropertyId;

		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x40")]
		public float GoodThreshold;

		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x44")]
		public float CautionThreshold;

		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x48")]
		private int goodThresholdPropertyId;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x4C")]
		private int cautionThresholdPropertyId;

		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x50")]
		public Color GoodColor;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x60")]
		public Color CautionColor;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x70")]
		public Color CriticalColor;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x80")]
		private int goodColorPropertyId;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x84")]
		private int cautionColorPropertyId;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x88")]
		private int criticalColorPropertyId;

		[Token(Token = "0x6000150")]
		[Address(RVA = "0xB0CBF8", Offset = "0xB0CBF8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED3F90]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202253C]) = v40;\nL_001A:\n\tv46 = UnityEngine.UI.Image::get_material(this.Image);\n\t// 34 NewArr v54 @ X0_v9 (System.Single[]), typeof(System.Single[]), this.ArrayMaxSize (System.Int32)\n\tUnityEngine.Material::SetFloatArray(v46, this.Name, v54);\n\tv76 = UnityEngine.Shader::PropertyToID(\"Average\");\n\tthis.averagePropertyId = v76;\n\tv101 = UnityEngine.Shader::PropertyToID(\"_GoodThreshold\");\n\tthis.goodThresholdPropertyId = v101;\n\tv106 = UnityEngine.Shader::PropertyToID(\"_CautionThreshold\");\n\tthis.cautionThresholdPropertyId = v106;\n\tv111 = UnityEngine.Shader::PropertyToID(\"_GoodColor\");\n\tthis.goodColorPropertyId = v111;\n\tv116 = UnityEngine.Shader::PropertyToID(\"_CautionColor\");\n\tthis.cautionColorPropertyId = v116;\n\tv87 = UnityEngine.Shader::PropertyToID(\"_CriticalColor\");\n\tthis.criticalColorPropertyId = v87;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InitializeShader()
		{
			Material material = Image.material;
			float[] values = new float[ArrayMaxSize];
			material.SetFloatArray(Name, values);
			int num = Shader.PropertyToID("Average");
			averagePropertyId = num;
			int num2 = Shader.PropertyToID("_GoodThreshold");
			goodThresholdPropertyId = num2;
			int num3 = Shader.PropertyToID("_CautionThreshold");
			cautionThresholdPropertyId = num3;
			int num4 = Shader.PropertyToID("_GoodColor");
			goodColorPropertyId = num4;
			int num5 = Shader.PropertyToID("_CautionColor");
			cautionColorPropertyId = num5;
			int num6 = Shader.PropertyToID("_CriticalColor");
			criticalColorPropertyId = num6;
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0xB0D708", Offset = "0xB0D708", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.UI.Image::get_material(this.Image);\n\tv30 = this.Array;\n\tUnityEngine.Material::SetInt(v15, this.Name_Length, v30.Length);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateArray()
		{
			Material material = Image.material;
			float[] array = Array;
			material.SetInt(Name_Length, array.Length);
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0xB0D760", Offset = "0xB0D760", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.UI.Image::get_material(this.Image);\n\tUnityEngine.Material::SetFloat(v15, this.averagePropertyId, this.Average);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateAverage()
		{
			Material material = Image.material;
			material.SetFloat(averagePropertyId, Average);
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xB0D694", Offset = "0xB0D694", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.UI.Image::get_material(this.Image);\n\tUnityEngine.Material::SetFloat(v15, this.goodThresholdPropertyId, this.GoodThreshold);\n\tv50 = UnityEngine.UI.Image::get_material(this.Image);\n\tUnityEngine.Material::SetFloat(v50, this.cautionThresholdPropertyId, this.CautionThreshold);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateThresholds()
		{
			Material material = Image.material;
			material.SetFloat(goodThresholdPropertyId, GoodThreshold);
			Material material2 = Image.material;
			material2.SetFloat(cautionThresholdPropertyId, CautionThreshold);
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0xB0D5E8", Offset = "0xB0D5E8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.UI.Image::get_material(this.Image);\n\t// 21 MakeStruct v36 @ AGGB0D624_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), this.GoodColor (UnityEngine.Color), this.GoodColor.g (System.Single), this.GoodColor.b (System.Single), this.GoodColor.a (System.Single)\n\tUnityEngine.Material::SetColor(v15, this.goodColorPropertyId, v36);\n\tv73 = UnityEngine.UI.Image::get_material(this.Image);\n\t// 38 MakeStruct v33 @ AGGB0D654_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), this.CautionColor (UnityEngine.Color), this.CautionColor.g (System.Single), this.CautionColor.b (System.Single), this.CautionColor.a (System.Single)\n\tUnityEngine.Material::SetColor(v73, this.cautionColorPropertyId, v33);\n\tv75 = UnityEngine.UI.Image::get_material(this.Image);\n\t// 59 MakeStruct v78 @ AGGB0D68C_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.CriticalColor (UnityEngine.Color), this.CriticalColor.g (System.Single), this.CriticalColor.b (System.Single), this.CriticalColor.a (System.Single)\n\tUnityEngine.Material::SetColor(v75, this.criticalColorPropertyId, v78);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateColors()
		{
			Material material = Image.material;
			Color value = default(Color);
			value.r = GoodColor.r;
			value.g = GoodColor.g;
			value.b = GoodColor.b;
			value.a = GoodColor.a;
			material.SetColor(goodColorPropertyId, value);
			Material material2 = Image.material;
			Color value2 = default(Color);
			value2.r = CautionColor.r;
			value2.g = CautionColor.g;
			value2.b = CautionColor.b;
			value2.a = CautionColor.a;
			material2.SetColor(cautionColorPropertyId, value2);
			Material material3 = Image.material;
			Color value3 = default(Color);
			value3.r = CriticalColor.r;
			value3.g = CriticalColor.g;
			value3.b = CriticalColor.b;
			value3.a = CriticalColor.a;
			material3.SetColor(criticalColorPropertyId, value3);
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0xB0D2E4", Offset = "0xB0D2E4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.UI.Image::get_material(this.Image);\n\tUnityEngine.Material::SetFloatArray(v15, this.Name, this.Array);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdatePoints()
		{
			Material material = Image.material;
			material.SetFloatArray(Name, Array);
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0xB0D7A8", Offset = "0xB0D7A8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F010A0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202253D]) = v38;\nL_0016:\n\tthis.ArrayMaxSize = 0x80;\n\tthis.Name = \"GraphValues\";\n\tthis.Name_Length = \"GraphValues_Length\";\n\tv47 = UnityEngine.Color::get_white();\n\tthis.GoodColor = v47;\n\tthis.GoodColor.g = v47.g;\n\tthis.GoodColor.b = v47.b;\n\tthis.GoodColor.a = v47.a;\n\tv52 = UnityEngine.Color::get_white();\n\tthis.CautionColor = v52;\n\tthis.CautionColor.g = v52.g;\n\tthis.CautionColor.b = v52.b;\n\tthis.CautionColor.a = v52.a;\n\tv57 = UnityEngine.Color::get_white();\n\tthis.CriticalColor = v57;\n\tthis.CriticalColor.g = v57.g;\n\tthis.CriticalColor.b = v57.b;\n\tthis.CriticalColor.a = v57.a;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_GraphShader()
		{
			ArrayMaxSize = 128;
			Name = "GraphValues";
			Name_Length = "GraphValues_Length";
			Color color = (GoodColor = Color.white);
			GoodColor.g = color.g;
			GoodColor.b = color.b;
			GoodColor.a = color.a;
			Color color2 = (CautionColor = Color.white);
			CautionColor.g = color2.g;
			CautionColor.b = color2.b;
			CautionColor.a = color2.a;
			Color color3 = (CriticalColor = Color.white);
			CriticalColor.g = color3.g;
			CriticalColor.b = color3.b;
			CriticalColor.a = color3.a;
		}
	}
}
