using System;
using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public sealed class DefaultParameter : IParameter, IVariable, ISymbol
{
	private readonly IType type;

	private readonly string name;

	private readonly DomRegion region;

	private readonly IList<IAttribute> attributes;

	private readonly bool isIn;

	private readonly bool isRef;

	private readonly bool isOut;

	private readonly bool isParams;

	private readonly bool isOptional;

	private readonly object defaultValue;

	private readonly IParameterizedMember owner;

	SymbolKind ISymbol.SymbolKind => SymbolKind.Parameter;

	public IParameterizedMember Owner => owner;

	public IList<IAttribute> Attributes => attributes;

	public bool IsIn => isIn;

	public bool IsRef => isRef;

	public bool IsOut => isOut;

	public bool IsParams => isParams;

	public bool IsOptional => isOptional;

	public string Name => name;

	public DomRegion Region => region;

	public IType Type => type;

	bool IVariable.IsConst => false;

	public object ConstantValue => defaultValue;

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
	}

	public DefaultParameter(IType type, string name, IParameterizedMember owner = null, DomRegion region = default(DomRegion), IList<IAttribute> attributes = null, bool isRef = false, bool isOut = false, bool isParams = false, bool isOptional = false, object defaultValue = null, bool isIn = false)
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
		this.region = region;
		this.attributes = attributes;
		this.isIn = isIn;
		this.isRef = isRef;
		this.isOut = isOut;
		this.isParams = isParams;
		this.isOptional = isOptional;
		this.defaultValue = defaultValue;
	}

	public override string ToString()
	{
		return ToString(this);
	}

	public static string ToString(IParameter parameter)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (parameter.IsIn)
		{
			stringBuilder.Append("in ");
		}
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
		if (parameter.IsOptional)
		{
			stringBuilder.Append(" = ");
			if (parameter.ConstantValue != null)
			{
				stringBuilder.Append(parameter.ConstantValue.ToString());
			}
			else
			{
				stringBuilder.Append("null");
			}
		}
		return stringBuilder.ToString();
	}

	public ISymbolReference ToReference()
	{
		if (owner == null)
		{
			return new ParameterReference(type.ToTypeReference(), name, region, isRef, isOut, isParams, isOptional, defaultValue, isIn);
		}
		return new OwnedParameterReference(owner.ToReference(), owner.Parameters.IndexOf(this));
	}
}
