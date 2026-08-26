namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class LongLiteral : LongConstant, ILiteralConstant
	{
		public override bool IsLiteral => true;

		public char[] ParsedValue
		{
			get;
			set;
		}

		public LongLiteral(BuiltinTypes types, long l, Location loc)
			: base(types, l, loc)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
