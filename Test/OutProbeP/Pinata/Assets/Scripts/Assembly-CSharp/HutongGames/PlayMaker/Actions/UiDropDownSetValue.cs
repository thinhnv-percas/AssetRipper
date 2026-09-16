using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761560", Offset = "0x761560")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761560", Offset = "0x761560")]
	[Token(Token = "0x20003E5")]
	public class UiDropDownSetValue : ComponentAction<Dropdown>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D31D0", Offset = "0x7D31D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D31D0", Offset = "0x7D31D0")]
		[Token(Token = "0x4001E51")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3268", Offset = "0x7D3268")]
		[Token(Token = "0x4001E52")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D32B4", Offset = "0x7D32B4")]
		[Token(Token = "0x4001E53")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001E54")]
		[FieldOffset(Offset = "0x78")]
		private Dropdown dropDown;

		[Token(Token = "0x6001356")]
		[Address(RVA = "0x9A467C", Offset = "0x9A467C", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			value = null;
		}

		[Token(Token = "0x6001357")]
		[Address(RVA = "0x9A4688", Offset = "0x9A4688", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiDropDownSetValue)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				dropDown = cachedComponent;
			}
			SetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001358")]
		[Address(RVA = "0x9A47FC", Offset = "0x9A47FC", Length = "0x4")]
		public override void OnUpdate()
		{
			SetValue();
		}

		[Token(Token = "0x6001359")]
		[Address(RVA = "0x9A4728", Offset = "0x9A4728", Length = "0xD4")]
		private void SetValue()
		{
			if (!(dropDown == null))
			{
				Dropdown dropdown = dropDown;
				int num = value.Value;
				if (dropdown.value != num)
				{
					int num2 = value.Value;
					dropDown.value = num2;
				}
			}
		}

		[Token(Token = "0x600135A")]
		[Address(RVA = "0x9A4800", Offset = "0x9A4800", Length = "0x50")]
		public UiDropDownSetValue()
		{
		}
	}
}
