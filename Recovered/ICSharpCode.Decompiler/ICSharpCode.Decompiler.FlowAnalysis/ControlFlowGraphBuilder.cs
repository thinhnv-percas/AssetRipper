using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class ControlFlowGraphBuilder
	{
		private class CopyFinallySubGraphLogic
		{
			private readonly ControlFlowGraphBuilder builder;

			private readonly Dictionary<ControlFlowNode, ControlFlowNode> oldToNew = new Dictionary<ControlFlowNode, ControlFlowNode>();

			private readonly ControlFlowNode start;

			private readonly ControlFlowNode end;

			private readonly ControlFlowNode newEnd;

			public CopyFinallySubGraphLogic(ControlFlowGraphBuilder builder, ControlFlowNode start, ControlFlowNode end, ControlFlowNode newEnd)
			{
				this.builder = builder;
				this.start = start;
				this.end = end;
				this.newEnd = newEnd;
			}

			internal ControlFlowNode CopyFinallySubGraph()
			{
				foreach (ControlFlowNode predecessor in end.Predecessors)
				{
					CollectNodes(predecessor);
				}
				foreach (KeyValuePair<ControlFlowNode, ControlFlowNode> item in oldToNew)
				{
					ReconstructEdges(item.Key, item.Value);
				}
				return GetNew(start);
			}

			private void CollectNodes(ControlFlowNode node)
			{
				if (node == end || node == newEnd)
				{
					throw new InvalidOperationException("unexpected cycle involving finally construct");
				}
				if (!oldToNew.ContainsKey(node))
				{
					int count = builder.nodes.Count;
					ControlFlowNode controlFlowNode;
					switch (node.NodeType)
					{
					case ControlFlowNodeType.Normal:
						controlFlowNode = new ControlFlowNode(count, node.Start, node.End);
						break;
					case ControlFlowNodeType.FinallyOrFaultHandler:
						controlFlowNode = new ControlFlowNode(count, node.ExceptionHandler, node.EndFinallyOrFaultNode);
						break;
					default:
						throw new NotSupportedException(node.NodeType.ToString());
					}
					controlFlowNode.CopyFrom = node;
					builder.nodes.Add(controlFlowNode);
					oldToNew.Add(node, controlFlowNode);
					if (node != start)
					{
						foreach (ControlFlowNode predecessor in node.Predecessors)
						{
							CollectNodes(predecessor);
						}
					}
				}
			}

			private void ReconstructEdges(ControlFlowNode oldNode, ControlFlowNode newNode)
			{
				foreach (ControlFlowEdge item in oldNode.Outgoing)
				{
					builder.CreateEdge(newNode, GetNew(item.Target), item.Type);
				}
			}

			private ControlFlowNode GetNew(ControlFlowNode oldNode)
			{
				if (oldNode == end)
				{
					return newEnd;
				}
				if (oldToNew.TryGetValue(oldNode, out ControlFlowNode value))
				{
					return value;
				}
				return oldNode;
			}
		}

		private bool copyFinallyBlocks;

		private MethodBody methodBody;

		private int[] offsets;

		private bool[] hasIncomingJumps;

		private List<ControlFlowNode> nodes = new List<ControlFlowNode>();

		private ControlFlowNode entryPoint;

		private ControlFlowNode regularExit;

		private ControlFlowNode exceptionalExit;

		public static ControlFlowGraph Build(MethodBody methodBody)
		{
			return new ControlFlowGraphBuilder(methodBody).Build();
		}

		private ControlFlowGraphBuilder(MethodBody methodBody)
		{
			this.methodBody = methodBody;
			offsets = (from i in methodBody.Instructions
				select i.Offset).ToArray();
			hasIncomingJumps = new bool[methodBody.Instructions.Count];
			entryPoint = new ControlFlowNode(0, 0, ControlFlowNodeType.EntryPoint);
			nodes.Add(entryPoint);
			regularExit = new ControlFlowNode(1, -1, ControlFlowNodeType.RegularExit);
			nodes.Add(regularExit);
			exceptionalExit = new ControlFlowNode(2, -1, ControlFlowNodeType.ExceptionalExit);
			nodes.Add(exceptionalExit);
		}

		private int GetInstructionIndex(Instruction inst)
		{
			return Array.BinarySearch(offsets, inst.Offset);
		}

		public ControlFlowGraph Build()
		{
			CalculateHasIncomingJumps();
			CreateNodes();
			CreateRegularControlFlow();
			CreateExceptionalControlFlow();
			if (copyFinallyBlocks)
			{
				CopyFinallyBlocksIntoLeaveEdges();
			}
			else
			{
				TransformLeaveEdges();
			}
			return new ControlFlowGraph(nodes.ToArray());
		}

		private void CalculateHasIncomingJumps()
		{
			foreach (Instruction instruction in methodBody.Instructions)
			{
				if (instruction.OpCode.OperandType == OperandType.InlineBrTarget || instruction.OpCode.OperandType == OperandType.ShortInlineBrTarget)
				{
					hasIncomingJumps[GetInstructionIndex((Instruction)instruction.Operand)] = true;
				}
				else if (instruction.OpCode.OperandType == OperandType.InlineSwitch)
				{
					Instruction[] array = (Instruction[])instruction.Operand;
					foreach (Instruction inst in array)
					{
						hasIncomingJumps[GetInstructionIndex(inst)] = true;
					}
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodBody.ExceptionHandlers)
			{
				if (exceptionHandler.FilterStart != null)
				{
					hasIncomingJumps[GetInstructionIndex(exceptionHandler.FilterStart)] = true;
				}
				hasIncomingJumps[GetInstructionIndex(exceptionHandler.HandlerStart)] = true;
			}
		}

		private void CreateNodes()
		{
			for (int i = 0; i < methodBody.Instructions.Count; i++)
			{
				Instruction instruction = methodBody.Instructions[i];
				ExceptionHandler exceptionHandler = FindInnermostExceptionHandler(instruction.Offset);
				for (; i + 1 < methodBody.Instructions.Count; i++)
				{
					Instruction instruction2 = methodBody.Instructions[i];
					if (IsBranch(instruction2.OpCode) || CanThrowException(instruction2.OpCode) || hasIncomingJumps[i + 1] || (instruction2.Next != null && FindInnermostExceptionHandler(instruction2.Next.Offset) != exceptionHandler))
					{
						break;
					}
				}
				nodes.Add(new ControlFlowNode(nodes.Count, instruction, methodBody.Instructions[i]));
			}
			foreach (ExceptionHandler exceptionHandler2 in methodBody.ExceptionHandlers)
			{
				if (exceptionHandler2.HandlerType == ExceptionHandlerType.Filter)
				{
					throw new NotSupportedException();
				}
				ControlFlowNode controlFlowNode = null;
				if (exceptionHandler2.HandlerType == ExceptionHandlerType.Finally || exceptionHandler2.HandlerType == ExceptionHandlerType.Fault)
				{
					controlFlowNode = new ControlFlowNode(nodes.Count, exceptionHandler2.HandlerEnd.Offset, ControlFlowNodeType.EndFinallyOrFault);
					nodes.Add(controlFlowNode);
				}
				nodes.Add(new ControlFlowNode(nodes.Count, exceptionHandler2, controlFlowNode));
			}
		}

		private void CreateRegularControlFlow()
		{
			CreateEdge(entryPoint, methodBody.Instructions[0], JumpType.Normal);
			foreach (ControlFlowNode node in nodes)
			{
				if (node.End != null)
				{
					if (!OpCodeInfo.IsUnconditionalBranch(node.End.OpCode))
					{
						CreateEdge(node, node.End.Next, JumpType.Normal);
					}
					if (node.End.OpCode.OperandType == OperandType.InlineBrTarget || node.End.OpCode.OperandType == OperandType.ShortInlineBrTarget)
					{
						if (node.End.OpCode == OpCodes.Leave || node.End.OpCode == OpCodes.Leave_S)
						{
							if (FindInnermostHandlerBlock(node.End.Offset).NodeType == ControlFlowNodeType.FinallyOrFaultHandler)
							{
								CreateEdge(node, (Instruction)node.End.Operand, JumpType.LeaveTry);
							}
							else
							{
								CreateEdge(node, (Instruction)node.End.Operand, JumpType.Normal);
							}
						}
						else
						{
							CreateEdge(node, (Instruction)node.End.Operand, JumpType.Normal);
						}
					}
					else if (node.End.OpCode.OperandType == OperandType.InlineSwitch)
					{
						Instruction[] array = (Instruction[])node.End.Operand;
						foreach (Instruction toInstruction in array)
						{
							CreateEdge(node, toInstruction, JumpType.Normal);
						}
					}
					if (node.End.OpCode.FlowControl == FlowControl.Return)
					{
						switch (node.End.OpCode.Code)
						{
						case Code.Ret:
							CreateEdge(node, regularExit, JumpType.Normal);
							break;
						case Code.Endfinally:
						{
							ControlFlowNode controlFlowNode = FindInnermostHandlerBlock(node.End.Offset);
							if (controlFlowNode.EndFinallyOrFaultNode == null)
							{
								throw new InvalidProgramException("Found endfinally in block " + controlFlowNode);
							}
							CreateEdge(node, controlFlowNode.EndFinallyOrFaultNode, JumpType.Normal);
							break;
						}
						default:
							throw new NotSupportedException(node.End.OpCode.ToString());
						}
					}
				}
			}
		}

		private void CreateExceptionalControlFlow()
		{
			foreach (ControlFlowNode node in nodes)
			{
				if (node.End != null && CanThrowException(node.End.OpCode))
				{
					CreateEdge(node, FindInnermostExceptionHandlerNode(node.End.Offset), JumpType.JumpToExceptionHandler);
				}
				if (node.ExceptionHandler != null)
				{
					if (node.EndFinallyOrFaultNode != null)
					{
						CreateEdge(node.EndFinallyOrFaultNode, FindParentExceptionHandlerNode(node), JumpType.JumpToExceptionHandler);
					}
					else
					{
						CreateEdge(node, FindParentExceptionHandlerNode(node), JumpType.JumpToExceptionHandler);
					}
					CreateEdge(node, node.ExceptionHandler.HandlerStart, JumpType.Normal);
				}
			}
		}

		private ExceptionHandler FindInnermostExceptionHandler(int instructionOffsetInTryBlock)
		{
			foreach (ExceptionHandler exceptionHandler in methodBody.ExceptionHandlers)
			{
				if (exceptionHandler.TryStart.Offset <= instructionOffsetInTryBlock && instructionOffsetInTryBlock < exceptionHandler.TryEnd.Offset)
				{
					return exceptionHandler;
				}
			}
			return null;
		}

		private ControlFlowNode FindInnermostExceptionHandlerNode(int instructionOffsetInTryBlock)
		{
			ExceptionHandler h = FindInnermostExceptionHandler(instructionOffsetInTryBlock);
			if (h != null)
			{
				return nodes.Single((ControlFlowNode n) => n.ExceptionHandler == h && n.CopyFrom == null);
			}
			return exceptionalExit;
		}

		private ControlFlowNode FindInnermostHandlerBlock(int instructionOffset)
		{
			foreach (ExceptionHandler h in methodBody.ExceptionHandlers)
			{
				if ((h.TryStart.Offset <= instructionOffset && instructionOffset < h.TryEnd.Offset) || (h.HandlerStart.Offset <= instructionOffset && instructionOffset < h.HandlerEnd.Offset))
				{
					return nodes.Single((ControlFlowNode n) => n.ExceptionHandler == h && n.CopyFrom == null);
				}
			}
			return exceptionalExit;
		}

		private ControlFlowNode FindParentExceptionHandlerNode(ControlFlowNode exceptionHandler)
		{
			int offset = exceptionHandler.ExceptionHandler.TryStart.Offset;
			for (int i = exceptionHandler.BlockIndex + 1; i < nodes.Count; i++)
			{
				ExceptionHandler exceptionHandler2 = nodes[i].ExceptionHandler;
				if (exceptionHandler2 != null && exceptionHandler2.TryStart.Offset <= offset && offset < exceptionHandler2.TryEnd.Offset)
				{
					return nodes[i];
				}
			}
			return exceptionalExit;
		}

		private void TransformLeaveEdges()
		{
			for (int num = nodes.Count - 1; num >= 0; num--)
			{
				ControlFlowNode controlFlowNode = nodes[num];
				if (controlFlowNode.End != null && controlFlowNode.Outgoing.Count == 1 && controlFlowNode.Outgoing[0].Type == JumpType.LeaveTry)
				{
					ControlFlowNode target = controlFlowNode.Outgoing[0].Target;
					target.Incoming.Remove(controlFlowNode.Outgoing[0]);
					controlFlowNode.Outgoing.Clear();
					ControlFlowNode controlFlowNode2 = FindInnermostExceptionHandlerNode(controlFlowNode.End.Offset);
					CreateEdge(controlFlowNode, controlFlowNode2, JumpType.Normal);
					CreateEdge(controlFlowNode2.EndFinallyOrFaultNode, target, JumpType.EndFinally);
				}
			}
		}

		private void CopyFinallyBlocksIntoLeaveEdges()
		{
			for (int num = nodes.Count - 1; num >= 0; num--)
			{
				ControlFlowNode controlFlowNode = nodes[num];
				if (controlFlowNode.End != null && controlFlowNode.Outgoing.Count == 1 && controlFlowNode.Outgoing[0].Type == JumpType.LeaveTry)
				{
					ControlFlowNode target = controlFlowNode.Outgoing[0].Target;
					target.Incoming.Remove(controlFlowNode.Outgoing[0]);
					controlFlowNode.Outgoing.Clear();
					ControlFlowNode controlFlowNode2 = FindInnermostExceptionHandlerNode(controlFlowNode.End.Offset);
					ControlFlowNode toNode = CopyFinallySubGraph(controlFlowNode2, controlFlowNode2.EndFinallyOrFaultNode, target);
					CreateEdge(controlFlowNode, toNode, JumpType.Normal);
				}
			}
		}

		private ControlFlowNode CopyFinallySubGraph(ControlFlowNode start, ControlFlowNode end, ControlFlowNode newEnd)
		{
			return new CopyFinallySubGraphLogic(this, start, end, newEnd).CopyFinallySubGraph();
		}

		private void CreateEdge(ControlFlowNode fromNode, Instruction toInstruction, JumpType type)
		{
			CreateEdge(fromNode, nodes.Single((ControlFlowNode n) => n.Start == toInstruction), type);
		}

		private void CreateEdge(ControlFlowNode fromNode, ControlFlowNode toNode, JumpType type)
		{
			ControlFlowEdge item = new ControlFlowEdge(fromNode, toNode, type);
			fromNode.Outgoing.Add(item);
			toNode.Incoming.Add(item);
		}

		private static bool CanThrowException(OpCode opcode)
		{
			if (opcode.OpCodeType == OpCodeType.Prefix)
			{
				return false;
			}
			return OpCodeInfo.Get(opcode).CanThrow;
		}

		private static bool IsBranch(OpCode opcode)
		{
			if (opcode.OpCodeType == OpCodeType.Prefix)
			{
				return false;
			}
			switch (opcode.FlowControl)
			{
			case FlowControl.Branch:
			case FlowControl.Cond_Branch:
			case FlowControl.Return:
			case FlowControl.Throw:
				return true;
			case FlowControl.Call:
			case FlowControl.Next:
				return false;
			default:
				throw new NotSupportedException(opcode.FlowControl.ToString());
			}
		}
	}
}
