using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class LambdaExpression : Expression
{
	public static readonly TokenRole AsyncModifierRole = new TokenRole("async");

	public static readonly TokenRole ArrowRole = new TokenRole("=>");

	public static readonly Role<AstNode> BodyRole = new Role<AstNode>("Body", AstNode.Null);

	private bool isAsync;

	public bool IsAsync
	{
		get
		{
			return isAsync;
		}
		set
		{
			ThrowIfFrozen();
			isAsync = value;
		}
	}

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public CSharpTokenNode ArrowToken => GetChildByRole(ArrowRole);

	public AstNode Body
	{
		get
		{
			return GetChildByRole(BodyRole);
		}
		set
		{
			SetChildByRole(BodyRole, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitLambdaExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitLambdaExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitLambdaExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is LambdaExpression lambdaExpression && IsAsync == lambdaExpression.IsAsync && Parameters.DoMatch(lambdaExpression.Parameters, match))
		{
			return Body.DoMatch(lambdaExpression.Body, match);
		}
		return false;
	}
}
