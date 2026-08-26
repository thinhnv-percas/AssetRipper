namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
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
			INamespace @namespace = context.Compilation.GetNamespaceForExternAlias(externAlias);
			for (int i = 0; i < array.Length; i++)
			{
				if (@namespace == null)
				{
					break;
				}
				@namespace = @namespace.GetChildNamespace(array[i]);
			}
			return @namespace;
		}
	}
}
