using System.Collections.Generic;

namespace ICSharpCode.NRefactory.PatternMatching;

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
		if (!(pattern == AnyString))
		{
			return pattern == text;
		}
		return true;
	}

	public abstract bool DoMatch(INode other, Match match);

	public virtual bool DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
	{
		return DoMatch(pos, match);
	}

	public static bool DoMatchCollection(Role role, INode firstPatternChild, INode firstOtherChild, Match match)
	{
		BacktrackingInfo backtrackingInfo = new BacktrackingInfo();
		Stack<INode> stack = new Stack<INode>();
		Stack<PossibleMatch> backtrackingStack = backtrackingInfo.backtrackingStack;
		stack.Push(firstPatternChild);
		backtrackingStack.Push(new PossibleMatch(firstOtherChild, match.CheckPoint()));
		while (backtrackingStack.Count > 0)
		{
			INode node = stack.Pop();
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
				flag = node.DoMatchCollection(role, node2, match, backtrackingInfo);
				while (backtrackingStack.Count > stack.Count)
				{
					stack.Push(node.NextSibling);
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
