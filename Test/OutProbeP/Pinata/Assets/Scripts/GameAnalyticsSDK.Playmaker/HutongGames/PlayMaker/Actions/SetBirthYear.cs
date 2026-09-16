using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74BB10", Offset = "0x74BB10")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BB10", Offset = "0x74BB10")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74BB10", Offset = "0x74BB10")]
	[Token(Token = "0x2000009")]
	public class SetBirthYear : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C4A8", Offset = "0x74C4A8")]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt BirthYear;

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x167B4EC", Offset = "0x167B4EC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFD0A8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B510]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v42);\n\tv42.useVariable = 0;\n\tthis.BirthYear = v42;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			BirthYear = fsmInt;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x167B55C", Offset = "0x167B55C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmInt::get_Value(this.BirthYear);\n\tGameAnalyticsSDK.Events.GA_Setup::SetBirthYear(v13);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			int value = BirthYear.Value;
			GA_Setup.SetBirthYear(value);
			Finish();
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x167B59C", Offset = "0x167B59C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetBirthYear()
		{
		}
	}
}
