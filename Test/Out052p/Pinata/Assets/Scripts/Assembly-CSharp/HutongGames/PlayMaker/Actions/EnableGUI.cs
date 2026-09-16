using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7568BC", Offset = "0x7568BC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7568BC", Offset = "0x7568BC")]
	[Token(Token = "0x20001FD")]
	public class EnableGUI : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1BD4", Offset = "0x7B1BD4")]
		[Token(Token = "0x4001498")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool enableGUI;

		[Token(Token = "0x6000A65")]
		[Address(RVA = "0xB74770", Offset = "0xB74770", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.enableGUI = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = true;
			enableGUI = fsmBool;
		}

		[Token(Token = "0x6000A66")]
		[Address(RVA = "0xB7479C", Offset = "0xB7479C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECF3C0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202291B]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = PlayMakerGUI::get_Instance();\n\tv59 = HutongGames.PlayMaker.FsmBool::get_Value(this.enableGUI);\n\tUnityEngine.Behaviour::set_enabled(v53, v59);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			PlayMakerGUI instance = PlayMakerGUI.Instance;
			bool value = enableGUI.Value;
			instance.enabled = value;
			Finish();
		}

		[Token(Token = "0x6000A67")]
		[Address(RVA = "0xB74840", Offset = "0xB74840", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnableGUI()
		{
		}
	}
}
