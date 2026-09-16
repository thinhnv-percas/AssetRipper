using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761240", Offset = "0x761240")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761240", Offset = "0x761240")]
	[Token(Token = "0x20003DB")]
	public class UiSetAnimationTriggers : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2364", Offset = "0x7D2364")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2364", Offset = "0x7D2364")]
		[Token(Token = "0x4001E12")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D23FC", Offset = "0x7D23FC")]
		[Token(Token = "0x4001E13")]
		[FieldOffset(Offset = "0x68")]
		public FsmString normalTrigger;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2434", Offset = "0x7D2434")]
		[Token(Token = "0x4001E14")]
		[FieldOffset(Offset = "0x70")]
		public FsmString highlightedTrigger;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D246C", Offset = "0x7D246C")]
		[Token(Token = "0x4001E15")]
		[FieldOffset(Offset = "0x78")]
		public FsmString pressedTrigger;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D24A4", Offset = "0x7D24A4")]
		[Token(Token = "0x4001E16")]
		[FieldOffset(Offset = "0x80")]
		public FsmString disabledTrigger;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D24DC", Offset = "0x7D24DC")]
		[Token(Token = "0x4001E17")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001E18")]
		[FieldOffset(Offset = "0x90")]
		private Selectable selectable;

		[Token(Token = "0x4001E19")]
		[FieldOffset(Offset = "0x98")]
		private AnimationTriggers _animationTriggers;

		[Token(Token = "0x4001E1A")]
		[FieldOffset(Offset = "0xA0")]
		private AnimationTriggers originalAnimationTriggers;

		[Token(Token = "0x6001325")]
		[Address(RVA = "0x9823F0", Offset = "0x9823F0", Length = "0xE4")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = true;
			normalTrigger = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = true;
			highlightedTrigger = fsmString2;
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = true;
			pressedTrigger = fsmString3;
			FsmString fsmString4 = new FsmString();
			fsmString4.useVariable = true;
			disabledTrigger = fsmString4;
			resetOnExit = null;
		}

		[Token(Token = "0x6001326")]
		[Address(RVA = "0x9824D4", Offset = "0x9824D4", Length = "0x104")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			//IL_010a: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSetAnimationTriggers)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			object obj;
			UnityEngine.Object obj2;
			if (UpdateCache(ownerDefaultTarget))
			{
				obj = (long)(IntPtr)this + 144L;
				selectable = cachedComponent;
				obj2 = cachedComponent;
			}
			else
			{
				obj = (long)(IntPtr)this + 144L;
				obj2 = selectable;
			}
			if (obj2 != null && resetOnExit.Value)
			{
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v12+C0]");
				originalAnimationTriggers = (AnimationTriggers)0;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x6001327")]
		[Address(RVA = "0x9825D8", Offset = "0x9825D8", Length = "0x16C")]
		private void DoSetValue()
		{
			if (!(this.selectable == null))
			{
				Selectable selectable = this.selectable;
				_animationTriggers = selectable.animationTriggers;
				if (!normalTrigger.IsNone)
				{
					AnimationTriggers animationTriggers = _animationTriggers;
					string value = normalTrigger.Value;
					animationTriggers.normalTrigger = value;
				}
				if (!highlightedTrigger.IsNone)
				{
					AnimationTriggers animationTriggers2 = _animationTriggers;
					string value2 = highlightedTrigger.Value;
					animationTriggers2.highlightedTrigger = value2;
				}
				if (!pressedTrigger.IsNone)
				{
					AnimationTriggers animationTriggers3 = _animationTriggers;
					string value3 = pressedTrigger.Value;
					animationTriggers3.pressedTrigger = value3;
				}
				if (!disabledTrigger.IsNone)
				{
					AnimationTriggers animationTriggers4 = _animationTriggers;
					string value4 = disabledTrigger.Value;
					animationTriggers4.disabledTrigger = value4;
				}
				this.selectable.animationTriggers = _animationTriggers;
			}
		}

		[Token(Token = "0x6001328")]
		[Address(RVA = "0x982744", Offset = "0x982744", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(selectable == null) && resetOnExit.Value)
			{
				selectable.animationTriggers = originalAnimationTriggers;
			}
		}

		[Token(Token = "0x6001329")]
		[Address(RVA = "0x9827F0", Offset = "0x9827F0", Length = "0x50")]
		public UiSetAnimationTriggers()
		{
		}
	}
}
