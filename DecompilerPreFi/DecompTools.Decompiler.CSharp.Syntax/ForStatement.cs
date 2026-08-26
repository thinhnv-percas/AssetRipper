using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ForStatement : Statement
{
	public static readonly TokenRole ForKeywordRole = new TokenRole("for");

	public static readonly Role<Statement> InitializerRole = new Role<Statement>("Initializer", Statement.Null);

	public static readonly Role<Statement> IteratorRole = new Role<Statement>("Iterator", Statement.Null);

	public CSharpTokenNode ForToken => GetChildByRole(ForKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<Statement> Initializers => GetChildrenByRole(InitializerRole);

	public Expression Condition
	{
		get
		{
			return GetChildByRole(Roles.Condition);
		}
		set
		{
			SetChildByRole(Roles.Condition, value);
		}
	}

	public AstNodeCollection<Statement> Iterators => GetChildrenByRole(IteratorRole);

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

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitForStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitForStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitForStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ForStatement forStatement && Initializers.DoMatch(forStatement.Initializers, match) && Condition.DoMatch(forStatement.Condition, match) && Iterators.DoMatch(forStatement.Iterators, match) && EmbeddedStatement.DoMatch(forStatement.EmbeddedStatement, match);
	}
}
