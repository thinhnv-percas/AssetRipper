using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class TypeSystemAstBuilder
	{
		private readonly CSharpResolver resolver;

		public bool AddTypeReferenceAnnotations
		{
			get;
			set;
		}

		public bool AddResolveResultAnnotations
		{
			get;
			set;
		}

		public bool ShowAccessibility
		{
			get;
			set;
		}

		public bool ShowModifiers
		{
			get;
			set;
		}

		public bool ShowBaseTypes
		{
			get;
			set;
		}

		public bool ShowTypeParameters
		{
			get;
			set;
		}

		public bool ShowTypeParameterConstraints
		{
			get;
			set;
		}

		public bool ShowParameterNames
		{
			get;
			set;
		}

		public bool ShowConstantValues
		{
			get;
			set;
		}

		public bool ShowAttributes
		{
			get;
			set;
		}

		public bool AlwaysUseShortTypeNames
		{
			get;
			set;
		}

		public NameLookupMode NameLookupMode
		{
			get;
			set;
		}

		public bool GenerateBody
		{
			get;
			set;
		}

		public bool UseCustomEvents
		{
			get;
			set;
		}

		public bool ConvertUnboundTypeArguments
		{
			get;
			set;
		}

		public bool UseAliases
		{
			get;
			set;
		}

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
			ShowAccessibility = true;
			ShowModifiers = true;
			ShowBaseTypes = true;
			ShowTypeParameters = true;
			ShowTypeParameterConstraints = true;
			ShowParameterNames = true;
			ShowConstantValues = true;
			UseAliases = true;
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
				foreach (IAssembly assembly in resolver.Compilation.Assemblies)
				{
					ITypeDefinition typeDefinition = assembly.GetTypeDefinition(fullTypeName);
					if (typeDefinition != null)
					{
						return ConvertType(typeDefinition);
					}
				}
			}
			TopLevelTypeName topLevelTypeName = fullTypeName.TopLevelTypeName;
			AstType astType = (!string.IsNullOrEmpty(topLevelTypeName.Namespace)) ? ((AstType)new SimpleType(topLevelTypeName.Namespace).MemberType(topLevelTypeName.Name)) : ((AstType)new SimpleType(topLevelTypeName.Name));
			for (int i = 0; i < fullTypeName.NestingLevel; i++)
			{
				astType = astType.MemberType(fullTypeName.GetNestedTypeName(i));
			}
			return astType;
		}

		private AstType ConvertTypeHelper(IType type)
		{
			TypeWithElementType typeWithElementType = type as TypeWithElementType;
			if (typeWithElementType != null)
			{
				if (typeWithElementType is PointerType)
				{
					return ConvertType(typeWithElementType.ElementType).MakePointerType();
				}
				if (typeWithElementType is ArrayType)
				{
					return ConvertType(typeWithElementType.ElementType).MakeArrayType(((ArrayType)type).Dimensions);
				}
				if (typeWithElementType is ByReferenceType)
				{
					return ConvertType(typeWithElementType.ElementType).MakeRefType();
				}
				return ConvertType(typeWithElementType.ElementType);
			}
			ParameterizedType parameterizedType = type as ParameterizedType;
			if (parameterizedType != null)
			{
				if (parameterizedType.Name == "Nullable" && parameterizedType.Namespace == "System" && parameterizedType.TypeParameterCount == 1)
				{
					return ConvertType(parameterizedType.TypeArguments[0]).MakeNullableType();
				}
				return ConvertTypeHelper(parameterizedType.GetDefinition(), parameterizedType.TypeArguments);
			}
			ITypeDefinition typeDefinition = type as ITypeDefinition;
			if (typeDefinition != null)
			{
				if (typeDefinition.TypeParameterCount > 0)
				{
					IType[] array = new IType[typeDefinition.TypeParameterCount];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = SpecialType.UnboundTypeArgument;
					}
					return ConvertTypeHelper(typeDefinition, array);
				}
				return ConvertTypeHelper(typeDefinition, EmptyList<IType>.Instance);
			}
			return new SimpleType(type.Name);
		}

		private AstType ConvertTypeHelper(ITypeDefinition typeDef, IList<IType> typeArguments)
		{
			string cSharpNameByTypeCode = KnownTypeReference.GetCSharpNameByTypeCode(typeDef.KnownTypeCode);
			if (cSharpNameByTypeCode != null)
			{
				return new PrimitiveType(cSharpNameByTypeCode);
			}
			int num = (typeDef.DeclaringType != null) ? typeDef.DeclaringType.TypeParameterCount : 0;
			if (resolver != null)
			{
				if (UseAliases)
				{
					for (ResolvedUsingScope resolvedUsingScope = resolver.CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
					{
						foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
						{
							if (usingAlias.Value is TypeResolveResult && TypeMatches(usingAlias.Value.Type, typeDef, typeArguments))
							{
								return new SimpleType(usingAlias.Key);
							}
						}
					}
				}
				IList<IType> list;
				if (typeDef.TypeParameterCount > num)
				{
					list = new IType[typeDef.TypeParameterCount - num];
					for (int i = 0; i < list.Count; i++)
					{
						list[i] = typeArguments[num + i];
					}
				}
				else
				{
					list = EmptyList<IType>.Instance;
				}
				ResolveResult resolveResult = resolver.LookupSimpleNameOrTypeName(typeDef.Name, list, NameLookupMode);
				TypeResolveResult trr = resolveResult as TypeResolveResult;
				if ((trr != null || (list.Count == 0 && resolver.IsVariableReferenceWithSameType(resolveResult, typeDef.Name, out trr))) && !trr.IsError && TypeMatches(trr.Type, typeDef, typeArguments))
				{
					SimpleType result = new SimpleType(typeDef.Name);
					AddTypeArguments(result, typeDef, typeArguments, num, typeDef.TypeParameterCount);
					return result;
				}
			}
			if (AlwaysUseShortTypeNames)
			{
				SimpleType result2 = new SimpleType(typeDef.Name);
				AddTypeArguments(result2, typeDef, typeArguments, num, typeDef.TypeParameterCount);
				return result2;
			}
			MemberType memberType = new MemberType();
			if (typeDef.DeclaringTypeDefinition != null)
			{
				memberType.Target = ConvertTypeHelper(typeDef.DeclaringTypeDefinition, typeArguments);
			}
			else if (string.IsNullOrEmpty(typeDef.Namespace))
			{
				memberType.Target = new SimpleType("global");
				memberType.IsDoubleColon = true;
			}
			else
			{
				memberType.Target = ConvertNamespace(typeDef.Namespace);
			}
			memberType.MemberName = typeDef.Name;
			AddTypeArguments(memberType, typeDef, typeArguments, num, typeDef.TypeParameterCount);
			return memberType;
		}

		private bool TypeMatches(IType type, ITypeDefinition typeDef, IList<IType> typeArguments)
		{
			if (typeDef.TypeParameterCount == 0)
			{
				return typeDef.Equals(type);
			}
			if (!typeDef.Equals(type.GetDefinition()))
			{
				return false;
			}
			ParameterizedType parameterizedType = type as ParameterizedType;
			if (parameterizedType == null)
			{
				return typeArguments.All((IType t) => t.Kind == TypeKind.UnboundTypeArgument);
			}
			IList<IType> typeArguments2 = parameterizedType.TypeArguments;
			for (int i = 0; i < typeArguments2.Count; i++)
			{
				if (!typeArguments2[i].Equals(typeArguments[i]))
				{
					return false;
				}
			}
			return true;
		}

		private void AddTypeArguments(AstType result, ITypeDefinition typeDef, IList<IType> typeArguments, int startIndex, int endIndex)
		{
			for (int i = startIndex; i < endIndex; i++)
			{
				if (ConvertUnboundTypeArguments && typeArguments[i].Kind == TypeKind.UnboundTypeArgument)
				{
					result.AddChild(new SimpleType(typeDef.TypeParameters[i].Name), Roles.TypeArgument);
				}
				else
				{
					result.AddChild(ConvertType(typeArguments[i]), Roles.TypeArgument);
				}
			}
		}

		public AstType ConvertNamespace(string namespaceName)
		{
			if (resolver != null && UseAliases)
			{
				for (ResolvedUsingScope resolvedUsingScope = resolver.CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
				{
					foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
					{
						NamespaceResolveResult namespaceResolveResult = usingAlias.Value as NamespaceResolveResult;
						if (namespaceResolveResult != null && namespaceResolveResult.NamespaceName == namespaceName)
						{
							return new SimpleType(usingAlias.Key);
						}
					}
				}
			}
			int num = namespaceName.LastIndexOf('.');
			if (num < 0)
			{
				if (IsValidNamespace(namespaceName))
				{
					return new SimpleType(namespaceName);
				}
				return new MemberType
				{
					Target = new SimpleType("global"),
					IsDoubleColon = true,
					MemberName = namespaceName
				};
			}
			string namespaceName2 = namespaceName.Substring(0, num);
			string memberName = namespaceName.Substring(num + 1);
			return new MemberType
			{
				Target = ConvertNamespace(namespaceName2),
				MemberName = memberName
			};
		}

		private bool IsValidNamespace(string firstNamespacePart)
		{
			if (resolver == null)
			{
				return true;
			}
			NamespaceResolveResult namespaceResolveResult = resolver.ResolveSimpleName(firstNamespacePart, EmptyList<IType>.Instance) as NamespaceResolveResult;
			if (namespaceResolveResult != null && !namespaceResolveResult.IsError)
			{
				return namespaceResolveResult.NamespaceName == firstNamespacePart;
			}
			return false;
		}

		public Attribute ConvertAttribute(IAttribute attribute)
		{
			Attribute attribute2 = new Attribute();
			attribute2.Type = ConvertType(attribute.AttributeType);
			SimpleType simpleType = attribute2.Type as SimpleType;
			MemberType memberType = attribute2.Type as MemberType;
			if (simpleType != null && simpleType.Identifier.EndsWith("Attribute", StringComparison.Ordinal))
			{
				simpleType.Identifier = simpleType.Identifier.Substring(0, simpleType.Identifier.Length - 9);
			}
			else if (memberType != null && memberType.MemberName.EndsWith("Attribute", StringComparison.Ordinal))
			{
				memberType.MemberName = memberType.MemberName.Substring(0, memberType.MemberName.Length - 9);
			}
			foreach (ResolveResult positionalArgument in attribute.PositionalArguments)
			{
				attribute2.Arguments.Add(ConvertConstantValue(positionalArgument));
			}
			foreach (KeyValuePair<IMember, ResolveResult> namedArgument in attribute.NamedArguments)
			{
				attribute2.Arguments.Add(new NamedExpression(namedArgument.Key.Name, ConvertConstantValue(namedArgument.Value)));
			}
			return attribute2;
		}

		public Expression ConvertConstantValue(ResolveResult rr)
		{
			if (rr == null)
			{
				throw new ArgumentNullException("rr");
			}
			if (rr is ConversionResolveResult)
			{
				rr = ((ConversionResolveResult)rr).Input;
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
			if (rr is ArrayCreateResolveResult)
			{
				ArrayCreateResolveResult arrayCreateResolveResult = (ArrayCreateResolveResult)rr;
				ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression();
				arrayCreateExpression.Type = ConvertType(arrayCreateResolveResult.Type);
				ComposedType composedType = arrayCreateExpression.Type as ComposedType;
				if (composedType != null)
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
					arrayCreateExpression.Arguments.AddRange(arrayCreateResolveResult.SizeArguments.Select(ConvertConstantValue));
				}
				if (arrayCreateResolveResult.InitializerElements != null)
				{
					ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
					arrayInitializerExpression.Elements.AddRange(arrayCreateResolveResult.InitializerElements.Select(ConvertConstantValue));
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
				return ConvertConstantValue(rr.Type, rr.ConstantValue);
			}
			return new ErrorExpression();
		}

		public Expression ConvertConstantValue(IType type, object constantValue)
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
			if (type.Kind == TypeKind.Enum)
			{
				return ConvertEnumValue(type, (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constantValue, checkForOverflow: false));
			}
			return new PrimitiveExpression(constantValue);
		}

		private bool IsFlagsEnum(ITypeDefinition type)
		{
			IType attributeType = ReflectionHelper.FindType(type.Compilation, typeof(FlagsAttribute));
			return type.GetAttribute(attributeType) != null;
		}

		private Expression ConvertEnumValue(IType type, long val)
		{
			ITypeDefinition definition = type.GetDefinition();
			TypeCode typeCode = ReflectionHelper.GetTypeCode(definition.EnumUnderlyingType);
			foreach (IField field in definition.Fields)
			{
				if (field.IsConst && object.Equals(CSharpPrimitiveCast.Cast(TypeCode.Int64, field.ConstantValue, checkForOverflow: false), val))
				{
					return ConvertType(type).Member(field.Name);
				}
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
					num2 &= uint.MaxValue;
					break;
				}
				Expression expression2 = null;
				foreach (IField item in from fld in definition.Fields
					where fld.IsConst
					select fld)
				{
					long num3 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, item.ConstantValue, checkForOverflow: false);
					if (num3 != 0L)
					{
						if ((num3 & num) == num3)
						{
							MemberReferenceExpression memberReferenceExpression = ConvertType(type).Member(item.Name);
							expression = ((expression != null) ? ((Expression)new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseOr, memberReferenceExpression)) : ((Expression)memberReferenceExpression));
							num &= ~num3;
						}
						if ((num3 & num2) == num3)
						{
							MemberReferenceExpression memberReferenceExpression2 = ConvertType(type).Member(item.Name);
							expression2 = ((expression2 != null) ? ((Expression)new BinaryOperatorExpression(expression2, BinaryOperatorType.BitwiseOr, memberReferenceExpression2)) : ((Expression)memberReferenceExpression2));
							num2 &= ~num3;
						}
					}
				}
				if (num == 0L && expression != null && (num2 != 0L || expression2 == null || expression2.Descendants.Count() >= expression.Descendants.Count()))
				{
					return expression;
				}
				if (num2 == 0L && expression2 != null)
				{
					return new UnaryOperatorExpression(UnaryOperatorType.BitNot, expression2);
				}
			}
			return new PrimitiveExpression(CSharpPrimitiveCast.Cast(typeCode, val, checkForOverflow: false)).CastTo(ConvertType(type));
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
			else if (parameter.IsParams)
			{
				parameterDeclaration.ParameterModifier = ParameterModifier.Params;
			}
			if (ShowAttributes)
			{
				parameterDeclaration.Attributes.AddRange(from a in parameter.Attributes
					select new AttributeSection(ConvertAttribute(a)));
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
			if (parameter.IsOptional && ShowConstantValues)
			{
				parameterDeclaration.DefaultExpression = ConvertConstantValue(parameter.Type, parameter.ConstantValue);
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
			{
				IEntity entity = symbol as IEntity;
				if (entity != null)
				{
					return ConvertEntity(entity);
				}
				throw new ArgumentException("Invalid value for SymbolKind: " + symbol.SymbolKind);
			}
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
				return ConvertAccessor(method, (method.AccessorOwner != null) ? method.AccessorOwner.Accessibility : Accessibility.None, addParamterAttribute: false);
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
				if (typeDefinition.IsShadowing)
				{
					modifiers |= Modifiers.New;
				}
			}
			ClassType classType;
			switch (typeDefinition.Kind)
			{
			case TypeKind.Struct:
				classType = ClassType.Struct;
				modifiers &= ~Modifiers.Sealed;
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
				typeDeclaration.Attributes.AddRange(from a in typeDefinition.Attributes
					select new AttributeSection(ConvertAttribute(a)));
			}
			if (AddResolveResultAnnotations)
			{
				typeDeclaration.AddAnnotation(new TypeResolveResult(typeDefinition));
			}
			typeDeclaration.Name = typeDefinition.Name;
			int count = (typeDefinition.DeclaringTypeDefinition != null) ? typeDefinition.DeclaringTypeDefinition.TypeParameterCount : 0;
			if (ShowTypeParameters)
			{
				foreach (ITypeParameter item in typeDefinition.TypeParameters.Skip(count))
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
				foreach (ITypeParameter item2 in typeDefinition.TypeParameters.Skip(count))
				{
					Constraint constraint = ConvertTypeParameterConstraint(item2);
					if (constraint != null)
					{
						typeDeclaration.Constraints.Add(constraint);
					}
				}
				return typeDeclaration;
			}
			return typeDeclaration;
		}

		private DelegateDeclaration ConvertDelegate(IMethod invokeMethod, Modifiers modifiers)
		{
			ITypeDefinition declaringTypeDefinition = invokeMethod.DeclaringTypeDefinition;
			DelegateDeclaration delegateDeclaration = new DelegateDeclaration();
			delegateDeclaration.Modifiers = (modifiers & ~Modifiers.Sealed);
			if (ShowAttributes)
			{
				delegateDeclaration.Attributes.AddRange(from a in declaringTypeDefinition.Attributes
					select new AttributeSection(ConvertAttribute(a)));
				delegateDeclaration.Attributes.AddRange(from a in invokeMethod.ReturnTypeAttributes
					select new AttributeSection(ConvertAttribute(a))
					{
						AttributeTarget = "return"
					});
			}
			if (AddResolveResultAnnotations)
			{
				delegateDeclaration.AddAnnotation(new TypeResolveResult(declaringTypeDefinition));
			}
			delegateDeclaration.ReturnType = ConvertType(invokeMethod.ReturnType);
			delegateDeclaration.Name = declaringTypeDefinition.Name;
			int count = (declaringTypeDefinition.DeclaringTypeDefinition != null) ? declaringTypeDefinition.DeclaringTypeDefinition.TypeParameterCount : 0;
			if (ShowTypeParameters)
			{
				foreach (ITypeParameter item in declaringTypeDefinition.TypeParameters.Skip(count))
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
				foreach (ITypeParameter item2 in declaringTypeDefinition.TypeParameters.Skip(count))
				{
					Constraint constraint = ConvertTypeParameterConstraint(item2);
					if (constraint != null)
					{
						delegateDeclaration.Constraints.Add(constraint);
					}
				}
				return delegateDeclaration;
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
				fieldDeclaration.Attributes.AddRange(from a in field.Attributes
					select new AttributeSection(ConvertAttribute(a)));
			}
			if (AddResolveResultAnnotations)
			{
				fieldDeclaration.AddAnnotation(new MemberResolveResult(null, field));
			}
			fieldDeclaration.ReturnType = ConvertType(field.ReturnType);
			Expression initializer = null;
			if (field.IsConst && ShowConstantValues)
			{
				initializer = ConvertConstantValue(field.Type, field.ConstantValue);
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

		private Accessor ConvertAccessor(IMethod accessor, Accessibility ownerAccessibility, bool addParamterAttribute)
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
				accessor2.Attributes.AddRange(from a in accessor.Attributes
					select new AttributeSection(ConvertAttribute(a)));
				accessor2.Attributes.AddRange(from a in accessor.ReturnTypeAttributes
					select new AttributeSection(ConvertAttribute(a))
					{
						AttributeTarget = "return"
					});
				if (addParamterAttribute && accessor.Parameters.Count > 0)
				{
					accessor2.Attributes.AddRange(from a in accessor.Parameters.Last().Attributes
						select new AttributeSection(ConvertAttribute(a))
						{
							AttributeTarget = "param"
						});
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
				propertyDeclaration.Attributes.AddRange(from a in property.Attributes
					select new AttributeSection(ConvertAttribute(a)));
			}
			if (AddResolveResultAnnotations)
			{
				propertyDeclaration.AddAnnotation(new MemberResolveResult(null, property));
			}
			propertyDeclaration.ReturnType = ConvertType(property.ReturnType);
			propertyDeclaration.Name = property.Name;
			propertyDeclaration.Getter = ConvertAccessor(property.Getter, property.Accessibility, addParamterAttribute: false);
			propertyDeclaration.Setter = ConvertAccessor(property.Setter, property.Accessibility, addParamterAttribute: true);
			propertyDeclaration.PrivateImplementationType = GetExplicitInterfaceType(property);
			return propertyDeclaration;
		}

		private IndexerDeclaration ConvertIndexer(IProperty indexer)
		{
			IndexerDeclaration indexerDeclaration = new IndexerDeclaration();
			indexerDeclaration.Modifiers = GetMemberModifiers(indexer);
			if (ShowAttributes)
			{
				indexerDeclaration.Attributes.AddRange(from a in indexer.Attributes
					select new AttributeSection(ConvertAttribute(a)));
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
			indexerDeclaration.Getter = ConvertAccessor(indexer.Getter, indexer.Accessibility, addParamterAttribute: false);
			indexerDeclaration.Setter = ConvertAccessor(indexer.Setter, indexer.Accessibility, addParamterAttribute: true);
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
					customEventDeclaration.Attributes.AddRange(from a in ev.Attributes
						select new AttributeSection(ConvertAttribute(a)));
				}
				if (AddResolveResultAnnotations)
				{
					customEventDeclaration.AddAnnotation(new MemberResolveResult(null, ev));
				}
				customEventDeclaration.ReturnType = ConvertType(ev.ReturnType);
				customEventDeclaration.Name = ev.Name;
				customEventDeclaration.AddAccessor = ConvertAccessor(ev.AddAccessor, ev.Accessibility, addParamterAttribute: true);
				customEventDeclaration.RemoveAccessor = ConvertAccessor(ev.RemoveAccessor, ev.Accessibility, addParamterAttribute: true);
				return customEventDeclaration;
			}
			EventDeclaration eventDeclaration = new EventDeclaration();
			eventDeclaration.Modifiers = GetMemberModifiers(ev);
			if (ShowAttributes)
			{
				eventDeclaration.Attributes.AddRange(from a in ev.Attributes
					select new AttributeSection(ConvertAttribute(a)));
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
			if (method.IsAsync && ShowModifiers)
			{
				methodDeclaration.Modifiers |= Modifiers.Async;
			}
			if (ShowAttributes)
			{
				methodDeclaration.Attributes.AddRange(from a in method.Attributes
					select new AttributeSection(ConvertAttribute(a)));
				methodDeclaration.Attributes.AddRange(from a in method.ReturnTypeAttributes
					select new AttributeSection(ConvertAttribute(a))
					{
						AttributeTarget = "return"
					});
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
			if (method.IsExtensionMethod && method.ReducedFrom == null && methodDeclaration.Parameters.Any() && methodDeclaration.Parameters.First().ParameterModifier == ParameterModifier.None)
			{
				methodDeclaration.Parameters.First().ParameterModifier = ParameterModifier.This;
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
				constructorDeclaration.Attributes.AddRange(from a in ctor.Attributes
					select new AttributeSection(ConvertAttribute(a)));
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
			switch (accessibility)
			{
			case Accessibility.Private:
				return Modifiers.Private;
			case Accessibility.Public:
				return Modifiers.Public;
			case Accessibility.Protected:
				return Modifiers.Protected;
			case Accessibility.Internal:
				return Modifiers.Internal;
			case Accessibility.ProtectedOrInternal:
			case Accessibility.ProtectedAndInternal:
				return Modifiers.Internal | Modifiers.Protected;
			default:
				return Modifiers.None;
			}
		}

		private bool NeedsAccessibility(IMember member)
		{
			IType declaringType = member.DeclaringType;
			if ((declaringType != null && declaringType.Kind == TypeKind.Interface) || member.IsExplicitInterfaceImplementation)
			{
				return false;
			}
			switch (member.SymbolKind)
			{
			case SymbolKind.Constructor:
				return !member.IsStatic;
			case SymbolKind.Destructor:
				return false;
			default:
				return true;
			}
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
					if (member.IsVirtual && !member.IsAbstract && !member.IsOverride)
					{
						modifiers |= Modifiers.Virtual;
					}
					if (member.IsSealed)
					{
						modifiers |= Modifiers.Sealed;
					}
				}
				if (member.IsShadowing)
				{
					modifiers |= Modifiers.New;
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
				typeParameterDeclaration.Attributes.AddRange(from a in tp.Attributes
					select new AttributeSection(ConvertAttribute(a)));
			}
			return typeParameterDeclaration;
		}

		private Constraint ConvertTypeParameterConstraint(ITypeParameter tp)
		{
			if (!tp.HasDefaultConstructorConstraint && !tp.HasReferenceTypeConstraint && !tp.HasValueTypeConstraint && tp.DirectBaseTypes.All(IsObjectOrValueType))
			{
				return null;
			}
			Constraint constraint = new Constraint();
			constraint.TypeParameter = new SimpleType(tp.Name);
			if (tp.HasReferenceTypeConstraint)
			{
				constraint.BaseTypes.Add(new PrimitiveType("class"));
			}
			else if (tp.HasValueTypeConstraint)
			{
				constraint.BaseTypes.Add(new PrimitiveType("struct"));
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
			if (definition != null)
			{
				if (definition.KnownTypeCode != KnownTypeCode.Object)
				{
					return definition.KnownTypeCode == KnownTypeCode.ValueType;
				}
				return true;
			}
			return false;
		}

		public VariableDeclarationStatement ConvertVariable(IVariable v)
		{
			VariableDeclarationStatement obj = new VariableDeclarationStatement
			{
				Modifiers = (v.IsConst ? Modifiers.Const : Modifiers.None),
				Type = ConvertType(v.Type)
			};
			Expression initializer = null;
			if (v.IsConst)
			{
				initializer = ConvertConstantValue(v.Type, v.ConstantValue);
			}
			obj.Variables.Add(new VariableInitializer(v.Name, initializer));
			return obj;
		}

		private NamespaceDeclaration ConvertNamespaceDeclaration(INamespace ns)
		{
			return new NamespaceDeclaration(ns.FullName);
		}

		private AstType GetExplicitInterfaceType(IMember member)
		{
			if (member.IsExplicitInterfaceImplementation)
			{
				IMember member2 = member.ImplementedInterfaceMembers.FirstOrDefault();
				if (member2 != null)
				{
					return ConvertType(member2.DeclaringType);
				}
			}
			return null;
		}
	}
}
