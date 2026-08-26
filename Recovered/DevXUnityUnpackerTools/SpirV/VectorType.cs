using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class VectorType : Type
	{
		[CompilerGenerated]
		internal readonly ScalarType _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020;

		[CompilerGenerated]
		internal readonly int _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A;

		public ScalarType ComponentType
		{
			get;
		}

		public int ComponentCount
		{
			get;
		}

		public VectorType(ScalarType scalarType, int componentCount)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 = scalarType;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A = componentCount;
		}

		public override string ToString()
		{
			return $"{ComponentType}_{ComponentCount}";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			return ComponentType.ToString(sb).Append('_').Append(ComponentCount);
		}
	}
}
