using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000002")]
public class DynamicBoneDemo1 : MonoBehaviour
{
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x18")]
	public GameObject m_Player;

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x20")]
	private float m_weight;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0xA02DBC", Offset = "0xA02DBC", Length = "0x1B0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F027A8]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C6D]) = v46;\nL_001B:\n\tv50 = UnityEngine.GameObject::get_transform(this.m_Player);\n\tv88 = UnityEngine.Input::GetAxis(\"Horizontal\");\n\tv135 = UnityEngine.Time::get_deltaTime();\n\tv137 = v88 * v135;\n\tv113 = v137 * 200f;\n\tv55 = 0;\n\tv124 = 0x1586898(&v55 @ stack_-50_v3, 0, v30, v31, v32, v33, v34, v35, 0, v113, 0, v39, v40, v41, v42, v43);\n\t// 56 MakeStruct v52 @ AGGA02E74_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v174 @ stack_-4C, 0\n\tUnityEngine.Transform::Rotate(v50, v52);\n\tv177 = UnityEngine.GameObject::get_transform(this.m_Player);\n\tv73 = UnityEngine.Component::get_transform(this);\n\tv180 = UnityEngine.Transform::get_forward(v73);\n\tv189 = UnityEngine.Input::GetAxis(\"Vertical\");\n\tgoto L_0064;\n\tv196 = *([v192 @ X0_v19+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tif (v198) goto L_0064;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v192, v122, v30, v31, v32, v33, v34, v35, v189, v181, v182, v39, v40, v41, v42, v43);\nL_0064:\n\tv207 = UnityEngine.Vector3::op_Multiply(v180, v189);\n\tv211 = UnityEngine.Time::get_deltaTime();\n\tv217 = UnityEngine.Vector3::op_Multiply(v207, v211);\n\tv119 = UnityEngine.Vector3::op_Multiply(v217, 4f);\n\tUnityEngine.Transform::Translate(v177, v119);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		//IL_0058: Expected O, but got I4
		//IL_0082: Expected F4, but got O
		Transform transform = m_Player.transform;
		float axis = Input.GetAxis("Horizontal");
		float deltaTime = Time.deltaTime;
		float num = axis * deltaTime;
		float num2 = num * 200f;
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
		Vector3 eulers = default(Vector3);
		eulers.x = 0f;
		object obj2 = default(object);
		eulers.y = (float)obj2;
		eulers.z = 0f;
		transform.Rotate(eulers);
		Transform transform2 = m_Player.transform;
		Transform transform3 = base.transform;
		Vector3 forward = transform3.forward;
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = forward * axis2;
		float deltaTime2 = Time.deltaTime;
		Vector3 vector2 = vector * deltaTime2;
		Vector3 translation = vector2 * 4f;
		transform2.Translate(translation);
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0xA02F6C", Offset = "0xA02F6C", Length = "0x3C0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv34 = *([1EEC838]);\n\tv35 = *([v34 @ X8_v44]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021C6E]) = v54;\nL_0025:\n\tv61 = 0;\n\tv67 = 0x10CCF64(&v61 @ stack_-70_v1, 0, v38, v39, v40, v41, v42, v43, 50f, 50f, 200f, 24f, v48, v49, v50, v51);\n\tgoto L_003C;\n\tv74 = *([v70 @ X0_v4+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_003C;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v70, v65, v38, v39, v40, v41, v42, v43, v62, v63, v64, v59, v48, v49, v50, v51);\nL_003C:\n\t// 60 MakeStruct v91 @ AGGA03020_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v84 @ stack_-6C, 0, v87 @ stack_-64\n\tUnityEngine.GUI::Label(v91, \"Press arrow key to move\");\n\tv97 = UnityEngine.GameObject::GetComponentInChildren(this.m_Player);\n\tv252 = 0;\n\tv313 = 0x10CCF64(&v252 @ stack_-80_v3, 0, v38, v39, v40, v41, v42, v43, 50f, 70f, 200f, 24f, v48, v49, v50, v51);\n\tv396 = UnityEngine.Behaviour::get_enabled(v97);\n\t// 94 MakeStruct v241 @ AGGA03090_0_v3 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v476 @ stack_-7C, 0, v477 @ stack_-74\n\tv481 = UnityEngine.GUI::Toggle(v241, v396, \"Play Animation\");\n\tUnityEngine.Behaviour::set_enabled(v97, v481);\n\tv486 = UnityEngine.GameObject::GetComponents(this.m_Player);\n\tv236 = 0;\n\tv494 = 0x10CCF64(&v236 @ stack_-90_v3, 0, 0, v39, v40, v41, v42, v43, 50f, 100f, 200f, 24f, v48, v49, v50, v51);\n\t// 127 MakeStruct v230 @ AGGA03100_0_v3 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v496 @ stack_-8C, 0, v497 @ stack_-84\n\tUnityEngine.GUI::Label(v230, \"Choose dynamic bone:\");\n\tv499 = v486.Length == 0;\n\tif (v499) goto L_015C;\n\tv208 = v486.Length == 1;\n\tif (v208) goto L_015C;\n\tv172 = 0;\n\tv515 = 0x10CCF64(&v172 @ stack_-A0_v4, 0, 0, v39, v40, v41, v42, v43, 50f, 120f, 100f, 24f, v48, v49, v50, v51);\n\tv519 = v486.Length == 0;\n\tif (v519) goto L_015C;\n\tv527 = UnityEngine.Behaviour::get_enabled(v486[0]);\n\t// 173 MakeStruct v164 @ AGGA03174_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v529 @ stack_-9C, 0, v530 @ stack_-94\n\tv378 = UnityEngine.GUI::Toggle(v164, v527, \"Breasts\");\n\tUnityEngine.Behaviour::set_enabled(v486[1], v378);\n\tUnityEngine.Behaviour::set_enabled(v486[0], v378);\n\tv532 = v486.Length < 2;\n\tv510 = ~v532;\n\tv509 = v486.Length - 2;\n\tv507 = v509 == 0;\n\tv533 = ~v510;\n\tv502 = v533 | v507;\n\tif (v502) goto L_015C;\n\tv152 = 0;\n\tv517 = 0x10CCF64(&v152 @ stack_-B0_v4, 0, 0, v39, v40, v41, v42, v43, 50f, 140f, 100f, 24f, v48, v49, v50, v51);\n\tv536 = v486.Length < 2;\n\tv227 = ~v536;\n\tv221 = v486.Length - 2;\n\tv209 = v221 == 0;\n\tv537 = ~v227;\n\tv156 = v537 | v209;\n\tif (v156) goto L_015C;\n\tv539 = UnityEngine.Behaviour::get_enabled(v486[2]);\n\t// 239 MakeStruct v144 @ AGGA03210_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v541 @ stack_-AC, 0, v542 @ stack_-A4\n\tv380 = UnityEngine.GUI::Toggle(v144, v539, \"Tail\");\n\tUnityEngine.Behaviour::set_enabled(v486[2], v380);\n\tv134 = 0;\n\tv553 = 0x10CCF64(&v134 @ stack_-C0_v4, 0, 0, v39, v40, v41, v42, v43, 50f, 160f, 200f, 24f, v48, v49, v50, v51);\n\t// 267 MakeStruct v126 @ AGGA0326C_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v557 @ stack_-BC, 0, v560 @ stack_-B4\n\tUnityEngine.GUI::Label(v126, \"Weight\");\n\tv122 = 0;\n\tv569 = 0x10CCF64(&v122 @ stack_-D0_v4, 0, 0, v39, v40, v41, v42, v43, 100f, 160f, 100f, 24f, v48, v49, v50, v51);\n\t// 286 MakeStruct v105 @ AGGA032A8_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v571 @ stack_-CC, 0, v572 @ stack_-C4\n\tv574 = UnityEngine.GUI::HorizontalSlider(v105, this.m_weight, 0f, 1f);\n\tthis.m_weight = v574;\n\tv522 = v486.Length;\n\tv586 = v486.Length < 1;\n\tif (v586) goto L_015B;\nL_012F:\n\tv609 = v180 < v522;\n\tv228 = ~v609;\n\tif (v228) goto L_015C;\n\tDynamicBone::SetWeight(v486[v180 @ X21_v9 (System.Int32)], this.m_weight);\n\tv522 = v486.Length;\n\tv180 = v180 + 1;\n\tv588 = v180 < v486.Length;\n\tif (v588) goto L_012F;\nL_015B:\n\treturn;\nL_015C:\n\tv523 = new System.IndexOutOfRangeException();\n\tthrow v523;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 270 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnGUI()
	{
		//IL_0522: Expected O, but got I4
		//IL_0020: Expected F4, but got O
		//IL_003b: Expected F4, but got O
		//IL_0066: Expected O, but got I4
		//IL_009d: Expected F4, but got O
		//IL_00b8: Expected F4, but got O
		//IL_00fd: Expected O, but got I4
		//IL_0127: Expected F4, but got O
		//IL_0142: Expected F4, but got O
		//IL_019c: Expected O, but got I4
		//IL_01f7: Expected F4, but got O
		//IL_0212: Expected F4, but got O
		//IL_028c: Expected O, but got I4
		//IL_02ca: Expected O, but got I4
		//IL_0300: Expected O, but got I4
		//IL_0367: Expected F4, but got O
		//IL_0382: Expected F4, but got O
		//IL_03bd: Expected O, but got I4
		//IL_03e7: Expected F4, but got O
		//IL_0402: Expected F4, but got O
		//IL_0419: Expected O, but got I4
		//IL_0443: Expected F4, but got O
		//IL_045e: Expected F4, but got O
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
		Rect position = default(Rect);
		position.x = 0f;
		object obj2 = default(object);
		position.y = (float)obj2;
		position.width = 0f;
		object obj3 = default(object);
		position.height = (float)obj3;
		GUI.Label(position, "Press arrow key to move");
		Animation componentInChildren = m_Player.GetComponentInChildren<Animation>();
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
		bool value = componentInChildren.enabled;
		Rect position2 = default(Rect);
		position2.x = 0f;
		object obj5 = default(object);
		position2.y = (float)obj5;
		position2.width = 0f;
		object obj6 = default(object);
		position2.height = (float)obj6;
		bool flag = GUI.Toggle(position2, value, "Play Animation");
		componentInChildren.enabled = flag;
		DynamicBone[] components = m_Player.GetComponents<DynamicBone>();
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
		Rect position3 = default(Rect);
		position3.x = 0f;
		object obj8 = default(object);
		position3.y = (float)obj8;
		position3.width = 0f;
		object obj9 = default(object);
		position3.height = (float)obj9;
		GUI.Label(position3, "Choose dynamic bone:");
		if (components.Length != 0 && components.Length != 1)
		{
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			if (components.Length != 0)
			{
				bool value2 = components[0].enabled;
				Rect position4 = default(Rect);
				position4.x = 0f;
				object obj11 = default(object);
				position4.y = (float)obj11;
				position4.width = 0f;
				object obj12 = default(object);
				position4.height = (float)obj12;
				bool flag2 = GUI.Toggle(position4, value2, "Breasts");
				components[1].enabled = flag2;
				components[0].enabled = flag2;
				bool flag3 = components.Length < 2;
				bool flag4 = !flag3;
				object obj13 = components.Length - 2;
				bool flag5 = obj13 == null;
				bool flag6 = !flag4;
				if (!(flag6 || flag5))
				{
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
					bool flag7 = components.Length < 2;
					bool flag8 = !flag7;
					object obj15 = components.Length - 2;
					bool flag9 = obj15 == null;
					bool flag10 = !flag8;
					if (!(flag10 || flag9))
					{
						bool value3 = components[2].enabled;
						Rect position5 = default(Rect);
						position5.x = 0f;
						object obj16 = default(object);
						position5.y = (float)obj16;
						position5.width = 0f;
						object obj17 = default(object);
						position5.height = (float)obj17;
						bool flag11 = GUI.Toggle(position5, value3, "Tail");
						components[2].enabled = flag11;
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
						Rect position6 = default(Rect);
						position6.x = 0f;
						object obj19 = default(object);
						position6.y = (float)obj19;
						position6.width = 0f;
						object obj20 = default(object);
						position6.height = (float)obj20;
						GUI.Label(position6, "Weight");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
						Rect position7 = default(Rect);
						position7.x = 0f;
						object obj22 = default(object);
						position7.y = (float)obj22;
						position7.width = 0f;
						object obj23 = default(object);
						position7.height = (float)obj23;
						float weight = GUI.HorizontalSlider(position7, m_weight, 0f, 1f);
						m_weight = weight;
						int num = components.Length;
						if (components.Length < 1)
						{
							return;
						}
						int num2 = 0;
						while (num2 < num)
						{
							components[num2].SetWeight(m_weight);
							num = components.Length;
							num2++;
							if (num2 >= components.Length)
							{
								return;
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0xA0332C", Offset = "0xA0332C", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_weight = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DynamicBoneDemo1()
	{
		m_weight = 1f;
	}
}
