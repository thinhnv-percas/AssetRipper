using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761380", Offset = "0x761380")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761380", Offset = "0x761380")]
	[Token(Token = "0x20003DF")]
	public class UiTransitionSetType : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2A24", Offset = "0x7D2A24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2A24", Offset = "0x7D2A24")]
		[Token(Token = "0x4001E34")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2ABC", Offset = "0x7D2ABC")]
		[Token(Token = "0x4001E35")]
		[FieldOffset(Offset = "0x68")]
		public Selectable.Transition transition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2AF4", Offset = "0x7D2AF4")]
		[Token(Token = "0x4001E36")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001E37")]
		[FieldOffset(Offset = "0x78")]
		private Selectable selectable;

		[Token(Token = "0x4001E38")]
		[FieldOffset(Offset = "0x80")]
		private Selectable.Transition originalTransition;

		[Token(Token = "0x6001339")]
		[Address(RVA = "0x985B08", Offset = "0x985B08", Length = "0x38")]
		public override void Reset()
		{
			gameObject = null;
			transition = Selectable.Transition.ColorTint;
			FsmBool fsmBool = false;
			resetOnExit = fsmBool;
		}

		[Token(Token = "0x600133A")]
		[Address(RVA = "0x985B40", Offset = "0x985B40", Length = "0x104")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiTransitionSetType)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			object obj;
			UnityEngine.Object obj2;
			if (UpdateCache(ownerDefaultTarget))
			{
				obj = (long)(IntPtr)this + 120L;
				selectable = cachedComponent;
				obj2 = cachedComponent;
			}
			else
			{
				obj = (long)(IntPtr)this + 120L;
				obj2 = selectable;
			}
			if (obj2 != null && resetOnExit.Value)
			{
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v12+40]");
				originalTransition = Selectable.Transition.None;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x600133B")]
		[Address(RVA = "0x985C44", Offset = "0x985C44", Length = "0x98")]
		private void DoSetValue()
		{
			if (selectable != null)
			{
				selectable.transition = transition;
			}
		}

		[Token(Token = "0x600133C")]
		[Address(RVA = "0x985CDC", Offset = "0x985CDC", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(selectable == null) && resetOnExit.Value)
			{
				selectable.transition = originalTransition;
			}
		}

		[Token(Token = "0x600133D")]
		[Address(RVA = "0x985D88", Offset = "0x985D88", Length = "0x50")]
		public UiTransitionSetType()
		{
		}
	}
}
