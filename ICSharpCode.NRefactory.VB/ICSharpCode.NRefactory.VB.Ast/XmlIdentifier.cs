using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class XmlIdentifier : AstNode
{
	private class NullXmlIdentifier : XmlIdentifier
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public new static readonly XmlIdentifier Null = new NullXmlIdentifier();

	private TextLocation startLocation;

	private TextLocation endLocation;

	public string Name { get; set; }

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => endLocation;

	private XmlIdentifier()
	{
		Name = string.Empty;
	}

	public XmlIdentifier(string name, TextLocation startLocation, TextLocation endLocation)
	{
		Name = name;
		this.startLocation = startLocation;
		this.endLocation = endLocation;
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is XmlIdentifier xmlIdentifier && AstNode.MatchStringXml(Name, xmlIdentifier.Name) && xmlIdentifier.startLocation == startLocation)
		{
			return xmlIdentifier.endLocation == endLocation;
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitXmlIdentifier(this, data);
	}
}
