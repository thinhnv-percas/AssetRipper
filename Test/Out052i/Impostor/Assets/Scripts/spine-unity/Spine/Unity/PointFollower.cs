using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[AddComponentMenu("Spine/Point Follower")]
	[HelpURL("http://esotericsoftware.com/spine-unity#PointFollower")]
	[Token(Token = "0x2000079")]
	public class PointFollower : MonoBehaviour, IHasSkeletonRenderer, IHasSkeletonComponent
	{
		[Token(Token = "0x40002F4")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonRenderer skeletonRenderer;

		[SpineSlot(null, "skeletonRenderer", false, true, false)]
		[Token(Token = "0x40002F5")]
		[FieldOffset(Offset = "0x28")]
		public string slotName;

		[SpineAttachment(true, false, false, "slotName", "skeletonRenderer", null, true, true)]
		[Token(Token = "0x40002F6")]
		[FieldOffset(Offset = "0x30")]
		public string pointAttachmentName;

		[Token(Token = "0x40002F7")]
		[FieldOffset(Offset = "0x38")]
		public bool followRotation;

		[Token(Token = "0x40002F8")]
		[FieldOffset(Offset = "0x39")]
		public bool followSkeletonFlip;

		[Token(Token = "0x40002F9")]
		[FieldOffset(Offset = "0x3A")]
		public bool followSkeletonZPosition;

		[Token(Token = "0x40002FA")]
		[FieldOffset(Offset = "0x40")]
		private Transform skeletonTransform;

		[Token(Token = "0x40002FB")]
		[FieldOffset(Offset = "0x48")]
		private bool skeletonTransformIsParent;

		[Token(Token = "0x40002FC")]
		[FieldOffset(Offset = "0x50")]
		private PointAttachment point;

		[Token(Token = "0x40002FD")]
		[FieldOffset(Offset = "0x58")]
		private Bone bone;

		[Token(Token = "0x40002FE")]
		[FieldOffset(Offset = "0x60")]
		private bool valid;

		[Token(Token = "0x1700018A")]
		public SkeletonRenderer SkeletonRenderer
		{
			[Token(Token = "0x60004F9")]
			[Address(RVA = "0x1557D0C", Offset = "0x1557D0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonRenderer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonRenderer;
			}
		}

		[Token(Token = "0x1700018B")]
		public ISkeletonComponent SkeletonComponent
		{
			[Token(Token = "0x60004FA")]
			[Address(RVA = "0x1557D14", Offset = "0x1557D14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonRenderer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonRenderer;
			}
		}

		[Token(Token = "0x1700018C")]
		public bool IsValid
		{
			[Token(Token = "0x60004FB")]
			[Address(RVA = "0x1557D1C", Offset = "0x1557D1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.valid;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsValid;
			}
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0x1557D24", Offset = "0x1557D24", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C01]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_0030;\n\tv51 = this.skeletonRenderer;\n\tthis.valid = v51.valid;\n\tv54 = ~v51.valid;\n\tif (v54) goto L_0036;\n\tSpine.Unity.PointFollower::UpdateReferences(this);\n\treturn;\nL_0030:\n\tthis.valid = 0;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			if (this.skeletonRenderer != null)
			{
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				valid = skeletonRenderer.valid;
				if (skeletonRenderer.valid)
				{
					UpdateReferences();
				}
			}
			else
			{
				valid = false;
			}
		}

		[Token(Token = "0x60004FD")]
		[Address(RVA = "0x1557FA0", Offset = "0x1557FA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.PointFollower::Initialize(this);\n\treturn;\n")]
		private void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer)
		{
			Initialize();
		}

		[Token(Token = "0x60004FE")]
		[Address(RVA = "0x1557DB8", Offset = "0x1557DB8", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv20 = Spine.PointAttachment;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv140 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C02]) = v40;\nL_0021:\n\tv51 = UnityEngine.Component::get_transform(this.skeletonRenderer);\n\tthis.skeletonTransform = v51;\n\tv111 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v111, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v111);\n\tv112 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v112, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::add_OnRebuild(this.skeletonRenderer, v112);\n\tv113 = UnityEngine.Component::get_transform(this);\n\tv222 = UnityEngine.Transform::get_parent(v113);\n\tthis.point = 0;\n\tv85 = this.skeletonTransform - v222;\n\tv77 = v85 == 0;\n\tthis.skeletonTransformIsParent = v77;\n\tthis.bone = 0;\n\tv114 = System.String::IsNullOrEmpty(this.pointAttachmentName);\n\tv227 = v114 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_00BB;\n\tv136 = this.skeletonRenderer;\n\tv115 = Spine.Unity.SkeletonRenderer::Initialize(this.skeletonRenderer, 0);\n\tv137 = v136.skeleton;\n\tv116 = Spine.Skeleton::FindSlotIndex(v136.skeleton, this.slotName);\n\tv252 = v116 & 0x80000000;\n\tv253 = v252 == 0;\n\tv246 = ~v253;\n\tif (v246) goto L_00BB;\n\tv129 = v137.slots;\n\tv130 = v129.Items;\n\tv131 = v130[v116 @ X0_v23 (System.Int32)];\n\tthis.bone = v131.bone;\n\tv244 = Spine.Skeleton::GetAttachment(v136.skeleton, v116, this.pointAttachmentName);\n\tv245 = v244 == 0;\n\tif (v245) goto L_009E;\n\tgoto L_FFFFFFFF;\n\tgoto L_00B3;\nL_009E:\n\tthis.point = 0;\n\tgoto L_00BB;\n\tv284 = v284_asT == 0;\n\tif (v284) goto L_FFFFFFFF;\n\tgoto L_00B3;\nL_00B3:\n\tthis.point = v247;\nL_00BB:\n\treturn;\n\tv138 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateReferences()
		{
			//IL_00a6: Expected O, but got I
			//IL_015d: Expected I4, but got I8
			Transform transform = this.skeletonRenderer.transform;
			skeletonTransform = transform;
			SkeletonRenderer.SkeletonRendererDelegate value = HandleRebuildRenderer;
			this.skeletonRenderer.OnRebuild -= value;
			SkeletonRenderer.SkeletonRendererDelegate value2 = HandleRebuildRenderer;
			this.skeletonRenderer.OnRebuild += value2;
			Transform transform2 = base.transform;
			Transform parent = transform2.parent;
			point = null;
			object obj = (nint)skeletonTransform - (nint)parent;
			bool flag = obj == null;
			skeletonTransformIsParent = flag;
			bone = null;
			if (string.IsNullOrEmpty(pointAttachmentName))
			{
				return;
			}
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			this.skeletonRenderer.Initialize(overwrite: false);
			Skeleton skeleton = skeletonRenderer.skeleton;
			int num = skeletonRenderer.skeleton.FindSlotIndex(slotName);
			if ((int)(num & 0x80000000L) == 0)
			{
				ExposedList<Slot> slots = skeleton.Slots;
				Slot[] items = slots.Items;
				Slot slot = items[num];
				bone = slot.Bone;
				Attachment attachment = skeletonRenderer.skeleton.GetAttachment(num, pointAttachmentName);
				if (attachment == null)
				{
					point = null;
					return;
				}
				PointAttachment pointAttachment = attachment as PointAttachment;
				Attachment attachment2 = ((pointAttachment == null) ? null : attachment);
				point = (PointAttachment)attachment2;
			}
		}

		[Token(Token = "0x60004FF")]
		[Address(RVA = "0x1557FC8", Offset = "0x1557FC8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C03]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_0042;\n\tv61 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v61, this, Il2CppMethodInfo);\n\tv80 = this.skeletonRenderer == 0;\n\tif (v80) goto L_0043;\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v61);\n\treturn;\nL_0042:\n\treturn;\nL_0043:\n\tthrow v61;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000500")]
		[Address(RVA = "0x1558090", Offset = "0x1558090", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = UnityEngine.Object;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37C04]) = v43;\nL_0016:\n\tv49 = this.point;\n\tv46 = this.point == 0;\n\tif (v46) goto L_0039;\nL_001B:\n\tv56 = &v58 @ stack_-48_v4 (System.Single) | 4;\n\tSpine.PointAttachment::ComputeWorldPosition(v49, this.bone, &v58 @ stack_-48_v4 (System.Single), v56);\n\tv69 = Spine.PointAttachment::ComputeWorldRotation(this.point, this.bone);\n\tv264 = UnityEngine.Component::get_transform(this);\n\tv454 = ~this.skeletonTransformIsParent;\n\tif (v454) goto L_004C;\n\tv456 = ~this.followSkeletonZPosition;\n\tif (v456) goto L_005E;\n\tv457 = v264 == 0;\n\tv271 = ~v457;\n\tif (v271) goto L_0065;\n\tgoto L_0134;\nL_0039:\n\tv61 = System.String::IsNullOrEmpty(this.pointAttachmentName);\n\tv65 = v61 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0133;\n\tSpine.Unity.PointFollower::UpdateReferences(this);\n\tv49 = this.point;\n\tv390 = this.point == 0;\n\tv52 = ~v390;\n\tif (v52) goto L_001B;\n\tgoto L_0133;\nL_004C:\n\t// 76 MakeStruct v224 @ AGG155C16C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v58 @ stack_-48_v4 (System.Single), v455 @ stack_-44, 0\n\tv250 = UnityEngine.Transform::TransformPoint(this.skeletonTransform, v224);\n\tv477 = ~this.followSkeletonZPosition;\n\tif (v477) goto L_007F;\n\tv480 = v264 == 0;\n\tv273 = ~v480;\n\tif (v273) goto L_0085;\n\tgoto L_0134;\nL_005E:\n\tv466 = UnityEngine.Transform::get_localPosition(v264);\n\tv463 = v466.z;\nL_0065:\n\t// 101 MakeStruct v476 @ AGG155C1AC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v58 @ stack_-48_v4 (System.Single), v455 @ stack_-44, v463 @ V2_v21 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v264, v476);\n\tv479 = ~this.followRotation;\n\tif (v479) goto L_00FF;\n\tv484 = v69 * 0.5f;\n\tv487 = v484 * 0.017453292f;\n\tv490 = 0x1854F30(&v486 @ stack_-8C_v4, &v489 @ stack_-90_v4, 0, v56, 0, v30, v31, v32, v487, v484, v463, v36, v37, v38, v39, v40);\n\t// 120 MakeStruct v501 @ AGG155C1EC_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, v486 @ stack_-8C_v4, v489 @ stack_-90_v4\n\tUnityEngine.Transform::set_localRotation(v264, v501);\n\tgoto L_00FF;\nL_007F:\n\tv526 = UnityEngine.Transform::get_position(v264);\nL_0085:\n\tv534 = UnityEngine.Transform::get_parent(v264);\n\tgoto L_0093;\n\tv539 = v284;\n\tv540 = \"il2cpp_codegen_runtime_class_init\"(v539, v533, v68, v56, v59, v30, v31, v32, v251, v228, v234, v36, v37, v38, v39, v40);\nL_0093:\n\tv266 = UnityEngine.Object::op_Inequality(v534, 0);\n\tv544 = v266 == 0;\n\tif (v544) goto L_00C1;\n\tv578 = UnityEngine.Transform::get_localToWorldMatrix(v534);\n\tv572 = v578.m00 * v578.m11;\n\tv589 = v578.m10 * v578.m01;\n\tv575 = v572 - v589;\n\tv546 = v575 >= 0;\n\tif (v546) goto L_00C1;\n\tv247 = -v69;\nL_00C1:\n\tv520 = ~this.followRotation;\n\tif (v520) goto L_00FC;\n\tv592 = UnityEngine.Transform::get_rotation(this.skeletonTransform);\n\tv599 = UnityEngine.Quaternion::Internal_ToEulerRad(v592);\n\tv605 = v599 * 57.29578f;\n\tv606 = v599.y * 57.29578f;\n\tv607 = v599.z * 57.29578f;\n\t// 214 MakeStruct v499 @ AGG155C2B4_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v605 @ V0_v16 (System.Single), v606 @ V1_v16 (System.Single), v607 @ V2_v13 (System.Single)\n\tv608 = UnityEngine.Quaternion::Internal_MakePositive(v499);\n\tv612 = v247 + v608.z;\n\tv614 = v608 * 0.017453292f;\n\tv615 = v608.y * 0.017453292f;\n\tv616 = v612 * 0.017453292f;\n\t// 225 MakeStruct v498 @ AGG155C2D4_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v614 @ V0_v18 (System.Single), v615 @ V1_v18 (System.Single), v616 @ V2_v16 (System.Single)\n\tv617 = UnityEngine.Quaternion::Internal_FromEulerRad(v498);\n\t// 243 MakeStruct v493 @ AGG155C30C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v250 @ V0_v10 (UnityEngine.Vector3), v250.y (System.Single), v220 @ V11_v6 (System.Single)\n\tUnityEngine.Transform::SetPositionAndRotation(v264, v493, v617);\n\tgoto L_00FF;\nL_00FC:\n\t// 252 MakeStruct v491 @ AGG155C328_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v250 @ V0_v10 (UnityEngine.Vector3), v250.y (System.Single), v220 @ V11_v6 (System.Single)\n\tUnityEngine.Transform::set_position(v264, v491);\nL_00FF:\n\tv377 = ~this.followSkeletonFlip;\n\tif (v377) goto L_0133;\n\tv253 = UnityEngine.Transform::get_localScale(v264);\n\tv286 = this.bone;\n\tv269 = v286.skeleton;\n\tv349 = UnityEngine.Mathf::Abs(v253.y);\n\tv582 = Spine.Skeleton::get_ScaleY(v286.skeleton);\n\tv584 = v269.scaleX * v582;\n\tv352 = -v349;\n\tv296 = v584 < 0;\n\tif (v296) goto L_0128;\n\tgoto L_0128;\nL_0128:\n\t// 296 MakeStruct v292 @ AGG155C388_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v253 @ V0_v5 (UnityEngine.Vector3), v352 @ V1_v6 (System.Single), v253.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v264, v292);\nL_0133:\n\treturn;\nL_0134:\n\tthrow System.NullReferenceException;\n// 209 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void LateUpdate()
		{
			//IL_0150: Expected F4, but got O
			//IL_05e8: Expected F4, but got O
			//IL_0238: Expected F4, but got O
			//IL_0245: Expected F4, but got O
			PointAttachment pointAttachment = point;
			if (point == null)
			{
				if (string.IsNullOrEmpty(pointAttachmentName))
				{
					return;
				}
				UpdateReferences();
				pointAttachment = point;
				if (point == null)
				{
					return;
				}
			}
			float ox = default(float);
			ref float oy = ref *(float*)((nint)ox | 4);
			pointAttachment.ComputeWorldPosition(this.bone, out ox, out oy);
			float num = point.ComputeWorldRotation(this.bone);
			Transform transform = base.transform;
			object obj = default(object);
			if (skeletonTransformIsParent)
			{
				float z;
				if (followSkeletonZPosition)
				{
					bool flag = (object)transform == null;
					bool flag2 = !flag;
					z = 0f;
					if (!flag2)
					{
						goto IL_059f;
					}
				}
				else
				{
					z = transform.localPosition.z;
				}
				Vector3 localPosition = default(Vector3);
				localPosition.x = ox;
				localPosition.y = (float)obj;
				localPosition.z = z;
				transform.localPosition = localPosition;
				if (followRotation)
				{
					float num2 = num * 0.5f;
					float num3 = num2 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F30 (native sincosf)");
					Quaternion localRotation = default(Quaternion);
					localRotation.x = 0f;
					localRotation.y = 0f;
					object obj2 = default(object);
					localRotation.z = (float)obj2;
					object obj3 = default(object);
					localRotation.w = (float)obj3;
					transform.localRotation = localRotation;
				}
			}
			else
			{
				Vector3 position = default(Vector3);
				position.x = ox;
				position.y = (float)obj;
				position.z = 0f;
				Vector3 vector = skeletonTransform.TransformPoint(position);
				float z2;
				if (followSkeletonZPosition)
				{
					bool flag3 = (object)transform == null;
					bool flag4 = !flag3;
					z2 = vector.z;
					if (!flag4)
					{
						goto IL_059f;
					}
				}
				else
				{
					z2 = transform.position.z;
				}
				Transform parent = transform.parent;
				bool flag5 = parent != null;
				bool flag6 = !flag5;
				float num4 = num;
				if (!flag6)
				{
					Matrix4x4 localToWorldMatrix = parent.localToWorldMatrix;
					float num5 = localToWorldMatrix.m00 * localToWorldMatrix.m11;
					float num6 = localToWorldMatrix.m10 * localToWorldMatrix.m01;
					float num7 = num5 - num6;
					bool flag7 = !(num7 < 0f);
					num4 = num;
					if (!flag7)
					{
						num4 = 0f - num;
					}
				}
				if (followRotation)
				{
					Quaternion rotation = skeletonTransform.rotation;
					Vector3 vector2 = Quaternion.Internal_ToEulerRad(rotation);
					float x = vector2.x * 57.29578f;
					float y = vector2.y * 57.29578f;
					float z3 = vector2.z * 57.29578f;
					Vector3 euler = default(Vector3);
					euler.x = x;
					euler.y = y;
					euler.z = z3;
					Vector3 vector3 = Quaternion.Internal_MakePositive(euler);
					float num8 = num4 + vector3.z;
					float x2 = vector3.x * ((float)Math.PI / 180f);
					float y2 = vector3.y * ((float)Math.PI / 180f);
					float z4 = num8 * ((float)Math.PI / 180f);
					Vector3 vector4 = default(Vector3);
					vector4.x = x2;
					vector4.y = y2;
					vector4.z = z4;
					Quaternion rotation2 = Quaternion.Euler(vector4 * 57.29578f);
					Vector3 position2 = default(Vector3);
					position2.x = vector.x;
					position2.y = vector.y;
					position2.z = z2;
					transform.SetPositionAndRotation(position2, rotation2);
				}
				else
				{
					Vector3 position3 = default(Vector3);
					position3.x = vector.x;
					position3.y = vector.y;
					position3.z = z2;
					transform.position = position3;
				}
			}
			if (followSkeletonFlip)
			{
				Vector3 localScale = transform.localScale;
				Bone bone = this.bone;
				Skeleton skeleton = bone.Skeleton;
				float num9 = Mathf.Abs(localScale.y);
				float scaleY = bone.Skeleton.ScaleY;
				float num10 = skeleton.ScaleX * scaleY;
				float y3 = 0f - num9;
				if (!(num10 < 0f))
				{
					y3 = num9;
				}
				Vector3 localScale2 = default(Vector3);
				localScale2.x = localScale.x;
				localScale2.y = y3;
				localScale2.z = localScale.z;
				transform.localScale = localScale2;
			}
			return;
			IL_059f:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000501")]
		[Address(RVA = "0x15583A8", Offset = "0x15583A8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.followRotation = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PointFollower()
		{
			followRotation = true;
			followSkeletonFlip = true;
		}
	}
}
