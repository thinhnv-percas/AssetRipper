using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class CatchClause : AstNode
{
	private sealed class NullCatchClause : CatchClause
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	private sealed class PatternPlaceholder : CatchClause, INode
	{
		private readonly Pattern child;

		public override NodeType NodeType => NodeType.Pattern;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitPatternPlaceholder(this, child);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitPatternPlaceholder(this, child);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPatternPlaceholder(this, child, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return child.DoMatch(other, match);
		}

		bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
		{
			return child.DoMatchCollection(role, pos, match, backtrackingInfo);
		}
	}

	public static readonly TokenRole CatchKeywordRole = new TokenRole("catch");

	public static readonly TokenRole WhenKeywordRole = new TokenRole("when");

	public static readonly Role<Expression> ConditionRole = Roles.Condition;

	public new static readonly CatchClause Null = new NullCatchClause();

	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode CatchToken => GetChildByRole(CatchKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstType Type
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
			if (string.IsNullOrEmpty(value))
			{
				SetChildByRole(Roles.Identifier, null);
			}
			else
			{
				SetChildByRole(Roles.Identifier, Identifier.Create(value));
			}
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

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public CSharpTokenNode WhenToken => GetChildByRole(WhenKeywordRole);

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

	public static implicit operator CatchClause(Pattern pattern)
	{
		return (pattern != null) ? new PatternPlaceholder(pattern) : null;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitCatchClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitCatchClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCatchClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is CatchClause catchClause && Type.DoMatch(catchClause.Type, match) && AstNode.MatchString(VariableName, catchClause.VariableName) && Body.DoMatch(catchClause.Body, match);
	}
}
