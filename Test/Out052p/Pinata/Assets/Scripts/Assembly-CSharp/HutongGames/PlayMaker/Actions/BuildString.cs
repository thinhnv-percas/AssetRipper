using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F78C", Offset = "0x75F78C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F78C", Offset = "0x75F78C")]
	[Token(Token = "0x2000385")]
	public class BuildString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC6B8", Offset = "0x7CC6B8")]
		[Token(Token = "0x4001C5B")]
		[FieldOffset(Offset = "0x50")]
		public FsmString[] stringParts;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC704", Offset = "0x7CC704")]
		[Token(Token = "0x4001C5C")]
		[FieldOffset(Offset = "0x58")]
		public FsmString separator;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC73C", Offset = "0x7CC73C")]
		[Token(Token = "0x4001C5D")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool addToEnd;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC774", Offset = "0x7CC774")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC774", Offset = "0x7CC774")]
		[Token(Token = "0x4001C5E")]
		[FieldOffset(Offset = "0x68")]
		public FsmString storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC7D4", Offset = "0x7CC7D4")]
		[Token(Token = "0x4001C5F")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001C60")]
		[FieldOffset(Offset = "0x78")]
		private string result;

		[Token(Token = "0x6001188")]
		[Address(RVA = "0xA8C81C", Offset = "0xA8C81C", Length = "0x6C")]
		public override void Reset()
		{
			FsmString[] array = new FsmString[3];
			stringParts = array;
			separator = null;
			FsmBool fsmBool = true;
			addToEnd = fsmBool;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001189")]
		[Address(RVA = "0xA8C888", Offset = "0xA8C888", Length = "0x3C")]
		public override void OnEnter()
		{
			DoBuildString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600118A")]
		[Address(RVA = "0xA8CA14", Offset = "0xA8CA14", Length = "0x4")]
		public override void OnUpdate()
		{
			DoBuildString();
		}

		[Token(Token = "0x600118B")]
		[Address(RVA = "0xA8C8C4", Offset = "0xA8C8C4", Length = "0x150")]
		private void DoBuildString()
		{
			if (storeResult == null)
			{
				return;
			}
			FsmString[] array = stringParts;
			result = "";
			int num = 0;
			string text = "";
			while (true)
			{
				int num2 = array.Length - 1;
				bool flag = num >= num2;
				object obj = text;
				if (!flag)
				{
					if (num >= array.Length)
					{
						goto IL_01b9;
					}
					string text2 = (result = text + array[num]);
					string value = separator.Value;
					text = text2 + value;
					array = stringParts;
					num++;
					result = text;
					if (stringParts != null)
					{
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					obj = ex;
					array = array;
				}
				if (array.Length != 0)
				{
					string text3 = string.Concat(obj, array[num2]);
					result = text3;
					if (addToEnd.Value)
					{
						string value2 = separator.Value;
						string text4 = result + value2;
						result = text4;
					}
					break;
				}
				goto IL_01b9;
				IL_01b9:
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}
			FsmString fsmString = storeResult;
			fsmString.Value = result;
		}

		[Token(Token = "0x600118C")]
		[Address(RVA = "0xA8CA18", Offset = "0xA8CA18", Length = "0x8")]
		public BuildString()
		{
		}
	}
}
