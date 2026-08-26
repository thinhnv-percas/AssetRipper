#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TypeSystemAstBuilder
{
	private readonly CSharpResolver resolver;

	private Dictionary<object, (KnownTypeCode Type, string Member)> specialConstants = new Dictionary<object, (KnownTypeCode, string)>
	{
		{
			byte.MaxValue,
			(KnownTypeCode.Byte, "MaxValue")
		},
		{
			sbyte.MinValue,
			(KnownTypeCode.SByte, "MinValue")
		},
		{
			sbyte.MaxValue,
			(KnownTypeCode.SByte, "MaxValue")
		},
		{
			short.MinValue,
			(KnownTypeCode.Int16, "MinValue")
		},
		{
			short.MaxValue,
			(KnownTypeCode.Int16, "MaxValue")
		},
		{
			ushort.MaxValue,
			(KnownTypeCode.UInt16, "MaxValue")
		},
		{
			int.MinValue,
			(KnownTypeCode.Int32, "MinValue")
		},
		{
			int.MaxValue,
			(KnownTypeCode.Int32, "MaxValue")
		},
		{
			uint.MaxValue,
			(KnownTypeCode.UInt32, "MaxValue")
		},
		{
			long.MinValue,
			(KnownTypeCode.Int64, "MinValue")
		},
		{
			long.MaxValue,
			(KnownTypeCode.Int64, "MaxValue")
		},
		{
			ulong.MaxValue,
			(KnownTypeCode.UInt64, "MaxValue")
		},
		{
			float.NaN,
			(KnownTypeCode.Single, "NaN")
		},
		{
			float.NegativeInfinity,
			(KnownTypeCode.Single, "NegativeInfinity")
		},
		{
			float.PositiveInfinity,
			(KnownTypeCode.Single, "PositiveInfinity")
		},
		{
			float.MinValue,
			(KnownTypeCode.Single, "MinValue")
		},
		{
			float.MaxValue,
			(KnownTypeCode.Single, "MaxValue")
		},
		{
			float.Epsilon,
			(KnownTypeCode.Single, "Epsilon")
		},
		{
			double.NaN,
			(KnownTypeCode.Double, "NaN")
		},
		{
			double.NegativeInfinity,
			(KnownTypeCode.Double, "NegativeInfinity")
		},
		{
			double.PositiveInfinity,
			(KnownTypeCode.Double, "PositiveInfinity")
		},
		{
			double.MinValue,
			(KnownTypeCode.Double, "MinValue")
		},
		{
			double.MaxValue,
			(KnownTypeCode.Double, "MaxValue")
		},
		{
			double.Epsilon,
			(KnownTypeCode.Double, "Epsilon")
		},
		{
			decimal.MinValue,
			(KnownTypeCode.Decimal, "MinValue")
		},
		{
			decimal.MaxValue,
			(KnownTypeCode.Decimal, "MaxValue")
		}
	};

	private const int MAX_DENOMINATOR = 1000;

	private const float MathF_PI = (float)Math.PI;

	private const float MathF_E = (float)Math.E;

	public bool AddTypeReferenceAnnotations { get; set; }

	public bool AddResolveResultAnnotations { get; set; }

	public bool ShowAccessibility { get; set; }

	public bool ShowModifiers { get; set; }

	public bool ShowBaseTypes { get; set; }

	public bool ShowTypeParameters { get; set; }

	public bool ShowTypeParametersForUnboundTypes { get; set; }

	public bool ShowTypeParameterConstraints { get; set; }

	public bool ShowParameterNames { get; set; }

	public bool ShowConstantValues { get; set; }

	public bool ShowAttributes { get; set; }

	public bool AlwaysUseShortTypeNames { get; set; }

	public bool AlwaysUseBuiltinTypeNames { get; set; }

	public NameLookupMode NameLookupMode { get; set; }

	public bool GenerateBody { get; set; }

	public bool UseCustomEvents { get; set; }

	public bool ConvertUnboundTypeArguments { get; set; }

	public bool UseAliases { get; set; }

	public bool UseSpecialConstants { get; set; }

	public bool PrintIntegralValuesAsHex { get; set; }

	public TypeSystemAstBuilder(CSharpResolver resolver)
	{
		if (resolver == null)
		{
			throw new ArgumentNullException("resolver");
		}
		this.resolver = resolver;
		InitProperties();
	}

	public TypeSystemAstBuilder()
	{
		InitProperties();
	}

	private void InitProperties()
	{
		AlwaysUseBuiltinTypeNames = true;
		ShowAccessibility = true;
		ShowModifiers = true;
		ShowBaseTypes = true;
		ShowTypeParameters = true;
		ShowTypeParameterConstraints = true;
		ShowParameterNames = true;
		ShowConstantValues = true;
		UseAliases = true;
		UseSpecialConstants = true;
	}

	public AstType ConvertType(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		AstType astType = ConvertTypeHelper(type);
		if (AddTypeReferenceAnnotations)
		{
			astType.AddAnnotation(type);
		}
		if (AddResolveResultAnnotations)
		{
			astType.AddAnnotation(new TypeResolveResult(type));
		}
		return astType;
	}

	public AstType ConvertType(FullTypeName fullTypeName)
	{
		if (resolver != null)
		{
			foreach (IModule module in resolver.Compilation.Modules)
			{
				ITypeDefinition typeDefinition = module.GetTypeDefinition(fullTypeName);
				if (typeDefinition != null)
				{
					return ConvertType(typeDefinition);
				}
			}
		}
		TopLevelTypeName topLevelTypeName = fullTypeName.TopLevelTypeName;
		AstType astType = ((!string.IsNullOrEmpty(topLevelTypeName.Namespace)) ? ((AstType)MakeMemberType(MakeSimpleType(topLevelTypeName.Namespace), topLevelTypeName.Name)) : ((AstType)MakeSimpleType(topLevelTypeName.Name)));
		for (int i = 0; i < fullTypeName.NestingLevel; i = checked(i + 1))
		{
			astType = MakeMemberType(astType, fullTypeName.GetNestedTypeName(i));
		}
		return astType;
	}

	private AstType ConvertTypeHelper(IType type)
	{
		if (type is TypeWithElementType typeWithElementType)
		{
			if (typeWithElementType is PointerType)
			{
				return ConvertType(typeWithElementType.ElementType).MakePointerType();
			}
			if (typeWithElementType is ArrayType)
			{
				AstType astType = ConvertType(typeWithElementType.ElementType).MakeArrayType(((ArrayType)type).Dimensions);
				if (type.Nullability == Nullability.Nullable)
				{
					return astType.MakeNullableType();
				}
				return astType;
			}
			if (typeWithElementType is ByReferenceType)
			{
				return ConvertType(typeWithElementType.ElementType).MakeRefType();
			}
			return ConvertType(typeWithElementType.ElementType);
		}
		if (type is ParameterizedType parameterizedType)
		{
			if (AlwaysUseBuiltinTypeNames && parameterizedType.IsKnownType(KnownTypeCode.NullableOfT))
			{
				return ConvertType(parameterizedType.TypeArguments[0]).MakeNullableType();
			}
			return ConvertTypeHelper(parameterizedType.GenericType, parameterizedType.TypeArguments);
		}
		if (type is NullabilityAnnotatedType nullabilityAnnotatedType)
		{
			AstType astType2 = ConvertType(nullabilityAnnotatedType.TypeWithoutAnnotation);
			if (nullabilityAnnotatedType.Nullability == Nullability.Nullable)
			{
				astType2 = astType2.MakeNullableType();
			}
			return astType2;
		}
		if (type is TupleType tupleType)
		{
			TupleAstType tupleAstType = new TupleAstType();
			foreach (var (type2, name) in tupleType.ElementTypes.Zip(tupleType.ElementNames))
			{
				tupleAstType.Elements.Add(new TupleTypeElement
				{
					Type = ConvertType(type2),
					Name = name
				});
			}
			return tupleAstType;
		}
		if (type is ITypeDefinition typeDefinition)
		{
			if (ShowTypeParametersForUnboundTypes)
			{
				return ConvertTypeHelper(typeDefinition, typeDefinition.TypeArguments);
			}
			if (typeDefinition.TypeParameterCount > 0)
			{
				IType[] array = new IType[typeDefinition.TypeParameterCount];
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i] = SpecialType.UnboundTypeArgument;
				}
				return ConvertTypeHelper(typeDefinition, array);
			}
			return ConvertTypeHelper(typeDefinition, EmptyList<IType>.Instance);
		}
		return MakeSimpleType(type.Name);
	}

	private AstType ConvertTypeHelper(IType genericType, IReadOnlyList<IType> typeArguments)
	{
		ITypeDefinition definition = genericType.GetDefinition();
		Debug.Assert(definition != null || genericType.Kind == TypeKind.Unknown);
		Debug.Assert(typeArguments.Count >= genericType.TypeParameterCount);
		if (AlwaysUseBuiltinTypeNames && definition != null)
		{
			string cSharpNameByTypeCode = KnownTypeReference.GetCSharpNameByTypeCode(definition.KnownTypeCode);
			if (cSharpNameByTypeCode != null)
			{
				if (genericType.Nullability == Nullability.Nullable)
				{
					return new PrimitiveType(cSharpNameByTypeCode).MakeNullableType();
				}
				return new PrimitiveType(cSharpNameByTypeCode);
			}
		}
		int num = genericType.DeclaringType?.TypeParameterCount ?? 0;
		checked
		{
			if (resolver != null && definition != null)
			{
				if (UseAliases)
				{
					for (ResolvedUsingScope resolvedUsingScope = resolver.CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
					{
						foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
						{
							if (usingAlias.Value is TypeResolveResult && TypeMatches(usingAlias.Value.Type, definition, typeArguments))
							{
								return MakeSimpleType(usingAlias.Key);
							}
						}
					}
				}
				IType[] array;
				if (definition.TypeParameterCount > num)
				{
					array = new IType[definition.TypeParameterCount - num];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = typeArguments[num + i];
					}
				}
				else
				{
					array = Empty<IType>.Array;
				}
				ResolveResult resolveResult = resolver.LookupSimpleNameOrTypeName(definition.Name, array, NameLookupMode);
				TypeResolveResult trr = resolveResult as TypeResolveResult;
				if ((trr != null || (array.Length == 0 && resolver.IsVariableReferenceWithSameType(resolveResult, definition.Name, out trr))) && !trr.IsError && TypeMatches(trr.Type, definition, typeArguments))
				{
					SimpleType result = MakeSimpleType(definition.Name);
					AddTypeArguments(result, definition.TypeParameters, typeArguments, num, definition.TypeParameterCount);
					return result;
				}
			}
			if (AlwaysUseShortTypeNames || (definition == null && genericType.DeclaringType == null))
			{
				SimpleType simpleType = MakeSimpleType(genericType.Name);
				AddTypeArguments(simpleType, genericType.TypeParameters, typeArguments, num, genericType.TypeParameterCount);
				if (genericType.Nullability == Nullability.Nullable)
				{
					return simpleType.MakeNullableType();
				}
				return simpleType;
			}
			MemberType memberType = new MemberType();
			if (genericType.DeclaringType != null)
			{
				memberType.Target = ConvertTypeHelper(genericType.DeclaringType, typeArguments);
			}
			else if (string.IsNullOrEmpty(genericType.Namespace))
			{
				memberType.Target = new SimpleType("global");
				if (AddResolveResultAnnotations && resolver != null)
				{
					memberType.Target.AddAnnotation(new NamespaceResolveResult(resolver.Compilation.RootNamespace));
				}
				memberType.IsDoubleColon = true;
			}
			else
			{
				memberType.Target = ConvertNamespace(genericType.Namespace, out var _);
			}
			memberType.MemberName = genericType.Name;
			AddTypeArguments(memberType, genericType.TypeParameters, typeArguments, num, genericType.TypeParameterCount);
			if (genericType.Nullability == Nullability.Nullable)
			{
				return memberType.MakeNullableType();
			}
			return memberType;
		}
	}

	private bool TypeMatches(IType type, ITypeDefinition typeDef, IReadOnlyList<IType> typeArguments)
	{
		if (typeDef.TypeParameterCount == 0)
		{
			return TypeDefMatches(typeDef, type);
		}
		if (!TypeDefMatches(typeDef, type.GetDefinition()))
		{
			return false;
		}
		if (!(type is ParameterizedType { TypeArguments: var typeArguments2 }))
		{
			return Enumerable.All<IType>((IEnumerable<IType>)typeArguments, (Func<IType, bool>)((IType t) => t.Kind == TypeKind.UnboundTypeArgument));
		}
		for (int num = 0; num < typeArguments2.Count; num = checked(num + 1))
		{
			if (!typeArguments2[num].Equals(typeArguments[num]))
			{
				return false;
			}
		}
		return true;
	}

	private bool TypeDefMatches(ITypeDefinition typeDef, IType type)
	{
		if (type.Name != typeDef.Name || type.Namespace != typeDef.Namespace || type.TypeParameterCount != typeDef.TypeParameterCount)
		{
			return false;
		}
		bool flag = typeDef.DeclaringTypeDefinition != null;
		bool flag2 = type.DeclaringType != null;
		if (flag & flag2)
		{
			return TypeDefMatches(typeDef.DeclaringTypeDefinition, type.DeclaringType);
		}
		return flag == flag2;
	}

	private void AddTypeArguments(AstType result, IReadOnlyList<ITypeParameter> typeParameters, IReadOnlyList<IType> typeArguments, int startIndex, int endIndex)
	{
		Debug.Assert(endIndex <= typeParameters.Count);
		for (int i = startIndex; i < endIndex; i = checked(i + 1))
		{
			if (ConvertUnboundTypeArguments && typeArguments[i].Kind == TypeKind.UnboundTypeArgument)
			{
				result.AddChild(MakeSimpleType(typeParameters[i].Name), Roles.TypeArgument);
			}
			else
			{
				result.AddChild(ConvertType(typeArguments[i]), Roles.TypeArgument);
			}
		}
	}

	public AstType ConvertNamespace(string namespaceName, out NamespaceResolveResult nrr)
	{
		if (resolver != null && UseAliases)
		{
			for (ResolvedUsingScope resolvedUsingScope = resolver.CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
			{
				foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
				{
					nrr = usingAlias.Value as NamespaceResolveResult;
					if (nrr != null && nrr.NamespaceName == namespaceName)
					{
						SimpleType simpleType = MakeSimpleType(usingAlias.Key);
						if (AddResolveResultAnnotations)
						{
							simpleType.AddAnnotation(nrr);
						}
						return simpleType;
					}
				}
			}
		}
		int num = namespaceName.LastIndexOf('.');
		if (num < 0)
		{
			if (IsValidNamespace(namespaceName, out nrr))
			{
				SimpleType simpleType2 = MakeSimpleType(namespaceName);
				if (AddResolveResultAnnotations && nrr != null)
				{
					simpleType2.AddAnnotation(nrr);
				}
				return simpleType2;
			}
			SimpleType simpleType3 = new SimpleType("global");
			if (AddResolveResultAnnotations)
			{
				simpleType3.AddAnnotation(new NamespaceResolveResult(resolver.Compilation.RootNamespace));
			}
			MemberType memberType = new MemberType
			{
				Target = simpleType3,
				IsDoubleColon = true,
				MemberName = namespaceName
			};
			if (AddResolveResultAnnotations)
			{
				INamespace childNamespace = resolver.Compilation.RootNamespace.GetChildNamespace(namespaceName);
				if (childNamespace != null)
				{
					memberType.AddAnnotation(nrr = new NamespaceResolveResult(childNamespace));
				}
			}
			return memberType;
		}
		string namespaceName2 = namespaceName.Substring(0, num);
		string text = namespaceName.Substring(checked(num + 1));
		AstType target = ConvertNamespace(namespaceName2, out var nrr2);
		MemberType memberType2 = new MemberType
		{
			Target = target,
			MemberName = text
		};
		nrr = null;
		if (AddResolveResultAnnotations && nrr2 != null)
		{
			INamespace childNamespace2 = nrr2.Namespace.GetChildNamespace(text);
			if (childNamespace2 != null)
			{
				memberType2.AddAnnotation(nrr = new NamespaceResolveResult(childNamespace2));
			}
		}
		return memberType2;
	}

	private bool IsValidNamespace(string firstNamespacePart, out NamespaceResolveResult nrr)
	{
		nrr = null;
		if (resolver == null)
		{
			return true;
		}
		nrr = resolver.ResolveSimpleName(firstNamespacePart, EmptyList<IType>.Instance) as NamespaceResolveResult;
		return nrr != null && !nrr.IsError && nrr.NamespaceName == firstNamespacePart;
	}

	private static SimpleType MakeSimpleType(string name)
	{
		if (name == "_")
		{
			return new SimpleType("@_");
		}
		return new SimpleType(name);
	}

	private static MemberType MakeMemberType(AstType target, string name)
	{
		if (name == "_")
		{
			return new MemberType(target, "@_");
		}
		return new MemberType(target, name);
	}

	public Attribute ConvertAttribute(IAttribute attribute)
	{
		Attribute attribute2 = new Attribute();
		attribute2.Type = ConvertAttributeType(attribute.AttributeType);
		SimpleType simpleType = attribute2.Type as SimpleType;
		MemberType memberType = attribute2.Type as MemberType;
		checked
		{
			if (simpleType != null && simpleType.Identifier.EndsWith("Attribute", StringComparison.Ordinal))
			{
				simpleType.Identifier = simpleType.Identifier.Substring(0, simpleType.Identifier.Length - 9);
			}
			else if (memberType != null && memberType.MemberName.EndsWith("Attribute", StringComparison.Ordinal))
			{
				memberType.MemberName = memberType.MemberName.Substring(0, memberType.MemberName.Length - 9);
			}
			IReadOnlyList<IParameter> readOnlyList = attribute.Constructor?.Parameters ?? EmptyList<IParameter>.Instance;
			for (int i = 0; i < attribute.FixedArguments.Length; i++)
			{
				CustomAttributeTypedArgument<IType> customAttributeTypedArgument = attribute.FixedArguments[i];
				IParameter obj = ((i < readOnlyList.Count) ? readOnlyList[i] : null);
				attribute2.Arguments.Add(ConvertConstantValue(obj?.Type ?? customAttributeTypedArgument.Type, customAttributeTypedArgument.Type, customAttributeTypedArgument.Value));
			}
			if (attribute.NamedArguments.Length > 0)
			{
				InitializedObjectResolveResult targetResult = new InitializedObjectResolveResult(attribute.AttributeType);
				foreach (CustomAttributeNamedArgument<IType> namedArgument in attribute.NamedArguments)
				{
					NamedExpression namedExpression = new NamedExpression(namedArgument.Name, ConvertConstantValue(namedArgument.Type, namedArgument.Value));
					if (AddResolveResultAnnotations)
					{
						IMember member = DecompTools.Decompiler.TypeSystem.Implementation.CustomAttribute.MemberForNamedArgument(attribute.AttributeType, namedArgument);
						if (member != null)
						{
							namedExpression.AddAnnotation(new MemberResolveResult(targetResult, member));
						}
					}
					attribute2.Arguments.Add(namedExpression);
				}
			}
			if (attribute.HasDecodeErrors)
			{
				attribute2.HasArgumentList = true;
				attribute2.AddChild(new Comment("Could not decode attribute arguments.", CommentType.MultiLine), Roles.Comment);
				attribute2.AddChild(new CSharpTokenNode(TextLocation.Empty, Roles.RPar), Roles.RPar);
			}
			return attribute2;
		}
	}

	private IEnumerable<AttributeSection> ConvertAttributes(IEnumerable<IAttribute> attibutes)
	{
		return Enumerable.Select<IAttribute, AttributeSection>(attibutes, (Func<IAttribute, AttributeSection>)((IAttribute a) => new AttributeSection(ConvertAttribute(a))));
	}

	private IEnumerable<AttributeSection> ConvertAttributes(IEnumerable<IAttribute> attibutes, string target)
	{
		return Enumerable.Select<IAttribute, AttributeSection>(attibutes, (Func<IAttribute, AttributeSection>)((IAttribute a) => new AttributeSection(ConvertAttribute(a))
		{
			AttributeTarget = target
		}));
	}

	public AstType ConvertAttributeType(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		AstType astType = ConvertTypeHelper(type);
		string text = null;
		if (type.Name.Length > 9 && type.Name.EndsWith("Attribute", StringComparison.Ordinal))
		{
			text = type.Name.Remove(checked(type.Name.Length - 9));
		}
		if (AlwaysUseShortTypeNames)
		{
			AstType astType2 = astType;
			AstType astType3 = astType2;
			if (astType3 != null)
			{
				if (!(astType3 is SimpleType simpleType))
				{
					if (astType3 is MemberType memberType)
					{
						MemberType memberType2 = memberType;
						memberType2.MemberName = text;
					}
				}
				else
				{
					SimpleType simpleType2 = simpleType;
					simpleType2.Identifier = text;
				}
			}
		}
		else if (resolver != null)
		{
			ApplyShortAttributeNameIfPossible(type, astType, text);
		}
		if (AddTypeReferenceAnnotations)
		{
			astType.AddAnnotation(type);
		}
		if (AddResolveResultAnnotations)
		{
			astType.AddAnnotation(new TypeResolveResult(type));
		}
		return astType;
	}

	private void ApplyShortAttributeNameIfPossible(IType type, AstType astType, string shortName)
	{
		if (astType == null)
		{
			return;
		}
		if (!(astType is SimpleType simpleType))
		{
			if (!(astType is MemberType memberType))
			{
				return;
			}
			MemberType memberType2 = memberType;
			if (type.DeclaringType != null)
			{
				ITypeDefinition definition = type.DeclaringType.GetDefinition();
				if (definition != null)
				{
					if (shortName != null && !Enumerable.Any<IType>(definition.GetNestedTypes((ITypeDefinition t) => t.TypeParameterCount == 0 && t.Name == shortName), (Func<IType, bool>)IsAttributeType))
					{
						memberType2.MemberName = shortName;
					}
					else if (Enumerable.Any<IType>(definition.GetNestedTypes((ITypeDefinition t) => t.TypeParameterCount == 0 && t.Name == type.Name + "Attribute"), (Func<IType, bool>)IsAttributeType))
					{
						memberType2.MemberName = "@" + memberType2.MemberName;
					}
				}
			}
			else if (memberType2.Target.GetResolveResult() is NamespaceResolveResult namespaceResolveResult)
			{
				if (shortName != null && !IsAttributeType(namespaceResolveResult.Namespace.GetTypeDefinition(shortName, 0)))
				{
					memberType2.MemberName = shortName;
				}
				else if (IsAttributeType(namespaceResolveResult.Namespace.GetTypeDefinition(type.Name + "Attribute", 0)))
				{
					memberType2.MemberName = "@" + memberType2.MemberName;
				}
			}
		}
		else
		{
			SimpleType simpleType2 = simpleType;
			ResolveResult resolveResult = null;
			ResolveResult rr = resolver.LookupSimpleNameOrTypeName(type.Name + "Attribute", EmptyList<IType>.Instance, NameLookupMode.Type);
			if (shortName != null)
			{
				resolveResult = resolver.LookupSimpleNameOrTypeName(shortName, EmptyList<IType>.Instance, NameLookupMode.Type);
			}
			if (resolveResult != null && (resolveResult is UnknownIdentifierResolveResult || !IsAttributeType(resolveResult)))
			{
				simpleType2.Identifier = shortName;
			}
			else if (IsAttributeType(rr))
			{
				simpleType2.Identifier = "@" + simpleType2.Identifier;
			}
		}
	}

	private bool IsAttributeType(IType type)
	{
		return type != null && Enumerable.Any<IType>(type.GetNonInterfaceBaseTypes(), (Func<IType, bool>)((IType t) => t.IsKnownType(KnownTypeCode.Attribute)));
	}

	private bool IsAttributeType(ResolveResult rr)
	{
		return rr is TypeResolveResult typeResolveResult && IsAttributeType(typeResolveResult.Type);
	}

	public Expression ConvertConstantValue(ResolveResult rr)
	{
		if (rr == null)
		{
			throw new ArgumentNullException("rr");
		}
		bool flag = false;
		if (rr is ConversionResolveResult conversionResolveResult)
		{
			rr = conversionResolveResult.Input;
			flag = conversionResolveResult.Conversion.IsBoxingConversion;
		}
		if (rr is TypeOfResolveResult)
		{
			TypeOfExpression typeOfExpression = new TypeOfExpression(ConvertType(((TypeOfResolveResult)rr).ReferencedType));
			if (AddResolveResultAnnotations)
			{
				typeOfExpression.AddAnnotation(rr);
			}
			return typeOfExpression;
		}
		if (rr is ArrayCreateResolveResult arrayCreateResolveResult)
		{
			ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
			arrayCreateExpression.Type = ConvertType(arrayCreateResolveResult.Type);
			if (arrayCreateExpression.Type is ComposedType composedType)
			{
				composedType.ArraySpecifiers.MoveTo(arrayCreateExpression.AdditionalArraySpecifiers);
				if (!composedType.HasNullableSpecifier && composedType.PointerRank == 0)
				{
					arrayCreateExpression.Type = composedType.BaseType;
				}
			}
			if (arrayCreateResolveResult.SizeArguments != null && arrayCreateResolveResult.InitializerElements == null)
			{
				arrayCreateExpression.AdditionalArraySpecifiers.FirstOrNullObject().Remove();
				arrayCreateExpression.Arguments.AddRange(Enumerable.Select<ResolveResult, Expression>((IEnumerable<ResolveResult>)arrayCreateResolveResult.SizeArguments, (Func<ResolveResult, Expression>)ConvertConstantValue));
			}
			if (arrayCreateResolveResult.InitializerElements != null)
			{
				ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
				arrayInitializerExpression.Elements.AddRange(Enumerable.Select<ResolveResult, Expression>((IEnumerable<ResolveResult>)arrayCreateResolveResult.InitializerElements, (Func<ResolveResult, Expression>)ConvertConstantValue));
				arrayCreateExpression.Initializer = arrayInitializerExpression;
			}
			if (AddResolveResultAnnotations)
			{
				arrayCreateExpression.AddAnnotation(rr);
			}
			return arrayCreateExpression;
		}
		if (rr.IsCompileTimeConstant)
		{
			Expression expression = ConvertConstantValue(rr.Type, rr.ConstantValue);
			if (flag && rr.Type.IsCSharpSmallIntegerType())
			{
				expression = new CastExpression(ConvertType(rr.Type), expression);
				if (AddResolveResultAnnotations)
				{
					expression.AddAnnotation(rr);
				}
			}
			return expression;
		}
		return new ErrorExpression();
	}

	public Expression ConvertConstantValue(IType type, object constantValue)
	{
		return ConvertConstantValue(type, type, constantValue);
	}

	public Expression ConvertConstantValue(IType expectedType, IType type, object constantValue)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (constantValue == null)
		{
			if (type.IsReferenceType == true)
			{
				NullReferenceExpression nullReferenceExpression = new NullReferenceExpression();
				if (AddResolveResultAnnotations)
				{
					nullReferenceExpression.AddAnnotation(new ConstantResolveResult(SpecialType.NullType, null));
				}
				return nullReferenceExpression;
			}
			DefaultValueExpression defaultValueExpression = new DefaultValueExpression(ConvertType(type));
			if (AddResolveResultAnnotations)
			{
				defaultValueExpression.AddAnnotation(new ConstantResolveResult(type, null));
			}
			return defaultValueExpression;
		}
		if (constantValue is IType type2)
		{
			TypeOfExpression typeOfExpression = new TypeOfExpression(ConvertType(type2));
			if (AddResolveResultAnnotations)
			{
				typeOfExpression.AddAnnotation(new TypeOfResolveResult(type, type2));
			}
			return typeOfExpression;
		}
		if (constantValue is ImmutableArray<CustomAttributeTypedArgument<IType>> immutableArray)
		{
			IType elementType = (type as ArrayType)?.ElementType ?? SpecialType.UnknownType;
			ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
			arrayCreateExpression.Type = ConvertType(type);
			if (arrayCreateExpression.Type is ComposedType composedType)
			{
				composedType.ArraySpecifiers.MoveTo(arrayCreateExpression.AdditionalArraySpecifiers);
				if (!composedType.HasNullableSpecifier && composedType.PointerRank == 0)
				{
					arrayCreateExpression.Type = composedType.BaseType;
				}
			}
			arrayCreateExpression.Initializer = new ArrayInitializerExpression(immutableArray.Select((CustomAttributeTypedArgument<IType> e) => ConvertConstantValue(elementType, e.Type, e.Value)));
			return arrayCreateExpression;
		}
		if (type.Kind == TypeKind.Enum)
		{
			return ConvertEnumValue(type, (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue, checkForOverflow: false));
		}
		if (IsSpecialConstant(type, constantValue, out var expression))
		{
			return expression;
		}
		if (type.IsKnownType(KnownTypeCode.Double) || type.IsKnownType(KnownTypeCode.Single))
		{
			return ConvertFloatingPointLiteral(type, constantValue);
		}
		IType type3 = type;
		bool flag = type.IsCSharpSmallIntegerType();
		if (flag)
		{
			constantValue = CSharpPrimitiveCast.Cast(TypeCode.Int32, constantValue, checkForOverflow: false);
			type3 = type.GetDefinition().Compilation.FindType(KnownTypeCode.Int32);
		}
		string literalValue = null;
		if (PrintIntegralValuesAsHex)
		{
			literalValue = $"0x{constantValue:X}";
		}
		expression = new PrimitiveExpression(constantValue, literalValue);
		if (AddResolveResultAnnotations)
		{
			expression.AddAnnotation(new ConstantResolveResult(type3, constantValue));
		}
		if (flag && !type.Equals(expectedType))
		{
			expression = new CastExpression(ConvertType(type), expression);
		}
		return expression;
	}

	private bool IsSpecialConstant(IType type, object constant, out Expression expression)
	{
		expression = null;
		if (!specialConstants.TryGetValue(constant, out var info))
		{
			return false;
		}
		IField field = Enumerable.SingleOrDefault<IField>(type.GetFields((IField p) => p.Name == info.Member));
		if (!UseSpecialConstants || field == null)
		{
			if (info.Type == KnownTypeCode.Double)
			{
				double num = (double)constant;
				double obj = num;
				if (double.NegativeInfinity.Equals(obj))
				{
					TranslatedExpression translatedExpression = new PrimitiveExpression(-1.0).WithoutILInstruction().WithRR(new ConstantResolveResult(type, -1.0));
					TranslatedExpression translatedExpression2 = new PrimitiveExpression(0.0).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0.0));
					expression = new BinaryOperatorExpression(translatedExpression, BinaryOperatorType.Divide, translatedExpression2).WithoutILInstruction().WithRR(new ConstantResolveResult(type, double.NegativeInfinity));
					return true;
				}
				if (double.PositiveInfinity.Equals(obj))
				{
					TranslatedExpression translatedExpression = new PrimitiveExpression(1.0).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 1.0));
					TranslatedExpression translatedExpression2 = new PrimitiveExpression(0.0).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0.0));
					expression = new BinaryOperatorExpression(translatedExpression, BinaryOperatorType.Divide, translatedExpression2).WithoutILInstruction().WithRR(new ConstantResolveResult(type, double.PositiveInfinity));
					return true;
				}
				if (double.NaN.Equals(obj))
				{
					TranslatedExpression translatedExpression = new PrimitiveExpression(0.0).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0.0));
					TranslatedExpression translatedExpression2 = new PrimitiveExpression(0.0).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0.0));
					expression = new BinaryOperatorExpression(translatedExpression, BinaryOperatorType.Divide, translatedExpression2).WithoutILInstruction().WithRR(new ConstantResolveResult(type, double.NaN));
					return true;
				}
			}
			if (info.Type == KnownTypeCode.Single)
			{
				float num2 = (float)constant;
				float obj2 = num2;
				if (float.NegativeInfinity.Equals(obj2))
				{
					TranslatedExpression translatedExpression3 = new PrimitiveExpression(-1f).WithoutILInstruction().WithRR(new ConstantResolveResult(type, -1f));
					TranslatedExpression translatedExpression4 = new PrimitiveExpression(0f).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0f));
					expression = new BinaryOperatorExpression(translatedExpression3, BinaryOperatorType.Divide, translatedExpression4).WithoutILInstruction().WithRR(new ConstantResolveResult(type, float.NegativeInfinity));
					return true;
				}
				if (float.PositiveInfinity.Equals(obj2))
				{
					TranslatedExpression translatedExpression3 = new PrimitiveExpression(1f).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 1f));
					TranslatedExpression translatedExpression4 = new PrimitiveExpression(0f).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0f));
					expression = new BinaryOperatorExpression(translatedExpression3, BinaryOperatorType.Divide, translatedExpression4).WithoutILInstruction().WithRR(new ConstantResolveResult(type, float.PositiveInfinity));
					return true;
				}
				if (float.NaN.Equals(obj2))
				{
					TranslatedExpression translatedExpression3 = new PrimitiveExpression(0f).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0f));
					TranslatedExpression translatedExpression4 = new PrimitiveExpression(0f).WithoutILInstruction().WithRR(new ConstantResolveResult(type, 0f));
					expression = new BinaryOperatorExpression(translatedExpression3, BinaryOperatorType.Divide, translatedExpression4).WithoutILInstruction().WithRR(new ConstantResolveResult(type, float.NaN));
					return true;
				}
			}
			return false;
		}
		expression = new TypeReferenceExpression(ConvertType(type));
		if (AddResolveResultAnnotations)
		{
			expression.AddAnnotation(new TypeResolveResult(type));
		}
		expression = new MemberReferenceExpression(expression, info.Member);
		if (AddResolveResultAnnotations)
		{
			expression.AddAnnotation(new MemberResolveResult(new TypeResolveResult(type), field));
		}
		return true;
	}

	private bool IsFlagsEnum(ITypeDefinition type)
	{
		return type.HasAttribute(KnownAttribute.Flags);
	}

	private Expression ConvertEnumValue(IType type, long val)
	{
		ITypeDefinition definition = type.GetDefinition();
		TypeCode typeCode = definition.EnumUnderlyingType.GetTypeCode();
		foreach (IField item in Enumerable.Where<IField>(definition.Fields, (Func<IField, bool>)((IField fld) => fld.IsConst)))
		{
			object constantValue = item.GetConstantValue();
			if (constantValue == null || !object.Equals(CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue, checkForOverflow: false), val))
			{
				continue;
			}
			MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(new TypeReferenceExpression(ConvertType(type)), item.Name);
			if (AddResolveResultAnnotations)
			{
				memberReferenceExpression.AddAnnotation(new MemberResolveResult(memberReferenceExpression.Target.GetResolveResult(), item));
			}
			return memberReferenceExpression;
		}
		if (IsFlagsEnum(definition))
		{
			long num = val;
			Expression expression = null;
			long num2 = ~val;
			switch (typeCode)
			{
			case TypeCode.SByte:
			case TypeCode.Byte:
				num2 &= 0xFF;
				break;
			case TypeCode.Int16:
			case TypeCode.UInt16:
				num2 &= 0xFFFF;
				break;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				num2 &= 0xFFFFFFFFu;
				break;
			}
			Expression expression2 = null;
			foreach (IField item2 in Enumerable.Where<IField>(definition.Fields, (Func<IField, bool>)((IField fld) => fld.IsConst)))
			{
				object constantValue2 = item2.GetConstantValue();
				long num3 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue2, checkForOverflow: false);
				if (num3 != 0)
				{
					if ((num3 & num) == num3)
					{
						MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(new TypeReferenceExpression(ConvertType(type)), item2.Name);
						expression = ((expression != null) ? ((Expression)new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseOr, memberReferenceExpression2)) : ((Expression)memberReferenceExpression2));
						num &= ~num3;
					}
					if ((num3 & num2) == num3)
					{
						MemberReferenceExpression memberReferenceExpression3 = new MemberReferenceExpression(new TypeReferenceExpression(ConvertType(type)), item2.Name);
						expression2 = ((expression2 != null) ? ((Expression)new BinaryOperatorExpression(expression2, BinaryOperatorType.BitwiseOr, memberReferenceExpression3)) : ((Expression)memberReferenceExpression3));
						num2 &= ~num3;
					}
				}
			}
			if (num == 0L && expression != null && (num2 != 0L || expression2 == null || Enumerable.Count<AstNode>(expression2.Descendants) >= Enumerable.Count<AstNode>(expression.Descendants)))
			{
				return expression;
			}
			if (num2 == 0L && expression2 != null)
			{
				return new UnaryOperatorExpression(UnaryOperatorType.BitNot, expression2);
			}
		}
		return new CastExpression(ConvertType(type), new PrimitiveExpression(CSharpPrimitiveCast.Cast(typeCode, val, checkForOverflow: false)));
	}

	private static bool IsValidFraction(long num, long den)
	{
		if (den <= 0 || num == 0)
		{
			return false;
		}
		if (den == 1 || Math.Abs(num) == 1)
		{
			return true;
		}
		return Math.Abs(num) < den && new int[3] { 2, 3, 5 }.Any((int x) => den % x == 0);
	}

	private static bool IsEqual(long num, long den, object constantValue, bool isDouble)
	{
		if (isDouble)
		{
			return (double)constantValue == (double)num / (double)den;
		}
		if (constantValue is float)
		{
			return (float)constantValue == (float)num / (float)den;
		}
		if (constantValue is int)
		{
			return (float)(int)constantValue == (float)num / (float)den;
		}
		if (constantValue is long)
		{
			return (float)(long)constantValue == (float)num / (float)den;
		}
		return float.Parse(string.Concat(constantValue)) == (float)num / (float)den;
	}

	private Expression ConvertFloatingPointLiteral(IType type, object constantValue)
	{
		try
		{
			bool flag = type.IsKnownType(KnownTypeCode.Single);
			bool flag2 = type.IsKnownType(KnownTypeCode.Double);
			if (flag && constantValue is int)
			{
				constantValue = (float)(int)constantValue;
			}
			if (flag && constantValue is uint)
			{
				constantValue = (float)(uint)constantValue;
			}
			if (flag && constantValue is long)
			{
				constantValue = (float)(long)constantValue;
			}
			if (flag2 && constantValue is int)
			{
				constantValue = (double)(int)constantValue;
			}
			if (flag2 && constantValue is uint)
			{
				constantValue = (double)(uint)constantValue;
			}
			if (flag2 && constantValue is long)
			{
				constantValue = (double)(long)constantValue;
			}
			ICompilation compilation = type.GetDefinition().Compilation;
			Expression expression = null;
			string text;
			if (flag2)
			{
				if (Math.Floor((double)constantValue) == (double)constantValue)
				{
					expression = new PrimitiveExpression(constantValue);
				}
				text = ((double)constantValue).ToString("r");
			}
			else
			{
				if (Math.Floor((float)constantValue) == (double)(float)constantValue)
				{
					expression = new PrimitiveExpression(constantValue);
				}
				text = ((float)constantValue).ToString("r");
			}
			bool flag3 = checked(text.Length - ((!text.StartsWith("-", StringComparison.OrdinalIgnoreCase)) ? 1 : 2)) > 5;
			try
			{
				if (flag3 && expression == null && UseSpecialConstants)
				{
					IType type2;
					if (flag2)
					{
						type2 = compilation.FindType(typeof(Math));
					}
					else
					{
						type2 = compilation.FindType(new TopLevelTypeName("System", "MathF")).GetDefinition();
						if (type2 == null || !Enumerable.Any<IField>(type2.GetFields((IField f) => f.Name == "PI" && f.IsConst)) || !Enumerable.Any<IField>(type2.GetFields((IField f) => f.Name == "E" && f.IsConst)))
						{
							type2 = compilation.FindType(typeof(Math));
						}
					}
					expression = TryExtractExpression(type2, type, constantValue, "PI", flag2) ?? TryExtractExpression(type2, type, constantValue, "E", flag2);
				}
			}
			catch
			{
			}
			try
			{
				if (flag3 && expression == null)
				{
					var (num, num2) = (flag2 ? FractionApprox((double)constantValue, 1000) : FractionApprox((float)constantValue, 1000));
					if (IsValidFraction(num, num2) && IsEqual(num, num2, constantValue, flag2) && Math.Abs(num) != 1 && Math.Abs(num2) != 1)
					{
						Expression left = MakeConstant(type, num);
						Expression right = MakeConstant(type, num2);
						return new BinaryOperatorExpression(left, BinaryOperatorType.Divide, right).WithoutILInstruction().WithRR(new ConstantResolveResult(type, constantValue));
					}
				}
			}
			catch
			{
			}
			if (expression == null)
			{
				expression = new PrimitiveExpression(constantValue);
			}
			if (AddResolveResultAnnotations)
			{
				expression.AddAnnotation(new ConstantResolveResult(type, constantValue));
			}
			return expression;
		}
		catch (Exception ex)
		{
			Console.WriteLine("constantValue=" + constantValue);
			Console.WriteLine("constantValue.t=" + constantValue.GetType().Name);
			Console.WriteLine("type=" + type);
			Console.WriteLine("type.t=" + type.GetType().Name);
			Console.WriteLine(string.Concat(ex));
			return new PrimitiveExpression(constantValue);
		}
	}

	private Expression MakeConstant(IType type, long c)
	{
		return new PrimitiveExpression(CSharpPrimitiveCast.Cast(type.GetTypeCode(), c, checkForOverflow: true));
	}

	private Expression TryExtractExpression(IType mathType, IType type, object literalValue, string memberName, bool isDouble)
	{
		try
		{
			long num;
			long num2;
			(num, num2) = (isDouble ? FractionApprox((double)literalValue / ((memberName == "PI") ? Math.PI : Math.E), 1000) : FractionApprox((float)literalValue / ((memberName == "PI") ? ((float)Math.PI) : ((float)Math.E)), 1000));
			if (IsValidFraction(num, num2))
			{
				return ExtractExpression(num, num2);
			}
			(num, num2) = (isDouble ? FractionApprox((double)literalValue * ((memberName == "PI") ? Math.PI : Math.E), 1000) : FractionApprox((float)literalValue * ((memberName == "PI") ? ((float)Math.PI) : ((float)Math.E)), 1000));
			if (IsValidFraction(num, num2))
			{
				return ExtractExpression(num, num2);
			}
		}
		catch
		{
		}
		return null;
		Expression ExtractExpression(long n, long d)
		{
			Expression expression = MakeFieldReference();
			Expression expression2 = expression;
			switch (n)
			{
			case -1L:
				expression2 = new UnaryOperatorExpression(UnaryOperatorType.Minus, expression2);
				break;
			default:
				expression2 = new BinaryOperatorExpression(expression2, BinaryOperatorType.Multiply, MakeConstant(type, n));
				break;
			case 1L:
				break;
			}
			if (d != 1)
			{
				expression2 = new BinaryOperatorExpression(expression2, BinaryOperatorType.Divide, MakeConstant(type, d));
			}
			if (isDouble)
			{
				double num3 = ((memberName == "PI") ? Math.PI : Math.E);
				double num4 = num3 * (double)n / (double)d;
				if (num4 == (double)literalValue)
				{
					return expression2;
				}
			}
			else
			{
				float num5 = ((memberName == "PI") ? ((float)Math.PI) : ((float)Math.E));
				float num6 = num5 * (float)n / (float)d;
				if (num6 == (float)literalValue)
				{
					return expression2;
				}
			}
			expression2 = expression.Detach();
			if (d == 1)
			{
				expression2 = new BinaryOperatorExpression(MakeConstant(type, n), BinaryOperatorType.Divide, expression2);
			}
			else
			{
				expression2 = new BinaryOperatorExpression(MakeConstant(type, d), BinaryOperatorType.Multiply, expression2);
				expression2 = new BinaryOperatorExpression(MakeConstant(type, n), BinaryOperatorType.Divide, expression2);
			}
			if (isDouble)
			{
				double num7 = ((memberName == "PI") ? Math.PI : Math.E);
				double num8 = (double)n / ((double)d * num7);
				if (num8 == (double)literalValue)
				{
					return expression2;
				}
			}
			else
			{
				float num9 = ((memberName == "PI") ? ((float)Math.PI) : ((float)Math.E));
				float num10 = (float)n / ((float)d * num9);
				if (num10 == (float)literalValue)
				{
					return expression2;
				}
			}
			return null;
		}
		Expression MakeFieldReference()
		{
			AstType astType = ConvertType(mathType);
			MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(new TypeReferenceExpression(astType), memberName);
			if (AddResolveResultAnnotations)
			{
				memberReferenceExpression.WithRR(new MemberResolveResult(astType.GetResolveResult(), Enumerable.Single<IField>(mathType.GetFields((IField f) => f.Name == memberName))));
			}
			if (type.IsKnownType(KnownTypeCode.Double))
			{
				return memberReferenceExpression;
			}
			if (mathType.Name == "MathF")
			{
				return memberReferenceExpression;
			}
			return new CastExpression(ConvertType(type), memberReferenceExpression);
		}
	}

	private static (long Num, long Den) FractionApprox(double value, int maxDenominator)
	{
		if (value > 2147483647.0)
		{
			return (Num: 0L, Den: 0L);
		}
		double num = value;
		if (value < 0.0)
		{
			value = 0.0 - value;
		}
		long[,] array = new long[2, 2];
		array[0, 0] = (array[1, 1] = 1L);
		array[0, 1] = (array[1, 0] = 0L);
		double num2 = value;
		long num5;
		long num6;
		long num3;
		checked
		{
			while (array[1, 0] * (num3 = (long)num2) + array[1, 1] <= maxDenominator)
			{
				long num4 = array[0, 0] * num3 + array[0, 1];
				array[0, 1] = array[0, 0];
				array[0, 0] = num4;
				num4 = array[1, 0] * num3 + array[1, 1];
				array[1, 1] = array[1, 0];
				array[1, 0] = num4;
				if (num2 - (double)num3 == 0.0)
				{
					break;
				}
				num2 = 1.0 / (num2 - (double)num3);
				if (Math.Abs(num2) > 9.223372036854776E+18)
				{
					break;
				}
			}
			if (array[1, 0] == 0)
			{
				return (Num: 0L, Den: 0L);
			}
			num5 = array[0, 0];
			num6 = array[1, 0];
		}
		num3 = checked(maxDenominator - array[1, 1]) / array[1, 0];
		checked
		{
			long num7 = array[0, 0] * num3 + array[0, 1];
			long num8 = array[1, 0] * num3 + array[1, 1];
			double num9 = Math.Abs(value - (double)num5 / (double)num6);
			double num10 = Math.Abs(value - (double)num7 / (double)num8);
			if (num9 < num10)
			{
				return (Num: (num < 0.0) ? (-num5) : num5, Den: num6);
			}
			return (Num: (num < 0.0) ? (-num7) : num7, Den: num8);
		}
	}

	public ParameterDeclaration ConvertParameter(IParameter parameter)
	{
		if (parameter == null)
		{
			throw new ArgumentNullException("parameter");
		}
		ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
		if (parameter.IsRef)
		{
			parameterDeclaration.ParameterModifier = ParameterModifier.Ref;
		}
		else if (parameter.IsOut)
		{
			parameterDeclaration.ParameterModifier = ParameterModifier.Out;
		}
		else if (parameter.IsIn)
		{
			parameterDeclaration.ParameterModifier = ParameterModifier.In;
		}
		else if (parameter.IsParams)
		{
			parameterDeclaration.ParameterModifier = ParameterModifier.Params;
		}
		if (ShowAttributes)
		{
			parameterDeclaration.Attributes.AddRange(ConvertAttributes(parameter.GetAttributes()));
		}
		if (parameter.Type.Kind == TypeKind.ByReference)
		{
			parameterDeclaration.Type = ConvertType(((ByReferenceType)parameter.Type).ElementType);
		}
		else
		{
			parameterDeclaration.Type = ConvertType(parameter.Type);
		}
		if (ShowParameterNames)
		{
			parameterDeclaration.Name = parameter.Name;
		}
		if (parameter.IsOptional && parameter.HasConstantValueInSignature && ShowConstantValues)
		{
			try
			{
				parameterDeclaration.DefaultExpression = ConvertConstantValue(parameter.Type, parameter.GetConstantValue(throwOnInvalidMetadata: true));
			}
			catch (BadImageFormatException ex)
			{
				parameterDeclaration.DefaultExpression = new ErrorExpression(ex.Message);
			}
		}
		return parameterDeclaration;
	}

	public AstNode ConvertSymbol(ISymbol symbol)
	{
		if (symbol == null)
		{
			throw new ArgumentNullException("symbol");
		}
		switch (symbol.SymbolKind)
		{
		case SymbolKind.Namespace:
			return ConvertNamespaceDeclaration((INamespace)symbol);
		case SymbolKind.Variable:
			return ConvertVariable((IVariable)symbol);
		case SymbolKind.Parameter:
			return ConvertParameter((IParameter)symbol);
		case SymbolKind.TypeParameter:
			return ConvertTypeParameter((ITypeParameter)symbol);
		default:
			if (symbol is IEntity entity)
			{
				return ConvertEntity(entity);
			}
			throw new ArgumentException("Invalid value for SymbolKind: " + symbol.SymbolKind);
		}
	}

	public EntityDeclaration ConvertEntity(IEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		switch (entity.SymbolKind)
		{
		case SymbolKind.TypeDefinition:
			return ConvertTypeDefinition((ITypeDefinition)entity);
		case SymbolKind.Field:
			return ConvertField((IField)entity);
		case SymbolKind.Property:
			return ConvertProperty((IProperty)entity);
		case SymbolKind.Indexer:
			return ConvertIndexer((IProperty)entity);
		case SymbolKind.Event:
			return ConvertEvent((IEvent)entity);
		case SymbolKind.Method:
			return ConvertMethod((IMethod)entity);
		case SymbolKind.Operator:
			return ConvertOperator((IMethod)entity);
		case SymbolKind.Constructor:
			return ConvertConstructor((IMethod)entity);
		case SymbolKind.Destructor:
			return ConvertDestructor((IMethod)entity);
		case SymbolKind.Accessor:
		{
			IMethod method = (IMethod)entity;
			return ConvertAccessor(method, (method.AccessorOwner != null) ? method.AccessorOwner.Accessibility : Accessibility.None, addParameterAttribute: false);
		}
		default:
			throw new ArgumentException("Invalid value for SymbolKind: " + entity.SymbolKind);
		}
	}

	private EntityDeclaration ConvertTypeDefinition(ITypeDefinition typeDefinition)
	{
		Modifiers modifiers = Modifiers.None;
		if (ShowAccessibility)
		{
			modifiers |= ModifierFromAccessibility(typeDefinition.Accessibility);
		}
		if (ShowModifiers)
		{
			if (typeDefinition.IsStatic)
			{
				modifiers |= Modifiers.Static;
			}
			else if (typeDefinition.IsAbstract)
			{
				modifiers |= Modifiers.Abstract;
			}
			else if (typeDefinition.IsSealed)
			{
				modifiers |= Modifiers.Sealed;
			}
		}
		ClassType classType;
		switch (typeDefinition.Kind)
		{
		case TypeKind.Struct:
			classType = ClassType.Struct;
			modifiers &= ~Modifiers.Sealed;
			if (ShowModifiers)
			{
				if (typeDefinition.IsReadOnly)
				{
					modifiers |= Modifiers.Readonly;
				}
				if (typeDefinition.IsByRefLike)
				{
					modifiers |= Modifiers.Ref;
				}
			}
			break;
		case TypeKind.Enum:
			classType = ClassType.Enum;
			modifiers &= ~Modifiers.Sealed;
			break;
		case TypeKind.Interface:
			classType = ClassType.Interface;
			modifiers &= ~Modifiers.Abstract;
			break;
		case TypeKind.Delegate:
		{
			IMethod delegateInvokeMethod = typeDefinition.GetDelegateInvokeMethod();
			if (delegateInvokeMethod != null)
			{
				return ConvertDelegate(delegateInvokeMethod, modifiers);
			}
			goto default;
		}
		default:
			classType = ClassType.Class;
			break;
		}
		TypeDeclaration typeDeclaration = new TypeDeclaration();
		typeDeclaration.ClassType = classType;
		typeDeclaration.Modifiers = modifiers;
		if (ShowAttributes)
		{
			typeDeclaration.Attributes.AddRange(ConvertAttributes(typeDefinition.GetAttributes()));
		}
		if (AddResolveResultAnnotations)
		{
			typeDeclaration.AddAnnotation(new TypeResolveResult(typeDefinition));
		}
		typeDeclaration.Name = ((typeDefinition.Name == "_") ? "@_" : typeDefinition.Name);
		int num = ((typeDefinition.DeclaringTypeDefinition != null) ? typeDefinition.DeclaringTypeDefinition.TypeParameterCount : 0);
		if (ShowTypeParameters)
		{
			foreach (ITypeParameter item in Enumerable.Skip<ITypeParameter>((IEnumerable<ITypeParameter>)typeDefinition.TypeParameters, num))
			{
				typeDeclaration.TypeParameters.Add(ConvertTypeParameter(item));
			}
		}
		if (ShowBaseTypes)
		{
			foreach (IType directBaseType in typeDefinition.DirectBaseTypes)
			{
				if (directBaseType.IsKnownType(KnownTypeCode.Enum))
				{
					if (!typeDefinition.EnumUnderlyingType.IsKnownType(KnownTypeCode.Int32))
					{
						typeDeclaration.BaseTypes.Add(ConvertType(typeDefinition.EnumUnderlyingType));
					}
				}
				else if (!directBaseType.IsKnownType(KnownTypeCode.Object) && !directBaseType.IsKnownType(KnownTypeCode.ValueType))
				{
					typeDeclaration.BaseTypes.Add(ConvertType(directBaseType));
				}
			}
		}
		if (ShowTypeParameters && ShowTypeParameterConstraints)
		{
			foreach (ITypeParameter item2 in Enumerable.Skip<ITypeParameter>((IEnumerable<ITypeParameter>)typeDefinition.TypeParameters, num))
			{
				Constraint constraint = ConvertTypeParameterConstraint(item2);
				if (constraint != null)
				{
					typeDeclaration.Constraints.Add(constraint);
				}
			}
		}
		return typeDeclaration;
	}

	private DelegateDeclaration ConvertDelegate(IMethod invokeMethod, Modifiers modifiers)
	{
		ITypeDefinition declaringTypeDefinition = invokeMethod.DeclaringTypeDefinition;
		DelegateDeclaration delegateDeclaration = new DelegateDeclaration();
		delegateDeclaration.Modifiers = modifiers & ~Modifiers.Sealed;
		if (ShowAttributes)
		{
			delegateDeclaration.Attributes.AddRange(ConvertAttributes(declaringTypeDefinition.GetAttributes()));
			delegateDeclaration.Attributes.AddRange(ConvertAttributes(invokeMethod.GetReturnTypeAttributes(), "return"));
		}
		if (AddResolveResultAnnotations)
		{
			delegateDeclaration.AddAnnotation(new TypeResolveResult(declaringTypeDefinition));
		}
		delegateDeclaration.ReturnType = ConvertType(invokeMethod.ReturnType);
		delegateDeclaration.Name = declaringTypeDefinition.Name;
		int num = ((declaringTypeDefinition.DeclaringTypeDefinition != null) ? declaringTypeDefinition.DeclaringTypeDefinition.TypeParameterCount : 0);
		if (ShowTypeParameters)
		{
			foreach (ITypeParameter item in Enumerable.Skip<ITypeParameter>((IEnumerable<ITypeParameter>)declaringTypeDefinition.TypeParameters, num))
			{
				delegateDeclaration.TypeParameters.Add(ConvertTypeParameter(item));
			}
		}
		foreach (IParameter parameter in invokeMethod.Parameters)
		{
			delegateDeclaration.Parameters.Add(ConvertParameter(parameter));
		}
		if (ShowTypeParameters && ShowTypeParameterConstraints)
		{
			foreach (ITypeParameter item2 in Enumerable.Skip<ITypeParameter>((IEnumerable<ITypeParameter>)declaringTypeDefinition.TypeParameters, num))
			{
				Constraint constraint = ConvertTypeParameterConstraint(item2);
				if (constraint != null)
				{
					delegateDeclaration.Constraints.Add(constraint);
				}
			}
		}
		return delegateDeclaration;
	}

	private FieldDeclaration ConvertField(IField field)
	{
		FieldDeclaration fieldDeclaration = new FieldDeclaration();
		if (ShowModifiers)
		{
			Modifiers modifiers = GetMemberModifiers(field);
			if (field.IsConst)
			{
				modifiers &= ~Modifiers.Static;
				modifiers |= Modifiers.Const;
			}
			else if (field.IsReadOnly)
			{
				modifiers |= Modifiers.Readonly;
			}
			else if (field.IsVolatile)
			{
				modifiers |= Modifiers.Volatile;
			}
			fieldDeclaration.Modifiers = modifiers;
		}
		if (ShowAttributes)
		{
			fieldDeclaration.Attributes.AddRange(ConvertAttributes(field.GetAttributes()));
		}
		if (AddResolveResultAnnotations)
		{
			fieldDeclaration.AddAnnotation(new MemberResolveResult(null, field));
		}
		fieldDeclaration.ReturnType = ConvertType(field.ReturnType);
		Expression initializer = null;
		if (field.IsConst && ShowConstantValues)
		{
			try
			{
				initializer = ConvertConstantValue(field.Type, field.GetConstantValue(throwOnInvalidMetadata: true));
			}
			catch (BadImageFormatException ex)
			{
				initializer = new ErrorExpression(ex.Message);
			}
		}
		fieldDeclaration.Variables.Add(new VariableInitializer(field.Name, initializer));
		return fieldDeclaration;
	}

	private BlockStatement GenerateBodyBlock()
	{
		if (GenerateBody)
		{
			return new BlockStatement
			{
				new ThrowStatement(new ObjectCreateExpression(ConvertType(new TopLevelTypeName("System", "NotImplementedException"))))
			};
		}
		return BlockStatement.Null;
	}

	private Accessor ConvertAccessor(IMethod accessor, Accessibility ownerAccessibility, bool addParameterAttribute)
	{
		if (accessor == null)
		{
			return Accessor.Null;
		}
		Accessor accessor2 = new Accessor();
		if (ShowAccessibility && accessor.Accessibility != ownerAccessibility)
		{
			accessor2.Modifiers = ModifierFromAccessibility(accessor.Accessibility);
		}
		if (ShowAttributes)
		{
			accessor2.Attributes.AddRange(ConvertAttributes(accessor.GetAttributes()));
			accessor2.Attributes.AddRange(ConvertAttributes(accessor.GetReturnTypeAttributes(), "return"));
			if (addParameterAttribute && accessor.Parameters.Count > 0)
			{
				accessor2.Attributes.AddRange(ConvertAttributes(Enumerable.Last<IParameter>((IEnumerable<IParameter>)accessor.Parameters).GetAttributes(), "param"));
			}
		}
		if (AddResolveResultAnnotations)
		{
			accessor2.AddAnnotation(new MemberResolveResult(null, accessor));
		}
		accessor2.Body = GenerateBodyBlock();
		return accessor2;
	}

	private PropertyDeclaration ConvertProperty(IProperty property)
	{
		PropertyDeclaration propertyDeclaration = new PropertyDeclaration();
		propertyDeclaration.Modifiers = GetMemberModifiers(property);
		if (ShowAttributes)
		{
			propertyDeclaration.Attributes.AddRange(ConvertAttributes(property.GetAttributes()));
		}
		if (AddResolveResultAnnotations)
		{
			propertyDeclaration.AddAnnotation(new MemberResolveResult(null, property));
		}
		propertyDeclaration.ReturnType = ConvertType(property.ReturnType);
		propertyDeclaration.Name = property.Name;
		propertyDeclaration.Getter = ConvertAccessor(property.Getter, property.Accessibility, addParameterAttribute: false);
		propertyDeclaration.Setter = ConvertAccessor(property.Setter, property.Accessibility, addParameterAttribute: true);
		propertyDeclaration.PrivateImplementationType = GetExplicitInterfaceType(property);
		return propertyDeclaration;
	}

	private IndexerDeclaration ConvertIndexer(IProperty indexer)
	{
		IndexerDeclaration indexerDeclaration = new IndexerDeclaration();
		indexerDeclaration.Modifiers = GetMemberModifiers(indexer);
		if (ShowAttributes)
		{
			indexerDeclaration.Attributes.AddRange(ConvertAttributes(indexer.GetAttributes()));
		}
		if (AddResolveResultAnnotations)
		{
			indexerDeclaration.AddAnnotation(new MemberResolveResult(null, indexer));
		}
		indexerDeclaration.ReturnType = ConvertType(indexer.ReturnType);
		foreach (IParameter parameter in indexer.Parameters)
		{
			indexerDeclaration.Parameters.Add(ConvertParameter(parameter));
		}
		indexerDeclaration.Getter = ConvertAccessor(indexer.Getter, indexer.Accessibility, addParameterAttribute: false);
		indexerDeclaration.Setter = ConvertAccessor(indexer.Setter, indexer.Accessibility, addParameterAttribute: true);
		indexerDeclaration.PrivateImplementationType = GetExplicitInterfaceType(indexer);
		return indexerDeclaration;
	}

	private EntityDeclaration ConvertEvent(IEvent ev)
	{
		if (UseCustomEvents)
		{
			CustomEventDeclaration customEventDeclaration = new CustomEventDeclaration();
			customEventDeclaration.Modifiers = GetMemberModifiers(ev);
			if (ShowAttributes)
			{
				customEventDeclaration.Attributes.AddRange(ConvertAttributes(ev.GetAttributes()));
			}
			if (AddResolveResultAnnotations)
			{
				customEventDeclaration.AddAnnotation(new MemberResolveResult(null, ev));
			}
			customEventDeclaration.ReturnType = ConvertType(ev.ReturnType);
			customEventDeclaration.Name = ev.Name;
			customEventDeclaration.AddAccessor = ConvertAccessor(ev.AddAccessor, ev.Accessibility, addParameterAttribute: true);
			customEventDeclaration.RemoveAccessor = ConvertAccessor(ev.RemoveAccessor, ev.Accessibility, addParameterAttribute: true);
			customEventDeclaration.PrivateImplementationType = GetExplicitInterfaceType(ev);
			return customEventDeclaration;
		}
		EventDeclaration eventDeclaration = new EventDeclaration();
		eventDeclaration.Modifiers = GetMemberModifiers(ev);
		if (ShowAttributes)
		{
			eventDeclaration.Attributes.AddRange(ConvertAttributes(ev.GetAttributes()));
		}
		if (AddResolveResultAnnotations)
		{
			eventDeclaration.AddAnnotation(new MemberResolveResult(null, ev));
		}
		eventDeclaration.ReturnType = ConvertType(ev.ReturnType);
		eventDeclaration.Variables.Add(new VariableInitializer(ev.Name));
		return eventDeclaration;
	}

	private MethodDeclaration ConvertMethod(IMethod method)
	{
		MethodDeclaration methodDeclaration = new MethodDeclaration();
		methodDeclaration.Modifiers = GetMemberModifiers(method);
		if (ShowAttributes)
		{
			methodDeclaration.Attributes.AddRange(ConvertAttributes(method.GetAttributes()));
			methodDeclaration.Attributes.AddRange(ConvertAttributes(method.GetReturnTypeAttributes(), "return"));
		}
		if (AddResolveResultAnnotations)
		{
			methodDeclaration.AddAnnotation(new MemberResolveResult(null, method));
		}
		methodDeclaration.ReturnType = ConvertType(method.ReturnType);
		methodDeclaration.Name = method.Name;
		if (ShowTypeParameters)
		{
			foreach (ITypeParameter typeParameter in method.TypeParameters)
			{
				methodDeclaration.TypeParameters.Add(ConvertTypeParameter(typeParameter));
			}
		}
		foreach (IParameter parameter in method.Parameters)
		{
			methodDeclaration.Parameters.Add(ConvertParameter(parameter));
		}
		if (method.IsExtensionMethod && method.ReducedFrom == null && methodDeclaration.Parameters.Any() && Enumerable.First<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)methodDeclaration.Parameters).ParameterModifier == ParameterModifier.None)
		{
			Enumerable.First<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)methodDeclaration.Parameters).ParameterModifier = ParameterModifier.This;
		}
		if (ShowTypeParameters && ShowTypeParameterConstraints && !method.IsOverride && !method.IsExplicitInterfaceImplementation)
		{
			foreach (ITypeParameter typeParameter2 in method.TypeParameters)
			{
				Constraint constraint = ConvertTypeParameterConstraint(typeParameter2);
				if (constraint != null)
				{
					methodDeclaration.Constraints.Add(constraint);
				}
			}
		}
		methodDeclaration.Body = GenerateBodyBlock();
		methodDeclaration.PrivateImplementationType = GetExplicitInterfaceType(method);
		return methodDeclaration;
	}

	private EntityDeclaration ConvertOperator(IMethod op)
	{
		OperatorType? operatorType = OperatorDeclaration.GetOperatorType(op.Name);
		if (!operatorType.HasValue)
		{
			return ConvertMethod(op);
		}
		OperatorDeclaration operatorDeclaration = new OperatorDeclaration();
		operatorDeclaration.Modifiers = GetMemberModifiers(op);
		operatorDeclaration.OperatorType = operatorType.Value;
		operatorDeclaration.ReturnType = ConvertType(op.ReturnType);
		foreach (IParameter parameter in op.Parameters)
		{
			operatorDeclaration.Parameters.Add(ConvertParameter(parameter));
		}
		if (ShowAttributes)
		{
			operatorDeclaration.Attributes.AddRange(ConvertAttributes(op.GetAttributes()));
			operatorDeclaration.Attributes.AddRange(ConvertAttributes(op.GetReturnTypeAttributes(), "return"));
		}
		if (AddResolveResultAnnotations)
		{
			operatorDeclaration.AddAnnotation(new MemberResolveResult(null, op));
		}
		operatorDeclaration.Body = GenerateBodyBlock();
		return operatorDeclaration;
	}

	private ConstructorDeclaration ConvertConstructor(IMethod ctor)
	{
		ConstructorDeclaration constructorDeclaration = new ConstructorDeclaration();
		constructorDeclaration.Modifiers = GetMemberModifiers(ctor);
		if (ShowAttributes)
		{
			constructorDeclaration.Attributes.AddRange(ConvertAttributes(ctor.GetAttributes()));
		}
		if (ctor.DeclaringTypeDefinition != null)
		{
			constructorDeclaration.Name = ctor.DeclaringTypeDefinition.Name;
		}
		foreach (IParameter parameter in ctor.Parameters)
		{
			constructorDeclaration.Parameters.Add(ConvertParameter(parameter));
		}
		if (AddResolveResultAnnotations)
		{
			constructorDeclaration.AddAnnotation(new MemberResolveResult(null, ctor));
		}
		constructorDeclaration.Body = GenerateBodyBlock();
		return constructorDeclaration;
	}

	private DestructorDeclaration ConvertDestructor(IMethod dtor)
	{
		DestructorDeclaration destructorDeclaration = new DestructorDeclaration();
		if (ShowAttributes)
		{
			destructorDeclaration.Attributes.AddRange(ConvertAttributes(dtor.GetAttributes()));
		}
		if (dtor.DeclaringTypeDefinition != null)
		{
			destructorDeclaration.Name = dtor.DeclaringTypeDefinition.Name;
		}
		if (AddResolveResultAnnotations)
		{
			destructorDeclaration.AddAnnotation(new MemberResolveResult(null, dtor));
		}
		destructorDeclaration.Body = GenerateBodyBlock();
		return destructorDeclaration;
	}

	public static Modifiers ModifierFromAccessibility(Accessibility accessibility)
	{
		return accessibility switch
		{
			Accessibility.Private => Modifiers.Private, 
			Accessibility.Public => Modifiers.Public, 
			Accessibility.Protected => Modifiers.Protected, 
			Accessibility.Internal => Modifiers.Internal, 
			Accessibility.ProtectedOrInternal => Modifiers.Internal | Modifiers.Protected, 
			Accessibility.ProtectedAndInternal => Modifiers.Private | Modifiers.Protected, 
			_ => Modifiers.None, 
		};
	}

	private bool NeedsAccessibility(IMember member)
	{
		IType declaringType = member.DeclaringType;
		if ((declaringType != null && declaringType.Kind == TypeKind.Interface) || member.IsExplicitInterfaceImplementation)
		{
			return false;
		}
		return member.SymbolKind switch
		{
			SymbolKind.Constructor => !member.IsStatic, 
			SymbolKind.Destructor => false, 
			_ => true, 
		};
	}

	private Modifiers GetMemberModifiers(IMember member)
	{
		Modifiers modifiers = Modifiers.None;
		if (ShowAccessibility && NeedsAccessibility(member))
		{
			modifiers |= ModifierFromAccessibility(member.Accessibility);
		}
		if (ShowModifiers)
		{
			if (member.IsStatic)
			{
				modifiers |= Modifiers.Static;
			}
			else
			{
				IType declaringType = member.DeclaringType;
				if (member.IsAbstract && declaringType != null && declaringType.Kind != TypeKind.Interface)
				{
					modifiers |= Modifiers.Abstract;
				}
				if (member.IsOverride)
				{
					modifiers |= Modifiers.Override;
				}
				if (member.IsVirtual && !member.IsAbstract && !member.IsOverride && declaringType.Kind != TypeKind.Interface)
				{
					modifiers |= Modifiers.Virtual;
				}
				if (member.IsSealed)
				{
					modifiers |= Modifiers.Sealed;
				}
			}
		}
		return modifiers;
	}

	private TypeParameterDeclaration ConvertTypeParameter(ITypeParameter tp)
	{
		TypeParameterDeclaration typeParameterDeclaration = new TypeParameterDeclaration();
		typeParameterDeclaration.Variance = tp.Variance;
		typeParameterDeclaration.Name = tp.Name;
		if (ShowAttributes)
		{
			typeParameterDeclaration.Attributes.AddRange(ConvertAttributes(tp.GetAttributes()));
		}
		return typeParameterDeclaration;
	}

	private Constraint ConvertTypeParameterConstraint(ITypeParameter tp)
	{
		if (!tp.HasDefaultConstructorConstraint && !tp.HasReferenceTypeConstraint && !tp.HasValueTypeConstraint && Enumerable.All<IType>(tp.DirectBaseTypes, (Func<IType, bool>)IsObjectOrValueType))
		{
			return null;
		}
		Constraint constraint = new Constraint();
		constraint.TypeParameter = MakeSimpleType(tp.Name);
		if (tp.HasReferenceTypeConstraint)
		{
			if (tp.NullabilityConstraint == Nullability.Nullable)
			{
				constraint.BaseTypes.Add(new PrimitiveType("class").MakeNullableType());
			}
			else
			{
				constraint.BaseTypes.Add(new PrimitiveType("class"));
			}
		}
		else if (tp.HasValueTypeConstraint)
		{
			if (tp.HasUnmanagedConstraint)
			{
				constraint.BaseTypes.Add(new PrimitiveType("unmanaged"));
			}
			else
			{
				constraint.BaseTypes.Add(new PrimitiveType("struct"));
			}
		}
		foreach (IType directBaseType in tp.DirectBaseTypes)
		{
			if (!IsObjectOrValueType(directBaseType))
			{
				constraint.BaseTypes.Add(ConvertType(directBaseType));
			}
		}
		if (tp.HasDefaultConstructorConstraint && !tp.HasValueTypeConstraint)
		{
			constraint.BaseTypes.Add(new PrimitiveType("new"));
		}
		return constraint;
	}

	private static bool IsObjectOrValueType(IType type)
	{
		ITypeDefinition definition = type.GetDefinition();
		return definition != null && (definition.KnownTypeCode == KnownTypeCode.Object || definition.KnownTypeCode == KnownTypeCode.ValueType);
	}

	public VariableDeclarationStatement ConvertVariable(IVariable v)
	{
		VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement();
		variableDeclarationStatement.Modifiers = (v.IsConst ? Modifiers.Const : Modifiers.None);
		variableDeclarationStatement.Type = ConvertType(v.Type);
		Expression initializer = null;
		if (v.IsConst)
		{
			try
			{
				initializer = ConvertConstantValue(v.Type, v.GetConstantValue(throwOnInvalidMetadata: true));
			}
			catch (BadImageFormatException ex)
			{
				initializer = new ErrorExpression(ex.Message);
			}
		}
		variableDeclarationStatement.Variables.Add(new VariableInitializer(v.Name, initializer));
		return variableDeclarationStatement;
	}

	private NamespaceDeclaration ConvertNamespaceDeclaration(INamespace ns)
	{
		return new NamespaceDeclaration(ns.FullName);
	}

	private AstType GetExplicitInterfaceType(IMember member)
	{
		if (member.IsExplicitInterfaceImplementation)
		{
			IMember member2 = Enumerable.FirstOrDefault<IMember>(member.ExplicitlyImplementedInterfaceMembers);
			if (member2 != null)
			{
				return ConvertType(member2.DeclaringType);
			}
		}
		return null;
	}
}
