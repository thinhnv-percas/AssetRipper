using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7624B0", Offset = "0x7624B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7624B0", Offset = "0x7624B0")]
	[Token(Token = "0x2000416")]
	public class UiSliderGetWholeNumbers : ComponentAction<Slider>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D82BC", Offset = "0x7D82BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D82BC", Offset = "0x7D82BC")]
		[Token(Token = "0x4001F51")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D8354", Offset = "0x7D8354")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8354", Offset = "0x7D8354")]
		[Token(Token = "0x4001F52")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool wholeNumbers;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D83A4", Offset = "0x7D83A4")]
		[Token(Token = "0x4001F53")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isShowingWholeNumbersEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D83DC", Offset = "0x7D83DC")]
		[Token(Token = "0x4001F54")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isNotShowingWholeNumbersEvent;

		[Token(Token = "0x4001F55")]
		[FieldOffset(Offset = "0x80")]
		private Slider slider;

		[Token(Token = "0x600144B")]
		[Address(RVA = "0x983830", Offset = "0x983830", Length = "0xC")]
		public override void Reset()
		{
			gameObject = null;
			isShowingWholeNumbersEvent = null;
		}

		[Token(Token = "0x600144C")]
		[Address(RVA = "0x98383C", Offset = "0x98383C", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderGetWholeNumbers)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				slider = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x600144D")]
		[Address(RVA = "0x9838C8", Offset = "0x9838C8", Length = "0xC8")]
		private void DoGetValue()
		{
			//IL_0099: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_011b: Expected O, but got I
			bool flag3;
			if (this.slider != null)
			{
				Slider slider = this.slider;
				bool flag = !slider.wholeNumbers;
				bool flag2 = !flag;
				flag3 = flag2;
			}
			else
			{
				flag3 = false;
			}
			FsmBool fsmBool = wholeNumbers;
			fsmBool.value = flag3;
			object obj = (long)(IntPtr)this + 112L;
			object obj2 = (long)(IntPtr)this + 120L;
			object fsmEvent = ((!flag3) ? obj2 : obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderGetWholeNumbers)+30]");
			((Fsm)0).Event((FsmEvent)fsmEvent);
		}

		[Token(Token = "0x600144E")]
		[Address(RVA = "0x983990", Offset = "0x983990", Length = "0x50")]
		public UiSliderGetWholeNumbers()
		{
		}
	}
}
