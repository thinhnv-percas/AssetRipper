using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761510", Offset = "0x761510")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761510", Offset = "0x761510")]
	[Token(Token = "0x20003E4")]
	public class UiDropDownGetSelectedData : ComponentAction<Dropdown>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2FC4", Offset = "0x7D2FC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2FC4", Offset = "0x7D2FC4")]
		[Token(Token = "0x4001E4B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D305C", Offset = "0x7D305C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D305C", Offset = "0x7D305C")]
		[Token(Token = "0x4001E4C")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt index;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D30AC", Offset = "0x7D30AC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D30AC", Offset = "0x7D30AC")]
		[Token(Token = "0x4001E4D")]
		[FieldOffset(Offset = "0x70")]
		public FsmString getText;

		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D30FC", Offset = "0x7D30FC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D30FC", Offset = "0x7D30FC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D30FC", Offset = "0x7D30FC")]
		[Token(Token = "0x4001E4E")]
		[FieldOffset(Offset = "0x78")]
		public FsmObject getImage;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3198", Offset = "0x7D3198")]
		[Token(Token = "0x4001E4F")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x4001E50")]
		[FieldOffset(Offset = "0x88")]
		private Dropdown dropDown;

		[Token(Token = "0x6001351")]
		[Address(RVA = "0x9A43E8", Offset = "0x9A43E8", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			getText = null;
		}

		[Token(Token = "0x6001352")]
		[Address(RVA = "0x9A43F8", Offset = "0x9A43F8", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiDropDownGetSelectedData)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				dropDown = cachedComponent;
			}
			GetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001353")]
		[Address(RVA = "0x9A4628", Offset = "0x9A4628", Length = "0x4")]
		public override void OnUpdate()
		{
			GetValue();
		}

		[Token(Token = "0x6001354")]
		[Address(RVA = "0x9A4498", Offset = "0x9A4498", Length = "0x190")]
		private void GetValue()
		{
			if (dropDown == null)
			{
				return;
			}
			if (!index.IsNone)
			{
				Dropdown dropdown = dropDown;
				FsmInt fsmInt = index;
				fsmInt.Value = dropdown.value;
			}
			if (!getText.IsNone)
			{
				FsmString fsmString = getText;
				List<Dropdown.OptionData> options = dropDown.options;
				Dropdown dropdown2 = dropDown;
				int value = dropdown2.value;
				bool flag = options.Count < dropdown2.value;
				bool flag2 = !flag;
				int num = options.Count - dropdown2.value;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				Dropdown.OptionData[] items = options._items;
				Dropdown.OptionData optionData = items[value];
				fsmString.Value = optionData.text;
			}
			if (!getImage.IsNone)
			{
				FsmObject fsmObject = getImage;
				List<Dropdown.OptionData> options2 = dropDown.options;
				Dropdown dropdown3 = dropDown;
				int value2 = dropdown3.value;
				bool flag5 = options2.Count < dropdown3.value;
				bool flag6 = !flag5;
				int num2 = options2.Count - dropdown3.value;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				Dropdown.OptionData[] items2 = options2._items;
				Dropdown.OptionData optionData2 = items2[value2];
				fsmObject.Value = optionData2.image;
			}
		}

		[Token(Token = "0x6001355")]
		[Address(RVA = "0x9A462C", Offset = "0x9A462C", Length = "0x50")]
		public UiDropDownGetSelectedData()
		{
		}
	}
}
