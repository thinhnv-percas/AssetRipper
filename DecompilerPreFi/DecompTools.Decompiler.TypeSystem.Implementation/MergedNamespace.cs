using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class MergedNamespace : INamespace, ISymbol, ICompilationProvider
{
	private readonly string externAlias;

	private readonly ICompilation compilation;

	private readonly INamespace parentNamespace;

	private readonly INamespace[] namespaces;

	private Dictionary<string, INamespace> childNamespaces;

	public string ExternAlias => externAlias;

	public string FullName => namespaces[0].FullName;

	public string Name => namespaces[0].Name;

	public INamespace ParentNamespace => parentNamespace;

	public IEnumerable<ITypeDefinition> Types => Enumerable.SelectMany<INamespace, ITypeDefinition>((IEnumerable<INamespace>)namespaces, (Func<INamespace, IEnumerable<ITypeDefinition>>)((INamespace ns) => ns.Types));

	public SymbolKind SymbolKind => SymbolKind.Namespace;

	public ICompilation Compilation => compilation;

	public IEnumerable<IModule> ContributingModules => Enumerable.SelectMany<INamespace, IModule>((IEnumerable<INamespace>)namespaces, (Func<INamespace, IEnumerable<IModule>>)((INamespace ns) => ns.ContributingModules));

	public IEnumerable<INamespace> ChildNamespaces => GetChildNamespaces().Values;

	public MergedNamespace(ICompilation compilation, INamespace[] namespaces, string externAlias = null)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (namespaces == null)
		{
			throw new ArgumentNullException("namespaces");
		}
		this.compilation = compilation;
		this.namespaces = namespaces;
		this.externAlias = externAlias;
	}

	public MergedNamespace(INamespace parentNamespace, INamespace[] namespaces)
	{
		if (parentNamespace == null)
		{
			throw new ArgumentNullException("parentNamespace");
		}
		if (namespaces == null)
		{
			throw new ArgumentNullException("namespaces");
		}
		this.parentNamespace = parentNamespace;
		this.namespaces = namespaces;
		compilation = parentNamespace.Compilation;
		externAlias = parentNamespace.ExternAlias;
	}

	public INamespace GetChildNamespace(string name)
	{
		if (GetChildNamespaces().TryGetValue(name, out var value))
		{
			return value;
		}
		return null;
	}

	private Dictionary<string, INamespace> GetChildNamespaces()
	{
		Dictionary<string, INamespace> dictionary = LazyInit.VolatileRead(ref childNamespaces);
		if (dictionary != null)
		{
			return dictionary;
		}
		dictionary = new Dictionary<string, INamespace>(compilation.NameComparer);
		foreach (IGrouping<string, INamespace> item in Enumerable.GroupBy<INamespace, string>(Enumerable.SelectMany<INamespace, INamespace>((IEnumerable<INamespace>)namespaces, (Func<INamespace, IEnumerable<INamespace>>)((INamespace ns) => ns.ChildNamespaces)), (Func<INamespace, string>)((INamespace ns) => ns.Name), (IEqualityComparer<string>)compilation.NameComparer))
		{
			dictionary.Add(item.Key, new MergedNamespace(this, Enumerable.ToArray<INamespace>((IEnumerable<INamespace>)item)));
		}
		return LazyInit.GetOrSet(ref childNamespaces, dictionary);
	}

	public ITypeDefinition GetTypeDefinition(string name, int typeParameterCount)
	{
		ITypeDefinition result = null;
		INamespace[] array = namespaces;
		foreach (INamespace obj in array)
		{
			ITypeDefinition typeDefinition = obj.GetTypeDefinition(name, typeParameterCount);
			if (typeDefinition != null)
			{
				if (typeDefinition.Accessibility == Accessibility.Public)
				{
					return typeDefinition;
				}
				result = typeDefinition;
			}
		}
		return result;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[MergedNamespace {0}{1} (from {2} assemblies)]", (externAlias != null) ? (externAlias + "::") : null, FullName, namespaces.Length);
	}
}
