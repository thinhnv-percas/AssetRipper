using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7610B0", Offset = "0x7610B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7610B0", Offset = "0x7610B0")]
	[Token(Token = "0x20003D6")]
	public class UiNavigationExplicitSetProperties : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D197C", Offset = "0x7D197C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D197C", Offset = "0x7D197C")]
		[Token(Token = "0x4001DEB")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1A14", Offset = "0x7D1A14")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1A14", Offset = "0x7D1A14")]
		[Token(Token = "0x4001DEC")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject selectOnDown;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1A9C", Offset = "0x7D1A9C")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1A9C", Offset = "0x7D1A9C")]
		[Token(Token = "0x4001DED")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject selectOnUp;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1B24", Offset = "0x7D1B24")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1B24", Offset = "0x7D1B24")]
		[Token(Token = "0x4001DEE")]
		[FieldOffset(Offset = "0x78")]
		public FsmGameObject selectOnLeft;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1BAC", Offset = "0x7D1BAC")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1BAC", Offset = "0x7D1BAC")]
		[Token(Token = "0x4001DEF")]
		[FieldOffset(Offset = "0x80")]
		public FsmGameObject selectOnRight;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1C34", Offset = "0x7D1C34")]
		[Token(Token = "0x4001DF0")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001DF1")]
		[FieldOffset(Offset = "0x90")]
		private Selectable selectable;

		[Token(Token = "0x4001DF2")]
		[FieldOffset(Offset = "0x98")]
		private Navigation navigation;

		[Token(Token = "0x4001DF3")]
		[FieldOffset(Offset = "0xC0")]
		private Navigation originalState;

		[Token(Token = "0x600130D")]
		[Address(RVA = "0x97E28C", Offset = "0x97E28C", Length = "0xF4")]
		public override void Reset()
		{
			gameObject = null;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			selectOnDown = fsmGameObject;
			FsmGameObject fsmGameObject2 = new FsmGameObject();
			fsmGameObject2.useVariable = true;
			selectOnUp = fsmGameObject2;
			FsmGameObject fsmGameObject3 = new FsmGameObject();
			fsmGameObject3.useVariable = true;
			selectOnLeft = fsmGameObject3;
			FsmGameObject fsmGameObject4 = new FsmGameObject();
			fsmGameObject4.useVariable = true;
			selectOnRight = fsmGameObject4;
			FsmBool fsmBool = false;
			resetOnExit = fsmBool;
		}

		[Token(Token = "0x600130E")]
		[Address(RVA = "0x97E380", Offset = "0x97E380", Length = "0x110")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			//IL_010f: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_0138: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiNavigationExplicitSetProperties)+30]");
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
				ref Navigation reference = ref originalState;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v12+38]");
				reference.selectOnRight = (Selectable)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v12+18]");
				originalState = (Navigation)0;
				ref Navigation reference2 = ref originalState;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v12+28]");
				reference2.selectOnDown = (Selectable)0;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x600130F")]
		[Address(RVA = "0x97E490", Offset = "0x97E490", Length = "0x198")]
		private unsafe void DoSetValue()
		{
			//IL_0216: Expected O, but got Ref
			if (!(this.selectable == null))
			{
				Selectable selectable = this.selectable;
				Navigation navigation = selectable.m_Navigation;
				this.navigation = selectable.m_Navigation;
				this.navigation.selectOnRight = selectable.m_Navigation.selectOnRight;
				this.navigation.selectOnDown = selectable.m_Navigation.selectOnDown;
				if (!selectOnDown.IsNone)
				{
					Selectable componentFromFsmGameObject = GetComponentFromFsmGameObject<Selectable>(selectOnDown);
					this.navigation.selectOnDown = componentFromFsmGameObject;
				}
				if (!selectOnUp.IsNone)
				{
					Selectable componentFromFsmGameObject2 = GetComponentFromFsmGameObject<Selectable>(selectOnUp);
					this.navigation.selectOnUp = componentFromFsmGameObject2;
				}
				if (!selectOnLeft.IsNone)
				{
					Selectable componentFromFsmGameObject3 = GetComponentFromFsmGameObject<Selectable>(selectOnLeft);
					this.navigation.selectOnLeft = componentFromFsmGameObject3;
				}
				if (!selectOnRight.IsNone)
				{
					Selectable componentFromFsmGameObject4 = GetComponentFromFsmGameObject<Selectable>(selectOnRight);
					this.navigation.selectOnRight = componentFromFsmGameObject4;
				}
				navigation = this.navigation;
				this.selectable.navigation = (Navigation)(&navigation);
			}
		}

		[Token(Token = "0x6001310")]
		[Address(RVA = "0x97E628", Offset = "0x97E628", Length = "0xF4")]
		public unsafe override void OnExit()
		{
			//IL_0135: Expected O, but got Ref
			if (!(this.selectable == null) && resetOnExit.Value)
			{
				Selectable selectable = this.selectable;
				Navigation navigation = selectable.m_Navigation;
				this.navigation = selectable.m_Navigation;
				this.navigation.selectOnRight = selectable.m_Navigation.selectOnRight;
				this.navigation.selectOnUp = originalState.selectOnUp;
				this.navigation.selectOnDown = selectable.m_Navigation.selectOnDown;
				navigation = this.navigation;
				this.navigation.selectOnDown = originalState.selectOnDown;
				this.navigation.selectOnLeft = originalState.selectOnLeft;
				this.navigation.selectOnRight = originalState.selectOnRight;
				selectable.navigation = (Navigation)(&navigation);
			}
		}

		[Token(Token = "0x6001311")]
		[Address(RVA = "0xB88BEC", Offset = "0xB88BEC", Length = "0xD0")]
		private static T GetComponentFromFsmGameObject<T>(FsmGameObject variable) where T : Component
		{
			//IL_0062: Expected O, but got I
			GameObject value = variable.Value;
			if (value != null)
			{
				GameObject value2 = variable.Value;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v84 @ X2_v3 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x6001312")]
		[Address(RVA = "0x97E71C", Offset = "0x97E71C", Length = "0x50")]
		public UiNavigationExplicitSetProperties()
		{
		}
	}
}
