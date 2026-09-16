using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757328", Offset = "0x757328")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757328", Offset = "0x757328")]
	[Token(Token = "0x200021D")]
	public class GUILayoutButton : GUILayoutAction
	{
		[Token(Token = "0x4001507")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2688", Offset = "0x7B2688")]
		[Token(Token = "0x4001508")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeButtonState;

		[Token(Token = "0x4001509")]
		[FieldOffset(Offset = "0x70")]
		public FsmTexture image;

		[Token(Token = "0x400150A")]
		[FieldOffset(Offset = "0x78")]
		public FsmString text;

		[Token(Token = "0x400150B")]
		[FieldOffset(Offset = "0x80")]
		public FsmString tooltip;

		[Token(Token = "0x400150C")]
		[FieldOffset(Offset = "0x88")]
		public FsmString style;

		[Token(Token = "0x6000ACE")]
		[Address(RVA = "0xB79E3C", Offset = "0xB79E3C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC1610]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022953]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.sendEvent = 0;\n\tthis.storeButtonState = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.image = 0;\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.tooltip = v47;\n\tv50 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v50;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000ACF")]
		[Address(RVA = "0xB79EC0", Offset = "0xB79EC0", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ECEE90]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022954]) = v46;\nL_001B:\n\tv50 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv93 = System.String::IsNullOrEmpty(v50);\n\tv129 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv132 = HutongGames.PlayMaker.FsmTexture::get_Value(this.image);\n\tv141 = HutongGames.PlayMaker.FsmString::get_Value(this.tooltip);\n\tv145 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v145, v129, v132, v141);\n\tv147 = v93 == 0;\n\tif (v147) goto L_0057;\n\tv149 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv153 = UnityEngine.GUILayout::Button(v145, v149);\n\tv157 = v153 == 0;\n\tif (v157) goto L_FFFFFFFF;\nL_0050:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\tgoto L_0076;\nL_0057:\n\tv155 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0068;\n\tv183 = *([v161 @ X8_v16+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0068;\n\tv198 = v161;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v198, v154, v61, v58, v55, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0068:\n\tv191 = UnityEngine.GUIStyle::op_Implicit(v155);\n\tv200 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv171 = UnityEngine.GUILayout::Button(v145, v191, v200);\n\tv203 = v171 == 0;\n\tv173 = ~v203;\n\tif (v173) goto L_0050;\nL_0076:\n\tv99 = this.storeButtonState;\n\tv118 = this.storeButtonState == 0;\n\tif (v118) goto L_0083;\n\tv99.value = v122;\nL_0083:\n\treturn;\n\tv78 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				if (GUILayout.Button(content, array))
				{
					goto IL_00d2;
				}
			}
			else
			{
				string value5 = style.Value;
				GUIStyle gUIStyle = value5;
				GUILayoutOption[] array2 = base.LayoutOptions;
				if (GUILayout.Button(content, gUIStyle, array2))
				{
					goto IL_00d2;
				}
			}
			int value6 = 0;
			goto IL_017e;
			IL_017e:
			FsmBool fsmBool = storeButtonState;
			if (storeButtonState != null)
			{
				fsmBool.value = (byte)value6 != 0;
			}
			return;
			IL_00d2:
			Fsm.Event(sendEvent);
			value6 = 1;
			goto IL_017e;
		}

		[Token(Token = "0x6000AD0")]
		[Address(RVA = "0xB7A060", Offset = "0xB7A060", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutButton()
		{
		}
	}
}
