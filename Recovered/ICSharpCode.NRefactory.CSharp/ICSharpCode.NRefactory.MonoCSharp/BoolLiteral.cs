namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class BoolLiteral : BoolConstant, ILiteralConstant
	{
		public override bool IsLiteral => true;

		public char[] ParsedValue
		{
			get;
			set;
		}

		public BoolLiteral(BuiltinTypes types, bool val, Location loc)
			: base(types, val, loc)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
