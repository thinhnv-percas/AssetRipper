using ICSharpCode.NRefactory.PatternMatching;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
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
					endLocation = ((value is string) ? AdvanceLocation(StartLocation, literalValue ?? "") : new TextLocation(StartLocation.Line, StartLocation.Column + (literalValue ?? "").Length));
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

		internal void SetStartLocation(TextLocation value)
		{
			ThrowIfFrozen();
			startLocation = value;
			endLocation = null;
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
			fixed (char* ptr = str)
			{
				char* p = ptr;
				char* endPtr = ptr + str.Length;
				while (p < endPtr)
				{
					int delimiterLength = NewLine.GetDelimiterLength(*p, delegate
					{
						char* ptr3 = p + 1;
						return (ptr3 < endPtr) ? (*ptr3) : '\0';
					});
					char* ptr2;
					if (delimiterLength > 0)
					{
						num++;
						num2 = 1;
						if (delimiterLength == 2)
						{
							ptr2 = p;
							p = ptr2 + 1;
						}
					}
					else
					{
						num2++;
					}
					ptr2 = p;
					p = ptr2 + 1;
				}
			}
			return new TextLocation(num, num2);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			PrimitiveExpression primitiveExpression = other as PrimitiveExpression;
			if (primitiveExpression != null)
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
}
