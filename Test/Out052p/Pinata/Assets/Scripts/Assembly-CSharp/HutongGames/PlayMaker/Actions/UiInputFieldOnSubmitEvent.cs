using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761CE0", Offset = "0x761CE0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761CE0", Offset = "0x761CE0")]
	[Token(Token = "0x20003FD")]
	public class UiInputFieldOnSubmitEvent : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D61CC", Offset = "0x7D61CC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D61CC", Offset = "0x7D61CC")]
		[Token(Token = "0x4001ECD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D6264", Offset = "0x7D6264")]
		[Token(Token = "0x4001ECE")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D629C", Offset = "0x7D629C")]
		[Token(Token = "0x4001ECF")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D62D4", Offset = "0x7D62D4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D62D4", Offset = "0x7D62D4")]
		[Token(Token = "0x4001ED0")]
		[FieldOffset(Offset = "0x78")]
		public FsmString text;

		[Token(Token = "0x4001ED1")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x60013C4")]
		[Address(RVA = "0x97BA10", Offset = "0x97BA10", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmEventTarget self = FsmEventTarget.Self;
			sendEvent = null;
			text = null;
			eventTarget = self;
		}

		[Token(Token = "0x60013C5")]
		[Address(RVA = "0x97BA40", Offset = "0x97BA40", Length = "0x128")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldOnSubmitEvent)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.inputField = cachedComponent;
				if (cachedComponent != null)
				{
					InputField inputField = this.inputField;
					UnityAction<string> call = DoOnEndEdit;
					inputField.onEndEdit.AddListener(call);
				}
			}
		}

		[Token(Token = "0x60013C6")]
		[Address(RVA = "0x97BB68", Offset = "0x97BB68", Length = "0xF0")]
		public override void OnExit()
		{
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				UnityAction<string> call = DoOnEndEdit;
				inputField.onEndEdit.RemoveListener(call);
			}
		}

		[Token(Token = "0x60013C7")]
		[Address(RVA = "0x97BC58", Offset = "0x97BC58", Length = "0xD4")]
		public void DoOnEndEdit(string value)
		{
			InputField inputField = this.inputField;
			if (!inputField.wasCanceled)
			{
				FsmString fsmString = text;
				fsmString.Value = value;
				FsmEventData eventData = Fsm.EventData;
				eventData.StringData = value;
				SendEvent(eventTarget, sendEvent);
				Finish();
			}
		}

		[Token(Token = "0x60013C8")]
		[Address(RVA = "0x97BD2C", Offset = "0x97BD2C", Length = "0x50")]
		public UiInputFieldOnSubmitEvent()
		{
		}
	}
}
