using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Lean.Pool.Extras
{
	[AddComponentMenu("Lean/Pool/Lean Pooled Rigidbody2D")]
	[RequireComponent(typeof(Rigidbody2D))]
	[HelpURL("https://carloswilkes.github.io/Documentation/LeanPool#LeanPooledRigidbody2D")]
	[Token(Token = "0x200000B")]
	public class LeanPooledRigidbody2D : MonoBehaviour, IPoolable
	{
		[Token(Token = "0x600004A")]
		[Address(RVA = "0x1363154", Offset = "0x1363154", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnSpawn()
		{
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x1363158", Offset = "0x1363158", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A369A1]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tgoto L_002C;\n\tv47 = UnityEngine.Vector2;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v38, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = 1;\n\t*([1A35518]) = v51;\nL_002C:\n\tUnityEngine.Rigidbody2D::set_velocity(v40, v58.zeroVector);\n\tUnityEngine.Rigidbody2D::set_angularVelocity(v40, 0f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDespawn()
		{
			Rigidbody2D component = GetComponent<Rigidbody2D>();
			component.velocity = Vector2.zero;
			component.angularVelocity = 0f;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x13631FC", Offset = "0x13631FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LeanPooledRigidbody2D()
		{
		}
	}
}
