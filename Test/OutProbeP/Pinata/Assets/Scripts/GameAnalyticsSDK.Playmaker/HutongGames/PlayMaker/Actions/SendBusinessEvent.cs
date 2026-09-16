using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74B7F8", Offset = "0x74B7F8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74B7F8", Offset = "0x74B7F8")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74B7F8", Offset = "0x74B7F8")]
	[Token(Token = "0x2000003")]
	public class SendBusinessEvent : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BD20", Offset = "0x74BD20")]
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x50")]
		public FsmString Currency;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BD6C", Offset = "0x74BD6C")]
		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt Amount;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BDB8", Offset = "0x74BDB8")]
		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x60")]
		public FsmString ItemType;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BE04", Offset = "0x74BE04")]
		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x68")]
		public FsmString ItemID;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BE50", Offset = "0x74BE50")]
		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x70")]
		public FsmString CartType;

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x167A980", Offset = "0x167A980", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE5760]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202B50A]) = v40;\nL_0017:\n\tv44 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v44);\n\tv44.useVariable = 0;\n\tthis.Currency = v44;\n\tv51 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v51);\n\tv51.useVariable = 0;\n\tthis.Amount = v51;\n\tv58 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v58);\n\tv58.useVariable = 0;\n\tthis.ItemType = v58;\n\tv59 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v59);\n\tv59.useVariable = 0;\n\tthis.ItemID = v59;\n\tv60 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v60);\n\tv60.useVariable = 0;\n\tthis.CartType = v60;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			Currency = fsmString;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			Amount = fsmInt;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			ItemType = fsmString2;
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			ItemID = fsmString3;
			FsmString fsmString4 = new FsmString();
			fsmString4.useVariable = false;
			CartType = fsmString4;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x167AA80", Offset = "0x167AA80", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = HutongGames.PlayMaker.FsmString::get_Value(this.Currency);\n\tv59 = HutongGames.PlayMaker.FsmInt::get_Value(this.Amount);\n\tv72 = HutongGames.PlayMaker.FsmString::get_Value(this.ItemType);\n\tv73 = HutongGames.PlayMaker.FsmString::get_Value(this.ItemID);\n\tv107 = HutongGames.PlayMaker.FsmString::get_Value(this.CartType);\n\tGameAnalyticsSDK.GameAnalytics::NewBusinessEvent(v21, v59, v72, v73, v107);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv39 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = Currency.Value;
			int value2 = Amount.Value;
			string value3 = ItemType.Value;
			string value4 = ItemID.Value;
			string value5 = CartType.Value;
			GameAnalytics.NewBusinessEvent(value, value2, value3, value4, value5);
			Finish();
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x167AB4C", Offset = "0x167AB4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendBusinessEvent()
		{
		}
	}
}
