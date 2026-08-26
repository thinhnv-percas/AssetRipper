using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public interface IParameter : IVariable, ISymbol
{
	bool IsRef { get; }

	bool IsOut { get; }

	bool IsIn { get; }

	bool IsParams { get; }

	bool IsOptional { get; }

	bool HasConstantValueInSignature { get; }

	IParameterizedMember Owner { get; }

	IEnumerable<IAttribute> GetAttributes();
}
