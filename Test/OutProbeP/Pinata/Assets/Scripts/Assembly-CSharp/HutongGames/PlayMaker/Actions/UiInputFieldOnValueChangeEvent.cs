using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761D30", Offset = "0x761D30")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761D30", Offset = "0x761D30")]
	[Token(Token = "0x20003FE")]
	public class UiInputFieldOnValueChangeEvent : ComponentAction<InputField>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6324", Offset = "0x7D6324")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D6324", Offset = "0x7D6324")]
		[Token(Token = "0x4001ED2")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D63BC", Offset = "0x7D63BC")]
		[Token(Token = "0x4001ED3")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D63F4", Offset = "0x7D63F4")]
		[Token(Token = "0x4001ED4")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D642C", Offset = "0x7D642C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D642C", Offset = "0x7D642C")]
		[Token(Token = "0x4001ED5")]
		[FieldOffset(Offset = "0x78")]
		public FsmString text;

		[Token(Token = "0x4001ED6")]
		[FieldOffset(Offset = "0x80")]
		private InputField inputField;

		[Token(Token = "0x60013C9")]
		[Address(RVA = "0x97BD7C", Offset = "0x97BD7C", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			text = null;
			FsmEventTarget self = FsmEventTarget.Self;
			eventTarget = self;
			sendEvent = null;
		}

		[Token(Token = "0x60013CA")]
		[Address(RVA = "0x97BDAC", Offset = "0x97BDAC", Length = "0x128")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiInputFieldOnValueChangeEvent)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.inputField = cachedComponent;
				if (cachedComponent != null)
				{
					InputField inputField = this.inputField;
					UnityAction<string> call = DoOnValueChange;
					inputField.onValueChange.AddListener(call);
				}
			}
		}

		[Token(Token = "0x60013CB")]
		[Address(RVA = "0x97BED4", Offset = "0x97BED4", Length = "0xF0")]
		public override void OnExit()
		{
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				UnityAction<string> call = DoOnValueChange;
				inputField.onValueChange.RemoveListener(call);
			}
		}

		[Token(Token = "0x60013CC")]
		[Address(RVA = "0x97BFC4", Offset = "0x97BFC4", Length = "0xA8")]
		public void DoOnValueChange(string value)
		{
			FsmString fsmString = text;
			fsmString.Value = value;
			FsmEventData eventData = Fsm.EventData;
			eventData.StringData = value;
			SendEvent(eventTarget, sendEvent);
		}

		[Token(Token = "0x60013CD")]
		[Address(RVA = "0x97C06C", Offset = "0x97C06C", Length = "0x50")]
		public UiInputFieldOnValueChangeEvent()
		{
		}
	}
}
