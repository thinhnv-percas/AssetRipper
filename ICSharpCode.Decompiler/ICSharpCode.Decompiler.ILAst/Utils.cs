using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

internal static class Utils
{
	public static void NopMergeILSpans(ILBlockBase block, List<ILNode> newBody, int instrIndexToRemove)
	{
		List<ILNode> body = block.Body;
		ILNode iLNode = null;
		ILNode next = null;
		ILExpression iLExpression = null;
		ILExpression iLExpression2 = null;
		if (newBody.Count > 0)
		{
			iLExpression = (iLNode = newBody[newBody.Count - 1]) as ILExpression;
		}
		if (instrIndexToRemove + 1 < body.Count)
		{
			iLExpression2 = (next = body[instrIndexToRemove + 1]) as ILExpression;
		}
		ILNode iLNode2 = null;
		if (iLExpression != null && iLExpression.Prefixes == null)
		{
			ILCode code = iLExpression.Code;
			if ((uint)(code - 39) <= 1u || code == ILCode.Callvirt || (uint)(code - 247) <= 4u)
			{
				iLNode2 = iLExpression;
			}
		}
		if (iLExpression2 != null && iLExpression2.Prefixes == null && iLExpression2.Match(ILCode.Leave))
		{
			iLNode2 = iLExpression2;
		}
		if (iLNode2 != null && iLNode2 == iLNode)
		{
			AddILSpansTryPreviousFirst(body[instrIndexToRemove], iLNode, next, block);
		}
		else
		{
			AddILSpansTryNextFirst(body[instrIndexToRemove], iLNode, next, block);
		}
	}

	public static void LabelMergeILSpans(ILBlockBase block, List<ILNode> newBody, int instrIndexToRemove)
	{
		List<ILNode> body = block.Body;
		ILNode prev = null;
		ILNode next = null;
		if (newBody.Count > 0)
		{
			prev = newBody[newBody.Count - 1];
		}
		if (instrIndexToRemove + 1 < body.Count)
		{
			next = body[instrIndexToRemove + 1];
		}
		AddILSpansTryNextFirst(body[instrIndexToRemove], prev, next, block);
	}

	public static void AddILSpansTryPreviousFirst(ILNode removed, ILNode prev, ILNode next, ILBlockBase block)
	{
		if (removed != null)
		{
			AddILSpansTryPreviousFirst(prev, next, block, removed);
		}
	}

	public static void AddILSpansTryNextFirst(ILNode removed, ILNode prev, ILNode next, ILBlockBase block)
	{
		if (removed != null)
		{
			AddILSpansTryNextFirst(prev, next, block, removed);
		}
	}

	public static void AddILSpansTryPreviousFirst(ILNode prev, ILNode next, ILBlockBase block, ILNode removed)
	{
		if (prev != null && prev.SafeToAddToEndILSpans)
		{
			removed.AddSelfAndChildrenRecursiveILSpans(prev.EndILSpans);
		}
		else if (next != null)
		{
			removed.AddSelfAndChildrenRecursiveILSpans(next.ILSpans);
		}
		else if (prev != null)
		{
			removed.AddSelfAndChildrenRecursiveILSpans(block.EndILSpans);
		}
		else
		{
			removed.AddSelfAndChildrenRecursiveILSpans(block.ILSpans);
		}
	}

	public static void AddILSpansTryNextFirst(ILNode prev, ILNode next, ILBlockBase block, ILNode removed)
	{
		if (next != null)
		{
			removed.AddSelfAndChildrenRecursiveILSpans(next.ILSpans);
		}
		else if (prev != null)
		{
			if (prev.SafeToAddToEndILSpans)
			{
				removed.AddSelfAndChildrenRecursiveILSpans(prev.EndILSpans);
			}
			else
			{
				removed.AddSelfAndChildrenRecursiveILSpans(block.EndILSpans);
			}
		}
		else
		{
			removed.AddSelfAndChildrenRecursiveILSpans(block.ILSpans);
		}
	}

	public static void AddILSpansTryNextFirst(ILNode prev, ILNode next, ILBlockBase block, IEnumerable<ILSpan> ilSpans)
	{
		if (next != null)
		{
			next.ILSpans.AddRange(ilSpans);
		}
		else if (prev != null)
		{
			if (prev.SafeToAddToEndILSpans)
			{
				prev.EndILSpans.AddRange(ilSpans);
			}
			else
			{
				block.EndILSpans.AddRange(ilSpans);
			}
		}
		else
		{
			block.ILSpans.AddRange(ilSpans);
		}
	}

