using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader.PortablePdb;

[ComVisible(false)]
public sealed class SymConstant : ISymUnmanagedConstant
{
	private readonly PortablePdbReader _pdbReader;

	private readonly LocalConstantHandle _handle;

	private object _lazyValue = s_uninitialized;

	private byte[] _lazySignature;

	private static readonly object s_nullReferenceValue = 0;

	private static readonly object s_uninitialized = new object();

	internal SymConstant(PortablePdbReader pdbReader, LocalConstantHandle handle)
	{
		_pdbReader = pdbReader;
		_handle = handle;
	}

	public int GetName(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] name)
	{
		MetadataReader metadataReader = _pdbReader.MetadataReader;
		return InteropUtilities.StringToBuffer(metadataReader.GetString(metadataReader.GetLocalConstant(_handle).Name), bufferLength, out count, name);
	}

	public int GetSignature(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] signature)
	{
		if (_lazySignature == null)
		{
			InitializeValueAndSignature();
		}
		return InteropUtilities.BytesToBuffer(_lazySignature, bufferLength, out count, signature);
	}

	public int GetValue(out object value)
	{
		if (_lazyValue == s_uninitialized)
		{
			InitializeValueAndSignature();
		}
		value = _lazyValue;
		return 0;
	}

	private void InitializeValueAndSignature()
	{
		MetadataReader metadataReader = _pdbReader.MetadataReader;
		LocalConstant localConstant = metadataReader.GetLocalConstant(_handle);
		BlobReader sigReader = metadataReader.GetBlobReader(localConstant.Signature);
		BlobWriter blobWriter = new BlobWriter(sigReader.Length);
		int num;
		while (true)
		{
			num = sigReader.ReadCompressedInteger();
			if (num != 32 && num != 31)
			{
				break;
			}
			sigReader.ReadCompressedInteger();
		}
		int num2 = sigReader.Offset - 1;
		if (num2 > 0)
		{
			blobWriter.Write(metadataReader.GetBlobBytes(localConstant.Signature), 0, num2);
		}
		object lazyValue;
		if (num == 17 || num == 18)
		{
			EntityHandle entityHandle = sigReader.ReadTypeHandle();
			string qualifiedTypeName = _pdbReader.SymReader.GetMetadataImport().GetQualifiedTypeName(entityHandle);
			lazyValue = ((qualifiedTypeName == "System.Decimal") ? ((object)sigReader.ReadDecimal()) : ((qualifiedTypeName == "System.DateTime") ? ((object)BitConverter.Int64BitsToDouble(sigReader.ReadDateTime().Ticks)) : ((sigReader.RemainingBytes != 0) ? null : s_nullReferenceValue)));
			blobWriter.Write((byte)num);
			blobWriter.WriteCompressedInteger(MetadataUtilities.GetTypeDefOrRefOrSpecCodedIndex(entityHandle));
		}
		else
		{
			lazyValue = ReadAndTranslateValue(ref sigReader, (SignatureTypeCode)num, out var isEnumTypeCode);
			if (sigReader.RemainingBytes == 0)
			{
				blobWriter.Write((byte)num);
			}
			else if (isEnumTypeCode)
			{
				EntityHandle typeHandle = sigReader.ReadTypeHandle();
				blobWriter.Write(17);
				blobWriter.WriteCompressedInteger(MetadataUtilities.GetTypeDefOrRefOrSpecCodedIndex(typeHandle));
			}
			if (sigReader.RemainingBytes > 0)
			{
				throw new BadImageFormatException();
			}
		}
		_lazyValue = lazyValue;
		_lazySignature = blobWriter.ToArray();
	}

	private object ReadAndTranslateValue(ref BlobReader sigReader, SignatureTypeCode typeCode, out bool isEnumTypeCode)
	{
		switch (typeCode)
		{
		case SignatureTypeCode.Boolean:
			isEnumTypeCode = true;
			return (short)(sigReader.ReadBoolean() ? 1 : 0);
		case SignatureTypeCode.Char:
			isEnumTypeCode = true;
			return (ushort)sigReader.ReadChar();
		case SignatureTypeCode.SByte:
			isEnumTypeCode = true;
			return (short)sigReader.ReadSByte();
		case SignatureTypeCode.Byte:
			isEnumTypeCode = true;
			return (short)sigReader.ReadByte();
		case SignatureTypeCode.Int16:
			isEnumTypeCode = true;
			return sigReader.ReadInt16();
		case SignatureTypeCode.UInt16:
			isEnumTypeCode = true;
			return sigReader.ReadUInt16();
		case SignatureTypeCode.Int32:
			isEnumTypeCode = true;
			return sigReader.ReadInt32();
		case SignatureTypeCode.UInt32:
			isEnumTypeCode = true;
			return sigReader.ReadUInt32();
		case SignatureTypeCode.Int64:
			isEnumTypeCode = true;
			return sigReader.ReadInt64();
		case SignatureTypeCode.UInt64:
			isEnumTypeCode = true;
			return sigReader.ReadUInt64();
		case SignatureTypeCode.Single:
			isEnumTypeCode = false;
			return sigReader.ReadSingle();
		case SignatureTypeCode.Double:
			isEnumTypeCode = false;
			return sigReader.ReadDouble();
		case SignatureTypeCode.String:
			isEnumTypeCode = false;
			if (sigReader.RemainingBytes == 1)
			{
				if (sigReader.ReadByte() != byte.MaxValue)
				{
					throw new BadImageFormatException();
				}
				return s_nullReferenceValue;
			}
			if (sigReader.RemainingBytes % 2 != 0)
			{
				throw new BadImageFormatException();
			}
			return sigReader.ReadUTF16(sigReader.RemainingBytes);
		case SignatureTypeCode.Object:
			isEnumTypeCode = false;
			return s_nullReferenceValue;
		default:
			throw new BadImageFormatException();
		}
	}
}
