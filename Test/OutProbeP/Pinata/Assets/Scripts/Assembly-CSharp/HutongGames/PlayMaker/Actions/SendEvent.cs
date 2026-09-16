using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E988", Offset = "0x75E988")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x75E988", Offset = "0x75E988")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x75E988", Offset = "0x75E988")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E988", Offset = "0x75E988")]
	[Token(Token = "0x200036F")]
	public class SendEvent : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CAD6C", Offset = "0x7CAD6C")]
		[Token(Token = "0x4001BBA")]
		[FieldOffset(Offset = "0x50")]
		public FsmEventTarget eventTarget;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CADA4", Offset = "0x7CADA4")]
		[Token(Token = "0x4001BBB")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CADF0", Offset = "0x7CADF0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CADF0", Offset = "0x7CADF0")]
		[Token(Token = "0x4001BBC")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat delay;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CAE44", Offset = "0x7CAE44")]
		[Token(Token = "0x4001BBD")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x4001BBE")]
		[FieldOffset(Offset = "0x70")]
		private DelayedEvent delayedEvent;

		[Token(Token = "0x6001123")]
		[Address(RVA = "0xB26F48", Offset = "0xB26F48", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			sendEvent = null;
			delay = null;
			eventTarget = null;
		}

		[Token(Token = "0x6001124")]
		[Address(RVA = "0xB26F58", Offset = "0xB26F58", Length = "0xBC")]
		public override void OnEnter()
		{
			float value = delay.Value;
			if (value < 0.001f)
			{
				Fsm.Event(eventTarget, sendEvent);
				if (!everyFrame)
				{
					Finish();
				}
			}
			else
			{
				float value2 = delay.Value;
				DelayedEvent delayedEvent = Fsm.DelayedEvent(eventTarget, sendEvent, value2);
				this.delayedEvent = delayedEvent;
			}
		}

		[Token(Token = "0x6001125")]
		[Address(RVA = "0xB27014", Offset = "0xB27014", Length = "0x68")]
		public override void OnUpdate()
		{
			if (everyFrame)
			{
				Fsm.Event(eventTarget, sendEvent);
			}
			else if (DelayedEvent.WasSent(delayedEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x6001126")]
		[Address(RVA = "0xB2707C", Offset = "0xB2707C", Length = "0x8")]
		public SendEvent()
		{
		}
	}
}
