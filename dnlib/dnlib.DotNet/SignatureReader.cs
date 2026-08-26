using System;
using System.Collections.Generic;
using System.IO;
using dnlib.IO;

namespace dnlib.DotNet;

public struct SignatureReader
{
	private readonly ISignatureReaderHelper helper;

	private readonly ICorLibTypes corLibTypes;

	private DataReader reader;

	private readonly GenericParamContext gpContext;

	private RecursionCounter recursionCounter;

	public static CallingConventionSig ReadSig(ModuleDefMD readerModule, uint sig)
	{
		return ReadSig(readerModule, sig, default(GenericParamContext));
	}

	public static CallingConventionSig ReadSig(ModuleDefMD readerModule, uint sig, GenericParamContext gpContext)
	{
		try
		{
			SignatureReader signatureReader = new SignatureReader(readerModule, sig, gpContext);
			if (signatureReader.reader.Length == 0)
			{
				return null;
			}
			CallingConventionSig callingConventionSig = signatureReader.ReadSig();
			if (callingConventionSig != null)
			{
				callingConventionSig.ExtraData = signatureReader.GetExtraData();
			}
			return callingConventionSig;
		}
		catch
		{
			return null;
		}
	}

	public static CallingConventionSig ReadSig(ModuleDefMD module, byte[] signature)
	{
		return ReadSig(module, module.CorLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), default(GenericParamContext));
	}

	public static CallingConventionSig ReadSig(ModuleDefMD module, byte[] signature, GenericParamContext gpContext)
	{
		return ReadSig(module, module.CorLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), gpContext);
	}

	public static CallingConventionSig ReadSig(ModuleDefMD module, DataReader signature)
	{
		return ReadSig(module, module.CorLibTypes, signature, default(GenericParamContext));
	}

	public static CallingConventionSig ReadSig(ModuleDefMD module, DataReader signature, GenericParamContext gpContext)
	{
		return ReadSig(module, module.CorLibTypes, signature, gpContext);
	}

	public static CallingConventionSig ReadSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, byte[] signature)
	{
		return ReadSig(helper, corLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), default(GenericParamContext));
	}

	public static CallingConventionSig ReadSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, byte[] signature, GenericParamContext gpContext)
	{
		return ReadSig(helper, corLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), gpContext);
	}

	public static CallingConventionSig ReadSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, DataReader signature)
	{
		return ReadSig(helper, corLibTypes, signature, default(GenericParamContext));
	}

	public static CallingConventionSig ReadSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, DataReader signature, GenericParamContext gpContext)
	{
		try
		{
			SignatureReader signatureReader = new SignatureReader(helper, corLibTypes, ref signature, gpContext);
			if (signatureReader.reader.Length == 0)
			{
				return null;
			}
			return signatureReader.ReadSig();
		}
		catch
		{
			return null;
		}
	}

	public static TypeSig ReadTypeSig(ModuleDefMD readerModule, uint sig)
	{
		return ReadTypeSig(readerModule, sig, default(GenericParamContext));
	}

	public static TypeSig ReadTypeSig(ModuleDefMD readerModule, uint sig, GenericParamContext gpContext)
	{
		try
		{
			return new SignatureReader(readerModule, sig, gpContext).ReadType();
		}
		catch
		{
			return null;
		}
	}

	public static TypeSig ReadTypeSig(ModuleDefMD readerModule, uint sig, out byte[] extraData)
	{
		return ReadTypeSig(readerModule, sig, default(GenericParamContext), out extraData);
	}

	public static TypeSig ReadTypeSig(ModuleDefMD readerModule, uint sig, GenericParamContext gpContext, out byte[] extraData)
	{
		try
		{
			SignatureReader signatureReader = new SignatureReader(readerModule, sig, gpContext);
			TypeSig result;
			try
			{
				result = signatureReader.ReadType();
			}
			catch (IOException)
			{
				signatureReader.reader.Position = 0u;
				result = null;
			}
			extraData = signatureReader.GetExtraData();
			return result;
		}
		catch
		{
			extraData = null;
			return null;
		}
	}

	public static TypeSig ReadTypeSig(ModuleDefMD module, byte[] signature)
	{
		return ReadTypeSig(module, module.CorLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), default(GenericParamContext));
	}

	public static TypeSig ReadTypeSig(ModuleDefMD module, byte[] signature, GenericParamContext gpContext)
	{
		return ReadTypeSig(module, module.CorLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), gpContext);
	}

	public static TypeSig ReadTypeSig(ModuleDefMD module, DataReader signature)
	{
		return ReadTypeSig(module, module.CorLibTypes, signature, default(GenericParamContext));
	}

	public static TypeSig ReadTypeSig(ModuleDefMD module, DataReader signature, GenericParamContext gpContext)
	{
		return ReadTypeSig(module, module.CorLibTypes, signature, gpContext);
	}

	public static TypeSig ReadTypeSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, byte[] signature)
	{
		return ReadTypeSig(helper, corLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), default(GenericParamContext));
	}

	public static TypeSig ReadTypeSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, byte[] signature, GenericParamContext gpContext)
	{
		return ReadTypeSig(helper, corLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), gpContext);
	}

	public static TypeSig ReadTypeSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, DataReader signature)
	{
		return ReadTypeSig(helper, corLibTypes, signature, default(GenericParamContext));
	}

	public static TypeSig ReadTypeSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, DataReader signature, GenericParamContext gpContext)
	{
		byte[] extraData;
		return ReadTypeSig(helper, corLibTypes, signature, gpContext, out extraData);
	}

	public static TypeSig ReadTypeSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, byte[] signature, GenericParamContext gpContext, out byte[] extraData)
	{
		return ReadTypeSig(helper, corLibTypes, ByteArrayDataReaderFactory.CreateReader(signature), gpContext, out extraData);
	}

	public static TypeSig ReadTypeSig(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, DataReader signature, GenericParamContext gpContext, out byte[] extraData)
	{
		try
		{
			SignatureReader signatureReader = new SignatureReader(helper, corLibTypes, ref signature, gpContext);
			TypeSig result;
			try
			{
				result = signatureReader.ReadType();
			}
			catch (IOException)
			{
				signatureReader.reader.Position = 0u;
				result = null;
			}
			extraData = signatureReader.GetExtraData();
			return result;
		}
		catch
		{
			extraData = null;
			return null;
		}
	}

	private SignatureReader(ModuleDefMD readerModule, uint sig, GenericParamContext gpContext)
	{
		helper = readerModule;
		corLibTypes = readerModule.CorLibTypes;
		reader = readerModule.BlobStream.CreateReader(sig);
		this.gpContext = gpContext;
		recursionCounter = default(RecursionCounter);
	}

	private SignatureReader(ISignatureReaderHelper helper, ICorLibTypes corLibTypes, ref DataReader reader, GenericParamContext gpContext)
	{
		this.helper = helper;
		this.corLibTypes = corLibTypes;
		this.reader = reader;
		this.gpContext = gpContext;
		recursionCounter = default(RecursionCounter);
	}

	private byte[] GetExtraData()
	{
		if (reader.Position == reader.Length)
		{
			return null;
		}
		return reader.ReadRemainingBytes();
	}

	private CallingConventionSig ReadSig()
	{
		if (!recursionCounter.Increment())
		{
			return null;
		}
		CallingConvention callingConvention = (CallingConvention)reader.ReadByte();
		CallingConventionSig result;
		switch (callingConvention & CallingConvention.Mask)
		{
		case CallingConvention.Default:
		case CallingConvention.C:
		case CallingConvention.StdCall:
		case CallingConvention.ThisCall:
		case CallingConvention.FastCall:
		case CallingConvention.VarArg:
		case CallingConvention.NativeVarArg:
			result = ReadMethod(callingConvention);
			break;
		case CallingConvention.Field:
			result = ReadField(callingConvention);
			break;
		case CallingConvention.LocalSig:
			result = ReadLocalSig(callingConvention);
			break;
		case CallingConvention.Property:
			result = ReadProperty(callingConvention);
			break;
		case CallingConvention.GenericInst:
			result = ReadGenericInstMethod(callingConvention);
			break;
		default:
			result = null;
			break;
		}
		recursionCounter.Decrement();
		return result;
	}

	private FieldSig ReadField(CallingConvention callingConvention)
	{
		return new FieldSig(callingConvention, ReadType());
	}

	private MethodSig ReadMethod(CallingConvention callingConvention)
	{
		return ReadSig(new MethodSig(callingConvention));
	}

	private PropertySig ReadProperty(CallingConvention callingConvention)
	{
		return ReadSig(new PropertySig(callingConvention));
	}

	private T ReadSig<T>(T methodSig) where T : MethodBaseSig
	{
		if (methodSig.Generic)
		{
			if (!reader.TryReadCompressedUInt32(out var value))
			{
				return null;
			}
			methodSig.GenParamCount = value;
		}
		if (!reader.TryReadCompressedUInt32(out var value2))
		{
			return null;
		}
		methodSig.RetType = ReadType();
		IList<TypeSig> list = methodSig.Params;
		for (uint num = 0u; num < value2; num++)
		{
			TypeSig typeSig = ReadType();
			if (typeSig is SentinelSig)
			{
				if (methodSig.ParamsAfterSentinel == null)
				{
					list = (methodSig.ParamsAfterSentinel = new List<TypeSig>((int)(value2 - num)));
				}
				num--;
			}
			else
			{
				list.Add(typeSig);
			}
		}
		return methodSig;
	}

	private LocalSig ReadLocalSig(CallingConvention callingConvention)
	{
		if (!reader.TryReadCompressedUInt32(out var value))
		{
			return null;
		}
		LocalSig localSig = new LocalSig(callingConvention, value);
		IList<TypeSig> locals = localSig.Locals;
		for (uint num = 0u; num < value; num++)
		{
			locals.Add(ReadType());
		}
		return localSig;
	}

	private GenericInstMethodSig ReadGenericInstMethod(CallingConvention callingConvention)
	{
		if (!reader.TryReadCompressedUInt32(out var value))
		{
			return null;
		}
		GenericInstMethodSig genericInstMethodSig = new GenericInstMethodSig(callingConvention, value);
		IList<TypeSig> genericArguments = genericInstMethodSig.GenericArguments;
		for (uint num = 0u; num < value; num++)
		{
			genericArguments.Add(ReadType());
		}
		return genericInstMethodSig;
	}

	private TypeSig ReadType()
	{
		if (!recursionCounter.Increment())
		{
			return null;
		}
		TypeSig result = null;
		uint value2;
		switch ((ElementType)reader.ReadByte())
		{
		case ElementType.Void:
			result = corLibTypes.Void;
			break;
		case ElementType.Boolean:
			result = corLibTypes.Boolean;
			break;
		case ElementType.Char:
			result = corLibTypes.Char;
			break;
		case ElementType.I1:
			result = corLibTypes.SByte;
			break;
		case ElementType.U1:
			result = corLibTypes.Byte;
			break;
		case ElementType.I2:
			result = corLibTypes.Int16;
			break;
		case ElementType.U2:
			result = corLibTypes.UInt16;
			break;
		case ElementType.I4:
			result = corLibTypes.Int32;
			break;
		case ElementType.U4:
			result = corLibTypes.UInt32;
			break;
		case ElementType.I8:
			result = corLibTypes.Int64;
			break;
		case ElementType.U8:
			result = corLibTypes.UInt64;
			break;
		case ElementType.R4:
			result = corLibTypes.Single;
			break;
		case ElementType.R8:
			result = corLibTypes.Double;
			break;
		case ElementType.String:
			result = corLibTypes.String;
			break;
		case ElementType.TypedByRef:
			result = corLibTypes.TypedReference;
			break;
		case ElementType.I:
			result = corLibTypes.IntPtr;
			break;
		case ElementType.U:
			result = corLibTypes.UIntPtr;
			break;
		case ElementType.Object:
			result = corLibTypes.Object;
			break;
		case ElementType.Ptr:
			result = new PtrSig(ReadType());
			break;
		case ElementType.ByRef:
			result = new ByRefSig(ReadType());
			break;
		case ElementType.ValueType:
			result = new ValueTypeSig(ReadTypeDefOrRef());
			break;
		case ElementType.Class:
			result = new ClassSig(ReadTypeDefOrRef());
			break;
		case ElementType.FnPtr:
			result = new FnPtrSig(ReadSig());
			break;
		case ElementType.SZArray:
			result = new SZArraySig(ReadType());
			break;
		case ElementType.CModReqd:
			result = new CModReqdSig(ReadTypeDefOrRef(), ReadType());
			break;
		case ElementType.CModOpt:
			result = new CModOptSig(ReadTypeDefOrRef(), ReadType());
			break;
		case ElementType.Sentinel:
			result = new SentinelSig();
			break;
		case ElementType.Pinned:
			result = new PinnedSig(ReadType());
			break;
		case ElementType.Var:
			if (reader.TryReadCompressedUInt32(out value2))
			{
				result = new GenericVar(value2, gpContext.Type);
			}
			break;
		case ElementType.MVar:
			if (reader.TryReadCompressedUInt32(out value2))
			{
				result = new GenericMVar(value2, gpContext.Method);
			}
			break;
		case ElementType.ValueArray:
		{
			TypeSig arrayType = ReadType();
			if (reader.TryReadCompressedUInt32(out value2))
			{
				result = new ValueArraySig(arrayType, value2);
			}
			break;
		}
		case ElementType.Module:
			if (reader.TryReadCompressedUInt32(out value2))
			{
				result = new ModuleSig(value2, ReadType());
			}
			break;
		case ElementType.GenericInst:
		{
			TypeSig arrayType = ReadType();
			if (reader.TryReadCompressedUInt32(out value2))
			{
				GenericInstSig genericInstSig = new GenericInstSig(arrayType as ClassOrValueTypeSig, value2);
				IList<TypeSig> genericArguments = genericInstSig.GenericArguments;
				for (uint num3 = 0u; num3 < value2; num3++)
				{
					genericArguments.Add(ReadType());
				}
				result = genericInstSig;
			}
			break;
		}
		case ElementType.Array:
		{
			TypeSig arrayType = ReadType();
			if (!reader.TryReadCompressedUInt32(out var value))
			{
				break;
			}
			if (value == 0)
			{
				result = new ArraySig(arrayType, value);
			}
			else
			{
				if (!reader.TryReadCompressedUInt32(out value2))
				{
					break;
				}
				List<uint> list = new List<uint>((int)value2);
				uint num = 0u;
				while (true)
				{
					if (num < value2)
					{
						if (!reader.TryReadCompressedUInt32(out var value3))
						{
							break;
						}
						list.Add(value3);
						num++;
						continue;
					}
					if (!reader.TryReadCompressedUInt32(out value2))
					{
						break;
					}
					List<int> list2 = new List<int>((int)value2);
					uint num2 = 0u;
					while (true)
					{
						if (num2 < value2)
						{
							if (!reader.TryReadCompressedInt32(out var value4))
							{
								break;
							}
							list2.Add(value4);
							num2++;
							continue;
						}
						result = new ArraySig(arrayType, value, list, list2);
						break;
					}
					break;
				}
			}
			break;
		}
		case ElementType.Internal:
		{
			IntPtr address = ((IntPtr.Size != 4) ? new IntPtr(reader.ReadInt64()) : new IntPtr(reader.ReadInt32()));
			result = helper.ConvertRTInternalAddress(address);
			break;
		}
		default:
			result = null;
			break;
		}
		recursionCounter.Decrement();
		return result;
	}

	private ITypeDefOrRef ReadTypeDefOrRef()
	{
		if (!reader.TryReadCompressedUInt32(out var value))
		{
			return null;
		}
		return helper.ResolveTypeDefOrRef(value, gpContext);
	}
}
