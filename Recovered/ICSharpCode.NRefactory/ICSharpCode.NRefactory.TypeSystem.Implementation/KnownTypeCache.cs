using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	internal sealed class KnownTypeCache
	{
		private readonly ICompilation compilation;

		private readonly IType[] knownTypes = new IType[46];

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
			foreach (IAssembly assembly in compilation.Assemblies)
			{
				ITypeDefinition typeDefinition = assembly.GetTypeDefinition(topLevelTypeName);
				if (typeDefinition != null)
				{
					return typeDefinition;
				}
			}
			return new UnknownType(topLevelTypeName);
		}
	}
}
