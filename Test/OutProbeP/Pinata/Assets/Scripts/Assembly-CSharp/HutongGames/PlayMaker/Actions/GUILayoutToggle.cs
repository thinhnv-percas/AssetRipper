using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757968", Offset = "0x757968")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757968", Offset = "0x757968")]
	[Token(Token = "0x2000231")]
	public class GUILayoutToggle : GUILayoutAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2EB0", Offset = "0x7B2EB0")]
		[Token(Token = "0x400153F")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeButtonState;

		[Token(Token = "0x4001540")]
		[FieldOffset(Offset = "0x68")]
		public FsmTexture image;

		[Token(Token = "0x4001541")]
		[FieldOffset(Offset = "0x70")]
		public FsmString text;

		[Token(Token = "0x4001542")]
		[FieldOffset(Offset = "0x78")]
		public FsmString tooltip;

		[Token(Token = "0x4001543")]
		[FieldOffset(Offset = "0x80")]
		public FsmString style;

		[Token(Token = "0x4001544")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent changedEvent;

		[Token(Token = "0x6000B09")]
		[Address(RVA = "0xB7BA5C", Offset = "0xB7BA5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE46A8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202296C]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.storeButtonState = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.image = 0;\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.tooltip = v47;\n\tv52 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Toggle\");\n\tthis.style = v52;\n\tthis.changedEvent = 0;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			storeButtonState = null;
			FsmString fsmString = "";
			image = null;
			text = fsmString;
			FsmString fsmString2 = "";
			tooltip = fsmString2;
			FsmString fsmString3 = "Toggle";
			style = fsmString3;
			changedEvent = null;
		}

		[Token(Token = "0x6000B0A")]
		[Address(RVA = "0xB7BAE8", Offset = "0xB7BAE8", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EC7E90]);\n\tv33 = *([v32 @ X8_v23]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202296D]) = v52;\nL_0020:\n\tgoto L_0027;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0027;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0027:\n\tv67 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv71 = this.storeButtonState;\n\tv75 = HutongGames.PlayMaker.FsmBool::get_Value(this.storeButtonState);\n\tv86 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv87 = HutongGames.PlayMaker.FsmTexture::get_Value(this.image);\n\tv182 = HutongGames.PlayMaker.FsmString::get_Value(this.tooltip);\n\tv186 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v186, v86, v87, v182);\n\tv188 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0068;\n\tv196 = *([v192 @ X8_v15+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tif (v198) goto L_0068;\n\tv205 = v192;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v205, v187, v109, v106, v103, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0068:\n\tv204 = UnityEngine.GUIStyle::op_Implicit(v188);\n\tv207 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv209 = UnityEngine.GUILayout::Toggle(v75, v186, v204, v207);\n\tv71.value = v209;\n\tv211 = UnityEngine.GUI::get_changed();\n\tv213 = v211 == 0;\n\tif (v213) goto L_0092;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\tUnityEngine.GUIUtility::ExitGUI();\n\treturn;\nL_0092:\n\tgoto L_00A6;\n\tv218 = *([v214 @ X0_v32+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_00A6;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v214, v119, v110, v107, v104, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00A6:\n\tUnityEngine.GUI::set_changed(v67);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool changed = GUI.changed;
			GUI.changed = false;
			FsmBool fsmBool = storeButtonState;
			bool value = storeButtonState.Value;
			string value2 = text.Value;
			Texture value3 = image.Value;
			string value4 = tooltip.Value;
			GUIContent content = new GUIContent(value2, value3, value4);
			string value5 = style.Value;
			GUIStyle gUIStyle = value5;
			GUILayoutOption[] array = base.LayoutOptions;
			bool value6 = GUILayout.Toggle(value, content, gUIStyle, array);
			fsmBool.value = value6;
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

		[Token(Token = "0x6000B0B")]
		[Address(RVA = "0xB7BCE4", Offset = "0xB7BCE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutToggle()
		{
		}
	}
}
