using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

internal sealed class SymReaderMetadataAdapter : MetadataAdapterBase
{
	private readonly ISymReaderMetadataProvider _metadataProvider;

	public SymReaderMetadataAdapter(ISymReaderMetadataProvider metadataProvider)
	{
		_metadataProvider = metadataProvider;
	}

	public unsafe override int GetSigFromToken(int standaloneSignature, [Out] byte** signature, [Out] int* signatureLength)
	{
		int result = ((!_metadataProvider.TryGetStandaloneSignature(standaloneSignature, out var signature2, out var length)) ? (-2147024809) : 0);
		if (signature != null)
		{
			*signature = signature2;
		}
		if (signatureLength != null)
		{
			*signatureLength = length;
		}
		return result;
	}

	public unsafe override int GetTypeDefProps(int typeDef, [Out] char* qualifiedName, int qualifiedNameBufferLength, [Out] int* qualifiedNameLength, [Out] TypeAttributes* attributes, [Out] int* baseType)
	{
		if (!_metadataProvider.TryGetTypeDefinitionInfo(typeDef, out var namespaceName, out var typeName, out var attributes2))
		{
			return -2147024809;
		}
		if (qualifiedNameLength != null || qualifiedName != null)
		{
			InteropUtilities.CopyQualifiedTypeName(qualifiedName, qualifiedNameBufferLength, qualifiedNameLength, namespaceName, typeName);
		}
		if (attributes != null)
		{
			*attributes = attributes2;
		}
		if (baseType != null)
		{
			*baseType = 0;
		}
		return 0;
	}

	public unsafe override int GetTypeRefProps(int typeRef, [Out] int* resolutionScope, [Out] char* qualifiedName, int qualifiedNameBufferLength, [Out] int* qualifiedNameLength)
	{
		if (!_metadataProvider.TryGetTypeReferenceInfo(typeRef, out var namespaceName, out var typeName))
		{
			return -2147024809;
		}
		if (qualifiedNameLength != null || qualifiedName != null)
		{
			InteropUtilities.CopyQualifiedTypeName(qualifiedName, qualifiedNameBufferLength, qualifiedNameLength, namespaceName, typeName);
		}
		if (resolutionScope != null)
		{
			*resolutionScope = 0;
		}
		return 0;
	}
}
