using Wasm.Instructions;

namespace Wasm.Interpret
{
	public abstract class InstructionInterpreter
	{
		public abstract void Interpret(Wasm.Instructions.Instruction value, InterpreterContext context);
	}
}
