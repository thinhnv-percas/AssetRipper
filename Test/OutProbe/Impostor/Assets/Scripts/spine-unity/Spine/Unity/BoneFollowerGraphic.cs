using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[AddComponentMenu("Spine/UI/BoneFollowerGraphic")]
	[HelpURL("http://esotericsoftware.com/spine-unity#BoneFollowerGraphic")]
	[Token(Token = "0x2000076")]
	public class BoneFollowerGraphic : MonoBehaviour
	{
		[Token(Token = "0x40002D2")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonGraphic skeletonGraphic;

		[Token(Token = "0x40002D3")]
		[FieldOffset(Offset = "0x28")]
		public bool initializeOnAwake;

		[SpineBone(null, "skeletonGraphic", true, false)]
		[Token(Token = "0x40002D4")]
		[FieldOffset(Offset = "0x30")]
		public string boneName;

		[Token(Token = "0x40002D5")]
		[FieldOffset(Offset = "0x38")]
		public bool followBoneRotation;

		[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
		[Token(Token = "0x40002D6")]
		[FieldOffset(Offset = "0x39")]
		public bool followSkeletonFlip;

		[Tooltip("Follows the target bone's local scale. BoneFollower cannot inherit world/skewed scale because of UnityEngine.Transform property limitations.")]
		[Token(Token = "0x40002D7")]
		[FieldOffset(Offset = "0x3A")]
		public bool followLocalScale;

		[Token(Token = "0x40002D8")]
		[FieldOffset(Offset = "0x3B")]
		public bool followXYPosition;

		[Token(Token = "0x40002D9")]
		[FieldOffset(Offset = "0x3C")]
		public bool followZPosition;

		[NonSerialized]
		[Token(Token = "0x40002DA")]
		[FieldOffset(Offset = "0x40")]
		public Bone bone;

		[Token(Token = "0x40002DB")]
		[FieldOffset(Offset = "0x48")]
		private Transform skeletonTransform;

		[Token(Token = "0x40002DC")]
		[FieldOffset(Offset = "0x50")]
		private bool skeletonTransformIsParent;

		[NonSerialized]
		[Token(Token = "0x40002DD")]
		[FieldOffset(Offset = "0x51")]
		public bool valid;

		[Token(Token = "0x1700017F")]
		public SkeletonGraphic SkeletonGraphic
		{
			[Token(Token = "0x60004D0")]
			[Address(RVA = "0x1554B90", Offset = "0x1554B90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonGraphic;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonGraphic;
			}
			[Token(Token = "0x60004D1")]
			[Address(RVA = "0x1554B98", Offset = "0x1554B98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skeletonGraphic = value;\n\tSpine.Unity.BoneFollowerGraphic::Initialize(this);\n\treturn;\n")]
			set
			{
				skeletonGraphic = value;
				Initialize();
			}
		}

		[Token(Token = "0x60004D2")]
		[Address(RVA = "0x1554CA4", Offset = "0x1554CA4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = \"Bone not found: \";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BEC]) = v37;\nL_0015:\n\tv38 = this.skeletonGraphic;\n\tv49 = Spine.Skeleton::FindBone(v38.skeleton, name);\n\tthis.bone = v49;\n\tv51 = v49 == 0;\n\tif (v51) goto L_0029;\n\tthis.boneName = name;\n\tgoto L_003E;\nL_0029:\n\tv105 = System.String::Concat(\"Bone not found: \", name);\n\tgoto L_0037;\n\tv119 = v114;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v119, v102, v103, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0037:\n\tUnityEngine.Debug::LogError(v105, this);\nL_003E:\n\tv70 = v49 == 0;\n\tv55 = ~v70;\n\treturn v55;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool SetBone(string name)
		{
			SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
			Bone bone = (this.bone = skeletonGraphic.Skeleton.FindBone(name));
			if (bone != null)
			{
				boneName = name;
			}
			else
			{
				string message = "Bone not found: " + name;
				Debug.LogError(message, this);
			}
			bool flag = bone == null;
			return !flag;
		}

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0x1554D70", Offset = "0x1554D70", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.initializeOnAwake;\n\tif (v2) goto L_0005;\n\tSpine.Unity.BoneFollowerGraphic::Initialize(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			if (initializeOnAwake)
			{
				Initialize();
			}
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0x1554BA0", Offset = "0x1554BA0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37BED]) = v37;\nL_0013:\n\tthis.bone = 0;\n\tgoto L_001E;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001E:\n\tv48 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_0060;\n\tv51 = this.skeletonGraphic;\n\tv58 = v51.skeleton == 0;\n\tv63 = ~v58;\n\tthis.valid = v63;\n\tv65 = v51.skeleton == 0;\n\tif (v65) goto L_0066;\n\tv158 = UnityEngine.Component::get_transform(this.skeletonGraphic);\n\tthis.skeletonTransform = v158;\n\tv100 = UnityEngine.Component::get_transform(this);\n\tv161 = UnityEngine.Transform::get_parent(v100);\n\tv91 = v158 - v161;\n\tv85 = v91 == 0;\n\tthis.skeletonTransformIsParent = v85;\n\tv101 = System.String::IsNullOrEmpty(this.boneName);\n\tv165 = v101 == 0;\n\tv130 = ~v165;\n\tif (v130) goto L_0066;\n\tv109 = this.skeletonGraphic;\n\tv128 = Spine.Skeleton::FindBone(v109.skeleton, this.boneName);\n\tthis.bone = v128;\n\tgoto L_0066;\nL_0060:\n\tthis.valid = 0;\nL_0066:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			//IL_00d0: Expected O, but got I
			this.bone = null;
			if (this.skeletonGraphic != null)
			{
				SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
				bool flag = skeletonGraphic.Skeleton == null;
				bool flag2 = !flag;
				valid = flag2;
				if (skeletonGraphic.Skeleton != null)
				{
					Transform transform = (skeletonTransform = this.skeletonGraphic.transform);
					Transform transform2 = base.transform;
					Transform parent = transform2.parent;
					object obj = (nint)transform - (nint)parent;
					bool flag3 = obj == null;
					skeletonTransformIsParent = flag3;
					if (!string.IsNullOrEmpty(boneName))
					{
						SkeletonGraphic skeletonGraphic2 = this.skeletonGraphic;
						Bone bone = skeletonGraphic2.Skeleton.FindBone(boneName);
						this.bone = bone;
					}
				}
			}
			else
			{
				valid = false;
			}
		}

		[Token(Token = "0x60004D5")]
		[Address(RVA = "0x1554D90", Offset = "0x1554D90", Length = "0x508")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = UnityEngine.Object;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv74 = UnityEngine.RectTransform;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37BEE]) = v52;\nL_0020:\n\tv54 = ~this.valid;\n\tif (v54) goto L_004C;\n\tv59 = this.bone == 0;\n\tif (v59) goto L_0050;\nL_0027:\n\tv87 = UnityEngine.Component::get_transform(this);\n\tv91 = v87 == 0;\n\tif (v91) goto L_FFFFFFFF;\n\tv336 = *([v87 @ X0_v14 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v336) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006E;\nL_004C:\n\tSpine.Unity.BoneFollowerGraphic::Initialize(this);\n\treturn;\nL_0050:\n\tv90 = System.String::IsNullOrEmpty(this.boneName);\n\tv93 = v90 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_01EE;\n\tv84 = this.skeletonGraphic;\n\tv592 = Spine.Skeleton::FindBone(v84.skeleton, this.boneName);\n\tthis.bone = v592;\n\tv80 = Spine.Unity.BoneFollowerGraphic::SetBone(this, this.boneName);\n\tv597 = v80 == 0;\n\tv82 = ~v597;\n\tif (v82) goto L_0027;\n\tgoto L_01EE;\nL_006E:\n\tgoto L_0073;\n\tv588 = \"il2cpp_codegen_runtime_class_init\"(v431, v86, v75, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0073:\n\tv419 = UnityEngine.Object::op_Equality(v425, 0);\n\tv594 = v419 == 0;\n\tv421 = ~v594;\n\tif (v421) goto L_01EE;\n\tv599 = UnityEngine.UI.Graphic::get_canvas(this.skeletonGraphic);\n\tgoto L_0088;\n\tv602 = v574;\n\tv603 = \"il2cpp_codegen_runtime_class_init\"(v602, v598, v377, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0088:\n\tv606 = UnityEngine.Object::op_Equality(v599, 0);\n\tv608 = v606 == 0;\n\tif (v608) goto L_0098;\n\tv613 = UnityEngine.Component::GetComponentInParent(this.skeletonGraphic);\nL_0098:\n\tgoto L_009D;\n\tv621 = \"il2cpp_codegen_runtime_class_init\"(v617, v610, v486, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_009D:\n\tv542 = UnityEngine.Object::op_Inequality(v506, 0);\n\tv625 = v542 == 0;\n\tif (v625) goto L_FFFFFFFF;\n\tv630 = UnityEngine.Canvas::get_referencePixelsPerUnit(v506);\n\tgoto L_00AB;\nL_00AB:\n\tv635 = ~this.skeletonTransformIsParent;\n\tif (v635) goto L_00B6;\n\tv636 = ~this.followXYPosition;\n\tif (v636) goto L_017B;\n\tv576 = this.bone;\n\tv638 = v495 * v576.worldX;\n\tgoto L_0182;\nL_00B6:\n\tv577 = this.bone;\n\tv644 = v495 * v577.worldY;\n\tv645 = v495 * v577.worldX;\n\t// 194 MakeStruct v458 @ AGG1558FAC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v645 @ V0_v10 (System.Single), v644 @ V1_v7 (System.Single), 0\n\tv477 = UnityEngine.Transform::TransformPoint(this.skeletonTransform, v458);\n\tv468 = v477.z;\n\tv654 = ~this.followZPosition;\n\tv655 = ~v654;\n\tif (v655) goto L_00D5;\n\tv663 = UnityEngine.Transform::get_position(v425);\n\tv468 = v663.z;\nL_00D5:\n\tv667 = ~this.followXYPosition;\n\tv668 = ~v667;\n\tif (v668) goto L_00EA;\n\tv687 = UnityEngine.Transform::get_position(v425);\n\tv677 = UnityEngine.Transform::get_position(v425);\nL_00EA:\n\tv480 = Spine.Bone::get_WorldRotationX(this.bone);\n\tv710 = UnityEngine.Transform::get_parent(v425);\n\tgoto L_00FC;\n\tv753 = v580;\n\tv754 = \"il2cpp_codegen_runtime_class_init\"(v753, v709, v487, v36, v37, v38, v39, v40, v480, v461, v469, v44, v45, v46, v47, v48);\nL_00FC:\n\tv547 = UnityEngine.Object::op_Inequality(v710, 0);\n\tv764 = v547 == 0;\n\tif (v764) goto L_012A;\n\tv817 = UnityEngine.Transform::get_localToWorldMatrix(v710);\n\tv803 = v817.m00 * v817.m11;\n\tv825 = v817.m10 * v817.m01;\n\tv805 = v803 - v825;\n\tv785 = v805 >= 0;\n\tif (v785) goto L_012A;\n\tv494 = -v480;\nL_012A:\n\tv744 = ~this.followBoneRotation;\n\tif (v744) goto L_01AF;\n\tv827 = UnityEngine.Transform::get_rotation(this.skeletonTransform);\n\tv832 = UnityEngine.Quaternion::Internal_ToEulerRad(v827);\n\tv836 = v832 * 57.29578f;\n\tv837 = v832.y * 57.29578f;\n\tv838 = v832.z * 57.29578f;\n\t// 319 MakeStruct v436 @ AGG15590BC_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v836 @ V0_v19 (System.Single), v837 @ V1_v15 (System.Single), v838 @ V2_v14 (System.Single)\n\tv482 = UnityEngine.Quaternion::Internal_MakePositive(v436);\n\tv840 = UnityEngine.Transform::get_rotation(this.skeletonTransform);\n\tv845 = UnityEngine.Quaternion::Internal_ToEulerRad(v840);\n\tv848 = v845 * 57.29578f;\n\tv849 = v845.y * 57.29578f;\n\tv850 = v845.z * 57.29578f;\n\t// 342 MakeStruct v723 @ AGG15590F0_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v848 @ V0_v23 (System.Single), v849 @ V1_v19 (System.Single), v850 @ V2_v18 (System.Single)\n\tv852 = UnityEngine.Quaternion::Internal_MakePositive(v723);\n\tv856 = v494 + v852.z;\n\tv858 = v482 * 0.017453292f;\n\tv859 = v482.y * 0.017453292f;\n\tv860 = v856 * 0.017453292f;\n\t// 353 MakeStruct v722 @ AGG1559110_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v858 @ V0_v25 (System.Single), v859 @ V1_v21 (System.Single), v860 @ V2_v21 (System.Single)\n\tv861 = UnityEngine.Quaternion::Internal_FromEulerRad(v722);\n\t// 371 MakeStruct v717 @ AGG1559148_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v500 @ V9_v13 (UnityEngine.Vector3), v491 @ V10_v9 (System.Single), v468 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::SetPositionAndRotation(v425, v717, v861);\n\tgoto L_01B2;\nL_017B:\n\tv641 = UnityEngine.Transform::get_localPosition(v425);\n\tv651 = ~this.followXYPosition;\n\tif (v651) goto L_01F1;\nL_0182:\n\tv584 = this.bone;\n\tv497 = v495 * v584.worldY;\nL_0188:\n\tv674 = ~this.followZPosition;\n\tif (v674) goto L_0193;\n\tv684 = v425 == 0;\n\tv569 = ~v684;\n\tif (v569) goto L_019A;\n\tgoto L_01F6;\nL_0193:\n\tv693 = UnityEngine.Transform::get_localPosition(v425);\n\tv690 = v693.z;\nL_019A:\n\t// 410 MakeStruct v703 @ AGG15591B0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v502 @ V9_v15 (UnityEngine.Vector3), v497 @ V8_v11 (System.Single), v690 @ V2_v29 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v425, v703);\n\tv707 = ~this.followBoneRotation;\n\tif (v707) goto L_01B2;\n\tv713 = Spine.Unity.SkeletonExtensions::GetQuaternion(this.bone);\n\tUnityEngine.Transform::set_localRotation(v425, v713);\n\tgoto L_01B2;\nL_01AF:\n\t// 431 MakeStruct v714 @ AGG15591EC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v500 @ V9_v13 (UnityEngine.Vector3), v491 @ V10_v9 (System.Single), v468 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_position(v425, v714);\nL_01B2:\n\tv748 = ~this.followLocalScale;\n\tif (v748) goto L_FFFFFFFF;\n\tv586 = this.bone;\n\tv389 = v586.scaleX;\n\tv391 = v586.scaleY;\n\tgoto L_01BD;\nL_01BD:\n\tv762 = ~this.followSkeletonFlip;\n\tif (v762) goto L_01DF;\n\tv587 = this.bone;\n\tv553 = v587.skeleton;\n\tv822 = Spine.Skeleton::get_ScaleY(v587.skeleton);\n\tv769 = v553.scaleX * v822;\n\tv767 = -v391;\n\tv773 = v769 < 0;\n\tif (v773) goto L_FFFFFFFF;\n\tgoto L_01DF;\nL_01DF:\n\t// 479 MakeStruct v339 @ AGG1559258_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v389 @ V8_v7 (System.Single), v391 @ V9_v7 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v425, v339);\nL_01EE:\n\treturn;\nL_01F1:\n\tv660 = UnityEngine.Transform::get_localPosition(v425);\n\tgoto L_0188;\nL_01F6:\n\tthrow System.NullReferenceException;\n// 342 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			//IL_0279: Expected O, but got F4
			UnityEngine.Object obj;
			Vector3 vector;
			float y;
			if (valid)
			{
				if (this.bone == null)
				{
					if (string.IsNullOrEmpty(boneName))
					{
						return;
					}
					SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
					Bone bone = skeletonGraphic.Skeleton.FindBone(boneName);
					this.bone = bone;
					if (!SetBone(boneName))
					{
						return;
					}
				}
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Transform transform2 = (((object)transform.GetType() != typeof(RectTransform)) ? null : transform);
					obj = transform2;
				}
				else
				{
					obj = null;
				}
				if (obj == null)
				{
					return;
				}
				Canvas canvas = this.skeletonGraphic.canvas;
				bool flag = canvas == null;
				bool flag2 = !flag;
				Canvas canvas2 = canvas;
				if (!flag2)
				{
					Canvas componentInParent = this.skeletonGraphic.GetComponentInParent<Canvas>();
					canvas2 = componentInParent;
				}
				float num;
				if (canvas2 != null)
				{
					float referencePixelsPerUnit = canvas2.referencePixelsPerUnit;
					num = referencePixelsPerUnit;
				}
				else
				{
					num = 100f;
				}
				if (skeletonTransformIsParent)
				{
					if (followXYPosition)
					{
						Bone bone2 = this.bone;
						float num2 = num * bone2.WorldX;
						vector = (Vector3)num2;
					}
					else
					{
						Vector3 localPosition = ((Transform)obj).localPosition;
						bool flag3 = !followXYPosition;
						vector = localPosition;
						if (flag3)
						{
							y = ((Transform)obj).localPosition.y;
							vector = localPosition;
							goto IL_0987;
						}
					}
					Bone bone3 = this.bone;
					y = num * bone3.WorldY;
					goto IL_0987;
				}
				Bone bone4 = this.bone;
				float y2 = num * bone4.WorldY;
				float x = num * bone4.WorldX;
				Vector3 position = default(Vector3);
				position.x = x;
				position.y = y2;
				position.z = 0f;
				Vector3 vector2 = skeletonTransform.TransformPoint(position);
				float z = vector2.z;
				if (!followZPosition)
				{
					z = ((Transform)obj).position.z;
				}
				bool flag4 = !followXYPosition;
				bool flag5 = !flag4;
				float y3 = vector2.y;
				Vector3 vector3 = vector2;
				if (!flag5)
				{
					Vector3 position2 = ((Transform)obj).position;
					y3 = ((Transform)obj).position.y;
					vector3 = position2;
				}
				float worldRotationX = this.bone.WorldRotationX;
				Transform parent = ((Transform)obj).parent;
				bool flag6 = parent != null;
				bool flag7 = !flag6;
				float num3 = worldRotationX;
				if (!flag7)
				{
					Matrix4x4 localToWorldMatrix = parent.localToWorldMatrix;
					float num4 = localToWorldMatrix.m00 * localToWorldMatrix.m11;
					float num5 = localToWorldMatrix.m10 * localToWorldMatrix.m01;
					float num6 = num4 - num5;
					bool flag8 = !(num6 < 0f);
					num3 = worldRotationX;
					if (!flag8)
					{
						num3 = 0f - worldRotationX;
					}
				}
				if (followBoneRotation)
				{
					Quaternion rotation = skeletonTransform.rotation;
					Vector3 vector4 = Quaternion.Internal_ToEulerRad(rotation);
					float x2 = vector4.x * 57.29578f;
					float y4 = vector4.y * 57.29578f;
					float z2 = vector4.z * 57.29578f;
					Vector3 euler = default(Vector3);
					euler.x = x2;
					euler.y = y4;
					euler.z = z2;
					Vector3 vector5 = Quaternion.Internal_MakePositive(euler);
					Quaternion rotation2 = skeletonTransform.rotation;
					Vector3 vector6 = Quaternion.Internal_ToEulerRad(rotation2);
					float x3 = vector6.x * 57.29578f;
					float y5 = vector6.y * 57.29578f;
					float z3 = vector6.z * 57.29578f;
					Vector3 euler2 = default(Vector3);
					euler2.x = x3;
					euler2.y = y5;
					euler2.z = z3;
					float num7 = num3 + Quaternion.Internal_MakePositive(euler2).z;
					float x4 = vector5.x * ((float)Math.PI / 180f);
					float y6 = vector5.y * ((float)Math.PI / 180f);
					float z4 = num7 * ((float)Math.PI / 180f);
					Vector3 vector7 = default(Vector3);
					vector7.x = x4;
					vector7.y = y6;
					vector7.z = z4;
					Quaternion rotation3 = Quaternion.Euler(vector7 * 57.29578f);
					Vector3 position3 = default(Vector3);
					position3.x = vector3.x;
					position3.y = y3;
					position3.z = z;
					((Transform)obj).SetPositionAndRotation(position3, rotation3);
				}
				else
				{
					Vector3 position4 = default(Vector3);
					position4.x = vector3.x;
					position4.y = y3;
					position4.z = z;
					((Transform)obj).position = position4;
				}
				goto IL_076b;
			}
			Initialize();
			return;
			IL_0987:
			float z5;
			if (followZPosition)
			{
				bool flag9 = (object)obj == null;
				bool flag10 = !flag9;
				z5 = 0f;
				if (!flag10)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				z5 = ((Transform)obj).localPosition.z;
			}
			Vector3 localPosition2 = default(Vector3);
			localPosition2.x = vector.x;
			localPosition2.y = y;
			localPosition2.z = z5;
			((Transform)obj).localPosition = localPosition2;
			if (followBoneRotation)
			{
				Quaternion quaternion = this.bone.GetQuaternion();
				((Transform)obj).localRotation = quaternion;
			}
			goto IL_076b;
			IL_076b:
			float x5;
			float num8;
			if (followLocalScale)
			{
				Bone bone5 = this.bone;
				x5 = bone5.ScaleX;
				num8 = bone5.ScaleY;
			}
			else
			{
				x5 = 1f;
				num8 = 1f;
			}
			if (followSkeletonFlip)
			{
				Bone bone6 = this.bone;
				Skeleton skeleton = bone6.Skeleton;
				float scaleY = bone6.Skeleton.ScaleY;
				float num9 = skeleton.ScaleX * scaleY;
				float num10 = 0f - num8;
				if (num9 < 0f)
				{
					num8 = num10;
				}
			}
			Vector3 localScale = default(Vector3);
			localScale.x = x5;
			localScale.y = num8;
			localScale.z = 1f;
			((Transform)obj).localScale = localScale;
		}

		[Token(Token = "0x60004D6")]
		[Address(RVA = "0x1555298", Offset = "0x1555298", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.initializeOnAwake = 1;\n\tthis.followBoneRotation = 0x101;\n\tthis.followXYPosition = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneFollowerGraphic()
		{
			initializeOnAwake = true;
			followBoneRotation = true;
			followSkeletonFlip = true;
			followXYPosition = true;
			followZPosition = true;
		}
	}
}
