using System;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem;

[Serializable]
public abstract class TypeOrNamespaceReference : ITypeReference
{
	public abstract ResolveResult Resolve(CSharpResolver resolver);

	public abstract IType ResolveType(CSharpResolver resolver);

	public INamespace ResolveNamespace(CSharpResolver resolver)
	{
		if (!(Resolve(resolver) is NamespaceResolveResult namespaceResolveResult))
		{
			return null;
		}
		return namespaceResolveResult.Namespace;
	}

	IType ITypeReference.Resolve(ITypeResolveContext context)
	{
		CSharpTypeResolveContext cSharpTypeResolveContext = context as CSharpTypeResolveContext;
		if (cSharpTypeResolveContext == null)
		{
			cSharpTypeResolveContext = new CSharpTypeResolveContext(context.CurrentAssembly ?? context.Compilation.MainAssembly, null, context.CurrentTypeDefinition, context.CurrentMember);
		}
		return ResolveType(new CSharpResolver(cSharpTypeResolveContext));
	}
}
