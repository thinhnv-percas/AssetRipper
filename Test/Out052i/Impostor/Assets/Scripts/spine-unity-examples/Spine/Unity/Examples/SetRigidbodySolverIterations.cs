using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[DisallowMultipleComponent]
	[Token(Token = "0x2000058")]
	public class SetRigidbodySolverIterations : MonoBehaviour
	{
		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x20")]
		public int solverIterations;

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x1518864", Offset = "0x1518864", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A82]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv54 = v40.Length < 1;\n\tif (v54) goto L_004C;\nL_0038:\n\tUnityEngine.Rigidbody::set_solverIterations(v40[v100 @ X21_v7 (System.Int32)], this.solverIterations);\n\tv100 = v100 + 1;\n\tv110 = v100 < v40.Length;\n\tif (v110) goto L_0038;\nL_004C:\n\treturn;\n\tv91 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
			if (componentsInChildren.Length >= 1)
			{
				int num = 0;
				do
				{
					componentsInChildren[num].solverIterations = solverIterations;
					num++;
				}
				while (num < componentsInChildren.Length);
			}
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x1518900", Offset = "0x1518900", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.solverIterations = 0x1E;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetRigidbodySolverIterations()
		{
			solverIterations = 30;
		}
	}
}
