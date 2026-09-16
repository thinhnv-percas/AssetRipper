using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7625A0", Offset = "0x7625A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7625A0", Offset = "0x7625A0")]
	[Token(Token = "0x2000419")]
	public class UiSliderSetMinMax : ComponentAction<Slider>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D870C", Offset = "0x7D870C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D870C", Offset = "0x7D870C")]
		[Token(Token = "0x4001F61")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D87A4", Offset = "0x7D87A4")]
		[Token(Token = "0x4001F62")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat minValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D87DC", Offset = "0x7D87DC")]
		[Token(Token = "0x4001F63")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat maxValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D8814", Offset = "0x7D8814")]
		[Token(Token = "0x4001F64")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool resetOnExit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D884C", Offset = "0x7D884C")]
		[Token(Token = "0x4001F65")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x4001F66")]
		[FieldOffset(Offset = "0x88")]
		private Slider slider;

		[Token(Token = "0x4001F67")]
		[FieldOffset(Offset = "0x90")]
		private float originalMinValue;

		[Token(Token = "0x4001F68")]
		[FieldOffset(Offset = "0x94")]
		private float originalMaxValue;

		[Token(Token = "0x6001459")]
		[Address(RVA = "0x98413C", Offset = "0x98413C", Length = "0xA4")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			minValue = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			maxValue = fsmFloat2;
			resetOnExit = null;
			everyFrame = false;
		}

		[Token(Token = "0x600145A")]
		[Address(RVA = "0x9841E0", Offset = "0x9841E0", Length = "0xD4")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderSetMinMax)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.slider = cachedComponent;
			}
			if (resetOnExit.Value)
			{
				Slider slider = this.slider;
				originalMinValue = slider.minValue;
				originalMaxValue = slider.maxValue;
			}
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600145B")]
		[Address(RVA = "0x9843B0", Offset = "0x9843B0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x600145C")]
		[Address(RVA = "0x9842B4", Offset = "0x9842B4", Length = "0xFC")]
		private void DoSetValue()
		{
			if (!(slider == null))
			{
				if (!minValue.IsNone)
				{
					float value = minValue.Value;
					slider.minValue = value;
				}
				if (!maxValue.IsNone)
				{
					float value2 = maxValue.Value;
					slider.maxValue = value2;
				}
			}
		}

		[Token(Token = "0x600145D")]
		[Address(RVA = "0x9843B4", Offset = "0x9843B4", Length = "0xC0")]
		public override void OnExit()
		{
			if (!(slider == null) && resetOnExit.Value)
			{
				slider.minValue = originalMinValue;
				slider.maxValue = originalMaxValue;
			}
		}

		[Token(Token = "0x600145E")]
		[Address(RVA = "0x984474", Offset = "0x984474", Length = "0x50")]
		public UiSliderSetMinMax()
		{
		}
	}
}
