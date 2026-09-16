using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761E70", Offset = "0x761E70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761E70", Offset = "0x761E70")]
	[Token(Token = "0x2000402")]
	public class UiInputFieldSetHideMobileInput : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6840", Offset = "0x7D6840")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6840", Offset = "0x7D6840")]
		[Token(Token = "0x4001EE9")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D68D8", Offset = "0x7D68D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D68D8", Offset = "0x7D68D8")]
		[Token(Token = "0x4001EEA")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool hideMobileInput;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6938", Offset = "0x7D6938")]
		[Token(Token = "0x4001EEB")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001EEC")]
		[FieldOffset(Offset = "0x78")]
		private InputField inputField;

		[Token(Token = "0x4001EED")]
		[FieldOffset(Offset = "0x80")]
		private bool originalValue;

		[Token(Token = "0x60013E0")]
		[Address(RVA = "0x97C938", Offset = "0x97C938", Length = "0xC")]
		public override void Reset()
		{
			hideMobileInput = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013E1")]
		[Address(RVA = "0x97C944", Offset = "0x97C944", Length = "0xAC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetHideMobileInput)+30]");
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
			bool shouldHideMobileInput = inputField.shouldHideMobileInput;
			originalValue = shouldHideMobileInput;
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x60013E2")]
		[Address(RVA = "0x97C9F0", Offset = "0x97C9F0", Length = "0xB4")]
		private void DoSetValue()
		{
			if (inputField != null)
			{
				bool value = hideMobileInput.Value;
				inputField.shouldHideMobileInput = value;
			}
		}

		[Token(Token = "0x60013E3")]
		[Address(RVA = "0x97CAA4", Offset = "0x97CAA4", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				inputField.shouldHideMobileInput = originalValue;
			}
		}

		[Token(Token = "0x60013E4")]
		[Address(RVA = "0x97CB50", Offset = "0x97CB50", Length = "0x50")]
		public UiInputFieldSetHideMobileInput()
		{
		}
	}
}
