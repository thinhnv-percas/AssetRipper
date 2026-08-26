using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp
{
	public class MethodDeclaration : EntityDeclaration
	{
		public override SymbolKind SymbolKind => SymbolKind.Method;

		public AstType PrivateImplementationType
		{
			get
			{
				return GetChildByRole(EntityDeclaration.PrivateImplementationTypeRole);
			}
			set
			{
				SetChildByRole(EntityDeclaration.PrivateImplementationTypeRole, value);
			}
		}

		public AstNodeCollection<TypeParameterDeclaration> TypeParameters => GetChildrenByRole(Roles.TypeParameter);

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public AstNodeCollection<Constraint> Constraints => GetChildrenByRole(Roles.Constraint);

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

		public bool IsExtensionMethod
		{
			get
			{
				ParameterDeclaration childByRole = GetChildByRole(Roles.Parameter);
				if (childByRole != null)
				{
					return childByRole.ParameterModifier == ParameterModifier.This;
				}
				return false;
			}
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitMethodDeclaration(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitMethodDeclaration(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitMethodDeclaration(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			MethodDeclaration methodDeclaration = other as MethodDeclaration;
			if (methodDeclaration != null && AstNode.MatchString(Name, methodDeclaration.Name) && MatchAttributesAndModifiers(methodDeclaration, match) && ReturnType.DoMatch(methodDeclaration.ReturnType, match) && PrivateImplementationType.DoMatch(methodDeclaration.PrivateImplementationType, match) && TypeParameters.DoMatch(methodDeclaration.TypeParameters, match) && Parameters.DoMatch(methodDeclaration.Parameters, match) && Constraints.DoMatch(methodDeclaration.Constraints, match))
			{
				return Body.DoMatch(methodDeclaration.Body, match);
			}
			return false;
		}
	}
}
