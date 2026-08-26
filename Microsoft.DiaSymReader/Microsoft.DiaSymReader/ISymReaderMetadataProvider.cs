using System.Reflection;

namespace Microsoft.DiaSymReader;

public interface ISymReaderMetadataProvider
{
	unsafe bool TryGetStandaloneSignature(int standaloneSignatureToken, out byte* signature, out int length);

	bool TryGetTypeDefinitionInfo(int typeDefinitionToken, out string namespaceName, out string typeName, out TypeAttributes attributes);

	bool TryGetTypeReferenceInfo(int typeReferenceToken, out string namespaceName, out string typeName);
}
