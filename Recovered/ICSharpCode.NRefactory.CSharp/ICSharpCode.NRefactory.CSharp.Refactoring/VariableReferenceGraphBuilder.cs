using ICSharpCode.NRefactory.CSharp.Analysis;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	internal class VariableReferenceGraphBuilder
	{
		private class GetExpressionsVisitor : DepthFirstAstVisitor<IEnumerable<Expression>>
		{
			public override IEnumerable<Expression> VisitIfElseStatement(IfElseStatement ifElseStatement)
			{
				yield return ifElseStatement.Condition;
			}

			public override IEnumerable<Expression> VisitSwitchStatement(SwitchStatement switchStatement)
			{
				yield return switchStatement.Expression;
			}

			public override IEnumerable<Expression> VisitForStatement(ForStatement forStatement)
			{
				yield return forStatement.Condition;
			}

			public override IEnumerable<Expression> VisitDoWhileStatement(DoWhileStatement doWhileStatement)
			{
				yield return doWhileStatement.Condition;
			}

			public override IEnumerable<Expression> VisitWhileStatement(WhileStatement whileStatement)
			{
				yield return whileStatement.Condition;
			}

			public override IEnumerable<Expression> VisitForeachStatement(ForeachStatement foreachStatement)
			{
				yield return foreachStatement.InExpression;
			}

			public override IEnumerable<Expression> VisitExpressionStatement(ExpressionStatement expressionStatement)
			{
				yield return expressionStatement.Expression;
			}

			public override IEnumerable<Expression> VisitLockStatement(LockStatement lockStatement)
			{
				yield return lockStatement.Expression;
			}

			public override IEnumerable<Expression> VisitReturnStatement(ReturnStatement returnStatement)
			{
				yield return returnStatement.Expression;
			}

			public override IEnumerable<Expression> VisitThrowStatement(ThrowStatement throwStatement)
			{
				yield return throwStatement.Expression;
			}

			public override IEnumerable<Expression> VisitUsingStatement(UsingStatement usingStatement)
			{
				Expression expression = usingStatement.ResourceAcquisition as Expression;
				if (expression != null)
				{
					return new Expression[1]
					{
						expression
					};
				}
				return usingStatement.ResourceAcquisition.AcceptVisitor(this);
			}

			public override IEnumerable<Expression> VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
			{
				return from v in variableDeclarationStatement.Variables
					select v.Initializer;
			}

			public override IEnumerable<Expression> VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
			{
				yield return yieldReturnStatement.Expression;
			}

			public override IEnumerable<Expression> VisitBlockStatement(BlockStatement blockStatement)
			{
				yield break;
			}
		}

		private class CfgVariableReferenceNodeBuilder
		{
			private readonly VariableReferenceGraphBuilder variableReferenceGraphBuilder;

			private GetExpressionsVisitor getExpr = new GetExpressionsVisitor();

			private ISet<AstNode> references;

			private ISet<Statement> refStatements;

			private CSharpAstResolver resolver;

			private Dictionary<ControlFlowNode, VariableReferenceNode> nodeDict;

			public CfgVariableReferenceNodeBuilder(VariableReferenceGraphBuilder variableReferenceGraphBuilder)
			{
				this.variableReferenceGraphBuilder = variableReferenceGraphBuilder;
			}

			public VariableReferenceNode Build(ControlFlowNode startNode, ISet<AstNode> references, ISet<Statement> refStatements, CSharpAstResolver resolver)
			{
				this.references = references;
				this.refStatements = refStatements;
				this.resolver = resolver;
				nodeDict = new Dictionary<ControlFlowNode, VariableReferenceNode>();
				return AddNode(startNode);
			}

			private static bool IsValidControlFlowNode(ControlFlowNode node)
			{
				if (node.NextStatement == null)
				{
					return false;
				}
				if (node.Type == ControlFlowNodeType.LoopCondition)
				{
					if (node.NextStatement is ForeachStatement)
					{
						return false;
					}
				}
				else if (node.NextStatement is WhileStatement || node.NextStatement is DoWhileStatement || node.NextStatement is ForStatement)
				{
					return false;
				}
				return true;
			}

			private VariableReferenceNode GetStatementEndNode(VariableReferenceNode currentNode, Statement statement)
			{
				IEnumerable<Expression> expressions = statement.AcceptVisitor(getExpr);
				ExpressionNodeCreationVisitor.CreateNode(references, resolver, expressions, currentNode, out VariableReferenceNode endNode);
				return endNode;
			}

			private VariableReferenceNode AddNode(ControlFlowNode startNode)
			{
				VariableReferenceNode variableReferenceNode = new VariableReferenceNode();
				ControlFlowNode controlFlowNode = startNode;
				while (true)
				{
					if (variableReferenceGraphBuilder.ctx.CancellationToken.IsCancellationRequested)
					{
						return null;
					}
					if (nodeDict.ContainsKey(controlFlowNode))
					{
						variableReferenceNode.AddNextNode(nodeDict[controlFlowNode]);
						break;
					}
					if (controlFlowNode.Incoming.Count > 1 || controlFlowNode.Outgoing.Count > 1)
					{
						nodeDict[controlFlowNode] = variableReferenceNode;
						VariableReferenceNode variableReferenceNode2 = new VariableReferenceNode();
						variableReferenceNode.AddNextNode(variableReferenceNode2);
						variableReferenceNode = variableReferenceNode2;
					}
					nodeDict[controlFlowNode] = variableReferenceNode;
					if (IsValidControlFlowNode(controlFlowNode) && refStatements.Contains(controlFlowNode.NextStatement))
					{
						variableReferenceNode = GetStatementEndNode(variableReferenceNode, controlFlowNode.NextStatement);
					}
					if (controlFlowNode.Outgoing.Count == 1)
					{
						controlFlowNode = controlFlowNode.Outgoing[0].To;
						continue;
					}
					foreach (ControlFlowEdge item in controlFlowNode.Outgoing)
					{
						variableReferenceNode.AddNextNode(AddNode(item.To));
					}
					break;
				}
				if (!nodeDict.TryGetValue(startNode, out VariableReferenceNode value))
				{
					return new VariableReferenceNode();
				}
				return value;
			}
		}

		private class ExpressionNodeCreationVisitor : DepthFirstAstVisitor
		{
			private VariableReferenceNode startNode;

			private VariableReferenceNode endNode;

			private ISet<AstNode> references;

			private CSharpAstResolver resolver;

			private ExpressionNodeCreationVisitor(ISet<AstNode> references, CSharpAstResolver resolver, VariableReferenceNode startNode)
			{
				this.references = references;
				this.resolver = resolver;
				VariableReferenceNode obj = startNode ?? new VariableReferenceNode();
				VariableReferenceNode variableReferenceNode = obj;
				endNode = obj;
				this.startNode = variableReferenceNode;
			}

			public static VariableReferenceNode CreateNode(ISet<AstNode> references, CSharpAstResolver resolver, params Expression[] expressions)
			{
				VariableReferenceNode variableReferenceNode;
				return CreateNode(references, resolver, expressions, null, out variableReferenceNode);
			}

			public static VariableReferenceNode CreateNode(ISet<AstNode> references, CSharpAstResolver resolver, IEnumerable<Expression> expressions, VariableReferenceNode startNode, out VariableReferenceNode endNode)
			{
				startNode = (startNode ?? new VariableReferenceNode());
				endNode = startNode;
				if (expressions != null)
				{
					foreach (Expression expression in expressions)
					{
						ExpressionNodeCreationVisitor expressionNodeCreationVisitor = CreateVisitor(references, resolver, expression, endNode);
						endNode = expressionNodeCreationVisitor.endNode;
					}
					return startNode;
				}
				return startNode;
			}

			private static ExpressionNodeCreationVisitor CreateVisitor(ISet<AstNode> references, CSharpAstResolver resolver, Expression rootExpr, VariableReferenceNode startNode = null, VariableReferenceNode nextNode = null)
			{
				ExpressionNodeCreationVisitor expressionNodeCreationVisitor = new ExpressionNodeCreationVisitor(references, resolver, startNode);
				rootExpr.AcceptVisitor(expressionNodeCreationVisitor);
				if (nextNode != null)
				{
					expressionNodeCreationVisitor.endNode.AddNextNode(nextNode);
				}
				return expressionNodeCreationVisitor;
			}

			private static VariableReferenceNode CreateNode(ISet<AstNode> references, CSharpAstResolver resolver, Expression rootExpr, VariableReferenceNode startNode = null, VariableReferenceNode nextNode = null)
			{
				return CreateVisitor(references, resolver, rootExpr, startNode, nextNode).startNode;
			}

			public override void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
			{
			}

			public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
			{
			}

			public override void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
			{
			}

			public override void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
			{
			}

			public override void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
			{
			}

			public override void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
			{
			}

			public override void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
			{
			}

			public override void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
			{
			}

			public override void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
			{
			}

			public override void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
			{
			}

			public override void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
			{
			}

			public override void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
			{
				assignmentExpression.Right.AcceptVisitor(this);
				assignmentExpression.Left.AcceptVisitor(this);
			}

			public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
			{
				binaryOperatorExpression.Left.AcceptVisitor(this);
				binaryOperatorExpression.Right.AcceptVisitor(this);
			}

			public override void VisitCastExpression(CastExpression castExpression)
			{
				castExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitCheckedExpression(CheckedExpression checkedExpression)
			{
				checkedExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
			{
				conditionalExpression.Condition.AcceptVisitor(this);
				ResolveResult resolveResult = resolver.Resolve(conditionalExpression.Condition);
				if (resolveResult.ConstantValue is bool)
				{
					if ((bool)resolveResult.ConstantValue)
					{
						conditionalExpression.TrueExpression.AcceptVisitor(this);
					}
					else
					{
						conditionalExpression.FalseExpression.AcceptVisitor(this);
					}
					return;
				}
				VariableReferenceNode nextNode = new VariableReferenceNode();
				VariableReferenceNode node = CreateNode(references, resolver, conditionalExpression.TrueExpression, null, nextNode);
				VariableReferenceNode node2 = CreateNode(references, resolver, conditionalExpression.FalseExpression, null, nextNode);
				endNode.AddNextNode(node);
				endNode.AddNextNode(node2);
				endNode = nextNode;
			}

			public override void VisitIdentifierExpression(IdentifierExpression identifierExpression)
			{
				if (references.Contains(identifierExpression))
				{
					endNode.References.Add(identifierExpression);
				}
			}

			public override void VisitIndexerExpression(IndexerExpression indexerExpression)
			{
				indexerExpression.Target.AcceptVisitor(this);
				foreach (Expression argument in indexerExpression.Arguments)
				{
					argument.AcceptVisitor(this);
				}
			}

			public override void VisitInvocationExpression(InvocationExpression invocationExpression)
			{
				invocationExpression.Target.AcceptVisitor(this);
				List<Expression> list = new List<Expression>();
				foreach (Expression argument in invocationExpression.Arguments)
				{
					DirectionExpression directionExpression = argument as DirectionExpression;
					if (directionExpression != null && directionExpression.FieldDirection == FieldDirection.Out)
					{
						list.Add(directionExpression);
					}
					else
					{
						argument.AcceptVisitor(this);
					}
				}
				foreach (Expression item in list)
				{
					item.AcceptVisitor(this);
				}
			}

			public override void VisitDirectionExpression(DirectionExpression directionExpression)
			{
				directionExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
			{
				memberReferenceExpression.Target.AcceptVisitor(this);
			}

			public override void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
			{
				foreach (Expression argument in objectCreateExpression.Arguments)
				{
					argument.AcceptVisitor(this);
				}
				objectCreateExpression.Initializer.AcceptVisitor(this);
			}

			public override void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
			{
				foreach (Expression initializer in anonymousTypeCreateExpression.Initializers)
				{
					initializer.AcceptVisitor(this);
				}
			}

			public override void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
			{
				foreach (Expression argument in arrayCreateExpression.Arguments)
				{
					argument.AcceptVisitor(this);
				}
				arrayCreateExpression.Initializer.AcceptVisitor(this);
			}

			public override void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
			{
				parenthesizedExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
			{
				pointerReferenceExpression.Target.AcceptVisitor(this);
			}

			public override void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
			{
				stackAllocExpression.CountExpression.AcceptVisitor(this);
			}

			public override void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
			{
				unaryOperatorExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
			{
				uncheckedExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitAsExpression(AsExpression asExpression)
			{
				asExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitIsExpression(IsExpression isExpression)
			{
				isExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
			{
				foreach (Expression element in arrayInitializerExpression.Elements)
				{
					element.AcceptVisitor(this);
				}
			}

			public override void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
			{
				namedArgumentExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitNamedExpression(NamedExpression namedExpression)
			{
				namedExpression.Expression.AcceptVisitor(this);
			}

			public override void VisitQueryExpression(QueryExpression queryExpression)
			{
				foreach (QueryClause clause in queryExpression.Clauses)
				{
					clause.AcceptVisitor(this);
				}
			}

			public override void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
			{
				queryContinuationClause.PrecedingQuery.AcceptVisitor(this);
			}

			public override void VisitQueryFromClause(QueryFromClause queryFromClause)
			{
				queryFromClause.Expression.AcceptVisitor(this);
			}

			public override void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
			{
				queryJoinClause.InExpression.AcceptVisitor(this);
			}

			public override void VisitQueryLetClause(QueryLetClause queryLetClause)
			{
			}

			public override void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
			{
			}

			public override void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
			{
			}

			public override void VisitQueryOrdering(QueryOrdering queryOrdering)
			{
			}

			public override void VisitQuerySelectClause(QuerySelectClause querySelectClause)
			{
			}

			public override void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
			{
			}
		}

		private ControlFlowGraphBuilder cfgBuilder = new ControlFlowGraphBuilder();

		private CfgVariableReferenceNodeBuilder cfgVrNodeBuilder;

		private BaseRefactoringContext ctx;

		public VariableReferenceGraphBuilder(BaseRefactoringContext ctx)
		{
			this.ctx = ctx;
			cfgVrNodeBuilder = new CfgVariableReferenceNodeBuilder(this);
		}

		public VariableReferenceNode Build(ISet<AstNode> references, CSharpAstResolver resolver, Expression expression)
		{
			return ExpressionNodeCreationVisitor.CreateNode(references, resolver, expression);
		}

		public VariableReferenceNode Build(Statement statement, ISet<AstNode> references, ISet<Statement> refStatements, BaseRefactoringContext context)
		{
			IList<ControlFlowNode> list = cfgBuilder.BuildControlFlowGraph(statement, context.Resolver, context.CancellationToken);
			if (list.Count == 0)
			{
				return new VariableReferenceNode();
			}
			return cfgVrNodeBuilder.Build(list[0], references, refStatements, context.Resolver);
		}

		public VariableReferenceNode Build(Statement statement, ISet<AstNode> references, ISet<Statement> refStatements, CSharpAstResolver resolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			IList<ControlFlowNode> list = cfgBuilder.BuildControlFlowGraph(statement, resolver, cancellationToken);
			if (list.Count == 0)
			{
				return new VariableReferenceNode();
			}
			return cfgVrNodeBuilder.Build(list[0], references, refStatements, resolver);
		}
	}
}
