using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CodeDomConvertVisitor : IAstVisitor<CodeObject>
	{
		private CSharpAstResolver resolver;

		private Stack<CodeTypeDeclaration> typeStack = new Stack<CodeTypeDeclaration>();

		public bool UseFullyQualifiedTypeNames
		{
			get;
			set;
		}

		public bool AllowSnippetNodes
		{
			get;
			set;
		}

		public CodeDomConvertVisitor()
		{
			AllowSnippetNodes = true;
		}

		public CodeCompileUnit Convert(ICompilation compilation, SyntaxTree syntaxTree, CSharpUnresolvedFile unresolvedFile)
		{
			if (syntaxTree == null)
			{
				throw new ArgumentNullException("syntaxTree");
			}
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			CSharpAstResolver cSharpAstResolver = new CSharpAstResolver(compilation, syntaxTree, unresolvedFile);
			return (CodeCompileUnit)Convert(syntaxTree, cSharpAstResolver);
		}

		public CodeObject Convert(AstNode node, CSharpAstResolver resolver)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			try
			{
				this.resolver = resolver;
				return node.AcceptVisitor(this);
			}
			finally
			{
				this.resolver = null;
			}
		}

		private ResolveResult Resolve(AstNode node)
		{
			if (resolver == null)
			{
				return ErrorResolveResult.UnknownError;
			}
			return resolver.Resolve(node);
		}

		private CodeExpression Convert(Expression expr)
		{
			return (CodeExpression)expr.AcceptVisitor(this);
		}

		private CodeExpression[] Convert(IEnumerable<Expression> expressions)
		{
			List<CodeExpression> list = new List<CodeExpression>();
			foreach (Expression expression in expressions)
			{
				CodeExpression codeExpression = Convert(expression);
				if (codeExpression != null)
				{
					list.Add(codeExpression);
				}
			}
			return list.ToArray();
		}

		private CodeTypeReference Convert(AstType type)
		{
			return (CodeTypeReference)type.AcceptVisitor(this);
		}

		private CodeTypeReference[] Convert(IEnumerable<AstType> types)
		{
			List<CodeTypeReference> list = new List<CodeTypeReference>();
			foreach (AstType type in types)
			{
				CodeTypeReference codeTypeReference = Convert(type);
				if (codeTypeReference != null)
				{
					list.Add(codeTypeReference);
				}
			}
			return list.ToArray();
		}

		public CodeTypeReference Convert(IType type)
		{
			if (type.Kind == TypeKind.Array)
			{
				ArrayType arrayType = (ArrayType)type;
				return new CodeTypeReference(Convert(arrayType.ElementType), arrayType.Dimensions);
			}
			if (type is ParameterizedType)
			{
				ParameterizedType parameterizedType = (ParameterizedType)type;
				return new CodeTypeReference(parameterizedType.GetDefinition().ReflectionName, parameterizedType.TypeArguments.Select(Convert).ToArray());
			}
			return new CodeTypeReference(type.ReflectionName);
		}

		private CodeStatement Convert(Statement stmt)
		{
			return (CodeStatement)stmt.AcceptVisitor(this);
		}

		private CodeStatement[] ConvertBlock(BlockStatement block)
		{
			List<CodeStatement> list = new List<CodeStatement>();
			foreach (Statement statement in block.Statements)
			{
				if (!(statement is EmptyStatement))
				{
					CodeStatement codeStatement = Convert(statement);
					if (codeStatement != null)
					{
						list.Add(codeStatement);
					}
				}
			}
			return list.ToArray();
		}

		private CodeStatement[] ConvertEmbeddedStatement(Statement embeddedStatement)
		{
			BlockStatement blockStatement = embeddedStatement as BlockStatement;
			if (blockStatement != null)
			{
				return ConvertBlock(blockStatement);
			}
			if (embeddedStatement is EmptyStatement)
			{
				return new CodeStatement[0];
			}
			CodeStatement codeStatement = Convert(embeddedStatement);
			if (codeStatement != null)
			{
				return new CodeStatement[1]
				{
					codeStatement
				};
			}
			return new CodeStatement[0];
		}

		private string MakeSnippet(AstNode node)
		{
			if (!AllowSnippetNodes)
			{
				throw new NotSupportedException();
			}
			StringWriter stringWriter = new StringWriter();
			CSharpOutputVisitor visitor = new CSharpOutputVisitor(stringWriter, FormattingOptionsFactory.CreateMono());
			node.AcceptVisitor(visitor);
			return stringWriter.ToString();
		}

		private CodeSnippetExpression MakeSnippetExpression(Expression expr)
		{
			return new CodeSnippetExpression(MakeSnippet(expr));
		}

		private CodeSnippetStatement MakeSnippetStatement(Statement stmt)
		{
			return new CodeSnippetStatement(MakeSnippet(stmt));
		}

		CodeObject IAstVisitor<CodeObject>.VisitNullNode(AstNode nullNode)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitErrorNode(AstNode errorNode)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
		{
			return MakeSnippetExpression(anonymousMethodExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
		{
			return MakeSnippetExpression(undocumentedExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
		{
			CodeArrayCreateExpression codeArrayCreateExpression = new CodeArrayCreateExpression();
			int count = arrayCreateExpression.Arguments.Count;
			int num = arrayCreateExpression.AdditionalArraySpecifiers.Count;
			if (count > 0)
			{
				num++;
			}
			if (num > 1 || count > 1)
			{
				return MakeSnippetExpression(arrayCreateExpression);
			}
			if (arrayCreateExpression.Type.IsNull)
			{
				codeArrayCreateExpression.CreateType = Convert(Resolve(arrayCreateExpression).Type);
			}
			else
			{
				codeArrayCreateExpression.CreateType = Convert(arrayCreateExpression.Type);
			}
			if (arrayCreateExpression.Arguments.Count == 1)
			{
				codeArrayCreateExpression.SizeExpression = Convert(arrayCreateExpression.Arguments.Single());
			}
			codeArrayCreateExpression.Initializers.AddRange(Convert(arrayCreateExpression.Initializer.Elements));
			return codeArrayCreateExpression;
		}

		CodeObject IAstVisitor<CodeObject>.VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
		{
			return MakeSnippetExpression(arrayInitializerExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitAsExpression(AsExpression asExpression)
		{
			return MakeSnippetExpression(asExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitAssignmentExpression(AssignmentExpression assignmentExpression)
		{
			return MakeSnippetExpression(assignmentExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
		{
			return new CodeBaseReferenceExpression();
		}

		CodeObject IAstVisitor<CodeObject>.VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
		{
			CodeBinaryOperatorType op;
			switch (binaryOperatorExpression.Operator)
			{
			case BinaryOperatorType.BitwiseAnd:
				op = CodeBinaryOperatorType.BitwiseAnd;
				break;
			case BinaryOperatorType.BitwiseOr:
				op = CodeBinaryOperatorType.BitwiseOr;
				break;
			case BinaryOperatorType.ConditionalAnd:
				op = CodeBinaryOperatorType.BooleanAnd;
				break;
			case BinaryOperatorType.ConditionalOr:
				op = CodeBinaryOperatorType.BooleanOr;
				break;
			case BinaryOperatorType.GreaterThan:
				op = CodeBinaryOperatorType.GreaterThan;
				break;
			case BinaryOperatorType.GreaterThanOrEqual:
				op = CodeBinaryOperatorType.GreaterThanOrEqual;
				break;
			case BinaryOperatorType.LessThan:
				op = CodeBinaryOperatorType.LessThan;
				break;
			case BinaryOperatorType.LessThanOrEqual:
				op = CodeBinaryOperatorType.LessThanOrEqual;
				break;
			case BinaryOperatorType.Add:
				op = CodeBinaryOperatorType.Add;
				break;
			case BinaryOperatorType.Subtract:
				op = CodeBinaryOperatorType.Subtract;
				break;
			case BinaryOperatorType.Multiply:
				op = CodeBinaryOperatorType.Multiply;
				break;
			case BinaryOperatorType.Divide:
				op = CodeBinaryOperatorType.Divide;
				break;
			case BinaryOperatorType.Modulus:
				op = CodeBinaryOperatorType.Modulus;
				break;
			case BinaryOperatorType.Equality:
			case BinaryOperatorType.InEquality:
			{
				OperatorResolveResult operatorResolveResult = Resolve(binaryOperatorExpression) as OperatorResolveResult;
				if (operatorResolveResult != null && operatorResolveResult.GetChildResults().Any((ResolveResult cr) => cr.Type.IsReferenceType == true))
				{
					op = ((binaryOperatorExpression.Operator != BinaryOperatorType.Equality) ? CodeBinaryOperatorType.IdentityInequality : CodeBinaryOperatorType.IdentityEquality);
					break;
				}
				if (binaryOperatorExpression.Operator == BinaryOperatorType.Equality)
				{
					op = CodeBinaryOperatorType.ValueEquality;
					break;
				}
				return new CodeBinaryOperatorExpression(new CodeBinaryOperatorExpression(Convert(binaryOperatorExpression.Left), CodeBinaryOperatorType.ValueEquality, Convert(binaryOperatorExpression.Right)), CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(false));
			}
			default:
				return MakeSnippetExpression(binaryOperatorExpression);
			}
			return new CodeBinaryOperatorExpression(Convert(binaryOperatorExpression.Left), op, Convert(binaryOperatorExpression.Right));
		}

		CodeObject IAstVisitor<CodeObject>.VisitCastExpression(CastExpression castExpression)
		{
			return new CodeCastExpression(Convert(castExpression.Type), Convert(castExpression.Expression));
		}

		CodeObject IAstVisitor<CodeObject>.VisitCheckedExpression(CheckedExpression checkedExpression)
		{
			return MakeSnippetExpression(checkedExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitConditionalExpression(ConditionalExpression conditionalExpression)
		{
			return MakeSnippetExpression(conditionalExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
		{
			return new CodeDefaultValueExpression(Convert(defaultValueExpression.Type));
		}

		CodeObject IAstVisitor<CodeObject>.VisitDirectionExpression(DirectionExpression directionExpression)
		{
			System.CodeDom.FieldDirection direction = (directionExpression.FieldDirection == FieldDirection.Out) ? System.CodeDom.FieldDirection.Out : System.CodeDom.FieldDirection.Ref;
			return new CodeDirectionExpression(direction, Convert(directionExpression.Expression));
		}

		CodeObject IAstVisitor<CodeObject>.VisitIdentifierExpression(IdentifierExpression identifierExpression)
		{
			ResolveResult resolveResult = Resolve(identifierExpression);
			LocalResolveResult localResolveResult = resolveResult as LocalResolveResult;
			if (localResolveResult != null && localResolveResult.IsParameter)
			{
				if (localResolveResult.Variable.Name == "value" && identifierExpression.Ancestors.Any((AstNode a) => a is Accessor))
				{
					return new CodePropertySetValueReferenceExpression();
				}
				return new CodeArgumentReferenceExpression(localResolveResult.Variable.Name);
			}
			MemberResolveResult memberResolveResult = resolveResult as MemberResolveResult;
			if (memberResolveResult != null)
			{
				return HandleMemberReference(null, identifierExpression.Identifier, identifierExpression.TypeArguments, memberResolveResult);
			}
			TypeResolveResult typeResolveResult = resolveResult as TypeResolveResult;
			if (typeResolveResult != null)
			{
				CodeTypeReference codeTypeReference;
				if (UseFullyQualifiedTypeNames)
				{
					codeTypeReference = Convert(typeResolveResult.Type);
				}
				else
				{
					codeTypeReference = new CodeTypeReference(identifierExpression.Identifier);
					codeTypeReference.TypeArguments.AddRange(Convert(identifierExpression.TypeArguments));
				}
				return new CodeTypeReferenceExpression(codeTypeReference);
			}
			if (resolveResult is MethodGroupResolveResult || identifierExpression.TypeArguments.Any())
			{
				return new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), identifierExpression.Identifier, Convert(identifierExpression.TypeArguments));
			}
			return new CodeVariableReferenceExpression(identifierExpression.Identifier);
		}

		CodeObject IAstVisitor<CodeObject>.VisitIndexerExpression(IndexerExpression indexerExpression)
		{
			if (Resolve(indexerExpression) is ArrayAccessResolveResult)
			{
				return new CodeArrayIndexerExpression(Convert(indexerExpression.Target), Convert(indexerExpression.Arguments));
			}
			return new CodeIndexerExpression(Convert(indexerExpression.Target), Convert(indexerExpression.Arguments));
		}

		CodeObject IAstVisitor<CodeObject>.VisitInvocationExpression(InvocationExpression invocationExpression)
		{
			MemberResolveResult memberResolveResult = Resolve(invocationExpression) as MemberResolveResult;
			CSharpInvocationResolveResult cSharpInvocationResolveResult = memberResolveResult as CSharpInvocationResolveResult;
			if (cSharpInvocationResolveResult != null && cSharpInvocationResolveResult.IsDelegateInvocation)
			{
				return new CodeDelegateInvokeExpression(Convert(invocationExpression.Target), Convert(invocationExpression.Arguments));
			}
			Expression expression = invocationExpression.Target;
			while (expression is ParenthesizedExpression)
			{
				expression = ((ParenthesizedExpression)expression).Expression;
			}
			CodeMethodReferenceExpression codeMethodReferenceExpression = null;
			MemberReferenceExpression memberReferenceExpression = expression as MemberReferenceExpression;
			if (memberReferenceExpression != null)
			{
				codeMethodReferenceExpression = new CodeMethodReferenceExpression(Convert(memberReferenceExpression.Target), memberReferenceExpression.MemberName, Convert(memberReferenceExpression.TypeArguments));
			}
			IdentifierExpression identifierExpression = expression as IdentifierExpression;
			if (identifierExpression != null)
			{
				CodeExpression targetObject = (memberResolveResult == null || !memberResolveResult.Member.IsStatic) ? ((CodeExpression)new CodeThisReferenceExpression()) : ((CodeExpression)new CodeTypeReferenceExpression(Convert(memberResolveResult.Member.DeclaringType ?? SpecialType.UnknownType)));
				codeMethodReferenceExpression = new CodeMethodReferenceExpression(targetObject, identifierExpression.Identifier, Convert(identifierExpression.TypeArguments));
			}
			if (codeMethodReferenceExpression != null)
			{
				return new CodeMethodInvokeExpression(codeMethodReferenceExpression, Convert(invocationExpression.Arguments));
			}
			return MakeSnippetExpression(invocationExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitIsExpression(IsExpression isExpression)
		{
			return MakeSnippetExpression(isExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitLambdaExpression(LambdaExpression lambdaExpression)
		{
			return MakeSnippetExpression(lambdaExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
		{
			CodeExpression codeExpression = Convert(memberReferenceExpression.Target);
			ResolveResult resolveResult = Resolve(memberReferenceExpression);
			MemberResolveResult memberResolveResult = resolveResult as MemberResolveResult;
			TypeResolveResult typeResolveResult = resolveResult as TypeResolveResult;
			if (memberResolveResult != null)
			{
				return HandleMemberReference(codeExpression, memberReferenceExpression.MemberName, memberReferenceExpression.TypeArguments, memberResolveResult);
			}
			if (typeResolveResult != null)
			{
				return new CodeTypeReferenceExpression(Convert(typeResolveResult.Type));
			}
			if (memberReferenceExpression.TypeArguments.Any() || resolveResult is MethodGroupResolveResult)
			{
				return new CodeMethodReferenceExpression(codeExpression, memberReferenceExpression.MemberName, Convert(memberReferenceExpression.TypeArguments));
			}
			return new CodePropertyReferenceExpression(codeExpression, memberReferenceExpression.MemberName);
		}

		private CodeExpression HandleMemberReference(CodeExpression target, string identifier, AstNodeCollection<AstType> typeArguments, MemberResolveResult mrr)
		{
			if (target == null)
			{
				target = ((!mrr.Member.IsStatic) ? ((CodeExpression)new CodeThisReferenceExpression()) : ((CodeExpression)new CodeTypeReferenceExpression(Convert(mrr.Member.DeclaringType ?? SpecialType.UnknownType))));
			}
			if (mrr.Member is IField)
			{
				return new CodeFieldReferenceExpression(target, identifier);
			}
			if (mrr.Member is IMethod)
			{
				return new CodeMethodReferenceExpression(target, identifier, Convert(typeArguments));
			}
			if (mrr.Member is IEvent)
			{
				return new CodeEventReferenceExpression(target, identifier);
			}
			return new CodePropertyReferenceExpression(target, identifier);
		}

		CodeObject IAstVisitor<CodeObject>.VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
		{
			return MakeSnippetExpression(namedArgumentExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitNamedExpression(NamedExpression namedExpression)
		{
			return MakeSnippetExpression(namedExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
		{
			return new CodePrimitiveExpression(null);
		}

		CodeObject IAstVisitor<CodeObject>.VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
		{
			if (!objectCreateExpression.Initializer.IsNull)
			{
				return MakeSnippetExpression(objectCreateExpression);
			}
			return new CodeObjectCreateExpression(Convert(objectCreateExpression.Type), Convert(objectCreateExpression.Arguments));
		}

		CodeObject IAstVisitor<CodeObject>.VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
		{
			return MakeSnippetExpression(anonymousTypeCreateExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
		{
			return Convert(parenthesizedExpression.Expression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
		{
			return MakeSnippetExpression(pointerReferenceExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
		{
			return new CodePrimitiveExpression(primitiveExpression.Value);
		}

		CodeObject IAstVisitor<CodeObject>.VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
		{
			return MakeSnippetExpression(sizeOfExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
		{
			return MakeSnippetExpression(stackAllocExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
		{
			return new CodeThisReferenceExpression();
		}

		CodeObject IAstVisitor<CodeObject>.VisitTypeOfExpression(TypeOfExpression typeOfExpression)
		{
			return new CodeTypeOfExpression(Convert(typeOfExpression.Type));
		}

		CodeObject IAstVisitor<CodeObject>.VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
		{
			return new CodeTypeReferenceExpression(Convert(typeReferenceExpression.Type));
		}

		CodeObject IAstVisitor<CodeObject>.VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
		{
			switch (unaryOperatorExpression.Operator)
			{
			case UnaryOperatorType.Not:
				return new CodeBinaryOperatorExpression(Convert(unaryOperatorExpression.Expression), CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(false));
			case UnaryOperatorType.Minus:
				return new CodeBinaryOperatorExpression(new CodePrimitiveExpression(0), CodeBinaryOperatorType.Subtract, Convert(unaryOperatorExpression.Expression));
			case UnaryOperatorType.Plus:
				return Convert(unaryOperatorExpression.Expression);
			default:
				return MakeSnippetExpression(unaryOperatorExpression);
			}
		}

		CodeObject IAstVisitor<CodeObject>.VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
		{
			return MakeSnippetExpression(uncheckedExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryExpression(QueryExpression queryExpression)
		{
			return MakeSnippetExpression(queryExpression);
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryFromClause(QueryFromClause queryFromClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryLetClause(QueryLetClause queryLetClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryWhereClause(QueryWhereClause queryWhereClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryJoinClause(QueryJoinClause queryJoinClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryOrderClause(QueryOrderClause queryOrderClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryOrdering(QueryOrdering queryOrdering)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQuerySelectClause(QuerySelectClause querySelectClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitQueryGroupClause(QueryGroupClause queryGroupClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitAttribute(Attribute attribute)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitAttributeSection(AttributeSection attributeSection)
		{
			throw new NotSupportedException();
		}

		private CodeAttributeDeclaration Convert(Attribute attribute)
		{
			CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration(Convert(attribute.Type));
			foreach (Expression argument in attribute.Arguments)
			{
				NamedExpression namedExpression = argument as NamedExpression;
				if (namedExpression != null)
				{
					codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument(namedExpression.Name, Convert(namedExpression.Expression)));
				}
				else
				{
					codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument(Convert(argument)));
				}
			}
			return codeAttributeDeclaration;
		}

		private CodeAttributeDeclaration[] Convert(IEnumerable<AttributeSection> attributeSections)
		{
			List<CodeAttributeDeclaration> list = new List<CodeAttributeDeclaration>();
			foreach (AttributeSection attributeSection in attributeSections)
			{
				foreach (Attribute attribute in attributeSection.Attributes)
				{
					CodeAttributeDeclaration codeAttributeDeclaration = Convert(attribute);
					if (codeAttributeDeclaration != null)
					{
						list.Add(codeAttributeDeclaration);
					}
				}
			}
			return list.ToArray();
		}

		CodeObject IAstVisitor<CodeObject>.VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
		{
			CodeTypeDelegate codeTypeDelegate = new CodeTypeDelegate(delegateDeclaration.Name);
			codeTypeDelegate.Attributes = ConvertMemberAttributes(delegateDeclaration.Modifiers, SymbolKind.TypeDefinition);
			codeTypeDelegate.CustomAttributes.AddRange(Convert(delegateDeclaration.Attributes));
			codeTypeDelegate.ReturnType = Convert(delegateDeclaration.ReturnType);
			codeTypeDelegate.Parameters.AddRange(Convert(delegateDeclaration.Parameters));
			codeTypeDelegate.TypeParameters.AddRange(ConvertTypeParameters(delegateDeclaration.TypeParameters, delegateDeclaration.Constraints));
			return codeTypeDelegate;
		}

		private MemberAttributes ConvertMemberAttributes(Modifiers modifiers, SymbolKind symbolKind)
		{
			MemberAttributes memberAttributes = (MemberAttributes)0;
			if ((modifiers & Modifiers.Abstract) != 0)
			{
				memberAttributes |= MemberAttributes.Abstract;
			}
			if ((modifiers & Modifiers.Sealed) != 0)
			{
				memberAttributes |= MemberAttributes.Final;
			}
			if (symbolKind != SymbolKind.TypeDefinition && (modifiers & (Modifiers.Abstract | Modifiers.Virtual | Modifiers.Override)) == Modifiers.None)
			{
				memberAttributes |= MemberAttributes.Final;
			}
			if ((modifiers & Modifiers.Static) != 0)
			{
				memberAttributes |= MemberAttributes.Static;
			}
			if ((modifiers & Modifiers.Override) != 0)
			{
				memberAttributes |= MemberAttributes.Override;
			}
			if ((modifiers & Modifiers.Const) != 0)
			{
				memberAttributes |= MemberAttributes.Const;
			}
			if ((modifiers & Modifiers.New) != 0)
			{
				memberAttributes |= MemberAttributes.New;
			}
			if ((modifiers & Modifiers.Public) != 0)
			{
				memberAttributes |= MemberAttributes.Public;
			}
			else if ((modifiers & (Modifiers.Internal | Modifiers.Protected)) == (Modifiers.Internal | Modifiers.Protected))
			{
				memberAttributes |= MemberAttributes.FamilyOrAssembly;
			}
			else if ((modifiers & Modifiers.Protected) != 0)
			{
				memberAttributes |= MemberAttributes.Family;
			}
			else if ((modifiers & Modifiers.Internal) != 0)
			{
				memberAttributes |= MemberAttributes.Assembly;
			}
			else if ((modifiers & Modifiers.Private) != 0)
			{
				memberAttributes |= MemberAttributes.Private;
			}
			return memberAttributes;
		}

		CodeObject IAstVisitor<CodeObject>.VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			CodeNamespace codeNamespace = new CodeNamespace(namespaceDeclaration.Name);
			foreach (AstNode member in namespaceDeclaration.Members)
			{
				CodeObject codeObject = member.AcceptVisitor(this);
				CodeNamespaceImport codeNamespaceImport = codeObject as CodeNamespaceImport;
				if (codeNamespaceImport != null)
				{
					codeNamespace.Imports.Add(codeNamespaceImport);
				}
				CodeTypeDeclaration codeTypeDeclaration = codeObject as CodeTypeDeclaration;
				if (codeTypeDeclaration != null)
				{
					codeNamespace.Types.Add(codeTypeDeclaration);
				}
			}
			return codeNamespace;
		}

		CodeObject IAstVisitor<CodeObject>.VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration(typeDeclaration.Name);
			codeTypeDeclaration.Attributes = ConvertMemberAttributes(typeDeclaration.Modifiers, SymbolKind.TypeDefinition);
			codeTypeDeclaration.CustomAttributes.AddRange(Convert(typeDeclaration.Attributes));
			switch (typeDeclaration.ClassType)
			{
			case ClassType.Struct:
				codeTypeDeclaration.IsStruct = true;
				break;
			case ClassType.Interface:
				codeTypeDeclaration.IsInterface = true;
				break;
			case ClassType.Enum:
				codeTypeDeclaration.IsEnum = true;
				break;
			default:
				codeTypeDeclaration.IsClass = true;
				break;
			}
			codeTypeDeclaration.IsPartial = ((typeDeclaration.Modifiers & Modifiers.Partial) == Modifiers.Partial);
			codeTypeDeclaration.BaseTypes.AddRange(Convert(typeDeclaration.BaseTypes));
			codeTypeDeclaration.TypeParameters.AddRange(ConvertTypeParameters(typeDeclaration.TypeParameters, typeDeclaration.Constraints));
			typeStack.Push(codeTypeDeclaration);
			foreach (EntityDeclaration member in typeDeclaration.Members)
			{
				CodeTypeMember codeTypeMember = member.AcceptVisitor(this) as CodeTypeMember;
				if (codeTypeMember != null)
				{
					codeTypeDeclaration.Members.Add(codeTypeMember);
				}
			}
			typeStack.Pop();
			return codeTypeDeclaration;
		}

		private void AddTypeMember(CodeTypeMember member)
		{
			if (typeStack.Count != 0)
			{
				typeStack.Peek().Members.Add(member);
			}
		}

		CodeObject IAstVisitor<CodeObject>.VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
		{
			return new CodeSnippetTypeMember(MakeSnippet(usingAliasDeclaration));
		}

		CodeObject IAstVisitor<CodeObject>.VisitUsingDeclaration(UsingDeclaration usingDeclaration)
		{
			return new CodeNamespaceImport(usingDeclaration.Namespace);
		}

		CodeObject IAstVisitor<CodeObject>.VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
		{
			return new CodeSnippetTypeMember(MakeSnippet(externAliasDeclaration));
		}

		CodeObject IAstVisitor<CodeObject>.VisitBlockStatement(BlockStatement blockStatement)
		{
			return new CodeConditionStatement(new CodePrimitiveExpression(true), ConvertBlock(blockStatement));
		}

		CodeObject IAstVisitor<CodeObject>.VisitBreakStatement(BreakStatement breakStatement)
		{
			return MakeSnippetStatement(breakStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitCheckedStatement(CheckedStatement checkedStatement)
		{
			return MakeSnippetStatement(checkedStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitContinueStatement(ContinueStatement continueStatement)
		{
			return MakeSnippetStatement(continueStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitDoWhileStatement(DoWhileStatement doWhileStatement)
		{
			string text = "_do" + doWhileStatement.Ancestors.OfType<DoWhileStatement>().Count();
			return new CodeIterationStatement(new CodeVariableDeclarationStatement(typeof(bool), text, new CodePrimitiveExpression(true)), new CodeVariableReferenceExpression(text), new CodeAssignStatement(new CodeVariableReferenceExpression(text), Convert(doWhileStatement.Condition)), ConvertEmbeddedStatement(doWhileStatement.EmbeddedStatement));
		}

		CodeObject IAstVisitor<CodeObject>.VisitEmptyStatement(EmptyStatement emptyStatement)
		{
			return EmptyStatement();
		}

		private CodeStatement EmptyStatement()
		{
			return new CodeExpressionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(object))));
		}

		CodeObject IAstVisitor<CodeObject>.VisitExpressionStatement(ExpressionStatement expressionStatement)
		{
			AssignmentExpression assignmentExpression = expressionStatement.Expression as AssignmentExpression;
			if (assignmentExpression != null && assignmentExpression.Operator == AssignmentOperatorType.Assign)
			{
				return new CodeAssignStatement(Convert(assignmentExpression.Left), Convert(assignmentExpression.Right));
			}
			if (assignmentExpression != null && CanBeDuplicatedForCompoundAssignment(assignmentExpression.Left))
			{
				CodeBinaryOperatorType op;
				switch (assignmentExpression.Operator)
				{
				case AssignmentOperatorType.Add:
					op = CodeBinaryOperatorType.Add;
					break;
				case AssignmentOperatorType.Subtract:
					op = CodeBinaryOperatorType.Subtract;
					break;
				case AssignmentOperatorType.Multiply:
					op = CodeBinaryOperatorType.Multiply;
					break;
				case AssignmentOperatorType.Divide:
					op = CodeBinaryOperatorType.Divide;
					break;
				case AssignmentOperatorType.Modulus:
					op = CodeBinaryOperatorType.Modulus;
					break;
				case AssignmentOperatorType.BitwiseAnd:
					op = CodeBinaryOperatorType.BitwiseAnd;
					break;
				case AssignmentOperatorType.BitwiseOr:
					op = CodeBinaryOperatorType.BitwiseOr;
					break;
				default:
					return MakeSnippetStatement(expressionStatement);
				}
				CodeBinaryOperatorExpression right = new CodeBinaryOperatorExpression(Convert(assignmentExpression.Left), op, Convert(assignmentExpression.Right));
				return new CodeAssignStatement(Convert(assignmentExpression.Left), right);
			}
			UnaryOperatorExpression unaryOperatorExpression = expressionStatement.Expression as UnaryOperatorExpression;
			if (unaryOperatorExpression != null && CanBeDuplicatedForCompoundAssignment(unaryOperatorExpression.Expression))
			{
				switch (unaryOperatorExpression.Operator)
				{
				case UnaryOperatorType.Increment:
				case UnaryOperatorType.PostIncrement:
				{
					CodeBinaryOperatorExpression right3 = new CodeBinaryOperatorExpression(Convert(unaryOperatorExpression.Expression), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1));
					return new CodeAssignStatement(Convert(unaryOperatorExpression.Expression), right3);
				}
				case UnaryOperatorType.Decrement:
				case UnaryOperatorType.PostDecrement:
				{
					CodeBinaryOperatorExpression right2 = new CodeBinaryOperatorExpression(Convert(unaryOperatorExpression.Expression), CodeBinaryOperatorType.Subtract, new CodePrimitiveExpression(1));
					return new CodeAssignStatement(Convert(unaryOperatorExpression.Expression), right2);
				}
				}
			}
			if (assignmentExpression != null && assignmentExpression.Operator == AssignmentOperatorType.Add)
			{
				ResolveResult resolveResult = Resolve(assignmentExpression.Left);
				if (!resolveResult.IsError && resolveResult.Type.Kind == TypeKind.Delegate)
				{
					MemberReferenceExpression memberReferenceExpression = (MemberReferenceExpression)assignmentExpression.Left;
					return new CodeAttachEventStatement((CodeEventReferenceExpression)HandleMemberReference(Convert(memberReferenceExpression.Target), memberReferenceExpression.MemberName, memberReferenceExpression.TypeArguments, (MemberResolveResult)resolveResult), Convert(assignmentExpression.Right));
				}
			}
			return new CodeExpressionStatement(Convert(expressionStatement.Expression));
		}

		private bool CanBeDuplicatedForCompoundAssignment(Expression expr)
		{
			return expr is IdentifierExpression;
		}

		CodeObject IAstVisitor<CodeObject>.VisitFixedStatement(FixedStatement fixedStatement)
		{
			return MakeSnippetStatement(fixedStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitForeachStatement(ForeachStatement foreachStatement)
		{
			return MakeSnippetStatement(foreachStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitForStatement(ForStatement forStatement)
		{
			if (forStatement.Initializers.Count != 1 || forStatement.Iterators.Count != 1)
			{
				return MakeSnippetStatement(forStatement);
			}
			return new CodeIterationStatement(Convert(forStatement.Initializers.Single()), Convert(forStatement.Condition), Convert(forStatement.Iterators.Single()), ConvertEmbeddedStatement(forStatement.EmbeddedStatement));
		}

		CodeObject IAstVisitor<CodeObject>.VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
		{
			return MakeSnippetStatement(gotoCaseStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
		{
			return MakeSnippetStatement(gotoDefaultStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitGotoStatement(GotoStatement gotoStatement)
		{
			return new CodeGotoStatement(gotoStatement.Label);
		}

		CodeObject IAstVisitor<CodeObject>.VisitIfElseStatement(IfElseStatement ifElseStatement)
		{
			return new CodeConditionStatement(Convert(ifElseStatement.Condition), ConvertEmbeddedStatement(ifElseStatement.TrueStatement), ConvertEmbeddedStatement(ifElseStatement.FalseStatement));
		}

		CodeObject IAstVisitor<CodeObject>.VisitLabelStatement(LabelStatement labelStatement)
		{
			return new CodeLabeledStatement(labelStatement.Label);
		}

		CodeObject IAstVisitor<CodeObject>.VisitLockStatement(LockStatement lockStatement)
		{
			return MakeSnippetStatement(lockStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitReturnStatement(ReturnStatement returnStatement)
		{
			return new CodeMethodReturnStatement(Convert(returnStatement.Expression));
		}

		CodeObject IAstVisitor<CodeObject>.VisitSwitchStatement(SwitchStatement switchStatement)
		{
			return MakeSnippetStatement(switchStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitSwitchSection(SwitchSection switchSection)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitCaseLabel(CaseLabel caseLabel)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitThrowStatement(ThrowStatement throwStatement)
		{
			return new CodeThrowExceptionStatement(Convert(throwStatement.Expression));
		}

		CodeObject IAstVisitor<CodeObject>.VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
		{
			List<CodeCatchClause> list = new List<CodeCatchClause>();
			foreach (CatchClause catchClause in tryCatchStatement.CatchClauses)
			{
				list.Add(new CodeCatchClause(catchClause.VariableName, Convert(catchClause.Type), ConvertBlock(catchClause.Body)));
			}
			return new CodeTryCatchFinallyStatement(ConvertBlock(tryCatchStatement.TryBlock), list.ToArray(), ConvertBlock(tryCatchStatement.FinallyBlock));
		}

		CodeObject IAstVisitor<CodeObject>.VisitCatchClause(CatchClause catchClause)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
		{
			return MakeSnippetStatement(uncheckedStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitUnsafeStatement(UnsafeStatement unsafeStatement)
		{
			return MakeSnippetStatement(unsafeStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitUsingStatement(UsingStatement usingStatement)
		{
			return MakeSnippetStatement(usingStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
		{
			if (variableDeclarationStatement.Variables.Count != 1)
			{
				return MakeSnippetStatement(variableDeclarationStatement);
			}
			VariableInitializer variableInitializer = variableDeclarationStatement.Variables.Single();
			return new CodeVariableDeclarationStatement(Convert(variableDeclarationStatement.Type), variableInitializer.Name, ConvertVariableInitializer(variableInitializer.Initializer, variableDeclarationStatement.Type));
		}

		private CodeExpression ConvertVariableInitializer(Expression expr, AstType type)
		{
			ArrayInitializerExpression arrayInitializerExpression = expr as ArrayInitializerExpression;
			if (arrayInitializerExpression != null)
			{
				return new CodeArrayCreateExpression(Convert(type), Convert(arrayInitializerExpression.Elements));
			}
			return Convert(expr);
		}

		CodeObject IAstVisitor<CodeObject>.VisitWhileStatement(WhileStatement whileStatement)
		{
			return new CodeIterationStatement(EmptyStatement(), Convert(whileStatement.Condition), EmptyStatement(), ConvertEmbeddedStatement(whileStatement.EmbeddedStatement));
		}

		CodeObject IAstVisitor<CodeObject>.VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
		{
			return MakeSnippetStatement(yieldBreakStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitYieldReturnStatement(YieldReturnStatement yieldStatement)
		{
			return MakeSnippetStatement(yieldStatement);
		}

		CodeObject IAstVisitor<CodeObject>.VisitAccessor(Accessor accessor)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
		{
			CodeConstructor codeConstructor = new CodeConstructor();
			codeConstructor.Attributes = ConvertMemberAttributes(constructorDeclaration.Modifiers, SymbolKind.Constructor);
			codeConstructor.CustomAttributes.AddRange(Convert(constructorDeclaration.Attributes));
			if (constructorDeclaration.Initializer.ConstructorInitializerType == ConstructorInitializerType.This)
			{
				codeConstructor.ChainedConstructorArgs.AddRange(Convert(constructorDeclaration.Initializer.Arguments));
			}
			else
			{
				codeConstructor.BaseConstructorArgs.AddRange(Convert(constructorDeclaration.Initializer.Arguments));
			}
			codeConstructor.Parameters.AddRange(Convert(constructorDeclaration.Parameters));
			codeConstructor.Statements.AddRange(ConvertBlock(constructorDeclaration.Body));
			return codeConstructor;
		}

		CodeObject IAstVisitor<CodeObject>.VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
		{
			return new CodeSnippetTypeMember(MakeSnippet(destructorDeclaration));
		}

		CodeObject IAstVisitor<CodeObject>.VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
		{
			TypeDeclaration typeDeclaration = enumMemberDeclaration.Parent as TypeDeclaration;
			CodeMemberField codeMemberField = new CodeMemberField((typeDeclaration != null) ? typeDeclaration.Name : "Enum", enumMemberDeclaration.Name);
			codeMemberField.Attributes = (MemberAttributes)24579;
			codeMemberField.CustomAttributes.AddRange(Convert(enumMemberDeclaration.Attributes));
			codeMemberField.InitExpression = Convert(enumMemberDeclaration.Initializer);
			return codeMemberField;
		}

		CodeObject IAstVisitor<CodeObject>.VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			foreach (VariableInitializer variable in eventDeclaration.Variables)
			{
				if (!variable.Initializer.IsNull)
				{
					AddTypeMember(new CodeSnippetTypeMember(MakeSnippet(eventDeclaration)));
				}
				else
				{
					CodeMemberEvent codeMemberEvent = new CodeMemberEvent();
					codeMemberEvent.Attributes = ConvertMemberAttributes(eventDeclaration.Modifiers, SymbolKind.Event);
					codeMemberEvent.CustomAttributes.AddRange(Convert(eventDeclaration.Attributes));
					codeMemberEvent.Name = variable.Name;
					codeMemberEvent.Type = Convert(eventDeclaration.ReturnType);
					AddTypeMember(codeMemberEvent);
				}
			}
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
		{
			return new CodeSnippetTypeMember(MakeSnippet(customEventDeclaration));
		}

		CodeObject IAstVisitor<CodeObject>.VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
		{
			foreach (VariableInitializer variable in fieldDeclaration.Variables)
			{
				CodeMemberField codeMemberField = new CodeMemberField(Convert(fieldDeclaration.ReturnType), variable.Name);
				codeMemberField.Attributes = ConvertMemberAttributes(fieldDeclaration.Modifiers, SymbolKind.Field);
				codeMemberField.CustomAttributes.AddRange(Convert(fieldDeclaration.Attributes));
				codeMemberField.InitExpression = ConvertVariableInitializer(variable.Initializer, fieldDeclaration.ReturnType);
				AddTypeMember(codeMemberField);
			}
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
		{
			CodeMemberProperty codeMemberProperty = new CodeMemberProperty();
			codeMemberProperty.Attributes = ConvertMemberAttributes(indexerDeclaration.Modifiers, SymbolKind.Indexer);
			codeMemberProperty.CustomAttributes.AddRange(Convert(indexerDeclaration.Attributes));
			codeMemberProperty.Name = "Items";
			codeMemberProperty.PrivateImplementationType = Convert(indexerDeclaration.PrivateImplementationType);
			codeMemberProperty.Parameters.AddRange(Convert(indexerDeclaration.Parameters));
			codeMemberProperty.Type = Convert(indexerDeclaration.ReturnType);
			if (!indexerDeclaration.Getter.IsNull)
			{
				codeMemberProperty.HasGet = true;
				codeMemberProperty.GetStatements.AddRange(ConvertBlock(indexerDeclaration.Getter.Body));
			}
			if (!indexerDeclaration.Setter.IsNull)
			{
				codeMemberProperty.HasSet = true;
				codeMemberProperty.SetStatements.AddRange(ConvertBlock(indexerDeclaration.Setter.Body));
			}
			return codeMemberProperty;
		}

		CodeObject IAstVisitor<CodeObject>.VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
			codeMemberMethod.Attributes = ConvertMemberAttributes(methodDeclaration.Modifiers, SymbolKind.Method);
			codeMemberMethod.CustomAttributes.AddRange(Convert(from a in methodDeclaration.Attributes
				where a.AttributeTarget != "return"
				select a));
			codeMemberMethod.ReturnTypeCustomAttributes.AddRange(Convert(from a in methodDeclaration.Attributes
				where a.AttributeTarget == "return"
				select a));
			codeMemberMethod.ReturnType = Convert(methodDeclaration.ReturnType);
			codeMemberMethod.PrivateImplementationType = Convert(methodDeclaration.PrivateImplementationType);
			codeMemberMethod.Name = methodDeclaration.Name;
			codeMemberMethod.TypeParameters.AddRange(ConvertTypeParameters(methodDeclaration.TypeParameters, methodDeclaration.Constraints));
			codeMemberMethod.Parameters.AddRange(Convert(methodDeclaration.Parameters));
			codeMemberMethod.Statements.AddRange(ConvertBlock(methodDeclaration.Body));
			return codeMemberMethod;
		}

		CodeObject IAstVisitor<CodeObject>.VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
		{
			CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
			codeMemberMethod.Attributes = ConvertMemberAttributes(operatorDeclaration.Modifiers, SymbolKind.Method);
			codeMemberMethod.CustomAttributes.AddRange(Convert(from a in operatorDeclaration.Attributes
				where a.AttributeTarget != "return"
				select a));
			codeMemberMethod.ReturnTypeCustomAttributes.AddRange(Convert(from a in operatorDeclaration.Attributes
				where a.AttributeTarget == "return"
				select a));
			codeMemberMethod.ReturnType = Convert(operatorDeclaration.ReturnType);
			codeMemberMethod.Name = operatorDeclaration.Name;
			codeMemberMethod.Parameters.AddRange(Convert(operatorDeclaration.Parameters));
			codeMemberMethod.Statements.AddRange(ConvertBlock(operatorDeclaration.Body));
			return codeMemberMethod;
		}

		CodeObject IAstVisitor<CodeObject>.VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
		{
			CodeParameterDeclarationExpression codeParameterDeclarationExpression = new CodeParameterDeclarationExpression(Convert(parameterDeclaration.Type), parameterDeclaration.Name);
			codeParameterDeclarationExpression.CustomAttributes.AddRange(Convert(parameterDeclaration.Attributes));
			switch (parameterDeclaration.ParameterModifier)
			{
			case ParameterModifier.Ref:
				codeParameterDeclarationExpression.Direction = System.CodeDom.FieldDirection.Ref;
				break;
			case ParameterModifier.Out:
				codeParameterDeclarationExpression.Direction = System.CodeDom.FieldDirection.Out;
				break;
			}
			return codeParameterDeclarationExpression;
		}

		private CodeParameterDeclarationExpression[] Convert(IEnumerable<ParameterDeclaration> parameters)
		{
			List<CodeParameterDeclarationExpression> list = new List<CodeParameterDeclarationExpression>();
			foreach (ParameterDeclaration parameter in parameters)
			{
				CodeParameterDeclarationExpression codeParameterDeclarationExpression = parameter.AcceptVisitor(this) as CodeParameterDeclarationExpression;
				if (codeParameterDeclarationExpression != null)
				{
					list.Add(codeParameterDeclarationExpression);
				}
			}
			return list.ToArray();
		}

		CodeObject IAstVisitor<CodeObject>.VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
		{
			CodeMemberProperty codeMemberProperty = new CodeMemberProperty();
			codeMemberProperty.Attributes = ConvertMemberAttributes(propertyDeclaration.Modifiers, SymbolKind.Property);
			codeMemberProperty.CustomAttributes.AddRange(Convert(propertyDeclaration.Attributes));
			codeMemberProperty.Name = propertyDeclaration.Name;
			codeMemberProperty.PrivateImplementationType = Convert(propertyDeclaration.PrivateImplementationType);
			codeMemberProperty.Type = Convert(propertyDeclaration.ReturnType);
			if (!propertyDeclaration.Getter.IsNull)
			{
				codeMemberProperty.HasGet = true;
				codeMemberProperty.GetStatements.AddRange(ConvertBlock(propertyDeclaration.Getter.Body));
			}
			if (!propertyDeclaration.Setter.IsNull)
			{
				codeMemberProperty.HasSet = true;
				codeMemberProperty.SetStatements.AddRange(ConvertBlock(propertyDeclaration.Setter.Body));
			}
			return codeMemberProperty;
		}

		CodeObject IAstVisitor<CodeObject>.VisitVariableInitializer(VariableInitializer variableInitializer)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
		{
			return new CodeSnippetTypeMember(MakeSnippet(fixedFieldDeclaration));
		}

		CodeObject IAstVisitor<CodeObject>.VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitSyntaxTree(SyntaxTree syntaxTree)
		{
			CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
			List<CodeNamespaceImport> list = new List<CodeNamespaceImport>();
			foreach (AstNode child in syntaxTree.Children)
			{
				CodeObject codeObject = child.AcceptVisitor(this);
				CodeNamespace codeNamespace = codeObject as CodeNamespace;
				if (codeNamespace != null)
				{
					codeCompileUnit.Namespaces.Add(codeNamespace);
				}
				CodeTypeDeclaration codeTypeDeclaration = codeObject as CodeTypeDeclaration;
				if (codeTypeDeclaration != null)
				{
					codeCompileUnit.Namespaces.Add(new CodeNamespace
					{
						Types = 
						{
							codeTypeDeclaration
						}
					});
				}
				CodeNamespaceImport codeNamespaceImport = codeObject as CodeNamespaceImport;
				if (codeNamespaceImport != null)
				{
					list.Add(codeNamespaceImport);
				}
			}
			foreach (CodeNamespaceImport gi in list)
			{
				for (int i = 0; i < codeCompileUnit.Namespaces.Count; i++)
				{
					CodeNamespace codeNamespace2 = codeCompileUnit.Namespaces[i];
					if (!codeNamespace2.Imports.Cast<CodeNamespaceImport>().Any((CodeNamespaceImport ns) => ns.Namespace == gi.Namespace))
					{
						codeNamespace2.Imports.Add(gi);
					}
				}
			}
			return codeCompileUnit;
		}

		CodeObject IAstVisitor<CodeObject>.VisitSimpleType(SimpleType simpleType)
		{
			if (UseFullyQualifiedTypeNames)
			{
				IType type = Resolve(simpleType).Type;
				if (type.Kind != TypeKind.Unknown)
				{
					return Convert(type);
				}
			}
			CodeTypeReference codeTypeReference = new CodeTypeReference(simpleType.Identifier);
			codeTypeReference.TypeArguments.AddRange(Convert(simpleType.TypeArguments));
			return codeTypeReference;
		}

		CodeObject IAstVisitor<CodeObject>.VisitMemberType(MemberType memberType)
		{
			if (memberType.IsDoubleColon && new SimpleType("global").IsMatch(memberType.Target))
			{
				CodeTypeReference codeTypeReference = new CodeTypeReference(memberType.MemberName, CodeTypeReferenceOptions.GlobalReference);
				codeTypeReference.TypeArguments.AddRange(Convert(memberType.TypeArguments));
				return codeTypeReference;
			}
			if (UseFullyQualifiedTypeNames || memberType.IsDoubleColon)
			{
				IType type = Resolve(memberType).Type;
				if (type.Kind != TypeKind.Unknown)
				{
					return Convert(type);
				}
			}
			CodeTypeReference codeTypeReference2 = Convert(memberType.Target);
			if (codeTypeReference2 == null)
			{
				return null;
			}
			codeTypeReference2.BaseType = codeTypeReference2.BaseType + "." + memberType.MemberName;
			codeTypeReference2.TypeArguments.AddRange(Convert(memberType.TypeArguments));
			return codeTypeReference2;
		}

		CodeObject IAstVisitor<CodeObject>.VisitComposedType(ComposedType composedType)
		{
			CodeTypeReference codeTypeReference = Convert(composedType.BaseType);
			if (codeTypeReference == null)
			{
				return null;
			}
			if (composedType.HasNullableSpecifier)
			{
				codeTypeReference = new CodeTypeReference("System.Nullable")
				{
					TypeArguments = 
					{
						codeTypeReference
					}
				};
			}
			foreach (ArraySpecifier item in composedType.ArraySpecifiers.Reverse())
			{
				codeTypeReference = new CodeTypeReference(codeTypeReference, item.Dimensions);
			}
			return codeTypeReference;
		}

		CodeObject IAstVisitor<CodeObject>.VisitArraySpecifier(ArraySpecifier arraySpecifier)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitPrimitiveType(PrimitiveType primitiveType)
		{
			KnownTypeCode knownTypeCode = primitiveType.KnownTypeCode;
			if (knownTypeCode != 0)
			{
				KnownTypeReference knownTypeReference = KnownTypeReference.Get(knownTypeCode);
				return new CodeTypeReference(knownTypeReference.Namespace + "." + knownTypeReference.Name);
			}
			return new CodeTypeReference(primitiveType.Keyword);
		}

		CodeObject IAstVisitor<CodeObject>.VisitComment(Comment comment)
		{
			return new CodeComment(comment.Content, comment.CommentType == CommentType.Documentation);
		}

		CodeObject IAstVisitor<CodeObject>.VisitNewLine(NewLineNode newLineNode)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitWhitespace(WhitespaceNode whitespaceNode)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitText(TextNode textNode)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
		{
			return new CodeComment("#" + preProcessorDirective.Type.ToString().ToLowerInvariant());
		}

		CodeObject IAstVisitor<CodeObject>.VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
		{
			throw new NotSupportedException();
		}

		CodeObject IAstVisitor<CodeObject>.VisitConstraint(Constraint constraint)
		{
			throw new NotSupportedException();
		}

		private CodeTypeParameter[] ConvertTypeParameters(IEnumerable<TypeParameterDeclaration> typeParameters, IEnumerable<Constraint> constraints)
		{
			List<CodeTypeParameter> list = new List<CodeTypeParameter>();
			foreach (TypeParameterDeclaration typeParameter in typeParameters)
			{
				CodeTypeParameter codeTypeParameter = new CodeTypeParameter(typeParameter.Name);
				codeTypeParameter.CustomAttributes.AddRange(Convert(typeParameter.Attributes));
				foreach (Constraint constraint in constraints)
				{
					if (constraint.TypeParameter.Identifier == codeTypeParameter.Name)
					{
						foreach (AstType baseType in constraint.BaseTypes)
						{
							if (baseType is PrimitiveType && ((PrimitiveType)baseType).Keyword == "new")
							{
								codeTypeParameter.HasConstructorConstraint = true;
							}
							else
							{
								CodeTypeReference codeTypeReference = Convert(baseType);
								if (codeTypeReference != null)
								{
									codeTypeParameter.Constraints.Add(codeTypeReference);
								}
							}
						}
					}
				}
				list.Add(codeTypeParameter);
			}
			return list.ToArray();
		}

		CodeObject IAstVisitor<CodeObject>.VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitIdentifier(Identifier identifier)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
		{
			return null;
		}

		CodeObject IAstVisitor<CodeObject>.VisitDocumentationReference(DocumentationReference documentationReference)
		{
			return null;
		}
	}
}
