using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Microsoft.DiaSymReader.Tools;

internal sealed class SymMetadataProvider : ISymWriterMetadataProvider, ISymReaderMetadataProvider
{
	private readonly MetadataReader _reader;

	internal SymMetadataProvider(MetadataReader reader)
	{
		_reader = reader;
	}

	public unsafe bool TryGetStandaloneSignature(int standaloneSignatureToken, out byte* signature, out int length)
	{
		StandaloneSignatureHandle handle = (StandaloneSignatureHandle)MetadataTokens.Handle(standaloneSignatureToken);
		if (handle.IsNil)
		{
			signature = null;
			length = 0;
			return false;
		}
		StandaloneSignature standaloneSignature = _reader.GetStandaloneSignature(handle);
		BlobReader blobReader = _reader.GetBlobReader(standaloneSignature.Signature);
		signature = blobReader.StartPointer;
		length = blobReader.Length;
		return true;
	}

	public bool TryGetTypeDefinitionInfo(int typeDefinitionToken, out string namespaceName, out string typeName, out TypeAttributes attributes)
	{
		TypeDefinitionHandle handle = (TypeDefinitionHandle)MetadataTokens.Handle(typeDefinitionToken);
		if (handle.IsNil)
		{
			namespaceName = null;
			typeName = null;
			attributes = TypeAttributes.NotPublic;
			return false;
		}
		TypeDefinition typeDefinition = _reader.GetTypeDefinition(handle);
		namespaceName = _reader.GetString(typeDefinition.Namespace);
		typeName = _reader.GetString(typeDefinition.Name);
		attributes = typeDefinition.Attributes;
		return true;
	}

	public bool TryGetTypeReferenceInfo(int typeReferenceToken, out string namespaceName, out string typeName)
	{
		TypeReferenceHandle handle = (TypeReferenceHandle)MetadataTokens.Handle(typeReferenceToken);
		if (handle.IsNil)
		{
			namespaceName = null;
			typeName = null;
			return false;
		}
		TypeReference typeReference = _reader.GetTypeReference(handle);
		namespaceName = _reader.GetString(typeReference.Namespace);
		typeName = _reader.GetString(typeReference.Name);
		return true;
	}

	public bool TryGetEnclosingType(int nestedTypeToken, out int enclosingTypeToken)
	{
		TypeDefinitionHandle declaringType = _reader.GetTypeDefinition(MetadataTokens.TypeDefinitionHandle(nestedTypeToken)).GetDeclaringType();
		if (declaringType.IsNil)
		{
			enclosingTypeToken = 0;
			return false;
		}
		enclosingTypeToken = MetadataTokens.GetToken(declaringType);
		return true;
	}

	public bool TryGetMethodInfo(int methodDefinitionToken, out string methodName, out int declaringTypeToken)
	{
		MethodDefinitionHandle handle = (MethodDefinitionHandle)MetadataTokens.Handle(methodDefinitionToken);
		if (handle.IsNil)
		{
			methodName = null;
			declaringTypeToken = 0;
			return false;
		}
		MethodDefinition methodDefinition = _reader.GetMethodDefinition(handle);
		methodName = _reader.GetString(methodDefinition.Name);
		declaringTypeToken = MetadataTokens.GetToken(methodDefinition.GetDeclaringType());
		return true;
	}
}
