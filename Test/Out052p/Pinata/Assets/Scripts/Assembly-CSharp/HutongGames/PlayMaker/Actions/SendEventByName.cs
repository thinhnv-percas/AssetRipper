using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EA84", Offset = "0x75EA84")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75EA84", Offset = "0x75EA84")]
	[Token(Token = "0x2000370")]
	public class SendEventByName : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CAE7C", Offset = "0x7CAE7C")]
		[Token(Token = "0x4001BBF")]
		[FieldOffset(Offset = "0x50")]
		public FsmEventTarget eventTarget;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CAEB4", Offset = "0x7CAEB4")]
		[Token(Token = "0x4001BC0")]
		[FieldOffset(Offset = "0x58")]
		public FsmString sendEvent;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CAF00", Offset = "0x7CAF00")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CAF00", Offset = "0x7CAF00")]
		[Token(Token = "0x4001BC1")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat delay;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CAF54", Offset = "0x7CAF54")]
		[Token(Token = "0x4001BC2")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x4001BC3")]
		[FieldOffset(Offset = "0x70")]
		private DelayedEvent delayedEvent;

		[Token(Token = "0x6001127")]
		[Address(RVA = "0xB27084", Offset = "0xB27084", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			sendEvent = null;
			delay = null;
			eventTarget = null;
		}

		[Token(Token = "0x6001128")]
		[Address(RVA = "0xB27094", Offset = "0xB27094", Length = "0x138")]
		public override void OnEnter()
		{
			float value = delay.Value;
			string value2 = sendEvent.Value;
			if (value < 0.001f)
			{
				Fsm.Event(eventTarget, value2);
				if (!everyFrame)
				{
					Finish();
				}
			}
			else
			{
				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(value2);
				float value3 = delay.Value;
				DelayedEvent delayedEvent = Fsm.DelayedEvent(eventTarget, fsmEvent, value3);
				this.delayedEvent = delayedEvent;
			}
		}

		[Token(Token = "0x6001129")]
		[Address(RVA = "0xB271CC", Offset = "0xB271CC", Length = "0x8C")]
		public override void OnUpdate()
		{
			if (everyFrame)
			{
				string value = sendEvent.Value;
				Fsm.Event(eventTarget, value);
			}
			else if (DelayedEvent.WasSent(delayedEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x600112A")]
		[Address(RVA = "0xB27258", Offset = "0xB27258", Length = "0x8")]
		public SendEventByName()
		{
		}
	}
}
