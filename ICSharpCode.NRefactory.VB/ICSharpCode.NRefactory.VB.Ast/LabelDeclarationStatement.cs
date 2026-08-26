using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class LabelDeclarationStatement : Statement
{
	public Expression Label
	{
		get
		{
			return GetChildByRole(Roles.Expression);
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public VBTokenNode Colon => GetChildByRole(Roles.Colon);

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitLabelDeclarationStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is LabelDeclarationStatement labelDeclarationStatement)
		{
			return Label.DoMatch(labelDeclarationStatement.Label, match);
		}
		return false;
	}
}
