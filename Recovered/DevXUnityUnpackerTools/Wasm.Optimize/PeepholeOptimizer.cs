using System.Collections.Generic;
using System.Linq;
using Wasm.Instructions;

namespace Wasm.Optimize
{
	public sealed class PeepholeOptimizer
	{
		internal IEnumerable<PeepholeOptimization> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020;

		public static readonly IEnumerable<PeepholeOptimization> DefaultOptimizations = new PeepholeOptimization[2]
		{
			TeeLocalOptimization.Instance,
			UnreachableCodeOptimization.Instance
		};

		public static PeepholeOptimizer DefaultOptimizer => new PeepholeOptimizer(DefaultOptimizations);

		public PeepholeOptimizer(IEnumerable<PeepholeOptimization> optimizations)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 = optimizations;
		}

		public IList<Wasm.Instructions.Instruction> Optimize(IList<Wasm.Instructions.Instruction> instructions)
		{
			Wasm.Instructions.Instruction[] array = instructions.ToArray();
			List<Wasm.Instructions.Instruction> list = new List<Wasm.Instructions.Instruction>();
			int num = 0;
			while (num < array.Length)
			{
				List<Wasm.Instructions.Instruction> list2 = new List<Wasm.Instructions.Instruction>();
				for (int i = num; i < array.Length; i++)
				{
					list2.Add(array[i]);
				}
				PeepholeOptimization peepholeOptimization;
				uint num2 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A(list2, out peepholeOptimization);
				if (num2 != 0)
				{
					List<Wasm.Instructions.Instruction> list3 = new List<Wasm.Instructions.Instruction>();
					for (int j = num; j < num + num2; j++)
					{
						list3.Add(array[j]);
					}
					list.AddRange(peepholeOptimization.Rewrite(list3));
					num += (int)num2;
					continue;
				}
				if (array[num] is BlockInstruction)
				{
					BlockInstruction blockInstruction = (BlockInstruction)array[num];
					list.Add(new BlockInstruction((BlockOperator)blockInstruction.Op, blockInstruction.Type, Optimize(blockInstruction.Contents)));
				}
				else if (array[num] is IfElseInstruction)
				{
					IfElseInstruction ifElseInstruction = (IfElseInstruction)array[num];
					list.Add(new IfElseInstruction(ifElseInstruction.Type, (ifElseInstruction.IfBranch == null) ? null : Optimize(ifElseInstruction.IfBranch), (ifElseInstruction.ElseBranch == null) ? null : Optimize(ifElseInstruction.ElseBranch)));
				}
				else
				{
					list.Add(array[num]);
				}
				num++;
			}
			return list;
		}

		internal uint _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A(IList<Wasm.Instructions.Instruction> _0020, out PeepholeOptimization _0020_000A)
		{
			uint num = 0u;
			PeepholeOptimization peepholeOptimization = null;
			foreach (PeepholeOptimization item in _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
			{
				uint num2 = item.Match(_0020);
				if (num2 > num)
				{
					num = num2;
					peepholeOptimization = item;
				}
			}
			_0020_000A = peepholeOptimization;
			return num;
		}
	}
}
