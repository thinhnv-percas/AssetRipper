using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760AC0", Offset = "0x760AC0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760AC0", Offset = "0x760AC0")]
	[Token(Token = "0x20003C3")]
	public class UiOnDeselectEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0AF8", Offset = "0x7D0AF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0AF8", Offset = "0x7D0AF8")]
		[Token(Token = "0x4001DBC")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onDeselectEvent;

		[Token(Token = "0x60012BF")]
		[Address(RVA = "0x97EFB0", Offset = "0x97EFB0", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onDeselectEvent = null;
		}

		[Token(Token = "0x60012C0")]
		[Address(RVA = "0x97EFD8", Offset = "0x97EFD8", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnDeselectDelegate;
			Init(EventTriggerType.Deselect, call);
		}

		[Token(Token = "0x60012C1")]
		[Address(RVA = "0x97F05C", Offset = "0x97F05C", Length = "0xB8")]
		private void OnDeselectDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onDeselectEvent);
		}

		[Token(Token = "0x60012C2")]
		[Address(RVA = "0x97F114", Offset = "0x97F114", Length = "0x8")]
		public UiOnDeselectEvent()
		{
		}
	}
}
