using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74B900", Offset = "0x74B900")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74B900", Offset = "0x74B900")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74B900", Offset = "0x74B900")]
	[Token(Token = "0x2000005")]
	public class SendDesignEvent : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C09C", Offset = "0x74C09C")]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x50")]
		public FsmString EventID;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C0E8", Offset = "0x74C0E8")]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat EventValue;

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x167ADA8", Offset = "0x167ADA8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEFC88]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B50C]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v42);\n\tv42.useVariable = 0;\n\tthis.EventID = v42;\n\tv49 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v49);\n\tv49.useVariable = 1;\n\tthis.EventValue = v49;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			EventID = fsmString;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			EventValue = fsmFloat;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x167AE44", Offset = "0x167AE44", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.EventValue);\n\tv57 = HutongGames.PlayMaker.FsmString::get_Value(this.EventID);\n\tv59 = v17 == 0;\n\tif (v59) goto L_0021;\n\tGameAnalyticsSDK.Events.GA_Design::NewEvent(v57, 0);\n\tgoto L_002E;\nL_0021:\n\tv85 = HutongGames.PlayMaker.FsmFloat::get_Value(this.EventValue);\n\tGameAnalyticsSDK.Events.GA_Design::NewEvent(v57, v85, 0);\nL_002E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = EventValue.IsNone;
			string value = EventID.Value;
			if (isNone)
			{
				GA_Design.NewEvent(value, null);
			}
			else
			{
				float value2 = EventValue.Value;
				GA_Design.NewEvent(value, value2, null);
			}
			Finish();
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x167AEE0", Offset = "0x167AEE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendDesignEvent()
		{
		}
	}
}
