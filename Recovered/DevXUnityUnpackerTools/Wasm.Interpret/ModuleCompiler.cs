using System.Collections.Generic;

namespace Wasm.Interpret
{
	public abstract class ModuleCompiler
	{
		public abstract void Initialize(ModuleInstance module, int offset, IList<FunctionType> types);

		public abstract FunctionDefinition Compile(int index, FunctionBody body);

		public abstract void Finish();
	}
}
