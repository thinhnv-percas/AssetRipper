using Mono.Cecil.Cil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	internal static class SsaOptimization
	{
		public static void Optimize(SsaForm ssaForm)
		{
			DirectlyStoreToVariables(ssaForm);
			SimpleCopyPropagation(ssaForm);
			RemoveDeadAssignments(ssaForm);
		}

		public static void DirectlyStoreToVariables(SsaForm ssaForm)
		{
			foreach (SsaBlock block in ssaForm.Blocks)
			{
				block.Instructions.RemoveAll(delegate(SsaInstruction inst)
				{
					if (inst.Instruction != null && (inst.Instruction.OpCode == OpCodes.Stloc || inst.Instruction.OpCode == OpCodes.Starg))
					{
						SsaVariable target = inst.Target;
						SsaVariable ssaVariable = inst.Operands[0];
						if (target.IsSingleAssignment && ssaVariable.IsSingleAssignment && ssaVariable.Usage.Count == 1 && ssaVariable.IsStackLocation)
						{
							ssaVariable.Definition.Target = target;
							return true;
						}
					}
					return false;
				});
			}
			ssaForm.ComputeVariableUsage();
		}

		public static void SimpleCopyPropagation(SsaForm ssaForm, bool onlyForStackLocations = true)
		{
			foreach (SsaBlock block in ssaForm.Blocks)
			{
				foreach (SsaInstruction instruction in block.Instructions)
				{
					if (instruction.IsMoveInstruction && instruction.Target.IsSingleAssignment && instruction.Operands[0].IsSingleAssignment && (instruction.Target.IsStackLocation || !onlyForStackLocations))
					{
						foreach (SsaInstruction item in instruction.Target.Usage)
						{
							item.ReplaceVariableInOperands(instruction.Target, instruction.Operands[0]);
						}
					}
				}
			}
			ssaForm.ComputeVariableUsage();
		}

		public static void RemoveDeadAssignments(SsaForm ssaForm)
		{
			HashSet<SsaVariable> liveVariables = new HashSet<SsaVariable>();
			foreach (SsaBlock block in ssaForm.Blocks)
			{
				foreach (SsaInstruction instruction in block.Instructions)
				{
					if (!CanRemoveAsDeadCode(instruction))
					{
						if (instruction.Target != null)
						{
							liveVariables.Add(instruction.Target);
						}
						SsaVariable[] operands = instruction.Operands;
						foreach (SsaVariable item in operands)
						{
							liveVariables.Add(item);
						}
					}
				}
			}
			Queue<SsaVariable> queue = new Queue<SsaVariable>(liveVariables);
			while (queue.Count > 0)
			{
				SsaVariable ssaVariable = queue.Dequeue();
				if (!ssaVariable.IsSingleAssignment)
				{
					continue;
				}
				SsaVariable[] operands = ssaVariable.Definition.Operands;
				foreach (SsaVariable item2 in operands)
				{
					if (liveVariables.Add(item2))
					{
						queue.Enqueue(item2);
					}
				}
			}
			foreach (SsaBlock block2 in ssaForm.Blocks)
			{
				block2.Instructions.RemoveAll((SsaInstruction inst) => (inst.Target != null && !liveVariables.Contains(inst.Target)) ? true : false);
			}
			ssaForm.ComputeVariableUsage();
		}

		private static bool CanRemoveAsDeadCode(SsaInstruction inst)
		{
			if (inst.Target != null && !inst.Target.IsSingleAssignment)
			{
				return false;
			}
			switch (inst.SpecialOpCode)
			{
			case SpecialOpCode.Phi:
			case SpecialOpCode.Uninitialized:
			case SpecialOpCode.Parameter:
			case SpecialOpCode.Exception:
				return true;
			case SpecialOpCode.None:
				return inst.IsMoveInstruction;
			default:
				return false;
			}
		}
	}
}
