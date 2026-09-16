using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761EC0", Offset = "0x761EC0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761EC0", Offset = "0x761EC0")]
	[Token(Token = "0x2000403")]
	public class UiInputFieldSetPlaceHolder : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6970", Offset = "0x7D6970")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6970", Offset = "0x7D6970")]
		[Token(Token = "0x4001EEE")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6A08", Offset = "0x7D6A08")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6A08", Offset = "0x7D6A08")]
		[Token(Token = "0x4001EEF")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject placeholder;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6AA0", Offset = "0x7D6AA0")]
		[Token(Token = "0x4001EF0")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001EF1")]
		[FieldOffset(Offset = "0x78")]
		private InputField inputField;

		[Token(Token = "0x4001EF2")]
		[FieldOffset(Offset = "0x80")]
		private Graphic originalValue;

		[Token(Token = "0x60013E5")]
		[Address(RVA = "0x97CBA0", Offset = "0x97CBA0", Length = "0xC")]
		public override void Reset()
		{
			placeholder = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013E6")]
		[Address(RVA = "0x97CBAC", Offset = "0x97CBAC", Length = "0xAC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetPlaceHolder)+30]");
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
			originalValue = inputField.placeholder;
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x60013E7")]
		[Address(RVA = "0x97CC58", Offset = "0x97CC58", Length = "0x11C")]
		private void DoSetValue()
		{
			if (this.inputField != null)
			{
				GameObject value = placeholder.Value;
				Graphic graphic;
				InputField inputField;
				if (value == null)
				{
					graphic = null;
					inputField = this.inputField;
				}
				else
				{
					Graphic component = value.GetComponent<Graphic>();
					graphic = component;
					inputField = this.inputField;
				}
				inputField.placeholder = graphic;
			}
		}

		[Token(Token = "0x60013E8")]
		[Address(RVA = "0x97CD74", Offset = "0x97CD74", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				inputField.placeholder = originalValue;
			}
		}

		[Token(Token = "0x60013E9")]
		[Address(RVA = "0x97CE20", Offset = "0x97CE20", Length = "0x50")]
		public UiInputFieldSetPlaceHolder()
		{
		}
	}
}
