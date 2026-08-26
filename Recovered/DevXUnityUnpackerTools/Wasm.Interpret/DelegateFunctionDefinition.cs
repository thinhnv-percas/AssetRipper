using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class DelegateFunctionDefinition : FunctionDefinition
	{
		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal Func<IList<object>, IList<object>> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A;

		public Func<IList<object>, IList<object>> Implementation
		{
			get;
			internal set;
		}

		public override IList<WasmValueType> ParameterTypes => _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		public override IList<WasmValueType> ReturnTypes => _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

		public DelegateFunctionDefinition(IList<WasmValueType> parameterTypes, IList<WasmValueType> returnTypes, Func<IList<object>, IList<object>> implementation)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A = parameterTypes;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020 = returnTypes;
			Implementation = implementation;
		}

		public override IList<object> Invoke(IList<object> arguments, uint callStackDepth = 0u)
		{
			return Implementation(arguments);
		}
	}
}
