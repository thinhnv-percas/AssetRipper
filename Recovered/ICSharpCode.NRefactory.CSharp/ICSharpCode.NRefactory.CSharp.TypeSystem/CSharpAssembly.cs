using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	public class CSharpAssembly : IAssembly, ICompilationProvider
	{
		private sealed class NS : INamespace, ISymbol, ICompilationProvider
		{
			private readonly CSharpAssembly assembly;

			private readonly NS parentNamespace;

			private readonly string fullName;

			private readonly string name;

			internal readonly List<NS> childNamespaces = new List<NS>();

			internal readonly Dictionary<TopLevelTypeName, ITypeDefinition> types;

			string INamespace.ExternAlias => null;

			string INamespace.FullName => fullName;

			public string Name => name;

			SymbolKind ISymbol.SymbolKind => SymbolKind.Namespace;

			INamespace INamespace.ParentNamespace => parentNamespace;

			IEnumerable<INamespace> INamespace.ChildNamespaces => childNamespaces;

			IEnumerable<ITypeDefinition> INamespace.Types
			{
				get
				{
					if (types != null)
					{
						return types.Values;
					}
					return from t in assembly.GetTypes()
						where t.Key.Namespace == fullName
						select t.Value;
				}
			}

			ICompilation ICompilationProvider.Compilation => assembly.Compilation;

			IEnumerable<IAssembly> INamespace.ContributingAssemblies => new CSharpAssembly[1]
			{
				assembly
			};

			public NS(CSharpAssembly assembly)
			{
				this.assembly = assembly;
				fullName = string.Empty;
				name = string.Empty;
				if (assembly.compilation.NameComparer != StringComparer.Ordinal)
				{
					types = new Dictionary<TopLevelTypeName, ITypeDefinition>(new TopLevelTypeNameComparer(assembly.compilation.NameComparer));
				}
			}

			public NS(NS parentNamespace, string fullName, string name)
			{
				assembly = parentNamespace.assembly;
				this.parentNamespace = parentNamespace;
				this.fullName = fullName;
				this.name = name;
				if (parentNamespace.types != null)
				{
					types = new Dictionary<TopLevelTypeName, ITypeDefinition>(parentNamespace.types.Comparer);
				}
			}

			INamespace INamespace.GetChildNamespace(string name)
			{
				StringComparer nameComparer = assembly.compilation.NameComparer;
				foreach (NS childNamespace in childNamespaces)
				{
					if (nameComparer.Equals(name, childNamespace.name))
					{
						return childNamespace;
					}
				}
				return null;
			}

			ITypeDefinition INamespace.GetTypeDefinition(string name, int typeParameterCount)
			{
				TopLevelTypeName topLevelTypeName = new TopLevelTypeName(fullName, name, typeParameterCount);
				if (types != null)
				{
					if (types.TryGetValue(topLevelTypeName, out ITypeDefinition value))
					{
						return value;
					}
					return null;
				}
				return assembly.GetTypeDefinition(topLevelTypeName);
			}

			public ISymbolReference ToReference()
			{
				return new NamespaceReference(new DefaultAssemblyReference(assembly.AssemblyName), fullName);
			}
		}

		private readonly ICompilation compilation;

		private readonly ITypeResolveContext context;

		private readonly CSharpProjectContent projectContent;

		private IList<IAttribute> assemblyAttributes;

		private IList<IAttribute> moduleAttributes;

		private NS rootNamespace;

		private volatile string[] internalsVisibleTo;

		private Dictionary<TopLevelTypeName, ITypeDefinition> typeDict;

		public bool IsMainAssembly => compilation.MainAssembly == this;

		public IUnresolvedAssembly UnresolvedAssembly => projectContent;

		public string AssemblyName => projectContent.AssemblyName;

		public string FullAssemblyName => projectContent.FullAssemblyName;

		public IList<IAttribute> AssemblyAttributes => GetAttributes(ref assemblyAttributes, assemblyAttributes: true);

		public IList<IAttribute> ModuleAttributes => GetAttributes(ref moduleAttributes, assemblyAttributes: false);

		public INamespace RootNamespace
		{
			get
			{
				NS nS = LazyInit.VolatileRead(ref rootNamespace);
				if (nS != null)
				{
					return nS;
				}
				nS = new NS(this);
				Dictionary<string, NS> dictionary = new Dictionary<string, NS>(compilation.NameComparer);
				dictionary.Add(string.Empty, nS);
				foreach (UsingScope item in projectContent.Files.OfType<CSharpUnresolvedFile>().SelectMany((CSharpUnresolvedFile f) => f.UsingScopes))
				{
					GetOrAddNamespace(dictionary, item.NamespaceName);
				}
				foreach (KeyValuePair<TopLevelTypeName, ITypeDefinition> type in GetTypes())
				{
					NS orAddNamespace = GetOrAddNamespace(dictionary, type.Key.Namespace);
					if (orAddNamespace.types != null)
					{
						orAddNamespace.types[type.Key] = type.Value;
					}
				}
				return LazyInit.GetOrSet(ref rootNamespace, nS);
			}
		}

		public ICompilation Compilation => compilation;

		public IEnumerable<ITypeDefinition> TopLevelTypeDefinitions => GetTypes().Values;

		internal CSharpAssembly(ICompilation compilation, CSharpProjectContent projectContent)
		{
			this.compilation = compilation;
			this.projectContent = projectContent;
			context = new SimpleTypeResolveContext(this);
		}

		private IList<IAttribute> GetAttributes(ref IList<IAttribute> field, bool assemblyAttributes)
		{
			IList<IAttribute> list = LazyInit.VolatileRead(ref field);
			if (list != null)
			{
				return list;
			}
			list = new List<IAttribute>();
			foreach (CSharpUnresolvedFile item in projectContent.Files.OfType<CSharpUnresolvedFile>())
			{
				IList<IUnresolvedAttribute> obj = assemblyAttributes ? item.AssemblyAttributes : item.ModuleAttributes;
				CSharpTypeResolveContext cSharpTypeResolveContext = new CSharpTypeResolveContext(this, item.RootUsingScope.Resolve(compilation));
				foreach (IUnresolvedAttribute item2 in obj)
				{
					list.Add(item2.CreateResolvedAttribute(cSharpTypeResolveContext));
				}
			}
			return LazyInit.GetOrSet(ref field, list);
		}

		private static NS GetOrAddNamespace(Dictionary<string, NS> dict, string fullName)
		{
			if (dict.TryGetValue(fullName, out NS value))
			{
				return value;
			}
			int num = fullName.LastIndexOf('.');
			NS nS;
			string name;
			if (num < 0)
			{
				nS = dict[string.Empty];
				name = fullName;
			}
			else
			{
				nS = GetOrAddNamespace(dict, fullName.Substring(0, num));
				name = fullName.Substring(num + 1);
			}
			value = new NS(nS, fullName, name);
			nS.childNamespaces.Add(value);
			dict.Add(fullName, value);
			return value;
		}

		public bool InternalsVisibleTo(IAssembly assembly)
		{
			if (this == assembly)
			{
				return true;
			}
			string[] array = GetInternalsVisibleTo();
			foreach (string b in array)
			{
				if (assembly.AssemblyName == b)
				{
					return true;
				}
			}
			return false;
		}

		private string[] GetInternalsVisibleTo()
		{
			string[] array = internalsVisibleTo;
			if (array != null)
			{
				return array;
			}
			using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
			{
				if (!busyLock.Success)
				{
					return new string[0];
				}
				internalsVisibleTo = (from attr in AssemblyAttributes
					where attr.AttributeType.Name == "InternalsVisibleToAttribute" && attr.AttributeType.Namespace == "System.Runtime.CompilerServices" && attr.PositionalArguments.Count == 1
					select GetShortName(attr.PositionalArguments.Single().ConstantValue as string)).ToArray();
			}
			return internalsVisibleTo;
		}

		private static string GetShortName(string fullAssemblyName)
		{
			if (fullAssemblyName == null)
			{
				return null;
			}
			int num = fullAssemblyName.IndexOf(',');
			if (num < 0)
			{
				return fullAssemblyName;
			}
			return fullAssemblyName.Substring(0, num);
		}

		private Dictionary<TopLevelTypeName, ITypeDefinition> GetTypes()
		{
			Dictionary<TopLevelTypeName, ITypeDefinition> dictionary = LazyInit.VolatileRead(ref typeDict);
			if (dictionary != null)
			{
				return dictionary;
			}
			TopLevelTypeNameComparer ordinal = TopLevelTypeNameComparer.Ordinal;
			dictionary = projectContent.TopLevelTypeDefinitions.GroupBy((IUnresolvedTypeDefinition t) => new TopLevelTypeName(t.Namespace, t.Name, t.TypeParameters.Count), ordinal).ToDictionary((IGrouping<TopLevelTypeName, IUnresolvedTypeDefinition> g) => g.Key, (IGrouping<TopLevelTypeName, IUnresolvedTypeDefinition> g) => CreateResolvedTypeDefinition(g.ToArray()), ordinal);
			return LazyInit.GetOrSet(ref typeDict, dictionary);
		}

		private ITypeDefinition CreateResolvedTypeDefinition(IUnresolvedTypeDefinition[] parts)
		{
			return new DefaultResolvedTypeDefinition(context, parts);
		}

		public ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName)
		{
			if (GetTypes().TryGetValue(topLevelTypeName, out ITypeDefinition value))
			{
				return value;
			}
			return null;
		}

		public override string ToString()
		{
			return "[CSharpAssembly " + AssemblyName + "]";
		}
	}
}
