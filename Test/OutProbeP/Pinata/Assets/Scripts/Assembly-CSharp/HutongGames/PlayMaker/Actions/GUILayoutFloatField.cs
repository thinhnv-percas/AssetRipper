using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7575F8", Offset = "0x7575F8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7575F8", Offset = "0x7575F8")]
	[Token(Token = "0x2000226")]
	public class GUILayoutFloatField : GUILayoutAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B296C", Offset = "0x7B296C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B296C", Offset = "0x7B296C")]
		[Token(Token = "0x4001519")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat floatVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B29BC", Offset = "0x7B29BC")]
		[Token(Token = "0x400151A")]
		[FieldOffset(Offset = "0x68")]
		public FsmString style;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B29F4", Offset = "0x7B29F4")]
		[Token(Token = "0x400151B")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent changedEvent;

		[Token(Token = "0x6000AE8")]
		[Address(RVA = "0xB7A538", Offset = "0xB7A538", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB4598]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022959]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.floatVariable = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v44;\n\tthis.changedEvent = 0;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			floatVariable = null;
			FsmString fsmString = "";
			style = fsmString;
			changedEvent = null;
		}

		[Token(Token = "0x6000AE9")]
		[Address(RVA = "0xB7A59C", Offset = "0xB7A59C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EE1548]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202295A]) = v46;\nL_001E:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0025:\n\tv62 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv69 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv102 = System.String::IsNullOrEmpty(v69);\n\tv88 = this.floatVariable;\n\tv82 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv151 = 0xBCCEC8(&v82 @ V0_v3 (System.Single), 0, v30, v31, v32, v33, v34, v35, v82, v37, v38, v39, v40, v41, v42, v43);\n\tv153 = v102 == 0;\n\tif (v153) goto L_004B;\n\tv155 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv175 = UnityEngine.GUILayout::TextField(v151, v155);\n\tgoto L_0066;\nL_004B:\n\tv161 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_005C;\n\tv180 = *([v165 @ X8_v17+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_005C;\n\tv192 = v165;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v192, v160, v30, v31, v32, v33, v34, v35, v82, v37, v38, v39, v40, v41, v42, v43);\nL_005C:\n\tv187 = UnityEngine.GUIStyle::op_Implicit(v161);\n\tv194 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv175 = UnityEngine.GUILayout::TextField(v151, v187, v194);\nL_0066:\n\tv82 = System.Single::Parse(v175);\n\tv88.value = v82;\n\tgoto L_0073;\n\tv195 = *([v188 @ X0_v19+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0073;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v188, v91, v76, v71, v32, v33, v34, v35, v83, v37, v38, v39, v40, v41, v42, v43);\nL_0073:\n\tv202 = UnityEngine.GUI::get_changed();\n\tv205 = v202 == 0;\n\tif (v205) goto L_0084;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\tgoto L_0096;\nL_0084:\n\tgoto L_008C;\n\tv212 = *([v206 @ X0_v24+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tif (v214) goto L_008C;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v206, v91, v76, v71, v32, v33, v34, v35, v83, v37, v38, v39, v40, v41, v42, v43);\nL_008C:\n\tUnityEngine.GUI::set_changed(v62);\nL_0096:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			string value = style.Value;
			bool flag = string.IsNullOrEmpty(value);
			FsmFloat fsmFloat = floatVariable;
			float value2 = floatVariable.Value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
			string s;
			string text = default(string);
			if (flag)
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
			value2 = float.Parse(s);
			fsmFloat.Value = value2;
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

		[Token(Token = "0x6000AEA")]
		[Address(RVA = "0xB7A778", Offset = "0xB7A778", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutFloatField()
		{
		}
	}
}
