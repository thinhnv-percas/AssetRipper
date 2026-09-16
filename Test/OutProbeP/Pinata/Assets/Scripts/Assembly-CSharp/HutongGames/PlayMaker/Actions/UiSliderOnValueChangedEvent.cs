using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762500", Offset = "0x762500")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762500", Offset = "0x762500")]
	[Token(Token = "0x2000417")]
	public class UiSliderOnValueChangedEvent : ComponentAction<Slider>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D8414", Offset = "0x7D8414")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8414", Offset = "0x7D8414")]
		[Token(Token = "0x4001F56")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D84AC", Offset = "0x7D84AC")]
		[Token(Token = "0x4001F57")]
		[FieldOffset(Offset = "0x68")]
		public FsmEventTarget eventTarget;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D84E4", Offset = "0x7D84E4")]
		[Token(Token = "0x4001F58")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D851C", Offset = "0x7D851C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D851C", Offset = "0x7D851C")]
		[Token(Token = "0x4001F59")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat value;

		[Token(Token = "0x4001F5A")]
		[FieldOffset(Offset = "0x80")]
		private Slider slider;

		[Token(Token = "0x600144F")]
		[Address(RVA = "0x9839E0", Offset = "0x9839E0", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmEventTarget self = FsmEventTarget.Self;
			sendEvent = null;
			value = null;
			eventTarget = self;
		}

		[Token(Token = "0x6001450")]
		[Address(RVA = "0x983A10", Offset = "0x983A10", Length = "0x128")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderOnValueChangedEvent)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.slider = cachedComponent;
				if (cachedComponent != null)
				{
					Slider slider = this.slider;
					UnityAction<float> call = DoOnValueChanged;
					slider.onValueChanged.AddListener(call);
				}
			}
		}

		[Token(Token = "0x6001451")]
		[Address(RVA = "0x983B38", Offset = "0x983B38", Length = "0xF0")]
		public override void OnExit()
		{
			if (this.slider != null)
			{
				Slider slider = this.slider;
				UnityAction<float> call = DoOnValueChanged;
				slider.onValueChanged.RemoveListener(call);
			}
		}

		[Token(Token = "0x6001452")]
		[Address(RVA = "0x983C28", Offset = "0x983C28", Length = "0xA8")]
		public void DoOnValueChanged(float _value)
		{
			FsmFloat fsmFloat = value;
			fsmFloat.Value = _value;
			FsmEventData eventData = Fsm.EventData;
			eventData.FloatData = _value;
			SendEvent(eventTarget, sendEvent);
		}

		[Token(Token = "0x6001453")]
		[Address(RVA = "0x983CD0", Offset = "0x983CD0", Length = "0x50")]
		public UiSliderOnValueChangedEvent()
		{
		}
	}
}
