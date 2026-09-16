using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760B60", Offset = "0x760B60")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760B60", Offset = "0x760B60")]
	[Token(Token = "0x20003C5")]
	public class UiOnDropEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0B98", Offset = "0x7D0B98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0B98", Offset = "0x7D0B98")]
		[Token(Token = "0x4001DBE")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onDropEvent;

		[Token(Token = "0x60012C7")]
		[Address(RVA = "0x97F288", Offset = "0x97F288", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onDropEvent = null;
		}

		[Token(Token = "0x60012C8")]
		[Address(RVA = "0x97F2B0", Offset = "0x97F2B0", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnDropDelegate;
			Init(EventTriggerType.Drop, call);
		}

		[Token(Token = "0x60012C9")]
		[Address(RVA = "0x97F334", Offset = "0x97F334", Length = "0xB8")]
		private void OnDropDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onDropEvent);
		}

		[Token(Token = "0x60012CA")]
		[Address(RVA = "0x97F3EC", Offset = "0x97F3EC", Length = "0x8")]
		public UiOnDropEvent()
		{
		}
	}
}
