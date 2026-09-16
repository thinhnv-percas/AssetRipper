using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756B80", Offset = "0x756B80")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756B80", Offset = "0x756B80")]
	[Token(Token = "0x2000206")]
	public class GUIVerticalSlider : GUIAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1F24", Offset = "0x7B1F24")]
		[Token(Token = "0x40014B8")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Token(Token = "0x40014B9")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat topValue;

		[RequiredField]
		[Token(Token = "0x40014BA")]
		[FieldOffset(Offset = "0xA0")]
		public FsmFloat bottomValue;

		[Token(Token = "0x40014BB")]
		[FieldOffset(Offset = "0xA8")]
		public FsmString sliderStyle;

		[Token(Token = "0x40014BC")]
		[FieldOffset(Offset = "0xB0")]
		public FsmString thumbStyle;

		[Token(Token = "0x6000A80")]
		[Address(RVA = "0xB7C658", Offset = "0xB7C658", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB9EB8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022974]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUIAction::Reset(this);\n\tthis.floatVariable = 0;\n\tv43 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.topValue = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.bottomValue = v46;\n\tv51 = HutongGames.PlayMaker.FsmString::op_Implicit(\"verticalslider\");\n\tthis.sliderStyle = v51;\n\tv56 = HutongGames.PlayMaker.FsmString::op_Implicit(\"verticalsliderthumb\");\n\tthis.thumbStyle = v56;\n\tv60 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.1f);\n\tthis.width = v60;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			floatVariable = null;
			FsmFloat fsmFloat = 100f;
			topValue = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			bottomValue = fsmFloat2;
			FsmString fsmString = "verticalslider";
			sliderStyle = fsmString;
			FsmString fsmString2 = "verticalsliderthumb";
			thumbStyle = fsmString2;
			FsmFloat fsmFloat3 = 0.1f;
			width = fsmFloat3;
		}

		[Token(Token = "0x6000A81")]
		[Address(RVA = "0xB7C70C", Offset = "0xB7C70C", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EFD800]);\n\tv39 = *([v38 @ X8_v24]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2022975]) = v58;\nL_001E:\n\tHutongGames.PlayMaker.Actions.GUIAction::OnGUI(this);\n\tv60 = this.floatVariable;\n\tv61 = this.floatVariable == 0;\n\tif (v61) goto L_00AA;\n\tv68 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv173 = HutongGames.PlayMaker.FsmFloat::get_Value(this.topValue);\n\tv183 = HutongGames.PlayMaker.FsmFloat::get_Value(this.bottomValue);\n\tv207 = HutongGames.PlayMaker.FsmString::get_Value(this.sliderStyle);\n\tv209 = System.String::op_Inequality(v207, \"\");\n\tv211 = v209 == 0;\n\tif (v211) goto L_FFFFFFFF;\n\tv216 = HutongGames.PlayMaker.FsmString::get_Value(this.sliderStyle);\n\tgoto L_0053;\nL_0053:\n\tgoto L_005B;\n\tv228 = *([v224 @ X0_v16+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tgoto L_005B;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v219, v177, v43, v44, v45, v46, v47, v183, v49, v50, v51, v52, v53, v54, v55);\nL_005B:\n\tv203 = UnityEngine.GUIStyle::op_Implicit(v217);\n\tv238 = HutongGames.PlayMaker.FsmString::get_Value(this.thumbStyle);\n\tv239 = System.String::op_Inequality(v238, \"\");\n\tv241 = v239 == 0;\n\tif (v241) goto L_FFFFFFFF;\n\tv246 = HutongGames.PlayMaker.FsmString::get_Value(this.thumbStyle);\n\tgoto L_0077;\nL_0077:\n\tgoto L_007F;\n\tv257 = *([v253 @ X0_v24+E0]);\n\tv258 = v257 == 0;\n\tv259 = ~v258;\n\tgoto L_007F;\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v253, v247, v178, v43, v44, v45, v46, v47, v183, v49, v50, v51, v52, v53, v54, v55);\nL_007F:\n\tv266 = UnityEngine.GUIStyle::op_Implicit(v250);\n\tgoto L_0098;\n\tv272 = *([v116 @ X8_v15+E0]);\n\tv273 = v272 == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_0098;\n\tv278 = v116;\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v278, v265, v178, v43, v44, v45, v46, v47, v183, v49, v50, v51, v52, v53, v54, v55);\nL_0098:\n\t// 152 MakeStruct v72 @ AGGB7C8E0_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.rect (UnityEngine.Rect), this.rect.m_YMin (System.Single), this.rect.m_Width (System.Single), this.rect.m_Height (System.Single)\n\tv102 = UnityEngine.GUI::VerticalSlider(v72, v68, v173, v183, v203, v266);\n\tv60.value = v102;\nL_00AA:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			base.OnGUI();
			FsmFloat fsmFloat = floatVariable;
			if (floatVariable != null)
			{
				float value = floatVariable.Value;
				float value2 = topValue.Value;
				float value3 = bottomValue.Value;
				string value4 = sliderStyle.Value;
				string text;
				if (value4 != "")
				{
					string value5 = sliderStyle.Value;
					text = value5;
				}
				else
				{
					text = "verticalslider";
				}
				GUIStyle slider = text;
				string value6 = thumbStyle.Value;
				string text2;
				if (value6 != "")
				{
					string value7 = thumbStyle.Value;
					text2 = value7;
				}
				else
				{
					text2 = "verticalsliderthumb";
				}
				GUIStyle thumb = text2;
				Rect position = default(Rect);
				position.x = rect.x;
				position.y = rect.y;
				position.width = rect.width;
				position.height = rect.height;
				float value8 = GUI.VerticalSlider(position, value, value2, value3, slider, thumb);
				fsmFloat.Value = value8;
			}
		}

		[Token(Token = "0x6000A82")]
		[Address(RVA = "0xB7C918", Offset = "0xB7C918", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUIVerticalSlider()
		{
		}
	}
}
