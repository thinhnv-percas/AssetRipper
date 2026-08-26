using System;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.TypeSystem;

[Serializable]
public abstract class TypeOrNamespaceReference : ITypeReference
{
	public abstract ResolveResult Resolve(CSharpResolver resolver);

	public abstract IType ResolveType(CSharpResolver resolver);

	public INamespace ResolveNamespace(CSharpResolver resolver)
	{
		return (Resolve(resolver) is NamespaceResolveResult namespaceResolveResult) ? namespaceResolveResult.Namespace : null;
	}

	IType ITypeReference.Resolve(ITypeResolveContext context)
	{
		CSharpTypeResolveContext cSharpTypeResolveContext = context as CSharpTypeResolveContext;
		if (cSharpTypeResolveContext == null)
		{
			cSharpTypeResolveContext = new CSharpTypeResolveContext(context.CurrentModule ?? context.Compilation.MainModule, null, context.CurrentTypeDefinition, context.CurrentMember);
		}
		return ResolveType(new CSharpResolver(cSharpTypeResolveContext));
	}
}
