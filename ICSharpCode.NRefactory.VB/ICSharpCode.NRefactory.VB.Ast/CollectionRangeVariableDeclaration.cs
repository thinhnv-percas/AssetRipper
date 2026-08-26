using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class CollectionRangeVariableDeclaration : AstNode
{
	public static readonly Role<CollectionRangeVariableDeclaration> CollectionRangeVariableDeclarationRole = new Role<CollectionRangeVariableDeclaration>("CollectionRangeVariableDeclaration");

	public VariableIdentifier Identifier
	{
		get
		{
			return GetChildByRole(VariableIdentifier.VariableIdentifierRole);
		}
		set
		{
			SetChildByRole(VariableIdentifier.VariableIdentifierRole, value);
		}
	}

	public AstType Type
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

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCollectionRangeVariableDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is CollectionRangeVariableDeclaration collectionRangeVariableDeclaration && Identifier.DoMatch(collectionRangeVariableDeclaration.Identifier, match) && Type.DoMatch(collectionRangeVariableDeclaration.Type, match))
		{
			return Expression.DoMatch(collectionRangeVariableDeclaration.Expression, match);
		}
		return false;
	}
}
