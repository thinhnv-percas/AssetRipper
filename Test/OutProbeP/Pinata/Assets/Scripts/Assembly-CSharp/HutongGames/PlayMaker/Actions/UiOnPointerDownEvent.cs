using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760CF0", Offset = "0x760CF0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760CF0", Offset = "0x760CF0")]
	[Token(Token = "0x20003CA")]
	public class UiOnPointerDownEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0D28", Offset = "0x7D0D28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0D28", Offset = "0x7D0D28")]
		[Token(Token = "0x4001DC3")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onPointerDownEvent;

		[Token(Token = "0x60012DB")]
		[Address(RVA = "0x97F9A4", Offset = "0x97F9A4", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onPointerDownEvent = null;
		}

		[Token(Token = "0x60012DC")]
		[Address(RVA = "0x97F9CC", Offset = "0x97F9CC", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnPointerDownDelegate;
			Init(EventTriggerType.PointerDown, call);
		}

		[Token(Token = "0x60012DD")]
		[Address(RVA = "0x97FA50", Offset = "0x97FA50", Length = "0xB8")]
		private void OnPointerDownDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onPointerDownEvent);
		}

		[Token(Token = "0x60012DE")]
		[Address(RVA = "0x97FB08", Offset = "0x97FB08", Length = "0x8")]
		public UiOnPointerDownEvent()
		{
		}
	}
}
