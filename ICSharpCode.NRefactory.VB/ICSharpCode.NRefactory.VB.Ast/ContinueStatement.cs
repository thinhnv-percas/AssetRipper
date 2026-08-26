using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ContinueStatement : Statement
{
	public static readonly Role<VBTokenNode> ContinueKindTokenRole = new Role<VBTokenNode>("ContinueKindToken");

	public ContinueKind ContinueKind { get; set; }

	public VBTokenNode ContinueToken => GetChildByRole(Roles.Keyword);

	public VBTokenNode ContinueKindToken => GetChildByRole(ContinueKindTokenRole);

	public ContinueStatement(ContinueKind kind)
	{
		ContinueKind = kind;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitContinueStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ContinueStatement continueStatement)
		{
			return ContinueKind == continueStatement.ContinueKind;
		}
		return false;
	}
}
