namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal sealed class EmptyAwaitExpression : EmptyExpression
	{
		public EmptyAwaitExpression(TypeSpec type)
			: base(type)
		{
		}

		public override bool ContainsEmitWithAwait()
		{
			return true;
		}
	}
}
