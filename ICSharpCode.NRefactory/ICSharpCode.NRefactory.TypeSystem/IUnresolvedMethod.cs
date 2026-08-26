using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedMethod : IUnresolvedParameterizedMember, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
{
	IList<IUnresolvedAttribute> ReturnTypeAttributes { get; }

	IList<IUnresolvedTypeParameter> TypeParameters { get; }

	bool IsConstructor { get; }

	bool IsDestructor { get; }

	bool IsOperator { get; }

	bool IsPartial { get; }

	bool IsAsync { get; }

	[Obsolete("Use IsPartial && !HasBody instead")]
	bool IsPartialMethodDeclaration { get; }

	[Obsolete("Use IsPartial && HasBody instead")]
	bool IsPartialMethodImplementation { get; }

	bool HasBody { get; }

	IUnresolvedMember AccessorOwner { get; }

	new IMethod Resolve(ITypeResolveContext context);
}
