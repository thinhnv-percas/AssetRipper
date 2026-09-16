using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760C50", Offset = "0x760C50")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760C50", Offset = "0x760C50")]
	[Token(Token = "0x20003C8")]
	public class UiOnMoveEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0C88", Offset = "0x7D0C88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0C88", Offset = "0x7D0C88")]
		[Token(Token = "0x4001DC1")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onMoveEvent;

		[Token(Token = "0x60012D3")]
		[Address(RVA = "0x97F6CC", Offset = "0x97F6CC", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onMoveEvent = null;
		}

		[Token(Token = "0x60012D4")]
		[Address(RVA = "0x97F6F4", Offset = "0x97F6F4", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnMoveDelegate;
			Init(EventTriggerType.Move, call);
		}

		[Token(Token = "0x60012D5")]
		[Address(RVA = "0x97F778", Offset = "0x97F778", Length = "0xB8")]
		private void OnMoveDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onMoveEvent);
		}

		[Token(Token = "0x60012D6")]
		[Address(RVA = "0x97F830", Offset = "0x97F830", Length = "0x8")]
		public UiOnMoveEvent()
		{
		}
	}
}
