namespace ICSharpCode.NRefactory.PatternMatching;

public interface INode
{
	Role Role { get; }

	INode FirstChild { get; }

	INode NextSibling { get; }

	bool IsNull { get; }

	bool DoMatch(INode other, Match match);

	bool DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo);
}
