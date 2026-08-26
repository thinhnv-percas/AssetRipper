using System.Runtime.CompilerServices;

namespace SpirV
{
	public class RuntimeArrayType : Type
	{
		[CompilerGenerated]
		internal readonly Type _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A;

		public Type ElementType
		{
			get;
		}

		public RuntimeArrayType(Type elementType)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A = elementType;
		}
	}
}
