using System.Collections.Generic;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public sealed class IfElseOperator : Operator
	{
		internal IfElseOperator(byte opCode, WasmType declaringType, string mnemonic)
			: base(opCode, declaringType, mnemonic)
		{
		}

		public override Instruction ReadImmediates(BinaryWasmReader reader)
		{
			return ReadBlockContents(reader.ReadWasmType(), reader);
		}

		public static IfElseInstruction ReadBlockContents(WasmType blockType, BinaryWasmReader reader)
		{
			List<Instruction> list = new List<Instruction>();
			List<Instruction> list2 = null;
			while (true)
			{
				byte b = reader.ReadByte();
				switch (b)
				{
				case 11:
					return new IfElseInstruction(blockType, list, list2);
				case 5:
					if (list2 != null)
					{
						throw new WasmException("More than one 'else' opcode in an 'if' instruction");
					}
					list2 = new List<Instruction>();
					break;
				default:
				{
					Operator @operator = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020(b);
					((list2 == null) ? list : list2).Add(@operator.ReadImmediates(reader));
					break;
				}
				}
			}
		}

		public IfElseInstruction Create(WasmType type, IEnumerable<Instruction> ifBranch, IEnumerable<Instruction> elseBranch)
		{
			return new IfElseInstruction(type, ifBranch, elseBranch);
		}

		public IfElseInstruction CastInstruction(Instruction value)
		{
			return (IfElseInstruction)value;
		}
	}
}
