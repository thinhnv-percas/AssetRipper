using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataParameter : IParameter, IVariable, ISymbol
{
	private readonly MetadataModule module;

	private readonly ParameterHandle handle;

	private readonly ParameterAttributes attributes;

	private string name;

	private byte constantValueInSignatureState;

	private byte decimalConstantState;

	private const ParameterAttributes inOut = ParameterAttributes.In | ParameterAttributes.Out;

	public IType Type { get; }

	public IParameterizedMember Owner { get; }

	public EntityHandle MetadataToken => handle;

	public bool IsRef
	{
		get
		{
			if (Type.Kind != TypeKind.ByReference || (attributes & (ParameterAttributes.In | ParameterAttributes.Out)) == ParameterAttributes.Out)
			{
				return false;
			}
			if ((module.TypeSystemOptions & TypeSystemOptions.ReadOnlyStructsAndParameters) == 0)
			{
				return true;
			}
			MetadataReader metadata = module.metadata;
			return !metadata.GetParameter(handle).GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.IsReadOnly);
		}
	}

	public bool IsOut => Type.Kind == TypeKind.ByReference && (attributes & (ParameterAttributes.In | ParameterAttributes.Out)) == ParameterAttributes.Out;

	public bool IsOptional => (attributes & ParameterAttributes.Optional) != 0;

	public bool IsIn
	{
		get
		{
			if ((module.TypeSystemOptions & TypeSystemOptions.ReadOnlyStructsAndParameters) == 0 || Type.Kind != TypeKind.ByReference || (attributes & (ParameterAttributes.In | ParameterAttributes.Out)) != ParameterAttributes.In)
			{
				return false;
			}
			MetadataReader metadata = module.metadata;
			return metadata.GetParameter(handle).GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.IsReadOnly);
		}
	}

	public bool IsParams
	{
		get
		{
			if (Type.Kind != TypeKind.Array)
			{
				return false;
			}
			MetadataReader metadata = module.metadata;
			return metadata.GetParameter(handle).GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.ParamArray);
		}
	}

	public string Name
	{
		get
		{
			string text = LazyInit.VolatileRead(ref name);
			if (text != null)
			{
				return text;
			}
			MetadataReader metadata = module.metadata;
			Parameter parameter = metadata.GetParameter(handle);
			return LazyInit.GetOrSet(ref name, metadata.GetString(parameter.Name));
		}
	}

	bool IVariable.IsConst => false;

	public bool HasConstantValueInSignature
	{
		get
		{
			if (constantValueInSignatureState == 0)
			{
				if (IsDecimalConstant)
				{
					constantValueInSignatureState = ThreeState.From(DecimalConstantHelper.AllowsDecimalConstants(module));
				}
				else
				{
					constantValueInSignatureState = ThreeState.From(!module.metadata.GetParameter(handle).GetDefaultValue().IsNil);
				}
			}
			return constantValueInSignatureState == 2;
		}
	}

	private bool IsDecimalConstant
	{
		get
		{
			if (decimalConstantState == 0)
			{
				Parameter parameter = module.metadata.GetParameter(handle);
				decimalConstantState = ThreeState.From(DecimalConstantHelper.IsDecimalConstant(module, parameter.GetCustomAttributes()));
			}
			return decimalConstantState == 2;
		}
	}

	SymbolKind ISymbol.SymbolKind => SymbolKind.Parameter;

	internal MetadataParameter(MetadataModule module, IParameterizedMember owner, IType type, ParameterHandle handle)
	{
		this.module = module;
		Owner = owner;
		Type = type;
		this.handle = handle;
		attributes = module.metadata.GetParameter(handle).Attributes;
		if (!IsOptional)
		{
			decimalConstantState = 1;
		}
	}

	public IEnumerable<IAttribute> GetAttributes()
	{
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module);
		MetadataReader metadata = module.metadata;
		Parameter parameter = metadata.GetParameter(handle);
		if (IsOptional && !HasConstantValueInSignature)
		{
			attributeListBuilder.Add(KnownAttribute.Optional);
		}
		if (!IsOut && !IsIn)
		{
			if ((attributes & ParameterAttributes.In) == ParameterAttributes.In)
			{
				attributeListBuilder.Add(KnownAttribute.In);
			}
			if ((attributes & ParameterAttributes.Out) == ParameterAttributes.Out)
			{
				attributeListBuilder.Add(KnownAttribute.Out);
			}
		}
		attributeListBuilder.Add(parameter.GetCustomAttributes(), SymbolKind.Parameter);
		attributeListBuilder.AddMarshalInfo(parameter.GetMarshallingDescriptor());
		return attributeListBuilder.Build();
	}

	public object GetConstantValue(bool throwOnInvalidMetadata)
	{
		try
		{
			MetadataReader metadata = module.metadata;
			Parameter parameter = metadata.GetParameter(handle);
			if (IsDecimalConstant)
			{
				return DecimalConstantHelper.GetDecimalConstantValue(module, parameter.GetCustomAttributes());
			}
			ConstantHandle defaultValue = parameter.GetDefaultValue();
			if (defaultValue.IsNil)
			{
				return null;
			}
			Constant constant = metadata.GetConstant(defaultValue);
			BlobReader blobReader = metadata.GetBlobReader(constant.Value);
			try
			{
				return blobReader.ReadConstant(constant.TypeCode);
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new BadImageFormatException($"Constant with invalid typecode: {constant.TypeCode}");
			}
		}
		catch (BadImageFormatException) when (!throwOnInvalidMetadata)
		{
			return null;
		}
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(handle):X8} {DefaultParameter.ToString(this)}";
	}
}
