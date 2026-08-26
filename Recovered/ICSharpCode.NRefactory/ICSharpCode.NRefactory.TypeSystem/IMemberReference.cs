namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IMemberReference : ISymbolReference
	{
		ITypeReference DeclaringTypeReference
		{
			get;
		}

		new IMember Resolve(ITypeResolveContext context);
	}
}
