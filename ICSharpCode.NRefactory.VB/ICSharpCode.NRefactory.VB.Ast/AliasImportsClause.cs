using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class AliasImportsClause : ImportsClause
{
	public Identifier Name
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

	public AstType Alias
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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is AliasImportsClause aliasImportsClause && Name.DoMatch(aliasImportsClause.Name, match))
		{
			return Alias.DoMatch(aliasImportsClause.Alias, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAliasImportsClause(this, data);
	}

	public override string ToString()
	{
		return $"[AliasImportsClause Name={Name} Alias={Alias}]";
	}
}
