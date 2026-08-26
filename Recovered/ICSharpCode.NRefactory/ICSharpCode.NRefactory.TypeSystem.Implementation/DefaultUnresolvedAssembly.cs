using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public class DefaultUnresolvedAssembly : AbstractFreezable, IUnresolvedAssembly, IAssemblyReference
	{
		[Serializable]
		private sealed class TypeOfConstantValue : IConstantValue
		{
			private readonly ITypeReference typeRef;

			public TypeOfConstantValue(ITypeReference typeRef)
			{
				this.typeRef = typeRef;
			}

			public ResolveResult Resolve(ITypeResolveContext context)
			{
				return new TypeOfResolveResult(context.Compilation.FindType(KnownTypeCode.Type), typeRef.Resolve(context));
			}
		}

		private sealed class UnresolvedNamespace
		{
			internal readonly string FullName;

			internal readonly string Name;

			internal readonly List<UnresolvedNamespace> Children = new List<UnresolvedNamespace>();

			public UnresolvedNamespace(string fullName, string name)
			{
				FullName = fullName;
				Name = name;
			}
		}

		private sealed class DefaultResolvedAssembly : IAssembly, ICompilationProvider
		{
			private sealed class NS : INamespace, ISymbol, ICompilationProvider
			{
				private readonly DefaultResolvedAssembly assembly;

				private readonly UnresolvedNamespace ns;

				private readonly INamespace parentNamespace;

				private readonly IList<NS> childNamespaces;

				private IEnumerable<ITypeDefinition> types;

				string INamespace.ExternAlias => null;

				string INamespace.FullName => ns.FullName;

				SymbolKind ISymbol.SymbolKind => SymbolKind.Namespace;

				public string Name => ns.Name;

				INamespace INamespace.ParentNamespace => parentNamespace;

				IEnumerable<IAssembly> INamespace.ContributingAssemblies => new DefaultResolvedAssembly[1]
				{
					assembly
				};

				IEnumerable<INamespace> INamespace.ChildNamespaces => childNamespaces;

				ICompilation ICompilationProvider.Compilation => assembly.compilation;

				IEnumerable<ITypeDefinition> INamespace.Types
				{
					get
					{
						IEnumerable<ITypeDefinition> enumerable = LazyInit.VolatileRead(ref types);
						if (enumerable != null)
						{
							return enumerable;
						}
						HashSet<ITypeDefinition> hashSet = new HashSet<ITypeDefinition>();
						foreach (IUnresolvedTypeDefinition topLevelTypeDefinition in assembly.UnresolvedAssembly.TopLevelTypeDefinitions)
						{
							if (topLevelTypeDefinition.Namespace == ns.FullName)
							{
								hashSet.Add(assembly.GetTypeDefinition(topLevelTypeDefinition));
							}
						}
						return LazyInit.GetOrSet(ref types, hashSet.ToArray());
					}
				}

				public NS(DefaultResolvedAssembly assembly, UnresolvedNamespace ns, INamespace parentNamespace)
				{
					this.assembly = assembly;
					this.ns = ns;
					this.parentNamespace = parentNamespace;
					childNamespaces = new ProjectedList<NS, UnresolvedNamespace, NS>(this, ns.Children, (NS self, UnresolvedNamespace c) => new NS(self.assembly, c, self));
				}

				INamespace INamespace.GetChildNamespace(string name)
				{
					StringComparer nameComparer = assembly.compilation.NameComparer;
					for (int i = 0; i < childNamespaces.Count; i++)
					{
						if (nameComparer.Equals(name, ns.Children[i].Name))
						{
							return childNamespaces[i];
						}
					}
					return null;
				}

				ITypeDefinition INamespace.GetTypeDefinition(string name, int typeParameterCount)
				{
					TopLevelTypeName key = new TopLevelTypeName(ns.FullName, name, typeParameterCount);
					if (assembly.unresolvedTypeDict.TryGetValue(key, out IUnresolvedTypeDefinition value))
					{
						return assembly.GetTypeDefinition(value);
					}
					return null;
				}

				public ISymbolReference ToReference()
				{
					return new NamespaceReference(new DefaultAssemblyReference(assembly.AssemblyName), ns.FullName);
				}
			}

			private readonly DefaultUnresolvedAssembly unresolvedAssembly;

			private readonly ICompilation compilation;

			private readonly ITypeResolveContext context;

			private readonly Dictionary<TopLevelTypeName, IUnresolvedTypeDefinition> unresolvedTypeDict;

			private readonly ConcurrentDictionary<IUnresolvedTypeDefinition, ITypeDefinition> typeDict = new ConcurrentDictionary<IUnresolvedTypeDefinition, ITypeDefinition>();

			private readonly INamespace rootNamespace;

			private volatile string[] internalsVisibleTo;

			public IUnresolvedAssembly UnresolvedAssembly => unresolvedAssembly;

			public bool IsMainAssembly => Compilation.MainAssembly == this;

			public string AssemblyName => unresolvedAssembly.AssemblyName;

			public string FullAssemblyName => unresolvedAssembly.FullAssemblyName;

			public IList<IAttribute> AssemblyAttributes
			{
				get;
				private set;
			}

			public IList<IAttribute> ModuleAttributes
			{
				get;
				private set;
			}

			public INamespace RootNamespace => rootNamespace;

			public ICompilation Compilation => compilation;

			public IEnumerable<ITypeDefinition> TopLevelTypeDefinitions => from t in unresolvedAssembly.TopLevelTypeDefinitions
				select GetTypeDefinition(t);

			public DefaultResolvedAssembly(ICompilation compilation, DefaultUnresolvedAssembly unresolved)
			{
				this.compilation = compilation;
				unresolvedAssembly = unresolved;
				unresolvedTypeDict = unresolved.GetTypeDictionary(compilation.NameComparer);
				rootNamespace = new NS(this, unresolved.GetUnresolvedRootNamespace(compilation.NameComparer), null);
				context = new SimpleTypeResolveContext(this);
				AssemblyAttributes = unresolved.AssemblyAttributes.CreateResolvedAttributes(context);
				ModuleAttributes = unresolved.ModuleAttributes.CreateResolvedAttributes(context);
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

			public ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName)
			{
				if (unresolvedAssembly.typeDefinitions.TryGetValue(topLevelTypeName, out IUnresolvedTypeDefinition value))
				{
					return GetTypeDefinition(value);
				}
				if (unresolvedAssembly.typeForwarders.TryGetValue(topLevelTypeName, out ITypeReference value2))
				{
					using (BusyManager.BusyLock busyLock = BusyManager.Enter(value2))
					{
						if (busyLock.Success)
						{
							return value2.Resolve(compilation.TypeResolveContext).GetDefinition();
						}
					}
				}
				return null;
			}

			private ITypeDefinition GetTypeDefinition(IUnresolvedTypeDefinition unresolved)
			{
				return typeDict.GetOrAdd(unresolved, (IUnresolvedTypeDefinition t) => CreateTypeDefinition(t));
			}

			private ITypeDefinition CreateTypeDefinition(IUnresolvedTypeDefinition unresolved)
			{
				if (unresolved.DeclaringTypeDefinition != null)
				{
					ITypeDefinition typeDefinition = GetTypeDefinition(unresolved.DeclaringTypeDefinition);
					return new DefaultResolvedTypeDefinition(context.WithCurrentTypeDefinition(typeDefinition), unresolved);
				}
				if (unresolved.Name == "Void" && unresolved.Namespace == "System" && unresolved.TypeParameters.Count == 0)
				{
					return new VoidTypeDefinition(context, unresolved);
				}
				return new DefaultResolvedTypeDefinition(context, unresolved);
			}

			public override string ToString()
			{
				return "[DefaultResolvedAssembly " + AssemblyName + "]";
			}
		}

		private string assemblyName;

		private string fullAssemblyName;

		private IList<IUnresolvedAttribute> assemblyAttributes;

		private IList<IUnresolvedAttribute> moduleAttributes;

		private Dictionary<TopLevelTypeName, IUnresolvedTypeDefinition> typeDefinitions = new Dictionary<TopLevelTypeName, IUnresolvedTypeDefinition>(TopLevelTypeNameComparer.Ordinal);

		private Dictionary<TopLevelTypeName, ITypeReference> typeForwarders = new Dictionary<TopLevelTypeName, ITypeReference>(TopLevelTypeNameComparer.Ordinal);

		private string location;

		private static readonly ITypeReference typeForwardedToAttributeTypeRef = ReflectionHelper.ToTypeReference(typeof(TypeForwardedToAttribute));

		[NonSerialized]
		private List<KeyValuePair<StringComparer, UnresolvedNamespace>> unresolvedNamespacesPerNameComparer;

		public string AssemblyName
		{
			get
			{
				return assemblyName;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				FreezableHelper.ThrowIfFrozen(this);
				assemblyName = value;
			}
		}

		public string FullAssemblyName
		{
			get
			{
				return fullAssemblyName;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				FreezableHelper.ThrowIfFrozen(this);
				fullAssemblyName = value;
			}
		}

		public string Location
		{
			get
			{
				return location;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				location = value;
			}
		}

		public IList<IUnresolvedAttribute> AssemblyAttributes => assemblyAttributes;

		IEnumerable<IUnresolvedAttribute> IUnresolvedAssembly.AssemblyAttributes => assemblyAttributes;

		public IList<IUnresolvedAttribute> ModuleAttributes => moduleAttributes;

		IEnumerable<IUnresolvedAttribute> IUnresolvedAssembly.ModuleAttributes => moduleAttributes;

		public IEnumerable<IUnresolvedTypeDefinition> TopLevelTypeDefinitions => typeDefinitions.Values;

		protected override void FreezeInternal()
		{
			base.FreezeInternal();
			assemblyAttributes = FreezableHelper.FreezeListAndElements(assemblyAttributes);
			moduleAttributes = FreezableHelper.FreezeListAndElements(moduleAttributes);
			foreach (IUnresolvedTypeDefinition value in typeDefinitions.Values)
			{
				FreezableHelper.Freeze(value);
			}
		}

		public DefaultUnresolvedAssembly(string assemblyName)
		{
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			fullAssemblyName = assemblyName;
			int num = assemblyName?.IndexOf(',') ?? (-1);
			this.assemblyName = ((num < 0) ? assemblyName : assemblyName.Substring(0, num));
			assemblyAttributes = new List<IUnresolvedAttribute>();
			moduleAttributes = new List<IUnresolvedAttribute>();
		}

		public void AddTypeDefinition(IUnresolvedTypeDefinition typeDefinition)
		{
			if (typeDefinition == null)
			{
				throw new ArgumentNullException("typeDefinition");
			}
			if (typeDefinition.DeclaringTypeDefinition != null)
			{
				throw new ArgumentException("Cannot add nested types.");
			}
			FreezableHelper.ThrowIfFrozen(this);
			TopLevelTypeName key = new TopLevelTypeName(typeDefinition.Namespace, typeDefinition.Name, typeDefinition.TypeParameters.Count);
			typeDefinitions.Add(key, typeDefinition);
		}

		public void AddTypeForwarder(TopLevelTypeName typeName, ITypeReference referencedType)
		{
			if (referencedType == null)
			{
				throw new ArgumentNullException("referencedType");
			}
			FreezableHelper.ThrowIfFrozen(this);
			DefaultUnresolvedAttribute defaultUnresolvedAttribute = new DefaultUnresolvedAttribute(typeForwardedToAttributeTypeRef, new KnownTypeReference[1]
			{
				KnownTypeReference.Type
			});
			defaultUnresolvedAttribute.PositionalArguments.Add(new TypeOfConstantValue(referencedType));
			assemblyAttributes.Add(defaultUnresolvedAttribute);
			typeForwarders[typeName] = referencedType;
		}

		public IUnresolvedTypeDefinition GetTypeDefinition(string ns, string name, int typeParameterCount)
		{
			TopLevelTypeName key = new TopLevelTypeName(ns ?? string.Empty, name, typeParameterCount);
			if (typeDefinitions.TryGetValue(key, out IUnresolvedTypeDefinition value))
			{
				return value;
			}
			return null;
		}

		public IAssembly Resolve(ITypeResolveContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			Freeze();
			CacheManager cacheManager = context.Compilation.CacheManager;
			IAssembly assembly = (IAssembly)cacheManager.GetShared(this);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = new DefaultResolvedAssembly(context.Compilation, this);
			return (IAssembly)cacheManager.GetOrAddShared(this, assembly);
		}

		public override string ToString()
		{
			return "[" + GetType().Name + " " + assemblyName + "]";
		}

		private Dictionary<TopLevelTypeName, IUnresolvedTypeDefinition> GetTypeDictionary(StringComparer nameComparer)
		{
			if (nameComparer == StringComparer.Ordinal)
			{
				return typeDefinitions;
			}
			throw new NotImplementedException();
		}

		private UnresolvedNamespace GetUnresolvedRootNamespace(StringComparer nameComparer)
		{
			LazyInitializer.EnsureInitialized(ref unresolvedNamespacesPerNameComparer);
			lock (unresolvedNamespacesPerNameComparer)
			{
				foreach (KeyValuePair<StringComparer, UnresolvedNamespace> item in unresolvedNamespacesPerNameComparer)
				{
					if (item.Key == nameComparer)
					{
						return item.Value;
					}
				}
				UnresolvedNamespace unresolvedNamespace = new UnresolvedNamespace(string.Empty, string.Empty);
				Dictionary<string, UnresolvedNamespace> dictionary = new Dictionary<string, UnresolvedNamespace>(nameComparer);
				dictionary.Add(unresolvedNamespace.FullName, unresolvedNamespace);
				foreach (TopLevelTypeName key in typeDefinitions.Keys)
				{
					GetOrAddNamespace(dictionary, key.Namespace);
				}
				unresolvedNamespacesPerNameComparer.Add(new KeyValuePair<StringComparer, UnresolvedNamespace>(nameComparer, unresolvedNamespace));
				return unresolvedNamespace;
			}
		}

		private static UnresolvedNamespace GetOrAddNamespace(Dictionary<string, UnresolvedNamespace> dict, string fullName)
		{
			if (dict.TryGetValue(fullName, out UnresolvedNamespace value))
			{
				return value;
			}
			int num = fullName.LastIndexOf('.');
			UnresolvedNamespace unresolvedNamespace;
			string name;
			if (num < 0)
			{
				unresolvedNamespace = dict[string.Empty];
				name = fullName;
			}
			else
			{
				unresolvedNamespace = GetOrAddNamespace(dict, fullName.Substring(0, num));
				name = fullName.Substring(num + 1);
			}
			value = new UnresolvedNamespace(fullName, name);
			unresolvedNamespace.Children.Add(value);
			dict.Add(fullName, value);
			return value;
		}
	}
}
