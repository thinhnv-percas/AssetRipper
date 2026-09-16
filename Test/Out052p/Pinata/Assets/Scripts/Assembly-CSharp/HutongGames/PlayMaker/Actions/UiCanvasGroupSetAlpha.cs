using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760700", Offset = "0x760700")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760700", Offset = "0x760700")]
	[Token(Token = "0x20003B6")]
	public class UiCanvasGroupSetAlpha : ComponentAction<CanvasGroup>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7CF6C4", Offset = "0x7CF6C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF6C4", Offset = "0x7CF6C4")]
		[Token(Token = "0x4001D6B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF75C", Offset = "0x7CF75C")]
		[Token(Token = "0x4001D6C")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat alpha;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF7A8", Offset = "0x7CF7A8")]
		[Token(Token = "0x4001D6D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CF7E0", Offset = "0x7CF7E0")]
		[Token(Token = "0x4001D6E")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001D6F")]
		[FieldOffset(Offset = "0x80")]
		private CanvasGroup component;

		[Token(Token = "0x4001D70")]
		[FieldOffset(Offset = "0x88")]
		private float originalValue;

		[Token(Token = "0x6001283")]
		[Address(RVA = "0x9A3480", Offset = "0x9A3480", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			alpha = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001284")]
		[Address(RVA = "0x9A3490", Offset = "0x9A3490", Length = "0xBC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiCanvasGroupSetAlpha)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			CanvasGroup canvasGroup;
			if (UpdateCache(ownerDefaultTarget))
			{
				canvasGroup = cachedComponent;
				component = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				canvasGroup = component;
			}
			float num = canvasGroup.alpha;
			originalValue = num;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001285")]
		[Address(RVA = "0x9A35FC", Offset = "0x9A35FC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001286")]
		[Address(RVA = "0x9A354C", Offset = "0x9A354C", Length = "0xB0")]
		private void DoSetValue()
		{
			if (component != null)
			{
				float value = alpha.Value;
				component.alpha = value;
			}
		}

		[Token(Token = "0x6001287")]
		[Address(RVA = "0x9A3600", Offset = "0x9A3600", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(component == null) && resetOnExit.Value)
			{
				component.alpha = originalValue;
			}
		}

		[Token(Token = "0x6001288")]
		[Address(RVA = "0x9A36AC", Offset = "0x9A36AC", Length = "0x50")]
		public UiCanvasGroupSetAlpha()
		{
		}
	}
}
