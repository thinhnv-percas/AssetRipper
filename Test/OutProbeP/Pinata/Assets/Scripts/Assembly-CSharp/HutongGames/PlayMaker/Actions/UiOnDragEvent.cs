using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760B10", Offset = "0x760B10")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760B10", Offset = "0x760B10")]
	[Token(Token = "0x20003C4")]
	public class UiOnDragEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0B48", Offset = "0x7D0B48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0B48", Offset = "0x7D0B48")]
		[Token(Token = "0x4001DBD")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onDragEvent;

		[Token(Token = "0x60012C3")]
		[Address(RVA = "0x97F11C", Offset = "0x97F11C", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onDragEvent = null;
		}

		[Token(Token = "0x60012C4")]
		[Address(RVA = "0x97F144", Offset = "0x97F144", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnDragDelegate;
			Init(EventTriggerType.Drag, call);
		}

		[Token(Token = "0x60012C5")]
		[Address(RVA = "0x97F1C8", Offset = "0x97F1C8", Length = "0xB8")]
		private void OnDragDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onDragEvent);
		}

		[Token(Token = "0x60012C6")]
		[Address(RVA = "0x97F280", Offset = "0x97F280", Length = "0x8")]
		public UiOnDragEvent()
		{
		}
	}
}
