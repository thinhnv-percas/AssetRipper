using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IUnresolvedMember : IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
	{
		ITypeReference ReturnType
		{
			get;
		}

		bool IsExplicitInterfaceImplementation
		{
			get;
		}

		IList<IMemberReference> ExplicitInterfaceImplementations
		{
			get;
		}

		bool IsVirtual
		{
			get;
		}

		bool IsOverride
		{
			get;
		}

		bool IsOverridable
		{
			get;
		}

		new IMember Resolve(ITypeResolveContext context);

		IMember CreateResolved(ITypeResolveContext context);
	}
}
