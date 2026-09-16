using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74BC18", Offset = "0x74BC18")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BC18", Offset = "0x74BC18")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74BC18", Offset = "0x74BC18")]
	[Token(Token = "0x200000C")]
	public class SetFacebookID : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C58C", Offset = "0x74C58C")]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x50")]
		public FsmString FacebookID;

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x167B6B8", Offset = "0x167B6B8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDD4A8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B512]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v42);\n\tv42.useVariable = 0;\n\tthis.FacebookID = v42;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			FacebookID = fsmString;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x167B728", Offset = "0x167B728", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmString::get_Value(this.FacebookID);\n\tGameAnalyticsSDK.Events.GA_Setup::SetFacebookId(v13);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = FacebookID.Value;
			GA_Setup.SetFacebookId(value);
			Finish();
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x167B768", Offset = "0x167B768", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFacebookID()
		{
		}
	}
}
