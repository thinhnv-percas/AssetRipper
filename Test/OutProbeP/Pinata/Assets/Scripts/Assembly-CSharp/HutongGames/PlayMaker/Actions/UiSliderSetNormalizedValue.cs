using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7625F0", Offset = "0x7625F0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7625F0", Offset = "0x7625F0")]
	[Token(Token = "0x200041A")]
	public class UiSliderSetNormalizedValue : ComponentAction<Slider>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D8884", Offset = "0x7D8884")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8884", Offset = "0x7D8884")]
		[Token(Token = "0x4001F69")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D891C", Offset = "0x7D891C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D891C", Offset = "0x7D891C")]
		[Token(Token = "0x4001F6A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8980", Offset = "0x7D8980")]
		[Token(Token = "0x4001F6B")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D89B8", Offset = "0x7D89B8")]
		[Token(Token = "0x4001F6C")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F6D")]
		[FieldOffset(Offset = "0x80")]
		private Slider slider;

		[Token(Token = "0x4001F6E")]
		[FieldOffset(Offset = "0x88")]
		private float originalValue;

		[Token(Token = "0x600145F")]
		[Address(RVA = "0x9844C4", Offset = "0x9844C4", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			value = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001460")]
		[Address(RVA = "0x9844D4", Offset = "0x9844D4", Length = "0xBC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderSetNormalizedValue)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Slider slider;
			if (UpdateCache(ownerDefaultTarget))
			{
				slider = cachedComponent;
				this.slider = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				slider = this.slider;
			}
			float normalizedValue = slider.normalizedValue;
			originalValue = normalizedValue;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001461")]
		[Address(RVA = "0x984640", Offset = "0x984640", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001462")]
		[Address(RVA = "0x984590", Offset = "0x984590", Length = "0xB0")]
		private void DoSetValue()
		{
			if (slider != null)
			{
				float normalizedValue = value.Value;
				slider.normalizedValue = normalizedValue;
			}
		}

		[Token(Token = "0x6001463")]
		[Address(RVA = "0x984644", Offset = "0x984644", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(slider == null) && resetOnExit.Value)
			{
				slider.normalizedValue = originalValue;
			}
		}

		[Token(Token = "0x6001464")]
		[Address(RVA = "0x9846F0", Offset = "0x9846F0", Length = "0x50")]
		public UiSliderSetNormalizedValue()
		{
		}
	}
}
