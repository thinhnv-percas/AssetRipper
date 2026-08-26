using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class PrimitiveExpression : Expression
{
	public static readonly object AnyValue = new object();

	private TextLocation startLocation;

	private int length;

	private string stringValue;

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => new TextLocation(StartLocation.Line, StartLocation.Column + length);

	public object Value { get; private set; }

	public string StringValue => stringValue ?? OutputVisitor.ToVBNetString(this);

	public PrimitiveExpression(object value)
	{
		Value = value;
	}

	public PrimitiveExpression(object value, string stringValue)
	{
		Value = value;
		this.stringValue = stringValue;
	}

	public PrimitiveExpression(object value, TextLocation startLocation, int length)
	{
		Value = value;
		this.startLocation = startLocation;
		this.length = length;
	}

	public PrimitiveExpression(object value, string stringValue, TextLocation startLocation, int length)
	{
		Value = value;
		this.stringValue = stringValue;
		this.startLocation = startLocation;
		this.length = length;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPrimitiveExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is PrimitiveExpression primitiveExpression)
		{
			if (Value != AnyValue)
			{
				return object.Equals(Value, primitiveExpression.Value);
			}
			return true;
		}
		return false;
	}
}
