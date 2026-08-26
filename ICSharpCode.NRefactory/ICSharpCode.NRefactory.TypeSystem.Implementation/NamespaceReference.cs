using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

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
		IAssembly assembly = assemblyReference.Resolve(context);
		INamespace obj = assembly.RootNamespace;
		string[] array = fullName.Split('.');
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
