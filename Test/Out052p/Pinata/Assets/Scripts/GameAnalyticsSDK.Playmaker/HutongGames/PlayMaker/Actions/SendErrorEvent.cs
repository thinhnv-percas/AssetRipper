using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74B984", Offset = "0x74B984")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74B984", Offset = "0x74B984")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74B984", Offset = "0x74B984")]
	[Token(Token = "0x2000006")]
	public class SendErrorEvent : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C120", Offset = "0x74C120")]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x4C")]
		public GAErrorSeverity severityType;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C158", Offset = "0x74C158")]
		[RequiredField]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x50")]
		public FsmString Message;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x167AEE8", Offset = "0x167AEE8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF7F28]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B50D]) = v38;\nL_0014:\n\tthis.severityType = 4;\n\tv43 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v43);\n\tv43.useVariable = 0;\n\tthis.Message = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			severityType = GAErrorSeverity.Error;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			Message = fsmString;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x167AF60", Offset = "0x167AF60", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmString::get_Value(this.Message);\n\tGameAnalyticsSDK.Events.GA_Error::NewEvent(this.severityType, v16, 0);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = Message.Value;
			GA_Error.NewEvent(severityType, value, null);
			Finish();
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x167AFB0", Offset = "0x167AFB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendErrorEvent()
		{
		}
	}
}
