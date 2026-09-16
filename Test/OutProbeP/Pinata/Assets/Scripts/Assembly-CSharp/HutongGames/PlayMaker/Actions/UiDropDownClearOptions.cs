using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7614C0", Offset = "0x7614C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7614C0", Offset = "0x7614C0")]
	[Token(Token = "0x20003E3")]
	public class UiDropDownClearOptions : ComponentAction<Dropdown>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2F2C", Offset = "0x7D2F2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2F2C", Offset = "0x7D2F2C")]
		[Token(Token = "0x4001E49")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4001E4A")]
		[FieldOffset(Offset = "0x68")]
		private Dropdown dropDown;

		[Token(Token = "0x600134E")]
		[Address(RVA = "0x9A42B0", Offset = "0x9A42B0", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x600134F")]
		[Address(RVA = "0x9A42B8", Offset = "0x9A42B8", Length = "0xE0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiDropDownClearOptions)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			object obj;
			UnityEngine.Object obj2;
			if (UpdateCache(ownerDefaultTarget))
			{
				obj = (long)(IntPtr)this + 104L;
				dropDown = cachedComponent;
				obj2 = cachedComponent;
			}
			else
			{
				obj = (long)(IntPtr)this + 104L;
				obj2 = dropDown;
			}
			if (obj2 != null)
			{
				((Dropdown)obj).ClearOptions();
			}
			Finish();
		}

		[Token(Token = "0x6001350")]
		[Address(RVA = "0x9A4398", Offset = "0x9A4398", Length = "0x50")]
		public UiDropDownClearOptions()
		{
		}
	}
}
