using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x2000011")]
	public class DemoRandomColorSwap : MonoBehaviour
	{
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x20")]
		private Material mat;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x28")]
		private readonly int colorSwapRed;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x2C")]
		private readonly int colorSwapGreen;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x30")]
		private readonly int colorSwapBlue;

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3C202FC", Offset = "0x3C202FC", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB78D000;\n\tv22 = *([B78D3A2]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_005D;\n\tv26 = UnityEngine.Component::GetComponent(this);\n\tv53 = v26;\n\tgoto L_001B;\nL_001B:\n\tv63 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv75 = ~v63;\n\tif (v75) goto L_0077;\n\tv95 = UnityEngine.Component::GetComponent(this);\n\tv165 = UnityEngine.Renderer::get_material(v95);\n\tthis.mat = v165;\n\tgoto L_0035;\nL_0035:\n\tv181 = UnityEngine.Object::op_Inequality(this.mat, 0);\n\tv183 = ~v181;\n\tif (v183) goto L_0086;\n\tUnityEngine.MonoBehaviour::InvokeRepeating(this, \"NewColor\", 0f, 0.6f);\n\treturn;\nL_005D:\n\t*([v16 @ X20_v1+3A2]) = 1;\n\tv54 = UnityEngine.Component::GetComponent(this);\n\tv53 = v54;\n\tgoto L_001B;\nL_0077:\n\treturn;\nL_0086:\n\tgoto L_008C;\nL_008C:\n\tUnityEngine.Debug::LogError(\"No material found\");\n\tgoto L_009A;\nL_009A:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\n")]
		private void Start()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D3A2]");
			Object obj2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				SpriteRenderer component = GetComponent<SpriteRenderer>();
				obj2 = component;
			}
			else
			{
				_ = 1;
				SpriteRenderer component2 = GetComponent<SpriteRenderer>();
				obj2 = component2;
			}
			if (obj2 != null)
			{
				Renderer component3 = GetComponent<Renderer>();
				Material material = component3.material;
				mat = material;
				if (mat != null)
				{
					InvokeRepeating("NewColor", 0f, 0.6f);
					return;
				}
				Debug.LogError("No material found");
				Object.Destroy(this);
			}
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x3C20500", Offset = "0x3C20500", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = UnityEngine.Random::Range(0f, 1f);\n\tv30 = UnityEngine.Random::Range(0f, 1f);\n\tv35 = UnityEngine.Random::Range(0f, 1f);\n\t// 36 MakeStruct v44 @ AGG3C20578_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v25 @ V0_v2 (System.Single), v30 @ V0_v4 (System.Single), v35 @ V0_v6 (System.Single), 1f\n\tUnityEngine.Material::SetColor(this.mat, this.colorSwapRed, v44);\n\tv100 = UnityEngine.Random::Range(0f, 1f);\n\tv104 = UnityEngine.Random::Range(0f, 1f);\n\tv78 = UnityEngine.Random::Range(0f, 1f);\n\t// 63 MakeStruct v47 @ AGG3C205DC_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v100 @ V0_v10 (System.Single), v104 @ V0_v12 (System.Single), v78 @ V0_v14 (System.Single), 1f\n\tUnityEngine.Material::SetColor(this.mat, this.colorSwapGreen, v47);\n\tv148 = UnityEngine.Random::Range(0f, 1f);\n\tv152 = UnityEngine.Random::Range(0f, 1f);\n\tv79 = UnityEngine.Random::Range(0f, 1f);\n\t// 99 MakeStruct v106 @ AGG3C20650_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v148 @ V0_v17 (System.Single), v152 @ V0_v19 (System.Single), v79 @ V0_v21 (System.Single), 1f\n\tUnityEngine.Material::SetColor(this.mat, this.colorSwapBlue, v106);\n\treturn;\n")]
		private void NewColor()
		{
			float r = Random.Range(0f, 1f);
			float g = Random.Range(0f, 1f);
			float b = Random.Range(0f, 1f);
			Color value = default(Color);
			value.r = r;
			value.g = g;
			value.b = b;
			value.a = 1f;
			mat.SetColor(colorSwapRed, value);
			float r2 = Random.Range(0f, 1f);
			float g2 = Random.Range(0f, 1f);
			float b2 = Random.Range(0f, 1f);
			Color value2 = default(Color);
			value2.r = r2;
			value2.g = g2;
			value2.b = b2;
			value2.a = 1f;
			mat.SetColor(colorSwapGreen, value2);
			float r3 = Random.Range(0f, 1f);
			float g3 = Random.Range(0f, 1f);
			float b3 = Random.Range(0f, 1f);
			Color value3 = default(Color);
			value3.r = r3;
			value3.g = g3;
			value3.b = b3;
			value3.a = 1f;
			mat.SetColor(colorSwapBlue, value3);
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x3C20658", Offset = "0x3C20658", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Random::Range(0f, 1f);\n\tv18 = UnityEngine.Random::Range(0f, 1f);\n\tv23 = UnityEngine.Random::Range(0f, 1f);\n\treturn v13;\n")]
		private Color GenerateColor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoRandomColorSwap::GenerateColor");
			return default;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x3C206B8", Offset = "0x3C206B8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tthis.colorSwapBlue = v66;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0024:\n\tv55 = UnityEngine.Shader::PropertyToID(\"_ColorSwapRed\");\n\tthis.colorSwapRed = v55;\n\tv61 = UnityEngine.Shader::PropertyToID(\"_ColorSwapGreen\");\n\tthis.colorSwapGreen = v61;\n\tv66 = UnityEngine.Shader::PropertyToID(\"_ColorSwapBlue\");\n")]
		public DemoRandomColorSwap()
		{
			int num = Shader.PropertyToID("_ColorSwapRed");
			colorSwapRed = num;
			int num2 = Shader.PropertyToID("_ColorSwapGreen");
			colorSwapGreen = num2;
			int num3 = Shader.PropertyToID("_ColorSwapBlue");
			colorSwapBlue = num3;
		}
	}
}
