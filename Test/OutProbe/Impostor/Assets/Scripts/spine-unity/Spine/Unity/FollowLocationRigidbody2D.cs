using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[RequireComponent(typeof(Rigidbody2D))]
	[Token(Token = "0x2000097")]
	public class FollowLocationRigidbody2D : MonoBehaviour
	{
		[Token(Token = "0x40003B9")]
		[FieldOffset(Offset = "0x20")]
		public Transform reference;

		[Token(Token = "0x40003BA")]
		[FieldOffset(Offset = "0x28")]
		public bool followFlippedX;

		[Token(Token = "0x40003BB")]
		[FieldOffset(Offset = "0x30")]
		private Rigidbody2D ownRigidbody;

		[Token(Token = "0x6000621")]
		[Address(RVA = "0x1568F74", Offset = "0x1568F74", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C9B]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.ownRigidbody = v40;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Rigidbody2D component = GetComponent<Rigidbody2D>();
			ownRigidbody = component;
		}

		[Token(Token = "0x6000622")]
		[Address(RVA = "0x1568FC4", Offset = "0x1568FC4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Transform::get_rotation(this.reference);\n\tv74 = UnityEngine.Quaternion::Internal_ToEulerRad(v15);\n\tv77 = v74 * 57.29578f;\n\tv78 = v74.y * 57.29578f;\n\tv79 = v74.z * 57.29578f;\n\t// 27 MakeStruct v18 @ AGG156D008_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v77 @ V0_v4 (System.Single), v78 @ V1_v4 (System.Single), v79 @ V2_v4 (System.Single)\n\tv41 = UnityEngine.Quaternion::Internal_MakePositive(v18);\n\tv32 = v41.z;\n\tv103 = ~this.followFlippedX;\n\tif (v103) goto L_002F;\n\tv107 = 0x43870000 - v41.z;\n\tv109 = 0x1854EF0(0, 0, v60, v61, v62, v63, v64, v65, v107, 0x43B40000, v41.z, 57.29578f, v66, v67, v68, v69);\n\tv32 = v107 + 0xC2B40000;\nL_002F:\n\tUnityEngine.Rigidbody2D::set_rotation(this.ownRigidbody, v32);\n\tv43 = UnityEngine.Transform::get_position(this.reference);\n\t// 65 MakeStruct v81 @ AGG156D070_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v43 @ V0_v8 (UnityEngine.Vector3), v43.y (System.Single)\n\tUnityEngine.Rigidbody2D::set_position(this.ownRigidbody, v81);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected O, but got Unknown
			Quaternion rotation = reference.rotation;
			Vector3 vector = Quaternion.Internal_ToEulerRad(rotation);
			float x = vector.x * 57.29578f;
			float y = vector.y * 57.29578f;
			float z = vector.z * 57.29578f;
			Vector3 euler = default(Vector3);
			euler.x = x;
			euler.y = y;
			euler.z = z;
			Vector3 vector2 = Quaternion.Internal_MakePositive(euler);
			float rotation2 = vector2.z;
			if (followFlippedX)
			{
				float num = 270f - vector2.z;
				object obj = num % 1135869952;
				rotation2 = num + -90f;
			}
			ownRigidbody.rotation = rotation2;
			Vector3 position = reference.position;
			Vector2 position2 = default(Vector2);
			position2.x = position.x;
			position2.y = position.y;
			ownRigidbody.position = position2;
		}

		[Token(Token = "0x6000623")]
		[Address(RVA = "0x1569078", Offset = "0x1569078", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FollowLocationRigidbody2D()
		{
		}
	}
}
