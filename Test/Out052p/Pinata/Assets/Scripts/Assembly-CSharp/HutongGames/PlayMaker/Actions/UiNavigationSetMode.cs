using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7611F0", Offset = "0x7611F0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7611F0", Offset = "0x7611F0")]
	[Token(Token = "0x20003DA")]
	public class UiNavigationSetMode : ComponentAction<Selectable>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D225C", Offset = "0x7D225C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D225C", Offset = "0x7D225C")]
		[Token(Token = "0x4001E0C")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D22F4", Offset = "0x7D22F4")]
		[Token(Token = "0x4001E0D")]
		[FieldOffset(Offset = "0x68")]
		public Navigation.Mode navigationMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D232C", Offset = "0x7D232C")]
		[Token(Token = "0x4001E0E")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001E0F")]
		[FieldOffset(Offset = "0x78")]
		private Selectable selectable;

		[Token(Token = "0x4001E10")]
		[FieldOffset(Offset = "0x80")]
		private Navigation _navigation;

		[Token(Token = "0x4001E11")]
		[FieldOffset(Offset = "0xA8")]
		private Navigation.Mode originalValue;

		[Token(Token = "0x6001320")]
		[Address(RVA = "0x97E9BC", Offset = "0x97E9BC", Length = "0x38")]
		public override void Reset()
		{
			gameObject = null;
			navigationMode = Navigation.Mode.Automatic;
			FsmBool fsmBool = false;
			resetOnExit = fsmBool;
		}

		[Token(Token = "0x6001321")]
		[Address(RVA = "0x97E9F4", Offset = "0x97E9F4", Length = "0x104")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiNavigationSetMode)+30]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v12+18]");
				originalValue = Navigation.Mode.None;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x6001322")]
		[Address(RVA = "0x97EAF8", Offset = "0x97EAF8", Length = "0xCC")]
		private unsafe void DoSetValue()
		{
			//IL_00b7: Expected O, but got Ref
			if (this.selectable != null)
			{
				Selectable selectable = this.selectable;
				Navigation navigation = selectable.m_Navigation;
				_navigation = selectable.m_Navigation;
				_navigation.selectOnDown = selectable.m_Navigation.selectOnDown;
				_navigation.mode = navigationMode;
				navigation = _navigation;
				_navigation.selectOnRight = selectable.m_Navigation.selectOnRight;
				selectable.navigation = (Navigation)(&navigation);
			}
		}

		[Token(Token = "0x6001323")]
		[Address(RVA = "0x97EBC4", Offset = "0x97EBC4", Length = "0xE0")]
		public unsafe override void OnExit()
		{
			//IL_00ee: Expected O, but got Ref
			if (!(this.selectable == null) && resetOnExit.Value)
			{
				Selectable selectable = this.selectable;
				Navigation navigation = selectable.m_Navigation;
				_navigation = selectable.m_Navigation;
				_navigation.selectOnDown = selectable.m_Navigation.selectOnDown;
				_navigation.mode = originalValue;
				navigation = _navigation;
				_navigation.selectOnRight = selectable.m_Navigation.selectOnRight;
				selectable.navigation = (Navigation)(&navigation);
			}
		}

		[Token(Token = "0x6001324")]
		[Address(RVA = "0x97ECA4", Offset = "0x97ECA4", Length = "0x50")]
		public UiNavigationSetMode()
		{
		}
	}
}
