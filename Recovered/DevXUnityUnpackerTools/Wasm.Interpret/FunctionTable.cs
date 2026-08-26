using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class FunctionTable
	{
		[CompilerGenerated]
		private ResizableLimits _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A;

		private List<FunctionDefinition> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020;

		public ResizableLimits Limits
		{
			get;
			private set;
		}

		public FunctionDefinition this[uint index]
		{
			get
			{
				_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(index);
				return _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020[(int)index];
			}
			set
			{
				_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(index);
				_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020[(int)index] = value;
			}
		}

		public int Count => _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020.Count;

		public FunctionTable(ResizableLimits limits)
		{
			Limits = limits;
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020 = new List<FunctionDefinition>((int)limits.Initial);
			ThrowFunctionDefinition item = new ThrowFunctionDefinition(new WasmValueType[0], new WasmValueType[0], new TrapException("Indirect call target not initialized yet.", "uninitialized element"));
			for (int i = 0; i < limits.Initial; i++)
			{
				_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020.Add(item);
			}
		}

		private void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(uint _0020)
		{
			if (_0020 >= _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020.Count)
			{
				throw new TrapException($"Cannot access element with index {_0020} in a function table of size {_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020.Count}.", "undefined element");
			}
		}
	}
}
