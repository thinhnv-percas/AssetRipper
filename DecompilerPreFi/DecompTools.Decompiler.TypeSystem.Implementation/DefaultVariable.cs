using System;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class DefaultVariable : IVariable, ISymbol
{
	private readonly string name;

	private readonly IType type;

	private readonly object constantValue;

	private readonly bool isConst;

	public string Name => name;

	public IType Type => type;

	public bool IsConst => isConst;

	public SymbolKind SymbolKind => SymbolKind.Variable;

	public DefaultVariable(IType type, string name)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		this.type = type;
		this.name = name;
	}

	public DefaultVariable(IType type, string name, bool isConst = false, object constantValue = null)
		: this(type, name)
	{
		this.isConst = isConst;
		this.constantValue = constantValue;
	}

	public object GetConstantValue(bool throwOnInvalidMetadata)
	{
		return constantValue;
	}
}
