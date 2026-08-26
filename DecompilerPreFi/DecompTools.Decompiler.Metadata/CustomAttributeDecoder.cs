using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.Metadata;

internal readonly struct CustomAttributeDecoder<TType>
{
	private struct ArgumentTypeInfo
	{
		public TType Type;

		public TType ElementType;

		public SerializationTypeCode TypeCode;

		public SerializationTypeCode ElementTypeCode;
	}

	private readonly ICustomAttributeTypeProvider<TType> _provider;

	private readonly MetadataReader _reader;

	private readonly bool _provideBoxingTypeInfo;

	public CustomAttributeDecoder(ICustomAttributeTypeProvider<TType> provider, MetadataReader reader, bool provideBoxingTypeInfo = false)
	{
		_reader = reader;
		_provider = provider;
		_provideBoxingTypeInfo = provideBoxingTypeInfo;
	}

	public ImmutableArray<CustomAttributeNamedArgument<TType>> DecodeNamedArguments(ref BlobReader valueReader, int count)
	{
		ImmutableArray<CustomAttributeNamedArgument<TType>>.Builder builder = ImmutableArray.CreateBuilder<CustomAttributeNamedArgument<TType>>(count);
		for (int i = 0; i < count; i = checked(i + 1))
		{
			CustomAttributeNamedArgumentKind customAttributeNamedArgumentKind = (CustomAttributeNamedArgumentKind)valueReader.ReadSerializationTypeCode();
			if (customAttributeNamedArgumentKind != CustomAttributeNamedArgumentKind.Field && customAttributeNamedArgumentKind != CustomAttributeNamedArgumentKind.Property)
			{
				throw new BadImageFormatException();
			}
			ArgumentTypeInfo info = DecodeNamedArgumentType(ref valueReader);
			string name = valueReader.ReadSerializedString();
			CustomAttributeTypedArgument<TType> customAttributeTypedArgument = DecodeArgument(ref valueReader, info);
			builder.Add(new CustomAttributeNamedArgument<TType>(name, customAttributeNamedArgumentKind, customAttributeTypedArgument.Type, customAttributeTypedArgument.Value));
		}
		return builder.MoveToImmutable();
	}

	private ArgumentTypeInfo DecodeNamedArgumentType(ref BlobReader valueReader, bool isElementType = false)
	{
		ArgumentTypeInfo result = new ArgumentTypeInfo
		{
			TypeCode = valueReader.ReadSerializationTypeCode()
		};
		switch (result.TypeCode)
		{
		case SerializationTypeCode.Boolean:
		case SerializationTypeCode.Char:
		case SerializationTypeCode.SByte:
		case SerializationTypeCode.Byte:
		case SerializationTypeCode.Int16:
		case SerializationTypeCode.UInt16:
		case SerializationTypeCode.Int32:
		case SerializationTypeCode.UInt32:
		case SerializationTypeCode.Int64:
		case SerializationTypeCode.UInt64:
		case SerializationTypeCode.Single:
		case SerializationTypeCode.Double:
		case SerializationTypeCode.String:
			result.Type = _provider.GetPrimitiveType((PrimitiveTypeCode)result.TypeCode);
			break;
		case SerializationTypeCode.Type:
			result.Type = _provider.GetSystemType();
			break;
		case SerializationTypeCode.TaggedObject:
			result.Type = _provider.GetPrimitiveType(PrimitiveTypeCode.Object);
			break;
		case SerializationTypeCode.SZArray:
		{
			if (isElementType)
			{
				throw new BadImageFormatException();
			}
			ArgumentTypeInfo argumentTypeInfo = DecodeNamedArgumentType(ref valueReader, isElementType: true);
			result.ElementType = argumentTypeInfo.Type;
			result.ElementTypeCode = argumentTypeInfo.TypeCode;
			result.Type = _provider.GetSZArrayType(result.ElementType);
			break;
		}
		case SerializationTypeCode.Enum:
		{
			string name = valueReader.ReadSerializedString();
			result.Type = _provider.GetTypeFromSerializedName(name);
			result.TypeCode = (SerializationTypeCode)_provider.GetUnderlyingEnumType(result.Type);
			break;
		}
		default:
			throw new BadImageFormatException();
		}
		return result;
	}

	private CustomAttributeTypedArgument<TType> DecodeArgument(ref BlobReader valueReader, ArgumentTypeInfo info)
	{
		ArgumentTypeInfo argumentTypeInfo = info;
		if (info.TypeCode == SerializationTypeCode.TaggedObject)
		{
			info = DecodeNamedArgumentType(ref valueReader);
		}
		object value;
		switch (info.TypeCode)
		{
		case SerializationTypeCode.Boolean:
			value = valueReader.ReadBoolean();
			break;
		case SerializationTypeCode.Byte:
			value = valueReader.ReadByte();
			break;
		case SerializationTypeCode.Char:
			value = valueReader.ReadChar();
			break;
		case SerializationTypeCode.Double:
			value = valueReader.ReadDouble();
			break;
		case SerializationTypeCode.Int16:
			value = valueReader.ReadInt16();
			break;
		case SerializationTypeCode.Int32:
			value = valueReader.ReadInt32();
			break;
		case SerializationTypeCode.Int64:
			value = valueReader.ReadInt64();
			break;
		case SerializationTypeCode.SByte:
			value = valueReader.ReadSByte();
			break;
		case SerializationTypeCode.Single:
			value = valueReader.ReadSingle();
			break;
		case SerializationTypeCode.UInt16:
			value = valueReader.ReadUInt16();
			break;
		case SerializationTypeCode.UInt32:
			value = valueReader.ReadUInt32();
			break;
		case SerializationTypeCode.UInt64:
			value = valueReader.ReadUInt64();
			break;
		case SerializationTypeCode.String:
			value = valueReader.ReadSerializedString();
			break;
		case SerializationTypeCode.Type:
		{
			string name = valueReader.ReadSerializedString();
			value = _provider.GetTypeFromSerializedName(name);
			break;
		}
		case SerializationTypeCode.SZArray:
			value = DecodeArrayArgument(ref valueReader, info);
			break;
		default:
			throw new BadImageFormatException();
		}
		if (_provideBoxingTypeInfo && argumentTypeInfo.TypeCode == SerializationTypeCode.TaggedObject)
		{
			return new CustomAttributeTypedArgument<TType>(argumentTypeInfo.Type, new CustomAttributeTypedArgument<TType>(info.Type, value));
		}
		return new CustomAttributeTypedArgument<TType>(info.Type, value);
	}

	private ImmutableArray<CustomAttributeTypedArgument<TType>>? DecodeArrayArgument(ref BlobReader blobReader, ArgumentTypeInfo info)
	{
		int num = blobReader.ReadInt32();
		if (num == -1)
		{
			return null;
		}
		if (num == 0)
		{
			return ImmutableArray<CustomAttributeTypedArgument<TType>>.Empty;
		}
		if (num < 0)
		{
			throw new BadImageFormatException();
		}
		ArgumentTypeInfo info2 = new ArgumentTypeInfo
		{
			Type = info.ElementType,
			TypeCode = info.ElementTypeCode
		};
		ImmutableArray<CustomAttributeTypedArgument<TType>>.Builder builder = ImmutableArray.CreateBuilder<CustomAttributeTypedArgument<TType>>(num);
		for (int i = 0; i < num; i = checked(i + 1))
		{
			builder.Add(DecodeArgument(ref blobReader, info2));
		}
		return builder.MoveToImmutable();
	}
}
