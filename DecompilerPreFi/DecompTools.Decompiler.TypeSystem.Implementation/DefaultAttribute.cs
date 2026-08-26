using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class DefaultAttribute : IAttribute
{
	private readonly IType attributeType;

	private volatile IMethod constructor;

	public ImmutableArray<CustomAttributeTypedArgument<IType>> FixedArguments { get; }

	public ImmutableArray<CustomAttributeNamedArgument<IType>> NamedArguments { get; }

	public IType AttributeType => attributeType;

	bool IAttribute.HasDecodeErrors => false;

	public IMethod Constructor
	{
		get
		{
			IMethod method = constructor;
			if (method == null)
			{
				foreach (IMethod constructor in AttributeType.GetConstructors((IMethod m) => m.Parameters.Count == FixedArguments.Length))
				{
					if (Enumerable.SequenceEqual<IType>(Enumerable.Select<IParameter, IType>((IEnumerable<IParameter>)constructor.Parameters, (Func<IParameter, IType>)((IParameter p) => p.Type)), FixedArguments.Select((CustomAttributeTypedArgument<IType> a) => a.Type)))
					{
						method = constructor;
						break;
					}
				}
				this.constructor = method;
			}
			return method;
		}
	}

	public DefaultAttribute(IType attributeType, ImmutableArray<CustomAttributeTypedArgument<IType>> fixedArguments, ImmutableArray<CustomAttributeNamedArgument<IType>> namedArguments)
	{
		if (attributeType == null)
		{
			throw new ArgumentNullException("attributeType");
		}
		this.attributeType = attributeType;
		FixedArguments = fixedArguments;
		NamedArguments = namedArguments;
	}

	public DefaultAttribute(IMethod constructor, ImmutableArray<CustomAttributeTypedArgument<IType>> fixedArguments, ImmutableArray<CustomAttributeNamedArgument<IType>> namedArguments)
	{
		if (constructor == null)
		{
			throw new ArgumentNullException("constructor");
		}
		this.constructor = constructor;
		attributeType = constructor.DeclaringType ?? SpecialType.UnknownType;
		FixedArguments = fixedArguments;
		NamedArguments = namedArguments;
		if (fixedArguments.Length != constructor.Parameters.Count)
		{
			throw new ArgumentException("Positional argument count must match the constructor's parameter count");
		}
	}
}
