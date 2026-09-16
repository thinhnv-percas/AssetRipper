using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761AB0", Offset = "0x761AB0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761AB0", Offset = "0x761AB0")]
	[Token(Token = "0x20003F6")]
	public class UiInputFieldGetText : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D58C4", Offset = "0x7D58C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D58C4", Offset = "0x7D58C4")]
		[Token(Token = "0x4001EA6")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D595C", Offset = "0x7D595C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D595C", Offset = "0x7D595C")]
		[Token(Token = "0x4001EA7")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[Token(Token = "0x4001EA8")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001EA9")]
		[FieldOffset(Offset = "0x78")]
		private InputField inputField;

		[Token(Token = "0x60013A4")]
		[Address(RVA = "0x97ABF0", Offset = "0x97ABF0", Length = "0xC")]
		public override void Reset()
		{
			text = null;
			everyFrame = false;
		}

		[Token(Token = "0x60013A5")]
		[Address(RVA = "0x97ABFC", Offset = "0x97ABFC", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetText)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetTextValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60013A6")]
		[Address(RVA = "0x97AD34", Offset = "0x97AD34", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetTextValue();
		}

		[Token(Token = "0x60013A7")]
		[Address(RVA = "0x97AC9C", Offset = "0x97AC9C", Length = "0x98")]
		private void DoGetTextValue()
		{
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				FsmString fsmString = text;
				fsmString.Value = inputField.text;
			}
		}

		[Token(Token = "0x60013A8")]
		[Address(RVA = "0x97AD38", Offset = "0x97AD38", Length = "0x50")]
		public UiInputFieldGetText()
		{
		}
	}
}
