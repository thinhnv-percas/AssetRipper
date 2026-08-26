#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public class Repeat : Pattern
{
	private readonly INode childNode;

	public int MinCount { get; set; }

	public int MaxCount { get; set; }

	public INode ChildNode => childNode;

	public Repeat(INode childNode)
	{
		if (childNode == null)
		{
			throw new ArgumentNullException("childNode");
		}
		this.childNode = childNode;
		MinCount = 0;
		MaxCount = int.MaxValue;
	}

	public override bool DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
	{
		Stack<PossibleMatch> backtrackingStack = backtrackingInfo.backtrackingStack;
		Debug.Assert(pos == null || pos.Role == role);
		int num = 0;
		if (MinCount <= 0)
		{
			backtrackingStack.Push(new PossibleMatch(pos, match.CheckPoint()));
		}
		while (num < MaxCount && pos != null && childNode.DoMatch(pos, match))
		{
			num = checked(num + 1);
			do
			{
				pos = pos.NextSibling;
			}
			while (pos != null && pos.Role != role);
			if (num >= MinCount)
			{
				backtrackingStack.Push(new PossibleMatch(pos, match.CheckPoint()));
			}
		}
		return false;
	}

	public override bool DoMatch(INode other, Match match)
	{
		if (other == null || other.IsNull)
		{
			return MinCount <= 0;
		}
		return MaxCount >= 1 && childNode.DoMatch(other, match);
	}
}
