using ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	public class TypeSystemConvertVisitor : DepthFirstAstVisitor<IUnresolvedEntity>
	{
		private sealed class ConstantValueBuilder : DepthFirstAstVisitor<ConstantExpression>
		{
			private readonly InterningProvider interningProvider;

			private readonly bool isAttributeArgument;

			public ConstantValueBuilder(bool isAttributeArgument, InterningProvider interningProvider)
			{
				this.interningProvider = interningProvider;
				this.isAttributeArgument = isAttributeArgument;
			}

			protected override ConstantExpression VisitChildren(AstNode node)
			{
				return null;
			}

			public override ConstantExpression VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
			{
				return interningProvider.Intern(new PrimitiveConstantExpression(KnownTypeReference.Object, null));
			}

			public override ConstantExpression VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
			{
				return new SizeOfConstantValue(sizeOfExpression.Type.ToTypeReference(NameLookupMode.Type, interningProvider));
			}

			public override ConstantExpression VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
			{
				object obj = interningProvider.InternValue(primitiveExpression.Value);
				TypeCode typeCode = (obj == null) ? TypeCode.Object : Type.GetTypeCode(obj.GetType());
				return interningProvider.Intern(new PrimitiveConstantExpression(typeCode.ToTypeReference(), obj));
			}

			private ITypeReference ConvertTypeReference(AstType type)
			{
				return type.ToTypeReference(NameLookupMode.Type, interningProvider);
			}

			private IList<ITypeReference> ConvertTypeArguments(AstNodeCollection<AstType> types)
			{
				int count = types.Count;
				if (count == 0)
				{
					return null;
				}
				ITypeReference[] array = new ITypeReference[count];
				int num = 0;
				foreach (AstType type in types)
				{
					array[num++] = ConvertTypeReference(type);
				}
				return interningProvider.InternList(array);
			}

			public override ConstantExpression VisitIdentifierExpression(IdentifierExpression identifierExpression)
			{
				return new ConstantIdentifierReference(interningProvider.Intern(identifierExpression.Identifier), ConvertTypeArguments(identifierExpression.TypeArguments));
			}

			public override ConstantExpression VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
			{
				string memberName = interningProvider.Intern(memberReferenceExpression.MemberName);
				TypeReferenceExpression typeReferenceExpression = memberReferenceExpression.Target as TypeReferenceExpression;
				if (typeReferenceExpression != null)
				{
					return new ConstantMemberReference(ConvertTypeReference(typeReferenceExpression.Type), memberName, ConvertTypeArguments(memberReferenceExpression.TypeArguments));
				}
				ConstantExpression constantExpression = memberReferenceExpression.Target.AcceptVisitor(this);
				if (constantExpression == null)
				{
					return null;
				}
				return new ConstantMemberReference(constantExpression, memberName, ConvertTypeArguments(memberReferenceExpression.TypeArguments));
			}

			public override ConstantExpression VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
			{
				return parenthesizedExpression.Expression.AcceptVisitor(this);
			}

			public override ConstantExpression VisitCastExpression(CastExpression castExpression)
			{
				ConstantExpression constantExpression = castExpression.Expression.AcceptVisitor(this);
				if (constantExpression == null)
				{
					return null;
				}
				ITypeReference targetType = ConvertTypeReference(castExpression.Type);
				return interningProvider.Intern(new ConstantCast(targetType, constantExpression, allowNullableConstants: false));
			}

			public override ConstantExpression VisitCheckedExpression(CheckedExpression checkedExpression)
			{
				ConstantExpression constantExpression = checkedExpression.Expression.AcceptVisitor(this);
				if (constantExpression != null)
				{
					return new ConstantCheckedExpression(checkForOverflow: true, constantExpression);
				}
				return null;
			}

			public override ConstantExpression VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
			{
				ConstantExpression constantExpression = uncheckedExpression.Expression.AcceptVisitor(this);
				if (constantExpression != null)
				{
					return new ConstantCheckedExpression(checkForOverflow: false, constantExpression);
				}
				return null;
			}

			public override ConstantExpression VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
			{
				return interningProvider.Intern(new ConstantDefaultValue(ConvertTypeReference(defaultValueExpression.Type)));
			}

			public override ConstantExpression VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
			{
				ConstantExpression constantExpression = unaryOperatorExpression.Expression.AcceptVisitor(this);
				if (constantExpression == null)
				{
					return null;
				}
				switch (unaryOperatorExpression.Operator)
				{
				case UnaryOperatorType.Not:
				case UnaryOperatorType.BitNot:
				case UnaryOperatorType.Minus:
				case UnaryOperatorType.Plus:
					return new ConstantUnaryOperator(unaryOperatorExpression.Operator, constantExpression);
				default:
					return null;
				}
			}

			public override ConstantExpression VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
			{
				ConstantExpression constantExpression = binaryOperatorExpression.Left.AcceptVisitor(this);
				ConstantExpression constantExpression2 = binaryOperatorExpression.Right.AcceptVisitor(this);
				if (constantExpression == null || constantExpression2 == null)
				{
					return null;
				}
				return new ConstantBinaryOperator(constantExpression, binaryOperatorExpression.Operator, constantExpression2);
			}

			public override ConstantExpression VisitTypeOfExpression(TypeOfExpression typeOfExpression)
			{
				if (isAttributeArgument)
				{
					return new TypeOfConstantExpression(ConvertTypeReference(typeOfExpression.Type));
				}
				return null;
			}

			public override ConstantExpression VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
			{
				if (!objectCreateExpression.Arguments.Any())
				{
					switch (objectCreateExpression.Type.ToString())
					{
					case "System.Boolean":
					case "bool":
						return new PrimitiveConstantExpression(KnownTypeReference.Boolean, false);
					case "System.Char":
					case "char":
						return new PrimitiveConstantExpression(KnownTypeReference.Char, '\0');
					case "System.SByte":
					case "sbyte":
						return new PrimitiveConstantExpression(KnownTypeReference.SByte, (sbyte)0);
					case "System.Byte":
					case "byte":
						return new PrimitiveConstantExpression(KnownTypeReference.Byte, (byte)0);
					case "System.Int16":
					case "short":
						return new PrimitiveConstantExpression(KnownTypeReference.Int16, (short)0);
					case "System.UInt16":
					case "ushort":
						return new PrimitiveConstantExpression(KnownTypeReference.UInt16, (ushort)0);
					case "System.Int32":
					case "int":
						return new PrimitiveConstantExpression(KnownTypeReference.Int32, 0);
					case "System.UInt32":
					case "uint":
						return new PrimitiveConstantExpression(KnownTypeReference.UInt32, 0u);
					case "System.Int64":
					case "long":
						return new PrimitiveConstantExpression(KnownTypeReference.Int64, 0L);
					case "System.UInt64":
					case "ulong":
						return new PrimitiveConstantExpression(KnownTypeReference.UInt64, 0uL);
					case "System.Single":
					case "float":
						return new PrimitiveConstantExpression(KnownTypeReference.Single, 0f);
					case "System.Double":
					case "double":
						return new PrimitiveConstantExpression(KnownTypeReference.Double, 0.0);
					case "System.Decimal":
					case "decimal":
						return new PrimitiveConstantExpression(KnownTypeReference.Decimal, decimal.Zero);
					}
				}
				return null;
			}

			public override ConstantExpression VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
			{
				ArrayInitializerExpression initializer = arrayCreateExpression.Initializer;
				if (isAttributeArgument && !initializer.IsNull && arrayCreateExpression.Arguments.Count < 2)
				{
					ITypeReference typeReference;
					if (arrayCreateExpression.Type.IsNull)
					{
						typeReference = null;
					}
					else
					{
						typeReference = ConvertTypeReference(arrayCreateExpression.Type);
						foreach (ArraySpecifier item in arrayCreateExpression.AdditionalArraySpecifiers.Reverse())
						{
							typeReference = interningProvider.Intern(new ArrayTypeReference(typeReference, item.Dimensions));
						}
					}
					ConstantExpression[] array = new ConstantExpression[initializer.Elements.Count];
					int num = 0;
					foreach (Expression element in initializer.Elements)
					{
						ConstantExpression constantExpression = element.AcceptVisitor(this);
						if (constantExpression == null)
						{
							return null;
						}
						array[num++] = constantExpression;
					}
					return new ConstantArrayCreation(typeReference, array);
				}
				return null;
			}
		}

		internal const int version = 2;

		private readonly CSharpUnresolvedFile unresolvedFile;

		private UsingScope usingScope;

		private CSharpUnresolvedTypeDefinition currentTypeDefinition;

		private DefaultUnresolvedMethod currentMethod;

		private InterningProvider interningProvider = new SimpleInterningProvider();

		private static readonly IUnresolvedParameter delegateObjectParameter = MakeParameter(KnownTypeReference.Object, "object");

		private static readonly IUnresolvedParameter delegateIntPtrMethodParameter = MakeParameter(KnownTypeReference.IntPtr, "method");

		private static readonly IUnresolvedParameter delegateAsyncCallbackParameter = MakeParameter(ReflectionHelper.ToTypeReference(typeof(AsyncCallback)), "callback");

		private static readonly IUnresolvedParameter delegateResultParameter = MakeParameter(ReflectionHelper.ToTypeReference(typeof(IAsyncResult)), "result");

		public InterningProvider InterningProvider
		{
			get
			{
				return interningProvider;
			}
			set
			{
				if (interningProvider == null)
				{
					throw new ArgumentNullException();
				}
				interningProvider = value;
			}
		}

		public bool SkipXmlDocumentation
		{
			get;
			set;
		}

		public CSharpUnresolvedFile UnresolvedFile => unresolvedFile;

		public TypeSystemConvertVisitor(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			unresolvedFile = new CSharpUnresolvedFile();
			unresolvedFile.FileName = fileName;
			usingScope = unresolvedFile.RootUsingScope;
		}

		public TypeSystemConvertVisitor(CSharpUnresolvedFile unresolvedFile, UsingScope currentUsingScope = null, CSharpUnresolvedTypeDefinition currentTypeDefinition = null)
		{
			if (unresolvedFile == null)
			{
				throw new ArgumentNullException("unresolvedFile");
			}
			this.unresolvedFile = unresolvedFile;
			usingScope = (currentUsingScope ?? unresolvedFile.RootUsingScope);
			this.currentTypeDefinition = currentTypeDefinition;
		}

		private DomRegion MakeRegion(TextLocation start, TextLocation end)
		{
			return new DomRegion(unresolvedFile.FileName, start.Line, start.Column, end.Line, end.Column);
		}

		private DomRegion MakeRegion(AstNode node)
		{
			if (node == null || node.IsNull)
			{
				return DomRegion.Empty;
			}
			return MakeRegion(GetStartLocationAfterAttributes(node), node.EndLocation);
		}

		internal static TextLocation GetStartLocationAfterAttributes(AstNode node)
		{
			AstNode astNode = node.FirstChild;
			while (astNode != null && (astNode is AttributeSection || astNode.NodeType == NodeType.Whitespace))
			{
				astNode = astNode.NextSibling;
			}
			return (astNode ?? node).StartLocation;
		}

		private DomRegion MakeBraceRegion(AstNode node)
		{
			if (node == null || node.IsNull)
			{
				return DomRegion.Empty;
			}
			return MakeRegion(node.GetChildByRole(Roles.LBrace).StartLocation, node.GetChildByRole(Roles.RBrace).EndLocation);
		}

		public override IUnresolvedEntity VisitSyntaxTree(SyntaxTree unit)
		{
			unresolvedFile.Errors = unit.Errors;
			return base.VisitSyntaxTree(unit);
		}

		public override IUnresolvedEntity VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
		{
			usingScope.ExternAliases.Add(externAliasDeclaration.Name);
			return null;
		}

		public override IUnresolvedEntity VisitUsingDeclaration(UsingDeclaration usingDeclaration)
		{
			TypeOrNamespaceReference typeOrNamespaceReference = ConvertTypeReference(usingDeclaration.Import, NameLookupMode.TypeInUsingDeclaration) as TypeOrNamespaceReference;
			if (typeOrNamespaceReference != null)
			{
				usingScope.Usings.Add(typeOrNamespaceReference);
			}
			return null;
		}

		public override IUnresolvedEntity VisitUsingAliasDeclaration(UsingAliasDeclaration usingDeclaration)
		{
			TypeOrNamespaceReference typeOrNamespaceReference = ConvertTypeReference(usingDeclaration.Import, NameLookupMode.TypeInUsingDeclaration) as TypeOrNamespaceReference;
			if (typeOrNamespaceReference != null)
			{
				usingScope.UsingAliases.Add(new KeyValuePair<string, TypeOrNamespaceReference>(usingDeclaration.Alias, typeOrNamespaceReference));
			}
			return null;
		}

		public override IUnresolvedEntity VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			DomRegion region = MakeRegion(namespaceDeclaration);
			UsingScope usingScope = this.usingScope;
			foreach (string identifier in namespaceDeclaration.Identifiers)
			{
				this.usingScope = new UsingScope(this.usingScope, identifier);
				this.usingScope.Region = region;
			}
			base.VisitNamespaceDeclaration(namespaceDeclaration);
			unresolvedFile.UsingScopes.Add(this.usingScope);
			this.usingScope = usingScope;
			return null;
		}

		private CSharpUnresolvedTypeDefinition CreateTypeDefinition(string name)
		{
			CSharpUnresolvedTypeDefinition cSharpUnresolvedTypeDefinition;
			if (currentTypeDefinition != null)
			{
				cSharpUnresolvedTypeDefinition = new CSharpUnresolvedTypeDefinition(currentTypeDefinition, name);
				foreach (IUnresolvedTypeParameter typeParameter in currentTypeDefinition.TypeParameters)
				{
					cSharpUnresolvedTypeDefinition.TypeParameters.Add(typeParameter);
				}
				currentTypeDefinition.NestedTypes.Add(cSharpUnresolvedTypeDefinition);
			}
			else
			{
				cSharpUnresolvedTypeDefinition = new CSharpUnresolvedTypeDefinition(usingScope, name);
				unresolvedFile.TopLevelTypeDefinitions.Add(cSharpUnresolvedTypeDefinition);
			}
			cSharpUnresolvedTypeDefinition.UnresolvedFile = unresolvedFile;
			cSharpUnresolvedTypeDefinition.HasExtensionMethods = false;
			return cSharpUnresolvedTypeDefinition;
		}

		public override IUnresolvedEntity VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			CSharpUnresolvedTypeDefinition cSharpUnresolvedTypeDefinition = currentTypeDefinition = CreateTypeDefinition(typeDeclaration.Name);
			cSharpUnresolvedTypeDefinition.Region = MakeRegion(typeDeclaration);
			cSharpUnresolvedTypeDefinition.BodyRegion = MakeBraceRegion(typeDeclaration);
			AddXmlDocumentation(cSharpUnresolvedTypeDefinition, typeDeclaration);
			ApplyModifiers(cSharpUnresolvedTypeDefinition, typeDeclaration.Modifiers);
			switch (typeDeclaration.ClassType)
			{
			case ClassType.Enum:
				cSharpUnresolvedTypeDefinition.Kind = TypeKind.Enum;
				break;
			case ClassType.Interface:
				cSharpUnresolvedTypeDefinition.Kind = TypeKind.Interface;
				cSharpUnresolvedTypeDefinition.IsAbstract = true;
				break;
			case ClassType.Struct:
				cSharpUnresolvedTypeDefinition.Kind = TypeKind.Struct;
				cSharpUnresolvedTypeDefinition.IsSealed = true;
				break;
			}
			ConvertAttributes(cSharpUnresolvedTypeDefinition.Attributes, typeDeclaration.Attributes);
			ConvertTypeParameters(cSharpUnresolvedTypeDefinition.TypeParameters, typeDeclaration.TypeParameters, typeDeclaration.Constraints, SymbolKind.TypeDefinition);
			foreach (AstType baseType in typeDeclaration.BaseTypes)
			{
				cSharpUnresolvedTypeDefinition.BaseTypes.Add(ConvertTypeReference(baseType, NameLookupMode.BaseTypeReference));
			}
			foreach (EntityDeclaration member in typeDeclaration.Members)
			{
				member.AcceptVisitor(this);
			}
			currentTypeDefinition = (CSharpUnresolvedTypeDefinition)currentTypeDefinition.DeclaringTypeDefinition;
			cSharpUnresolvedTypeDefinition.ApplyInterningProvider(interningProvider);
			return cSharpUnresolvedTypeDefinition;
		}

		public override IUnresolvedEntity VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
		{
			CSharpUnresolvedTypeDefinition cSharpUnresolvedTypeDefinition = currentTypeDefinition = CreateTypeDefinition(delegateDeclaration.Name);
			cSharpUnresolvedTypeDefinition.Kind = TypeKind.Delegate;
			cSharpUnresolvedTypeDefinition.Region = MakeRegion(delegateDeclaration);
			cSharpUnresolvedTypeDefinition.BaseTypes.Add(KnownTypeReference.MulticastDelegate);
			AddXmlDocumentation(cSharpUnresolvedTypeDefinition, delegateDeclaration);
			ApplyModifiers(cSharpUnresolvedTypeDefinition, delegateDeclaration.Modifiers);
			cSharpUnresolvedTypeDefinition.IsSealed = true;
			ConvertTypeParameters(cSharpUnresolvedTypeDefinition.TypeParameters, delegateDeclaration.TypeParameters, delegateDeclaration.Constraints, SymbolKind.TypeDefinition);
			ITypeReference returnType = ConvertTypeReference(delegateDeclaration.ReturnType);
			List<IUnresolvedParameter> list = new List<IUnresolvedParameter>();
			ConvertParameters(list, delegateDeclaration.Parameters);
			AddDefaultMethodsToDelegate(cSharpUnresolvedTypeDefinition, returnType, list);
			foreach (AttributeSection attribute in delegateDeclaration.Attributes)
			{
				if (attribute.AttributeTarget == "return")
				{
					List<IUnresolvedAttribute> list2 = new List<IUnresolvedAttribute>();
					ConvertAttributes(list2, attribute);
					IUnresolvedMethod unresolvedMethod = (IUnresolvedMethod)cSharpUnresolvedTypeDefinition.Members.Single((IUnresolvedMember m) => m.Name == "Invoke");
					IUnresolvedMethod unresolvedMethod2 = (IUnresolvedMethod)cSharpUnresolvedTypeDefinition.Members.Single((IUnresolvedMember m) => m.Name == "EndInvoke");
					foreach (IUnresolvedAttribute item in list2)
					{
						unresolvedMethod.ReturnTypeAttributes.Add(item);
						unresolvedMethod2.ReturnTypeAttributes.Add(item);
					}
				}
				else
				{
					ConvertAttributes(cSharpUnresolvedTypeDefinition.Attributes, attribute);
				}
			}
			currentTypeDefinition = (CSharpUnresolvedTypeDefinition)currentTypeDefinition.DeclaringTypeDefinition;
			cSharpUnresolvedTypeDefinition.ApplyInterningProvider(interningProvider);
			return cSharpUnresolvedTypeDefinition;
		}

		private static IUnresolvedParameter MakeParameter(ITypeReference type, string name)
		{
			DefaultUnresolvedParameter defaultUnresolvedParameter = new DefaultUnresolvedParameter(type, name);
			defaultUnresolvedParameter.Freeze();
			return defaultUnresolvedParameter;
		}

		public static void AddDefaultMethodsToDelegate(DefaultUnresolvedTypeDefinition delegateType, ITypeReference returnType, IEnumerable<IUnresolvedParameter> parameters)
		{
			if (delegateType == null)
			{
				throw new ArgumentNullException("delegateType");
			}
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			DomRegion region = delegateType.Region;
			region = new DomRegion(region.FileName, region.BeginLine, region.BeginColumn);
			DefaultUnresolvedMethod defaultUnresolvedMethod = new DefaultUnresolvedMethod(delegateType, "Invoke");
			defaultUnresolvedMethod.Accessibility = Accessibility.Public;
			defaultUnresolvedMethod.IsSynthetic = true;
			foreach (IUnresolvedParameter parameter in parameters)
			{
				defaultUnresolvedMethod.Parameters.Add(parameter);
			}
			defaultUnresolvedMethod.ReturnType = returnType;
			defaultUnresolvedMethod.Region = region;
			delegateType.Members.Add(defaultUnresolvedMethod);
			DefaultUnresolvedMethod defaultUnresolvedMethod2 = new DefaultUnresolvedMethod(delegateType, "BeginInvoke");
			defaultUnresolvedMethod2.Accessibility = Accessibility.Public;
			defaultUnresolvedMethod2.IsSynthetic = true;
			foreach (IUnresolvedParameter parameter2 in parameters)
			{
				defaultUnresolvedMethod2.Parameters.Add(parameter2);
			}
			defaultUnresolvedMethod2.Parameters.Add(delegateAsyncCallbackParameter);
			defaultUnresolvedMethod2.Parameters.Add(delegateObjectParameter);
			defaultUnresolvedMethod2.ReturnType = delegateResultParameter.Type;
			defaultUnresolvedMethod2.Region = region;
			delegateType.Members.Add(defaultUnresolvedMethod2);
			DefaultUnresolvedMethod defaultUnresolvedMethod3 = new DefaultUnresolvedMethod(delegateType, "EndInvoke");
			defaultUnresolvedMethod3.Accessibility = Accessibility.Public;
			defaultUnresolvedMethod3.IsSynthetic = true;
			defaultUnresolvedMethod3.Parameters.Add(delegateResultParameter);
			defaultUnresolvedMethod3.ReturnType = defaultUnresolvedMethod.ReturnType;
			defaultUnresolvedMethod3.Region = region;
			delegateType.Members.Add(defaultUnresolvedMethod3);
			DefaultUnresolvedMethod defaultUnresolvedMethod4 = new DefaultUnresolvedMethod(delegateType, ".ctor");
			defaultUnresolvedMethod4.SymbolKind = SymbolKind.Constructor;
			defaultUnresolvedMethod4.Accessibility = Accessibility.Public;
			defaultUnresolvedMethod4.IsSynthetic = true;
			defaultUnresolvedMethod4.Parameters.Add(delegateObjectParameter);
			defaultUnresolvedMethod4.Parameters.Add(delegateIntPtrMethodParameter);
			defaultUnresolvedMethod4.ReturnType = delegateType;
			defaultUnresolvedMethod4.Region = region;
			delegateType.Members.Add(defaultUnresolvedMethod4);
		}

		public override IUnresolvedEntity VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
		{
			bool flag = fieldDeclaration.Variables.Count == 1;
			Modifiers modifiers = fieldDeclaration.Modifiers;
			DefaultUnresolvedField defaultUnresolvedField = null;
			foreach (VariableInitializer variable in fieldDeclaration.Variables)
			{
				defaultUnresolvedField = new DefaultUnresolvedField(currentTypeDefinition, variable.Name);
				defaultUnresolvedField.Region = (flag ? MakeRegion(fieldDeclaration) : MakeRegion(variable));
				defaultUnresolvedField.BodyRegion = MakeRegion(variable);
				ConvertAttributes(defaultUnresolvedField.Attributes, fieldDeclaration.Attributes);
				AddXmlDocumentation(defaultUnresolvedField, fieldDeclaration);
				ApplyModifiers(defaultUnresolvedField, modifiers);
				defaultUnresolvedField.IsVolatile = ((modifiers & Modifiers.Volatile) != Modifiers.None);
				defaultUnresolvedField.IsReadOnly = ((modifiers & Modifiers.Readonly) != Modifiers.None);
				defaultUnresolvedField.ReturnType = ConvertTypeReference(fieldDeclaration.ReturnType);
				if ((modifiers & Modifiers.Const) != 0)
				{
					defaultUnresolvedField.ConstantValue = ConvertConstantValue(defaultUnresolvedField.ReturnType, variable.Initializer);
					defaultUnresolvedField.IsStatic = true;
				}
				currentTypeDefinition.Members.Add(defaultUnresolvedField);
				defaultUnresolvedField.ApplyInterningProvider(interningProvider);
			}
			if (!flag)
			{
				return null;
			}
			return defaultUnresolvedField;
		}

		public override IUnresolvedEntity VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
		{
			bool flag = fixedFieldDeclaration.Variables.Count == 1;
			Modifiers modifiers = fixedFieldDeclaration.Modifiers;
			DefaultUnresolvedField defaultUnresolvedField = null;
			foreach (FixedVariableInitializer variable in fixedFieldDeclaration.Variables)
			{
				defaultUnresolvedField = new DefaultUnresolvedField(currentTypeDefinition, variable.Name);
				defaultUnresolvedField.Region = (flag ? MakeRegion(fixedFieldDeclaration) : MakeRegion(variable));
				defaultUnresolvedField.BodyRegion = MakeRegion(variable);
				ConvertAttributes(defaultUnresolvedField.Attributes, fixedFieldDeclaration.Attributes);
				AddXmlDocumentation(defaultUnresolvedField, fixedFieldDeclaration);
				ApplyModifiers(defaultUnresolvedField, modifiers);
				defaultUnresolvedField.ReturnType = ConvertTypeReference(fixedFieldDeclaration.ReturnType);
				defaultUnresolvedField.IsFixed = true;
				defaultUnresolvedField.ConstantValue = ConvertConstantValue(defaultUnresolvedField.ReturnType, variable.CountExpression);
				currentTypeDefinition.Members.Add(defaultUnresolvedField);
				defaultUnresolvedField.ApplyInterningProvider(interningProvider);
			}
			if (!flag)
			{
				return null;
			}
			return defaultUnresolvedField;
		}

		public override IUnresolvedEntity VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
		{
			DefaultUnresolvedField defaultUnresolvedField = new DefaultUnresolvedField(currentTypeDefinition, enumMemberDeclaration.Name);
			DomRegion domRegion3 = defaultUnresolvedField.Region = (defaultUnresolvedField.BodyRegion = MakeRegion(enumMemberDeclaration));
			ConvertAttributes(defaultUnresolvedField.Attributes, enumMemberDeclaration.Attributes);
			AddXmlDocumentation(defaultUnresolvedField, enumMemberDeclaration);
			if (currentTypeDefinition.TypeParameters.Count == 0)
			{
				defaultUnresolvedField.ReturnType = currentTypeDefinition;
			}
			else
			{
				ITypeReference[] array = new ITypeReference[currentTypeDefinition.TypeParameters.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = TypeParameterReference.Create(SymbolKind.TypeDefinition, i);
				}
				defaultUnresolvedField.ReturnType = interningProvider.Intern(new ParameterizedTypeReference(currentTypeDefinition, array));
			}
			defaultUnresolvedField.Accessibility = Accessibility.Public;
			defaultUnresolvedField.IsStatic = true;
			if (!enumMemberDeclaration.Initializer.IsNull)
			{
				defaultUnresolvedField.ConstantValue = ConvertConstantValue(defaultUnresolvedField.ReturnType, enumMemberDeclaration.Initializer);
			}
			else
			{
				DefaultUnresolvedField defaultUnresolvedField2 = currentTypeDefinition.Members.LastOrDefault() as DefaultUnresolvedField;
				if (defaultUnresolvedField2 == null || defaultUnresolvedField2.ConstantValue == null)
				{
					defaultUnresolvedField.ConstantValue = ConvertConstantValue(defaultUnresolvedField.ReturnType, new PrimitiveExpression(0));
				}
				else
				{
					defaultUnresolvedField.ConstantValue = interningProvider.Intern(new IncrementConstantValue(defaultUnresolvedField2.ConstantValue));
				}
			}
			currentTypeDefinition.Members.Add(defaultUnresolvedField);
			defaultUnresolvedField.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedField;
		}

		public override IUnresolvedEntity VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			DefaultUnresolvedMethod defaultUnresolvedMethod = currentMethod = new DefaultUnresolvedMethod(currentTypeDefinition, methodDeclaration.Name);
			defaultUnresolvedMethod.Region = MakeRegion(methodDeclaration);
			defaultUnresolvedMethod.BodyRegion = MakeRegion(methodDeclaration.Body);
			AddXmlDocumentation(defaultUnresolvedMethod, methodDeclaration);
			if (InheritsConstraints(methodDeclaration) && methodDeclaration.Constraints.Count == 0)
			{
				int num = 0;
				foreach (TypeParameterDeclaration typeParameter in methodDeclaration.TypeParameters)
				{
					MethodTypeParameterWithInheritedConstraints methodTypeParameterWithInheritedConstraints = new MethodTypeParameterWithInheritedConstraints(num++, typeParameter.Name);
					methodTypeParameterWithInheritedConstraints.Region = MakeRegion(typeParameter);
					ConvertAttributes(methodTypeParameterWithInheritedConstraints.Attributes, typeParameter.Attributes);
					methodTypeParameterWithInheritedConstraints.Variance = typeParameter.Variance;
					methodTypeParameterWithInheritedConstraints.ApplyInterningProvider(interningProvider);
					defaultUnresolvedMethod.TypeParameters.Add(methodTypeParameterWithInheritedConstraints);
				}
			}
			else
			{
				ConvertTypeParameters(defaultUnresolvedMethod.TypeParameters, methodDeclaration.TypeParameters, methodDeclaration.Constraints, SymbolKind.Method);
			}
			defaultUnresolvedMethod.ReturnType = ConvertTypeReference(methodDeclaration.ReturnType);
			ConvertAttributes(defaultUnresolvedMethod.Attributes, from s in methodDeclaration.Attributes
				where s.AttributeTarget != "return"
				select s);
			ConvertAttributes(defaultUnresolvedMethod.ReturnTypeAttributes, from s in methodDeclaration.Attributes
				where s.AttributeTarget == "return"
				select s);
			ApplyModifiers(defaultUnresolvedMethod, methodDeclaration.Modifiers);
			if (methodDeclaration.IsExtensionMethod)
			{
				defaultUnresolvedMethod.IsExtensionMethod = true;
				currentTypeDefinition.HasExtensionMethods = true;
			}
			defaultUnresolvedMethod.IsPartial = methodDeclaration.HasModifier(Modifiers.Partial);
			defaultUnresolvedMethod.IsAsync = methodDeclaration.HasModifier(Modifiers.Async);
			defaultUnresolvedMethod.HasBody = !methodDeclaration.Body.IsNull;
			ConvertParameters(defaultUnresolvedMethod.Parameters, methodDeclaration.Parameters);
			if (!methodDeclaration.PrivateImplementationType.IsNull)
			{
				defaultUnresolvedMethod.Accessibility = Accessibility.None;
				defaultUnresolvedMethod.IsExplicitInterfaceImplementation = true;
				defaultUnresolvedMethod.ExplicitInterfaceImplementations.Add(interningProvider.Intern(new DefaultMemberReference(defaultUnresolvedMethod.SymbolKind, ConvertTypeReference(methodDeclaration.PrivateImplementationType), defaultUnresolvedMethod.Name, defaultUnresolvedMethod.TypeParameters.Count, GetParameterTypes(defaultUnresolvedMethod.Parameters))));
			}
			currentTypeDefinition.Members.Add(defaultUnresolvedMethod);
			currentMethod = null;
			defaultUnresolvedMethod.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedMethod;
		}

		private IList<ITypeReference> GetParameterTypes(IList<IUnresolvedParameter> parameters)
		{
			if (parameters.Count == 0)
			{
				return EmptyList<ITypeReference>.Instance;
			}
			ITypeReference[] array = new ITypeReference[parameters.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = parameters[i].Type;
			}
			return interningProvider.InternList(array);
		}

		private bool InheritsConstraints(MethodDeclaration methodDeclaration)
		{
			if ((methodDeclaration.Modifiers & Modifiers.Override) == Modifiers.Override)
			{
				return true;
			}
			return !methodDeclaration.PrivateImplementationType.IsNull;
		}

		private void ConvertTypeParameters(IList<IUnresolvedTypeParameter> output, AstNodeCollection<TypeParameterDeclaration> typeParameters, AstNodeCollection<Constraint> constraints, SymbolKind ownerType)
		{
			int num = output.Count;
			List<DefaultUnresolvedTypeParameter> list = new List<DefaultUnresolvedTypeParameter>();
			foreach (TypeParameterDeclaration typeParameter in typeParameters)
			{
				DefaultUnresolvedTypeParameter defaultUnresolvedTypeParameter = new DefaultUnresolvedTypeParameter(ownerType, num++, typeParameter.Name);
				defaultUnresolvedTypeParameter.Region = MakeRegion(typeParameter);
				ConvertAttributes(defaultUnresolvedTypeParameter.Attributes, typeParameter.Attributes);
				defaultUnresolvedTypeParameter.Variance = typeParameter.Variance;
				list.Add(defaultUnresolvedTypeParameter);
				output.Add(defaultUnresolvedTypeParameter);
			}
			foreach (Constraint constraint in constraints)
			{
				foreach (DefaultUnresolvedTypeParameter item in list)
				{
					if (item.Name == constraint.TypeParameter.Identifier)
					{
						foreach (AstType baseType in constraint.BaseTypes)
						{
							PrimitiveType primitiveType = baseType as PrimitiveType;
							if (primitiveType != null)
							{
								if (primitiveType.Keyword == "new")
								{
									item.HasDefaultConstructorConstraint = true;
									continue;
								}
								if (primitiveType.Keyword == "class")
								{
									item.HasReferenceTypeConstraint = true;
									continue;
								}
								if (primitiveType.Keyword == "struct")
								{
									item.HasValueTypeConstraint = true;
									continue;
								}
							}
							NameLookupMode lookupMode = (ownerType == SymbolKind.TypeDefinition) ? NameLookupMode.BaseTypeReference : NameLookupMode.Type;
							item.Constraints.Add(ConvertTypeReference(baseType, lookupMode));
						}
						break;
					}
				}
			}
			foreach (DefaultUnresolvedTypeParameter item2 in list)
			{
				item2.ApplyInterningProvider(interningProvider);
			}
		}

		public override IUnresolvedEntity VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
		{
			DefaultUnresolvedMethod defaultUnresolvedMethod = new DefaultUnresolvedMethod(currentTypeDefinition, operatorDeclaration.Name);
			defaultUnresolvedMethod.SymbolKind = SymbolKind.Operator;
			defaultUnresolvedMethod.Region = MakeRegion(operatorDeclaration);
			defaultUnresolvedMethod.BodyRegion = MakeRegion(operatorDeclaration.Body);
			AddXmlDocumentation(defaultUnresolvedMethod, operatorDeclaration);
			defaultUnresolvedMethod.ReturnType = ConvertTypeReference(operatorDeclaration.ReturnType);
			ConvertAttributes(defaultUnresolvedMethod.Attributes, from s in operatorDeclaration.Attributes
				where s.AttributeTarget != "return"
				select s);
			ConvertAttributes(defaultUnresolvedMethod.ReturnTypeAttributes, from s in operatorDeclaration.Attributes
				where s.AttributeTarget == "return"
				select s);
			ApplyModifiers(defaultUnresolvedMethod, operatorDeclaration.Modifiers);
			defaultUnresolvedMethod.HasBody = !operatorDeclaration.Body.IsNull;
			ConvertParameters(defaultUnresolvedMethod.Parameters, operatorDeclaration.Parameters);
			currentTypeDefinition.Members.Add(defaultUnresolvedMethod);
			defaultUnresolvedMethod.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedMethod;
		}

		public override IUnresolvedEntity VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
		{
			Modifiers modifiers = constructorDeclaration.Modifiers;
			bool flag = (modifiers & Modifiers.Static) != Modifiers.None;
			DefaultUnresolvedMethod defaultUnresolvedMethod = new DefaultUnresolvedMethod(currentTypeDefinition, flag ? ".cctor" : ".ctor");
			defaultUnresolvedMethod.SymbolKind = SymbolKind.Constructor;
			defaultUnresolvedMethod.Region = MakeRegion(constructorDeclaration);
			if (!constructorDeclaration.Initializer.IsNull)
			{
				defaultUnresolvedMethod.BodyRegion = MakeRegion(constructorDeclaration.Initializer.StartLocation, constructorDeclaration.EndLocation);
			}
			else
			{
				defaultUnresolvedMethod.BodyRegion = MakeRegion(constructorDeclaration.Body);
			}
			defaultUnresolvedMethod.ReturnType = KnownTypeReference.Void;
			ConvertAttributes(defaultUnresolvedMethod.Attributes, constructorDeclaration.Attributes);
			ConvertParameters(defaultUnresolvedMethod.Parameters, constructorDeclaration.Parameters);
			AddXmlDocumentation(defaultUnresolvedMethod, constructorDeclaration);
			defaultUnresolvedMethod.HasBody = !constructorDeclaration.Body.IsNull;
			if (flag)
			{
				defaultUnresolvedMethod.IsStatic = true;
			}
			else
			{
				ApplyModifiers(defaultUnresolvedMethod, modifiers);
			}
			currentTypeDefinition.Members.Add(defaultUnresolvedMethod);
			defaultUnresolvedMethod.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedMethod;
		}

		public override IUnresolvedEntity VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
		{
			DefaultUnresolvedMethod defaultUnresolvedMethod = new DefaultUnresolvedMethod(currentTypeDefinition, "Finalize");
			defaultUnresolvedMethod.SymbolKind = SymbolKind.Destructor;
			defaultUnresolvedMethod.Region = MakeRegion(destructorDeclaration);
			defaultUnresolvedMethod.BodyRegion = MakeRegion(destructorDeclaration.Body);
			defaultUnresolvedMethod.Accessibility = Accessibility.Protected;
			defaultUnresolvedMethod.IsOverride = true;
			defaultUnresolvedMethod.ReturnType = KnownTypeReference.Void;
			defaultUnresolvedMethod.HasBody = !destructorDeclaration.Body.IsNull;
			ConvertAttributes(defaultUnresolvedMethod.Attributes, destructorDeclaration.Attributes);
			AddXmlDocumentation(defaultUnresolvedMethod, destructorDeclaration);
			currentTypeDefinition.Members.Add(defaultUnresolvedMethod);
			defaultUnresolvedMethod.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedMethod;
		}

		public override IUnresolvedEntity VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
		{
			DefaultUnresolvedProperty defaultUnresolvedProperty = new DefaultUnresolvedProperty(currentTypeDefinition, propertyDeclaration.Name);
			defaultUnresolvedProperty.Region = MakeRegion(propertyDeclaration);
			defaultUnresolvedProperty.BodyRegion = MakeBraceRegion(propertyDeclaration);
			ApplyModifiers(defaultUnresolvedProperty, propertyDeclaration.Modifiers);
			defaultUnresolvedProperty.ReturnType = ConvertTypeReference(propertyDeclaration.ReturnType);
			ConvertAttributes(defaultUnresolvedProperty.Attributes, propertyDeclaration.Attributes);
			AddXmlDocumentation(defaultUnresolvedProperty, propertyDeclaration);
			if (!propertyDeclaration.PrivateImplementationType.IsNull)
			{
				defaultUnresolvedProperty.Accessibility = Accessibility.None;
				defaultUnresolvedProperty.IsExplicitInterfaceImplementation = true;
				defaultUnresolvedProperty.ExplicitInterfaceImplementations.Add(interningProvider.Intern(new DefaultMemberReference(defaultUnresolvedProperty.SymbolKind, ConvertTypeReference(propertyDeclaration.PrivateImplementationType), defaultUnresolvedProperty.Name)));
			}
			bool memberIsExtern = propertyDeclaration.HasModifier(Modifiers.Extern);
			defaultUnresolvedProperty.Getter = ConvertAccessor(propertyDeclaration.Getter, defaultUnresolvedProperty, "get_", memberIsExtern);
			defaultUnresolvedProperty.Setter = ConvertAccessor(propertyDeclaration.Setter, defaultUnresolvedProperty, "set_", memberIsExtern);
			currentTypeDefinition.Members.Add(defaultUnresolvedProperty);
			defaultUnresolvedProperty.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedProperty;
		}

		public override IUnresolvedEntity VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
		{
			DefaultUnresolvedProperty defaultUnresolvedProperty = new DefaultUnresolvedProperty(currentTypeDefinition, "Item");
			defaultUnresolvedProperty.SymbolKind = SymbolKind.Indexer;
			defaultUnresolvedProperty.Region = MakeRegion(indexerDeclaration);
			defaultUnresolvedProperty.BodyRegion = MakeBraceRegion(indexerDeclaration);
			ApplyModifiers(defaultUnresolvedProperty, indexerDeclaration.Modifiers);
			defaultUnresolvedProperty.ReturnType = ConvertTypeReference(indexerDeclaration.ReturnType);
			ConvertAttributes(defaultUnresolvedProperty.Attributes, indexerDeclaration.Attributes);
			AddXmlDocumentation(defaultUnresolvedProperty, indexerDeclaration);
			ConvertParameters(defaultUnresolvedProperty.Parameters, indexerDeclaration.Parameters);
			if (!indexerDeclaration.PrivateImplementationType.IsNull)
			{
				defaultUnresolvedProperty.Accessibility = Accessibility.None;
				defaultUnresolvedProperty.IsExplicitInterfaceImplementation = true;
				defaultUnresolvedProperty.ExplicitInterfaceImplementations.Add(interningProvider.Intern(new DefaultMemberReference(defaultUnresolvedProperty.SymbolKind, indexerDeclaration.PrivateImplementationType.ToTypeReference(), defaultUnresolvedProperty.Name, 0, GetParameterTypes(defaultUnresolvedProperty.Parameters))));
			}
			bool memberIsExtern = indexerDeclaration.HasModifier(Modifiers.Extern);
			defaultUnresolvedProperty.Getter = ConvertAccessor(indexerDeclaration.Getter, defaultUnresolvedProperty, "get_", memberIsExtern);
			defaultUnresolvedProperty.Setter = ConvertAccessor(indexerDeclaration.Setter, defaultUnresolvedProperty, "set_", memberIsExtern);
			currentTypeDefinition.Members.Add(defaultUnresolvedProperty);
			defaultUnresolvedProperty.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedProperty;
		}

		private DefaultUnresolvedMethod ConvertAccessor(Accessor accessor, IUnresolvedMember p, string prefix, bool memberIsExtern)
		{
			if (accessor.IsNull)
			{
				return null;
			}
			DefaultUnresolvedMethod defaultUnresolvedMethod = new DefaultUnresolvedMethod(currentTypeDefinition, prefix + p.Name);
			defaultUnresolvedMethod.SymbolKind = SymbolKind.Accessor;
			defaultUnresolvedMethod.AccessorOwner = p;
			defaultUnresolvedMethod.Accessibility = (GetAccessibility(accessor.Modifiers) ?? p.Accessibility);
			defaultUnresolvedMethod.IsAbstract = p.IsAbstract;
			defaultUnresolvedMethod.IsOverride = p.IsOverride;
			defaultUnresolvedMethod.IsSealed = p.IsSealed;
			defaultUnresolvedMethod.IsStatic = p.IsStatic;
			defaultUnresolvedMethod.IsSynthetic = p.IsSynthetic;
			defaultUnresolvedMethod.IsVirtual = p.IsVirtual;
			defaultUnresolvedMethod.Region = MakeRegion(accessor);
			defaultUnresolvedMethod.BodyRegion = MakeRegion(accessor.Body);
			defaultUnresolvedMethod.HasBody = (!accessor.Body.IsNull || !(p.IsAbstract | memberIsExtern));
			if (p.SymbolKind == SymbolKind.Indexer)
			{
				foreach (IUnresolvedParameter parameter in ((IUnresolvedProperty)p).Parameters)
				{
					defaultUnresolvedMethod.Parameters.Add(parameter);
				}
			}
			DefaultUnresolvedParameter defaultUnresolvedParameter = null;
			if (accessor.Role == PropertyDeclaration.GetterRole)
			{
				defaultUnresolvedMethod.ReturnType = p.ReturnType;
			}
			else
			{
				defaultUnresolvedParameter = new DefaultUnresolvedParameter(p.ReturnType, "value");
				defaultUnresolvedMethod.Parameters.Add(defaultUnresolvedParameter);
				defaultUnresolvedMethod.ReturnType = KnownTypeReference.Void;
			}
			foreach (AttributeSection attribute in accessor.Attributes)
			{
				if (attribute.AttributeTarget == "return")
				{
					ConvertAttributes(defaultUnresolvedMethod.ReturnTypeAttributes, attribute);
				}
				else if (defaultUnresolvedParameter != null && attribute.AttributeTarget == "param")
				{
					ConvertAttributes(defaultUnresolvedParameter.Attributes, attribute);
				}
				else
				{
					ConvertAttributes(defaultUnresolvedMethod.Attributes, attribute);
				}
			}
			if (p.IsExplicitInterfaceImplementation)
			{
				defaultUnresolvedMethod.IsExplicitInterfaceImplementation = true;
				defaultUnresolvedMethod.ExplicitInterfaceImplementations.Add(interningProvider.Intern(new DefaultMemberReference(SymbolKind.Accessor, p.ExplicitInterfaceImplementations[0].DeclaringTypeReference, defaultUnresolvedMethod.Name, 0, GetParameterTypes(defaultUnresolvedMethod.Parameters))));
			}
			defaultUnresolvedMethod.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedMethod;
		}

		public override IUnresolvedEntity VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			bool flag = eventDeclaration.Variables.Count == 1;
			Modifiers modifiers = eventDeclaration.Modifiers;
			DefaultUnresolvedEvent defaultUnresolvedEvent = null;
			foreach (VariableInitializer variable in eventDeclaration.Variables)
			{
				defaultUnresolvedEvent = new DefaultUnresolvedEvent(currentTypeDefinition, variable.Name);
				defaultUnresolvedEvent.Region = (flag ? MakeRegion(eventDeclaration) : MakeRegion(variable));
				defaultUnresolvedEvent.BodyRegion = MakeRegion(variable);
				ApplyModifiers(defaultUnresolvedEvent, modifiers);
				AddXmlDocumentation(defaultUnresolvedEvent, eventDeclaration);
				defaultUnresolvedEvent.ReturnType = ConvertTypeReference(eventDeclaration.ReturnType);
				DefaultUnresolvedParameter valueParameter = new DefaultUnresolvedParameter(defaultUnresolvedEvent.ReturnType, "value");
				defaultUnresolvedEvent.AddAccessor = CreateDefaultEventAccessor(defaultUnresolvedEvent, "add_" + defaultUnresolvedEvent.Name, valueParameter);
				defaultUnresolvedEvent.RemoveAccessor = CreateDefaultEventAccessor(defaultUnresolvedEvent, "remove_" + defaultUnresolvedEvent.Name, valueParameter);
				foreach (AttributeSection attribute in eventDeclaration.Attributes)
				{
					if (attribute.AttributeTarget == "method")
					{
						foreach (Attribute attribute2 in attribute.Attributes)
						{
							IUnresolvedAttribute item = ConvertAttribute(attribute2);
							defaultUnresolvedEvent.AddAccessor.Attributes.Add(item);
							defaultUnresolvedEvent.RemoveAccessor.Attributes.Add(item);
						}
					}
					else if (attribute.AttributeTarget != "field")
					{
						ConvertAttributes(defaultUnresolvedEvent.Attributes, attribute);
					}
				}
				currentTypeDefinition.Members.Add(defaultUnresolvedEvent);
				defaultUnresolvedEvent.ApplyInterningProvider(interningProvider);
			}
			if (!flag)
			{
				return null;
			}
			return defaultUnresolvedEvent;
		}

		private DefaultUnresolvedMethod CreateDefaultEventAccessor(IUnresolvedEvent ev, string name, IUnresolvedParameter valueParameter)
		{
			return new DefaultUnresolvedMethod(currentTypeDefinition, name)
			{
				SymbolKind = SymbolKind.Accessor,
				AccessorOwner = ev,
				Region = ev.BodyRegion,
				BodyRegion = DomRegion.Empty,
				Accessibility = ev.Accessibility,
				IsAbstract = ev.IsAbstract,
				IsOverride = ev.IsOverride,
				IsSealed = ev.IsSealed,
				IsStatic = ev.IsStatic,
				IsSynthetic = ev.IsSynthetic,
				IsVirtual = ev.IsVirtual,
				HasBody = true,
				ReturnType = KnownTypeReference.Void,
				Parameters = 
				{
					valueParameter
				}
			};
		}

		public override IUnresolvedEntity VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
		{
			DefaultUnresolvedEvent defaultUnresolvedEvent = new DefaultUnresolvedEvent(currentTypeDefinition, eventDeclaration.Name);
			defaultUnresolvedEvent.Region = MakeRegion(eventDeclaration);
			defaultUnresolvedEvent.BodyRegion = MakeBraceRegion(eventDeclaration);
			ApplyModifiers(defaultUnresolvedEvent, eventDeclaration.Modifiers);
			defaultUnresolvedEvent.ReturnType = ConvertTypeReference(eventDeclaration.ReturnType);
			ConvertAttributes(defaultUnresolvedEvent.Attributes, eventDeclaration.Attributes);
			AddXmlDocumentation(defaultUnresolvedEvent, eventDeclaration);
			if (!eventDeclaration.PrivateImplementationType.IsNull)
			{
				defaultUnresolvedEvent.Accessibility = Accessibility.None;
				defaultUnresolvedEvent.IsExplicitInterfaceImplementation = true;
				defaultUnresolvedEvent.ExplicitInterfaceImplementations.Add(interningProvider.Intern(new DefaultMemberReference(defaultUnresolvedEvent.SymbolKind, eventDeclaration.PrivateImplementationType.ToTypeReference(), defaultUnresolvedEvent.Name)));
			}
			defaultUnresolvedEvent.AddAccessor = ConvertAccessor(eventDeclaration.AddAccessor, defaultUnresolvedEvent, "add_", memberIsExtern: false);
			defaultUnresolvedEvent.RemoveAccessor = ConvertAccessor(eventDeclaration.RemoveAccessor, defaultUnresolvedEvent, "remove_", memberIsExtern: false);
			currentTypeDefinition.Members.Add(defaultUnresolvedEvent);
			defaultUnresolvedEvent.ApplyInterningProvider(interningProvider);
			return defaultUnresolvedEvent;
		}

		private static void ApplyModifiers(DefaultUnresolvedTypeDefinition td, Modifiers modifiers)
		{
			td.Accessibility = (Accessibility)(((int?)GetAccessibility(modifiers)) ?? ((td.DeclaringTypeDefinition != null) ? 1 : 4));
			td.IsAbstract = ((modifiers & (Modifiers.Abstract | Modifiers.Static)) != Modifiers.None);
			td.IsSealed = ((modifiers & (Modifiers.Sealed | Modifiers.Static)) != Modifiers.None);
			td.IsShadowing = ((modifiers & Modifiers.New) != Modifiers.None);
			td.IsPartial = ((modifiers & Modifiers.Partial) != Modifiers.None);
		}

		private static void ApplyModifiers(AbstractUnresolvedMember m, Modifiers modifiers)
		{
			if (m.DeclaringTypeDefinition.Kind == TypeKind.Interface)
			{
				m.Accessibility = Accessibility.Public;
				m.IsAbstract = true;
				m.IsShadowing = ((modifiers & Modifiers.New) != Modifiers.None);
				return;
			}
			m.Accessibility = (GetAccessibility(modifiers) ?? Accessibility.Private);
			m.IsAbstract = ((modifiers & Modifiers.Abstract) != Modifiers.None);
			m.IsOverride = ((modifiers & Modifiers.Override) != Modifiers.None);
			m.IsSealed = ((modifiers & Modifiers.Sealed) != Modifiers.None);
			m.IsShadowing = ((modifiers & Modifiers.New) != Modifiers.None);
			m.IsStatic = ((modifiers & Modifiers.Static) != Modifiers.None);
			m.IsVirtual = ((modifiers & Modifiers.Virtual) != Modifiers.None);
		}

		private static Accessibility? GetAccessibility(Modifiers modifiers)
		{
			switch (modifiers & Modifiers.VisibilityMask)
			{
			case Modifiers.Private:
				return Accessibility.Private;
			case Modifiers.Internal:
				return Accessibility.Internal;
			case Modifiers.Internal | Modifiers.Protected:
				return Accessibility.ProtectedOrInternal;
			case Modifiers.Protected:
				return Accessibility.Protected;
			case Modifiers.Public:
				return Accessibility.Public;
			default:
				return null;
			}
		}

		public override IUnresolvedEntity VisitAttributeSection(AttributeSection attributeSection)
		{
			if (attributeSection.AttributeTarget == "assembly")
			{
				ConvertAttributes(unresolvedFile.AssemblyAttributes, attributeSection);
			}
			else if (attributeSection.AttributeTarget == "module")
			{
				ConvertAttributes(unresolvedFile.ModuleAttributes, attributeSection);
			}
			return null;
		}

		private void ConvertAttributes(IList<IUnresolvedAttribute> outputList, IEnumerable<AttributeSection> attributes)
		{
			foreach (AttributeSection attribute in attributes)
			{
				ConvertAttributes(outputList, attribute);
			}
		}

		private void ConvertAttributes(IList<IUnresolvedAttribute> outputList, AttributeSection attributeSection)
		{
			foreach (Attribute attribute in attributeSection.Attributes)
			{
				outputList.Add(ConvertAttribute(attribute));
			}
		}

		internal static ITypeReference ConvertAttributeType(AstType type, InterningProvider interningProvider)
		{
			ITypeReference typeReference = type.ToTypeReference(NameLookupMode.Type, interningProvider);
			if (!type.GetChildByRole(Roles.Identifier).IsVerbatim)
			{
				SimpleTypeOrNamespaceReference simpleTypeOrNamespaceReference = typeReference as SimpleTypeOrNamespaceReference;
				MemberTypeOrNamespaceReference memberTypeOrNamespaceReference = typeReference as MemberTypeOrNamespaceReference;
				if (simpleTypeOrNamespaceReference != null)
				{
					return interningProvider.Intern(new AttributeTypeReference(simpleTypeOrNamespaceReference, interningProvider.Intern(simpleTypeOrNamespaceReference.AddSuffix("Attribute"))));
				}
				if (memberTypeOrNamespaceReference != null)
				{
					return interningProvider.Intern(new AttributeTypeReference(memberTypeOrNamespaceReference, interningProvider.Intern(memberTypeOrNamespaceReference.AddSuffix("Attribute"))));
				}
			}
			return typeReference;
		}

		private CSharpAttribute ConvertAttribute(Attribute attr)
		{
			DomRegion region = MakeRegion(attr);
			ITypeReference attributeType = ConvertAttributeType(attr.Type, interningProvider);
			List<IConstantValue> list = null;
			List<KeyValuePair<string, IConstantValue>> list2 = null;
			List<KeyValuePair<string, IConstantValue>> list3 = null;
			foreach (Expression argument in attr.Arguments)
			{
				NamedArgumentExpression namedArgumentExpression = argument as NamedArgumentExpression;
				if (namedArgumentExpression != null)
				{
					string key = interningProvider.Intern(namedArgumentExpression.Name);
					if (list2 == null)
					{
						list2 = new List<KeyValuePair<string, IConstantValue>>();
					}
					list2.Add(new KeyValuePair<string, IConstantValue>(key, ConvertAttributeArgument(namedArgumentExpression.Expression)));
				}
				else
				{
					NamedExpression namedExpression = argument as NamedExpression;
					if (namedExpression != null)
					{
						string key2 = interningProvider.Intern(namedExpression.Name);
						if (list3 == null)
						{
							list3 = new List<KeyValuePair<string, IConstantValue>>();
						}
						list3.Add(new KeyValuePair<string, IConstantValue>(key2, ConvertAttributeArgument(namedExpression.Expression)));
					}
					else
					{
						if (list == null)
						{
							list = new List<IConstantValue>();
						}
						list.Add(ConvertAttributeArgument(argument));
					}
				}
			}
			return new CSharpAttribute(attributeType, region, interningProvider.InternList(list), list2, list3);
		}

		private ITypeReference ConvertTypeReference(AstType type, NameLookupMode lookupMode = NameLookupMode.Type)
		{
			return type.ToTypeReference(lookupMode, interningProvider);
		}

		private IConstantValue ConvertConstantValue(ITypeReference targetType, AstNode expression)
		{
			return ConvertConstantValue(targetType, expression, currentTypeDefinition, currentMethod, usingScope, interningProvider);
		}

		internal static IConstantValue ConvertConstantValue(ITypeReference targetType, AstNode expression, IUnresolvedTypeDefinition parentTypeDefinition, IUnresolvedMethod parentMethodDefinition, UsingScope parentUsingScope, InterningProvider interningProvider)
		{
			ConstantValueBuilder visitor = new ConstantValueBuilder(isAttributeArgument: false, interningProvider);
			ConstantExpression constantExpression = expression.AcceptVisitor(visitor);
			if (constantExpression == null)
			{
				return new ErrorConstantValue(targetType);
			}
			PrimitiveConstantExpression primitiveConstantExpression = constantExpression as PrimitiveConstantExpression;
			if (primitiveConstantExpression != null && primitiveConstantExpression.Type == targetType)
			{
				return interningProvider.Intern(new SimpleConstantValue(targetType, primitiveConstantExpression.Value));
			}
			return interningProvider.Intern(new ConstantCast(targetType, constantExpression, allowNullableConstants: true));
		}

		private IConstantValue ConvertAttributeArgument(Expression expression)
		{
			ConstantValueBuilder visitor = new ConstantValueBuilder(isAttributeArgument: true, interningProvider);
			return expression.AcceptVisitor(visitor);
		}

		private void ConvertParameters(IList<IUnresolvedParameter> outputList, IEnumerable<ParameterDeclaration> parameters)
		{
			foreach (ParameterDeclaration parameter in parameters)
			{
				DefaultUnresolvedParameter defaultUnresolvedParameter = new DefaultUnresolvedParameter(ConvertTypeReference(parameter.Type), interningProvider.Intern(parameter.Name));
				defaultUnresolvedParameter.Region = MakeRegion(parameter);
				ConvertAttributes(defaultUnresolvedParameter.Attributes, parameter.Attributes);
				switch (parameter.ParameterModifier)
				{
				case ParameterModifier.Ref:
					defaultUnresolvedParameter.IsRef = true;
					defaultUnresolvedParameter.Type = interningProvider.Intern(new ByReferenceTypeReference(defaultUnresolvedParameter.Type));
					break;
				case ParameterModifier.Out:
					defaultUnresolvedParameter.IsOut = true;
					defaultUnresolvedParameter.Type = interningProvider.Intern(new ByReferenceTypeReference(defaultUnresolvedParameter.Type));
					break;
				case ParameterModifier.Params:
					defaultUnresolvedParameter.IsParams = true;
					break;
				}
				if (!parameter.DefaultExpression.IsNull)
				{
					defaultUnresolvedParameter.DefaultValue = ConvertConstantValue(defaultUnresolvedParameter.Type, parameter.DefaultExpression);
				}
				outputList.Add(interningProvider.Intern(defaultUnresolvedParameter));
			}
		}

		internal static IList<ITypeReference> GetParameterTypes(IEnumerable<ParameterDeclaration> parameters, InterningProvider interningProvider)
		{
			List<ITypeReference> list = new List<ITypeReference>();
			foreach (ParameterDeclaration parameter in parameters)
			{
				ITypeReference typeReference = parameter.Type.ToTypeReference(NameLookupMode.Type, interningProvider);
				if (parameter.ParameterModifier == ParameterModifier.Ref || parameter.ParameterModifier == ParameterModifier.Out)
				{
					typeReference = interningProvider.Intern(new ByReferenceTypeReference(typeReference));
				}
				list.Add(typeReference);
			}
			return list;
		}

		private void AddXmlDocumentation(IUnresolvedEntity entity, AstNode entityDeclaration)
		{
			if (SkipXmlDocumentation)
			{
				return;
			}
			StringBuilder stringBuilder = null;
			AstNode astNode = entityDeclaration.FirstChild;
			while (astNode != null && astNode.NodeType == NodeType.Whitespace)
			{
				Comment comment = astNode as Comment;
				if (comment != null && comment.IsDocumentation)
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder();
					}
					if (comment.CommentType == CommentType.MultiLineDocumentation)
					{
						PrepareMultilineDocumentation(comment.Content, stringBuilder);
					}
					else
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.AppendLine();
						}
						if (comment.Content.Length > 0 && comment.Content[0] == ' ')
						{
							stringBuilder.Append(comment.Content.Substring(1));
						}
						else
						{
							stringBuilder.Append(comment.Content);
						}
					}
				}
				astNode = astNode.NextSibling;
			}
			if (stringBuilder != null)
			{
				unresolvedFile.AddDocumentation(entity, stringBuilder.ToString());
			}
		}

		private void PrepareMultilineDocumentation(string content, StringBuilder b)
		{
			using (StringReader stringReader = new StringReader(content))
			{
				string text = stringReader.ReadLine();
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (text[0] == ' ')
					{
						b.Append(text, 1, text.Length - 1);
					}
					else
					{
						b.Append(text);
					}
				}
				List<string> list = new List<string>();
				string item;
				while ((item = stringReader.ReadLine()) != null)
				{
					list.Add(item);
				}
				if (list.Count > 0 && string.IsNullOrWhiteSpace(list[list.Count - 1]))
				{
					list.RemoveAt(list.Count - 1);
				}
				if (list.Count > 0)
				{
					int i = 0;
					string text2;
					for (text2 = list[0]; i < text2.Length && char.IsWhiteSpace(text2[i]); i++)
					{
					}
					if (i < text2.Length && text2[i] == '*')
					{
						for (i++; i < text2.Length && char.IsWhiteSpace(text2[i]); i++)
						{
						}
					}
					else
					{
						i = 0;
					}
					for (int j = 1; j < list.Count; j++)
					{
						item = list[j];
						if (item.Length < i)
						{
							i = item.Length;
						}
						for (int k = 0; k < i; k++)
						{
							if (text2[k] != item[k])
							{
								i = k;
							}
						}
					}
					for (int l = 0; l < list.Count; l++)
					{
						if (b.Length > 0 || l > 0)
						{
							b.Append(Environment.NewLine);
						}
						b.Append(list[l], i, list[l].Length - i);
					}
				}
			}
		}
	}
}
