#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

internal sealed class ApplyAttributeTypeVisitor : TypeVisitor
{
	private readonly ICompilation compilation;

	private readonly bool hasDynamicAttribute;

	private readonly bool[] dynamicAttributeData;

	private readonly TypeSystemOptions options;

	private readonly string[] tupleElementNames;

	private readonly Nullability defaultNullability;

	private readonly Nullability[] nullableAttributeData;

	private int dynamicTypeIndex = 0;

	private int tupleTypeIndex = 0;

	private int nullabilityTypeIndex = 0;

	public static IType ApplyAttributesToType(IType inputType, ICompilation compilation, CustomAttributeHandleCollection? attributes, MetadataReader metadata, TypeSystemOptions options, bool typeChildrenOnly = false)
	{
		bool flag = false;
		bool[] array = null;
		string[] array2 = null;
		bool flag2 = false;
		Nullability nullability = Nullability.Oblivious;
		Nullability[] array3 = null;
		if (attributes.HasValue && (options & (TypeSystemOptions.Dynamic | TypeSystemOptions.Tuple | TypeSystemOptions.NullabilityAnnotations)) != TypeSystemOptions.None)
		{
			foreach (CustomAttributeHandle item in attributes.Value)
			{
				System.Reflection.Metadata.CustomAttribute customAttribute = metadata.GetCustomAttribute(item);
				EntityHandle attributeType = customAttribute.GetAttributeType(metadata);
				if ((options & TypeSystemOptions.Dynamic) != TypeSystemOptions.None && attributeType.IsKnownType(metadata, KnownAttribute.Dynamic))
				{
					flag = true;
					CustomAttributeValue<IType> customAttributeValue = customAttribute.DecodeValue(MetadataExtensions.minimalCorlibTypeProvider);
					if (customAttributeValue.FixedArguments.Length == 1 && customAttributeValue.FixedArguments[0].Value is ImmutableArray<CustomAttributeTypedArgument<IType>> immutableArray && immutableArray.All((CustomAttributeTypedArgument<IType> v) => v.Value is bool))
					{
						array = immutableArray.SelectArray((CustomAttributeTypedArgument<IType> v) => (bool)v.Value);
					}
				}
				else if ((options & TypeSystemOptions.Tuple) != TypeSystemOptions.None && attributeType.IsKnownType(metadata, KnownAttribute.TupleElementNames))
				{
					CustomAttributeValue<IType> customAttributeValue2 = customAttribute.DecodeValue(MetadataExtensions.minimalCorlibTypeProvider);
					if (customAttributeValue2.FixedArguments.Length == 1 && customAttributeValue2.FixedArguments[0].Value is ImmutableArray<CustomAttributeTypedArgument<IType>> immutableArray2 && immutableArray2.All((CustomAttributeTypedArgument<IType> v) => v.Value is string || v.Value == null))
					{
						array2 = immutableArray2.SelectArray((CustomAttributeTypedArgument<IType> v) => (string)v.Value);
					}
				}
				else
				{
					if ((options & TypeSystemOptions.NullabilityAnnotations) == 0 || !attributeType.IsKnownType(metadata, KnownAttribute.Nullable))
					{
						continue;
					}
					flag2 = true;
					CustomAttributeValue<IType> customAttributeValue3 = customAttribute.DecodeValue(MetadataExtensions.minimalCorlibTypeProvider);
					if (customAttributeValue3.FixedArguments.Length != 1)
					{
						continue;
					}
					CustomAttributeTypedArgument<IType> customAttributeTypedArgument = customAttributeValue3.FixedArguments[0];
					if (customAttributeTypedArgument.Value is ImmutableArray<CustomAttributeTypedArgument<IType>> immutableArray3 && immutableArray3.All((CustomAttributeTypedArgument<IType> v) => v.Value is byte b2 && b2 <= 2))
					{
						array3 = immutableArray3.SelectArray((CustomAttributeTypedArgument<IType> v) => (Nullability)(byte)v.Value);
					}
					else if (customAttributeTypedArgument.Value is byte b && b <= 2)
					{
						nullability = (Nullability)(byte)customAttributeTypedArgument.Value;
					}
				}
			}
		}
		if ((flag | flag2) || (options & (TypeSystemOptions.Tuple | TypeSystemOptions.KeepModifiers)) != TypeSystemOptions.KeepModifiers)
		{
			ApplyAttributeTypeVisitor visitor = new ApplyAttributeTypeVisitor(compilation, flag, array, options, array2, nullability, array3);
			if (typeChildrenOnly)
			{
				return inputType.VisitChildren(visitor);
			}
			return inputType.AcceptVisitor(visitor);
		}
		return inputType;
	}

