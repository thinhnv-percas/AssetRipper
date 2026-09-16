using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity
{
	[AddComponentMenu("Spine/BoneFollower")]
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#BoneFollower")]
	[Token(Token = "0x2000075")]
	public class BoneFollower : MonoBehaviour
	{
		[Token(Token = "0x40002C6")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonRenderer skeletonRenderer;

		[SpineBone(null, "skeletonRenderer", true, false)]
		[Token(Token = "0x40002C7")]
		[FieldOffset(Offset = "0x28")]
		public string boneName;

		[Token(Token = "0x40002C8")]
		[FieldOffset(Offset = "0x30")]
		public bool followXYPosition;

		[Token(Token = "0x40002C9")]
		[FieldOffset(Offset = "0x31")]
		public bool followZPosition;

		[Token(Token = "0x40002CA")]
		[FieldOffset(Offset = "0x32")]
		public bool followBoneRotation;

		[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
		[Token(Token = "0x40002CB")]
		[FieldOffset(Offset = "0x33")]
		public bool followSkeletonFlip;

		[Tooltip("Follows the target bone's local scale. BoneFollower cannot inherit world/skewed scale because of UnityEngine.Transform property limitations.")]
		[Token(Token = "0x40002CC")]
		[FieldOffset(Offset = "0x34")]
		public bool followLocalScale;

		[FormerlySerializedAs("resetOnAwake")]
		[Token(Token = "0x40002CD")]
		[FieldOffset(Offset = "0x35")]
		public bool initializeOnAwake;

		[NonSerialized]
		[Token(Token = "0x40002CE")]
		[FieldOffset(Offset = "0x36")]
		public bool valid;

		[NonSerialized]
		[Token(Token = "0x40002CF")]
		[FieldOffset(Offset = "0x38")]
		public Bone bone;

		[Token(Token = "0x40002D0")]
		[FieldOffset(Offset = "0x40")]
		private Transform skeletonTransform;

		[Token(Token = "0x40002D1")]
		[FieldOffset(Offset = "0x48")]
		private bool skeletonTransformIsParent;

		[Token(Token = "0x1700017E")]
		public SkeletonRenderer SkeletonRenderer
		{
			[Token(Token = "0x60004C7")]
			[Address(RVA = "0x15541EC", Offset = "0x15541EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonRenderer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonRenderer;
			}
			[Token(Token = "0x60004C8")]
			[Address(RVA = "0x15541F4", Offset = "0x15541F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skeletonRenderer = value;\n\tSpine.Unity.BoneFollower::Initialize(this);\n\treturn;\n")]
			set
			{
				skeletonRenderer = value;
				Initialize();
			}
		}

		[Token(Token = "0x60004C9")]
		[Address(RVA = "0x1554380", Offset = "0x1554380", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = \"Bone not found: \";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BE8]) = v37;\nL_0015:\n\tv38 = this.skeletonRenderer;\n\tv49 = Spine.Skeleton::FindBone(v38.skeleton, name);\n\tthis.bone = v49;\n\tv51 = v49 == 0;\n\tif (v51) goto L_0029;\n\tthis.boneName = name;\n\tgoto L_003E;\nL_0029:\n\tv105 = System.String::Concat(\"Bone not found: \", name);\n\tgoto L_0037;\n\tv119 = v114;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v119, v102, v103, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0037:\n\tUnityEngine.Debug::LogError(v105, this);\nL_003E:\n\tv70 = v49 == 0;\n\tv55 = ~v70;\n\treturn v55;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool SetBone(string name)
		{
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			Bone bone = (this.bone = skeletonRenderer.skeleton.FindBone(name));
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

		[Token(Token = "0x60004CA")]
		[Address(RVA = "0x155444C", Offset = "0x155444C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.initializeOnAwake;\n\tif (v2) goto L_0005;\n\tSpine.Unity.BoneFollower::Initialize(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			if (initializeOnAwake)
			{
				Initialize();
			}
		}

		[Token(Token = "0x60004CB")]
		[Address(RVA = "0x155445C", Offset = "0x155445C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.BoneFollower::Initialize(this);\n\treturn;\n")]
		public void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer)
		{
			Initialize();
		}

		[Token(Token = "0x60004CC")]
		[Address(RVA = "0x15541FC", Offset = "0x15541FC", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = UnityEngine.Object;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37BE9]) = v42;\nL_001B:\n\tthis.bone = 0;\n\tgoto L_0026;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tv56 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv60 = v56 == 0;\n\tif (v60) goto L_0079;\n\tv61 = this.skeletonRenderer;\n\tthis.valid = v61.valid;\n\tv64 = ~v61.valid;\n\tif (v64) goto L_0081;\n\tv178 = UnityEngine.Component::get_transform(this.skeletonRenderer);\n\tthis.skeletonTransform = v178;\n\tv106 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v106, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v106);\n\tv107 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v107, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::add_OnRebuild(this.skeletonRenderer, v107);\n\tv108 = UnityEngine.Component::get_transform(this);\n\tv189 = UnityEngine.Transform::get_parent(v108);\n\tv88 = this.skeletonTransform - v189;\n\tv82 = v88 == 0;\n\tthis.skeletonTransformIsParent = v82;\n\tv109 = System.String::IsNullOrEmpty(this.boneName);\n\tv193 = v109 == 0;\n\tv146 = ~v193;\n\tif (v146) goto L_0081;\n\tv119 = this.skeletonRenderer;\n\tv144 = Spine.Skeleton::FindBone(v119.skeleton, this.boneName);\n\tthis.bone = v144;\n\tgoto L_0081;\nL_0079:\n\tthis.valid = 0;\nL_0081:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			//IL_0108: Expected O, but got I
			this.bone = null;
			if (this.skeletonRenderer != null)
			{
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				valid = skeletonRenderer.valid;
				if (skeletonRenderer.valid)
				{
					Transform transform = this.skeletonRenderer.transform;
					skeletonTransform = transform;
					SkeletonRenderer.SkeletonRendererDelegate value = HandleRebuildRenderer;
					this.skeletonRenderer.OnRebuild -= value;
					SkeletonRenderer.SkeletonRendererDelegate value2 = HandleRebuildRenderer;
					this.skeletonRenderer.OnRebuild += value2;
					Transform transform2 = base.transform;
					Transform parent = transform2.parent;
					object obj = (nint)skeletonTransform - (nint)parent;
					bool flag = obj == null;
					skeletonTransformIsParent = flag;
					if (!string.IsNullOrEmpty(boneName))
					{
						SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
						Bone bone = skeletonRenderer2.skeleton.FindBone(boneName);
						this.bone = bone;
					}
				}
			}
			else
			{
				valid = false;
			}
		}

		[Token(Token = "0x60004CD")]
		[Address(RVA = "0x1554698", Offset = "0x1554698", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37BEA]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_0042;\n\tv61 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v61, this, Il2CppMethodInfo);\n\tv80 = this.skeletonRenderer == 0;\n\tif (v80) goto L_0043;\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v61);\n\treturn;\nL_0042:\n\treturn;\nL_0043:\n\tthrow v61;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (skeletonRenderer != null)
			{
				SkeletonRenderer.SkeletonRendererDelegate skeletonRendererDelegate = HandleRebuildRenderer;
				if ((object)skeletonRenderer == null)
				{
					throw skeletonRendererDelegate;
				}
				skeletonRenderer.OnRebuild -= skeletonRendererDelegate;
			}
		}

		[Token(Token = "0x60004CE")]
		[Address(RVA = "0x1554760", Offset = "0x1554760", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = UnityEngine.Object;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37BEB]) = v43;\nL_0016:\n\tv45 = ~this.valid;\n\tif (v45) goto L_0034;\n\tv47 = this.bone == 0;\n\tif (v47) goto L_0038;\nL_001D:\n\tv69 = UnityEngine.Component::get_transform(this);\n\tv75 = ~this.skeletonTransformIsParent;\n\tif (v75) goto L_004F;\n\tv295 = ~this.followXYPosition;\n\tif (v295) goto L_0112;\n\tv515 = this.bone;\n\tgoto L_011C;\nL_0034:\n\tSpine.Unity.BoneFollower::Initialize(this);\n\treturn;\nL_0038:\n\tv72 = System.String::IsNullOrEmpty(this.boneName);\n\tv77 = v72 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_019B;\n\tv66 = this.skeletonRenderer;\n\tv507 = Spine.Skeleton::FindBone(v66.skeleton, this.boneName);\n\tthis.bone = v507;\n\tv62 = Spine.Unity.BoneFollower::SetBone(this, this.boneName);\n\tv540 = v62 == 0;\n\tv64 = ~v540;\n\tif (v64) goto L_001D;\n\tgoto L_019B;\nL_004F:\n\tv296 = this.bone;\n\t// 89 MakeStruct v407 @ AGG1558858_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v296.worldX (System.Single), v296.worldY (System.Single), 0\n\tv418 = UnityEngine.Transform::TransformPoint(this.skeletonTransform, v407);\n\tv409 = v418.z;\n\tv519 = ~this.followZPosition;\n\tv520 = ~v519;\n\tif (v520) goto L_006C;\n\tv532 = UnityEngine.Transform::get_position(v69);\n\tv409 = v532.z;\nL_006C:\n\tv537 = ~this.followXYPosition;\n\tv538 = ~v537;\n\tif (v538) goto L_0081;\n\tv563 = UnityEngine.Transform::get_position(v69);\n\tv543 = UnityEngine.Transform::get_position(v69);\nL_0081:\n\tv421 = Spine.Bone::get_WorldRotationX(this.bone);\n\tv625 = UnityEngine.Transform::get_parent(v69);\n\tgoto L_0095;\n\tv644 = v494;\n\tv645 = \"il2cpp_codegen_runtime_class_init\"(v644, v624, v57, v28, v29, v30, v31, v32, v421, v430, v410, v36, v37, v38, v39, v40);\nL_0095:\n\tv469 = UnityEngine.Object::op_Inequality(v625, 0);\n\tv688 = v469 == 0;\n\tif (v688) goto L_00C3;\n\tv721 = UnityEngine.Transform::get_localToWorldMatrix(v625);\n\tv717 = v721.m00 * v721.m11;\n\tv730 = v721.m10 * v721.m01;\n\tv716 = v717 - v730;\n\tv689 = v716 >= 0;\n\tif (v689) goto L_00C3;\n\tv607 = -v421;\nL_00C3:\n\tv615 = ~this.followBoneRotation;\n\tif (v615) goto L_0160;\n\tv732 = UnityEngine.Transform::get_rotation(this.skeletonTransform);\n\tv737 = UnityEngine.Quaternion::Internal_ToEulerRad(v732);\n\tv741 = v737 * 57.29578f;\n\tv742 = v737.y * 57.29578f;\n\tv743 = v737.z * 57.29578f;\n\t// 216 MakeStruct v368 @ AGG1558970_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v741 @ V0_v17 (System.Single), v742 @ V1_v15 (System.Single), v743 @ V2_v13 (System.Single)\n\tv423 = UnityEngine.Quaternion::Internal_MakePositive(v368);\n\tv745 = ~this.followLocalScale;\n\tif (v745) goto L_00F3;\n\tv496 = this.bone;\n\tv746 = v496.scaleX >= 0;\n\tif (v746) goto L_00F3;\n\tv607 = v607 + 0x43340000;\nL_00F3:\n\tv762 = v423.z + v607;\n\tv764 = v423 * 0.017453292f;\n\tv765 = v423.y * 0.017453292f;\n\tv766 = v762 * 0.017453292f;\n\t// 248 MakeStruct v569 @ AGG15589B8_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v764 @ V0_v19 (System.Single), v765 @ V1_v17 (System.Single), v766 @ V2_v16 (System.Single)\n\tv767 = UnityEngine.Quaternion::Internal_FromEulerRad(v569);\n\t// 266 MakeStruct v573 @ AGG15589F0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v444 @ V9_v13 (UnityEngine.Vector3), v439 @ V10_v9 (System.Single), v409 @ V2_v7 (System.Single)\n\tUnityEngine.Transform::SetPositionAndRotation(v69, v573, v767);\n\tgoto L_0163;\nL_0112:\n\tv424 = UnityEngine.Transform::get_localPosition(v69);\n\tv518 = ~this.followXYPosition;\n\tif (v518) goto L_019E;\n\tv515 = this.bone;\nL_011C:\n\tv445 = v515.worldY;\nL_011E:\n\tv530 = ~this.followZPosition;\n\tif (v530) goto L_0129;\n\tv541 = v69 == 0;\n\tv486 = ~v541;\n\tif (v486) goto L_0130;\n\tgoto L_01A3;\nL_0129:\n\tv553 = UnityEngine.Transform::get_localPosition(v69);\n\tv416 = v553.z;\nL_0130:\n\t// 304 MakeStruct v367 @ AGG1558A54_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v452 @ V8_v10 (UnityEngine.Vector3), v445 @ V9_v15 (System.Single), v416 @ V2_v24 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v69, v367);\n\tv564 = ~this.followBoneRotation;\n\tif (v564) goto L_0163;\n\tv449 = this.bone;\n\tv628 = 0x1854F00(v69, 0, 0, v28, v29, v30, v31, v32, v449.c, v449.a, v416, v36, v37, v38, v39, v40);\n\tv659 = v449.c * 0.5f;\n\tv617 = ~this.followLocalScale;\n\tif (v617) goto L_0151;\n\tv661 = v449.scaleX;\n\tv658 = v449.scaleX >= 0;\n\tif (v658) goto L_0151;\n\tv659 = v659 + 1.5707964f;\nL_0151:\n\tv666 = 0x1854F30(&v568 @ stack_-84_v4, &v567 @ stack_-88_v4, 0, v28, v29, v30, v31, v32, v659, v661, v416, v36, v37, v38, v39, v40);\n\t// 344 MakeStruct v571 @ AGG1558ABC_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, v568 @ stack_-84_v4, v567 @ stack_-88_v4\n\tUnityEngine.Transform::set_localRotation(v69, v571);\n\tgoto L_0163;\nL_0160:\n\t// 352 MakeStruct v570 @ AGG1558AD8_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v444 @ V9_v13 (UnityEngine.Vector3), v439 @ V10_v9 (System.Single), v409 @ V2_v7 (System.Single)\n\tUnityEngine.Transform::set_position(v69, v570);\nL_0163:\n\tv622 = ~this.followLocalScale;\n\tif (v622) goto L_FFFFFFFF;\n\tv500 = this.bone;\n\tv356 = v500.scaleX;\n\tv352 = v500.scaleY;\n\tgoto L_016E;\nL_016E:\n\tv643 = ~this.followSkeletonFlip;\n\tif (v643) goto L_0190;\n\tv501 = this.bone;\n\tv476 = v501.skeleton;\n\tv725 = Spine.Skeleton::get_ScaleY(v501.skeleton);\n\tv678 = v476.scaleX * v725;\n\tv680 = -v352;\n\tv667 = v678 < 0;\n\tif (v667) goto L_FFFFFFFF;\n\tgoto L_0190;\nL_0190:\n\t// 400 MakeStruct v299 @ AGG1558B44_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v356 @ V8_v6 (System.Single), v352 @ V9_v7 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v69, v299);\nL_019B:\n\treturn;\nL_019E:\n\tv523 = UnityEngine.Transform::get_localPosition(v69);\n\tgoto L_011E;\nL_01A3:\n\tthrow System.NullReferenceException;\n// 284 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			//IL_0080: Expected O, but got F4
			//IL_084b: Expected F4, but got O
			//IL_0858: Expected F4, but got O
			Transform transform;
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
					SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
					Bone bone = skeletonRenderer.skeleton.FindBone(boneName);
					this.bone = bone;
					if (!SetBone(boneName))
					{
						return;
					}
				}
				transform = base.transform;
				if (skeletonTransformIsParent)
				{
					Bone bone2;
					if (followXYPosition)
					{
						bone2 = this.bone;
						vector = (Vector3)bone2.WorldX;
					}
					else
					{
						Vector3 localPosition = transform.localPosition;
						if (!followXYPosition)
						{
							y = transform.localPosition.y;
							vector = localPosition;
							goto IL_0885;
						}
						bone2 = this.bone;
						vector = localPosition;
					}
					y = bone2.WorldY;
					goto IL_0885;
				}
				Bone bone3 = this.bone;
				Vector3 position = default(Vector3);
				position.x = bone3.WorldX;
				position.y = bone3.WorldY;
				position.z = 0f;
				Vector3 vector2 = skeletonTransform.TransformPoint(position);
				float z = vector2.z;
				if (!followZPosition)
				{
					z = transform.position.z;
				}
				bool flag = !followXYPosition;
				bool flag2 = !flag;
				float y2 = vector2.y;
				Vector3 vector3 = vector2;
				if (!flag2)
				{
					Vector3 position2 = transform.position;
					y2 = transform.position.y;
					vector3 = position2;
				}
				float worldRotationX = this.bone.WorldRotationX;
				Transform parent = transform.parent;
				bool flag3 = parent != null;
				bool flag4 = !flag3;
				float num = worldRotationX;
				if (!flag4)
				{
					Matrix4x4 localToWorldMatrix = parent.localToWorldMatrix;
					float num2 = localToWorldMatrix.m00 * localToWorldMatrix.m11;
					float num3 = localToWorldMatrix.m10 * localToWorldMatrix.m01;
					float num4 = num2 - num3;
					bool flag5 = !(num4 < 0f);
					num = worldRotationX;
					if (!flag5)
					{
						num = 0f - worldRotationX;
					}
				}
				if (followBoneRotation)
				{
					Quaternion rotation = skeletonTransform.rotation;
					Vector3 vector4 = Quaternion.Internal_ToEulerRad(rotation);
					float x = vector4.x * 57.29578f;
					float y3 = vector4.y * 57.29578f;
					float z2 = vector4.z * 57.29578f;
					Vector3 euler = default(Vector3);
					euler.x = x;
					euler.y = y3;
					euler.z = z2;
					Vector3 vector5 = Quaternion.Internal_MakePositive(euler);
					if (followLocalScale)
					{
						Bone bone4 = this.bone;
						if (bone4.ScaleX < 0f)
						{
							num += 180f;
						}
					}
					float num5 = vector5.z + num;
					float x2 = vector5.x * ((float)Math.PI / 180f);
					float y4 = vector5.y * ((float)Math.PI / 180f);
					float z3 = num5 * ((float)Math.PI / 180f);
					Vector3 vector6 = default(Vector3);
					vector6.x = x2;
					vector6.y = y4;
					vector6.z = z3;
					Quaternion rotation2 = Quaternion.Euler(vector6 * 57.29578f);
					Vector3 position3 = default(Vector3);
					position3.x = vector3.x;
					position3.y = y2;
					position3.z = z;
					transform.SetPositionAndRotation(position3, rotation2);
				}
				else
				{
					Vector3 position4 = default(Vector3);
					position4.x = vector3.x;
					position4.y = y2;
					position4.z = z;
					transform.position = position4;
				}
				goto IL_0576;
			}
			Initialize();
			return;
			IL_0885:
			float z4;
			if (followZPosition)
			{
				bool flag6 = (object)transform == null;
				bool flag7 = !flag6;
				z4 = 0f;
				if (!flag7)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				z4 = transform.localPosition.z;
			}
			Vector3 localPosition2 = default(Vector3);
			localPosition2.x = vector.x;
			localPosition2.y = y;
			localPosition2.z = z4;
			transform.localPosition = localPosition2;
			if (followBoneRotation)
			{
				Bone bone5 = this.bone;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F00 (native atan2f)");
				float num6 = bone5.C * 0.5f;
				bool flag8 = !followLocalScale;
				float num7 = 0.5f;
				if (!flag8)
				{
					num7 = bone5.ScaleX;
					if (bone5.ScaleX < 0f)
					{
						num6 += (float)Math.PI / 2f;
						num7 = (float)Math.PI / 2f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F30 (native sincosf)");
				Quaternion localRotation = default(Quaternion);
				localRotation.x = 0f;
				localRotation.y = 0f;
				object obj = default(object);
				localRotation.z = (float)obj;
				object obj2 = default(object);
				localRotation.w = (float)obj2;
				transform.localRotation = localRotation;
			}
			goto IL_0576;
			IL_0576:
			float x3;
			float num8;
			if (followLocalScale)
			{
				Bone bone6 = this.bone;
				x3 = bone6.ScaleX;
				num8 = bone6.ScaleY;
			}
			else
			{
				num8 = 1f;
				x3 = 1f;
			}
			if (followSkeletonFlip)
			{
				Bone bone7 = this.bone;
				Skeleton skeleton = bone7.Skeleton;
				float scaleY = bone7.Skeleton.ScaleY;
				float num9 = skeleton.ScaleX * scaleY;
				float num10 = 0f - num8;
				if (num9 < 0f)
				{
					num8 = num10;
				}
			}
			Vector3 localScale = default(Vector3);
			localScale.x = x3;
			localScale.y = num8;
			localScale.z = 1f;
			transform.localScale = localScale;
		}

		[Token(Token = "0x60004CF")]
		[Address(RVA = "0x1554B78", Offset = "0x1554B78", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.initializeOnAwake = 1;\n\tthis.followXYPosition = 0x1010101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneFollower()
		{
			initializeOnAwake = true;
			followXYPosition = true;
			followZPosition = true;
			followBoneRotation = true;
			followSkeletonFlip = true;
		}
	}
}
