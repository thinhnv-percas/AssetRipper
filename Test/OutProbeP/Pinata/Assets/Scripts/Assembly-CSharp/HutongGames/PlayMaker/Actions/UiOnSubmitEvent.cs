using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760ED0", Offset = "0x760ED0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760ED0", Offset = "0x760ED0")]
	[Token(Token = "0x20003D0")]
	public class UiOnSubmitEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0F08", Offset = "0x7D0F08")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0F08", Offset = "0x7D0F08")]
		[Token(Token = "0x4001DC9")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onSubmitEvent;

		[Token(Token = "0x60012F3")]
		[Address(RVA = "0x98022C", Offset = "0x98022C", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onSubmitEvent = null;
		}

		[Token(Token = "0x60012F4")]
		[Address(RVA = "0x980254", Offset = "0x980254", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnSubmitDelegate;
			Init(EventTriggerType.Submit, call);
		}

		[Token(Token = "0x60012F5")]
		[Address(RVA = "0x9802D8", Offset = "0x9802D8", Length = "0xB8")]
		private void OnSubmitDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onSubmitEvent);
		}

		[Token(Token = "0x60012F6")]
		[Address(RVA = "0x980390", Offset = "0x980390", Length = "0x8")]
		public UiOnSubmitEvent()
		{
		}
	}
}
