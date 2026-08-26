namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IMemoryLocation
	{
		void AddressOf(EmitContext ec, AddressOp mode);
	}
}
