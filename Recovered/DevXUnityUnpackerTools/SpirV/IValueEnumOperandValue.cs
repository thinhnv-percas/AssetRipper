using System.Collections.Generic;

namespace SpirV
{
	public interface IValueEnumOperandValue : IEnumOperandValue
	{
		object Key
		{
			get;
		}

		IList<object> Value
		{
			get;
		}
	}
}
