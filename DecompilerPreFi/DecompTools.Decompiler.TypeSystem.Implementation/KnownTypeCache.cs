using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class KnownTypeCache
{
	private readonly ICompilation compilation;

	private readonly IType[] knownTypes = new IType[52];

	public KnownTypeCache(ICompilation compilation)
	{
		this.compilation = compilation;
	}

	public IType FindType(KnownTypeCode typeCode)
	{
		IType type = LazyInit.VolatileRead(ref knownTypes[(int)typeCode]);
		if (type != null)
		{
			return type;
		}
		return LazyInit.GetOrSet(ref knownTypes[(int)typeCode], SearchType(typeCode));
	}

	private IType SearchType(KnownTypeCode typeCode)
	{
		KnownTypeReference knownTypeReference = KnownTypeReference.Get(typeCode);
		if (knownTypeReference == null)
		{
			return SpecialType.UnknownType;
		}
		TopLevelTypeName topLevelTypeName = new TopLevelTypeName(knownTypeReference.Namespace, knownTypeReference.Name, knownTypeReference.TypeParameterCount);
		foreach (IModule module in compilation.Modules)
		{
			ITypeDefinition typeDefinition = module.GetTypeDefinition(topLevelTypeName);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
		}
		return new UnknownType(topLevelTypeName);
	}
}
