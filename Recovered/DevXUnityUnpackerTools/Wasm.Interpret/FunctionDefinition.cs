using System.Collections.Generic;

namespace Wasm.Interpret
{
	public abstract class FunctionDefinition
	{
		public abstract IList<WasmValueType> ParameterTypes
		{
			get;
		}

		public abstract IList<WasmValueType> ReturnTypes
		{
			get;
		}

		public abstract IList<object> Invoke(IList<object> arguments, uint callStackDepth = 0u);
	}
}
