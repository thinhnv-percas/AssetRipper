using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Attribute(Type = typeof(RequireComponent), RVA = "0x74CCE8", Offset = "0x74CCE8")]
	[Token(Token = "0x2000051")]
	public class SampleCharacterController : MonoBehaviour
	{
		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x18")]
		private ObiCharacter m_Character;

		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_Cam;

		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x28")]
		private Vector3 m_CamForward;

		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x34")]
		private Vector3 m_Move;

		[Token(Token = "0x4000258")]
		[FieldOffset(Offset = "0x40")]
		private bool m_Jump;

		[Token(Token = "0x600024A")]
		[Address(RVA = "0x98E68C", Offset = "0x98E68C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED0198]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021700]) = v38;\nL_0014:\n\tv40 = UnityEngine.Camera::get_main();\n\tgoto L_0026;\n\tv48 = *([v44 @ X8_v5+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv59 = v44;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv58 = UnityEngine.Object::op_Inequality(v40, 0);\n\tv61 = v58 == 0;\n\tif (v61) goto L_0038;\n\tv63 = UnityEngine.Camera::get_main();\n\tv83 = UnityEngine.Component::get_transform(v63);\n\tthis.m_Cam = v83;\n\tgoto L_0047;\nL_0038:\n\tgoto L_0042;\n\tv71 = *([v66 @ X0_v10+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0042;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v66, v56, v57, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0042:\n\tUnityEngine.Debug::LogWarning(\"Warning: no main camera found. Third person character needs a Camera tagged \\\"MainCamera\\\", for camera-relative controls.\");\nL_0047:\n\tv93 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Character = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Camera main = Camera.main;
			if (main != null)
			{
				Camera main2 = Camera.main;
				Transform cam = main2.transform;
				m_Cam = cam;
			}
			else
			{
				Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			}
			ObiCharacter component = GetComponent<ObiCharacter>();
			m_Character = component;
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x98E77C", Offset = "0x98E77C", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EBCCD8]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021701]) = v50;\nL_001C:\n\tv54 = ~this.m_Jump;\n\tv55 = ~v54;\n\tif (v55) goto L_002A;\n\tv60 = UnityEngine.Input::GetButtonDown(\"Jump\");\n\tthis.m_Jump = v60;\nL_002A:\n\tv69 = UnityEngine.Input::GetAxis(\"Horizontal\");\n\tv69 = UnityEngine.Input::GetAxis(\"Vertical\");\n\tv79 = UnityEngine.Input::GetKey(0x63);\n\tgoto L_0047;\n\tv88 = *([v84 @ X8_v11+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0047;\n\tv99 = v84;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v99, v77, v34, v35, v36, v37, v38, v39, v75, v41, v42, v43, v44, v45, v46, v47);\nL_0047:\n\tv98 = UnityEngine.Object::op_Inequality(this.m_Cam, 0);\n\tv101 = v98 == 0;\n\tif (v101) goto L_009B;\n\tv111 = UnityEngine.Transform::get_forward(this.m_Cam);\n\tv157 = 0;\n\tv215 = 0x1586898(&v157 @ stack_-70_v3, 0, 0, v35, v36, v37, v38, v39, 1f, 0, 1f, v43, v44, v45, v46, v47);\n\tgoto L_0071;\n\tv289 = *([v230 @ X0_v25+E0]);\n\tv290 = v289 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_0071;\n\tv293 = \"il2cpp_codegen_runtime_class_init\"(v230, v214, v97, v35, v36, v37, v38, v39, v209, v212, v213, v43, v44, v45, v46, v47);\nL_0071:\n\t// 113 MakeStruct v140 @ AGG98E8E0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v297 @ stack_-6C, 0\n\tv303 = UnityEngine.Vector3::Scale(v111, v140);\n\tv309 = 0x158A710(&v303 @ V0_v16 (UnityEngine.Vector3), 0, 0, v35, v36, v37, v38, v39, v303, v303.y, v303.z, 0, v297, 0, v46, v47);\n\tthis.m_CamForward = v303;\n\tthis.m_CamForward.y = v303.y;\n\tthis.m_CamForward.z = v303.z;\n\tv182 = UnityEngine.Vector3::op_Multiply(v69, v303);\n\tv317 = UnityEngine.Transform::get_right(this.m_Cam);\n\tv315 = v317.y;\n\tv313 = v317.z;\n\tgoto L_00C0;\nL_009B:\n\tgoto L_00A2;\n\tv197 = *([v106 @ X0_v16+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_00A2;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v106, v96, v97, v35, v36, v37, v38, v39, v75, v41, v42, v43, v44, v45, v46, v47);\nL_00A2:\n\tv205 = UnityEngine.Vector3::get_forward();\n\tv227 = UnityEngine.Vector3::op_Multiply(v69, v205);\n\tv317 = UnityEngine.Vector3::get_right();\n\tv315 = v317.y;\n\tv313 = v317.z;\nL_00C0:\n\t// 192 MakeStruct v114 @ AGG98E9C4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v317 @ V0_v3 (UnityEngine.Vector3), v315 @ V1_v1 (System.Single), v313 @ V2_v1 (System.Single)\n\tv330 = UnityEngine.Vector3::op_Multiply(v69, v114);\n\t// 203 MakeStruct v120 @ AGG98E9E4_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v180 @ V9_v2 (UnityEngine.Vector3), v171 @ V10_v1 (System.Single), v168 @ V11_v1 (System.Single)\n\tv183 = UnityEngine.Vector3::op_Addition(v120, v330);\n\tthis.m_Move = v183;\n\tthis.m_Move.y = v183.y;\n\tthis.m_Move.z = v183.z;\n\tObi.ObiCharacter::Move(this.m_Character, v183, v79, this.m_Jump);\n\tthis.m_Jump = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			//IL_006c: Expected O, but got I4
			//IL_00a0: Expected F4, but got O
			if (!m_Jump)
			{
				bool buttonDown = Input.GetButtonDown("Jump");
				m_Jump = buttonDown;
			}
			float axis = Input.GetAxis("Horizontal");
			axis = Input.GetAxis("Vertical");
			bool key = Input.GetKey(KeyCode.C);
			Vector3 right;
			float y;
			float z;
			float z2;
			float y2;
			Vector3 vector3;
			if (m_Cam != null)
			{
				Vector3 forward = m_Cam.forward;
				object obj = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 b = default(Vector3);
				b.x = 0f;
				object obj2 = default(object);
				b.y = (float)obj2;
				b.z = 0f;
				Vector3 vector = Vector3.Scale(forward, b);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
				m_CamForward = vector;
				m_CamForward.y = vector.y;
				m_CamForward.z = vector.z;
				Vector3 vector2 = axis * vector;
				right = m_Cam.right;
				y = right.y;
				z = right.z;
				z2 = vector2.z;
				y2 = vector2.y;
				vector3 = vector2;
			}
			else
			{
				Vector3 forward2 = Vector3.forward;
				Vector3 vector4 = axis * forward2;
				right = Vector3.right;
				y = right.y;
				z = right.z;
				z2 = vector4.z;
				y2 = vector4.y;
				vector3 = vector4;
			}
			Vector3 vector5 = default(Vector3);
			vector5.x = right.x;
			vector5.y = y;
			vector5.z = z;
			Vector3 vector6 = axis * vector5;
			Vector3 vector7 = default(Vector3);
			vector7.x = vector3.x;
			vector7.y = y2;
			vector7.z = z2;
			Vector3 move = (m_Move = vector7 + vector6);
			m_Move.y = move.y;
			m_Move.z = move.z;
			m_Character.Move(move, key, m_Jump);
			m_Jump = false;
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x98EA2C", Offset = "0x98EA2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SampleCharacterController()
		{
		}
	}
}
