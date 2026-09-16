using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757698", Offset = "0x757698")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757698", Offset = "0x757698")]
	[Token(Token = "0x2000228")]
	public class GUILayoutHorizontalSlider : GUILayoutAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2AFC", Offset = "0x7B2AFC")]
		[Token(Token = "0x400151F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Token(Token = "0x4001520")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat leftValue;

		[RequiredField]
		[Token(Token = "0x4001521")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat rightValue;

		[Token(Token = "0x4001522")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent changedEvent;

		[Token(Token = "0x6000AEE")]
		[Address(RVA = "0xB7A9B0", Offset = "0xB7A9B0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.floatVariable = 0;\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.leftValue = v13;\n\tv17 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rightValue = v17;\n\tthis.changedEvent = 0;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			floatVariable = null;
			FsmFloat fsmFloat = 0f;
			leftValue = fsmFloat;
			FsmFloat fsmFloat2 = 100f;
			rightValue = fsmFloat2;
			changedEvent = null;
		}

		[Token(Token = "0x6000AEF")]
		[Address(RVA = "0xB7A9F8", Offset = "0xB7A9F8", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EE40B0]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202295D]) = v48;\nL_001E:\n\tgoto L_0025;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0025;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0025:\n\tv63 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv67 = this.floatVariable;\n\tv68 = this.floatVariable == 0;\n\tif (v68) goto L_0049;\n\tv71 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv106 = HutongGames.PlayMaker.FsmFloat::get_Value(this.leftValue);\n\tv128 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rightValue);\n\tv87 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv83 = UnityEngine.GUILayout::HorizontalSlider(v71, v106, v128, v87);\n\tv67.value = v83;\nL_0049:\n\tgoto L_0050;\n\tv96 = *([v90 @ X0_v8+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_0050;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v90, v84, v32, v33, v34, v35, v36, v37, v82, v74, v72, v41, v42, v43, v44, v45);\nL_0050:\n\tv104 = UnityEngine.GUI::get_changed();\n\tv122 = v104 == 0;\n\tif (v122) goto L_006B;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\treturn;\nL_006B:\n\tgoto L_007D;\n\tv171 = *([v123 @ X0_v12+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_007D;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v123, v84, v32, v33, v34, v35, v36, v37, v82, v74, v72, v41, v42, v43, v44, v45);\nL_007D:\n\tUnityEngine.GUI::set_changed(v63);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			FsmFloat fsmFloat = floatVariable;
			if (floatVariable != null)
			{
				float value = floatVariable.Value;
				float value2 = leftValue.Value;
				float value3 = rightValue.Value;
				GUILayoutOption[] array = base.LayoutOptions;
				float value4 = GUILayout.HorizontalSlider(value, value2, value3, array);
				fsmFloat.Value = value4;
			}
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

		[Token(Token = "0x6000AF0")]
		[Address(RVA = "0xB7AB60", Offset = "0xB7AB60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutHorizontalSlider()
		{
		}
	}
}
