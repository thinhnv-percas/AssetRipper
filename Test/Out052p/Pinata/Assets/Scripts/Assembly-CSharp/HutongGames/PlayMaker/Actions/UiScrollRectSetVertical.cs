using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762320", Offset = "0x762320")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762320", Offset = "0x762320")]
	[Token(Token = "0x2000411")]
	public class UiScrollRectSetVertical : ComponentAction<ScrollRect>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7C68", Offset = "0x7D7C68")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7C68", Offset = "0x7D7C68")]
		[Token(Token = "0x4001F3B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7D00", Offset = "0x7D7D00")]
		[Token(Token = "0x4001F3C")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool vertical;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7D38", Offset = "0x7D7D38")]
		[Token(Token = "0x4001F3D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7D70", Offset = "0x7D7D70")]
		[Token(Token = "0x4001F3E")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F3F")]
		[FieldOffset(Offset = "0x80")]
		private ScrollRect scrollRect;

		[Token(Token = "0x4001F40")]
		[FieldOffset(Offset = "0x88")]
		private bool originalValue;

		[Token(Token = "0x6001432")]
		[Address(RVA = "0x980F1C", Offset = "0x980F1C", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			vertical = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001433")]
		[Address(RVA = "0x980F2C", Offset = "0x980F2C", Length = "0xC0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollRectSetVertical)+30]");
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

		[Token(Token = "0x6001434")]
		[Address(RVA = "0x981090", Offset = "0x981090", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001435")]
		[Address(RVA = "0x980FEC", Offset = "0x980FEC", Length = "0xA4")]
		private void DoSetValue()
		{
			if (this.scrollRect != null)
			{
				ScrollRect scrollRect = this.scrollRect;
				bool value = vertical.Value;
				scrollRect.m_Vertical = value;
			}
		}

		[Token(Token = "0x6001436")]
		[Address(RVA = "0x981094", Offset = "0x981094", Length = "0xA8")]
		public override void OnExit()
		{
			if (!(this.scrollRect == null) && resetOnExit.Value)
			{
				ScrollRect scrollRect = this.scrollRect;
				scrollRect.m_Vertical = originalValue;
			}
		}

		[Token(Token = "0x6001437")]
		[Address(RVA = "0x98113C", Offset = "0x98113C", Length = "0x50")]
		public UiScrollRectSetVertical()
		{
		}
	}
}
