using System;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.TypeSystem;

public sealed class CSharpTypeResolveContext : ITypeResolveContext, ICompilationProvider
{
	private readonly IModule module;

	private readonly ResolvedUsingScope currentUsingScope;

	private readonly ITypeDefinition currentTypeDefinition;

	private readonly IMember currentMember;

	private readonly string[] methodTypeParameterNames;

	public ResolvedUsingScope CurrentUsingScope => currentUsingScope;

	public ICompilation Compilation => module.Compilation;

	public IModule CurrentModule => module;

	public ITypeDefinition CurrentTypeDefinition => currentTypeDefinition;

	public IMember CurrentMember => currentMember;

	public CSharpTypeResolveContext(IModule module, ResolvedUsingScope usingScope = null, ITypeDefinition typeDefinition = null, IMember member = null)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		this.module = module;
		currentUsingScope = usingScope;
		currentTypeDefinition = typeDefinition;
		currentMember = member;
	}

	private CSharpTypeResolveContext(IModule module, ResolvedUsingScope usingScope, ITypeDefinition typeDefinition, IMember member, string[] methodTypeParameterNames)
	{
		this.module = module;
		currentUsingScope = usingScope;
		currentTypeDefinition = typeDefinition;
		currentMember = member;
		this.methodTypeParameterNames = methodTypeParameterNames;
	}

	public CSharpTypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
	{
		return new CSharpTypeResolveContext(module, currentUsingScope, typeDefinition, currentMember, methodTypeParameterNames);
	}

	ITypeResolveContext ITypeResolveContext.WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
	{
		return WithCurrentTypeDefinition(typeDefinition);
	}

	public CSharpTypeResolveContext WithCurrentMember(IMember member)
	{
		return new CSharpTypeResolveContext(module, currentUsingScope, currentTypeDefinition, member, methodTypeParameterNames);
	}

	ITypeResolveContext ITypeResolveContext.WithCurrentMember(IMember member)
	{
		return WithCurrentMember(member);
	}

	public CSharpTypeResolveContext WithUsingScope(ResolvedUsingScope usingScope)
	{
		return new CSharpTypeResolveContext(module, usingScope, currentTypeDefinition, currentMember, methodTypeParameterNames);
	}
}
