using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public sealed class VariableReference : ISymbolReference
{
	private ITypeReference variableTypeReference;

	private string name;

	private DomRegion region;

	private bool isConst;

	private object constantValue;

	public VariableReference(ITypeReference variableTypeReference, string name, DomRegion region, bool isConst, object constantValue)
	{
		if (variableTypeReference == null)
		{
			throw new ArgumentNullException("variableTypeReference");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		this.variableTypeReference = variableTypeReference;
		this.name = name;
		this.region = region;
		this.isConst = isConst;
		this.constantValue = constantValue;
	}

	public ISymbol Resolve(ITypeResolveContext context)
	{
		return new DefaultVariable(variableTypeReference.Resolve(context), name, region, isConst, constantValue);
	}
}
