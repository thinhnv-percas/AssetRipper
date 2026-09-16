using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760E80", Offset = "0x760E80")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760E80", Offset = "0x760E80")]
	[Token(Token = "0x20003CF")]
	public class UiOnSelectEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0EB8", Offset = "0x7D0EB8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0EB8", Offset = "0x7D0EB8")]
		[Token(Token = "0x4001DC8")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onSelectEvent;

		[Token(Token = "0x60012EF")]
		[Address(RVA = "0x9800C0", Offset = "0x9800C0", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onSelectEvent = null;
		}

		[Token(Token = "0x60012F0")]
		[Address(RVA = "0x9800E8", Offset = "0x9800E8", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnSelectDelegate;
			Init(EventTriggerType.Select, call);
		}

		[Token(Token = "0x60012F1")]
		[Address(RVA = "0x98016C", Offset = "0x98016C", Length = "0xB8")]
		private void OnSelectDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onSelectEvent);
		}

		[Token(Token = "0x60012F2")]
		[Address(RVA = "0x980224", Offset = "0x980224", Length = "0x8")]
		public UiOnSelectEvent()
		{
		}
	}
}
