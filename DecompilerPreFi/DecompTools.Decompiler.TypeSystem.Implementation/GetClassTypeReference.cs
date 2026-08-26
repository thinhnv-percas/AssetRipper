using System;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

[Serializable]
public sealed class GetClassTypeReference : ITypeReference, ISupportsInterning
{
	private readonly IModuleReference module;

	private readonly FullTypeName fullTypeName;

	private readonly bool? isReferenceType;

	public IModuleReference Module => module;

	public FullTypeName FullTypeName => fullTypeName;

	public GetClassTypeReference(FullTypeName fullTypeName, IModuleReference module = null, bool? isReferenceType = null)
	{
		this.fullTypeName = fullTypeName;
		this.module = module;
		this.isReferenceType = isReferenceType;
	}

	public GetClassTypeReference(string namespaceName, string name, int typeParameterCount = 0, bool? isReferenceType = null)
	{
		fullTypeName = new TopLevelTypeName(namespaceName, name, typeParameterCount);
		this.isReferenceType = isReferenceType;
	}

	public GetClassTypeReference(IModuleReference module, string namespaceName, string name, int typeParameterCount = 0, bool? isReferenceType = null)
	{
		this.module = module;
		fullTypeName = new TopLevelTypeName(namespaceName, name, typeParameterCount);
		this.isReferenceType = isReferenceType;
	}

	private IType ResolveInAllAssemblies(ITypeResolveContext context)
	{
		ICompilation compilation = context.Compilation;
		foreach (IModule module in compilation.Modules)
		{
			IType typeDefinition = module.GetTypeDefinition(fullTypeName);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
		}
		return null;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		IType type = null;
		if (this.module == null)
		{
			if (context.CurrentModule != null)
			{
				type = context.CurrentModule.GetTypeDefinition(fullTypeName);
			}
			if (type == null)
			{
				type = ResolveInAllAssemblies(context);
			}
		}
		else
		{
			IModule module = this.module.Resolve(context);
			type = ((module == null) ? ResolveInAllAssemblies(context) : module.GetTypeDefinition(fullTypeName));
		}
		return type ?? new UnknownType(fullTypeName, isReferenceType);
	}

	public override string ToString()
	{
		return fullTypeName.ToString() + ((module != null) ? (", " + module.ToString()) : null);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return 33 * module.GetHashCode() + fullTypeName.GetHashCode();
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is GetClassTypeReference getClassTypeReference && module == getClassTypeReference.module && fullTypeName == getClassTypeReference.fullTypeName && isReferenceType == getClassTypeReference.isReferenceType;
	}
}
