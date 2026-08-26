using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class ConstantIdentifierReference : ConstantExpression
{
	private readonly string identifier;

	private readonly IList<ITypeReference> typeArguments;

	public ConstantIdentifierReference(string identifier, IList<ITypeReference> typeArguments = null)
	{
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		this.identifier = identifier;
		this.typeArguments = typeArguments ?? EmptyList<ITypeReference>.Instance;
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		return resolver.ResolveSimpleName(identifier, typeArguments.Resolve(resolver.CurrentTypeResolveContext));
	}
}
