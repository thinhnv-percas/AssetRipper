using ICSharpCode.NRefactory.Documentation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public abstract class AbstractResolvedEntity : IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		protected readonly IUnresolvedEntity unresolved;

		protected readonly ITypeResolveContext parentContext;

		public SymbolKind SymbolKind => unresolved.SymbolKind;

		[Obsolete("Use the SymbolKind property instead.")]
		public EntityType EntityType => (EntityType)unresolved.SymbolKind;

		public DomRegion Region => unresolved.Region;

		public DomRegion BodyRegion => unresolved.BodyRegion;

		public ITypeDefinition DeclaringTypeDefinition => parentContext.CurrentTypeDefinition;

		public virtual IType DeclaringType => parentContext.CurrentTypeDefinition;

		public IAssembly ParentAssembly => parentContext.CurrentAssembly;

		public IList<IAttribute> Attributes
		{
			get;
			protected set;
		}

		public virtual DocumentationComment Documentation => FindDocumentation(parentContext)?.GetDocumentation(this);

		public bool IsStatic => unresolved.IsStatic;

		public bool IsAbstract => unresolved.IsAbstract;

		public bool IsSealed => unresolved.IsSealed;

		public bool IsShadowing => unresolved.IsShadowing;

		public bool IsSynthetic => unresolved.IsSynthetic;

		public ICompilation Compilation => parentContext.Compilation;

		public string FullName => unresolved.FullName;

		public string Name => unresolved.Name;

		public string ReflectionName => unresolved.ReflectionName;

		public string Namespace => unresolved.Namespace;

		public virtual Accessibility Accessibility => unresolved.Accessibility;

		public bool IsPrivate => Accessibility == Accessibility.Private;

		public bool IsPublic => Accessibility == Accessibility.Public;

		public bool IsProtected => Accessibility == Accessibility.Protected;

		public bool IsInternal => Accessibility == Accessibility.Internal;

		public bool IsProtectedOrInternal => Accessibility == Accessibility.ProtectedOrInternal;

		public bool IsProtectedAndInternal => Accessibility == Accessibility.ProtectedAndInternal;

		protected AbstractResolvedEntity(IUnresolvedEntity unresolved, ITypeResolveContext parentContext)
		{
			if (unresolved == null)
			{
				throw new ArgumentNullException("unresolved");
			}
			if (parentContext == null)
			{
				throw new ArgumentNullException("parentContext");
			}
			this.unresolved = unresolved;
			this.parentContext = parentContext;
			Attributes = unresolved.Attributes.CreateResolvedAttributes(parentContext);
		}

		internal static IDocumentationProvider FindDocumentation(ITypeResolveContext context)
		{
			IAssembly currentAssembly = context.CurrentAssembly;
			if (currentAssembly != null)
			{
				return currentAssembly.UnresolvedAssembly as IDocumentationProvider;
			}
			return null;
		}

		public abstract ISymbolReference ToReference();

		public override string ToString()
		{
			return "[" + SymbolKind.ToString() + " " + ReflectionName + "]";
		}
	}
}
