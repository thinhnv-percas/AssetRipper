using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	public sealed class CSharpTypeResolveContext : ITypeResolveContext, ICompilationProvider
	{
		private readonly IAssembly assembly;

		private readonly ResolvedUsingScope currentUsingScope;

		private readonly ITypeDefinition currentTypeDefinition;

		private readonly IMember currentMember;

		private readonly string[] methodTypeParameterNames;

		public ResolvedUsingScope CurrentUsingScope => currentUsingScope;

		public ICompilation Compilation => assembly.Compilation;

		public IAssembly CurrentAssembly => assembly;

		public ITypeDefinition CurrentTypeDefinition => currentTypeDefinition;

		public IMember CurrentMember => currentMember;

		public CSharpTypeResolveContext(IAssembly assembly, ResolvedUsingScope usingScope = null, ITypeDefinition typeDefinition = null, IMember member = null)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			this.assembly = assembly;
			currentUsingScope = usingScope;
			currentTypeDefinition = typeDefinition;
			currentMember = member;
		}

		private CSharpTypeResolveContext(IAssembly assembly, ResolvedUsingScope usingScope, ITypeDefinition typeDefinition, IMember member, string[] methodTypeParameterNames)
		{
			this.assembly = assembly;
			currentUsingScope = usingScope;
			currentTypeDefinition = typeDefinition;
			currentMember = member;
			this.methodTypeParameterNames = methodTypeParameterNames;
		}

		public CSharpTypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
		{
			return new CSharpTypeResolveContext(assembly, currentUsingScope, typeDefinition, currentMember, methodTypeParameterNames);
		}

		ITypeResolveContext ITypeResolveContext.WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
		{
			return WithCurrentTypeDefinition(typeDefinition);
		}

		public CSharpTypeResolveContext WithCurrentMember(IMember member)
		{
			return new CSharpTypeResolveContext(assembly, currentUsingScope, currentTypeDefinition, member, methodTypeParameterNames);
		}

		ITypeResolveContext ITypeResolveContext.WithCurrentMember(IMember member)
		{
			return WithCurrentMember(member);
		}

		public CSharpTypeResolveContext WithUsingScope(ResolvedUsingScope usingScope)
		{
			return new CSharpTypeResolveContext(assembly, usingScope, currentTypeDefinition, currentMember, methodTypeParameterNames);
		}
	}
}
