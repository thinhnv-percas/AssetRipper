namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface ILocalVariable
	{
		void Emit(EmitContext ec);

		void EmitAssign(EmitContext ec);

		void EmitAddressOf(EmitContext ec);
	}
}
