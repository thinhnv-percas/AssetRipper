using dnlib.IO;

namespace dnlib.DotNet;

public struct MarshalBlobReader
{
	private readonly ModuleDef module;

	private DataReader reader;

	private readonly GenericParamContext gpContext;

	public static MarshalType Read(ModuleDefMD module, uint sig)
	{
		return Read(module, module.BlobStream.CreateReader(sig), default(GenericParamContext));
	}

	public static MarshalType Read(ModuleDefMD module, uint sig, GenericParamContext gpContext)
	{
		return Read(module, module.BlobStream.CreateReader(sig), gpContext);
	}

	public static MarshalType Read(ModuleDef module, byte[] data)
	{
		return Read(module, ByteArrayDataReaderFactory.CreateReader(data), default(GenericParamContext));
	}

	public static MarshalType Read(ModuleDef module, byte[] data, GenericParamContext gpContext)
	{
		return Read(module, ByteArrayDataReaderFactory.CreateReader(data), gpContext);
	}

	public static MarshalType Read(ModuleDef module, DataReader reader)
	{
		return Read(module, reader, default(GenericParamContext));
	}

	public static MarshalType Read(ModuleDef module, DataReader reader, GenericParamContext gpContext)
	{
		return new MarshalBlobReader(module, ref reader, gpContext).Read();
	}

	private MarshalBlobReader(ModuleDef module, ref DataReader reader, GenericParamContext gpContext)
	{
		this.module = module;
		this.reader = reader;
		this.gpContext = gpContext;
	}

	private MarshalType Read()
	{
		MarshalType result;
		try
		{
			NativeType nativeType = (NativeType)reader.ReadByte();
			switch (nativeType)
			{
			case NativeType.FixedSysString:
			{
				int size = (CanRead() ? ((int)reader.ReadCompressedUInt32()) : (-1));
				result = new FixedSysStringMarshalType(size);
				break;
			}
			case NativeType.SafeArray:
			{
				VariantType vt = (CanRead() ? ((VariantType)reader.ReadCompressedUInt32()) : VariantType.NotInitialized);
				UTF8String uTF8String = (CanRead() ? ReadUTF8String() : null);
				ITypeDefOrRef userDefinedSubType = (((object)uTF8String == null) ? null : TypeNameParser.ParseReflection(module, UTF8String.ToSystemStringOrEmpty(uTF8String), null, gpContext));
				result = new SafeArrayMarshalType(vt, userDefinedSubType);
				break;
			}
			case NativeType.FixedArray:
			{
				int size = (CanRead() ? ((int)reader.ReadCompressedUInt32()) : (-1));
				NativeType elementType = (CanRead() ? ((NativeType)reader.ReadCompressedUInt32()) : NativeType.NotInitialized);
				result = new FixedArrayMarshalType(size, elementType);
				break;
			}
			case NativeType.Array:
			{
				NativeType elementType = (CanRead() ? ((NativeType)reader.ReadCompressedUInt32()) : NativeType.NotInitialized);
				int paramNum = (CanRead() ? ((int)reader.ReadCompressedUInt32()) : (-1));
				int size = (CanRead() ? ((int)reader.ReadCompressedUInt32()) : (-1));
				int flags = (CanRead() ? ((int)reader.ReadCompressedUInt32()) : (-1));
				result = new ArrayMarshalType(elementType, paramNum, size, flags);
				break;
			}
			case NativeType.CustomMarshaler:
			{
				UTF8String guid = ReadUTF8String();
				UTF8String nativeTypeName = ReadUTF8String();
				UTF8String utf = ReadUTF8String();
				ITypeDefOrRef custMarshaler = TypeNameParser.ParseReflection(module, UTF8String.ToSystemStringOrEmpty(utf), new CAAssemblyRefFinder(module), gpContext);
				UTF8String cookie = ReadUTF8String();
				result = new CustomMarshalType(guid, nativeTypeName, custMarshaler, cookie);
				break;
			}
			case NativeType.IUnknown:
			case NativeType.IDispatch:
			case NativeType.IntF:
			{
				int iidParamIndex = (CanRead() ? ((int)reader.ReadCompressedUInt32()) : (-1));
				return new InterfaceMarshalType(nativeType, iidParamIndex);
			}
			default:
				result = new MarshalType(nativeType);
				break;
			}
		}
		catch
		{
			result = new RawMarshalType(reader.ToArray());
		}
		return result;
	}

	private bool CanRead()
	{
		return reader.Position < reader.Length;
	}

	private UTF8String ReadUTF8String()
	{
		uint num = reader.ReadCompressedUInt32();
		return (num == 0) ? UTF8String.Empty : new UTF8String(reader.ReadBytes((int)num));
	}
}
