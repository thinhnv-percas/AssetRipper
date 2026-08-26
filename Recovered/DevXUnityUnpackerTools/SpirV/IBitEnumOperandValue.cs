using System.Collections.Generic;

namespace SpirV
{
	public interface IBitEnumOperandValue : IEnumOperandValue
	{
		IDictionary<uint, IList<object>> Values
		{
			get;
		}
	}
}
