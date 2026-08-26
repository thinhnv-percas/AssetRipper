using System.Collections.Generic;
using Wasm.Instructions;

namespace Wasm.Optimize
{
	public static class WasmFileOptimizations
	{
		public static void Optimize(this WasmFile file)
		{
			file.CompressFunctionTypes();
			foreach (Section section in file.Sections)
			{
				if (section is CodeSection)
				{
					((CodeSection)section).Optimize();
				}
			}
		}

		public static void Optimize(this CodeSection section)
		{
			PeepholeOptimizer defaultOptimizer = PeepholeOptimizer.DefaultOptimizer;
			foreach (FunctionBody body in section.Bodies)
			{
				body.CompressLocalEntries();
				IList<Wasm.Instructions.Instruction> collection = defaultOptimizer.Optimize(body.BodyInstructions);
				body.BodyInstructions.Clear();
				body.BodyInstructions.AddRange(collection);
			}
		}
	}
}
