using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class CheckedStatement : Statement
{
	public static readonly TokenRole CheckedKeywordRole = new TokenRole("checked");

	public CSharpTokenNode CheckedToken => GetChildByRole(CheckedKeywordRole);

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

	public CheckedStatement()
	{
	}

	public CheckedStatement(BlockStatement body)
	{
		AddChild(body, Roles.Body);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitCheckedStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitCheckedStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCheckedStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is CheckedStatement checkedStatement && Body.DoMatch(checkedStatement.Body, match);
	}
}
