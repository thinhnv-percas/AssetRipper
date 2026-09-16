using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7557D0", Offset = "0x7557D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7557D0", Offset = "0x7557D0")]
	[Token(Token = "0x20001CA")]
	public class GetIPhoneSettings : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AEC40", Offset = "0x7AEC40")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEC40", Offset = "0x7AEC40")]
		[Token(Token = "0x40013A9")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool getScreenCanDarken;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AEC90", Offset = "0x7AEC90")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEC90", Offset = "0x7AEC90")]
		[Token(Token = "0x40013AA")]
		[FieldOffset(Offset = "0x58")]
		public FsmString getUniqueIdentifier;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AECE0", Offset = "0x7AECE0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AECE0", Offset = "0x7AECE0")]
		[Token(Token = "0x40013AB")]
		[FieldOffset(Offset = "0x60")]
		public FsmString getName;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AED30", Offset = "0x7AED30")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AED30", Offset = "0x7AED30")]
		[Token(Token = "0x40013AC")]
		[FieldOffset(Offset = "0x68")]
		public FsmString getModel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AED80", Offset = "0x7AED80")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AED80", Offset = "0x7AED80")]
		[Token(Token = "0x40013AD")]
		[FieldOffset(Offset = "0x70")]
		public FsmString getSystemName;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AEDD0", Offset = "0x7AEDD0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEDD0", Offset = "0x7AEDD0")]
		[Token(Token = "0x40013AE")]
		[FieldOffset(Offset = "0x78")]
		public FsmString getGeneration;

		[Token(Token = "0x600098C")]
		[Address(RVA = "0xA2EDFC", Offset = "0xA2EDFC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.getName = 0;\n\tthis.getSystemName = 0;\n\tthis.getScreenCanDarken = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			getName = null;
			getSystemName = null;
			getScreenCanDarken = null;
		}

		[Token(Token = "0x600098D")]
		[Address(RVA = "0xA2EE0C", Offset = "0xA2EE0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Finish();
		}

		[Token(Token = "0x600098E")]
		[Address(RVA = "0xA2EE14", Offset = "0xA2EE14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetIPhoneSettings()
		{
		}
	}
}
