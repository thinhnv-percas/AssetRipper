using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760E30", Offset = "0x760E30")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760E30", Offset = "0x760E30")]
	[Token(Token = "0x20003CE")]
	public class UiOnScrollEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0E68", Offset = "0x7D0E68")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0E68", Offset = "0x7D0E68")]
		[Token(Token = "0x4001DC7")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onScrollEvent;

		[Token(Token = "0x60012EB")]
		[Address(RVA = "0x97FF54", Offset = "0x97FF54", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onScrollEvent = null;
		}

		[Token(Token = "0x60012EC")]
		[Address(RVA = "0x97FF7C", Offset = "0x97FF7C", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnScrollDelegate;
			Init(EventTriggerType.Scroll, call);
		}

		[Token(Token = "0x60012ED")]
		[Address(RVA = "0x980000", Offset = "0x980000", Length = "0xB8")]
		private void OnScrollDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onScrollEvent);
		}

		[Token(Token = "0x60012EE")]
		[Address(RVA = "0x9800B8", Offset = "0x9800B8", Length = "0x8")]
		public UiOnScrollEvent()
		{
		}
	}
}
