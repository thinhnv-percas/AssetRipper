using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761830", Offset = "0x761830")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761830", Offset = "0x761830")]
	[Token(Token = "0x20003EE")]
	public class UiInputFieldActivate : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D3EE4", Offset = "0x7D3EE4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3EE4", Offset = "0x7D3EE4")]
		[Token(Token = "0x4001E82")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3F7C", Offset = "0x7D3F7C")]
		[Token(Token = "0x4001E83")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool deactivateOnExit;

		[Token(Token = "0x4001E84")]
		[FieldOffset(Offset = "0x70")]
		private InputField inputField;

		[Token(Token = "0x600137F")]
		[Address(RVA = "0x979CF8", Offset = "0x979CF8", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
			deactivateOnExit = null;
		}

		[Token(Token = "0x6001380")]
		[Address(RVA = "0x979D00", Offset = "0x979D00", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldActivate)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoAction();
			Finish();
		}

		[Token(Token = "0x6001381")]
		[Address(RVA = "0x979D8C", Offset = "0x979D8C", Length = "0x94")]
		private void DoAction()
		{
			if (inputField != null)
			{
				inputField.ActivateInputField();
			}
		}

		[Token(Token = "0x6001382")]
		[Address(RVA = "0x979E20", Offset = "0x979E20", Length = "0xA8")]
		public override void OnExit()
		{
			if (!(inputField == null) && deactivateOnExit.Value)
			{
				inputField.DeactivateInputField();
			}
		}

		[Token(Token = "0x6001383")]
		[Address(RVA = "0x979EC8", Offset = "0x979EC8", Length = "0x50")]
		public UiInputFieldActivate()
		{
		}
	}
}
