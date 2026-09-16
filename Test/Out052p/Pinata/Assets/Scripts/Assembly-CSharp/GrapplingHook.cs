using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Token(Token = "0x2000027")]
public class GrapplingHook : MonoBehaviour
{
	[Token(Token = "0x40000F0")]
	[FieldOffset(Offset = "0x18")]
	public ObiSolver solver;

	[Token(Token = "0x40000F1")]
	[FieldOffset(Offset = "0x20")]
	public ObiCollider character;

	[Token(Token = "0x40000F2")]
	[FieldOffset(Offset = "0x28")]
	public float hookExtendRetractSpeed;

	[Token(Token = "0x40000F3")]
	[FieldOffset(Offset = "0x30")]
	public Material material;

	[Token(Token = "0x40000F4")]
	[FieldOffset(Offset = "0x38")]
	public ObiRopeSection section;

	[Token(Token = "0x40000F5")]
	[FieldOffset(Offset = "0x40")]
	private ObiRope rope;

	[Token(Token = "0x40000F6")]
	[FieldOffset(Offset = "0x48")]
	private ObiRopeBlueprint blueprint;

	[Token(Token = "0x40000F7")]
	[FieldOffset(Offset = "0x50")]
	private ObiRopeExtrudedRenderer ropeRenderer;

	[Token(Token = "0x40000F8")]
	[FieldOffset(Offset = "0x58")]
	private ObiRopeCursor cursor;

	[Token(Token = "0x40000F9")]
	[FieldOffset(Offset = "0x60")]
	private RaycastHit hookAttachment;

