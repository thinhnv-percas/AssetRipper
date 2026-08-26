using System;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class TypeOfConstantExpression : ConstantExpression
{
	private readonly ITypeReference type;

	public ITypeReference Type => type;

	public TypeOfConstantExpression(ITypeReference type)
	{
		this.type = type;
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		return resolver.ResolveTypeOf(type.Resolve(resolver.CurrentTypeResolveContext));
	}
}
