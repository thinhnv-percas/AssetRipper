using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000053")]
	public class OutlineSkeletonGraphic : MonoBehaviour
	{
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonGraphic skeletonGraphic;

		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x28")]
		public Material materialWithoutOutline;

		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x30")]
		public Material materialWithOutline;

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x1517BF8", Offset = "0x1517BF8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A77]) = v38;\nL_001B:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv53 = v51 == 0;\n\tif (v53) goto L_002F;\n\tv58 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonGraphic = v58;\nL_002F:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (skeletonGraphic == null)
			{
				SkeletonGraphic component = GetComponent<SkeletonGraphic>();
				skeletonGraphic = component;
			}
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x1517C84", Offset = "0x1517C84", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.skeletonGraphic;\n\tv6 = *([v4 @ X0_v1 (Spine.Unity.SkeletonGraphic)]);\n\tv7 = this.materialWithOutline;\n\tv8 = *([v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+348]);\n\tv9 = *([v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+350]);\n\t// 12 IndirectJump v8 @ X3_v1, v4 @ X0_v1 (Spine.Unity.SkeletonGraphic), v4 @ X0_v1 (Spine.Unity.SkeletonGraphic), v7 @ X1_v1 (UnityEngine.Material), v9 @ X2_v1, v8 @ X3_v1, v11 @ X4, v12 @ X5, v13 @ X6, v14 @ X7, v15 @ V0, v16 @ V1, v17 @ V2, v18 @ V3, v19 @ V4, v20 @ V5, v21 @ V6, v22 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void EnableOutlineRendering()
		{
			//IL_0017: Expected I, but got O
			//IL_0031: Expected O, but got I
			//IL_0041: Expected O, but got I
			SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
			nint num = (nint)skeletonGraphic;
			Material material = materialWithOutline;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+348]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+350]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x1517CB0", Offset = "0x1517CB0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.skeletonGraphic;\n\tv6 = *([v4 @ X0_v1 (Spine.Unity.SkeletonGraphic)]);\n\tv7 = this.materialWithoutOutline;\n\tv8 = *([v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+348]);\n\tv9 = *([v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+350]);\n\t// 12 IndirectJump v8 @ X3_v1, v4 @ X0_v1 (Spine.Unity.SkeletonGraphic), v4 @ X0_v1 (Spine.Unity.SkeletonGraphic), v7 @ X1_v1 (UnityEngine.Material), v9 @ X2_v1, v8 @ X3_v1, v11 @ X4, v12 @ X5, v13 @ X6, v14 @ X7, v15 @ V0, v16 @ V1, v17 @ V2, v18 @ V3, v19 @ V4, v20 @ V5, v21 @ V6, v22 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DisableOutlineRendering()
		{
			//IL_0017: Expected I, but got O
			//IL_0031: Expected O, but got I
			//IL_0041: Expected O, but got I
			SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
			nint num = (nint)skeletonGraphic;
			Material material = materialWithoutOutline;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+348]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X9_v1 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+350]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x1517CDC", Offset = "0x1517CDC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OutlineSkeletonGraphic()
		{
		}
	}
}
