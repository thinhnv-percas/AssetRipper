namespace dnlib.DotNet;

internal sealed class CAAssemblyRefFinder : IAssemblyRefFinder
{
	private readonly ModuleDef module;

	public CAAssemblyRefFinder(ModuleDef module)
	{
		this.module = module;
	}

	public AssemblyRef FindAssemblyRef(TypeRef nonNestedTypeRef)
	{
		AssemblyDef assembly = module.Assembly;
		if (assembly != null)
		{
			TypeDef typeDef = assembly.Find(nonNestedTypeRef);
			if (typeDef != null)
			{
				return module.UpdateRowId(new AssemblyRefUser(assembly));
			}
		}
		else if (module.Find(nonNestedTypeRef) != null)
		{
			return AssemblyRef.CurrentAssembly;
		}
		AssemblyDef assemblyDef = module.Context.AssemblyResolver.Resolve(module.CorLibTypes.AssemblyRef, module);
		if (assemblyDef != null)
		{
			TypeDef typeDef2 = assemblyDef.Find(nonNestedTypeRef);
			if (typeDef2 != null)
			{
				return module.CorLibTypes.AssemblyRef;
			}
		}
		if (assembly != null)
		{
			return module.UpdateRowId(new AssemblyRefUser(assembly));
		}
		return AssemblyRef.CurrentAssembly;
	}
}
