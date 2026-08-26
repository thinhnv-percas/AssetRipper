using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class GetXmlNamespaceExpression : Expression
{
	public XmlIdentifier NamespaceName
	{
		get
		{
			return GetChildByRole(Roles.XmlIdentifier);
		}
		set
		{
			SetChildByRole(Roles.XmlIdentifier, value);
		}
	}

	public GetXmlNamespaceExpression(XmlIdentifier namespaceName)
	{
		SetChildByRole(Roles.XmlIdentifier, namespaceName);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is GetXmlNamespaceExpression getXmlNamespaceExpression)
		{
			return NamespaceName.DoMatch(getXmlNamespaceExpression.NamespaceName, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitGetXmlNamespaceExpression(this, data);
	}
}
