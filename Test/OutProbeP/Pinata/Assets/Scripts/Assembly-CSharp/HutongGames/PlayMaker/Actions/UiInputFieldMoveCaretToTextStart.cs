using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761C40", Offset = "0x761C40")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761C40", Offset = "0x761C40")]
	[Token(Token = "0x20003FB")]
	public class UiInputFieldMoveCaretToTextStart : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5F54", Offset = "0x7D5F54")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5F54", Offset = "0x7D5F54")]
		[Token(Token = "0x4001EC4")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5FEC", Offset = "0x7D5FEC")]
		[Token(Token = "0x4001EC5")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool shift;

		[Token(Token = "0x4001EC6")]
		[FieldOffset(Offset = "0x70")]
		private InputField inputField;

		[Token(Token = "0x60013BB")]
		[Address(RVA = "0x97B4F0", Offset = "0x97B4F0", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = true;
			shift = fsmBool;
		}

		[Token(Token = "0x60013BC")]
		[Address(RVA = "0x97B520", Offset = "0x97B520", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldMoveCaretToTextStart)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoAction();
			Finish();
		}

		[Token(Token = "0x60013BD")]
		[Address(RVA = "0x97B5AC", Offset = "0x97B5AC", Length = "0xB4")]
		private void DoAction()
		{
			if (inputField != null)
			{
				bool value = shift.Value;
				inputField.MoveTextStart(value);
			}
		}

		[Token(Token = "0x60013BE")]
		[Address(RVA = "0x97B660", Offset = "0x97B660", Length = "0x50")]
		public UiInputFieldMoveCaretToTextStart()
		{
		}
	}
}
