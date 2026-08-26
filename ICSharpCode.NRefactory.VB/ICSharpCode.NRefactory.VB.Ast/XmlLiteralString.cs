using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class XmlLiteralString : AstNode
{
	private class NullXmlLiteralString : XmlLiteralString
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

	public new static readonly XmlLiteralString Null = new XmlLiteralString();

	private TextLocation startLocation;

	private TextLocation endLocation;

	public string Value { get; set; }

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => endLocation;

	private XmlLiteralString()
	{
		Value = string.Empty;
	}

	public XmlLiteralString(string value, TextLocation startLocation, TextLocation endLocation)
	{
		Value = value;
		this.startLocation = startLocation;
		this.endLocation = endLocation;
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is XmlLiteralString xmlLiteralString && AstNode.MatchStringXml(Value, xmlLiteralString.Value) && xmlLiteralString.startLocation == startLocation)
		{
			return xmlLiteralString.endLocation == endLocation;
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitXmlLiteralString(this, data);
	}
}
