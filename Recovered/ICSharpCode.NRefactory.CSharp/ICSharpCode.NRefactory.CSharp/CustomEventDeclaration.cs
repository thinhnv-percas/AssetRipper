using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CustomEventDeclaration : EntityDeclaration
	{
		public static readonly TokenRole EventKeywordRole = new TokenRole("event");

		public static readonly TokenRole AddKeywordRole = new TokenRole("add");

		public static readonly TokenRole RemoveKeywordRole = new TokenRole("remove");

		public static readonly Role<Accessor> AddAccessorRole = new Role<Accessor>("AddAccessor", Accessor.Null);

		public static readonly Role<Accessor> RemoveAccessorRole = new Role<Accessor>("RemoveAccessor", Accessor.Null);

		public override SymbolKind SymbolKind => SymbolKind.Event;

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

		public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

		public Accessor AddAccessor
		{
			get
			{
				return GetChildByRole(AddAccessorRole);
			}
			set
			{
				SetChildByRole(AddAccessorRole, value);
			}
		}

		public Accessor RemoveAccessor
		{
			get
			{
				return GetChildByRole(RemoveAccessorRole);
			}
			set
			{
				SetChildByRole(RemoveAccessorRole, value);
			}
		}

		public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitCustomEventDeclaration(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitCustomEventDeclaration(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitCustomEventDeclaration(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			CustomEventDeclaration customEventDeclaration = other as CustomEventDeclaration;
			if (customEventDeclaration != null && AstNode.MatchString(Name, customEventDeclaration.Name) && MatchAttributesAndModifiers(customEventDeclaration, match) && ReturnType.DoMatch(customEventDeclaration.ReturnType, match) && PrivateImplementationType.DoMatch(customEventDeclaration.PrivateImplementationType, match) && AddAccessor.DoMatch(customEventDeclaration.AddAccessor, match))
			{
				return RemoveAccessor.DoMatch(customEventDeclaration.RemoveAccessor, match);
			}
			return false;
		}
	}
}
