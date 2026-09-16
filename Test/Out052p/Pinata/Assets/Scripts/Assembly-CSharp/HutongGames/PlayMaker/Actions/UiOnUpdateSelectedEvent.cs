using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760F20", Offset = "0x760F20")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760F20", Offset = "0x760F20")]
	[Token(Token = "0x20003D1")]
	public class UiOnUpdateSelectedEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0F58", Offset = "0x7D0F58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0F58", Offset = "0x7D0F58")]
		[Token(Token = "0x4001DCA")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onUpdateSelectedEvent;

		[Token(Token = "0x60012F7")]
		[Address(RVA = "0x980398", Offset = "0x980398", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onUpdateSelectedEvent = null;
		}

		[Token(Token = "0x60012F8")]
		[Address(RVA = "0x9803C0", Offset = "0x9803C0", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnUpdateSelectedDelegate;
			Init(EventTriggerType.UpdateSelected, call);
		}

		[Token(Token = "0x60012F9")]
		[Address(RVA = "0x980444", Offset = "0x980444", Length = "0xB8")]
		private void OnUpdateSelectedDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onUpdateSelectedEvent);
		}

		[Token(Token = "0x60012FA")]
		[Address(RVA = "0x9804FC", Offset = "0x9804FC", Length = "0x8")]
		public UiOnUpdateSelectedEvent()
		{
		}
	}
}
