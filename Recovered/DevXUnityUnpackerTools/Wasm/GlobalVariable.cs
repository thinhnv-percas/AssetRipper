using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;
using Wasm.Instructions;

namespace Wasm
{
	public sealed class GlobalVariable
	{
		[CompilerGenerated]
		internal GlobalType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal InitializerExpression _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020;

		public GlobalType Type
		{
			get;
			set;
		}

		public InitializerExpression InitialValue
		{
			get;
			set;
		}

		public GlobalVariable(GlobalType type, InitializerExpression initialValue)
		{
			Type = type;
			InitialValue = initialValue;
		}

		public static GlobalVariable ReadFrom(BinaryWasmReader reader)
		{
			return new GlobalVariable(GlobalType.ReadFrom(reader), InitializerExpression.ReadFrom(reader));
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			Type.WriteTo(writer);
			InitialValue.WriteTo(writer);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("- Type: ");
			Type.Dump(writer);
			writer.WriteLine();
			writer.Write("- Initial value:");
			TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
			foreach (Wasm.Instructions.Instruction bodyInstruction in InitialValue.BodyInstructions)
			{
				textWriter.WriteLine();
				bodyInstruction.Dump(textWriter);
			}
		}
	}
}
