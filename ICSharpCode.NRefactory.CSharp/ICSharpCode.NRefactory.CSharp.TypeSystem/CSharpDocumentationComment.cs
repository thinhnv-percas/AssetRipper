using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem;

internal sealed class CSharpDocumentationComment : DocumentationComment
{
	public CSharpDocumentationComment(string xmlDoc, ITypeResolveContext context)
		: base(xmlDoc, context)
	{
	}

	public override IEntity ResolveCref(string cref)
	{
		if (cref.Length > 2 && cref[1] == ':')
		{
			return base.ResolveCref(cref);
		}
		DocumentationReference documentationReference = new DocumentationReference();
		CSharpResolver resolver = ((!(context is CSharpTypeResolveContext cSharpTypeResolveContext)) ? new CSharpResolver(context.Compilation) : new CSharpResolver(cSharpTypeResolveContext));
		CSharpAstResolver cSharpAstResolver = new CSharpAstResolver(resolver, documentationReference);
		ResolveResult resolveResult = cSharpAstResolver.Resolve(documentationReference);
		if (resolveResult is MemberResolveResult memberResolveResult)
		{
			return memberResolveResult.Member;
		}
		if (resolveResult is TypeResolveResult typeResolveResult)
		{
			return typeResolveResult.Type.GetDefinition();
		}
		return null;
	}
}
