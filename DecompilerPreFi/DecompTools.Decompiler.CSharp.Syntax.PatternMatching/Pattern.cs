#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public abstract class Pattern : INode
{
	internal struct PossibleMatch
	{
		public readonly INode NextOther;

		public readonly int Checkpoint;

		public PossibleMatch(INode nextOther, int checkpoint)
		{
			NextOther = nextOther;
			Checkpoint = checkpoint;
		}
	}

	public static readonly string AnyString = "$any$";

	bool INode.IsNull => false;

	Role INode.Role => null;

	INode INode.NextSibling => null;

	INode INode.FirstChild => null;

	public static bool MatchString(string pattern, string text)
	{
		return pattern == AnyString || pattern == text;
	}

	public abstract bool DoMatch(INode other, Match match);

	public virtual bool DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
	{
		return DoMatch(pos, match);
	}

	public static bool DoMatchCollection(Role role, INode firstPatternChild, INode firstOtherChild, Match match)
	{
		BacktrackingInfo backtrackingInfo = new BacktrackingInfo();
		Stack<INode> val = new Stack<INode>();
		Stack<PossibleMatch> backtrackingStack = backtrackingInfo.backtrackingStack;
		val.Push(firstPatternChild);
		backtrackingStack.Push(new PossibleMatch(firstOtherChild, match.CheckPoint()));
		while (backtrackingStack.Count > 0)
		{
			INode node = val.Pop();
			INode node2 = backtrackingStack.Peek().NextOther;
			match.RestoreCheckPoint(backtrackingStack.Pop().Checkpoint);
			bool flag = true;
			while ((node != null) & flag)
			{
				while (node != null && node.Role != role)
				{
					node = node.NextSibling;
				}
				while (node2 != null && node2.Role != role)
				{
					node2 = node2.NextSibling;
				}
				if (node == null)
				{
					break;
				}
				Debug.Assert(backtrackingStack.Count == val.Count);
				flag = node.DoMatchCollection(role, node2, match, backtrackingInfo);
				Debug.Assert(backtrackingStack.Count >= val.Count);
				while (backtrackingStack.Count > val.Count)
				{
					val.Push(node.NextSibling);
				}
				node = node.NextSibling;
				if (node2 != null)
				{
					node2 = node2.NextSibling;
				}
			}
			while (node2 != null && node2.Role != role)
			{
				node2 = node2.NextSibling;
			}
			if (flag && node2 == null)
			{
				return true;
			}
		}
		return false;
	}
}
