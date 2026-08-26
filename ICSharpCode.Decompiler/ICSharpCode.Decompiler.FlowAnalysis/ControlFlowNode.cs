using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.Disassembler;

namespace ICSharpCode.Decompiler.FlowAnalysis;

public sealed class ControlFlowNode
{
	public readonly int BlockIndex;

	public readonly uint? Offset;

	public readonly ControlFlowNodeType NodeType;

	public readonly ControlFlowNode EndFinallyOrFaultNode;

	public bool Visited;

	public readonly List<ControlFlowNode> DominatorTreeChildren = new List<ControlFlowNode>();

	public HashSet<ControlFlowNode> DominanceFrontier;

	public readonly LinkedListNode<Instruction> Start;

	public readonly LinkedListNode<Instruction> End;

	public readonly ExceptionHandler ExceptionHandler;

	public readonly List<ControlFlowEdge> Incoming = new List<ControlFlowEdge>();

	public readonly List<ControlFlowEdge> Outgoing = new List<ControlFlowEdge>();

	public object UserData;

	public bool IsReachable
	{
		get
		{
			if (ImmediateDominator == null)
			{
				return NodeType == ControlFlowNodeType.EntryPoint;
			}
			return true;
		}
	}

	public ControlFlowNode CopyFrom { get; internal set; }

	public ControlFlowNode ImmediateDominator { get; internal set; }

	public IEnumerable<ControlFlowNode> Predecessors => Incoming.Select((ControlFlowEdge e) => e.Source);

	public IEnumerable<ControlFlowNode> Successors => Outgoing.Select((ControlFlowEdge e) => e.Target);

	public IEnumerable<Instruction> Instructions
	{
		get
		{
			LinkedListNode<Instruction> inst = Start;
			if (inst != null)
			{
				yield return inst.Value;
				while (inst != End)
				{
					inst = inst.Next;
					yield return inst.Value;
				}
			}
		}
	}

	internal ControlFlowNode(int blockIndex, uint? offset, ControlFlowNodeType nodeType)
	{
		BlockIndex = blockIndex;
		Offset = offset;
		NodeType = nodeType;
	}

	internal ControlFlowNode(int blockIndex, LinkedListNode<Instruction> start, LinkedListNode<Instruction> end)
	{
		if (start == null)
		{
			throw new ArgumentNullException("start");
		}
		if (end == null)
		{
			throw new ArgumentNullException("end");
		}
		BlockIndex = blockIndex;
		NodeType = ControlFlowNodeType.Normal;
		Start = start;
		End = end;
		Offset = start.Value.Offset;
	}

	internal ControlFlowNode(int blockIndex, ExceptionHandler exceptionHandler, ControlFlowNode endFinallyOrFaultNode)
	{
		BlockIndex = blockIndex;
		NodeType = ((endFinallyOrFaultNode != null) ? ControlFlowNodeType.FinallyOrFaultHandler : ControlFlowNodeType.CatchHandler);
		ExceptionHandler = exceptionHandler;
		EndFinallyOrFaultNode = endFinallyOrFaultNode;
		Offset = exceptionHandler.HandlerStart.GetOffset();
	}

	public void TraversePreOrder(Func<ControlFlowNode, IEnumerable<ControlFlowNode>> children, Action<ControlFlowNode> visitAction)
	{
		if (Visited)
		{
			return;
		}
		Visited = true;
		visitAction(this);
		foreach (ControlFlowNode item in children(this))
		{
			item.TraversePreOrder(children, visitAction);
		}
	}

	public void TraversePostOrder(Func<ControlFlowNode, IEnumerable<ControlFlowNode>> children, Action<ControlFlowNode> visitAction)
	{
		if (Visited)
		{
			return;
		}
		Visited = true;
		foreach (ControlFlowNode item in children(this))
		{
			item.TraversePostOrder(children, visitAction);
		}
		visitAction(this);
	}

	public override string ToString()
	{
		StringWriter stringWriter = new StringWriter();
		switch (NodeType)
		{
		case ControlFlowNodeType.Normal:
			stringWriter.Write("Block #{0}", BlockIndex);
			if (Start != null)
			{
				stringWriter.Write(": IL_{0:x4}", Start.Value.GetOffset());
			}
			if (End != null)
			{
				stringWriter.Write(" to IL_{0:x4}", End.Value.GetEndOffset());
			}
			break;
		case ControlFlowNodeType.CatchHandler:
		case ControlFlowNodeType.FinallyOrFaultHandler:
			stringWriter.Write("Block #{0}: {1}: ", BlockIndex, NodeType);
			ExceptionHandler.WriteTo(new TextWriterDecompilerOutput(stringWriter), null);
			break;
		default:
			stringWriter.Write("Block #{0}: {1}", BlockIndex, NodeType);
			break;
		}
		if (DominanceFrontier != null && DominanceFrontier.Any())
		{
			stringWriter.WriteLine();
			stringWriter.Write("DominanceFrontier: " + string.Join(",", from d in DominanceFrontier
				orderby d.BlockIndex
				select d.BlockIndex.ToString()));
		}
		foreach (Instruction instruction in Instructions)
		{
			stringWriter.WriteLine();
			instruction.WriteTo(new TextWriterDecompilerOutput(stringWriter), null, 0u, 0L, null, null, null, null, out var _);
		}
		if (UserData != null)
		{
			stringWriter.WriteLine();
			stringWriter.Write(UserData.ToString());
		}
		return stringWriter.ToString();
	}

	public bool Dominates(ControlFlowNode node)
	{
		for (ControlFlowNode controlFlowNode = node; controlFlowNode != null; controlFlowNode = controlFlowNode.ImmediateDominator)
		{
			if (controlFlowNode == this)
			{
				return true;
			}
		}
		return false;
	}
}
