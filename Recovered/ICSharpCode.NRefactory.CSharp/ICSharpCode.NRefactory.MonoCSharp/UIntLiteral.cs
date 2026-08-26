namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class UIntLiteral : UIntConstant, ILiteralConstant
	{
		public override bool IsLiteral => true;

		public char[] ParsedValue
		{
			get;
			set;
		}

		public UIntLiteral(BuiltinTypes types, uint l, Location loc)
			: base(types, l, loc)
		{
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}
