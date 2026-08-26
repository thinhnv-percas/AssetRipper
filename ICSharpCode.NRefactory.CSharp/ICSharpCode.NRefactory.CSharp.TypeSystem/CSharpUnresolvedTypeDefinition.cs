using System;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem;

[Serializable]
public class CSharpUnresolvedTypeDefinition : DefaultUnresolvedTypeDefinition
{
	private readonly UsingScope usingScope;

	public CSharpUnresolvedTypeDefinition(UsingScope usingScope, string name)
		: base(usingScope.NamespaceName, name)
	{
		this.usingScope = usingScope;
		base.AddDefaultConstructorIfRequired = true;
	}

	public CSharpUnresolvedTypeDefinition(CSharpUnresolvedTypeDefinition declaringTypeDefinition, string name)
		: base(declaringTypeDefinition, name)
	{
		usingScope = declaringTypeDefinition.usingScope;
		base.AddDefaultConstructorIfRequired = true;
	}

	public override ITypeResolveContext CreateResolveContext(ITypeResolveContext parentContext)
	{
		return new CSharpTypeResolveContext(parentContext.CurrentAssembly, usingScope.Resolve(parentContext.Compilation), parentContext.CurrentTypeDefinition);
	}
}
