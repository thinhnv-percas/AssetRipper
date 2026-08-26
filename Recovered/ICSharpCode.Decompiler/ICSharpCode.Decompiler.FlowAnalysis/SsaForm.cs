using ICSharpCode.NRefactory.Utils;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class SsaForm
	{
		private readonly SsaVariable[] parameters;

		private readonly SsaVariable[] locals;

		public readonly ReadOnlyCollection<SsaVariable> OriginalVariables;

		public readonly ReadOnlyCollection<SsaBlock> Blocks;

		private readonly bool methodHasThis;

		public SsaBlock EntryPoint => Blocks[0];

		public SsaBlock RegularExit => Blocks[1];

		public SsaBlock ExceptionalExit => Blocks[2];

		public IEnumerable<SsaVariable> AllVariables => (from block in Blocks
			from instruction in block.Instructions
			where instruction.Target != null
			select instruction.Target).Distinct();

		internal SsaForm(SsaBlock[] blocks, SsaVariable[] parameters, SsaVariable[] locals, SsaVariable[] stackLocations, bool methodHasThis)
		{
			this.parameters = parameters;
			this.locals = locals;
			Blocks = new ReadOnlyCollection<SsaBlock>(blocks);
			OriginalVariables = new ReadOnlyCollection<SsaVariable>(parameters.Concat(locals).Concat(stackLocations).ToList());
			this.methodHasThis = methodHasThis;
			for (int i = 0; i < OriginalVariables.Count; i++)
			{
				OriginalVariables[i].OriginalVariableIndex = i;
			}
		}

		public GraphVizGraph ExportBlockGraph(Func<SsaBlock, string> labelProvider = null)
		{
			if (labelProvider == null)
			{
				labelProvider = ((SsaBlock b) => b.ToString());
			}
			GraphVizGraph graphVizGraph = new GraphVizGraph();
			foreach (SsaBlock block in Blocks)
			{
				graphVizGraph.AddNode(new GraphVizNode(block.BlockIndex)
				{
					label = labelProvider(block),
					shape = "box"
				});
			}
			foreach (SsaBlock block2 in Blocks)
			{
				foreach (SsaBlock successor in block2.Successors)
				{
					graphVizGraph.AddEdge(new GraphVizEdge(block2.BlockIndex, successor.BlockIndex));
				}
			}
			return graphVizGraph;
		}

		public GraphVizGraph ExportVariableGraph(Func<SsaVariable, string> labelProvider = null)
		{
			if (labelProvider == null)
			{
				labelProvider = ((SsaVariable v) => v.ToString());
			}
			GraphVizGraph graphVizGraph = new GraphVizGraph();
			foreach (SsaVariable allVariable in AllVariables)
			{
				graphVizGraph.AddNode(new GraphVizNode(allVariable.Name)
				{
					label = labelProvider(allVariable)
				});
			}
			int num = 0;
			foreach (SsaBlock block in Blocks)
			{
				foreach (SsaInstruction instruction in block.Instructions)
				{
					if (instruction.Operands.Length != 0 || instruction.Target != null)
					{
						string text = "instruction" + ++num;
						graphVizGraph.AddNode(new GraphVizNode(text)
						{
							label = instruction.ToString(),
							shape = "box"
						});
						SsaVariable[] operands = instruction.Operands;
						foreach (SsaVariable ssaVariable in operands)
						{
							graphVizGraph.AddEdge(new GraphVizEdge(ssaVariable.Name, text));
						}
						if (instruction.Target != null)
						{
							graphVizGraph.AddEdge(new GraphVizEdge(text, instruction.Target.Name));
						}
					}
				}
			}
			return graphVizGraph;
		}

		public SsaVariable GetOriginalVariable(ParameterReference parameter)
		{
			if (methodHasThis)
			{
				return parameters[parameter.Index + 1];
			}
			return parameters[parameter.Index];
		}

		public SsaVariable GetOriginalVariable(VariableReference variable)
		{
			return locals[variable.Index];
		}

		public void ComputeVariableUsage()
		{
			foreach (SsaBlock block in Blocks)
			{
				foreach (SsaInstruction instruction in block.Instructions)
				{
					SsaVariable[] operands = instruction.Operands;
					foreach (SsaVariable ssaVariable in operands)
					{
						if (ssaVariable.Usage != null)
						{
							ssaVariable.Usage.Clear();
						}
					}
					if (instruction.Target != null && instruction.Target.Usage != null)
					{
						instruction.Target.Usage.Clear();
					}
				}
			}
			foreach (SsaBlock block2 in Blocks)
			{
				foreach (SsaInstruction instruction2 in block2.Instructions)
				{
					SsaVariable[] operands = instruction2.Operands;
					foreach (SsaVariable ssaVariable2 in operands)
					{
						if (ssaVariable2.Usage == null)
						{
							ssaVariable2.Usage = new List<SsaInstruction>();
						}
						ssaVariable2.Usage.Add(instruction2);
					}
					if (instruction2.Target != null && instruction2.Target.Usage == null)
					{
						instruction2.Target.Usage = new List<SsaInstruction>();
					}
				}
			}
		}
	}
}
