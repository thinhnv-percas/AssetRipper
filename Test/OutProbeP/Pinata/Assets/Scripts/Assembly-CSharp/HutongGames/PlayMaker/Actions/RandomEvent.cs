using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E8B0", Offset = "0x75E8B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E8B0", Offset = "0x75E8B0")]
	[Token(Token = "0x200036C")]
	public class RandomEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CAC94", Offset = "0x7CAC94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAC94", Offset = "0x7CAC94")]
		[Token(Token = "0x4001BB1")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat delay;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CACE8", Offset = "0x7CACE8")]
		[Token(Token = "0x4001BB2")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool noRepeat;

		[Token(Token = "0x4001BB3")]
		[FieldOffset(Offset = "0x60")]
		private DelayedEvent delayedEvent;

		[Token(Token = "0x4001BB4")]
		[FieldOffset(Offset = "0x68")]
		private int randomEventIndex;

		[Token(Token = "0x4001BB5")]
		[FieldOffset(Offset = "0x6C")]
		private int lastEventIndex;

		[Token(Token = "0x6001101")]
		[Address(RVA = "0xB1CA9C", Offset = "0xB1CA9C", Length = "0x30")]
		public override void Reset()
		{
			delay = null;
			FsmBool fsmBool = false;
			noRepeat = fsmBool;
		}

		[Token(Token = "0x6001102")]
		[Address(RVA = "0xB1CACC", Offset = "0xB1CACC", Length = "0xF4")]
		public override void OnEnter()
		{
			FsmState state = State;
			FsmTransition[] transitions = state.Transitions;
			if (transitions.Length != 0)
			{
				if (lastEventIndex + 1 == 0)
				{
					int num = UnityEngine.Random.Range(0, transitions.Length);
					lastEventIndex = num;
				}
				float value = delay.Value;
				FsmEvent randomEvent = GetRandomEvent();
				if (value < 0.001f)
				{
					Fsm.Event(randomEvent);
					Finish();
				}
				else
				{
					float value2 = delay.Value;
					DelayedEvent delayedEvent = Fsm.DelayedEvent(randomEvent, value2);
					this.delayedEvent = delayedEvent;
				}
			}
		}

		[Token(Token = "0x6001103")]
		[Address(RVA = "0xB1CC94", Offset = "0xB1CC94", Length = "0x40")]
		public override void OnUpdate()
		{
			if (DelayedEvent.WasSent(delayedEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x6001104")]
		[Address(RVA = "0xB1CBC0", Offset = "0xB1CBC0", Length = "0xD4")]
		private FsmEvent GetRandomEvent()
		{
			FsmState state = State;
			int num2;
			while (true)
			{
				FsmTransition[] transitions = state.Transitions;
				int num = UnityEngine.Random.Range(0, transitions.Length);
				randomEventIndex = num;
				bool value = noRepeat.Value;
				state = State;
				if (value)
				{
					FsmTransition[] transitions2 = state.Transitions;
					if (transitions2.Length < 2 || randomEventIndex != lastEventIndex)
					{
						num2 = randomEventIndex;
						lastEventIndex = randomEventIndex;
						break;
					}
					continue;
				}
				num2 = randomEventIndex;
				lastEventIndex = randomEventIndex;
				break;
			}
			FsmTransition[] transitions3 = state.Transitions;
			if (num2 < transitions3.Length)
			{
				FsmTransition fsmTransition = transitions3[num2];
				return fsmTransition.FsmEvent;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6001105")]
		[Address(RVA = "0xB1CCD4", Offset = "0xB1CCD4", Length = "0x10")]
		public RandomEvent()
		{
			lastEventIndex = -1;
		}
	}
}
