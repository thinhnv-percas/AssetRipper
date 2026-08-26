using System;

namespace DecompTools.Decompiler.TypeSystem;

public class SimpleTypeResolveContext : ITypeResolveContext, ICompilationProvider
{
	private readonly ICompilation compilation;

	private readonly IModule currentModule;

	private readonly ITypeDefinition currentTypeDefinition;

	private readonly IMember currentMember;

	public ICompilation Compilation => compilation;

	public IModule CurrentModule => currentModule;

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

	public SimpleTypeResolveContext(IModule module)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		compilation = module.Compilation;
		currentModule = module;
	}

	public SimpleTypeResolveContext(IEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		compilation = entity.Compilation;
		currentModule = entity.ParentModule;
		currentTypeDefinition = (entity as ITypeDefinition) ?? entity.DeclaringTypeDefinition;
		currentMember = entity as IMember;
	}

	private SimpleTypeResolveContext(ICompilation compilation, IModule currentModule, ITypeDefinition currentTypeDefinition, IMember currentMember)
	{
		this.compilation = compilation;
		this.currentModule = currentModule;
		this.currentTypeDefinition = currentTypeDefinition;
		this.currentMember = currentMember;
	}

	public ITypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
	{
		return new SimpleTypeResolveContext(compilation, currentModule, typeDefinition, currentMember);
	}

	public ITypeResolveContext WithCurrentMember(IMember member)
	{
		return new SimpleTypeResolveContext(compilation, currentModule, currentTypeDefinition, member);
	}
}
