using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FAFC", Offset = "0x75FAFC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75FAFC", Offset = "0x75FAFC")]
	[Token(Token = "0x2000390")]
	public class StringSplit : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CCF30", Offset = "0x7CCF30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CCF30", Offset = "0x7CCF30")]
		[Token(Token = "0x4001C86")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringToSplit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CCF80", Offset = "0x7CCF80")]
		[Token(Token = "0x4001C87")]
		[FieldOffset(Offset = "0x58")]
		public FsmString separators;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CCFB8", Offset = "0x7CCFB8")]
		[Token(Token = "0x4001C88")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool trimStrings;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CCFF0", Offset = "0x7CCFF0")]
		[Token(Token = "0x4001C89")]
		[FieldOffset(Offset = "0x68")]
		public FsmString trimChars;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CD028", Offset = "0x7CD028")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7CD028", Offset = "0x7CD028")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CD028", Offset = "0x7CD028")]
		[Token(Token = "0x4001C8A")]
		[FieldOffset(Offset = "0x70")]
		public FsmArray stringArray;

		[Token(Token = "0x60011B9")]
		[Address(RVA = "0x99EB28", Offset = "0x99EB28", Length = "0x34")]
		public override void Reset()
		{
			stringToSplit = null;
			separators = null;
			FsmBool fsmBool = false;
			trimChars = null;
			stringArray = null;
			trimStrings = fsmBool;
		}

		[Token(Token = "0x60011BA")]
		[Address(RVA = "0x99EB5C", Offset = "0x99EB5C", Length = "0x218")]
		public override void OnEnter()
		{
			string value = trimChars.Value;
			char[] array = value.ToCharArray();
			if (!stringToSplit.IsNone && !stringArray.IsNone)
			{
				string value2 = stringToSplit.Value;
				string value3 = separators.Value;
				char[] separator = value3.ToCharArray();
				string[] values = value2.Split(separator);
				stringArray.Values = values;
				if (trimStrings.Value)
				{
					FsmArray fsmArray = stringArray;
					int num = 0;
					while (true)
					{
						object[] values2 = fsmArray.Values;
						if (num >= values2.Length)
						{
							break;
						}
						object[] values3 = stringArray.Values;
						if (num < values3.Length)
						{
							object obj = values3[num];
							if (values3[num] != null && (object)obj.GetType() == typeof(string))
							{
								FsmArray fsmArray2;
								string value4;
								if (!trimChars.IsNone && array.Length != 0)
								{
									fsmArray2 = stringArray;
									value4 = ((string)values3[num]).Trim(array);
								}
								else
								{
									fsmArray2 = stringArray;
									value4 = ((string)values3[num]).Trim();
								}
								fsmArray2.Set(num, value4);
							}
							fsmArray = stringArray;
							num++;
							if (stringArray == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
				}
				stringArray.SaveChanges();
			}
			Finish();
		}

		[Token(Token = "0x60011BB")]
		[Address(RVA = "0x99ED74", Offset = "0x99ED74", Length = "0x8")]
		public StringSplit()
		{
		}
	}
}
