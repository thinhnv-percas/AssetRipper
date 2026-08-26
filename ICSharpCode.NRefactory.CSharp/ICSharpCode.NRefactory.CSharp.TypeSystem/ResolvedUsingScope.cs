using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem;

public class ResolvedUsingScope
{
	private sealed class DummyNamespace : INamespace, ISymbol, ICompilationProvider
	{
		private readonly INamespace parentNamespace;

		private readonly string name;

		public string ExternAlias { get; set; }

		string INamespace.FullName => NamespaceDeclaration.BuildQualifiedName(parentNamespace.FullName, name);

		public string Name => name;

		SymbolKind ISymbol.SymbolKind => SymbolKind.Namespace;

		INamespace INamespace.ParentNamespace => parentNamespace;

		IEnumerable<INamespace> INamespace.ChildNamespaces => EmptyList<INamespace>.Instance;

		IEnumerable<ITypeDefinition> INamespace.Types => EmptyList<ITypeDefinition>.Instance;

		IEnumerable<IAssembly> INamespace.ContributingAssemblies => EmptyList<IAssembly>.Instance;

		ICompilation ICompilationProvider.Compilation => parentNamespace.Compilation;

		public DummyNamespace(INamespace parentNamespace, string name)
		{
			this.parentNamespace = parentNamespace;
			this.name = name;
		}

		INamespace INamespace.GetChildNamespace(string name)
		{
			return null;
		}

		ITypeDefinition INamespace.GetTypeDefinition(string name, int typeParameterCount)
		{
			return null;
		}

		public ISymbolReference ToReference()
		{
			return new MergedNamespaceReference(ExternAlias, ((INamespace)this).FullName);
		}
	}

	private readonly CSharpTypeResolveContext parentContext;

	private readonly UsingScope usingScope;

	internal readonly ConcurrentDictionary<string, ResolveResult> ResolveCache = new ConcurrentDictionary<string, ResolveResult>();

	internal List<List<IMethod>> AllExtensionMethods;

	private INamespace @namespace;

	private IList<INamespace> usings;

	private IList<KeyValuePair<string, ResolveResult>> usingAliases;

	public UsingScope UnresolvedUsingScope => usingScope;

	public INamespace Namespace
	{
		get
		{
			INamespace obj = LazyInit.VolatileRead(ref @namespace);
			if (obj != null)
			{
				return obj;
			}
			if (parentContext.CurrentUsingScope != null)
			{
				obj = parentContext.CurrentUsingScope.Namespace.GetChildNamespace(usingScope.ShortNamespaceName);
				if (obj == null)
				{
					obj = new DummyNamespace(parentContext.CurrentUsingScope.Namespace, usingScope.ShortNamespaceName);
				}
			}
			else
			{
				obj = parentContext.Compilation.RootNamespace;
			}
			return LazyInit.GetOrSet(ref @namespace, obj);
		}
	}

	public ResolvedUsingScope Parent => parentContext.CurrentUsingScope;

	public IList<INamespace> Usings
	{
		get
		{
			IList<INamespace> list = LazyInit.VolatileRead(ref usings);
			if (list != null)
			{
				return list;
			}
			list = new List<INamespace>();
			CSharpResolver resolver = new CSharpResolver(parentContext.WithUsingScope(this));
			foreach (TypeOrNamespaceReference @using in usingScope.Usings)
			{
				INamespace obj = @using.ResolveNamespace(resolver);
				if (obj != null && !list.Contains(obj))
				{
					list.Add(obj);
				}
			}
			return LazyInit.GetOrSet(ref usings, new ReadOnlyCollection<INamespace>(list));
		}
	}

	public IList<KeyValuePair<string, ResolveResult>> UsingAliases
	{
		get
		{
			IList<KeyValuePair<string, ResolveResult>> list = LazyInit.VolatileRead(ref usingAliases);
			if (list != null)
			{
				return list;
			}
			CSharpResolver resolver = new CSharpResolver(parentContext.WithUsingScope(this));
			list = new KeyValuePair<string, ResolveResult>[usingScope.UsingAliases.Count];
			for (int i = 0; i < list.Count; i++)
			{
				ResolveResult resolveResult = usingScope.UsingAliases[i].Value.Resolve(resolver);
				if (resolveResult is TypeResolveResult)
				{
					resolveResult = new AliasTypeResolveResult(usingScope.UsingAliases[i].Key, (TypeResolveResult)resolveResult);
				}
				else if (resolveResult is NamespaceResolveResult)
				{
					resolveResult = new AliasNamespaceResolveResult(usingScope.UsingAliases[i].Key, (NamespaceResolveResult)resolveResult);
				}
				list[i] = new KeyValuePair<string, ResolveResult>(usingScope.UsingAliases[i].Key, resolveResult);
			}
			return LazyInit.GetOrSet(ref usingAliases, list);
		}
	}

	public IList<string> ExternAliases => usingScope.ExternAliases;

	public ResolvedUsingScope(CSharpTypeResolveContext context, UsingScope usingScope)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (usingScope == null)
		{
			throw new ArgumentNullException("usingScope");
		}
		parentContext = context;
		this.usingScope = usingScope;
		if (usingScope.Parent != null)
		{
			if (context.CurrentUsingScope == null)
			{
				throw new InvalidOperationException();
			}
		}
		else if (context.CurrentUsingScope != null)
		{
			throw new InvalidOperationException();
		}
	}

	public bool HasAlias(string identifier)
	{
		return usingScope.HasAlias(identifier);
	}
}
