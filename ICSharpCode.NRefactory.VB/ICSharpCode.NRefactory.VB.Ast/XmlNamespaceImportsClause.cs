using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class XmlNamespaceImportsClause : ImportsClause
{
	public XmlIdentifier Prefix
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

	public XmlLiteralString Namespace
	{
		get
		{
			return GetChildByRole(Roles.XmlLiteralString);
		}
		set
		{
			SetChildByRole(Roles.XmlLiteralString, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is XmlNamespaceImportsClause xmlNamespaceImportsClause && Namespace.DoMatch(xmlNamespaceImportsClause.Namespace, match))
		{
			return Prefix.DoMatch(xmlNamespaceImportsClause.Prefix, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitXmlNamespaceImportsClause(this, data);
	}

	public override string ToString()
	{
		return $"[XmlNamespaceImportsClause Prefix={Prefix}, Namespace={Namespace}]";
	}
}
