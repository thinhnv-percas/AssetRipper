using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.ComponentModel;

namespace ICSharpCode.NRefactory.CSharp
{
	public class EventDeclaration : EntityDeclaration
	{
		public static readonly TokenRole EventKeywordRole = new TokenRole("event");

		public override SymbolKind SymbolKind => SymbolKind.Event;

		public CSharpTokenNode EventToken => GetChildByRole(EventKeywordRole);

		public AstNodeCollection<VariableInitializer> Variables => GetChildrenByRole(Roles.Variable);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Name
		{
			get
			{
				return string.Empty;
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

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitEventDeclaration(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitEventDeclaration(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitEventDeclaration(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			EventDeclaration eventDeclaration = other as EventDeclaration;
			if (eventDeclaration != null && MatchAttributesAndModifiers(eventDeclaration, match) && ReturnType.DoMatch(eventDeclaration.ReturnType, match))
			{
				return Variables.DoMatch(eventDeclaration.Variables, match);
			}
			return false;
		}
	}
}
