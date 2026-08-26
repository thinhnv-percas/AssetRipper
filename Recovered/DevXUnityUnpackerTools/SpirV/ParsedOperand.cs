using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public class ParsedOperand
	{
		[CompilerGenerated]
		internal readonly IList<uint> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A;

		[CompilerGenerated]
		internal object _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020;

		[CompilerGenerated]
		internal readonly Operand _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A;

		public IList<uint> Words
		{
			get;
		}

		public object Value
		{
			get;
			set;
		}

		public Operand Operand
		{
			get;
		}

		public ParsedOperand(IList<uint> words, int index, int count, object value, Operand operand)
		{
			uint[] array = new uint[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = words[index + i];
			}
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A = array;
			Value = value;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A = operand;
		}

		public T GetSingleEnumValue<T>()
		{
			IValueEnumOperandValue valueEnumOperandValue = (IValueEnumOperandValue)Value;
			if (valueEnumOperandValue.Value.Count == 0)
			{
				return (T)valueEnumOperandValue.Key;
			}
			return (T)((IValueEnumOperandValue)Value).Value[0];
		}

		public uint GetId()
		{
			return ((ObjectReference)Value).Id;
		}

		public T GetBitEnumValue<T>()
		{
			IBitEnumOperandValue obj = Value as IBitEnumOperandValue;
			uint num = 0u;
			foreach (uint key in obj.Values.Keys)
			{
				num |= key;
			}
			return (T)(object)num;
		}
	}
}
