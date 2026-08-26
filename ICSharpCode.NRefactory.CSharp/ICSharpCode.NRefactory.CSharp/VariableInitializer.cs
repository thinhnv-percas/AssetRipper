using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class VariableInitializer : AstNode
{
	private sealed class NullVariableInitializer : VariableInitializer
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

	private sealed class PatternPlaceholder : VariableInitializer, INode
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

	public static readonly Role<CSharpModifierToken> ModifierRole = EntityDeclaration.ModifierRole;

	public new static readonly VariableInitializer Null = new NullVariableInitializer();

	public override NodeType NodeType => NodeType.Unknown;

	public Modifiers Modifiers
	{
		get
		{
			return EntityDeclaration.GetModifiers(this);
		}
		set
		{
			EntityDeclaration.SetModifiers(this, value);
		}
	}

	public string Name
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

	public Identifier NameToken
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

	public CSharpTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression Initializer
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

	public static implicit operator VariableInitializer(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public VariableInitializer()
	{
	}

	public VariableInitializer(object nameAnnotation, string name, Expression initializer = null)
	{
		NameToken = Identifier.Create(name);
		if (nameAnnotation != null)
		{
			NameToken.AddAnnotation(nameAnnotation);
		}
		Initializer = initializer;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitVariableInitializer(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitVariableInitializer(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitVariableInitializer(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is VariableInitializer variableInitializer && AstNode.MatchString(Name, variableInitializer.Name))
		{
			return Initializer.DoMatch(variableInitializer.Initializer, match);
		}
		return false;
	}
}
