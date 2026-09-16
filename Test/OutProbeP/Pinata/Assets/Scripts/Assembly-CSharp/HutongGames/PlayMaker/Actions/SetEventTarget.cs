using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EC38", Offset = "0x75EC38")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75EC38", Offset = "0x75EC38")]
	[Token(Token = "0x2000375")]
	public class SetEventTarget : FsmStateAction
	{
		[Token(Token = "0x4001BE0")]
		[FieldOffset(Offset = "0x50")]
		public FsmEventTarget eventTarget;

		[Token(Token = "0x600113A")]
		[Address(RVA = "0x990764", Offset = "0x990764", Length = "0x4")]
		public override void Reset()
		{
		}

		[Token(Token = "0x600113B")]
		[Address(RVA = "0x990768", Offset = "0x990768", Length = "0x28")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			fsm.EventTarget = eventTarget;
			Finish();
		}

		[Token(Token = "0x600113C")]
		[Address(RVA = "0x990790", Offset = "0x990790", Length = "0x8")]
		public SetEventTarget()
		{
		}
	}
}
