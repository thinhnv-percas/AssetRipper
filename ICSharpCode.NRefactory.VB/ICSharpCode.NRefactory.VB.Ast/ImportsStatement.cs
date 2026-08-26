using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ImportsStatement : AstNode
{
	public static readonly Role<ImportsClause> ImportsClauseRole = new Role<ImportsClause>("ImportsClause", ImportsClause.Null);

	public VBTokenNode Imports => GetChildByRole(Roles.Keyword);

	public AstNodeCollection<ImportsClause> ImportsClauses => GetChildrenByRole(ImportsClauseRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ImportsStatement importsStatement)
		{
			return importsStatement.ImportsClauses.DoMatch(ImportsClauses, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitImportsStatement(this, data);
	}
}
