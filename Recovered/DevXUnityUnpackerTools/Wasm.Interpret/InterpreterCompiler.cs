using System.Collections.Generic;

namespace Wasm.Interpret
{
	public sealed class InterpreterCompiler : ModuleCompiler
	{
		internal ModuleInstance _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A;

		internal IList<FunctionType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020;

		public override void Initialize(ModuleInstance module, int offset, IList<FunctionType> types)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = module;
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020 = types;
		}

		public override FunctionDefinition Compile(int index, FunctionBody body)
		{
			return new WasmFunctionDefinition(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020[index], body, _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A);
		}

		public override void Finish()
		{
		}
	}
}
