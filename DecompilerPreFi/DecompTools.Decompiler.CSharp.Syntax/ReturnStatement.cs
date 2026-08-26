using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ReturnStatement : Statement
{
	public static readonly TokenRole ReturnKeywordRole = new TokenRole("return");

	public CSharpTokenNode ReturnToken => GetChildByRole(ReturnKeywordRole);

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

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public ReturnStatement()
	{
	}

	public ReturnStatement(Expression returnExpression)
	{
		AddChild(returnExpression, Roles.Expression);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitReturnStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitReturnStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitReturnStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ReturnStatement returnStatement && Expression.DoMatch(returnStatement.Expression, match);
	}
}
