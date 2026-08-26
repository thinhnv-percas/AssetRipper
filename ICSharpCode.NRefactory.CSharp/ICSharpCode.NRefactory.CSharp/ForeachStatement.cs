using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ForeachStatement : Statement
{
	public static readonly TokenRole ForeachKeywordRole = new TokenRole("foreach");

	public static readonly TokenRole InKeywordRole = new TokenRole("in");

	public CSharpTokenNode ForeachToken => GetChildByRole(ForeachKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstType VariableType
	{
		get
		{
			return GetChildByRole(Roles.Type);
		}
		set
		{
			SetChildByRole(Roles.Type, value);
		}
	}

	public string VariableName
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
		}
	}

	public Identifier VariableNameToken
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

	public CSharpTokenNode InToken => GetChildByRole(InKeywordRole);

	public Expression InExpression
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

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public Statement EmbeddedStatement
	{
		get
		{
			return GetChildByRole(Roles.EmbeddedStatement);
		}
		set
		{
			SetChildByRole(Roles.EmbeddedStatement, value);
		}
	}

	public AstNode HiddenInitializer { get; set; }

	public AstNode HiddenGetEnumeratorNode { get; set; }

	public AstNode HiddenMoveNextNode { get; set; }

	public AstNode HiddenGetCurrentNode { get; set; }

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitForeachStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitForeachStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitForeachStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ForeachStatement foreachStatement && VariableType.DoMatch(foreachStatement.VariableType, match) && AstNode.MatchString(VariableName, foreachStatement.VariableName) && InExpression.DoMatch(foreachStatement.InExpression, match))
		{
			return EmbeddedStatement.DoMatch(foreachStatement.EmbeddedStatement, match);
		}
		return false;
	}
}
