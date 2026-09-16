using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7571E8", Offset = "0x7571E8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7571E8", Offset = "0x7571E8")]
	[Token(Token = "0x2000219")]
	public class GUILayoutBeginHorizontal : GUILayoutAction
	{
		[Token(Token = "0x40014F4")]
		[FieldOffset(Offset = "0x60")]
		public FsmTexture image;

		[Token(Token = "0x40014F5")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[Token(Token = "0x40014F6")]
		[FieldOffset(Offset = "0x70")]
		public FsmString tooltip;

		[Token(Token = "0x40014F7")]
		[FieldOffset(Offset = "0x78")]
		public FsmString style;

		[Token(Token = "0x6000AC2")]
		[Address(RVA = "0xB796FC", Offset = "0xB796FC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F02650]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202294C]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.image = 0;\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.tooltip = v47;\n\tv50 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v50;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmString fsmString = "";
			image = null;
			text = fsmString;
			FsmString fsmString2 = "";
			tooltip = fsmString2;
			FsmString fsmString3 = "";
			style = fsmString3;
		}

		[Token(Token = "0x6000AC3")]
		[Address(RVA = "0xB7977C", Offset = "0xB7977C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F0E528]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202294D]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv83 = HutongGames.PlayMaker.FsmTexture::get_Value(this.image);\n\tv124 = HutongGames.PlayMaker.FsmString::get_Value(this.tooltip);\n\tv128 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v128, v48, v83, v124);\n\tv130 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_004A;\n\tv137 = *([v117 @ X8_v12+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_004A;\n\tv145 = v117;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v145, v129, v54, v52, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004A:\n\tv144 = UnityEngine.GUIStyle::op_Implicit(v130);\n\tv148 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::BeginHorizontal(v128, v144, v148);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			string value = text.Value;
			Texture value2 = image.Value;
			string value3 = tooltip.Value;
			GUIContent content = new GUIContent(value, value2, value3);
			string value4 = style.Value;
			GUIStyle gUIStyle = value4;
			GUILayoutOption[] array = base.LayoutOptions;
			GUILayout.BeginHorizontal(content, gUIStyle, array);
		}

		[Token(Token = "0x6000AC4")]
		[Address(RVA = "0xB798A8", Offset = "0xB798A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutBeginHorizontal()
		{
		}
	}
}
