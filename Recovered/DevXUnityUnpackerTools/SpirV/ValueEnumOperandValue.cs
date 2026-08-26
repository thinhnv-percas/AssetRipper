using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public class ValueEnumOperandValue<T> : IValueEnumOperandValue, IEnumOperandValue
	{
		[CompilerGenerated]
		internal readonly object _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		internal readonly IList<object> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020;

		public System.Type EnumerationType => typeof(T);

		public object Key
		{
			get;
		}

		public IList<object> Value
		{
			get;
		}

		public ValueEnumOperandValue(T key, IList<object> value)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 = key;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 = value;
		}
	}
}
