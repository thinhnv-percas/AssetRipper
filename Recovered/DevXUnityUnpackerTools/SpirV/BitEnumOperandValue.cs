using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public class BitEnumOperandValue<T> : IBitEnumOperandValue, IEnumOperandValue
	{
		[CompilerGenerated]
		private readonly IDictionary<uint, IList<object>> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A;

		public IDictionary<uint, IList<object>> Values
		{
			get;
		}

		public System.Type EnumerationType => typeof(T);

		public BitEnumOperandValue(Dictionary<uint, IList<object>> values)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A = values;
		}
	}
}
