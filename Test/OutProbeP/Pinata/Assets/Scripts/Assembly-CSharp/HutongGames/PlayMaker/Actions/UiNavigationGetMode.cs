using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7611A0", Offset = "0x7611A0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7611A0", Offset = "0x7611A0")]
	[Token(Token = "0x20003D9")]
	public class UiNavigationGetMode : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2074", Offset = "0x7D2074")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2074", Offset = "0x7D2074")]
		[Token(Token = "0x4001E03")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D210C", Offset = "0x7D210C")]
		[Token(Token = "0x4001E04")]
		[FieldOffset(Offset = "0x68")]
		public FsmString navigationMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2144", Offset = "0x7D2144")]
		[Token(Token = "0x4001E05")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent automaticEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D217C", Offset = "0x7D217C")]
		[Token(Token = "0x4001E06")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent horizontalEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D21B4", Offset = "0x7D21B4")]
		[Token(Token = "0x4001E07")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent verticalEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D21EC", Offset = "0x7D21EC")]
		[Token(Token = "0x4001E08")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent explicitEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2224", Offset = "0x7D2224")]
		[Token(Token = "0x4001E09")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent noNavigationEvent;

		[Token(Token = "0x4001E0A")]
		[FieldOffset(Offset = "0x98")]
		private Selectable selectable;

		[Token(Token = "0x4001E0B")]
		[FieldOffset(Offset = "0xA0")]
		private Selectable.Transition originalTransition;

		[Token(Token = "0x600131C")]
		[Address(RVA = "0x97E76C", Offset = "0x97E76C", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x600131D")]
		[Address(RVA = "0x97E774", Offset = "0x97E774", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiNavigationGetMode)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				selectable = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x600131E")]
		[Address(RVA = "0x97E800", Offset = "0x97E800", Length = "0x16C")]
		private void DoGetValue()
		{
			//IL_006c: Expected I4, but got O
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_014a: Expected O, but got I
			//IL_0158: Expected O, but got I
			if (!(this.selectable == null))
			{
				Selectable selectable = this.selectable;
				FsmString fsmString = navigationMode;
				Navigation navigation = selectable.m_Navigation;
				object obj = (Navigation.Mode)navigation;
				selectable = (Selectable)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v65 @ X8_v8 (UnityEngine.UI.Selectable)+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string value = default(string);
				fsmString.Value = value;
				selectable = this.selectable;
				Navigation navigation2 = selectable.m_Navigation;
				bool flag = (long)(IntPtr)selectable.m_Navigation < 4L;
				bool flag2 = !flag;
				object obj2 = selectable.m_Navigation - 4;
				bool flag3 = obj2 == null;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num = 25260032 + 3656;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X9_v8 (System.Int32)+v110 @ X8_v15 (UnityEngine.UI.Navigation)*4]");
					selectable = (Selectable)0;
					selectable = (Selectable)((long)(IntPtr)selectable + (long)num);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v65 @ X8_v8 (UnityEngine.UI.Selectable) (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x600131F")]
		[Address(RVA = "0x97E96C", Offset = "0x97E96C", Length = "0x50")]
		public UiNavigationGetMode()
		{
		}
	}
}
