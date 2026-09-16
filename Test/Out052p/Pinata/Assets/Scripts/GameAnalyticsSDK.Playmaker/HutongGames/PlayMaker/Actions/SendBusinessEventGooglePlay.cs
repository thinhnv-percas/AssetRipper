using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74B87C", Offset = "0x74B87C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74B87C", Offset = "0x74B87C")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74B87C", Offset = "0x74B87C")]
	[Token(Token = "0x2000004")]
	public class SendBusinessEventGooglePlay : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BE9C", Offset = "0x74BE9C")]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x50")]
		public FsmString Currency;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BEE8", Offset = "0x74BEE8")]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt Amount;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BF34", Offset = "0x74BF34")]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x60")]
		public FsmString ItemType;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BF80", Offset = "0x74BF80")]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x68")]
		public FsmString ItemID;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BFCC", Offset = "0x74BFCC")]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x70")]
		public FsmString CartType;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C018", Offset = "0x74C018")]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x78")]
		public FsmString Receipt;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C050", Offset = "0x74C050")]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x80")]
		public FsmString Signature;

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x167AB54", Offset = "0x167AB54", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA6AD0]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202B50B]) = v40;\nL_0017:\n\tv44 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v44);\n\tv44.useVariable = 0;\n\tthis.Currency = v44;\n\tv51 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v51);\n\tv51.useVariable = 0;\n\tthis.Amount = v51;\n\tv60 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v60);\n\tv60.useVariable = 0;\n\tthis.ItemType = v60;\n\tv61 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v61);\n\tv61.useVariable = 0;\n\tthis.ItemID = v61;\n\tv62 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v62);\n\tv62.useVariable = 0;\n\tthis.CartType = v62;\n\tv63 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v63);\n\tv63.useVariable = 0;\n\tthis.Receipt = v63;\n\tv64 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v64);\n\tv64.useVariable = 0;\n\tthis.Signature = v64;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			FsmString fsmString5 = new FsmString();
			fsmString5.useVariable = false;
			Receipt = fsmString5;
			FsmString fsmString6 = new FsmString();
			fsmString6.useVariable = false;
			Signature = fsmString6;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x167AC94", Offset = "0x167AC94", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = HutongGames.PlayMaker.FsmString::get_Value(this.Currency);\n\tv67 = HutongGames.PlayMaker.FsmInt::get_Value(this.Amount);\n\tv88 = HutongGames.PlayMaker.FsmString::get_Value(this.ItemType);\n\tv89 = HutongGames.PlayMaker.FsmString::get_Value(this.ItemID);\n\tv90 = HutongGames.PlayMaker.FsmString::get_Value(this.CartType);\n\tv91 = HutongGames.PlayMaker.FsmString::get_Value(this.Receipt);\n\tv135 = HutongGames.PlayMaker.FsmString::get_Value(this.Signature);\n\tGameAnalyticsSDK.GameAnalytics::NewBusinessEventGooglePlay(v25, v67, v88, v89, v90, v91, v135);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv47 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = Currency.Value;
			int value2 = Amount.Value;
			string value3 = ItemType.Value;
			string value4 = ItemID.Value;
			string value5 = CartType.Value;
			string value6 = Receipt.Value;
			string value7 = Signature.Value;
			GameAnalytics.NewBusinessEventGooglePlay(value, value2, value3, value4, value5, value6, value7);
			Finish();
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x167ADA0", Offset = "0x167ADA0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendBusinessEventGooglePlay()
		{
		}
	}
}
