using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761A60", Offset = "0x761A60")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761A60", Offset = "0x761A60")]
	[Token(Token = "0x20003F5")]
	public class UiInputFieldGetSelectionColor : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5794", Offset = "0x7D5794")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5794", Offset = "0x7D5794")]
		[Token(Token = "0x4001EA2")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D582C", Offset = "0x7D582C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D582C", Offset = "0x7D582C")]
		[Token(Token = "0x4001EA3")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor selectionColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D588C", Offset = "0x7D588C")]
		[Token(Token = "0x4001EA4")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001EA5")]
		[FieldOffset(Offset = "0x78")]
		private InputField inputField;

		[Token(Token = "0x600139F")]
		[Address(RVA = "0x97AA48", Offset = "0x97AA48", Length = "0xC")]
		public override void Reset()
		{
			selectionColor = null;
			everyFrame = false;
		}

		[Token(Token = "0x60013A0")]
		[Address(RVA = "0x97AA54", Offset = "0x97AA54", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetSelectionColor)+30]");
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

		[Token(Token = "0x60013A1")]
		[Address(RVA = "0x97AB9C", Offset = "0x97AB9C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x60013A2")]
		[Address(RVA = "0x97AAF4", Offset = "0x97AAF4", Length = "0xA8")]
		private void DoGetValue()
		{
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				FsmColor fsmColor = selectionColor;
				fsmColor.value.r = inputField.m_SelectionColor.r;
				fsmColor.value.g = inputField.m_SelectionColor.g;
				fsmColor.value.a = inputField.m_SelectionColor.a;
			}
		}

		[Token(Token = "0x60013A3")]
		[Address(RVA = "0x97ABA0", Offset = "0x97ABA0", Length = "0x50")]
		public UiInputFieldGetSelectionColor()
		{
		}
	}
}
