using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class DefiniteAssignmentAnalysis
	{
		private sealed class DefiniteAssignmentNode : ControlFlowNode
		{
			public int Index;

			public DefiniteAssignmentStatus NodeStatus;

			public DefiniteAssignmentNode(Statement previousStatement, Statement nextStatement, ControlFlowNodeType type)
				: base(previousStatement, nextStatement, type)
			{
			}
		}

		private sealed class DerivedControlFlowGraphBuilder : ControlFlowGraphBuilder
		{
			protected override ControlFlowNode CreateNode(Statement previousStatement, Statement nextStatement, ControlFlowNodeType type)
			{
				return new DefiniteAssignmentNode(previousStatement, nextStatement, type);
			}
		}

		private sealed class DefiniteAssignmentVisitor : DepthFirstAstVisitor<DefiniteAssignmentStatus, DefiniteAssignmentStatus>
		{
			internal DefiniteAssignmentAnalysis analysis;

			protected override DefiniteAssignmentStatus VisitChildren(AstNode node, DefiniteAssignmentStatus data)
			{
				DefiniteAssignmentStatus definiteAssignmentStatus = data;
				for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
				{
					analysis.analysisCancellationToken.ThrowIfCancellationRequested();
					definiteAssignmentStatus = astNode.AcceptVisitor(this, definiteAssignmentStatus);
					definiteAssignmentStatus = CleanSpecialValues(definiteAssignmentStatus);
				}
				return definiteAssignmentStatus;
			}

			public override DefiniteAssignmentStatus VisitBlockStatement(BlockStatement blockStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitCheckedStatement(CheckedStatement checkedStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitUncheckedStatement(UncheckedStatement uncheckedStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitVariableInitializer(VariableInitializer variableInitializer, DefiniteAssignmentStatus data)
			{
				if (variableInitializer.Initializer.IsNull)
				{
					return data;
				}
				DefiniteAssignmentStatus result = variableInitializer.Initializer.AcceptVisitor(this, data);
				if (variableInitializer.Name == analysis.variableName)
				{
					return DefiniteAssignmentStatus.DefinitelyAssigned;
				}
				return result;
			}

			public override DefiniteAssignmentStatus VisitSwitchStatement(SwitchStatement switchStatement, DefiniteAssignmentStatus data)
			{
				return switchStatement.Expression.AcceptVisitor(this, data);
			}

			public override DefiniteAssignmentStatus VisitWhileStatement(WhileStatement whileStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitDoWhileStatement(DoWhileStatement doWhileStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitForStatement(ForStatement forStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitTryCatchStatement(TryCatchStatement tryCatchStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitForeachStatement(ForeachStatement foreachStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitUsingStatement(UsingStatement usingStatement, DefiniteAssignmentStatus data)
			{
				if (usingStatement.ResourceAcquisition is Expression)
				{
					return usingStatement.ResourceAcquisition.AcceptVisitor(this, data);
				}
				return data;
			}

			public override DefiniteAssignmentStatus VisitLockStatement(LockStatement lockStatement, DefiniteAssignmentStatus data)
			{
				return lockStatement.Expression.AcceptVisitor(this, data);
			}

			public override DefiniteAssignmentStatus VisitUnsafeStatement(UnsafeStatement unsafeStatement, DefiniteAssignmentStatus data)
			{
				return data;
			}

			public override DefiniteAssignmentStatus VisitFixedStatement(FixedStatement fixedStatement, DefiniteAssignmentStatus data)
			{
				DefiniteAssignmentStatus definiteAssignmentStatus = data;
				foreach (VariableInitializer variable in fixedStatement.Variables)
				{
					definiteAssignmentStatus = variable.AcceptVisitor(this, definiteAssignmentStatus);
				}
				return definiteAssignmentStatus;
			}

			public override DefiniteAssignmentStatus VisitDirectionExpression(DirectionExpression directionExpression, DefiniteAssignmentStatus data)
			{
				if (directionExpression.FieldDirection == FieldDirection.Out)
				{
					return HandleAssignment(directionExpression.Expression, null, data);
				}
				return VisitChildren(directionExpression, data);
			}

			public override DefiniteAssignmentStatus VisitAssignmentExpression(AssignmentExpression assignmentExpression, DefiniteAssignmentStatus data)
			{
				if (assignmentExpression.Operator == AssignmentOperatorType.Assign)
				{
					return HandleAssignment(assignmentExpression.Left, assignmentExpression.Right, data);
				}
				return VisitChildren(assignmentExpression, data);
			}

			private DefiniteAssignmentStatus HandleAssignment(Expression left, Expression right, DefiniteAssignmentStatus initialStatus)
			{
				IdentifierExpression identifierExpression = left as IdentifierExpression;
				if (identifierExpression != null && identifierExpression.Identifier == analysis.variableName)
				{
					right?.AcceptVisitor(this, initialStatus);
					return DefiniteAssignmentStatus.DefinitelyAssigned;
				}
				DefiniteAssignmentStatus status = left.AcceptVisitor(this, initialStatus);
				if (right != null)
				{
					status = right.AcceptVisitor(this, CleanSpecialValues(status));
				}
				return CleanSpecialValues(status);
			}

			public override DefiniteAssignmentStatus VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, DefiniteAssignmentStatus data)
			{
				return parenthesizedExpression.Expression.AcceptVisitor(this, data);
			}

			public override DefiniteAssignmentStatus VisitCheckedExpression(CheckedExpression checkedExpression, DefiniteAssignmentStatus data)
			{
				return checkedExpression.Expression.AcceptVisitor(this, data);
			}

			public override DefiniteAssignmentStatus VisitUncheckedExpression(UncheckedExpression uncheckedExpression, DefiniteAssignmentStatus data)
			{
				return uncheckedExpression.Expression.AcceptVisitor(this, data);
			}

			public override DefiniteAssignmentStatus VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, DefiniteAssignmentStatus data)
			{
				if (binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalAnd)
				{
					bool? flag = analysis.EvaluateCondition(binaryOperatorExpression.Left);
					if (flag == true)
					{
						return binaryOperatorExpression.Right.AcceptVisitor(this, data);
					}
					if (flag == false)
					{
						return data;
					}
					DefiniteAssignmentStatus definiteAssignmentStatus = binaryOperatorExpression.Left.AcceptVisitor(this, data);
					DefiniteAssignmentStatus data2;
					switch (definiteAssignmentStatus)
					{
					case DefiniteAssignmentStatus.AssignedAfterTrueExpression:
						data2 = DefiniteAssignmentStatus.DefinitelyAssigned;
						break;
					case DefiniteAssignmentStatus.AssignedAfterFalseExpression:
						data2 = DefiniteAssignmentStatus.PotentiallyAssigned;
						break;
					default:
						data2 = definiteAssignmentStatus;
						break;
					}
					DefiniteAssignmentStatus definiteAssignmentStatus2 = binaryOperatorExpression.Right.AcceptVisitor(this, data2);
					if (definiteAssignmentStatus == DefiniteAssignmentStatus.DefinitelyAssigned)
					{
						return DefiniteAssignmentStatus.DefinitelyAssigned;
					}
					if (definiteAssignmentStatus2 == DefiniteAssignmentStatus.DefinitelyAssigned && definiteAssignmentStatus == DefiniteAssignmentStatus.AssignedAfterFalseExpression)
					{
						return DefiniteAssignmentStatus.DefinitelyAssigned;
					}
					if (definiteAssignmentStatus2 == DefiniteAssignmentStatus.DefinitelyAssigned || definiteAssignmentStatus2 == DefiniteAssignmentStatus.AssignedAfterTrueExpression)
					{
						return DefiniteAssignmentStatus.AssignedAfterTrueExpression;
					}
					if (definiteAssignmentStatus == DefiniteAssignmentStatus.AssignedAfterFalseExpression && definiteAssignmentStatus2 == DefiniteAssignmentStatus.AssignedAfterFalseExpression)
					{
						return DefiniteAssignmentStatus.AssignedAfterFalseExpression;
					}
					return DefiniteAssignmentStatus.PotentiallyAssigned;
				}
				if (binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalOr)
				{
					bool? flag2 = analysis.EvaluateCondition(binaryOperatorExpression.Left);
					if (flag2 == false)
					{
						return binaryOperatorExpression.Right.AcceptVisitor(this, data);
					}
					if (flag2 == true)
					{
						return data;
					}
					DefiniteAssignmentStatus definiteAssignmentStatus3 = binaryOperatorExpression.Left.AcceptVisitor(this, data);
					DefiniteAssignmentStatus data3;
					switch (definiteAssignmentStatus3)
					{
					case DefiniteAssignmentStatus.AssignedAfterTrueExpression:
						data3 = DefiniteAssignmentStatus.PotentiallyAssigned;
						break;
					case DefiniteAssignmentStatus.AssignedAfterFalseExpression:
						data3 = DefiniteAssignmentStatus.DefinitelyAssigned;
						break;
					default:
						data3 = definiteAssignmentStatus3;
						break;
					}
					DefiniteAssignmentStatus definiteAssignmentStatus4 = binaryOperatorExpression.Right.AcceptVisitor(this, data3);
					if (definiteAssignmentStatus3 == DefiniteAssignmentStatus.DefinitelyAssigned)
					{
						return DefiniteAssignmentStatus.DefinitelyAssigned;
					}
					if (definiteAssignmentStatus4 == DefiniteAssignmentStatus.DefinitelyAssigned && definiteAssignmentStatus3 == DefiniteAssignmentStatus.AssignedAfterTrueExpression)
					{
						return DefiniteAssignmentStatus.DefinitelyAssigned;
					}
					if (definiteAssignmentStatus4 == DefiniteAssignmentStatus.DefinitelyAssigned || definiteAssignmentStatus4 == DefiniteAssignmentStatus.AssignedAfterFalseExpression)
					{
						return DefiniteAssignmentStatus.AssignedAfterFalseExpression;
					}
					if (definiteAssignmentStatus3 == DefiniteAssignmentStatus.AssignedAfterTrueExpression && definiteAssignmentStatus4 == DefiniteAssignmentStatus.AssignedAfterTrueExpression)
					{
						return DefiniteAssignmentStatus.AssignedAfterTrueExpression;
					}
					return DefiniteAssignmentStatus.PotentiallyAssigned;
				}
				if (binaryOperatorExpression.Operator == BinaryOperatorType.NullCoalescing)
				{
					ResolveResult resolveResult = analysis.EvaluateConstant(binaryOperatorExpression.Left);
					if (resolveResult != null && resolveResult.IsCompileTimeConstant && resolveResult.ConstantValue == null)
					{
						return binaryOperatorExpression.Right.AcceptVisitor(this, data);
					}
					DefiniteAssignmentStatus definiteAssignmentStatus5 = CleanSpecialValues(binaryOperatorExpression.Left.AcceptVisitor(this, data));
					binaryOperatorExpression.Right.AcceptVisitor(this, definiteAssignmentStatus5);
					return definiteAssignmentStatus5;
				}
				return VisitChildren(binaryOperatorExpression, data);
			}

			public override DefiniteAssignmentStatus VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, DefiniteAssignmentStatus data)
			{
				if (unaryOperatorExpression.Operator == UnaryOperatorType.Not)
				{
					DefiniteAssignmentStatus definiteAssignmentStatus = unaryOperatorExpression.Expression.AcceptVisitor(this, data);
					switch (definiteAssignmentStatus)
					{
					case DefiniteAssignmentStatus.AssignedAfterFalseExpression:
						return DefiniteAssignmentStatus.AssignedAfterTrueExpression;
					case DefiniteAssignmentStatus.AssignedAfterTrueExpression:
						return DefiniteAssignmentStatus.AssignedAfterFalseExpression;
					default:
						return definiteAssignmentStatus;
					}
				}
				return VisitChildren(unaryOperatorExpression, data);
			}

			public override DefiniteAssignmentStatus VisitConditionalExpression(ConditionalExpression conditionalExpression, DefiniteAssignmentStatus data)
			{
				bool? flag = analysis.EvaluateCondition(conditionalExpression.Condition);
				if (flag == true)
				{
					return conditionalExpression.TrueExpression.AcceptVisitor(this, data);
				}
				if (flag == false)
				{
					return conditionalExpression.FalseExpression.AcceptVisitor(this, data);
				}
				DefiniteAssignmentStatus definiteAssignmentStatus = conditionalExpression.Condition.AcceptVisitor(this, data);
				DefiniteAssignmentStatus data2;
				DefiniteAssignmentStatus data3;
				switch (definiteAssignmentStatus)
				{
				case DefiniteAssignmentStatus.AssignedAfterTrueExpression:
					data2 = DefiniteAssignmentStatus.DefinitelyAssigned;
					data3 = DefiniteAssignmentStatus.PotentiallyAssigned;
					break;
				case DefiniteAssignmentStatus.AssignedAfterFalseExpression:
					data2 = DefiniteAssignmentStatus.PotentiallyAssigned;
					data3 = DefiniteAssignmentStatus.DefinitelyAssigned;
					break;
				default:
					data2 = definiteAssignmentStatus;
					data3 = definiteAssignmentStatus;
					break;
				}
				DefiniteAssignmentStatus status = conditionalExpression.TrueExpression.AcceptVisitor(this, data2);
				return MergeStatus(b: CleanSpecialValues(conditionalExpression.FalseExpression.AcceptVisitor(this, data3)), a: CleanSpecialValues(status));
			}

			public override DefiniteAssignmentStatus VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, DefiniteAssignmentStatus data)
			{
				BlockStatement body = anonymousMethodExpression.Body;
				analysis.ChangeNodeStatus(analysis.beginNodeDict[body], data);
				return data;
			}

			public override DefiniteAssignmentStatus VisitLambdaExpression(LambdaExpression lambdaExpression, DefiniteAssignmentStatus data)
			{
				Statement statement = lambdaExpression.Body as Statement;
				if (statement != null)
				{
					analysis.ChangeNodeStatus(analysis.beginNodeDict[statement], data);
				}
				else
				{
					lambdaExpression.Body.AcceptVisitor(this, data);
				}
				return data;
			}

			public override DefiniteAssignmentStatus VisitIdentifierExpression(IdentifierExpression identifierExpression, DefiniteAssignmentStatus data)
			{
				if (data != DefiniteAssignmentStatus.DefinitelyAssigned && identifierExpression.Identifier == analysis.variableName && identifierExpression.TypeArguments.Count == 0)
				{
					analysis.unassignedVariableUses.Add(identifierExpression);
				}
				return data;
			}
		}

		private readonly DefiniteAssignmentVisitor visitor = new DefiniteAssignmentVisitor();

		private readonly List<DefiniteAssignmentNode> allNodes = new List<DefiniteAssignmentNode>();

		private readonly Dictionary<Statement, DefiniteAssignmentNode> beginNodeDict = new Dictionary<Statement, DefiniteAssignmentNode>();

		private readonly Dictionary<Statement, DefiniteAssignmentNode> endNodeDict = new Dictionary<Statement, DefiniteAssignmentNode>();

		private readonly Dictionary<Statement, DefiniteAssignmentNode> conditionNodeDict = new Dictionary<Statement, DefiniteAssignmentNode>();

		private readonly CSharpAstResolver resolver;

		private Dictionary<ControlFlowEdge, DefiniteAssignmentStatus> edgeStatus = new Dictionary<ControlFlowEdge, DefiniteAssignmentStatus>();

		private string variableName;

		private List<IdentifierExpression> unassignedVariableUses = new List<IdentifierExpression>();

		private int analyzedRangeStart;

		private int analyzedRangeEnd;

		private CancellationToken analysisCancellationToken;

		private Queue<DefiniteAssignmentNode> nodesWithModifiedInput = new Queue<DefiniteAssignmentNode>();

		public IList<IdentifierExpression> UnassignedVariableUses => unassignedVariableUses.AsReadOnly();

		public DefiniteAssignmentAnalysis(Statement rootStatement, CancellationToken cancellationToken)
			: this(rootStatement, new CSharpAstResolver(new CSharpResolver(MinimalCorlib.Instance.CreateCompilation()), rootStatement), cancellationToken)
		{
		}

		public DefiniteAssignmentAnalysis(Statement rootStatement, CSharpAstResolver resolver, CancellationToken cancellationToken)
		{
			if (rootStatement == null)
			{
				throw new ArgumentNullException("rootStatement");
			}
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			this.resolver = resolver;
			visitor.analysis = this;
			DerivedControlFlowGraphBuilder derivedControlFlowGraphBuilder = new DerivedControlFlowGraphBuilder();
			if (resolver.TypeResolveContext.Compilation.MainAssembly.UnresolvedAssembly is MinimalCorlib)
			{
				derivedControlFlowGraphBuilder.EvaluateOnlyPrimitiveConstants = true;
			}
			allNodes.AddRange(derivedControlFlowGraphBuilder.BuildControlFlowGraph(rootStatement, resolver, cancellationToken).Cast<DefiniteAssignmentNode>());
			for (int i = 0; i < allNodes.Count; i++)
			{
				DefiniteAssignmentNode definiteAssignmentNode = allNodes[i];
				definiteAssignmentNode.Index = i;
				if (definiteAssignmentNode.Type == ControlFlowNodeType.StartNode || definiteAssignmentNode.Type == ControlFlowNodeType.BetweenStatements)
				{
					for (AstNode astNode = definiteAssignmentNode.NextStatement.LastChild; astNode != null; astNode = astNode.PrevSibling)
					{
						InsertAnonymousMethods(i + 1, astNode, derivedControlFlowGraphBuilder, cancellationToken);
					}
				}
				if (definiteAssignmentNode.Type == ControlFlowNodeType.StartNode || definiteAssignmentNode.Type == ControlFlowNodeType.BetweenStatements)
				{
					beginNodeDict.Add(definiteAssignmentNode.NextStatement, definiteAssignmentNode);
				}
				if (definiteAssignmentNode.Type == ControlFlowNodeType.BetweenStatements || definiteAssignmentNode.Type == ControlFlowNodeType.EndNode)
				{
					endNodeDict.Add(definiteAssignmentNode.PreviousStatement, definiteAssignmentNode);
				}
				if (definiteAssignmentNode.Type == ControlFlowNodeType.LoopCondition)
				{
					conditionNodeDict.Add(definiteAssignmentNode.NextStatement, definiteAssignmentNode);
				}
			}
			analyzedRangeStart = 0;
			analyzedRangeEnd = allNodes.Count - 1;
		}

		private void InsertAnonymousMethods(int insertPos, AstNode node, ControlFlowGraphBuilder cfgBuilder, CancellationToken cancellationToken)
		{
			if (node is Statement)
			{
				return;
			}
			AnonymousMethodExpression anonymousMethodExpression = node as AnonymousMethodExpression;
			if (anonymousMethodExpression != null)
			{
				allNodes.InsertRange(insertPos, cfgBuilder.BuildControlFlowGraph(anonymousMethodExpression.Body, resolver, cancellationToken).Cast<DefiniteAssignmentNode>());
				return;
			}
			LambdaExpression lambdaExpression = node as LambdaExpression;
			if (lambdaExpression != null && lambdaExpression.Body is Statement)
			{
				allNodes.InsertRange(insertPos, cfgBuilder.BuildControlFlowGraph((Statement)lambdaExpression.Body, resolver, cancellationToken).Cast<DefiniteAssignmentNode>());
				return;
			}
			for (AstNode astNode = node.LastChild; astNode != null; astNode = astNode.PrevSibling)
			{
				InsertAnonymousMethods(insertPos, astNode, cfgBuilder, cancellationToken);
			}
		}

		public void SetAnalyzedRange(Statement start, Statement end, bool startInclusive = true, bool endInclusive = true)
		{
			Dictionary<Statement, DefiniteAssignmentNode> dictionary = startInclusive ? beginNodeDict : endNodeDict;
			Dictionary<Statement, DefiniteAssignmentNode> obj = endInclusive ? endNodeDict : beginNodeDict;
			int index = dictionary[start].Index;
			int index2 = obj[end].Index;
			if (index > index2)
			{
				throw new ArgumentException("The start statement must be lexically preceding the end statement");
			}
			analyzedRangeStart = index;
			analyzedRangeEnd = index2;
		}

		public void Analyze(string variable, DefiniteAssignmentStatus initialStatus = DefiniteAssignmentStatus.PotentiallyAssigned, CancellationToken cancellationToken = default(CancellationToken))
		{
			analysisCancellationToken = cancellationToken;
			variableName = variable;
			try
			{
				unassignedVariableUses.Clear();
				foreach (DefiniteAssignmentNode allNode in allNodes)
				{
					allNode.NodeStatus = DefiniteAssignmentStatus.CodeUnreachable;
					foreach (ControlFlowEdge item in allNode.Outgoing)
					{
						edgeStatus[item] = DefiniteAssignmentStatus.CodeUnreachable;
					}
				}
				ChangeNodeStatus(allNodes[analyzedRangeStart], initialStatus);
				while (nodesWithModifiedInput.Count > 0)
				{
					DefiniteAssignmentNode definiteAssignmentNode = nodesWithModifiedInput.Dequeue();
					DefiniteAssignmentStatus definiteAssignmentStatus = DefiniteAssignmentStatus.CodeUnreachable;
					foreach (ControlFlowEdge item2 in definiteAssignmentNode.Incoming)
					{
						definiteAssignmentStatus = MergeStatus(definiteAssignmentStatus, edgeStatus[item2]);
					}
					ChangeNodeStatus(definiteAssignmentNode, definiteAssignmentStatus);
				}
			}
			finally
			{
				analysisCancellationToken = CancellationToken.None;
				variableName = null;
			}
		}

		public DefiniteAssignmentStatus GetStatusBefore(Statement statement)
		{
			return beginNodeDict[statement].NodeStatus;
		}

		public DefiniteAssignmentStatus GetStatusAfter(Statement statement)
		{
			return endNodeDict[statement].NodeStatus;
		}

		public DefiniteAssignmentStatus GetStatusBeforeLoopCondition(Statement statement)
		{
			return conditionNodeDict[statement].NodeStatus;
		}

		public GraphVizGraph ExportGraph()
		{
			GraphVizGraph graphVizGraph = new GraphVizGraph();
			graphVizGraph.Title = "DefiniteAssignment - " + variableName;
			for (int i = 0; i < allNodes.Count; i++)
			{
				string str = "#" + i + " = " + allNodes[i].NodeStatus.ToString() + Environment.NewLine;
				switch (allNodes[i].Type)
				{
				case ControlFlowNodeType.StartNode:
				case ControlFlowNodeType.BetweenStatements:
					str += allNodes[i].NextStatement.ToString();
					break;
				case ControlFlowNodeType.EndNode:
					str = str + "End of " + allNodes[i].PreviousStatement.ToString();
					break;
				case ControlFlowNodeType.LoopCondition:
					str = str + "Condition in " + allNodes[i].NextStatement.ToString();
					break;
				default:
					str += allNodes[i].Type.ToString();
					break;
				}
				graphVizGraph.AddNode(new GraphVizNode(i)
				{
					label = str
				});
				foreach (ControlFlowEdge item in allNodes[i].Outgoing)
				{
					GraphVizEdge graphVizEdge = new GraphVizEdge(i, ((DefiniteAssignmentNode)item.To).Index);
					if (edgeStatus.Count > 0)
					{
						graphVizEdge.label = edgeStatus[item].ToString();
					}
					if (item.IsLeavingTryFinally)
					{
						graphVizEdge.style = "dashed";
					}
					switch (item.Type)
					{
					case ControlFlowEdgeType.ConditionTrue:
						graphVizEdge.color = "green";
						break;
					case ControlFlowEdgeType.ConditionFalse:
						graphVizEdge.color = "red";
						break;
					case ControlFlowEdgeType.Jump:
						graphVizEdge.color = "blue";
						break;
					}
					graphVizGraph.AddEdge(graphVizEdge);
				}
			}
			return graphVizGraph;
		}

		private static DefiniteAssignmentStatus MergeStatus(DefiniteAssignmentStatus a, DefiniteAssignmentStatus b)
		{
			if (a == b)
			{
				return a;
			}
			if (a == DefiniteAssignmentStatus.CodeUnreachable)
			{
				return b;
			}
			if (b == DefiniteAssignmentStatus.CodeUnreachable)
			{
				return a;
			}
			return DefiniteAssignmentStatus.PotentiallyAssigned;
		}

		private void ChangeNodeStatus(DefiniteAssignmentNode node, DefiniteAssignmentStatus inputStatus)
		{
			if (node.NodeStatus == inputStatus)
			{
				return;
			}
			node.NodeStatus = inputStatus;
			DefiniteAssignmentStatus definiteAssignmentStatus;
			switch (node.Type)
			{
			case ControlFlowNodeType.StartNode:
			case ControlFlowNodeType.BetweenStatements:
				if (!(node.NextStatement is IfElseStatement))
				{
					definiteAssignmentStatus = ((inputStatus == DefiniteAssignmentStatus.DefinitelyAssigned) ? DefiniteAssignmentStatus.DefinitelyAssigned : CleanSpecialValues(node.NextStatement.AcceptVisitor(visitor, inputStatus)));
					break;
				}
				goto case ControlFlowNodeType.LoopCondition;
			case ControlFlowNodeType.EndNode:
				definiteAssignmentStatus = inputStatus;
				if (node.PreviousStatement.Role == TryCatchStatement.FinallyBlockRole && (definiteAssignmentStatus == DefiniteAssignmentStatus.DefinitelyAssigned || definiteAssignmentStatus == DefiniteAssignmentStatus.PotentiallyAssigned))
				{
					TryCatchStatement value = (TryCatchStatement)node.PreviousStatement.Parent;
					foreach (ControlFlowEdge item in allNodes.SelectMany((DefiniteAssignmentNode n) => n.Outgoing))
					{
						if (item.IsLeavingTryFinally && item.TryFinallyStatements.Contains(value) && edgeStatus[item] == DefiniteAssignmentStatus.PotentiallyAssigned)
						{
							ChangeEdgeStatus(item, definiteAssignmentStatus);
						}
					}
				}
				break;
			case ControlFlowNodeType.LoopCondition:
			{
				ForeachStatement foreachStatement = node.NextStatement as ForeachStatement;
				if (foreachStatement != null)
				{
					definiteAssignmentStatus = CleanSpecialValues(foreachStatement.InExpression.AcceptVisitor(visitor, inputStatus));
					if (foreachStatement.VariableName == variableName)
					{
						definiteAssignmentStatus = DefiniteAssignmentStatus.DefinitelyAssigned;
					}
					break;
				}
				Expression childByRole = node.NextStatement.GetChildByRole(Roles.Condition);
				definiteAssignmentStatus = ((!childByRole.IsNull) ? childByRole.AcceptVisitor(visitor, inputStatus) : inputStatus);
				foreach (ControlFlowEdge item2 in node.Outgoing)
				{
					if (item2.Type == ControlFlowEdgeType.ConditionTrue && definiteAssignmentStatus == DefiniteAssignmentStatus.AssignedAfterTrueExpression)
					{
						ChangeEdgeStatus(item2, DefiniteAssignmentStatus.DefinitelyAssigned);
					}
					else if (item2.Type == ControlFlowEdgeType.ConditionFalse && definiteAssignmentStatus == DefiniteAssignmentStatus.AssignedAfterFalseExpression)
					{
						ChangeEdgeStatus(item2, DefiniteAssignmentStatus.DefinitelyAssigned);
					}
					else
					{
						ChangeEdgeStatus(item2, CleanSpecialValues(definiteAssignmentStatus));
					}
				}
				return;
			}
			default:
				throw new InvalidOperationException();
			}
			foreach (ControlFlowEdge item3 in node.Outgoing)
			{
				ChangeEdgeStatus(item3, definiteAssignmentStatus);
			}
		}

		private void ChangeEdgeStatus(ControlFlowEdge edge, DefiniteAssignmentStatus newStatus)
		{
			if (edgeStatus[edge] != newStatus)
			{
				if (newStatus == DefiniteAssignmentStatus.CodeUnreachable || newStatus == DefiniteAssignmentStatus.AssignedAfterFalseExpression || newStatus == DefiniteAssignmentStatus.AssignedAfterTrueExpression)
				{
					throw new InvalidOperationException();
				}
				edgeStatus[edge] = newStatus;
				DefiniteAssignmentNode definiteAssignmentNode = (DefiniteAssignmentNode)edge.To;
				if (analyzedRangeStart <= definiteAssignmentNode.Index && definiteAssignmentNode.Index <= analyzedRangeEnd)
				{
					nodesWithModifiedInput.Enqueue(definiteAssignmentNode);
				}
			}
		}

		private ResolveResult EvaluateConstant(Expression expr)
		{
			return resolver.Resolve(expr, analysisCancellationToken);
		}

		private bool? EvaluateCondition(Expression expr)
		{
			ResolveResult resolveResult = EvaluateConstant(expr);
			if (resolveResult != null && resolveResult.IsCompileTimeConstant)
			{
				return resolveResult.ConstantValue as bool?;
			}
			return null;
		}

		private static DefiniteAssignmentStatus CleanSpecialValues(DefiniteAssignmentStatus status)
		{
			switch (status)
			{
			case DefiniteAssignmentStatus.AssignedAfterTrueExpression:
				return DefiniteAssignmentStatus.PotentiallyAssigned;
			case DefiniteAssignmentStatus.AssignedAfterFalseExpression:
				return DefiniteAssignmentStatus.PotentiallyAssigned;
			default:
				return status;
			}
		}
	}
}
