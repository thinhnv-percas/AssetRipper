using System;
using System.Text;
using System.Threading;
using Mon3.Cecil.Metadata;
using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public sealed class GenericInstanceType : TypeSpecification, IGenericInstance, IMetadataTokenProvider, IGenericContext
{
	private Collection<TypeReference> arguments;

	public bool HasGenericArguments => !arguments.IsNullOrEmpty();

	public Collection<TypeReference> GenericArguments
	{
		get
		{
			if (arguments == null)
			{
				Interlocked.CompareExchange(ref arguments, new Collection<TypeReference>(), null);
			}
			return arguments;
		}
	}

	public override TypeReference DeclaringType
	{
		get
		{
			return base.ElementType.DeclaringType;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override string FullName
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.FullName);
			this.GenericInstanceFullName(stringBuilder);
			return stringBuilder.ToString();
		}
	}

	public override bool IsGenericInstance => true;

	public override bool ContainsGenericParameter
	{
		get
		{
			if (!this.ContainsGenericParameter())
			{
				return base.ContainsGenericParameter;
			}
			return true;
		}
	}

	IGenericParameterProvider IGenericContext.Type => base.ElementType;

	public GenericInstanceType(TypeReference type)
		: base(type)
	{
		base.IsValueType = type.IsValueType;
		etype = Mon3.Cecil.Metadata.ElementType.GenericInst;
	}

	internal GenericInstanceType(TypeReference type, int arity)
		: this(type)
	{
		arguments = new Collection<TypeReference>(arity);
	}
}
