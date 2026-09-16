using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762640", Offset = "0x762640")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762640", Offset = "0x762640")]
	[Token(Token = "0x200041B")]
	public class UiSliderSetValue : ComponentAction<Slider>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D89F0", Offset = "0x7D89F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D89F0", Offset = "0x7D89F0")]
		[Token(Token = "0x4001F6F")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8A88", Offset = "0x7D8A88")]
		[Token(Token = "0x4001F70")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8AD4", Offset = "0x7D8AD4")]
		[Token(Token = "0x4001F71")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8B0C", Offset = "0x7D8B0C")]
		[Token(Token = "0x4001F72")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F73")]
		[FieldOffset(Offset = "0x80")]
		private Slider slider;

		[Token(Token = "0x4001F74")]
		[FieldOffset(Offset = "0x88")]
		private float originalValue;

		[Token(Token = "0x6001465")]
		[Address(RVA = "0x984740", Offset = "0x984740", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			value = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001466")]
		[Address(RVA = "0x984750", Offset = "0x984750", Length = "0xC4")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderSetValue)+30]");
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
			float num = slider.value;
			float num2 = default(float);
			originalValue = num2;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001467")]
		[Address(RVA = "0x9848CC", Offset = "0x9848CC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001468")]
		[Address(RVA = "0x984814", Offset = "0x984814", Length = "0xB8")]
		private void DoSetValue()
		{
			//IL_0058: Expected I, but got O
			//IL_0068: Expected O, but got I
			//IL_0078: Expected O, but got I
			if (this.slider != null)
			{
				Slider slider = this.slider;
				float num = value.Value;
				IntPtr intPtr = (IntPtr)slider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v7 (Il2CppClass<UnityEngine.UI.Slider>)+420]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v7 (Il2CppClass<UnityEngine.UI.Slider>)+428]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6001469")]
		[Address(RVA = "0x9848D0", Offset = "0x9848D0", Length = "0xB4")]
		public override void OnExit()
		{
			//IL_0080: Expected I, but got O
			//IL_009a: Expected O, but got I
			//IL_00aa: Expected O, but got I
			if (!(this.slider == null) && resetOnExit.Value)
			{
				Slider slider = this.slider;
				IntPtr intPtr = (IntPtr)slider;
				float num = originalValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v7 (Il2CppClass<UnityEngine.UI.Slider>)+420]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v7 (Il2CppClass<UnityEngine.UI.Slider>)+428]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v83 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600146A")]
		[Address(RVA = "0x984984", Offset = "0x984984", Length = "0x50")]
		public UiSliderSetValue()
		{
		}
	}
}
