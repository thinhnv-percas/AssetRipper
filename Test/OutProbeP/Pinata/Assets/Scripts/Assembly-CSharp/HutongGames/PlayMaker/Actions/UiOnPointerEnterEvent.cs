using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760D40", Offset = "0x760D40")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760D40", Offset = "0x760D40")]
	[Token(Token = "0x20003CB")]
	public class UiOnPointerEnterEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0D78", Offset = "0x7D0D78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0D78", Offset = "0x7D0D78")]
		[Token(Token = "0x4001DC4")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onPointerEnterEvent;

		[Token(Token = "0x60012DF")]
		[Address(RVA = "0x97FB10", Offset = "0x97FB10", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onPointerEnterEvent = null;
		}

		[Token(Token = "0x60012E0")]
		[Address(RVA = "0x97FB38", Offset = "0x97FB38", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnPointerEnterDelegate;
			Init(default(EventTriggerType), call);
		}

		[Token(Token = "0x60012E1")]
		[Address(RVA = "0x97FBBC", Offset = "0x97FBBC", Length = "0xB8")]
		private void OnPointerEnterDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onPointerEnterEvent);
		}

		[Token(Token = "0x60012E2")]
		[Address(RVA = "0x97FC74", Offset = "0x97FC74", Length = "0x8")]
		public UiOnPointerEnterEvent()
		{
		}
	}
}
