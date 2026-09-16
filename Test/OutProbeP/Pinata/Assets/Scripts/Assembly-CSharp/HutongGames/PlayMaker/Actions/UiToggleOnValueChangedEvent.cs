using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7627D0", Offset = "0x7627D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7627D0", Offset = "0x7627D0")]
	[Token(Token = "0x2000420")]
	public class UiToggleOnValueChangedEvent : ComponentAction<Toggle>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D9078", Offset = "0x7D9078")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9078", Offset = "0x7D9078")]
		[Token(Token = "0x4001F8A")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9110", Offset = "0x7D9110")]
		[Token(Token = "0x4001F8B")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9148", Offset = "0x7D9148")]
		[Token(Token = "0x4001F8C")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9180", Offset = "0x7D9180")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9180", Offset = "0x7D9180")]
		[Token(Token = "0x4001F8D")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool value;

		[Token(Token = "0x4001F8E")]
		[FieldOffset(Offset = "0x80")]
		private Toggle toggle;

		[Token(Token = "0x6001480")]
		[Address(RVA = "0x98524C", Offset = "0x98524C", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmEventTarget self = FsmEventTarget.Self;
			sendEvent = null;
			value = null;
			eventTarget = self;
		}

		[Token(Token = "0x6001481")]
		[Address(RVA = "0x98527C", Offset = "0x98527C", Length = "0x20C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiToggleOnValueChangedEvent)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			string text3;
			if (UpdateCache(ownerDefaultTarget))
			{
				if (this.toggle != null)
				{
					Toggle toggle = this.toggle;
					UnityAction<bool> call = DoOnValueChanged;
					toggle.onValueChanged.RemoveListener(call);
				}
				this.toggle = cachedComponent;
				if (cachedComponent != null)
				{
					Toggle toggle2 = this.toggle;
					UnityAction<bool> call2 = DoOnValueChanged;
					toggle2.onValueChanged.AddListener(call2);
					return;
				}
				string text = ownerDefaultTarget.name;
				string text2 = "Missing UI.Toggle on " + text;
				text3 = text2;
			}
			else
			{
				text3 = "Missing GameObject";
			}
			LogError(text3);
		}

		[Token(Token = "0x6001482")]
		[Address(RVA = "0x985488", Offset = "0x985488", Length = "0xF0")]
		public override void OnExit()
		{
			if (this.toggle != null)
			{
				Toggle toggle = this.toggle;
				UnityAction<bool> call = DoOnValueChanged;
				toggle.onValueChanged.RemoveListener(call);
			}
		}

		[Token(Token = "0x6001483")]
		[Address(RVA = "0x985578", Offset = "0x985578", Length = "0xAC")]
		public void DoOnValueChanged(bool _value)
		{
			FsmBool fsmBool = value;
			fsmBool.value = _value;
			FsmEventData eventData = Fsm.EventData;
			eventData.BoolData = _value;
			SendEvent(eventTarget, sendEvent);
		}

		[Token(Token = "0x6001484")]
		[Address(RVA = "0x985624", Offset = "0x985624", Length = "0x50")]
		public UiToggleOnValueChangedEvent()
		{
		}
	}
}