	private ApplyAttributeTypeVisitor(ICompilation compilation, bool hasDynamicAttribute, bool[] dynamicAttributeData, TypeSystemOptions options, string[] tupleElementNames, Nullability defaultNullability, Nullability[] nullableAttributeData)
	{
		this.compilation = compilation ?? throw new ArgumentNullException("compilation");
		this.hasDynamicAttribute = hasDynamicAttribute;
		this.dynamicAttributeData = dynamicAttributeData;
		this.options = options;
		this.tupleElementNames = tupleElementNames;
		this.defaultNullability = defaultNullability;
		this.nullableAttributeData = nullableAttributeData;
	}

	public override IType VisitModOpt(ModifiedType type)
	{
		if ((options & TypeSystemOptions.KeepModifiers) != TypeSystemOptions.None)
		{
			return base.VisitModOpt(type);
		}
		return type.ElementType.AcceptVisitor(this);
	}

	public override IType VisitModReq(ModifiedType type)
	{
		if ((options & TypeSystemOptions.KeepModifiers) != TypeSystemOptions.None)
		{
			return base.VisitModReq(type);
		}
		return type.ElementType.AcceptVisitor(this);
	}

	public override IType VisitPointerType(PointerType type)
	{
		checked
		{
			dynamicTypeIndex++;
			return base.VisitPointerType(type);
		}
	}

	private Nullability GetNullability()
	{
		if (nullabilityTypeIndex < nullableAttributeData?.Length)
		{
			return nullableAttributeData[nullabilityTypeIndex];
		}
		return defaultNullability;
	}

	public override IType VisitArrayType(ArrayType type)
	{
		Nullability nullability = GetNullability();
		checked
		{
			dynamicTypeIndex++;
			nullabilityTypeIndex++;
			return base.VisitArrayType(type).ChangeNullability(nullability);
		}
	}

	public override IType VisitByReferenceType(ByReferenceType type)
	{
		checked
		{
			dynamicTypeIndex++;
			return base.VisitByReferenceType(type);
		}
	}

	public override IType VisitParameterizedType(ParameterizedType type)
	{
		checked
		{
			if ((options & TypeSystemOptions.Tuple) != TypeSystemOptions.None && TupleType.IsTupleCompatible(type, out var tupleCardinality))
			{
				if (tupleCardinality > 1)
				{
					IModule valueTupleAssembly = type.GetDefinition()?.ParentModule;
					ImmutableArray<string> elementNames = default(ImmutableArray<string>);
					if (tupleElementNames != null && tupleTypeIndex < tupleElementNames.Length)
					{
						string[] array = new string[tupleCardinality];
						Array.Copy(tupleElementNames, tupleTypeIndex, array, 0, Math.Min(tupleCardinality, tupleElementNames.Length - tupleTypeIndex));
						elementNames = ImmutableArray.CreateRange(array);
					}
					tupleTypeIndex += tupleCardinality;
					ImmutableArray<IType>.Builder builder = ImmutableArray.CreateBuilder<IType>(tupleCardinality);
					do
					{
						int num = Math.Min(type.TypeArguments.Count, 7);
						for (int i = 0; i < num; i++)
						{
							dynamicTypeIndex++;
							nullabilityTypeIndex++;
							builder.Add(type.TypeArguments[i].AcceptVisitor(this));
						}
						if (type.TypeArguments.Count == 8)
						{
							type = Enumerable.Last<IType>((IEnumerable<IType>)type.TypeArguments) as ParameterizedType;
							dynamicTypeIndex++;
							nullabilityTypeIndex++;
							if (type != null && TupleType.IsTupleCompatible(type, out var tupleCardinality2))
							{
								tupleTypeIndex += tupleCardinality2;
								continue;
							}
							Debug.Fail("TRest should be another value tuple");
							type = null;
						}
						else
						{
							type = null;
						}
					}
					while (type != null);
					Debug.Assert(builder.Count == tupleCardinality);
					return new TupleType(compilation, builder.MoveToImmutable(), elementNames, valueTupleAssembly);
				}
				tupleTypeIndex += tupleCardinality;
			}
			IType type2 = type.GenericType.AcceptVisitor(this);
			bool flag = type.GenericType != type2;
			IType[] array2 = new IType[type.TypeArguments.Count];
			for (int j = 0; j < type.TypeArguments.Count; j++)
			{
				dynamicTypeIndex++;
				nullabilityTypeIndex++;
				array2[j] = type.TypeArguments[j].AcceptVisitor(this);
				flag = flag || array2[j] != type.TypeArguments[j];
			}
			if (!flag)
			{
				return type;
			}
			return new ParameterizedType(type2, array2);
		}
	}

	public override IType VisitTypeDefinition(ITypeDefinition type)
	{
		IType type2 = type;
		if (type.KnownTypeCode == KnownTypeCode.Object && hasDynamicAttribute)
		{
			if (dynamicAttributeData == null || dynamicTypeIndex >= dynamicAttributeData.Length)
			{
				type2 = SpecialType.Dynamic;
			}
			else if (dynamicAttributeData[dynamicTypeIndex])
			{
				type2 = SpecialType.Dynamic;
			}
		}
		Nullability nullability = GetNullability();
		return type2.ChangeNullability(nullability);
	}
}
