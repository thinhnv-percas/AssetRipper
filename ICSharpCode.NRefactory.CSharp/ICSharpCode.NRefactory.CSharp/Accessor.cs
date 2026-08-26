using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class Accessor : EntityDeclaration
{
	private sealed class NullAccessor : Accessor
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public new static readonly Accessor Null = new NullAccessor();

	public override NodeType NodeType => NodeType.Unknown;

	public override SymbolKind SymbolKind => SymbolKind.Method;

	public CSharpTokenNode Keyword
	{
		get
		{
			for (AstNode astNode = base.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				if (astNode.Role == PropertyDeclaration.GetKeywordRole || astNode.Role == PropertyDeclaration.SetKeywordRole || astNode.Role == CustomEventDeclaration.AddKeywordRole || astNode.Role == CustomEventDeclaration.RemoveKeywordRole)
				{
					return (CSharpTokenNode)astNode;
				}
			}
			return CSharpTokenNode.Null;
		}
	}

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

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAccessor(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAccessor(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAccessor(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is Accessor { IsNull: false } accessor && MatchAttributesAndModifiers(accessor, match))
		{
			return Body.DoMatch(accessor.Body, match);
		}
		return false;
	}
}
