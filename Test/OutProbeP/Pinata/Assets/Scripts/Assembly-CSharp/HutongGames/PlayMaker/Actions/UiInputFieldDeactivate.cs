using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761880", Offset = "0x761880")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761880", Offset = "0x761880")]
	[Token(Token = "0x20003EF")]
	public class UiInputFieldDeactivate : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D3FB4", Offset = "0x7D3FB4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3FB4", Offset = "0x7D3FB4")]
		[Token(Token = "0x4001E85")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D504C", Offset = "0x7D504C")]
		[Token(Token = "0x4001E86")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool activateOnExit;

		[Token(Token = "0x4001E87")]
		[FieldOffset(Offset = "0x70")]
		private InputField inputField;

		[Token(Token = "0x6001384")]
		[Address(RVA = "0x979F18", Offset = "0x979F18", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
			activateOnExit = null;
		}

		[Token(Token = "0x6001385")]
		[Address(RVA = "0x979F20", Offset = "0x979F20", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldDeactivate)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoAction();
			Finish();
		}

		[Token(Token = "0x6001386")]
		[Address(RVA = "0x979FAC", Offset = "0x979FAC", Length = "0x94")]
		private void DoAction()
		{
			if (inputField != null)
			{
				inputField.DeactivateInputField();
			}
		}

		[Token(Token = "0x6001387")]
		[Address(RVA = "0x97A040", Offset = "0x97A040", Length = "0xA8")]
		public override void OnExit()
		{
			if (!(inputField == null) && activateOnExit.Value)
			{
				inputField.ActivateInputField();
			}
		}

		[Token(Token = "0x6001388")]
		[Address(RVA = "0x97A0E8", Offset = "0x97A0E8", Length = "0x50")]
		public UiInputFieldDeactivate()
		{
		}
	}
}
