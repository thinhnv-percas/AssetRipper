using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761F10", Offset = "0x761F10")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761F10", Offset = "0x761F10")]
	[Token(Token = "0x2000404")]
	public class UiInputFieldSetSelectionColor : ComponentAction<InputField>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6AD8", Offset = "0x7D6AD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6AD8", Offset = "0x7D6AD8")]
		[Token(Token = "0x4001EF3")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6B70", Offset = "0x7D6B70")]
		[Token(Token = "0x4001EF4")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor selectionColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6BBC", Offset = "0x7D6BBC")]
		[Token(Token = "0x4001EF5")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6BF4", Offset = "0x7D6BF4")]
		[Token(Token = "0x4001EF6")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001EF7")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x4001EF8")]
		[FieldOffset(Offset = "0x88")]
		private Color originalValue;

		[Token(Token = "0x60013EA")]
		[Address(RVA = "0x97CE70", Offset = "0x97CE70", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			selectionColor = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013EB")]
		[Address(RVA = "0x97CE80", Offset = "0x97CE80", Length = "0xD0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldSetSelectionColor)+30]");
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
			originalValue.r = inputField.m_SelectionColor.r;
			originalValue.g = inputField.m_SelectionColor.g;
			originalValue.a = inputField.m_SelectionColor.a;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60013EC")]
		[Address(RVA = "0x97CFF8", Offset = "0x97CFF8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x60013ED")]
		[Address(RVA = "0x97CF50", Offset = "0x97CF50", Length = "0xA8")]
		private void DoSetValue()
		{
			if (inputField != null)
			{
				FsmColor fsmColor = selectionColor;
				Color color = default(Color);
				color.r = fsmColor.value.r;
				color.g = fsmColor.value.g;
				color.b = fsmColor.value.b;
				color.a = fsmColor.value.a;
				inputField.selectionColor = color;
			}
		}

		[Token(Token = "0x60013EE")]
		[Address(RVA = "0x97CFFC", Offset = "0x97CFFC", Length = "0xB0")]
		public override void OnExit()
		{
			if (!(inputField == null) && resetOnExit.Value)
			{
				Color color = default(Color);
				color.r = originalValue.r;
				color.g = originalValue.g;
				color.b = originalValue.b;
				color.a = originalValue.a;
				inputField.selectionColor = color;
			}
		}

		[Token(Token = "0x60013EF")]
		[Address(RVA = "0x97D0AC", Offset = "0x97D0AC", Length = "0x50")]
		public UiInputFieldSetSelectionColor()
		{
		}
	}
}
