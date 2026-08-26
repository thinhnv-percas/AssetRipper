#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataTypeParameter : AbstractTypeParameter
{
	private readonly MetadataModule module;

	private readonly GenericParameterHandle handle;

	private readonly GenericParameterAttributes attr;

	private IReadOnlyList<IType> constraints;

	private byte unmanagedConstraint = 0;

	private const byte nullabilityNotYetLoaded = byte.MaxValue;

	private byte nullabilityConstraint = byte.MaxValue;

	public GenericParameterHandle MetadataToken => handle;

	public override bool HasDefaultConstructorConstraint => (attr & GenericParameterAttributes.DefaultConstructorConstraint) != 0;

	public override bool HasReferenceTypeConstraint => (attr & GenericParameterAttributes.ReferenceTypeConstraint) != 0;

	public override bool HasValueTypeConstraint => (attr & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0;

	public override bool HasUnmanagedConstraint
	{
		get
		{
			if (unmanagedConstraint == 0)
			{
				unmanagedConstraint = ThreeState.From(LoadUnmanagedConstraint());
			}
			return unmanagedConstraint == 2;
		}
	}

	public override Nullability NullabilityConstraint
	{
		get
		{
			if (nullabilityConstraint == byte.MaxValue)
			{
				nullabilityConstraint = (byte)LoadNullabilityConstraint();
			}
			return (Nullability)nullabilityConstraint;
		}
	}

	public override IEnumerable<IType> DirectBaseTypes
	{
		get
		{
			IReadOnlyList<IType> readOnlyList = LazyInit.VolatileRead(ref constraints);
			if (readOnlyList != null)
			{
				return readOnlyList;
			}
			return LazyInit.GetOrSet(ref constraints, DecodeConstraints());
		}
	}

	public static ITypeParameter[] Create(MetadataModule module, ITypeDefinition copyFromOuter, IEntity owner, GenericParameterHandleCollection handles)
	{
		if (handles.Count == 0)
		{
			return Empty<ITypeParameter>.Array;
		}
		IReadOnlyList<ITypeParameter> typeParameters = copyFromOuter.TypeParameters;
		ITypeParameter[] array = new ITypeParameter[handles.Count];
		int num = 0;
		foreach (GenericParameterHandle item in handles)
		{
			if (num < typeParameters.Count)
			{
				array[num] = typeParameters[num];
			}
			else
			{
				array[num] = Create(module, owner, num, item);
			}
			num = checked(num + 1);
		}
		return array;
	}

	public static ITypeParameter[] Create(MetadataModule module, IEntity owner, GenericParameterHandleCollection handles)
	{
		if (handles.Count == 0)
		{
			return Empty<ITypeParameter>.Array;
		}
		ITypeParameter[] array = new ITypeParameter[handles.Count];
		int num = 0;
		foreach (GenericParameterHandle item in handles)
		{
			array[num] = Create(module, owner, num, item);
			num = checked(num + 1);
		}
		return array;
	}

	public static MetadataTypeParameter Create(MetadataModule module, IEntity owner, int index, GenericParameterHandle handle)
	{
		MetadataReader metadata = module.metadata;
		GenericParameter genericParameter = metadata.GetGenericParameter(handle);
		Debug.Assert(genericParameter.Index == index);
		return new MetadataTypeParameter(module, owner, index, module.GetString(genericParameter.Name), handle, genericParameter.Attributes);
	}

	private MetadataTypeParameter(MetadataModule module, IEntity owner, int index, string name, GenericParameterHandle handle, GenericParameterAttributes attr)
		: base(owner, index, name, GetVariance(attr))
	{
		this.module = module;
		this.handle = handle;
		this.attr = attr;
	}

	private static VarianceModifier GetVariance(GenericParameterAttributes attr)
	{
		return (attr & GenericParameterAttributes.VarianceMask) switch
		{
			GenericParameterAttributes.Contravariant => VarianceModifier.Contravariant, 
			GenericParameterAttributes.Covariant => VarianceModifier.Covariant, 
			_ => VarianceModifier.Invariant, 
		};
	}

	public override IEnumerable<IAttribute> GetAttributes()
	{
		MetadataReader metadata = module.metadata;
		CustomAttributeHandleCollection customAttributes = metadata.GetGenericParameter(handle).GetCustomAttributes();
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module, customAttributes.Count);
		attributeListBuilder.Add(customAttributes, SymbolKind.TypeParameter);
		return attributeListBuilder.Build();
	}

	private bool LoadUnmanagedConstraint()
	{
		if ((module.TypeSystemOptions & TypeSystemOptions.UnmanagedConstraints) == 0)
		{
			return false;
		}
		MetadataReader metadata = module.metadata;
		return metadata.GetGenericParameter(handle).GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.IsUnmanaged);
	}

	private Nullability LoadNullabilityConstraint()
	{
		if ((module.TypeSystemOptions & TypeSystemOptions.NullabilityAnnotations) == 0)
		{
			return Nullability.Oblivious;
		}
		MetadataReader metadata = module.metadata;
		foreach (CustomAttributeHandle customAttribute2 in metadata.GetGenericParameter(handle).GetCustomAttributes())
		{
			System.Reflection.Metadata.CustomAttribute customAttribute = metadata.GetCustomAttribute(customAttribute2);
			if (customAttribute.IsKnownAttribute(metadata, KnownAttribute.Nullable))
			{
				CustomAttributeValue<IType> customAttributeValue = customAttribute.DecodeValue(module.TypeProvider);
				if (customAttributeValue.FixedArguments.Length == 1 && customAttributeValue.FixedArguments[0].Value is byte b && b <= 2)
				{
					return (Nullability)b;
				}
			}
		}
		return Nullability.Oblivious;
	}

	private IReadOnlyList<IType> DecodeConstraints()
	{
		MetadataReader metadata = module.metadata;
		GenericParameterConstraintHandleCollection genericParameterConstraintHandleCollection = metadata.GetGenericParameter(handle).GetConstraints();
		List<IType> list = new List<IType>(checked(genericParameterConstraintHandleCollection.Count + 1));
		bool flag = false;
		foreach (GenericParameterConstraintHandle item in genericParameterConstraintHandleCollection)
		{
			GenericParameterConstraint genericParameterConstraint = metadata.GetGenericParameterConstraint(item);
			IType type = module.ResolveType(genericParameterConstraint.Type, new GenericContext(base.Owner), genericParameterConstraint.GetCustomAttributes());
			list.Add(type);
			flag |= type.Kind != TypeKind.Interface;
		}
		if (HasValueTypeConstraint)
		{
			list.Add(base.Compilation.FindType(KnownTypeCode.ValueType));
		}
		else if (!flag)
		{
			list.Add(base.Compilation.FindType(KnownTypeCode.Object));
		}
		return list;
	}

	public override int GetHashCode()
	{
		return 0x51FC5B83 ^ module.PEFile.GetHashCode() ^ handle.GetHashCode();
	}

	public override bool Equals(IType other)
	{
		return other is MetadataTypeParameter metadataTypeParameter && handle == metadataTypeParameter.handle && module.PEFile == metadataTypeParameter.module.PEFile;
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(handle):X8} Index={base.Index} Owner={base.Owner}";
	}
}
