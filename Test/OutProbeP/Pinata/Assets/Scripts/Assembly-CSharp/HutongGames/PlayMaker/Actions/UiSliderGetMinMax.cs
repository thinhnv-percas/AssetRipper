using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7623C0", Offset = "0x7623C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7623C0", Offset = "0x7623C0")]
	[Token(Token = "0x2000413")]
	public class UiSliderGetMinMax : ComponentAction<Slider>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7F24", Offset = "0x7D7F24")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7F24", Offset = "0x7D7F24")]
		[Token(Token = "0x4001F45")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D7FBC", Offset = "0x7D7FBC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7FBC", Offset = "0x7D7FBC")]
		[Token(Token = "0x4001F46")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat minValue;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D800C", Offset = "0x7D800C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D800C", Offset = "0x7D800C")]
		[Token(Token = "0x4001F47")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat maxValue;

		[Token(Token = "0x4001F48")]
		[FieldOffset(Offset = "0x78")]
		private Slider slider;

		[Token(Token = "0x600143D")]
		[Address(RVA = "0x983330", Offset = "0x983330", Length = "0xC")]
		public override void Reset()
		{
			minValue = null;
			maxValue = null;
			gameObject = null;
		}

		[Token(Token = "0x600143E")]
		[Address(RVA = "0x98333C", Offset = "0x98333C", Length = "0x80")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderGetMinMax)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				slider = cachedComponent;
			}
			DoGetValue();
		}

		[Token(Token = "0x600143F")]
		[Address(RVA = "0x9833BC", Offset = "0x9833BC", Length = "0xDC")]
		private void DoGetValue()
		{
			if (this.slider != null)
			{
				if (!minValue.IsNone)
				{
					Slider slider = this.slider;
					FsmFloat fsmFloat = minValue;
					fsmFloat.Value = slider.minValue;
				}
				if (!maxValue.IsNone)
				{
					Slider slider2 = this.slider;
					FsmFloat fsmFloat2 = maxValue;
					fsmFloat2.Value = slider2.maxValue;
				}
			}
		}

		[Token(Token = "0x6001440")]
		[Address(RVA = "0x983498", Offset = "0x983498", Length = "0x50")]
		public UiSliderGetMinMax()
		{
		}
	}
}
