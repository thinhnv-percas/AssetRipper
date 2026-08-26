using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class VaryingOperandValue
	{
		[CompilerGenerated]
		private readonly IList<object> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A;

		public IList<object> Values
		{
			get;
		}

		public VaryingOperandValue(IList<object> values)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A = values;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ToString(stringBuilder);
			return stringBuilder.ToString();
		}

		public StringBuilder ToString(StringBuilder sb)
		{
			for (int i = 0; i < Values.Count; i++)
			{
				ObjectReference objectReference;
				if ((objectReference = (Values[i] as ObjectReference)) != null)
				{
					objectReference.ToString(sb);
				}
				else
				{
					sb.Append(Values[i]);
				}
				if (i < Values.Count - 1)
				{
					sb.Append(' ');
				}
			}
			return sb;
		}
	}
}
