using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760890", Offset = "0x760890")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760890", Offset = "0x760890")]
	[Token(Token = "0x20003BC")]
	public class UiEventSystemExecuteEvent : FsmStateAction
	{
		[Token(Token = "0x200049F")]
		public enum EventHandlers
		{
			[Token(Token = "0x40021DF")]
			Submit = 0,
			[Token(Token = "0x40021E0")]
			beginDrag = 1,
			[Token(Token = "0x40021E1")]
			cancel = 2,
			[Token(Token = "0x40021E2")]
			deselectHandler = 3,
			[Token(Token = "0x40021E3")]
			dragHandler = 4,
			[Token(Token = "0x40021E4")]
			dropHandler = 5,
			[Token(Token = "0x40021E5")]
			endDragHandler = 6,
			[Token(Token = "0x40021E6")]
			initializePotentialDrag = 7,
			[Token(Token = "0x40021E7")]
			pointerClickHandler = 8,
			[Token(Token = "0x40021E8")]
			pointerDownHandler = 9,
			[Token(Token = "0x40021E9")]
			pointerEnterHandler = 10,
			[Token(Token = "0x40021EA")]
			pointerExitHandler = 11,
			[Token(Token = "0x40021EB")]
			pointerUpHandler = 12,
			[Token(Token = "0x40021EC")]
			scrollHandler = 13,
			[Token(Token = "0x40021ED")]
			submitHandler = 14,
			[Token(Token = "0x40021EE")]
			updateSelectedHandler = 15
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFE70", Offset = "0x7CFE70")]
		[Token(Token = "0x4001D90")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFEBC", Offset = "0x7CFEBC")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7CFEBC", Offset = "0x7CFEBC")]
		[Token(Token = "0x4001D91")]
		[FieldOffset(Offset = "0x58")]
		public FsmEnum eventHandler;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFF44", Offset = "0x7CFF44")]
		[Token(Token = "0x4001D92")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent success;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFF7C", Offset = "0x7CFF7C")]
		[Token(Token = "0x4001D93")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent canNotHandleEvent;

		[Token(Token = "0x4001D94")]
		[FieldOffset(Offset = "0x70")]
		private GameObject go;

		[Token(Token = "0x60012A2")]
		[Address(RVA = "0x9A4C1C", Offset = "0x9A4C1C", Length = "0x74")]
		public override void Reset()
		{
			//IL_0015: Expected O, but got I4
			//IL_001e: Expected I4, but got O
			gameObject = null;
			object obj = 0;
			Enum obj2 = (EventHandlers)obj;
			FsmEnum fsmEnum = obj2;
			success = null;
			canNotHandleEvent = null;
			eventHandler = fsmEnum;
		}

		[Token(Token = "0x60012A3")]
		[Address(RVA = "0x9A4C90", Offset = "0x9A4C90", Length = "0x58")]
		public override void OnEnter()
		{
			//IL_001b: Expected O, but got I
			//IL_0027: Expected O, but got I
			bool flag = ExecuteEvent();
			object fsmEvent = (long)(IntPtr)this + 96L;
			object obj = (long)(IntPtr)this + 104L;
			if (!flag)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
			Finish();
		}

		[Token(Token = "0x60012A4")]
		[Address(RVA = "0x9A4CE8", Offset = "0x9A4CE8", Length = "0xFF0")]
		private bool ExecuteEvent()
		{
			//IL_008e: Expected I4, but got O
			//IL_015f: Expected I4, but got O
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0147: Expected O, but got I
			bool result;
			if ((go = Fsm.GetOwnerDefaultTarget(gameObject)) == null)
			{
				LogError("Missing GameObject ");
				result = false;
				goto IL_015f;
			}
			Enum value = eventHandler.Value;
			if ((int)((value is EventHandlers) ? value : null) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				object obj = obj2;
				bool flag = (long)(IntPtr)obj2 < 15L;
				bool flag2 = !flag;
				object obj3 = obj2 - 15;
				bool flag3 = obj3 == null;
				bool flag4 = !flag3;
				bool flag5 = flag2 && flag4;
				result = true;
				if (flag5)
				{
					goto IL_015f;
				}
				int num = 25260032 + 3952;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X9_v6 (System.Int32)+v179 @ X8_v13*4]");
				object obj4 = 0L + (long)num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v167 @ X8_v15 (should have been resolved before IL gen)");
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
			IL_015f:
			return result;
		}

		[Token(Token = "0x60012A5")]
		[Address(RVA = "0x9A5CD8", Offset = "0x9A5CD8", Length = "0x8")]
		public UiEventSystemExecuteEvent()
		{
		}
	}
}
