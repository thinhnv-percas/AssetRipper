using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761470", Offset = "0x761470")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761470", Offset = "0x761470")]
	[Token(Token = "0x20003E2")]
	public class UiDropDownAddOptions : ComponentAction<Dropdown>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2DA0", Offset = "0x7D2DA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2DA0", Offset = "0x7D2DA0")]
		[Token(Token = "0x4001E44")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2E38", Offset = "0x7D2E38")]
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7D2E38", Offset = "0x7D2E38")]
		[Token(Token = "0x4001E45")]
		[FieldOffset(Offset = "0x68")]
		public FsmString[] optionText;

		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D2EC8", Offset = "0x7D2EC8")]
		[Token(Token = "0x4001E46")]
		[FieldOffset(Offset = "0x70")]
		public FsmObject[] optionImage;

		[Token(Token = "0x4001E47")]
		[FieldOffset(Offset = "0x78")]
		private Dropdown dropDown;

		[Token(Token = "0x4001E48")]
		[FieldOffset(Offset = "0x80")]
		private List<Dropdown.OptionData> options;

		[Token(Token = "0x600134A")]
		[Address(RVA = "0x9A3F78", Offset = "0x9A3F78", Length = "0x74")]
		public override void Reset()
		{
			gameObject = null;
			FsmString[] array = new FsmString[1];
			optionText = array;
			FsmObject[] array2 = new FsmObject[1];
			optionImage = array2;
		}

		[Token(Token = "0x600134B")]
		[Address(RVA = "0x9A3FEC", Offset = "0x9A3FEC", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiDropDownAddOptions)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				dropDown = cachedComponent;
			}
			DoAddOptions();
			Finish();
		}

		[Token(Token = "0x600134C")]
		[Address(RVA = "0x9A4078", Offset = "0x9A4078", Length = "0x1E8")]
		private void DoAddOptions()
		{
			if (dropDown == null)
			{
				return;
			}
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
			FsmString[] array = optionText;
			options = list;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (num < array.Length)
					{
						Dropdown.OptionData optionData = new Dropdown.OptionData();
						string value = array[num].Value;
						optionData.text = value;
						FsmObject[] array2 = optionImage;
						if (num < array2.Length)
						{
							object rawValue = array2[num].RawValue;
							Sprite image;
							if (rawValue != null)
							{
								object obj = (((object)rawValue.GetType() != typeof(Sprite)) ? null : rawValue);
								image = (Sprite)obj;
							}
							else
							{
								image = null;
							}
							optionData.image = image;
							num++;
							options.Add(optionData);
							array = optionText;
							if (optionText == null)
							{
								break;
							}
							continue;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				dropDown.AddOptions(options);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600134D")]
		[Address(RVA = "0x9A4260", Offset = "0x9A4260", Length = "0x50")]
		public UiDropDownAddOptions()
		{
		}
	}
}
