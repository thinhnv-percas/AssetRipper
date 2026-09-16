using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7628C0", Offset = "0x7628C0")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x7628C0", Offset = "0x7628C0")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x7628C0", Offset = "0x7628C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7628C0", Offset = "0x7628C0")]
	[Token(Token = "0x2000423")]
	public class GetProperty : FsmStateAction
	{
		[Token(Token = "0x4001F97")]
		[FieldOffset(Offset = "0x50")]
		public FsmProperty targetProperty;

		[Token(Token = "0x4001F98")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x600148F")]
		[Address(RVA = "0xA32908", Offset = "0xA32908", Length = "0x74")]
		public override void Reset()
		{
			FsmProperty fsmProperty = new FsmProperty();
			fsmProperty.setProperty = false;
			targetProperty = fsmProperty;
			everyFrame = false;
		}

		[Token(Token = "0x6001490")]
		[Address(RVA = "0xA3297C", Offset = "0xA3297C", Length = "0x4C")]
		public override void OnEnter()
		{
			targetProperty.GetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001491")]
		[Address(RVA = "0xA329C8", Offset = "0xA329C8", Length = "0x1C")]
		public override void OnUpdate()
		{
			targetProperty.GetValue();
		}

		[Token(Token = "0x6001492")]
		[Address(RVA = "0xA329E4", Offset = "0xA329E4", Length = "0x8")]
		public GetProperty()
		{
		}
	}
}
