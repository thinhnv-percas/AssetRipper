namespace ICSharpCode.NRefactory.PatternMatching
{
	public class AnyNode : Pattern
	{
		private readonly string groupName;

		public string GroupName => groupName;

		public AnyNode(string groupName = null)
		{
			this.groupName = groupName;
		}

		public override bool DoMatch(INode other, Match match)
		{
			match.Add(groupName, other);
			if (other != null)
			{
				return !other.IsNull;
			}
			return false;
		}
	}
}
