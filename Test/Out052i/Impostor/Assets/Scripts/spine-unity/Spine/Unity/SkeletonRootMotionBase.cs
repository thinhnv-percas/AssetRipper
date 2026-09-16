using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AnimationTools;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x200007C")]
	public abstract class SkeletonRootMotionBase : MonoBehaviour
	{
		[SpineBone(null, null, true, false)]
		[SerializeField]
		[Token(Token = "0x4000307")]
		[FieldOffset(Offset = "0x20")]
		protected string rootMotionBoneName;

		[Token(Token = "0x4000308")]
		[FieldOffset(Offset = "0x28")]
		public bool transformPositionX;

		[Token(Token = "0x4000309")]
		[FieldOffset(Offset = "0x29")]
		public bool transformPositionY;

		[Token(Token = "0x400030A")]
		[FieldOffset(Offset = "0x2C")]
		public float rootMotionScaleX;

		[Token(Token = "0x400030B")]
		[FieldOffset(Offset = "0x30")]
		public float rootMotionScaleY;

		[Header("Optional")]
		[Token(Token = "0x400030C")]
		[FieldOffset(Offset = "0x38")]
		public Rigidbody2D rigidBody2D;

		[Token(Token = "0x400030D")]
		[FieldOffset(Offset = "0x40")]
		public Rigidbody rigidBody;

		[Token(Token = "0x400030E")]
		[FieldOffset(Offset = "0x48")]
		protected internal ISkeletonComponent skeletonComponent;

		[Token(Token = "0x400030F")]
		[FieldOffset(Offset = "0x50")]
		protected Bone rootMotionBone;

		[Token(Token = "0x4000310")]
		[FieldOffset(Offset = "0x58")]
		protected int rootMotionBoneIndex;

		[Token(Token = "0x4000311")]
		[FieldOffset(Offset = "0x60")]
		protected List<Bone> topLevelBones;

		[Token(Token = "0x4000312")]
		[FieldOffset(Offset = "0x68")]
		protected Vector2 rigidbodyDisplacement;

		[Token(Token = "0x1700018F")]
		public bool UsesRigidbody
		{
			[Token(Token = "0x6000510")]
			[Address(RVA = "0x155919C", Offset = "0x155919C", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C0A]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.rigidBody, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_002D;\n\treturn 1;\nL_002D:\n\tgoto L_0037;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v56, v46, v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\treturnVal2 = UnityEngine.Object::op_Inequality(this.rigidBody2D, 0);\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (rigidBody != null)
				{
					return true;
				}
				return rigidBody2D != null;
			}
		}

		[Token(Token = "0x17000190")]
		protected virtual float AdditionalScale
		{
			[Token(Token = "0x6000516")]
			[Address(RVA = "0x1559970", Offset = "0x1559970", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1f;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 1f;
			}
		}

		[Token(Token = "0x6000511")]
		[Address(RVA = "0x155879C", Offset = "0x155879C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonRootMotionBase::FindRigidbodyComponent(this);\n\treturn;\n")]
		protected virtual void Reset()
		{
			FindRigidbodyComponent();
		}

		[Token(Token = "0x6000512")]
		[Address(RVA = "0x15588D8", Offset = "0x15588D8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Spine.Unity.ISkeletonAnimation;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = Spine.Unity.UpdateBonesDelegate;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C0B]) = v42;\nL_0021:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonComponent = v45;\n\tSpine.Unity.SkeletonRootMotionBase::GatherTopLevelBones(this);\n\tSpine.Unity.SkeletonRootMotionBase::SetRootMotionBone(this, this.rootMotionBoneName);\n\t// 42 IsInst v59 @ X0_v7 (Spine.Unity.ISkeletonAnimation), typeof(Spine.Unity.ISkeletonAnimation), this.skeletonComponent (Spine.Unity.ISkeletonComponent)\n\tv60 = v59 == 0;\n\tif (v60) goto L_0062;\n\tv67 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v67, this, Il2CppMethodInfo);\n\tgoto L_0071;\n\tv141 = *([v138 @ X8_v5+B0]);\n\tv142 = v141 + 8;\n\tv144 = *([v180 @ X10_v5-8]);\n\tv186 = v144 == v139;\n\tif (v186) goto L_0063;\n\tv166 = v181 - 1;\n\tv164 = v180 + 0x10;\n\tv146 = v181 != 1;\n\tif (v146) goto L_FFFFFFFF;\n\tv167 = v63;\n\tv168 = 0;\n\tv169 = 0xB349B4(v167, v139, v168, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0071;\nL_0062:\n\treturn;\nL_0063:\n\tv192 = *([v180 @ X10_v5]);\n\tv193 = v192 << 4;\n\tv194 = v138 + v193;\n\tv195 = v194 + 0x138;\nL_0071:\n\tSpine.Unity.ISkeletonAnimation::add_UpdateLocal(v59, v67);\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void Start()
		{
			ISkeletonComponent component = GetComponent<ISkeletonComponent>();
			skeletonComponent = component;
			GatherTopLevelBones();
			SetRootMotionBone(rootMotionBoneName);
			ISkeletonAnimation skeletonAnimation = skeletonComponent as ISkeletonAnimation;
			if (skeletonAnimation != null)
			{
				UpdateBonesDelegate value = HandleUpdateLocal;
				skeletonAnimation.UpdateLocal += value;
			}
		}

		[Token(Token = "0x6000513")]
		[Address(RVA = "0x15597A8", Offset = "0x15597A8", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C0C]) = v37;\nL_0014:\n\tv40 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv42 = v40 == 0;\n\tif (v42) goto L_0080;\n\tgoto L_0024;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v46, v39, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tv93 = UnityEngine.Object::op_Inequality(this.rigidBody2D, 0);\n\tv124 = v93 == 0;\n\tif (v124) goto L_004B;\n\tv128 = UnityEngine.Component::get_transform(this);\n\tv156 = UnityEngine.Transform::get_position(v128);\n\tv170 = UnityEngine.Component::get_transform(this);\n\tv163 = UnityEngine.Transform::get_position(v170);\n\tv134 = v163.y + this.rigidbodyDisplacement.y;\n\tv136 = v156 + this.rigidbodyDisplacement;\n\t// 68 MakeStruct v129 @ AGG155D868_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v136 @ V0_v11 (System.Single), v134 @ V1_v9 (System.Single)\n\tUnityEngine.Rigidbody2D::MovePosition(this.rigidBody2D, v129);\nL_004B:\n\tgoto L_0050;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v144, v137, v92, v22, v23, v24, v25, v26, v135, v133, v131, v30, v31, v32, v33, v34);\nL_0050:\n\tv154 = UnityEngine.Object::op_Inequality(this.rigidBody, 0);\n\tv177 = v154 == 0;\n\tif (v177) goto L_006E;\n\tv171 = UnityEngine.Component::get_transform(this);\n\tv164 = UnityEngine.Transform::get_position(v171);\n\tv185 = v164.y + this.rigidbodyDisplacement.y;\n\tv187 = v164 + this.rigidbodyDisplacement;\n\t// 104 MakeStruct v180 @ AGG155D8D0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v187 @ V0_v7 (System.Single), v185 @ V1_v6 (System.Single), v164.z (System.Single)\n\tUnityEngine.Rigidbody::MovePosition(this.rigidBody, v180);\nL_006E:\n\tgoto L_0079;\n\tv196 = UnityEngine.Vector2;\n\tv197 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, v73, v71, v22, v23, v24, v25, v26, v186, v67, v65, v56, v58, v54, v33, v34);\n\tv199 = 1;\n\t*([1A35518]) = v199;\nL_0079:\n\tthis.rigidbodyDisplacement = v80.zeroVector;\nL_0080:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void FixedUpdate()
		{
			if (base.isActiveAndEnabled)
			{
				if (rigidBody2D != null)
				{
					Transform transform = base.transform;
					Vector3 position = transform.position;
					Transform transform2 = base.transform;
					float y = transform2.position.y + rigidbodyDisplacement.y;
					float x = position.x + rigidbodyDisplacement.x;
					Vector2 position2 = default(Vector2);
					position2.x = x;
					position2.y = y;
					rigidBody2D.MovePosition(position2);
				}
				if (rigidBody != null)
				{
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					float y2 = position3.y + rigidbodyDisplacement.y;
					float x2 = position3.x + rigidbodyDisplacement.x;
					Vector3 position4 = default(Vector3);
					position4.x = x2;
					position4.y = y2;
					position4.z = position3.z;
					rigidBody.MovePosition(position4);
				}
				rigidbodyDisplacement = Vector2.zero;
			}
		}

		[Token(Token = "0x6000514")]
		[Address(RVA = "0x1559920", Offset = "0x1559920", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = UnityEngine.Vector2;\n\tv14 = \"il2cpp_codegen_initialize_runtime_metadata\"(v13, methodInfo, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv32 = 1;\n\t*([1A35518]) = v32;\nL_0014:\n\tthis.rigidbodyDisplacement = v36.zeroVector;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnDisable()
		{
			rigidbodyDisplacement = Vector2.zero;
		}

		[Token(Token = "0x6000515")]
		[Address(RVA = "0x1559234", Offset = "0x1559234", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = UnityEngine.Object;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C0D]) = v42;\nL_0024:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.rigidBody2D = v45;\n\tgoto L_002F;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v50, v43, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\tv61 = UnityEngine.Object::op_Implicit(v45);\n\tv66 = v61 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003F;\n\tv74 = UnityEngine.Component::GetComponent(this);\n\tthis.rigidBody = v74;\nL_003F:\n\tgoto L_0043;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v78, v75, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0043:\n\tv87 = UnityEngine.Object::op_Implicit(this.rigidBody2D);\n\tv89 = v87 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0076;\n\tgoto L_0051;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v91, v86, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0051:\n\tv102 = UnityEngine.Object::op_Implicit(this.rigidBody);\n\tv121 = v102 == 0;\n\tv106 = ~v121;\n\tif (v106) goto L_0076;\n\tv126 = UnityEngine.Component::GetComponentInParent(this);\n\tthis.rigidBody2D = v126;\n\tgoto L_0065;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v127, v125, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0065:\n\tv103 = UnityEngine.Object::op_Implicit(v126);\n\tv134 = v103 == 0;\n\tv105 = ~v134;\n\tif (v105) goto L_0076;\n\tv101 = UnityEngine.Component::GetComponentInParent(this);\n\tthis.rigidBody = v101;\nL_0076:\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void FindRigidbodyComponent()
		{
			if (!(rigidBody2D = GetComponent<Rigidbody2D>()))
			{
				Rigidbody component = GetComponent<Rigidbody>();
				rigidBody = component;
			}
			if (!rigidBody2D && !rigidBody && !(rigidBody2D = GetComponentInParent<Rigidbody2D>()))
			{
				Rigidbody componentInParent = GetComponentInParent<Rigidbody>();
				rigidBody = componentInParent;
			}
		}

		[Token(Token = "0x6000517")]
		protected abstract Vector2 CalculateAnimationsMovementDelta();

		[Token(Token = "0x6000518")]
		public abstract Vector2 GetRemainingRootMotion(int trackIndex = 0);

		[Token(Token = "0x6000519")]
		[Address(RVA = "0x155962C", Offset = "0x155962C", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Spine.Unity.ISkeletonComponent;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv109 = \"Bone named \\\"\";\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv170 = \"\\\" could not be found.\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v170, name, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37C0E]) = v37;\nL_0024:\n\tgoto L_004B;\n\tv111 = *([v44 @ X8_v5+B0]);\n\tv112 = v111 + 8;\n\tv114 = *([v182 @ X10_v9-8]);\n\tv187 = v114 == v47;\n\tif (v187) goto L_0043;\n\tv134 = v181 - 1;\n\tv136 = v182 + 0x10;\n\tv116 = v181 != 1;\n\tif (v116) goto L_FFFFFFFF;\n\tv137 = 1;\n\tv138 = v38;\n\tv139 = 0xB349B4(v138, v47, v137, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_004B;\nL_0043:\n\tv193 = *([v182 @ X10_v9]);\n\tv194 = v193 + 1;\n\tv195 = v194 << 4;\n\tv196 = v44 + v195;\n\tv197 = v196 + 0x138;\nL_004B:\n\tv96 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv95 = Spine.Skeleton::FindBoneIndex(v96, name);\n\tv244 = v95 & 0x80000000;\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_0074;\n\tthis.rootMotionBoneIndex = v95;\n\tv102 = v96.bones;\n\tv103 = v102.Items;\n\tgoto L_0086;\nL_0074:\n\tv255 = System.String::Concat(\"Bone named \\\"\", name, \"\\\" could not be found.\");\n\tgoto L_0081;\n\tv264 = v259;\n\tv265 = \"il2cpp_codegen_runtime_class_init\"(v264, v251, v254, v252, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0081:\n\tUnityEngine.Debug::Log(v255);\n\tthis.rootMotionBoneIndex = 0;\n\tv233 = Spine.Skeleton::get_RootBone(v96);\nL_0086:\n\tthis.rootMotionBone = v233;\n\treturn;\n\tv107 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetRootMotionBone(string name)
		{
			//IL_002d: Expected I4, but got I8
			Skeleton skeleton = skeletonComponent.Skeleton;
			int num = skeleton.FindBoneIndex(name);
			Bone bone;
			if ((int)(num & 0x80000000L) == 0)
			{
				rootMotionBoneIndex = num;
				ExposedList<Bone> bones = skeleton.Bones;
				Bone[] items = bones.Items;
				bone = items[num];
			}
			else
			{
				string message = "Bone named \"" + name + "\" could not be found.";
				Debug.Log(message);
				rootMotionBoneIndex = 0;
				bone = skeleton.RootBone;
			}
			rootMotionBone = bone;
		}

		[Token(Token = "0x600051A")]
		[Address(RVA = "0x1559978", Offset = "0x1559978", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Spine.Unity.SkeletonRootMotionBase::GetRemainingRootMotion(this, trackIndex);\n\tv41 = distanceToTarget != 0;\n\tif (v41) goto L_FFFFFFFF;\n\tgoto L_0027;\nL_0027:\n\tv54 = distanceToTarget.y != 0;\n\tif (v54) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_002D:\n\tv58 = distanceToTarget / v44;\n\tv59 = distanceToTarget.y / v57;\n\tthis.rootMotionScaleX = v58;\n\tthis.rootMotionScaleY = v59;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AdjustRootMotionToDistance(Vector2 distanceToTarget, int trackIndex = 0)
		{
			//IL_003e: Expected O, but got F4
			Vector2 remainingRootMotion = GetRemainingRootMotion(trackIndex);
			Vector2 vector = default(Vector2);
			object obj = ((vector.x != 0f) ? distanceToTarget : ((object)0.0001f));
			float num = ((distanceToTarget.y != 0f) ? distanceToTarget.y : 0.0001f);
			float num2 = vector.x / (float)obj;
			float num3 = distanceToTarget.y / num;
			rootMotionScaleX = num2;
			rootMotionScaleY = num3;
		}

		[Token(Token = "0x600051B")]
		[Address(RVA = "0x15599C8", Offset = "0x15599C8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Spine.Unity.SkeletonRootMotionBase::GetAnimationRootMotion(this, 0f, animation.duration, animation);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2 GetAnimationRootMotion(Animation animation)
		{
			return GetAnimationRootMotion(0f, animation.Duration, animation);
		}

		[Token(Token = "0x600051C")]
		[Address(RVA = "0x1558700", Offset = "0x1558700", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = Spine.Unity.AnimationTools.TimelineExtensions::FindTranslateTimelineForBone(animation, this.rootMotionBoneIndex);\n\tv19 = v18 == 0;\n\tif (v19) goto L_0019;\n\treturnVal1 = Spine.Unity.SkeletonRootMotionBase::GetTimelineMovementDelta(v18, startTime, endTime, v18, animation);\n\tgoto L_002A;\nL_0019:\n\tgoto L_0023;\n\tv32 = UnityEngine.Vector2;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, v10, v13, v25, v34, v35, v36, v37, startTime, endTime, v38, v39, v40, v41, v42, v43);\n\tv45 = 1;\n\t*([1A35518]) = v45;\nL_0023:\n\treturnVal1 = v50.zeroVector;\nL_002A:\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2 GetAnimationRootMotion(float startTime, float endTime, Animation animation)
		{
			TranslateTimeline translateTimeline = animation.FindTranslateTimelineForBone(rootMotionBoneIndex);
			return ((SkeletonRootMotionBase)(object)translateTimeline)?.GetTimelineMovementDelta(startTime, endTime, translateTimeline, animation) ?? Vector2.zero;
		}

		[Token(Token = "0x600051D")]
		[Address(RVA = "0x15599E4", Offset = "0x15599E4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = startTime <= endTime;\n\tif (v29) goto L_003C;\n\tv37 = Spine.Unity.AnimationTools.TimelineExtensions::Evaluate(timeline, animation.duration, 0);\n\tv67 = Spine.Unity.AnimationTools.TimelineExtensions::Evaluate(timeline, startTime, 0);\n\tv89 = v37 - v67;\n\tv95 = Spine.Unity.AnimationTools.TimelineExtensions::Evaluate(timeline, endTime, 0);\n\tv143 = Spine.Unity.AnimationTools.TimelineExtensions::Evaluate(timeline, 0f, 0);\n\tv145 = v95 - v143;\n\tv133 = v89 + v145;\n\tgoto L_0066;\nL_003C:\n\tv32 = startTime != endTime;\n\tif (v32) goto L_0053;\n\tgoto L_004C;\n\tv69 = UnityEngine.Vector2;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, timeline, animation, methodInfo, v41, v42, v43, v44, startTime, endTime, v45, v46, v47, v48, v49, v50);\n\tv72 = 1;\n\t*([1A35518]) = v72;\nL_004C:\n\treturnVal2 = v77.zeroVector;\n\tgoto L_0066;\nL_0053:\n\tv59 = Spine.Unity.AnimationTools.TimelineExtensions::Evaluate(timeline, endTime, 0);\n\tv87 = Spine.Unity.AnimationTools.TimelineExtensions::Evaluate(timeline, startTime, 0);\n\tv132 = v59 - v87;\nL_0066:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn startTime;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector2 GetTimelineMovementDelta(float startTime, float endTime, TranslateTimeline timeline, Animation animation)
		{
			//IL_0137: Expected O, but got F4
			//IL_00c2: Expected O, but got F4
			if (startTime > endTime)
			{
				Vector2 vector = timeline.Evaluate(animation.Duration);
				Vector2 vector2 = timeline.Evaluate(startTime);
				float num = vector.x - vector2.x;
				Vector2 vector3 = timeline.Evaluate(endTime);
				Vector2 vector4 = timeline.Evaluate(0f);
				float num2 = vector3.x - vector4.x;
				float num3 = num + num2;
				return (Vector2)num3;
			}
			if (startTime != endTime)
			{
				Vector2 vector5 = timeline.Evaluate(endTime);
				Vector2 vector6 = timeline.Evaluate(startTime);
				float num4 = vector5.x - vector6.x;
				return (Vector2)num4;
			}
			return Vector2.zero;
		}

		[Token(Token = "0x600051E")]
		[Address(RVA = "0x155939C", Offset = "0x155939C", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv155 = Il2CppMethodInfo;\n\tv156 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv161 = Il2CppMethodInfo;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv181 = Spine.Unity.ISkeletonComponent;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv226 = Il2CppMethodInfo;\n\tv227 = \"il2cpp_codegen_initialize_runtime_metadata\"(v226, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv255 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v255, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C0F]) = v38;\nL_0027:\n\tv42 = this.topLevelBones;\n\tv43 = this.topLevelBones == 0;\n\tif (v43) goto L_00C0;\n\tv49 = v42._version + 1;\n\tv42._size = 0;\n\tv42._version = v49;\n\tv60 = v42._size < 1;\n\tif (v60) goto L_0040;\n\tSystem.Array::Clear(v42._items, 0, v42._size);\nL_0040:\n\tv144 = this.skeletonComponent == 0;\n\tif (v144) goto L_00C0;\n\tgoto L_006F;\n\tv183 = *([v164 @ X8_v11+B0]);\n\tv184 = v183 + 8;\n\tv186 = *([v229 @ X10_v13-8]);\n\tv244 = v186 == v167;\n\tif (v244) goto L_0067;\n\tv208 = v239 - 1;\n\tv188 = v229 + 0x10;\n\tv190 = v239 != 1;\n\tif (v190) goto L_FFFFFFFF;\n\tv209 = 1;\n\tv210 = v152;\n\tv211 = 0xB349B4(v210, v167, v209, v90, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_006F;\nL_0067:\n\tv257 = *([v229 @ X10_v13]);\n\tv258 = v257 + 1;\n\tv259 = v258 << 4;\n\tv260 = v164 + v259;\n\tv261 = v260 + 0x138;\nL_006F:\n\tv141 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv146 = v141 == 0;\n\tif (v146) goto L_00C0;\n\tv145 = v141.bones == 0;\n\tif (v145) goto L_00C0;\n\tv281 = Spine.ExposedList`1<Spine.Bone>::GetEnumerator(v141.bones);\nL_0086:\n\tv375 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v75 @ stack_-68_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv313 = v375 == 0;\n\tif (v313) goto L_00B5;\n\tv383 = v325.parent == 0;\n\tv378 = ~v383;\n\tif (v378) goto L_0086;\n\tv376 = this.topLevelBones;\n\tv391 = v376._items;\n\tv392 = v376._version + 1;\n\tv376._version = v392;\n\tv356 = v376._size;\n\tv394 = v376._size < v391.Length;\n\tv369 = ~v394;\n\tif (v369) goto L_00B1;\n\tv358 = v376._size + 1;\n\tv376._size = v358;\n\tv391[v356 @ X11_v8 (System.Int32)] = v325;\n\tgoto L_0086;\nL_00B1:\n\tSystem.Collections.Generic.List`1<Spine.Bone>::AddWithResize(v376, v325);\n\tgoto L_0086;\nL_00B5:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v75 @ stack_-68_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00BC:\n\treturn;\n\tv384 = new System.NullReferenceException();\n\tv389 = new System.NullReferenceException();\n\tv138 = new System.NullReferenceException();\nL_00C0:\n\tv153 = new System.NullReferenceException();\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\nL_00CE:\n\tv179 = v91 != 1;\n\tif (v179) goto L_00DE;\n\tv213 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::MoveNext(v153);\n\tv249 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::MoveNext(v213);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v70 @ stack_-50_v2 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv219 = ~v213.m_value;\n\tif (v219) goto L_00BC;\n\tthrow System.OutOfMemoryException;\nL_00DE:\n\tgoto L_00E4;\n\tX19 = X0;\nL_00E4:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v70 @ stack_-50_v2 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00EB;\n\tv270 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v153);\nL_00EB:\n\tv273 = new System.OutOfMemoryException();\n\tv323 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v273);\n\treturn;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void GatherTopLevelBones()
		{
			//IL_02cf: Expected I, but got O
			//IL_007e: Expected I, but got O
			List<Bone> list = topLevelBones;
			bool flag = topLevelBones == null;
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			nint num = unchecked((nint)null);
			if (!flag)
			{
				int version = list._version + 1;
				list._size = 0;
				list._version = version;
				bool flag2 = list.Count < 1;
				IntPtr intPtr = default(IntPtr);
				nint num2 = intPtr;
				if (!flag2)
				{
					Array.Clear(list._items, 0, list.Count);
					num2 = unchecked((nint)null);
				}
				bool flag3 = skeletonComponent == null;
				ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
				enumerator = enumerator2;
				num = 0;
				if (!flag3)
				{
					Skeleton skeleton = skeletonComponent.Skeleton;
					bool flag4 = skeleton == null;
					enumerator = default(ExposedList<object>.Enumerator);
					num = intPtr;
					if (!flag4)
					{
						bool flag5 = skeleton.Bones == null;
						enumerator = default(ExposedList<object>.Enumerator);
						num = num2;
						if (!flag5)
						{
							ExposedList<Bone>.Enumerator enumerator3 = skeleton.Bones.GetEnumerator();
							Bone bone = default(Bone);
							while (enumerator2.MoveNext())
							{
								if (bone.Parent == null)
								{
									List<Bone> list2 = topLevelBones;
									Bone[] items = list2._items;
									int version2 = list2._version + 1;
									list2._version = version2;
									int count = list2.Count;
									if (list2.Count < items.Length)
									{
										int size = list2.Count + 1;
										list2._size = size;
										items[count] = bone;
									}
									else
									{
										list2.Add(bone);
									}
								}
							}
							enumerator2.Dispose();
							return;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (num == 1)
			{
				bool flag6 = ((ExposedList<Bone>.Enumerator*)ex)->MoveNext();
				bool flag7 = (flag6 ? ((ExposedList<Bone>.Enumerator*)1) : ((ExposedList<Bone>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (((bool*)(flag6 ? 1 : 0))->m_value)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((ExposedList<Bone>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x600051F")]
		[Address(RVA = "0x1559B0C", Offset = "0x1559B0C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.ISkeletonAnimation;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, animatedSkeletonComponent, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37C10]) = v36;\nL_0014:\n\tv39 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv41 = v39 == 0;\n\tif (v41) goto L_005D;\n\tv46 = Spine.Unity.SkeletonRootMotionBase::CalculateAnimationsMovementDelta(this);\n\tgoto L_004E;\n\tv148 = *([v116 @ X8_v5+B0]);\n\tv149 = v148 + 8;\n\tv151 = *([v187 @ X10_v8-8]);\n\tv193 = v151 == v119;\n\tif (v193) goto L_0046;\n\tv173 = v188 - 1;\n\tv171 = v187 + 0x10;\n\tv153 = v188 != 1;\n\tif (v153) goto L_FFFFFFFF;\n\tv174 = 6;\n\tv175 = v10;\n\tv176 = 0xB349B4(v175, v119, v174, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_004E;\nL_0046:\n\tv199 = *([v187 @ X10_v8]);\n\tv200 = v199 + 6;\n\tv201 = v200 << 4;\n\tv202 = v116 + v201;\n\tv203 = v202 + 0x138;\nL_004E:\n\tv209 = Spine.Unity.ISkeletonAnimation::get_Skeleton(animatedSkeletonComponent);\n\tSpine.Unity.SkeletonRootMotionBase::AdjustMovementDeltaToConfiguration(this, &v98 @ stack_-28_v3 (UnityEngine.Vector2), v209);\n\t// 86 MakeStruct v54 @ AGG155DBE4_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v98 @ stack_-28_v3 (UnityEngine.Vector2), v27 @ V1\n\tSpine.Unity.SkeletonRootMotionBase::ApplyRootMotion(this, v54);\nL_005D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleUpdateLocal(ISkeletonAnimation animatedSkeletonComponent)
		{
			//IL_007b: Expected F4, but got O
			if (base.isActiveAndEnabled)
			{
				Vector2 vector = CalculateAnimationsMovementDelta();
				Skeleton skeleton = animatedSkeletonComponent.Skeleton;
				Vector2 localDelta = default(Vector2);
				AdjustMovementDeltaToConfiguration(ref localDelta, skeleton);
				Vector2 localDelta2 = default(Vector2);
				localDelta2.x = localDelta.x;
				object obj = default(object);
				localDelta2.y = (float)obj;
				ApplyRootMotion(localDelta2);
			}
		}

		[Token(Token = "0x6000520")]
		[Address(RVA = "0x1559BFC", Offset = "0x1559BFC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = skeleton.scaleX >= 0;\n\tif (v22) goto L_0019;\n\tv38 = -*([localDelta @ X1 (UnityEngine.Vector2&)]);\n\t*([localDelta @ X1 (UnityEngine.Vector2&)]) = v38;\nL_0019:\n\tv42 = Spine.Skeleton::get_ScaleY(skeleton);\n\tv52 = v42 >= 0;\n\tif (v52) goto L_0029;\n\tv87 = -*([localDelta @ X1 (UnityEngine.Vector2&)+4]);\n\t*([localDelta @ X1 (UnityEngine.Vector2&)+4]) = v87;\nL_0029:\n\tv89 = ~this.transformPositionX;\n\tv90 = ~v89;\n\tif (v90) goto L_002E;\n\t*([localDelta @ X1 (UnityEngine.Vector2&)]) = 0;\nL_002E:\n\tv91 = ~this.transformPositionY;\n\tv85 = ~v91;\n\tif (v85) goto L_0036;\n\t*([localDelta @ X1 (UnityEngine.Vector2&)+4]) = 0;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void AdjustMovementDeltaToConfiguration(ref Vector2 localDelta, Skeleton skeleton)
		{
			//IL_0030: Unsupported input type for neg.
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0053: Expected O, but got I
			if (skeleton.ScaleX < 0f)
			{
				object obj = 0 - localDelta;
				ref Vector2 reference = ref *(Vector2*)obj;
			}
			float scaleY = skeleton.ScaleY;
			if (scaleY < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [localDelta @ X1 (UnityEngine.Vector2&)+4]");
				object obj2 = -0;
			}
			if (!transformPositionX)
			{
				ref Vector2 reference = ref *(Vector2*)null;
			}
			if (!transformPositionY)
			{
				_ = 0;
			}
		}

		[Token(Token = "0x6000521")]
		[Address(RVA = "0x1559C70", Offset = "0x1559C70", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, localDelta, v0, v39, v40, v41, v42, v43, v44);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v33, v34, v35, v36, v37, v38, localDelta, v0, v39, v40, v41, v42, v43, v44);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v33, v34, v35, v36, v37, v38, localDelta, v0, v39, v40, v41, v42, v43, v44);\n\tv81 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v33, v34, v35, v36, v37, v38, localDelta, v0, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37C11]) = v48;\nL_0025:\n\t;\n\tv56 = Spine.Unity.SkeletonRootMotionBase::get_AdditionalScale(this);\n\tv59 = localDelta * localDelta;\n\tv60 = localDelta.y * localDelta;\n\tv62 = v59 * this.rootMotionScaleX;\n\tv63 = v60 * this.rootMotionScaleY;\n\tv64 = Spine.Unity.SkeletonRootMotionBase::get_UsesRigidbody(this);\n\tv69 = v64 == 0;\n\tif (v69) goto L_0049;\n\tv76 = UnityEngine.Component::get_transform(this);\n\tv82 = v76 == 0;\n\tif (v82) goto L_00AA;\n\t// 63 MakeStruct v88 @ AGG155DD34_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v62 @ V9_v2 (System.Single), v63 @ V8_v2 (System.Single), 0\n\tv89 = UnityEngine.Transform::TransformVector(v76, v88);\n\tv157 = this.rigidbodyDisplacement + v89;\n\tthis.rigidbodyDisplacement = v157;\n\tgoto L_0069;\nL_0049:\n\tv79 = UnityEngine.Component::get_transform(this);\n\tv83 = v79 == 0;\n\tif (v83) goto L_00AA;\n\tv121 = UnityEngine.Transform::get_position(v79);\n\tv135 = UnityEngine.Component::get_transform(this);\n\tv139 = v135 == 0;\n\tif (v139) goto L_00AA;\n\t// 93 MakeStruct v160 @ AGG155DD90_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v62 @ V9_v2 (System.Single), v63 @ V8_v2 (System.Single), 0\n\tv203 = UnityEngine.Transform::TransformVector(v135, v160);\n\tv161 = v121 + v203;\n\tv167 = v121.y + v203.y;\n\tv162 = v121.z + v203.z;\n\t// 102 MakeStruct v159 @ AGG155DDA8_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v161 @ V0_v17 (System.Single), v167 @ V1_v15 (System.Single), v162 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_position(v79, v159);\nL_0069:\n\tv140 = this.topLevelBones == 0;\n\tif (v140) goto L_00AA;\n\tv185 = System.Collections.Generic.List`1<Spine.Bone>::GetEnumerator(this.topLevelBones);\nL_007A:\n\tv222 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v97 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv236 = v222 == 0;\n\tif (v236) goto L_009A;\n\tv243 = ~this.transformPositionX;\n\tif (v243) goto L_008C;\n\tv298 = this.rootMotionBone;\n\tv299 = *([v206 @ stack_-78+30]) - v298.x;\n\t*([v206 @ stack_-78+30]) = v299;\nL_008C:\n\tv225 = ~this.transformPositionY;\n\tif (v225) goto L_007A;\n\tv215 = this.rootMotionBone;\n\tv218 = *([v206 @ stack_-78+34]) - v215.y;\n\t*([v206 @ stack_-78+34]) = v218;\n\tgoto L_007A;\nL_009A:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v97 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00A5:\n\treturn;\n\tv336 = new System.NullReferenceException();\n\tv342 = new System.NullReferenceException();\n\tv348 = new System.NullReferenceException();\n\tv134 = new System.NullReferenceException();\nL_00AA:\n\tv151 = new System.NullReferenceException();\n\tgoto L_00B9;\n\tgoto L_00B9;\n\tgoto L_00B9;\n\tgoto L_00B9;\nL_00B9:\n\tv178 = v126 != 1;\n\tif (v178) goto L_00C9;\n\tv187 = System.Collections.Generic.List`1<Spine.Bone>+Enumerator<Spine.Bone>::MoveNext(v151);\n\tv207 = System.Collections.Generic.List`1<Spine.Bone>+Enumerator<Spine.Bone>::MoveNext(v187);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-70_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv193 = ~v187.m_value;\n\tif (v193) goto L_00A5;\n\tthrow System.OutOfMemoryException;\nL_00C9:\n\tgoto L_00CF;\n\tX19 = X0;\nL_00CF:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-70_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00D6;\n\tv238 = System.Collections.Generic.List`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v151);\nL_00D6:\n\tv241 = new System.OutOfMemoryException();\n\tv295 = System.Collections.Generic.List`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v241);\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ApplyRootMotion(Vector2 localDelta)
		{
			//IL_00c5: Expected I, but got O
			//IL_010d: Expected I, but got O
			//IL_0098: Expected O, but got F4
			//IL_01f8: Expected I, but got O
			float additionalScale = AdditionalScale;
			Vector2 vector = default(Vector2);
			float num = vector.x * vector.x;
			float num2 = localDelta.y * vector.x;
			float x = num * rootMotionScaleX;
			float y = num2 * rootMotionScaleY;
			List<object>.Enumerator enumerator;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			nint num3;
			if (UsesRigidbody)
			{
				Transform transform = base.transform;
				bool flag = (object)transform == null;
				enumerator = enumerator2;
				num3 = 0;
				if (!flag)
				{
					Vector3 vector2 = default(Vector3);
					vector2.x = x;
					vector2.y = y;
					vector2.z = 0f;
					Vector3 vector3 = transform.TransformVector(vector2);
					float num4 = rigidbodyDisplacement.x + vector3.x;
					rigidbodyDisplacement = (Vector2)num4;
					goto IL_01d8;
				}
			}
			else
			{
				Transform transform2 = base.transform;
				bool flag2 = (object)transform2 == null;
				enumerator = default(List<object>.Enumerator);
				num3 = unchecked((nint)null);
				if (!flag2)
				{
					Vector3 position = transform2.position;
					Transform transform3 = base.transform;
					bool flag3 = (object)transform3 == null;
					enumerator = default(List<object>.Enumerator);
					num3 = unchecked((nint)null);
					if (!flag3)
					{
						Vector3 vector4 = default(Vector3);
						vector4.x = x;
						vector4.y = y;
						vector4.z = 0f;
						Vector3 vector5 = transform3.TransformVector(vector4);
						float x2 = position.x + vector5.x;
						float y2 = position.y + vector5.y;
						float z = position.z + vector5.z;
						Vector3 position2 = default(Vector3);
						position2.x = x2;
						position2.y = y2;
						position2.z = z;
						transform2.position = position2;
						goto IL_01d8;
					}
				}
			}
			goto IL_02ae;
			IL_02ae:
			NullReferenceException ex = new NullReferenceException();
			if (num3 == 1)
			{
				bool flag4 = ((List<Bone>.Enumerator*)ex)->MoveNext();
				bool flag5 = (flag4 ? ((List<Bone>.Enumerator*)1) : ((List<Bone>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (((bool*)(flag4 ? 1 : 0))->m_value)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<Bone>.Enumerator*)ex2)->Dispose();
			}
			return;
			IL_01d8:
			bool flag6 = topLevelBones == null;
			enumerator = default(List<object>.Enumerator);
			num3 = unchecked((nint)null);
			if (!flag6)
			{
				List<Bone>.Enumerator enumerator3 = topLevelBones.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					if (transformPositionX)
					{
						Bone bone = rootMotionBone;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ stack_-78+30]");
						float num5 = 0f - bone.X;
					}
					if (transformPositionY)
					{
						Bone bone2 = rootMotionBone;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ stack_-78+34]");
						float num6 = 0f - bone2.Y;
					}
				}
				enumerator2.Dispose();
				return;
			}
			goto IL_02ae;
		}

		[Token(Token = "0x6000522")]
		[Address(RVA = "0x1558C1C", Offset = "0x1558C1C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = System.Collections.Generic.List`1<Spine.Bone>;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv58 = \"root\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37C12]) = v46;\nL_0022:\n\tthis.transformPositionX = 0x101;\n\tthis.rootMotionBoneName = \"root\";\n\tthis.rootMotionScaleX = 0f;\n\tv51 = new System.Collections.Generic.List`1<Spine.Bone>();\n\tSystem.Collections.Generic.List`1<Spine.Bone>::.ctor(v51);\n\tthis.topLevelBones = v51;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal SkeletonRootMotionBase()
		{
			transformPositionX = true;
			transformPositionY = true;
			rootMotionBoneName = "root";
			rootMotionScaleX = 0f;
			List<Bone> list = new List<Bone>();
			topLevelBones = list;
		}
	}
}
