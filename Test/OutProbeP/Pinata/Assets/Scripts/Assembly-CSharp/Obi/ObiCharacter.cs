using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CC34", Offset = "0x74CC34")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CC34", Offset = "0x74CC34")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CC34", Offset = "0x74CC34")]
	[Token(Token = "0x2000050")]
	public class ObiCharacter : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000240")]
		[FieldOffset(Offset = "0x18")]
		private float m_MovingTurnSpeed;

		[SerializeField]
		[Token(Token = "0x4000241")]
		[FieldOffset(Offset = "0x1C")]
		private float m_StationaryTurnSpeed;

		[SerializeField]
		[Token(Token = "0x4000242")]
		[FieldOffset(Offset = "0x20")]
		private float m_JumpPower;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x764C00", Offset = "0x764C00")]
		[SerializeField]
		[Token(Token = "0x4000243")]
		[FieldOffset(Offset = "0x24")]
		private float m_GravityMultiplier;

		[SerializeField]
		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x28")]
		private float m_RunCycleLegOffset;

		[SerializeField]
		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x2C")]
		private float m_MoveSpeedMultiplier;

		[SerializeField]
		[Token(Token = "0x4000246")]
		[FieldOffset(Offset = "0x30")]
		private float m_AnimSpeedMultiplier;

		[SerializeField]
		[Token(Token = "0x4000247")]
		[FieldOffset(Offset = "0x34")]
		private float m_GroundCheckDistance;

		[Token(Token = "0x4000248")]
		[FieldOffset(Offset = "0x38")]
		private Rigidbody m_Rigidbody;

		[Token(Token = "0x4000249")]
		[FieldOffset(Offset = "0x40")]
		private Animator m_Animator;

		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x48")]
		private bool m_IsGrounded;

		[Token(Token = "0x400024B")]
		[FieldOffset(Offset = "0x4C")]
		private float m_OrigGroundCheckDistance;

		[Token(Token = "0x400024C")]
		private const float k_Half = 0.5f;

		[Token(Token = "0x400024D")]
		[FieldOffset(Offset = "0x50")]
		private float m_TurnAmount;

		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x54")]
		private float m_ForwardAmount;

		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x58")]
		private Vector3 m_GroundNormal;

		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x64")]
		private float m_CapsuleHeight;

		[Token(Token = "0x4000251")]
		[FieldOffset(Offset = "0x68")]
		private Vector3 m_CapsuleCenter;

		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x78")]
		private CapsuleCollider m_Capsule;

		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x80")]
		private bool m_Crouching;

		[Token(Token = "0x600023F")]
		[Address(RVA = "0x98D704", Offset = "0x98D704", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE05F8]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216F6]) = v38;\nL_0017:\n\tv43 = UnityEngine.LayerMask::NameToLayer(\"Default\");\n\tv50 = UnityEngine.LayerMask::NameToLayer(\"Ignore Raycast\");\n\tUnityEngine.Physics::IgnoreLayerCollision(v43, v50, 1);\n\tv59 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Animator = v59;\n\tv64 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Rigidbody = v64;\n\tv69 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Capsule = v69;\n\tv72 = UnityEngine.CapsuleCollider::get_height(v69);\n\tthis.m_CapsuleHeight = v72;\n\tv78 = UnityEngine.CapsuleCollider::get_center(this.m_Capsule);\n\tthis.m_CapsuleCenter = v78;\n\tthis.m_CapsuleCenter.y = v78.y;\n\tthis.m_CapsuleCenter.z = v78.z;\n\tUnityEngine.Rigidbody::set_constraints(this.m_Rigidbody, 0x70);\n\tthis.m_OrigGroundCheckDistance = this.m_GroundCheckDistance;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			int layer = LayerMask.NameToLayer("Default");
			int layer2 = LayerMask.NameToLayer("Ignore Raycast");
			Physics.IgnoreLayerCollision(layer, layer2, ignore: true);
			Animator component = GetComponent<Animator>();
			m_Animator = component;
			Rigidbody component2 = GetComponent<Rigidbody>();
			m_Rigidbody = component2;
			float height = (m_Capsule = GetComponent<CapsuleCollider>()).height;
			m_CapsuleHeight = height;
			Vector3 vector = (m_CapsuleCenter = m_Capsule.center);
			m_CapsuleCenter.y = vector.y;
			m_CapsuleCenter.z = vector.z;
			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0x98D818", Offset = "0x98D818", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv44 = *([1EAFD18]);\n\tv45 = *([v44 @ X8_v17]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, crouch, jump, methodInfo, v48, v49, v50, v51, move, v0, v2, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20216F7]) = v59;\nL_0024:\n\tv63 = 0x158AD58(&v61 @ stack_-70_v2, 0, v119, methodInfo, v48, v49, v50, v51, move, move.y, move.z, v52, v53, v54, v55, v56);\n\tv76 = move <= 1f;\n\tif (v76) goto L_0038;\n\tv80 = 0x158A620(&v61 @ stack_-70_v2, 0, v119, methodInfo, v48, v49, v50, v51, move, 1f, move.z, v52, v53, v54, v55, v56);\nL_0038:\n\tv86 = UnityEngine.Component::get_transform(this);\n\t// 63 MakeStruct v92 @ AGG98D8B0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61 @ stack_-70_v2, move.y (System.Single), move.z (System.Single)\n\tv93 = UnityEngine.Transform::InverseTransformDirection(v86, v92);\n\tObi.ObiCharacter::CheckGroundStatus(this);\n\tgoto L_0062;\n\tv176 = *([v109 @ X0_v9+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0062;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v109, v91, jump, methodInfo, v48, v49, v50, v51, v93, v95, v96, v52, v53, v54, v55, v56);\nL_0062:\n\t// 98 MakeStruct v121 @ AGG98D910_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_GroundNormal (UnityEngine.Vector3), this.m_GroundNormal.y (System.Single), this.m_GroundNormal.z (System.Single)\n\tv187 = UnityEngine.Vector3::ProjectOnPlane(v93, v121);\n\tgoto L_0079;\n\tv198 = *([v194 @ X0_v12 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0079;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v194, v91, jump, methodInfo, v48, v49, v50, v51, v187, v188, v189, v131, v129, v127, v55, v56);\nL_0079:\n\tv207 = 0x6D29A0(UnityEngine.Mathf, 0, v119, methodInfo, v48, v49, v50, v51, v187, v187.z, v187.z, this.m_GroundNormal, this.m_GroundNormal.y, this.m_GroundNormal.z, v55, v56);\n\tthis.m_TurnAmount = v187;\n\tthis.m_ForwardAmount = v187.z;\n\tObi.ObiCharacter::ApplyExtraTurnRotation(this);\n\tv153 = ~this.m_IsGrounded;\n\tif (v153) goto L_0088;\n\tObi.ObiCharacter::HandleGroundedMovement(this, crouch, v119);\n\tgoto L_008B;\nL_0088:\n\tObi.ObiCharacter::HandleAirborneMovement(this);\nL_008B:\n\tObi.ObiCharacter::ScaleCapsuleForCrouching(this, crouch);\n\tObi.ObiCharacter::PreventStandingInLowHeadroom(this);\n\tObi.ObiCharacter::UpdateAnimator(this, v187);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Move(Vector3 move, bool crouch, bool jump)
		{
			//IL_0035: Expected F4, but got O
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			Vector3 vector = default(Vector3);
			if (vector.x > 1f)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A620 (inside UnityEngine.Vector3::get_zero +0x6C)");
			}
			Transform transform = base.transform;
			Vector3 direction = default(Vector3);
			object obj = default(object);
			direction.x = (float)obj;
			direction.y = move.y;
			direction.z = move.z;
			Vector3 vector2 = transform.InverseTransformDirection(direction);
			CheckGroundStatus();
			Vector3 planeNormal = default(Vector3);
			planeNormal.x = m_GroundNormal.x;
			planeNormal.y = m_GroundNormal.y;
			planeNormal.z = m_GroundNormal.z;
			Vector3 move2 = Vector3.ProjectOnPlane(vector2, planeNormal);
			Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
			m_TurnAmount = move2.x;
			m_ForwardAmount = move2.z;
			ApplyExtraTurnRotation();
			if (m_IsGrounded)
			{
				bool jump2 = default(bool);
				HandleGroundedMovement(crouch, jump2);
			}
			else
			{
				HandleAirborneMovement();
			}
			ScaleCapsuleForCrouching(crouch);
			PreventStandingInLowHeadroom();
			UpdateAnimator(move2);
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0x98DE98", Offset = "0x98DE98", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1ED73D0]);\n\tv35 = *([v34 @ X8_v24]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, crouch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20216F8]) = v53;\nL_001C:\n\tv55 = ~this.m_IsGrounded;\n\tif (v55) goto L_005F;\n\tv57 = crouch == 0;\n\tif (v57) goto L_005F;\n\tv62 = this.m_Crouching + 3;\n\tv63 = ~v62;\n\tv65 = v63 & 3;\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_00E6;\n\tv245 = UnityEngine.CapsuleCollider::get_height(this.m_Capsule);\n\tv247 = v245 * 0.5f;\n\tUnityEngine.CapsuleCollider::set_height(this.m_Capsule, v247);\n\tv298 = UnityEngine.CapsuleCollider::get_center(this.m_Capsule);\n\tgoto L_0051;\n\tv318 = *([v309 @ X0_v28+E0]);\n\tv319 = v318 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_0051;\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v309, v297, methodInfo, v38, v39, v40, v41, v42, v298, v305, v306, v46, v47, v48, v49, v50);\nL_0051:\n\tv210 = UnityEngine.Vector3::op_Division(v298, 2f);\n\tUnityEngine.CapsuleCollider::set_center(this.m_Capsule, v210);\n\tthis.m_Crouching = 1;\n\tgoto L_00E6;\nL_005F:\n\tv69 = UnityEngine.Rigidbody::get_position(this.m_Rigidbody);\n\tgoto L_0072;\n\tv287 = *([v239 @ X0_v6+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_0072;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v239, v68, methodInfo, v38, v39, v40, v41, v42, v69, v235, v236, v46, v47, v48, v49, v50);\nL_0072:\n\tv135 = UnityEngine.Vector3::get_up();\n\tv295 = UnityEngine.CapsuleCollider::get_radius(this.m_Capsule);\n\tv304 = UnityEngine.Vector3::op_Multiply(v135, v295);\n\tv317 = UnityEngine.Vector3::op_Multiply(v304, 0.5f);\n\tv337 = UnityEngine.Vector3::op_Addition(v69, v317);\n\tv341 = UnityEngine.Vector3::get_up();\n\tv82 = 0;\n\tv345 = 0x10CCD20(&v82 @ stack_-78_v3, 0, methodInfo, v38, v39, v40, v41, v42, v337, v337.y, v337.z, v341, v341.y, v341.z, v49, v50);\n\tv137 = UnityEngine.CapsuleCollider::get_radius(this.m_Capsule);\n\tv346 = v137 * 0.5f;\n\tv121 = this.m_CapsuleHeight - v346;\n\tv348 = UnityEngine.CapsuleCollider::get_radius(this.m_Capsule);\n\tv138 = v348 * 0.5f;\n\tv79 = 0;\n\tv216 = UnityEngine.Physics::SphereCast(&v79 @ stack_-90_v3, v138, v121, 0xFFFFFFFB, 1);\n\tv219 = v216 == 0;\n\tif (v219) goto L_00CF;\n\tthis.m_Crouching = 1;\n\tgoto L_00E6;\nL_00CF:\n\tUnityEngine.CapsuleCollider::set_height(this.m_Capsule, this.m_CapsuleHeight);\n\t// 215 MakeStruct v170 @ AGG98E114_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_CapsuleCenter (UnityEngine.Vector3), this.m_CapsuleCenter.y (System.Single), this.m_CapsuleCenter.z (System.Single)\n\tUnityEngine.CapsuleCollider::set_center(this.m_Capsule, v170);\n\tthis.m_Crouching = 0;\nL_00E6:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ScaleCapsuleForCrouching(bool crouch)
		{
			//IL_0032: Expected O, but got I4
			//IL_003b: Expected I4, but got O
			//IL_016f: Expected O, but got I4
			//IL_01e0: Expected O, but got I4
			//IL_01fb: Expected O, but got Ref
			if (m_IsGrounded && crouch)
			{
				object obj = (m_Crouching ? 1 : 0) + 3;
				int num = (int)(~obj);
				if ((num & 3) == 0)
				{
					float height = m_Capsule.height;
					float height2 = height * 0.5f;
					m_Capsule.height = height2;
					Vector3 center = m_Capsule.center;
					Vector3 center2 = center / 2f;
					m_Capsule.center = center2;
					m_Crouching = true;
				}
				return;
			}
			Vector3 position = m_Rigidbody.position;
			Vector3 up = Vector3.up;
			float radius = m_Capsule.radius;
			Vector3 vector = up * radius;
			Vector3 vector2 = vector * 0.5f;
			Vector3 vector3 = position + vector2;
			Vector3 up2 = Vector3.up;
			object obj2 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCD20 (inside UnityEngine.RangeAttribute::.ctor +0x4C)");
			float radius2 = m_Capsule.radius;
			float num2 = radius2 * 0.5f;
			float maxDistance = m_CapsuleHeight - num2;
			float radius3 = m_Capsule.radius;
			float radius4 = radius3 * 0.5f;
			object obj3 = 0;
			if (Physics.SphereCast((Ray)(&obj3), radius4, maxDistance, -5, QueryTriggerInteraction.Ignore))
			{
				m_Crouching = true;
				return;
			}
			m_Capsule.height = m_CapsuleHeight;
			Vector3 center3 = default(Vector3);
			center3.x = m_CapsuleCenter.x;
			center3.y = m_CapsuleCenter.y;
			center3.z = m_CapsuleCenter.z;
			m_Capsule.center = center3;
			m_Crouching = false;
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0x98E144", Offset = "0x98E144", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EF56E0]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20216F9]) = v50;\nL_001A:\n\tv52 = ~this.m_Crouching;\n\tv53 = ~v52;\n\tif (v53) goto L_0096;\n\tv132 = UnityEngine.Rigidbody::get_position(this.m_Rigidbody);\n\tgoto L_0034;\n\tv217 = *([v213 @ X0_v6+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_0034;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v213, v131, v34, v35, v36, v37, v38, v39, v132, v209, v210, v43, v44, v45, v46, v47);\nL_0034:\n\tv161 = UnityEngine.Vector3::get_up();\n\tv225 = UnityEngine.CapsuleCollider::get_radius(this.m_Capsule);\n\tv231 = UnityEngine.Vector3::op_Multiply(v161, v225);\n\tv236 = UnityEngine.Vector3::op_Multiply(v231, 0.5f);\n\tv246 = UnityEngine.Vector3::op_Addition(v132, v236);\n\tv250 = UnityEngine.Vector3::get_up();\n\tv67 = 0;\n\tv254 = 0x10CCD20(&v67 @ stack_-68_v3, 0, v34, v35, v36, v37, v38, v39, v246, v246.y, v246.z, v250, v250.y, v250.z, v46, v47);\n\tv163 = UnityEngine.CapsuleCollider::get_radius(this.m_Capsule);\n\tv255 = v163 * 0.5f;\n\tv104 = this.m_CapsuleHeight - v255;\n\tv257 = UnityEngine.CapsuleCollider::get_radius(this.m_Capsule);\n\tv110 = v257 * 0.5f;\n\tv64 = 0;\n\tv114 = UnityEngine.Physics::SphereCast(&v64 @ stack_-80_v2, v110, v104, 0xFFFFFFFB, 1);\n\tv116 = v114 == 0;\n\tif (v116) goto L_0096;\n\tthis.m_Crouching = 1;\nL_0096:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void PreventStandingInLowHeadroom()
		{
			//IL_0086: Expected O, but got I4
			//IL_00f7: Expected O, but got I4
			//IL_0112: Expected O, but got Ref
			if (!m_Crouching)
			{
				Vector3 position = m_Rigidbody.position;
				Vector3 up = Vector3.up;
				float radius = m_Capsule.radius;
				Vector3 vector = up * radius;
				Vector3 vector2 = vector * 0.5f;
				Vector3 vector3 = position + vector2;
				Vector3 up2 = Vector3.up;
				object obj = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCD20 (inside UnityEngine.RangeAttribute::.ctor +0x4C)");
				float radius2 = m_Capsule.radius;
				float num = radius2 * 0.5f;
				float maxDistance = m_CapsuleHeight - num;
				float radius3 = m_Capsule.radius;
				float radius4 = radius3 * 0.5f;
				object obj2 = 0;
				if (Physics.SphereCast((Ray)(&obj2), radius4, maxDistance, -5, QueryTriggerInteraction.Ignore))
				{
					m_Crouching = true;
				}
			}
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0x98E2FC", Offset = "0x98E2FC", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = &v16 @ stack_-10_v2;\n\t*([v15 @ X29_v1-30]) = move;\n\t*([v15 @ X29_v1-2C]) = move.y;\n\t*([v15 @ X29_v1-28]) = move.z;\n\tgoto L_0021;\n\tv25 = *([1EBBF08]);\n\tv26 = *([v25 @ X8_v33]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, move, v0, v2, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20216FA]) = v42;\nL_0021:\n\tv50 = UnityEngine.Time::get_deltaTime();\n\tUnityEngine.Animator::SetFloat(this.m_Animator, \"Forward\", this.m_ForwardAmount, 0.1f, v50);\n\tv72 = UnityEngine.Time::get_deltaTime();\n\tUnityEngine.Animator::SetFloat(this.m_Animator, \"Turn\", this.m_TurnAmount, 0.1f, v72);\n\tUnityEngine.Animator::SetBool(this.m_Animator, \"Crouch\", this.m_Crouching);\n\tUnityEngine.Animator::SetBool(this.m_Animator, \"OnGround\", this.m_IsGrounded);\n\tv295 = ~this.m_IsGrounded;\n\tv296 = ~v295;\n\tif (v296) goto L_006B;\n\tv73 = UnityEngine.Rigidbody::get_velocity(this.m_Rigidbody);\n\tv223 = v73.z;\n\tUnityEngine.Animator::SetFloat(this.m_Animator, \"Jump\", v73.y);\nL_006B:\n\tv306 = UnityEngine.Animator::GetCurrentAnimatorStateInfo(this.m_Animator, 0);\n\tv170 = v306.m_Name;\n\tv311 = 0x1638F18(&v170 @ stack_-98_v2 (System.Int32), 0, 0, 0, v31, v32, v33, v34, v306.m_Length, v306.m_Name, v223, v35, v36, v37, v38, v39);\n\tgoto L_008C;\n\tv320 = *([v316 @ X0_v17+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_008C;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v316, v182, v189, v63, v31, v32, v33, v34, v308, v309, v223, v35, v36, v37, v38, v39);\nL_008C:\n\tv327 = v306.m_Length + this.m_RunCycleLegOffset;\n\tv330 = UnityEngine.Mathf::Repeat(v327, 1f);\n\tv97 = v330 >= 0.5f;\n\tif (v97) goto L_FFFFFFFF;\n\tgoto L_00A3;\nL_00A3:\n\tv335 = ~this.m_IsGrounded;\n\tif (v335) goto L_00C7;\n\tv196 = v195 * this.m_ForwardAmount;\n\tUnityEngine.Animator::SetFloat(this.m_Animator, \"JumpLeg\", v196);\n\tv340 = ~this.m_IsGrounded;\n\tif (v340) goto L_00C7;\n\tv346 = &v16 @ stack_-10_v2 - 0x30;\n\tv338 = 0x158AD58(v346, 0, 0, 0, v31, v32, v33, v34, v196, this.m_ForwardAmount, v223, v35, v36, v37, v38, v39);\n\tv93 = v196 <= 0;\n\tif (v93) goto L_00C7;\n\tv278 = this.m_Animator;\n\tv276 = this.m_AnimSpeedMultiplier;\n\tgoto L_00CC;\nL_00C7:\n\tv278 = this.m_Animator;\nL_00CC:\n\tUnityEngine.Animator::set_speed(v278, v276);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateAnimator(Vector3 move)
		{
			//IL_0204: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = move.y;
			_ = move.z;
			float deltaTime = Time.deltaTime;
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, deltaTime);
			float deltaTime2 = Time.deltaTime;
			m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, deltaTime2);
			m_Animator.SetBool("Crouch", m_Crouching);
			m_Animator.SetBool("OnGround", m_IsGrounded);
			bool flag = !m_IsGrounded;
			bool flag2 = !flag;
			float num = deltaTime2;
			if (!flag2)
			{
				Vector3 velocity = m_Rigidbody.velocity;
				num = velocity.z;
				m_Animator.SetFloat("Jump", velocity.y);
			}
			AnimatorStateInfo currentAnimatorStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
			int shortNameHash = currentAnimatorStateInfo.shortNameHash;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1638F18 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x98)");
			float t = currentAnimatorStateInfo.length + m_RunCycleLegOffset;
			float num2 = Mathf.Repeat(t, 1f);
			float num3 = ((!(num2 < 0.5f)) ? (-1f) : 1f);
			Animator animator;
			float speed;
			if (m_IsGrounded)
			{
				float num4 = num3 * m_ForwardAmount;
				m_Animator.SetFloat("JumpLeg", num4);
				if (m_IsGrounded)
				{
					object obj3 = (long)(IntPtr)obj2 - 48L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
					if (num4 > 0f)
					{
						animator = m_Animator;
						speed = m_AnimSpeedMultiplier;
						goto IL_0299;
					}
				}
			}
			animator = m_Animator;
			speed = 1f;
			goto IL_0299;
			IL_0299:
			animator.speed = speed;
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0x98DD84", Offset = "0x98DD84", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1F07120]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20216FB]) = v46;\nL_0018:\n\tv48 = UnityEngine.Physics::get_gravity();\n\tgoto L_0031;\n\tv61 = *([v56 @ X0_v3+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0031;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v30, v31, v32, v33, v34, v35, v48, v49, v50, v39, v40, v41, v42, v43);\nL_0031:\n\tv74 = UnityEngine.Vector3::op_Multiply(v48, this.m_GravityMultiplier);\n\tv81 = UnityEngine.Physics::get_gravity();\n\tv93 = UnityEngine.Vector3::op_Subtraction(v74, v81);\n\tUnityEngine.Rigidbody::AddForce(this.m_Rigidbody, v93);\n\tv109 = UnityEngine.Rigidbody::get_velocity(this.m_Rigidbody);\n\tv113 = v109.y >= 0;\n\tif (v113) goto L_FFFFFFFF;\n\tv142 = this.m_OrigGroundCheckDistance;\n\tgoto L_0063;\nL_0063:\n\tthis.m_GroundCheckDistance = v142;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleAirborneMovement()
		{
			Vector3 gravity = Physics.gravity;
			Vector3 vector = gravity * m_GravityMultiplier;
			Vector3 gravity2 = Physics.gravity;
			Vector3 force = vector - gravity2;
			m_Rigidbody.AddForce(force);
			float groundCheckDistance = ((!(m_Rigidbody.velocity.y < 0f)) ? 0.01f : m_OrigGroundCheckDistance);
			m_GroundCheckDistance = groundCheckDistance;
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0x98DC3C", Offset = "0x98DC3C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EA6780]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, crouch, jump, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20216FC]) = v48;\nL_001E:\n\tv54 = crouch == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0075;\n\tv57 = jump == 0;\n\tif (v57) goto L_0075;\n\tv196 = UnityEngine.Animator::GetCurrentAnimatorStateInfo(this.m_Animator, 0);\n\tv110 = v196.m_Name;\n\tv119 = 0x1638E8C(&v110 @ stack_-98_v4 (System.Int32), \"Grounded\", 0, methodInfo, v34, v35, v36, v37, v196.m_Length, v196.m_Name, v40, v41, v42, v43, v44, v45);\n\tv235 = v119 & 1;\n\tv122 = v235 == 0;\n\tif (v122) goto L_0075;\n\tv208 = UnityEngine.Rigidbody::get_velocity(this.m_Rigidbody);\n\tv238 = UnityEngine.Rigidbody::get_velocity(this.m_Rigidbody);\n\tv110 = 0;\n\tv245 = 0x1586898(&v110 @ stack_-98_v4 (System.Int32), 0, 0, methodInfo, v34, v35, v36, v37, v208, this.m_JumpPower, v238.z, v41, v42, v43, v44, v45);\n\t// 96 MakeStruct v59 @ AGG98DD38_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v196.m_Path (System.Int32), 0\n\tUnityEngine.Rigidbody::set_velocity(this.m_Rigidbody, v59);\n\tthis.m_IsGrounded = 0;\n\tUnityEngine.Animator::set_applyRootMotion(this.m_Animator, 0);\n\tthis.m_GroundCheckDistance = 0.1f;\nL_0075:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleGroundedMovement(bool crouch, bool jump)
		{
			//IL_00e3: Expected F4, but got I4
			if (!crouch && jump)
			{
				AnimatorStateInfo currentAnimatorStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
				int shortNameHash = currentAnimatorStateInfo.shortNameHash;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1638E8C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0xC)");
				object obj = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					Vector3 velocity = m_Rigidbody.velocity;
					Vector3 velocity2 = m_Rigidbody.velocity;
					shortNameHash = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					Vector3 velocity3 = default(Vector3);
					velocity3.x = 0f;
					velocity3.y = currentAnimatorStateInfo.m_Path;
					velocity3.z = 0f;
					m_Rigidbody.velocity = velocity3;
					m_IsGrounded = false;
					m_Animator.applyRootMotion = false;
					m_GroundCheckDistance = 0.1f;
				}
			}
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0x98DB68", Offset = "0x98DB68", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EA7A10]);\n\tv25 = *([v24 @ X8_v9]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20216FD]) = v44;\nL_001F:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0029:\n\tv65 = UnityEngine.Mathf::Lerp(this.m_StationaryTurnSpeed, this.m_MovingTurnSpeed, this.m_ForwardAmount);\n\tv69 = UnityEngine.Component::get_transform(this);\n\tv73 = UnityEngine.Time::get_deltaTime();\n\tv76 = v65 * this.m_TurnAmount;\n\tv85 = v76 * v73;\n\tUnityEngine.Transform::Rotate(v69, 0f, v85, 0f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ApplyExtraTurnRotation()
		{
			float num = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			Transform transform = base.transform;
			float deltaTime = Time.deltaTime;
			float num2 = num * m_TurnAmount;
			float yAngle = num2 * deltaTime;
			transform.Rotate(0f, yAngle, 0f);
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0x98E54C", Offset = "0x98E54C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EA8820]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20216FE]) = v46;\nL_0018:\n\tv48 = ~this.m_IsGrounded;\n\tif (v48) goto L_006C;\n\tv60 = UnityEngine.Animator::get_deltaPosition(this.m_Animator);\n\tgoto L_0037;\n\tv140 = *([v136 @ X0_v5+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0037;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v136, v59, v30, v31, v32, v33, v34, v35, v60, v129, v130, v39, v40, v41, v42, v43);\nL_0037:\n\tv151 = UnityEngine.Vector3::op_Multiply(v60, this.m_MoveSpeedMultiplier);\n\tv157 = UnityEngine.Time::get_deltaTime();\n\tv84 = UnityEngine.Vector3::op_Division(v151, v157);\n\tv85 = UnityEngine.Rigidbody::get_velocity(this.m_Rigidbody);\n\t// 96 MakeStruct v98 @ AGG98E650_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v84 @ V0_v7 (UnityEngine.Vector3), v85.y (System.Single), v84.z (System.Single)\n\tUnityEngine.Rigidbody::set_velocity(this.m_Rigidbody, v98);\n\treturn;\nL_006C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAnimatorMove()
		{
			if (m_IsGrounded)
			{
				Vector3 deltaPosition = m_Animator.deltaPosition;
				Vector3 vector = deltaPosition * m_MoveSpeedMultiplier;
				float deltaTime = Time.deltaTime;
				Vector3 vector2 = vector / deltaTime;
				Vector3 velocity = m_Rigidbody.velocity;
				Vector3 velocity2 = default(Vector3);
				velocity2.x = vector2.x;
				velocity2.y = velocity.y;
				velocity2.z = vector2.z;
				m_Rigidbody.velocity = velocity2;
			}
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x98D9D0", Offset = "0x98D9D0", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EA78D0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20216FF]) = v44;\nL_001B:\n\tv50 = 0;\n\tv52 = UnityEngine.Component::get_transform(this);\n\tv55 = UnityEngine.Transform::get_position(v52);\n\tgoto L_0034;\n\tv121 = *([v117 @ X0_v6+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0034;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v117, v54, v28, v29, v30, v31, v32, v33, v55, v111, v112, v37, v38, v39, v40, v41);\nL_0034:\n\tv129 = UnityEngine.Vector3::get_up();\n\tv174 = UnityEngine.Vector3::op_Multiply(v129, 0.1f);\n\tv184 = UnityEngine.Vector3::op_Addition(v55, v174);\n\tv188 = UnityEngine.Vector3::get_down();\n\tv192 = UnityEngine.Physics::Raycast(v184, v188, &v50 @ stack_-70_v1 (UnityEngine.RaycastHit), this.m_GroundCheckDistance, 0xFFFFFFFB);\n\tv194 = v192 == 0;\n\tif (v194) goto L_006E;\n\tv196 = 0x164C884(&v50 @ stack_-70_v1 (UnityEngine.RaycastHit), 0, 0, v29, v30, v31, v32, v33, v184, v184.y, v184.z, v188, v188.y, v188.z, this.m_GroundCheckDistance, v41);\n\tv158 = this.m_Animator;\n\tthis.m_GroundNormal = v184;\n\tthis.m_GroundNormal.y = v184.y;\n\tthis.m_GroundNormal.z = v184.z;\n\tthis.m_IsGrounded = 1;\n\tgoto L_0085;\nL_006E:\n\tthis.m_IsGrounded = 0;\n\tgoto L_007A;\n\tv201 = *([v197 @ X0_v15+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_007A;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v197, v98, v63, v29, v30, v31, v32, v33, v94, v91, v88, v80, v75, v73, v65, v41);\nL_007A:\n\tv95 = UnityEngine.Vector3::get_up();\n\tv158 = this.m_Animator;\n\tthis.m_GroundNormal = v95;\n\tthis.m_GroundNormal.y = v95.y;\n\tthis.m_GroundNormal.z = v95.z;\nL_0085:\n\tUnityEngine.Animator::set_applyRootMotion(v158, v156);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckGroundStatus()
		{
			RaycastHit hitInfo = default(RaycastHit);
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 up = Vector3.up;
			Vector3 vector = up * 0.1f;
			Vector3 vector2 = position + vector;
			Vector3 down = Vector3.down;
			Animator animator;
			bool applyRootMotion;
			if (Physics.Raycast(vector2, down, out hitInfo, m_GroundCheckDistance, -5))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
				animator = m_Animator;
				m_GroundNormal = vector2;
				m_GroundNormal.y = vector2.y;
				m_GroundNormal.z = vector2.z;
				m_IsGrounded = true;
				applyRootMotion = true;
			}
			else
			{
				m_IsGrounded = false;
				Vector3 up2 = Vector3.up;
				animator = m_Animator;
				m_GroundNormal = up2;
				m_GroundNormal.y = up2.y;
				m_GroundNormal.z = up2.z;
				applyRootMotion = false;
			}
			animator.applyRootMotion = applyRootMotion;
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x98E66C", Offset = "0x98E66C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_MovingTurnSpeed = *([1817F00]);\n\tthis.m_RunCycleLegOffset = *([1817F10]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCharacter()
		{
			//IL_0018: Expected F4, but got I
			//IL_002a: Expected F4, but got I
			base._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1817F00]");
			m_MovingTurnSpeed = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1817F10]");
			m_RunCycleLegOffset = 0f;
		}
	}
}
