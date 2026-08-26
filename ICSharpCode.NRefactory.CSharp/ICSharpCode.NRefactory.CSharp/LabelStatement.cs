using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class LabelStatement : Statement
{
	public string Label
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			Identifier identifier = Identifier.Create(value);
			identifier.AddAnnotation(BoxedTextColor.Label);
			SetChildByRole(Roles.Identifier, identifier);
		}
	}

	public Identifier LabelToken
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

	public CSharpTokenNode ColonToken => GetChildByRole(Roles.Colon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitLabelStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitLabelStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitLabelStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is LabelStatement labelStatement)
		{
			return AstNode.MatchString(Label, labelStatement.Label);
		}
		return false;
	}
}
