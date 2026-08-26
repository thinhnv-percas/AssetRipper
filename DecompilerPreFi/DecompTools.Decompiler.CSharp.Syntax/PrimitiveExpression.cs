using System;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class PrimitiveExpression : Expression
{
	public static readonly object AnyValue = new object();

	private TextLocation startLocation;

	private string literalValue;

	private TextLocation? endLocation;

	private object value;

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation
	{
		get
		{
			if (!endLocation.HasValue)
			{
				endLocation = ((value is string) ? AdvanceLocation(StartLocation, literalValue ?? "") : new TextLocation(StartLocation.Line, checked(StartLocation.Column + (literalValue ?? "").Length)));
			}
			return endLocation.Value;
		}
	}

	public object Value
	{
		get
		{
			return value;
		}
		set
		{
			ThrowIfFrozen();
			this.value = value;
			literalValue = null;
		}
	}

	public string LiteralValue => literalValue ?? "";

	public string UnsafeLiteralValue => literalValue;

	internal void SetLocation(TextLocation startLocation, TextLocation endLocation)
	{
		ThrowIfFrozen();
		this.startLocation = startLocation;
		this.endLocation = endLocation;
	}

	public void SetValue(object value, string literalValue)
	{
		if (value == null)
		{
			throw new ArgumentNullException();
		}
		ThrowIfFrozen();
		this.value = value;
		this.literalValue = literalValue;
	}

	public PrimitiveExpression(object value)
	{
		Value = value;
		literalValue = null;
	}

	public PrimitiveExpression(object value, string literalValue)
	{
		Value = value;
		this.literalValue = literalValue;
	}

	public PrimitiveExpression(object value, TextLocation startLocation, string literalValue)
	{
		Value = value;
		this.startLocation = startLocation;
		this.literalValue = literalValue;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitPrimitiveExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitPrimitiveExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPrimitiveExpression(this, data);
	}

	private unsafe static TextLocation AdvanceLocation(TextLocation startLocation, string str)
	{
		int num = startLocation.Line;
		int num2 = startLocation.Column;
		checked
		{
			fixed (char* ptr = str)
			{
				char* p = ptr;
				char* endPtr;
				for (endPtr = unchecked((char*)checked(unchecked((nuint)ptr) + unchecked((nuint)checked(unchecked((nint)str.Length) * (nint)2)))); p < endPtr; p++)
				{
					int delimiterLength;
					unchecked
					{
						delimiterLength = NewLine.GetDelimiterLength(*p, delegate
						{
							char* ptr2 = (char*)checked(unchecked((nuint)p) + (nuint)2u);
							return (ptr2 < endPtr) ? (*ptr2) : '\0';
						});
					}
					if (delimiterLength > 0)
					{
						num++;
						num2 = 1;
						if (delimiterLength == 2)
						{
							p++;
						}
					}
					else
					{
						num2++;
					}
				}
			}
			return new TextLocation(num, num2);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is PrimitiveExpression primitiveExpression && (Value == AnyValue || object.Equals(Value, primitiveExpression.Value));
	}
}
