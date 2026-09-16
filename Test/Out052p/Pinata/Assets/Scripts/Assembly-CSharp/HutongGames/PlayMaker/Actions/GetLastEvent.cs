using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E6FC", Offset = "0x75E6FC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E6FC", Offset = "0x75E6FC")]
	[Token(Token = "0x2000367")]
	public class GetLastEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAC5C", Offset = "0x7CAC5C")]
		[Token(Token = "0x4001BAE")]
		[FieldOffset(Offset = "0x50")]
		public FsmString storeEvent;

		[Token(Token = "0x60010F2")]
		[Address(RVA = "0xA2F148", Offset = "0xA2F148", Length = "0x8")]
		public override void Reset()
		{
			storeEvent = null;
		}

		[Token(Token = "0x60010F3")]
		[Address(RVA = "0xA2F150", Offset = "0xA2F150", Length = "0x84")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			FsmString fsmString = storeEvent;
			string value;
			if (fsm.LastTransition != null)
			{
				value = fsm.LastTransition.EventName;
			}
			else
			{
				bool flag = storeEvent == null;
				bool flag2 = !flag;
				value = "START";
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			fsmString.Value = value;
			Finish();
		}

		[Token(Token = "0x60010F4")]
		[Address(RVA = "0xA2F1D4", Offset = "0xA2F1D4", Length = "0x8")]
		public GetLastEvent()
		{
		}
	}
}
