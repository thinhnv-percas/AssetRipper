using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762280", Offset = "0x762280")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762280", Offset = "0x762280")]
	[Token(Token = "0x200040F")]
	public class UiScrollRectSetHorizontal : ComponentAction<ScrollRect>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7940", Offset = "0x7D7940")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7940", Offset = "0x7D7940")]
		[Token(Token = "0x4001F2D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D79D8", Offset = "0x7D79D8")]
		[Token(Token = "0x4001F2E")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool horizontal;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7A10", Offset = "0x7D7A10")]
		[Token(Token = "0x4001F2F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7A48", Offset = "0x7D7A48")]
		[Token(Token = "0x4001F30")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F31")]
		[FieldOffset(Offset = "0x80")]
		private ScrollRect scrollRect;

		[Token(Token = "0x4001F32")]
		[FieldOffset(Offset = "0x88")]
		private bool originalValue;

		[Token(Token = "0x6001426")]
		[Address(RVA = "0x980914", Offset = "0x980914", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			horizontal = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001427")]
		[Address(RVA = "0x980924", Offset = "0x980924", Length = "0xC0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollRectSetHorizontal)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			ScrollRect scrollRect;
			if (UpdateCache(ownerDefaultTarget))
			{
				scrollRect = cachedComponent;
				this.scrollRect = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				scrollRect = this.scrollRect;
			}
			originalValue = scrollRect.vertical;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001428")]
		[Address(RVA = "0x980A88", Offset = "0x980A88", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001429")]
		[Address(RVA = "0x9809E4", Offset = "0x9809E4", Length = "0xA4")]
		private void DoSetValue()
		{
			if (this.scrollRect != null)
			{
				ScrollRect scrollRect = this.scrollRect;
				bool value = horizontal.Value;
				scrollRect.m_Horizontal = value;
			}
		}

		[Token(Token = "0x600142A")]
		[Address(RVA = "0x980A8C", Offset = "0x980A8C", Length = "0xA8")]
		public override void OnExit()
		{
			if (!(this.scrollRect == null) && resetOnExit.Value)
			{
				ScrollRect scrollRect = this.scrollRect;
				scrollRect.m_Horizontal = originalValue;
			}
		}

		[Token(Token = "0x600142B")]
		[Address(RVA = "0x980B34", Offset = "0x980B34", Length = "0x50")]
		public UiScrollRectSetHorizontal()
		{
		}
	}
}
