using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class QueryJoinClause : QueryClause
{
	public static readonly TokenRole JoinKeywordRole = new TokenRole("join");

	public static readonly Role<AstType> TypeRole = Roles.Type;

	public static readonly Role<Identifier> JoinIdentifierRole = Roles.Identifier;

	public static readonly TokenRole InKeywordRole = new TokenRole("in");

	public static readonly Role<Expression> InExpressionRole = Roles.Expression;

	public static readonly TokenRole OnKeywordRole = new TokenRole("on");

	public static readonly Role<Expression> OnExpressionRole = new Role<Expression>("OnExpression", Expression.Null);

	public static readonly TokenRole EqualsKeywordRole = new TokenRole("equals");

	public static readonly Role<Expression> EqualsExpressionRole = new Role<Expression>("EqualsExpression", Expression.Null);

	public static readonly TokenRole IntoKeywordRole = new TokenRole("into");

	public static readonly Role<Identifier> IntoIdentifierRole = new Role<Identifier>("IntoIdentifier", Identifier.Null);

	public bool IsGroupJoin => !string.IsNullOrEmpty(IntoIdentifier);

	public CSharpTokenNode JoinKeyword => GetChildByRole(JoinKeywordRole);

	public AstType Type
	{
		get
		{
			return GetChildByRole(TypeRole);
		}
		set
		{
			SetChildByRole(TypeRole, value);
		}
	}

	public string JoinIdentifier
	{
		get
		{
			return GetChildByRole(JoinIdentifierRole).Name;
		}
		set
		{
			SetChildByRole(JoinIdentifierRole, Identifier.Create(value));
		}
	}

	public Identifier JoinIdentifierToken
	{
		get
		{
			return GetChildByRole(JoinIdentifierRole);
		}
		set
		{
			SetChildByRole(JoinIdentifierRole, value);
		}
	}

	public CSharpTokenNode InKeyword => GetChildByRole(InKeywordRole);

	public Expression InExpression
	{
		get
		{
			return GetChildByRole(InExpressionRole);
		}
		set
		{
			SetChildByRole(InExpressionRole, value);
		}
	}

	public CSharpTokenNode OnKeyword => GetChildByRole(OnKeywordRole);

	public Expression OnExpression
	{
		get
		{
			return GetChildByRole(OnExpressionRole);
		}
		set
		{
			SetChildByRole(OnExpressionRole, value);
		}
	}

	public CSharpTokenNode EqualsKeyword => GetChildByRole(EqualsKeywordRole);

	public Expression EqualsExpression
	{
		get
		{
			return GetChildByRole(EqualsExpressionRole);
		}
		set
		{
			SetChildByRole(EqualsExpressionRole, value);
		}
	}

	public CSharpTokenNode IntoKeyword => GetChildByRole(IntoKeywordRole);

	public string IntoIdentifier
	{
		get
		{
			return GetChildByRole(IntoIdentifierRole).Name;
		}
		set
		{
			SetChildByRole(IntoIdentifierRole, Identifier.Create(value));
		}
	}

	public Identifier IntoIdentifierToken
	{
		get
		{
			return GetChildByRole(IntoIdentifierRole);
		}
		set
		{
			SetChildByRole(IntoIdentifierRole, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryJoinClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryJoinClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryJoinClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is QueryJoinClause queryJoinClause && IsGroupJoin == queryJoinClause.IsGroupJoin && Type.DoMatch(queryJoinClause.Type, match) && AstNode.MatchString(JoinIdentifier, queryJoinClause.JoinIdentifier) && InExpression.DoMatch(queryJoinClause.InExpression, match) && OnExpression.DoMatch(queryJoinClause.OnExpression, match) && EqualsExpression.DoMatch(queryJoinClause.EqualsExpression, match))
		{
			return AstNode.MatchString(IntoIdentifier, queryJoinClause.IntoIdentifier);
		}
		return false;
	}
}
