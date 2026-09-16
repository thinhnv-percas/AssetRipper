using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x74C6A4", Offset = "0x74C6A4")]
[Token(Token = "0x2000003")]
public class DynamicBone : MonoBehaviour
{
	[Token(Token = "0x200044F")]
	public enum UpdateMode
	{
		[Token(Token = "0x400203E")]
		Normal = 0,
		[Token(Token = "0x400203F")]
		AnimatePhysics = 1,
		[Token(Token = "0x4002040")]
		UnscaledTime = 2
	}

	[Token(Token = "0x2000450")]
	public enum FreezeAxis
	{
		[Token(Token = "0x4002042")]
		None = 0,
		[Token(Token = "0x4002043")]
		X = 1,
		[Token(Token = "0x4002044")]
		Y = 2,
		[Token(Token = "0x4002045")]
		Z = 3
	}

	[Token(Token = "0x2000451")]
	private class Particle
	{
		[Token(Token = "0x4002046")]
		[FieldOffset(Offset = "0x10")]
		public Transform m_Transform;

		[Token(Token = "0x4002047")]
		[FieldOffset(Offset = "0x18")]
		public int m_ParentIndex;

		[Token(Token = "0x4002048")]
		[FieldOffset(Offset = "0x1C")]
		public float m_Damping;

		[Token(Token = "0x4002049")]
		[FieldOffset(Offset = "0x20")]
		public float m_Elasticity;

		[Token(Token = "0x400204A")]
		[FieldOffset(Offset = "0x24")]
		public float m_Stiffness;

		[Token(Token = "0x400204B")]
		[FieldOffset(Offset = "0x28")]
		public float m_Inert;

		[Token(Token = "0x400204C")]
		[FieldOffset(Offset = "0x2C")]
		public float m_Friction;

		[Token(Token = "0x400204D")]
		[FieldOffset(Offset = "0x30")]
		public float m_Radius;

		[Token(Token = "0x400204E")]
		[FieldOffset(Offset = "0x34")]
		public float m_BoneLength;

		[Token(Token = "0x400204F")]
		[FieldOffset(Offset = "0x38")]
		public bool m_isCollide;

		[Token(Token = "0x4002050")]
		[FieldOffset(Offset = "0x3C")]
		public Vector3 m_Position;

		[Token(Token = "0x4002051")]
		[FieldOffset(Offset = "0x48")]
		public Vector3 m_PrevPosition;

		[Token(Token = "0x4002052")]
		[FieldOffset(Offset = "0x54")]
		public Vector3 m_EndOffset;

		[Token(Token = "0x4002053")]
		[FieldOffset(Offset = "0x60")]
		public Vector3 m_InitLocalPosition;

		[Token(Token = "0x4002054")]
		[FieldOffset(Offset = "0x6C")]
		public Quaternion m_InitLocalRotation;

