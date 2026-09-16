using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762230", Offset = "0x762230")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762230", Offset = "0x762230")]
	[Token(Token = "0x200040E")]
	public class UiScrollbarSetValue : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D77D4", Offset = "0x7D77D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D77D4", Offset = "0x7D77D4")]
		[Token(Token = "0x4001F27")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D786C", Offset = "0x7D786C")]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D786C", Offset = "0x7D786C")]
		[Token(Token = "0x4001F28")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D78D0", Offset = "0x7D78D0")]
		[Token(Token = "0x4001F29")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7908", Offset = "0x7D7908")]
		[Token(Token = "0x4001F2A")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F2B")]
		[FieldOffset(Offset = "0x80")]
		private Scrollbar scrollbar;

		[Token(Token = "0x4001F2C")]
		[FieldOffset(Offset = "0x88")]
		private float originalValue;

		[Token(Token = "0x6001420")]
		[Address(RVA = "0x982174", Offset = "0x982174", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			value = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001421")]
		[Address(RVA = "0x982184", Offset = "0x982184", Length = "0xBC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarSetValue)+30]");
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
			float num = scrollbar.value;
			originalValue = num;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001422")]
		[Address(RVA = "0x9822F0", Offset = "0x9822F0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001423")]
		[Address(RVA = "0x982240", Offset = "0x982240", Length = "0xB0")]
		private void DoSetValue()
		{
			if (scrollbar != null)
			{
				float num = value.Value;
				scrollbar.value = num;
			}
		}

		[Token(Token = "0x6001424")]
		[Address(RVA = "0x9822F4", Offset = "0x9822F4", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(scrollbar == null) && resetOnExit.Value)
			{
				scrollbar.value = originalValue;
			}
		}

		[Token(Token = "0x6001425")]
		[Address(RVA = "0x9823A0", Offset = "0x9823A0", Length = "0x50")]
		public UiScrollbarSetValue()
		{
		}
	}
}
