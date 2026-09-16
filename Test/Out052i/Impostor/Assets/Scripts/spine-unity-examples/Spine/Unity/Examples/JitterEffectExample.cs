using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000056")]
	public class JitterEffectExample : MonoBehaviour
	{
		[Range(0f, 0.8f)]
		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x20")]
		public float jitterMagnitude;

		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x28")]
		private SkeletonRenderer skeletonRenderer;

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x15181EC", Offset = "0x15181EC", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = UnityEngine.Debug;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv66 = Spine.Unity.MeshGeneratorDelegate;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv71 = UnityEngine.Object;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv87 = \"Jitter Effect Enabled.\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37A7E]) = v44;\nL_0028:\n\tv47 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonRenderer = v47;\n\tgoto L_0034;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v52, v45, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0034:\n\tv64 = UnityEngine.Object::op_Equality(v47, 0);\n\tv69 = v64 == 0;\n\tif (v69) goto L_0046;\n\treturn;\nL_0046:\n\tv129 = new Spine.Unity.MeshGeneratorDelegate();\n\tSpine.Unity.MeshGeneratorDelegate::.ctor(v129, this, Il2CppMethodInfo);\n\tv123 = this.skeletonRenderer == 0;\n\tif (v123) goto L_0075;\n\tSpine.Unity.SkeletonRenderer::remove_OnPostProcessVertices(this.skeletonRenderer, v129);\n\tv129 = new Spine.Unity.MeshGeneratorDelegate();\n\tSpine.Unity.MeshGeneratorDelegate::.ctor(v129, this, Il2CppMethodInfo);\n\tv131 = this.skeletonRenderer == 0;\n\tif (v131) goto L_0075;\n\tSpine.Unity.SkeletonRenderer::add_OnPostProcessVertices(this.skeletonRenderer, v129);\n\tgoto L_0073;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v139, v136, v96, v89, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0073:\n\tUnityEngine.Debug::Log(\"Jitter Effect Enabled.\");\n\treturn;\nL_0075:\n\tthrow v129;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					Debug.Log("Jitter Effect Enabled.");
					return;
				}
			}
			throw meshGeneratorDelegate;
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x1518364", Offset = "0x1518364", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = UnityEngine.Behaviour::get_enabled(this);\n\tv25 = v23 == 0;\n\tif (v25) goto L_0052;\n\tv37 = buffers.vertexCount < 1;\n\tif (v37) goto L_0052;\n\tv165 = buffers.vertexBuffer + 0x28;\nL_0032:\n\tv199 = UnityEngine.Random::get_insideUnitCircle();\n\tv166 = v166 + 1;\n\tv201 = v199 * v202;\n\tv54 = *([v165 @ X23_v5-8]) + v201;\n\t*([v165 @ X23_v5]) = *([v165 @ X23_v5]);\n\t*([v165 @ X23_v5-8]) = v54;\n\tv165 = v165 + 0xC;\n\tv67 = buffers.vertexCount != v166;\n\tif (v67) goto L_0032;\nL_0052:\n\treturn;\n\tv177 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ProcessVertices(MeshGeneratorBuffers buffers)
		{
			//IL_005d: Expected O, but got I
			//IL_00c9: Expected O, but got I
			if (base.enabled && buffers.vertexCount >= 1)
			{
				object obj = (nint)buffers.vertexBuffer + 40;
				int num = 0;
				object obj2 = default(object);
				do
				{
					Vector2 insideUnitCircle = Random.insideUnitCircle;
					num++;
					float num2 = insideUnitCircle.x * (float)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X23_v5-8]");
					float num3 = 0f + num2;
					obj = obj;
					obj = (nint)obj + 12;
				}
				while (buffers.vertexCount != num);
			}
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0x1518414", Offset = "0x1518414", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Spine.Unity.MeshGeneratorDelegate;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = UnityEngine.Object;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv71 = \"Jitter Effect Disabled.\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A7F]) = v38;\nL_0024:\n\tgoto L_0029;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0037;\n\treturn;\nL_0037:\n\tv69 = new Spine.Unity.MeshGeneratorDelegate();\n\tSpine.Unity.MeshGeneratorDelegate::.ctor(v69, this, Il2CppMethodInfo);\n\tv87 = this.skeletonRenderer == 0;\n\tif (v87) goto L_0058;\n\tSpine.Unity.SkeletonRenderer::remove_OnPostProcessVertices(this.skeletonRenderer, v69);\n\tgoto L_0056;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v103, v100, v77, v73, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0056:\n\tUnityEngine.Debug::Log(\"Jitter Effect Disabled.\");\n\treturn;\nL_0058:\n\tthrow v69;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				Debug.Log("Jitter Effect Disabled.");
			}
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x1518528", Offset = "0x1518528", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.jitterMagnitude = 0.2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JitterEffectExample()
		{
			jitterMagnitude = 0.2f;
		}
	}
}
