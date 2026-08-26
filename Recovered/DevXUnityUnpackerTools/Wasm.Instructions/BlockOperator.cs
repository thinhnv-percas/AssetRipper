using System.Collections.Generic;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class BlockOperator : Operator
	{
		public BlockOperator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public BlockInstruction Create(WasmType blockType, IEnumerable<Instruction> contents)
		{
			return new BlockInstruction(this, blockType, contents);
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			WasmType blockType = reader.ReadWasmType();
			return ReadBlockContents(blockType, reader);
		}

		public BlockInstruction ReadBlockContents(WasmType blockType, BinaryWasmReader reader)
		{
			List<Instruction> list = new List<Instruction>();
			while (true)
			{
				byte b = reader.ReadByte();
				if (b == 11)
				{
					break;
				}
				Operator @operator = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020(b);
				list.Add(@operator.ReadImmediates(reader));
			}
			return Create(blockType, list);
		}

		public BlockInstruction CastInstruction(Instruction value)
		{
			return (BlockInstruction)value;
		}
	}
}
