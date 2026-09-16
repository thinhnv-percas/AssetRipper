using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760DE0", Offset = "0x760DE0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760DE0", Offset = "0x760DE0")]
	[Token(Token = "0x20003CD")]
	public class UiOnPointerUpEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0E18", Offset = "0x7D0E18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0E18", Offset = "0x7D0E18")]
		[Token(Token = "0x4001DC6")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onPointerUpEvent;

		[Token(Token = "0x60012E7")]
		[Address(RVA = "0x97FDE8", Offset = "0x97FDE8", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onPointerUpEvent = null;
		}

		[Token(Token = "0x60012E8")]
		[Address(RVA = "0x97FE10", Offset = "0x97FE10", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnPointerUpDelegate;
			Init(EventTriggerType.PointerUp, call);
		}

		[Token(Token = "0x60012E9")]
		[Address(RVA = "0x97FE94", Offset = "0x97FE94", Length = "0xB8")]
		private void OnPointerUpDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onPointerUpEvent);
		}

		[Token(Token = "0x60012EA")]
		[Address(RVA = "0x97FF4C", Offset = "0x97FF4C", Length = "0x8")]
		public UiOnPointerUpEvent()
		{
		}
	}
}
