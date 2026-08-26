using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class SsaFormBuilder
	{
		private readonly MethodDefinition method;

		private readonly ControlFlowGraph cfg;

		private readonly SsaBlock[] blocks;

		private readonly int[] stackSizeAtBlockStart;

		private readonly SsaVariable[] parameters;

		private readonly SsaVariable[] locals;

		private readonly SsaVariable[] stackLocations;

		private SsaForm ssaForm;

		public static SsaForm Build(MethodDefinition method)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			ControlFlowGraph controlFlowGraph = ControlFlowGraphBuilder.Build(method.Body);
			controlFlowGraph.ComputeDominance();
			controlFlowGraph.ComputeDominanceFrontier();
			SsaForm ssaForm = BuildRegisterIL(method, controlFlowGraph);
			TransformToSsa.Transform(controlFlowGraph, ssaForm);
			return ssaForm;
		}

		public static SsaForm BuildRegisterIL(MethodDefinition method, ControlFlowGraph cfg)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (cfg == null)
			{
				throw new ArgumentNullException("cfg");
			}
			return new SsaFormBuilder(method, cfg).Build();
		}

		private SsaFormBuilder(MethodDefinition method, ControlFlowGraph cfg)
		{
			this.method = method;
			this.cfg = cfg;
			blocks = new SsaBlock[cfg.Nodes.Count];
			stackSizeAtBlockStart = new int[cfg.Nodes.Count];
			for (int i = 0; i < stackSizeAtBlockStart.Length; i++)
			{
				stackSizeAtBlockStart[i] = -1;
			}
			stackSizeAtBlockStart[cfg.EntryPoint.BlockIndex] = 0;
			parameters = new SsaVariable[method.Parameters.Count + (method.HasThis ? 1 : 0)];
			if (method.HasThis)
			{
				parameters[0] = new SsaVariable(method.Body.ThisParameter);
			}
			for (int j = 0; j < method.Parameters.Count; j++)
			{
				parameters[j + (method.HasThis ? 1 : 0)] = new SsaVariable(method.Parameters[j]);
			}
			locals = new SsaVariable[method.Body.Variables.Count];
			for (int k = 0; k < locals.Length; k++)
			{
				locals[k] = new SsaVariable(method.Body.Variables[k]);
			}
			stackLocations = new SsaVariable[method.Body.MaxStackSize];
			for (int l = 0; l < stackLocations.Length; l++)
			{
				stackLocations[l] = new SsaVariable(l);
			}
		}

		internal SsaForm Build()
		{
			CreateGraphStructure();
			ssaForm = new SsaForm(blocks, parameters, locals, stackLocations, method.HasThis);
			CreateInstructions(cfg.EntryPoint.BlockIndex);
			CreateSpecialInstructions();
			return ssaForm;
		}

		private void CreateGraphStructure()
		{
			for (int i = 0; i < blocks.Length; i++)
			{
				blocks[i] = new SsaBlock(cfg.Nodes[i]);
			}
			for (int j = 0; j < blocks.Length; j++)
			{
				foreach (ControlFlowNode successor in cfg.Nodes[j].Successors)
				{
					blocks[j].Successors.Add(blocks[successor.BlockIndex]);
					blocks[successor.BlockIndex].Predecessors.Add(blocks[j]);
				}
			}
		}

		private void CreateInstructions(int blockIndex)
		{
			ControlFlowNode controlFlowNode = cfg.Nodes[blockIndex];
			SsaBlock ssaBlock = blocks[blockIndex];
			int num = stackSizeAtBlockStart[blockIndex];
			List<Instruction> list = new List<Instruction>();
			foreach (Instruction instruction in controlFlowNode.Instructions)
			{
				if (instruction.OpCode.OpCodeType == OpCodeType.Prefix)
				{
					list.Add(instruction);
				}
				else
				{
					int num2 = instruction.GetPopDelta(method) ?? num;
					num -= num2;
					if (num < 0)
					{
						throw new InvalidProgramException("IL stack underflow");
					}
					int pushDelta = instruction.GetPushDelta();
					if (num + pushDelta > stackLocations.Length)
					{
						throw new InvalidProgramException("IL stack overflow");
					}
					DetermineOperands(num, instruction, num2, pushDelta, out SsaVariable target, out SsaVariable[] operands);
					Instruction[] prefixes = (list.Count > 0) ? list.ToArray() : null;
					list.Clear();
					if (!(instruction.OpCode == OpCodes.Nop) && !(instruction.OpCode == OpCodes.Pop))
					{
						ssaBlock.Instructions.Add(new SsaInstruction(ssaBlock, instruction, target, operands, prefixes));
					}
					num += pushDelta;
				}
			}
			foreach (ControlFlowEdge item in controlFlowNode.Outgoing)
			{
				int num3;
				switch (item.Type)
				{
				case JumpType.Normal:
					num3 = num;
					break;
				case JumpType.EndFinally:
					if (num != 0)
					{
						throw new NotSupportedException("stacksize must be 0 in endfinally edge");
					}
					num3 = 0;
					break;
				case JumpType.JumpToExceptionHandler:
					switch (item.Target.NodeType)
					{
					case ControlFlowNodeType.FinallyOrFaultHandler:
						num3 = 0;
						break;
					case ControlFlowNodeType.ExceptionalExit:
					case ControlFlowNodeType.CatchHandler:
						num3 = 1;
						break;
					default:
						throw new NotSupportedException("unsupported target node type: " + item.Target.NodeType);
					}
					break;
				default:
					throw new NotSupportedException("unsupported jump type: " + item.Type);
				}
				int num4 = stackSizeAtBlockStart[item.Target.BlockIndex];
				if (num4 == -1)
				{
					stackSizeAtBlockStart[item.Target.BlockIndex] = num3;
					CreateInstructions(item.Target.BlockIndex);
				}
				else if (num4 != num3)
				{
					throw new InvalidProgramException("Stack size doesn't match");
				}
			}
		}

		private void DetermineOperands(int stackSize, Instruction inst, int popCount, int pushCount, out SsaVariable target, out SsaVariable[] operands)
		{
			switch (inst.OpCode.Code)
			{
			case Code.Ldarg:
				operands = new SsaVariable[1]
				{
					ssaForm.GetOriginalVariable((ParameterReference)inst.Operand)
				};
				target = stackLocations[stackSize];
				return;
			case Code.Starg:
				operands = new SsaVariable[1]
				{
					stackLocations[stackSize]
				};
				target = ssaForm.GetOriginalVariable((ParameterReference)inst.Operand);
				return;
			case Code.Ldloc:
				operands = new SsaVariable[1]
				{
					ssaForm.GetOriginalVariable((VariableReference)inst.Operand)
				};
				target = stackLocations[stackSize];
				return;
			case Code.Stloc:
				operands = new SsaVariable[1]
				{
					stackLocations[stackSize]
				};
				target = ssaForm.GetOriginalVariable((VariableReference)inst.Operand);
				return;
			case Code.Dup:
				operands = new SsaVariable[1]
				{
					stackLocations[stackSize]
				};
				target = stackLocations[stackSize + 1];
				return;
			}
			operands = new SsaVariable[popCount];
			for (int i = 0; i < popCount; i++)
			{
				operands[i] = stackLocations[stackSize + i];
			}
			switch (pushCount)
			{
			case 0:
				target = null;
				break;
			case 1:
				target = stackLocations[stackSize];
				break;
			default:
				throw new NotSupportedException("unsupported pushCount=" + pushCount);
			}
		}

		private void CreateSpecialInstructions()
		{
			SsaVariable[] array = parameters;
			foreach (SsaVariable target in array)
			{
				ssaForm.EntryPoint.Instructions.Add(new SsaInstruction(ssaForm.EntryPoint, null, target, null, null, SpecialOpCode.Parameter));
			}
			array = locals;
			foreach (SsaVariable target2 in array)
			{
				ssaForm.EntryPoint.Instructions.Add(new SsaInstruction(ssaForm.EntryPoint, null, target2, null, null, SpecialOpCode.Uninitialized));
			}
			array = stackLocations;
			foreach (SsaVariable target3 in array)
			{
				ssaForm.EntryPoint.Instructions.Add(new SsaInstruction(ssaForm.EntryPoint, null, target3, null, null, SpecialOpCode.Uninitialized));
			}
			SsaBlock[] array2 = blocks;
			foreach (SsaBlock ssaBlock in array2)
			{
				if (ssaBlock.NodeType == ControlFlowNodeType.CatchHandler)
				{
					ssaBlock.Instructions.Add(new SsaInstruction(ssaBlock, null, stackLocations[0], null, null, SpecialOpCode.Exception, cfg.Nodes[ssaBlock.BlockIndex].ExceptionHandler.CatchType));
				}
			}
		}
	}
}
