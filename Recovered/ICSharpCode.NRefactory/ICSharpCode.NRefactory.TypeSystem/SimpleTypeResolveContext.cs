using System;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public class SimpleTypeResolveContext : ITypeResolveContext, ICompilationProvider
	{
		private readonly ICompilation compilation;

		private readonly IAssembly currentAssembly;

		private readonly ITypeDefinition currentTypeDefinition;

		private readonly IMember currentMember;

		public ICompilation Compilation => compilation;

		public IAssembly CurrentAssembly => currentAssembly;

		public ITypeDefinition CurrentTypeDefinition => currentTypeDefinition;

		public IMember CurrentMember => currentMember;

		public SimpleTypeResolveContext(ICompilation compilation)
		{
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			this.compilation = compilation;
		}

		public SimpleTypeResolveContext(IAssembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			compilation = assembly.Compilation;
			currentAssembly = assembly;
		}

		public SimpleTypeResolveContext(IEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			compilation = entity.Compilation;
			currentAssembly = entity.ParentAssembly;
			currentTypeDefinition = ((entity as ITypeDefinition) ?? entity.DeclaringTypeDefinition);
			currentMember = (entity as IMember);
		}

		private SimpleTypeResolveContext(ICompilation compilation, IAssembly currentAssembly, ITypeDefinition currentTypeDefinition, IMember currentMember)
		{
			this.compilation = compilation;
			this.currentAssembly = currentAssembly;
			this.currentTypeDefinition = currentTypeDefinition;
			this.currentMember = currentMember;
		}

		public ITypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
		{
			return new SimpleTypeResolveContext(compilation, currentAssembly, typeDefinition, currentMember);
		}

		public ITypeResolveContext WithCurrentMember(IMember member)
		{
			return new SimpleTypeResolveContext(compilation, currentAssembly, currentTypeDefinition, member);
		}
	}
}
