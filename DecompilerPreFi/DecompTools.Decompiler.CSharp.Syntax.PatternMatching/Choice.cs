using System;
using System.Collections;
using System.Collections.Generic;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public class Choice : Pattern, IEnumerable<INode>, IEnumerable
{
	private readonly List<INode> alternatives = new List<INode>();

	public void Add(string name, INode alternative)
	{
		if (alternative == null)
		{
			throw new ArgumentNullException("alternative");
		}
		alternatives.Add(new NamedNode(name, alternative));
	}

	public void Add(INode alternative)
	{
		if (alternative == null)
		{
			throw new ArgumentNullException("alternative");
		}
		alternatives.Add(alternative);
	}

	public override bool DoMatch(INode other, Match match)
	{
		int checkPoint = match.CheckPoint();
		foreach (INode alternative in alternatives)
		{
			if (alternative.DoMatch(other, match))
			{
				return true;
			}
			match.RestoreCheckPoint(checkPoint);
		}
		return false;
	}

	IEnumerator<INode> IEnumerable<INode>.GetEnumerator()
	{
		return alternatives.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return alternatives.GetEnumerator();
	}
}
