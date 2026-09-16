using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757148", Offset = "0x757148")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757148", Offset = "0x757148")]
	[Token(Token = "0x2000217")]
	public class GUILayoutBeginAreaFollowObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B22FC", Offset = "0x7B22FC")]
		[Token(Token = "0x40014ED")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[RequiredField]
		[Token(Token = "0x40014EE")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat offsetLeft;

		[RequiredField]
		[Token(Token = "0x40014EF")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat offsetTop;

		[RequiredField]
		[Token(Token = "0x40014F0")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat width;

		[RequiredField]
		[Token(Token = "0x40014F1")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat height;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2388", Offset = "0x7B2388")]
		[Token(Token = "0x40014F2")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool normalized;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B23C0", Offset = "0x7B23C0")]
		[Token(Token = "0x40014F3")]
		[FieldOffset(Offset = "0x80")]
		public FsmString style;

		[Token(Token = "0x6000ABB")]
		[Address(RVA = "0xB79098", Offset = "0xB79098", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EB8D50]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022949]) = v40;\nL_0016:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.offsetLeft = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.offsetTop = v46;\n\tv50 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.width = v50;\n\tv53 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.height = v53;\n\tv56 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalized = v56;\n\tv61 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v61;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 0f;
			offsetLeft = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			offsetTop = fsmFloat2;
			FsmFloat fsmFloat3 = 1f;
			width = fsmFloat3;
			FsmFloat fsmFloat4 = 1f;
			height = fsmFloat4;
			FsmBool fsmBool = true;
			normalized = fsmBool;
			FsmString fsmString = "";
			style = fsmString;
		}

		[Token(Token = "0x6000ABC")]
		[Address(RVA = "0xB79150", Offset = "0xB79150", Length = "0x384")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ED0F50]);\n\tv31 = *([v30 @ X8_v18]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202294A]) = v50;\nL_001F:\n\tv56 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0031;\n\tv233 = *([v187 @ X8_v5+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_0031;\n\tv244 = v187;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v244, v55, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0031:\n\tv243 = UnityEngine.Object::op_Equality(v56, 0);\n\tv246 = v243 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_007A;\n\tv321 = UnityEngine.Camera::get_main();\n\tgoto L_0047;\n\tv373 = *([v176 @ X8_v8+E0]);\n\tv374 = v373 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_0047;\n\tv380 = v176;\n\tv377 = \"il2cpp_codegen_runtime_class_init\"(v380, v241, v242, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0047:\n\tv221 = UnityEngine.Object::op_Equality(v321, 0);\n\tv382 = v221 == 0;\n\tv344 = ~v382;\n\tif (v344) goto L_007A;\n\tv154 = UnityEngine.GameObject::get_transform(v56);\n\tv127 = UnityEngine.Transform::get_position(v154);\n\tv155 = UnityEngine.Camera::get_main();\n\tv156 = UnityEngine.Component::get_transform(v155);\n\tv128 = UnityEngine.Transform::InverseTransformPoint(v156, v127);\n\tv74 = v128.z >= 0;\n\tif (v74) goto L_0089;\nL_007A:\n\t// 122 MakeStruct v351 @ AGGB79294_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, 0, 0\n\tUnityEngine.GUILayout::BeginArea(v351);\nL_0087:\n\treturn;\nL_0089:\n\tv157 = UnityEngine.Camera::get_main();\n\tv393 = UnityEngine.Camera::WorldToScreenPoint(v157, v127);\n\tgoto L_00A8;\n\tv404 = *([v400 @ X0_v27+E0]);\n\tv405 = v404 == 0;\n\tv406 = ~v405;\n\tif (v406) goto L_00A8;\n\tv408 = \"il2cpp_codegen_runtime_class_init\"(v400, v147, v136, v35, v36, v37, v38, v39, v393, v394, v395, v43, v44, v45, v46, v47);\nL_00A8:\n\tv129 = UnityEngine.Vector2::op_Implicit(v393);\n\tv222 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv414 = v222 == 0;\n\tif (v414) goto L_00C4;\n\tv417 = HutongGames.PlayMaker.FsmFloat::get_Value(this.offsetLeft);\n\tv423 = UnityEngine.Screen::get_width();\n\tv105 = v417 * v423;\n\tgoto L_00CA;\nL_00C4:\n\tv420 = HutongGames.PlayMaker.FsmFloat::get_Value(this.offsetLeft);\nL_00CA:\n\tv223 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv430 = HutongGames.PlayMaker.FsmFloat::get_Value(this.offsetTop);\n\tv433 = v223 == 0;\n\tif (v433) goto L_00DE;\n\tv435 = UnityEngine.Screen::get_width();\n\tv69 = v430 * v435;\nL_00DE:\n\tv130 = HutongGames.PlayMaker.FsmFloat::get_Value(this.width);\n\tv113 = v129 + v105;\n\tv109 = v129.y + v69;\n\tv440 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tv442 = 0x10CCF64(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v113, v109, v130, v440, v44, v45, v46, v47);\n\tv444 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv446 = v444 == 0;\n\tif (v446) goto L_010D;\n\tv450 = 0x10CD178(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v113, v109, v130, v440, v44, v45, v46, v47);\n\tv464 = UnityEngine.Screen::get_width();\n\tv470 = v113 * v464;\n\tv474 = 0x10CD180(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v470, v109, v130, v440, v44, v45, v46, v47);\n\tv480 = 0x10CD188(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v470, v109, v130, v440, v44, v45, v46, v47);\n\tv482 = UnityEngine.Screen::get_height();\n\tv454 = v470 * v482;\n\tv459 = 0x10CD190(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v454, v109, v130, v440, v44, v45, v46, v47);\nL_010D:\n\tv461 = UnityEngine.Screen::get_height();\n\tv468 = 0x10CCFC4(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v454, v109, v130, v440, v44, v45, v46, v47);\n\tv132 = v461 - v454;\n\tv476 = 0x10CCFCC(&v58 @ stack_-60_v5, 0, 0, v35, v36, v37, v38, v39, v132, v461, v130, v440, v44, v45, v46, v47);\n\tv371 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\t// 293 MakeStruct v355 @ AGGB794C0_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), v58 @ stack_-60_v5, v484 @ stack_-5C, 0, v483 @ stack_-54\n\tUnityEngine.GUILayout::BeginArea(v355, v371);\n\tgoto L_0087;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_03b1: Expected F4, but got O
			//IL_03be: Expected F4, but got O
			//IL_03d9: Expected F4, but got O
			GameObject value = gameObject.Value;
			if (!(value == null))
			{
				Camera main = Camera.main;
				if (!(main == null))
				{
					Transform transform = value.transform;
					Vector3 position = transform.position;
					Camera main2 = Camera.main;
					Transform transform2 = main2.transform;
					if (!(transform2.InverseTransformPoint(position).z < 0f))
					{
						Camera main3 = Camera.main;
						Vector3 vector = main3.WorldToScreenPoint(position);
						Vector2 vector2 = vector;
						float num2;
						if (normalized.Value)
						{
							float value2 = offsetLeft.Value;
							int num = Screen.width;
							num2 = value2 * (float)num;
						}
						else
						{
							float value3 = offsetLeft.Value;
							num2 = value3;
						}
						bool value4 = normalized.Value;
						float value5 = offsetTop.Value;
						bool flag = !value4;
						float num3 = value5;
						if (!flag)
						{
							int num4 = Screen.width;
							num3 = value5 * (float)num4;
						}
						float value6 = width.Value;
						float num5 = vector2.x + num2;
						float num6 = vector2.y + num3;
						float value7 = height.Value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
						bool value8 = normalized.Value;
						bool flag2 = !value8;
						float num7 = num5;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
							int num8 = Screen.width;
							float num9 = num5 * (float)num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
							int num10 = Screen.height;
							num7 = num9 * (float)num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
						}
						int num11 = Screen.height;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
						float num12 = (float)num11 - num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
						string value9 = style.Value;
						Rect screenRect = default(Rect);
						object obj = default(object);
						screenRect.x = (float)obj;
						object obj2 = default(object);
						screenRect.y = (float)obj2;
						screenRect.width = 0f;
						object obj3 = default(object);
						screenRect.height = (float)obj3;
						GUILayout.BeginArea(screenRect, value9);
						return;
					}
				}
			}
			Rect screenRect2 = default(Rect);
			screenRect2.x = 0f;
			screenRect2.y = 0f;
			screenRect2.width = 0f;
			screenRect2.height = 0f;
			GUILayout.BeginArea(screenRect2);
		}

		[Token(Token = "0x6000ABD")]
		[Address(RVA = "0xB794D4", Offset = "0xB794D4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 5 MakeStruct v5 @ AGGB794E8_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, 0, 0\n\tUnityEngine.GUILayout::BeginArea(v5);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DummyBeginArea()
		{
			Rect screenRect = default(Rect);
			screenRect.x = 0f;
			screenRect.y = 0f;
			screenRect.width = 0f;
			screenRect.height = 0f;
			GUILayout.BeginArea(screenRect);
		}

		[Token(Token = "0x6000ABE")]
		[Address(RVA = "0xB794EC", Offset = "0xB794EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutBeginAreaFollowObject()
		{
		}
	}
}
