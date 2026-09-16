using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761C90", Offset = "0x761C90")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761C90", Offset = "0x761C90")]
	[Token(Token = "0x20003FC")]
	public class UiInputFieldOnEndEditEvent : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6024", Offset = "0x7D6024")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D6024", Offset = "0x7D6024")]
		[Token(Token = "0x4001EC7")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D60BC", Offset = "0x7D60BC")]
		[Token(Token = "0x4001EC8")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D60F4", Offset = "0x7D60F4")]
		[Token(Token = "0x4001EC9")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D612C", Offset = "0x7D612C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D612C", Offset = "0x7D612C")]
		[Token(Token = "0x4001ECA")]
		[FieldOffset(Offset = "0x78")]
		public FsmString text;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D617C", Offset = "0x7D617C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D617C", Offset = "0x7D617C")]
		[Token(Token = "0x4001ECB")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool wasCanceled;

		[Token(Token = "0x4001ECC")]
		[FieldOffset(Offset = "0x88")]
		private InputField inputField;

		[Token(Token = "0x60013BF")]
		[Address(RVA = "0x97B6B0", Offset = "0x97B6B0", Length = "0x10")]
		public override void Reset()
		{
			gameObject = null;
			text = null;
			wasCanceled = null;
			sendEvent = null;
		}

		[Token(Token = "0x60013C0")]
		[Address(RVA = "0x97B6C0", Offset = "0x97B6C0", Length = "0x128")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldOnEndEditEvent)+30]");
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

		[Token(Token = "0x60013C1")]
		[Address(RVA = "0x97B7E8", Offset = "0x97B7E8", Length = "0xF0")]
		public override void OnExit()
		{
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				UnityAction<string> call = DoOnEndEdit;
				inputField.onEndEdit.RemoveListener(call);
			}
		}

		[Token(Token = "0x60013C2")]
		[Address(RVA = "0x97B8D8", Offset = "0x97B8D8", Length = "0xE8")]
		public void DoOnEndEdit(string value)
		{
			FsmString fsmString = text;
			fsmString.Value = value;
			InputField inputField = this.inputField;
			FsmBool fsmBool = wasCanceled;
			fsmBool.value = inputField.wasCanceled;
			FsmEventData eventData = Fsm.EventData;
			eventData.StringData = value;
			InputField inputField2 = this.inputField;
			FsmEventData eventData2 = Fsm.EventData;
			eventData2.BoolData = inputField2.wasCanceled;
			SendEvent(eventTarget, sendEvent);
			Finish();
		}

		[Token(Token = "0x60013C3")]
		[Address(RVA = "0x97B9C0", Offset = "0x97B9C0", Length = "0x50")]
		public UiInputFieldOnEndEditEvent()
		{
		}
	}
}
