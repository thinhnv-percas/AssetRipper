using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader.PortablePdb;

[ComVisible(false)]
public sealed class SymVariable : ISymUnmanagedVariable
{
	private sealed class DummyTypeProvider : ISignatureTypeProvider<object, object>, ISimpleTypeProvider<object>, IConstructedTypeProvider<object>, ISZArrayTypeProvider<object>
	{
		public static readonly DummyTypeProvider Instance = new DummyTypeProvider();

		public object GetArrayType(object elementType, ArrayShape shape)
		{
			return null;
		}

		public object GetByReferenceType(object elementType)
		{
			return null;
		}

		public object GetFunctionPointerType(MethodSignature<object> signature)
		{
			return null;
		}

		public object GetGenericInstantiation(object genericType, ImmutableArray<object> typeArguments)
		{
			return null;
		}

		public object GetGenericMethodParameter(object genericContext, int index)
		{
			return null;
		}

		public object GetGenericTypeParameter(object genericContext, int index)
		{
			return null;
		}

		public object GetModifiedType(object modifier, object unmodifiedType, bool isRequired)
		{
			return null;
		}

		public object GetPinnedType(object elementType)
		{
			return null;
		}

		public object GetPointerType(object elementType)
		{
			return null;
		}

		public object GetPrimitiveType(PrimitiveTypeCode typeCode)
		{
			return null;
		}

		public object GetSZArrayType(object elementType)
		{
			return null;
		}

		public object GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
		{
			return null;
		}

		public object GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
		{
			return null;
		}

		public object GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
		{
			return null;
		}
	}

	private const int ADDR_IL_OFFSET = 1;

	private readonly SymMethod _symMethod;

	private readonly LocalVariableHandle _handle;

	private MetadataReader MetadataReader => _symMethod.MetadataReader;

	internal SymVariable(SymMethod symMethod, LocalVariableHandle handle)
	{
		_symMethod = symMethod;
		_handle = handle;
	}

	public int GetAttributes(out int attributes)
	{
		attributes = (int)MetadataReader.GetLocalVariable(_handle).Attributes;
		return 0;
	}

	public int GetAddressField1(out int value)
	{
		value = MetadataReader.GetLocalVariable(_handle).Index;
		return 0;
	}

	public int GetAddressField2(out int value)
	{
		value = 0;
		return -2147467263;
	}

	public int GetAddressField3(out int value)
	{
		value = 0;
		return -2147467263;
	}

	public int GetStartOffset(out int offset)
	{
		offset = 0;
		return -2147467263;
	}

	public int GetEndOffset(out int offset)
	{
		offset = 0;
		return -2147467263;
	}

	public int GetAddressKind(out int kind)
	{
		kind = 1;
		return 0;
	}

	public int GetName(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] name)
	{
		LocalVariable localVariable = MetadataReader.GetLocalVariable(_handle);
		return InteropUtilities.StringToBuffer(MetadataReader.GetString(localVariable.Name), bufferLength, out count, name);
	}

	public unsafe int GetSignature(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] signature)
	{
		StandaloneSignatureHandle localSignatureHandle = _symMethod.GetLocalSignatureHandle();
		MetadataImport metadataImport = _symMethod.SymReader.GetMetadataImport();
		LocalVariable localVariable = _symMethod.MetadataReader.GetLocalVariable(_handle);
		int sigFromToken = metadataImport.GetSigFromToken(MetadataTokens.GetToken(localSignatureHandle), out var signaturePtr, out var signatureLength);
		if (sigFromToken != 0)
		{
			count = 0;
			return sigFromToken;
		}
		BlobReader blobReader = new BlobReader(signaturePtr, signatureLength);
		if (blobReader.ReadSignatureHeader().Kind != SignatureKind.LocalVariables)
		{
			count = 0;
			return -2147467259;
		}
		int num = blobReader.ReadCompressedInteger();
		int index = localVariable.Index;
		if (index >= num)
		{
			count = 0;
			return -2147467259;
		}
		DummyTypeProvider instance = DummyTypeProvider.Instance;
		SignatureDecoder<object, object> signatureDecoder = new SignatureDecoder<object, object>(instance, null, null);
		for (int i = 0; i < index - 1; i++)
		{
			signatureDecoder.DecodeType(ref blobReader);
		}
		int offset = blobReader.Offset;
		signatureDecoder.DecodeType(ref blobReader);
		int num2 = blobReader.Offset - offset;
		if (num2 <= bufferLength)
		{
			Marshal.Copy((IntPtr)(signaturePtr + offset), signature, 0, num2);
		}
		count = num2;
		return 0;
	}
}
