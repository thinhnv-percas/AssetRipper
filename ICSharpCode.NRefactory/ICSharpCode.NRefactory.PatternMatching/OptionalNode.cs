using System;

namespace ICSharpCode.NRefactory.PatternMatching;

public class OptionalNode : Pattern
{
	private readonly INode childNode;

	public INode ChildNode => childNode;

	public OptionalNode(INode childNode)
	{
		if (childNode == null)
		{
			throw new ArgumentNullException("childNode");
		}
		this.childNode = childNode;
	}

	public OptionalNode(string groupName, INode childNode)
		: this(new NamedNode(groupName, childNode))
	{
	}

	public override bool DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
	{
		backtrackingInfo.backtrackingStack.Push(new PossibleMatch(pos, match.CheckPoint()));
		return childNode.DoMatch(pos, match);
	}

	public override bool DoMatch(INode other, Match match)
	{
		if (other == null || other.IsNull)
		{
			return true;
		}
		return childNode.DoMatch(other, match);
	}
}
