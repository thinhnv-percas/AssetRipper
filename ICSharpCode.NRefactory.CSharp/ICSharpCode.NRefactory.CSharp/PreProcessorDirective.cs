using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class PreProcessorDirective : AstNode
{
	private TextLocation startLocation;

	private TextLocation endLocation;

	public override NodeType NodeType => NodeType.Whitespace;

	public PreProcessorDirectiveType Type { get; set; }

	public string Argument { get; set; }

	public bool Take { get; set; }

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => endLocation;

	public PreProcessorDirective(PreProcessorDirectiveType type, TextLocation startLocation, TextLocation endLocation)
	{
		Type = type;
		this.startLocation = startLocation;
		this.endLocation = endLocation;
	}

	public PreProcessorDirective(PreProcessorDirectiveType type, string argument = null)
	{
		Type = type;
		Argument = argument;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitPreProcessorDirective(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitPreProcessorDirective(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPreProcessorDirective(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is PreProcessorDirective preProcessorDirective && Type == preProcessorDirective.Type)
		{
			return AstNode.MatchString(Argument, preProcessorDirective.Argument);
		}
		return false;
	}
}
