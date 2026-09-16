using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761E20", Offset = "0x761E20")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761E20", Offset = "0x761E20")]
	[Token(Token = "0x2000401")]
	public class UiInputFieldSetCharacterLimit : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D66EC", Offset = "0x7D66EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D66EC", Offset = "0x7D66EC")]
		[Token(Token = "0x4001EE3")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6784", Offset = "0x7D6784")]
		[Token(Token = "0x4001EE4")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt characterLimit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D67D0", Offset = "0x7D67D0")]
		[Token(Token = "0x4001EE5")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6808", Offset = "0x7D6808")]
		[Token(Token = "0x4001EE6")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001EE7")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x4001EE8")]
		[FieldOffset(Offset = "0x88")]
		private int originalValue;

		[Token(Token = "0x60013DA")]
		[Address(RVA = "0x97C6B4", Offset = "0x97C6B4", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			characterLimit = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013DB")]
		[Address(RVA = "0x97C6C4", Offset = "0x97C6C4", Length = "0xC0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetCharacterLimit)+30]");
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
			originalValue = inputField.characterLimit;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60013DC")]
		[Address(RVA = "0x97C838", Offset = "0x97C838", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x60013DD")]
		[Address(RVA = "0x97C784", Offset = "0x97C784", Length = "0xB4")]
		private void DoSetValue()
		{
			if (inputField != null)
			{
				int value = characterLimit.Value;
				inputField.characterLimit = value;
			}
		}

		[Token(Token = "0x60013DE")]
		[Address(RVA = "0x97C83C", Offset = "0x97C83C", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				inputField.characterLimit = originalValue;
			}
		}

		[Token(Token = "0x60013DF")]
		[Address(RVA = "0x97C8E8", Offset = "0x97C8E8", Length = "0x50")]
		public UiInputFieldSetCharacterLimit()
		{
		}
	}
}
