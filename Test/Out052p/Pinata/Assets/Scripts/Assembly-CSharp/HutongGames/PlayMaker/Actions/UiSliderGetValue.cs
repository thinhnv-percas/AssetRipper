using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762460", Offset = "0x762460")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762460", Offset = "0x762460")]
	[Token(Token = "0x2000415")]
	public class UiSliderGetValue : ComponentAction<Slider>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D818C", Offset = "0x7D818C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D818C", Offset = "0x7D818C")]
		[Token(Token = "0x4001F4D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D8224", Offset = "0x7D8224")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8224", Offset = "0x7D8224")]
		[Token(Token = "0x4001F4E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8284", Offset = "0x7D8284")]
		[Token(Token = "0x4001F4F")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001F50")]
		[FieldOffset(Offset = "0x78")]
		private Slider slider;

		[Token(Token = "0x6001446")]
		[Address(RVA = "0x983688", Offset = "0x983688", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			value = null;
		}

		[Token(Token = "0x6001447")]
		[Address(RVA = "0x983694", Offset = "0x983694", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderGetValue)+30]");
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

		[Token(Token = "0x6001448")]
		[Address(RVA = "0x9837DC", Offset = "0x9837DC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001449")]
		[Address(RVA = "0x983734", Offset = "0x983734", Length = "0xA8")]
		private void DoGetValue()
		{
			if (slider != null)
			{
				FsmFloat fsmFloat = value;
				float num = slider.value;
				float num2 = default(float);
				fsmFloat.Value = num2;
			}
		}

		[Token(Token = "0x600144A")]
		[Address(RVA = "0x9837E0", Offset = "0x9837E0", Length = "0x50")]
		public UiSliderGetValue()
		{
		}
	}
}
