using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ErrorNode : AstNode
{
	private static TextLocation maxLoc = new TextLocation(int.MaxValue, int.MaxValue);

	public override NodeType NodeType => NodeType.Unknown;

	public override TextLocation StartLocation => maxLoc;

	public override TextLocation EndLocation => maxLoc;

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitErrorNode(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitErrorNode(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitErrorNode(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		ErrorNode errorNode = other as ErrorNode;
		return errorNode != null;
	}

	public override string ToString(CSharpFormattingOptions formattingOptions)
	{
		return "[ErrorNode]";
	}
}
