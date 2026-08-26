using System;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;

[Serializable]
public sealed class ErrorConstantValue : IConstantValue
{
	private readonly ITypeReference type;

	public ErrorConstantValue(ITypeReference type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		this.type = type;
	}

	public ResolveResult Resolve(ITypeResolveContext context)
	{
		return new ErrorResolveResult(type.Resolve(context));
	}
}
