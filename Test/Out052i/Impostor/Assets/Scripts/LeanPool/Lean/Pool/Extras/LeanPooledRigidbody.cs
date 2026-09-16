using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Lean.Pool.Extras
{
	[HelpURL("https://carloswilkes.github.io/Documentation/LeanPool#LeanPooledRigidbody")]
	[AddComponentMenu("Lean/Pool/Lean Pooled Rigidbody")]
	[RequireComponent(typeof(Rigidbody))]
	[Token(Token = "0x200000A")]
	public class LeanPooledRigidbody : MonoBehaviour, IPoolable
	{
		[Token(Token = "0x6000047")]
		[Address(RVA = "0x1363078", Offset = "0x1363078", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnSpawn()
		{
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x136307C", Offset = "0x136307C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A369A0]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tgoto L_002D;\n\tv47 = UnityEngine.Vector3;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v38, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = 1;\n\t*([1A35519]) = v51;\nL_002D:\n\tUnityEngine.Rigidbody::set_velocity(v40, v58.zeroVector);\n\tgoto L_0044;\n\tv68 = UnityEngine.Vector3;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, v56, v21, v22, v23, v24, v25, v26, v61, v59, v60, v30, v31, v32, v33, v34);\n\tv72 = 1;\n\t*([1A35519]) = v72;\nL_0044:\n\tUnityEngine.Rigidbody::set_angularVelocity(v40, v78.zeroVector);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDespawn()
		{
			Rigidbody component = GetComponent<Rigidbody>();
			component.velocity = Vector3.zero;
			component.angularVelocity = Vector3.zero;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x136314C", Offset = "0x136314C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LeanPooledRigidbody()
		{
		}
	}
}
