using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762690", Offset = "0x762690")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762690", Offset = "0x762690")]
	[Token(Token = "0x200041C")]
	public class UiSliderSetWholeNumbers : ComponentAction<Slider>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D8B44", Offset = "0x7D8B44")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8B44", Offset = "0x7D8B44")]
		[Token(Token = "0x4001F75")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8BDC", Offset = "0x7D8BDC")]
		[Token(Token = "0x4001F76")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool wholeNumbers;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8C28", Offset = "0x7D8C28")]
		[Token(Token = "0x4001F77")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001F78")]
		[FieldOffset(Offset = "0x78")]
		private Slider slider;

		[Token(Token = "0x4001F79")]
		[FieldOffset(Offset = "0x80")]
		private bool originalValue;

		[Token(Token = "0x600146B")]
		[Address(RVA = "0x9849D4", Offset = "0x9849D4", Length = "0xC")]
		public override void Reset()
		{
			wholeNumbers = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x600146C")]
		[Address(RVA = "0x9849E0", Offset = "0x9849E0", Length = "0xAC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderSetWholeNumbers)+30]");
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
			originalValue = slider.wholeNumbers;
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x600146D")]
		[Address(RVA = "0x984A8C", Offset = "0x984A8C", Length = "0xB4")]
		private void DoSetValue()
		{
			if (slider != null)
			{
				bool value = wholeNumbers.Value;
				slider.wholeNumbers = value;
			}
		}

		[Token(Token = "0x600146E")]
		[Address(RVA = "0x984B40", Offset = "0x984B40", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(slider == null) && resetOnExit.Value)
			{
				slider.wholeNumbers = originalValue;
			}
		}

		[Token(Token = "0x600146F")]
		[Address(RVA = "0x984BEC", Offset = "0x984BEC", Length = "0x50")]
		public UiSliderSetWholeNumbers()
		{
		}
	}
}
