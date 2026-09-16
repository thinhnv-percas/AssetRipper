using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200002D")]
	public class MaterialReplacementExample : MonoBehaviour
	{
		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x20")]
		public Material originalMaterial;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x28")]
		public Material replacementMaterial;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x30")]
		public bool replacementEnabled;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x38")]
		public SkeletonAnimation skeletonAnimation;

		[Space]
		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x40")]
		public string phasePropertyName;

		[Range(0f, 1f)]
		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x48")]
		public float phase;

		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x4C")]
		private bool previousEnabled;

		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x50")]
		private MaterialPropertyBlock mpb;

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x150E7B0", Offset = "0x150E7B0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = UnityEngine.MaterialPropertyBlock;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A23]) = v37;\nL_0016:\n\tthis.previousEnabled = this.replacementEnabled;\n\tSpine.Unity.Examples.MaterialReplacementExample::SetReplacementEnabled(this, 0);\n\tv42 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v42);\n\tthis.mpb = v42;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			previousEnabled = replacementEnabled;
			SetReplacementEnabled(active: false);
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			mpb = materialPropertyBlock;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x150E8AC", Offset = "0x150E8AC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37A24]) = v33;\nL_0018:\n\tUnityEngine.MaterialPropertyBlock::SetFloat(this.mpb, this.phasePropertyName, this.phase);\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.Renderer::SetPropertyBlock(v46, this.mpb);\n\tv92 = this.previousEnabled;\n\tv67 = this.previousEnabled == this.replacementEnabled;\n\tif (v67) goto L_0031;\n\tSpine.Unity.Examples.MaterialReplacementExample::SetReplacementEnabled(this, 0);\n\tv92 = this.replacementEnabled;\nL_0031:\n\tthis.previousEnabled = v92;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			mpb.SetFloat(phasePropertyName, phase);
			MeshRenderer component = GetComponent<MeshRenderer>();
			component.SetPropertyBlock(mpb);
			bool flag = previousEnabled;
			if (previousEnabled != replacementEnabled)
			{
				SetReplacementEnabled(active: false);
				flag = replacementEnabled;
			}
			previousEnabled = flag;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x150E81C", Offset = "0x150E81C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, active, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, active, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37A25]) = v34;\nL_0013:\n\tv35 = this.skeletonAnimation;\n\tv42 = ~this.replacementEnabled;\n\tif (v42) goto L_0030;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::set_Item(v35.customMaterialOverride, this.originalMaterial, this.replacementMaterial);\n\treturn;\nL_0030:\n\tv64 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::Remove(v35.customMaterialOverride, this.originalMaterial);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetReplacementEnabled(bool active)
		{
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			if (replacementEnabled)
			{
				skeletonAnimation.CustomMaterialOverride[originalMaterial] = replacementMaterial;
			}
			else
			{
				bool flag = skeletonAnimation.CustomMaterialOverride.Remove(originalMaterial);
			}
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x150E948", Offset = "0x150E948", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = \"_FillPhase\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A26]) = v37;\nL_0014:\n\tthis.replacementEnabled = 1;\n\tthis.phase = 1f;\n\tthis.phasePropertyName = \"_FillPhase\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MaterialReplacementExample()
		{
			replacementEnabled = true;
			phase = 1f;
			phasePropertyName = "_FillPhase";
		}
	}
}
