using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler;

public static class SRMExtensions
{
	private sealed class FieldValueSizeDecoder : ISignatureTypeProvider<int, DecompTools.Decompiler.TypeSystem.GenericContext>, ISimpleTypeProvider<int>, IConstructedTypeProvider<int>, ISZArrayTypeProvider<int>
	{
		private MetadataModule module;

		public FieldValueSizeDecoder(ICompilation typeSystem)
		{
			module = (MetadataModule)typeSystem.MainModule;
		}

		public int GetArrayType(int elementType, ArrayShape shape)
		{
			return GetPrimitiveType(PrimitiveTypeCode.Object);
		}

		public int GetSZArrayType(int elementType)
		{
			return GetPrimitiveType(PrimitiveTypeCode.Object);
		}

		public int GetByReferenceType(int elementType)
		{
			return GetPointerType(elementType);
		}

		public int GetFunctionPointerType(MethodSignature<int> signature)
		{
			return GetPrimitiveType(PrimitiveTypeCode.IntPtr);
		}

		public int GetGenericInstantiation(int genericType, ImmutableArray<int> typeArguments)
		{
			return genericType;
		}

		public int GetGenericMethodParameter(DecompTools.Decompiler.TypeSystem.GenericContext genericContext, int index)
		{
			return 0;
		}

		public int GetGenericTypeParameter(DecompTools.Decompiler.TypeSystem.GenericContext genericContext, int index)
		{
			return 0;
		}

		public int GetModifiedType(int modifier, int unmodifiedType, bool isRequired)
		{
			return unmodifiedType;
		}

		public int GetPinnedType(int elementType)
		{
			return elementType;
		}

		public int GetPointerType(int elementType)
		{
			return GetPrimitiveType(PrimitiveTypeCode.IntPtr);
		}

		public int GetPrimitiveType(PrimitiveTypeCode typeCode)
		{
			switch (typeCode)
			{
			case PrimitiveTypeCode.Boolean:
			case PrimitiveTypeCode.SByte:
			case PrimitiveTypeCode.Byte:
				return 1;
			case PrimitiveTypeCode.Char:
			case PrimitiveTypeCode.Int16:
			case PrimitiveTypeCode.UInt16:
				return 2;
			case PrimitiveTypeCode.Int32:
			case PrimitiveTypeCode.UInt32:
			case PrimitiveTypeCode.Single:
				return 4;
			case PrimitiveTypeCode.Int64:
			case PrimitiveTypeCode.UInt64:
			case PrimitiveTypeCode.Double:
				return 8;
			case PrimitiveTypeCode.IntPtr:
			case PrimitiveTypeCode.UIntPtr:
				return IntPtr.Size;
			default:
				return 0;
			}
		}

		public int GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
		{
			return reader.GetTypeDefinition(handle).GetLayout().Size;
		}

		public int GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
		{
			ITypeDefinition definition = module.ResolveType(handle, default(DecompTools.Decompiler.TypeSystem.GenericContext)).GetDefinition();
			if (definition == null || definition.MetadataToken.IsNil)
			{
				return 0;
			}
			reader = definition.ParentModule.PEFile.Metadata;
			return reader.GetTypeDefinition((TypeDefinitionHandle)definition.MetadataToken).GetLayout().Size;
		}

		public int GetTypeFromSpecification(MetadataReader reader, DecompTools.Decompiler.TypeSystem.GenericContext genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
		{
			return reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
		}
	}

	public static bool HasFlag(this TypeDefinition typeDefinition, TypeAttributes attribute)
	{
		return (typeDefinition.Attributes & attribute) == attribute;
	}

	public static bool HasFlag(this MethodDefinition methodDefinition, MethodAttributes attribute)
	{
		return (methodDefinition.Attributes & attribute) == attribute;
	}

	public static bool HasFlag(this FieldDefinition fieldDefinition, FieldAttributes attribute)
	{
		return (fieldDefinition.Attributes & attribute) == attribute;
	}

	public static bool HasFlag(this PropertyDefinition propertyDefinition, PropertyAttributes attribute)
	{
		return (propertyDefinition.Attributes & attribute) == attribute;
	}

