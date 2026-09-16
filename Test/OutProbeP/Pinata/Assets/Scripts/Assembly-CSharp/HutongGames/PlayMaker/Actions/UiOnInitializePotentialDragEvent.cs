using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760C00", Offset = "0x760C00")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760C00", Offset = "0x760C00")]
	[Token(Token = "0x20003C7")]
	public class UiOnInitializePotentialDragEvent : EventTriggerActionBase
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0C38", Offset = "0x7D0C38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0C38", Offset = "0x7D0C38")]
		[Token(Token = "0x4001DC0")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent onInitializePotentialDragEvent;

		[Token(Token = "0x60012CF")]
		[Address(RVA = "0x97F560", Offset = "0x97F560", Length = "0x28")]
		public override void Reset()
		{
			base.Reset();
			onInitializePotentialDragEvent = null;
		}

		[Token(Token = "0x60012D0")]
		[Address(RVA = "0x97F588", Offset = "0x97F588", Length = "0x84")]
		public override void OnEnter()
		{
			UnityAction<BaseEventData> call = OnInitializePotentialDragDelegate;
			Init(EventTriggerType.InitializePotentialDrag, call);
		}

		[Token(Token = "0x60012D1")]
		[Address(RVA = "0x97F60C", Offset = "0x97F60C", Length = "0xB8")]
		private void OnInitializePotentialDragDelegate(BaseEventData data)
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
			SendEvent(eventTarget, onInitializePotentialDragEvent);
		}

		[Token(Token = "0x60012D2")]
		[Address(RVA = "0x97F6C4", Offset = "0x97F6C4", Length = "0x8")]
		public UiOnInitializePotentialDragEvent()
		{
		}
	}
}
