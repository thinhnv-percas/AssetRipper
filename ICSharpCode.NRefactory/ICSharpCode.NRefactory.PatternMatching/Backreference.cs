using System;
using System.Linq;

namespace ICSharpCode.NRefactory.PatternMatching;

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
		INode node = match.Get(referencedGroupName).Last();
		if (node == null && other == null)
		{
			return true;
		}
		return node.IsMatch(other);
	}
}
