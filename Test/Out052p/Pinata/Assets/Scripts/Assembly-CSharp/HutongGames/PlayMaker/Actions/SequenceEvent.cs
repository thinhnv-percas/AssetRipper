using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EB98", Offset = "0x75EB98")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EB98", Offset = "0x75EB98")]
	[Token(Token = "0x2000373")]
	public class SequenceEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CB0C0", Offset = "0x7CB0C0")]
		[Token(Token = "0x4001BCF")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat delay;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB0D8", Offset = "0x7CB0D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB0D8", Offset = "0x7CB0D8")]
		[Token(Token = "0x4001BD0")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool reset;

		[Token(Token = "0x4001BD1")]
		[FieldOffset(Offset = "0x60")]
		private DelayedEvent delayedEvent;

		[Token(Token = "0x4001BD2")]
		[FieldOffset(Offset = "0x68")]
		private int eventIndex;

		[Token(Token = "0x6001133")]
		[Address(RVA = "0xB28334", Offset = "0xB28334", Length = "0x8")]
		public override void Reset()
		{
			delay = null;
		}

		[Token(Token = "0x6001134")]
		[Address(RVA = "0xB2833C", Offset = "0xB2833C", Length = "0x120")]
		public override void OnEnter()
		{
			if (reset.Value)
			{
				FsmBool fsmBool = reset;
				eventIndex = 0;
				fsmBool.value = false;
			}
			FsmState state = State;
			FsmTransition[] transitions = state.Transitions;
			if (transitions.Length >= 1)
			{
				int num = eventIndex;
				if (eventIndex >= transitions.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				FsmTransition fsmTransition = transitions[num];
				float value = delay.Value;
				if (value < 0.001f)
				{
					Fsm.Event(fsmTransition.FsmEvent);
					Finish();
				}
				else
				{
					float value2 = delay.Value;
					DelayedEvent delayedEvent = Fsm.DelayedEvent(fsmTransition.FsmEvent, value2);
					this.delayedEvent = delayedEvent;
				}
				int num2 = eventIndex + 1;
				int num3 = ((num2 != transitions.Length) ? (eventIndex + 1) : 0);
				eventIndex = num3;
			}
		}

		[Token(Token = "0x6001135")]
		[Address(RVA = "0xB2845C", Offset = "0xB2845C", Length = "0x40")]
		public override void OnUpdate()
		{
			if (DelayedEvent.WasSent(delayedEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x6001136")]
		[Address(RVA = "0xB2849C", Offset = "0xB2849C", Length = "0x8")]
		public SequenceEvent()
		{
		}
	}
}