	public static bool HasFlag(this EventDefinition eventDefinition, EventAttributes attribute)
	{
		return (eventDefinition.Attributes & attribute) == attribute;
	}

	public static bool IsTypeKind(this HandleKind kind)
	{
		return kind == HandleKind.TypeDefinition || kind == HandleKind.TypeReference || kind == HandleKind.TypeSpecification;
	}

	public static bool IsMemberKind(this HandleKind kind)
	{
		return kind == HandleKind.MethodDefinition || kind == HandleKind.PropertyDefinition || kind == HandleKind.FieldDefinition || kind == HandleKind.EventDefinition || kind == HandleKind.MemberReference || kind == HandleKind.MethodSpecification;
	}

	public static bool IsValueType(this TypeDefinitionHandle handle, MetadataReader reader)
	{
		return reader.GetTypeDefinition(handle).IsValueType(reader);
	}

	public static bool IsValueType(this TypeDefinition typeDefinition, MetadataReader reader)
	{
		EntityHandle baseTypeOrNil = typeDefinition.GetBaseTypeOrNil();
		if (baseTypeOrNil.IsNil)
		{
			return false;
		}
		if (baseTypeOrNil.IsKnownType(reader, KnownTypeCode.Enum))
		{
			return true;
		}
		if (!baseTypeOrNil.IsKnownType(reader, KnownTypeCode.ValueType))
		{
			return false;
		}
		FullTypeName fullTypeName = typeDefinition.GetFullTypeName(reader);
		return !fullTypeName.IsKnownType(KnownTypeCode.Enum);
	}

	public static bool IsEnum(this TypeDefinitionHandle handle, MetadataReader reader)
	{
		return reader.GetTypeDefinition(handle).IsEnum(reader);
	}

	public static bool IsEnum(this TypeDefinition typeDefinition, MetadataReader reader)
	{
		EntityHandle baseTypeOrNil = typeDefinition.GetBaseTypeOrNil();
		if (baseTypeOrNil.IsNil)
		{
			return false;
		}
		return baseTypeOrNil.IsKnownType(reader, KnownTypeCode.Enum);
	}

	public static bool IsEnum(this TypeDefinitionHandle handle, MetadataReader reader, out PrimitiveTypeCode underlyingType)
	{
		return reader.GetTypeDefinition(handle).IsEnum(reader, out underlyingType);
	}

	public static bool IsEnum(this TypeDefinition typeDefinition, MetadataReader reader, out PrimitiveTypeCode underlyingType)
	{
		underlyingType = (PrimitiveTypeCode)0;
		EntityHandle baseTypeOrNil = typeDefinition.GetBaseTypeOrNil();
		if (baseTypeOrNil.IsNil)
		{
			return false;
		}
		if (!baseTypeOrNil.IsKnownType(reader, KnownTypeCode.Enum))
		{
			return false;
		}
		BlobReader blobReader = reader.GetBlobReader(reader.GetFieldDefinition(Enumerable.First<FieldDefinitionHandle>((IEnumerable<FieldDefinitionHandle>)typeDefinition.GetFields())).Signature);
		if (blobReader.ReadSignatureHeader().Kind != SignatureKind.Field)
		{
			return false;
		}
		underlyingType = (PrimitiveTypeCode)blobReader.ReadByte();
		return true;
	}

	public static bool IsDelegate(this TypeDefinitionHandle handle, MetadataReader reader)
	{
		return reader.GetTypeDefinition(handle).IsDelegate(reader);
	}

	public static bool IsDelegate(this TypeDefinition typeDefinition, MetadataReader reader)
	{
		EntityHandle baseTypeOrNil = typeDefinition.GetBaseTypeOrNil();
		return !baseTypeOrNil.IsNil && baseTypeOrNil.IsKnownType(reader, KnownTypeCode.MulticastDelegate);
	}

	public static bool HasBody(this MethodDefinition methodDefinition)
	{
		return (methodDefinition.Attributes & (MethodAttributes.Abstract | MethodAttributes.PinvokeImpl)) == 0 && (methodDefinition.ImplAttributes & (MethodImplAttributes)0x1007) == 0 && methodDefinition.RelativeVirtualAddress > 0;
	}

