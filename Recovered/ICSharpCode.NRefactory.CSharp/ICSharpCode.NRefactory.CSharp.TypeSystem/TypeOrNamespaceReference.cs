using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	public abstract class TypeOrNamespaceReference : ITypeReference
	{
		public abstract ResolveResult Resolve(CSharpResolver resolver);

		public abstract IType ResolveType(CSharpResolver resolver);

		public INamespace ResolveNamespace(CSharpResolver resolver)
		{
			return (Resolve(resolver) as NamespaceResolveResult)?.Namespace;
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
}
