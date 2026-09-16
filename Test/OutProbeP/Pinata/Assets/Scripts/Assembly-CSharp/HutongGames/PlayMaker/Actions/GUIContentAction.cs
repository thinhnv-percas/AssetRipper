using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7569E4", Offset = "0x7569E4")]
	[Token(Token = "0x2000201")]
	public abstract class GUIContentAction : GUIAction
	{
		[Token(Token = "0x40014A2")]
		[FieldOffset(Offset = "0x90")]
		public FsmTexture image;

		[Token(Token = "0x40014A3")]
		[FieldOffset(Offset = "0x98")]
		public FsmString text;

		[Token(Token = "0x40014A4")]
		[FieldOffset(Offset = "0xA0")]
		public FsmString tooltip;

		[Token(Token = "0x40014A5")]
		[FieldOffset(Offset = "0xA8")]
		public FsmString style;

		[Token(Token = "0x40014A6")]
		[FieldOffset(Offset = "0xB0")]
		internal GUIContent content;

		[Token(Token = "0x6000A70")]
		[Address(RVA = "0xB781C0", Offset = "0xB781C0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB9B80]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202293E]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUIAction::Reset(this);\n\tthis.image = 0;\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.tooltip = v47;\n\tv50 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v50;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			image = null;
			FsmString fsmString = "";
			text = fsmString;
			FsmString fsmString2 = "";
			tooltip = fsmString2;
			FsmString fsmString3 = "";
			style = fsmString3;
		}

		[Token(Token = "0x6000A71")]
		[Address(RVA = "0xB78074", Offset = "0xB78074", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFF4A8]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202293F]) = v44;\nL_0017:\n\tHutongGames.PlayMaker.Actions.GUIAction::OnGUI(this);\n\tv49 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv67 = HutongGames.PlayMaker.FsmTexture::get_Value(this.image);\n\tv102 = HutongGames.PlayMaker.FsmString::get_Value(this.tooltip);\n\tv90 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v90, v49, v67, v102);\n\tthis.content = v90;\n\treturn;\n\tv55 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			base.OnGUI();
			string value = text.Value;
			Texture value2 = image.Value;
			string value3 = tooltip.Value;
			GUIContent gUIContent = new GUIContent(value, value2, value3);
			content = gUIContent;
		}

		[Token(Token = "0x6000A72")]
		[Address(RVA = "0xB78154", Offset = "0xB78154", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal GUIContentAction()
		{
		}
	}
}
