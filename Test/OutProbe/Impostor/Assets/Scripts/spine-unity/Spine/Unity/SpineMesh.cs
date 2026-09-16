using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000AF")]
	public static class SpineMesh
	{
		[Token(Token = "0x400041C")]
		internal const HideFlags MeshHideflags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;

		[Token(Token = "0x600069E")]
		[Address(RVA = "0x156FB6C", Offset = "0x156FB6C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = UnityEngine.Mesh;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = \"Skeleton Mesh\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A37CDD]) = v35;\nL_0015:\n\tv37 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v37);\n\tUnityEngine.Mesh::MarkDynamic(v37);\n\tUnityEngine.Object::set_name(v37, \"Skeleton Mesh\");\n\tUnityEngine.Object::set_hideFlags(v37, 0x14);\n\treturn v37;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Mesh NewSkeletonMesh()
		{
			Mesh mesh = new Mesh();
			mesh.MarkDynamic();
			mesh.name = "Skeleton Mesh";
			mesh.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			return mesh;
		}
	}
}
