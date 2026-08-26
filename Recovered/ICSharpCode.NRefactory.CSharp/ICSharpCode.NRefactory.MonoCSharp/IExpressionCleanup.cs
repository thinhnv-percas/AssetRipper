namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IExpressionCleanup
	{
		void EmitCleanup(EmitContext ec);
	}
}
