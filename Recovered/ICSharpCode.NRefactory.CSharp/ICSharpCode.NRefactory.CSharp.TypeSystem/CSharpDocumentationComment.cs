using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	internal sealed class CSharpDocumentationComment : DocumentationComment
	{
		public CSharpDocumentationComment(ITextSource xmlDoc, ITypeResolveContext context)
			: base(xmlDoc, context)
		{
		}

		public override IEntity ResolveCref(string cref)
		{
			if (cref.Length > 2 && cref[1] == ':')
			{
				return base.ResolveCref(cref);
			}
			DocumentationReference documentationReference = new CSharpParser().ParseDocumentationReference(cref);
			CSharpTypeResolveContext cSharpTypeResolveContext = context as CSharpTypeResolveContext;
			CSharpResolver resolver = (cSharpTypeResolveContext == null) ? new CSharpResolver(context.Compilation) : new CSharpResolver(cSharpTypeResolveContext);
			ResolveResult resolveResult = new CSharpAstResolver(resolver, documentationReference).Resolve(documentationReference);
			MemberResolveResult memberResolveResult = resolveResult as MemberResolveResult;
			if (memberResolveResult != null)
			{
				return memberResolveResult.Member;
			}
			return (resolveResult as TypeResolveResult)?.Type.GetDefinition();
		}
	}
}
