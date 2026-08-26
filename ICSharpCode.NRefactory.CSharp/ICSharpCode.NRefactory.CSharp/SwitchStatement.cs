using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class SwitchStatement : Statement
{
	public static readonly TokenRole SwitchKeywordRole = new TokenRole("switch");

	public static readonly Role<SwitchSection> SwitchSectionRole = new Role<SwitchSection>("SwitchSection");

	public CSharpTokenNode SwitchToken => GetChildByRole(SwitchKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

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

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public AstNodeCollection<SwitchSection> SwitchSections => GetChildrenByRole(SwitchSectionRole);

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	public AstNode HiddenEnd { get; set; }

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitSwitchStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitSwitchStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSwitchStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is SwitchStatement switchStatement && Expression.DoMatch(switchStatement.Expression, match))
		{
			return SwitchSections.DoMatch(switchStatement.SwitchSections, match);
		}
		return false;
	}
}
