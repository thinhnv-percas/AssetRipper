namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal class HoistedEvaluatorVariable : HoistedVariable
	{
		public HoistedEvaluatorVariable(Field field)
			: base(null, field)
		{
		}

		protected override FieldExpr GetFieldExpression(EmitContext ec)
		{
			return new FieldExpr(field, field.Location);
		}
	}
}
