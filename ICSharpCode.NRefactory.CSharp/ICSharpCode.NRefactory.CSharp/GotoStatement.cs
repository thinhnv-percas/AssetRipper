using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class GotoStatement : Statement
{
	public static readonly TokenRole GotoKeywordRole = new TokenRole("goto");

	public CSharpTokenNode GotoToken => GetChildByRole(GotoKeywordRole);

	public string Label
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
				return;
			}
			Identifier identifier = Identifier.Create(value);
			identifier.AddAnnotation(BoxedTextColor.Label);
			SetChildByRole(Roles.Identifier, identifier);
		}
	}

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public GotoStatement()
	{
	}

	public GotoStatement(string label)
	{
		Label = label;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitGotoStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitGotoStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitGotoStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is GotoStatement gotoStatement)
		{
			return AstNode.MatchString(Label, gotoStatement.Label);
		}
		return false;
	}
}
