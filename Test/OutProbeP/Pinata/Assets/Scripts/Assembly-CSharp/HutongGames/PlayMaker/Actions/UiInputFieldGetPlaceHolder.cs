using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761A10", Offset = "0x761A10")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761A10", Offset = "0x761A10")]
	[Token(Token = "0x20003F4")]
	public class UiInputFieldGetPlaceHolder : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D5604", Offset = "0x7D5604")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5604", Offset = "0x7D5604")]
		[Token(Token = "0x4001E9C")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D569C", Offset = "0x7D569C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D569C", Offset = "0x7D569C")]
		[Token(Token = "0x4001E9D")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject placeHolder;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D56EC", Offset = "0x7D56EC")]
		[Token(Token = "0x4001E9E")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool placeHolderDefined;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D5724", Offset = "0x7D5724")]
		[Token(Token = "0x4001E9F")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent foundEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D575C", Offset = "0x7D575C")]
		[Token(Token = "0x4001EA0")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent notFoundEvent;

		[Token(Token = "0x4001EA1")]
		[FieldOffset(Offset = "0x88")]
		private InputField inputField;

		[Token(Token = "0x600139B")]
		[Address(RVA = "0x97A824", Offset = "0x97A824", Length = "0x10")]
		public override void Reset()
		{
			foundEvent = null;
			placeHolder = null;
		}

		[Token(Token = "0x600139C")]
		[Address(RVA = "0x97A834", Offset = "0x97A834", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetPlaceHolder)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				inputField = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x600139D")]
		[Address(RVA = "0x97A8C0", Offset = "0x97A8C0", Length = "0x138")]
		private void DoGetValue()
		{
			//IL_0100: Expected O, but got I
			//IL_00dc: Expected O, but got I
			if (!(this.inputField == null))
			{
				InputField inputField = this.inputField;
				FsmBool fsmBool = placeHolderDefined;
				bool value = inputField.placeholder != null;
				fsmBool.value = value;
				Fsm fsm;
				FsmEvent fsmEvent;
				if (inputField.placeholder != null)
				{
					GameObject value2 = inputField.placeholder.gameObject;
					placeHolder.Value = value2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetPlaceHolder)+30]");
					fsm = (Fsm)0;
					fsmEvent = foundEvent;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldGetPlaceHolder)+30]");
					fsm = (Fsm)0;
					fsmEvent = notFoundEvent;
				}
				fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x600139E")]
		[Address(RVA = "0x97A9F8", Offset = "0x97A9F8", Length = "0x50")]
		public UiInputFieldGetPlaceHolder()
		{
		}
	}
}