	public static int GetCodeSize(this MethodBodyBlock body)
	{
		if (body == null)
		{
			throw new ArgumentNullException("body");
		}
		return body.GetILReader().Length;
	}

	public static MethodDefinitionHandle GetAny(this PropertyAccessors accessors)
	{
		if (!accessors.Getter.IsNil)
		{
			return accessors.Getter;
		}
		return accessors.Setter;
	}

	public static MethodDefinitionHandle GetAny(this EventAccessors accessors)
	{
		if (!accessors.Adder.IsNil)
		{
			return accessors.Adder;
		}
		if (!accessors.Remover.IsNil)
		{
			return accessors.Remover;
		}
		return accessors.Raiser;
	}

	public static TypeDefinitionHandle GetDeclaringType(this EntityHandle entity, MetadataReader metadata)
	{
		return entity.Kind switch
		{
			HandleKind.TypeDefinition => metadata.GetTypeDefinition((TypeDefinitionHandle)entity).GetDeclaringType(), 
			HandleKind.FieldDefinition => metadata.GetFieldDefinition((FieldDefinitionHandle)entity).GetDeclaringType(), 
			HandleKind.MethodDefinition => metadata.GetMethodDefinition((MethodDefinitionHandle)entity).GetDeclaringType(), 
			HandleKind.EventDefinition => metadata.GetMethodDefinition(metadata.GetEventDefinition((EventDefinitionHandle)entity).GetAccessors().GetAny()).GetDeclaringType(), 
			HandleKind.PropertyDefinition => metadata.GetMethodDefinition(metadata.GetPropertyDefinition((PropertyDefinitionHandle)entity).GetAccessors().GetAny()).GetDeclaringType(), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static TypeReferenceHandle GetDeclaringType(this TypeReference tr)
	{
		HandleKind kind = tr.ResolutionScope.Kind;
		if (kind == HandleKind.TypeReference)
		{
			return (TypeReferenceHandle)tr.ResolutionScope;
		}
		return default(TypeReferenceHandle);
	}

	public static FullTypeName GetFullTypeName(this EntityHandle handle, MetadataReader reader)
	{
		if (handle.IsNil)
		{
			throw new ArgumentNullException("handle");
		}
		return handle.Kind switch
		{
			HandleKind.TypeDefinition => ((TypeDefinitionHandle)handle).GetFullTypeName(reader), 
			HandleKind.TypeReference => ((TypeReferenceHandle)handle).GetFullTypeName(reader), 
			HandleKind.TypeSpecification => ((TypeSpecificationHandle)handle).GetFullTypeName(reader), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static bool IsKnownType(this EntityHandle handle, MetadataReader reader, KnownTypeCode knownType)
	{
		return handle.GetFullTypeName(reader) == KnownTypeReference.Get(knownType).TypeName;
	}

	internal static bool IsKnownType(this EntityHandle handle, MetadataReader reader, KnownAttribute knownType)
	{
		return handle.GetFullTypeName(reader) == knownType.GetTypeName();
	}

	public static FullTypeName GetFullTypeName(this TypeSpecificationHandle handle, MetadataReader reader)
	{
		if (handle.IsNil)
		{
			throw new ArgumentNullException("handle");
		}
		return reader.GetTypeSpecification(handle).DecodeSignature(new FullTypeNameSignatureDecoder(reader), default(Unit));
	}

	public static FullTypeName GetFullTypeName(this TypeReferenceHandle handle, MetadataReader reader)
	{
		if (handle.IsNil)
		{
			throw new ArgumentNullException("handle");
		}
		TypeReference typeReference = reader.GetTypeReference(handle);
		string reflectionName;
		try
		{
			reflectionName = reader.GetString(typeReference.Name);
		}
		catch (BadImageFormatException)
		{
			reflectionName = $"TR{reader.GetToken(handle):x8}";
		}
		reflectionName = ReflectionHelper.SplitTypeParameterCountFromReflectionName(reflectionName, out var typeParameterCount);
		TypeReferenceHandle handle2;
		try
		{
			handle2 = typeReference.GetDeclaringType();
		}
		catch (BadImageFormatException)
		{
			handle2 = default(TypeReferenceHandle);
		}
		if (handle2.IsNil)
		{
			string namespaceName;
			try
			{
				namespaceName = (typeReference.Namespace.IsNil ? "" : reader.GetString(typeReference.Namespace));
			}
			catch (BadImageFormatException)
			{
				namespaceName = "";
			}
			return new FullTypeName(new TopLevelTypeName(namespaceName, reflectionName, typeParameterCount));
		}
		return handle2.GetFullTypeName(reader).NestedType(reflectionName, typeParameterCount);
	}

	public static FullTypeName GetFullTypeName(this TypeDefinitionHandle handle, MetadataReader reader)
	{
		if (handle.IsNil)
		{
			throw new ArgumentNullException("handle");
		}
		return reader.GetTypeDefinition(handle).GetFullTypeName(reader);
	}

	public static FullTypeName GetFullTypeName(this TypeDefinition td, MetadataReader reader)
	{
		string name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(reader.GetString(td.Name), out var typeParameterCount);
		TypeDefinitionHandle declaringType;
		TypeDefinitionHandle typeDefinitionHandle = (declaringType = td.GetDeclaringType());
		if (typeDefinitionHandle.IsNil)
		{
			string namespaceName = (td.Namespace.IsNil ? "" : reader.GetString(td.Namespace));
			return new FullTypeName(new TopLevelTypeName(namespaceName, name, typeParameterCount));
		}
		return declaringType.GetFullTypeName(reader).NestedType(name, typeParameterCount);
	}

	public static FullTypeName GetFullTypeName(this ExportedType type, MetadataReader metadata)
	{
		string name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(metadata.GetString(type.Name), out var typeParameterCount);
		if (type.Implementation.Kind == HandleKind.ExportedType)
		{
			ExportedType exportedType = metadata.GetExportedType((ExportedTypeHandle)type.Implementation);
			return exportedType.GetFullTypeName(metadata).NestedType(name, typeParameterCount);
		}
		string namespaceName = (type.Namespace.IsNil ? "" : metadata.GetString(type.Namespace));
		return new TopLevelTypeName(namespaceName, name, typeParameterCount);
	}

	public static bool IsAnonymousType(this TypeDefinition type, MetadataReader metadata)
	{
		string text = metadata.GetString(type.Name);
		if (type.Namespace.IsNil && type.HasGeneratedName(metadata) && (text.Contains("AnonType") || text.Contains("AnonymousType")))
		{
			return type.IsCompilerGenerated(metadata);
		}
		return false;
	}

	public static bool IsGeneratedName(this StringHandle handle, MetadataReader metadata)
	{
		return !handle.IsNil && metadata.GetString(handle).StartsWith("<", StringComparison.Ordinal);
	}

	public static bool HasGeneratedName(this MethodDefinitionHandle handle, MetadataReader metadata)
	{
		return metadata.GetMethodDefinition(handle).Name.IsGeneratedName(metadata);
	}

	public static bool HasGeneratedName(this TypeDefinitionHandle handle, MetadataReader metadata)
	{
		return metadata.GetTypeDefinition(handle).Name.IsGeneratedName(metadata);
	}

	public static bool HasGeneratedName(this TypeDefinition type, MetadataReader metadata)
	{
		return type.Name.IsGeneratedName(metadata);
	}

	public static bool HasGeneratedName(this FieldDefinitionHandle handle, MetadataReader metadata)
	{
		return metadata.GetFieldDefinition(handle).Name.IsGeneratedName(metadata);
	}

	public static bool IsCompilerGenerated(this MethodDefinitionHandle handle, MetadataReader metadata)
	{
		return metadata.GetMethodDefinition(handle).IsCompilerGenerated(metadata);
	}

	public static bool IsCompilerGeneratedOrIsInCompilerGeneratedClass(this MethodDefinitionHandle handle, MetadataReader metadata)
	{
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		if (methodDefinition.IsCompilerGenerated(metadata))
		{
			return true;
		}
		TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
		if (!declaringType.IsNil && declaringType.IsCompilerGenerated(metadata))
		{
			return true;
		}
		return false;
	}

	public static bool IsCompilerGenerated(this MethodDefinition method, MetadataReader metadata)
	{
		return method.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.CompilerGenerated);
	}

	public static bool IsCompilerGenerated(this FieldDefinitionHandle handle, MetadataReader metadata)
	{
		return metadata.GetFieldDefinition(handle).IsCompilerGenerated(metadata);
	}

	public static bool IsCompilerGenerated(this FieldDefinition field, MetadataReader metadata)
	{
		return field.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.CompilerGenerated);
	}

	public static bool IsCompilerGenerated(this TypeDefinitionHandle handle, MetadataReader metadata)
	{
		return metadata.GetTypeDefinition(handle).IsCompilerGenerated(metadata);
	}

	public static bool IsCompilerGenerated(this TypeDefinition type, MetadataReader metadata)
	{
		return type.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.CompilerGenerated);
	}

	public static EntityHandle GetAttributeType(this CustomAttribute attribute, MetadataReader reader)
	{
		return attribute.Constructor.Kind switch
		{
			HandleKind.MethodDefinition => reader.GetMethodDefinition((MethodDefinitionHandle)attribute.Constructor).GetDeclaringType(), 
			HandleKind.MemberReference => reader.GetMemberReference((MemberReferenceHandle)attribute.Constructor).Parent, 
			_ => throw new BadImageFormatException("Unexpected token kind for attribute constructor: " + attribute.Constructor.Kind), 
		};
	}

	public static bool HasKnownAttribute(this CustomAttributeHandleCollection customAttributes, MetadataReader metadata, KnownAttribute type)
	{
		foreach (CustomAttributeHandle item in customAttributes)
		{
			CustomAttribute customAttribute = metadata.GetCustomAttribute(item);
			if (customAttribute.IsKnownAttribute(metadata, type))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool IsKnownAttribute(this CustomAttribute attr, MetadataReader metadata, KnownAttribute attrType)
	{
		return attr.GetAttributeType(metadata).IsKnownType(metadata, attrType);
	}

	public static BlobReader GetInitialValue(this FieldDefinition field, PEReader pefile, ICompilation typeSystem)
	{
		if (!field.HasFlag(FieldAttributes.HasFieldRVA))
		{
			return default(BlobReader);
		}
		int relativeVirtualAddress = field.GetRelativeVirtualAddress();
		if (relativeVirtualAddress == 0)
		{
			return default(BlobReader);
		}
		int num = field.DecodeSignature(new FieldValueSizeDecoder(typeSystem), default(DecompTools.Decompiler.TypeSystem.GenericContext));
		PEMemoryBlock sectionData = pefile.GetSectionData(relativeVirtualAddress);
		if (sectionData.Length == 0 && num != 0)
		{
			throw new BadImageFormatException($"Field data (rva=0x{relativeVirtualAddress:x}) could not be found in any section!");
		}
		if (num < 0 || num > sectionData.Length)
		{
			throw new BadImageFormatException($"Invalid size {num} for field data!");
		}
		return sectionData.GetReader(0, num);
	}

	public static EntityHandle GetBaseTypeOrNil(this TypeDefinition definition)
	{
		try
		{
			return definition.BaseType;
		}
		catch (BadImageFormatException)
		{
			return default(EntityHandle);
		}
	}

	public static ImmutableArray<MethodImplementationHandle> GetMethodImplementations(this MethodDefinitionHandle handle, MetadataReader reader)
	{
		ImmutableArray<MethodImplementationHandle>.Builder builder = ImmutableArray.CreateBuilder<MethodImplementationHandle>();
		foreach (MethodImplementationHandle methodImplementation in reader.GetTypeDefinition(reader.GetMethodDefinition(handle).GetDeclaringType()).GetMethodImplementations())
		{
			if (reader.GetMethodImplementation(methodImplementation).MethodBody == handle)
			{
				builder.Add(methodImplementation);
			}
		}
		return builder.ToImmutable();
	}
}
