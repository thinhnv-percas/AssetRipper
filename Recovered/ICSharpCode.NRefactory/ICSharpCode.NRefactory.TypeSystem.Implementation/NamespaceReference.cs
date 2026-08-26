using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public sealed class NamespaceReference : ISymbolReference
	{
		private IAssemblyReference assemblyReference;

		private string fullName;

		public NamespaceReference(IAssemblyReference assemblyReference, string fullName)
		{
			if (assemblyReference == null)
			{
				throw new ArgumentNullException("assemblyReference");
			}
			this.assemblyReference = assemblyReference;
			this.fullName = fullName;
		}

		public ISymbol Resolve(ITypeResolveContext context)
		{
			INamespace @namespace = assemblyReference.Resolve(context).RootNamespace;
			string[] array = fullName.Split('.');
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
