using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761F60", Offset = "0x761F60")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761F60", Offset = "0x761F60")]
	[Token(Token = "0x2000405")]
	public class UiInputFieldSetText : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6C2C", Offset = "0x7D6C2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6C2C", Offset = "0x7D6C2C")]
		[Token(Token = "0x4001EF9")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D6CC4", Offset = "0x7D6CC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6CC4", Offset = "0x7D6CC4")]
		[Token(Token = "0x4001EFA")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6D14", Offset = "0x7D6D14")]
		[Token(Token = "0x4001EFB")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6D4C", Offset = "0x7D6D4C")]
		[Token(Token = "0x4001EFC")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001EFD")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x4001EFE")]
		[FieldOffset(Offset = "0x88")]
		private string originalString;

		[Token(Token = "0x60013F0")]
		[Address(RVA = "0x97D0FC", Offset = "0x97D0FC", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			text = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013F1")]
		[Address(RVA = "0x97D10C", Offset = "0x97D10C", Length = "0xC0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetText)+30]");
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
			originalString = inputField.text;
			DoSetTextValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60013F2")]
		[Address(RVA = "0x97D280", Offset = "0x97D280", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetTextValue();
		}

		[Token(Token = "0x60013F3")]
		[Address(RVA = "0x97D1CC", Offset = "0x97D1CC", Length = "0xB4")]
		private void DoSetTextValue()
		{
			if (inputField != null)
			{
				string value = text.Value;
				inputField.text = value;
			}
		}

		[Token(Token = "0x60013F4")]
		[Address(RVA = "0x97D284", Offset = "0x97D284", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				inputField.text = originalString;
			}
		}

		[Token(Token = "0x60013F5")]
		[Address(RVA = "0x97D330", Offset = "0x97D330", Length = "0x50")]
		public UiInputFieldSetText()
		{
		}
	}
}
