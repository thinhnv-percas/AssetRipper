using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762140", Offset = "0x762140")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762140", Offset = "0x762140")]
	[Token(Token = "0x200040B")]
	public class UiScrollbarSetDirection : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7374", Offset = "0x7D7374")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7374", Offset = "0x7D7374")]
		[Token(Token = "0x4001F15")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D740C", Offset = "0x7D740C")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D740C", Offset = "0x7D740C")]
		[Token(Token = "0x4001F16")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D74A4", Offset = "0x7D74A4")]
		[Token(Token = "0x4001F17")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool includeRectLayouts;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D74DC", Offset = "0x7D74DC")]
		[Token(Token = "0x4001F18")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001F19")]
		[FieldOffset(Offset = "0x80")]
		private Scrollbar scrollbar;

		[Token(Token = "0x4001F1A")]
		[FieldOffset(Offset = "0x88")]
		private Scrollbar.Direction originalValue;

		[Token(Token = "0x600140F")]
		[Address(RVA = "0x981830", Offset = "0x981830", Length = "0xA4")]
		public override void Reset()
		{
			//IL_003a: Expected O, but got I4
			//IL_0043: Expected I4, but got O
			gameObject = null;
			object obj = 0;
			Enum obj2 = (Scrollbar.Direction)obj;
			FsmEnum fsmEnum = obj2;
			direction = fsmEnum;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			includeRectLayouts = fsmBool;
			resetOnExit = null;
		}

		[Token(Token = "0x6001410")]
		[Address(RVA = "0x9818D4", Offset = "0x9818D4", Length = "0xB8")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarSetDirection)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.scrollbar = cachedComponent;
			}
			if (resetOnExit.Value)
			{
				Scrollbar scrollbar = this.scrollbar;
				originalValue = scrollbar.direction;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x6001411")]
		[Address(RVA = "0x98198C", Offset = "0x98198C", Length = "0x178")]
		private void DoSetValue()
		{
			//IL_00e2: Expected I4, but got O
			//IL_0080: Expected I4, but got O
			//IL_0121: Expected I4, but got O
			//IL_00bb: Expected I4, but got O
			if (scrollbar == null)
			{
				return;
			}
			bool isNone = includeRectLayouts.IsNone;
			Enum value = direction.Value;
			if (isNone)
			{
				if ((int)((value is Scrollbar.Direction) ? value : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					scrollbar.direction = (Scrollbar.Direction)obj;
					return;
				}
			}
			else
			{
				bool value2 = includeRectLayouts.Value;
				if ((int)((value is Scrollbar.Direction) ? value : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					scrollbar.SetDirection((Scrollbar.Direction)obj2, value2);
					return;
				}
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x6001412")]
		[Address(RVA = "0x981B04", Offset = "0x981B04", Length = "0x110")]
		public override void OnExit()
		{
			if (!(scrollbar == null) && resetOnExit.Value)
			{
				if (includeRectLayouts.IsNone)
				{
					scrollbar.direction = originalValue;
					return;
				}
				bool value = includeRectLayouts.Value;
				scrollbar.SetDirection(originalValue, value);
			}
		}

		[Token(Token = "0x6001413")]
		[Address(RVA = "0x981C14", Offset = "0x981C14", Length = "0x50")]
		public UiScrollbarSetDirection()
		{
		}
	}
}
