using System.Collections.Generic;
using Wasm.Instructions;

namespace Wasm.Optimize
{
	public abstract class PeepholeOptimization
	{
		public abstract uint Match(IList<Wasm.Instructions.Instruction> instructions);

		public abstract IList<Wasm.Instructions.Instruction> Rewrite(IList<Wasm.Instructions.Instruction> matched);
	}
}
