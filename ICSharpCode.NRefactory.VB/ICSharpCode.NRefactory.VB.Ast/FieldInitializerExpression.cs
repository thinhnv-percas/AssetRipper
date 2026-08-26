using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class FieldInitializerExpression : Expression
{
	public bool IsKey { get; set; }

	public VBTokenNode KeyToken => GetChildByRole(Roles.Keyword);

	public VBTokenNode DotToken => GetChildByRole(Roles.Dot);

	public Identifier Identifier
	{
		get
		{
			return GetChildByRole(Roles.Identifier);
		}
		set
		{
			SetChildByRole(Roles.Identifier, value);
		}
	}

	public VBTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression Expression
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

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitFieldInitializerExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is FieldInitializerExpression fieldInitializerExpression && IsKey == fieldInitializerExpression.IsKey && Identifier.DoMatch(fieldInitializerExpression.Identifier, match))
		{
			return Expression.DoMatch(fieldInitializerExpression.Expression, match);
		}
		return false;
	}
}
