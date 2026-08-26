using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.ComponentModel;

namespace ICSharpCode.NRefactory.CSharp
{
	public class IndexerDeclaration : EntityDeclaration
	{
		public static readonly TokenRole ThisKeywordRole = new TokenRole("this");

		public static readonly Role<Accessor> GetterRole = PropertyDeclaration.GetterRole;

		public static readonly Role<Accessor> SetterRole = PropertyDeclaration.SetterRole;

		public override SymbolKind SymbolKind => SymbolKind.Indexer;

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

		public override string Name
		{
			get
			{
				return "Item";
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Identifier NameToken
		{
			get
			{
				return Identifier.Null;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

		public CSharpTokenNode ThisToken => GetChildByRole(ThisKeywordRole);

		public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

		public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

		public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

		public Accessor Getter
		{
			get
			{
				return GetChildByRole(GetterRole);
			}
			set
			{
				SetChildByRole(GetterRole, value);
			}
		}

		public Accessor Setter
		{
			get
			{
				return GetChildByRole(SetterRole);
			}
			set
			{
				SetChildByRole(SetterRole, value);
			}
		}

		public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitIndexerDeclaration(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitIndexerDeclaration(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitIndexerDeclaration(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			IndexerDeclaration indexerDeclaration = other as IndexerDeclaration;
			if (indexerDeclaration != null && MatchAttributesAndModifiers(indexerDeclaration, match) && ReturnType.DoMatch(indexerDeclaration.ReturnType, match) && PrivateImplementationType.DoMatch(indexerDeclaration.PrivateImplementationType, match) && Parameters.DoMatch(indexerDeclaration.Parameters, match) && Getter.DoMatch(indexerDeclaration.Getter, match))
			{
				return Setter.DoMatch(indexerDeclaration.Setter, match);
			}
			return false;
		}
	}
}
