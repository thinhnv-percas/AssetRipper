using System;
using System.Collections.Generic;

namespace dnlib.DotNet;

public sealed class Resolver : IResolver, ITypeResolver, IMemberRefResolver
{
	private readonly IAssemblyResolver assemblyResolver;

	private bool projectWinMDRefs = true;

	public bool ProjectWinMDRefs
	{
		get
		{
			return projectWinMDRefs;
		}
		set
		{
			projectWinMDRefs = value;
		}
	}

	public Resolver(IAssemblyResolver assemblyResolver)
	{
		this.assemblyResolver = assemblyResolver ?? throw new ArgumentNullException("assemblyResolver");
	}

	public TypeDef Resolve(TypeRef typeRef, ModuleDef sourceModule)
	{
		if (typeRef == null)
		{
			return null;
		}
		if (ProjectWinMDRefs)
		{
			typeRef = WinMDHelpers.ToCLR(typeRef.Module ?? sourceModule, typeRef) ?? typeRef;
		}
		TypeRef nonNestedTypeRef = TypeRef.GetNonNestedTypeRef(typeRef);
		if (nonNestedTypeRef == null)
		{
			return null;
		}
		IResolutionScope resolutionScope = nonNestedTypeRef.ResolutionScope;
		ModuleDef module = nonNestedTypeRef.Module;
		if (resolutionScope is AssemblyRef assembly)
		{
			AssemblyDef assemblyDef = assemblyResolver.Resolve(assembly, sourceModule ?? module);
			return (assemblyDef == null) ? null : (assemblyDef.Find(typeRef) ?? ResolveExportedType(assemblyDef.Modules, typeRef, sourceModule));
		}
		if (resolutionScope is ModuleDef moduleDef)
		{
			return moduleDef.Find(typeRef) ?? ResolveExportedType(new ModuleDef[1] { moduleDef }, typeRef, sourceModule);
		}
		if (resolutionScope is ModuleRef moduleRef)
		{
			if (module == null)
			{
				return null;
			}
			if (default(SigComparer).Equals(moduleRef, module))
			{
				return module.Find(typeRef) ?? ResolveExportedType(new ModuleDef[1] { module }, typeRef, sourceModule);
			}
			AssemblyDef assembly2 = module.Assembly;
			if (assembly2 == null)
			{
				return null;
			}
			ModuleDef moduleDef2 = assembly2.FindModule(moduleRef.Name);
			return (moduleDef2 == null) ? null : (moduleDef2.Find(typeRef) ?? ResolveExportedType(new ModuleDef[1] { moduleDef2 }, typeRef, sourceModule));
		}
		return null;
	}

	private TypeDef ResolveExportedType(IList<ModuleDef> modules, TypeRef typeRef, ModuleDef sourceModule)
	{
		for (int i = 0; i < 30; i++)
		{
			ExportedType exportedType = FindExportedType(modules, typeRef);
			if (exportedType == null)
			{
				return null;
			}
			IAssemblyResolver assemblyResolver = modules[0].Context.AssemblyResolver;
			AssemblyDef assemblyDef = assemblyResolver.Resolve(exportedType.DefinitionAssembly, sourceModule ?? typeRef.Module);
			if (assemblyDef == null)
			{
				return null;
			}
			TypeDef typeDef = assemblyDef.Find(typeRef);
			if (typeDef != null)
			{
				return typeDef;
			}
			modules = assemblyDef.Modules;
		}
		return null;
	}

	private static ExportedType FindExportedType(IList<ModuleDef> modules, TypeRef typeRef)
	{
		if (typeRef == null)
		{
			return null;
		}
		int count = modules.Count;
		for (int i = 0; i < count; i++)
		{
			ModuleDef moduleDef = modules[i];
			IList<ExportedType> exportedTypes = moduleDef.ExportedTypes;
			int count2 = exportedTypes.Count;
			for (int j = 0; j < count2; j++)
			{
				ExportedType exportedType = exportedTypes[j];
				if (new SigComparer(SigComparerOptions.DontCompareTypeScope).Equals(exportedType, typeRef))
				{
					return exportedType;
				}
			}
		}
		return null;
	}

	public IMemberForwarded Resolve(MemberRef memberRef)
	{
		if (memberRef == null)
		{
			return null;
		}
		if (ProjectWinMDRefs)
		{
			memberRef = WinMDHelpers.ToCLR(memberRef.Module, memberRef) ?? memberRef;
		}
		IMemberRefParent memberRefParent = memberRef.Class;
		if (memberRefParent is MethodDef result)
		{
			return result;
		}
		return GetDeclaringType(memberRef, memberRefParent)?.Resolve(memberRef);
	}

	private TypeDef GetDeclaringType(MemberRef memberRef, IMemberRefParent parent)
	{
		if (memberRef == null || parent == null)
		{
			return null;
		}
		if (parent is TypeSpec typeSpec)
		{
			parent = typeSpec.ScopeType;
		}
		if (parent is TypeDef result)
		{
			return result;
		}
		if (parent is TypeRef typeRef)
		{
			return Resolve(typeRef, memberRef.Module);
		}
		if (parent is ModuleRef moduleRef)
		{
			ModuleDef module = memberRef.Module;
			if (module == null)
			{
				return null;
			}
			TypeDef typeDef = null;
			if (default(SigComparer).Equals(module, moduleRef))
			{
				typeDef = module.GlobalType;
			}
			AssemblyDef assembly = module.Assembly;
			if (typeDef == null && assembly != null)
			{
				ModuleDef moduleDef = assembly.FindModule(moduleRef.Name);
				if (moduleDef != null)
				{
					typeDef = moduleDef.GlobalType;
				}
			}
			return typeDef;
		}
		if (!(parent is MethodDef { DeclaringType: var declaringType }))
		{
			return null;
		}
		return declaringType;
	}
}
