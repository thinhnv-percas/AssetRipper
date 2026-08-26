using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	public class UsingScope : AbstractFreezable
	{
		private readonly UsingScope parent;

		private DomRegion region;

		private string shortName = "";

		private IList<TypeOrNamespaceReference> usings;

		private IList<KeyValuePair<string, TypeOrNamespaceReference>> usingAliases;

		private IList<string> externAliases;

		public UsingScope Parent => parent;

		public DomRegion Region
		{
			get
			{
				return region;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				region = value;
			}
		}

		public string ShortNamespaceName => shortName;

		public string NamespaceName
		{
			get
			{
				if (parent != null)
				{
					return NamespaceDeclaration.BuildQualifiedName(parent.NamespaceName, shortName);
				}
				return shortName;
			}
		}

		public IList<TypeOrNamespaceReference> Usings
		{
			get
			{
				if (usings == null)
				{
					usings = new List<TypeOrNamespaceReference>();
				}
				return usings;
			}
		}

		public IList<KeyValuePair<string, TypeOrNamespaceReference>> UsingAliases
		{
			get
			{
				if (usingAliases == null)
				{
					usingAliases = new List<KeyValuePair<string, TypeOrNamespaceReference>>();
				}
				return usingAliases;
			}
		}

		public IList<string> ExternAliases
		{
			get
			{
				if (externAliases == null)
				{
					externAliases = new List<string>();
				}
				return externAliases;
			}
		}

		protected override void FreezeInternal()
		{
			usings = FreezableHelper.FreezeList(usings);
			usingAliases = FreezableHelper.FreezeList(usingAliases);
			externAliases = FreezableHelper.FreezeList(externAliases);
			if (parent != null)
			{
				parent.Freeze();
			}
			base.FreezeInternal();
		}

		public UsingScope()
		{
		}

		public UsingScope(UsingScope parent, string shortName)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			if (shortName == null)
			{
				throw new ArgumentNullException("shortName");
			}
			this.parent = parent;
			this.shortName = shortName;
		}

		public bool HasAlias(string identifier)
		{
			if (usingAliases != null)
			{
				foreach (KeyValuePair<string, TypeOrNamespaceReference> usingAlias in usingAliases)
				{
					if (usingAlias.Key == identifier)
					{
						return true;
					}
				}
			}
			if (externAliases != null)
			{
				return externAliases.Contains(identifier);
			}
			return false;
		}

		public ResolvedUsingScope Resolve(ICompilation compilation)
		{
			CacheManager cacheManager = compilation.CacheManager;
			ResolvedUsingScope resolvedUsingScope = cacheManager.GetShared(this) as ResolvedUsingScope;
			if (resolvedUsingScope == null)
			{
				CSharpTypeResolveContext context = new CSharpTypeResolveContext(compilation.MainAssembly, (parent != null) ? parent.Resolve(compilation) : null);
				resolvedUsingScope = (ResolvedUsingScope)cacheManager.GetOrAddShared(this, new ResolvedUsingScope(context, this));
			}
			return resolvedUsingScope;
		}
	}
}
