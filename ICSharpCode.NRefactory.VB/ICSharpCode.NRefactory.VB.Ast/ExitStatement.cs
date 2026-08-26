using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ExitStatement : Statement
{
	public static readonly Role<VBTokenNode> ExitKindTokenRole = new Role<VBTokenNode>("ExitKindToken");

	public ExitKind ExitKind { get; set; }

	public VBTokenNode ExitToken => GetChildByRole(Roles.Keyword);

	public VBTokenNode ExitKindToken => GetChildByRole(ExitKindTokenRole);

	public ExitStatement(ExitKind kind)
	{
		ExitKind = kind;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitExitStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ExitStatement exitStatement)
		{
			return ExitKind == exitStatement.ExitKind;
		}
		return false;
	}
}
