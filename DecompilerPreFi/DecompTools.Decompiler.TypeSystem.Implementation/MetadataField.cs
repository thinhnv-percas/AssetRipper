#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataField : IField, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IVariable
{
	private readonly MetadataModule module;

	private readonly FieldDefinitionHandle handle;

	private readonly FieldAttributes attributes;

	private ITypeDefinition declaringType;

	private string name;

	private object constantValue;

	private IType type;

	private bool isVolatile;

	private byte decimalConstantState;

	public EntityHandle MetadataToken => handle;

	public string Name
	{
		get
		{
			string text = LazyInit.VolatileRead(ref name);
			if (text != null)
			{
				return text;
			}
			MetadataReader metadata = module.metadata;
			FieldDefinition fieldDefinition = metadata.GetFieldDefinition(handle);
			return LazyInit.GetOrSet(ref name, metadata.GetString(fieldDefinition.Name));
		}
	}

	public Accessibility Accessibility => (attributes & FieldAttributes.FieldAccessMask) switch
	{
		FieldAttributes.Public => Accessibility.Public, 
		FieldAttributes.FamANDAssem => Accessibility.ProtectedAndInternal, 
		FieldAttributes.Assembly => Accessibility.Internal, 
		FieldAttributes.Family => Accessibility.Protected, 
		FieldAttributes.FamORAssem => Accessibility.ProtectedOrInternal, 
		_ => Accessibility.Private, 
	};

	public bool IsReadOnly => (attributes & FieldAttributes.InitOnly) != 0;

	public bool IsStatic => (attributes & FieldAttributes.Static) != 0;

	SymbolKind ISymbol.SymbolKind => SymbolKind.Field;

	IMember IMember.MemberDefinition => this;

	TypeParameterSubstitution IMember.Substitution => TypeParameterSubstitution.Identity;

	IEnumerable<IMember> IMember.ExplicitlyImplementedInterfaceMembers => EmptyList<IMember>.Instance;

	bool IMember.IsExplicitInterfaceImplementation => false;

	bool IMember.IsVirtual => false;

	bool IMember.IsOverride => false;

	bool IMember.IsOverridable => false;

	bool IEntity.IsAbstract => false;

	bool IEntity.IsSealed => false;

	public ITypeDefinition DeclaringTypeDefinition
	{
		get
		{
			ITypeDefinition typeDefinition = LazyInit.VolatileRead(ref declaringType);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
			FieldDefinition fieldDefinition = module.metadata.GetFieldDefinition(handle);
			return LazyInit.GetOrSet(ref declaringType, module.GetDefinition(fieldDefinition.GetDeclaringType()));
		}
	}

	public IType DeclaringType => DeclaringTypeDefinition;

	public IModule ParentModule => module;

	public ICompilation Compilation => module.Compilation;

	public string FullName => DeclaringType?.FullName + "." + Name;

	public string ReflectionName => DeclaringType?.ReflectionName + "." + Name;

	public string Namespace => DeclaringType?.Namespace ?? string.Empty;

	public bool IsVolatile
	{
		get
		{
			if (LazyInit.VolatileRead(ref type) == null)
			{
				DecodeTypeAndVolatileFlag();
			}
			return isVolatile;
		}
	}

	IType IMember.ReturnType => Type;

	public IType Type
	{
		get
		{
			IType type = LazyInit.VolatileRead(ref this.type);
			if (type != null)
			{
				return type;
			}
			return DecodeTypeAndVolatileFlag();
		}
	}

	public bool IsConst => (attributes & FieldAttributes.Literal) != FieldAttributes.PrivateScope || (IsDecimalConstant && DecimalConstantHelper.AllowsDecimalConstants(module));

	private bool IsDecimalConstant
	{
		get
		{
			if (decimalConstantState == 0)
			{
				FieldDefinition fieldDefinition = module.metadata.GetFieldDefinition(handle);
				decimalConstantState = ThreeState.From(DecimalConstantHelper.IsDecimalConstant(module, fieldDefinition.GetCustomAttributes()));
			}
			return decimalConstantState == 2;
		}
	}

	internal MetadataField(MetadataModule module, FieldDefinitionHandle handle)
	{
		Debug.Assert(module != null);
		Debug.Assert(!handle.IsNil);
		this.module = module;
		this.handle = handle;
		attributes = module.metadata.GetFieldDefinition(handle).Attributes;
		if ((attributes & (FieldAttributes.Static | FieldAttributes.InitOnly)) != (FieldAttributes.Static | FieldAttributes.InitOnly))
		{
			decimalConstantState = 1;
		}
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(handle):X8} {DeclaringType?.ReflectionName}.{Name}";
	}

	public IEnumerable<IAttribute> GetAttributes()
	{
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module);
		MetadataReader metadata = module.metadata;
		FieldDefinition fieldDefinition = metadata.GetFieldDefinition(handle);
		int offset = fieldDefinition.GetOffset();
		if (offset != -1)
		{
			attributeListBuilder.Add(KnownAttribute.FieldOffset, KnownTypeCode.Int32, offset);
		}
		if ((fieldDefinition.Attributes & FieldAttributes.NotSerialized) != FieldAttributes.PrivateScope)
		{
			attributeListBuilder.Add(KnownAttribute.NonSerialized);
		}
		attributeListBuilder.AddMarshalInfo(fieldDefinition.GetMarshallingDescriptor());
		attributeListBuilder.Add(fieldDefinition.GetCustomAttributes(), SymbolKind.Field);
		return attributeListBuilder.Build();
	}

	private IType DecodeTypeAndVolatileFlag()
	{
		MetadataReader metadata = module.metadata;
		FieldDefinition fieldDefinition = metadata.GetFieldDefinition(handle);
		IType type = fieldDefinition.DecodeSignature(module.TypeProvider, new GenericContext(DeclaringType?.TypeParameters));
		if (type is ModifiedType modifiedType && modifiedType.Modifier.Name == "IsVolatile" && modifiedType.Modifier.Namespace == "System.Runtime.CompilerServices")
		{
			Volatile.Write(ref isVolatile, value: true);
			type = modifiedType.ElementType;
		}
		type = ApplyAttributeTypeVisitor.ApplyAttributesToType(type, Compilation, fieldDefinition.GetCustomAttributes(), metadata, module.TypeSystemOptions);
		return LazyInit.GetOrSet(ref this.type, type);
	}

	public object GetConstantValue(bool throwOnInvalidMetadata)
	{
		object obj = LazyInit.VolatileRead(ref constantValue);
		if (obj != null)
		{
			return obj;
		}
		try
		{
			MetadataReader metadata = module.metadata;
			FieldDefinition fieldDefinition = metadata.GetFieldDefinition(handle);
			if (IsDecimalConstant && DecimalConstantHelper.AllowsDecimalConstants(module))
			{
				obj = DecimalConstantHelper.GetDecimalConstantValue(module, fieldDefinition.GetCustomAttributes());
			}
			else
			{
				ConstantHandle defaultValue = fieldDefinition.GetDefaultValue();
				if (defaultValue.IsNil)
				{
					return null;
				}
				Constant constant = metadata.GetConstant(defaultValue);
				BlobReader blobReader = metadata.GetBlobReader(constant.Value);
				try
				{
					obj = blobReader.ReadConstant(constant.TypeCode);
				}
				catch (ArgumentOutOfRangeException)
				{
					throw new BadImageFormatException($"Constant with invalid typecode: {constant.TypeCode}");
				}
			}
			return LazyInit.GetOrSet(ref constantValue, obj);
		}
		catch (BadImageFormatException) when (!throwOnInvalidMetadata)
		{
			return null;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj is MetadataField metadataField)
		{
			return handle == metadataField.handle && module.PEFile == metadataField.module.PEFile;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 0x11DDA32B ^ module.PEFile.GetHashCode() ^ handle.GetHashCode();
	}

	bool IMember.Equals(IMember obj, TypeVisitor typeNormalization)
	{
		return Equals(obj);
	}

	public IMember Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedField.Create(this, substitution);
	}
}
