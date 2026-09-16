using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757828", Offset = "0x757828")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757828", Offset = "0x757828")]
	[Token(Token = "0x200022D")]
	public class GUILayoutRepeatButton : GUILayoutAction
	{
		[Token(Token = "0x4001532")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2E18", Offset = "0x7B2E18")]
		[Token(Token = "0x4001533")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeButtonState;

		[Token(Token = "0x4001534")]
		[FieldOffset(Offset = "0x70")]
		public FsmTexture image;

		[Token(Token = "0x4001535")]
		[FieldOffset(Offset = "0x78")]
		public FsmString text;

		[Token(Token = "0x4001536")]
		[FieldOffset(Offset = "0x80")]
		public FsmString tooltip;

		[Token(Token = "0x4001537")]
		[FieldOffset(Offset = "0x88")]
		public FsmString style;

		[Token(Token = "0x6000AFD")]
		[Address(RVA = "0xB7B418", Offset = "0xB7B418", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFEEE0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022966]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.sendEvent = 0;\n\tthis.storeButtonState = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.image = 0;\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.tooltip = v47;\n\tv50 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v50;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			sendEvent = null;
			storeButtonState = null;
			FsmString fsmString = "";
			image = null;
			text = fsmString;
			FsmString fsmString2 = "";
			tooltip = fsmString2;
			FsmString fsmString3 = "";
			style = fsmString3;
		}

		[Token(Token = "0x6000AFE")]
		[Address(RVA = "0xB7B49C", Offset = "0xB7B49C", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EED268]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022967]) = v46;\nL_001B:\n\tv50 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv100 = System.String::IsNullOrEmpty(v50);\n\tv136 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv140 = HutongGames.PlayMaker.FsmTexture::get_Value(this.image);\n\tv149 = HutongGames.PlayMaker.FsmString::get_Value(this.tooltip);\n\tv153 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v153, v136, v140, v149);\n\tv155 = v100 == 0;\n\tif (v155) goto L_0057;\n\tv157 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv161 = UnityEngine.GUILayout::RepeatButton(v153, v157);\n\tv165 = v161 == 0;\n\tif (v165) goto L_FFFFFFFF;\nL_0050:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\tgoto L_0076;\nL_0057:\n\tv163 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0068;\n\tv191 = *([v169 @ X8_v16+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0068;\n\tv205 = v169;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v205, v162, v65, v61, v57, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0068:\n\tv199 = UnityEngine.GUIStyle::op_Implicit(v163);\n\tv207 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv179 = UnityEngine.GUILayout::RepeatButton(v153, v199, v207);\n\tv210 = v179 == 0;\n\tv181 = ~v210;\n\tif (v181) goto L_0050;\nL_0076:\n\tv106 = this.storeButtonState;\n\tv106.value = v129;\n\treturn;\n\tv84 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			string value = style.Value;
			bool flag = string.IsNullOrEmpty(value);
			string value2 = text.Value;
			Texture value3 = image.Value;
			string value4 = tooltip.Value;
			GUIContent content = new GUIContent(value2, value3, value4);
			if (flag)
			{
				GUILayoutOption[] array = base.LayoutOptions;
				if (GUILayout.RepeatButton(content, array))
				{
					goto IL_00d2;
				}
			}
			else
			{
				string value5 = style.Value;
				GUIStyle gUIStyle = value5;
				GUILayoutOption[] array2 = base.LayoutOptions;
				if (GUILayout.RepeatButton(content, gUIStyle, array2))
				{
					goto IL_00d2;
				}
			}
			int value6 = 0;
			goto IL_017a;
			IL_017a:
			FsmBool fsmBool = storeButtonState;
			fsmBool.value = (byte)value6 != 0;
			return;
			IL_00d2:
			Fsm.Event(sendEvent);
			value6 = 1;
			goto IL_017a;
		}

		[Token(Token = "0x6000AFF")]
		[Address(RVA = "0xB7B63C", Offset = "0xB7B63C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutRepeatButton()
		{
		}
	}
}
