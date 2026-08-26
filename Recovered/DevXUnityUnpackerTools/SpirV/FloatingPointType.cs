using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class FloatingPointType : ScalarType
	{
		[CompilerGenerated]
		internal readonly int _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020;

		public int Width
		{
			get;
		}

		public FloatingPointType(int width)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 = width;
		}

		public override string ToString()
		{
			return $"f{Width}";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			return sb.Append('f').Append(Width);
		}
	}
}
