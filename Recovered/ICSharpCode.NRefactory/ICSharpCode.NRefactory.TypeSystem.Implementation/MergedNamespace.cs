using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
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

		public IEnumerable<ITypeDefinition> Types => namespaces.SelectMany((INamespace ns) => ns.Types);

		public SymbolKind SymbolKind => SymbolKind.Namespace;

		public ICompilation Compilation => compilation;

		public IEnumerable<IAssembly> ContributingAssemblies => namespaces.SelectMany((INamespace ns) => ns.ContributingAssemblies);

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
			if (GetChildNamespaces().TryGetValue(name, out INamespace value))
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
			foreach (IGrouping<string, INamespace> item in namespaces.SelectMany((INamespace ns) => ns.ChildNamespaces).GroupBy((INamespace ns) => ns.Name, compilation.NameComparer))
			{
				dictionary.Add(item.Key, new MergedNamespace(this, item.ToArray()));
			}
			return LazyInit.GetOrSet(ref childNamespaces, dictionary);
		}

		public ITypeDefinition GetTypeDefinition(string name, int typeParameterCount)
		{
			ITypeDefinition result = null;
			INamespace[] array = namespaces;
			for (int i = 0; i < array.Length; i++)
			{
				ITypeDefinition typeDefinition = array[i].GetTypeDefinition(name, typeParameterCount);
				if (typeDefinition != null)
				{
					if (typeDefinition.IsPublic)
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
			return string.Format(CultureInfo.InvariantCulture, "[MergedNamespace {0}{1} (from {2} assemblies)]", new object[3]
			{
				(externAlias != null) ? (externAlias + "::") : null,
				FullName,
				namespaces.Length
			});
		}

		public ISymbolReference ToReference()
		{
			return new MergedNamespaceReference(externAlias, FullName);
		}
	}
}
