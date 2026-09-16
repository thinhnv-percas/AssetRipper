using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761BA0", Offset = "0x761BA0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761BA0", Offset = "0x761BA0")]
	[Token(Token = "0x20003F9")]
	public class UiInputFieldGetWasCanceled : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5D2C", Offset = "0x7D5D2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5D2C", Offset = "0x7D5D2C")]
		[Token(Token = "0x4001EBC")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D5DC4", Offset = "0x7D5DC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5DC4", Offset = "0x7D5DC4")]
		[Token(Token = "0x4001EBD")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool wasCanceled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5E14", Offset = "0x7D5E14")]
		[Token(Token = "0x4001EBE")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent wasCanceledEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D5E4C", Offset = "0x7D5E4C")]
		[Token(Token = "0x4001EBF")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent wasNotCanceledEvent;

		[Token(Token = "0x4001EC0")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x60013B3")]
		[Address(RVA = "0x97B178", Offset = "0x97B178", Length = "0xC")]
		public override void Reset()
		{
			wasCanceledEvent = null;
			wasNotCanceledEvent = null;
			wasCanceled = null;
		}

		[Token(Token = "0x60013B4")]
		[Address(RVA = "0x97B184", Offset = "0x97B184", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetWasCanceled)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x60013B5")]
		[Address(RVA = "0x97B210", Offset = "0x97B210", Length = "0xD0")]
		private void DoGetValue()
		{
			//IL_007e: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_00f6: Expected O, but got I
			if (!(this.inputField == null))
			{
				InputField inputField = this.inputField;
				FsmBool fsmBool = wasCanceled;
				fsmBool.value = inputField.wasCanceled;
				InputField inputField2 = this.inputField;
				object obj = (long)(IntPtr)this + 112L;
				object obj2 = (long)(IntPtr)this + 120L;
				object fsmEvent = ((!inputField2.wasCanceled) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetWasCanceled)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x60013B6")]
		[Address(RVA = "0x97B2E0", Offset = "0x97B2E0", Length = "0x50")]
		public UiInputFieldGetWasCanceled()
		{
		}
	}
}
