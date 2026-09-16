using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000057")]
	public class TwoByTwoTransformEffectExample : MonoBehaviour
	{
		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x20")]
		public Vector2 xAxis;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x28")]
		public Vector2 yAxis;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x30")]
		private SkeletonRenderer skeletonRenderer;

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x151853C", Offset = "0x151853C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = UnityEngine.Debug;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv57 = Spine.Unity.MeshGeneratorDelegate;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv66 = UnityEngine.Object;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv87 = \"2x2 Transform Effect Enabled.\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37A80]) = v44;\nL_0028:\n\tv47 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonRenderer = v47;\n\tgoto L_0034;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v52, v45, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0034:\n\tv64 = UnityEngine.Object::op_Equality(v47, 0);\n\tv69 = v64 == 0;\n\tif (v69) goto L_0046;\n\treturn;\nL_0046:\n\tv129 = new Spine.Unity.MeshGeneratorDelegate();\n\tSpine.Unity.MeshGeneratorDelegate::.ctor(v129, this, Il2CppMethodInfo);\n\tv123 = this.skeletonRenderer == 0;\n\tif (v123) goto L_0075;\n\tSpine.Unity.SkeletonRenderer::remove_OnPostProcessVertices(this.skeletonRenderer, v129);\n\tv129 = new Spine.Unity.MeshGeneratorDelegate();\n\tSpine.Unity.MeshGeneratorDelegate::.ctor(v129, this, Il2CppMethodInfo);\n\tv131 = this.skeletonRenderer == 0;\n\tif (v131) goto L_0075;\n\tSpine.Unity.SkeletonRenderer::add_OnPostProcessVertices(this.skeletonRenderer, v129);\n\tgoto L_0073;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v139, v136, v96, v89, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0073:\n\tUnityEngine.Debug::Log(\"2x2 Transform Effect Enabled.\");\n\treturn;\nL_0075:\n\tthrow v129;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if ((skeletonRenderer = GetComponent<SkeletonRenderer>()) == null)
			{
				return;
			}
			MeshGeneratorDelegate meshGeneratorDelegate = ProcessVertices;
			if ((object)skeletonRenderer != null)
			{
				skeletonRenderer.OnPostProcessVertices -= meshGeneratorDelegate;
				meshGeneratorDelegate = ProcessVertices;
				if ((object)skeletonRenderer != null)
				{
					skeletonRenderer.OnPostProcessVertices += meshGeneratorDelegate;
					Debug.Log("2x2 Transform Effect Enabled.");
					return;
				}
			}
			throw meshGeneratorDelegate;
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x15186B4", Offset = "0x15186B4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Behaviour::get_enabled(this);\n\tv13 = v11 == 0;\n\tif (v13) goto L_0043;\n\tv25 = buffers.vertexCount < 1;\n\tif (v25) goto L_0043;\n\tv134 = buffers.vertexBuffer + 0x20;\nL_0029:\n\t// 41 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv133 = v133 + 1;\n\tv167 = v128 * this.xAxis;\n\t*([v134 @ X11_v5+8]) = 0;\n\tv36 = this.yAxis * v168;\n\tv128 = v167 + v36;\n\t*([v134 @ X11_v5]) = v128;\n\tv134 = v134 + 0xC;\n\tv51 = buffers.vertexCount != v133;\n\tif (v51) goto L_0029;\nL_0043:\n\treturn;\n\tv145 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ProcessVertices(MeshGeneratorBuffers buffers)
		{
			//IL_005d: Expected O, but got I
			//IL_00cc: Expected O, but got F4
			//IL_00db: Expected O, but got I
			if (base.enabled && buffers.vertexCount >= 1)
			{
				object obj = (nint)buffers.vertexBuffer + 32;
				int num = 0;
				float num3 = default(float);
				object obj2 = default(object);
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					num++;
					float num2 = num3 * xAxis.x;
					_ = 0;
					float num4 = yAxis.x * (float)obj2;
					num3 = num2 + num4;
					obj = num3;
					obj = (nint)obj + 12;
				}
				while (buffers.vertexCount != num);
			}
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x151873C", Offset = "0x151873C", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Spine.Unity.MeshGeneratorDelegate;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Object;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv71 = \"2x2 Transform Effect Disabled.\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A81]) = v38;\nL_0024:\n\tgoto L_0029;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0037;\n\treturn;\nL_0037:\n\tv69 = new Spine.Unity.MeshGeneratorDelegate();\n\tSpine.Unity.MeshGeneratorDelegate::.ctor(v69, this, Il2CppMethodInfo);\n\tv87 = this.skeletonRenderer == 0;\n\tif (v87) goto L_0058;\n\tSpine.Unity.SkeletonRenderer::remove_OnPostProcessVertices(this.skeletonRenderer, v69);\n\tgoto L_0056;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v103, v100, v77, v73, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0056:\n\tUnityEngine.Debug::Log(\"2x2 Transform Effect Disabled.\");\n\treturn;\nL_0058:\n\tthrow v69;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (!(skeletonRenderer == null))
			{
				MeshGeneratorDelegate meshGeneratorDelegate = ProcessVertices;
				if ((object)skeletonRenderer == null)
				{
					throw meshGeneratorDelegate;
				}
				skeletonRenderer.OnPostProcessVertices -= meshGeneratorDelegate;
				Debug.Log("2x2 Transform Effect Disabled.");
			}
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x1518850", Offset = "0x1518850", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.xAxis = *([4080A0]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TwoByTwoTransformEffectExample()
		{
			//IL_0018: Expected O, but got I
			base._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4080A0]");
			xAxis = (Vector2)0;
		}
	}
}
