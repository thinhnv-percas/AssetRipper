using System;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public class NamedNode : Pattern
{
	private readonly string groupName;

	private readonly INode childNode;

	public string GroupName => groupName;

	public INode ChildNode => childNode;

	public NamedNode(string groupName, INode childNode)
	{
		if (childNode == null)
		{
			throw new ArgumentNullException("childNode");
		}
		this.groupName = groupName;
		this.childNode = childNode;
	}

	public override bool DoMatch(INode other, Match match)
	{
		match.Add(groupName, other);
		return childNode.DoMatch(other, match);
	}
}
