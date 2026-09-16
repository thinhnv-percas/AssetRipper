using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762370", Offset = "0x762370")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762370", Offset = "0x762370")]
	[Token(Token = "0x2000412")]
	public class UiSliderGetDirection : ComponentAction<Slider>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7DA8", Offset = "0x7D7DA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7DA8", Offset = "0x7D7DA8")]
		[Token(Token = "0x4001F41")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D7E40", Offset = "0x7D7E40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7E40", Offset = "0x7D7E40")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D7E40", Offset = "0x7D7E40")]
		[Token(Token = "0x4001F42")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7EEC", Offset = "0x7D7EEC")]
		[Token(Token = "0x4001F43")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001F44")]
		[FieldOffset(Offset = "0x78")]
		private Slider slider;

		[Token(Token = "0x6001438")]
		[Address(RVA = "0x98316C", Offset = "0x98316C", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			direction = null;
		}

		[Token(Token = "0x6001439")]
		[Address(RVA = "0x983178", Offset = "0x983178", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderGetDirection)+30]");
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

		[Token(Token = "0x600143A")]
		[Address(RVA = "0x9832DC", Offset = "0x9832DC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x600143B")]
		[Address(RVA = "0x983218", Offset = "0x983218", Length = "0xC4")]
		private void DoGetValue()
		{
			if (this.slider != null)
			{
				Slider slider = this.slider;
				Slider.Direction direction = slider.direction;
				Enum value = direction;
				this.direction.Value = value;
			}
		}

		[Token(Token = "0x600143C")]
		[Address(RVA = "0x9832E0", Offset = "0x9832E0", Length = "0x50")]
		public UiSliderGetDirection()
		{
		}
	}
}
