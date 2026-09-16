using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7608E0", Offset = "0x7608E0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7608E0", Offset = "0x7608E0")]
	[Token(Token = "0x20003BD")]
	public class UiGetLastPointerDataInfo : FsmStateAction
	{
		[Token(Token = "0x4001D95")]
		public static PointerEventData lastPointerEventData;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFFB4", Offset = "0x7CFFB4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CFFB4", Offset = "0x7CFFB4")]
		[Token(Token = "0x4001D96")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt clickCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0004", Offset = "0x7D0004")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0004", Offset = "0x7D0004")]
		[Token(Token = "0x4001D97")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat clickTime;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0054", Offset = "0x7D0054")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0054", Offset = "0x7D0054")]
		[Token(Token = "0x4001D98")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 delta;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D00A4", Offset = "0x7D00A4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D00A4", Offset = "0x7D00A4")]
		[Token(Token = "0x4001D99")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool dragging;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D00F4", Offset = "0x7D00F4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D00F4", Offset = "0x7D00F4")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D00F4", Offset = "0x7D00F4")]
		[Token(Token = "0x4001D9A")]
		[FieldOffset(Offset = "0x70")]
		public FsmEnum inputButton;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0190", Offset = "0x7D0190")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0190", Offset = "0x7D0190")]
		[Token(Token = "0x4001D9B")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool eligibleForClick;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D01E0", Offset = "0x7D01E0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D01E0", Offset = "0x7D01E0")]
		[Token(Token = "0x4001D9C")]
		[FieldOffset(Offset = "0x80")]
		public FsmGameObject enterEventCamera;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0230", Offset = "0x7D0230")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0230", Offset = "0x7D0230")]
		[Token(Token = "0x4001D9D")]
		[FieldOffset(Offset = "0x88")]
		public FsmGameObject pressEventCamera;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0280", Offset = "0x7D0280")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0280", Offset = "0x7D0280")]
		[Token(Token = "0x4001D9E")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool isPointerMoving;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D02D0", Offset = "0x7D02D0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D02D0", Offset = "0x7D02D0")]
		[Token(Token = "0x4001D9F")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool isScrolling;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0320", Offset = "0x7D0320")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0320", Offset = "0x7D0320")]
		[Token(Token = "0x4001DA0")]
		[FieldOffset(Offset = "0xA0")]
		public FsmGameObject lastPress;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0370", Offset = "0x7D0370")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0370", Offset = "0x7D0370")]
		[Token(Token = "0x4001DA1")]
		[FieldOffset(Offset = "0xA8")]
		public FsmGameObject pointerDrag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D03C0", Offset = "0x7D03C0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D03C0", Offset = "0x7D03C0")]
		[Token(Token = "0x4001DA2")]
		[FieldOffset(Offset = "0xB0")]
		public FsmGameObject pointerEnter;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0410", Offset = "0x7D0410")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0410", Offset = "0x7D0410")]
		[Token(Token = "0x4001DA3")]
		[FieldOffset(Offset = "0xB8")]
		public FsmInt pointerId;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0460", Offset = "0x7D0460")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0460", Offset = "0x7D0460")]
		[Token(Token = "0x4001DA4")]
		[FieldOffset(Offset = "0xC0")]
		public FsmGameObject pointerPress;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D04B0", Offset = "0x7D04B0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D04B0", Offset = "0x7D04B0")]
		[Token(Token = "0x4001DA5")]
		[FieldOffset(Offset = "0xC8")]
		public FsmVector2 position;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0500", Offset = "0x7D0500")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0500", Offset = "0x7D0500")]
		[Token(Token = "0x4001DA6")]
		[FieldOffset(Offset = "0xD0")]
		public FsmVector2 pressPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0550", Offset = "0x7D0550")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0550", Offset = "0x7D0550")]
		[Token(Token = "0x4001DA7")]
		[FieldOffset(Offset = "0xD8")]
		public FsmGameObject rawPointerPress;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D05A0", Offset = "0x7D05A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D05A0", Offset = "0x7D05A0")]
		[Token(Token = "0x4001DA8")]
		[FieldOffset(Offset = "0xE0")]
		public FsmVector2 scrollDelta;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D05F0", Offset = "0x7D05F0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D05F0", Offset = "0x7D05F0")]
		[Token(Token = "0x4001DA9")]
		[FieldOffset(Offset = "0xE8")]
		public FsmBool used;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0640", Offset = "0x7D0640")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0640", Offset = "0x7D0640")]
		[Token(Token = "0x4001DAA")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool useDragThreshold;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0690", Offset = "0x7D0690")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0690", Offset = "0x7D0690")]
		[Token(Token = "0x4001DAB")]
		[FieldOffset(Offset = "0xF8")]
		public FsmVector3 worldNormal;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D06E0", Offset = "0x7D06E0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D06E0", Offset = "0x7D06E0")]
		[Token(Token = "0x4001DAC")]
		[FieldOffset(Offset = "0x100")]
		public FsmVector3 worldPosition;

		[Token(Token = "0x60012A6")]
		[Address(RVA = "0x9A617C", Offset = "0x9A617C", Length = "0x84")]
		public override void Reset()
		{
			//IL_001d: Expected O, but got I4
			//IL_0026: Expected I4, but got O
			//IL_004d: Expected O, but got I
			clickCount = null;
			delta = null;
			object obj = 0;
			Enum obj2 = (PointerEventData.InputButton)obj;
			FsmEnum fsmEnum = obj2;
			inputButton = fsmEnum;
			object obj3 = (long)(IntPtr)this + 120L;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x60012A7")]
		[Address(RVA = "0x9A6200", Offset = "0x9A6200", Length = "0x5DC")]
		public override void OnEnter()
		{
			if (lastPointerEventData != null)
			{
				if (!clickCount.IsNone)
				{
					PointerEventData pointerEventData = lastPointerEventData;
					FsmInt fsmInt = clickCount;
					fsmInt.Value = pointerEventData.clickCount;
				}
				if (!clickTime.IsNone)
				{
					PointerEventData pointerEventData2 = lastPointerEventData;
					FsmFloat fsmFloat = clickTime;
					fsmFloat.Value = pointerEventData2.clickTime;
				}
				if (!delta.IsNone)
				{
					PointerEventData pointerEventData3 = lastPointerEventData;
					FsmVector2 fsmVector = delta;
					fsmVector.value = pointerEventData3.delta;
					fsmVector.value.y = pointerEventData3.delta.y;
				}
				if (!dragging.IsNone)
				{
					PointerEventData pointerEventData4 = lastPointerEventData;
					FsmBool fsmBool = dragging;
					fsmBool.value = pointerEventData4.dragging;
				}
				if (!inputButton.IsNone)
				{
					PointerEventData pointerEventData5 = lastPointerEventData;
					PointerEventData.InputButton button = pointerEventData5.button;
					Enum value = button;
					inputButton.Value = value;
				}
				if (!eligibleForClick.IsNone)
				{
					PointerEventData pointerEventData6 = lastPointerEventData;
					FsmBool fsmBool2 = eligibleForClick;
					fsmBool2.value = pointerEventData6.eligibleForClick;
				}
				if (!enterEventCamera.IsNone)
				{
					Camera camera = lastPointerEventData.enterEventCamera;
					GameObject gameObject = camera.gameObject;
					enterEventCamera.Value = gameObject;
				}
				if (!isPointerMoving.IsNone)
				{
					FsmBool fsmBool3 = isPointerMoving;
					bool value2 = lastPointerEventData.IsPointerMoving();
					fsmBool3.value = value2;
				}
				if (!isScrolling.IsNone)
				{
					FsmBool fsmBool4 = isScrolling;
					bool value3 = lastPointerEventData.IsScrolling();
					fsmBool4.value = value3;
				}
				if (!lastPress.IsNone)
				{
					PointerEventData pointerEventData7 = lastPointerEventData;
					lastPress.Value = pointerEventData7.lastPress;
				}
				if (!pointerDrag.IsNone)
				{
					PointerEventData pointerEventData8 = lastPointerEventData;
					pointerDrag.Value = pointerEventData8.pointerDrag;
				}
				if (!pointerEnter.IsNone)
				{
					PointerEventData pointerEventData9 = lastPointerEventData;
					pointerEnter.Value = pointerEventData9.pointerEnter;
				}
				if (!pointerId.IsNone)
				{
					PointerEventData pointerEventData10 = lastPointerEventData;
					FsmInt fsmInt2 = pointerId;
					fsmInt2.Value = pointerEventData10.pointerId;
				}
				if (!pointerPress.IsNone)
				{
					PointerEventData pointerEventData11 = lastPointerEventData;
					pointerPress.Value = pointerEventData11.pointerPress;
				}
				if (!position.IsNone)
				{
					PointerEventData pointerEventData12 = lastPointerEventData;
					FsmVector2 fsmVector2 = position;
					fsmVector2.value = pointerEventData12.position;
					fsmVector2.value.y = pointerEventData12.position.y;
				}
				if (!pressEventCamera.IsNone)
				{
					Camera camera2 = lastPointerEventData.pressEventCamera;
					GameObject gameObject2 = camera2.gameObject;
					pressEventCamera.Value = gameObject2;
				}
				if (!pressPosition.IsNone)
				{
					PointerEventData pointerEventData13 = lastPointerEventData;
					FsmVector2 fsmVector3 = pressPosition;
					fsmVector3.value = pointerEventData13.pressPosition;
					fsmVector3.value.y = pointerEventData13.pressPosition.y;
				}
				if (!rawPointerPress.IsNone)
				{
					PointerEventData pointerEventData14 = lastPointerEventData;
					rawPointerPress.Value = pointerEventData14.rawPointerPress;
				}
				if (!scrollDelta.IsNone)
				{
					PointerEventData pointerEventData15 = lastPointerEventData;
					FsmVector2 fsmVector4 = scrollDelta;
					fsmVector4.value = pointerEventData15.scrollDelta;
					fsmVector4.value.y = pointerEventData15.scrollDelta.y;
				}
				if (!used.IsNone)
				{
					FsmBool fsmBool5 = used;
					bool value4 = lastPointerEventData.used;
					fsmBool5.value = value4;
				}
				if (!useDragThreshold.IsNone)
				{
					PointerEventData pointerEventData16 = lastPointerEventData;
					FsmBool fsmBool6 = useDragThreshold;
					fsmBool6.value = pointerEventData16.useDragThreshold;
				}
				if (!worldNormal.IsNone)
				{
					PointerEventData pointerEventData17 = lastPointerEventData;
					FsmVector3 fsmVector5 = worldNormal;
					fsmVector5.value = pointerEventData17.pointerCurrentRaycast.worldNormal;
					fsmVector5.value.z = pointerEventData17.pointerCurrentRaycast.worldNormal.z;
				}
				if (!worldPosition.IsNone)
				{
					PointerEventData pointerEventData18 = lastPointerEventData;
					FsmVector3 fsmVector6 = worldPosition;
					fsmVector6.value = pointerEventData18.pointerCurrentRaycast.worldPosition;
					fsmVector6.value.z = pointerEventData18.pointerCurrentRaycast.worldPosition.z;
				}
				Finish();
			}
			else
			{
				Finish();
			}
		}

		[Token(Token = "0x60012A8")]
		[Address(RVA = "0x9A67DC", Offset = "0x9A67DC", Length = "0x8")]
		public UiGetLastPointerDataInfo()
		{
		}
	}
}
