using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EB48", Offset = "0x75EB48")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EB48", Offset = "0x75EB48")]
	[Token(Token = "0x2000372")]
	public class SendRandomEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7CB040", Offset = "0x7CB040")]
		[Token(Token = "0x4001BCB")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent[] events;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CB0A8", Offset = "0x7CB0A8")]
		[Token(Token = "0x4001BCC")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] weights;

		[Token(Token = "0x4001BCD")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat delay;

		[Token(Token = "0x4001BCE")]
		[FieldOffset(Offset = "0x68")]
		private DelayedEvent delayedEvent;

		[Token(Token = "0x600112F")]
		[Address(RVA = "0xB27C2C", Offset = "0xB27C2C", Length = "0x144")]
		public override void Reset()
		{
			//IL_00ce: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			FsmEvent[] array = new FsmEvent[3];
			events = array;
			FsmFloat[] array2 = new FsmFloat[3];
			FsmFloat fsmFloat = 1f;
			if (fsmFloat != null)
			{
				object obj = fsmFloat as FsmFloat;
			}
			if (array2.Length != 0)
			{
				array2[0] = fsmFloat;
				FsmFloat fsmFloat2 = 1f;
				if (fsmFloat2 != null)
				{
					object obj2 = fsmFloat2 as FsmFloat;
				}
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj3 = array2.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = fsmFloat2;
					FsmFloat fsmFloat3 = 1f;
					if (fsmFloat3 != null)
					{
						object obj4 = fsmFloat3 as FsmFloat;
					}
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj5 = array2.Length - 2;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[2] = fsmFloat3;
						weights = array2;
						delay = null;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6001130")]
		[Address(RVA = "0xB27D70", Offset = "0xB27D70", Length = "0xF8")]
		public override void OnEnter()
		{
			FsmEvent[] array = events;
			if (array.Length != 0)
			{
				int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(weights);
				if (randomWeightedIndex + 1 != 0)
				{
					float value = delay.Value;
					FsmEvent[] array2 = events;
					if (randomWeightedIndex >= array2.Length)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					if (!(value < 0.001f))
					{
						float value2 = delay.Value;
						DelayedEvent delayedEvent = Fsm.DelayedEvent(array2[randomWeightedIndex], value2);
						this.delayedEvent = delayedEvent;
						return;
					}
					Fsm.Event(array2[randomWeightedIndex]);
				}
			}
			Finish();
		}

		[Token(Token = "0x6001131")]
		[Address(RVA = "0xB27E68", Offset = "0xB27E68", Length = "0x40")]
		public override void OnUpdate()
		{
			if (DelayedEvent.WasSent(delayedEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x6001132")]
		[Address(RVA = "0xB27EA8", Offset = "0xB27EA8", Length = "0x8")]
		public SendRandomEvent()
		{
		}
	}
}
