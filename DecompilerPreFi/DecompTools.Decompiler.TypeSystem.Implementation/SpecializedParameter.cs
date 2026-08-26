#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class SpecializedParameter : IParameter, IVariable, ISymbol
{
	private readonly IParameter baseParameter;

	private readonly IType newType;

	private readonly IParameterizedMember newOwner;

	bool IParameter.IsRef => baseParameter.IsRef;

	bool IParameter.IsOut => baseParameter.IsOut;

	bool IParameter.IsIn => baseParameter.IsIn;

	bool IParameter.IsParams => baseParameter.IsParams;

	bool IParameter.IsOptional => baseParameter.IsOptional;

	bool IParameter.HasConstantValueInSignature => baseParameter.HasConstantValueInSignature;

	IParameterizedMember IParameter.Owner => newOwner;

	string IVariable.Name => baseParameter.Name;

	string ISymbol.Name => baseParameter.Name;

	IType IVariable.Type => newType;

	bool IVariable.IsConst => baseParameter.IsConst;

	SymbolKind ISymbol.SymbolKind => SymbolKind.Parameter;

	public SpecializedParameter(IParameter baseParameter, IType newType, IParameterizedMember newOwner)
	{
		Debug.Assert(baseParameter != null && newType != null);
		this.baseParameter = baseParameter;
		this.newType = newType;
		this.newOwner = newOwner;
	}

	IEnumerable<IAttribute> IParameter.GetAttributes()
	{
		return baseParameter.GetAttributes();
	}

	object IVariable.GetConstantValue(bool throwOnInvalidMetadata)
	{
		return baseParameter.GetConstantValue(throwOnInvalidMetadata);
	}

	public override string ToString()
	{
		return DefaultParameter.ToString(this);
	}
}
