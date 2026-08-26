using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class VBTokenNode : AstNode
{
	private class NullVBTokenNode : VBTokenNode
	{
		public override bool IsNull => true;

		public NullVBTokenNode()
			: base(TextLocation.Empty, 0)
		{
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public new static readonly VBTokenNode Null = new NullVBTokenNode();

	private TextLocation startLocation;

	protected int tokenLength = -1;

	private TextLocation endLocation;

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation
	{
		get
		{
			if (tokenLength >= 0)
			{
				return new TextLocation(startLocation.Line, startLocation.Column + tokenLength);
			}
			return endLocation;
		}
	}

	public VBTokenNode(TextLocation location, int tokenLength)
	{
		startLocation = location;
		this.tokenLength = tokenLength;
	}

	public VBTokenNode(TextLocation startLocation, TextLocation endLocation)
	{
		this.startLocation = startLocation;
		this.endLocation = endLocation;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitVBTokenNode(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is VBTokenNode vBTokenNode)
		{
			return !vBTokenNode.IsNull;
		}
		return false;
	}

	public override string ToString()
	{
		return $"[VBTokenNode: StartLocation={StartLocation}, EndLocation={EndLocation}, Role={base.Role}]";
	}
}
