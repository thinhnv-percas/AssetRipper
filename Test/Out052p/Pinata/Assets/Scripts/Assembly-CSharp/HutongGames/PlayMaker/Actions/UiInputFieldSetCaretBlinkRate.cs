using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761DD0", Offset = "0x761DD0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761DD0", Offset = "0x761DD0")]
	[Token(Token = "0x2000400")]
	public class UiInputFieldSetCaretBlinkRate : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6598", Offset = "0x7D6598")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6598", Offset = "0x7D6598")]
		[Token(Token = "0x4001EDD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6630", Offset = "0x7D6630")]
		[Token(Token = "0x4001EDE")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt caretBlinkRate;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D667C", Offset = "0x7D667C")]
		[Token(Token = "0x4001EDF")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D66B4", Offset = "0x7D66B4")]
		[Token(Token = "0x4001EE0")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001EE1")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x4001EE2")]
		[FieldOffset(Offset = "0x88")]
		private float originalValue;

		[Token(Token = "0x60013D4")]
		[Address(RVA = "0x97C430", Offset = "0x97C430", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			caretBlinkRate = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013D5")]
		[Address(RVA = "0x97C440", Offset = "0x97C440", Length = "0xC0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetCaretBlinkRate)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			InputField inputField;
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
				this.inputField = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				inputField = this.inputField;
			}
			originalValue = inputField.caretBlinkRate;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60013D6")]
		[Address(RVA = "0x97C5B4", Offset = "0x97C5B4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x60013D7")]
		[Address(RVA = "0x97C500", Offset = "0x97C500", Length = "0xB4")]
		private void DoSetValue()
		{
			if (inputField != null)
			{
				int value = caretBlinkRate.Value;
				inputField.caretBlinkRate = value;
			}
		}

		[Token(Token = "0x60013D8")]
		[Address(RVA = "0x97C5B8", Offset = "0x97C5B8", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				inputField.caretBlinkRate = originalValue;
			}
		}

		[Token(Token = "0x60013D9")]
		[Address(RVA = "0x97C664", Offset = "0x97C664", Length = "0x50")]
		public UiInputFieldSetCaretBlinkRate()
		{
		}
	}
}
