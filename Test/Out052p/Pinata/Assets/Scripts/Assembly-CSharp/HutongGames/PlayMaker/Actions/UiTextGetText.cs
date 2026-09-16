using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7626E0", Offset = "0x7626E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7626E0", Offset = "0x7626E0")]
	[Token(Token = "0x200041D")]
	public class UiTextGetText : ComponentAction<Text>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D8C60", Offset = "0x7D8C60")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8C60", Offset = "0x7D8C60")]
		[Token(Token = "0x4001F7A")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D8CF8", Offset = "0x7D8CF8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8CF8", Offset = "0x7D8CF8")]
		[Token(Token = "0x4001F7B")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8D58", Offset = "0x7D8D58")]
		[Token(Token = "0x4001F7C")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001F7D")]
		[FieldOffset(Offset = "0x78")]
		private Text uiText;

		[Token(Token = "0x6001470")]
		[Address(RVA = "0x984C3C", Offset = "0x984C3C", Length = "0xC")]
		public override void Reset()
		{
			text = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001471")]
		[Address(RVA = "0x984C48", Offset = "0x984C48", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiTextGetText)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				uiText = cachedComponent;
			}
			DoGetTextValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001472")]
		[Address(RVA = "0x984D90", Offset = "0x984D90", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetTextValue();
		}

		[Token(Token = "0x6001473")]
		[Address(RVA = "0x984CE8", Offset = "0x984CE8", Length = "0xA8")]
		private void DoGetTextValue()
		{
			if (uiText != null)
			{
				FsmString fsmString = text;
				string value = uiText.text;
				fsmString.Value = value;
			}
		}

		[Token(Token = "0x6001474")]
		[Address(RVA = "0x984D94", Offset = "0x984D94", Length = "0x50")]
		public UiTextGetText()
		{
		}
	}
}
