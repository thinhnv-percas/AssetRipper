using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public sealed class ReachabilityAnalysis
	{
		public class RecursiveDetectorVisitor : DepthFirstAstVisitor<bool>
		{
			public override bool VisitConditionalExpression(ConditionalExpression conditionalExpression)
			{
				if (conditionalExpression.Condition.AcceptVisitor(this))
				{
					return true;
				}
				if (!conditionalExpression.TrueExpression.AcceptVisitor(this))
				{
					return false;
				}
				return conditionalExpression.FalseExpression.AcceptVisitor(this);
			}

			public override bool VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
			{
				if (binaryOperatorExpression.Operator == BinaryOperatorType.NullCoalescing)
				{
					return binaryOperatorExpression.Left.AcceptVisitor(this);
				}
				return base.VisitBinaryOperatorExpression(binaryOperatorExpression);
			}

			public override bool VisitIfElseStatement(IfElseStatement ifElseStatement)
			{
				if (ifElseStatement.Condition.AcceptVisitor(this))
				{
					return true;
				}
				if (!ifElseStatement.TrueStatement.AcceptVisitor(this))
				{
					return false;
				}
				return ifElseStatement.FalseStatement.AcceptVisitor(this);
			}

			public override bool VisitForeachStatement(ForeachStatement foreachStatement)
			{
				return foreachStatement.InExpression.AcceptVisitor(this);
			}

			public override bool VisitForStatement(ForStatement forStatement)
			{
				if (forStatement.Initializers.Any((Statement initializer) => initializer.AcceptVisitor(this)))
				{
					return true;
				}
				return forStatement.Condition.AcceptVisitor(this);
			}

			public override bool VisitSwitchStatement(SwitchStatement switchStatement)
			{
				if (switchStatement.Expression.AcceptVisitor(this))
				{
					return true;
				}
				bool flag = false;
				foreach (SwitchSection switchSection in switchStatement.SwitchSections)
				{
					flag = (flag || switchSection.CaseLabels.Any((CaseLabel label) => label.Expression.IsNull));
					if (!switchSection.AcceptVisitor(this))
					{
						return false;
					}
				}
				return flag;
			}

			public override bool VisitBlockStatement(BlockStatement blockStatement)
			{
				return false;
			}

			protected override bool VisitChildren(AstNode node)
			{
				return VisitNodeList(node.Children);
			}

			private bool VisitNodeList(IEnumerable<AstNode> nodes)
			{
				return nodes.Any((AstNode node) => node.AcceptVisitor(this));
			}

			public override bool VisitQueryExpression(QueryExpression queryExpression)
			{
				return queryExpression.Clauses.OfType<QueryFromClause>().FirstOrDefault()?.AcceptVisitor(this) ?? true;
			}
		}

		private HashSet<Statement> reachableStatements = new HashSet<Statement>();

		private HashSet<Statement> reachableEndPoints = new HashSet<Statement>();

		private HashSet<ControlFlowNode> visitedNodes = new HashSet<ControlFlowNode>();

		private Stack<ControlFlowNode> stack = new Stack<ControlFlowNode>();

		private RecursiveDetectorVisitor recursiveDetectorVisitor;

		public IEnumerable<Statement> ReachableStatements => reachableStatements;

		private ReachabilityAnalysis()
		{
		}

		public static ReachabilityAnalysis Create(Statement statement, CSharpAstResolver resolver = null, RecursiveDetectorVisitor recursiveDetectorVisitor = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Create(new ControlFlowGraphBuilder().BuildControlFlowGraph(statement, resolver, cancellationToken), recursiveDetectorVisitor, cancellationToken);
		}

		internal static ReachabilityAnalysis Create(Statement statement, Func<AstNode, CancellationToken, ResolveResult> resolver, CSharpTypeResolveContext typeResolveContext, CancellationToken cancellationToken)
		{
			return Create(new ControlFlowGraphBuilder().BuildControlFlowGraph(statement, resolver, typeResolveContext, cancellationToken), null, cancellationToken);
		}

		public static ReachabilityAnalysis Create(IList<ControlFlowNode> controlFlowGraph, RecursiveDetectorVisitor recursiveDetectorVisitor = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (controlFlowGraph == null)
			{
				throw new ArgumentNullException("controlFlowGraph");
			}
			ReachabilityAnalysis reachabilityAnalysis = new ReachabilityAnalysis();
			reachabilityAnalysis.recursiveDetectorVisitor = recursiveDetectorVisitor;
			if (controlFlowGraph.Count > 0)
			{
				reachabilityAnalysis.stack.Push(controlFlowGraph[0]);
				while (reachabilityAnalysis.stack.Count > 0)
				{
					cancellationToken.ThrowIfCancellationRequested();
					reachabilityAnalysis.MarkReachable(reachabilityAnalysis.stack.Pop());
				}
			}
			reachabilityAnalysis.stack = null;
			reachabilityAnalysis.visitedNodes = null;
			return reachabilityAnalysis;
		}

		private void MarkReachable(ControlFlowNode node)
		{
			if (node.PreviousStatement != null)
			{
				if (node.PreviousStatement is LabelStatement)
				{
					reachableStatements.Add(node.PreviousStatement);
				}
				reachableEndPoints.Add(node.PreviousStatement);
			}
			if (node.NextStatement != null)
			{
				reachableStatements.Add(node.NextStatement);
				if (IsRecursive(node.NextStatement))
				{
					return;
				}
			}
			foreach (ControlFlowEdge item in node.Outgoing)
			{
				if (visitedNodes.Add(item.To))
				{
					stack.Push(item.To);
				}
			}
		}

		private bool IsRecursive(Statement statement)
		{
			if (recursiveDetectorVisitor != null)
			{
				return statement.AcceptVisitor(recursiveDetectorVisitor);
			}
			return false;
		}

		public bool IsReachable(Statement statement)
		{
			return reachableStatements.Contains(statement);
		}

		public bool IsEndpointReachable(Statement statement)
		{
			return reachableEndPoints.Contains(statement);
		}
	}
}
