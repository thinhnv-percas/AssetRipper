using System.Collections.Immutable;
using System.Reflection.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Metadata;

public sealed class FullTypeNameSignatureDecoder : ISignatureTypeProvider<FullTypeName, Unit>, ISimpleTypeProvider<FullTypeName>, IConstructedTypeProvider<FullTypeName>, ISZArrayTypeProvider<FullTypeName>
{
	private readonly MetadataReader metadata;

	public FullTypeNameSignatureDecoder(MetadataReader metadata)
	{
		this.metadata = metadata;
	}

	public FullTypeName GetArrayType(FullTypeName elementType, ArrayShape shape)
	{
		return elementType;
	}

	public FullTypeName GetByReferenceType(FullTypeName elementType)
	{
		return elementType;
	}

	public FullTypeName GetFunctionPointerType(MethodSignature<FullTypeName> signature)
	{
		return default(FullTypeName);
	}

	public FullTypeName GetGenericInstantiation(FullTypeName genericType, ImmutableArray<FullTypeName> typeArguments)
	{
		return genericType;
	}

	public FullTypeName GetGenericMethodParameter(Unit genericContext, int index)
	{
		return default(FullTypeName);
	}

	public FullTypeName GetGenericTypeParameter(Unit genericContext, int index)
	{
		return default(FullTypeName);
	}

	public FullTypeName GetModifiedType(FullTypeName modifier, FullTypeName unmodifiedType, bool isRequired)
	{
		return unmodifiedType;
	}

	public FullTypeName GetPinnedType(FullTypeName elementType)
	{
		return elementType;
	}

	public FullTypeName GetPointerType(FullTypeName elementType)
	{
		return elementType;
	}

	public FullTypeName GetPrimitiveType(PrimitiveTypeCode typeCode)
	{
		KnownTypeReference knownTypeReference = KnownTypeReference.Get(typeCode.ToKnownTypeCode());
		return new TopLevelTypeName(knownTypeReference.Namespace, knownTypeReference.Name, knownTypeReference.TypeParameterCount);
	}

	public FullTypeName GetSZArrayType(FullTypeName elementType)
	{
		return elementType;
	}

	public FullTypeName GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
	{
		return handle.GetFullTypeName(reader);
	}

	public FullTypeName GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
	{
		return handle.GetFullTypeName(reader);
	}

	public FullTypeName GetTypeFromSpecification(MetadataReader reader, Unit genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
	{
		return reader.GetTypeSpecification(handle).DecodeSignature(new FullTypeNameSignatureDecoder(metadata), default(Unit));
	}
}
