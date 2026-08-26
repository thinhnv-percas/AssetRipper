using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class PrimitiveType : AstType
{
	public string Keyword { get; set; }

	public TextLocation Location { get; set; }

	public override TextLocation StartLocation => Location;

	public override TextLocation EndLocation => new TextLocation(Location.Line, Location.Column + ((Keyword != null) ? Keyword.Length : 0));

	public PrimitiveType()
	{
	}

	public PrimitiveType(string keyword)
	{
		Keyword = keyword;
	}

	public PrimitiveType(string keyword, TextLocation location)
	{
		Keyword = keyword;
		Location = location;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPrimitiveType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is PrimitiveType primitiveType)
		{
			return AstNode.MatchString(Keyword, primitiveType.Keyword);
		}
		return false;
	}

	public override string ToString()
	{
		return Keyword ?? base.ToString();
	}
}
