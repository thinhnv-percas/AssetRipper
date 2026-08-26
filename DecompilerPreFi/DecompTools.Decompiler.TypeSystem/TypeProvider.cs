using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

internal sealed class TypeProvider : ICompilationProvider, ISignatureTypeProvider<IType, GenericContext>, ISimpleTypeProvider<IType>, IConstructedTypeProvider<IType>, ISZArrayTypeProvider<IType>, ICustomAttributeTypeProvider<IType>
{
	private readonly MetadataModule module;

	private readonly ICompilation compilation;

	public ICompilation Compilation => compilation;

	public TypeProvider(MetadataModule module)
	{
		this.module = module;
		compilation = module.Compilation;
	}

	public TypeProvider(ICompilation compilation)
	{
		this.compilation = compilation;
	}

	public IType GetArrayType(IType elementType, ArrayShape shape)
	{
		return new ArrayType(compilation, elementType, shape.Rank);
	}

	public IType GetByReferenceType(IType elementType)
	{
		return new ByReferenceType(elementType);
	}

	public IType GetFunctionPointerType(MethodSignature<IType> signature)
	{
		return compilation.FindType(KnownTypeCode.IntPtr);
	}

	public IType GetGenericInstantiation(IType genericType, ImmutableArray<IType> typeArguments)
	{
		return new ParameterizedType(genericType, typeArguments);
	}

	public IType GetGenericMethodParameter(GenericContext genericContext, int index)
	{
		return genericContext.GetMethodTypeParameter(index);
	}

	public IType GetGenericTypeParameter(GenericContext genericContext, int index)
	{
		return genericContext.GetClassTypeParameter(index);
	}

	public IType GetModifiedType(IType modifier, IType unmodifiedType, bool isRequired)
	{
		return new ModifiedType(modifier, unmodifiedType, isRequired);
	}

	public IType GetPinnedType(IType elementType)
	{
		return new PinnedType(elementType);
	}

	public IType GetPointerType(IType elementType)
	{
		return new PointerType(elementType);
	}

	public IType GetPrimitiveType(PrimitiveTypeCode typeCode)
	{
		return compilation.FindType(typeCode.ToKnownTypeCode());
	}

	public IType GetSystemType()
	{
		return compilation.FindType(KnownTypeCode.Type);
	}

	public IType GetSZArrayType(IType elementType)
	{
		return new ArrayType(compilation, elementType);
	}

	private bool? IsReferenceType(MetadataReader reader, EntityHandle handle, byte rawTypeKind)
	{
		return reader.ResolveSignatureTypeKind(handle, rawTypeKind) switch
		{
			SignatureTypeKind.ValueType => false, 
			SignatureTypeKind.Class => true, 
			_ => null, 
		};
	}

	public IType GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
	{
		ITypeDefinition typeDefinition = module?.GetDefinition(handle);
		if (typeDefinition != null)
		{
			return typeDefinition;
		}
		bool? isReferenceType = IsReferenceType(reader, handle, rawTypeKind);
		return new UnknownType(handle.GetFullTypeName(reader), isReferenceType);
	}

	public IType GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
	{
		IModuleReference declaringModule = handle.GetDeclaringModule(reader);
		bool? isReferenceType = IsReferenceType(reader, handle, rawTypeKind);
		GetClassTypeReference getClassTypeReference = new GetClassTypeReference(handle.GetFullTypeName(reader), handle.GetDeclaringModule(reader), isReferenceType);
		return getClassTypeReference.Resolve((module != null) ? new SimpleTypeResolveContext(module) : new SimpleTypeResolveContext(compilation));
	}

	public IType GetTypeFromSerializedName(string name)
	{
		if (name == null)
		{
			return null;
		}
		return ReflectionHelper.ParseReflectionName(name).Resolve((module != null) ? new SimpleTypeResolveContext(module) : new SimpleTypeResolveContext(compilation));
	}

	public IType GetTypeFromSpecification(MetadataReader reader, GenericContext genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
	{
		return reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
	}

	public PrimitiveTypeCode GetUnderlyingEnumType(IType type)
	{
		ITypeDefinition definition = type.GetEnumUnderlyingType().GetDefinition();
		if (definition == null)
		{
			throw new EnumUnderlyingTypeResolveException();
		}
		return definition.KnownTypeCode.ToPrimitiveTypeCode();
	}

	public bool IsSystemType(IType type)
	{
		return type.IsKnownType(KnownTypeCode.Type);
	}
}
