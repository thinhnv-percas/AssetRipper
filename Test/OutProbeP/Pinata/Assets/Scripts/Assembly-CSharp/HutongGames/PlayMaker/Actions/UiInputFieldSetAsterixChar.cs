using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761D80", Offset = "0x761D80")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761D80", Offset = "0x761D80")]
	[Token(Token = "0x20003FF")]
	public class UiInputFieldSetAsterixChar : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D647C", Offset = "0x7D647C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D647C", Offset = "0x7D647C")]
		[Token(Token = "0x4001ED7")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6514", Offset = "0x7D6514")]
		[Token(Token = "0x4001ED8")]
		[FieldOffset(Offset = "0x68")]
		public FsmString asterixChar;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6560", Offset = "0x7D6560")]
		[Token(Token = "0x4001ED9")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001EDA")]
		[FieldOffset(Offset = "0x78")]
		private InputField inputField;

		[Token(Token = "0x4001EDB")]
		[FieldOffset(Offset = "0x80")]
		private char originalValue;

		[Token(Token = "0x4001EDC")]
		private static char __char__ = ' ';

		[Token(Token = "0x60013CE")]
		[Address(RVA = "0x97C0BC", Offset = "0x97C0BC", Length = "0x5C")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "*";
			asterixChar = fsmString;
			resetOnExit = null;
		}

		[Token(Token = "0x60013CF")]
		[Address(RVA = "0x97C118", Offset = "0x97C118", Length = "0xAC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetAsterixChar)+30]");
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
			originalValue = inputField.asteriskChar;
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x60013D0")]
		[Address(RVA = "0x97C1C4", Offset = "0x97C1C4", Length = "0x11C")]
		private void DoSetValue()
		{
			char asteriskChar = __char__;
			string value = asterixChar.Value;
			if (value.Length >= 1)
			{
				string value2 = asterixChar.Value;
				char c = value2.get_Chars(0);
				asteriskChar = c;
			}
			if (inputField != null)
			{
				inputField.asteriskChar = asteriskChar;
			}
		}

		[Token(Token = "0x60013D1")]
		[Address(RVA = "0x97C2E0", Offset = "0x97C2E0", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				inputField.asteriskChar = originalValue;
			}
		}

		[Token(Token = "0x60013D2")]
		[Address(RVA = "0x97C38C", Offset = "0x97C38C", Length = "0x50")]
		public UiInputFieldSetAsterixChar()
		{
		}
	}
}
