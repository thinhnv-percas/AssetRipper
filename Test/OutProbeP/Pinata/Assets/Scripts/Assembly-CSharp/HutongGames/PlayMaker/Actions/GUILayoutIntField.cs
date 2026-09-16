using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7576E8", Offset = "0x7576E8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7576E8", Offset = "0x7576E8")]
	[Token(Token = "0x2000229")]
	public class GUILayoutIntField : GUILayoutAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2B58", Offset = "0x7B2B58")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2B58", Offset = "0x7B2B58")]
		[Token(Token = "0x4001523")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt intVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2BA8", Offset = "0x7B2BA8")]
		[Token(Token = "0x4001524")]
		[FieldOffset(Offset = "0x68")]
		public FsmString style;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2BE0", Offset = "0x7B2BE0")]
		[Token(Token = "0x4001525")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent changedEvent;

		[Token(Token = "0x6000AF1")]
		[Address(RVA = "0xB7AB68", Offset = "0xB7AB68", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB03A8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202295E]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.intVariable = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v44;\n\tthis.changedEvent = 0;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			intVariable = null;
			FsmString fsmString = "";
			style = fsmString;
			changedEvent = null;
		}

		[Token(Token = "0x6000AF2")]
		[Address(RVA = "0xB7ABCC", Offset = "0xB7ABCC", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EC5A90]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202295F]) = v46;\nL_001E:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0025:\n\tv62 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv69 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv62 = System.String::IsNullOrEmpty(v69);\n\tv85 = this.intVariable;\n\tv116 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv147 = 0xDC3560(&v116 @ X0_v16 (System.Int32), 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv149 = v62 == 0;\n\tif (v149) goto L_004B;\n\tv151 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv171 = UnityEngine.GUILayout::TextField(v147, v151);\n\tgoto L_0066;\nL_004B:\n\tv157 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_005C;\n\tv177 = *([v161 @ X8_v17+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_005C;\n\tv189 = v161;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v189, v156, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005C:\n\tv184 = UnityEngine.GUIStyle::op_Implicit(v157);\n\tv191 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv171 = UnityEngine.GUILayout::TextField(v147, v184, v191);\nL_0066:\n\tv176 = System.Int32::Parse(v171);\n\tv85.value = v176;\n\tgoto L_0073;\n\tv192 = *([v185 @ X0_v21+E0]);\n\tv193 = v192 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0073;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v185, v88, v76, v71, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0073:\n\tv62 = UnityEngine.GUI::get_changed();\n\tv202 = v62 == 0;\n\tif (v202) goto L_0084;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\tgoto L_0096;\nL_0084:\n\tgoto L_008C;\n\tv209 = *([v203 @ X0_v26+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_008C;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v203, v88, v76, v71, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_008C:\n\tUnityEngine.GUI::set_changed(v62);\nL_0096:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			string value = style.Value;
			changed = string.IsNullOrEmpty(value);
			FsmInt fsmInt = intVariable;
			int value2 = intVariable.Value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string s;
			string text = default(string);
			if (changed)
			{
				GUILayoutOption[] array = base.LayoutOptions;
				s = GUILayout.TextField(text, array);
			}
			else
			{
				string value3 = style.Value;
				GUIStyle gUIStyle = value3;
				GUILayoutOption[] array2 = base.LayoutOptions;
				s = GUILayout.TextField(text, gUIStyle, array2);
			}
			int value4 = int.Parse(s);
			fsmInt.Value = value4;
			changed = GUI.changed;
			if (changed)
			{
				Fsm.Event(changedEvent);
				GUIUtility.ExitGUI();
			}
			else
			{
				GUI.changed = changed;
			}
		}

		[Token(Token = "0x6000AF3")]
		[Address(RVA = "0xB7ADA8", Offset = "0xB7ADA8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutIntField()
		{
		}
	}
}
