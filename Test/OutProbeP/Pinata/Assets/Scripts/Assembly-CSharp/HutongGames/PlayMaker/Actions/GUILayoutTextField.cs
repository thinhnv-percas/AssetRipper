using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7578C8", Offset = "0x7578C8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7578C8", Offset = "0x7578C8")]
	[Token(Token = "0x200022F")]
	public class GUILayoutTextField : GUILayoutAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2E2C", Offset = "0x7B2E2C")]
		[Token(Token = "0x4001539")]
		[FieldOffset(Offset = "0x60")]
		public FsmString text;

		[Token(Token = "0x400153A")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt maxLength;

		[Token(Token = "0x400153B")]
		[FieldOffset(Offset = "0x70")]
		public FsmString style;

		[Token(Token = "0x400153C")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent changedEvent;

		[Token(Token = "0x6000B03")]
		[Address(RVA = "0xB7B6A0", Offset = "0xB7B6A0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFBAC0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022968]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.text = 0;\n\tv42 = HutongGames.PlayMaker.FsmInt::op_Implicit(0x19);\n\tthis.maxLength = v42;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"TextField\");\n\tthis.style = v47;\n\tthis.changedEvent = 0;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			text = null;
			FsmInt fsmInt = 25;
			maxLength = fsmInt;
			FsmString fsmString = "TextField";
			style = fsmString;
			changedEvent = null;
		}

		[Token(Token = "0x6000B04")]
		[Address(RVA = "0xB7B714", Offset = "0xB7B714", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EB1650]);\n\tv29 = *([v28 @ X8_v18]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022969]) = v48;\nL_001E:\n\tgoto L_0025;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0025;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0025:\n\tv63 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv67 = this.text;\n\tv71 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv79 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxLength);\n\tv154 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_004E;\n\tv161 = *([v107 @ X8_v11+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_004E;\n\tv170 = v107;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v170, v153, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_004E:\n\tv169 = UnityEngine.GUIStyle::op_Implicit(v154);\n\tv172 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv174 = UnityEngine.GUILayout::TextField(v71, v79, v169, v172);\n\tv67.value = v174;\n\tv176 = UnityEngine.GUI::get_changed();\n\tv178 = v176 == 0;\n\tif (v178) goto L_0075;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\treturn;\nL_0075:\n\tgoto L_0087;\n\tv183 = *([v179 @ X0_v26+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0087;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v179, v101, v90, v92, v88, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0087:\n\tUnityEngine.GUI::set_changed(v63);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			FsmString fsmString = text;
			string value = text.Value;
			int value2 = maxLength.Value;
			string value3 = style.Value;
			GUIStyle gUIStyle = value3;
			GUILayoutOption[] array = base.LayoutOptions;
			string value4 = GUILayout.TextField(value, value2, gUIStyle, array);
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

		[Token(Token = "0x6000B05")]
		[Address(RVA = "0xB7B8A8", Offset = "0xB7B8A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutTextField()
		{
		}
	}
}
