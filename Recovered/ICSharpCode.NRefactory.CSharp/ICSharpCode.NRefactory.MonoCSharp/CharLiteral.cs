namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class CharLiteral : CharConstant, ILiteralConstant
	{
		public override bool IsLiteral => true;

		public char[] ParsedValue
		{
			get;
			set;
		}

		public CharLiteral(BuiltinTypes types, char c, Location loc)
			: base(types, c, loc)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
