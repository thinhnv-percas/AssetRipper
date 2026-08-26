using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class IntegerType : ScalarType
	{
		[CompilerGenerated]
		internal readonly int _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020;

		[CompilerGenerated]
		internal readonly bool _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A;

		public int Width
		{
			get;
		}

		public bool Signed
		{
			get;
		}

		public IntegerType(int width, bool signed)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 = width;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A = signed;
		}

		public override string ToString()
		{
			if (Signed)
			{
				return $"i{Width}";
			}
			return $"u{Width}";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			if (Signed)
			{
				sb.Append('i').Append(Width);
			}
			else
			{
				sb.Append('u').Append(Width);
			}
			return sb;
		}
	}
}
