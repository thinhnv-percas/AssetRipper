using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp
{
	public class DelegateDeclaration : EntityDeclaration
	{
		public override NodeType NodeType => NodeType.TypeDeclaration;

		public override SymbolKind SymbolKind => SymbolKind.TypeDefinition;

		public CSharpTokenNode DelegateToken => GetChildByRole(Roles.DelegateKeyword);

		public AstNodeCollection<TypeParameterDeclaration> TypeParameters => GetChildrenByRole(Roles.TypeParameter);

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public AstNodeCollection<Constraint> Constraints => GetChildrenByRole(Roles.Constraint);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitDelegateDeclaration(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitDelegateDeclaration(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitDelegateDeclaration(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			DelegateDeclaration delegateDeclaration = other as DelegateDeclaration;
			if (delegateDeclaration != null && AstNode.MatchString(Name, delegateDeclaration.Name) && MatchAttributesAndModifiers(delegateDeclaration, match) && ReturnType.DoMatch(delegateDeclaration.ReturnType, match) && TypeParameters.DoMatch(delegateDeclaration.TypeParameters, match) && Parameters.DoMatch(delegateDeclaration.Parameters, match))
			{
				return Constraints.DoMatch(delegateDeclaration.Constraints, match);
			}
			return false;
		}
	}
}
