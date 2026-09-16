using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7573C8", Offset = "0x7573C8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7573C8", Offset = "0x7573C8")]
	[Token(Token = "0x200021F")]
	public class GUILayoutEmailField : GUILayoutAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B283C", Offset = "0x7B283C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B283C", Offset = "0x7B283C")]
		[Token(Token = "0x4001514")]
		[FieldOffset(Offset = "0x60")]
		public FsmString text;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B288C", Offset = "0x7B288C")]
		[Token(Token = "0x4001515")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt maxLength;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B28C4", Offset = "0x7B28C4")]
		[Token(Token = "0x4001516")]
		[FieldOffset(Offset = "0x70")]
		public FsmString style;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B28FC", Offset = "0x7B28FC")]
		[Token(Token = "0x4001517")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2934", Offset = "0x7B2934")]
		[Token(Token = "0x4001518")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool valid;

		[Token(Token = "0x6000AD4")]
		[Address(RVA = "0xB7A2A8", Offset = "0xB7A2A8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EFD3A0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022957]) = v38;\nL_0015:\n\tthis.text = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0x19);\n\tthis.maxLength = v41;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"TextField\");\n\tthis.style = v46;\n\tv49 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.changedEvent = 0;\n\tthis.valid = v49;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			text = null;
			FsmInt fsmInt = 25;
			maxLength = fsmInt;
			FsmString fsmString = "TextField";
			style = fsmString;
			FsmBool fsmBool = true;
			changedEvent = null;
			valid = fsmBool;
		}

		[Token(Token = "0x6000AD5")]
		[Address(RVA = "0xB7A324", Offset = "0xB7A324", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB4238]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022958]) = v46;\nL_001D:\n\tgoto L_0024;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\tv61 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv65 = this.text;\n\tv69 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv100 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0046;\n\tv145 = *([v96 @ X8_v10+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0046;\n\tv154 = v96;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v154, v99, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0046:\n\tv153 = UnityEngine.GUIStyle::op_Implicit(v100);\n\tv156 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv158 = UnityEngine.GUILayout::TextField(v69, v153, v156);\n\tv65.value = v158;\n\tv160 = UnityEngine.GUI::get_changed();\n\tv162 = v160 == 0;\n\tif (v162) goto L_006B;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\treturn;\nL_006B:\n\tgoto L_007C;\n\tv167 = *([v163 @ X0_v24+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_007C;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v163, v90, v82, v80, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_007C:\n\tUnityEngine.GUI::set_changed(v61);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			FsmString fsmString = text;
			string value = text.Value;
			string value2 = style.Value;
			GUIStyle gUIStyle = value2;
			GUILayoutOption[] array = base.LayoutOptions;
			string value3 = GUILayout.TextField(value, gUIStyle, array);
			fsmString.Value = value3;
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

		[Token(Token = "0x6000AD6")]
		[Address(RVA = "0xB7A490", Offset = "0xB7A490", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutEmailField()
		{
		}
	}
}