		[Token(Token = "0x6001549")]
		[Address(RVA = "0xA01A1C", Offset = "0xA01A1C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC1C60]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C64]) = v38;\nL_0014:\n\tthis.m_ParentIndex = 0xFFFFFFFF;\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv54 = UnityEngine.Vector3::get_zero();\n\tthis.m_Position = v54;\n\tthis.m_Position.y = v54.y;\n\tthis.m_Position.z = v54.z;\n\tv58 = UnityEngine.Vector3::get_zero();\n\tthis.m_PrevPosition = v58;\n\tthis.m_PrevPosition.y = v58.y;\n\tthis.m_PrevPosition.z = v58.z;\n\tv62 = UnityEngine.Vector3::get_zero();\n\tthis.m_EndOffset = v62;\n\tthis.m_EndOffset.y = v62.y;\n\tthis.m_EndOffset.z = v62.z;\n\tv66 = UnityEngine.Vector3::get_zero();\n\tthis.m_InitLocalPosition = v66;\n\tthis.m_InitLocalPosition.y = v66.y;\n\tthis.m_InitLocalPosition.z = v66.z;\n\tgoto L_004A;\n\tv75 = *([v71 @ X0_v8+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_004A;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v22, v23, v24, v25, v26, v27, v66, v67, v68, v31, v32, v33, v34, v35);\nL_004A:\n\tv83 = UnityEngine.Quaternion::get_identity();\n\tthis.m_InitLocalRotation = v83;\n\tthis.m_InitLocalRotation.y = v83.y;\n\tthis.m_InitLocalRotation.z = v83.z;\n\tthis.m_InitLocalRotation.w = v83.w;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Particle()
		{
			m_ParentIndex = -1;
			Vector3 vector = (m_Position = Vector3.zero);
			m_Position.y = vector.y;
			m_Position.z = vector.z;
			Vector3 vector2 = (m_PrevPosition = Vector3.zero);
			m_PrevPosition.y = vector2.y;
			m_PrevPosition.z = vector2.z;
			Vector3 vector3 = (m_EndOffset = Vector3.zero);
			m_EndOffset.y = vector3.y;
			m_EndOffset.z = vector3.z;
			Vector3 vector4 = (m_InitLocalPosition = Vector3.zero);
			m_InitLocalPosition.y = vector4.y;
			m_InitLocalPosition.z = vector4.z;
			Quaternion quaternion = (m_InitLocalRotation = Quaternion.identity);
			m_InitLocalRotation.y = quaternion.y;
			m_InitLocalRotation.z = quaternion.z;
			m_InitLocalRotation.w = quaternion.w;
		}
	}

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7638B8", Offset = "0x7638B8")]
	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x18")]
	public Transform m_Root;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7638F0", Offset = "0x7638F0")]
	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x20")]
	public float m_UpdateRate;

	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x24")]
	public UpdateMode m_UpdateMode;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763928", Offset = "0x763928")]
	[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x763928", Offset = "0x763928")]
	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x28")]
	public float m_Damping;

	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x30")]
	public AnimationCurve m_DampingDistrib;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76397C", Offset = "0x76397C")]
	[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x76397C", Offset = "0x76397C")]
	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x38")]
	public float m_Elasticity;

	[Token(Token = "0x4000009")]
	[FieldOffset(Offset = "0x40")]
	public AnimationCurve m_ElasticityDistrib;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7639D0", Offset = "0x7639D0")]
	[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7639D0", Offset = "0x7639D0")]
	[Token(Token = "0x400000A")]
	[FieldOffset(Offset = "0x48")]
	public float m_Stiffness;

	[Token(Token = "0x400000B")]
	[FieldOffset(Offset = "0x50")]
	public AnimationCurve m_StiffnessDistrib;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763A24", Offset = "0x763A24")]
	[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x763A24", Offset = "0x763A24")]
	[Token(Token = "0x400000C")]
	[FieldOffset(Offset = "0x58")]
	public float m_Inert;

	[Token(Token = "0x400000D")]
	[FieldOffset(Offset = "0x60")]
	public AnimationCurve m_InertDistrib;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763A78", Offset = "0x763A78")]
	[Token(Token = "0x400000E")]
	[FieldOffset(Offset = "0x68")]
	public float m_Friction;

	[Token(Token = "0x400000F")]
	[FieldOffset(Offset = "0x70")]
	public AnimationCurve m_FrictionDistrib;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763AB0", Offset = "0x763AB0")]
	[Token(Token = "0x4000010")]
	[FieldOffset(Offset = "0x78")]
	public float m_Radius;

	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x80")]
	public AnimationCurve m_RadiusDistrib;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763AE8", Offset = "0x763AE8")]
	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x88")]
	public float m_EndLength;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763B20", Offset = "0x763B20")]
	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x8C")]
	public Vector3 m_EndOffset;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763B58", Offset = "0x763B58")]
	[Token(Token = "0x4000014")]
	[FieldOffset(Offset = "0x98")]
	public Vector3 m_Gravity;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763B90", Offset = "0x763B90")]
	[Token(Token = "0x4000015")]
	[FieldOffset(Offset = "0xA4")]
	public Vector3 m_Force;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763BC8", Offset = "0x763BC8")]
	[Token(Token = "0x4000016")]
	[FieldOffset(Offset = "0xB0")]
	public List<DynamicBoneColliderBase> m_Colliders;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763C00", Offset = "0x763C00")]
	[Token(Token = "0x4000017")]
	[FieldOffset(Offset = "0xB8")]
	public List<Transform> m_Exclusions;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763C38", Offset = "0x763C38")]
	[Token(Token = "0x4000018")]
	[FieldOffset(Offset = "0xC0")]
	public FreezeAxis m_FreezeAxis;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763C70", Offset = "0x763C70")]
	[Token(Token = "0x4000019")]
	[FieldOffset(Offset = "0xC4")]
	public bool m_DistantDisable;

	[Token(Token = "0x400001A")]
	[FieldOffset(Offset = "0xC8")]
	public Transform m_ReferenceObject;

	[Token(Token = "0x400001B")]
	[FieldOffset(Offset = "0xD0")]
	public float m_DistanceToObject;

	[Token(Token = "0x400001C")]
	[FieldOffset(Offset = "0xD4")]
	private Vector3 m_LocalGravity;

	[Token(Token = "0x400001D")]
	[FieldOffset(Offset = "0xE0")]
	private Vector3 m_ObjectMove;

	[Token(Token = "0x400001E")]
	[FieldOffset(Offset = "0xEC")]
	private Vector3 m_ObjectPrevPosition;

	[Token(Token = "0x400001F")]
	[FieldOffset(Offset = "0xF8")]
	private float m_BoneTotalLength;

	[Token(Token = "0x4000020")]
	[FieldOffset(Offset = "0xFC")]
	private float m_ObjectScale;

	[Token(Token = "0x4000021")]
	[FieldOffset(Offset = "0x100")]
	private float m_Time;

	[Token(Token = "0x4000022")]
	[FieldOffset(Offset = "0x104")]
	private float m_Weight;

	[Token(Token = "0x4000023")]
	[FieldOffset(Offset = "0x108")]
	private bool m_DistantDisabled;

	[Token(Token = "0x4000024")]
	[FieldOffset(Offset = "0x110")]
	private List<Particle> m_Particles;

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x9FEFFC", Offset = "0x9FEFFC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDynamicBone::SetupParticles(this);\n\treturn;\n")]
	private void Start()
	{
		SetupParticles();
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x9FF17C", Offset = "0x9FF17C", Length = "0x30")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.m_UpdateMode != 1;\n\tif (v11) goto L_0020;\n\tv24 = this.m_Weight <= 0;\n\tif (v24) goto L_0020;\n\tv42 = ~this.m_DistantDisable;\n\tif (v42) goto L_0021;\n\tv26 = ~this.m_DistantDisabled;\n\tif (v26) goto L_0021;\nL_0020:\n\treturn;\nL_0021:\n\tDynamicBone::InitTransforms(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void FixedUpdate()
	{
		if (m_UpdateMode == UpdateMode.AnimatePhysics && m_Weight > 0f && (!m_DistantDisable || !m_DistantDisabled))
		{
			InitTransforms();
		}
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x9FF1D0", Offset = "0x9FF1D0", Length = "0x30")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_UpdateMode == 1;\n\tif (v6) goto L_001F;\n\tv23 = this.m_Weight <= 0;\n\tif (v23) goto L_001F;\n\tv42 = ~this.m_DistantDisable;\n\tif (v42) goto L_0020;\n\tv25 = ~this.m_DistantDisabled;\n\tif (v25) goto L_0020;\nL_001F:\n\treturn;\nL_0020:\n\tDynamicBone::InitTransforms(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (m_UpdateMode != UpdateMode.AnimatePhysics && m_Weight > 0f && (!m_DistantDisable || !m_DistantDisabled))
		{
			InitTransforms();
		}
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x9FF200", Offset = "0x9FF200", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this.m_DistantDisable;\n\tif (v11) goto L_0017;\n\tDynamicBone::CheckDistance(this);\nL_0017:\n\tv27 = this.m_Weight <= 0;\n\tif (v27) goto L_0024;\n\tv29 = ~this.m_DistantDisable;\n\tif (v29) goto L_002F;\n\tv31 = this.m_DistantDisabled == 0;\n\tif (v31) goto L_002F;\nL_0024:\n\treturn;\nL_002F:\n\tv50 = this.m_UpdateMode != 2;\n\tif (v50) goto L_0035;\n\tv63 = UnityEngine.Time::get_unscaledDeltaTime();\n\tgoto L_003B;\nL_0035:\n\tv63 = UnityEngine.Time::get_deltaTime();\nL_003B:\n\tDynamicBone::UpdateDynamicBones(this, v63);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void LateUpdate()
	{
		if (m_DistantDisable)
		{
			CheckDistance();
		}
		if (m_Weight > 0f && (!m_DistantDisable || !m_DistantDisabled))
		{
			float t = ((m_UpdateMode != UpdateMode.UnscaledTime) ? Time.deltaTime : Time.unscaledDeltaTime);
			UpdateDynamicBones(t);
		}
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x9FF1AC", Offset = "0x9FF1AC", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.m_Weight <= 0;\n\tif (v13) goto L_0014;\n\tv15 = ~this.m_DistantDisable;\n\tif (v15) goto L_0015;\n\tv17 = ~this.m_DistantDisabled;\n\tif (v17) goto L_0015;\nL_0014:\n\treturn;\nL_0015:\n\tDynamicBone::InitTransforms(this);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void PreUpdate()
	{
		if (m_Weight > 0f && (!m_DistantDisable || !m_DistantDisabled))
		{
			InitTransforms();
		}
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x9FF278", Offset = "0x9FF278", Length = "0x20C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EEF0E0]);\n\tv35 = *([v34 @ X8_v24]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021C55]) = v54;\nL_001F:\n\tv97 = this.m_ReferenceObject;\n\tgoto L_002D;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002D;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_002D:\n\tv74 = UnityEngine.Object::op_Equality(this.m_ReferenceObject, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0051;\n\tv78 = UnityEngine.Camera::get_main();\n\tgoto L_0042;\n\tv117 = *([v96 @ X8_v20+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0042;\n\tv126 = v96;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v126, v72, v73, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0042:\n\tv91 = UnityEngine.Object::op_Inequality(v78, 0);\n\tv94 = v91 == 0;\n\tif (v94) goto L_0051;\n\tv231 = UnityEngine.Camera::get_main();\n\tv90 = UnityEngine.Component::get_transform(v231);\nL_0051:\n\tgoto L_005A;\n\tv106 = *([v99 @ X0_v7+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tgoto L_005A;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v99, v86, v84, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_005A:\n\tv116 = UnityEngine.Object::op_Inequality(v97, 0);\n\tv125 = v116 == 0;\n\tif (v125) goto L_00E2;\n\tv234 = UnityEngine.Transform::get_position(v97);\n\tv310 = UnityEngine.Component::get_transform(this);\n\tv234 = UnityEngine.Transform::get_position(v310);\n\tgoto L_0089;\n\tv323 = *([v319 @ X0_v15+E0]);\n\tv324 = v323 == 0;\n\tv325 = ~v324;\n\tif (v325) goto L_0089;\n\tv327 = \"il2cpp_codegen_runtime_class_init\"(v319, v313, v115, v39, v40, v41, v42, v43, v314, v315, v316, v47, v48, v49, v50, v51);\nL_0089:\n\tv234 = UnityEngine.Vector3::op_Subtraction(v234, v234);\n\tv212 = 0x158AB88(&v234 @ V0_v2 (UnityEngine.Vector3), 0, 0, v39, v40, v41, v42, v43, v234, v234.y, v234.z, v234, v234.y, v234.z, v50, v51);\n\tv197 = this.m_DistanceToObject * this.m_DistanceToObject;\n\tv338 = v234 - v197;\n\tv339 = v338 < 0;\n\tv340 = v338 == 0;\n\tv341 = v234 ^ v197;\n\tv342 = v234 ^ v338;\n\tv343 = v341 & v342;\n\tv344 = v343 < 0;\n\tv345 = v339 == v344;\n\tv132 = ~v340;\n\tv346 = v345 & v132;\n\tv351 = this.m_DistantDisabled == 0;\n\tv136 = ~v351;\n\tv156 = v346 == v136;\n\tif (v156) goto L_00E2;\n\tv368 = v234 > v197;\n\tif (v368) goto L_00C9;\n\tDynamicBone::ResetParticlesPosition(this);\nL_00C9:\n\tv162 = v234 - v197;\n\tv158 = v162 < 0;\n\tv154 = v162 == 0;\n\tv150 = v234 ^ v197;\n\tv146 = v234 ^ v162;\n\tv142 = v150 & v146;\n\tv138 = v142 < 0;\n\tv371 = v158 == v138;\n\tv130 = ~v154;\n\tv134 = v371 & v130;\n\tthis.m_DistantDisabled = v134;\nL_00E2:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void CheckDistance()
	{
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		UnityEngine.Object obj = m_ReferenceObject;
		if (m_ReferenceObject == null)
		{
			Camera main = Camera.main;
			if (main != null)
			{
				Camera main2 = Camera.main;
				Transform transform = main2.transform;
				obj = transform;
			}
		}
		if (!(obj != null))
		{
			return;
		}
		Vector3 position = ((Transform)obj).position;
		Transform transform2 = base.transform;
		position = transform2.position;
		position -= position;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
		float num = m_DistanceToObject * m_DistanceToObject;
		float num2 = position.x - num;
		bool flag = num2 < 0f;
		bool flag2 = num2 == 0f;
		object obj2 = position ^ num;
		object obj3 = position ^ num2;
		int num3 = (int)((long)(IntPtr)obj2 & (long)(IntPtr)obj3);
		bool flag3 = num3 < 0;
		bool flag4 = flag == flag3;
		bool flag5 = !flag2;
		bool flag6 = flag4 && flag5;
		bool flag7 = !m_DistantDisabled;
		bool flag8 = !flag7;
		if (flag6 != flag8)
		{
			if (!(position.x > num))
			{
				ResetParticlesPosition();
			}
			float num4 = position.x - num;
			bool flag9 = num4 < 0f;
			bool flag10 = num4 == 0f;
			object obj4 = position ^ num;
			object obj5 = position ^ num4;
			int num5 = (int)((long)(IntPtr)obj4 & (long)(IntPtr)obj5);
			bool flag11 = num5 < 0;
			bool flag12 = flag9 == flag11;
			bool flag13 = !flag10;
			bool distantDisabled = flag12 && flag13;
			m_DistantDisabled = distantDisabled;
		}
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x9FF938", Offset = "0x9FF938", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDynamicBone::ResetParticlesPosition(this);\n\treturn;\n")]
	private void OnEnable()
	{
		ResetParticlesPosition();
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x9FF93C", Offset = "0x9FF93C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDynamicBone::InitTransforms(this);\n\treturn;\n")]
	private void OnDisable()
	{
		InitTransforms();
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x9FF940", Offset = "0x9FF940", Length = "0x130")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EF9FC8]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C56]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Mathf::Max(this.m_UpdateRate, 0f);\n\tthis.m_UpdateRate = v58;\n\tv62 = UnityEngine.Mathf::Clamp01(this.m_Damping);\n\tthis.m_Damping = v62;\n\tv66 = UnityEngine.Mathf::Clamp01(this.m_Elasticity);\n\tthis.m_Elasticity = v66;\n\tv70 = UnityEngine.Mathf::Clamp01(this.m_Stiffness);\n\tthis.m_Stiffness = v70;\n\tv74 = UnityEngine.Mathf::Clamp01(this.m_Inert);\n\tthis.m_Inert = v74;\n\tv78 = UnityEngine.Mathf::Clamp01(this.m_Friction);\n\tthis.m_Friction = v78;\n\tv83 = UnityEngine.Mathf::Max(this.m_Radius, 0f);\n\tthis.m_Radius = v83;\n\tv85 = UnityEngine.Application::get_isEditor();\n\tv87 = v85 == 0;\n\tif (v87) goto L_0060;\n\tv89 = UnityEngine.Application::get_isPlaying();\n\tv92 = v89 == 0;\n\tif (v92) goto L_0060;\n\tDynamicBone::InitTransforms(this);\n\tDynamicBone::SetupParticles(this);\n\treturn;\nL_0060:\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnValidate()
	{
		float updateRate = Mathf.Max(m_UpdateRate, 0f);
		m_UpdateRate = updateRate;
		float damping = Mathf.Clamp01(m_Damping);
		m_Damping = damping;
		float elasticity = Mathf.Clamp01(m_Elasticity);
		m_Elasticity = elasticity;
		float stiffness = Mathf.Clamp01(m_Stiffness);
		m_Stiffness = stiffness;
		float inert = Mathf.Clamp01(m_Inert);
		m_Inert = inert;
		float friction = Mathf.Clamp01(m_Friction);
		m_Friction = friction;
		float radius = Mathf.Max(m_Radius, 0f);
		m_Radius = radius;
		if (Application.isEditor && Application.isPlaying)
		{
			InitTransforms();
			SetupParticles();
		}
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x9FFA70", Offset = "0x9FFA70", Length = "0x1AC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED0B68]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021C57]) = v44;\nL_0018:\n\tv47 = UnityEngine.Behaviour::get_enabled(this);\n\tv49 = v47 == 0;\n\tif (v49) goto L_00C2;\n\tgoto L_002C;\n\tv166 = *([v53 @ X0_v5+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_002C;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v53, v46, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv146 = UnityEngine.Object::op_Equality(this.m_Root, 0);\n\tv209 = v146 == 0;\n\tv150 = ~v209;\n\tif (v150) goto L_00C2;\n\tv211 = UnityEngine.Application::get_isEditor();\n\tv213 = v211 == 0;\n\tif (v213) goto L_004B;\n\tv215 = UnityEngine.Application::get_isPlaying();\n\tv226 = v215 == 0;\n\tv222 = ~v226;\n\tif (v222) goto L_004B;\n\tv232 = UnityEngine.Component::get_transform(this);\n\tv219 = UnityEngine.Transform::get_hasChanged(v232);\n\tv221 = v219 == 0;\n\tif (v221) goto L_004B;\n\tDynamicBone::InitTransforms(this);\n\tDynamicBone::SetupParticles(this);\nL_004B:\n\tv224 = UnityEngine.Color::get_white();\n\tUnityEngine.Gizmos::set_color(v224);\n\tv123 = this.m_Particles;\nL_0060:\n\tv88 = v158 >= v123._size;\n\tif (v88) goto L_00C2;\n\tv305 = v123._size < v158;\n\tv272 = ~v305;\n\tv269 = v123._size - v158;\n\tv263 = v269 == 0;\n\tv306 = ~v263;\n\tv248 = v272 & v306;\n\tif (v248) goto L_0070;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0070:\n\tv309 = v123._items;\n\tv275 = v309[v158 @ X20_v7 (System.Int32)];\n\tv243 = v275.m_ParentIndex;\n\tv310 = v275.m_ParentIndex & 0x80000000;\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_00A9;\n\tv242 = this.m_Particles;\n\tv343 = v242._size < v275.m_ParentIndex;\n\tv273 = ~v343;\n\tv270 = v242._size - v275.m_ParentIndex;\n\tv264 = v270 == 0;\n\tv344 = ~v264;\n\tv249 = v273 & v344;\n\tif (v249) goto L_008D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008D:\n\tv354 = v242._items;\n\tv290 = v354[v243 @ X22_v5 (System.Int32)];\n\t// 154 MakeStruct v314 @ AGG9FFBC8_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v275.m_Position (UnityEngine.Vector3), v275.m_Position.y (System.Single), v275.m_Position.z (System.Single)\n\t// 155 MakeStruct v313 @ AGG9FFBC8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v290.m_Position (UnityEngine.Vector3), v290.m_Position.y (System.Single), v290.m_Position.z (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v314, v313);\nL_00A9:\n\tv247 = v275.m_Radius <= 0;\n\tif (v247) goto L_00B3;\n\tv350 = v275.m_Radius * this.m_ObjectScale;\n\t// 177 MakeStruct v351 @ AGG9FFBEC_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v275.m_Position (UnityEngine.Vector3), v275.m_Position.y (System.Single), v275.m_Position.z (System.Single)\n\tUnityEngine.Gizmos::DrawWireSphere(v351, v350);\nL_00B3:\n\tv123 = this.m_Particles;\n\tv158 = v158 + 1;\n\tv352 = this.m_Particles == 0;\n\tv284 = ~v352;\n\tif (v284) goto L_0060;\n\tthrow System.NullReferenceException;\nL_00C2:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDrawGizmosSelected()
	{
		//IL_01ce: Expected I4, but got I8
		if (!base.enabled || m_Root == null)
		{
			return;
		}
		if (Application.isEditor && !Application.isPlaying)
		{
			Transform transform = base.transform;
			if (transform.hasChanged)
			{
				InitTransforms();
				SetupParticles();
			}
		}
		Color white = Color.white;
		Gizmos.color = white;
		List<Particle> particles = m_Particles;
		int num = 0;
		Vector3 vector = default(Vector3);
		Vector3 to = default(Vector3);
		Vector3 center = default(Vector3);
		while (num < particles.Count)
		{
			bool flag = particles.Count < num;
			bool flag2 = !flag;
			int num2 = particles.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items = particles._items;
			Particle particle = items[num];
			int parentIndex = particle.m_ParentIndex;
			if ((int)(particle.m_ParentIndex & 0x80000000L) == 0)
			{
				List<Particle> particles2 = m_Particles;
				bool flag5 = particles2.Count < particle.m_ParentIndex;
				bool flag6 = !flag5;
				int num3 = particles2.Count - particle.m_ParentIndex;
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				Particle[] items2 = particles2._items;
				Particle particle2 = items2[parentIndex];
				vector.x = particle.m_Position.x;
				vector.y = particle.m_Position.y;
				vector.z = particle.m_Position.z;
				to.x = particle2.m_Position.x;
				to.y = particle2.m_Position.y;
				to.z = particle2.m_Position.z;
				Gizmos.DrawLine(vector, to);
			}
			if (particle.m_Radius > 0f)
			{
				float radius = particle.m_Radius * m_ObjectScale;
				center.x = particle.m_Position.x;
				center.y = particle.m_Position.y;
				center.z = particle.m_Position.z;
				Gizmos.DrawWireSphere(center, radius);
			}
			particles = m_Particles;
			num++;
			if (m_Particles == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0x9FFC1C", Offset = "0x9FFC1C", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = this.m_Weight == w;\n\tif (v19) goto L_0034;\n\tv33 = w != 0;\n\tif (v33) goto L_002A;\n\tDynamicBone::InitTransforms(this);\n\tgoto L_002E;\nL_002A:\n\tv70 = this.m_Weight != 0;\n\tif (v70) goto L_002E;\n\tDynamicBone::ResetParticlesPosition(this);\nL_002E:\n\tthis.m_Weight = w;\nL_0034:\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetWeight(float w)
	{
		if (m_Weight != w)
		{
			if (w == 0f)
			{
				InitTransforms();
			}
			else if (m_Weight == 0f)
			{
				ResetParticlesPosition();
			}
			m_Weight = w;
		}
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x9FFC78", Offset = "0x9FFC78", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Weight;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public float GetWeight()
	{
		return m_Weight;
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x9FF484", Offset = "0x9FF484", Length = "0x250")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv36 = *([1EC9C88]);\n\tv37 = *([v36 @ X8_v26]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, t, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2021C58]) = v55;\nL_0023:\n\tgoto L_002C;\n\tv63 = *([v59 @ X0_v2+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002C;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v40, v41, v42, v43, v44, v45, t, v46, v47, v48, v49, v50, v51, v52);\nL_002C:\n\tv73 = UnityEngine.Object::op_Equality(this.m_Root, 0);\n\tv75 = v73 == 0;\n\tif (v75) goto L_0040;\n\treturn;\nL_0040:\n\tv90 = UnityEngine.Component::get_transform(this);\n\tv189 = UnityEngine.Transform::get_lossyScale(v90);\n\tgoto L_0054;\n\tv220 = *([v216 @ X0_v10+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_0054;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v216, v188, v72, v41, v42, v43, v44, v45, v189, v193, v191, v48, v49, v50, v51, v52);\nL_0054:\n\tv195 = UnityEngine.Mathf::Abs(v189);\n\tthis.m_ObjectScale = v195;\n\tv207 = UnityEngine.Component::get_transform(this);\n\tv228 = UnityEngine.Transform::get_position(v207);\n\tgoto L_0079;\n\tv236 = *([v232 @ X0_v14+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0079;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v232, v227, v72, v41, v42, v43, v44, v45, v228, v229, v230, v48, v49, v50, v51, v52);\nL_0079:\n\t// 121 MakeStruct v120 @ AGG9FF5D4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_ObjectPrevPosition (UnityEngine.Vector3), this.m_ObjectPrevPosition.y (System.Single), this.m_ObjectPrevPosition.z (System.Single)\n\tv196 = UnityEngine.Vector3::op_Subtraction(v228, v120);\n\tthis.m_ObjectMove = v196;\n\tthis.m_ObjectMove.y = v196.y;\n\tthis.m_ObjectMove.z = v196.z;\n\tv208 = UnityEngine.Component::get_transform(this);\n\tv247 = UnityEngine.Transform::get_position(v208);\n\tthis.m_ObjectPrevPosition = v247;\n\tthis.m_ObjectPrevPosition.y = v247.y;\n\tthis.m_ObjectPrevPosition.z = v247.z;\n\tv261 = this.m_UpdateRate <= 0;\n\tif (v261) goto L_FFFFFFFF;\n\tv265 = 1f / this.m_UpdateRate;\n\tv286 = this.m_Time + t;\n\tthis.m_Time = v286;\nL_00AA:\n\tv302 = v286 < v265;\n\tif (v302) goto L_00CC;\n\tv291 = v327 + 1;\n\tv286 = v286 - v265;\n\tthis.m_Time = v286;\n\tv269 = v327 <= 1;\n\tif (v269) goto L_00AA;\n\tthis.m_Time = 0f;\n\tgoto L_00CF;\n\tgoto L_00CF;\nL_00CC:\n\tv304 = v327 < 1;\n\tif (v304) goto L_00F8;\nL_00CF:\n\tDynamicBone::UpdateParticles1(this);\n\tDynamicBone::UpdateParticles2(this);\n\tgoto L_00DD;\n\tv348 = *([v344 @ X0_v24+E0]);\n\tv349 = v348 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_00DD;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v344, v167, v72, v41, v42, v43, v44, v45, v325, v323, v321, v133, v130, v127, v51, v52);\nL_00DD:\n\tv326 = UnityEngine.Vector3::get_zero();\n\tv329 = v327 - 1;\n\tthis.m_ObjectMove = v326;\n\tthis.m_ObjectMove.y = v326.y;\n\tthis.m_ObjectMove.z = v326.z;\n\tv333 = v327 != 1;\n\tif (v333) goto L_00CF;\nL_00F5:\n\tDynamicBone::ApplyParticlesToTransforms(this);\n\treturn;\nL_00F8:\n\tDynamicBone::SkipUpdateParticles(this);\n\tgoto L_00F5;\n\tthrow System.NullReferenceException;\n\treturn;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateDynamicBones(float t)
	{
		if (m_Root == null)
		{
			return;
		}
		Transform transform = base.transform;
		float objectScale = Mathf.Abs(transform.lossyScale.x);
		m_ObjectScale = objectScale;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Vector3 vector = default(Vector3);
		vector.x = m_ObjectPrevPosition.x;
		vector.y = m_ObjectPrevPosition.y;
		vector.z = m_ObjectPrevPosition.z;
		Vector3 vector2 = (m_ObjectMove = position - vector);
		m_ObjectMove.y = vector2.y;
		m_ObjectMove.z = vector2.z;
		Transform transform3 = base.transform;
		Vector3 vector3 = (m_ObjectPrevPosition = transform3.position);
		m_ObjectPrevPosition.y = vector3.y;
		m_ObjectPrevPosition.z = vector3.z;
		int num3;
		int num4;
		if (m_UpdateRate > 0f)
		{
			float num = 1f / m_UpdateRate;
			float num2 = (m_Time += t);
			num3 = 0;
			while (!(num2 < num))
			{
				num4 = num3 + 1;
				num2 = (m_Time = num2 - num);
				bool flag = num3 <= 1;
				num3 = num4;
				if (flag)
				{
					continue;
				}
				goto IL_020c;
			}
			if (num3 < 1)
			{
				SkipUpdateParticles();
				goto IL_02d6;
			}
		}
		else
		{
			num3 = 1;
		}
		goto IL_024f;
		IL_02d6:
		ApplyParticlesToTransforms();
		return;
		IL_024f:
		bool flag2;
		do
		{
			UpdateParticles1();
			UpdateParticles2();
			Vector3 zero = Vector3.zero;
			int num5 = num3 - 1;
			m_ObjectMove = zero;
			m_ObjectMove.y = zero.y;
			m_ObjectMove.z = zero.z;
			flag2 = num3 != 1;
			num3 = num5;
		}
		while (flag2);
		goto IL_02d6;
		IL_020c:
		m_Time = 0f;
		num3 = num4;
		goto IL_024f;
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x9FF000", Offset = "0x9FF000", Length = "0x17C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB1F98]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C59]) = v40;\nL_001A:\n\tSystem.Collections.Generic.List`1<DynamicBone+Particle>::Clear(this.m_Particles);\n\tgoto L_002B;\n\tv86 = *([v82 @ X0_v5+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_002B;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v82, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv93 = UnityEngine.Object::op_Equality(this.m_Root, 0);\n\tv114 = v93 == 0;\n\tif (v114) goto L_003D;\n\treturn;\nL_003D:\n\t// 61 MakeStruct v48 @ AGG9FF0AC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Gravity (UnityEngine.Vector3), this.m_Gravity.y (System.Single), this.m_Gravity.z (System.Single)\n\tv56 = UnityEngine.Transform::InverseTransformDirection(this.m_Root, v48);\n\tthis.m_LocalGravity = v56;\n\tthis.m_LocalGravity.y = v56.y;\n\tthis.m_LocalGravity.z = v56.z;\n\tv68 = UnityEngine.Component::get_transform(this);\n\tv134 = UnityEngine.Transform::get_lossyScale(v68);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v12+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v133, v61, v25, v26, v27, v28, v29, v134, v54, v51, v33, v34, v35, v36, v37);\nL_005A:\n\tv57 = UnityEngine.Mathf::Abs(v134);\n\tthis.m_ObjectScale = v57;\n\tv69 = UnityEngine.Component::get_transform(this);\n\tv149 = UnityEngine.Transform::get_position(v69);\n\tthis.m_ObjectPrevPosition = v149;\n\tthis.m_ObjectPrevPosition.y = v149.y;\n\tthis.m_ObjectPrevPosition.z = v149.z;\n\tgoto L_0075;\n\tv158 = *([v154 @ X0_v16+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0075;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v154, v148, v61, v25, v26, v27, v28, v29, v149, v150, v151, v33, v34, v35, v36, v37);\nL_0075:\n\tv164 = UnityEngine.Vector3::get_zero();\n\tthis.m_ObjectMove = v164;\n\tthis.m_ObjectMove.y = v164.y;\n\tthis.m_ObjectMove.z = v164.z;\n\tthis.m_BoneTotalLength = 0f;\n\tDynamicBone::AppendParticles(this, this.m_Root, 0xFFFFFFFF, 0f);\n\tDynamicBone::UpdateParameters(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetupParticles()
	{
		m_Particles.Clear();
		if (!(m_Root == null))
		{
			Vector3 direction = default(Vector3);
			direction.x = m_Gravity.x;
			direction.y = m_Gravity.y;
			direction.z = m_Gravity.z;
			Vector3 vector = (m_LocalGravity = m_Root.InverseTransformDirection(direction));
			m_LocalGravity.y = vector.y;
			m_LocalGravity.z = vector.z;
			Transform transform = base.transform;
			float objectScale = Mathf.Abs(transform.lossyScale.x);
			m_ObjectScale = objectScale;
			Transform transform2 = base.transform;
			Vector3 vector2 = (m_ObjectPrevPosition = transform2.position);
			m_ObjectPrevPosition.y = vector2.y;
			m_ObjectPrevPosition.z = vector2.z;
			Vector3 vector3 = (m_ObjectMove = Vector3.zero);
			m_ObjectMove.y = vector3.y;
			m_ObjectMove.z = vector3.z;
			m_BoneTotalLength = 0f;
			AppendParticles(m_Root, -1, 0f);
			UpdateParameters();
		}
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0xA01064", Offset = "0xA01064", Length = "0x678")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv52 = *([1ECC950]);\n\tv53 = *([v52 @ X8_v72]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, b, parentIndex, methodInfo, v56, v57, v58, v59, boneLength, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 0 | 1;\n\t*([2021C5A]) = v69;\nL_0029:\n\tv75 = new DynamicBone+Particle();\n\tDynamicBone+Particle::.ctor(v75);\n\tv75.m_Transform = b;\n\tv75.m_ParentIndex = parentIndex;\n\tgoto L_003F;\n\tv371 = *([v80 @ X0_v8+E0]);\n\tv372 = v371 == 0;\n\tv373 = ~v372;\n\tif (v373) goto L_003F;\n\tv375 = \"il2cpp_codegen_runtime_class_init\"(v80, b, parentIndex, methodInfo, v56, v57, v58, v59, boneLength, v60, v61, v62, v63, v64, v65, v66);\nL_003F:\n\tv337 = UnityEngine.Object::op_Inequality(b, 0);\n\tv446 = v337 == 0;\n\tif (v446) goto L_0069;\n\tv559 = UnityEngine.Transform::get_position(b);\n\tv75.m_Position.z = v559.z;\n\tv75.m_PrevPosition = v559;\n\tv75.m_PrevPosition.y = v559.y;\n\tv75.m_PrevPosition.z = v559.z;\n\tv75.m_Position = v559;\n\tv75.m_Position.y = v559.y;\n\tv559 = UnityEngine.Transform::get_localPosition(b);\n\tv75.m_InitLocalPosition = v559;\n\tv75.m_InitLocalPosition.y = v559.y;\n\tv75.m_InitLocalPosition.z = v559.z;\n\tv578 = UnityEngine.Transform::get_localRotation(b);\n\tv75.m_InitLocalRotation = v578;\n\tv75.m_InitLocalRotation.y = v578.y;\n\tv75.m_InitLocalRotation.z = v578.z;\n\tv75.m_InitLocalRotation.w = v578.w;\n\tv585 = parentIndex & 0x80000000;\n\tv586 = v585 == 0;\n\tif (v586) goto L_0148;\n\tgoto L_019F;\nL_0069:\n\tv283 = v1148.m_Particles;\n\tv561 = v283._size < parentIndex;\n\tv276 = ~v561;\n\tv268 = v283._size - parentIndex;\n\tv252 = v268 == 0;\n\tv562 = ~v252;\n\tv212 = v276 & v562;\n\tif (v212) goto L_007B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_007B:\n\tv572 = v283._items;\n\tv362 = v572[parentIndex @ X2 (System.Int32)];\n\tv213 = v1148.m_EndLength <= 0;\n\tif (v213) goto L_00EA;\n\tv627 = UnityEngine.Transform::get_parent(v362.m_Transform);\n\tgoto L_00A4;\n\tv669 = *([v655 @ X8_v62+E0]);\n\tv670 = v669 == 0;\n\tv671 = ~v670;\n\tif (v671) goto L_00A4;\n\tv682 = v655;\n\tv673 = \"il2cpp_codegen_runtime_class_init\"(v682, v626, v323, methodInfo, v56, v57, v58, v59, v316, v60, v61, v62, v63, v64, v65, v66);\nL_00A4:\n\tv677 = UnityEngine.Object::op_Inequality(v627, 0);\n\tv684 = v677 == 0;\n\tif (v684) goto L_012A;\n\tv559 = UnityEngine.Transform::get_position(v362.m_Transform);\n\tgoto L_00C2;\n\tv857 = *([v736 @ X0_v94+E0]);\n\tv858 = v857 == 0;\n\tv859 = ~v858;\n\tif (v859) goto L_00C2;\n\tv861 = \"il2cpp_codegen_runtime_class_init\"(v736, v330, v324, methodInfo, v56, v57, v58, v59, v698, v729, v730, v62, v63, v64, v65, v66);\nL_00C2:\n\tv559 = UnityEngine.Vector3::op_Multiply(v559, 2f);\n\tv559 = UnityEngine.Transform::get_position(v627);\n\tv559 = UnityEngine.Vector3::op_Subtraction(v559, v559);\n\tv559 = UnityEngine.Transform::InverseTransformPoint(v362.m_Transform, v559);\n\tv559 = UnityEngine.Vector3::op_Multiply(v559, v1148.m_EndLength);\n\tv888 = v559.y;\n\tv886 = v559.z;\n\tgoto L_0120;\nL_00EA:\n\tv340 = UnityEngine.Component::get_transform(v1148);\n\tv559 = v1148.m_EndOffset;\n\t// 241 MakeStruct v142 @ AGGA012C0_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1148.m_EndOffset (UnityEngine.Vector3), v1148.m_EndOffset.y (System.Single), v1148.m_EndOffset.z (System.Single)\n\tv559 = UnityEngine.Transform::TransformDirection(v340, v142);\n\tv559 = UnityEngine.Transform::get_position(v362.m_Transform);\n\tgoto L_0117;\n\tv747 = *([v714 @ X0_v81+E0]);\n\tv748 = v747 == 0;\n\tv749 = ~v748;\n\tif (v749) goto L_0117;\n\tv751 = \"il2cpp_codegen_runtime_class_init\"(v714, v686, v323, methodInfo, v56, v57, v58, v59, v687, v707, v708, v62, v63, v64, v65, v66);\nL_0117:\n\tv559 = UnityEngine.Vector3::op_Addition(v559, v559);\n\tv559 = UnityEngine.Transform::InverseTransformPoint(v362.m_Transform, v559);\n\tv888 = v559.y;\n\tv886 = v559.z;\nL_0120:\n\tv75.m_EndOffset = v559;\n\tv75.m_EndOffset.y = v888;\n\tv75.m_EndOffset.z = v886;\n\tgoto L_0137;\nL_012A:\n\tv701 = 0;\n\tv706 = 0x1586898(&v701 @ stack_-B0_v6 (UnityEngine.Vector3), 0, 0, methodInfo, v56, v57, v58, v59, v1148.m_EndLength, 0, 0, v62, v63, v64, v65, v66);\n\tv75.m_EndOffset = 0;\n\tv75.m_EndOffset.y = v742;\n\tv75.m_EndOffset.z = 0f;\nL_0137:\n\t// 311 MakeStruct v588 @ AGGA01388_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v559 @ V0_v45 (UnityEngine.Vector3), v888 @ V1_v20 (System.Single), v886 @ V2_v19 (System.Single)\n\tv559 = UnityEngine.Transform::TransformPoint(v362.m_Transform, v588);\n\tv75.m_Position.z = v559.z;\n\tv75.m_PrevPosition = v559;\n\tv75.m_PrevPosition.y = v559.y;\n\tv75.m_PrevPosition.z = v559.z;\n\tv75.m_Position = v559;\n\tv75.m_Position.y = v559.y;\n\tv912 = parentIndex & 0x80000000;\n\tv913 = v912 == 0;\n\tv623 = ~v913;\n\tif (v623) goto L_019F;\nL_0148:\n\tv285 = v1148.m_Particles;\n\tv653 = v285._size < parentIndex;\n\tv279 = ~v653;\n\tv271 = v285._size - parentIndex;\n\tv255 = v271 == 0;\n\tv654 = ~v255;\n\tv215 = v279 & v654;\n\tif (v215) goto L_015A;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_015A:\n\tv667 = v285._items;\n\tv365 = v667[parentIndex @ X2 (System.Int32)];\n\tv559 = UnityEngine.Transform::get_position(v365.m_Transform);\n\tgoto L_0181;\n\tv845 = *([v725 @ X0_v63+E0]);\n\tv846 = v845 == 0;\n\tv847 = ~v846;\n\tif (v847) goto L_0181;\n\tv849 = \"il2cpp_codegen_runtime_class_init\"(v725, v695, v325, methodInfo, v56, v57, v58, v59, v696, v720, v721, v290, v166, v162, v65, v66);\nL_0181:\n\t// 385 MakeStruct v628 @ AGGA01430_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v75.m_Position (UnityEngine.Vector3), v75.m_Position.y (System.Single), v75.m_Position.z (System.Single)\n\tv559 = UnityEngine.Vector3::op_Subtraction(v559, v628);\n\tv911 = 0x158AD58(&v559 @ V0_v45 (UnityEngine.Vector3), 0, v325, methodInfo, v56, v57, v58, v59, v559, v559.y, v559.z, v75.m_Position, v75.m_Position.y, v75.m_Position.z, v65, v66);\n\tv359 = v559 + boneLength;\n\tv75.m_BoneLength = v359;\n\tgoto L_019D;\n\tv986 = *([v929 @ X0_v68+E0]);\n\tv987 = v986 == 0;\n\tv988 = ~v987;\n\tif (v988) goto L_019D;\n\tv990 = \"il2cpp_codegen_runtime_class_init\"(v929, v645, v325, methodInfo, v56, v57, v58, v59, v856, v909, v642, v638, v634, v633, v65, v66);\nL_019D:\n\tv644 = UnityEngine.Mathf::Max(v1148.m_BoneTotalLength, v359);\n\tv1148.m_BoneTotalLength = v644;\nL_019F:\n\tv434 = v1148.m_Particles;\n\tSystem.Collections.Generic.List`1<DynamicBone+Particle>::Add(v1148.m_Particles, v75);\n\tgoto L_01B5;\n\tv688 = *([v678 @ X0_v14+E0]);\n\tv689 = v688 == 0;\n\tv690 = ~v689;\n\tif (v690) goto L_01B5;\n\tv692 = \"il2cpp_codegen_runtime_class_init\"(v678, v664, v665, methodInfo, v56, v57, v58, v59, v320, v313, v307, v291, v167, v163, v65, v66);\nL_01B5:\n\tv343 = UnityEngine.Object::op_Inequality(b, 0);\n\tv719 = v343 == 0;\n\tif (v719) goto L_02A1;\n\tv908 = UnityEngine.Transform::get_childCount(b);\n\tv926 = v908 < 1;\n\tif (v926) goto L_0257;\nL_01CD:\n\tv1054 = v1148.m_Exclusions;\n\tv1020 = v1148.m_Exclusions == 0;\n\tif (v1020) goto L_0210;\nL_01DB:\n\tv1036 = v1028 >= v1054._size;\n\tif (v1036) goto L_0210;\n\tv1095 = v1054._size < v1028;\n\tv281 = ~v1095;\n\tv273 = v1054._size - v1028;\n\tv257 = v273 == 0;\n\tv1096 = ~v257;\n\tv217 = v281 & v1096;\n\tif (v217) goto L_01EB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01EB:\n\tv1166 = v1054._items;\n\tv1171 = UnityEngine.Transform::GetChild(b, v369);\n\tgoto L_0202;\n\tv1207 = *([v367 @ X8_v30+E0]);\n\tv1208 = v1207 == 0;\n\tv1209 = ~v1208;\n\tif (v1209) goto L_0202;\n\tv1214 = v367;\n\tv1211 = \"il2cpp_codegen_runtime_class_init\"(v1214, v1168, v1169, methodInfo, v56, v57, v58, v59, v321, v314, v308, v292, v168, v164, v65, v66);\nL_0202:\n\tv344 = UnityEngine.Object::op_Equality(v1166[v1028 @ X27_v11 (System.Int32)], v1171);\n\tv1216 = v344 == 0;\n\tv1217 = ~v1216;\n\tif (v1217) goto L_0220;\n\tv1054 = v1148.m_Exclusions;\n\tv1028 = v1028 + 1;\n\tv1218 = v1148.m_Exclusions == 0;\n\tv355 = ~v1218;\n\tif (v355) goto L_01DB;\n\tgoto L_02A3;\nL_0210:\n\tv1068 = UnityEngine.Transform::GetChild(b, v369);\n\tgoto L_0244;\nL_0220:\n\tv1118 = v1148.m_EndLength > 0;\n\tif (v1118) goto L_FFFFFFFF;\n\tgoto L_0230;\n\tv1227 = *([v1222 @ X0_v50+E0]);\n\tv1228 = v1227 == 0;\n\tv1229 = ~v1228;\n\tif (v1229) goto L_0230;\n\tv1231 = \"il2cpp_codegen_runtime_class_init\"(v1222, v334, v327, methodInfo, v56, v57, v58, v59, v1219, v314, v308, v292, v168, v164, v65, v66);\nL_0230:\n\tv559 = UnityEngine.Vector3::get_zero();\n\t// 570 MakeStruct v1173 @ AGGA015EC_0_v9 (\n// ... truncated")]
	private void AppendParticles(Transform b, int parentIndex, float boneLength)
	{
		//IL_0190: Expected I4, but got I8
		//IL_01a8: Expected O, but got I4
		//IL_04c1: Expected O, but got I4
		//IL_0443: Expected O, but got I4
		//IL_0b49: Expected I4, but got I8
		//IL_036d: Expected O, but got I4
		Particle particle = new Particle();
		particle.m_Transform = b;
		particle.m_ParentIndex = parentIndex;
		float num2;
		Vector3 position;
		if (b != null)
		{
			position = b.position;
			particle.m_Position.z = position.z;
			particle.m_PrevPosition = position;
			particle.m_PrevPosition.y = position.y;
			particle.m_PrevPosition.z = position.z;
			particle.m_Position = position;
			particle.m_Position.y = position.y;
			position = (particle.m_InitLocalPosition = b.localPosition);
			particle.m_InitLocalPosition.y = position.y;
			particle.m_InitLocalPosition.z = position.z;
			Quaternion quaternion = (particle.m_InitLocalRotation = b.localRotation);
			particle.m_InitLocalRotation.y = quaternion.y;
			particle.m_InitLocalRotation.z = quaternion.z;
			particle.m_InitLocalRotation.w = quaternion.w;
			int num = (int)(parentIndex & 0x80000000L);
			bool flag = num == 0;
			object obj = 0;
			if (flag)
			{
				goto IL_04c6;
			}
			num2 = boneLength;
			goto IL_09cb;
		}
		List<Particle> particles = m_Particles;
		bool flag2 = particles.Count < parentIndex;
		bool flag3 = !flag2;
		int num3 = particles.Count - parentIndex;
		bool flag4 = num3 == 0;
		bool flag5 = !flag4;
		if (!(flag3 && flag5))
		{
			throw new ArgumentOutOfRangeException();
		}
		Particle[] items = particles._items;
		Particle particle2 = items[parentIndex];
		float z;
		float y;
		if (m_EndLength > 0f)
		{
			Transform parent = particle2.m_Transform.parent;
			object obj;
			if (!(parent != null))
			{
				Vector3 vector = default(Vector3);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				particle.m_EndOffset = default(Vector3);
				float num4 = default(float);
				particle.m_EndOffset.y = num4;
				particle.m_EndOffset.z = 0f;
				z = 0f;
				y = num4;
				position = default(Vector3);
				obj = 0;
				goto IL_0a7f;
			}
			position = particle2.m_Transform.position;
			position *= 2f;
			position = parent.position;
			position -= position;
			position = particle2.m_Transform.InverseTransformPoint(position);
			position *= m_EndLength;
			y = position.y;
			z = position.z;
			obj = 0;
		}
		else
		{
			Transform transform = base.transform;
			position = m_EndOffset;
			Vector3 direction = default(Vector3);
			direction.x = m_EndOffset.x;
			direction.y = m_EndOffset.y;
			direction.z = m_EndOffset.z;
			position = transform.TransformDirection(direction);
			position = particle2.m_Transform.position;
			position += position;
			position = particle2.m_Transform.InverseTransformPoint(position);
			y = position.y;
			z = position.z;
			object obj = 0;
		}
		particle.m_EndOffset = position;
		particle.m_EndOffset.y = y;
		particle.m_EndOffset.z = z;
		goto IL_0a7f;
		IL_09cb:
		List<Particle> particles2 = m_Particles;
		m_Particles.Add(particle);
		if (!(b != null))
		{
			return;
		}
		int childCount = b.childCount;
		if (childCount >= 1)
		{
			int num5 = 0;
			int childCount2;
			Vector3 vector2 = default(Vector3);
			do
			{
				List<Transform> exclusions = m_Exclusions;
				if (m_Exclusions != null)
				{
					int num6 = 0;
					while (num6 < exclusions.Count)
					{
						bool flag6 = exclusions.Count < num6;
						bool flag7 = !flag6;
						int num7 = exclusions.Count - num6;
						bool flag8 = num7 == 0;
						bool flag9 = !flag8;
						if (!(flag7 && flag9))
						{
							throw new ArgumentOutOfRangeException();
						}
						Transform[] items2 = exclusions._items;
						Transform child = b.GetChild(num5);
						if (!(items2[num6] == child))
						{
							exclusions = m_Exclusions;
							num6++;
							if (m_Exclusions == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						goto IL_07f0;
					}
				}
				Transform child2 = b.GetChild(num5);
				Transform b2 = child2;
				goto IL_0a3a;
				IL_0a3a:
				AppendParticles(b2, particles2.Count, num2);
				goto IL_0898;
				IL_0898:
				num5++;
				childCount2 = b.childCount;
				continue;
				IL_07f0:
				if (!(m_EndLength > 0f))
				{
					position = Vector3.zero;
					vector2.x = m_EndOffset.x;
					vector2.y = m_EndOffset.y;
					vector2.z = m_EndOffset.z;
					if (!(vector2 != position))
					{
						goto IL_0898;
					}
				}
				b2 = null;
				goto IL_0a3a;
			}
			while (num5 < childCount2);
		}
		if (b.childCount != 0)
		{
			return;
		}
		if (!(m_EndLength > 0f))
		{
			position = Vector3.zero;
			Vector3 vector3 = default(Vector3);
			vector3.x = m_EndOffset.x;
			vector3.y = m_EndOffset.y;
			vector3.z = m_EndOffset.z;
			if (!(vector3 != position))
			{
				return;
			}
		}
		AppendParticles(null, particles2.Count, num2);
		return;
		IL_0a7f:
		Vector3 position2 = default(Vector3);
		position2.x = position.x;
		position2.y = y;
		position2.z = z;
		position = particle2.m_Transform.TransformPoint(position2);
		particle.m_Position.z = position.z;
		particle.m_PrevPosition = position;
		particle.m_PrevPosition.y = position.y;
		particle.m_PrevPosition.z = position.z;
		particle.m_Position = position;
		particle.m_Position.y = position.y;
		int num8 = (int)(parentIndex & 0x80000000L);
		bool flag10 = num8 == 0;
		bool flag11 = !flag10;
		num2 = boneLength;
		if (!flag11)
		{
			goto IL_04c6;
		}
		goto IL_09cb;
		IL_04c6:
		List<Particle> particles3 = m_Particles;
		bool flag12 = particles3.Count < parentIndex;
		bool flag13 = !flag12;
		int num9 = particles3.Count - parentIndex;
		bool flag14 = num9 == 0;
		bool flag15 = !flag14;
		if (!(flag13 && flag15))
		{
			throw new ArgumentOutOfRangeException();
		}
		Particle[] items3 = particles3._items;
		Particle particle3 = items3[parentIndex];
		position = particle3.m_Transform.position;
		Vector3 vector4 = default(Vector3);
		vector4.x = particle.m_Position.x;
		vector4.y = particle.m_Position.y;
		vector4.z = particle.m_Position.z;
		position -= vector4;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
		num2 = (particle.m_BoneLength = position.x + boneLength);
		float boneTotalLength = Mathf.Max(m_BoneTotalLength, num2);
		m_BoneTotalLength = boneTotalLength;
		goto IL_09cb;
	}

	[Token(Token = "0x6000013")]
	[Address(RVA = "0xA016DC", Offset = "0xA016DC", Length = "0x340")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EB15C8]);\n\tv27 = *([v26 @ X8_v38]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C5B]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv64 = UnityEngine.Object::op_Equality(this.m_Root, 0);\n\tv66 = v64 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0127;\n\t// 51 MakeStruct v123 @ AGGA01764_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Gravity (UnityEngine.Vector3), this.m_Gravity.y (System.Single), this.m_Gravity.z (System.Single)\n\tv161 = UnityEngine.Transform::InverseTransformDirection(this.m_Root, v123);\n\tv121 = this.m_Particles;\n\tthis.m_LocalGravity = v161;\n\tthis.m_LocalGravity.y = v161.y;\n\tthis.m_LocalGravity.z = v161.z;\nL_004A:\n\tv83 = v148 >= v121._size;\n\tif (v83) goto L_0127;\n\tv320 = v121._size < v148;\n\tv294 = ~v320;\n\tv293 = v121._size - v148;\n\tv291 = v293 == 0;\n\tv321 = ~v291;\n\tv286 = v294 & v321;\n\tif (v286) goto L_005A;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005A:\n\tv323 = v121._items;\n\tv192 = v323[v148 @ X20_v8 (System.Int32)];\n\tv192.m_Damping = this.m_Damping;\n\tv192.m_Elasticity = this.m_Elasticity;\n\tv192.m_Stiffness = this.m_Stiffness;\n\tv192.m_Inert = this.m_Inert;\n\tv192.m_Friction = this.m_Friction;\n\tv192.m_Radius = this.m_Radius;\n\tv173 = this.m_BoneTotalLength <= 0;\n\tif (v173) goto L_00F3;\n\tv169 = v192.m_BoneLength / this.m_BoneTotalLength;\n\tv333 = this.m_DampingDistrib == 0;\n\tif (v333) goto L_0090;\n\tv212 = UnityEngine.AnimationCurve::get_keys(this.m_DampingDistrib);\n\tv357 = v212.Length == 0;\n\tif (v357) goto L_0090;\n\tv409 = UnityEngine.AnimationCurve::Evaluate(this.m_DampingDistrib, v169);\n\tv352 = v192.m_Damping * v409;\n\tv192.m_Damping = v352;\nL_0090:\n\tv359 = this.m_ElasticityDistrib == 0;\n\tif (v359) goto L_00A3;\n\tv214 = UnityEngine.AnimationCurve::get_keys(this.m_ElasticityDistrib);\n\tv375 = v214.Length == 0;\n\tif (v375) goto L_00A3;\n\tv421 = UnityEngine.AnimationCurve::Evaluate(this.m_ElasticityDistrib, v169);\n\tv370 = v192.m_Elasticity * v421;\n\tv192.m_Elasticity = v370;\nL_00A3:\n\tv377 = this.m_StiffnessDistrib == 0;\n\tif (v377) goto L_00B6;\n\tv216 = UnityEngine.AnimationCurve::get_keys(this.m_StiffnessDistrib);\n\tv388 = v216.Length == 0;\n\tif (v388) goto L_00B6;\n\tv424 = UnityEngine.AnimationCurve::Evaluate(this.m_StiffnessDistrib, v169);\n\tv383 = v192.m_Stiffness * v424;\n\tv192.m_Stiffness = v383;\nL_00B6:\n\tv390 = this.m_InertDistrib == 0;\n\tif (v390) goto L_00C9;\n\tv218 = UnityEngine.AnimationCurve::get_keys(this.m_InertDistrib);\n\tv401 = v218.Length == 0;\n\tif (v401) goto L_00C9;\n\tv427 = UnityEngine.AnimationCurve::Evaluate(this.m_InertDistrib, v169);\n\tv396 = v192.m_Inert * v427;\n\tv192.m_Inert = v396;\nL_00C9:\n\tv403 = this.m_FrictionDistrib == 0;\n\tif (v403) goto L_00DC;\n\tv220 = UnityEngine.AnimationCurve::get_keys(this.m_FrictionDistrib);\n\tv415 = v220.Length == 0;\n\tif (v415) goto L_00DC;\n\tv429 = UnityEngine.AnimationCurve::Evaluate(this.m_FrictionDistrib, v169);\n\tv411 = v192.m_Friction * v429;\n\tv192.m_Friction = v411;\nL_00DC:\n\tv345 = this.m_RadiusDistrib == 0;\n\tif (v345) goto L_00F3;\n\tv222 = UnityEngine.AnimationCurve::get_keys(this.m_RadiusDistrib);\n\tv344 = v222.Length == 0;\n\tif (v344) goto L_00F3;\n\tv431 = UnityEngine.AnimationCurve::Evaluate(this.m_RadiusDistrib, v169);\n\tv338 = v192.m_Radius * v431;\n\tv192.m_Radius = v338;\nL_00F3:\n\tgoto L_00FB;\n\tv360 = *([v347 @ X0_v16+E0]);\n\tv361 = v360 == 0;\n\tv362 = ~v361;\n\tgoto L_00FB;\n\tv364 = \"il2cpp_codegen_runtime_class_init\"(v347, v299, v63, v31, v32, v33, v34, v35, v337, v336, v127, v39, v40, v41, v42, v43);\nL_00FB:\n\tv368 = UnityEngine.Mathf::Clamp01(v192.m_Damping);\n\tv192.m_Damping = v368;\n\tv381 = UnityEngine.Mathf::Clamp01(v192.m_Elasticity);\n\tv192.m_Elasticity = v381;\n\tv394 = UnityEngine.Mathf::Clamp01(v192.m_Stiffness);\n\tv192.m_Stiffness = v394;\n\tv407 = UnityEngine.Mathf::Clamp01(v192.m_Inert);\n\tv192.m_Inert = v407;\n\tv419 = UnityEngine.Mathf::Clamp01(v192.m_Friction);\n\tv192.m_Friction = v419;\n\tv298 = UnityEngine.Mathf::Max(v192.m_Radius, 0f);\n\tv192.m_Radius = v298;\n\tv121 = this.m_Particles;\n\tv148 = v148 + 1;\n\tv425 = this.m_Particles == 0;\n\tv303 = ~v425;\n\tif (v303) goto L_004A;\n\tthrow System.NullReferenceException;\nL_0127:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 180 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void UpdateParameters()
	{
		if (m_Root == null)
		{
			return;
		}
		Vector3 direction = default(Vector3);
		direction.x = m_Gravity.x;
		direction.y = m_Gravity.y;
		direction.z = m_Gravity.z;
		Vector3 localGravity = m_Root.InverseTransformDirection(direction);
		List<Particle> particles = m_Particles;
		m_LocalGravity = localGravity;
		m_LocalGravity.y = localGravity.y;
		m_LocalGravity.z = localGravity.z;
		int num = 0;
		while (num < particles.Count)
		{
			bool flag = particles.Count < num;
			bool flag2 = !flag;
			int num2 = particles.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items = particles._items;
			Particle particle = items[num];
			particle.m_Damping = m_Damping;
			particle.m_Elasticity = m_Elasticity;
			particle.m_Stiffness = m_Stiffness;
			particle.m_Inert = m_Inert;
			particle.m_Friction = m_Friction;
			particle.m_Radius = m_Radius;
			if (m_BoneTotalLength > 0f)
			{
				float time = particle.m_BoneLength / m_BoneTotalLength;
				if (m_DampingDistrib != null)
				{
					Keyframe[] keys = m_DampingDistrib.keys;
					if (keys.Length != 0)
					{
						float num3 = m_DampingDistrib.Evaluate(time);
						float damping = particle.m_Damping * num3;
						particle.m_Damping = damping;
					}
				}
				if (m_ElasticityDistrib != null)
				{
					Keyframe[] keys2 = m_ElasticityDistrib.keys;
					if (keys2.Length != 0)
					{
						float num4 = m_ElasticityDistrib.Evaluate(time);
						float elasticity = particle.m_Elasticity * num4;
						particle.m_Elasticity = elasticity;
					}
				}
				if (m_StiffnessDistrib != null)
				{
					Keyframe[] keys3 = m_StiffnessDistrib.keys;
					if (keys3.Length != 0)
					{
						float num5 = m_StiffnessDistrib.Evaluate(time);
						float stiffness = particle.m_Stiffness * num5;
						particle.m_Stiffness = stiffness;
					}
				}
				if (m_InertDistrib != null)
				{
					Keyframe[] keys4 = m_InertDistrib.keys;
					if (keys4.Length != 0)
					{
						float num6 = m_InertDistrib.Evaluate(time);
						float inert = particle.m_Inert * num6;
						particle.m_Inert = inert;
					}
				}
				if (m_FrictionDistrib != null)
				{
					Keyframe[] keys5 = m_FrictionDistrib.keys;
					if (keys5.Length != 0)
					{
						float num7 = m_FrictionDistrib.Evaluate(time);
						float friction = particle.m_Friction * num7;
						particle.m_Friction = friction;
					}
				}
				if (m_RadiusDistrib != null)
				{
					Keyframe[] keys6 = m_RadiusDistrib.keys;
					if (keys6.Length != 0)
					{
						float num8 = m_RadiusDistrib.Evaluate(time);
						float radius = particle.m_Radius * num8;
						particle.m_Radius = radius;
					}
				}
			}
			float damping2 = Mathf.Clamp01(particle.m_Damping);
			particle.m_Damping = damping2;
			float elasticity2 = Mathf.Clamp01(particle.m_Elasticity);
			particle.m_Elasticity = elasticity2;
			float stiffness2 = Mathf.Clamp01(particle.m_Stiffness);
			particle.m_Stiffness = stiffness2;
			float inert2 = Mathf.Clamp01(particle.m_Inert);
			particle.m_Inert = inert2;
			float friction2 = Mathf.Clamp01(particle.m_Friction);
			particle.m_Friction = friction2;
			float radius2 = Mathf.Max(particle.m_Radius, 0f);
			particle.m_Radius = radius2;
			particles = m_Particles;
			num++;
			if (m_Particles == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0x9FF6D4", Offset = "0x9FF6D4", Length = "0x104")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F0D0E0]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021C5C]) = v44;\nL_0016:\n\tv123 = this.m_Particles;\nL_0026:\n\tv149 = v110 >= v123._size;\n\tif (v149) goto L_0070;\n\tv187 = v123._size < v110;\n\tv106 = ~v187;\n\tv103 = v123._size - v110;\n\tv97 = v103 == 0;\n\tv188 = ~v97;\n\tv82 = v106 & v188;\n\tif (v82) goto L_0036;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0036:\n\tv222 = v123._items;\n\tv77 = v222[v110 @ X21_v6 (System.Int32)];\n\tgoto L_004A;\n\tv227 = *([v223 @ X0_v9+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_004A;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v223, v75, v72, v29, v30, v31, v32, v33, v69, v66, v63, v56, v38, v39, v40, v41);\nL_004A:\n\tv234 = UnityEngine.Object::op_Inequality(v77.m_Transform, 0);\n\tv236 = v234 == 0;\n\tif (v236) goto L_0061;\n\t// 85 MakeStruct v153 @ AGG9FF794_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v77.m_InitLocalPosition (UnityEngine.Vector3), v77.m_InitLocalPosition.y (System.Single), v77.m_InitLocalPosition.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v77.m_Transform, v153);\n\t// 95 MakeStruct v237 @ AGG9FF7AC_1_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v77.m_InitLocalRotation (UnityEngine.Quaternion), v77.m_InitLocalRotation.y (System.Single), v77.m_InitLocalRotation.z (System.Single), v77.m_InitLocalRotation.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v77.m_Transform, v237);\nL_0061:\n\tv123 = this.m_Particles;\n\tv110 = v110 + 1;\n\tv244 = this.m_Particles == 0;\n\tv116 = ~v244;\n\tif (v116) goto L_0026;\n\tthrow System.NullReferenceException;\nL_0070:\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void InitTransforms()
	{
		List<Particle> particles = m_Particles;
		int num = 0;
		Vector3 localPosition = default(Vector3);
		Quaternion localRotation = default(Quaternion);
		do
		{
			if (num < particles.Count)
			{
				bool flag = particles.Count < num;
				bool flag2 = !flag;
				int num2 = particles.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				Particle[] items = particles._items;
				Particle particle = items[num];
				if (particle.m_Transform != null)
				{
					localPosition.x = particle.m_InitLocalPosition.x;
					localPosition.y = particle.m_InitLocalPosition.y;
					localPosition.z = particle.m_InitLocalPosition.z;
					particle.m_Transform.localPosition = localPosition;
					localRotation.x = particle.m_InitLocalRotation.x;
					localRotation.y = particle.m_InitLocalRotation.y;
					localRotation.z = particle.m_InitLocalRotation.z;
					localRotation.w = particle.m_InitLocalRotation.w;
					particle.m_Transform.localRotation = localRotation;
				}
				particles = m_Particles;
				num++;
				continue;
			}
			return;
		}
		while (m_Particles != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0x9FF7D8", Offset = "0x9FF7D8", Length = "0x160")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB8E50]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C5D]) = v46;\nL_0017:\n\tv149 = this.m_Particles;\nL_0027:\n\tv176 = v130 >= v149._size;\n\tif (v176) goto L_008B;\n\tv231 = v149._size < v130;\n\tv125 = ~v231;\n\tv120 = v149._size - v130;\n\tv110 = v120 == 0;\n\tv232 = ~v110;\n\tv85 = v125 & v232;\n\tif (v85) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv238 = v149._items;\n\tv77 = v238[v130 @ X21_v6 (System.Int32)];\n\tgoto L_004B;\n\tv245 = *([v239 @ X0_v11+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_004B;\n\tv249 = \"il2cpp_codegen_runtime_class_init\"(v239, v74, v71, v31, v32, v33, v34, v35, v68, v65, v62, v39, v40, v41, v42, v43);\nL_004B:\n\tv135 = UnityEngine.Object::op_Inequality(v77.m_Transform, 0);\n\tv263 = v135 == 0;\n\tif (v263) goto L_0057;\n\tv67 = UnityEngine.Transform::get_position(v77.m_Transform);\n\tv64 = v67.y;\n\tv61 = v67.z;\n\tgoto L_007B;\nL_0057:\n\tv150 = this.m_Particles;\n\tv59 = v77.m_ParentIndex;\n\tv267 = v150._size < v77.m_ParentIndex;\n\tv126 = ~v267;\n\tv121 = v150._size - v77.m_ParentIndex;\n\tv111 = v121 == 0;\n\tv268 = ~v111;\n\tv86 = v126 & v268;\n\tif (v86) goto L_006A;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_006A:\n\tv272 = v150._items;\n\tv146 = v272[v59 @ X24_v7 (System.Int32)];\n\t// 119 MakeStruct v274 @ AGG9FF8DC_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v77.m_EndOffset (UnityEngine.Vector3), v77.m_EndOffset.y (System.Single), v77.m_EndOffset.z (System.Single)\n\tv67 = UnityEngine.Transform::TransformPoint(v146.m_Transform, v274);\n\tv64 = v67.y;\n\tv61 = v67.z;\nL_007B:\n\tv77.m_Position.z = v61;\n\tv77.m_PrevPosition = v67;\n\tv77.m_PrevPosition.y = v64;\n\tv77.m_PrevPosition.z = v61;\n\tv77.m_Position = v67;\n\tv77.m_Position.y = v64;\n\tv77.m_isCollide = 0;\n\tv149 = this.m_Particles;\n\tv130 = v130 + 1;\n\tv281 = this.m_Particles == 0;\n\tv138 = ~v281;\n\tif (v138) goto L_0027;\n\tthrow System.NullReferenceException;\nL_008B:\n\tv220 = UnityEngine.Component::get_transform(this);\n\tv244 = UnityEngine.Transform::get_position(v220);\n\tthis.m_ObjectPrevPosition = v244;\n\tthis.m_ObjectPrevPosition.y = v244.y;\n\tthis.m_ObjectPrevPosition.z = v244.z;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void ResetParticlesPosition()
	{
		List<Particle> particles = m_Particles;
		int num = 0;
		Vector3 position = default(Vector3);
		do
		{
			if (num < particles.Count)
			{
				bool flag = particles.Count < num;
				bool flag2 = !flag;
				int num2 = particles.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				Particle[] items = particles._items;
				Particle particle = items[num];
				Vector3 vector;
				float y;
				float z;
				if (particle.m_Transform != null)
				{
					vector = particle.m_Transform.position;
					y = vector.y;
					z = vector.z;
				}
				else
				{
					List<Particle> particles2 = m_Particles;
					int parentIndex = particle.m_ParentIndex;
					bool flag5 = particles2.Count < particle.m_ParentIndex;
					bool flag6 = !flag5;
					int num3 = particles2.Count - particle.m_ParentIndex;
					bool flag7 = num3 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					Particle[] items2 = particles2._items;
					Particle particle2 = items2[parentIndex];
					position.x = particle.m_EndOffset.x;
					position.y = particle.m_EndOffset.y;
					position.z = particle.m_EndOffset.z;
					vector = particle2.m_Transform.TransformPoint(position);
					y = vector.y;
					z = vector.z;
				}
				particle.m_Position.z = z;
				particle.m_PrevPosition = vector;
				particle.m_PrevPosition.y = y;
				particle.m_PrevPosition.z = z;
				particle.m_Position = vector;
				particle.m_Position.y = y;
				particle.m_isCollide = false;
				particles = m_Particles;
				num++;
				continue;
			}
			Transform transform = base.transform;
			Vector3 vector2 = (m_ObjectPrevPosition = transform.position);
			m_ObjectPrevPosition.y = vector2.y;
			m_ObjectPrevPosition.z = vector2.z;
			return;
		}
		while (m_Particles != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0x9FFC80", Offset = "0x9FFC80", Length = "0x340")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EC4050]);\n\tv39 = *([v38 @ X8_v29]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2021C5E]) = v58;\nL_001E:\n\tv60 = this + 0x98;\n\tv67 = 0x158A710(v60, 0, v42, v43, v44, v45, v46, v47, this.m_Gravity, v49, v50, v51, v52, v53, v54, v55);\n\t// 48 MakeStruct v77 @ AGG9FFD08_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_LocalGravity (UnityEngine.Vector3), this.m_LocalGravity.y (System.Single), this.m_LocalGravity.z (System.Single)\n\tv78 = UnityEngine.Transform::TransformDirection(this.m_Root, v77);\n\tgoto L_004B;\n\tv238 = *([v234 @ X0_v7+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_004B;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v234, v76, v42, v43, v44, v45, v46, v47, v78, v228, v229, v51, v52, v53, v54, v55);\nL_004B:\n\t// 75 MakeStruct v187 @ AGG9FFD54_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Gravity (UnityEngine.Vector3), v49 @ V1, v50 @ V2\n\tv252 = UnityEngine.Vector3::Dot(v78, v187);\n\tgoto L_005D;\n\tv368 = *([v364 @ X0_v10+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_005D;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v364, v76, v42, v43, v44, v45, v46, v47, v252, v246, v247, v248, v249, v250, v54, v55);\nL_005D:\n\tv378 = UnityEngine.Mathf::Max(v252, 0f);\n\t// 99 MakeStruct v184 @ AGG9FFDA0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Gravity (UnityEngine.Vector3), v49 @ V1, v50 @ V2\n\tv384 = UnityEngine.Vector3::op_Multiply(v184, v378);\n\t// 110 MakeStruct v181 @ AGG9FFDC0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Gravity (UnityEngine.Vector3), this.m_Gravity.y (System.Single), this.m_Gravity.z (System.Single)\n\tv394 = UnityEngine.Vector3::op_Subtraction(v181, v384);\n\t// 120 MakeStruct v172 @ AGG9FFDD0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Force (UnityEngine.Vector3), this.m_Force.y (System.Single), this.m_Force.z (System.Single)\n\tv401 = UnityEngine.Vector3::op_Addition(v394, v172);\n\tv406 = UnityEngine.Vector3::op_Multiply(v401, this.m_ObjectScale);\n\tv508 = this.m_Particles;\nL_0093:\n\tv522 = v155 >= v508._size;\n\tif (v522) goto L_014C;\n\tv533 = v508._size < v155;\n\tv153 = ~v533;\n\tv150 = v508._size - v155;\n\tv144 = v150 == 0;\n\tv534 = ~v144;\n\tv129 = v153 & v534;\n\tif (v129) goto L_00A3;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00A3:\n\tv536 = v508._items;\n\tv160 = v536[v155 @ X21_v6 (System.Int32)];\n\tv537 = v160.m_ParentIndex & 0x80000000;\n\tv538 = v537 == 0;\n\tv539 = ~v538;\n\tif (v539) goto L_012A;\n\tgoto L_00C5;\n\tv547 = *([v540 @ X0_v25+E0]);\n\tv548 = v547 == 0;\n\tv549 = ~v548;\n\tif (v549) goto L_00C5;\n\tv551 = \"il2cpp_codegen_runtime_class_init\"(v540, v206, v42, v43, v44, v45, v46, v47, v212, v210, v208, v196, v194, v192, v54, v55);\nL_00C5:\n\t// 197 MakeStruct v561 @ AGG9FFE6C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v160.m_Position (UnityEngine.Vector3), v160.m_Position.y (System.Single), v160.m_Position.z (System.Single)\n\t// 198 MakeStruct v562 @ AGG9FFE6C_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v160.m_PrevPosition (UnityEngine.Vector3), v160.m_PrevPosition.y (System.Single), v160.m_PrevPosition.z (System.Single)\n\tv563 = UnityEngine.Vector3::op_Subtraction(v561, v562);\n\t// 211 MakeStruct v577 @ AGG9FFE8C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_ObjectMove (UnityEngine.Vector3), this.m_ObjectMove.y (System.Single), this.m_ObjectMove.z (System.Single)\n\tv578 = UnityEngine.Vector3::op_Multiply(v577, v160.m_Inert);\n\t// 226 MakeStruct v594 @ AGG9FFEB8_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v160.m_Position (UnityEngine.Vector3), v160.m_Position.y (System.Single), v160.m_Position.z (System.Single)\n\tv596 = UnityEngine.Vector3::op_Addition(v594, v578);\n\tv609 = v160.m_Damping;\n\tv160.m_PrevPosition = v596;\n\tv160.m_PrevPosition.y = v596.y;\n\tv160.m_PrevPosition.z = v596.z;\n\tv623 = ~v160.m_isCollide;\n\tif (v623) goto L_00FA;\n\tv160.m_isCollide = 0;\n\tv626 = v160.m_Damping + v160.m_Friction;\n\tv609 = UnityEngine.Mathf::Min(v626, 1f);\nL_00FA:\n\tgoto L_0101;\n\tv634 = *([v630 @ X0_v30+E0]);\n\tv635 = v634 == 0;\n\tv636 = ~v635;\n\tif (v636) goto L_0101;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v630, v206, v42, v43, v44, v45, v46, v47, v629, v628, v620, v590, v591, v592, v54, v55);\nL_0101:\n\tv640 = 1f - v609;\n\tv645 = UnityEngine.Vector3::op_Multiply(v563, v640);\n\tv652 = UnityEngine.Vector3::op_Addition(v645, v406);\n\tv659 = UnityEngine.Vector3::op_Addition(v652, v578);\n\t// 291 MakeStruct v598 @ AGG9FFF5C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v160.m_Position (UnityEngine.Vector3), v160.m_Position.y (System.Single), v160.m_Position.z (System.Single)\n\tv480 = UnityEngine.Vector3::op_Addition(v598, v659);\n\tv478 = v480.y;\n\tv476 = v480.z;\n\tgoto L_0133;\nL_012A:\n\tv160.m_PrevPosition = v160.m_Position;\n\tv160.m_PrevPosition.y = v160.m_Position.y;\n\tv160.m_PrevPosition.z = v160.m_Position.z;\n\tv480 = UnityEngine.Transform::get_position(v160.m_Transform);\n\tv478 = v480.y;\n\tv476 = v480.z;\nL_0133:\n\tv160.m_Position = v480;\n\tv160.m_Position.y = v478;\n\tv160.m_Position.z = v476;\n\tv508 = this.m_Particles;\n\tv155 = v155 + 1;\n\tv618 = this.m_Particles == 0;\n\tv491 = ~v618;\n\tif (v491) goto L_0093;\n\tthrow System.NullReferenceException;\nL_014C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateParticles1()
	{
		//IL_05df: Expected O, but got I
		//IL_007a: Expected F4, but got O
		//IL_0087: Expected F4, but got O
		//IL_00d0: Expected F4, but got O
		//IL_00dd: Expected F4, but got O
		//IL_026c: Expected I4, but got I8
		object obj = (long)(IntPtr)this + 152L;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
		Vector3 direction = default(Vector3);
		direction.x = m_LocalGravity.x;
		direction.y = m_LocalGravity.y;
		direction.z = m_LocalGravity.z;
		Vector3 lhs = m_Root.TransformDirection(direction);
		Vector3 rhs = default(Vector3);
		rhs.x = m_Gravity.x;
		object obj2 = default(object);
		rhs.y = (float)obj2;
		object obj3 = default(object);
		rhs.z = (float)obj3;
		float a = Vector3.Dot(lhs, rhs);
		float num = Mathf.Max(a, 0f);
		Vector3 vector = default(Vector3);
		vector.x = m_Gravity.x;
		vector.y = (float)obj2;
		vector.z = (float)obj3;
		Vector3 vector2 = vector * num;
		Vector3 vector3 = default(Vector3);
		vector3.x = m_Gravity.x;
		vector3.y = m_Gravity.y;
		vector3.z = m_Gravity.z;
		Vector3 vector4 = vector3 - vector2;
		Vector3 vector5 = default(Vector3);
		vector5.x = m_Force.x;
		vector5.y = m_Force.y;
		vector5.z = m_Force.z;
		Vector3 vector6 = vector4 + vector5;
		Vector3 vector7 = vector6 * m_ObjectScale;
		List<Particle> particles = m_Particles;
		int num2 = 0;
		Vector3 vector8 = default(Vector3);
		Vector3 vector9 = default(Vector3);
		Vector3 vector11 = default(Vector3);
		Vector3 vector13 = default(Vector3);
		Vector3 vector17 = default(Vector3);
		while (num2 < particles.Count)
		{
			bool flag = particles.Count < num2;
			bool flag2 = !flag;
			int num3 = particles.Count - num2;
			bool flag3 = num3 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items = particles._items;
			Particle particle = items[num2];
			Vector3 position;
			float y;
			float z;
			if ((int)(particle.m_ParentIndex & 0x80000000L) == 0)
			{
				vector8.x = particle.m_Position.x;
				vector8.y = particle.m_Position.y;
				vector8.z = particle.m_Position.z;
				vector9.x = particle.m_PrevPosition.x;
				vector9.y = particle.m_PrevPosition.y;
				vector9.z = particle.m_PrevPosition.z;
				Vector3 vector10 = vector8 - vector9;
				vector11.x = m_ObjectMove.x;
				vector11.y = m_ObjectMove.y;
				vector11.z = m_ObjectMove.z;
				Vector3 vector12 = vector11 * particle.m_Inert;
				vector13.x = particle.m_Position.x;
				vector13.y = particle.m_Position.y;
				vector13.z = particle.m_Position.z;
				Vector3 prevPosition = vector13 + vector12;
				float num4 = particle.m_Damping;
				particle.m_PrevPosition = prevPosition;
				particle.m_PrevPosition.y = prevPosition.y;
				particle.m_PrevPosition.z = prevPosition.z;
				if (particle.m_isCollide)
				{
					particle.m_isCollide = false;
					float a2 = particle.m_Damping + particle.m_Friction;
					num4 = Mathf.Min(a2, 1f);
				}
				float num5 = 1f - num4;
				Vector3 vector14 = vector10 * num5;
				Vector3 vector15 = vector14 + vector7;
				Vector3 vector16 = vector15 + vector12;
				vector17.x = particle.m_Position.x;
				vector17.y = particle.m_Position.y;
				vector17.z = particle.m_Position.z;
				position = vector17 + vector16;
				y = position.y;
				z = position.z;
			}
			else
			{
				particle.m_PrevPosition = particle.m_Position;
				particle.m_PrevPosition.y = particle.m_Position.y;
				particle.m_PrevPosition.z = particle.m_Position.z;
				position = particle.m_Transform.position;
				y = position.y;
				z = position.z;
			}
			particle.m_Position = position;
			particle.m_Position.y = y;
			particle.m_Position.z = z;
			particles = m_Particles;
			num2++;
			if (m_Particles == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0x9FFFC0", Offset = "0x9FFFC0", Length = "0x7A4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0024;\n\tv50 = *([1EA86A8]);\n\tv51 = *([v50 @ X8_v71]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([2021C5F]) = v70;\nL_0024:\n\t*([v40 @ X29_v1-A8]) = 0;\n\t*([v40 @ X29_v1-B0]) = 0;\n\t*([v40 @ X29_v1-B8]) = 0;\n\t*([v40 @ X29_v1-C0]) = 0;\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-98]) = 0;\n\tv476 = this.m_Particles;\nL_0046:\n\tv505 = v452 >= v476._size;\n\tif (v505) goto L_0345;\n\tv683 = v476._size < v452;\n\tv445 = ~v683;\n\tv438 = v476._size - v452;\n\tv424 = v438 == 0;\n\tv685 = ~v424;\n\tv384 = v445 & v685;\n\tif (v384) goto L_0058;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv391 = this.m_Particles;\nL_0058:\n\tv798 = v476._items;\n\tv123 = v798[v452 @ X22_v6 (System.Int32)];\n\tv911 = v123.m_ParentIndex;\n\tv913 = v391._size < v123.m_ParentIndex;\n\tv446 = ~v913;\n\tv439 = v391._size - v123.m_ParentIndex;\n\tv425 = v439 == 0;\n\tv914 = ~v425;\n\tv385 = v446 & v914;\n\tif (v385) goto L_0070;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0070:\n\tv917 = v391._items;\n\tv367 = v917[v911 @ X20_v8 (System.Int32)];\n\tgoto L_0082;\n\tv922 = *([v918 @ X0_v10+E0]);\n\tv923 = v922 == 0;\n\tv924 = ~v923;\n\tif (v924) goto L_0082;\n\tv926 = \"il2cpp_codegen_runtime_class_init\"(v918, v362, v356, v55, v56, v57, v58, v59, v351, v347, v343, v316, v312, v308, v66, v67);\nL_0082:\n\tv458 = UnityEngine.Object::op_Inequality(v123.m_Transform, 0);\n\tv931 = v458 == 0;\n\tif (v931) goto L_00B6;\n\tv633 = UnityEngine.Transform::get_position(v367.m_Transform);\n\tv633 = UnityEngine.Transform::get_position(v123.m_Transform);\n\tgoto L_00B0;\n\tv1005 = *([v994 @ X0_v96+E0]);\n\tv1006 = v1005 == 0;\n\tv1007 = ~v1006;\n\tif (v1007) goto L_00B0;\n\tv1009 = \"il2cpp_codegen_runtime_class_init\"(v994, v965, v357, v55, v56, v57, v58, v59, v966, v992, v993, v316, v312, v308, v66, v67);\nL_00B0:\n\tv633 = UnityEngine.Vector3::op_Subtraction(v633, v633);\n\tv979 = v633.y;\n\tv977 = v633.z;\n\tgoto L_00D5;\nL_00B6:\n\tv934 = UnityEngine.Transform::get_localToWorldMatrix(v367.m_Transform);\n\tv935 = v934.m00;\n\tv633 = v123.m_EndOffset;\n\tv979 = v123.m_EndOffset.y;\n\tv977 = v123.m_EndOffset.z;\n\tv964 = 0x10C2868(&v935 @ stack_-1A0_v8 (System.Single), 0, 0, v55, v56, v57, v58, v59, v123.m_EndOffset, v123.m_EndOffset.y, v123.m_EndOffset.z, v934.m00, v313, v309, v66, v67);\nL_00D5:\n\tv990 = &v41 @ stack_-10_v2 - 0xC0;\n\t*([v40 @ X29_v1-C0]) = v633;\n\t*([v40 @ X29_v1-BC]) = v979;\n\t*([v40 @ X29_v1-B8]) = v977;\n\tv991 = 0x158AD58(v990, 0, 0, v55, v56, v57, v58, v59, v633, v979, v977, v317, v313, v309, v66, v67);\n\tgoto L_00EE;\n\tv1013 = *([v1001 @ X0_v18+E0]);\n\tv1014 = v1013 == 0;\n\tv1015 = ~v1014;\n\tif (v1015) goto L_00EE;\n\tv1017 = \"il2cpp_codegen_runtime_class_init\"(v1001, v640, v357, v55, v56, v57, v58, v59, v981, v979, v977, v604, v602, v600, v66, v67);\nL_00EE:\n\tv1021 = UnityEngine.Mathf::Lerp(1f, v123.m_Stiffness, this.m_Weight);\n\tv1032 = v1021 > 0;\n\tif (v1032) goto L_0110;\n\tv1045 = v123.m_Elasticity <= 0;\n\tif (v1045) goto L_0204;\nL_0110:\n\tv1145 = UnityEngine.Transform::get_localToWorldMatrix(v367.m_Transform);\n\tv935 = v1145.m00;\n\tgoto L_013C;\n\tv1210 = *([v1184 @ X0_v59+E0]);\n\tv1211 = v1210 == 0;\n\tv1212 = ~v1211;\n\tif (v1212) goto L_013C;\n\tv1214 = \"il2cpp_codegen_runtime_class_init\"(v1184, v1144, v357, v55, v56, v57, v58, v59, v1180, v1179, v1182, v1181, v602, v600, v66, v67);\nL_013C:\n\t// 316 MakeStruct v534 @ AGGA00264_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v367.m_Position (UnityEngine.Vector3), v367.m_Position.y (System.Single), v367.m_Position.z (System.Single)\n\tv635 = UnityEngine.Vector4::op_Implicit(v534);\n\tv1236 = 0x10C26E8(&v935 @ stack_-1A0_v8 (System.Single), 3, 0, v55, v56, v57, v58, v59, v635, v635.y, v635.z, v635.w, v313, v309, v66, v67);\n\tgoto L_0153;\n\tv1273 = *([v1249 @ X0_v64+E0]);\n\tv1274 = v1273 == 0;\n\tv1275 = ~v1274;\n\tif (v1275) goto L_0153;\n\tv1277 = \"il2cpp_codegen_runtime_class_init\"(v1249, v1234, v1235, v55, v56, v57, v58, v59, v635, v631, v627, v605, v602, v600, v66, v67);\nL_0153:\n\tv1280 = UnityEngine.Object::op_Inequality(v123.m_Transform, 0);\n\tv1294 = v1280 == 0;\n\tif (v1294) goto L_015F;\n\tv633 = UnityEngine.Transform::get_localPosition(v123.m_Transform);\n\tv1337 = v633.y;\n\tv1335 = v633.z;\n\tgoto L_0164;\nL_015F:\n\tv633 = v123.m_EndOffset;\n\tv1337 = v123.m_EndOffset.y;\n\tv1335 = v123.m_EndOffset.z;\nL_0164:\n\tv1344 = 0x10C27FC(&v935 @ stack_-1A0_v8 (System.Single), 0, 0, v55, v56, v57, v58, v59, v633, v1337, v1335, v635.w, v313, v309, v66, v67);\n\tgoto L_017C;\n\tv1376 = *([v1361 @ X0_v71+E0]);\n\tv1377 = v1376 == 0;\n\tv1378 = ~v1377;\n\tgoto L_017C;\n\tv1380 = \"il2cpp_codegen_runtime_class_init\"(v1361, v1100, v637, v55, v56, v57, v58, v59, v1339, v1337, v1335, v605, v602, v600, v66, v67);\nL_017C:\n\t// 380 MakeStruct v1061 @ AGGA00318_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v633 @ V0_v54 (UnityEngine.Vector3), v1337 @ V1_v25 (System.Single), v1335 @ V2_v23 (System.Single)\n\t// 381 MakeStruct v1060 @ AGGA00318_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v123.m_Position (UnityEngine.Vector3), v123.m_Position.y (System.Single), v123.m_Position.z (System.Single)\n\tv633 = UnityEngine.Vector3::op_Subtraction(v1061, v1060);\n\tv633 = UnityEngine.Vector3::op_Multiply(v633, v123.m_Elasticity);\n\t// 404 MakeStruct v1052 @ AGGA00354_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v123.m_Position (UnityEngine.Vector3), v123.m_Position.y (System.Single), v123.m_Position.z (System.Single)\n\tv633 = UnityEngine.Vector3::op_Addition(v1052, v633);\n\tv868 = v633.y;\n\tv344 = v633.z;\n\tv123.m_Position = v633;\n\tv123.m_Position.y = v633.y;\n\tv123.m_Position.z = v633.z;\n\tv1103 = v1021 <= 0;\n\tif (v1103) goto L_0204;\n\tgoto L_01BD;\n\tv1454 = *([v1450 @ X0_v76+E0]);\n\tv1455 = v1454 == 0;\n\tv1456 = ~v1455;\n\tif (v1456) goto L_01BD;\n\tv1458 = \"il2cpp_codegen_runtime_class_init\"(v1450, v1100, v637, v55, v56, v57, v58, v59, v1095, v1091, v1087, v1073, v1070, v1067, v66, v67);\nL_01BD:\n\t// 445 MakeStruct v1050 @ AGGA003A8_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v633 @ V0_v54 (UnityEngine.Vector3), v1337 @ V1_v25 (System.Single), v1335 @ V2_v23 (System.Single)\n\tv633 = UnityEngine.Vector3::op_Subtraction(v1050, v633);\n\tv1171 = 0x158AD58(&v633 @ V0_v54 (UnityEngine.Vector3), 0, 0, v55, v56, v57, v58, v59, v633, v633.y, v633.z, v633, v633.y, v633.z, v66, v67);\n\tv1467 = 1f - v1021;\n\tv1096 = v633 * v1467;\n\tv1085 = v1096 + v1096;\n\tv1102 = v633 <= v1085;\n\tif (v1102) goto L_0204;\n\tgoto L_01EB;\n\tv1475 = *([v1471 @ X0_v81+E0]);\n\tv1476 = v1475 == 0;\n\tv1477 = ~v1476;\n\tif (v1477) goto L_01EB;\n\tv1479 = \"il2cpp_codegen_runtime_class_init\"(v1471, v1099, v637, v55, v56, v57, v58, v59, v1096, v1092, v1088, v1074, v1071, v1068, v66, v67);\nL_01EB:\n\tv1480 = v1096 - v1085;\n\tv1481 = v1480 / v1096;\n\tv633 = UnityEngine.Vector3::op_Multiply(v1096, v1481);\n\t// 508 MakeStruct v1047 @ AGGA00440_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v123.m_Position (UnityEngine.Vector3), v123.m_Position.y (System.Single), v123.m_Position.z (System.Single)\n\tv633 = UnityEngine.Vector3::op_Addition(v1047, v633);\n\tv868 = v633.y;\n\tv344 = v633.z;\n\tv123.m_Position = v633;\n\tv123.m_Position.y = v633.y;\n\tv123.m_Position.z = v633.z;\nL_0204:\n\tv1154 = this.m_Colliders;\n\tv1142 = this.m_Colliders == 0;\n\tif (v1142) goto L_025F;\n\tv353 = v123.m_Radius;\n\tv868 = this.m_ObjectScale;\n\tv478 = v798[v452 @ X22_v6 (System.Int32)] + 0x3C;\n\tv337 = v123.m_Radius * this.m_ObjectScale;\nL_0216:\n\tv1153 = v138 >= v1154._size;\n\tif (v1153) goto L_025F;\n\tv1221 = v1154._size < v138;\n\tv447 = ~v1221;\n\tv440 = v1154._size - v138;\n\tv426 = v440 == 0;\n\tv1222 = ~v426;\n\tv386 = v447 & v1222;\n\tif (v386) goto L_0226;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0226:\n\tv1239 = v1154._items;\n\tv392 = v1239[v138 @ X25_v8 (System.Int32)];\n\tgoto L_0237;\n\tv1253 = *([v1240 @ X0_v46+E0]);\n\tv1254 = v1253 == 0;\n\tv1255 = ~v1254;\n\tif (v1255) goto L_0237;\n\tv1257 = \"il2cpp_codegen_runtime_class_init\"(v1240, v1149, v1148, v55, v56, v57, v58, v59, v352, v348, v344, v317, v313, v309, v66, v67);\nL_0237:\n\tv1171 = UnityEngine.Object::op_Inequality(v1239[v138 @ X25_v8 (System.Int32)], 0);\n\tv1282 = \n// ... truncated")]
	private void UpdateParticles2()
	{
		//IL_0281: Expected O, but got I
		//IL_031d: Expected O, but got F4
		//IL_0326: Expected O, but got I4
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Expected O, but got Unknown
		//IL_0ae1: Expected O, but got I
		//IL_0af0: Expected O, but got I
		//IL_0b00: Expected O, but got I
		//IL_0b21: Expected O, but got I
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Expected O, but got Unknown
		//IL_0ab1: Expected O, but got I
		//IL_0f30: Expected O, but got F4
		//IL_0ba5: Expected F4, but got O
		//IL_0bb2: Expected F4, but got O
		//IL_05f4: Expected O, but got I4
		//IL_0bec: Expected O, but got F4
		//IL_0bf9: Expected O, but got F4
		//IL_0c63: Expected O, but got I
		//IL_0952: Expected O, but got I4
		//IL_06fa: Expected O, but got F4
		//IL_0703: Expected O, but got I4
		//IL_0993: Expected O, but got I4
		//IL_0d1d: Expected F4, but got I
		//IL_0d32: Expected F4, but got I
		//IL_0d47: Expected F4, but got I
		//IL_0d7c: Expected F4, but got O
		//IL_0d89: Expected F4, but got O
		//IL_09ae: Expected I, but got O
		//IL_09bf: Expected O, but got I
		//IL_0747: Expected O, but got F4
		//IL_0dc3: Expected O, but got F4
		//IL_0dd0: Expected O, but got F4
		//IL_082b: Expected O, but got I4
		object obj2 = default(object);
		object obj = obj2;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		List<Particle> particles = m_Particles;
		int num = 1;
		Vector3 vector = default(Vector3);
		Vector3 vector3 = default(Vector3);
		Vector3 vector4 = default(Vector3);
		Vector3 vector5 = default(Vector3);
		Vector3 vector6 = default(Vector3);
		Vector3 vector7 = default(Vector3);
		Vector3 vector8 = default(Vector3);
		Vector3 vector9 = default(Vector3);
		Vector3 vector10 = default(Vector3);
		Vector3 vector11 = default(Vector3);
		Vector3 vector12 = default(Vector3);
		do
		{
			if (num >= particles.Count)
			{
				return;
			}
			bool flag = particles.Count < num;
			bool flag2 = !flag;
			int num2 = particles.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			List<Particle> list = particles;
			if (!flag5)
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items = particles._items;
			Particle particle = items[num];
			int parentIndex = particle.m_ParentIndex;
			bool flag6 = list.Count < particle.m_ParentIndex;
			bool flag7 = !flag6;
			int num3 = list.Count - particle.m_ParentIndex;
			bool flag8 = num3 == 0;
			bool flag9 = !flag8;
			if (!(flag7 && flag9))
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items2 = list._items;
			Particle particle2 = items2[parentIndex];
			float m;
			float x;
			Vector3 position;
			float z2;
			float y2;
			if (particle.m_Transform != null)
			{
				position = particle2.m_Transform.position;
				position = particle.m_Transform.position;
				position -= position;
				float y = position.y;
				float z = position.z;
				z2 = position.z;
				y2 = position.y;
				x = position.x;
			}
			else
			{
				Matrix4x4 localToWorldMatrix = particle2.m_Transform.localToWorldMatrix;
				m = localToWorldMatrix.m00;
				position = particle.m_EndOffset;
				float y = particle.m_EndOffset.y;
				float z = particle.m_EndOffset.z;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
				x = localToWorldMatrix.m00;
			}
			object obj3 = (long)(IntPtr)obj2 - 192L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			float num4 = Mathf.Lerp(1f, particle.m_Stiffness, m_Weight);
			float z3;
			float y3;
			bool flag11;
			UnityEngine.Object obj5;
			object obj4;
			if (!(num4 > 0f))
			{
				bool flag10 = !(particle.m_Elasticity > 0f);
				z3 = m_Weight;
				y3 = particle.m_Stiffness;
				position = (Vector3)particle.m_Elasticity;
				obj4 = 0;
				obj5 = null;
				flag11 = false;
				if (flag10)
				{
					goto IL_0e4c;
				}
			}
			m = particle2.m_Transform.localToWorldMatrix.m00;
			vector.x = particle2.m_Position.x;
			vector.y = particle2.m_Position.y;
			vector.z = particle2.m_Position.z;
			Vector4 vector2 = vector;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C26E8 (inside UnityEngine.Matrix4x4::op_Multiply +0x94)");
			float y4;
			float z4;
			if (particle.m_Transform != null)
			{
				position = particle.m_Transform.localPosition;
				y4 = position.y;
				z4 = position.z;
			}
			else
			{
				position = particle.m_EndOffset;
				y4 = particle.m_EndOffset.y;
				z4 = particle.m_EndOffset.z;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
			vector3.x = position.x;
			vector3.y = y4;
			vector3.z = z4;
			vector4.x = particle.m_Position.x;
			vector4.y = particle.m_Position.y;
			vector4.z = particle.m_Position.z;
			position = vector3 - vector4;
			position *= particle.m_Elasticity;
			vector5.x = particle.m_Position.x;
			vector5.y = particle.m_Position.y;
			vector5.z = particle.m_Position.z;
			position = vector5 + position;
			y3 = position.y;
			z3 = position.z;
			particle.m_Position = position;
			particle.m_Position.y = position.y;
			particle.m_Position.z = position.z;
			bool flag12 = !(num4 > 0f);
			z2 = position.z;
			y2 = position.y;
			x = position.x;
			obj4 = 0;
			obj5 = null;
			flag11 = false;
			if (!flag12)
			{
				vector6.x = position.x;
				vector6.y = y4;
				vector6.z = z4;
				position = vector6 - position;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				float num5 = 1f - num4;
				float num6 = position.x * num5;
				float num7 = num6 + num6;
				bool flag13 = !(position.x > num7);
				z2 = position.z;
				y2 = position.y;
				x = position.x;
				z3 = position.z;
				y3 = position.x;
				position = (Vector3)num6;
				obj4 = 0;
				obj5 = null;
				if (!flag13)
				{
					float num8 = num6 - num7;
					float num9 = num8 / num6;
					position = (Vector3)num6 * num9;
					vector7.x = particle.m_Position.x;
					vector7.y = particle.m_Position.y;
					vector7.z = particle.m_Position.z;
					position = vector7 + position;
					y3 = position.y;
					z3 = position.z;
					particle.m_Position = position;
					particle.m_Position.y = position.y;
					particle.m_Position.z = position.z;
					z2 = position.z;
					y2 = position.y;
					x = position.x;
					obj4 = 0;
					obj5 = null;
					flag11 = false;
				}
			}
			goto IL_0e4c;
			IL_0e4c:
			List<DynamicBoneColliderBase> colliders = m_Colliders;
			if (m_Colliders != null)
			{
				float num10 = particle.m_Radius;
				y3 = m_ObjectScale;
				UnityEngine.Object obj6 = (UnityEngine.Object)(items[num] + 60);
				float num11 = particle.m_Radius * m_ObjectScale;
				int num12 = 0;
				while (true)
				{
					bool flag14 = num12 >= colliders.Count;
					position = (Vector3)num10;
					if (flag14)
					{
						break;
					}
					bool flag15 = colliders.Count < num12;
					bool flag16 = !flag15;
					int num13 = colliders.Count - num12;
					bool flag17 = num13 == 0;
					bool flag18 = !flag17;
					if (!(flag16 && flag18))
					{
						throw new ArgumentOutOfRangeException();
					}
					DynamicBoneColliderBase[] items3 = colliders._items;
					UnityEngine.Object obj7 = items3[num12];
					flag11 = items3[num12] != null;
					bool flag19 = !flag11;
					obj4 = 0;
					obj5 = null;
					if (!flag19)
					{
						flag11 = items3[num12].enabled;
						bool flag20 = !flag11;
						obj4 = 0;
						obj5 = null;
						if (!flag20)
						{
							IntPtr intPtr = (IntPtr)obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1368 @ X8_v41 (Il2CppClass<UnityEngine.Object>)+178]");
							obj4 = 0;
							bool flag21 = !particle.m_isCollide;
							bool flag22 = !flag21;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1368 @ X8_v41 (Il2CppClass<UnityEngine.Object>)+170] (should have been resolved before IL gen)");
							int num14 = ((flag22 || flag11) ? 1 : 0);
							int isCollide = num14 & 1;
							particle.m_isCollide = (byte)isCollide != 0;
							num10 = num11;
						}
					}
					colliders = m_Colliders;
					num12++;
					if (m_Colliders == null)
					{
						goto end_IL_0f3e;
					}
				}
			}
			FreezeAxis freezeAxis = m_FreezeAxis;
			bool flag23 = m_FreezeAxis < FreezeAxis.Z;
			bool flag24 = !flag23;
			int num15 = (int)(m_FreezeAxis - 3);
			bool flag25 = num15 == 0;
			bool flag26 = !flag25;
			if (!(flag24 && flag26))
			{
				int num16 = 25264128 + 1672;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v876 @ X9_v8 (System.Int32)+v1175 @ X8_v22 (DynamicBone+FreezeAxis)*4]");
				object obj8 = 0L + (long)num16;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v907 @ X8_v34 (should have been resolved before IL gen)");
			}
			object obj9 = items[num] + 60;
			object obj10 = (long)(IntPtr)obj2 - 160L;
			object obj11 = (long)(IntPtr)obj9 + 4L;
			object obj12 = (long)(IntPtr)obj9 + 8L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C884C (inside UnityEngine.Object::.cctor +0x11C)");
			object obj13 = (long)(IntPtr)obj2 - 160L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C892C (inside UnityEngine.Object::.cctor +0x1FC)");
			vector8.x = position.x;
			vector8.y = y3;
			vector8.z = z3;
			position = vector8 * particle.m_Position.x;
			vector9.x = particle.m_Position.x;
			vector9.y = (float)obj11;
			vector9.z = (float)obj12;
			position = vector9 - position;
			particle.m_Position.x = position.x;
			obj11 = position.y;
			obj12 = position.z;
			vector10.x = particle2.m_Position.x;
			vector10.y = particle2.m_Position.y;
			vector10.z = particle2.m_Position.z;
			position = vector10 - position;
			object obj14 = (long)(IntPtr)obj2 - 176L;
			_ = position.y;
			_ = position.z;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			bool flag27 = !(position.x > 0f);
			z2 = position.z;
			y2 = position.y;
			if (!flag27)
			{
				float num17 = position.x - position.x;
				float num18 = num17 / position.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B0]");
				vector11.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-AC]");
				vector11.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
				vector11.z = 0f;
				position = vector11 * num18;
				vector12.x = particle.m_Position.x;
				vector12.y = (float)obj11;
				vector12.z = (float)obj12;
				position = vector12 + position;
				particle.m_Position.x = position.x;
				obj11 = position.y;
				obj12 = position.z;
				z2 = position.z;
				y2 = position.y;
			}
			particles = m_Particles;
			num++;
			continue;
			end_IL_0f3e:
			break;
		}
		while (m_Particles != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000018")]
	[Address(RVA = "0xA00764", Offset = "0xA00764", Length = "0x620")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0024;\n\tv50 = *([1EACD58]);\n\tv51 = *([v50 @ X8_v63]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([2021C60]) = v70;\nL_0024:\n\t*([v40 @ X29_v1-98]) = 0;\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-A8]) = 0;\n\t*([v40 @ X29_v1-B0]) = 0;\n\tv428 = this.m_Particles;\nL_0042:\n\tv455 = v407 >= v428._size;\n\tif (v455) goto L_0285;\n\tv643 = v428._size < v407;\n\tv402 = ~v643;\n\tv397 = v428._size - v407;\n\tv387 = v397 == 0;\n\tv644 = ~v387;\n\tv362 = v402 & v644;\n\tif (v362) goto L_0052;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0052:\n\tv751 = v428._items;\n\tv354 = v751[v407 @ X21_v6 (System.Int32)];\n\tv753 = v354.m_ParentIndex & 0x80000000;\n\tv754 = v753 == 0;\n\tv755 = ~v754;\n\tif (v755) goto L_00EB;\n\tgoto L_0074;\n\tv761 = *([v756 @ X0_v12+E0]);\n\tv762 = v761 == 0;\n\tv763 = ~v762;\n\tif (v763) goto L_0074;\n\tv765 = \"il2cpp_codegen_runtime_class_init\"(v756, v253, v249, v55, v56, v57, v58, v59, v326, v322, v318, v314, v310, v306, v288, v67);\nL_0074:\n\t// 116 MakeStruct v302 @ AGGA00874_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v354.m_PrevPosition (UnityEngine.Vector3), v354.m_PrevPosition.y (System.Single), v354.m_PrevPosition.z (System.Single)\n\t// 117 MakeStruct v297 @ AGGA00874_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_ObjectMove (UnityEngine.Vector3), this.m_ObjectMove.y (System.Single), this.m_ObjectMove.z (System.Single)\n\tv774 = UnityEngine.Vector3::op_Addition(v302, v297);\n\tv780 = v751[v407 @ X21_v6 (System.Int32)];\n\tv883 = v751[v407 @ X21_v6 (System.Int32)] + 0x44;\n\tv780.m_PrevPosition = v774;\n\tv780.m_PrevPosition.y = v774.y;\n\tv780.m_PrevPosition.z = v774.z;\n\tv881 = v883 + -8;\n\tv774 = *([v881 @ X28_v7]);\n\tv880 = v883 + -4;\n\tv567 = this.m_ObjectMove.y;\n\tv565 = this.m_ObjectMove.z;\n\t// 138 MakeStruct v276 @ AGGA008A8_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v881 @ X28_v7], [v880 @ X27_v7], v780.m_Position.z (System.Single)\n\t// 139 MakeStruct v271 @ AGGA008A8_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_ObjectMove (UnityEngine.Vector3), this.m_ObjectMove.y (System.Single), this.m_ObjectMove.z (System.Single)\n\tv774 = UnityEngine.Vector3::op_Addition(v276, v271);\n\t*([v881 @ X28_v7]) = v774;\n\t*([v880 @ X27_v7]) = v774.y;\n\tv780.m_Position.z = v774.z;\n\tv267 = this.m_Particles;\n\tv940 = v780.m_ParentIndex;\n\tv942 = v267._size < v780.m_ParentIndex;\n\tv403 = ~v942;\n\tv398 = v267._size - v780.m_ParentIndex;\n\tv388 = v398 == 0;\n\tv943 = ~v388;\n\tv363 = v403 & v943;\n\tif (v363) goto L_00A6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00A6:\n\tv965 = v267._items;\n\tv258 = v965[v940 @ X20_v11 (System.Int32)];\n\tgoto L_00B9;\n\tv971 = *([v968 @ X0_v17+E0]);\n\tv972 = v971 == 0;\n\tv973 = ~v972;\n\tif (v973) goto L_00B9;\n\tv975 = \"il2cpp_codegen_runtime_class_init\"(v968, v253, v249, v55, v56, v57, v58, v59, v327, v323, v319, v315, v311, v307, v289, v67);\nL_00B9:\n\tv415 = UnityEngine.Object::op_Inequality(v354.m_Transform, 0);\n\tv980 = v415 == 0;\n\tif (v980) goto L_00FE;\n\tv774 = UnityEngine.Transform::get_position(v258.m_Transform);\n\tv774 = UnityEngine.Transform::get_position(v354.m_Transform);\n\tgoto L_00E7;\n\tv1055 = *([v1044 @ X0_v74+E0]);\n\tv1056 = v1055 == 0;\n\tv1057 = ~v1056;\n\tif (v1057) goto L_00E7;\n\tv1059 = \"il2cpp_codegen_runtime_class_init\"(v1044, v1014, v250, v55, v56, v57, v58, v59, v1015, v1042, v1043, v315, v311, v307, v289, v67);\nL_00E7:\n\tv774 = UnityEngine.Vector3::op_Subtraction(v774, v774);\n\tv1025 = v774.y;\n\tv1023 = v774.z;\n\tgoto L_011D;\nL_00EB:\n\tv601 = v751[v407 @ X21_v6 (System.Int32)] + 0x3C;\n\tv883 = v601 + 8;\n\tv354.m_PrevPosition = v354.m_Position;\n\tv354.m_PrevPosition.z = *([v883 @ X24_v7]);\n\tv880 = v601 + 4;\n\tv774 = UnityEngine.Transform::get_position(v354.m_Transform);\n\tv894 = v774.y;\n\tv892 = v774.z;\n\tgoto L_0266;\nL_00FE:\n\tv983 = UnityEngine.Transform::get_localToWorldMatrix(v258.m_Transform);\n\tv984 = v983.m00;\n\tv774 = v354.m_EndOffset;\n\tv1025 = v354.m_EndOffset.y;\n\tv1023 = v354.m_EndOffset.z;\n\tv1013 = 0x10C2868(&v984 @ stack_-190_v10 (System.Single), 0, 0, v55, v56, v57, v58, v59, v354.m_EndOffset, v354.m_EndOffset.y, v354.m_EndOffset.z, v983.m00, v567, v565, v780.m_Position.z, v67);\nL_011D:\n\tv1040 = &v41 @ stack_-10_v2 - 0xB0;\n\t*([v40 @ X29_v1-B0]) = v774;\n\t*([v40 @ X29_v1-AC]) = v1025;\n\t*([v40 @ X29_v1-A8]) = v1023;\n\tv1041 = 0x158AD58(v1040, 0, 0, v55, v56, v57, v58, v59, v774, v1025, v1023, v569, v567, v565, v780.m_Position.z, v67);\n\tgoto L_0136;\n\tv1063 = *([v1051 @ X0_v25+E0]);\n\tv1064 = v1063 == 0;\n\tv1065 = ~v1064;\n\tif (v1065) goto L_0136;\n\tv1067 = \"il2cpp_codegen_runtime_class_init\"(v1051, v547, v250, v55, v56, v57, v58, v59, v1027, v1025, v1023, v569, v567, v565, v289, v67);\nL_0136:\n\tv581 = UnityEngine.Mathf::Lerp(1f, v354.m_Stiffness, this.m_Weight);\n\tv604 = v581 <= 0;\n\tif (v604) goto L_01A0;\n\tv1079 = UnityEngine.Transform::get_localToWorldMatrix(v258.m_Transform);\n\tv984 = v1079.m00;\n\tv874 = v965[v940 @ X20_v11 (System.Int32)] + 0x44;\n\tv1135 = v874 + -8;\n\tv877 = v874 + -4;\n\tgoto L_017B;\n\tv1169 = *([v1156 @ X0_v42+E0]);\n\tv1170 = v1169 == 0;\n\tv1171 = ~v1170;\n\tif (v1171) goto L_017B;\n\tv1173 = \"il2cpp_codegen_runtime_class_init\"(v1156, v1078, v250, v55, v56, v57, v58, v59, v1149, v1148, v1151, v1150, v567, v565, v289, v67);\nL_017B:\n\t// 379 MakeStruct v472 @ AGGA00AC0_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1135 @ X23_v10], [v877 @ X22_v9], v258.m_Position.z (System.Single)\n\tv582 = UnityEngine.Vector4::op_Implicit(v472);\n\tv1184 = 0x10C26E8(&v984 @ stack_-190_v10 (System.Single), 3, 0, v55, v56, v57, v58, v59, v582, v582.y, v582.z, v582.w, v567, v565, v780.m_Position.z, v67);\n\tgoto L_0194;\n\tv1198 = *([v1190 @ X0_v47+E0]);\n\tv1199 = v1198 == 0;\n\tv1200 = ~v1199;\n\tif (v1200) goto L_0194;\n\tv1202 = \"il2cpp_codegen_runtime_class_init\"(v1190, v1182, v1183, v55, v56, v57, v58, v59, v582, v578, v574, v570, v567, v565, v289, v67);\nL_0194:\n\tv1205 = UnityEngine.Object::op_Inequality(v354.m_Transform, 0);\n\tv1219 = v1205 == 0;\n\tif (v1219) goto L_01A4;\n\tv774 = UnityEngine.Transform::get_localPosition(v354.m_Transform);\n\tv1233 = v774.y;\n\tv1231 = v774.z;\n\tgoto L_01A9;\nL_01A0:\n\tv1135 = v965[v940 @ X20_v11 (System.Int32)] + 0x3C;\n\tv877 = v965[v940 @ X20_v11 (System.Int32)] + 0x40;\n\tv874 = v965[v940 @ X20_v11 (System.Int32)] + 0x44;\n\tgoto L_020E;\nL_01A4:\n\tv774 = v354.m_EndOffset;\n\tv1233 = v354.m_EndOffset.y;\n\tv1231 = v354.m_EndOffset.z;\nL_01A9:\n\tv1240 = 0x10C27FC(&v984 @ stack_-190_v10 (System.Single), 0, 0, v55, v56, v57, v58, v59, v774, v1233, v1231, v582.w, v567, v565, v780.m_Position.z, v67);\n\tgoto L_01C3;\n\tv1253 = *([v1246 @ X0_v54+E0]);\n\tv1254 = v1253 == 0;\n\tv1255 = ~v1254;\n\tgoto L_01C3;\n\tv1257 = \"il2cpp_codegen_runtime_class_init\"(v1246, v1239, v544, v55, v56, v57, v58, v59, v1235, v1233, v1231, v570, v567, v565, v289, v67);\nL_01C3:\n\t// 451 MakeStruct v1088 @ AGGA00B98_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v774 @ V0_v10 (UnityEngine.Vector3), v1233 @ V1_v24 (System.Single), v1231 @ V2_v24 (System.Single)\n\t// 452 MakeStruct v1087 @ AGGA00B98_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v881 @ X28_v7], [v880 @ X27_v7], v780.m_Position.z (System.Single)\n\tv774 = UnityEngine.Vector3::op_Subtraction(v1088, v1087);\n\tv1271 = 0x158AD58(&v774 @ V0_v10 (UnityEngine.Vector3), 0, 0, v55, v56, v57, v58, v59, v774, v774.y, v774.z, *([v881 @ X28_v7]), *([v880 @ X27_v7]), v780.m_Position.z, v780.m_Position.z, v67);\n\tv1273 = 1f - v581;\n\tv1274 = v774 * v1273;\n\tv1275 = v1274 + v1274;\n\tv1118 = v774 <= v1275;\n\tif (v1118) goto L_FFFFFFFF;\n\tv774 = *([v881 @ X28_v7]);\n\tgoto L_01F4;\n\tv1304 = *([v1288 @ X0_v60+E0]);\n\tv1305 = v1304 == 0;\n\tv1306 = ~v1305;\n\tif (v1306) goto L_01F4;\n\tv1308 = \"il2cpp_codegen_runtime_class_init\"(v1288, v1093, v544, v55, v56, v57, v58, v59, v1279, v1268, v1269, v1263, v1264, v1265, v289, v67);\nL_01F4:\n\tv1309 = *([v881 @ X28_v7]) - v1275;\n\tv1310 = v1309 / *([v881 @ X28_v7]);\n\tv774 = UnityEngine.Vector3::op_Multiply(v774, v1310);\n\t// 517 MakeStruct v1293 @ AGGA00C40_0_v9 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v774 @ V0_v10 (Uni\n// ... truncated")]
	private void SkipUpdateParticles()
	{
		//IL_00c5: Expected I4, but got I8
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_0474: Expected O, but got I
		//IL_0499: Expected F4, but got O
		//IL_04ad: Expected O, but got I
		//IL_0af8: Expected O, but got F4
		//IL_0b00: Expected O, but got F4
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01f6: Expected O, but got I
		//IL_020d: Expected O, but got I
		//IL_0239: Expected F4, but got O
		//IL_0246: Expected F4, but got O
		//IL_02c4: Expected O, but got F4
		//IL_0566: Expected O, but got I
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected O, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected O, but got Unknown
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_0729: Expected O, but got I4
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_060d: Expected O, but got I
		//IL_061d: Expected O, but got I
		//IL_090e: Expected F4, but got O
		//IL_091b: Expected F4, but got O
		//IL_0928: Expected F4, but got O
		//IL_0935: Expected F4, but got O
		//IL_0942: Expected F4, but got O
		//IL_0979: Expected O, but got I
		//IL_0630: Expected F4, but got O
		//IL_063d: Expected F4, but got O
		//IL_0a19: Expected F4, but got I
		//IL_0a2e: Expected F4, but got I
		//IL_0a43: Expected F4, but got I
		//IL_0a61: Expected F4, but got O
		//IL_0a6e: Expected F4, but got O
		//IL_07a5: Expected F4, but got O
		//IL_07b2: Expected F4, but got O
		//IL_0b2e: Expected O, but got I4
		//IL_08a3: Expected F4, but got O
		//IL_08e5: Expected O, but got F4
		object obj2 = default(object);
		object obj = obj2;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		List<Particle> particles = m_Particles;
		int num = 0;
		Vector3 vector = default(Vector3);
		Vector3 vector2 = default(Vector3);
		Vector3 vector3 = default(Vector3);
		Vector3 vector4 = default(Vector3);
		Vector3 vector5 = default(Vector3);
		Vector3 vector7 = default(Vector3);
		Vector3 vector8 = default(Vector3);
		Vector3 vector9 = default(Vector3);
		Vector3 vector11 = default(Vector3);
		Vector3 vector12 = default(Vector3);
		Vector3 vector13 = default(Vector3);
		Vector3 vector14 = default(Vector3);
		do
		{
			if (num >= particles.Count)
			{
				return;
			}
			bool flag = particles.Count < num;
			bool flag2 = !flag;
			int num2 = particles.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items = particles._items;
			Particle particle = items[num];
			Vector3 prevPosition;
			float y4;
			float z4;
			object obj4;
			object obj5;
			object obj3;
			if ((int)(particle.m_ParentIndex & 0x80000000L) == 0)
			{
				vector.x = particle.m_PrevPosition.x;
				vector.y = particle.m_PrevPosition.y;
				vector.z = particle.m_PrevPosition.z;
				vector2.x = m_ObjectMove.x;
				vector2.y = m_ObjectMove.y;
				vector2.z = m_ObjectMove.z;
				prevPosition = vector + vector2;
				Particle particle2 = items[num];
				obj3 = items[num] + 68;
				particle2.m_PrevPosition = prevPosition;
				particle2.m_PrevPosition.y = prevPosition.y;
				particle2.m_PrevPosition.z = prevPosition.z;
				obj4 = (long)(IntPtr)obj3 + -8L;
				prevPosition = (Vector3)obj4;
				obj5 = (long)(IntPtr)obj3 + -4L;
				float y = m_ObjectMove.y;
				float z = m_ObjectMove.z;
				vector3.x = (float)obj4;
				vector3.y = (float)obj5;
				vector3.z = particle2.m_Position.z;
				vector4.x = m_ObjectMove.x;
				vector4.y = m_ObjectMove.y;
				vector4.z = m_ObjectMove.z;
				prevPosition = vector3 + vector4;
				obj4 = prevPosition;
				obj5 = prevPosition.y;
				particle2.m_Position.z = prevPosition.z;
				List<Particle> particles2 = m_Particles;
				int parentIndex = particle2.m_ParentIndex;
				bool flag5 = particles2.Count < particle2.m_ParentIndex;
				bool flag6 = !flag5;
				int num3 = particles2.Count - particle2.m_ParentIndex;
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				Particle[] items2 = particles2._items;
				Particle particle3 = items2[parentIndex];
				if (particle.m_Transform != null)
				{
					prevPosition = particle3.m_Transform.position;
					prevPosition = particle.m_Transform.position;
					prevPosition -= prevPosition;
					float y2 = prevPosition.y;
					float z2 = prevPosition.z;
					z = prevPosition.z;
					y = prevPosition.y;
					float x = prevPosition.x;
				}
				else
				{
					Matrix4x4 localToWorldMatrix = particle3.m_Transform.localToWorldMatrix;
					float m = localToWorldMatrix.m00;
					prevPosition = particle.m_EndOffset;
					float y2 = particle.m_EndOffset.y;
					float z2 = particle.m_EndOffset.z;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
					float x = localToWorldMatrix.m00;
				}
				object obj6 = (long)(IntPtr)obj2 - 176L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				float num4 = Mathf.Lerp(1f, particle.m_Stiffness, m_Weight);
				object obj7;
				object obj8;
				object obj9;
				Vector3 vector10;
				if (num4 > 0f)
				{
					float m = particle3.m_Transform.localToWorldMatrix.m00;
					obj7 = items2[parentIndex] + 68;
					obj8 = (long)(IntPtr)obj7 + -8L;
					obj9 = (long)(IntPtr)obj7 + -4L;
					vector5.x = (float)obj8;
					vector5.y = (float)obj9;
					vector5.z = particle3.m_Position.z;
					Vector4 vector6 = vector5;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C26E8 (inside UnityEngine.Matrix4x4::op_Multiply +0x94)");
					float y3;
					float z3;
					if (particle.m_Transform != null)
					{
						prevPosition = particle.m_Transform.localPosition;
						y3 = prevPosition.y;
						z3 = prevPosition.z;
					}
					else
					{
						prevPosition = particle.m_EndOffset;
						y3 = particle.m_EndOffset.y;
						z3 = particle.m_EndOffset.z;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
					vector7.x = prevPosition.x;
					vector7.y = y3;
					vector7.z = z3;
					vector8.x = (float)obj4;
					vector8.y = (float)obj5;
					vector8.z = particle2.m_Position.z;
					prevPosition = vector7 - vector8;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
					float num5 = 1f - num4;
					float num6 = prevPosition.x * num5;
					float num7 = num6 + num6;
					if (prevPosition.x > num7)
					{
						prevPosition = (Vector3)obj4;
						float num8 = (float)obj4 - num7;
						float num9 = num8 / (float)obj4;
						prevPosition *= num9;
						vector9.x = prevPosition.x;
						vector9.y = (float)obj5;
						vector9.z = particle2.m_Position.z;
						prevPosition = vector9 + prevPosition;
						obj4 = prevPosition;
						obj5 = prevPosition.y;
						particle2.m_Position.z = prevPosition.z;
					}
					object obj10 = 0;
					vector10 = prevPosition;
				}
				else
				{
					obj8 = items2[parentIndex] + 60;
					obj9 = items2[parentIndex] + 64;
					obj7 = items2[parentIndex] + 68;
					object obj10 = 0;
					vector10 = prevPosition;
				}
				vector11.x = (float)obj8;
				vector11.y = (float)obj9;
				vector11.z = (float)obj7;
				vector12.x = (float)obj4;
				vector12.y = (float)obj5;
				vector12.z = particle2.m_Position.z;
				prevPosition = vector11 - vector12;
				object obj11 = (long)(IntPtr)obj2 - 160L;
				_ = prevPosition.y;
				_ = prevPosition.z;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				if (!(prevPosition.x > 0f))
				{
					goto IL_0b3b;
				}
				float num10 = prevPosition.x - vector10.x;
				float num11 = num10 / prevPosition.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A0]");
				vector13.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-9C]");
				vector13.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-98]");
				vector13.z = 0f;
				prevPosition = vector13 * num11;
				vector14.x = (float)obj4;
				vector14.y = (float)obj5;
				vector14.z = particle2.m_Position.z;
				prevPosition = vector14 + prevPosition;
				y4 = prevPosition.y;
				z4 = prevPosition.z;
			}
			else
			{
				object obj12 = items[num] + 60;
				obj3 = (long)(IntPtr)obj12 + 8L;
				particle.m_PrevPosition = particle.m_Position;
				particle.m_PrevPosition.z = (float)obj3;
				obj5 = (long)(IntPtr)obj12 + 4L;
				prevPosition = particle.m_Transform.position;
				y4 = prevPosition.y;
				z4 = prevPosition.z;
				obj4 = obj12;
			}
			obj4 = prevPosition;
			obj5 = y4;
			obj3 = z4;
			goto IL_0b3b;
			IL_0b3b:
			particles = m_Particles;
			num++;
		}
		while (m_Particles != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000019")]
	[Address(RVA = "0xA01AFC", Offset = "0xA01AFC", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1EF9258]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, v41, v42, v43, v44, v45, v46, v47, v, v0, v2, axis, v3, v5, v48, v49);\n\tv53 = 0 | 1;\n\t*([2021C61]) = v53;\nL_0027:\n\tgoto L_0036;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0036;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, v41, v42, v43, v44, v45, v46, v47, v, v0, v2, axis, v3, v5, v48, v49);\nL_0036:\n\tv76 = UnityEngine.Vector3::Dot(v, axis);\n\tv77 = v76 + v76;\n\tv83 = UnityEngine.Vector3::op_Multiply(axis, v77);\n\treturnVal1 = UnityEngine.Vector3::op_Subtraction(v, v83);\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static Vector3 MirrorVector(Vector3 v, Vector3 axis)
	{
		float num = Vector3.Dot(v, axis);
		float num2 = num + num;
		Vector3 vector = axis * num2;
		return v - vector;
	}

	[Token(Token = "0x600001A")]
	[Address(RVA = "0xA00D84", Offset = "0xA00D84", Length = "0x2E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv46 = *([1ECE030]);\n\tv47 = *([v46 @ X8_v27]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([2021C62]) = v66;\nL_0021:\n\tv274 = this.m_Particles;\nL_0035:\n\tv303 = v252 >= v274._size;\n\tif (v303) goto L_0131;\n\tv382 = v274._size < v252;\n\tv247 = ~v382;\n\tv242 = v274._size - v252;\n\tv232 = v242 == 0;\n\tv384 = ~v232;\n\tv204 = v247 & v384;\n\tif (v204) goto L_0047;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv209 = this.m_Particles;\nL_0047:\n\tv454 = v274._items;\n\tv85 = v454[v252 @ X21_v6 (System.Int32)];\n\tv275 = v85.m_ParentIndex;\n\tv456 = v209._size < v85.m_ParentIndex;\n\tv248 = ~v456;\n\tv243 = v209._size - v85.m_ParentIndex;\n\tv233 = v243 == 0;\n\tv457 = ~v233;\n\tv205 = v248 & v457;\n\tif (v205) goto L_005F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005F:\n\tv459 = v209._items;\n\tv208 = v459[v275 @ X20_v8 (System.Int32)];\n\tv461 = UnityEngine.Transform::get_childCount(v208.m_Transform);\n\tv203 = v461 > 1;\n\tif (v203) goto L_0101;\n\tgoto L_0085;\n\tv491 = *([v464 @ X0_v20+E0]);\n\tv492 = v491 == 0;\n\tv493 = ~v492;\n\tif (v493) goto L_0085;\n\tv495 = \"il2cpp_codegen_runtime_class_init\"(v464, v460, v188, v51, v52, v53, v54, v55, v184, v180, v176, v159, v155, v151, v107, v104);\nL_0085:\n\tv498 = UnityEngine.Object::op_Inequality(v85.m_Transform, 0);\n\tv508 = v498 == 0;\n\tif (v508) goto L_0096;\n\tv523 = UnityEngine.Transform::get_localPosition(v85.m_Transform);\n\tgoto L_00A2;\nL_0096:\n\tv333 = v85.m_EndOffset.y;\n\tv331 = v85.m_EndOffset.z;\nL_00A2:\n\tgoto L_00AF;\n\tv541 = *([v534 @ X0_v25+E0]);\n\tv542 = v541 == 0;\n\tv543 = ~v542;\n\tgoto L_00AF;\n\tv545 = \"il2cpp_codegen_runtime_class_init\"(v534, v348, v189, v51, v52, v53, v54, v55, v531, v529, v527, v159, v155, v151, v107, v104);\nL_00AF:\n\t// 175 MakeStruct v147 @ AGGA00F14_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v85.m_Position (UnityEngine.Vector3), v85.m_Position.y (System.Single), v85.m_Position.z (System.Single)\n\t// 176 MakeStruct v142 @ AGGA00F14_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v208.m_Position (UnityEngine.Vector3), v208.m_Position.y (System.Single), v208.m_Position.z (System.Single)\n\tv342 = UnityEngine.Vector3::op_Subtraction(v147, v142);\n\t// 190 MakeStruct v125 @ AGGA00F3C_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v172 @ stack_-94_v6 (UnityEngine.Vector3), v333 @ V9_v7 (System.Single), v331 @ V10_v7 (System.Single)\n\tv554 = UnityEngine.Transform::TransformDirection(v208.m_Transform, v125);\n\tgoto L_00D8;\n\tv564 = *([v557 @ X0_v29+E0]);\n\tv565 = v564 == 0;\n\tv566 = ~v565;\n\tif (v566) goto L_00D8;\n\tv568 = \"il2cpp_codegen_runtime_class_init\"(v557, v197, v189, v51, v52, v53, v54, v55, v554, v555, v556, v329, v327, v325, v107, v104);\nL_00D8:\n\tv185 = UnityEngine.Quaternion::FromToRotation(v554, v342);\n\tv576 = UnityEngine.Transform::get_rotation(v208.m_Transform);\n\tv478 = UnityEngine.Quaternion::op_Multiply(v185, v576);\n\tUnityEngine.Transform::set_rotation(v208.m_Transform, v478);\nL_0101:\n\tgoto L_010A;\n\tv499 = *([v487 @ X0_v13+E0]);\n\tv500 = v499 == 0;\n\tv501 = ~v500;\n\tif (v501) goto L_010A;\n\tv503 = \"il2cpp_codegen_runtime_class_init\"(v487, v480, v479, v51, v52, v53, v54, v55, v343, v340, v337, v158, v154, v150, v106, v103);\nL_010A:\n\tv506 = UnityEngine.Object::op_Inequality(v85.m_Transform, 0);\n\tv510 = v506 == 0;\n\tif (v510) goto L_0117;\n\t// 277 MakeStruct v515 @ AGGA01020_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v85.m_Position (UnityEngine.Vector3), v85.m_Position.y (System.Single), v85.m_Position.z (System.Single)\n\tUnityEngine.Transform::set_position(v85.m_Transform, v515);\nL_0117:\n\tv274 = this.m_Particles;\n\tv252 = v252 + 1;\n\tv521 = this.m_Particles == 0;\n\tv262 = ~v521;\n\tif (v262) goto L_0035;\n\tthrow System.NullReferenceException;\nL_0131:\n\treturn;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void ApplyParticlesToTransforms()
	{
		List<Particle> particles = m_Particles;
		int num = 1;
		Vector3 vector2 = default(Vector3);
		Vector3 vector3 = default(Vector3);
		Vector3 direction = default(Vector3);
		Vector3 position = default(Vector3);
		do
		{
			if (num >= particles.Count)
			{
				return;
			}
			bool flag = particles.Count < num;
			bool flag2 = !flag;
			int num2 = particles.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			List<Particle> list = particles;
			if (!flag5)
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items = particles._items;
			Particle particle = items[num];
			int parentIndex = particle.m_ParentIndex;
			bool flag6 = list.Count < particle.m_ParentIndex;
			bool flag7 = !flag6;
			int num3 = list.Count - particle.m_ParentIndex;
			bool flag8 = num3 == 0;
			bool flag9 = !flag8;
			if (!(flag7 && flag9))
			{
				throw new ArgumentOutOfRangeException();
			}
			Particle[] items2 = list._items;
			Particle particle2 = items2[parentIndex];
			int childCount = particle2.m_Transform.childCount;
			if (childCount <= 1)
			{
				float z;
				float y;
				Vector3 vector;
				if (particle.m_Transform != null)
				{
					Vector3 localPosition = particle.m_Transform.localPosition;
					z = localPosition.z;
					y = localPosition.y;
					vector = localPosition;
				}
				else
				{
					y = particle.m_EndOffset.y;
					z = particle.m_EndOffset.z;
					vector = particle.m_EndOffset;
				}
				vector2.x = particle.m_Position.x;
				vector2.y = particle.m_Position.y;
				vector2.z = particle.m_Position.z;
				vector3.x = particle2.m_Position.x;
				vector3.y = particle2.m_Position.y;
				vector3.z = particle2.m_Position.z;
				Vector3 toDirection = vector2 - vector3;
				direction.x = vector.x;
				direction.y = y;
				direction.z = z;
				Vector3 fromDirection = particle2.m_Transform.TransformDirection(direction);
				Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
				Quaternion rotation = particle2.m_Transform.rotation;
				Quaternion rotation2 = quaternion * rotation;
				particle2.m_Transform.rotation = rotation2;
			}
			if (particle.m_Transform != null)
			{
				position.x = particle.m_Position.x;
				position.y = particle.m_Position.y;
				position.z = particle.m_Position.z;
				particle.m_Transform.position = position;
			}
			particles = m_Particles;
			num++;
		}
		while (m_Particles != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x600001B")]
	[Address(RVA = "0xA01BDC", Offset = "0xA01BDC", Length = "0x120")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECBFB0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C63]) = v38;\nL_0016:\n\tthis.m_UpdateRate = 60f;\n\tthis.m_Damping = 0.1f;\n\tthis.m_Elasticity = 0.1f;\n\tthis.m_Stiffness = 0.1f;\n\tgoto L_0027;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0027;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv56 = UnityEngine.Vector3::get_zero();\n\tthis.m_EndOffset = v56;\n\tthis.m_EndOffset.y = v56.y;\n\tthis.m_EndOffset.z = v56.z;\n\tv60 = UnityEngine.Vector3::get_zero();\n\tthis.m_Gravity = v60;\n\tthis.m_Gravity.y = v60.y;\n\tthis.m_Gravity.z = v60.z;\n\tv64 = UnityEngine.Vector3::get_zero();\n\tthis.m_Force = v64;\n\tthis.m_Force.y = v64.y;\n\tthis.m_Force.z = v64.z;\n\tthis.m_DistanceToObject = 20f;\n\tv69 = UnityEngine.Vector3::get_zero();\n\tthis.m_LocalGravity = v69;\n\tthis.m_LocalGravity.y = v69.y;\n\tthis.m_LocalGravity.z = v69.z;\n\tv73 = UnityEngine.Vector3::get_zero();\n\tthis.m_ObjectMove = v73;\n\tthis.m_ObjectMove.y = v73.y;\n\tthis.m_ObjectMove.z = v73.z;\n\tv77 = UnityEngine.Vector3::get_zero();\n\tthis.m_ObjectPrevPosition = v77;\n\tthis.m_ObjectPrevPosition.y = v77.y;\n\tthis.m_ObjectPrevPosition.z = v77.z;\n\tthis.m_ObjectScale = 1f;\n\tthis.m_Weight = 1f;\n\tv84 = new System.Collections.Generic.List`1<DynamicBone+Particle>();\n\tSystem.Collections.Generic.List`1<DynamicBone+Particle>::.ctor(v84);\n\tthis.m_Particles = v84;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DynamicBone()
	{
		m_UpdateRate = 60f;
		m_Damping = 0.1f;
		m_Elasticity = 0.1f;
		m_Stiffness = 0.1f;
		Vector3 vector = (m_EndOffset = Vector3.zero);
		m_EndOffset.y = vector.y;
		m_EndOffset.z = vector.z;
		Vector3 vector2 = (m_Gravity = Vector3.zero);
		m_Gravity.y = vector2.y;
		m_Gravity.z = vector2.z;
		Vector3 vector3 = (m_Force = Vector3.zero);
		m_Force.y = vector3.y;
		m_Force.z = vector3.z;
		m_DistanceToObject = 20f;
		Vector3 vector4 = (m_LocalGravity = Vector3.zero);
		m_LocalGravity.y = vector4.y;
		m_LocalGravity.z = vector4.z;
		Vector3 vector5 = (m_ObjectMove = Vector3.zero);
		m_ObjectMove.y = vector5.y;
		m_ObjectMove.z = vector5.z;
		Vector3 vector6 = (m_ObjectPrevPosition = Vector3.zero);
		m_ObjectPrevPosition.y = vector6.y;
		m_ObjectPrevPosition.z = vector6.z;
		m_ObjectScale = 1f;
		m_Weight = 1f;
		List<Particle> particles = new List<Particle>();
		m_Particles = particles;
	}
}
