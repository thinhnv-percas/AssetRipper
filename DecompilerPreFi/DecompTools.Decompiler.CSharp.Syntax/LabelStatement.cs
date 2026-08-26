using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

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
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
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
		return other is LabelStatement labelStatement && AstNode.MatchString(Label, labelStatement.Label);
	}
}