	[Token(Token = "0x60000D2")]
	[Address(RVA = "0xA0B698", Offset = "0xA0B698", Length = "0x194")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF7AF8]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC4]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tv46 = UnityEngine.GameObject::AddComponent(v41);\n\tthis.rope = v46;\n\tv70 = UnityEngine.Component::get_gameObject(this);\n\tv71 = UnityEngine.GameObject::AddComponent(v70);\n\tthis.ropeRenderer = v71;\n\tv71.section = this.section;\n\tv98 = this.ropeRenderer;\n\tv54 = 0;\n\tv111 = 0x1588A6C(&v54 @ stack_-28_v3 (UnityEngine.Vector2), 0, v22, v23, v24, v25, v26, v27, 1f, 5f, v30, v31, v32, v33, v34, v35);\n\tv98.uvScale = 0;\n\tv98.uvScale.y = v145;\n\tv119 = this.ropeRenderer;\n\tv119.normalizeV = 0;\n\tv91 = this.ropeRenderer;\n\tv91.uvAnchor = 1f;\n\tv73 = UnityEngine.Component::GetComponent(this.rope);\n\tUnityEngine.Renderer::set_material(v73, this.material);\n\tv74 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.blueprint = v74;\n\tv74.resolution = 0.5f;\n\tObi.ObiRope::set_maxBending(this.rope, 0.02f);\n\tv77 = UnityEngine.Component::get_gameObject(this.rope);\n\tv78 = UnityEngine.GameObject::AddComponent(v77);\n\tthis.cursor = v78;\n\tObi.ObiRopeCursor::set_cursorMu(v78, 0f);\n\tv120 = this.cursor;\n\tv120.direction = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		ObiRope obiRope = gameObject.AddComponent<ObiRope>();
		rope = obiRope;
		GameObject gameObject2 = base.gameObject;
		(ropeRenderer = gameObject2.AddComponent<ObiRopeExtrudedRenderer>()).section = section;
		ObiRopeExtrudedRenderer obiRopeExtrudedRenderer = ropeRenderer;
		Vector2 vector = default(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
		obiRopeExtrudedRenderer.uvScale = default(Vector2);
		float y = default(float);
		obiRopeExtrudedRenderer.uvScale.y = y;
		ObiRopeExtrudedRenderer obiRopeExtrudedRenderer2 = ropeRenderer;
		obiRopeExtrudedRenderer2.normalizeV = false;
		ObiRopeExtrudedRenderer obiRopeExtrudedRenderer3 = ropeRenderer;
		obiRopeExtrudedRenderer3.uvAnchor = 1f;
		MeshRenderer component = rope.GetComponent<MeshRenderer>();
		component.material = material;
		(blueprint = ScriptableObject.CreateInstance<ObiRopeBlueprint>()).resolution = 0.5f;
		rope.maxBending = 0.02f;
		GameObject gameObject3 = rope.gameObject;
		(cursor = gameObject3.AddComponent<ObiRopeCursor>()).cursorMu = 0f;
		ObiRopeCursor obiRopeCursor = cursor;
		obiRopeCursor.direction = true;
	}

	[Token(Token = "0x60000D3")]
	[Address(RVA = "0xA0B82C", Offset = "0xA0B82C", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB9530]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC5]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Object::DestroyImmediate(this.blueprint);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDestroy()
	{
		UnityEngine.Object.DestroyImmediate(blueprint);
	}

	[Token(Token = "0x60000D4")]
	[Address(RVA = "0xA0B898", Offset = "0xA0B898", Length = "0x1E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1F07778]);\n\tv35 = *([v34 @ X8_v11]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021CC6]) = v54;\nL_001C:\n\tv56 = UnityEngine.Input::get_mousePosition();\n\tv63 = UnityEngine.Component::get_transform(this);\n\tv66 = UnityEngine.Transform::get_position(v63);\n\tv108 = UnityEngine.Camera::get_main();\n\tv109 = UnityEngine.Component::get_transform(v108);\n\tv84 = UnityEngine.Transform::get_position(v109);\n\tv110 = UnityEngine.Camera::get_main();\n\tv191 = v66.z - v84.z;\n\t// 64 MakeStruct v76 @ AGGA0B94C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v56 @ V0_v1 (UnityEngine.Vector3), v56.y (System.Single), v191 @ V2_v5 (System.Single)\n\tv85 = UnityEngine.Camera::ScreenToWorldPoint(v110, v76);\n\tv111 = UnityEngine.Component::get_transform(this);\n\tv86 = UnityEngine.Transform::get_position(v111);\n\tv112 = UnityEngine.Component::get_transform(this);\n\tv199 = UnityEngine.Transform::get_position(v112);\n\tgoto L_0076;\n\tv211 = *([v207 @ X0_v16+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_0076;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v207, v198, v38, v39, v40, v41, v42, v43, v199, v200, v201, v47, v48, v49, v50, v51);\nL_0076:\n\tv225 = UnityEngine.Vector3::op_Subtraction(v85, v199);\n\tv132 = 0;\n\tv231 = 0x10CCD20(&v132 @ stack_-78_v1, 0, v38, v39, v40, v41, v42, v43, v86, v86.y, v86.z, v225, v225.y, v225.z, v50, v51);\n\tv232 = this + 0x60;\n\tv124 = 0;\n\tv235 = UnityEngine.Physics::Raycast(&v124 @ stack_-90_v1, v232);\n\tv181 = v235 == 0;\n\tif (v181) goto L_00A3;\n\tv238 = GrapplingHook::AttachHook(this);\n\tv241 = UnityEngine.MonoBehaviour::StartCoroutine(this, v238);\nL_00A3:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void LaunchHook()
	{
		//IL_00ff: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0130: Expected O, but got Ref
		Vector3 mousePosition = Input.mousePosition;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Camera main = Camera.main;
		Transform transform2 = main.transform;
		Vector3 position2 = transform2.position;
		Camera main2 = Camera.main;
		float z = position.z - position2.z;
		Vector3 position3 = default(Vector3);
		position3.x = mousePosition.x;
		position3.y = mousePosition.y;
		position3.z = z;
		Vector3 vector = main2.ScreenToWorldPoint(position3);
		Transform transform3 = base.transform;
		Vector3 position4 = transform3.position;
		Transform transform4 = base.transform;
		Vector3 position5 = transform4.position;
		Vector3 vector2 = vector - position5;
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCD20 (inside UnityEngine.RangeAttribute::.ctor +0x4C)");
		ref RaycastHit hitInfo = ref *(RaycastHit*)((long)(IntPtr)this + 96L);
		object obj2 = 0;
		if (Physics.Raycast((Ray)(&obj2), out hitInfo))
		{
			IEnumerator routine = AttachHook();
			Coroutine coroutine = StartCoroutine(routine);
		}
	}

	[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7DB48C", Offset = "0x7DB48C")]
	[Token(Token = "0x60000D5")]
	[Address(RVA = "0xA0BA78", Offset = "0xA0BA78", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEC060]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC7]) = v38;\nL_0016:\n\tv42 = new GrapplingHook+<AttachHook>d__13();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IEnumerator AttachHook()
	{
		_003CAttachHook_003Ed__13 _003CAttachHook_003Ed__14 = null;
		_003CAttachHook_003Ed__14._003C_003E1__state = 0;
		_003CAttachHook_003Ed__14._003C_003E4__this = this;
		return _003CAttachHook_003Ed__14;
	}

	[Token(Token = "0x60000D6")]
	[Address(RVA = "0xA0BB18", Offset = "0xA0BB18", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFAC18]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC8]) = v38;\nL_0018:\n\tObi.ObiRope::set_ropeBlueprint(this.rope, 0);\n\tv48 = UnityEngine.Component::GetComponent(this.rope);\n\tUnityEngine.Renderer::set_enabled(v48, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void DetachHook()
	{
		rope.ropeBlueprint = null;
		MeshRenderer component = rope.GetComponent<MeshRenderer>();
		component.enabled = false;
	}

	[Token(Token = "0x60000D7")]
	[Address(RVA = "0xA0BB94", Offset = "0xA0BB94", Length = "0x104")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv20 = v18 == 0;\n\tif (v20) goto L_001A;\n\tv21 = this.rope;\n\tv27 = ~v21.m_Loaded;\n\tif (v27) goto L_0019;\n\tGrapplingHook::DetachHook(this);\n\tgoto L_001A;\nL_0019:\n\tGrapplingHook::LaunchHook(this);\nL_001A:\n\tv31 = this.rope;\n\tv82 = ~v31.m_Loaded;\n\tif (v82) goto L_0059;\n\tv62 = UnityEngine.Input::GetKey(0x77);\n\tv121 = v62 == 0;\n\tif (v121) goto L_0037;\n\tv51 = this.rope;\n\tv35 = UnityEngine.Time::get_deltaTime();\n\tv130 = this.hookExtendRetractSpeed * v35;\n\tv122 = v51.restLength_ - v130;\n\tObi.ObiRopeCursor::ChangeLength(this.cursor, v122);\nL_0037:\n\tv64 = UnityEngine.Input::GetKey(0x73);\n\tv91 = v64 == 0;\n\tif (v91) goto L_0059;\n\tv52 = this.rope;\n\tv37 = UnityEngine.Time::get_deltaTime();\n\tv131 = this.hookExtendRetractSpeed * v37;\n\tv103 = v52.restLength_ + v131;\n\tObi.ObiRopeCursor::ChangeLength(this.cursor, v103);\n\treturn;\nL_0059:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ObiRope obiRope = rope;
			if (obiRope.isLoaded)
			{
				DetachHook();
			}
			else
			{
				LaunchHook();
			}
		}
		ObiRope obiRope2 = rope;
		if (obiRope2.isLoaded)
		{
			if (Input.GetKey(KeyCode.W))
			{
				ObiRope obiRope3 = rope;
				float deltaTime = Time.deltaTime;
				float num = hookExtendRetractSpeed * deltaTime;
				float newLength = obiRope3.restLength - num;
				cursor.ChangeLength(newLength);
			}
			if (Input.GetKey(KeyCode.S))
			{
				ObiRope obiRope4 = rope;
				float deltaTime2 = Time.deltaTime;
				float num2 = hookExtendRetractSpeed * deltaTime2;
				float newLength2 = obiRope4.restLength + num2;
				cursor.ChangeLength(newLength2);
			}
		}
	}

	[Token(Token = "0x60000D8")]
	[Address(RVA = "0xA0BC98", Offset = "0xA0BC98", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hookExtendRetractSpeed = 2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GrapplingHook()
	{
		hookExtendRetractSpeed = 2f;
	}
}
