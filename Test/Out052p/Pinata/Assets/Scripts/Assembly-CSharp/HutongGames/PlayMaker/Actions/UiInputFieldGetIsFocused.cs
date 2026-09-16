using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7619C0", Offset = "0x7619C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7619C0", Offset = "0x7619C0")]
	[Token(Token = "0x20003F3")]
	public class UiInputFieldGetIsFocused : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D54AC", Offset = "0x7D54AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D54AC", Offset = "0x7D54AC")]
		[Token(Token = "0x4001E97")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D5544", Offset = "0x7D5544")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5544", Offset = "0x7D5544")]
		[Token(Token = "0x4001E98")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isFocused;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5594", Offset = "0x7D5594")]
		[Token(Token = "0x4001E99")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isfocusedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D55CC", Offset = "0x7D55CC")]
		[Token(Token = "0x4001E9A")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isNotFocusedEvent;

		[Token(Token = "0x4001E9B")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x6001397")]
		[Address(RVA = "0x97A66C", Offset = "0x97A66C", Length = "0xC")]
		public override void Reset()
		{
			isfocusedEvent = null;
			isNotFocusedEvent = null;
			isFocused = null;
		}

		[Token(Token = "0x6001398")]
		[Address(RVA = "0x97A678", Offset = "0x97A678", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetIsFocused)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x6001399")]
		[Address(RVA = "0x97A704", Offset = "0x97A704", Length = "0xD0")]
		private void DoGetValue()
		{
			//IL_007e: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_00f6: Expected O, but got I
			if (!(this.inputField == null))
			{
				InputField inputField = this.inputField;
				FsmBool fsmBool = isFocused;
				fsmBool.value = inputField.isFocused;
				InputField inputField2 = this.inputField;
				object obj = (long)(IntPtr)this + 112L;
				object obj2 = (long)(IntPtr)this + 120L;
				object fsmEvent = ((!inputField2.isFocused) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetIsFocused)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x600139A")]
		[Address(RVA = "0x97A7D4", Offset = "0x97A7D4", Length = "0x50")]
		public UiInputFieldGetIsFocused()
		{
		}
	}
}
