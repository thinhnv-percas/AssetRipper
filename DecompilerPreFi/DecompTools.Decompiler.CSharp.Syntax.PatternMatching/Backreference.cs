using System;
using System.Linq;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public class Backreference : Pattern
{
	private readonly string referencedGroupName;

	public string ReferencedGroupName => referencedGroupName;

	public Backreference(string referencedGroupName)
	{
		if (referencedGroupName == null)
		{
			throw new ArgumentNullException("referencedGroupName");
		}
		this.referencedGroupName = referencedGroupName;
	}

	public override bool DoMatch(INode other, Match match)
	{
		INode node = Enumerable.LastOrDefault<INode>(match.Get(referencedGroupName));
		if (node == null && other == null)
		{
			return true;
		}
		return node.IsMatch(other);
	}
}
