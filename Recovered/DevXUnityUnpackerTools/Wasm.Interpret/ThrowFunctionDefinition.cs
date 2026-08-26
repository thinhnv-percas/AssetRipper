using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class ThrowFunctionDefinition : FunctionDefinition
	{
		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		internal IList<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal Exception _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A;

		public override IList<WasmValueType> ParameterTypes => _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		public override IList<WasmValueType> ReturnTypes => _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

		public Exception ExceptionToThrow
		{
			get;
			internal set;
		}

		public ThrowFunctionDefinition(IList<WasmValueType> parameterTypes, IList<WasmValueType> returnTypes, Exception exceptionToThrow)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A = parameterTypes;
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020 = returnTypes;
			ExceptionToThrow = exceptionToThrow;
		}

		public override IList<object> Invoke(IList<object> arguments, uint callStackDepth = 0u)
		{
			throw ExceptionToThrow;
		}
	}
}
