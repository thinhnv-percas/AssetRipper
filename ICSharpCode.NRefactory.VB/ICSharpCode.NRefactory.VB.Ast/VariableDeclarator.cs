namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class VariableDeclarator : AstNode
{
	public static readonly Role<VariableDeclarator> VariableDeclaratorRole = new Role<VariableDeclarator>("VariableDeclarator");

	public AstNodeCollection<VariableIdentifier> Identifiers => GetChildrenByRole(VariableIdentifier.VariableIdentifierRole);
}
