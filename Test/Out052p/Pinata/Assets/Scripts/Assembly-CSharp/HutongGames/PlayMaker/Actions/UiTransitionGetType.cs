using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761330", Offset = "0x761330")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761330", Offset = "0x761330")]
	[Token(Token = "0x20003DE")]
	public class UiTransitionGetType : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2874", Offset = "0x7D2874")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2874", Offset = "0x7D2874")]
		[Token(Token = "0x4001E2C")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D290C", Offset = "0x7D290C")]
		[Token(Token = "0x4001E2D")]
		[FieldOffset(Offset = "0x68")]
		public FsmString transition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2944", Offset = "0x7D2944")]
		[Token(Token = "0x4001E2E")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent colorTintEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D297C", Offset = "0x7D297C")]
		[Token(Token = "0x4001E2F")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent spriteSwapEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D29B4", Offset = "0x7D29B4")]
		[Token(Token = "0x4001E30")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent animationEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D29EC", Offset = "0x7D29EC")]
		[Token(Token = "0x4001E31")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent noTransitionEvent;

		[Token(Token = "0x4001E32")]
		[FieldOffset(Offset = "0x90")]
		private Selectable selectable;

		[Token(Token = "0x4001E33")]
		[FieldOffset(Offset = "0x98")]
		private Selectable.Transition originalTransition;

		[Token(Token = "0x6001335")]
		[Address(RVA = "0x9858C0", Offset = "0x9858C0", Length = "0x10")]
		public override void Reset()
		{
			colorTintEvent = null;
			animationEvent = null;
			gameObject = null;
		}

		[Token(Token = "0x6001336")]
		[Address(RVA = "0x9858D0", Offset = "0x9858D0", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiTransitionGetType)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				selectable = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x6001337")]
		[Address(RVA = "0x98595C", Offset = "0x98595C", Length = "0x15C")]
		private void DoGetValue()
		{
			//IL_0145: Expected O, but got I
			//IL_0153: Expected O, but got I
			if (!(this.selectable == null))
			{
				Selectable selectable = this.selectable;
				FsmString fsmString = this.transition;
				Selectable.Transition transition = selectable.transition;
				object obj = transition;
				selectable = (Selectable)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v65 @ X8_v8 (UnityEngine.UI.Selectable)+160] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string value = default(string);
				fsmString.Value = value;
				selectable = this.selectable;
				Selectable.Transition transition2 = selectable.transition;
				bool flag = selectable.transition < Selectable.Transition.Animation;
				bool flag2 = !flag;
				int num = (int)(selectable.transition - 3);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num2 = 25260032 + 3676;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X9_v8 (System.Int32)+v110 @ X8_v15 (UnityEngine.UI.Selectable+Transition)*4]");
					selectable = (Selectable)0;
					selectable = (Selectable)((long)(IntPtr)selectable + (long)num2);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v65 @ X8_v8 (UnityEngine.UI.Selectable) (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x6001338")]
		[Address(RVA = "0x985AB8", Offset = "0x985AB8", Length = "0x50")]
		public UiTransitionGetType()
		{
		}
	}
}
