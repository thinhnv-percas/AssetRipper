using System.Reflection.Metadata;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal static class DecimalConstantHelper
{
	public static bool AllowsDecimalConstants(MetadataModule module)
	{
		return (module.TypeSystemOptions & TypeSystemOptions.DecimalConstants) == TypeSystemOptions.DecimalConstants;
	}

	public static bool IsDecimalConstant(MetadataModule module, CustomAttributeHandleCollection attributeHandles)
	{
		return attributeHandles.HasKnownAttribute(module.metadata, KnownAttribute.DecimalConstant);
	}

	public static object GetDecimalConstantValue(MetadataModule module, CustomAttributeHandleCollection attributeHandles)
	{
		MetadataReader metadata = module.metadata;
		foreach (CustomAttributeHandle item in attributeHandles)
		{
			System.Reflection.Metadata.CustomAttribute customAttribute = metadata.GetCustomAttribute(item);
			if (customAttribute.IsKnownAttribute(metadata, KnownAttribute.DecimalConstant))
			{
				return TryDecodeDecimalConstantAttribute(module, customAttribute);
			}
		}
		return null;
	}

	private static decimal? TryDecodeDecimalConstantAttribute(MetadataModule module, System.Reflection.Metadata.CustomAttribute attribute)
	{
		CustomAttributeValue<IType> customAttributeValue = attribute.DecodeValue(module.TypeProvider);
		if (customAttributeValue.FixedArguments.Length != 5)
		{
			return null;
		}
		if (customAttributeValue.FixedArguments[0].Value is byte scale)
		{
			object value;
			byte b = default(byte);
			int num;
			if ((value = customAttributeValue.FixedArguments[1].Value) is byte)
			{
				b = (byte)value;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				if (customAttributeValue.FixedArguments[2].Value is uint hi && customAttributeValue.FixedArguments[3].Value is uint mid && customAttributeValue.FixedArguments[4].Value is uint lo)
				{
					return new decimal((int)lo, (int)mid, (int)hi, b != 0, scale);
				}
				if (customAttributeValue.FixedArguments[2].Value is int hi2 && customAttributeValue.FixedArguments[3].Value is int mid2 && customAttributeValue.FixedArguments[4].Value is int lo2)
				{
					return new decimal(lo2, mid2, hi2, b != 0, scale);
				}
				return null;
			}
		}
		return null;
	}
}
