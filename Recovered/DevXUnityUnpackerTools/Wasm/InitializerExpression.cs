using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Wasm.Binary;
using Wasm.Instructions;

namespace Wasm
{
	public sealed class InitializerExpression
	{
		[CompilerGenerated]
		internal List<Wasm.Instructions.Instruction> _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020;

		public List<Wasm.Instructions.Instruction> BodyInstructions
		{
			get;
			internal set;
		}

		public InitializerExpression(IEnumerable<Wasm.Instructions.Instruction> body)
		{
			BodyInstructions = new List<Wasm.Instructions.Instruction>(body);
		}

		public InitializerExpression(params Wasm.Instructions.Instruction[] body)
			: this((IEnumerable<Wasm.Instructions.Instruction>)body)
		{
		}

		public static InitializerExpression ReadFrom(BinaryWasmReader reader)
		{
			return new InitializerExpression(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.ReadBlockContents(WasmType.Empty, reader).Contents);
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Create(WasmType.Empty, BodyInstructions).WriteContentsTo(writer);
		}
	}
}
