using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7609D0", Offset = "0x7609D0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7609D0", Offset = "0x7609D0")]
	[Token(Token = "0x20003C0")]
	public class UiIsPointerOverUiObject : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0964", Offset = "0x7D0964")]
		[Token(Token = "0x4001DB5")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt pointerId;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D099C", Offset = "0x7D099C")]
		[Token(Token = "0x4001DB6")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent pointerOverUI;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D09D4", Offset = "0x7D09D4")]
		[Token(Token = "0x4001DB7")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent pointerNotOverUI;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D0A0C", Offset = "0x7D0A0C")]
		[Token(Token = "0x4001DB8")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isPointerOverUI;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D0A20", Offset = "0x7D0A20")]
		[Token(Token = "0x4001DB9")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60012B2")]
		[Address(RVA = "0x97D380", Offset = "0x97D380", Length = "0x7C")]
		public override void Reset()
		{
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			pointerNotOverUI = null;
			isPointerOverUI = null;
			everyFrame = false;
			pointerId = fsmInt;
			pointerOverUI = null;
		}

		[Token(Token = "0x60012B3")]
		[Address(RVA = "0x97D3FC", Offset = "0x97D3FC", Length = "0x3C")]
		public override void OnEnter()
		{
			DoCheckPointer();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60012B4")]
		[Address(RVA = "0x97D5F4", Offset = "0x97D5F4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoCheckPointer();
		}

		[Token(Token = "0x60012B5")]
		[Address(RVA = "0x97D438", Offset = "0x97D438", Length = "0x1BC")]
		private void DoCheckPointer()
		{
			//IL_00ee: Expected O, but got I
			//IL_00fa: Expected O, but got I
			bool flag;
			if (pointerId.IsNone)
			{
				EventSystem current = EventSystem.current;
				flag = current.IsPointerOverGameObject();
			}
			else
			{
				EventSystem current2 = EventSystem.current;
				if ((object)current2.currentInputModule != null)
				{
					PointerInputModule pointerInputModule = current2.currentInputModule as PointerInputModule;
					if ((object)pointerInputModule != null)
					{
						EventSystem current3 = EventSystem.current;
						int value = pointerId.Value;
						PointerInputModule pointerInputModule2 = current3.currentInputModule as PointerInputModule;
						flag = current3.currentInputModule.IsPointerOverGameObject(value);
						goto IL_01a3;
					}
				}
				flag = false;
			}
			goto IL_01a3;
			IL_01a3:
			FsmBool fsmBool = isPointerOverUI;
			fsmBool.value = flag;
			object fsmEvent = (long)(IntPtr)this + 88L;
			object obj = (long)(IntPtr)this + 96L;
			if (!flag)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
		}

		[Token(Token = "0x60012B6")]
		[Address(RVA = "0x97D5F8", Offset = "0x97D5F8", Length = "0x8")]
		public UiIsPointerOverUiObject()
		{
		}
	}
}
