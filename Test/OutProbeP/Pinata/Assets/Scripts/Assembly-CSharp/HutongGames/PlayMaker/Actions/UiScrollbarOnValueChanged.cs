using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7620F0", Offset = "0x7620F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7620F0", Offset = "0x7620F0")]
	[Token(Token = "0x200040A")]
	public class UiScrollbarOnValueChanged : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D721C", Offset = "0x7D721C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D721C", Offset = "0x7D721C")]
		[Token(Token = "0x4001F10")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D72B4", Offset = "0x7D72B4")]
		[Token(Token = "0x4001F11")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D72EC", Offset = "0x7D72EC")]
		[Token(Token = "0x4001F12")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7324", Offset = "0x7D7324")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D7324", Offset = "0x7D7324")]
		[Token(Token = "0x4001F13")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat value;

		[Token(Token = "0x4001F14")]
		[FieldOffset(Offset = "0x80")]
		private Scrollbar scrollbar;

		[Token(Token = "0x600140A")]
		[Address(RVA = "0x9814F0", Offset = "0x9814F0", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmEventTarget self = FsmEventTarget.Self;
			sendEvent = null;
			value = null;
			eventTarget = self;
		}

		[Token(Token = "0x600140B")]
		[Address(RVA = "0x981520", Offset = "0x981520", Length = "0x128")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarOnValueChanged)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.scrollbar = cachedComponent;
				if (cachedComponent != null)
				{
					Scrollbar scrollbar = this.scrollbar;
					UnityAction<float> call = DoOnValueChanged;
					scrollbar.onValueChanged.AddListener(call);
				}
			}
		}

		[Token(Token = "0x600140C")]
		[Address(RVA = "0x981648", Offset = "0x981648", Length = "0xF0")]
		public override void OnExit()
		{
			if (this.scrollbar != null)
			{
				Scrollbar scrollbar = this.scrollbar;
				UnityAction<float> call = DoOnValueChanged;
				scrollbar.onValueChanged.RemoveListener(call);
			}
		}

		[Token(Token = "0x600140D")]
		[Address(RVA = "0x981738", Offset = "0x981738", Length = "0xA8")]
		public void DoOnValueChanged(float _value)
		{
			FsmFloat fsmFloat = value;
			fsmFloat.Value = _value;
			FsmEventData eventData = Fsm.EventData;
			eventData.FloatData = _value;
			SendEvent(eventTarget, sendEvent);
		}

		[Token(Token = "0x600140E")]
		[Address(RVA = "0x9817E0", Offset = "0x9817E0", Length = "0x50")]
		public UiScrollbarOnValueChanged()
		{
		}
	}
}
