namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public sealed class MergedNamespaceReference : ISymbolReference
{
	private string externAlias;

	private string fullName;

	public MergedNamespaceReference(string externAlias, string fullName)
	{
		this.externAlias = externAlias;
		this.fullName = fullName;
	}

	public ISymbol Resolve(ITypeResolveContext context)
	{
		string[] array = fullName.Split('.');
		INamespace obj = context.Compilation.GetNamespaceForExternAlias(externAlias);
		for (int i = 0; i < array.Length; i++)
		{
			if (obj == null)
			{
				break;
			}
			obj = obj.GetChildNamespace(array[i]);
		}
		return obj;
	}
}
