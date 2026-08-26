#define DEBUG
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataNamespace : INamespace, ISymbol, ICompilationProvider
{
	private readonly MetadataModule module;

	private readonly NamespaceDefinition ns;

	private INamespace[] childNamespaces;

	public INamespace ParentNamespace { get; }

	public string FullName { get; }

	public string Name { get; }

	string INamespace.ExternAlias => string.Empty;

	public IEnumerable<INamespace> ChildNamespaces
	{
		get
		{
			INamespace[] array = LazyInit.VolatileRead(ref childNamespaces);
			if (array != null)
			{
				return array;
			}
			ImmutableArray<NamespaceDefinitionHandle> namespaceDefinitions = ns.NamespaceDefinitions;
			array = new INamespace[namespaceDefinitions.Length];
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				NamespaceDefinitionHandle handle = namespaceDefinitions[i];
				string fullName = module.metadata.GetString(handle);
				array[i] = new MetadataNamespace(module, this, fullName, module.metadata.GetNamespaceDefinition(handle));
			}
			return LazyInit.GetOrSet(ref childNamespaces, array);
		}
	}

	IEnumerable<ITypeDefinition> INamespace.Types
	{
		get
		{
			foreach (TypeDefinitionHandle typeHandle in ns.TypeDefinitions)
			{
				ITypeDefinition def = module.GetDefinition(typeHandle);
				if (def != null)
				{
					yield return def;
				}
			}
		}
	}

	IEnumerable<IModule> INamespace.ContributingModules => new MetadataModule[1] { module };

	SymbolKind ISymbol.SymbolKind => SymbolKind.Namespace;

	ICompilation ICompilationProvider.Compilation => module.Compilation;

	public MetadataNamespace(MetadataModule module, INamespace parent, string fullName, NamespaceDefinition ns)
	{
		Debug.Assert(module != null);
		Debug.Assert(fullName != null);
		this.module = module;
		ParentNamespace = parent;
		this.ns = ns;
		FullName = fullName;
		Name = module.GetString(ns.Name);
	}

	INamespace INamespace.GetChildNamespace(string name)
	{
		foreach (INamespace childNamespace in ChildNamespaces)
		{
			if (childNamespace.Name == name)
			{
				return childNamespace;
			}
		}
		return null;
	}

	ITypeDefinition INamespace.GetTypeDefinition(string name, int typeParameterCount)
	{
		return module.GetTypeDefinition(FullName, name, typeParameterCount);
	}
}
