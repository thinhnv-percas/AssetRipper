using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	internal sealed class TransformToSsa
	{
		private sealed class VariableRenamer
		{
			private readonly TransformToSsa transform;

			private readonly ReadOnlyCollection<SsaVariable> inputVariables;

			internal readonly Stack<SsaVariable>[] versionStacks;

			private int[] versionCounters;

			public VariableRenamer(TransformToSsa transform, bool[] processVariable)
			{
				this.transform = transform;
				inputVariables = transform.ssaForm.OriginalVariables;
				versionCounters = new int[inputVariables.Count];
				versionStacks = new Stack<SsaVariable>[inputVariables.Count];
				for (int i = 0; i < versionStacks.Length; i++)
				{
					if (processVariable[i])
					{
						versionStacks[i] = new Stack<SsaVariable>();
						versionStacks[i].Push(inputVariables[i]);
					}
				}
			}

			private SsaVariable MakeNewVersion(int variableIndex)
			{
				int num = ++versionCounters[variableIndex];
				SsaVariable ssaVariable = inputVariables[variableIndex];
				if (num == 1)
				{
					return ssaVariable;
				}
				if (ssaVariable.IsStackLocation)
				{
					return new SsaVariable(ssaVariable, "temp" + transform.tempVariableCounter++);
				}
				return new SsaVariable(ssaVariable, ssaVariable.Name + "_" + num);
			}

			internal void Visit(SsaBlock block)
			{
				Stack<SsaVariable>[] array = versionStacks;
				foreach (Stack<SsaVariable> stack in array)
				{
					stack?.Push(stack.Peek());
				}
				foreach (SsaInstruction instruction in block.Instructions)
				{
					if (instruction.SpecialOpCode != SpecialOpCode.Phi)
					{
						for (int j = 0; j < instruction.Operands.Length; j++)
						{
							Stack<SsaVariable> stack2 = versionStacks[instruction.Operands[j].OriginalVariableIndex];
							if (stack2 != null)
							{
								instruction.Operands[j] = stack2.Peek();
							}
						}
					}
					if (instruction.Target != null)
					{
						int originalVariableIndex = instruction.Target.OriginalVariableIndex;
						if (versionStacks[originalVariableIndex] != null)
						{
							instruction.Target = MakeNewVersion(originalVariableIndex);
							instruction.Target.IsSingleAssignment = true;
							instruction.Target.Definition = instruction;
							versionStacks[originalVariableIndex].Pop();
							versionStacks[originalVariableIndex].Push(instruction.Target);
						}
					}
				}
				foreach (SsaBlock successor in block.Successors)
				{
					int num = successor.Predecessors.IndexOf(block);
					foreach (SsaInstruction instruction2 in successor.Instructions)
					{
						if (instruction2.SpecialOpCode == SpecialOpCode.Phi)
						{
							Stack<SsaVariable> stack3 = versionStacks[instruction2.Target.OriginalVariableIndex];
							if (stack3 != null)
							{
								instruction2.Operands[num] = stack3.Peek();
							}
						}
					}
				}
				foreach (ControlFlowNode dominatorTreeChild in transform.cfg.Nodes[block.BlockIndex].DominatorTreeChildren)
				{
					Visit(transform.ssaForm.Blocks[dominatorTreeChild.BlockIndex]);
				}
				array = versionStacks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i]?.Pop();
				}
			}
		}

		private readonly ControlFlowGraph cfg;

		private readonly SsaForm ssaForm;

		private readonly List<SsaInstruction>[] writeToOriginalVariables;

		private readonly bool[] addressTaken;

		private int tempVariableCounter = 1;

		public static void Transform(ControlFlowGraph cfg, SsaForm ssa, bool optimize = true)
		{
			TransformToSsa transformToSsa = new TransformToSsa(cfg, ssa);
			transformToSsa.ConvertVariablesToSsa();
			SsaOptimization.RemoveDeadAssignments(ssa);
			if (SimplifyByRefCalls.MakeByRefCallsSimple(ssa))
			{
				transformToSsa.ConvertVariablesToSsa();
			}
			if (optimize)
			{
				SsaOptimization.Optimize(ssa);
			}
		}

		private TransformToSsa(ControlFlowGraph cfg, SsaForm ssaForm)
		{
			this.cfg = cfg;
			this.ssaForm = ssaForm;
			writeToOriginalVariables = new List<SsaInstruction>[ssaForm.OriginalVariables.Count];
			addressTaken = new bool[ssaForm.OriginalVariables.Count];
		}

		private void CollectInformationAboutOriginalVariableUse()
		{
			for (int i = 0; i < writeToOriginalVariables.Length; i++)
			{
				addressTaken[i] = false;
				if (ssaForm.OriginalVariables[i].IsSingleAssignment)
				{
					writeToOriginalVariables[i] = null;
				}
				else
				{
					writeToOriginalVariables[i] = new List<SsaInstruction>();
				}
			}
			foreach (SsaBlock block in ssaForm.Blocks)
			{
				foreach (SsaInstruction instruction in block.Instructions)
				{
					if (instruction.Target != null)
					{
						writeToOriginalVariables[instruction.Target.OriginalVariableIndex]?.Add(instruction);
					}
					if (instruction.Instruction != null)
					{
						if (instruction.Instruction.OpCode == OpCodes.Ldloca)
						{
							addressTaken[ssaForm.GetOriginalVariable((VariableDefinition)instruction.Instruction.Operand).OriginalVariableIndex] = true;
						}
						else if (instruction.Instruction.OpCode == OpCodes.Ldarga)
						{
							addressTaken[ssaForm.GetOriginalVariable((ParameterDefinition)instruction.Instruction.Operand).OriginalVariableIndex] = true;
						}
					}
				}
			}
		}

		private void ConvertVariablesToSsa()
		{
			CollectInformationAboutOriginalVariableUse();
			bool[] array = new bool[ssaForm.OriginalVariables.Count];
			foreach (SsaVariable originalVariable in ssaForm.OriginalVariables)
			{
				if (!originalVariable.IsSingleAssignment && !addressTaken[originalVariable.OriginalVariableIndex])
				{
					PlacePhiFunctions(originalVariable);
					array[originalVariable.OriginalVariableIndex] = true;
				}
			}
			RenameVariables(array);
			foreach (SsaVariable originalVariable2 in ssaForm.OriginalVariables)
			{
				bool flag = addressTaken[originalVariable2.OriginalVariableIndex];
			}
			ssaForm.ComputeVariableUsage();
		}

		private void PlacePhiFunctions(SsaVariable variable)
		{
			cfg.ResetVisited();
			HashSet<SsaBlock> hashSet = new HashSet<SsaBlock>();
			Queue<ControlFlowNode> queue = new Queue<ControlFlowNode>();
			foreach (SsaInstruction item in writeToOriginalVariables[variable.OriginalVariableIndex])
			{
				ControlFlowNode controlFlowNode = cfg.Nodes[item.ParentBlock.BlockIndex];
				if (!controlFlowNode.Visited)
				{
					controlFlowNode.Visited = true;
					queue.Enqueue(controlFlowNode);
				}
			}
			while (queue.Count > 0)
			{
				foreach (ControlFlowNode item2 in queue.Dequeue().DominanceFrontier)
				{
					if (item2.NodeType != ControlFlowNodeType.RegularExit && item2.NodeType != ControlFlowNodeType.ExceptionalExit)
					{
						SsaBlock ssaBlock = ssaForm.Blocks[item2.BlockIndex];
						if (hashSet.Add(ssaBlock))
						{
							SsaVariable[] operands = Enumerable.Repeat(variable, item2.Incoming.Count).ToArray();
							ssaBlock.Instructions.Insert(0, new SsaInstruction(ssaBlock, null, variable, operands, null, SpecialOpCode.Phi));
							if (!item2.Visited)
							{
								item2.Visited = true;
								queue.Enqueue(item2);
							}
						}
					}
				}
			}
		}

		private void RenameVariables(bool[] processVariable)
		{
			new VariableRenamer(this, processVariable).Visit(ssaForm.EntryPoint);
		}
	}
}
