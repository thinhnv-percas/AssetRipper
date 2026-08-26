namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class StringLiteral : StringConstant, ILiteralConstant
	{
		public override bool IsLiteral => true;

		public char[] ParsedValue
		{
			get;
			set;
		}

		public StringLiteral(BuiltinTypes types, string s, Location loc)
			: base(types, s, loc)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
