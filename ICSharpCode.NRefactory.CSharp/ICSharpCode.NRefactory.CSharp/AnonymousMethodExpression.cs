using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class AnonymousMethodExpression : Expression
{
	public static readonly TokenRole DelegateKeywordRole = new TokenRole("delegate");

	public static readonly TokenRole AsyncModifierRole = LambdaExpression.AsyncModifierRole;

	private bool isAsync;

	private bool hasParameterList;

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

	public bool HasParameterList
	{
		get
		{
			if (!hasParameterList)
			{
				return Parameters.Any();
			}
			return true;
		}
		set
		{
			ThrowIfFrozen();
			hasParameterList = value;
		}
	}

	public CSharpTokenNode DelegateToken => GetChildByRole(DelegateKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public BlockStatement Body
	{
		get
		{
			return GetChildByRole(Roles.Body);
		}
		set
		{
			SetChildByRole(Roles.Body, value);
		}
	}

	public AnonymousMethodExpression()
	{
	}

	public AnonymousMethodExpression(BlockStatement body, IEnumerable<ParameterDeclaration> parameters = null)
	{
		if (parameters != null)
		{
			hasParameterList = true;
			foreach (ParameterDeclaration parameter in parameters)
			{
				AddChild(parameter, Roles.Parameter);
			}
		}
		AddChild(body, Roles.Body);
	}

	public AnonymousMethodExpression(BlockStatement body, params ParameterDeclaration[] parameters)
		: this(body, (IEnumerable<ParameterDeclaration>)parameters)
	{
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAnonymousMethodExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAnonymousMethodExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAnonymousMethodExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is AnonymousMethodExpression anonymousMethodExpression && IsAsync == anonymousMethodExpression.IsAsync && HasParameterList == anonymousMethodExpression.HasParameterList && Parameters.DoMatch(anonymousMethodExpression.Parameters, match))
		{
			return Body.DoMatch(anonymousMethodExpression.Body, match);
		}
		return false;
	}
}
