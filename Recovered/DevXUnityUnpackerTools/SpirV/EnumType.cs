using System;
using System.Collections.Generic;
using System.Linq;

namespace SpirV
{
	public class EnumType<T> : EnumType<T, ParameterFactory>
	{
	}
	public class EnumType<T, U> : OperandType where U : ParameterFactory, new()
	{
		private U _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020 = new U();

		public System.Type EnumerationType => typeof(T);

		public override bool ReadValue(IList<uint> words, int index, out object value, out int wordsUsed)
		{
			int num = 0;
			if (typeof(T).GetTypeInfo().GetCustomAttributes<FlagsAttribute>().Any())
			{
				Dictionary<uint, IList<object>> dictionary = new Dictionary<uint, IList<object>>();
				foreach (uint enumValue in EnumerationType.GetEnumValues())
				{
					if ((words[index] & enumValue) != 0 || (enumValue == 0 && words[index] == 0))
					{
						Parameter parameter = _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020.CreateParameter(enumValue);
						if (parameter == null)
						{
							dictionary.Add(enumValue, new object[0]);
						}
						else
						{
							object[] array = new object[parameter.OperandTypes.Count];
							for (int i = 0; i < parameter.OperandTypes.Count; i++)
							{
								parameter.OperandTypes[i].ReadValue(words, 1 + num, out object value2, out int wordsUsed2);
								num += wordsUsed2;
								array[i] = value2;
							}
							dictionary.Add(enumValue, array);
						}
					}
				}
				value = new BitEnumOperandValue<T>(dictionary);
			}
			else
			{
				Parameter parameter2 = _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020.CreateParameter(words[index]);
				object[] array2;
				if (parameter2 == null)
				{
					array2 = new object[0];
				}
				else
				{
					array2 = new object[parameter2.OperandTypes.Count];
					for (int j = 0; j < parameter2.OperandTypes.Count; j++)
					{
						parameter2.OperandTypes[j].ReadValue(words, 1 + num, out object value3, out int wordsUsed3);
						num += wordsUsed3;
						array2[j] = value3;
					}
				}
				value = new ValueEnumOperandValue<T>((T)(object)words[index], array2);
			}
			wordsUsed = num + 1;
			return true;
		}
	}
}
