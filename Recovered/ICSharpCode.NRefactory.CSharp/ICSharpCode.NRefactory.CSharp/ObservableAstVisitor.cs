using ICSharpCode.NRefactory.PatternMatching;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ObservableAstVisitor : IAstVisitor
	{
		public event Action<SyntaxTree> EnterSyntaxTree;

		public event Action<SyntaxTree> LeaveSyntaxTree;

		public event Action<Comment> EnterComment;

		public event Action<Comment> LeaveComment;

		public event Action<NewLineNode> EnterNewLine;

		public event Action<NewLineNode> LeaveNewLine;

		public event Action<WhitespaceNode> EnterWhitespace;

		public event Action<WhitespaceNode> LeaveWhitespace;

		public event Action<TextNode> EnterText;

		public event Action<TextNode> LeaveText;

		public event Action<PreProcessorDirective> EnterPreProcessorDirective;

		public event Action<PreProcessorDirective> LeavePreProcessorDirective;

		public event Action<DocumentationReference> EnterDocumentationReference;

		public event Action<DocumentationReference> LeaveDocumentationReference;

		public event Action<Identifier> EnterIdentifier;

		public event Action<Identifier> LeaveIdentifier;

		public event Action<CSharpTokenNode> EnterCSharpTokenNode;

		public event Action<CSharpTokenNode> LeaveCSharpTokenNode;

		public event Action<PrimitiveType> EnterPrimitiveType;

		public event Action<PrimitiveType> LeavePrimitiveType;

		public event Action<ComposedType> EnterComposedType;

		public event Action<ComposedType> LeaveComposedType;

		public event Action<SimpleType> EnterSimpleType;

		public event Action<SimpleType> LeaveSimpleType;

		public event Action<MemberType> EnterMemberType;

		public event Action<MemberType> LeaveMemberType;

		public event Action<Attribute> EnterAttribute;

		public event Action<Attribute> LeaveAttribute;

		public event Action<AttributeSection> EnterAttributeSection;

		public event Action<AttributeSection> LeaveAttributeSection;

		public event Action<DelegateDeclaration> EnterDelegateDeclaration;

		public event Action<DelegateDeclaration> LeaveDelegateDeclaration;

		public event Action<NamespaceDeclaration> EnterNamespaceDeclaration;

		public event Action<NamespaceDeclaration> LeaveNamespaceDeclaration;

		public event Action<TypeDeclaration> EnterTypeDeclaration;

		public event Action<TypeDeclaration> LeaveTypeDeclaration;

		public event Action<TypeParameterDeclaration> EnterTypeParameterDeclaration;

		public event Action<TypeParameterDeclaration> LeaveTypeParameterDeclaration;

		public event Action<EnumMemberDeclaration> EnterEnumMemberDeclaration;

		public event Action<EnumMemberDeclaration> LeaveEnumMemberDeclaration;

		public event Action<UsingDeclaration> EnterUsingDeclaration;

		public event Action<UsingDeclaration> LeaveUsingDeclaration;

		public event Action<UsingAliasDeclaration> EnterUsingAliasDeclaration;

		public event Action<UsingAliasDeclaration> LeaveUsingAliasDeclaration;

		public event Action<ExternAliasDeclaration> EnterExternAliasDeclaration;

		public event Action<ExternAliasDeclaration> LeaveExternAliasDeclaration;

		public event Action<ConstructorDeclaration> EnterConstructorDeclaration;

		public event Action<ConstructorDeclaration> LeaveConstructorDeclaration;

		public event Action<ConstructorInitializer> EnterConstructorInitializer;

		public event Action<ConstructorInitializer> LeaveConstructorInitializer;

		public event Action<DestructorDeclaration> EnterDestructorDeclaration;

		public event Action<DestructorDeclaration> LeaveDestructorDeclaration;

		public event Action<EventDeclaration> EnterEventDeclaration;

		public event Action<EventDeclaration> LeaveEventDeclaration;

		public event Action<CustomEventDeclaration> EnterCustomEventDeclaration;

		public event Action<CustomEventDeclaration> LeaveCustomEventDeclaration;

		public event Action<FieldDeclaration> EnterFieldDeclaration;

		public event Action<FieldDeclaration> LeaveFieldDeclaration;

		public event Action<FixedFieldDeclaration> EnterFixedFieldDeclaration;

		public event Action<FixedFieldDeclaration> LeaveFixedFieldDeclaration;

		public event Action<FixedVariableInitializer> EnterFixedVariableInitializer;

		public event Action<FixedVariableInitializer> LeaveFixedVariableInitializer;

		public event Action<IndexerDeclaration> EnterIndexerDeclaration;

		public event Action<IndexerDeclaration> LeaveIndexerDeclaration;

		public event Action<MethodDeclaration> EnterMethodDeclaration;

		public event Action<MethodDeclaration> LeaveMethodDeclaration;

		public event Action<OperatorDeclaration> EnterOperatorDeclaration;

		public event Action<OperatorDeclaration> LeaveOperatorDeclaration;

		public event Action<PropertyDeclaration> EnterPropertyDeclaration;

		public event Action<PropertyDeclaration> LeavePropertyDeclaration;

		public event Action<Accessor> EnterAccessor;

		public event Action<Accessor> LeaveAccessor;

		public event Action<VariableInitializer> EnterVariableInitializer;

		public event Action<VariableInitializer> LeaveVariableInitializer;

		public event Action<ParameterDeclaration> EnterParameterDeclaration;

		public event Action<ParameterDeclaration> LeaveParameterDeclaration;

		public event Action<Constraint> EnterConstraint;

		public event Action<Constraint> LeaveConstraint;

		public event Action<BlockStatement> EnterBlockStatement;

		public event Action<BlockStatement> LeaveBlockStatement;

		public event Action<ExpressionStatement> EnterExpressionStatement;

		public event Action<ExpressionStatement> LeaveExpressionStatement;

		public event Action<BreakStatement> EnterBreakStatement;

		public event Action<BreakStatement> LeaveBreakStatement;

		public event Action<CheckedStatement> EnterCheckedStatement;

		public event Action<CheckedStatement> LeaveCheckedStatement;

		public event Action<ContinueStatement> EnterContinueStatement;

		public event Action<ContinueStatement> LeaveContinueStatement;

		public event Action<DoWhileStatement> EnterDoWhileStatement;

		public event Action<DoWhileStatement> LeaveDoWhileStatement;

		public event Action<EmptyStatement> EnterEmptyStatement;

		public event Action<EmptyStatement> LeaveEmptyStatement;

		public event Action<FixedStatement> EnterFixedStatement;

		public event Action<FixedStatement> LeaveFixedStatement;

		public event Action<ForeachStatement> EnterForeachStatement;

		public event Action<ForeachStatement> LeaveForeachStatement;

		public event Action<ForStatement> EnterForStatement;

		public event Action<ForStatement> LeaveForStatement;

		public event Action<GotoCaseStatement> EnterGotoCaseStatement;

		public event Action<GotoCaseStatement> LeaveGotoCaseStatement;

		public event Action<GotoDefaultStatement> EnterGotoDefaultStatement;

		public event Action<GotoDefaultStatement> LeaveGotoDefaultStatement;

		public event Action<GotoStatement> EnterGotoStatement;

		public event Action<GotoStatement> LeaveGotoStatement;

		public event Action<IfElseStatement> EnterIfElseStatement;

		public event Action<IfElseStatement> LeaveIfElseStatement;

		public event Action<LabelStatement> EnterLabelStatement;

		public event Action<LabelStatement> LeaveLabelStatement;

		public event Action<LockStatement> EnterLockStatement;

		public event Action<LockStatement> LeaveLockStatement;

		public event Action<ReturnStatement> EnterReturnStatement;

		public event Action<ReturnStatement> LeaveReturnStatement;

		public event Action<SwitchStatement> EnterSwitchStatement;

		public event Action<SwitchStatement> LeaveSwitchStatement;

		public event Action<SwitchSection> EnterSwitchSection;

		public event Action<SwitchSection> LeaveSwitchSection;

		public event Action<CaseLabel> EnterCaseLabel;

		public event Action<CaseLabel> LeaveCaseLabel;

		public event Action<ThrowStatement> EnterThrowStatement;

		public event Action<ThrowStatement> LeaveThrowStatement;

		public event Action<TryCatchStatement> EnterTryCatchStatement;

		public event Action<TryCatchStatement> LeaveTryCatchStatement;

		public event Action<CatchClause> EnterCatchClause;

		public event Action<CatchClause> LeaveCatchClause;

		public event Action<UncheckedStatement> EnterUncheckedStatement;

		public event Action<UncheckedStatement> LeaveUncheckedStatement;

		public event Action<UnsafeStatement> EnterUnsafeStatement;

		public event Action<UnsafeStatement> LeaveUnsafeStatement;

		public event Action<UsingStatement> EnterUsingStatement;

		public event Action<UsingStatement> LeaveUsingStatement;

		public event Action<VariableDeclarationStatement> EnterVariableDeclarationStatement;

		public event Action<VariableDeclarationStatement> LeaveVariableDeclarationStatement;

		public event Action<WhileStatement> EnterWhileStatement;

		public event Action<WhileStatement> LeaveWhileStatement;

		public event Action<YieldBreakStatement> EnterYieldBreakStatement;

		public event Action<YieldBreakStatement> LeaveYieldBreakStatement;

		public event Action<YieldReturnStatement> EnterYieldReturnStatement;

		public event Action<YieldReturnStatement> LeaveYieldReturnStatement;

		public event Action<AnonymousMethodExpression> EnterAnonymousMethodExpression;

		public event Action<AnonymousMethodExpression> LeaveAnonymousMethodExpression;

		public event Action<LambdaExpression> EnterLambdaExpression;

		public event Action<LambdaExpression> LeaveLambdaExpression;

		public event Action<AssignmentExpression> EnterAssignmentExpression;

		public event Action<AssignmentExpression> LeaveAssignmentExpression;

		public event Action<BaseReferenceExpression> EnterBaseReferenceExpression;

		public event Action<BaseReferenceExpression> LeaveBaseReferenceExpression;

		public event Action<BinaryOperatorExpression> EnterBinaryOperatorExpression;

		public event Action<BinaryOperatorExpression> LeaveBinaryOperatorExpression;

		public event Action<CastExpression> EnterCastExpression;

		public event Action<CastExpression> LeaveCastExpression;

		public event Action<CheckedExpression> EnterCheckedExpression;

		public event Action<CheckedExpression> LeaveCheckedExpression;

		public event Action<ConditionalExpression> EnterConditionalExpression;

		public event Action<ConditionalExpression> LeaveConditionalExpression;

		public event Action<IdentifierExpression> EnterIdentifierExpression;

		public event Action<IdentifierExpression> LeaveIdentifierExpression;

		public event Action<IndexerExpression> EnterIndexerExpression;

		public event Action<IndexerExpression> LeaveIndexerExpression;

		public event Action<InvocationExpression> EnterInvocationExpression;

		public event Action<InvocationExpression> LeaveInvocationExpression;

		public event Action<DirectionExpression> EnterDirectionExpression;

		public event Action<DirectionExpression> LeaveDirectionExpression;

		public event Action<MemberReferenceExpression> EnterMemberReferenceExpression;

		public event Action<MemberReferenceExpression> LeaveMemberReferenceExpression;

		public event Action<NullReferenceExpression> EnterNullReferenceExpression;

		public event Action<NullReferenceExpression> LeaveNullReferenceExpression;

		public event Action<ObjectCreateExpression> EnterObjectCreateExpression;

		public event Action<ObjectCreateExpression> LeaveObjectCreateExpression;

		public event Action<AnonymousTypeCreateExpression> EnterAnonymousTypeCreateExpression;

		public event Action<AnonymousTypeCreateExpression> LeaveAnonymousTypeCreateExpression;

		public event Action<ArrayCreateExpression> EnterArrayCreateExpression;

		public event Action<ArrayCreateExpression> LeaveArrayCreateExpression;

		public event Action<ParenthesizedExpression> EnterParenthesizedExpression;

		public event Action<ParenthesizedExpression> LeaveParenthesizedExpression;

		public event Action<PointerReferenceExpression> EnterPointerReferenceExpression;

		public event Action<PointerReferenceExpression> LeavePointerReferenceExpression;

		public event Action<PrimitiveExpression> EnterPrimitiveExpression;

		public event Action<PrimitiveExpression> LeavePrimitiveExpression;

		public event Action<SizeOfExpression> EnterSizeOfExpression;

		public event Action<SizeOfExpression> LeaveSizeOfExpression;

		public event Action<StackAllocExpression> EnterStackAllocExpression;

		public event Action<StackAllocExpression> LeaveStackAllocExpression;

		public event Action<ThisReferenceExpression> EnterThisReferenceExpression;

		public event Action<ThisReferenceExpression> LeaveThisReferenceExpression;

		public event Action<TypeOfExpression> EnterTypeOfExpression;

		public event Action<TypeOfExpression> LeaveTypeOfExpression;

		public event Action<TypeReferenceExpression> EnterTypeReferenceExpression;

		public event Action<TypeReferenceExpression> LeaveTypeReferenceExpression;

		public event Action<UnaryOperatorExpression> EnterUnaryOperatorExpression;

		public event Action<UnaryOperatorExpression> LeaveUnaryOperatorExpression;

		public event Action<UncheckedExpression> EnterUncheckedExpression;

		public event Action<UncheckedExpression> LeaveUncheckedExpression;

		public event Action<QueryExpression> EnterQueryExpression;

		public event Action<QueryExpression> LeaveQueryExpression;

		public event Action<QueryContinuationClause> EnterQueryContinuationClause;

		public event Action<QueryContinuationClause> LeaveQueryContinuationClause;

		public event Action<QueryFromClause> EnterQueryFromClause;

		public event Action<QueryFromClause> LeaveQueryFromClause;

		public event Action<QueryLetClause> EnterQueryLetClause;

		public event Action<QueryLetClause> LeaveQueryLetClause;

		public event Action<QueryWhereClause> EnterQueryWhereClause;

		public event Action<QueryWhereClause> LeaveQueryWhereClause;

		public event Action<QueryJoinClause> EnterQueryJoinClause;

		public event Action<QueryJoinClause> LeaveQueryJoinClause;

		public event Action<QueryOrderClause> EnterQueryOrderClause;

		public event Action<QueryOrderClause> LeaveQueryOrderClause;

		public event Action<QueryOrdering> EnterQueryOrdering;

		public event Action<QueryOrdering> LeaveQueryOrdering;

		public event Action<QuerySelectClause> EnterQuerySelectClause;

		public event Action<QuerySelectClause> LeaveQuerySelectClause;

		public event Action<QueryGroupClause> EnterQueryGroupClause;

		public event Action<QueryGroupClause> LeaveQueryGroupClause;

		public event Action<AsExpression> EnterAsExpression;

		public event Action<AsExpression> LeaveAsExpression;

		public event Action<IsExpression> EnterIsExpression;

		public event Action<IsExpression> LeaveIsExpression;

		public event Action<DefaultValueExpression> EnterDefaultValueExpression;

		public event Action<DefaultValueExpression> LeaveDefaultValueExpression;

		public event Action<UndocumentedExpression> EnterUndocumentedExpression;

		public event Action<UndocumentedExpression> LeaveUndocumentedExpression;

		public event Action<ArrayInitializerExpression> EnterArrayInitializerExpression;

		public event Action<ArrayInitializerExpression> LeaveArrayInitializerExpression;

		public event Action<ArraySpecifier> EnterArraySpecifier;

		public event Action<ArraySpecifier> LeaveArraySpecifier;

		public event Action<NamedArgumentExpression> EnterNamedArgumentExpression;

		public event Action<NamedArgumentExpression> LeaveNamedArgumentExpression;

		public event Action<NamedExpression> EnterNamedExpression;

		public event Action<NamedExpression> LeaveNamedExpression;

		private void Visit<T>(Action<T> enter, Action<T> leave, T node) where T : AstNode
		{
			enter?.Invoke(node);
			AstNode nextSibling;
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = nextSibling)
			{
				nextSibling = astNode.NextSibling;
				astNode.AcceptVisitor(this);
			}
			leave?.Invoke(node);
		}

		void IAstVisitor.VisitNullNode(AstNode nullNode)
		{
		}

		void IAstVisitor.VisitErrorNode(AstNode nullNode)
		{
		}

		void IAstVisitor.VisitSyntaxTree(SyntaxTree unit)
		{
			Visit(this.EnterSyntaxTree, this.LeaveSyntaxTree, unit);
		}

		void IAstVisitor.VisitComment(Comment comment)
		{
			Visit(this.EnterComment, this.LeaveComment, comment);
		}

		void IAstVisitor.VisitNewLine(NewLineNode newLineNode)
		{
			Visit(this.EnterNewLine, this.LeaveNewLine, newLineNode);
		}

		void IAstVisitor.VisitWhitespace(WhitespaceNode whitespace)
		{
			Visit(this.EnterWhitespace, this.LeaveWhitespace, whitespace);
		}

		void IAstVisitor.VisitText(TextNode textNode)
		{
			Visit(this.EnterText, this.LeaveText, textNode);
		}

		void IAstVisitor.VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
		{
			Visit(this.EnterPreProcessorDirective, this.LeavePreProcessorDirective, preProcessorDirective);
		}

		void IAstVisitor.VisitDocumentationReference(DocumentationReference documentationReference)
		{
			Visit(this.EnterDocumentationReference, this.LeaveDocumentationReference, documentationReference);
		}

		void IAstVisitor.VisitIdentifier(Identifier identifier)
		{
			Visit(this.EnterIdentifier, this.LeaveIdentifier, identifier);
		}

		void IAstVisitor.VisitCSharpTokenNode(CSharpTokenNode token)
		{
			Visit(this.EnterCSharpTokenNode, this.LeaveCSharpTokenNode, token);
		}

		void IAstVisitor.VisitPrimitiveType(PrimitiveType primitiveType)
		{
			Visit(this.EnterPrimitiveType, this.LeavePrimitiveType, primitiveType);
		}

		void IAstVisitor.VisitComposedType(ComposedType composedType)
		{
			Visit(this.EnterComposedType, this.LeaveComposedType, composedType);
		}

		void IAstVisitor.VisitSimpleType(SimpleType simpleType)
		{
			Visit(this.EnterSimpleType, this.LeaveSimpleType, simpleType);
		}

		void IAstVisitor.VisitMemberType(MemberType memberType)
		{
			Visit(this.EnterMemberType, this.LeaveMemberType, memberType);
		}

		void IAstVisitor.VisitAttribute(Attribute attribute)
		{
			Visit(this.EnterAttribute, this.LeaveAttribute, attribute);
		}

		void IAstVisitor.VisitAttributeSection(AttributeSection attributeSection)
		{
			Visit(this.EnterAttributeSection, this.LeaveAttributeSection, attributeSection);
		}

		void IAstVisitor.VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
		{
			Visit(this.EnterDelegateDeclaration, this.LeaveDelegateDeclaration, delegateDeclaration);
		}

		void IAstVisitor.VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			Visit(this.EnterNamespaceDeclaration, this.LeaveNamespaceDeclaration, namespaceDeclaration);
		}

		void IAstVisitor.VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			Visit(this.EnterTypeDeclaration, this.LeaveTypeDeclaration, typeDeclaration);
		}

		void IAstVisitor.VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
		{
			Visit(this.EnterTypeParameterDeclaration, this.LeaveTypeParameterDeclaration, typeParameterDeclaration);
		}

		void IAstVisitor.VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
		{
			Visit(this.EnterEnumMemberDeclaration, this.LeaveEnumMemberDeclaration, enumMemberDeclaration);
		}

		void IAstVisitor.VisitUsingDeclaration(UsingDeclaration usingDeclaration)
		{
			Visit(this.EnterUsingDeclaration, this.LeaveUsingDeclaration, usingDeclaration);
		}

		void IAstVisitor.VisitUsingAliasDeclaration(UsingAliasDeclaration usingDeclaration)
		{
			Visit(this.EnterUsingAliasDeclaration, this.LeaveUsingAliasDeclaration, usingDeclaration);
		}

		void IAstVisitor.VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
		{
			Visit(this.EnterExternAliasDeclaration, this.LeaveExternAliasDeclaration, externAliasDeclaration);
		}

		void IAstVisitor.VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
		{
			Visit(this.EnterConstructorDeclaration, this.LeaveConstructorDeclaration, constructorDeclaration);
		}

		void IAstVisitor.VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
		{
			Visit(this.EnterConstructorInitializer, this.LeaveConstructorInitializer, constructorInitializer);
		}

		void IAstVisitor.VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
		{
			Visit(this.EnterDestructorDeclaration, this.LeaveDestructorDeclaration, destructorDeclaration);
		}

		void IAstVisitor.VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			Visit(this.EnterEventDeclaration, this.LeaveEventDeclaration, eventDeclaration);
		}

		void IAstVisitor.VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
		{
			Visit(this.EnterCustomEventDeclaration, this.LeaveCustomEventDeclaration, eventDeclaration);
		}

		void IAstVisitor.VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
		{
			Visit(this.EnterFieldDeclaration, this.LeaveFieldDeclaration, fieldDeclaration);
		}

		void IAstVisitor.VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
		{
			Visit(this.EnterFixedFieldDeclaration, this.LeaveFixedFieldDeclaration, fixedFieldDeclaration);
		}

		void IAstVisitor.VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
		{
			Visit(this.EnterFixedVariableInitializer, this.LeaveFixedVariableInitializer, fixedVariableInitializer);
		}

		void IAstVisitor.VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
		{
			Visit(this.EnterIndexerDeclaration, this.LeaveIndexerDeclaration, indexerDeclaration);
		}

		void IAstVisitor.VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			Visit(this.EnterMethodDeclaration, this.LeaveMethodDeclaration, methodDeclaration);
		}

		void IAstVisitor.VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
		{
			Visit(this.EnterOperatorDeclaration, this.LeaveOperatorDeclaration, operatorDeclaration);
		}

		void IAstVisitor.VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
		{
			Visit(this.EnterPropertyDeclaration, this.LeavePropertyDeclaration, propertyDeclaration);
		}

		void IAstVisitor.VisitAccessor(Accessor accessor)
		{
			Visit(this.EnterAccessor, this.LeaveAccessor, accessor);
		}

		void IAstVisitor.VisitVariableInitializer(VariableInitializer variableInitializer)
		{
			Visit(this.EnterVariableInitializer, this.LeaveVariableInitializer, variableInitializer);
		}

		void IAstVisitor.VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
		{
			Visit(this.EnterParameterDeclaration, this.LeaveParameterDeclaration, parameterDeclaration);
		}

		void IAstVisitor.VisitConstraint(Constraint constraint)
		{
			Visit(this.EnterConstraint, this.LeaveConstraint, constraint);
		}

		void IAstVisitor.VisitBlockStatement(BlockStatement blockStatement)
		{
			Visit(this.EnterBlockStatement, this.LeaveBlockStatement, blockStatement);
		}

		void IAstVisitor.VisitExpressionStatement(ExpressionStatement expressionStatement)
		{
			Visit(this.EnterExpressionStatement, this.LeaveExpressionStatement, expressionStatement);
		}

		void IAstVisitor.VisitBreakStatement(BreakStatement breakStatement)
		{
			Visit(this.EnterBreakStatement, this.LeaveBreakStatement, breakStatement);
		}

		void IAstVisitor.VisitCheckedStatement(CheckedStatement checkedStatement)
		{
			Visit(this.EnterCheckedStatement, this.LeaveCheckedStatement, checkedStatement);
		}

		void IAstVisitor.VisitContinueStatement(ContinueStatement continueStatement)
		{
			Visit(this.EnterContinueStatement, this.LeaveContinueStatement, continueStatement);
		}

		void IAstVisitor.VisitDoWhileStatement(DoWhileStatement doWhileStatement)
		{
			Visit(this.EnterDoWhileStatement, this.LeaveDoWhileStatement, doWhileStatement);
		}

		void IAstVisitor.VisitEmptyStatement(EmptyStatement emptyStatement)
		{
			Visit(this.EnterEmptyStatement, this.LeaveEmptyStatement, emptyStatement);
		}

		void IAstVisitor.VisitFixedStatement(FixedStatement fixedStatement)
		{
			Visit(this.EnterFixedStatement, this.LeaveFixedStatement, fixedStatement);
		}

		void IAstVisitor.VisitForeachStatement(ForeachStatement foreachStatement)
		{
			Visit(this.EnterForeachStatement, this.LeaveForeachStatement, foreachStatement);
		}

		void IAstVisitor.VisitForStatement(ForStatement forStatement)
		{
			Visit(this.EnterForStatement, this.LeaveForStatement, forStatement);
		}

		void IAstVisitor.VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
		{
			Visit(this.EnterGotoCaseStatement, this.LeaveGotoCaseStatement, gotoCaseStatement);
		}

		void IAstVisitor.VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
		{
			Visit(this.EnterGotoDefaultStatement, this.LeaveGotoDefaultStatement, gotoDefaultStatement);
		}

		void IAstVisitor.VisitGotoStatement(GotoStatement gotoStatement)
		{
			Visit(this.EnterGotoStatement, this.LeaveGotoStatement, gotoStatement);
		}

		void IAstVisitor.VisitIfElseStatement(IfElseStatement ifElseStatement)
		{
			Visit(this.EnterIfElseStatement, this.LeaveIfElseStatement, ifElseStatement);
		}

		void IAstVisitor.VisitLabelStatement(LabelStatement labelStatement)
		{
			Visit(this.EnterLabelStatement, this.LeaveLabelStatement, labelStatement);
		}

		void IAstVisitor.VisitLockStatement(LockStatement lockStatement)
		{
			Visit(this.EnterLockStatement, this.LeaveLockStatement, lockStatement);
		}

		void IAstVisitor.VisitReturnStatement(ReturnStatement returnStatement)
		{
			Visit(this.EnterReturnStatement, this.LeaveReturnStatement, returnStatement);
		}

		void IAstVisitor.VisitSwitchStatement(SwitchStatement switchStatement)
		{
			Visit(this.EnterSwitchStatement, this.LeaveSwitchStatement, switchStatement);
		}

		void IAstVisitor.VisitSwitchSection(SwitchSection switchSection)
		{
			Visit(this.EnterSwitchSection, this.LeaveSwitchSection, switchSection);
		}

		void IAstVisitor.VisitCaseLabel(CaseLabel caseLabel)
		{
			Visit(this.EnterCaseLabel, this.LeaveCaseLabel, caseLabel);
		}

		void IAstVisitor.VisitThrowStatement(ThrowStatement throwStatement)
		{
			Visit(this.EnterThrowStatement, this.LeaveThrowStatement, throwStatement);
		}

		void IAstVisitor.VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
		{
			Visit(this.EnterTryCatchStatement, this.LeaveTryCatchStatement, tryCatchStatement);
		}

		void IAstVisitor.VisitCatchClause(CatchClause catchClause)
		{
			Visit(this.EnterCatchClause, this.LeaveCatchClause, catchClause);
		}

		void IAstVisitor.VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
		{
			Visit(this.EnterUncheckedStatement, this.LeaveUncheckedStatement, uncheckedStatement);
		}

		void IAstVisitor.VisitUnsafeStatement(UnsafeStatement unsafeStatement)
		{
			Visit(this.EnterUnsafeStatement, this.LeaveUnsafeStatement, unsafeStatement);
		}

		void IAstVisitor.VisitUsingStatement(UsingStatement usingStatement)
		{
			Visit(this.EnterUsingStatement, this.LeaveUsingStatement, usingStatement);
		}

		void IAstVisitor.VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
		{
			Visit(this.EnterVariableDeclarationStatement, this.LeaveVariableDeclarationStatement, variableDeclarationStatement);
		}

		void IAstVisitor.VisitWhileStatement(WhileStatement whileStatement)
		{
			Visit(this.EnterWhileStatement, this.LeaveWhileStatement, whileStatement);
		}

		void IAstVisitor.VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
		{
			Visit(this.EnterYieldBreakStatement, this.LeaveYieldBreakStatement, yieldBreakStatement);
		}

		void IAstVisitor.VisitYieldReturnStatement(YieldReturnStatement yieldStatement)
		{
			Visit(this.EnterYieldReturnStatement, this.LeaveYieldReturnStatement, yieldStatement);
		}

		void IAstVisitor.VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
		{
			Visit(this.EnterAnonymousMethodExpression, this.LeaveAnonymousMethodExpression, anonymousMethodExpression);
		}

		void IAstVisitor.VisitLambdaExpression(LambdaExpression lambdaExpression)
		{
			Visit(this.EnterLambdaExpression, this.LeaveLambdaExpression, lambdaExpression);
		}

		void IAstVisitor.VisitAssignmentExpression(AssignmentExpression assignmentExpression)
		{
			Visit(this.EnterAssignmentExpression, this.LeaveAssignmentExpression, assignmentExpression);
		}

		void IAstVisitor.VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
		{
			Visit(this.EnterBaseReferenceExpression, this.LeaveBaseReferenceExpression, baseReferenceExpression);
		}

		void IAstVisitor.VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
		{
			Visit(this.EnterBinaryOperatorExpression, this.LeaveBinaryOperatorExpression, binaryOperatorExpression);
		}

		void IAstVisitor.VisitCastExpression(CastExpression castExpression)
		{
			Visit(this.EnterCastExpression, this.LeaveCastExpression, castExpression);
		}

		void IAstVisitor.VisitCheckedExpression(CheckedExpression checkedExpression)
		{
			Visit(this.EnterCheckedExpression, this.LeaveCheckedExpression, checkedExpression);
		}

		void IAstVisitor.VisitConditionalExpression(ConditionalExpression conditionalExpression)
		{
			Visit(this.EnterConditionalExpression, this.LeaveConditionalExpression, conditionalExpression);
		}

		void IAstVisitor.VisitIdentifierExpression(IdentifierExpression identifierExpression)
		{
			Visit(this.EnterIdentifierExpression, this.LeaveIdentifierExpression, identifierExpression);
		}

		void IAstVisitor.VisitIndexerExpression(IndexerExpression indexerExpression)
		{
			Visit(this.EnterIndexerExpression, this.LeaveIndexerExpression, indexerExpression);
		}

		void IAstVisitor.VisitInvocationExpression(InvocationExpression invocationExpression)
		{
			Visit(this.EnterInvocationExpression, this.LeaveInvocationExpression, invocationExpression);
		}

		void IAstVisitor.VisitDirectionExpression(DirectionExpression directionExpression)
		{
			Visit(this.EnterDirectionExpression, this.LeaveDirectionExpression, directionExpression);
		}

		void IAstVisitor.VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
		{
			Visit(this.EnterMemberReferenceExpression, this.LeaveMemberReferenceExpression, memberReferenceExpression);
		}

		void IAstVisitor.VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
		{
			Visit(this.EnterNullReferenceExpression, this.LeaveNullReferenceExpression, nullReferenceExpression);
		}

		void IAstVisitor.VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
		{
			Visit(this.EnterObjectCreateExpression, this.LeaveObjectCreateExpression, objectCreateExpression);
		}

		void IAstVisitor.VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
		{
			Visit(this.EnterAnonymousTypeCreateExpression, this.LeaveAnonymousTypeCreateExpression, anonymousTypeCreateExpression);
		}

		void IAstVisitor.VisitArrayCreateExpression(ArrayCreateExpression arraySCreateExpression)
		{
			Visit(this.EnterArrayCreateExpression, this.LeaveArrayCreateExpression, arraySCreateExpression);
		}

		void IAstVisitor.VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
		{
			Visit(this.EnterParenthesizedExpression, this.LeaveParenthesizedExpression, parenthesizedExpression);
		}

		void IAstVisitor.VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
		{
			Visit(this.EnterPointerReferenceExpression, this.LeavePointerReferenceExpression, pointerReferenceExpression);
		}

		void IAstVisitor.VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
		{
			Visit(this.EnterPrimitiveExpression, this.LeavePrimitiveExpression, primitiveExpression);
		}

		void IAstVisitor.VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
		{
			Visit(this.EnterSizeOfExpression, this.LeaveSizeOfExpression, sizeOfExpression);
		}

		void IAstVisitor.VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
		{
			Visit(this.EnterStackAllocExpression, this.LeaveStackAllocExpression, stackAllocExpression);
		}

		void IAstVisitor.VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
		{
			Visit(this.EnterThisReferenceExpression, this.LeaveThisReferenceExpression, thisReferenceExpression);
		}

		void IAstVisitor.VisitTypeOfExpression(TypeOfExpression typeOfExpression)
		{
			Visit(this.EnterTypeOfExpression, this.LeaveTypeOfExpression, typeOfExpression);
		}

		void IAstVisitor.VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
		{
			Visit(this.EnterTypeReferenceExpression, this.LeaveTypeReferenceExpression, typeReferenceExpression);
		}

		void IAstVisitor.VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
		{
			Visit(this.EnterUnaryOperatorExpression, this.LeaveUnaryOperatorExpression, unaryOperatorExpression);
		}

		void IAstVisitor.VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
		{
			Visit(this.EnterUncheckedExpression, this.LeaveUncheckedExpression, uncheckedExpression);
		}

		void IAstVisitor.VisitQueryExpression(QueryExpression queryExpression)
		{
			Visit(this.EnterQueryExpression, this.LeaveQueryExpression, queryExpression);
		}

		void IAstVisitor.VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
		{
			Visit(this.EnterQueryContinuationClause, this.LeaveQueryContinuationClause, queryContinuationClause);
		}

		void IAstVisitor.VisitQueryFromClause(QueryFromClause queryFromClause)
		{
			Visit(this.EnterQueryFromClause, this.LeaveQueryFromClause, queryFromClause);
		}

		void IAstVisitor.VisitQueryLetClause(QueryLetClause queryLetClause)
		{
			Visit(this.EnterQueryLetClause, this.LeaveQueryLetClause, queryLetClause);
		}

		void IAstVisitor.VisitQueryWhereClause(QueryWhereClause queryWhereClause)
		{
			Visit(this.EnterQueryWhereClause, this.LeaveQueryWhereClause, queryWhereClause);
		}

		void IAstVisitor.VisitQueryJoinClause(QueryJoinClause queryJoinClause)
		{
			Visit(this.EnterQueryJoinClause, this.LeaveQueryJoinClause, queryJoinClause);
		}

		void IAstVisitor.VisitQueryOrderClause(QueryOrderClause queryOrderClause)
		{
			Visit(this.EnterQueryOrderClause, this.LeaveQueryOrderClause, queryOrderClause);
		}

		void IAstVisitor.VisitQueryOrdering(QueryOrdering queryOrdering)
		{
			Visit(this.EnterQueryOrdering, this.LeaveQueryOrdering, queryOrdering);
		}

		void IAstVisitor.VisitQuerySelectClause(QuerySelectClause querySelectClause)
		{
			Visit(this.EnterQuerySelectClause, this.LeaveQuerySelectClause, querySelectClause);
		}

		void IAstVisitor.VisitQueryGroupClause(QueryGroupClause queryGroupClause)
		{
			Visit(this.EnterQueryGroupClause, this.LeaveQueryGroupClause, queryGroupClause);
		}

		void IAstVisitor.VisitAsExpression(AsExpression asExpression)
		{
			Visit(this.EnterAsExpression, this.LeaveAsExpression, asExpression);
		}

		void IAstVisitor.VisitIsExpression(IsExpression isExpression)
		{
			Visit(this.EnterIsExpression, this.LeaveIsExpression, isExpression);
		}

		void IAstVisitor.VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
		{
			Visit(this.EnterDefaultValueExpression, this.LeaveDefaultValueExpression, defaultValueExpression);
		}

		void IAstVisitor.VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
		{
			Visit(this.EnterUndocumentedExpression, this.LeaveUndocumentedExpression, undocumentedExpression);
		}

		void IAstVisitor.VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
		{
			Visit(this.EnterArrayInitializerExpression, this.LeaveArrayInitializerExpression, arrayInitializerExpression);
		}

		void IAstVisitor.VisitArraySpecifier(ArraySpecifier arraySpecifier)
		{
			Visit(this.EnterArraySpecifier, this.LeaveArraySpecifier, arraySpecifier);
		}

		void IAstVisitor.VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
		{
			Visit(this.EnterNamedArgumentExpression, this.LeaveNamedArgumentExpression, namedArgumentExpression);
		}

		void IAstVisitor.VisitNamedExpression(NamedExpression namedExpression)
		{
			Visit(this.EnterNamedExpression, this.LeaveNamedExpression, namedExpression);
		}

		void IAstVisitor.VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
		{
		}
	}
}
