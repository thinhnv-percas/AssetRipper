using System;
using System.Collections.Generic;
using System.Text;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class DefaultParameter : IParameter, IVariable, ISymbol
{
	private readonly IType type;

	private readonly string name;

	private readonly IReadOnlyList<IAttribute> attributes;

	private readonly bool isRef;

	private readonly bool isOut;

	private readonly bool isIn;

	private readonly bool isParams;

	private readonly bool isOptional;

	private readonly object defaultValue;

	private readonly IParameterizedMember owner;

	SymbolKind ISymbol.SymbolKind => SymbolKind.Parameter;

	public IParameterizedMember Owner => owner;

	public bool IsRef => isRef;

	public bool IsOut => isOut;

	public bool IsIn => isIn;

	public bool IsParams => isParams;

	public bool IsOptional => isOptional;

	public string Name => name;

	public IType Type => type;

	bool IVariable.IsConst => false;

	public bool HasConstantValueInSignature => IsOptional;

	public DefaultParameter(IType type, string name)
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
		attributes = EmptyList<IAttribute>.Instance;
	}

	public DefaultParameter(IType type, string name, IParameterizedMember owner = null, IReadOnlyList<IAttribute> attributes = null, bool isRef = false, bool isOut = false, bool isIn = false, bool isParams = false, bool isOptional = false, object defaultValue = null)
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
		this.owner = owner;
		this.attributes = attributes ?? EmptyList<IAttribute>.Instance;
		this.isRef = isRef;
		this.isOut = isOut;
		this.isIn = isIn;
		this.isParams = isParams;
		this.isOptional = isOptional;
		this.defaultValue = defaultValue;
	}

	public IEnumerable<IAttribute> GetAttributes()
	{
		return attributes;
	}

	public object GetConstantValue(bool throwOnInvalidMetadata)
	{
		return defaultValue;
	}

	public override string ToString()
	{
		return ToString(this);
	}

	public static string ToString(IParameter parameter)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (parameter.IsRef)
		{
			stringBuilder.Append("ref ");
		}
		if (parameter.IsOut)
		{
			stringBuilder.Append("out ");
		}
		if (parameter.IsParams)
		{
			stringBuilder.Append("params ");
		}
		stringBuilder.Append(parameter.Name);
		stringBuilder.Append(':');
		stringBuilder.Append(parameter.Type.ReflectionName);
		if (parameter.IsOptional && parameter.HasConstantValueInSignature)
		{
			stringBuilder.Append(" = ");
			object constantValue = parameter.GetConstantValue();
			if (constantValue != null)
			{
				stringBuilder.Append(constantValue.ToString());
			}
			else
			{
				stringBuilder.Append("null");
			}
		}
		return stringBuilder.ToString();
	}
}
