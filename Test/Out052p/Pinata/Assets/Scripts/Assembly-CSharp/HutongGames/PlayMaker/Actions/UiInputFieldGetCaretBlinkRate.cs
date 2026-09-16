using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7618D0", Offset = "0x7618D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7618D0", Offset = "0x7618D0")]
	[Token(Token = "0x20003F0")]
	public class UiInputFieldGetCaretBlinkRate : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5084", Offset = "0x7D5084")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5084", Offset = "0x7D5084")]
		[Token(Token = "0x4001E88")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D511C", Offset = "0x7D511C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D511C", Offset = "0x7D511C")]
		[Token(Token = "0x4001E89")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat caretBlinkRate;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D517C", Offset = "0x7D517C")]
		[Token(Token = "0x4001E8A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001E8B")]
		[FieldOffset(Offset = "0x78")]
		private InputField inputField;

		[Token(Token = "0x6001389")]
		[Address(RVA = "0x97A138", Offset = "0x97A138", Length = "0xC")]
		public override void Reset()
		{
			caretBlinkRate = null;
			everyFrame = false;
		}

		[Token(Token = "0x600138A")]
		[Address(RVA = "0x97A144", Offset = "0x97A144", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetCaretBlinkRate)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600138B")]
		[Address(RVA = "0x97A27C", Offset = "0x97A27C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x600138C")]
		[Address(RVA = "0x97A1E4", Offset = "0x97A1E4", Length = "0x98")]
		private void DoGetValue()
		{
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				FsmFloat fsmFloat = caretBlinkRate;
				fsmFloat.Value = inputField.caretBlinkRate;
			}
		}

		[Token(Token = "0x600138D")]
		[Address(RVA = "0x97A280", Offset = "0x97A280", Length = "0x50")]
		public UiInputFieldGetCaretBlinkRate()
		{
		}
	}
}
