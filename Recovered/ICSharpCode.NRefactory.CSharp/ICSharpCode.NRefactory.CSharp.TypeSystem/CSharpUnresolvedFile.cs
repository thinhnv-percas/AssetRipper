using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	[FastSerializerVersion(2)]
	public class CSharpUnresolvedFile : AbstractFreezable, IUnresolvedFile, IUnresolvedDocumentationProvider
	{
		private string fileName = string.Empty;

		private readonly UsingScope rootUsingScope = new UsingScope();

		private IList<IUnresolvedTypeDefinition> topLevelTypeDefinitions = new List<IUnresolvedTypeDefinition>();

		private IList<IUnresolvedAttribute> assemblyAttributes = new List<IUnresolvedAttribute>();

		private IList<IUnresolvedAttribute> moduleAttributes = new List<IUnresolvedAttribute>();

		private IList<UsingScope> usingScopes = new List<UsingScope>();

		private IList<Error> errors = new List<Error>();

		private Dictionary<IUnresolvedEntity, string> documentation;

		private DateTime? lastWriteTime;

		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				fileName = (value ?? string.Empty);
			}
		}

		public DateTime? LastWriteTime
		{
			get
			{
				return lastWriteTime;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				lastWriteTime = value;
			}
		}

		public UsingScope RootUsingScope => rootUsingScope;

		public IList<Error> Errors
		{
			get
			{
				return errors;
			}
			internal set
			{
				errors = (List<Error>)value;
			}
		}

		public IList<UsingScope> UsingScopes => usingScopes;

		public IList<IUnresolvedTypeDefinition> TopLevelTypeDefinitions => topLevelTypeDefinitions;

		public IList<IUnresolvedAttribute> AssemblyAttributes => assemblyAttributes;

		public IList<IUnresolvedAttribute> ModuleAttributes => moduleAttributes;

		protected override void FreezeInternal()
		{
			base.FreezeInternal();
			rootUsingScope.Freeze();
			topLevelTypeDefinitions = FreezableHelper.FreezeListAndElements(topLevelTypeDefinitions);
			assemblyAttributes = FreezableHelper.FreezeListAndElements(assemblyAttributes);
			moduleAttributes = FreezableHelper.FreezeListAndElements(moduleAttributes);
			usingScopes = FreezableHelper.FreezeListAndElements(usingScopes);
		}

		public void AddDocumentation(IUnresolvedEntity entity, string xmlDocumentation)
		{
			FreezableHelper.ThrowIfFrozen(this);
			if (documentation == null)
			{
				documentation = new Dictionary<IUnresolvedEntity, string>();
			}
			documentation.Add(entity, xmlDocumentation);
		}

		public UsingScope GetUsingScope(TextLocation location)
		{
			foreach (UsingScope usingScope in usingScopes)
			{
				if (usingScope.Region.IsInside(location.Line, location.Column))
				{
					return usingScope;
				}
			}
			return rootUsingScope;
		}

		public IUnresolvedTypeDefinition GetTopLevelTypeDefinition(TextLocation location)
		{
			return FindEntity(topLevelTypeDefinitions, location);
		}

		public IUnresolvedTypeDefinition GetInnermostTypeDefinition(TextLocation location)
		{
			IUnresolvedTypeDefinition unresolvedTypeDefinition = null;
			for (IUnresolvedTypeDefinition unresolvedTypeDefinition2 = GetTopLevelTypeDefinition(location); unresolvedTypeDefinition2 != null; unresolvedTypeDefinition2 = FindEntity(unresolvedTypeDefinition.NestedTypes, location))
			{
				unresolvedTypeDefinition = unresolvedTypeDefinition2;
			}
			return unresolvedTypeDefinition;
		}

		public IUnresolvedMember GetMember(TextLocation location)
		{
			IUnresolvedTypeDefinition innermostTypeDefinition = GetInnermostTypeDefinition(location);
			if (innermostTypeDefinition == null)
			{
				return null;
			}
			return FindEntity(innermostTypeDefinition.Members, location);
		}

		private static T FindEntity<T>(IList<T> list, TextLocation location) where T : class, IUnresolvedEntity
		{
			foreach (T item in list)
			{
				if (item.Region.IsInside(location.Line, location.Column))
				{
					return item;
				}
			}
			return null;
		}

		public CSharpTypeResolveContext GetTypeResolveContext(ICompilation compilation, TextLocation loc)
		{
			CSharpTypeResolveContext cSharpTypeResolveContext = new CSharpTypeResolveContext(compilation.MainAssembly);
			cSharpTypeResolveContext = cSharpTypeResolveContext.WithUsingScope(GetUsingScope(loc).Resolve(compilation));
			IUnresolvedTypeDefinition innermostTypeDefinition = GetInnermostTypeDefinition(loc);
			if (innermostTypeDefinition != null)
			{
				ITypeDefinition definition = innermostTypeDefinition.Resolve(cSharpTypeResolveContext).GetDefinition();
				if (definition == null)
				{
					return cSharpTypeResolveContext;
				}
				cSharpTypeResolveContext = cSharpTypeResolveContext.WithCurrentTypeDefinition(definition);
				IMember member = definition.Members.FirstOrDefault((IMember m) => m.Region.FileName == FileName && m.Region.Begin <= loc && loc < m.BodyRegion.End);
				if (member != null)
				{
					cSharpTypeResolveContext = cSharpTypeResolveContext.WithCurrentMember(member);
				}
			}
			return cSharpTypeResolveContext;
		}

		public CSharpResolver GetResolver(ICompilation compilation, TextLocation loc)
		{
			return new CSharpResolver(GetTypeResolveContext(compilation, loc));
		}

		public string GetDocumentation(IUnresolvedEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			if (documentation == null)
			{
				return null;
			}
			if (documentation.TryGetValue(entity, out string value))
			{
				return value;
			}
			return null;
		}

		public DocumentationComment GetDocumentation(IUnresolvedEntity entity, IEntity resolvedEntity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			if (resolvedEntity == null)
			{
				throw new ArgumentNullException("resolvedEntity");
			}
			string text = GetDocumentation(entity);
			if (text == null)
			{
				return null;
			}
			IUnresolvedTypeDefinition unresolvedTypeDefinition = (entity as IUnresolvedTypeDefinition) ?? entity.DeclaringTypeDefinition;
			ITypeDefinition typeDefinition = (resolvedEntity as ITypeDefinition) ?? resolvedEntity.DeclaringTypeDefinition;
			if (unresolvedTypeDefinition != null && typeDefinition != null)
			{
				ITypeResolveContext typeResolveContext = unresolvedTypeDefinition.CreateResolveContext(new SimpleTypeResolveContext(typeDefinition));
				if (resolvedEntity is IMember)
				{
					typeResolveContext = typeResolveContext.WithCurrentMember((IMember)resolvedEntity);
				}
				return new CSharpDocumentationComment(new StringTextSource(text), typeResolveContext);
			}
			return new DocumentationComment(new StringTextSource(text), new SimpleTypeResolveContext(resolvedEntity));
		}
	}
}
