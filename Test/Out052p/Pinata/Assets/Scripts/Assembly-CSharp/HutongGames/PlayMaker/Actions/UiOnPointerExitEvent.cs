using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760D90", Offset = "0x760D90")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760D90", Offset = "0x760D90")]
	[Token(Token = "0x20003CC")]
	public class UiOnPointerExitEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0DC8", Offset = "0x7D0DC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0DC8", Offset = "0x7D0DC8")]
		[Token(Token = "0x4001DC5")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onPointerExitEvent;

		[Token(Token = "0x60012E3")]
		[Address(RVA = "0x97FC7C", Offset = "0x97FC7C", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onPointerExitEvent = null;
		}

		[Token(Token = "0x60012E4")]
		[Address(RVA = "0x97FCA4", Offset = "0x97FCA4", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnPointerExitDelegate;
			Init(EventTriggerType.PointerExit, call);
		}

		[Token(Token = "0x60012E5")]
		[Address(RVA = "0x97FD28", Offset = "0x97FD28", Length = "0xB8")]
		private void OnPointerExitDelegate(BaseEventData data)
		{
			if (data != null)
			{
				PointerEventData pointerEventData = data as PointerEventData;
				if (pointerEventData == null)
				{
					throw new InvalidCastException();
				}
			}
			UiGetLastPointerDataInfo.lastPointerEventData = (PointerEventData)data;
			SendEvent(eventTarget, onPointerExitEvent);
		}

		[Token(Token = "0x60012E6")]
		[Address(RVA = "0x97FDE0", Offset = "0x97FDE0", Length = "0x8")]
		public UiOnPointerExitEvent()
		{
		}
	}
}
