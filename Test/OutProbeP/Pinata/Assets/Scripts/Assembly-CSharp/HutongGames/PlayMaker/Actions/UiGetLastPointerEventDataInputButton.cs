using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760930", Offset = "0x760930")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760930", Offset = "0x760930")]
	[Token(Token = "0x20003BE")]
	public class UiGetLastPointerEventDataInputButton : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0730", Offset = "0x7D0730")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0730", Offset = "0x7D0730")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D0730", Offset = "0x7D0730")]
		[Token(Token = "0x4001DAD")]
		[FieldOffset(Offset = "0x50")]
		public FsmEnum inputButton;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D07CC", Offset = "0x7D07CC")]
		[Token(Token = "0x4001DAE")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent leftClick;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0804", Offset = "0x7D0804")]
		[Token(Token = "0x4001DAF")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent middleClick;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D083C", Offset = "0x7D083C")]
		[Token(Token = "0x4001DB0")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent rightClick;

		[Token(Token = "0x60012A9")]
		[Address(RVA = "0x97868C", Offset = "0x97868C", Length = "0x70")]
		public override void Reset()
		{
			//IL_000e: Expected O, but got I4
			//IL_0017: Expected I4, but got O
			object obj = 0;
			Enum obj2 = (PointerEventData.InputButton)obj;
			FsmEnum fsmEnum = obj2;
			middleClick = null;
			rightClick = null;
			inputButton = fsmEnum;
			leftClick = null;
		}

		[Token(Token = "0x60012AA")]
		[Address(RVA = "0x9786FC", Offset = "0x9786FC", Length = "0x28")]
		public override void OnEnter()
		{
			ExecuteAction();
			Finish();
		}

		[Token(Token = "0x60012AB")]
		[Address(RVA = "0x978724", Offset = "0x978724", Length = "0x190")]
		private void ExecuteAction()
		{
			if (UiGetLastPointerDataInfo.lastPointerEventData == null)
			{
				return;
			}
			if (!inputButton.IsNone)
			{
				PointerEventData lastPointerEventData = UiGetLastPointerDataInfo.lastPointerEventData;
				PointerEventData.InputButton button = lastPointerEventData.button;
				Enum value = button;
				inputButton.Value = value;
			}
			FsmEvent fsmEvent = leftClick;
			Fsm fsm;
			FsmEvent fsmEvent2;
			if (!string.IsNullOrEmpty(fsmEvent.Name))
			{
				PointerEventData lastPointerEventData2 = UiGetLastPointerDataInfo.lastPointerEventData;
				if (lastPointerEventData2.button == PointerEventData.InputButton.Left)
				{
					fsm = Fsm;
					fsmEvent2 = leftClick;
					goto IL_0267;
				}
			}
			FsmEvent fsmEvent3 = middleClick;
			if (!string.IsNullOrEmpty(fsmEvent3.Name))
			{
				PointerEventData lastPointerEventData3 = UiGetLastPointerDataInfo.lastPointerEventData;
				if (lastPointerEventData3.button == PointerEventData.InputButton.Middle)
				{
					fsm = Fsm;
					fsmEvent2 = middleClick;
					goto IL_0267;
				}
			}
			FsmEvent fsmEvent4 = rightClick;
			if (!string.IsNullOrEmpty(fsmEvent4.Name))
			{
				PointerEventData lastPointerEventData4 = UiGetLastPointerDataInfo.lastPointerEventData;
				if (lastPointerEventData4.button == PointerEventData.InputButton.Right)
				{
					fsm = Fsm;
					fsmEvent2 = rightClick;
					goto IL_0267;
				}
				return;
			}
			return;
			IL_0267:
			fsm.Event(fsmEvent2);
		}

		[Token(Token = "0x60012AC")]
		[Address(RVA = "0x9788B4", Offset = "0x9788B4", Length = "0x8")]
		public UiGetLastPointerEventDataInputButton()
		{
		}
	}
}
