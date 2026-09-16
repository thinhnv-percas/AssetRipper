using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x2000098")]
	public class FollowSkeletonUtilityRootRotation : MonoBehaviour
	{
		[Token(Token = "0x40003BC")]
		private const float FLIP_ANGLE_THRESHOLD = 100f;

		[Token(Token = "0x40003BD")]
		[FieldOffset(Offset = "0x20")]
		public Transform reference;

		[Token(Token = "0x40003BE")]
		[FieldOffset(Offset = "0x28")]
		private Vector3 prevLocalEulerAngles;

		[Token(Token = "0x6000624")]
		[Address(RVA = "0x1569080", Offset = "0x1569080", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_transform(this);\n\tv10 = UnityEngine.Transform::get_localEulerAngles(v7);\n\tthis.prevLocalEulerAngles = v10;\n\tthis.prevLocalEulerAngles.y = v10.y;\n\tthis.prevLocalEulerAngles.z = v10.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Transform transform = base.transform;
			Vector3 vector = (prevLocalEulerAngles = transform.localEulerAngles);
			prevLocalEulerAngles.y = vector.y;
			prevLocalEulerAngles.z = vector.z;
		}

		[Token(Token = "0x6000625")]
		[Address(RVA = "0x15690B0", Offset = "0x15690B0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_transform(this);\n\tv19 = UnityEngine.Transform::get_rotation(this.reference);\n\tUnityEngine.Transform::set_rotation(v13, v19);\n\tv80 = UnityEngine.Component::get_transform(this);\n\tv69 = UnityEngine.Transform::get_localEulerAngles(v80);\n\tv81 = UnityEngine.Component::get_transform(this);\n\t// 42 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv136 = UnityEngine.Transform::get_localEulerAngles(v81);\n\t// 58 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv151 = v69.y <= 0x42C80000;\n\tif (v151) goto L_004E;\n\tSpine.Unity.FollowSkeletonUtilityRootRotation::CompensatePositionToYRotation(this);\nL_004E:\n\tv22 = v69.y <= 0x42C80000;\n\tif (v22) goto L_0054;\n\tSpine.Unity.FollowSkeletonUtilityRootRotation::CompensatePositionToXRotation(this);\nL_0054:\n\tv82 = UnityEngine.Component::get_transform(this);\n\tv122 = UnityEngine.Transform::get_localEulerAngles(v82);\n\tthis.prevLocalEulerAngles = v122;\n\tthis.prevLocalEulerAngles.y = v122.y;\n\tthis.prevLocalEulerAngles.z = v122.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			Transform transform = base.transform;
			Quaternion rotation = reference.rotation;
			transform.rotation = rotation;
			Transform transform2 = base.transform;
			Vector3 localEulerAngles = transform2.localEulerAngles;
			Transform transform3 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Vector3 localEulerAngles2 = transform3.localEulerAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (localEulerAngles.y > 100f)
			{
				CompensatePositionToYRotation();
			}
			if (localEulerAngles.y > 100f)
			{
				CompensatePositionToXRotation();
			}
			Transform transform4 = base.transform;
			Vector3 vector = (prevLocalEulerAngles = transform4.localEulerAngles);
			prevLocalEulerAngles.y = vector.y;
			prevLocalEulerAngles.z = vector.z;
		}

		[Token(Token = "0x6000626")]
		[Address(RVA = "0x1569198", Offset = "0x1569198", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = UnityEngine.Transform::get_position(this.reference);\n\tv52 = UnityEngine.Transform::get_position(this.reference);\n\tv67 = UnityEngine.Component::get_transform(this);\n\tv53 = UnityEngine.Transform::get_position(v67);\n\tv68 = UnityEngine.Component::get_transform(this);\n\tv54 = UnityEngine.Transform::get_position(v68);\n\tv69 = UnityEngine.Component::get_transform(this);\n\tv119 = v52.z - v53.z;\n\tv120 = v52 - v53;\n\tv103 = v23.z + v119;\n\tv107 = v23 + v120;\n\t// 71 MakeStruct v84 @ AGG156D258_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v107 @ V0_v7 (System.Single), v54.y (System.Single), v103 @ V2_v6 (System.Single)\n\tUnityEngine.Transform::set_position(v69, v84);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CompensatePositionToYRotation()
		{
			Vector3 position = reference.position;
			Vector3 position2 = reference.position;
			Transform transform = base.transform;
			Vector3 position3 = transform.position;
			Transform transform2 = base.transform;
			Vector3 position4 = transform2.position;
			Transform transform3 = base.transform;
			float num = position2.z - position3.z;
			float num2 = position2.x - position3.x;
			float z = position.z + num;
			float x = position.x + num2;
			Vector3 position5 = default(Vector3);
			position5.x = x;
			position5.y = position4.y;
			position5.z = z;
			transform3.position = position5;
		}

		[Token(Token = "0x6000627")]
		[Address(RVA = "0x1569260", Offset = "0x1569260", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = UnityEngine.Transform::get_position(this.reference);\n\tv52 = UnityEngine.Transform::get_position(this.reference);\n\tv67 = UnityEngine.Component::get_transform(this);\n\tv53 = UnityEngine.Transform::get_position(v67);\n\tv68 = UnityEngine.Component::get_transform(this);\n\tv54 = UnityEngine.Transform::get_position(v68);\n\tv69 = UnityEngine.Component::get_transform(this);\n\tv119 = v52.z - v53.z;\n\tv120 = v52.y - v53.y;\n\tv103 = v23.z + v119;\n\tv105 = v23.y + v120;\n\t// 71 MakeStruct v84 @ AGG156D320_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v54 @ V0_v5 (UnityEngine.Vector3), v105 @ V1_v7 (System.Single), v103 @ V2_v6 (System.Single)\n\tUnityEngine.Transform::set_position(v69, v84);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CompensatePositionToXRotation()
		{
			Vector3 position = reference.position;
			Vector3 position2 = reference.position;
			Transform transform = base.transform;
			Vector3 position3 = transform.position;
			Transform transform2 = base.transform;
			Vector3 position4 = transform2.position;
			Transform transform3 = base.transform;
			float num = position2.z - position3.z;
			float num2 = position2.y - position3.y;
			float z = position.z + num;
			float y = position.y + num2;
			Vector3 position5 = default(Vector3);
			position5.x = position4.x;
			position5.y = y;
			position5.z = z;
			transform3.position = position5;
		}

		[Token(Token = "0x6000628")]
		[Address(RVA = "0x1569328", Offset = "0x1569328", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FollowSkeletonUtilityRootRotation()
		{
		}
	}
}
