using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ConditionalExpression : Expression
{
	public static readonly Role<Expression> ConditionRole = Roles.Condition;

	public static readonly TokenRole QuestionMarkRole = new TokenRole("?");

	public static readonly Role<Expression> TrueRole = new Role<Expression>("True", Expression.Null);

	public static readonly TokenRole ColonRole = Roles.Colon;

	public static readonly Role<Expression> FalseRole = new Role<Expression>("False", Expression.Null);

	public Expression Condition
	{
		get
		{
			return GetChildByRole(ConditionRole);
		}
		set
		{
			SetChildByRole(ConditionRole, value);
		}
	}

	public CSharpTokenNode QuestionMarkToken => GetChildByRole(QuestionMarkRole);

	public Expression TrueExpression
	{
		get
		{
			return GetChildByRole(TrueRole);
		}
		set
		{
			SetChildByRole(TrueRole, value);
		}
	}

	public CSharpTokenNode ColonToken => GetChildByRole(ColonRole);

	public Expression FalseExpression
	{
		get
		{
			return GetChildByRole(FalseRole);
		}
		set
		{
			SetChildByRole(FalseRole, value);
		}
	}

	public ConditionalExpression()
	{
	}

	public ConditionalExpression(Expression condition, Expression trueExpression, Expression falseExpression)
	{
		AddChild(condition, ConditionRole);
		AddChild(trueExpression, TrueRole);
		AddChild(falseExpression, FalseRole);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitConditionalExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitConditionalExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitConditionalExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ConditionalExpression conditionalExpression && Condition.DoMatch(conditionalExpression.Condition, match) && TrueExpression.DoMatch(conditionalExpression.TrueExpression, match) && FalseExpression.DoMatch(conditionalExpression.FalseExpression, match);
	}
}
