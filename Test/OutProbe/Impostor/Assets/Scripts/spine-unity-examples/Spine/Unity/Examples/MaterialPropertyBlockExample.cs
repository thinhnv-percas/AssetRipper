using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200002C")]
	public class MaterialPropertyBlockExample : MonoBehaviour
	{
		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x20")]
		public float timeInterval;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x28")]
		public Gradient randomColors;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x30")]
		public string colorPropertyName;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x38")]
		private MaterialPropertyBlock mpb;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x40")]
		private float timeToNextColor;

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x150E610", Offset = "0x150E610", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = UnityEngine.MaterialPropertyBlock;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A20]) = v37;\nL_0014:\n\tv39 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v39);\n\tthis.mpb = v39;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			mpb = materialPropertyBlock;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x150E668", Offset = "0x150E668", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A37A21]) = v35;\nL_0011:\n\tv52 = this.timeToNextColor;\n\tv37 = this.timeToNextColor < 0;\n\tv38 = ~v37;\n\tv41 = this.timeToNextColor == 0;\n\tv46 = ~v41;\n\tv47 = v38 & v46;\n\tif (v47) goto L_003E;\n\tthis.timeToNextColor = this.timeInterval;\n\tv51 = UnityEngine.Random::get_value();\n\tv68 = UnityEngine.Gradient::Evaluate(this.randomColors, v51);\n\tUnityEngine.MaterialPropertyBlock::SetColor(this.mpb, this.colorPropertyName, v68);\n\tv70 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.Renderer::SetPropertyBlock(v70, this.mpb);\n\tv52 = this.timeToNextColor;\nL_003E:\n\tv77 = UnityEngine.Time::get_deltaTime();\n\tv79 = v52 - v77;\n\tthis.timeToNextColor = v79;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float num = timeToNextColor;
			bool flag = timeToNextColor < 0f;
			bool flag2 = !flag;
			bool flag3 = timeToNextColor == 0f;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				timeToNextColor = timeInterval;
				float value = Random.value;
				Color value2 = randomColors.Evaluate(value);
				mpb.SetColor(colorPropertyName, value2);
				MeshRenderer component = GetComponent<MeshRenderer>();
				component.SetPropertyBlock(mpb);
				num = timeToNextColor;
			}
			float deltaTime = Time.deltaTime;
			float num2 = num - deltaTime;
			timeToNextColor = num2;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x150E728", Offset = "0x150E728", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = UnityEngine.Gradient;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = \"_FillColor\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A22]) = v42;\nL_001A:\n\tthis.timeInterval = 1f;\n\tv45 = new UnityEngine.Gradient();\n\tUnityEngine.Gradient::.ctor(v45);\n\tthis.randomColors = v45;\n\tthis.colorPropertyName = \"_FillColor\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MaterialPropertyBlockExample()
		{
			timeInterval = 1f;
			Gradient gradient = new Gradient();
			randomColors = gradient;
			colorPropertyName = "_FillColor";
		}
	}
}
