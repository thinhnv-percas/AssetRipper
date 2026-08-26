namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class DecimalLiteral : DecimalConstant, ILiteralConstant
	{
		public override bool IsLiteral => true;

		public char[] ParsedValue
		{
			get;
			set;
		}

		public DecimalLiteral(BuiltinTypes types, decimal d, Location loc)
			: base(types, d, loc)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
