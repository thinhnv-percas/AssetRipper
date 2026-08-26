namespace ICSharpCode.NRefactory.PatternMatching;

public class AnyNodeOrNull : Pattern
{
	private readonly string groupName;

	public string GroupName => groupName;

	public AnyNodeOrNull(string groupName = null)
	{
		this.groupName = groupName;
	}

	public override bool DoMatch(INode other, Match match)
	{
		if (other == null)
		{
			match.AddNull(groupName);
		}
		else
		{
			match.Add(groupName, other);
		}
		return true;
	}
}
