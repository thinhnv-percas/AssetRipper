namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IAssemblyReference
	{
		IAssembly Resolve(ITypeResolveContext context);
	}
}
