using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Instructions;

namespace Wasm.Interpret
{
	public class TracingInstructionInterpreter : InstructionInterpreter
	{
		[CompilerGenerated]
		internal InstructionInterpreter _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		internal TextWriter _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020;

		public InstructionInterpreter Interpreter
		{
			get;
			internal set;
		}

		public TextWriter TraceWriter
		{
			get;
			internal set;
		}

		public TracingInstructionInterpreter(InstructionInterpreter interpreter, TextWriter traceWriter)
		{
			Interpreter = interpreter;
			TraceWriter = traceWriter;
		}

		internal virtual void Trace(Wasm.Instructions.Instruction value)
		{
			if (value is BlockInstruction || value is IfElseInstruction)
			{
				value.Op.Dump(TraceWriter);
			}
			else
			{
				value.Dump(TraceWriter);
			}
			TraceWriter.WriteLine();
		}

		public override void Interpret(Wasm.Instructions.Instruction value, InterpreterContext context)
		{
			if (!context.HasReturned)
			{
				Trace(value);
			}
			Interpreter.Interpret(value, context);
		}
	}
}
