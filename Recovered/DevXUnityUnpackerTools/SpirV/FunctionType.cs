using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public class FunctionType : Type
	{
		[CompilerGenerated]
		private readonly Type _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		private readonly IList<Type> _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A;

		public Type ReturnType
		{
			get;
		}

		public IList<Type> ParameterTypes
		{
			get;
		}

		public FunctionType(Type returnType, IList<Type> parameterTypes)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 = returnType;
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A = parameterTypes;
		}
	}
}
