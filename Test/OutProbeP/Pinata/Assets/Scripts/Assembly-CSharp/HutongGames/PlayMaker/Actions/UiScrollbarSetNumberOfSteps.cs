using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762190", Offset = "0x762190")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762190", Offset = "0x762190")]
	[Token(Token = "0x200040C")]
	public class UiScrollbarSetNumberOfSteps : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7514", Offset = "0x7D7514")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7514", Offset = "0x7D7514")]
		[Token(Token = "0x4001F1B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D75AC", Offset = "0x7D75AC")]
		[Token(Token = "0x4001F1C")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt value;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D75F8", Offset = "0x7D75F8")]
		[Token(Token = "0x4001F1D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7630", Offset = "0x7D7630")]
		[Token(Token = "0x4001F1E")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F1F")]
		[FieldOffset(Offset = "0x80")]
		private Scrollbar scrollbar;

		[Token(Token = "0x4001F20")]
		[FieldOffset(Offset = "0x88")]
		private int originalValue;

		[Token(Token = "0x6001414")]
		[Address(RVA = "0x981C64", Offset = "0x981C64", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			value = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001415")]
		[Address(RVA = "0x981C74", Offset = "0x981C74", Length = "0xC0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarSetNumberOfSteps)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Scrollbar scrollbar;
			if (UpdateCache(ownerDefaultTarget))
			{
				scrollbar = cachedComponent;
				this.scrollbar = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				scrollbar = this.scrollbar;
			}
			originalValue = scrollbar.numberOfSteps;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001416")]
		[Address(RVA = "0x981DE8", Offset = "0x981DE8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001417")]
		[Address(RVA = "0x981D34", Offset = "0x981D34", Length = "0xB4")]
		private void DoSetValue()
		{
			if (scrollbar != null)
			{
				int numberOfSteps = value.Value;
				scrollbar.numberOfSteps = numberOfSteps;
			}
		}

		[Token(Token = "0x6001418")]
		[Address(RVA = "0x981DEC", Offset = "0x981DEC", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(scrollbar == null) && resetOnExit.Value)
			{
				scrollbar.numberOfSteps = originalValue;
			}
		}

		[Token(Token = "0x6001419")]
		[Address(RVA = "0x981E98", Offset = "0x981E98", Length = "0x50")]
		public UiScrollbarSetNumberOfSteps()
		{
		}
	}
}
