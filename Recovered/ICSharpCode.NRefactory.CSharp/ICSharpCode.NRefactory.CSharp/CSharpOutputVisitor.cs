using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CSharpOutputVisitor : IAstVisitor
	{
		protected readonly TokenWriter writer;

		protected readonly CSharpFormattingOptions policy;

		protected readonly Stack<AstNode> containerStack = new Stack<AstNode>();

		protected bool isAtStartOfLine = true;

		private static readonly HashSet<string> unconditionalKeywords = new HashSet<string>
		{
			"abstract",
			"as",
			"base",
			"bool",
			"break",
			"byte",
			"case",
			"catch",
			"char",
			"checked",
			"class",
			"const",
			"continue",
			"decimal",
			"default",
			"delegate",
			"do",
			"double",
			"else",
			"enum",
			"event",
			"explicit",
			"extern",
			"false",
			"finally",
			"fixed",
			"float",
			"for",
			"foreach",
			"goto",
			"if",
			"implicit",
			"in",
			"int",
			"interface",
			"internal",
			"is",
			"lock",
			"long",
			"namespace",
			"new",
			"null",
			"object",
			"operator",
			"out",
			"override",
			"params",
			"private",
			"protected",
			"public",
			"readonly",
			"ref",
			"return",
			"sbyte",
			"sealed",
			"short",
			"sizeof",
			"stackalloc",
			"static",
			"string",
			"struct",
			"switch",
			"this",
			"throw",
			"true",
			"try",
			"typeof",
			"uint",
			"ulong",
			"unchecked",
			"unsafe",
			"ushort",
			"using",
			"virtual",
			"void",
			"volatile",
			"while"
		};

		private static readonly HashSet<string> queryKeywords = new HashSet<string>
		{
			"from",
			"where",
			"join",
			"on",
			"equals",
			"into",
			"let",
			"orderby",
			"ascending",
			"descending",
			"select",
			"group",
			"by"
		};

		public CSharpOutputVisitor(TextWriter textWriter, CSharpFormattingOptions formattingPolicy)
		{
			if (textWriter == null)
			{
				throw new ArgumentNullException("textWriter");
			}
			if (formattingPolicy == null)
			{
				throw new ArgumentNullException("formattingPolicy");
			}
			writer = TokenWriter.Create(textWriter);
			policy = formattingPolicy;
		}

		public CSharpOutputVisitor(TokenWriter writer, CSharpFormattingOptions formattingPolicy)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (formattingPolicy == null)
			{
				throw new ArgumentNullException("formattingPolicy");
			}
			this.writer = new InsertSpecialsDecorator(new InsertRequiredSpacesDecorator(writer));
			policy = formattingPolicy;
		}

		protected virtual void StartNode(AstNode node)
		{
			containerStack.Push(node);
			writer.StartNode(node);
		}

		protected virtual void EndNode(AstNode node)
		{
			containerStack.Pop();
			writer.EndNode(node);
		}

		protected virtual void Comma(AstNode nextNode, bool noSpaceAfterComma = false)
		{
			Space(policy.SpaceBeforeBracketComma);
			writer.WriteToken(Roles.Comma, ",");
			Space(!noSpaceAfterComma && policy.SpaceAfterBracketComma);
		}

		protected virtual void OptionalComma(AstNode pos)
		{
			while (pos != null && pos.NodeType == NodeType.Whitespace)
			{
				pos = pos.NextSibling;
			}
			if (pos != null && pos.Role == Roles.Comma)
			{
				Comma(null, noSpaceAfterComma: true);
			}
		}

		protected virtual void OptionalSemicolon(AstNode pos)
		{
			while (pos != null && pos.NodeType == NodeType.Whitespace)
			{
				pos = pos.PrevSibling;
			}
			if (pos != null && pos.Role == Roles.Semicolon)
			{
				Semicolon();
			}
		}

		protected virtual void WriteCommaSeparatedList(IEnumerable<AstNode> list)
		{
			bool flag = true;
			foreach (AstNode item in list)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					Comma(item);
				}
				item.AcceptVisitor(this);
			}
		}

		protected virtual void WriteCommaSeparatedListInParenthesis(IEnumerable<AstNode> list, bool spaceWithin)
		{
			LPar();
			if (list.Any())
			{
				Space(spaceWithin);
				WriteCommaSeparatedList(list);
				Space(spaceWithin);
			}
			RPar();
		}

		protected virtual void WriteCommaSeparatedListInBrackets(IEnumerable<ParameterDeclaration> list, bool spaceWithin)
		{
			WriteToken(Roles.LBracket);
			if (list.Any())
			{
				Space(spaceWithin);
				WriteCommaSeparatedList(list);
				Space(spaceWithin);
			}
			WriteToken(Roles.RBracket);
		}

		protected virtual void WriteCommaSeparatedListInBrackets(IEnumerable<Expression> list)
		{
			WriteToken(Roles.LBracket);
			if (list.Any())
			{
				Space(policy.SpacesWithinBrackets);
				WriteCommaSeparatedList(list);
				Space(policy.SpacesWithinBrackets);
			}
			WriteToken(Roles.RBracket);
		}

		protected virtual void WriteKeyword(TokenRole tokenRole)
		{
			WriteKeyword(tokenRole.Token, tokenRole);
		}

		protected virtual void WriteKeyword(string token, Role tokenRole = null)
		{
			writer.WriteKeyword(tokenRole, token);
			isAtStartOfLine = false;
		}

		protected virtual void WriteIdentifier(Identifier identifier)
		{
			writer.WriteIdentifier(identifier);
			isAtStartOfLine = false;
		}

		protected virtual void WriteIdentifier(string identifier)
		{
			AstType.Create(identifier).AcceptVisitor(this);
			isAtStartOfLine = false;
		}

		protected virtual void WriteToken(TokenRole tokenRole)
		{
			WriteToken(tokenRole.Token, tokenRole);
		}

		protected virtual void WriteToken(string token, Role tokenRole)
		{
			writer.WriteToken(tokenRole, token);
			isAtStartOfLine = false;
		}

		protected virtual void LPar()
		{
			WriteToken(Roles.LPar);
		}

		protected virtual void RPar()
		{
			WriteToken(Roles.RPar);
		}

		protected virtual void Semicolon()
		{
			Role role = containerStack.Peek().Role;
			if (role != ForStatement.InitializerRole && role != ForStatement.IteratorRole && role != UsingStatement.ResourceAcquisitionRole)
			{
				WriteToken(Roles.Semicolon);
				NewLine();
			}
		}

		protected virtual void Space(bool addSpace = true)
		{
			if (addSpace)
			{
				writer.Space();
			}
		}

		protected virtual void NewLine()
		{
			writer.NewLine();
			isAtStartOfLine = true;
		}

		protected virtual void OpenBrace(BraceStyle style)
		{
			switch (style)
			{
			case BraceStyle.DoNotChange:
			case BraceStyle.EndOfLine:
			case BraceStyle.BannerStyle:
				if (!isAtStartOfLine)
				{
					writer.Space();
				}
				writer.WriteToken(Roles.LBrace, "{");
				break;
			case BraceStyle.EndOfLineWithoutSpace:
				writer.WriteToken(Roles.LBrace, "{");
				break;
			case BraceStyle.NextLine:
				if (!isAtStartOfLine)
				{
					NewLine();
				}
				writer.WriteToken(Roles.LBrace, "{");
				break;
			case BraceStyle.NextLineShifted:
				NewLine();
				writer.Indent();
				writer.WriteToken(Roles.LBrace, "{");
				NewLine();
				return;
			case BraceStyle.NextLineShifted2:
				NewLine();
				writer.Indent();
				writer.WriteToken(Roles.LBrace, "{");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			writer.Indent();
			NewLine();
		}

		protected virtual void CloseBrace(BraceStyle style)
		{
			switch (style)
			{
			case BraceStyle.DoNotChange:
			case BraceStyle.EndOfLine:
			case BraceStyle.EndOfLineWithoutSpace:
			case BraceStyle.NextLine:
				writer.Unindent();
				writer.WriteToken(Roles.RBrace, "}");
				isAtStartOfLine = false;
				break;
			case BraceStyle.NextLineShifted:
			case BraceStyle.BannerStyle:
				writer.WriteToken(Roles.RBrace, "}");
				isAtStartOfLine = false;
				writer.Unindent();
				break;
			case BraceStyle.NextLineShifted2:
				writer.Unindent();
				writer.WriteToken(Roles.RBrace, "}");
				isAtStartOfLine = false;
				writer.Unindent();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public static bool IsKeyword(string identifier, AstNode context)
		{
			if (unconditionalKeywords.Contains(identifier))
			{
				return true;
			}
			foreach (AstNode ancestor in context.Ancestors)
			{
				if (ancestor is QueryExpression && queryKeywords.Contains(identifier))
				{
					return true;
				}
				if (identifier == "await")
				{
					if (ancestor is LambdaExpression)
					{
						return ((LambdaExpression)ancestor).IsAsync;
					}
					if (ancestor is AnonymousMethodExpression)
					{
						return ((AnonymousMethodExpression)ancestor).IsAsync;
					}
					if (ancestor is EntityDeclaration)
					{
						return (((EntityDeclaration)ancestor).Modifiers & Modifiers.Async) == Modifiers.Async;
					}
				}
			}
			return false;
		}

		protected virtual void WriteTypeArguments(IEnumerable<AstType> typeArguments)
		{
			if (typeArguments.Any())
			{
				WriteToken(Roles.LChevron);
				WriteCommaSeparatedList(typeArguments);
				WriteToken(Roles.RChevron);
			}
		}

		public virtual void WriteTypeParameters(IEnumerable<TypeParameterDeclaration> typeParameters)
		{
			if (typeParameters.Any())
			{
				WriteToken(Roles.LChevron);
				WriteCommaSeparatedList(typeParameters);
				WriteToken(Roles.RChevron);
			}
		}

		protected virtual void WriteModifiers(IEnumerable<CSharpModifierToken> modifierTokens)
		{
			foreach (CSharpModifierToken modifierToken in modifierTokens)
			{
				modifierToken.AcceptVisitor(this);
			}
		}

		protected virtual void WriteQualifiedIdentifier(IEnumerable<Identifier> identifiers)
		{
			bool flag = true;
			foreach (Identifier identifier in identifiers)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					writer.WriteToken(Roles.Dot, ".");
				}
				writer.WriteIdentifier(identifier);
			}
		}

		protected virtual void WriteEmbeddedStatement(Statement embeddedStatement, NewLinePlacement nlp = NewLinePlacement.NewLine)
		{
			if (embeddedStatement.IsNull)
			{
				NewLine();
				return;
			}
			BlockStatement blockStatement = embeddedStatement as BlockStatement;
			if (blockStatement != null)
			{
				WriteBlock(blockStatement, policy.StatementBraceStyle);
				if (nlp == NewLinePlacement.SameLine)
				{
					Space();
				}
				else
				{
					NewLine();
				}
			}
			else
			{
				NewLine();
				writer.Indent();
				embeddedStatement.AcceptVisitor(this);
				writer.Unindent();
			}
		}

		protected virtual void WriteMethodBody(BlockStatement body, BraceStyle style)
		{
			if (body.IsNull)
			{
				Semicolon();
				return;
			}
			WriteBlock(body, style);
			NewLine();
		}

		protected virtual void WriteAttributes(IEnumerable<AttributeSection> attributes)
		{
			foreach (AttributeSection attribute in attributes)
			{
				attribute.AcceptVisitor(this);
			}
		}

		protected virtual void WritePrivateImplementationType(AstType privateImplementationType)
		{
			if (!privateImplementationType.IsNull)
			{
				privateImplementationType.AcceptVisitor(this);
				WriteToken(Roles.Dot);
			}
		}

		public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
		{
			StartNode(anonymousMethodExpression);
			if (anonymousMethodExpression.IsAsync)
			{
				WriteKeyword(AnonymousMethodExpression.AsyncModifierRole);
				Space();
			}
			WriteKeyword(AnonymousMethodExpression.DelegateKeywordRole);
			if (anonymousMethodExpression.HasParameterList)
			{
				Space(policy.SpaceBeforeMethodDeclarationParentheses);
				WriteCommaSeparatedListInParenthesis(anonymousMethodExpression.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			}
			WriteBlock(anonymousMethodExpression.Body, policy.AnonymousMethodBraceStyle);
			EndNode(anonymousMethodExpression);
		}

		public virtual void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
		{
			StartNode(undocumentedExpression);
			switch (undocumentedExpression.UndocumentedExpressionType)
			{
			case UndocumentedExpressionType.ArgListAccess:
			case UndocumentedExpressionType.ArgList:
				WriteKeyword(UndocumentedExpression.ArglistKeywordRole);
				break;
			case UndocumentedExpressionType.MakeRef:
				WriteKeyword(UndocumentedExpression.MakerefKeywordRole);
				break;
			case UndocumentedExpressionType.RefType:
				WriteKeyword(UndocumentedExpression.ReftypeKeywordRole);
				break;
			case UndocumentedExpressionType.RefValue:
				WriteKeyword(UndocumentedExpression.RefvalueKeywordRole);
				break;
			}
			if (undocumentedExpression.UndocumentedExpressionType != 0)
			{
				Space(policy.SpaceBeforeMethodCallParentheses);
				WriteCommaSeparatedListInParenthesis(undocumentedExpression.Arguments, policy.SpaceWithinMethodCallParentheses);
			}
			EndNode(undocumentedExpression);
		}

		public virtual void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
		{
			StartNode(arrayCreateExpression);
			WriteKeyword(ArrayCreateExpression.NewKeywordRole);
			arrayCreateExpression.Type.AcceptVisitor(this);
			if (arrayCreateExpression.Arguments.Count > 0)
			{
				WriteCommaSeparatedListInBrackets(arrayCreateExpression.Arguments);
			}
			foreach (ArraySpecifier additionalArraySpecifier in arrayCreateExpression.AdditionalArraySpecifiers)
			{
				additionalArraySpecifier.AcceptVisitor(this);
			}
			arrayCreateExpression.Initializer.AcceptVisitor(this);
			EndNode(arrayCreateExpression);
		}

		public virtual void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
		{
			StartNode(arrayInitializerExpression);
			if (arrayInitializerExpression.Elements.Count == 1 && IsObjectOrCollectionInitializer(arrayInitializerExpression.Parent) && !CanBeConfusedWithObjectInitializer(arrayInitializerExpression.Elements.Single()) && arrayInitializerExpression.LBraceToken.IsNull)
			{
				arrayInitializerExpression.Elements.Single().AcceptVisitor(this);
			}
			else
			{
				PrintInitializerElements(arrayInitializerExpression.Elements);
			}
			EndNode(arrayInitializerExpression);
		}

		protected bool CanBeConfusedWithObjectInitializer(Expression expr)
		{
			AssignmentExpression assignmentExpression = expr as AssignmentExpression;
			if (assignmentExpression != null)
			{
				return assignmentExpression.Operator == AssignmentOperatorType.Assign;
			}
			return false;
		}

		protected bool IsObjectOrCollectionInitializer(AstNode node)
		{
			if (!(node is ArrayInitializerExpression))
			{
				return false;
			}
			if (node.Parent is ObjectCreateExpression)
			{
				return node.Role == ObjectCreateExpression.InitializerRole;
			}
			if (node.Parent is NamedExpression)
			{
				return node.Role == Roles.Expression;
			}
			return false;
		}

		protected virtual void PrintInitializerElements(AstNodeCollection<Expression> elements)
		{
			BraceStyle style = (policy.ArrayInitializerWrapping != Wrapping.WrapAlways) ? BraceStyle.EndOfLine : BraceStyle.NextLine;
			OpenBrace(style);
			bool flag = true;
			AstNode astNode = null;
			foreach (Expression element in elements)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					Comma(element, noSpaceAfterComma: true);
					NewLine();
				}
				astNode = element;
				element.AcceptVisitor(this);
			}
			if (astNode != null)
			{
				OptionalComma(astNode.NextSibling);
			}
			NewLine();
			CloseBrace(style);
		}

		public virtual void VisitAsExpression(AsExpression asExpression)
		{
			StartNode(asExpression);
			asExpression.Expression.AcceptVisitor(this);
			Space();
			WriteKeyword(AsExpression.AsKeywordRole);
			Space();
			asExpression.Type.AcceptVisitor(this);
			EndNode(asExpression);
		}

		public virtual void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
		{
			StartNode(assignmentExpression);
			assignmentExpression.Left.AcceptVisitor(this);
			Space(policy.SpaceAroundAssignment);
			WriteToken(AssignmentExpression.GetOperatorRole(assignmentExpression.Operator));
			Space(policy.SpaceAroundAssignment);
			assignmentExpression.Right.AcceptVisitor(this);
			EndNode(assignmentExpression);
		}

		public virtual void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
		{
			StartNode(baseReferenceExpression);
			WriteKeyword("base", baseReferenceExpression.Role);
			EndNode(baseReferenceExpression);
		}

		public virtual void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
		{
			StartNode(binaryOperatorExpression);
			binaryOperatorExpression.Left.AcceptVisitor(this);
			bool addSpace;
			switch (binaryOperatorExpression.Operator)
			{
			case BinaryOperatorType.BitwiseAnd:
			case BinaryOperatorType.BitwiseOr:
			case BinaryOperatorType.ExclusiveOr:
				addSpace = policy.SpaceAroundBitwiseOperator;
				break;
			case BinaryOperatorType.ConditionalAnd:
			case BinaryOperatorType.ConditionalOr:
				addSpace = policy.SpaceAroundLogicalOperator;
				break;
			case BinaryOperatorType.GreaterThan:
			case BinaryOperatorType.GreaterThanOrEqual:
			case BinaryOperatorType.LessThan:
			case BinaryOperatorType.LessThanOrEqual:
				addSpace = policy.SpaceAroundRelationalOperator;
				break;
			case BinaryOperatorType.Equality:
			case BinaryOperatorType.InEquality:
				addSpace = policy.SpaceAroundEqualityOperator;
				break;
			case BinaryOperatorType.Add:
			case BinaryOperatorType.Subtract:
				addSpace = policy.SpaceAroundAdditiveOperator;
				break;
			case BinaryOperatorType.Multiply:
			case BinaryOperatorType.Divide:
			case BinaryOperatorType.Modulus:
				addSpace = policy.SpaceAroundMultiplicativeOperator;
				break;
			case BinaryOperatorType.ShiftLeft:
			case BinaryOperatorType.ShiftRight:
				addSpace = policy.SpaceAroundShiftOperator;
				break;
			case BinaryOperatorType.NullCoalescing:
				addSpace = true;
				break;
			default:
				throw new NotSupportedException("Invalid value for BinaryOperatorType");
			}
			Space(addSpace);
			WriteToken(BinaryOperatorExpression.GetOperatorRole(binaryOperatorExpression.Operator));
			Space(addSpace);
			binaryOperatorExpression.Right.AcceptVisitor(this);
			EndNode(binaryOperatorExpression);
		}

		public virtual void VisitCastExpression(CastExpression castExpression)
		{
			StartNode(castExpression);
			LPar();
			Space(policy.SpacesWithinCastParentheses);
			castExpression.Type.AcceptVisitor(this);
			Space(policy.SpacesWithinCastParentheses);
			RPar();
			Space(policy.SpaceAfterTypecast);
			castExpression.Expression.AcceptVisitor(this);
			EndNode(castExpression);
		}

		public virtual void VisitCheckedExpression(CheckedExpression checkedExpression)
		{
			StartNode(checkedExpression);
			WriteKeyword(CheckedExpression.CheckedKeywordRole);
			LPar();
			Space(policy.SpacesWithinCheckedExpressionParantheses);
			checkedExpression.Expression.AcceptVisitor(this);
			Space(policy.SpacesWithinCheckedExpressionParantheses);
			RPar();
			EndNode(checkedExpression);
		}

		public virtual void VisitConditionalExpression(ConditionalExpression conditionalExpression)
		{
			StartNode(conditionalExpression);
			conditionalExpression.Condition.AcceptVisitor(this);
			Space(policy.SpaceBeforeConditionalOperatorCondition);
			WriteToken(ConditionalExpression.QuestionMarkRole);
			Space(policy.SpaceAfterConditionalOperatorCondition);
			conditionalExpression.TrueExpression.AcceptVisitor(this);
			Space(policy.SpaceBeforeConditionalOperatorSeparator);
			WriteToken(ConditionalExpression.ColonRole);
			Space(policy.SpaceAfterConditionalOperatorSeparator);
			conditionalExpression.FalseExpression.AcceptVisitor(this);
			EndNode(conditionalExpression);
		}

		public virtual void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
		{
			StartNode(defaultValueExpression);
			WriteKeyword(DefaultValueExpression.DefaultKeywordRole);
			LPar();
			Space(policy.SpacesWithinTypeOfParentheses);
			defaultValueExpression.Type.AcceptVisitor(this);
			Space(policy.SpacesWithinTypeOfParentheses);
			RPar();
			EndNode(defaultValueExpression);
		}

		public virtual void VisitDirectionExpression(DirectionExpression directionExpression)
		{
			StartNode(directionExpression);
			switch (directionExpression.FieldDirection)
			{
			case FieldDirection.Out:
				WriteKeyword(DirectionExpression.OutKeywordRole);
				break;
			case FieldDirection.Ref:
				WriteKeyword(DirectionExpression.RefKeywordRole);
				break;
			default:
				throw new NotSupportedException("Invalid value for FieldDirection");
			}
			Space();
			directionExpression.Expression.AcceptVisitor(this);
			EndNode(directionExpression);
		}

		public virtual void VisitIdentifierExpression(IdentifierExpression identifierExpression)
		{
			StartNode(identifierExpression);
			WriteIdentifier(identifierExpression.IdentifierToken);
			WriteTypeArguments(identifierExpression.TypeArguments);
			EndNode(identifierExpression);
		}

		public virtual void VisitIndexerExpression(IndexerExpression indexerExpression)
		{
			StartNode(indexerExpression);
			indexerExpression.Target.AcceptVisitor(this);
			Space(policy.SpaceBeforeMethodCallParentheses);
			WriteCommaSeparatedListInBrackets(indexerExpression.Arguments);
			EndNode(indexerExpression);
		}

		public virtual void VisitInvocationExpression(InvocationExpression invocationExpression)
		{
			StartNode(invocationExpression);
			invocationExpression.Target.AcceptVisitor(this);
			Space(policy.SpaceBeforeMethodCallParentheses);
			WriteCommaSeparatedListInParenthesis(invocationExpression.Arguments, policy.SpaceWithinMethodCallParentheses);
			EndNode(invocationExpression);
		}

		public virtual void VisitIsExpression(IsExpression isExpression)
		{
			StartNode(isExpression);
			isExpression.Expression.AcceptVisitor(this);
			Space();
			WriteKeyword(IsExpression.IsKeywordRole);
			isExpression.Type.AcceptVisitor(this);
			EndNode(isExpression);
		}

		public virtual void VisitLambdaExpression(LambdaExpression lambdaExpression)
		{
			StartNode(lambdaExpression);
			if (lambdaExpression.IsAsync)
			{
				WriteKeyword(LambdaExpression.AsyncModifierRole);
				Space();
			}
			if (LambdaNeedsParenthesis(lambdaExpression))
			{
				WriteCommaSeparatedListInParenthesis(lambdaExpression.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			}
			else
			{
				lambdaExpression.Parameters.Single().AcceptVisitor(this);
			}
			Space();
			WriteToken(LambdaExpression.ArrowRole);
			if (lambdaExpression.Body is BlockStatement)
			{
				WriteBlock((BlockStatement)lambdaExpression.Body, policy.AnonymousMethodBraceStyle);
			}
			else
			{
				Space();
				lambdaExpression.Body.AcceptVisitor(this);
			}
			EndNode(lambdaExpression);
		}

		protected bool LambdaNeedsParenthesis(LambdaExpression lambdaExpression)
		{
			if (lambdaExpression.Parameters.Count != 1)
			{
				return true;
			}
			ParameterDeclaration parameterDeclaration = lambdaExpression.Parameters.Single();
			if (parameterDeclaration.Type.IsNull)
			{
				return parameterDeclaration.ParameterModifier != ParameterModifier.None;
			}
			return true;
		}

		public virtual void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
		{
			StartNode(memberReferenceExpression);
			memberReferenceExpression.Target.AcceptVisitor(this);
			WriteToken(Roles.Dot);
			WriteIdentifier(memberReferenceExpression.MemberNameToken);
			WriteTypeArguments(memberReferenceExpression.TypeArguments);
			EndNode(memberReferenceExpression);
		}

		public virtual void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
		{
			StartNode(namedArgumentExpression);
			WriteIdentifier(namedArgumentExpression.NameToken);
			WriteToken(Roles.Colon);
			Space();
			namedArgumentExpression.Expression.AcceptVisitor(this);
			EndNode(namedArgumentExpression);
		}

		public virtual void VisitNamedExpression(NamedExpression namedExpression)
		{
			StartNode(namedExpression);
			WriteIdentifier(namedExpression.NameToken);
			Space();
			WriteToken(Roles.Assign);
			Space();
			namedExpression.Expression.AcceptVisitor(this);
			EndNode(namedExpression);
		}

		public virtual void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
		{
			StartNode(nullReferenceExpression);
			writer.WritePrimitiveValue(null);
			EndNode(nullReferenceExpression);
		}

		public virtual void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
		{
			StartNode(objectCreateExpression);
			WriteKeyword(ObjectCreateExpression.NewKeywordRole);
			objectCreateExpression.Type.AcceptVisitor(this);
			bool flag = objectCreateExpression.Arguments.Any() || objectCreateExpression.Initializer.IsNull;
			if (!objectCreateExpression.LParToken.IsNull)
			{
				flag = true;
			}
			if (flag)
			{
				Space(policy.SpaceBeforeMethodCallParentheses);
				WriteCommaSeparatedListInParenthesis(objectCreateExpression.Arguments, policy.SpaceWithinMethodCallParentheses);
			}
			objectCreateExpression.Initializer.AcceptVisitor(this);
			EndNode(objectCreateExpression);
		}

		public virtual void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
		{
			StartNode(anonymousTypeCreateExpression);
			WriteKeyword(AnonymousTypeCreateExpression.NewKeywordRole);
			PrintInitializerElements(anonymousTypeCreateExpression.Initializers);
			EndNode(anonymousTypeCreateExpression);
		}

		public virtual void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
		{
			StartNode(parenthesizedExpression);
			LPar();
			Space(policy.SpacesWithinParentheses);
			parenthesizedExpression.Expression.AcceptVisitor(this);
			Space(policy.SpacesWithinParentheses);
			RPar();
			EndNode(parenthesizedExpression);
		}

		public virtual void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
		{
			StartNode(pointerReferenceExpression);
			pointerReferenceExpression.Target.AcceptVisitor(this);
			WriteToken(PointerReferenceExpression.ArrowRole);
			WriteIdentifier(pointerReferenceExpression.MemberNameToken);
			WriteTypeArguments(pointerReferenceExpression.TypeArguments);
			EndNode(pointerReferenceExpression);
		}

		public virtual void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
		{
			StartNode(primitiveExpression);
			writer.WritePrimitiveValue(primitiveExpression.Value, primitiveExpression.UnsafeLiteralValue);
			EndNode(primitiveExpression);
		}

		public virtual void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
		{
			StartNode(sizeOfExpression);
			WriteKeyword(SizeOfExpression.SizeofKeywordRole);
			LPar();
			Space(policy.SpacesWithinSizeOfParentheses);
			sizeOfExpression.Type.AcceptVisitor(this);
			Space(policy.SpacesWithinSizeOfParentheses);
			RPar();
			EndNode(sizeOfExpression);
		}

		public virtual void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
		{
			StartNode(stackAllocExpression);
			WriteKeyword(StackAllocExpression.StackallocKeywordRole);
			stackAllocExpression.Type.AcceptVisitor(this);
			WriteCommaSeparatedListInBrackets(new Expression[1]
			{
				stackAllocExpression.CountExpression
			});
			EndNode(stackAllocExpression);
		}

		public virtual void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
		{
			StartNode(thisReferenceExpression);
			WriteKeyword("this", thisReferenceExpression.Role);
			EndNode(thisReferenceExpression);
		}

		public virtual void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
		{
			StartNode(typeOfExpression);
			WriteKeyword(TypeOfExpression.TypeofKeywordRole);
			LPar();
			Space(policy.SpacesWithinTypeOfParentheses);
			typeOfExpression.Type.AcceptVisitor(this);
			Space(policy.SpacesWithinTypeOfParentheses);
			RPar();
			EndNode(typeOfExpression);
		}

		public virtual void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
		{
			StartNode(typeReferenceExpression);
			typeReferenceExpression.Type.AcceptVisitor(this);
			EndNode(typeReferenceExpression);
		}

		public virtual void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
		{
			StartNode(unaryOperatorExpression);
			UnaryOperatorType @operator = unaryOperatorExpression.Operator;
			TokenRole operatorRole = UnaryOperatorExpression.GetOperatorRole(@operator);
			switch (@operator)
			{
			case UnaryOperatorType.Await:
				WriteKeyword(operatorRole);
				break;
			default:
				WriteToken(operatorRole);
				break;
			case UnaryOperatorType.PostIncrement:
			case UnaryOperatorType.PostDecrement:
				break;
			}
			unaryOperatorExpression.Expression.AcceptVisitor(this);
			if (@operator == UnaryOperatorType.PostIncrement || @operator == UnaryOperatorType.PostDecrement)
			{
				WriteToken(operatorRole);
			}
			EndNode(unaryOperatorExpression);
		}

		public virtual void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
		{
			StartNode(uncheckedExpression);
			WriteKeyword(UncheckedExpression.UncheckedKeywordRole);
			LPar();
			Space(policy.SpacesWithinCheckedExpressionParantheses);
			uncheckedExpression.Expression.AcceptVisitor(this);
			Space(policy.SpacesWithinCheckedExpressionParantheses);
			RPar();
			EndNode(uncheckedExpression);
		}

		public virtual void VisitQueryExpression(QueryExpression queryExpression)
		{
			StartNode(queryExpression);
			bool flag = queryExpression.Parent is QueryClause && !(queryExpression.Parent is QueryContinuationClause);
			if (flag)
			{
				writer.Indent();
				NewLine();
			}
			bool flag2 = true;
			foreach (QueryClause clause in queryExpression.Clauses)
			{
				if (flag2)
				{
					flag2 = false;
				}
				else if (!(clause is QueryContinuationClause))
				{
					NewLine();
				}
				clause.AcceptVisitor(this);
			}
			if (flag)
			{
				writer.Unindent();
			}
			EndNode(queryExpression);
		}

		public virtual void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
		{
			StartNode(queryContinuationClause);
			queryContinuationClause.PrecedingQuery.AcceptVisitor(this);
			Space();
			WriteKeyword(QueryContinuationClause.IntoKeywordRole);
			Space();
			WriteIdentifier(queryContinuationClause.IdentifierToken);
			EndNode(queryContinuationClause);
		}

		public virtual void VisitQueryFromClause(QueryFromClause queryFromClause)
		{
			StartNode(queryFromClause);
			WriteKeyword(QueryFromClause.FromKeywordRole);
			queryFromClause.Type.AcceptVisitor(this);
			Space();
			WriteIdentifier(queryFromClause.IdentifierToken);
			Space();
			WriteKeyword(QueryFromClause.InKeywordRole);
			Space();
			queryFromClause.Expression.AcceptVisitor(this);
			EndNode(queryFromClause);
		}

		public virtual void VisitQueryLetClause(QueryLetClause queryLetClause)
		{
			StartNode(queryLetClause);
			WriteKeyword(QueryLetClause.LetKeywordRole);
			Space();
			WriteIdentifier(queryLetClause.IdentifierToken);
			Space(policy.SpaceAroundAssignment);
			WriteToken(Roles.Assign);
			Space(policy.SpaceAroundAssignment);
			queryLetClause.Expression.AcceptVisitor(this);
			EndNode(queryLetClause);
		}

		public virtual void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
		{
			StartNode(queryWhereClause);
			WriteKeyword(QueryWhereClause.WhereKeywordRole);
			Space();
			queryWhereClause.Condition.AcceptVisitor(this);
			EndNode(queryWhereClause);
		}

		public virtual void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
		{
			StartNode(queryJoinClause);
			WriteKeyword(QueryJoinClause.JoinKeywordRole);
			queryJoinClause.Type.AcceptVisitor(this);
			Space();
			WriteIdentifier(queryJoinClause.JoinIdentifierToken);
			Space();
			WriteKeyword(QueryJoinClause.InKeywordRole);
			Space();
			queryJoinClause.InExpression.AcceptVisitor(this);
			Space();
			WriteKeyword(QueryJoinClause.OnKeywordRole);
			Space();
			queryJoinClause.OnExpression.AcceptVisitor(this);
			Space();
			WriteKeyword(QueryJoinClause.EqualsKeywordRole);
			Space();
			queryJoinClause.EqualsExpression.AcceptVisitor(this);
			if (queryJoinClause.IsGroupJoin)
			{
				Space();
				WriteKeyword(QueryJoinClause.IntoKeywordRole);
				WriteIdentifier(queryJoinClause.IntoIdentifierToken);
			}
			EndNode(queryJoinClause);
		}

		public virtual void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
		{
			StartNode(queryOrderClause);
			WriteKeyword(QueryOrderClause.OrderbyKeywordRole);
			Space();
			WriteCommaSeparatedList(queryOrderClause.Orderings);
			EndNode(queryOrderClause);
		}

		public virtual void VisitQueryOrdering(QueryOrdering queryOrdering)
		{
			StartNode(queryOrdering);
			queryOrdering.Expression.AcceptVisitor(this);
			switch (queryOrdering.Direction)
			{
			case QueryOrderingDirection.Ascending:
				Space();
				WriteKeyword(QueryOrdering.AscendingKeywordRole);
				break;
			case QueryOrderingDirection.Descending:
				Space();
				WriteKeyword(QueryOrdering.DescendingKeywordRole);
				break;
			}
			EndNode(queryOrdering);
		}

		public virtual void VisitQuerySelectClause(QuerySelectClause querySelectClause)
		{
			StartNode(querySelectClause);
			WriteKeyword(QuerySelectClause.SelectKeywordRole);
			Space();
			querySelectClause.Expression.AcceptVisitor(this);
			EndNode(querySelectClause);
		}

		public virtual void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
		{
			StartNode(queryGroupClause);
			WriteKeyword(QueryGroupClause.GroupKeywordRole);
			Space();
			queryGroupClause.Projection.AcceptVisitor(this);
			Space();
			WriteKeyword(QueryGroupClause.ByKeywordRole);
			Space();
			queryGroupClause.Key.AcceptVisitor(this);
			EndNode(queryGroupClause);
		}

		public virtual void VisitAttribute(Attribute attribute)
		{
			StartNode(attribute);
			attribute.Type.AcceptVisitor(this);
			if (attribute.Arguments.Count != 0 || !attribute.GetChildByRole(Roles.LPar).IsNull)
			{
				Space(policy.SpaceBeforeMethodCallParentheses);
				WriteCommaSeparatedListInParenthesis(attribute.Arguments, policy.SpaceWithinMethodCallParentheses);
			}
			EndNode(attribute);
		}

		public virtual void VisitAttributeSection(AttributeSection attributeSection)
		{
			StartNode(attributeSection);
			WriteToken(Roles.LBracket);
			if (!string.IsNullOrEmpty(attributeSection.AttributeTarget))
			{
				WriteKeyword(attributeSection.AttributeTarget, Roles.Identifier);
				WriteToken(Roles.Colon);
				Space();
			}
			WriteCommaSeparatedList(attributeSection.Attributes);
			WriteToken(Roles.RBracket);
			if (attributeSection.Parent is ParameterDeclaration || attributeSection.Parent is TypeParameterDeclaration)
			{
				Space();
			}
			else
			{
				NewLine();
			}
			EndNode(attributeSection);
		}

		public virtual void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
		{
			StartNode(delegateDeclaration);
			WriteAttributes(delegateDeclaration.Attributes);
			WriteModifiers(delegateDeclaration.ModifierTokens);
			WriteKeyword(Roles.DelegateKeyword);
			delegateDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WriteIdentifier(delegateDeclaration.NameToken);
			WriteTypeParameters(delegateDeclaration.TypeParameters);
			Space(policy.SpaceBeforeDelegateDeclarationParentheses);
			WriteCommaSeparatedListInParenthesis(delegateDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			foreach (Constraint constraint in delegateDeclaration.Constraints)
			{
				constraint.AcceptVisitor(this);
			}
			Semicolon();
			EndNode(delegateDeclaration);
		}

		public virtual void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			StartNode(namespaceDeclaration);
			WriteKeyword(Roles.NamespaceKeyword);
			namespaceDeclaration.NamespaceName.AcceptVisitor(this);
			OpenBrace(policy.NamespaceBraceStyle);
			foreach (AstNode member in namespaceDeclaration.Members)
			{
				member.AcceptVisitor(this);
				MaybeNewLinesAfterUsings(member);
			}
			CloseBrace(policy.NamespaceBraceStyle);
			OptionalSemicolon(namespaceDeclaration.LastChild);
			NewLine();
			EndNode(namespaceDeclaration);
		}

		public virtual void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			StartNode(typeDeclaration);
			WriteAttributes(typeDeclaration.Attributes);
			WriteModifiers(typeDeclaration.ModifierTokens);
			BraceStyle style;
			switch (typeDeclaration.ClassType)
			{
			case ClassType.Enum:
				WriteKeyword(Roles.EnumKeyword);
				style = policy.EnumBraceStyle;
				break;
			case ClassType.Interface:
				WriteKeyword(Roles.InterfaceKeyword);
				style = policy.InterfaceBraceStyle;
				break;
			case ClassType.Struct:
				WriteKeyword(Roles.StructKeyword);
				style = policy.StructBraceStyle;
				break;
			default:
				WriteKeyword(Roles.ClassKeyword);
				style = policy.ClassBraceStyle;
				break;
			}
			WriteIdentifier(typeDeclaration.NameToken);
			WriteTypeParameters(typeDeclaration.TypeParameters);
			if (typeDeclaration.BaseTypes.Any())
			{
				Space();
				WriteToken(Roles.Colon);
				Space();
				WriteCommaSeparatedList(typeDeclaration.BaseTypes);
			}
			foreach (Constraint constraint in typeDeclaration.Constraints)
			{
				constraint.AcceptVisitor(this);
			}
			OpenBrace(style);
			if (typeDeclaration.ClassType == ClassType.Enum)
			{
				bool flag = true;
				AstNode astNode = null;
				foreach (EntityDeclaration member in typeDeclaration.Members)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						Comma(member, noSpaceAfterComma: true);
						NewLine();
					}
					astNode = member;
					member.AcceptVisitor(this);
				}
				if (astNode != null)
				{
					OptionalComma(astNode.NextSibling);
				}
				NewLine();
			}
			else
			{
				bool flag2 = true;
				foreach (EntityDeclaration member2 in typeDeclaration.Members)
				{
					if (!flag2)
					{
						for (int i = 0; i < policy.MinimumBlankLinesBetweenMembers; i++)
						{
							NewLine();
						}
					}
					flag2 = false;
					member2.AcceptVisitor(this);
				}
			}
			CloseBrace(style);
			OptionalSemicolon(typeDeclaration.LastChild);
			NewLine();
			EndNode(typeDeclaration);
		}

		public virtual void VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
		{
			StartNode(usingAliasDeclaration);
			WriteKeyword(UsingAliasDeclaration.UsingKeywordRole);
			WriteIdentifier(usingAliasDeclaration.GetChildByRole(UsingAliasDeclaration.AliasRole));
			Space(policy.SpaceAroundEqualityOperator);
			WriteToken(Roles.Assign);
			Space(policy.SpaceAroundEqualityOperator);
			usingAliasDeclaration.Import.AcceptVisitor(this);
			Semicolon();
			EndNode(usingAliasDeclaration);
		}

		public virtual void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
		{
			StartNode(usingDeclaration);
			WriteKeyword(UsingDeclaration.UsingKeywordRole);
			usingDeclaration.Import.AcceptVisitor(this);
			Semicolon();
			EndNode(usingDeclaration);
		}

		public virtual void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
		{
			StartNode(externAliasDeclaration);
			WriteKeyword(Roles.ExternKeyword);
			Space();
			WriteKeyword(Roles.AliasKeyword);
			Space();
			WriteIdentifier(externAliasDeclaration.NameToken);
			Semicolon();
			EndNode(externAliasDeclaration);
		}

		public virtual void VisitBlockStatement(BlockStatement blockStatement)
		{
			WriteBlock(blockStatement, policy.StatementBraceStyle);
			NewLine();
		}

		protected virtual void WriteBlock(BlockStatement blockStatement, BraceStyle style)
		{
			StartNode(blockStatement);
			OpenBrace(style);
			foreach (Statement statement in blockStatement.Statements)
			{
				statement.AcceptVisitor(this);
			}
			EndNode(blockStatement);
			CloseBrace(style);
		}

		public virtual void VisitBreakStatement(BreakStatement breakStatement)
		{
			StartNode(breakStatement);
			WriteKeyword("break", BreakStatement.BreakKeywordRole);
			Semicolon();
			EndNode(breakStatement);
		}

		public virtual void VisitCheckedStatement(CheckedStatement checkedStatement)
		{
			StartNode(checkedStatement);
			WriteKeyword(CheckedStatement.CheckedKeywordRole);
			checkedStatement.Body.AcceptVisitor(this);
			EndNode(checkedStatement);
		}

		public virtual void VisitContinueStatement(ContinueStatement continueStatement)
		{
			StartNode(continueStatement);
			WriteKeyword("continue", ContinueStatement.ContinueKeywordRole);
			Semicolon();
			EndNode(continueStatement);
		}

		public virtual void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
		{
			StartNode(doWhileStatement);
			WriteKeyword(DoWhileStatement.DoKeywordRole);
			WriteEmbeddedStatement(doWhileStatement.EmbeddedStatement, policy.WhileNewLinePlacement);
			WriteKeyword(DoWhileStatement.WhileKeywordRole);
			Space(policy.SpaceBeforeWhileParentheses);
			LPar();
			Space(policy.SpacesWithinWhileParentheses);
			doWhileStatement.Condition.AcceptVisitor(this);
			Space(policy.SpacesWithinWhileParentheses);
			RPar();
			Semicolon();
			EndNode(doWhileStatement);
		}

		public virtual void VisitEmptyStatement(EmptyStatement emptyStatement)
		{
			StartNode(emptyStatement);
			Semicolon();
			EndNode(emptyStatement);
		}

		public virtual void VisitExpressionStatement(ExpressionStatement expressionStatement)
		{
			StartNode(expressionStatement);
			expressionStatement.Expression.AcceptVisitor(this);
			Semicolon();
			EndNode(expressionStatement);
		}

		public virtual void VisitFixedStatement(FixedStatement fixedStatement)
		{
			StartNode(fixedStatement);
			WriteKeyword(FixedStatement.FixedKeywordRole);
			Space(policy.SpaceBeforeUsingParentheses);
			LPar();
			Space(policy.SpacesWithinUsingParentheses);
			fixedStatement.Type.AcceptVisitor(this);
			Space();
			WriteCommaSeparatedList(fixedStatement.Variables);
			Space(policy.SpacesWithinUsingParentheses);
			RPar();
			WriteEmbeddedStatement(fixedStatement.EmbeddedStatement);
			EndNode(fixedStatement);
		}

		public virtual void VisitForeachStatement(ForeachStatement foreachStatement)
		{
			StartNode(foreachStatement);
			WriteKeyword(ForeachStatement.ForeachKeywordRole);
			Space(policy.SpaceBeforeForeachParentheses);
			LPar();
			Space(policy.SpacesWithinForeachParentheses);
			foreachStatement.VariableType.AcceptVisitor(this);
			Space();
			WriteIdentifier(foreachStatement.VariableNameToken);
			WriteKeyword(ForeachStatement.InKeywordRole);
			Space();
			foreachStatement.InExpression.AcceptVisitor(this);
			Space(policy.SpacesWithinForeachParentheses);
			RPar();
			WriteEmbeddedStatement(foreachStatement.EmbeddedStatement);
			EndNode(foreachStatement);
		}

		public virtual void VisitForStatement(ForStatement forStatement)
		{
			StartNode(forStatement);
			WriteKeyword(ForStatement.ForKeywordRole);
			Space(policy.SpaceBeforeForParentheses);
			LPar();
			Space(policy.SpacesWithinForParentheses);
			WriteCommaSeparatedList(forStatement.Initializers);
			Space(policy.SpaceBeforeForSemicolon);
			WriteToken(Roles.Semicolon);
			Space(policy.SpaceAfterForSemicolon);
			forStatement.Condition.AcceptVisitor(this);
			Space(policy.SpaceBeforeForSemicolon);
			WriteToken(Roles.Semicolon);
			if (forStatement.Iterators.Any())
			{
				Space(policy.SpaceAfterForSemicolon);
				WriteCommaSeparatedList(forStatement.Iterators);
			}
			Space(policy.SpacesWithinForParentheses);
			RPar();
			WriteEmbeddedStatement(forStatement.EmbeddedStatement);
			EndNode(forStatement);
		}

		public virtual void VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
		{
			StartNode(gotoCaseStatement);
			WriteKeyword(GotoCaseStatement.GotoKeywordRole);
			WriteKeyword(GotoCaseStatement.CaseKeywordRole);
			Space();
			gotoCaseStatement.LabelExpression.AcceptVisitor(this);
			Semicolon();
			EndNode(gotoCaseStatement);
		}

		public virtual void VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
		{
			StartNode(gotoDefaultStatement);
			WriteKeyword(GotoDefaultStatement.GotoKeywordRole);
			WriteKeyword(GotoDefaultStatement.DefaultKeywordRole);
			Semicolon();
			EndNode(gotoDefaultStatement);
		}

		public virtual void VisitGotoStatement(GotoStatement gotoStatement)
		{
			StartNode(gotoStatement);
			WriteKeyword(GotoStatement.GotoKeywordRole);
			WriteIdentifier(gotoStatement.GetChildByRole(Roles.Identifier));
			Semicolon();
			EndNode(gotoStatement);
		}

		public virtual void VisitIfElseStatement(IfElseStatement ifElseStatement)
		{
			StartNode(ifElseStatement);
			WriteKeyword(IfElseStatement.IfKeywordRole);
			Space(policy.SpaceBeforeIfParentheses);
			LPar();
			Space(policy.SpacesWithinIfParentheses);
			ifElseStatement.Condition.AcceptVisitor(this);
			Space(policy.SpacesWithinIfParentheses);
			RPar();
			if (ifElseStatement.FalseStatement.IsNull)
			{
				WriteEmbeddedStatement(ifElseStatement.TrueStatement);
			}
			else
			{
				WriteEmbeddedStatement(ifElseStatement.TrueStatement, policy.ElseNewLinePlacement);
				WriteKeyword(IfElseStatement.ElseKeywordRole);
				if (ifElseStatement.FalseStatement is IfElseStatement)
				{
					ifElseStatement.FalseStatement.AcceptVisitor(this);
				}
				else
				{
					WriteEmbeddedStatement(ifElseStatement.FalseStatement);
				}
			}
			EndNode(ifElseStatement);
		}

		public virtual void VisitLabelStatement(LabelStatement labelStatement)
		{
			StartNode(labelStatement);
			WriteIdentifier(labelStatement.GetChildByRole(Roles.Identifier));
			WriteToken(Roles.Colon);
			bool flag = false;
			for (AstNode nextSibling = labelStatement.NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
			{
				if (nextSibling.Role == labelStatement.Role)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				WriteToken(Roles.Semicolon);
			}
			NewLine();
			EndNode(labelStatement);
		}

		public virtual void VisitLockStatement(LockStatement lockStatement)
		{
			StartNode(lockStatement);
			WriteKeyword(LockStatement.LockKeywordRole);
			Space(policy.SpaceBeforeLockParentheses);
			LPar();
			Space(policy.SpacesWithinLockParentheses);
			lockStatement.Expression.AcceptVisitor(this);
			Space(policy.SpacesWithinLockParentheses);
			RPar();
			WriteEmbeddedStatement(lockStatement.EmbeddedStatement);
			EndNode(lockStatement);
		}

		public virtual void VisitReturnStatement(ReturnStatement returnStatement)
		{
			StartNode(returnStatement);
			WriteKeyword(ReturnStatement.ReturnKeywordRole);
			if (!returnStatement.Expression.IsNull)
			{
				Space();
				returnStatement.Expression.AcceptVisitor(this);
			}
			Semicolon();
			EndNode(returnStatement);
		}

		public virtual void VisitSwitchStatement(SwitchStatement switchStatement)
		{
			StartNode(switchStatement);
			WriteKeyword(SwitchStatement.SwitchKeywordRole);
			Space(policy.SpaceBeforeSwitchParentheses);
			LPar();
			Space(policy.SpacesWithinSwitchParentheses);
			switchStatement.Expression.AcceptVisitor(this);
			Space(policy.SpacesWithinSwitchParentheses);
			RPar();
			OpenBrace(policy.StatementBraceStyle);
			if (!policy.IndentSwitchBody)
			{
				writer.Unindent();
			}
			foreach (SwitchSection switchSection in switchStatement.SwitchSections)
			{
				switchSection.AcceptVisitor(this);
			}
			if (!policy.IndentSwitchBody)
			{
				writer.Indent();
			}
			CloseBrace(policy.StatementBraceStyle);
			NewLine();
			EndNode(switchStatement);
		}

		public virtual void VisitSwitchSection(SwitchSection switchSection)
		{
			StartNode(switchSection);
			bool flag = true;
			foreach (CaseLabel caseLabel in switchSection.CaseLabels)
			{
				if (!flag)
				{
					NewLine();
				}
				caseLabel.AcceptVisitor(this);
				flag = false;
			}
			bool flag2 = switchSection.Statements.Count == 1 && switchSection.Statements.Single() is BlockStatement;
			if (policy.IndentCaseBody && !flag2)
			{
				writer.Indent();
			}
			if (!flag2)
			{
				NewLine();
			}
			foreach (Statement statement in switchSection.Statements)
			{
				statement.AcceptVisitor(this);
			}
			if (policy.IndentCaseBody && !flag2)
			{
				writer.Unindent();
			}
			EndNode(switchSection);
		}

		public virtual void VisitCaseLabel(CaseLabel caseLabel)
		{
			StartNode(caseLabel);
			if (caseLabel.Expression.IsNull)
			{
				WriteKeyword(CaseLabel.DefaultKeywordRole);
			}
			else
			{
				WriteKeyword(CaseLabel.CaseKeywordRole);
				Space();
				caseLabel.Expression.AcceptVisitor(this);
			}
			WriteToken(Roles.Colon);
			EndNode(caseLabel);
		}

		public virtual void VisitThrowStatement(ThrowStatement throwStatement)
		{
			StartNode(throwStatement);
			WriteKeyword(ThrowStatement.ThrowKeywordRole);
			if (!throwStatement.Expression.IsNull)
			{
				Space();
				throwStatement.Expression.AcceptVisitor(this);
			}
			Semicolon();
			EndNode(throwStatement);
		}

		public virtual void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
		{
			StartNode(tryCatchStatement);
			WriteKeyword(TryCatchStatement.TryKeywordRole);
			WriteBlock(tryCatchStatement.TryBlock, policy.StatementBraceStyle);
			foreach (CatchClause catchClause in tryCatchStatement.CatchClauses)
			{
				if (policy.CatchNewLinePlacement == NewLinePlacement.SameLine)
				{
					Space();
				}
				else
				{
					NewLine();
				}
				catchClause.AcceptVisitor(this);
			}
			if (!tryCatchStatement.FinallyBlock.IsNull)
			{
				if (policy.FinallyNewLinePlacement == NewLinePlacement.SameLine)
				{
					Space();
				}
				else
				{
					NewLine();
				}
				WriteKeyword(TryCatchStatement.FinallyKeywordRole);
				WriteBlock(tryCatchStatement.FinallyBlock, policy.StatementBraceStyle);
			}
			NewLine();
			EndNode(tryCatchStatement);
		}

		public virtual void VisitCatchClause(CatchClause catchClause)
		{
			StartNode(catchClause);
			WriteKeyword(CatchClause.CatchKeywordRole);
			if (!catchClause.Type.IsNull)
			{
				Space(policy.SpaceBeforeCatchParentheses);
				LPar();
				Space(policy.SpacesWithinCatchParentheses);
				catchClause.Type.AcceptVisitor(this);
				if (!string.IsNullOrEmpty(catchClause.VariableName))
				{
					Space();
					WriteIdentifier(catchClause.VariableNameToken);
				}
				Space(policy.SpacesWithinCatchParentheses);
				RPar();
			}
			if (!catchClause.Condition.IsNull)
			{
				Space();
				WriteKeyword(CatchClause.WhenKeywordRole);
				Space(policy.SpaceBeforeIfParentheses);
				LPar();
				Space(policy.SpacesWithinIfParentheses);
				catchClause.Condition.AcceptVisitor(this);
				Space(policy.SpacesWithinIfParentheses);
				RPar();
			}
			WriteBlock(catchClause.Body, policy.StatementBraceStyle);
			EndNode(catchClause);
		}

		public virtual void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
		{
			StartNode(uncheckedStatement);
			WriteKeyword(UncheckedStatement.UncheckedKeywordRole);
			uncheckedStatement.Body.AcceptVisitor(this);
			EndNode(uncheckedStatement);
		}

		public virtual void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
		{
			StartNode(unsafeStatement);
			WriteKeyword(UnsafeStatement.UnsafeKeywordRole);
			unsafeStatement.Body.AcceptVisitor(this);
			EndNode(unsafeStatement);
		}

		public virtual void VisitUsingStatement(UsingStatement usingStatement)
		{
			StartNode(usingStatement);
			WriteKeyword(UsingStatement.UsingKeywordRole);
			Space(policy.SpaceBeforeUsingParentheses);
			LPar();
			Space(policy.SpacesWithinUsingParentheses);
			usingStatement.ResourceAcquisition.AcceptVisitor(this);
			Space(policy.SpacesWithinUsingParentheses);
			RPar();
			WriteEmbeddedStatement(usingStatement.EmbeddedStatement);
			EndNode(usingStatement);
		}

		public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
		{
			StartNode(variableDeclarationStatement);
			WriteModifiers(variableDeclarationStatement.GetChildrenByRole(VariableDeclarationStatement.ModifierRole));
			variableDeclarationStatement.Type.AcceptVisitor(this);
			Space();
			WriteCommaSeparatedList(variableDeclarationStatement.Variables);
			Semicolon();
			EndNode(variableDeclarationStatement);
		}

		public virtual void VisitWhileStatement(WhileStatement whileStatement)
		{
			StartNode(whileStatement);
			WriteKeyword(WhileStatement.WhileKeywordRole);
			Space(policy.SpaceBeforeWhileParentheses);
			LPar();
			Space(policy.SpacesWithinWhileParentheses);
			whileStatement.Condition.AcceptVisitor(this);
			Space(policy.SpacesWithinWhileParentheses);
			RPar();
			WriteEmbeddedStatement(whileStatement.EmbeddedStatement);
			EndNode(whileStatement);
		}

		public virtual void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
		{
			StartNode(yieldBreakStatement);
			WriteKeyword(YieldBreakStatement.YieldKeywordRole);
			WriteKeyword(YieldBreakStatement.BreakKeywordRole);
			Semicolon();
			EndNode(yieldBreakStatement);
		}

		public virtual void VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
		{
			StartNode(yieldReturnStatement);
			WriteKeyword(YieldReturnStatement.YieldKeywordRole);
			WriteKeyword(YieldReturnStatement.ReturnKeywordRole);
			Space();
			yieldReturnStatement.Expression.AcceptVisitor(this);
			Semicolon();
			EndNode(yieldReturnStatement);
		}

		public virtual void VisitAccessor(Accessor accessor)
		{
			StartNode(accessor);
			WriteAttributes(accessor.Attributes);
			WriteModifiers(accessor.ModifierTokens);
			BraceStyle style = policy.StatementBraceStyle;
			if (accessor.Role == PropertyDeclaration.GetterRole)
			{
				WriteKeyword("get", PropertyDeclaration.GetKeywordRole);
				style = policy.PropertyGetBraceStyle;
			}
			else if (accessor.Role == PropertyDeclaration.SetterRole)
			{
				WriteKeyword("set", PropertyDeclaration.SetKeywordRole);
				style = policy.PropertySetBraceStyle;
			}
			else if (accessor.Role == CustomEventDeclaration.AddAccessorRole)
			{
				WriteKeyword("add", CustomEventDeclaration.AddKeywordRole);
				style = policy.EventAddBraceStyle;
			}
			else if (accessor.Role == CustomEventDeclaration.RemoveAccessorRole)
			{
				WriteKeyword("remove", CustomEventDeclaration.RemoveKeywordRole);
				style = policy.EventRemoveBraceStyle;
			}
			WriteMethodBody(accessor.Body, style);
			EndNode(accessor);
		}

		public virtual void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
		{
			StartNode(constructorDeclaration);
			WriteAttributes(constructorDeclaration.Attributes);
			WriteModifiers(constructorDeclaration.ModifierTokens);
			TypeDeclaration typeDeclaration = constructorDeclaration.Parent as TypeDeclaration;
			if (typeDeclaration != null && typeDeclaration.Name != constructorDeclaration.Name)
			{
				WriteIdentifier((Identifier)typeDeclaration.NameToken.Clone());
			}
			else
			{
				WriteIdentifier(constructorDeclaration.NameToken);
			}
			Space(policy.SpaceBeforeConstructorDeclarationParentheses);
			WriteCommaSeparatedListInParenthesis(constructorDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			if (!constructorDeclaration.Initializer.IsNull)
			{
				Space();
				constructorDeclaration.Initializer.AcceptVisitor(this);
			}
			WriteMethodBody(constructorDeclaration.Body, policy.ConstructorBraceStyle);
			EndNode(constructorDeclaration);
		}

		public virtual void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
		{
			StartNode(constructorInitializer);
			WriteToken(Roles.Colon);
			Space();
			if (constructorInitializer.ConstructorInitializerType == ConstructorInitializerType.This)
			{
				WriteKeyword(ConstructorInitializer.ThisKeywordRole);
			}
			else
			{
				WriteKeyword(ConstructorInitializer.BaseKeywordRole);
			}
			Space(policy.SpaceBeforeMethodCallParentheses);
			WriteCommaSeparatedListInParenthesis(constructorInitializer.Arguments, policy.SpaceWithinMethodCallParentheses);
			EndNode(constructorInitializer);
		}

		public virtual void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
		{
			StartNode(destructorDeclaration);
			WriteAttributes(destructorDeclaration.Attributes);
			WriteModifiers(destructorDeclaration.ModifierTokens);
			if (destructorDeclaration.ModifierTokens.Any())
			{
				Space();
			}
			WriteToken(DestructorDeclaration.TildeRole);
			TypeDeclaration typeDeclaration = destructorDeclaration.Parent as TypeDeclaration;
			if (typeDeclaration != null && typeDeclaration.Name != destructorDeclaration.Name)
			{
				WriteIdentifier((Identifier)typeDeclaration.NameToken.Clone());
			}
			else
			{
				WriteIdentifier(destructorDeclaration.NameToken);
			}
			Space(policy.SpaceBeforeConstructorDeclarationParentheses);
			LPar();
			RPar();
			WriteMethodBody(destructorDeclaration.Body, policy.DestructorBraceStyle);
			EndNode(destructorDeclaration);
		}

		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
		{
			StartNode(enumMemberDeclaration);
			WriteAttributes(enumMemberDeclaration.Attributes);
			WriteModifiers(enumMemberDeclaration.ModifierTokens);
			WriteIdentifier(enumMemberDeclaration.NameToken);
			if (!enumMemberDeclaration.Initializer.IsNull)
			{
				Space(policy.SpaceAroundAssignment);
				WriteToken(Roles.Assign);
				Space(policy.SpaceAroundAssignment);
				enumMemberDeclaration.Initializer.AcceptVisitor(this);
			}
			EndNode(enumMemberDeclaration);
		}

		public virtual void VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			StartNode(eventDeclaration);
			WriteAttributes(eventDeclaration.Attributes);
			WriteModifiers(eventDeclaration.ModifierTokens);
			WriteKeyword(EventDeclaration.EventKeywordRole);
			eventDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WriteCommaSeparatedList(eventDeclaration.Variables);
			Semicolon();
			EndNode(eventDeclaration);
		}

		public virtual void VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
		{
			StartNode(customEventDeclaration);
			WriteAttributes(customEventDeclaration.Attributes);
			WriteModifiers(customEventDeclaration.ModifierTokens);
			WriteKeyword(CustomEventDeclaration.EventKeywordRole);
			customEventDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WritePrivateImplementationType(customEventDeclaration.PrivateImplementationType);
			WriteIdentifier(customEventDeclaration.NameToken);
			OpenBrace(policy.EventBraceStyle);
			foreach (AstNode child in customEventDeclaration.Children)
			{
				if (child.Role == CustomEventDeclaration.AddAccessorRole || child.Role == CustomEventDeclaration.RemoveAccessorRole)
				{
					child.AcceptVisitor(this);
				}
			}
			CloseBrace(policy.EventBraceStyle);
			NewLine();
			EndNode(customEventDeclaration);
		}

		public virtual void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
		{
			StartNode(fieldDeclaration);
			WriteAttributes(fieldDeclaration.Attributes);
			WriteModifiers(fieldDeclaration.ModifierTokens);
			fieldDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WriteCommaSeparatedList(fieldDeclaration.Variables);
			Semicolon();
			EndNode(fieldDeclaration);
		}

		public virtual void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
		{
			StartNode(fixedFieldDeclaration);
			WriteAttributes(fixedFieldDeclaration.Attributes);
			WriteModifiers(fixedFieldDeclaration.ModifierTokens);
			WriteKeyword(FixedFieldDeclaration.FixedKeywordRole);
			Space();
			fixedFieldDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WriteCommaSeparatedList(fixedFieldDeclaration.Variables);
			Semicolon();
			EndNode(fixedFieldDeclaration);
		}

		public virtual void VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
		{
			StartNode(fixedVariableInitializer);
			WriteIdentifier(fixedVariableInitializer.NameToken);
			if (!fixedVariableInitializer.CountExpression.IsNull)
			{
				WriteToken(Roles.LBracket);
				Space(policy.SpacesWithinBrackets);
				fixedVariableInitializer.CountExpression.AcceptVisitor(this);
				Space(policy.SpacesWithinBrackets);
				WriteToken(Roles.RBracket);
			}
			EndNode(fixedVariableInitializer);
		}

		public virtual void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
		{
			StartNode(indexerDeclaration);
			WriteAttributes(indexerDeclaration.Attributes);
			WriteModifiers(indexerDeclaration.ModifierTokens);
			indexerDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WritePrivateImplementationType(indexerDeclaration.PrivateImplementationType);
			WriteKeyword(IndexerDeclaration.ThisKeywordRole);
			Space(policy.SpaceBeforeMethodDeclarationParentheses);
			WriteCommaSeparatedListInBrackets(indexerDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			OpenBrace(policy.PropertyBraceStyle);
			foreach (AstNode child in indexerDeclaration.Children)
			{
				if (child.Role == IndexerDeclaration.GetterRole || child.Role == IndexerDeclaration.SetterRole)
				{
					child.AcceptVisitor(this);
				}
			}
			CloseBrace(policy.PropertyBraceStyle);
			NewLine();
			EndNode(indexerDeclaration);
		}

		public virtual void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			StartNode(methodDeclaration);
			WriteAttributes(methodDeclaration.Attributes);
			WriteModifiers(methodDeclaration.ModifierTokens);
			methodDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WritePrivateImplementationType(methodDeclaration.PrivateImplementationType);
			WriteIdentifier(methodDeclaration.NameToken);
			WriteTypeParameters(methodDeclaration.TypeParameters);
			Space(policy.SpaceBeforeMethodDeclarationParentheses);
			WriteCommaSeparatedListInParenthesis(methodDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			foreach (Constraint constraint in methodDeclaration.Constraints)
			{
				constraint.AcceptVisitor(this);
			}
			WriteMethodBody(methodDeclaration.Body, policy.MethodBraceStyle);
			EndNode(methodDeclaration);
		}

		public virtual void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
		{
			StartNode(operatorDeclaration);
			WriteAttributes(operatorDeclaration.Attributes);
			WriteModifiers(operatorDeclaration.ModifierTokens);
			if (operatorDeclaration.OperatorType == OperatorType.Explicit)
			{
				WriteKeyword(OperatorDeclaration.ExplicitRole);
			}
			else if (operatorDeclaration.OperatorType == OperatorType.Implicit)
			{
				WriteKeyword(OperatorDeclaration.ImplicitRole);
			}
			else
			{
				operatorDeclaration.ReturnType.AcceptVisitor(this);
			}
			WriteKeyword(OperatorDeclaration.OperatorKeywordRole);
			Space();
			if (operatorDeclaration.OperatorType == OperatorType.Explicit || operatorDeclaration.OperatorType == OperatorType.Implicit)
			{
				operatorDeclaration.ReturnType.AcceptVisitor(this);
			}
			else
			{
				WriteToken(OperatorDeclaration.GetToken(operatorDeclaration.OperatorType), OperatorDeclaration.GetRole(operatorDeclaration.OperatorType));
			}
			Space(policy.SpaceBeforeMethodDeclarationParentheses);
			WriteCommaSeparatedListInParenthesis(operatorDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
			WriteMethodBody(operatorDeclaration.Body, policy.MethodBraceStyle);
			EndNode(operatorDeclaration);
		}

		public virtual void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
		{
			StartNode(parameterDeclaration);
			WriteAttributes(parameterDeclaration.Attributes);
			switch (parameterDeclaration.ParameterModifier)
			{
			case ParameterModifier.Ref:
				WriteKeyword(ParameterDeclaration.RefModifierRole);
				break;
			case ParameterModifier.Out:
				WriteKeyword(ParameterDeclaration.OutModifierRole);
				break;
			case ParameterModifier.Params:
				WriteKeyword(ParameterDeclaration.ParamsModifierRole);
				break;
			case ParameterModifier.This:
				WriteKeyword(ParameterDeclaration.ThisModifierRole);
				break;
			}
			parameterDeclaration.Type.AcceptVisitor(this);
			if (!parameterDeclaration.Type.IsNull && !string.IsNullOrEmpty(parameterDeclaration.Name))
			{
				Space();
			}
			if (!string.IsNullOrEmpty(parameterDeclaration.Name))
			{
				WriteIdentifier(parameterDeclaration.NameToken);
			}
			if (!parameterDeclaration.DefaultExpression.IsNull)
			{
				Space(policy.SpaceAroundAssignment);
				WriteToken(Roles.Assign);
				Space(policy.SpaceAroundAssignment);
				parameterDeclaration.DefaultExpression.AcceptVisitor(this);
			}
			EndNode(parameterDeclaration);
		}

		public virtual void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
		{
			StartNode(propertyDeclaration);
			WriteAttributes(propertyDeclaration.Attributes);
			WriteModifiers(propertyDeclaration.ModifierTokens);
			propertyDeclaration.ReturnType.AcceptVisitor(this);
			Space();
			WritePrivateImplementationType(propertyDeclaration.PrivateImplementationType);
			WriteIdentifier(propertyDeclaration.NameToken);
			OpenBrace(policy.PropertyBraceStyle);
			foreach (AstNode child in propertyDeclaration.Children)
			{
				if (child.Role == IndexerDeclaration.GetterRole || child.Role == IndexerDeclaration.SetterRole)
				{
					child.AcceptVisitor(this);
				}
			}
			CloseBrace(policy.PropertyBraceStyle);
			NewLine();
			EndNode(propertyDeclaration);
		}

		public virtual void VisitVariableInitializer(VariableInitializer variableInitializer)
		{
			StartNode(variableInitializer);
			WriteIdentifier(variableInitializer.NameToken);
			if (!variableInitializer.Initializer.IsNull)
			{
				Space(policy.SpaceAroundAssignment);
				WriteToken(Roles.Assign);
				Space(policy.SpaceAroundAssignment);
				variableInitializer.Initializer.AcceptVisitor(this);
			}
			EndNode(variableInitializer);
		}

		private void MaybeNewLinesAfterUsings(AstNode node)
		{
			AstNode nextSibling = node.NextSibling;
			while (nextSibling is WhitespaceNode || nextSibling is NewLineNode)
			{
				nextSibling = nextSibling.NextSibling;
			}
			if ((node is UsingDeclaration || node is UsingAliasDeclaration) && !(nextSibling is UsingDeclaration) && !(nextSibling is UsingAliasDeclaration))
			{
				for (int i = 0; i < policy.MinimumBlankLinesAfterUsings; i++)
				{
					NewLine();
				}
			}
		}

		public virtual void VisitSyntaxTree(SyntaxTree syntaxTree)
		{
			foreach (AstNode child in syntaxTree.Children)
			{
				child.AcceptVisitor(this);
				MaybeNewLinesAfterUsings(child);
			}
		}

		public virtual void VisitSimpleType(SimpleType simpleType)
		{
			StartNode(simpleType);
			WriteIdentifier(simpleType.IdentifierToken);
			WriteTypeArguments(simpleType.TypeArguments);
			EndNode(simpleType);
		}

		public virtual void VisitMemberType(MemberType memberType)
		{
			StartNode(memberType);
			memberType.Target.AcceptVisitor(this);
			if (memberType.IsDoubleColon)
			{
				WriteToken(Roles.DoubleColon);
			}
			else
			{
				WriteToken(Roles.Dot);
			}
			WriteIdentifier(memberType.MemberNameToken);
			WriteTypeArguments(memberType.TypeArguments);
			EndNode(memberType);
		}

		public virtual void VisitComposedType(ComposedType composedType)
		{
			StartNode(composedType);
			if (composedType.HasRefSpecifier)
			{
				WriteKeyword(ComposedType.RefRole);
			}
			composedType.BaseType.AcceptVisitor(this);
			if (composedType.HasNullableSpecifier)
			{
				WriteToken(ComposedType.NullableRole);
			}
			for (int i = 0; i < composedType.PointerRank; i++)
			{
				WriteToken(ComposedType.PointerRole);
			}
			foreach (ArraySpecifier arraySpecifier in composedType.ArraySpecifiers)
			{
				arraySpecifier.AcceptVisitor(this);
			}
			EndNode(composedType);
		}

		public virtual void VisitArraySpecifier(ArraySpecifier arraySpecifier)
		{
			StartNode(arraySpecifier);
			WriteToken(Roles.LBracket);
			foreach (CSharpTokenNode item in arraySpecifier.GetChildrenByRole(Roles.Comma))
			{
				CSharpTokenNode cSharpTokenNode = item;
				writer.WriteToken(Roles.Comma, ",");
			}
			WriteToken(Roles.RBracket);
			EndNode(arraySpecifier);
		}

		public virtual void VisitPrimitiveType(PrimitiveType primitiveType)
		{
			StartNode(primitiveType);
			writer.WritePrimitiveType(primitiveType.Keyword);
			EndNode(primitiveType);
		}

		public virtual void VisitComment(Comment comment)
		{
			writer.StartNode(comment);
			writer.WriteComment(comment.CommentType, comment.Content);
			writer.EndNode(comment);
		}

		public virtual void VisitNewLine(NewLineNode newLineNode)
		{
		}

		public virtual void VisitWhitespace(WhitespaceNode whitespaceNode)
		{
		}

		public virtual void VisitText(TextNode textNode)
		{
		}

		public virtual void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
		{
			writer.StartNode(preProcessorDirective);
			writer.WritePreProcessorDirective(preProcessorDirective.Type, preProcessorDirective.Argument);
			writer.EndNode(preProcessorDirective);
		}

		public virtual void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
		{
			StartNode(typeParameterDeclaration);
			WriteAttributes(typeParameterDeclaration.Attributes);
			switch (typeParameterDeclaration.Variance)
			{
			case VarianceModifier.Covariant:
				WriteKeyword(TypeParameterDeclaration.OutVarianceKeywordRole);
				break;
			case VarianceModifier.Contravariant:
				WriteKeyword(TypeParameterDeclaration.InVarianceKeywordRole);
				break;
			default:
				throw new NotSupportedException("Invalid value for VarianceModifier");
			case VarianceModifier.Invariant:
				break;
			}
			WriteIdentifier(typeParameterDeclaration.NameToken);
			EndNode(typeParameterDeclaration);
		}

		public virtual void VisitConstraint(Constraint constraint)
		{
			StartNode(constraint);
			Space();
			WriteKeyword(Roles.WhereKeyword);
			constraint.TypeParameter.AcceptVisitor(this);
			Space();
			WriteToken(Roles.Colon);
			Space();
			WriteCommaSeparatedList(constraint.BaseTypes);
			EndNode(constraint);
		}

		public virtual void VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
		{
			CSharpModifierToken cSharpModifierToken = cSharpTokenNode as CSharpModifierToken;
			if (cSharpModifierToken != null)
			{
				WriteKeyword(CSharpModifierToken.GetModifierName(cSharpModifierToken.Modifier), cSharpTokenNode.Role);
				return;
			}
			throw new NotSupportedException("Should never visit individual tokens");
		}

		public virtual void VisitIdentifier(Identifier identifier)
		{
			WriteIdentifier(identifier);
		}

		void IAstVisitor.VisitNullNode(AstNode nullNode)
		{
		}

		void IAstVisitor.VisitErrorNode(AstNode errorNode)
		{
			StartNode(errorNode);
			EndNode(errorNode);
		}

		public virtual void VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
		{
			StartNode(placeholder);
			VisitNodeInPattern(pattern);
			EndNode(placeholder);
		}

		private void VisitAnyNode(AnyNode anyNode)
		{
			if (!string.IsNullOrEmpty(anyNode.GroupName))
			{
				WriteIdentifier(anyNode.GroupName);
				WriteToken(Roles.Colon);
			}
		}

		private void VisitBackreference(Backreference backreference)
		{
			WriteKeyword("backreference");
			LPar();
			WriteIdentifier(backreference.ReferencedGroupName);
			RPar();
		}

		private void VisitIdentifierExpressionBackreference(IdentifierExpressionBackreference identifierExpressionBackreference)
		{
			WriteKeyword("identifierBackreference");
			LPar();
			WriteIdentifier(identifierExpressionBackreference.ReferencedGroupName);
			RPar();
		}

		private void VisitChoice(Choice choice)
		{
			WriteKeyword("choice");
			Space();
			LPar();
			NewLine();
			writer.Indent();
			foreach (INode item in (IEnumerable<INode>)choice)
			{
				VisitNodeInPattern(item);
				if (item != choice.Last())
				{
					WriteToken(Roles.Comma);
				}
				NewLine();
			}
			writer.Unindent();
			RPar();
		}

		private void VisitNamedNode(NamedNode namedNode)
		{
			if (!string.IsNullOrEmpty(namedNode.GroupName))
			{
				WriteIdentifier(namedNode.GroupName);
				WriteToken(Roles.Colon);
			}
			VisitNodeInPattern(namedNode.ChildNode);
		}

		private void VisitRepeat(Repeat repeat)
		{
			WriteKeyword("repeat");
			LPar();
			if (repeat.MinCount != 0 || repeat.MaxCount != int.MaxValue)
			{
				WriteIdentifier(repeat.MinCount.ToString());
				WriteToken(Roles.Comma);
				WriteIdentifier(repeat.MaxCount.ToString());
				WriteToken(Roles.Comma);
			}
			VisitNodeInPattern(repeat.ChildNode);
			RPar();
		}

		private void VisitOptionalNode(OptionalNode optionalNode)
		{
			WriteKeyword("optional");
			LPar();
			VisitNodeInPattern(optionalNode.ChildNode);
			RPar();
		}

		private void VisitNodeInPattern(INode childNode)
		{
			if (childNode is AstNode)
			{
				((AstNode)childNode).AcceptVisitor(this);
			}
			else if (childNode is IdentifierExpressionBackreference)
			{
				VisitIdentifierExpressionBackreference((IdentifierExpressionBackreference)childNode);
			}
			else if (childNode is Choice)
			{
				VisitChoice((Choice)childNode);
			}
			else if (childNode is AnyNode)
			{
				VisitAnyNode((AnyNode)childNode);
			}
			else if (childNode is Backreference)
			{
				VisitBackreference((Backreference)childNode);
			}
			else if (childNode is NamedNode)
			{
				VisitNamedNode((NamedNode)childNode);
			}
			else if (childNode is OptionalNode)
			{
				VisitOptionalNode((OptionalNode)childNode);
			}
			else if (childNode is Repeat)
			{
				VisitRepeat((Repeat)childNode);
			}
			else
			{
				TextWriterTokenWriter.PrintPrimitiveValue(childNode);
			}
		}

		public virtual void VisitDocumentationReference(DocumentationReference documentationReference)
		{
			StartNode(documentationReference);
			if (!documentationReference.DeclaringType.IsNull)
			{
				documentationReference.DeclaringType.AcceptVisitor(this);
				if (documentationReference.SymbolKind != SymbolKind.TypeDefinition)
				{
					WriteToken(Roles.Dot);
				}
			}
			switch (documentationReference.SymbolKind)
			{
			case SymbolKind.Indexer:
				WriteKeyword(IndexerDeclaration.ThisKeywordRole);
				break;
			case SymbolKind.Operator:
			{
				OperatorType operatorType = documentationReference.OperatorType;
				switch (operatorType)
				{
				case OperatorType.Explicit:
					WriteKeyword(OperatorDeclaration.ExplicitRole);
					break;
				case OperatorType.Implicit:
					WriteKeyword(OperatorDeclaration.ImplicitRole);
					break;
				}
				WriteKeyword(OperatorDeclaration.OperatorKeywordRole);
				Space();
				if (operatorType == OperatorType.Explicit || operatorType == OperatorType.Implicit)
				{
					documentationReference.ConversionOperatorReturnType.AcceptVisitor(this);
				}
				else
				{
					WriteToken(OperatorDeclaration.GetToken(operatorType), OperatorDeclaration.GetRole(operatorType));
				}
				break;
			}
			default:
				WriteIdentifier(documentationReference.GetChildByRole(Roles.Identifier));
				break;
			case SymbolKind.TypeDefinition:
				break;
			}
			WriteTypeArguments(documentationReference.TypeArguments);
			if (documentationReference.HasParameterList)
			{
				Space(policy.SpaceBeforeMethodDeclarationParentheses);
				if (documentationReference.SymbolKind == SymbolKind.Indexer)
				{
					WriteCommaSeparatedListInBrackets(documentationReference.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
				}
				else
				{
					WriteCommaSeparatedListInParenthesis(documentationReference.Parameters, policy.SpaceWithinMethodDeclarationParentheses);
				}
			}
			EndNode(documentationReference);
		}

		public static string ConvertString(string text)
		{
			return TextWriterTokenWriter.ConvertString(text);
		}
	}
}