	public static void AddILSpansTryPreviousFirst(List<ILNode> newBody, List<ILNode> body, int removedIndex, ILBlockBase block)
	{
		ILNode prev = ((newBody.Count > 0) ? newBody[newBody.Count - 1] : null);
		ILNode next = ((removedIndex + 1 < body.Count) ? body[removedIndex + 1] : null);
		AddILSpansTryPreviousFirst(body[removedIndex], prev, next, block);
	}

	public static void AddILSpansTryNextFirst(List<ILNode> newBody, List<ILNode> body, int removedIndex, ILBlockBase block)
	{
		ILNode prev = ((newBody.Count > 0) ? newBody[newBody.Count - 1] : null);
		ILNode next = ((removedIndex + 1 < body.Count) ? body[removedIndex + 1] : null);
		AddILSpansTryNextFirst(body[removedIndex], prev, next, block);
	}

	public static void AddILSpans(ILBlockBase block, List<ILNode> body, int removedIndex)
	{
		AddILSpans(block, body, removedIndex, 1);
	}

	public static void AddILSpans(ILBlockBase block, List<ILNode> body, int removedIndex, int numRemoved)
	{
		ILNode iLNode = ((removedIndex - 1 >= 0) ? body[removedIndex - 1] : null);
		ILNode iLNode2 = ((removedIndex + numRemoved < body.Count) ? body[removedIndex + numRemoved] : null);
		ILNode iLNode3 = null;
		if (iLNode3 == null && iLNode2 is ILExpression)
		{
			iLNode3 = iLNode2;
		}
		if (iLNode3 == null && iLNode is ILExpression)
		{
			iLNode3 = iLNode;
		}
		if (iLNode3 == null && iLNode2 is ILLabel)
		{
			iLNode3 = iLNode2;
		}
		if (iLNode3 == null && iLNode is ILLabel)
		{
			iLNode3 = iLNode;
		}
		if (iLNode3 == null)
		{
			iLNode3 = iLNode2 ?? iLNode;
		}
		for (int i = 0; i < numRemoved; i++)
		{
			AddILSpansToInstruction(iLNode3, iLNode, iLNode2, block, body[removedIndex + i]);
		}
	}

	public static void AddILSpans(ILBlockBase block, List<ILNode> body, int removedIndex, IEnumerable<ILSpan> ilSpans)
	{
		ILNode iLNode = ((removedIndex - 1 >= 0) ? body[removedIndex - 1] : null);
		ILNode iLNode2 = ((removedIndex + 1 < body.Count) ? body[removedIndex + 1] : null);
		ILNode iLNode3 = null;
		if (iLNode3 == null && iLNode2 is ILExpression)
		{
			iLNode3 = iLNode2;
		}
		if (iLNode3 == null && iLNode is ILExpression)
		{
			iLNode3 = iLNode;
		}
		if (iLNode3 == null && iLNode2 is ILLabel)
		{
			iLNode3 = iLNode2;
		}
		if (iLNode3 == null && iLNode is ILLabel)
		{
			iLNode3 = iLNode;
		}
		if (iLNode3 == null)
		{
			iLNode3 = iLNode2 ?? iLNode;
		}
		AddILSpansToInstruction(iLNode3, iLNode, iLNode2, block, ilSpans);
	}

	public static void AddILSpansToInstruction(ILNode nodeToAddTo, ILNode prev, ILNode next, ILBlockBase block, ILNode removed)
	{
		if (nodeToAddTo != null)
		{
			if (nodeToAddTo == prev && prev.SafeToAddToEndILSpans)
			{
				removed.AddSelfAndChildrenRecursiveILSpans(prev.EndILSpans);
				return;
			}
			if (nodeToAddTo != null && nodeToAddTo == next)
			{
				removed.AddSelfAndChildrenRecursiveILSpans(next.ILSpans);
				return;
			}
		}
		AddILSpansTryNextFirst(prev, next, block, removed);
	}

	public static void AddILSpansToInstruction(ILNode nodeToAddTo, ILNode prev, ILNode next, ILBlockBase block, IEnumerable<ILSpan> ilSpans)
	{
		if (nodeToAddTo != null)
		{
			if (nodeToAddTo == prev && prev.SafeToAddToEndILSpans)
			{
				prev.EndILSpans.AddRange(ilSpans);
				return;
			}
			if (nodeToAddTo != null && nodeToAddTo == next)
			{
				next.ILSpans.AddRange(ilSpans);
				return;
			}
		}
		AddILSpansTryNextFirst(prev, next, block, ilSpans);
	}
}
