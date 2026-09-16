using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760A20", Offset = "0x760A20")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760A20", Offset = "0x760A20")]
	[Token(Token = "0x20003C1")]
	public class UiOnBeginDragEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0A58", Offset = "0x7D0A58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0A58", Offset = "0x7D0A58")]
		[Token(Token = "0x4001DBA")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onBeginDragEvent;

		[Token(Token = "0x60012B7")]
		[Address(RVA = "0x97ECF4", Offset = "0x97ECF4", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onBeginDragEvent = null;
		}

		[Token(Token = "0x60012B8")]
		[Address(RVA = "0x97ED1C", Offset = "0x97ED1C", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnBeginDragDelegate;
			Init(EventTriggerType.BeginDrag, call);
		}

		[Token(Token = "0x60012B9")]
		[Address(RVA = "0x97EDA0", Offset = "0x97EDA0", Length = "0xB8")]
		private void OnBeginDragDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onBeginDragEvent);
		}

		[Token(Token = "0x60012BA")]
		[Address(RVA = "0x97EE58", Offset = "0x97EE58", Length = "0x8")]
		public UiOnBeginDragEvent()
		{
		}
	}
}
