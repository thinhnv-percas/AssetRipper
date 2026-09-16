using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760CA0", Offset = "0x760CA0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760CA0", Offset = "0x760CA0")]
	[Token(Token = "0x20003C9")]
	public class UiOnPointerClickEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0CD8", Offset = "0x7D0CD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0CD8", Offset = "0x7D0CD8")]
		[Token(Token = "0x4001DC2")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onPointerClickEvent;

		[Token(Token = "0x60012D7")]
		[Address(RVA = "0x97F838", Offset = "0x97F838", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onPointerClickEvent = null;
		}

		[Token(Token = "0x60012D8")]
		[Address(RVA = "0x97F860", Offset = "0x97F860", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnPointerClickDelegate;
			Init(EventTriggerType.PointerClick, call);
		}

		[Token(Token = "0x60012D9")]
		[Address(RVA = "0x97F8E4", Offset = "0x97F8E4", Length = "0xB8")]
		private void OnPointerClickDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onPointerClickEvent);
		}

		[Token(Token = "0x60012DA")]
		[Address(RVA = "0x97F99C", Offset = "0x97F99C", Length = "0x8")]
		public UiOnPointerClickEvent()
		{
		}
	}
}
