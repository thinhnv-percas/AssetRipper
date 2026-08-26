using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class ControlFlowGraphBuilder
	{
		private sealed class NodeCreationVisitor : DepthFirstAstVisitor<ControlFlowNode, ControlFlowNode>
		{
			internal ControlFlowGraphBuilder builder;

			private Stack<ControlFlowNode> breakTargets = new Stack<ControlFlowNode>();

			private Stack<ControlFlowNode> continueTargets = new Stack<ControlFlowNode>();

			private List<ControlFlowNode> gotoCaseOrDefault = new List<ControlFlowNode>();

			internal ControlFlowEdge Connect(ControlFlowNode from, ControlFlowNode to, ControlFlowEdgeType type = ControlFlowEdgeType.Normal)
			{
				if (from == null || to == null)
				{
					return null;
				}
				ControlFlowEdge controlFlowEdge = builder.CreateEdge(from, to, type);
				from.Outgoing.Add(controlFlowEdge);
				to.Incoming.Add(controlFlowEdge);
				return controlFlowEdge;
			}

			private ControlFlowNode CreateConnectedEndNode(Statement stmt, ControlFlowNode from)
			{
				ControlFlowNode controlFlowNode = builder.CreateEndNode(stmt);
				Connect(from, controlFlowNode);
				return controlFlowNode;
			}

			protected override ControlFlowNode VisitChildren(AstNode node, ControlFlowNode data)
			{
				throw new NotSupportedException();
			}

			public override ControlFlowNode VisitBlockStatement(BlockStatement blockStatement, ControlFlowNode data)
			{
				ControlFlowNode from = HandleStatementList(blockStatement.Statements, data);
				return CreateConnectedEndNode(blockStatement, from);
			}

			private ControlFlowNode HandleStatementList(AstNodeCollection<Statement> statements, ControlFlowNode source)
			{
				ControlFlowNode controlFlowNode = null;
				foreach (Statement statement in statements)
				{
					if (controlFlowNode == null)
					{
						controlFlowNode = builder.CreateStartNode(statement);
						if (source != null)
						{
							Connect(source, controlFlowNode);
						}
					}
					controlFlowNode = statement.AcceptVisitor(this, controlFlowNode);
				}
				return controlFlowNode ?? source;
			}

			public override ControlFlowNode VisitEmptyStatement(EmptyStatement emptyStatement, ControlFlowNode data)
			{
				return CreateConnectedEndNode(emptyStatement, data);
			}

			public override ControlFlowNode VisitLabelStatement(LabelStatement labelStatement, ControlFlowNode data)
			{
				ControlFlowNode controlFlowNode = CreateConnectedEndNode(labelStatement, data);
				builder.labels[labelStatement.Label] = controlFlowNode;
				return controlFlowNode;
			}

			public override ControlFlowNode VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, ControlFlowNode data)
			{
				return CreateConnectedEndNode(variableDeclarationStatement, data);
			}

			public override ControlFlowNode VisitExpressionStatement(ExpressionStatement expressionStatement, ControlFlowNode data)
			{
				return CreateConnectedEndNode(expressionStatement, data);
			}

			public override ControlFlowNode VisitIfElseStatement(IfElseStatement ifElseStatement, ControlFlowNode data)
			{
				bool? flag = builder.EvaluateCondition(ifElseStatement.Condition);
				ControlFlowNode controlFlowNode = builder.CreateStartNode(ifElseStatement.TrueStatement);
				if (flag != false)
				{
					Connect(data, controlFlowNode, ControlFlowEdgeType.ConditionTrue);
				}
				ControlFlowNode from = ifElseStatement.TrueStatement.AcceptVisitor(this, controlFlowNode);
				ControlFlowNode controlFlowNode2 = builder.CreateStartNode(ifElseStatement.FalseStatement);
				if (flag != true)
				{
					Connect(data, controlFlowNode2, ControlFlowEdgeType.ConditionFalse);
				}
				ControlFlowNode controlFlowNode3 = ifElseStatement.FalseStatement.AcceptVisitor(this, controlFlowNode2);
				ControlFlowNode controlFlowNode4 = builder.CreateEndNode(ifElseStatement);
				Connect(from, controlFlowNode4);
				if (controlFlowNode3 != null)
				{
					Connect(controlFlowNode3, controlFlowNode4);
				}
				else if (flag != true)
				{
					Connect(data, controlFlowNode4, ControlFlowEdgeType.ConditionFalse);
				}
				return controlFlowNode4;
			}

			public override ControlFlowNode VisitSwitchStatement(SwitchStatement switchStatement, ControlFlowNode data)
			{
				ResolveResult resolveResult = builder.EvaluateConstant(switchStatement.Expression);
				SwitchSection switchSection = null;
				SwitchSection switchSection2 = null;
				foreach (SwitchSection switchSection3 in switchStatement.SwitchSections)
				{
					foreach (CaseLabel caseLabel in switchSection3.CaseLabels)
					{
						if (caseLabel.Expression.IsNull)
						{
							switchSection = switchSection3;
						}
						else if (resolveResult != null && resolveResult.IsCompileTimeConstant)
						{
							ResolveResult c = builder.EvaluateConstant(caseLabel.Expression);
							if (builder.AreEqualConstants(resolveResult, c))
							{
								switchSection2 = switchSection3;
							}
						}
					}
				}
				if (resolveResult != null && resolveResult.IsCompileTimeConstant && switchSection2 == null)
				{
					switchSection2 = switchSection;
				}
				int count = gotoCaseOrDefault.Count;
				List<ControlFlowNode> list = new List<ControlFlowNode>();
				ControlFlowNode controlFlowNode = builder.CreateEndNode(switchStatement, addToNodeList: false);
				breakTargets.Push(controlFlowNode);
				foreach (SwitchSection switchSection4 in switchStatement.SwitchSections)
				{
					int count2 = builder.nodes.Count;
					if (resolveResult == null || !resolveResult.IsCompileTimeConstant || switchSection4 == switchSection2)
					{
						HandleStatementList(switchSection4.Statements, data);
					}
					else
					{
						HandleStatementList(switchSection4.Statements, null);
					}
					list.Add((count2 < builder.nodes.Count) ? builder.nodes[count2] : null);
				}
				breakTargets.Pop();
				if (switchSection == null && switchSection2 == null)
				{
					Connect(data, controlFlowNode);
				}
				if (gotoCaseOrDefault.Count > count)
				{
					for (int i = count; i < gotoCaseOrDefault.Count; i++)
					{
						ControlFlowNode controlFlowNode2 = gotoCaseOrDefault[i];
						GotoCaseStatement gotoCaseStatement = controlFlowNode2.NextStatement as GotoCaseStatement;
						ResolveResult c2 = null;
						if (gotoCaseStatement != null)
						{
							c2 = builder.EvaluateConstant(gotoCaseStatement.LabelExpression);
						}
						int num = -1;
						int num2 = 0;
						foreach (SwitchSection switchSection5 in switchStatement.SwitchSections)
						{
							foreach (CaseLabel caseLabel2 in switchSection5.CaseLabels)
							{
								if (gotoCaseStatement != null)
								{
									if (!caseLabel2.Expression.IsNull)
									{
										ResolveResult c3 = builder.EvaluateConstant(caseLabel2.Expression);
										if (builder.AreEqualConstants(c2, c3))
										{
											num = num2;
										}
									}
								}
								else if (caseLabel2.Expression.IsNull)
								{
									num = num2;
								}
							}
							num2++;
						}
						if (num >= 0 && list[num] != null)
						{
							Connect(controlFlowNode2, list[num], ControlFlowEdgeType.Jump);
						}
						else
						{
							Connect(controlFlowNode2, controlFlowNode, ControlFlowEdgeType.Jump);
						}
					}
					gotoCaseOrDefault.RemoveRange(count, gotoCaseOrDefault.Count - count);
				}
				builder.nodes.Add(controlFlowNode);
				return controlFlowNode;
			}

			public override ControlFlowNode VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, ControlFlowNode data)
			{
				gotoCaseOrDefault.Add(data);
				return builder.CreateEndNode(gotoCaseStatement);
			}

			public override ControlFlowNode VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement, ControlFlowNode data)
			{
				gotoCaseOrDefault.Add(data);
				return builder.CreateEndNode(gotoDefaultStatement);
			}

			public override ControlFlowNode VisitWhileStatement(WhileStatement whileStatement, ControlFlowNode data)
			{
				ControlFlowNode controlFlowNode = builder.CreateEndNode(whileStatement, addToNodeList: false);
				ControlFlowNode controlFlowNode2 = builder.CreateSpecialNode(whileStatement, ControlFlowNodeType.LoopCondition);
				breakTargets.Push(controlFlowNode);
				continueTargets.Push(controlFlowNode2);
				Connect(data, controlFlowNode2);
				bool? flag = builder.EvaluateCondition(whileStatement.Condition);
				ControlFlowNode controlFlowNode3 = builder.CreateStartNode(whileStatement.EmbeddedStatement);
				if (flag != false)
				{
					Connect(controlFlowNode2, controlFlowNode3, ControlFlowEdgeType.ConditionTrue);
				}
				ControlFlowNode from = whileStatement.EmbeddedStatement.AcceptVisitor(this, controlFlowNode3);
				Connect(from, controlFlowNode2);
				if (flag != true)
				{
					Connect(controlFlowNode2, controlFlowNode, ControlFlowEdgeType.ConditionFalse);
				}
				breakTargets.Pop();
				continueTargets.Pop();
				builder.nodes.Add(controlFlowNode);
				return controlFlowNode;
			}

			public override ControlFlowNode VisitDoWhileStatement(DoWhileStatement doWhileStatement, ControlFlowNode data)
			{
				ControlFlowNode controlFlowNode = builder.CreateEndNode(doWhileStatement, addToNodeList: false);
				ControlFlowNode controlFlowNode2 = builder.CreateSpecialNode(doWhileStatement, ControlFlowNodeType.LoopCondition, addToNodeList: false);
				breakTargets.Push(controlFlowNode);
				continueTargets.Push(controlFlowNode2);
				ControlFlowNode controlFlowNode3 = builder.CreateStartNode(doWhileStatement.EmbeddedStatement);
				Connect(data, controlFlowNode3);
				ControlFlowNode from = doWhileStatement.EmbeddedStatement.AcceptVisitor(this, controlFlowNode3);
				Connect(from, controlFlowNode2);
				bool? flag;
				bool? flag2 = flag = builder.EvaluateCondition(doWhileStatement.Condition);
				if (flag != false)
				{
					Connect(controlFlowNode2, controlFlowNode3, ControlFlowEdgeType.ConditionTrue);
				}
				if (flag2 != true)
				{
					Connect(controlFlowNode2, controlFlowNode, ControlFlowEdgeType.ConditionFalse);
				}
				breakTargets.Pop();
				continueTargets.Pop();
				builder.nodes.Add(controlFlowNode2);
				builder.nodes.Add(controlFlowNode);
				return controlFlowNode;
			}

			public override ControlFlowNode VisitForStatement(ForStatement forStatement, ControlFlowNode data)
			{
				data = HandleStatementList(forStatement.Initializers, data);
				ControlFlowNode controlFlowNode = builder.CreateEndNode(forStatement, addToNodeList: false);
				ControlFlowNode controlFlowNode2 = builder.CreateSpecialNode(forStatement, ControlFlowNodeType.LoopCondition);
				Connect(data, controlFlowNode2);
				int count = builder.nodes.Count;
				ControlFlowNode controlFlowNode3 = HandleStatementList(forStatement.Iterators, null);
				ControlFlowNode controlFlowNode4;
				if (controlFlowNode3 != null)
				{
					controlFlowNode4 = builder.nodes[count];
					Connect(controlFlowNode3, controlFlowNode2);
				}
				else
				{
					controlFlowNode4 = controlFlowNode2;
				}
				breakTargets.Push(controlFlowNode);
				continueTargets.Push(controlFlowNode4);
				ControlFlowNode controlFlowNode5 = builder.CreateStartNode(forStatement.EmbeddedStatement);
				ControlFlowNode from = forStatement.EmbeddedStatement.AcceptVisitor(this, controlFlowNode5);
				Connect(from, controlFlowNode4);
				breakTargets.Pop();
				continueTargets.Pop();
				bool? obj = forStatement.Condition.IsNull ? new bool?(true) : builder.EvaluateCondition(forStatement.Condition);
				if (obj != false)
				{
					Connect(controlFlowNode2, controlFlowNode5, ControlFlowEdgeType.ConditionTrue);
				}
				if (obj != true)
				{
					Connect(controlFlowNode2, controlFlowNode, ControlFlowEdgeType.ConditionFalse);
				}
				builder.nodes.Add(controlFlowNode);
				return controlFlowNode;
			}

			private ControlFlowNode HandleEmbeddedStatement(Statement embeddedStatement, ControlFlowNode source)
			{
				if (embeddedStatement == null || embeddedStatement.IsNull)
				{
					return source;
				}
				ControlFlowNode controlFlowNode = builder.CreateStartNode(embeddedStatement);
				if (source != null)
				{
					Connect(source, controlFlowNode);
				}
				return embeddedStatement.AcceptVisitor(this, controlFlowNode);
			}

			public override ControlFlowNode VisitForeachStatement(ForeachStatement foreachStatement, ControlFlowNode data)
			{
				ControlFlowNode controlFlowNode = builder.CreateEndNode(foreachStatement, addToNodeList: false);
				ControlFlowNode controlFlowNode2 = builder.CreateSpecialNode(foreachStatement, ControlFlowNodeType.LoopCondition);
				Connect(data, controlFlowNode2);
				breakTargets.Push(controlFlowNode);
				continueTargets.Push(controlFlowNode2);
				ControlFlowNode from = HandleEmbeddedStatement(foreachStatement.EmbeddedStatement, controlFlowNode2);
				Connect(from, controlFlowNode2);
				breakTargets.Pop();
				continueTargets.Pop();
				Connect(controlFlowNode2, controlFlowNode);
				builder.nodes.Add(controlFlowNode);
				return controlFlowNode;
			}

			public override ControlFlowNode VisitBreakStatement(BreakStatement breakStatement, ControlFlowNode data)
			{
				if (breakTargets.Count > 0)
				{
					Connect(data, breakTargets.Peek(), ControlFlowEdgeType.Jump);
				}
				return builder.CreateEndNode(breakStatement);
			}

			public override ControlFlowNode VisitContinueStatement(ContinueStatement continueStatement, ControlFlowNode data)
			{
				if (continueTargets.Count > 0)
				{
					Connect(data, continueTargets.Peek(), ControlFlowEdgeType.Jump);
				}
				return builder.CreateEndNode(continueStatement);
			}

			public override ControlFlowNode VisitGotoStatement(GotoStatement gotoStatement, ControlFlowNode data)
			{
				builder.gotoStatements.Add(data);
				return builder.CreateEndNode(gotoStatement);
			}

			public override ControlFlowNode VisitReturnStatement(ReturnStatement returnStatement, ControlFlowNode data)
			{
				return builder.CreateEndNode(returnStatement);
			}

			public override ControlFlowNode VisitThrowStatement(ThrowStatement throwStatement, ControlFlowNode data)
			{
				return builder.CreateEndNode(throwStatement);
			}

			public override ControlFlowNode VisitTryCatchStatement(TryCatchStatement tryCatchStatement, ControlFlowNode data)
			{
				ControlFlowNode controlFlowNode = builder.CreateEndNode(tryCatchStatement, addToNodeList: false);
				ControlFlowEdge controlFlowEdge = Connect(HandleEmbeddedStatement(tryCatchStatement.TryBlock, data), controlFlowNode);
				if (!tryCatchStatement.FinallyBlock.IsNull)
				{
					controlFlowEdge.AddJumpOutOfTryFinally(tryCatchStatement);
				}
				foreach (CatchClause catchClause in tryCatchStatement.CatchClauses)
				{
					controlFlowEdge = Connect(HandleEmbeddedStatement(catchClause.Body, data), controlFlowNode);
					if (!tryCatchStatement.FinallyBlock.IsNull)
					{
						controlFlowEdge.AddJumpOutOfTryFinally(tryCatchStatement);
					}
				}
				if (!tryCatchStatement.FinallyBlock.IsNull)
				{
					HandleEmbeddedStatement(tryCatchStatement.FinallyBlock, data);
				}
				builder.nodes.Add(controlFlowNode);
				return controlFlowNode;
			}

			public override ControlFlowNode VisitCheckedStatement(CheckedStatement checkedStatement, ControlFlowNode data)
			{
				ControlFlowNode from = HandleEmbeddedStatement(checkedStatement.Body, data);
				return CreateConnectedEndNode(checkedStatement, from);
			}

			public override ControlFlowNode VisitUncheckedStatement(UncheckedStatement uncheckedStatement, ControlFlowNode data)
			{
				ControlFlowNode from = HandleEmbeddedStatement(uncheckedStatement.Body, data);
				return CreateConnectedEndNode(uncheckedStatement, from);
			}

			public override ControlFlowNode VisitLockStatement(LockStatement lockStatement, ControlFlowNode data)
			{
				ControlFlowNode from = HandleEmbeddedStatement(lockStatement.EmbeddedStatement, data);
				return CreateConnectedEndNode(lockStatement, from);
			}

			public override ControlFlowNode VisitUsingStatement(UsingStatement usingStatement, ControlFlowNode data)
			{
				data = HandleEmbeddedStatement(usingStatement.ResourceAcquisition as Statement, data);
				ControlFlowNode from = HandleEmbeddedStatement(usingStatement.EmbeddedStatement, data);
				return CreateConnectedEndNode(usingStatement, from);
			}

			public override ControlFlowNode VisitYieldReturnStatement(YieldReturnStatement yieldStatement, ControlFlowNode data)
			{
				return CreateConnectedEndNode(yieldStatement, data);
			}

			public override ControlFlowNode VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement, ControlFlowNode data)
			{
				return builder.CreateEndNode(yieldBreakStatement);
			}

			public override ControlFlowNode VisitUnsafeStatement(UnsafeStatement unsafeStatement, ControlFlowNode data)
			{
				ControlFlowNode from = HandleEmbeddedStatement(unsafeStatement.Body, data);
				return CreateConnectedEndNode(unsafeStatement, from);
			}

			public override ControlFlowNode VisitFixedStatement(FixedStatement fixedStatement, ControlFlowNode data)
			{
				ControlFlowNode from = HandleEmbeddedStatement(fixedStatement.EmbeddedStatement, data);
				return CreateConnectedEndNode(fixedStatement, from);
			}
		}

		private Statement rootStatement;

		private CSharpTypeResolveContext typeResolveContext;

		private Func<AstNode, CancellationToken, ResolveResult> resolver;

		private List<ControlFlowNode> nodes;

		private Dictionary<string, ControlFlowNode> labels;

		private List<ControlFlowNode> gotoStatements;

		private CancellationToken cancellationToken;

		public bool EvaluateOnlyPrimitiveConstants
		{
			get;
			set;
		}

		protected virtual ControlFlowNode CreateNode(Statement previousStatement, Statement nextStatement, ControlFlowNodeType type)
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new ControlFlowNode(previousStatement, nextStatement, type);
		}

		protected virtual ControlFlowEdge CreateEdge(ControlFlowNode from, ControlFlowNode to, ControlFlowEdgeType type)
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new ControlFlowEdge(from, to, type);
		}

		public IList<ControlFlowNode> BuildControlFlowGraph(Statement statement, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (statement == null)
			{
				throw new ArgumentNullException("statement");
			}
			CSharpResolver cSharpResolver = new CSharpResolver(MinimalCorlib.Instance.CreateCompilation());
			return BuildControlFlowGraph(statement, new CSharpAstResolver(cSharpResolver, statement), cancellationToken);
		}

		public IList<ControlFlowNode> BuildControlFlowGraph(Statement statement, CSharpAstResolver resolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (statement == null)
			{
				throw new ArgumentNullException("statement");
			}
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			return BuildControlFlowGraph(statement, resolver.Resolve, resolver.TypeResolveContext, cancellationToken);
		}

		internal IList<ControlFlowNode> BuildControlFlowGraph(Statement statement, Func<AstNode, CancellationToken, ResolveResult> resolver, CSharpTypeResolveContext typeResolveContext, CancellationToken cancellationToken)
		{
			NodeCreationVisitor nodeCreationVisitor = new NodeCreationVisitor();
			nodeCreationVisitor.builder = this;
			try
			{
				nodes = new List<ControlFlowNode>();
				labels = new Dictionary<string, ControlFlowNode>();
				gotoStatements = new List<ControlFlowNode>();
				rootStatement = statement;
				this.resolver = resolver;
				this.typeResolveContext = typeResolveContext;
				this.cancellationToken = cancellationToken;
				ControlFlowNode data = CreateStartNode(statement);
				statement.AcceptVisitor(nodeCreationVisitor, data);
				foreach (ControlFlowNode gotoStatement in gotoStatements)
				{
					string label = ((GotoStatement)gotoStatement.NextStatement).Label;
					if (labels.TryGetValue(label, out ControlFlowNode value))
					{
						nodeCreationVisitor.Connect(gotoStatement, value, ControlFlowEdgeType.Jump);
					}
				}
				AnnotateLeaveEdgesWithTryFinallyBlocks();
				return nodes;
			}
			finally
			{
				nodes = null;
				labels = null;
				gotoStatements = null;
				rootStatement = null;
				this.resolver = null;
				this.typeResolveContext = null;
				this.cancellationToken = CancellationToken.None;
			}
		}

		private void AnnotateLeaveEdgesWithTryFinallyBlocks()
		{
			foreach (ControlFlowEdge item in nodes.SelectMany((ControlFlowNode n) => n.Outgoing))
			{
				if (item.Type == ControlFlowEdgeType.Jump)
				{
					Statement nextStatement = item.From.NextStatement;
					Statement statement = item.To.PreviousStatement ?? item.To.NextStatement;
					if (nextStatement.Parent != statement.Parent)
					{
						HashSet<TryCatchStatement> hashSet = new HashSet<TryCatchStatement>(statement.Ancestors.OfType<TryCatchStatement>());
						for (AstNode parent = nextStatement.Parent; parent != null; parent = parent.Parent)
						{
							TryCatchStatement tryCatchStatement = parent as TryCatchStatement;
							if (tryCatchStatement != null)
							{
								if (hashSet.Contains(tryCatchStatement))
								{
									break;
								}
								if (!tryCatchStatement.FinallyBlock.IsNull)
								{
									item.AddJumpOutOfTryFinally(tryCatchStatement);
								}
							}
						}
					}
				}
			}
		}

		private ControlFlowNode CreateStartNode(Statement statement)
		{
			if (statement.IsNull)
			{
				return null;
			}
			ControlFlowNode controlFlowNode = CreateNode(null, statement, ControlFlowNodeType.StartNode);
			nodes.Add(controlFlowNode);
			return controlFlowNode;
		}

		private ControlFlowNode CreateSpecialNode(Statement statement, ControlFlowNodeType type, bool addToNodeList = true)
		{
			ControlFlowNode controlFlowNode = CreateNode(null, statement, type);
			if (addToNodeList)
			{
				nodes.Add(controlFlowNode);
			}
			return controlFlowNode;
		}

		private ControlFlowNode CreateEndNode(Statement statement, bool addToNodeList = true)
		{
			Statement statement2;
			if (statement == rootStatement)
			{
				statement2 = null;
			}
			else
			{
				AstNode astNode = statement;
				do
				{
					astNode = astNode.NextSibling;
				}
				while (astNode != null && astNode.Role != statement.Role);
				statement2 = (astNode as Statement);
			}
			ControlFlowNodeType type = (statement2 != null) ? ControlFlowNodeType.BetweenStatements : ControlFlowNodeType.EndNode;
			ControlFlowNode controlFlowNode = CreateNode(statement, statement2, type);
			if (addToNodeList)
			{
				nodes.Add(controlFlowNode);
			}
			return controlFlowNode;
		}

		private ResolveResult EvaluateConstant(Expression expr)
		{
			if (expr.IsNull)
			{
				return null;
			}
			if (EvaluateOnlyPrimitiveConstants && !(expr is PrimitiveExpression) && !(expr is NullReferenceExpression))
			{
				return null;
			}
			return resolver(expr, cancellationToken);
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

		private bool AreEqualConstants(ResolveResult c1, ResolveResult c2)
		{
			if (c1 == null || c2 == null || !c1.IsCompileTimeConstant || !c2.IsCompileTimeConstant)
			{
				return false;
			}
			ResolveResult resolveResult = new CSharpResolver(typeResolveContext).ResolveBinaryOperator(BinaryOperatorType.Equality, c1, c2);
			if (resolveResult.IsCompileTimeConstant)
			{
				return resolveResult.ConstantValue as bool? == true;
			}
			return false;
		}

		public static GraphVizGraph ExportGraph(IList<ControlFlowNode> nodes)
		{
			GraphVizGraph graphVizGraph = new GraphVizGraph();
			GraphVizNode[] array = new GraphVizNode[nodes.Count];
			Dictionary<ControlFlowNode, int> dictionary = new Dictionary<ControlFlowNode, int>();
			for (int i = 0; i < array.Length; i++)
			{
				dictionary.Add(nodes[i], i);
				array[i] = new GraphVizNode(i);
				string str = "#" + i + " = ";
				switch (nodes[i].Type)
				{
				case ControlFlowNodeType.StartNode:
				case ControlFlowNodeType.BetweenStatements:
					str += nodes[i].NextStatement.DebugToString();
					break;
				case ControlFlowNodeType.EndNode:
					str = str + "End of " + nodes[i].PreviousStatement.DebugToString();
					break;
				case ControlFlowNodeType.LoopCondition:
					str = str + "Condition in " + nodes[i].NextStatement.DebugToString();
					break;
				default:
					str += "?";
					break;
				}
				array[i].label = str;
				graphVizGraph.AddNode(array[i]);
			}
			for (int j = 0; j < array.Length; j++)
			{
				foreach (ControlFlowEdge item in nodes[j].Outgoing)
				{
					GraphVizEdge graphVizEdge = new GraphVizEdge(j, dictionary[item.To]);
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
	}
}
