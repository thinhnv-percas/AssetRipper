using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755410", Offset = "0x755410")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755410", Offset = "0x755410")]
	[Token(Token = "0x20001BE")]
	public class DebugLog : BaseLogAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE598", Offset = "0x7AE598")]
		[Token(Token = "0x4001384")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE5D0", Offset = "0x7AE5D0")]
		[Token(Token = "0x4001385")]
		[FieldOffset(Offset = "0x50")]
		public FsmString text;

		[Token(Token = "0x6000962")]
		[Address(RVA = "0xA85DF0", Offset = "0xA85DF0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE1C90]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022194]) = v38;\nL_0013:\n\tthis.logLevel = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.text = v43;\n\tHutongGames.PlayMaker.Actions.BaseLogAction::Reset(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			FsmString fsmString = "";
			text = fsmString;
			base.Reset();
		}

		[Token(Token = "0x6000963")]
		[Address(RVA = "0xA85E54", Offset = "0xA85E54", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv40 = System.String::IsNullOrEmpty(v17);\n\tv42 = v40 == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0028;\n\tv78 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tHutongGames.PlayMaker.ActionHelpers::DebugLog(this.fsm, this.logLevel, v78, this.sendToUnityLog);\nL_0028:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = text.Value;
			if (!string.IsNullOrEmpty(value))
			{
				string value2 = text.Value;
				ActionHelpers.DebugLog(Fsm, logLevel, value2, sendToUnityLog);
			}
			Finish();
		}

		[Token(Token = "0x6000964")]
		[Address(RVA = "0xA85ED0", Offset = "0xA85ED0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseLogAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugLog()
		{
		}
	}
}
