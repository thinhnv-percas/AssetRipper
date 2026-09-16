using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760BB0", Offset = "0x760BB0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760BB0", Offset = "0x760BB0")]
	[Token(Token = "0x20003C6")]
	public class UiOnEndDragEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0BE8", Offset = "0x7D0BE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0BE8", Offset = "0x7D0BE8")]
		[Token(Token = "0x4001DBF")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onEndDragEvent;

		[Token(Token = "0x60012CB")]
		[Address(RVA = "0x97F3F4", Offset = "0x97F3F4", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onEndDragEvent = null;
		}

		[Token(Token = "0x60012CC")]
		[Address(RVA = "0x97F41C", Offset = "0x97F41C", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnEndDragDelegate;
			Init(EventTriggerType.EndDrag, call);
		}

		[Token(Token = "0x60012CD")]
		[Address(RVA = "0x97F4A0", Offset = "0x97F4A0", Length = "0xB8")]
		private void OnEndDragDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onEndDragEvent);
		}

		[Token(Token = "0x60012CE")]
		[Address(RVA = "0x97F558", Offset = "0x97F558", Length = "0x8")]
		public UiOnEndDragEvent()
		{
		}
	}
}
