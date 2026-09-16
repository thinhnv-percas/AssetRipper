using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756994", Offset = "0x756994")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756994", Offset = "0x756994")]
	[Token(Token = "0x2000200")]
	public class GUIButton : GUIContentAction
	{
		[Token(Token = "0x40014A0")]
		[FieldOffset(Offset = "0xB8")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1C30", Offset = "0x7B1C30")]
		[Token(Token = "0x40014A1")]
		[FieldOffset(Offset = "0xC0")]
		public FsmBool storeButtonState;

		[Token(Token = "0x6000A6D")]
		[Address(RVA = "0xB7815C", Offset = "0xB7815C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF9510]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202293C]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUIContentAction::Reset(this);\n\tthis.sendEvent = 0;\n\tthis.storeButtonState = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Button\");\n\tthis.style = v44;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			sendEvent = null;
			storeButtonState = null;
			FsmString fsmString = "Button";
			style = fsmString;
		}

		[Token(Token = "0x6000A6E")]
		[Address(RVA = "0xB78244", Offset = "0xB78244", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EB2030]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202293D]) = v48;\nL_0019:\n\tHutongGames.PlayMaker.Actions.GUIContentAction::OnGUI(this);\n\tv58 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0034;\n\tv98 = *([v94 @ X8_v6+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0034;\n\tv143 = v94;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v143, v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0034:\n\tv107 = UnityEngine.GUIStyle::op_Implicit(v58);\n\tgoto L_004A;\n\tv149 = *([v88 @ X8_v9+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_004A;\n\tv157 = v88;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v157, v106, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_004A:\n\t// 74 MakeStruct v61 @ AGGB78320_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.rect (UnityEngine.Rect), this.rect.m_YMin (System.Single), this.rect.m_Width (System.Single), this.rect.m_Height (System.Single)\n\tv156 = UnityEngine.GUI::Button(v61, this.content, v107);\n\tv159 = v156 == 0;\n\tif (v159) goto L_FFFFFFFF;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\tgoto L_0058;\nL_0058:\n\tv118 = this.storeButtonState;\n\tv134 = this.storeButtonState == 0;\n\tif (v134) goto L_0066;\n\tv118.value = v138;\nL_0066:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			base.OnGUI();
			string value = style.Value;
			GUIStyle gUIStyle = value;
			Rect position = default(Rect);
			position.x = rect.x;
			position.y = rect.y;
			position.width = rect.width;
			position.height = rect.height;
			int value2;
			if (GUI.Button(position, content, gUIStyle))
			{
				Fsm.Event(sendEvent);
				value2 = 1;
			}
			else
			{
				value2 = 0;
			}
			FsmBool fsmBool = storeButtonState;
			if (storeButtonState != null)
			{
				fsmBool.value = (byte)value2 != 0;
			}
		}

		[Token(Token = "0x6000A6F")]
		[Address(RVA = "0xB78370", Offset = "0xB78370", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUIButton()
		{
		}
	}
}
