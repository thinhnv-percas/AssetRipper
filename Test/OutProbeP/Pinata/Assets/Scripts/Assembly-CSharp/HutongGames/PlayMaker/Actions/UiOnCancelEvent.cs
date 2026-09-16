using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760A70", Offset = "0x760A70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760A70", Offset = "0x760A70")]
	[Token(Token = "0x20003C2")]
	public class UiOnCancelEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0AA8", Offset = "0x7D0AA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0AA8", Offset = "0x7D0AA8")]
		[Token(Token = "0x4001DBB")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onCancelEvent;

		[Token(Token = "0x60012BB")]
		[Address(RVA = "0x97EE60", Offset = "0x97EE60", Length = "0xC")]
		public override void Reset()
		{
			gameObject = null;
			onCancelEvent = null;
		}

		[Token(Token = "0x60012BC")]
		[Address(RVA = "0x97EE6C", Offset = "0x97EE6C", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnCancelDelegate;
			Init(EventTriggerType.Cancel, call);
		}

		[Token(Token = "0x60012BD")]
		[Address(RVA = "0x97EEF0", Offset = "0x97EEF0", Length = "0xB8")]
		private void OnCancelDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onCancelEvent);
		}

		[Token(Token = "0x60012BE")]
		[Address(RVA = "0x97EFA8", Offset = "0x97EFA8", Length = "0x8")]
		public UiOnCancelEvent()
		{
		}
	}
}
