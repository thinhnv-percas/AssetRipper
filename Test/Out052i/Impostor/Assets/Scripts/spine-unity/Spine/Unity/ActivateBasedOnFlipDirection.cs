using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x2000095")]
	public class ActivateBasedOnFlipDirection : MonoBehaviour
	{
		[Token(Token = "0x40003AF")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonRenderer skeletonRenderer;

		[Token(Token = "0x40003B0")]
		[FieldOffset(Offset = "0x28")]
		public SkeletonGraphic skeletonGraphic;

		[Token(Token = "0x40003B1")]
		[FieldOffset(Offset = "0x30")]
		public GameObject activeOnNormalX;

		[Token(Token = "0x40003B2")]
		[FieldOffset(Offset = "0x38")]
		public GameObject activeOnFlippedX;

		[Token(Token = "0x40003B3")]
		[FieldOffset(Offset = "0x40")]
		private HingeJoint2D[] jointsNormalX;

		[Token(Token = "0x40003B4")]
		[FieldOffset(Offset = "0x48")]
		private HingeJoint2D[] jointsFlippedX;

		[Token(Token = "0x40003B5")]
		[FieldOffset(Offset = "0x50")]
		private ISkeletonComponent skeletonComponent;

		[Token(Token = "0x40003B6")]
		[FieldOffset(Offset = "0x58")]
		private bool wasFlippedXBefore;

		[Token(Token = "0x6000618")]
		[Address(RVA = "0x1568AE0", Offset = "0x1568AE0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37C98]) = v34;\nL_0019:\n\tv42 = UnityEngine.GameObject::GetComponentsInChildren(this.activeOnNormalX);\n\tthis.jointsNormalX = v42;\n\tv55 = UnityEngine.GameObject::GetComponentsInChildren(this.activeOnFlippedX);\n\tthis.jointsFlippedX = v55;\n\tgoto L_002E;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v93, v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002E:\n\tv84 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv74 = v84 == 0;\n\tv62 = ~v74;\n\tv59 = ~v62;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\tthis.skeletonComponent = this->klass;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			//IL_00b2: Expected O, but got I
			HingeJoint2D[] componentsInChildren = activeOnNormalX.GetComponentsInChildren<HingeJoint2D>();
			jointsNormalX = componentsInChildren;
			HingeJoint2D[] componentsInChildren2 = activeOnFlippedX.GetComponentsInChildren<HingeJoint2D>();
			jointsFlippedX = componentsInChildren2;
			if (skeletonRenderer != null)
			{
				int num = 32;
			}
			else
			{
				int num = 40;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v104 @ X8_v7 (System.Int32)]");
			skeletonComponent = (ISkeletonComponent)0;
		}

		[Token(Token = "0x6000619")]
		[Address(RVA = "0x1568BA0", Offset = "0x1568BA0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = Spine.Unity.ISkeletonComponent;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37C99]) = v33;\nL_0019:\n\tgoto L_0040;\n\tv92 = *([v37 @ X8_v4+B0]);\n\tv93 = v92 + 8;\n\tv95 = *([v132 @ X10_v8-8]);\n\tv137 = v95 == v40;\n\tif (v137) goto L_0038;\n\tv115 = v131 - 1;\n\tv117 = v132 + 0x10;\n\tv97 = v131 != 1;\n\tif (v97) goto L_FFFFFFFF;\n\tv118 = 1;\n\tv119 = v34;\n\tv120 = 0xB349B4(v119, v40, v118, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0040;\nL_0038:\n\tv180 = *([v132 @ X10_v8]);\n\tv181 = v180 + 1;\n\tv182 = v181 << 4;\n\tv183 = v37 + v182;\n\tv184 = v183 + 0x138;\nL_0040:\n\tv86 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv191 = v86.scaleX < 0;\n\tv202 = this.wasFlippedXBefore == v191;\n\tif (v202) goto L_0065;\n\tv210 = v86.scaleX < 0;\n\tSpine.Unity.ActivateBasedOnFlipDirection::HandleFlip(this, v210);\nL_0065:\n\tthis.wasFlippedXBefore = v191;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			Skeleton skeleton = skeletonComponent.Skeleton;
			bool flag = skeleton.ScaleX < 0f;
			if (wasFlippedXBefore != flag)
			{
				bool isFlippedX = skeleton.ScaleX < 0f;
				HandleFlip(isFlippedX);
			}
			wasFlippedXBefore = flag;
		}

		[Token(Token = "0x600061A")]
		[Address(RVA = "0x1568C78", Offset = "0x1568C78", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = isFlippedX == 0;\n\tv18 = ~v13;\n\tv19 = ~v18;\n\tif (v19) goto L_FFFFFFFF;\n\tgoto L_0015;\nL_0015:\n\tv25 = ~v13;\n\tv26 = ~v25;\n\tif (v26) goto L_FFFFFFFF;\n\tgoto L_0024;\nL_0024:\n\tUnityEngine.GameObject::SetActive(*([this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v22 @ X10_v1 (System.Int32)]), 1);\n\tUnityEngine.GameObject::SetActive(*([this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]), 0);\n\tv89 = this + 0x48;\n\tv87 = this + 0x40;\n\tv95 = isFlippedX == 0;\n\tv100 = ~v95;\n\tv101 = ~v100;\n\tif (v101) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tv85 = ~v95;\n\tv83 = ~v85;\n\tif (v83) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tSpine.Unity.ActivateBasedOnFlipDirection::ResetJointPositions(*([this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]), *([v81 @ X10_v2]));\n\tSpine.Unity.ActivateBasedOnFlipDirection::ResetJointPositions(*([this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]), *([v107 @ X21_v3]));\n\tv111 = UnityEngine.GameObject::get_transform(*([this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v22 @ X10_v1 (System.Int32)]));\n\tv71 = UnityEngine.GameObject::get_transform(*([this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]));\n\tSpine.Unity.ActivateBasedOnFlipDirection::CompensateMovementAfterFlipX(v71, v111, v71);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleFlip(bool isFlippedX)
		{
			//IL_0081: Expected O, but got I
			//IL_009c: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_01a9: Expected O, but got I
			//IL_01be: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_0131: Expected O, but got I
			bool flag = !isFlippedX;
			if (!flag)
			{
				int num = 56;
			}
			else
			{
				int num = 48;
			}
			if (!flag)
			{
				int num2 = 48;
			}
			else
			{
				int num2 = 56;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v22 @ X10_v1 (System.Int32)]");
			((GameObject)0).SetActive(value: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]");
			((GameObject)0).SetActive(value: false);
			object obj = (nint)this + 72;
			object obj2 = (nint)this + 64;
			bool flag2 = !isFlippedX;
			object joints = (flag2 ? obj2 : obj);
			object joints2 = (flag2 ? obj : obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]");
			((ActivateBasedOnFlipDirection)0).ResetJointPositions((HingeJoint2D[])joints);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]");
			((ActivateBasedOnFlipDirection)0).ResetJointPositions((HingeJoint2D[])joints2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v22 @ X10_v1 (System.Int32)]");
			Transform toActivate = ((GameObject)0).transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.ActivateBasedOnFlipDirection)+v29 @ X8_v2 (System.Int32)]");
			Transform transform = ((GameObject)0).transform;
			((ActivateBasedOnFlipDirection)(object)transform).CompensateMovementAfterFlipX(toActivate, transform);
		}

		[Token(Token = "0x600061B")]
		[Address(RVA = "0x1568D30", Offset = "0x1568D30", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = joints.Length < 1;\n\tif (v26) goto L_005B;\nL_0029:\n\tv62 = UnityEngine.Joint2D::get_connectedBody(joints[v71 @ X23_v6 (System.Int32)]);\n\tv229 = UnityEngine.Component::get_transform(v62);\n\tv232 = UnityEngine.Component::get_transform(joints[v71 @ X23_v6 (System.Int32)]);\n\tv46 = UnityEngine.AnchoredJoint2D::get_connectedAnchor(joints[v71 @ X23_v6 (System.Int32)]);\n\t// 60 MakeStruct v33 @ AGG156CDB0_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v46 @ V0_v5 (UnityEngine.Vector2), v46.y (System.Single), 0\n\tv47 = UnityEngine.Transform::TransformPoint(v229, v33);\n\tUnityEngine.Transform::set_position(v232, v47);\n\tv71 = v71 + 1;\n\tv138 = v71 < joints.Length;\n\tif (v138) goto L_0029;\nL_005B:\n\treturn;\n\tv108 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetJointPositions(HingeJoint2D[] joints)
		{
			if (joints.Length >= 1)
			{
				int num = 0;
				Vector3 position = default(Vector3);
				do
				{
					Rigidbody2D connectedBody = joints[num].connectedBody;
					Transform transform = connectedBody.transform;
					Transform transform2 = joints[num].transform;
					Vector2 connectedAnchor = joints[num].connectedAnchor;
					position.x = connectedAnchor.x;
					position.y = connectedAnchor.y;
					position.z = 0f;
					Vector3 position2 = transform.TransformPoint(position);
					transform2.position = position2;
					num++;
				}
				while (num < joints.Length);
			}
		}

		[Token(Token = "0x600061C")]
		[Address(RVA = "0x1568DEC", Offset = "0x1568DEC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = UnityEngine.Transform::GetChild(toDeactivate, 0);\n\tv77 = UnityEngine.Transform::GetChild(toActivate, 0);\n\tv44 = UnityEngine.Transform::get_position(toActivate);\n\tv45 = UnityEngine.Transform::get_position(v27);\n\tv118 = UnityEngine.Transform::get_position(v77);\n\tv121 = v45 - v118;\n\tv122 = v45.y - v118.y;\n\tv123 = v45.z - v118.z;\n\tv100 = v44 + v121;\n\tv98 = v44.y + v122;\n\tv96 = v44.z + v123;\n\t// 70 MakeStruct v79 @ AGG156CEAC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v100 @ V0_v6 (System.Single), v98 @ V1_v6 (System.Single), v96 @ V2_v6 (System.Single)\n\tUnityEngine.Transform::set_position(toActivate, v79);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CompensateMovementAfterFlipX(Transform toActivate, Transform toDeactivate)
		{
			Transform child = toDeactivate.GetChild(0);
			Transform child2 = toActivate.GetChild(0);
			Vector3 position = toActivate.position;
			Vector3 position2 = child.position;
			Vector3 position3 = child2.position;
			float num = position2.x - position3.x;
			float num2 = position2.y - position3.y;
			float num3 = position2.z - position3.z;
			float x = position.x + num;
			float y = position.y + num2;
			float z = position.z + num3;
			Vector3 position4 = default(Vector3);
			position4.x = x;
			position4.y = y;
			position4.z = z;
			toActivate.position = position4;
		}

		[Token(Token = "0x600061D")]
		[Address(RVA = "0x1568EB4", Offset = "0x1568EB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActivateBasedOnFlipDirection()
		{
		}
	}
}
