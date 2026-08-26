#define DEBUG
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Metadata;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class CustomAttribute : IAttribute
{
	private readonly MetadataModule module;

	private readonly CustomAttributeHandle handle;

	private CustomAttributeValue<IType> value;

	private bool valueDecoded;

	private bool hasDecodeErrors;

	public IMethod Constructor { get; }

	public IType AttributeType => Constructor.DeclaringType;

	public ImmutableArray<CustomAttributeTypedArgument<IType>> FixedArguments
	{
		get
		{
			DecodeValue();
			return value.FixedArguments;
		}
	}

	public ImmutableArray<CustomAttributeNamedArgument<IType>> NamedArguments
	{
		get
		{
			DecodeValue();
			return value.NamedArguments;
		}
	}

	public bool HasDecodeErrors
	{
		get
		{
			DecodeValue();
			return hasDecodeErrors;
		}
	}

	internal CustomAttribute(MetadataModule module, IMethod attrCtor, CustomAttributeHandle handle)
	{
		Debug.Assert(module != null);
		Debug.Assert(attrCtor != null);
		Debug.Assert(!handle.IsNil);
		this.module = module;
		Constructor = attrCtor;
		this.handle = handle;
	}

	private void DecodeValue()
	{
		lock (this)
		{
			try
			{
				if (!valueDecoded)
				{
					MetadataReader metadata = module.metadata;
					value = metadata.GetCustomAttribute(handle).DecodeValue(module.TypeProvider);
					valueDecoded = true;
				}
			}
			catch (EnumUnderlyingTypeResolveException)
			{
				value = new CustomAttributeValue<IType>(ImmutableArray<CustomAttributeTypedArgument<IType>>.Empty, ImmutableArray<CustomAttributeNamedArgument<IType>>.Empty);
				hasDecodeErrors = true;
				valueDecoded = true;
			}
			catch (BadImageFormatException)
			{
				value = new CustomAttributeValue<IType>(ImmutableArray<CustomAttributeTypedArgument<IType>>.Empty, ImmutableArray<CustomAttributeNamedArgument<IType>>.Empty);
				hasDecodeErrors = true;
				valueDecoded = true;
			}
		}
	}

	internal static IMember MemberForNamedArgument(IType attributeType, CustomAttributeNamedArgument<IType> namedArgument)
	{
		return namedArgument.Kind switch
		{
			CustomAttributeNamedArgumentKind.Field => Enumerable.LastOrDefault<IField>(attributeType.GetFields((IField f) => f.Name == namedArgument.Name)), 
			CustomAttributeNamedArgumentKind.Property => Enumerable.LastOrDefault<IProperty>(attributeType.GetProperties((IProperty p) => p.Name == namedArgument.Name)), 
			_ => null, 
		};
	}
}
