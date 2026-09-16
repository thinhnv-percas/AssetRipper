using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74BA8C", Offset = "0x74BA8C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BA8C", Offset = "0x74BA8C")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74BA8C", Offset = "0x74BA8C")]
	[Token(Token = "0x2000008")]
	public class SendResourceEvent : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C308", Offset = "0x74C308")]
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x50")]
		public FsmString ResourceFlowTypeAsString;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C340", Offset = "0x74C340")]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x58")]
		public GAResourceFlowType ResourceFlowType;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C378", Offset = "0x74C378")]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x60")]
		public FsmString ResourceCurrency;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C3C4", Offset = "0x74C3C4")]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat Amount;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C410", Offset = "0x74C410")]
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x70")]
		public FsmString ItemType;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C45C", Offset = "0x74C45C")]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x78")]
		public FsmString ItemID;

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x167B344", Offset = "0x167B344", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EFF960]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202B50F]) = v40;\nL_0015:\n\tthis.ResourceFlowType = 1;\n\tv45 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v45);\n\tv45.useVariable = 0;\n\tthis.ResourceCurrency = v45;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.Amount = v52;\n\tv58 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v58);\n\tv58.useVariable = 0;\n\tthis.ItemType = v58;\n\tv59 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v59);\n\tv59.useVariable = 0;\n\tthis.ItemID = v59;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			ResourceFlowType = GAResourceFlowType.Source;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			ResourceCurrency = fsmString;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			Amount = fsmFloat;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			ItemType = fsmString2;
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			ItemID = fsmString3;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x167B42C", Offset = "0x167B42C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = HutongGames.PlayMaker.FsmString::get_Value(this.ResourceCurrency);\n\tv27 = HutongGames.PlayMaker.FsmFloat::get_Value(this.Amount);\n\tv69 = HutongGames.PlayMaker.FsmString::get_Value(this.ItemType);\n\tv105 = HutongGames.PlayMaker.FsmString::get_Value(this.ItemID);\n\tGameAnalyticsSDK.Events.GA_Resource::NewEvent(this.ResourceFlowType, v22, v27, v69, v105, 0);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = ResourceCurrency.Value;
			float value2 = Amount.Value;
			string value3 = ItemType.Value;
			string value4 = ItemID.Value;
			GA_Resource.NewEvent(ResourceFlowType, value, value2, value3, value4, null);
			Finish();
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x167B4E4", Offset = "0x167B4E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendResourceEvent()
		{
		}
	}
}
