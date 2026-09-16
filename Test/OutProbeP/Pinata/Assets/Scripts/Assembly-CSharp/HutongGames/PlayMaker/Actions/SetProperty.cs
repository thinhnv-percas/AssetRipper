using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762A0C", Offset = "0x762A0C")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x762A0C", Offset = "0x762A0C")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x762A0C", Offset = "0x762A0C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762A0C", Offset = "0x762A0C")]
	[Token(Token = "0x2000425")]
	public class SetProperty : FsmStateAction
	{
		[Token(Token = "0x4001F9C")]
		[FieldOffset(Offset = "0x50")]
		public FsmProperty targetProperty;

		[Token(Token = "0x4001F9D")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6001497")]
		[Address(RVA = "0x998878", Offset = "0x998878", Length = "0x78")]
		public override void Reset()
		{
			FsmProperty fsmProperty = new FsmProperty();
			fsmProperty.setProperty = true;
			targetProperty = fsmProperty;
			everyFrame = false;
		}

		[Token(Token = "0x6001498")]
		[Address(RVA = "0x9988F0", Offset = "0x9988F0", Length = "0x4C")]
		public override void OnEnter()
		{
			targetProperty.SetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001499")]
		[Address(RVA = "0x99893C", Offset = "0x99893C", Length = "0x1C")]
		public override void OnUpdate()
		{
			targetProperty.SetValue();
		}

		[Token(Token = "0x600149A")]
		[Address(RVA = "0x998958", Offset = "0x998958", Length = "0x8")]
		public SetProperty()
		{
		}
	}
}
