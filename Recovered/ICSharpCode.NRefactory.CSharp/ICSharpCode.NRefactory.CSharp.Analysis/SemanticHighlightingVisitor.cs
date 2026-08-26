using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public abstract class SemanticHighlightingVisitor<TColor> : DepthFirstAstVisitor
	{
		protected CancellationToken cancellationToken;

		protected TColor defaultTextColor;

		protected TColor referenceTypeColor;

		protected TColor valueTypeColor;

		protected TColor interfaceTypeColor;

		protected TColor enumerationTypeColor;

		protected TColor typeParameterTypeColor;

		protected TColor delegateTypeColor;

		protected TColor methodCallColor;

		protected TColor methodDeclarationColor;

		protected TColor eventDeclarationColor;

		protected TColor eventAccessColor;

		protected TColor propertyDeclarationColor;

		protected TColor propertyAccessColor;

		protected TColor fieldDeclarationColor;

		protected TColor fieldAccessColor;

		protected TColor variableDeclarationColor;

		protected TColor variableAccessColor;

		protected TColor parameterDeclarationColor;

		protected TColor parameterAccessColor;

		protected TColor valueKeywordColor;

		protected TColor externAliasKeywordColor;

		protected TColor varKeywordTypeColor;

		protected TColor parameterModifierColor;

		protected TColor inactiveCodeColor;

		protected TColor stringFormatItemColor;

		protected TColor syntaxErrorColor;

		protected TextLocation regionStart;

		protected TextLocation regionEnd;

		protected CSharpAstResolver resolver;

		protected bool isInAccessorContainingValueParameter;

		private int blockDepth;

		protected abstract void Colorize(TextLocation start, TextLocation end, TColor color);

		protected void Colorize(Identifier identifier, ResolveResult rr)
		{
			if (identifier.IsNull)
			{
				return;
			}
			if (rr.IsError)
			{
				Colorize(identifier, syntaxErrorColor);
				return;
			}
			if (rr is TypeResolveResult)
			{
				TColor color;
				if (blockDepth > 0 && identifier.Name == "var" && rr.Type.Kind != TypeKind.Null && rr.Type.Name != "var")
				{
					Colorize(identifier, varKeywordTypeColor);
				}
				else if (TryGetTypeHighlighting(rr.Type.Kind, out color))
				{
					Colorize(identifier, color);
				}
				return;
			}
			MemberResolveResult memberResolveResult = rr as MemberResolveResult;
			if (memberResolveResult != null && TryGetMemberColor(memberResolveResult.Member, out TColor color2))
			{
				Colorize(identifier, color2);
				return;
			}
			if (rr is MethodGroupResolveResult)
			{
				Colorize(identifier, methodCallColor);
				return;
			}
			LocalResolveResult localResolveResult = rr as LocalResolveResult;
			if (localResolveResult != null)
			{
				if (localResolveResult.Variable is IParameter)
				{
					Colorize(identifier, parameterAccessColor);
				}
				else
				{
					Colorize(identifier, variableAccessColor);
				}
			}
			VisitIdentifier(identifier);
		}

		protected void Colorize(AstNode node, TColor color)
		{
			if (!node.IsNull)
			{
				Colorize(node.StartLocation, node.EndLocation, color);
			}
		}

		protected override void VisitChildren(AstNode node)
		{
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				if (astNode.StartLocation < regionEnd && astNode.EndLocation > regionStart)
				{
					astNode.AcceptVisitor(this);
				}
			}
		}

		protected void VisitChildrenUntil(AstNode node, AstNode end)
		{
			if (end.IsNull)
			{
				return;
			}
			for (AstNode astNode = node.FirstChild; astNode != end; astNode = astNode.NextSibling)
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (astNode.StartLocation < regionEnd && astNode.EndLocation > regionStart)
				{
					astNode.AcceptVisitor(this);
				}
			}
		}

		protected void VisitChildrenAfter(AstNode node, AstNode start)
		{
			for (AstNode astNode = start.IsNull ? node.FirstChild : start.NextSibling; astNode != null; astNode = astNode.NextSibling)
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (astNode.StartLocation < regionEnd && astNode.EndLocation > regionStart)
				{
					astNode.AcceptVisitor(this);
				}
			}
		}

		public override void VisitIdentifier(Identifier identifier)
		{
			switch (identifier.Name)
			{
			case "add":
			case "async":
			case "await":
			case "get":
			case "partial":
			case "remove":
			case "set":
			case "where":
			case "yield":
			case "from":
			case "select":
			case "group":
			case "into":
			case "orderby":
			case "join":
			case "let":
			case "on":
			case "equals":
			case "by":
			case "ascending":
			case "descending":
			case "dynamic":
			case "var":
				Colorize(identifier, defaultTextColor);
				break;
			case "global":
			{
				MemberType memberType = identifier.Parent as MemberType;
				if (memberType == null || !memberType.IsDoubleColon)
				{
					Colorize(identifier, defaultTextColor);
				}
				break;
			}
			}
		}

		public override void VisitSimpleType(SimpleType simpleType)
		{
			Identifier identifierToken = simpleType.IdentifierToken;
			VisitChildrenUntil(simpleType, identifierToken);
			Colorize(identifierToken, resolver.Resolve(simpleType, cancellationToken));
			VisitChildrenAfter(simpleType, identifierToken);
		}

		public override void VisitMemberType(MemberType memberType)
		{
			Identifier memberNameToken = memberType.MemberNameToken;
			VisitChildrenUntil(memberType, memberNameToken);
			Colorize(memberNameToken, resolver.Resolve(memberType, cancellationToken));
			VisitChildrenAfter(memberType, memberNameToken);
		}

		public override void VisitIdentifierExpression(IdentifierExpression identifierExpression)
		{
			Identifier identifierToken = identifierExpression.IdentifierToken;
			VisitChildrenUntil(identifierExpression, identifierToken);
			if (isInAccessorContainingValueParameter && identifierExpression.Identifier == "value")
			{
				Colorize(identifierToken, valueKeywordColor);
			}
			else
			{
				Colorize(identifierToken, resolver.Resolve(identifierExpression, cancellationToken));
			}
			VisitChildrenAfter(identifierExpression, identifierToken);
		}

		public override void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
		{
			Identifier memberNameToken = memberReferenceExpression.MemberNameToken;
			VisitChildrenUntil(memberReferenceExpression, memberNameToken);
			ResolveResult rr = resolver.Resolve(memberReferenceExpression, cancellationToken);
			Colorize(memberNameToken, rr);
			VisitChildrenAfter(memberReferenceExpression, memberNameToken);
		}

		private void HighlightStringFormatItems(PrimitiveExpression expr)
		{
			if (!(expr.Value is string))
			{
				return;
			}
			int num = expr.StartLocation.Line;
			int num2 = expr.StartLocation.Column;
			TextLocation start = TextLocation.Empty;
			for (int i = 0; i < expr.LiteralValue.Length; i++)
			{
				char c = expr.LiteralValue[i];
				if (NewLine.GetDelimiterType(c, (i + 1 < expr.LiteralValue.Length) ? expr.LiteralValue[i + 1] : '\0') != 0)
				{
					num++;
					num2 = 1;
					continue;
				}
				if (c == '{' && start.IsEmpty)
				{
					if (((i + 1 < expr.LiteralValue.Length) ? expr.LiteralValue[i + 1] : '\0') == '{')
					{
						i++;
						num2 += 2;
						continue;
					}
					start = new TextLocation(num, num2);
				}
				if (c == '}' && !start.IsEmpty)
				{
					Colorize(start, new TextLocation(num, num2 + 1), stringFormatItemColor);
					start = TextLocation.Empty;
				}
				num2++;
			}
		}

		public override void VisitInvocationExpression(InvocationExpression invocationExpression)
		{
			Expression target = invocationExpression.Target;
			if (target is IdentifierExpression || target is MemberReferenceExpression || target is PointerReferenceExpression)
			{
				CSharpInvocationResolveResult cSharpInvocationResolveResult = resolver.Resolve(invocationExpression, cancellationToken) as CSharpInvocationResolveResult;
				if (cSharpInvocationResolveResult != null)
				{
					if (invocationExpression.Parent is ExpressionStatement && (IsInactiveConditionalMethod(cSharpInvocationResolveResult.Member) || IsEmptyPartialMethod(cSharpInvocationResolveResult.Member)))
					{
						Colorize(invocationExpression.Parent, inactiveCodeColor);
						return;
					}
					if (cSharpInvocationResolveResult.Arguments.Count > 1 && FormatStringHelper.TryGetFormattingParameters(cSharpInvocationResolveResult, invocationExpression, out Expression _, out IList<Expression> _, null))
					{
						PrimitiveExpression primitiveExpression = invocationExpression.Arguments.First() as PrimitiveExpression;
						if (primitiveExpression != null)
						{
							HighlightStringFormatItems(primitiveExpression);
						}
					}
				}
				VisitChildrenUntil(invocationExpression, target);
				Identifier childByRole = target.GetChildByRole(Roles.Identifier);
				VisitChildrenUntil(target, childByRole);
				if (cSharpInvocationResolveResult != null && !cSharpInvocationResolveResult.IsDelegateInvocation)
				{
					Colorize(childByRole, methodCallColor);
				}
				else
				{
					ResolveResult rr = resolver.Resolve(target, cancellationToken);
					Colorize(childByRole, rr);
				}
				VisitChildrenAfter(target, childByRole);
				VisitChildrenAfter(invocationExpression, target);
			}
			else
			{
				VisitChildren(invocationExpression);
			}
		}

		private bool IsInactiveConditionalMethod(IParameterizedMember member)
		{
			if (member.SymbolKind != SymbolKind.Method || member.ReturnType.Kind != TypeKind.Void)
			{
				return false;
			}
			foreach (IMember baseMember in InheritanceHelper.GetBaseMembers(member, includeImplementedInterfaces: false))
			{
				if (IsInactiveConditional(baseMember.Attributes))
				{
					return true;
				}
			}
			return IsInactiveConditional(member.Attributes);
		}

		private static bool IsEmptyPartialMethod(IParameterizedMember member)
		{
			if (member.SymbolKind != SymbolKind.Method || member.ReturnType.Kind != TypeKind.Void)
			{
				return false;
			}
			IMethod method = (IMethod)member;
			if (method.IsPartial)
			{
				return !method.HasBody;
			}
			return false;
		}

		private bool IsInactiveConditional(IList<IAttribute> attributes)
		{
			bool result = false;
			foreach (IAttribute attribute in attributes)
			{
				if (attribute.AttributeType.Name == "ConditionalAttribute" && attribute.AttributeType.Namespace == "System.Diagnostics" && attribute.PositionalArguments.Count == 1)
				{
					string text = attribute.PositionalArguments[0].ConstantValue as string;
					if (text != null)
					{
						result = true;
						SyntaxTree syntaxTree = resolver.RootNode as SyntaxTree;
						if (syntaxTree != null && syntaxTree.ConditionalSymbols.Contains(text))
						{
							return false;
						}
					}
				}
			}
			return result;
		}

		public override void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
		{
			CSharpTokenNode aliasToken = externAliasDeclaration.AliasToken;
			VisitChildrenUntil(externAliasDeclaration, aliasToken);
			Colorize(aliasToken, externAliasKeywordColor);
			VisitChildrenAfter(externAliasDeclaration, aliasToken);
		}

		public override void VisitAccessor(Accessor accessor)
		{
			isInAccessorContainingValueParameter = (accessor.Role != PropertyDeclaration.GetterRole);
			try
			{
				VisitChildren(accessor);
			}
			finally
			{
				isInAccessorContainingValueParameter = false;
			}
		}

		private bool CheckInterfaceImplementation(EntityDeclaration entityDeclaration)
		{
			MemberResolveResult memberResolveResult = resolver.Resolve(entityDeclaration, cancellationToken) as MemberResolveResult;
			if (memberResolveResult == null)
			{
				return false;
			}
			if (memberResolveResult.Member.ImplementedInterfaceMembers.Count == 0)
			{
				Colorize(entityDeclaration.NameToken, syntaxErrorColor);
				return false;
			}
			return true;
		}

		public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			Identifier nameToken = methodDeclaration.NameToken;
			VisitChildrenUntil(methodDeclaration, nameToken);
			if (!methodDeclaration.PrivateImplementationType.IsNull && !CheckInterfaceImplementation(methodDeclaration))
			{
				VisitChildrenAfter(methodDeclaration, nameToken);
				return;
			}
			Colorize(nameToken, methodDeclarationColor);
			VisitChildrenAfter(methodDeclaration, nameToken);
		}

		public override void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
		{
			Identifier nameToken = parameterDeclaration.NameToken;
			VisitChildrenUntil(parameterDeclaration, nameToken);
			Colorize(nameToken, parameterDeclarationColor);
			VisitChildrenAfter(parameterDeclaration, nameToken);
		}

		public override void VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			Identifier nameToken = eventDeclaration.NameToken;
			VisitChildrenUntil(eventDeclaration, nameToken);
			Colorize(nameToken, eventDeclarationColor);
			VisitChildrenAfter(eventDeclaration, nameToken);
		}

		public override void VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
		{
			Identifier nameToken = eventDeclaration.NameToken;
			VisitChildrenUntil(eventDeclaration, nameToken);
			if (!eventDeclaration.PrivateImplementationType.IsNull && !CheckInterfaceImplementation(eventDeclaration))
			{
				VisitChildrenAfter(eventDeclaration, nameToken);
				return;
			}
			Colorize(nameToken, eventDeclarationColor);
			VisitChildrenAfter(eventDeclaration, nameToken);
		}

		public override void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
		{
			Identifier nameToken = propertyDeclaration.NameToken;
			VisitChildrenUntil(propertyDeclaration, nameToken);
			if (!propertyDeclaration.PrivateImplementationType.IsNull && !CheckInterfaceImplementation(propertyDeclaration))
			{
				VisitChildrenAfter(propertyDeclaration, nameToken);
				return;
			}
			Colorize(nameToken, propertyDeclarationColor);
			VisitChildrenAfter(propertyDeclaration, nameToken);
		}

		public override void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
		{
			base.VisitIndexerDeclaration(indexerDeclaration);
			if (!indexerDeclaration.PrivateImplementationType.IsNull)
			{
				CheckInterfaceImplementation(indexerDeclaration);
			}
		}

		public override void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
		{
			fieldDeclaration.ReturnType.AcceptVisitor(this);
			foreach (VariableInitializer variable in fieldDeclaration.Variables)
			{
				Colorize(variable.NameToken, fieldDeclarationColor);
				variable.Initializer.AcceptVisitor(this);
			}
		}

		public override void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
		{
			fixedFieldDeclaration.ReturnType.AcceptVisitor(this);
			foreach (FixedVariableInitializer variable in fixedFieldDeclaration.Variables)
			{
				Colorize(variable.NameToken, fieldDeclarationColor);
				variable.CountExpression.AcceptVisitor(this);
			}
		}

		public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
		{
			HandleConstructorOrDestructor(constructorDeclaration);
		}

		public override void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
		{
			HandleConstructorOrDestructor(destructorDeclaration);
		}

		private void HandleConstructorOrDestructor(AstNode constructorDeclaration)
		{
			Identifier childByRole = constructorDeclaration.GetChildByRole(Roles.Identifier);
			VisitChildrenUntil(constructorDeclaration, childByRole);
			ITypeDefinition currentTypeDefinition = resolver.GetResolverStateBefore(constructorDeclaration).CurrentTypeDefinition;
			if (currentTypeDefinition != null && childByRole.Name == currentTypeDefinition.Name && TryGetTypeHighlighting(currentTypeDefinition.Kind, out TColor color))
			{
				Colorize(childByRole, color);
			}
			VisitChildrenAfter(constructorDeclaration, childByRole);
		}

		private bool TryGetMemberColor(IMember member, out TColor color)
		{
			switch (member.SymbolKind)
			{
			case SymbolKind.Field:
				color = fieldAccessColor;
				return true;
			case SymbolKind.Property:
				color = propertyAccessColor;
				return true;
			case SymbolKind.Event:
				color = eventAccessColor;
				return true;
			case SymbolKind.Method:
				color = methodCallColor;
				return true;
			case SymbolKind.Constructor:
			case SymbolKind.Destructor:
				return TryGetTypeHighlighting(member.DeclaringType?.Kind ?? TypeKind.Unknown, out color);
			default:
				color = default(TColor);
				return false;
			}
		}

		private TColor GetTypeHighlighting(ClassType classType)
		{
			switch (classType)
			{
			case ClassType.Class:
				return referenceTypeColor;
			case ClassType.Struct:
				return valueTypeColor;
			case ClassType.Interface:
				return interfaceTypeColor;
			case ClassType.Enum:
				return enumerationTypeColor;
			default:
				throw new InvalidOperationException("Unknown class type :" + classType);
			}
		}

		private bool TryGetTypeHighlighting(TypeKind kind, out TColor color)
		{
			switch (kind)
			{
			case TypeKind.Class:
				color = referenceTypeColor;
				return true;
			case TypeKind.Struct:
				color = valueTypeColor;
				return true;
			case TypeKind.Interface:
				color = interfaceTypeColor;
				return true;
			case TypeKind.Enum:
				color = enumerationTypeColor;
				return true;
			case TypeKind.TypeParameter:
				color = typeParameterTypeColor;
				return true;
			case TypeKind.Delegate:
				color = delegateTypeColor;
				return true;
			case TypeKind.Unknown:
			case TypeKind.Null:
				color = syntaxErrorColor;
				return true;
			default:
				color = default(TColor);
				return false;
			}
		}

		public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			Identifier nameToken = typeDeclaration.NameToken;
			VisitChildrenUntil(typeDeclaration, nameToken);
			Colorize(nameToken, GetTypeHighlighting(typeDeclaration.ClassType));
			VisitChildrenAfter(typeDeclaration, nameToken);
		}

		public override void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
		{
			if (typeParameterDeclaration.Variance == VarianceModifier.Contravariant)
			{
				Colorize(typeParameterDeclaration.VarianceToken, parameterModifierColor);
			}
			Identifier nameToken = typeParameterDeclaration.NameToken;
			VisitChildrenUntil(typeParameterDeclaration, nameToken);
			Colorize(nameToken, typeParameterTypeColor);
			VisitChildrenAfter(typeParameterDeclaration, nameToken);
		}

		public override void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
		{
			Identifier nameToken = delegateDeclaration.NameToken;
			VisitChildrenUntil(delegateDeclaration, nameToken);
			Colorize(nameToken, delegateTypeColor);
			VisitChildrenAfter(delegateDeclaration, nameToken);
		}

		public override void VisitVariableInitializer(VariableInitializer variableInitializer)
		{
			Identifier nameToken = variableInitializer.NameToken;
			VisitChildrenUntil(variableInitializer, nameToken);
			if (variableInitializer.Parent is FieldDeclaration)
			{
				Colorize(nameToken, fieldDeclarationColor);
			}
			else if (variableInitializer.Parent is EventDeclaration)
			{
				Colorize(nameToken, eventDeclarationColor);
			}
			else
			{
				Colorize(nameToken, variableDeclarationColor);
			}
			VisitChildrenAfter(variableInitializer, nameToken);
		}

		public override void VisitComment(Comment comment)
		{
			if (comment.CommentType == CommentType.InactiveCode)
			{
				Colorize(comment, inactiveCodeColor);
			}
		}

		public override void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
		{
		}

		public override void VisitAttribute(Attribute attribute)
		{
			ITypeDefinition definition = resolver.Resolve(attribute.Type, cancellationToken).Type.GetDefinition();
			if (definition != null && IsInactiveConditional(definition.Attributes))
			{
				Colorize(attribute, inactiveCodeColor);
			}
			else
			{
				VisitChildren(attribute);
			}
		}

		public override void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
		{
			foreach (Expression element in arrayInitializerExpression.Elements)
			{
				NamedExpression namedExpression = element as NamedExpression;
				if (namedExpression != null)
				{
					if (resolver.Resolve(namedExpression, cancellationToken).IsError)
					{
						Colorize(namedExpression.NameToken, syntaxErrorColor);
					}
					namedExpression.Expression.AcceptVisitor(this);
				}
				else
				{
					element.AcceptVisitor(this);
				}
			}
		}

		public override void VisitBlockStatement(BlockStatement blockStatement)
		{
			blockDepth++;
			base.VisitBlockStatement(blockStatement);
			blockDepth--;
		}
	}
}
