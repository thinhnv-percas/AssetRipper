using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761BF0", Offset = "0x761BF0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761BF0", Offset = "0x761BF0")]
	[Token(Token = "0x20003FA")]
	public class UiInputFieldMoveCaretToTextEnd : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5E84", Offset = "0x7D5E84")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5E84", Offset = "0x7D5E84")]
		[Token(Token = "0x4001EC1")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5F1C", Offset = "0x7D5F1C")]
		[Token(Token = "0x4001EC2")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool shift;

		[Token(Token = "0x4001EC3")]
		[FieldOffset(Offset = "0x70")]
		private InputField inputField;

		[Token(Token = "0x60013B7")]
		[Address(RVA = "0x97B330", Offset = "0x97B330", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = true;
			shift = fsmBool;
		}

		[Token(Token = "0x60013B8")]
		[Address(RVA = "0x97B360", Offset = "0x97B360", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldMoveCaretToTextEnd)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoAction();
			Finish();
		}

		[Token(Token = "0x60013B9")]
		[Address(RVA = "0x97B3EC", Offset = "0x97B3EC", Length = "0xB4")]
		private void DoAction()
		{
			if (inputField != null)
			{
				bool value = shift.Value;
				inputField.MoveTextEnd(value);
			}
		}

		[Token(Token = "0x60013BA")]
		[Address(RVA = "0x97B4A0", Offset = "0x97B4A0", Length = "0x50")]
		public UiInputFieldMoveCaretToTextEnd()
		{
		}
	}
}
