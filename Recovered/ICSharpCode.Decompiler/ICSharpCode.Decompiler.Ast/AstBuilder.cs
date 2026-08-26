using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ICSharpCode.Decompiler.Ast
{
	public class AstBuilder
	{
		private DecompilerContext context;

		private SyntaxTree syntaxTree = new SyntaxTree();

		private Dictionary<string, NamespaceDeclaration> astNamespaces = new Dictionary<string, NamespaceDeclaration>();

		private bool transformationsHaveRun;

		private const string DynamicAttributeFullName = "System.Runtime.CompilerServices.DynamicAttribute";

		public SyntaxTree SyntaxTree => syntaxTree;

		public bool DecompileMethodBodies
		{
			get;
			set;
		}

		public AstBuilder(DecompilerContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			this.context = context;
			DecompileMethodBodies = true;
		}

		public static bool MemberIsHidden(MemberReference member, DecompilerSettings settings)
		{
			MethodDefinition methodDefinition = member as MethodDefinition;
			if (methodDefinition != null)
			{
				if (methodDefinition.IsGetter || methodDefinition.IsSetter || methodDefinition.IsAddOn || methodDefinition.IsRemoveOn)
				{
					return true;
				}
				if (settings.AnonymousMethods && methodDefinition.HasGeneratedName() && methodDefinition.IsCompilerGenerated())
				{
					return true;
				}
			}
			if (!settings.CompillerTypeGenerated_Clear)
			{
				return false;
			}
			TypeDefinition typeDefinition = member as TypeDefinition;
			if (typeDefinition != null && typeDefinition.DeclaringType != null)
			{
				if (settings.AnonymousMethods && IsClosureType(typeDefinition))
				{
					return true;
				}
				if (settings.YieldReturn && YieldReturnDecompiler.IsCompilerGeneratorEnumerator(typeDefinition))
				{
					return true;
				}
				if (settings.AsyncAwait && AsyncDecompiler.IsCompilerGeneratedStateMachine(typeDefinition))
				{
					return true;
				}
				if (typeDefinition.IsCompilerGenerated())
				{
					if (typeDefinition.Name.StartsWith("<PrivateImplementationDetails>", StringComparison.Ordinal))
					{
						return true;
					}
					if (typeDefinition.IsAnonymousType())
					{
						return true;
					}
				}
			}
			FieldDefinition field = member as FieldDefinition;
			if (field != null)
			{
				if (field.IsCompilerGenerated())
				{
					if (settings.AnonymousMethods && IsAnonymousMethodCacheField(field))
					{
						return true;
					}
					if (settings.AutomaticProperties && IsAutomaticPropertyBackingField(field))
					{
						return true;
					}
					if (settings.SwitchStatementOnString && IsSwitchOnStringCache(field))
					{
						return true;
					}
				}
				if (settings.AutomaticEvents && field.DeclaringType.Events.Any((EventDefinition ev) => ev.Name == field.Name))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsSwitchOnStringCache(FieldDefinition field)
		{
			return field.Name.StartsWith("<>f__switch", StringComparison.Ordinal);
		}

		private static bool IsAutomaticPropertyBackingField(FieldDefinition field)
		{
			if (field.HasGeneratedName())
			{
				return field.Name.EndsWith("BackingField", StringComparison.Ordinal);
			}
			return false;
		}

		private static bool IsAnonymousMethodCacheField(FieldDefinition field)
		{
			if (!field.Name.StartsWith("CS$<>", StringComparison.Ordinal))
			{
				return field.Name.StartsWith("<>f__am", StringComparison.Ordinal);
			}
			return true;
		}

		private static bool IsClosureType(TypeDefinition type)
		{
			if (type.HasGeneratedName() && type.IsCompilerGenerated())
			{
				if (!type.Name.Contains("DisplayClass"))
				{
					return type.Name.Contains("AnonStorey");
				}
				return true;
			}
			return false;
		}

		public void RunTransformations()
		{
			RunTransformations(null);
		}

		public void RunTransformations(Predicate<IAstTransform> transformAbortCondition)
		{
			TransformationPipeline.RunTransformationsUntil(syntaxTree, transformAbortCondition, context);
			transformationsHaveRun = true;
		}

		public void GenerateCode(ITextOutput output)
		{
			if (!transformationsHaveRun)
			{
				RunTransformations();
			}
			syntaxTree.AcceptVisitor(new InsertParenthesesVisitor
			{
				InsertParenthesesForReadability = true
			});
			TextTokenWriter writer = new TextTokenWriter(output, context)
			{
				FoldBraces = context.Settings.FoldBraces
			};
			CSharpFormattingOptions cSharpFormattingOptions = context.Settings.CSharpFormattingOptions;
			syntaxTree.AcceptVisitor(new CSharpOutputVisitor(writer, cSharpFormattingOptions));
		}

		public void AddAssembly(AssemblyDefinition assemblyDefinition, bool onlyAssemblyLevel = false)
		{
			AddAssembly(assemblyDefinition.MainModule, onlyAssemblyLevel);
		}

		public void AddAssembly(ModuleDefinition moduleDefinition, bool onlyAssemblyLevel = false)
		{
			if (moduleDefinition.Assembly != null && moduleDefinition.Assembly.Name.Version != null)
			{
				syntaxTree.AddChild(new AttributeSection
				{
					AttributeTarget = "assembly",
					Attributes = 
					{
						new ICSharpCode.NRefactory.CSharp.Attribute
						{
							Type = new SimpleType("AssemblyVersion").WithAnnotation(new TypeReference("System.Reflection", "AssemblyVersionAttribute", moduleDefinition, moduleDefinition.TypeSystem.CoreLibrary)),
							Arguments = 
							{
								(Expression)new PrimitiveExpression(moduleDefinition.Assembly.Name.Version.ToString())
							}
						}
					}
				}, EntityDeclaration.AttributeRole);
			}
			if (moduleDefinition.Assembly != null)
			{
				ConvertCustomAttributes(syntaxTree, moduleDefinition.Assembly, "assembly");
				ConvertSecurityAttributes(syntaxTree, moduleDefinition.Assembly, "assembly");
			}
			ConvertCustomAttributes(syntaxTree, moduleDefinition, "module");
			AddTypeForwarderAttributes(syntaxTree, moduleDefinition, "assembly");
			if (!onlyAssemblyLevel)
			{
				foreach (TypeDefinition type in moduleDefinition.Types)
				{
					if (!(type.Name == "<Module>") && !MemberIsHidden(type, context.Settings))
					{
						AddType(type);
					}
				}
			}
		}

		private void AddTypeForwarderAttributes(SyntaxTree astCompileUnit, ModuleDefinition module, string target)
		{
			if (module.HasExportedTypes)
			{
				foreach (ExportedType exportedType in module.ExportedTypes)
				{
					if (exportedType.IsForwarder)
					{
						TypeOfExpression element = CreateTypeOfExpression(new TypeReference(exportedType.Namespace, exportedType.Name, module, exportedType.Scope));
						astCompileUnit.AddChild(new AttributeSection
						{
							AttributeTarget = target,
							Attributes = 
							{
								new ICSharpCode.NRefactory.CSharp.Attribute
								{
									Type = new SimpleType("TypeForwardedTo").WithAnnotation(new TypeReference("System.Runtime.CompilerServices", "TypeForwardedToAttribute", module, module.TypeSystem.CoreLibrary)),
									Arguments = 
									{
										(Expression)element
									}
								}
							}
						}, EntityDeclaration.AttributeRole);
					}
				}
			}
		}

		private NamespaceDeclaration GetCodeNamespace(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			if (astNamespaces.ContainsKey(name))
			{
				return astNamespaces[name];
			}
			NamespaceDeclaration namespaceDeclaration = new NamespaceDeclaration
			{
				Name = name
			};
			syntaxTree.Members.Add(namespaceDeclaration);
			astNamespaces[name] = namespaceDeclaration;
			return namespaceDeclaration;
		}

		public void AddType(TypeDefinition typeDef)
		{
			EntityDeclaration element = CreateType(typeDef);
			NamespaceDeclaration codeNamespace = GetCodeNamespace(typeDef.Namespace);
			if (codeNamespace != null)
			{
				codeNamespace.Members.Add(element);
			}
			else
			{
				syntaxTree.Members.Add(element);
			}
		}

		public void AddMethod(MethodDefinition method)
		{
			AstNode element = method.IsConstructor ? CreateConstructor(method) : CreateMethod(method);
			syntaxTree.Members.Add(element);
		}

		public void AddProperty(PropertyDefinition property)
		{
			syntaxTree.Members.Add(CreateProperty(property));
		}

		public void AddField(FieldDefinition field)
		{
			syntaxTree.Members.Add(CreateField(field));
		}

		public void AddEvent(EventDefinition ev)
		{
			syntaxTree.Members.Add(CreateEvent(ev));
		}

		public EntityDeclaration CreateType(TypeDefinition typeDef)
		{
			TypeDefinition currentType = context.CurrentType;
			context.CurrentType = typeDef;
			TypeDeclaration typeDeclaration = new TypeDeclaration();
			ConvertAttributes(typeDeclaration, typeDef);
			typeDeclaration.AddAnnotation(typeDef);
			typeDeclaration.Modifiers = ConvertModifiers(typeDef);
			typeDeclaration.Name = CleanName(typeDef.Name);
			if (typeDef.IsEnum)
			{
				typeDeclaration.ClassType = ClassType.Enum;
				typeDeclaration.Modifiers &= ~Modifiers.Sealed;
			}
			else if (typeDef.IsValueType)
			{
				typeDeclaration.ClassType = ClassType.Struct;
				typeDeclaration.Modifiers &= ~Modifiers.Sealed;
			}
			else if (typeDef.IsInterface)
			{
				typeDeclaration.ClassType = ClassType.Interface;
				typeDeclaration.Modifiers &= ~Modifiers.Abstract;
			}
			else
			{
				typeDeclaration.ClassType = ClassType.Class;
			}
			IEnumerable<GenericParameter> enumerable = typeDef.GenericParameters;
			if (typeDef.DeclaringType != null && typeDef.DeclaringType.HasGenericParameters)
			{
				enumerable = enumerable.Skip(typeDef.DeclaringType.GenericParameters.Count);
			}
			typeDeclaration.TypeParameters.AddRange(MakeTypeParameters(enumerable));
			typeDeclaration.Constraints.AddRange(MakeConstraints(enumerable));
			EntityDeclaration result = typeDeclaration;
			if (typeDef.IsEnum)
			{
				long num = 0L;
				bool flag = IsFlagsEnum(typeDef);
				TypeCode targetType = TypeCode.Int32;
				foreach (FieldDefinition field in typeDef.Fields)
				{
					if (!field.IsStatic)
					{
						if (field.FieldType != typeDef.Module.TypeSystem.Int32)
						{
							typeDeclaration.AddChild(ConvertType(field.FieldType), Roles.BaseType);
							targetType = TypeAnalysis.GetTypeCode(field.FieldType);
						}
					}
					else
					{
						EnumMemberDeclaration enumMemberDeclaration = new EnumMemberDeclaration();
						ConvertCustomAttributes(enumMemberDeclaration, field);
						enumMemberDeclaration.AddAnnotation(field);
						enumMemberDeclaration.Name = CleanName(field.Name);
						long num2 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, field.Constant, checkForOverflow: false);
						if (flag || num2 != num)
						{
							enumMemberDeclaration.AddChild(new PrimitiveExpression(CSharpPrimitiveCast.Cast(targetType, field.Constant, checkForOverflow: false)), EnumMemberDeclaration.InitializerRole);
						}
						num = num2 + 1;
						typeDeclaration.AddChild(enumMemberDeclaration, Roles.TypeMemberRole);
					}
				}
			}
			else if (typeDef.BaseType != null && typeDef.BaseType.FullName == "System.MulticastDelegate")
			{
				DelegateDeclaration delegateDeclaration = new DelegateDeclaration();
				delegateDeclaration.Modifiers = (typeDeclaration.Modifiers & ~Modifiers.Sealed);
				delegateDeclaration.Name = typeDeclaration.Name;
				delegateDeclaration.AddAnnotation(typeDef);
				typeDeclaration.Attributes.MoveTo(delegateDeclaration.Attributes);
				typeDeclaration.TypeParameters.MoveTo(delegateDeclaration.TypeParameters);
				typeDeclaration.Constraints.MoveTo(delegateDeclaration.Constraints);
				foreach (MethodDefinition method in typeDef.Methods)
				{
					if (method.Name == "Invoke")
					{
						delegateDeclaration.ReturnType = ConvertType(method.ReturnType, method.MethodReturnType);
						delegateDeclaration.Parameters.AddRange(MakeParameters(method));
						ConvertAttributes(delegateDeclaration, method.MethodReturnType, method.Module);
					}
				}
				result = delegateDeclaration;
			}
			else
			{
				if (typeDef.BaseType != null && !typeDef.IsValueType && typeDef.BaseType.FullName != "System.Object")
				{
					typeDeclaration.AddChild(ConvertType(typeDef.BaseType), Roles.BaseType);
				}
				foreach (TypeReference @interface in typeDef.Interfaces)
				{
					typeDeclaration.AddChild(ConvertType(@interface), Roles.BaseType);
				}
				AddTypeMembers(typeDeclaration, typeDef);
				if (typeDeclaration.Members.OfType<IndexerDeclaration>().Any((IndexerDeclaration idx) => idx.PrivateImplementationType.IsNull))
				{
					foreach (AttributeSection attribute in typeDeclaration.Attributes)
					{
						foreach (ICSharpCode.NRefactory.CSharp.Attribute attribute2 in attribute.Attributes)
						{
							TypeReference typeReference = attribute2.Type.Annotation<TypeReference>();
							if (typeReference != null && typeReference.Name == "DefaultMemberAttribute" && typeReference.Namespace == "System.Reflection")
							{
								attribute2.Remove();
							}
						}
						if (attribute.Attributes.Count == 0)
						{
							attribute.Remove();
						}
					}
				}
			}
			context.CurrentType = currentType;
			return result;
		}

		internal static string CleanName(string name)
		{
			int num = name.LastIndexOf('`');
			if (num >= 0)
			{
				name = name.Substring(0, num);
			}
			num = name.LastIndexOf('.');
			if (num >= 0)
			{
				name = name.Substring(num + 1);
			}
			return name;
		}

		public static TypeOfExpression CreateTypeOfExpression(TypeReference type)
		{
			return new TypeOfExpression(AddEmptyTypeArgumentsForUnboundGenerics(ConvertType(type)));
		}

		private static AstType AddEmptyTypeArgumentsForUnboundGenerics(AstType type)
		{
			TypeReference typeReference = type.Annotation<TypeReference>();
			if (typeReference == null)
			{
				return type;
			}
			TypeDefinition typeDefinition = typeReference.Resolve();
			if (typeDefinition == null || !typeDefinition.HasGenericParameters)
			{
				return type;
			}
			SimpleType simpleType = type as SimpleType;
			MemberType memberType = type as MemberType;
			if (simpleType != null)
			{
				while (typeDefinition.GenericParameters.Count > simpleType.TypeArguments.Count)
				{
					simpleType.TypeArguments.Add(new SimpleType(""));
				}
			}
			if (memberType != null)
			{
				AddEmptyTypeArgumentsForUnboundGenerics(memberType.Target);
				int num = (typeDefinition.DeclaringType != null) ? typeDefinition.DeclaringType.GenericParameters.Count : 0;
				while (typeDefinition.GenericParameters.Count - num > memberType.TypeArguments.Count)
				{
					memberType.TypeArguments.Add(new SimpleType(""));
				}
			}
			return type;
		}

		public static AstType ConvertType(TypeReference type, ICustomAttributeProvider typeAttributes = null, ConvertTypeOptions options = ConvertTypeOptions.None)
		{
			int typeIndex = 0;
			return ConvertType(type, typeAttributes, ref typeIndex, options);
		}

		private static AstType ConvertType(TypeReference type, ICustomAttributeProvider typeAttributes, ref int typeIndex, ConvertTypeOptions options)
		{
			while (type is OptionalModifierType || type is RequiredModifierType)
			{
				type = ((TypeSpecification)type).ElementType;
			}
			if (type == null)
			{
				return AstType.Null;
			}
			if (type is Mono.Cecil.ByReferenceType)
			{
				typeIndex++;
				return ConvertType((type as Mono.Cecil.ByReferenceType).ElementType, typeAttributes, ref typeIndex, options).MakePointerType();
			}
			if (type is Mono.Cecil.PointerType)
			{
				typeIndex++;
				return ConvertType((type as Mono.Cecil.PointerType).ElementType, typeAttributes, ref typeIndex, options).MakePointerType();
			}
			if (type is Mono.Cecil.ArrayType)
			{
				typeIndex++;
				return ConvertType((type as Mono.Cecil.ArrayType).ElementType, typeAttributes, ref typeIndex, options).MakeArrayType((type as Mono.Cecil.ArrayType).Rank);
			}
			if (type is GenericInstanceType)
			{
				GenericInstanceType genericInstanceType = (GenericInstanceType)type;
				if (genericInstanceType.ElementType.Namespace == "System" && genericInstanceType.ElementType.Name == "Nullable`1" && genericInstanceType.GenericArguments.Count == 1)
				{
					typeIndex++;
					return new ComposedType
					{
						BaseType = ConvertType(genericInstanceType.GenericArguments[0], typeAttributes, ref typeIndex, options),
						HasNullableSpecifier = true
					};
				}
				AstType astType = ConvertType(genericInstanceType.ElementType, typeAttributes, ref typeIndex, options & ~ConvertTypeOptions.IncludeTypeParameterDefinitions);
				List<AstType> list = new List<AstType>();
				foreach (TypeReference genericArgument in genericInstanceType.GenericArguments)
				{
					typeIndex++;
					list.Add(ConvertType(genericArgument, typeAttributes, ref typeIndex, options));
				}
				ApplyTypeArgumentsTo(astType, list);
				return astType;
			}
			if (type is GenericParameter)
			{
				return new SimpleType(type.Name);
			}
			if (type.IsNested)
			{
				AstType target = ConvertType(type.DeclaringType, typeAttributes, ref typeIndex, options & ~ConvertTypeOptions.IncludeTypeParameterDefinitions);
				string memberName = ReflectionHelper.SplitTypeParameterCountFromReflectionName(type.Name);
				MemberType memberType = new MemberType
				{
					Target = target,
					MemberName = memberName
				};
				memberType.AddAnnotation(type);
				if ((options & ConvertTypeOptions.IncludeTypeParameterDefinitions) == ConvertTypeOptions.IncludeTypeParameterDefinitions)
				{
					AddTypeParameterDefininitionsTo(type, memberType);
				}
				return memberType;
			}
			string text = type.Namespace ?? string.Empty;
			string name = type.Name;
			if (name == null)
			{
				throw new InvalidOperationException("type.Name returned null. Type: " + type.ToString());
			}
			if (name == "Object" && text == "System" && HasDynamicAttribute(typeAttributes, typeIndex))
			{
				return new PrimitiveType("dynamic");
			}
			if (text == "System" && (options & ConvertTypeOptions.DoNotUsePrimitiveTypeNames) != ConvertTypeOptions.DoNotUsePrimitiveTypeNames)
			{
				switch (name)
				{
				case "SByte":
					return new PrimitiveType("sbyte");
				case "Int16":
					return new PrimitiveType("short");
				case "Int32":
					return new PrimitiveType("int");
				case "Int64":
					return new PrimitiveType("long");
				case "Byte":
					return new PrimitiveType("byte");
				case "UInt16":
					return new PrimitiveType("ushort");
				case "UInt32":
					return new PrimitiveType("uint");
				case "UInt64":
					return new PrimitiveType("ulong");
				case "String":
					return new PrimitiveType("string");
				case "Single":
					return new PrimitiveType("float");
				case "Double":
					return new PrimitiveType("double");
				case "Decimal":
					return new PrimitiveType("decimal");
				case "Char":
					return new PrimitiveType("char");
				case "Boolean":
					return new PrimitiveType("bool");
				case "Void":
					return new PrimitiveType("void");
				case "Object":
					return new PrimitiveType("object");
				}
			}
			name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(name);
			AstType astType2;
			if ((options & ConvertTypeOptions.IncludeNamespace) == ConvertTypeOptions.IncludeNamespace && text.Length > 0)
			{
				string[] array = text.Split('.');
				AstType target2 = new SimpleType(array[0]);
				for (int i = 1; i < array.Length; i++)
				{
					target2 = new MemberType
					{
						Target = target2,
						MemberName = array[i]
					};
				}
				astType2 = new MemberType
				{
					Target = target2,
					MemberName = name
				};
			}
			else
			{
				astType2 = new SimpleType(name);
			}
			astType2.AddAnnotation(type);
			if ((options & ConvertTypeOptions.IncludeTypeParameterDefinitions) == ConvertTypeOptions.IncludeTypeParameterDefinitions)
			{
				AddTypeParameterDefininitionsTo(type, astType2);
			}
			return astType2;
		}

		private static void AddTypeParameterDefininitionsTo(TypeReference type, AstType astType)
		{
			if (type.HasGenericParameters)
			{
				List<AstType> list = new List<AstType>();
				foreach (GenericParameter genericParameter in type.GenericParameters)
				{
					list.Add(new SimpleType(genericParameter.Name));
				}
				ApplyTypeArgumentsTo(astType, list);
			}
		}

		private static void ApplyTypeArgumentsTo(AstType baseType, List<AstType> typeArguments)
		{
			(baseType as SimpleType)?.TypeArguments.AddRange(typeArguments);
			MemberType memberType = baseType as MemberType;
			if (memberType == null)
			{
				return;
			}
			TypeReference typeReference = memberType.Annotation<TypeReference>();
			if (typeReference != null)
			{
				ReflectionHelper.SplitTypeParameterCountFromReflectionName(typeReference.Name, out int typeParameterCount);
				if (typeParameterCount > typeArguments.Count)
				{
					typeParameterCount = typeArguments.Count;
				}
				memberType.TypeArguments.AddRange(typeArguments.GetRange(typeArguments.Count - typeParameterCount, typeParameterCount));
				typeArguments.RemoveRange(typeArguments.Count - typeParameterCount, typeParameterCount);
				if (typeArguments.Count > 0)
				{
					ApplyTypeArgumentsTo(memberType.Target, typeArguments);
				}
			}
			else
			{
				memberType.TypeArguments.AddRange(typeArguments);
			}
		}

		private static bool HasDynamicAttribute(ICustomAttributeProvider attributeProvider, int typeIndex)
		{
			if (attributeProvider == null || !attributeProvider.HasCustomAttributes)
			{
				return false;
			}
			foreach (CustomAttribute customAttribute in attributeProvider.CustomAttributes)
			{
				if (customAttribute.Constructor.DeclaringType.FullName == "System.Runtime.CompilerServices.DynamicAttribute")
				{
					if (customAttribute.ConstructorArguments.Count == 1)
					{
						CustomAttributeArgument[] array = customAttribute.ConstructorArguments[0].Value as CustomAttributeArgument[];
						if (array != null && typeIndex < array.Length && array[typeIndex].Value is bool)
						{
							return (bool)array[typeIndex].Value;
						}
					}
					return true;
				}
			}
			return false;
		}

		private Modifiers ConvertModifiers(TypeDefinition typeDef)
		{
			Modifiers modifiers = Modifiers.None;
			if (typeDef.IsNestedPrivate)
			{
				modifiers |= Modifiers.Private;
			}
			else if (typeDef.IsNestedAssembly || typeDef.IsNestedFamilyAndAssembly || typeDef.IsNotPublic)
			{
				modifiers |= Modifiers.Internal;
			}
			else if (typeDef.IsNestedFamily)
			{
				modifiers |= Modifiers.Protected;
			}
			else if (typeDef.IsNestedFamilyOrAssembly)
			{
				modifiers |= (Modifiers.Internal | Modifiers.Protected);
			}
			else if (typeDef.IsPublic || typeDef.IsNestedPublic)
			{
				modifiers |= Modifiers.Public;
			}
			if (typeDef.IsAbstract && typeDef.IsSealed)
			{
				modifiers |= Modifiers.Static;
			}
			else if (typeDef.IsAbstract)
			{
				modifiers |= Modifiers.Abstract;
			}
			else if (typeDef.IsSealed)
			{
				modifiers |= Modifiers.Sealed;
			}
			return modifiers;
		}

		private Modifiers ConvertModifiers(FieldDefinition fieldDef)
		{
			Modifiers modifiers = Modifiers.None;
			if (fieldDef.IsPrivate)
			{
				modifiers |= Modifiers.Private;
			}
			else if (fieldDef.IsAssembly || fieldDef.IsFamilyAndAssembly)
			{
				modifiers |= Modifiers.Internal;
			}
			else if (fieldDef.IsFamily)
			{
				modifiers |= Modifiers.Protected;
			}
			else if (fieldDef.IsFamilyOrAssembly)
			{
				modifiers |= (Modifiers.Internal | Modifiers.Protected);
			}
			else if (fieldDef.IsPublic)
			{
				modifiers |= Modifiers.Public;
			}
			if (fieldDef.IsLiteral)
			{
				modifiers |= Modifiers.Const;
			}
			else
			{
				if (fieldDef.IsStatic)
				{
					modifiers |= Modifiers.Static;
				}
				if (fieldDef.IsInitOnly)
				{
					modifiers |= Modifiers.Readonly;
				}
			}
			RequiredModifierType requiredModifierType = fieldDef.FieldType as RequiredModifierType;
			if (requiredModifierType != null && requiredModifierType.ModifierType.FullName == typeof(IsVolatile).FullName)
			{
				modifiers |= Modifiers.Volatile;
			}
			return modifiers;
		}

		private Modifiers ConvertModifiers(MethodDefinition methodDef)
		{
			if (methodDef == null)
			{
				return Modifiers.None;
			}
			Modifiers modifiers = Modifiers.None;
			if (methodDef.IsPrivate)
			{
				modifiers |= Modifiers.Private;
			}
			else if (methodDef.IsAssembly || methodDef.IsFamilyAndAssembly)
			{
				modifiers |= Modifiers.Internal;
			}
			else if (methodDef.IsFamily)
			{
				modifiers |= Modifiers.Protected;
			}
			else if (methodDef.IsFamilyOrAssembly)
			{
				modifiers |= (Modifiers.Internal | Modifiers.Protected);
			}
			else if (methodDef.IsPublic)
			{
				modifiers |= Modifiers.Public;
			}
			if (methodDef.IsStatic)
			{
				modifiers |= Modifiers.Static;
			}
			if (methodDef.IsAbstract)
			{
				modifiers |= Modifiers.Abstract;
				if (!methodDef.IsNewSlot)
				{
					modifiers |= Modifiers.Override;
				}
			}
			else if (methodDef.IsFinal)
			{
				if (!methodDef.IsNewSlot)
				{
					modifiers |= (Modifiers.Sealed | Modifiers.Override);
				}
			}
			else if (methodDef.IsVirtual)
			{
				modifiers = ((!methodDef.IsNewSlot) ? (modifiers | Modifiers.Override) : (modifiers | Modifiers.Virtual));
			}
			if (!methodDef.HasBody && !methodDef.IsAbstract)
			{
				modifiers |= Modifiers.Extern;
			}
			return modifiers;
		}

		private void AddTypeMembers(TypeDeclaration astType, TypeDefinition typeDef)
		{
			foreach (TypeDefinition nestedType in typeDef.NestedTypes)
			{
				if (!MemberIsHidden(nestedType, context.Settings))
				{
					EntityDeclaration entityDeclaration = CreateType(nestedType);
					SetNewModifier(entityDeclaration);
					astType.AddChild(entityDeclaration, Roles.TypeMemberRole);
				}
			}
			foreach (FieldDefinition field in typeDef.Fields)
			{
				if (!MemberIsHidden(field, context.Settings))
				{
					astType.AddChild(CreateField(field), Roles.TypeMemberRole);
				}
			}
			foreach (EventDefinition @event in typeDef.Events)
			{
				astType.AddChild(CreateEvent(@event), Roles.TypeMemberRole);
			}
			foreach (PropertyDefinition property in typeDef.Properties)
			{
				astType.Members.Add(CreateProperty(property));
			}
			foreach (MethodDefinition method in typeDef.Methods)
			{
				if (!MemberIsHidden(method, context.Settings))
				{
					if (method.IsConstructor)
					{
						astType.Members.Add(CreateConstructor(method));
					}
					else
					{
						astType.Members.Add(CreateMethod(method));
					}
				}
			}
		}

		private EntityDeclaration CreateMethod(MethodDefinition methodDef)
		{
			MethodDeclaration methodDeclaration = new MethodDeclaration();
			methodDeclaration.AddAnnotation(methodDef);
			methodDeclaration.ReturnType = ConvertType(methodDef.ReturnType, methodDef.MethodReturnType);
			methodDeclaration.Name = CleanName(methodDef.Name);
			methodDeclaration.TypeParameters.AddRange(MakeTypeParameters(methodDef.GenericParameters));
			methodDeclaration.Parameters.AddRange(MakeParameters(methodDef));
			bool flag = false;
			if (!methodDef.IsVirtual || (methodDef.IsNewSlot && !methodDef.IsPrivate))
			{
				methodDeclaration.Constraints.AddRange(MakeConstraints(methodDef.GenericParameters));
			}
			if (!methodDef.DeclaringType.IsInterface)
			{
				if (IsExplicitInterfaceImplementation(methodDef))
				{
					methodDeclaration.PrivateImplementationType = ConvertType(methodDef.Overrides.First().DeclaringType);
				}
				else
				{
					methodDeclaration.Modifiers = ConvertModifiers(methodDef);
					if (methodDef.IsVirtual == methodDef.IsNewSlot)
					{
						SetNewModifier(methodDeclaration);
					}
				}
				flag = true;
			}
			else if (methodDef.IsStatic)
			{
				methodDeclaration.Modifiers = ConvertModifiers(methodDef);
				flag = true;
			}
			if (flag)
			{
				methodDeclaration.Body = CreateMethodBody(methodDef, methodDeclaration.Parameters);
				if (context.CurrentMethodIsAsync)
				{
					methodDeclaration.Modifiers |= Modifiers.Async;
					context.CurrentMethodIsAsync = false;
				}
			}
			ConvertAttributes(methodDeclaration, methodDef);
			if (methodDef.HasCustomAttributes && methodDeclaration.Parameters.Count > 0)
			{
				foreach (CustomAttribute customAttribute in methodDef.CustomAttributes)
				{
					if (customAttribute.AttributeType.Name == "ExtensionAttribute" && customAttribute.AttributeType.Namespace == "System.Runtime.CompilerServices")
					{
						methodDeclaration.Parameters.First().ParameterModifier = ParameterModifier.This;
					}
				}
			}
			if (methodDef.IsSpecialName && !methodDef.HasGenericParameters)
			{
				OperatorType? operatorType = OperatorDeclaration.GetOperatorType(methodDef.Name);
				if (operatorType.HasValue)
				{
					OperatorDeclaration operatorDeclaration = new OperatorDeclaration();
					operatorDeclaration.CopyAnnotationsFrom(methodDeclaration);
					operatorDeclaration.ReturnType = methodDeclaration.ReturnType.Detach();
					operatorDeclaration.OperatorType = operatorType.Value;
					operatorDeclaration.Modifiers = methodDeclaration.Modifiers;
					methodDeclaration.Parameters.MoveTo(operatorDeclaration.Parameters);
					methodDeclaration.Attributes.MoveTo(operatorDeclaration.Attributes);
					operatorDeclaration.Body = methodDeclaration.Body.Detach();
					return operatorDeclaration;
				}
			}
			return methodDeclaration;
		}

		private bool IsExplicitInterfaceImplementation(MethodDefinition methodDef)
		{
			if (methodDef.HasOverrides)
			{
				return methodDef.IsPrivate;
			}
			return false;
		}

		private IEnumerable<TypeParameterDeclaration> MakeTypeParameters(IEnumerable<GenericParameter> genericParameters)
		{
			foreach (GenericParameter genericParameter in genericParameters)
			{
				TypeParameterDeclaration typeParameterDeclaration = new TypeParameterDeclaration();
				typeParameterDeclaration.Name = CleanName(genericParameter.Name);
				if (genericParameter.IsContravariant)
				{
					typeParameterDeclaration.Variance = VarianceModifier.Contravariant;
				}
				else if (genericParameter.IsCovariant)
				{
					typeParameterDeclaration.Variance = VarianceModifier.Covariant;
				}
				ConvertCustomAttributes(typeParameterDeclaration, genericParameter);
				yield return typeParameterDeclaration;
			}
		}

		private IEnumerable<Constraint> MakeConstraints(IEnumerable<GenericParameter> genericParameters)
		{
			foreach (GenericParameter genericParameter in genericParameters)
			{
				Constraint constraint = new Constraint();
				constraint.TypeParameter = new SimpleType(CleanName(genericParameter.Name));
				if (genericParameter.HasReferenceTypeConstraint)
				{
					constraint.BaseTypes.Add(new PrimitiveType("class"));
				}
				if (genericParameter.HasNotNullableValueTypeConstraint)
				{
					constraint.BaseTypes.Add(new PrimitiveType("struct"));
				}
				foreach (TypeReference constraint2 in genericParameter.Constraints)
				{
					if (!genericParameter.HasNotNullableValueTypeConstraint || !(constraint2.FullName == "System.ValueType"))
					{
						constraint.BaseTypes.Add(ConvertType(constraint2));
					}
				}
				if (genericParameter.HasDefaultConstructorConstraint && !genericParameter.HasNotNullableValueTypeConstraint)
				{
					constraint.BaseTypes.Add(new PrimitiveType("new"));
				}
				if (constraint.BaseTypes.Any())
				{
					yield return constraint;
				}
			}
		}

		private ConstructorDeclaration CreateConstructor(MethodDefinition methodDef)
		{
			ConstructorDeclaration constructorDeclaration = new ConstructorDeclaration();
			constructorDeclaration.AddAnnotation(methodDef);
			constructorDeclaration.Modifiers = ConvertModifiers(methodDef);
			if (methodDef.IsStatic)
			{
				constructorDeclaration.Modifiers &= ~(Modifiers.Private | Modifiers.Internal | Modifiers.Protected | Modifiers.Public);
			}
			constructorDeclaration.Name = CleanName(methodDef.DeclaringType.Name);
			constructorDeclaration.Parameters.AddRange(MakeParameters(methodDef));
			constructorDeclaration.Body = CreateMethodBody(methodDef, constructorDeclaration.Parameters);
			ConvertAttributes(constructorDeclaration, methodDef);
			if (methodDef.IsStatic && methodDef.DeclaringType.IsBeforeFieldInit && !constructorDeclaration.Body.IsNull)
			{
				constructorDeclaration.Body.InsertChildAfter(null, new Comment(" Note: this type is marked as 'beforefieldinit'."), Roles.Comment);
			}
			return constructorDeclaration;
		}

		private Modifiers FixUpVisibility(Modifiers m)
		{
			Modifiers modifiers = m & Modifiers.VisibilityMask;
			if ((modifiers & Modifiers.Public) == Modifiers.Public)
			{
				return Modifiers.Public | (m & ~(Modifiers.Private | Modifiers.Internal | Modifiers.Protected | Modifiers.Public));
			}
			if (modifiers == Modifiers.Private)
			{
				return m;
			}
			return m & ~Modifiers.Private;
		}

		private EntityDeclaration CreateProperty(PropertyDefinition propDef)
		{
			PropertyDeclaration propertyDeclaration = new PropertyDeclaration();
			propertyDeclaration.AddAnnotation(propDef);
			MethodDefinition methodDefinition = propDef.GetMethod ?? propDef.SetMethod;
			Modifiers modifiers = Modifiers.None;
			Modifiers modifiers2 = Modifiers.None;
			if (IsExplicitInterfaceImplementation(methodDefinition))
			{
				propertyDeclaration.PrivateImplementationType = ConvertType(methodDefinition.Overrides.First().DeclaringType);
			}
			else if (!propDef.DeclaringType.IsInterface)
			{
				modifiers = ConvertModifiers(propDef.GetMethod);
				modifiers2 = ConvertModifiers(propDef.SetMethod);
				propertyDeclaration.Modifiers = FixUpVisibility(modifiers | modifiers2);
				try
				{
					if (methodDefinition.IsVirtual && !methodDefinition.IsNewSlot && (propDef.GetMethod == null || propDef.SetMethod == null))
					{
						foreach (PropertyDefinition item in TypesHierarchyHelpers.FindBaseProperties(propDef))
						{
							if (item.GetMethod != null && item.SetMethod != null)
							{
								Modifiers modifiers3 = ConvertModifiers(item.GetMethod) | ConvertModifiers(item.SetMethod);
								propertyDeclaration.Modifiers = FixUpVisibility((propertyDeclaration.Modifiers & ~(Modifiers.Private | Modifiers.Internal | Modifiers.Protected | Modifiers.Public)) | (modifiers3 & Modifiers.VisibilityMask));
								break;
							}
							if ((item.GetMethod ?? item.SetMethod).IsNewSlot)
							{
								break;
							}
						}
					}
				}
				catch (ReferenceResolvingException)
				{
				}
			}
			propertyDeclaration.Name = CleanName(propDef.Name);
			propertyDeclaration.ReturnType = ConvertType(propDef.PropertyType, propDef);
			if (propDef.GetMethod != null)
			{
				propertyDeclaration.Getter = new Accessor();
				propertyDeclaration.Getter.Body = CreateMethodBody(propDef.GetMethod);
				propertyDeclaration.Getter.AddAnnotation(propDef.GetMethod);
				ConvertAttributes(propertyDeclaration.Getter, propDef.GetMethod);
				if ((modifiers & Modifiers.VisibilityMask) != (propertyDeclaration.Modifiers & Modifiers.VisibilityMask))
				{
					propertyDeclaration.Getter.Modifiers = (modifiers & Modifiers.VisibilityMask);
				}
			}
			if (propDef.SetMethod != null)
			{
				propertyDeclaration.Setter = new Accessor();
				propertyDeclaration.Setter.Body = CreateMethodBody(propDef.SetMethod);
				propertyDeclaration.Setter.AddAnnotation(propDef.SetMethod);
				ConvertAttributes(propertyDeclaration.Setter, propDef.SetMethod);
				ParameterDefinition parameterDefinition = propDef.SetMethod.Parameters.LastOrDefault();
				if (parameterDefinition != null)
				{
					ConvertCustomAttributes(propertyDeclaration.Setter, parameterDefinition, "param");
					if (parameterDefinition.HasMarshalInfo)
					{
						propertyDeclaration.Setter.Attributes.Add(new AttributeSection(ConvertMarshalInfo(parameterDefinition, propDef.Module))
						{
							AttributeTarget = "param"
						});
					}
				}
				if ((modifiers2 & Modifiers.VisibilityMask) != (propertyDeclaration.Modifiers & Modifiers.VisibilityMask))
				{
					propertyDeclaration.Setter.Modifiers = (modifiers2 & Modifiers.VisibilityMask);
				}
			}
			ConvertCustomAttributes(propertyDeclaration, propDef);
			EntityDeclaration entityDeclaration = propertyDeclaration;
			if (propDef.IsIndexer())
			{
				entityDeclaration = ConvertPropertyToIndexer(propertyDeclaration, propDef);
			}
			if (!methodDefinition.HasOverrides && !methodDefinition.DeclaringType.IsInterface && methodDefinition.IsVirtual == methodDefinition.IsNewSlot)
			{
				SetNewModifier(entityDeclaration);
			}
			return entityDeclaration;
		}

		private IndexerDeclaration ConvertPropertyToIndexer(PropertyDeclaration astProp, PropertyDefinition propDef)
		{
			IndexerDeclaration indexerDeclaration = new IndexerDeclaration();
			indexerDeclaration.CopyAnnotationsFrom(astProp);
			astProp.Attributes.MoveTo(indexerDeclaration.Attributes);
			indexerDeclaration.Modifiers = astProp.Modifiers;
			indexerDeclaration.PrivateImplementationType = astProp.PrivateImplementationType.Detach();
			indexerDeclaration.ReturnType = astProp.ReturnType.Detach();
			indexerDeclaration.Getter = astProp.Getter.Detach();
			indexerDeclaration.Setter = astProp.Setter.Detach();
			indexerDeclaration.Parameters.AddRange(MakeParameters(propDef.Parameters));
			return indexerDeclaration;
		}

		private EntityDeclaration CreateEvent(EventDefinition eventDef)
		{
			if (eventDef.AddMethod != null && eventDef.AddMethod.IsAbstract)
			{
				EventDeclaration eventDeclaration = new EventDeclaration();
				ConvertCustomAttributes(eventDeclaration, eventDef);
				eventDeclaration.AddAnnotation(eventDef);
				eventDeclaration.Variables.Add(new VariableInitializer(CleanName(eventDef.Name)));
				eventDeclaration.ReturnType = ConvertType(eventDef.EventType, eventDef);
				if (!eventDef.DeclaringType.IsInterface)
				{
					eventDeclaration.Modifiers = ConvertModifiers(eventDef.AddMethod);
				}
				return eventDeclaration;
			}
			CustomEventDeclaration customEventDeclaration = new CustomEventDeclaration();
			ConvertCustomAttributes(customEventDeclaration, eventDef);
			customEventDeclaration.AddAnnotation(eventDef);
			customEventDeclaration.Name = CleanName(eventDef.Name);
			customEventDeclaration.ReturnType = ConvertType(eventDef.EventType, eventDef);
			if (eventDef.AddMethod == null || !IsExplicitInterfaceImplementation(eventDef.AddMethod))
			{
				customEventDeclaration.Modifiers = ConvertModifiers(eventDef.AddMethod);
			}
			else
			{
				customEventDeclaration.PrivateImplementationType = ConvertType(eventDef.AddMethod.Overrides.First().DeclaringType);
			}
			if (eventDef.AddMethod != null)
			{
				customEventDeclaration.AddAccessor = new Accessor
				{
					Body = CreateMethodBody(eventDef.AddMethod)
				}.WithAnnotation(eventDef.AddMethod);
				ConvertAttributes(customEventDeclaration.AddAccessor, eventDef.AddMethod);
			}
			if (eventDef.RemoveMethod != null)
			{
				customEventDeclaration.RemoveAccessor = new Accessor
				{
					Body = CreateMethodBody(eventDef.RemoveMethod)
				}.WithAnnotation(eventDef.RemoveMethod);
				ConvertAttributes(customEventDeclaration.RemoveAccessor, eventDef.RemoveMethod);
			}
			MethodDefinition methodDefinition = eventDef.AddMethod ?? eventDef.RemoveMethod;
			if (methodDefinition.IsVirtual == methodDefinition.IsNewSlot)
			{
				SetNewModifier(customEventDeclaration);
			}
			return customEventDeclaration;
		}

		private BlockStatement CreateMethodBody(MethodDefinition method, IEnumerable<ParameterDeclaration> parameters = null)
		{
			if (DecompileMethodBodies)
			{
				return AstMethodBodyBuilder.CreateMethodBody(method, context, parameters);
			}
			return null;
		}

		private FieldDeclaration CreateField(FieldDefinition fieldDef)
		{
			FieldDeclaration fieldDeclaration = new FieldDeclaration();
			fieldDeclaration.AddAnnotation(fieldDef);
			VariableInitializer variableInitializer = new VariableInitializer(CleanName(fieldDef.Name));
			fieldDeclaration.AddChild(variableInitializer, Roles.Variable);
			fieldDeclaration.ReturnType = ConvertType(fieldDef.FieldType, fieldDef);
			fieldDeclaration.Modifiers = ConvertModifiers(fieldDef);
			if (fieldDef.HasConstant)
			{
				variableInitializer.Initializer = CreateExpressionForConstant(fieldDef.Constant, fieldDef.FieldType, fieldDef.DeclaringType.IsEnum);
			}
			ConvertAttributes(fieldDeclaration, fieldDef);
			SetNewModifier(fieldDeclaration);
			return fieldDeclaration;
		}

		private static Expression CreateExpressionForConstant(object constant, TypeReference type, bool isEnumMemberDeclaration = false)
		{
			if (constant == null)
			{
				if (type.IsValueType && (!(type.Namespace == "System") || !(type.Name == "Nullable`1")))
				{
					return new DefaultValueExpression(ConvertType(type));
				}
				return new NullReferenceExpression();
			}
			TypeCode typeCode = Type.GetTypeCode(constant.GetType());
			if (typeCode >= TypeCode.SByte && typeCode <= TypeCode.UInt64 && !isEnumMemberDeclaration)
			{
				return MakePrimitive((long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constant, checkForOverflow: false), type);
			}
			return new PrimitiveExpression(constant);
		}

		public static IEnumerable<ParameterDeclaration> MakeParameters(MethodDefinition method, bool isLambda = false)
		{
			IEnumerable<ParameterDeclaration> enumerable = MakeParameters(method.Parameters, isLambda);
			if (method.CallingConvention == MethodCallingConvention.VarArg)
			{
				return enumerable.Concat(new ParameterDeclaration[1]
				{
					new ParameterDeclaration
					{
						Type = new PrimitiveType("__arglist")
					}
				});
			}
			return enumerable;
		}

		public static IEnumerable<ParameterDeclaration> MakeParameters(IEnumerable<ParameterDefinition> paramCol, bool isLambda = false)
		{
			foreach (ParameterDefinition item in paramCol)
			{
				ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
				parameterDeclaration.AddAnnotation(item);
				if (!isLambda || !item.ParameterType.ContainsAnonymousType())
				{
					parameterDeclaration.Type = ConvertType(item.ParameterType, item);
				}
				parameterDeclaration.Name = item.Name;
				if (item.ParameterType is Mono.Cecil.ByReferenceType)
				{
					parameterDeclaration.ParameterModifier = ((item.IsIn || !item.IsOut) ? ParameterModifier.Ref : ParameterModifier.Out);
					ComposedType composedType = parameterDeclaration.Type as ComposedType;
					if (composedType != null && composedType.PointerRank > 0)
					{
						composedType.PointerRank--;
					}
				}
				if (item.HasCustomAttributes)
				{
					foreach (CustomAttribute customAttribute in item.CustomAttributes)
					{
						if (customAttribute.AttributeType.Name == "ParamArrayAttribute" && customAttribute.AttributeType.Namespace == "System")
						{
							parameterDeclaration.ParameterModifier = ParameterModifier.Params;
						}
					}
				}
				if (item.IsOptional)
				{
					parameterDeclaration.DefaultExpression = CreateExpressionForConstant(item.Constant, item.ParameterType);
				}
				ConvertCustomAttributes(parameterDeclaration, item);
				ModuleDefinition module = ((MethodDefinition)item.Method).Module;
				if (item.HasMarshalInfo)
				{
					parameterDeclaration.Attributes.Add(new AttributeSection(ConvertMarshalInfo(item, module)));
				}
				if (parameterDeclaration.ParameterModifier != ParameterModifier.Out)
				{
					if (item.IsIn)
					{
						parameterDeclaration.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(InAttribute), module)));
					}
					if (item.IsOut)
					{
						parameterDeclaration.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(OutAttribute), module)));
					}
				}
				yield return parameterDeclaration;
			}
		}

		private void ConvertAttributes(EntityDeclaration attributedNode, TypeDefinition typeDefinition)
		{
			ConvertCustomAttributes(attributedNode, typeDefinition);
			ConvertSecurityAttributes(attributedNode, typeDefinition);
			if (typeDefinition.IsSerializable)
			{
				attributedNode.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(SerializableAttribute))));
			}
			if (typeDefinition.IsImport)
			{
				attributedNode.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(ComImportAttribute))));
			}
			LayoutKind layoutKind = LayoutKind.Auto;
			switch (typeDefinition.Attributes & TypeAttributes.LayoutMask)
			{
			case TypeAttributes.SequentialLayout:
				layoutKind = LayoutKind.Sequential;
				break;
			case TypeAttributes.ExplicitLayout:
				layoutKind = LayoutKind.Explicit;
				break;
			}
			CharSet charSet = CharSet.None;
			switch (typeDefinition.Attributes & TypeAttributes.StringFormatMask)
			{
			case TypeAttributes.NotPublic:
				charSet = CharSet.Ansi;
				break;
			case TypeAttributes.AutoClass:
				charSet = CharSet.Auto;
				break;
			case TypeAttributes.UnicodeClass:
				charSet = CharSet.Unicode;
				break;
			}
			LayoutKind layoutKind2 = (!typeDefinition.IsValueType || typeDefinition.IsEnum) ? LayoutKind.Auto : LayoutKind.Sequential;
			if (layoutKind != layoutKind2 || charSet != CharSet.Ansi || typeDefinition.PackingSize > 0 || typeDefinition.ClassSize > 0)
			{
				ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute(typeof(StructLayoutAttribute));
				attribute.Arguments.Add(new IdentifierExpression("LayoutKind").Member(layoutKind.ToString()));
				if (charSet != CharSet.Ansi)
				{
					attribute.AddNamedArgument("CharSet", new IdentifierExpression("CharSet").Member(charSet.ToString()));
				}
				if (typeDefinition.PackingSize > 0)
				{
					attribute.AddNamedArgument("Pack", new PrimitiveExpression((int)typeDefinition.PackingSize));
				}
				if (typeDefinition.ClassSize > 0)
				{
					attribute.AddNamedArgument("Size", new PrimitiveExpression(typeDefinition.ClassSize));
				}
				attributedNode.Attributes.Add(new AttributeSection(attribute));
			}
		}

		private void ConvertAttributes(EntityDeclaration attributedNode, MethodDefinition methodDefinition)
		{
			ConvertCustomAttributes(attributedNode, methodDefinition);
			ConvertSecurityAttributes(attributedNode, methodDefinition);
			MethodImplAttributes methodImplAttributes = methodDefinition.ImplAttributes & ~MethodImplAttributes.CodeTypeMask;
			if (methodDefinition.HasPInvokeInfo && methodDefinition.PInvokeInfo != null)
			{
				PInvokeInfo pInvokeInfo = methodDefinition.PInvokeInfo;
				ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute(typeof(DllImportAttribute));
				attribute.Arguments.Add(new PrimitiveExpression(pInvokeInfo.Module.Name));
				if (pInvokeInfo.IsBestFitDisabled)
				{
					attribute.AddNamedArgument("BestFitMapping", new PrimitiveExpression(false));
				}
				if (pInvokeInfo.IsBestFitEnabled)
				{
					attribute.AddNamedArgument("BestFitMapping", new PrimitiveExpression(true));
				}
				CallingConvention callingConvention;
				switch (pInvokeInfo.Attributes & PInvokeAttributes.CallConvMask)
				{
				case PInvokeAttributes.CallConvCdecl:
					callingConvention = CallingConvention.Cdecl;
					break;
				case PInvokeAttributes.CallConvFastcall:
					callingConvention = CallingConvention.FastCall;
					break;
				case PInvokeAttributes.CallConvStdCall:
					callingConvention = CallingConvention.StdCall;
					break;
				case PInvokeAttributes.CallConvThiscall:
					callingConvention = CallingConvention.ThisCall;
					break;
				case PInvokeAttributes.CallConvWinapi:
					callingConvention = CallingConvention.Winapi;
					break;
				default:
					throw new NotSupportedException("unknown calling convention");
				}
				if (callingConvention != CallingConvention.Winapi)
				{
					attribute.AddNamedArgument("CallingConvention", new IdentifierExpression("CallingConvention").Member(callingConvention.ToString()));
				}
				CharSet charSet = CharSet.None;
				switch (pInvokeInfo.Attributes & PInvokeAttributes.CharSetMask)
				{
				case PInvokeAttributes.CharSetAnsi:
					charSet = CharSet.Ansi;
					break;
				case PInvokeAttributes.CharSetMask:
					charSet = CharSet.Auto;
					break;
				case PInvokeAttributes.CharSetUnicode:
					charSet = CharSet.Unicode;
					break;
				}
				if (charSet != CharSet.None)
				{
					attribute.AddNamedArgument("CharSet", new IdentifierExpression("CharSet").Member(charSet.ToString()));
				}
				if (!string.IsNullOrEmpty(pInvokeInfo.EntryPoint) && pInvokeInfo.EntryPoint != methodDefinition.Name)
				{
					attribute.AddNamedArgument("EntryPoint", new PrimitiveExpression(pInvokeInfo.EntryPoint));
				}
				if (pInvokeInfo.IsNoMangle)
				{
					attribute.AddNamedArgument("ExactSpelling", new PrimitiveExpression(true));
				}
				if ((methodImplAttributes & MethodImplAttributes.PreserveSig) == MethodImplAttributes.PreserveSig)
				{
					methodImplAttributes &= ~MethodImplAttributes.PreserveSig;
				}
				else
				{
					attribute.AddNamedArgument("PreserveSig", new PrimitiveExpression(false));
				}
				if (pInvokeInfo.SupportsLastError)
				{
					attribute.AddNamedArgument("SetLastError", new PrimitiveExpression(true));
				}
				if (pInvokeInfo.IsThrowOnUnmappableCharDisabled)
				{
					attribute.AddNamedArgument("ThrowOnUnmappableChar", new PrimitiveExpression(false));
				}
				if (pInvokeInfo.IsThrowOnUnmappableCharEnabled)
				{
					attribute.AddNamedArgument("ThrowOnUnmappableChar", new PrimitiveExpression(true));
				}
				attributedNode.Attributes.Add(new AttributeSection(attribute));
			}
			if (methodImplAttributes == MethodImplAttributes.PreserveSig)
			{
				attributedNode.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(PreserveSigAttribute))));
				methodImplAttributes = MethodImplAttributes.IL;
			}
			if (methodImplAttributes != 0)
			{
				ICSharpCode.NRefactory.CSharp.Attribute attribute2 = CreateNonCustomAttribute(typeof(MethodImplAttribute));
				TypeReference type = new TypeReference("System.Runtime.CompilerServices", "MethodImplOptions", methodDefinition.Module, methodDefinition.Module.TypeSystem.CoreLibrary);
				attribute2.Arguments.Add(MakePrimitive((long)methodImplAttributes, type));
				attributedNode.Attributes.Add(new AttributeSection(attribute2));
			}
			ConvertAttributes(attributedNode, methodDefinition.MethodReturnType, methodDefinition.Module);
		}

		private void ConvertAttributes(EntityDeclaration attributedNode, MethodReturnType methodReturnType, ModuleDefinition module)
		{
			ConvertCustomAttributes(attributedNode, methodReturnType, "return");
			if (methodReturnType.HasMarshalInfo)
			{
				ICSharpCode.NRefactory.CSharp.Attribute attr = ConvertMarshalInfo(methodReturnType, module);
				attributedNode.Attributes.Add(new AttributeSection(attr)
				{
					AttributeTarget = "return"
				});
			}
		}

		internal static void ConvertAttributes(EntityDeclaration attributedNode, FieldDefinition fieldDefinition, string attributeTarget = null)
		{
			ConvertCustomAttributes(attributedNode, fieldDefinition);
			if (fieldDefinition.HasLayoutInfo)
			{
				ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute(typeof(FieldOffsetAttribute), fieldDefinition.Module);
				attribute.Arguments.Add(new PrimitiveExpression(fieldDefinition.Offset));
				attributedNode.Attributes.Add(new AttributeSection(attribute)
				{
					AttributeTarget = attributeTarget
				});
			}
			if (fieldDefinition.IsNotSerialized)
			{
				ICSharpCode.NRefactory.CSharp.Attribute attr = CreateNonCustomAttribute(typeof(NonSerializedAttribute), fieldDefinition.Module);
				attributedNode.Attributes.Add(new AttributeSection(attr)
				{
					AttributeTarget = attributeTarget
				});
			}
			if (fieldDefinition.HasMarshalInfo)
			{
				attributedNode.Attributes.Add(new AttributeSection(ConvertMarshalInfo(fieldDefinition, fieldDefinition.Module))
				{
					AttributeTarget = attributeTarget
				});
			}
		}

		private static ICSharpCode.NRefactory.CSharp.Attribute ConvertMarshalInfo(IMarshalInfoProvider marshalInfoProvider, ModuleDefinition module)
		{
			MarshalInfo marshalInfo = marshalInfoProvider.MarshalInfo;
			ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute(typeof(MarshalAsAttribute), module);
			TypeReference type = new TypeReference("System.Runtime.InteropServices", "UnmanagedType", module, module.TypeSystem.CoreLibrary);
			attribute.Arguments.Add(MakePrimitive((long)marshalInfo.NativeType, type));
			FixedArrayMarshalInfo fixedArrayMarshalInfo = marshalInfo as FixedArrayMarshalInfo;
			if (fixedArrayMarshalInfo != null)
			{
				attribute.AddNamedArgument("SizeConst", new PrimitiveExpression(fixedArrayMarshalInfo.Size));
				if (fixedArrayMarshalInfo.ElementType != NativeType.None)
				{
					attribute.AddNamedArgument("ArraySubType", MakePrimitive((long)fixedArrayMarshalInfo.ElementType, type));
				}
			}
			SafeArrayMarshalInfo safeArrayMarshalInfo = marshalInfo as SafeArrayMarshalInfo;
			if (safeArrayMarshalInfo != null && safeArrayMarshalInfo.ElementType != 0)
			{
				TypeReference type2 = new TypeReference("System.Runtime.InteropServices", "VarEnum", module, module.TypeSystem.CoreLibrary);
				attribute.AddNamedArgument("SafeArraySubType", MakePrimitive((long)safeArrayMarshalInfo.ElementType, type2));
			}
			ArrayMarshalInfo arrayMarshalInfo = marshalInfo as ArrayMarshalInfo;
			if (arrayMarshalInfo != null)
			{
				if (arrayMarshalInfo.ElementType != NativeType.Max)
				{
					attribute.AddNamedArgument("ArraySubType", MakePrimitive((long)arrayMarshalInfo.ElementType, type));
				}
				if (arrayMarshalInfo.Size >= 0)
				{
					attribute.AddNamedArgument("SizeConst", new PrimitiveExpression(arrayMarshalInfo.Size));
				}
				if (arrayMarshalInfo.SizeParameterMultiplier != 0 && arrayMarshalInfo.SizeParameterIndex >= 0)
				{
					attribute.AddNamedArgument("SizeParamIndex", new PrimitiveExpression(arrayMarshalInfo.SizeParameterIndex));
				}
			}
			CustomMarshalInfo customMarshalInfo = marshalInfo as CustomMarshalInfo;
			if (customMarshalInfo != null)
			{
				attribute.AddNamedArgument("MarshalType", new PrimitiveExpression(customMarshalInfo.ManagedType.FullName));
				if (!string.IsNullOrEmpty(customMarshalInfo.Cookie))
				{
					attribute.AddNamedArgument("MarshalCookie", new PrimitiveExpression(customMarshalInfo.Cookie));
				}
			}
			FixedSysStringMarshalInfo fixedSysStringMarshalInfo = marshalInfo as FixedSysStringMarshalInfo;
			if (fixedSysStringMarshalInfo != null)
			{
				attribute.AddNamedArgument("SizeConst", new PrimitiveExpression(fixedSysStringMarshalInfo.Size));
			}
			return attribute;
		}

		private ICSharpCode.NRefactory.CSharp.Attribute CreateNonCustomAttribute(Type attributeType)
		{
			return CreateNonCustomAttribute(attributeType, (context.CurrentType != null) ? context.CurrentType.Module : null);
		}

		private static ICSharpCode.NRefactory.CSharp.Attribute CreateNonCustomAttribute(Type attributeType, ModuleDefinition module)
		{
			ICSharpCode.NRefactory.CSharp.Attribute attribute = new ICSharpCode.NRefactory.CSharp.Attribute();
			attribute.Type = new SimpleType(attributeType.Name.Substring(0, attributeType.Name.Length - "Attribute".Length));
			if (module != null)
			{
				attribute.Type.AddAnnotation(new TypeReference(attributeType.Namespace, attributeType.Name, module, module.TypeSystem.CoreLibrary));
			}
			return attribute;
		}

		private static void ConvertCustomAttributes(AstNode attributedNode, ICustomAttributeProvider customAttributeProvider, string attributeTarget = null)
		{
			EntityDeclaration entityDeclaration = attributedNode as EntityDeclaration;
			if (customAttributeProvider.HasCustomAttributes)
			{
				List<ICSharpCode.NRefactory.CSharp.Attribute> list = new List<ICSharpCode.NRefactory.CSharp.Attribute>();
				foreach (CustomAttribute item in from a in customAttributeProvider.CustomAttributes
					orderby a.AttributeType.FullName
					select a)
				{
					if ((!(item.AttributeType.Name == "ExtensionAttribute") || !(item.AttributeType.Namespace == "System.Runtime.CompilerServices")) && (!(item.AttributeType.Name == "ParamArrayAttribute") || !(item.AttributeType.Namespace == "System")) && (entityDeclaration == null || !entityDeclaration.HasModifier(Modifiers.Async) || ((!(item.AttributeType.Name == "DebuggerStepThroughAttribute") || !(item.AttributeType.Namespace == "System.Diagnostics")) && (!(item.AttributeType.Name == "AsyncStateMachineAttribute") || !(item.AttributeType.Namespace == "System.Runtime.CompilerServices")))))
					{
						ICSharpCode.NRefactory.CSharp.Attribute attribute = new ICSharpCode.NRefactory.CSharp.Attribute();
						attribute.AddAnnotation(item);
						attribute.Type = ConvertType(item.AttributeType);
						list.Add(attribute);
						SimpleType simpleType = attribute.Type as SimpleType;
						if (simpleType != null && simpleType.Identifier.EndsWith("Attribute", StringComparison.Ordinal))
						{
							simpleType.Identifier = simpleType.Identifier.Substring(0, simpleType.Identifier.Length - "Attribute".Length);
						}
						if (item.HasConstructorArguments)
						{
							foreach (CustomAttributeArgument constructorArgument in item.ConstructorArguments)
							{
								Expression element = ConvertArgumentValue(constructorArgument);
								attribute.Arguments.Add(element);
							}
						}
						if (item.HasProperties)
						{
							TypeDefinition typeDefinition = item.AttributeType.Resolve();
							foreach (CustomAttributeNamedArgument propertyNamedArg in item.Properties)
							{
								PropertyDefinition annotation = typeDefinition?.Properties.FirstOrDefault((PropertyDefinition pr) => pr.Name == propertyNamedArg.Name);
								IdentifierExpression left = new IdentifierExpression(propertyNamedArg.Name).WithAnnotation(annotation);
								Expression right = ConvertArgumentValue(propertyNamedArg.Argument);
								attribute.Arguments.Add(new AssignmentExpression(left, right));
							}
						}
						if (item.HasFields)
						{
							TypeDefinition typeDefinition2 = item.AttributeType.Resolve();
							foreach (CustomAttributeNamedArgument fieldNamedArg in item.Fields)
							{
								FieldDefinition annotation2 = typeDefinition2?.Fields.FirstOrDefault((FieldDefinition f) => f.Name == fieldNamedArg.Name);
								IdentifierExpression left2 = new IdentifierExpression(fieldNamedArg.Name).WithAnnotation(annotation2);
								Expression right2 = ConvertArgumentValue(fieldNamedArg.Argument);
								attribute.Arguments.Add(new AssignmentExpression(left2, right2));
							}
						}
					}
				}
				if (attributeTarget == "module" || attributeTarget == "assembly")
				{
					foreach (ICSharpCode.NRefactory.CSharp.Attribute item2 in list)
					{
						AttributeSection attributeSection = new AttributeSection();
						attributeSection.AttributeTarget = attributeTarget;
						attributeSection.Attributes.Add(item2);
						attributedNode.AddChild(attributeSection, EntityDeclaration.AttributeRole);
					}
				}
				else if (list.Count > 0)
				{
					AttributeSection attributeSection2 = new AttributeSection();
					attributeSection2.AttributeTarget = attributeTarget;
					attributeSection2.Attributes.AddRange(list);
					attributedNode.AddChild(attributeSection2, EntityDeclaration.AttributeRole);
				}
			}
		}

		private static void ConvertSecurityAttributes(AstNode attributedNode, ISecurityDeclarationProvider secDeclProvider, string attributeTarget = null)
		{
			if (secDeclProvider.HasSecurityDeclarations)
			{
				List<ICSharpCode.NRefactory.CSharp.Attribute> list = new List<ICSharpCode.NRefactory.CSharp.Attribute>();
				foreach (SecurityDeclaration item in from d in secDeclProvider.SecurityDeclarations
					orderby d.Action
					select d)
				{
					foreach (SecurityAttribute item2 in from a in item.SecurityAttributes
						orderby a.AttributeType.FullName
						select a)
					{
						ICSharpCode.NRefactory.CSharp.Attribute attribute = new ICSharpCode.NRefactory.CSharp.Attribute();
						attribute.AddAnnotation(item2);
						attribute.Type = ConvertType(item2.AttributeType);
						list.Add(attribute);
						SimpleType simpleType = attribute.Type as SimpleType;
						if (simpleType != null && simpleType.Identifier.EndsWith("Attribute", StringComparison.Ordinal))
						{
							simpleType.Identifier = simpleType.Identifier.Substring(0, simpleType.Identifier.Length - "Attribute".Length);
						}
						ModuleDefinition module = item2.AttributeType.Module;
						TypeReference type = new TypeReference("System.Security.Permissions", "SecurityAction", module, module.TypeSystem.CoreLibrary);
						attribute.Arguments.Add(MakePrimitive((int)item.Action, type));
						if (item2.HasProperties)
						{
							TypeDefinition typeDefinition = item2.AttributeType.Resolve();
							foreach (CustomAttributeNamedArgument propertyNamedArg in item2.Properties)
							{
								PropertyDefinition annotation = typeDefinition?.Properties.FirstOrDefault((PropertyDefinition pr) => pr.Name == propertyNamedArg.Name);
								IdentifierExpression left = new IdentifierExpression(propertyNamedArg.Name).WithAnnotation(annotation);
								Expression right = ConvertArgumentValue(propertyNamedArg.Argument);
								attribute.Arguments.Add(new AssignmentExpression(left, right));
							}
						}
						if (item2.HasFields)
						{
							TypeDefinition typeDefinition2 = item2.AttributeType.Resolve();
							foreach (CustomAttributeNamedArgument fieldNamedArg in item2.Fields)
							{
								FieldDefinition annotation2 = typeDefinition2?.Fields.FirstOrDefault((FieldDefinition f) => f.Name == fieldNamedArg.Name);
								IdentifierExpression left2 = new IdentifierExpression(fieldNamedArg.Name).WithAnnotation(annotation2);
								Expression right2 = ConvertArgumentValue(fieldNamedArg.Argument);
								attribute.Arguments.Add(new AssignmentExpression(left2, right2));
							}
						}
					}
				}
				if (attributeTarget == "module" || attributeTarget == "assembly")
				{
					foreach (ICSharpCode.NRefactory.CSharp.Attribute item3 in list)
					{
						AttributeSection attributeSection = new AttributeSection();
						attributeSection.AttributeTarget = attributeTarget;
						attributeSection.Attributes.Add(item3);
						attributedNode.AddChild(attributeSection, EntityDeclaration.AttributeRole);
					}
				}
				else if (list.Count > 0)
				{
					AttributeSection attributeSection2 = new AttributeSection();
					attributeSection2.AttributeTarget = attributeTarget;
					attributeSection2.Attributes.AddRange(list);
					attributedNode.AddChild(attributeSection2, EntityDeclaration.AttributeRole);
				}
			}
		}

		private static Expression ConvertArgumentValue(CustomAttributeArgument argument)
		{
			if (argument.Value is CustomAttributeArgument[])
			{
				ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
				CustomAttributeArgument[] array = (CustomAttributeArgument[])argument.Value;
				foreach (CustomAttributeArgument argument2 in array)
				{
					arrayInitializerExpression.Elements.Add(ConvertArgumentValue(argument2));
				}
				Mono.Cecil.ArrayType arrayType = argument.Type as Mono.Cecil.ArrayType;
				return new ArrayCreateExpression
				{
					Type = ConvertType((arrayType != null) ? arrayType.ElementType : argument.Type),
					AdditionalArraySpecifiers = 
					{
						new ArraySpecifier()
					},
					Initializer = arrayInitializerExpression
				};
			}
			if (argument.Value is CustomAttributeArgument)
			{
				return ConvertArgumentValue((CustomAttributeArgument)argument.Value);
			}
			TypeDefinition typeDefinition = argument.Type.Resolve();
			if (typeDefinition != null && typeDefinition.IsEnum)
			{
				return MakePrimitive((long)CSharpPrimitiveCast.Cast(TypeCode.Int64, argument.Value, checkForOverflow: false), typeDefinition);
			}
			if (argument.Value is TypeReference)
			{
				return CreateTypeOfExpression((TypeReference)argument.Value);
			}
			return new PrimitiveExpression(argument.Value);
		}

		internal static Expression MakePrimitive(long val, TypeReference type)
		{
			if (TypeAnalysis.IsBoolean(type) && val == 0L)
			{
				return new PrimitiveExpression(false);
			}
			if (TypeAnalysis.IsBoolean(type) && val == 1)
			{
				return new PrimitiveExpression(true);
			}
			if (val == 0L && type is Mono.Cecil.PointerType)
			{
				return new NullReferenceExpression();
			}
			if (type != null)
			{
				TypeDefinition typeDefinition = type.Resolve();
				if (typeDefinition != null && typeDefinition.IsEnum)
				{
					TypeCode typeCode = TypeCode.Int32;
					foreach (FieldDefinition field in typeDefinition.Fields)
					{
						if (field.IsStatic && object.Equals(CSharpPrimitiveCast.Cast(TypeCode.Int64, field.Constant, checkForOverflow: false), val))
						{
							return ConvertType(type).Member(field.Name).WithAnnotation(field);
						}
						if (!field.IsStatic)
						{
							typeCode = TypeAnalysis.GetTypeCode(field.FieldType);
						}
					}
					if (IsFlagsEnum(typeDefinition))
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
						foreach (FieldDefinition item in from fld in typeDefinition.Fields
							where fld.IsStatic
							select fld)
						{
							long num3 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, item.Constant, checkForOverflow: false);
							if (num3 != 0L)
							{
								if ((num3 & num) == num3)
								{
									MemberReferenceExpression memberReferenceExpression = ConvertType(type).Member(item.Name).WithAnnotation(item);
									expression = ((expression != null) ? ((Expression)new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseOr, memberReferenceExpression)) : ((Expression)memberReferenceExpression));
									num &= ~num3;
								}
								if ((num3 & num2) == num3)
								{
									MemberReferenceExpression memberReferenceExpression2 = ConvertType(type).Member(item.Name).WithAnnotation(item);
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
			}
			TypeCode typeCode2 = TypeAnalysis.GetTypeCode(type);
			if (typeCode2 == TypeCode.Object || typeCode2 == TypeCode.Empty)
			{
				typeCode2 = TypeCode.Int32;
			}
			return new PrimitiveExpression(CSharpPrimitiveCast.Cast(typeCode2, val, checkForOverflow: false));
		}

		private static bool IsFlagsEnum(TypeDefinition type)
		{
			if (!type.HasCustomAttributes)
			{
				return false;
			}
			return type.CustomAttributes.Any((CustomAttribute attr) => attr.AttributeType.FullName == "System.FlagsAttribute");
		}

		private static void SetNewModifier(EntityDeclaration member)
		{
			try
			{
				bool flag = false;
				if ((!(member is IndexerDeclaration)) ? HidesBaseMember(member) : TypesHierarchyHelpers.FindBaseProperties(member.Annotation<PropertyDefinition>()).Any())
				{
					member.Modifiers |= Modifiers.New;
				}
			}
			catch (ReferenceResolvingException)
			{
			}
		}

		private static bool HidesBaseMember(EntityDeclaration member)
		{
			IMemberDefinition memberDefinition = member.Annotation<IMemberDefinition>();
			bool flag = false;
			MethodDefinition methodDefinition = memberDefinition as MethodDefinition;
			if (methodDefinition != null)
			{
				flag = HidesByName(memberDefinition, includeBaseMethods: false);
				if (!flag)
				{
					flag = TypesHierarchyHelpers.FindBaseMethods(methodDefinition).Any();
				}
			}
			else
			{
				flag = HidesByName(memberDefinition, includeBaseMethods: true);
			}
			return flag;
		}

		private static bool HidesByName(IMemberDefinition member, bool includeBaseMethods)
		{
			if (member.DeclaringType.BaseType != null)
			{
				TypeDefinition typeDefinition;
				for (TypeReference baseType = member.DeclaringType.BaseType; baseType != null; baseType = typeDefinition.BaseType)
				{
					typeDefinition = baseType.ResolveOrThrow();
					if (typeDefinition.HasProperties && AnyIsHiddenBy(typeDefinition.Properties, member, (PropertyDefinition m) => !m.IsIndexer()))
					{
						return true;
					}
					if (typeDefinition.HasEvents && AnyIsHiddenBy(typeDefinition.Events, member))
					{
						return true;
					}
					if (typeDefinition.HasFields && AnyIsHiddenBy(typeDefinition.Fields, member))
					{
						return true;
					}
					if (includeBaseMethods && typeDefinition.HasMethods && AnyIsHiddenBy(typeDefinition.Methods, member, (MethodDefinition m) => !m.IsSpecialName))
					{
						return true;
					}
					if (typeDefinition.HasNestedTypes && AnyIsHiddenBy(typeDefinition.NestedTypes, member))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool AnyIsHiddenBy<T>(IEnumerable<T> members, IMemberDefinition derived, Predicate<T> condition = null) where T : IMemberDefinition
		{
			return members.Any((T m) => m.Name == derived.Name && (condition == null || condition(m)) && TypesHierarchyHelpers.IsVisibleFromDerived(m, derived.DeclaringType));
		}
	}
}
