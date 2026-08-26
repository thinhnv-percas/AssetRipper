namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface ITypeReference
	{
		IType Resolve(ITypeResolveContext context);
	}
}
