using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class FixedFieldDeclaration : EntityDeclaration
{
	public static readonly TokenRole FixedKeywordRole = new TokenRole("fixed");

	public static readonly Role<FixedVariableInitializer> VariableRole = new Role<FixedVariableInitializer>("FixedVariable");

	public override SymbolKind SymbolKind => SymbolKind.Field;

	public CSharpTokenNode FixedToken => GetChildByRole(FixedKeywordRole);

	public AstNodeCollection<FixedVariableInitializer> Variables => GetChildrenByRole(VariableRole);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitFixedFieldDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitFixedFieldDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitFixedFieldDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is FixedFieldDeclaration fixedFieldDeclaration && MatchAttributesAndModifiers(fixedFieldDeclaration, match) && ReturnType.DoMatch(fixedFieldDeclaration.ReturnType, match))
		{
			return Variables.DoMatch(fixedFieldDeclaration.Variables, match);
		}
		return false;
	}
}
