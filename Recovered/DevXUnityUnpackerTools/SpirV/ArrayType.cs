using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class ArrayType : Type
	{
		[CompilerGenerated]
		internal readonly int _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal readonly Type _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A;

		public int ElementCount
		{
			get;
		}

		public Type ElementType
		{
			get;
		}

		public ArrayType(Type elementType, int elementCount)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A = elementType;
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020 = elementCount;
		}

		public override string ToString()
		{
			return $"{ElementType}[{ElementCount}]";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			return ElementType.ToString(sb).Append('[').Append(ElementCount)
				.Append(']');
		}
	}
}
