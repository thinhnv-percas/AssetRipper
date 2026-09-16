using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7577D8", Offset = "0x7577D8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7577D8", Offset = "0x7577D8")]
	[Token(Token = "0x200022C")]
	public class GUILayoutPasswordField : GUILayoutAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2CE8", Offset = "0x7B2CE8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2CE8", Offset = "0x7B2CE8")]
		[Token(Token = "0x400152D")]
		[FieldOffset(Offset = "0x60")]
		public FsmString text;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2D38", Offset = "0x7B2D38")]
		[Token(Token = "0x400152E")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt maxLength;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2D70", Offset = "0x7B2D70")]
		[Token(Token = "0x400152F")]
		[FieldOffset(Offset = "0x70")]
		public FsmString style;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2DA8", Offset = "0x7B2DA8")]
		[Token(Token = "0x4001530")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2DE0", Offset = "0x7B2DE0")]
		[Token(Token = "0x4001531")]
		[FieldOffset(Offset = "0x80")]
		public FsmString mask;

		[Token(Token = "0x6000AFA")]
		[Address(RVA = "0xB7B1E8", Offset = "0xB7B1E8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC6C20]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022964]) = v38;\nL_0015:\n\tthis.text = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0x19);\n\tthis.maxLength = v41;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"TextField\");\n\tthis.style = v46;\n\tv51 = HutongGames.PlayMaker.FsmString::op_Implicit(\"*\");\n\tthis.changedEvent = 0;\n\tthis.mask = v51;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			text = null;
			FsmInt fsmInt = 25;
			maxLength = fsmInt;
			FsmString fsmString = "TextField";
			style = fsmString;
			FsmString fsmString2 = "*";
			changedEvent = null;
			mask = fsmString2;
		}

		[Token(Token = "0x6000AFB")]
		[Address(RVA = "0xB7B26C", Offset = "0xB7B26C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EC7690]);\n\tv29 = *([v28 @ X8_v18]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022965]) = v48;\nL_001E:\n\tgoto L_0025;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0025;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0025:\n\tv63 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv67 = this.text;\n\tv71 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv106 = HutongGames.PlayMaker.FsmString::get_Value(this.mask);\n\tv81 = System.String::get_Chars(v106, 0);\n\tv159 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0053;\n\tv166 = *([v112 @ X8_v11+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0053;\n\tv175 = v112;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v175, v158, v75, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0053:\n\tv174 = UnityEngine.GUIStyle::op_Implicit(v159);\n\tv177 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv179 = UnityEngine.GUILayout::PasswordField(v71, v81, v174, v177);\n\tv67.value = v179;\n\tv181 = UnityEngine.GUI::get_changed();\n\tv183 = v181 == 0;\n\tif (v183) goto L_007A;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\treturn;\nL_007A:\n\tgoto L_008C;\n\tv188 = *([v184 @ X0_v27+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_008C;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v184, v104, v100, v92, v90, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_008C:\n\tUnityEngine.GUI::set_changed(v63);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			FsmString fsmString = text;
			string value = text.Value;
			string value2 = mask.Value;
			char maskChar = value2.get_Chars(0);
			string value3 = style.Value;
			GUIStyle gUIStyle = value3;
			GUILayoutOption[] array = base.LayoutOptions;
			string value4 = GUILayout.PasswordField(value, maskChar, gUIStyle, array);
			fsmString.Value = value4;
			if (GUI.changed)
			{
				Fsm.Event(changedEvent);
				GUIUtility.ExitGUI();
			}
			else
			{
				GUI.changed = changed;
			}
		}

		[Token(Token = "0x6000AFC")]
		[Address(RVA = "0xB7B410", Offset = "0xB7B410", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutPasswordField()
		{
		}
	}
}
