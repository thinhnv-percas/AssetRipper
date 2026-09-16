using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[RequireComponent(typeof(Rigidbody))]
	[Token(Token = "0x2000096")]
	public class FollowLocationRigidbody : MonoBehaviour
	{
		[Token(Token = "0x40003B7")]
		[FieldOffset(Offset = "0x20")]
		public Transform reference;

		[Token(Token = "0x40003B8")]
		[FieldOffset(Offset = "0x28")]
		private Rigidbody ownRigidbody;

		[Token(Token = "0x600061E")]
		[Address(RVA = "0x1568EBC", Offset = "0x1568EBC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C9A]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.ownRigidbody = v40;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Rigidbody component = GetComponent<Rigidbody>();
			ownRigidbody = component;
		}

		[Token(Token = "0x600061F")]
		[Address(RVA = "0x1568F0C", Offset = "0x1568F0C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Transform::get_rotation(this.reference);\n\tUnityEngine.Rigidbody::set_rotation(this.ownRigidbody, v12);\n\tv29 = UnityEngine.Transform::get_position(this.reference);\n\tUnityEngine.Rigidbody::set_position(this.ownRigidbody, v29);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			Quaternion rotation = reference.rotation;
			ownRigidbody.rotation = rotation;
			Vector3 position = reference.position;
			ownRigidbody.position = position;
		}

		[Token(Token = "0x6000620")]
		[Address(RVA = "0x1568F6C", Offset = "0x1568F6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FollowLocationRigidbody()
		{
		}
	}
}
