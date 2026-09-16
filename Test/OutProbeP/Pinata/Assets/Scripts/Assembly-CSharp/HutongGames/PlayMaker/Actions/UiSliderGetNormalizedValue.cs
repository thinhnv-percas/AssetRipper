using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762410", Offset = "0x762410")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762410", Offset = "0x762410")]
	[Token(Token = "0x2000414")]
	public class UiSliderGetNormalizedValue : ComponentAction<Slider>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D805C", Offset = "0x7D805C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D805C", Offset = "0x7D805C")]
		[Token(Token = "0x4001F49")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D80F4", Offset = "0x7D80F4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D80F4", Offset = "0x7D80F4")]
		[Token(Token = "0x4001F4A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8154", Offset = "0x7D8154")]
		[Token(Token = "0x4001F4B")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001F4C")]
		[FieldOffset(Offset = "0x78")]
		private Slider slider;

		[Token(Token = "0x6001441")]
		[Address(RVA = "0x9834E8", Offset = "0x9834E8", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			value = null;
		}

		[Token(Token = "0x6001442")]
		[Address(RVA = "0x9834F4", Offset = "0x9834F4", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderGetNormalizedValue)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				slider = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001443")]
		[Address(RVA = "0x983634", Offset = "0x983634", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001444")]
		[Address(RVA = "0x983594", Offset = "0x983594", Length = "0xA0")]
		private void DoGetValue()
		{
			if (slider != null)
			{
				FsmFloat fsmFloat = value;
				float normalizedValue = slider.normalizedValue;
				fsmFloat.Value = normalizedValue;
			}
		}

		[Token(Token = "0x6001445")]
		[Address(RVA = "0x983638", Offset = "0x983638", Length = "0x50")]
		public UiSliderGetNormalizedValue()
		{
		}
	}
}
