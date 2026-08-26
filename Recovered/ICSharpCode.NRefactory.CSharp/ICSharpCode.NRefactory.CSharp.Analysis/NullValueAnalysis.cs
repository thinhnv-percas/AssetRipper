using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class NullValueAnalysis
	{
		private sealed class VariableStatusInfo : IEquatable<VariableStatusInfo>, IEnumerable<KeyValuePair<string, NullValueStatus>>, IEnumerable
		{
			private readonly Dictionary<string, NullValueStatus> VariableStatus = new Dictionary<string, NullValueStatus>();

			public NullValueStatus this[string name]
			{
				get
				{
					if (VariableStatus.TryGetValue(name, out NullValueStatus value))
					{
						return value;
					}
					return NullValueStatus.UnreachableOrInexistent;
				}
				set
				{
					if (value == NullValueStatus.UnreachableOrInexistent)
					{
						VariableStatus.Remove(name);
					}
					else
					{
						VariableStatus[name] = value;
					}
				}
			}

			public bool ReceiveIncoming(VariableStatusInfo incomingState)
			{
				bool result = false;
				foreach (string item in VariableStatus.Keys.Concat(incomingState.VariableStatus.Keys).ToList())
				{
					NullValueStatus nullValueStatus = CombineStatus(this[item], incomingState[item]);
					if (this[item] != nullValueStatus)
					{
						this[item] = nullValueStatus;
						result = true;
					}
				}
				return result;
			}

			public static NullValueStatus CombineStatus(NullValueStatus oldValue, NullValueStatus incomingValue)
			{
				if (oldValue == NullValueStatus.Error || incomingValue == NullValueStatus.Error)
				{
					return NullValueStatus.Error;
				}
				if (oldValue == NullValueStatus.UnreachableOrInexistent || oldValue == NullValueStatus.Unassigned)
				{
					return incomingValue;
				}
				if (incomingValue == NullValueStatus.Unassigned)
				{
					return NullValueStatus.Unassigned;
				}
				if (oldValue == NullValueStatus.CapturedUnknown || incomingValue == NullValueStatus.CapturedUnknown)
				{
					return NullValueStatus.CapturedUnknown;
				}
				switch (oldValue)
				{
				case NullValueStatus.Unknown:
					return NullValueStatus.Unknown;
				case NullValueStatus.DefinitelyNull:
					if (incomingValue != NullValueStatus.DefinitelyNull)
					{
						return NullValueStatus.PotentiallyNull;
					}
					return NullValueStatus.DefinitelyNull;
				case NullValueStatus.DefinitelyNotNull:
					switch (incomingValue)
					{
					case NullValueStatus.Unknown:
						return NullValueStatus.Unknown;
					case NullValueStatus.DefinitelyNotNull:
						return NullValueStatus.DefinitelyNotNull;
					default:
						return NullValueStatus.PotentiallyNull;
					}
				default:
					return NullValueStatus.PotentiallyNull;
				}
			}

			public bool HasVariable(string variable)
			{
				return VariableStatus.ContainsKey(variable);
			}

			public VariableStatusInfo Clone()
			{
				VariableStatusInfo variableStatusInfo = new VariableStatusInfo();
				foreach (KeyValuePair<string, NullValueStatus> item in VariableStatus)
				{
					variableStatusInfo.VariableStatus.Add(item.Key, item.Value);
				}
				return variableStatusInfo;
			}

			public override bool Equals(object obj)
			{
				return Equals(obj as VariableStatusInfo);
			}

			public bool Equals(VariableStatusInfo obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (VariableStatus.Count != obj.VariableStatus.Count)
				{
					return false;
				}
				return VariableStatus.All((KeyValuePair<string, NullValueStatus> item) => item.Value == obj[item.Key]);
			}

			public override int GetHashCode()
			{
				return VariableStatus.Count.GetHashCode();
			}

			public static bool operator ==(VariableStatusInfo obj1, VariableStatusInfo obj2)
			{
				return obj1?.Equals(obj2) ?? ((object)obj2 == null);
			}

			public static bool operator !=(VariableStatusInfo obj1, VariableStatusInfo obj2)
			{
				return !(obj1 == obj2);
			}

			public IEnumerator<KeyValuePair<string, NullValueStatus>> GetEnumerator()
			{
				return VariableStatus.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder("[");
				using (IEnumerator<KeyValuePair<string, NullValueStatus>> enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, NullValueStatus> current = enumerator.Current;
						stringBuilder.Append(current.Key);
						stringBuilder.Append("=");
						stringBuilder.Append(current.Value);
					}
				}
				stringBuilder.Append("]");
				return stringBuilder.ToString();
			}
		}

		private sealed class NullAnalysisNode : ControlFlowNode
		{
			public readonly VariableStatusInfo VariableState = new VariableStatusInfo();

			public bool Visited
			{
				get;
				private set;
			}

			public NullAnalysisNode(Statement previousStatement, Statement nextStatement, ControlFlowNodeType type)
				: base(previousStatement, nextStatement, type)
			{
			}

			public bool ReceiveIncoming(VariableStatusInfo incomingState)
			{
				bool result = VariableState.ReceiveIncoming(incomingState);
				if (!Visited)
				{
					Visited = true;
					return true;
				}
				return result;
			}
		}

		private sealed class NullAnalysisGraphBuilder : ControlFlowGraphBuilder
		{
			protected override ControlFlowNode CreateNode(Statement previousStatement, Statement nextStatement, ControlFlowNodeType type)
			{
				return new NullAnalysisNode(previousStatement, nextStatement, type);
			}
		}

		private class PendingNode : IEquatable<PendingNode>
		{
			internal readonly NullAnalysisNode nodeToVisit;

			internal readonly VariableStatusInfo statusInfo;

			internal readonly ComparableList<NullAnalysisNode> pendingTryFinallyNodes;

			internal readonly NullAnalysisNode nodeAfterFinally;

			internal PendingNode(NullAnalysisNode nodeToVisit, VariableStatusInfo statusInfo)
				: this(nodeToVisit, statusInfo, new ComparableList<NullAnalysisNode>(), null)
			{
			}

			public PendingNode(NullAnalysisNode nodeToVisit, VariableStatusInfo statusInfo, ComparableList<NullAnalysisNode> pendingFinallyNodes, NullAnalysisNode nodeAfterFinally)
			{
				this.nodeToVisit = nodeToVisit;
				this.statusInfo = statusInfo;
				pendingTryFinallyNodes = pendingFinallyNodes;
				this.nodeAfterFinally = nodeAfterFinally;
			}

			public override bool Equals(object obj)
			{
				return Equals(obj as PendingNode);
			}

			public bool Equals(PendingNode obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (nodeToVisit != obj.nodeToVisit)
				{
					return false;
				}
				if (statusInfo != obj.statusInfo)
				{
					return false;
				}
				if (pendingTryFinallyNodes != obj.pendingTryFinallyNodes)
				{
					return false;
				}
				if (nodeAfterFinally != obj.nodeAfterFinally)
				{
					return false;
				}
				return true;
			}

			public override int GetHashCode()
			{
				return nodeToVisit.GetHashCode() ^ statusInfo.GetHashCode() ^ pendingTryFinallyNodes.GetHashCode() ^ ((nodeAfterFinally != null) ? nodeAfterFinally.GetHashCode() : 0);
			}
		}

		private class ConditionalBranchInfo
		{
			public Dictionary<string, bool> TrueResultVariableNullStates = new Dictionary<string, bool>();

			public Dictionary<string, bool> FalseResultVariableNullStates = new Dictionary<string, bool>();
		}

		private class VisitorResult
		{
			public NullValueStatus NullableReturnResult;

			public NullValueStatus EnumeratedValueResult;

			public ConditionalBranchInfo ConditionalBranchInfo;

			public VariableStatusInfo Variables;

			public bool ThrowsException;

			public bool? KnownBoolResult;

			public VisitorResult Negated
			{
				get
				{
					VisitorResult visitorResult = new VisitorResult();
					if (NullableReturnResult.IsDefiniteValue())
					{
						visitorResult.NullableReturnResult = ((NullableReturnResult == NullValueStatus.DefinitelyNull) ? NullValueStatus.DefinitelyNotNull : NullValueStatus.DefinitelyNull);
					}
					else
					{
						visitorResult.NullableReturnResult = NullableReturnResult;
					}
					visitorResult.Variables = Variables.Clone();
					visitorResult.KnownBoolResult = !KnownBoolResult;
					if (ConditionalBranchInfo != null)
					{
						visitorResult.ConditionalBranchInfo = new ConditionalBranchInfo();
						foreach (KeyValuePair<string, bool> trueResultVariableNullState in ConditionalBranchInfo.TrueResultVariableNullStates)
						{
							visitorResult.ConditionalBranchInfo.FalseResultVariableNullStates[trueResultVariableNullState.Key] = trueResultVariableNullState.Value;
						}
						{
							foreach (KeyValuePair<string, bool> falseResultVariableNullState in ConditionalBranchInfo.FalseResultVariableNullStates)
							{
								visitorResult.ConditionalBranchInfo.TrueResultVariableNullStates[falseResultVariableNullState.Key] = falseResultVariableNullState.Value;
							}
							return visitorResult;
						}
					}
					return visitorResult;
				}
			}

			public VariableStatusInfo TruePathVariables
			{
				get
				{
					VariableStatusInfo variableStatusInfo = Variables.Clone();
					if (ConditionalBranchInfo != null)
					{
						foreach (KeyValuePair<string, bool> trueResultVariableNullState in ConditionalBranchInfo.TrueResultVariableNullStates)
						{
							variableStatusInfo[trueResultVariableNullState.Key] = (trueResultVariableNullState.Value ? NullValueStatus.DefinitelyNull : NullValueStatus.DefinitelyNotNull);
						}
						return variableStatusInfo;
					}
					return variableStatusInfo;
				}
			}

			public VariableStatusInfo FalsePathVariables
			{
				get
				{
					VariableStatusInfo variableStatusInfo = Variables.Clone();
					if (ConditionalBranchInfo != null)
					{
						foreach (KeyValuePair<string, bool> falseResultVariableNullState in ConditionalBranchInfo.FalseResultVariableNullStates)
						{
							variableStatusInfo[falseResultVariableNullState.Key] = (falseResultVariableNullState.Value ? NullValueStatus.DefinitelyNull : NullValueStatus.DefinitelyNotNull);
						}
						return variableStatusInfo;
					}
					return variableStatusInfo;
				}
			}

			public static VisitorResult ForEnumeratedValue(VariableStatusInfo variables, NullValueStatus itemValues)
			{
				return new VisitorResult
				{
					NullableReturnResult = NullValueStatus.DefinitelyNotNull,
					EnumeratedValueResult = itemValues,
					Variables = variables.Clone()
				};
			}

			public static VisitorResult ForValue(VariableStatusInfo variables, NullValueStatus returnValue)
			{
				return new VisitorResult
				{
					NullableReturnResult = returnValue,
					Variables = variables.Clone()
				};
			}

			public static VisitorResult ForBoolValue(VariableStatusInfo variables, bool newValue)
			{
				return new VisitorResult
				{
					NullableReturnResult = NullValueStatus.DefinitelyNotNull,
					KnownBoolResult = newValue,
					Variables = variables.Clone()
				};
			}

			public static VisitorResult ForException(VariableStatusInfo variables)
			{
				return new VisitorResult
				{
					NullableReturnResult = NullValueStatus.UnreachableOrInexistent,
					ThrowsException = true,
					Variables = variables.Clone()
				};
			}

			public static VisitorResult AndOperation(VisitorResult tentativeLeftResult, VisitorResult tentativeRightResult)
			{
				VisitorResult visitorResult = new VisitorResult();
				visitorResult.KnownBoolResult = (tentativeLeftResult.KnownBoolResult & tentativeRightResult.KnownBoolResult);
				VariableStatusInfo truePathVariables = tentativeRightResult.TruePathVariables;
				VariableStatusInfo falsePathVariables = tentativeRightResult.FalsePathVariables;
				VariableStatusInfo falsePathVariables2 = tentativeLeftResult.FalsePathVariables;
				VariableStatusInfo variableStatusInfo = truePathVariables;
				VariableStatusInfo variableStatusInfo2 = falsePathVariables.Clone();
				variableStatusInfo2.ReceiveIncoming(falsePathVariables2);
				visitorResult.Variables = variableStatusInfo.Clone();
				visitorResult.Variables.ReceiveIncoming(variableStatusInfo2);
				visitorResult.ConditionalBranchInfo = new ConditionalBranchInfo();
				foreach (KeyValuePair<string, NullValueStatus> item in variableStatusInfo)
				{
					if (item.Value.IsDefiniteValue())
					{
						string key = item.Key;
						if (item.Value != visitorResult.Variables[key])
						{
							bool value = item.Value == NullValueStatus.DefinitelyNull;
							visitorResult.ConditionalBranchInfo.TrueResultVariableNullStates.Add(key, value);
						}
					}
				}
				foreach (KeyValuePair<string, NullValueStatus> item2 in variableStatusInfo2)
				{
					if (item2.Value.IsDefiniteValue())
					{
						string key2 = item2.Key;
						if (item2.Value != visitorResult.Variables[key2])
						{
							bool value2 = item2.Value == NullValueStatus.DefinitelyNull;
							visitorResult.ConditionalBranchInfo.FalseResultVariableNullStates.Add(key2, value2);
						}
					}
				}
				return visitorResult;
			}

			public static VisitorResult OrOperation(VisitorResult tentativeLeftResult, VisitorResult tentativeRightResult)
			{
				return AndOperation(tentativeLeftResult.Negated, tentativeRightResult.Negated).Negated;
			}
		}

		private class NullAnalysisVisitor : DepthFirstAstVisitor<VariableStatusInfo, VisitorResult>
		{
			private NullValueAnalysis analysis;

			public NullAnalysisVisitor(NullValueAnalysis analysis)
			{
				this.analysis = analysis;
			}

			protected override VisitorResult VisitChildren(AstNode node, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitNullNode(AstNode nullNode, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitEmptyStatement(EmptyStatement emptyStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitBlockStatement(BlockStatement blockStatement, VariableStatusInfo data)
			{
				return new VisitorResult
				{
					Variables = data
				};
			}

			public override VisitorResult VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, VariableStatusInfo data)
			{
				foreach (VariableInitializer variable in variableDeclarationStatement.Variables)
				{
					VisitorResult visitorResult = variable.AcceptVisitor(this, data);
					if (visitorResult.ThrowsException)
					{
						return visitorResult;
					}
					data = visitorResult.Variables;
				}
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitVariableInitializer(VariableInitializer variableInitializer, VariableStatusInfo data)
			{
				if (variableInitializer.Initializer.IsNull)
				{
					data = data.Clone();
					data[variableInitializer.Name] = NullValueStatus.Unassigned;
				}
				else
				{
					VisitorResult visitorResult = variableInitializer.Initializer.AcceptVisitor(this, data);
					if (visitorResult.ThrowsException)
					{
						return visitorResult;
					}
					data = visitorResult.Variables.Clone();
					data[variableInitializer.Name] = visitorResult.NullableReturnResult;
				}
				return VisitorResult.ForValue(data, data[variableInitializer.Name]);
			}

			public override VisitorResult VisitIfElseStatement(IfElseStatement ifElseStatement, VariableStatusInfo data)
			{
				return ifElseStatement.Condition.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitWhileStatement(WhileStatement whileStatement, VariableStatusInfo data)
			{
				return whileStatement.Condition.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitDoWhileStatement(DoWhileStatement doWhileStatement, VariableStatusInfo data)
			{
				return doWhileStatement.Condition.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitForStatement(ForStatement forStatement, VariableStatusInfo data)
			{
				if (forStatement.Condition.IsNull)
				{
					return VisitorResult.ForValue(data, NullValueStatus.Unknown);
				}
				return forStatement.Condition.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitForeachStatement(ForeachStatement foreachStatement, VariableStatusInfo data)
			{
				Identifier variableNameToken = foreachStatement.VariableNameToken;
				VisitorResult visitorResult = foreachStatement.InExpression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				VariableStatusInfo variableStatusInfo = visitorResult.Variables.Clone();
				LocalResolveResult localResolveResult = analysis.context.Resolve(foreachStatement.VariableNameToken) as LocalResolveResult;
				if (localResolveResult != null && (analysis.context.Supports(new Version(5, 0)) || data[variableNameToken.Name] != NullValueStatus.CapturedUnknown))
				{
					variableStatusInfo[variableNameToken.Name] = (IsTypeNullable(localResolveResult.Type) ? visitorResult.EnumeratedValueResult : NullValueStatus.DefinitelyNotNull);
				}
				return VisitorResult.ForValue(variableStatusInfo, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitUsingStatement(UsingStatement usingStatement, VariableStatusInfo data)
			{
				return usingStatement.ResourceAcquisition.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitFixedStatement(FixedStatement fixedStatement, VariableStatusInfo data)
			{
				foreach (VariableInitializer variable in fixedStatement.Variables)
				{
					VisitorResult visitorResult = variable.AcceptVisitor(this, data);
					if (visitorResult.ThrowsException)
					{
						return visitorResult;
					}
					data = visitorResult.Variables;
				}
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitSwitchStatement(SwitchStatement switchStatement, VariableStatusInfo data)
			{
				VisitorResult visitorResult = switchStatement.Expression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				foreach (SwitchSection switchSection in switchStatement.SwitchSections)
				{
					switchSection.AcceptVisitor(this, visitorResult.Variables);
				}
				return VisitorResult.ForValue(visitorResult.Variables, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitSwitchSection(SwitchSection switchSection, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitExpressionStatement(ExpressionStatement expressionStatement, VariableStatusInfo data)
			{
				return expressionStatement.Expression.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitReturnStatement(ReturnStatement returnStatement, VariableStatusInfo data)
			{
				if (returnStatement.Expression.IsNull)
				{
					return VisitorResult.ForValue(data, NullValueStatus.Unknown);
				}
				return returnStatement.Expression.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitTryCatchStatement(TryCatchStatement tryCatchStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitBreakStatement(BreakStatement breakStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitContinueStatement(ContinueStatement continueStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitGotoStatement(GotoStatement gotoStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitLabelStatement(LabelStatement labelStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitUnsafeStatement(UnsafeStatement unsafeStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitLockStatement(LockStatement lockStatement, VariableStatusInfo data)
			{
				VisitorResult visitorResult = lockStatement.Expression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
				{
					return VisitorResult.ForException(visitorResult.Variables);
				}
				IdentifierExpression identifierExpression = CSharpUtil.GetInnerMostExpression(lockStatement.Expression) as IdentifierExpression;
				if (identifierExpression != null && visitorResult.Variables[identifierExpression.Identifier] != NullValueStatus.CapturedUnknown)
				{
					VariableStatusInfo variableStatusInfo = visitorResult.Variables.Clone();
					analysis.SetLocalVariableValue(variableStatusInfo, identifierExpression, NullValueStatus.DefinitelyNotNull);
					return VisitorResult.ForValue(variableStatusInfo, NullValueStatus.Unknown);
				}
				return VisitorResult.ForValue(visitorResult.Variables, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitThrowStatement(ThrowStatement throwStatement, VariableStatusInfo data)
			{
				if (throwStatement.Expression.IsNull)
				{
					return VisitorResult.ForValue(data, NullValueStatus.DefinitelyNotNull);
				}
				return throwStatement.Expression.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement, VariableStatusInfo data)
			{
				return yieldReturnStatement.Expression.AcceptVisitor(this, data);
			}

			public override VisitorResult VisitCheckedStatement(CheckedStatement checkedStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitUncheckedStatement(UncheckedStatement uncheckedStatement, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			private void RegisterExpressionResult(Expression expression, NullValueStatus expressionResult)
			{
				if (analysis.expressionResult.TryGetValue(expression, out NullValueStatus _))
				{
					analysis.expressionResult[expression] = VariableStatusInfo.CombineStatus(analysis.expressionResult[expression], expressionResult);
				}
				else
				{
					analysis.expressionResult[expression] = expressionResult;
				}
			}

			private VisitorResult HandleExpressionResult(Expression expression, VariableStatusInfo dataAfterExpression, NullValueStatus expressionResult)
			{
				RegisterExpressionResult(expression, expressionResult);
				return VisitorResult.ForValue(dataAfterExpression, expressionResult);
			}

			private VisitorResult HandleExpressionResult(Expression expression, VariableStatusInfo dataAfterExpression, bool expressionResult)
			{
				RegisterExpressionResult(expression, NullValueStatus.DefinitelyNotNull);
				return VisitorResult.ForBoolValue(dataAfterExpression, expressionResult);
			}

			private VisitorResult HandleExpressionResult(Expression expression, VisitorResult result)
			{
				RegisterExpressionResult(expression, result.NullableReturnResult);
				return result;
			}

			public override VisitorResult VisitAssignmentExpression(AssignmentExpression assignmentExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = assignmentExpression.Left.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return HandleExpressionResult(assignmentExpression, visitorResult);
				}
				visitorResult = assignmentExpression.Right.AcceptVisitor(this, visitorResult.Variables);
				if (visitorResult.ThrowsException)
				{
					return HandleExpressionResult(assignmentExpression, visitorResult);
				}
				IdentifierExpression identifierExpression = assignmentExpression.Left as IdentifierExpression;
				if (identifierExpression != null)
				{
					ResolveResult resolveResult = analysis.context.Resolve(identifierExpression);
					if (resolveResult.IsError)
					{
						return HandleExpressionResult(assignmentExpression, data, NullValueStatus.Error);
					}
					if (resolveResult is LocalResolveResult)
					{
						VisitorResult visitorResult2 = new VisitorResult();
						visitorResult2.NullableReturnResult = visitorResult.NullableReturnResult;
						visitorResult2.Variables = visitorResult.Variables.Clone();
						NullValueStatus nullValueStatus = visitorResult2.Variables[identifierExpression.Identifier];
						if (assignmentExpression.Operator == AssignmentOperatorType.Assign || nullValueStatus == NullValueStatus.Unassigned || nullValueStatus == NullValueStatus.DefinitelyNotNull || visitorResult.NullableReturnResult == NullValueStatus.Error || visitorResult.NullableReturnResult == NullValueStatus.Unknown)
						{
							analysis.SetLocalVariableValue(visitorResult2.Variables, identifierExpression, visitorResult.NullableReturnResult);
						}
						else if (nullValueStatus != NullValueStatus.DefinitelyNull)
						{
							analysis.SetLocalVariableValue(visitorResult2.Variables, identifierExpression, NullValueStatus.PotentiallyNull);
						}
						return HandleExpressionResult(assignmentExpression, visitorResult2);
					}
				}
				return HandleExpressionResult(assignmentExpression, visitorResult);
			}

			public override VisitorResult VisitIdentifierExpression(IdentifierExpression identifierExpression, VariableStatusInfo data)
			{
				ResolveResult resolveResult = analysis.context.Resolve(identifierExpression);
				if (resolveResult.IsError)
				{
					return HandleExpressionResult(identifierExpression, data, NullValueStatus.Error);
				}
				LocalResolveResult localResolveResult = resolveResult as LocalResolveResult;
				if (localResolveResult != null)
				{
					NullValueStatus nullValueStatus = data[localResolveResult.Variable.Name];
					if (nullValueStatus == NullValueStatus.CapturedUnknown)
					{
						nullValueStatus = NullValueStatus.Unknown;
					}
					return HandleExpressionResult(identifierExpression, data, nullValueStatus);
				}
				if (resolveResult.IsCompileTimeConstant)
				{
					object constantValue = resolveResult.ConstantValue;
					if (constantValue == null)
					{
						return HandleExpressionResult(identifierExpression, data, NullValueStatus.DefinitelyNull);
					}
					bool? flag = constantValue as bool?;
					if (flag.HasValue)
					{
						return VisitorResult.ForBoolValue(data, flag.Value);
					}
					return HandleExpressionResult(identifierExpression, data, NullValueStatus.DefinitelyNotNull);
				}
				NullValueStatus fieldReturnValue = GetFieldReturnValue(resolveResult as MemberResolveResult, data);
				return HandleExpressionResult(identifierExpression, data, fieldReturnValue);
			}

			public override VisitorResult VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, VariableStatusInfo data)
			{
				ResolveResult resolveResult = analysis.context.Resolve(defaultValueExpression);
				if (resolveResult.IsError)
				{
					return HandleExpressionResult(defaultValueExpression, data, NullValueStatus.Unknown);
				}
				NullValueStatus expressionResult = (resolveResult.ConstantValue == null && resolveResult.Type.IsReferenceType != false) ? NullValueStatus.DefinitelyNull : NullValueStatus.DefinitelyNotNull;
				return HandleExpressionResult(defaultValueExpression, data, expressionResult);
			}

			public override VisitorResult VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(nullReferenceExpression, data, NullValueStatus.DefinitelyNull);
			}

			public override VisitorResult VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(primitiveExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(parenthesizedExpression, parenthesizedExpression.Expression.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitConditionalExpression(ConditionalExpression conditionalExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = conditionalExpression.Condition.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return HandleExpressionResult(conditionalExpression, visitorResult);
				}
				ResolveResult resolveResult = analysis.context.Resolve(conditionalExpression.Condition);
				if (visitorResult.KnownBoolResult == true || true.Equals(resolveResult.ConstantValue))
				{
					return HandleExpressionResult(conditionalExpression, conditionalExpression.TrueExpression.AcceptVisitor(this, visitorResult.TruePathVariables));
				}
				if (visitorResult.KnownBoolResult == false || false.Equals(resolveResult.ConstantValue))
				{
					return HandleExpressionResult(conditionalExpression, conditionalExpression.FalseExpression.AcceptVisitor(this, visitorResult.FalsePathVariables));
				}
				VisitorResult visitorResult2 = conditionalExpression.TrueExpression.AcceptVisitor(this, visitorResult.TruePathVariables);
				if (visitorResult2.ThrowsException)
				{
					return HandleExpressionResult(conditionalExpression, conditionalExpression.FalseExpression.AcceptVisitor(this, visitorResult.FalsePathVariables));
				}
				VisitorResult visitorResult3 = conditionalExpression.FalseExpression.AcceptVisitor(this, visitorResult.FalsePathVariables);
				if (visitorResult3.ThrowsException)
				{
					return HandleExpressionResult(conditionalExpression, visitorResult2.Variables, expressionResult: true);
				}
				return HandleExpressionResult(conditionalExpression, VisitorResult.OrOperation(visitorResult2, visitorResult3));
			}

			public override VisitorResult VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, VariableStatusInfo data)
			{
				switch (binaryOperatorExpression.Operator)
				{
				case BinaryOperatorType.ConditionalAnd:
					return HandleExpressionResult(binaryOperatorExpression, VisitConditionalAndExpression(binaryOperatorExpression, data));
				case BinaryOperatorType.ConditionalOr:
					return HandleExpressionResult(binaryOperatorExpression, VisitConditionalOrExpression(binaryOperatorExpression, data));
				case BinaryOperatorType.NullCoalescing:
					return HandleExpressionResult(binaryOperatorExpression, VisitNullCoalescing(binaryOperatorExpression, data));
				case BinaryOperatorType.Equality:
					return HandleExpressionResult(binaryOperatorExpression, VisitEquality(binaryOperatorExpression, data));
				case BinaryOperatorType.InEquality:
					return HandleExpressionResult(binaryOperatorExpression, VisitEquality(binaryOperatorExpression, data).Negated);
				default:
					return HandleExpressionResult(binaryOperatorExpression, VisitOtherBinaryExpression(binaryOperatorExpression, data));
				}
			}

			private VisitorResult VisitOtherBinaryExpression(BinaryOperatorExpression binaryOperatorExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = binaryOperatorExpression.Left.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				VisitorResult visitorResult2 = binaryOperatorExpression.Right.AcceptVisitor(this, visitorResult.Variables);
				if (visitorResult2.ThrowsException)
				{
					return visitorResult2;
				}
				switch (binaryOperatorExpression.Operator)
				{
				case BinaryOperatorType.GreaterThan:
				case BinaryOperatorType.LessThan:
					if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull && visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNull)
					{
						return VisitorResult.ForBoolValue(visitorResult2.Variables, newValue: false);
					}
					return VisitorResult.ForValue(visitorResult2.Variables, NullValueStatus.DefinitelyNotNull);
				case BinaryOperatorType.GreaterThanOrEqual:
				case BinaryOperatorType.LessThanOrEqual:
					if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
					{
						if (visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNull)
						{
							return VisitorResult.ForBoolValue(visitorResult2.Variables, newValue: true);
						}
						if (visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNotNull)
						{
							return VisitorResult.ForBoolValue(visitorResult2.Variables, newValue: false);
						}
					}
					else if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNotNull && visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNull)
					{
						return VisitorResult.ForBoolValue(visitorResult2.Variables, newValue: false);
					}
					return VisitorResult.ForValue(visitorResult2.Variables, NullValueStatus.Unknown);
				default:
					if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
					{
						return VisitorResult.ForValue(visitorResult2.Variables, NullValueStatus.DefinitelyNull);
					}
					if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNotNull)
					{
						if (visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNull)
						{
							return VisitorResult.ForValue(visitorResult2.Variables, NullValueStatus.DefinitelyNull);
						}
						if (visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNotNull)
						{
							return VisitorResult.ForValue(visitorResult2.Variables, NullValueStatus.DefinitelyNotNull);
						}
					}
					return VisitorResult.ForValue(visitorResult2.Variables, NullValueStatus.Unknown);
				}
			}

			private VisitorResult WithVariableValue(VisitorResult result, IdentifierExpression identifier, bool isNull)
			{
				if (analysis.context.Resolve(identifier) is LocalResolveResult)
				{
					result.ConditionalBranchInfo.TrueResultVariableNullStates[identifier.Identifier] = isNull;
					if (isNull)
					{
						result.ConditionalBranchInfo.FalseResultVariableNullStates[identifier.Identifier] = false;
					}
				}
				return result;
			}

			private VisitorResult VisitEquality(BinaryOperatorExpression binaryOperatorExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = binaryOperatorExpression.Left.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				VisitorResult visitorResult2 = binaryOperatorExpression.Right.AcceptVisitor(this, visitorResult.Variables);
				if (visitorResult2.ThrowsException)
				{
					return visitorResult2;
				}
				if (visitorResult.KnownBoolResult.HasValue && visitorResult.KnownBoolResult == visitorResult2.KnownBoolResult)
				{
					return VisitorResult.ForBoolValue(visitorResult2.Variables, newValue: true);
				}
				if (visitorResult.KnownBoolResult.HasValue && visitorResult.KnownBoolResult == !visitorResult2.KnownBoolResult)
				{
					return VisitorResult.ForBoolValue(visitorResult2.Variables, newValue: false);
				}
				if (visitorResult.NullableReturnResult.IsDefiniteValue() && visitorResult2.NullableReturnResult.IsDefiniteValue() && (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull || visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNull))
				{
					return VisitorResult.ForBoolValue(visitorResult2.Variables, visitorResult.NullableReturnResult == visitorResult2.NullableReturnResult);
				}
				VisitorResult visitorResult3 = new VisitorResult();
				visitorResult3.Variables = visitorResult2.Variables;
				visitorResult3.NullableReturnResult = NullValueStatus.Unknown;
				visitorResult3.ConditionalBranchInfo = new ConditionalBranchInfo();
				if (visitorResult2.NullableReturnResult.IsDefiniteValue())
				{
					IdentifierExpression identifierExpression = CSharpUtil.GetInnerMostExpression(binaryOperatorExpression.Left) as IdentifierExpression;
					if (identifierExpression != null)
					{
						bool isNull = visitorResult2.NullableReturnResult == NullValueStatus.DefinitelyNull;
						WithVariableValue(visitorResult3, identifierExpression, isNull);
					}
				}
				if (visitorResult.NullableReturnResult.IsDefiniteValue())
				{
					IdentifierExpression identifierExpression2 = CSharpUtil.GetInnerMostExpression(binaryOperatorExpression.Right) as IdentifierExpression;
					if (identifierExpression2 != null)
					{
						bool isNull2 = visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull;
						WithVariableValue(visitorResult3, identifierExpression2, isNull2);
					}
				}
				return visitorResult3;
			}

			private VisitorResult VisitConditionalAndExpression(BinaryOperatorExpression binaryOperatorExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = binaryOperatorExpression.Left.AcceptVisitor(this, data);
				if (visitorResult.KnownBoolResult == false || visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				VariableStatusInfo truePathVariables = visitorResult.TruePathVariables;
				VisitorResult visitorResult2 = binaryOperatorExpression.Right.AcceptVisitor(this, truePathVariables);
				if (visitorResult2.ThrowsException)
				{
					return VisitorResult.ForBoolValue(visitorResult.FalsePathVariables, newValue: false);
				}
				return VisitorResult.AndOperation(visitorResult, visitorResult2);
			}

			private VisitorResult VisitConditionalOrExpression(BinaryOperatorExpression binaryOperatorExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = binaryOperatorExpression.Left.AcceptVisitor(this, data);
				if (visitorResult.KnownBoolResult == true || visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				VariableStatusInfo falsePathVariables = visitorResult.FalsePathVariables;
				VisitorResult visitorResult2 = binaryOperatorExpression.Right.AcceptVisitor(this, falsePathVariables);
				if (visitorResult2.ThrowsException)
				{
					return VisitorResult.ForBoolValue(visitorResult.TruePathVariables, newValue: true);
				}
				return VisitorResult.OrOperation(visitorResult, visitorResult2);
			}

			private VisitorResult VisitNullCoalescing(BinaryOperatorExpression binaryOperatorExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = binaryOperatorExpression.Left.AcceptVisitor(this, data);
				if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNotNull || visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				VariableStatusInfo variableStatusInfo = visitorResult.Variables;
				IdentifierExpression identifierExpression = CSharpUtil.GetInnerMostExpression(binaryOperatorExpression.Left) as IdentifierExpression;
				if (identifierExpression != null)
				{
					variableStatusInfo = variableStatusInfo.Clone();
					analysis.SetLocalVariableValue(variableStatusInfo, identifierExpression, NullValueStatus.DefinitelyNull);
				}
				VisitorResult visitorResult2 = binaryOperatorExpression.Right.AcceptVisitor(this, variableStatusInfo);
				if (visitorResult2.ThrowsException)
				{
					if (identifierExpression != null)
					{
						variableStatusInfo = variableStatusInfo.Clone();
						analysis.SetLocalVariableValue(variableStatusInfo, identifierExpression, NullValueStatus.DefinitelyNotNull);
						return VisitorResult.ForValue(variableStatusInfo, NullValueStatus.DefinitelyNotNull);
					}
					return VisitorResult.ForValue(visitorResult.Variables, NullValueStatus.DefinitelyNotNull);
				}
				VariableStatusInfo variableStatusInfo2 = visitorResult2.Variables;
				NullValueStatus nullValueStatus = visitorResult2.NullableReturnResult;
				if (visitorResult.NullableReturnResult != NullValueStatus.DefinitelyNull)
				{
					variableStatusInfo2 = variableStatusInfo2.Clone();
					variableStatusInfo2.ReceiveIncoming(visitorResult.Variables);
					if (nullValueStatus == NullValueStatus.DefinitelyNull)
					{
						nullValueStatus = NullValueStatus.PotentiallyNull;
					}
				}
				return VisitorResult.ForValue(variableStatusInfo2, nullValueStatus);
			}

			public override VisitorResult VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = unaryOperatorExpression.Expression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return HandleExpressionResult(unaryOperatorExpression, visitorResult);
				}
				if (unaryOperatorExpression.Operator == UnaryOperatorType.Not)
				{
					return HandleExpressionResult(unaryOperatorExpression, visitorResult.Negated);
				}
				return HandleExpressionResult(unaryOperatorExpression, visitorResult);
			}

			public override VisitorResult VisitInvocationExpression(InvocationExpression invocationExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = invocationExpression.Target.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return HandleExpressionResult(invocationExpression, visitorResult);
				}
				data = visitorResult.Variables;
				CSharpInvocationResolveResult cSharpInvocationResolveResult = analysis.context.Resolve(invocationExpression) as CSharpInvocationResolveResult;
				List<VisitorResult> list = new List<VisitorResult>();
				foreach (var item in invocationExpression.Arguments.Select((Expression argument, int parameterIndex) => new
				{
					argument,
					parameterIndex
				}))
				{
					Expression argument2 = item.argument;
					int parameterIndex2 = item.parameterIndex;
					VisitorResult visitorResult2 = argument2.AcceptVisitor(this, data);
					if (visitorResult2.ThrowsException)
					{
						return HandleExpressionResult(invocationExpression, visitorResult2);
					}
					list.Add(visitorResult2);
					NamedArgumentExpression namedArgumentExpression = argument2 as NamedArgumentExpression;
					DirectionExpression directionExpression = ((namedArgumentExpression == null) ? argument2 : namedArgumentExpression.Expression) as DirectionExpression;
					if (directionExpression != null && cSharpInvocationResolveResult != null)
					{
						IdentifierExpression identifierExpression2 = directionExpression.Expression as IdentifierExpression;
						if (identifierExpression2 != null)
						{
							LocalResolveResult localResolveResult = analysis.context.Resolve(identifierExpression2) as LocalResolveResult;
							if (localResolveResult != null && IsTypeNullable(localResolveResult.Type))
							{
								data = data.Clone();
								FixParameter(argument2, cSharpInvocationResolveResult.Member.Parameters, parameterIndex2, identifierExpression2, data);
							}
						}
					}
					else
					{
						data = visitorResult2.Variables;
					}
				}
				IdentifierExpression identifierExpression = CSharpUtil.GetInnerMostExpression(invocationExpression.Target) as IdentifierExpression;
				if (identifierExpression != null)
				{
					if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
					{
						return HandleExpressionResult(invocationExpression, VisitorResult.ForException(data));
					}
					if (!invocationExpression.Arguments.SelectMany((Expression argument) => argument.DescendantsAndSelf).OfType<IdentifierExpression>().Any((IdentifierExpression identifier) => identifier.Identifier == identifierExpression.Identifier))
					{
						data = data.Clone();
						analysis.SetLocalVariableValue(data, identifierExpression, NullValueStatus.DefinitelyNotNull);
					}
				}
				return HandleExpressionResult(invocationExpression, GetMethodVisitorResult(cSharpInvocationResolveResult, data, list));
			}

			private static VisitorResult GetMethodVisitorResult(CSharpInvocationResolveResult methodResolveResult, VariableStatusInfo data, List<VisitorResult> parameterResults)
			{
				if (methodResolveResult == null)
				{
					return VisitorResult.ForValue(data, NullValueStatus.Unknown);
				}
				IMethod method = methodResolveResult.Member as IMethod;
				if (method != null && method.GetAttribute(new FullTypeName("JetBrains.Annotations.AssertionMethodAttribute")) != null)
				{
					var list = (from parameter in method.Parameters.Select((IParameter parameter, int index) => new
						{
							index,
							parameter
						})
						select new
						{
							index = parameter.index,
							parameter = parameter.parameter,
							attributes = (from attribute in parameter.parameter.Attributes
								where attribute.AttributeType.FullName == "JetBrains.Annotations.AssertionConditionAttribute"
								select attribute).ToList()
						} into parameter
						where parameter.attributes.Count() == 1
						select new
						{
							index = parameter.index,
							parameter = parameter.parameter,
							attribute = parameter.attributes[0]
						}).ToList();
					if (list.Count() == 1)
					{
						var assertionParameter = list[0];
						VisitorResult visitorResult = null;
						object obj = true;
						MemberResolveResult memberResolveResult = assertionParameter.attribute.PositionalArguments.FirstOrDefault() as MemberResolveResult;
						if (memberResolveResult != null && memberResolveResult.Type.FullName == "JetBrains.Annotations.AssertionConditionType")
						{
							switch (memberResolveResult.Member.FullName)
							{
							case "JetBrains.Annotations.AssertionConditionType.IS_TRUE":
								obj = true;
								break;
							case "JetBrains.Annotations.AssertionConditionType.IS_FALSE":
								obj = false;
								break;
							case "JetBrains.Annotations.AssertionConditionType.IS_NULL":
								obj = null;
								break;
							case "JetBrains.Annotations.AssertionConditionType.IS_NOT_NULL":
								obj = "<not-null>";
								break;
							}
						}
						int index2 = assertionParameter.index;
						if (assertionParameter.index < methodResolveResult.Arguments.Count && !(methodResolveResult.Arguments[assertionParameter.index] is NamedArgumentResolveResult))
						{
							visitorResult = parameterResults[assertionParameter.index];
						}
						else
						{
							int? num = (from argument in methodResolveResult.Arguments.Select((ResolveResult argument, int index) => new
								{
									argument,
									index
								}).Where(argument =>
								{
									NamedArgumentResolveResult namedArgumentResolveResult = argument.argument as NamedArgumentResolveResult;
									return namedArgumentResolveResult != null && namedArgumentResolveResult.ParameterName == assertionParameter.parameter.Name;
								})
								select (int?)argument.index).FirstOrDefault();
							if (num.HasValue)
							{
								index2 = num.Value;
								visitorResult = parameterResults[num.Value];
							}
							else
							{
								if (!assertionParameter.parameter.IsOptional)
								{
									return VisitorResult.ForException(data);
								}
								if (obj is string)
								{
									if (assertionParameter.parameter.ConstantValue == null)
									{
										return VisitorResult.ForException(data);
									}
								}
								else if (!object.Equals(assertionParameter.parameter.ConstantValue, obj))
								{
									return VisitorResult.ForException(data);
								}
							}
						}
						if (visitorResult != null)
						{
							if (obj is bool)
							{
								if (visitorResult.KnownBoolResult == !(bool)obj)
								{
									return VisitorResult.ForException(data);
								}
								data = (((bool)obj) ? visitorResult.TruePathVariables : visitorResult.FalsePathVariables);
							}
							else
							{
								bool flag = obj == null;
								if (visitorResult.NullableReturnResult == (NullValueStatus)(flag ? 5 : 3))
								{
									return VisitorResult.ForException(data);
								}
								ResolveResult resolveResult = methodResolveResult.Arguments[index2];
								LocalResolveResult localResolveResult = null;
								ConversionResolveResult conversionResolveResult = resolveResult as ConversionResolveResult;
								if (conversionResolveResult != null)
								{
									if (!IsTypeNullable(conversionResolveResult.Type))
									{
										if (obj == null)
										{
											return VisitorResult.ForException(data);
										}
									}
									else
									{
										localResolveResult = (conversionResolveResult.Input as LocalResolveResult);
									}
								}
								else
								{
									localResolveResult = (resolveResult as LocalResolveResult);
								}
								if (localResolveResult != null && data[localResolveResult.Variable.Name] != NullValueStatus.CapturedUnknown)
								{
									data = data.Clone();
									data[localResolveResult.Variable.Name] = (flag ? NullValueStatus.DefinitelyNull : NullValueStatus.DefinitelyNotNull);
								}
							}
						}
					}
				}
				if (!IsTypeNullable(methodResolveResult.Type))
				{
					return VisitorResult.ForValue(data, NullValueStatus.DefinitelyNotNull);
				}
				if (method != null)
				{
					return VisitorResult.ForValue(data, GetNullableStatus(method));
				}
				return VisitorResult.ForValue(data, GetNullableStatus(methodResolveResult.TargetResult.Type.GetDefinition()));
			}

			private static NullValueStatus GetNullableStatus(IEntity entity)
			{
				if (entity.DeclaringType != null && entity.DeclaringType.Kind == TypeKind.Delegate)
				{
					return GetNullableStatus(entity.DeclaringTypeDefinition);
				}
				return GetNullableStatus((string fullTypeName) => entity.GetAttribute(new FullTypeName(fullTypeName)));
			}

			private static NullValueStatus GetNullableStatus(IParameter parameter)
			{
				return GetNullableStatus((string fullTypeName) => parameter.Attributes.FirstOrDefault((IAttribute attribute) => attribute.AttributeType.FullName == fullTypeName));
			}

			private static NullValueStatus GetNullableStatus(Func<string, IAttribute> attributeGetter)
			{
				if (attributeGetter("JetBrains.Annotations.NotNullAttribute") != null)
				{
					return NullValueStatus.DefinitelyNotNull;
				}
				if (attributeGetter("JetBrains.Annotations.CanBeNullAttribute") != null)
				{
					return NullValueStatus.PotentiallyNull;
				}
				return NullValueStatus.Unknown;
			}

			public override VisitorResult VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = memberReferenceExpression.Target.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return HandleExpressionResult(memberReferenceExpression, visitorResult);
				}
				VariableStatusInfo variableStatusInfo = visitorResult.Variables;
				MemberResolveResult memberResolveResult = analysis.context.Resolve(memberReferenceExpression) as MemberResolveResult;
				IdentifierExpression identifierExpression = CSharpUtil.GetInnerMostExpression(memberReferenceExpression.Target) as IdentifierExpression;
				if (identifierExpression != null)
				{
					if (memberResolveResult == null)
					{
						InvocationExpression invocationExpression = memberReferenceExpression.Parent as InvocationExpression;
						if (invocationExpression != null)
						{
							memberResolveResult = (analysis.context.Resolve(invocationExpression) as MemberResolveResult);
						}
					}
					if (memberResolveResult != null && memberResolveResult.Member.FullName != "System.Nullable.HasValue")
					{
						IMethod method = memberResolveResult.Member as IMethod;
						if (method == null || !method.IsExtensionMethod)
						{
							if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
							{
								return HandleExpressionResult(memberReferenceExpression, VisitorResult.ForException(variableStatusInfo));
							}
							if (variableStatusInfo[identifierExpression.Identifier] != NullValueStatus.CapturedUnknown)
							{
								variableStatusInfo = variableStatusInfo.Clone();
								analysis.SetLocalVariableValue(variableStatusInfo, identifierExpression, NullValueStatus.DefinitelyNotNull);
							}
						}
					}
				}
				NullValueStatus fieldReturnValue = GetFieldReturnValue(memberResolveResult, data);
				return HandleExpressionResult(memberReferenceExpression, variableStatusInfo, fieldReturnValue);
			}

			private static NullValueStatus GetFieldReturnValue(MemberResolveResult memberResolveResult, VariableStatusInfo data)
			{
				if (memberResolveResult != null && !IsTypeNullable(memberResolveResult.Type))
				{
					return NullValueStatus.DefinitelyNotNull;
				}
				if (memberResolveResult != null)
				{
					return GetNullableStatus(memberResolveResult.Member);
				}
				return NullValueStatus.Unknown;
			}

			public override VisitorResult VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(typeReferenceExpression, data, NullValueStatus.Unknown);
			}

			private void FixParameter(Expression argument, IList<IParameter> parameters, int parameterIndex, IdentifierExpression identifier, VariableStatusInfo data)
			{
				NullValueStatus value = NullValueStatus.Unknown;
				if (argument is NamedArgumentExpression)
				{
					NamedArgumentResolveResult namedArgumentResolveResult = analysis.context.Resolve(argument) as NamedArgumentResolveResult;
					if (namedArgumentResolveResult != null)
					{
						value = GetNullableStatus(namedArgumentResolveResult.Parameter);
					}
				}
				else
				{
					value = GetNullableStatus(parameters[parameterIndex]);
				}
				analysis.SetLocalVariableValue(data, identifier, value);
			}

			public override VisitorResult VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, VariableStatusInfo data)
			{
				foreach (var item in objectCreateExpression.Arguments.Select((Expression argument, int parameterIndex) => new
				{
					argument,
					parameterIndex
				}))
				{
					Expression argument2 = item.argument;
					int parameterIndex2 = item.parameterIndex;
					NamedArgumentExpression namedArgumentExpression = argument2 as NamedArgumentExpression;
					DirectionExpression directionExpression = ((namedArgumentExpression == null) ? argument2 : namedArgumentExpression.Expression) as DirectionExpression;
					if (directionExpression != null)
					{
						IdentifierExpression identifierExpression = directionExpression.Expression as IdentifierExpression;
						if (identifierExpression != null && data[identifierExpression.Identifier] != NullValueStatus.CapturedUnknown)
						{
							data = data.Clone();
							CSharpInvocationResolveResult cSharpInvocationResolveResult = analysis.context.Resolve(objectCreateExpression) as CSharpInvocationResolveResult;
							if (cSharpInvocationResolveResult != null)
							{
								FixParameter(argument2, cSharpInvocationResolveResult.Member.Parameters, parameterIndex2, identifierExpression, data);
							}
						}
					}
					else
					{
						VisitorResult visitorResult = argument2.AcceptVisitor(this, data);
						if (visitorResult.ThrowsException)
						{
							return visitorResult;
						}
						data = visitorResult.Variables;
					}
				}
				return HandleExpressionResult(objectCreateExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, VariableStatusInfo data)
			{
				foreach (Expression argument in arrayCreateExpression.Arguments)
				{
					VisitorResult visitorResult = argument.AcceptVisitor(this, data);
					if (visitorResult.ThrowsException)
					{
						return visitorResult;
					}
					data = visitorResult.Variables.Clone();
				}
				if (arrayCreateExpression.Initializer.IsNull)
				{
					return HandleExpressionResult(arrayCreateExpression, data, NullValueStatus.DefinitelyNotNull);
				}
				return HandleExpressionResult(arrayCreateExpression, arrayCreateExpression.Initializer.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, VariableStatusInfo data)
			{
				if (arrayInitializerExpression.IsSingleElement)
				{
					return HandleExpressionResult(arrayInitializerExpression, arrayInitializerExpression.Elements.Single().AcceptVisitor(this, data));
				}
				if (!arrayInitializerExpression.Elements.Any())
				{
					return HandleExpressionResult(arrayInitializerExpression, VisitorResult.ForValue(data, NullValueStatus.Unknown));
				}
				NullValueStatus nullValueStatus = NullValueStatus.UnreachableOrInexistent;
				foreach (Expression element in arrayInitializerExpression.Elements)
				{
					VisitorResult visitorResult = element.AcceptVisitor(this, data);
					if (visitorResult.ThrowsException)
					{
						return visitorResult;
					}
					data = visitorResult.Variables.Clone();
					nullValueStatus = VariableStatusInfo.CombineStatus(nullValueStatus, visitorResult.NullableReturnResult);
				}
				return HandleExpressionResult(arrayInitializerExpression, VisitorResult.ForEnumeratedValue(data, nullValueStatus));
			}

			public override VisitorResult VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression, VariableStatusInfo data)
			{
				foreach (Expression initializer in anonymousTypeCreateExpression.Initializers)
				{
					VisitorResult visitorResult = initializer.AcceptVisitor(this, data);
					if (visitorResult.ThrowsException)
					{
						return visitorResult;
					}
					data = visitorResult.Variables;
				}
				return HandleExpressionResult(anonymousTypeCreateExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitLambdaExpression(LambdaExpression lambdaExpression, VariableStatusInfo data)
			{
				VariableStatusInfo variableStatusInfo = data.Clone();
				foreach (IdentifierExpression item in lambdaExpression.Descendants.OfType<IdentifierExpression>())
				{
					if (item.Parent is AssignmentExpression && item.Role == AssignmentExpression.LeftRole && ((AssignmentExpression)item.Parent).Operator == AssignmentOperatorType.Assign)
					{
						LocalResolveResult localResolveResult = analysis.context.Resolve(item) as LocalResolveResult;
						if (localResolveResult != null && IsTypeNullable(localResolveResult.Type))
						{
							analysis.SetLocalVariableValue(variableStatusInfo, item, NullValueStatus.CapturedUnknown);
						}
					}
				}
				return HandleExpressionResult(lambdaExpression, variableStatusInfo, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, VariableStatusInfo data)
			{
				VariableStatusInfo variableStatusInfo = data.Clone();
				foreach (IdentifierExpression item in anonymousMethodExpression.Descendants.OfType<IdentifierExpression>())
				{
					if (item.Parent is AssignmentExpression && item.Role == AssignmentExpression.LeftRole && ((AssignmentExpression)item.Parent).Operator == AssignmentOperatorType.Assign)
					{
						LocalResolveResult localResolveResult = analysis.context.Resolve(item) as LocalResolveResult;
						if (localResolveResult != null && IsTypeNullable(localResolveResult.Type))
						{
							analysis.SetLocalVariableValue(variableStatusInfo, item, NullValueStatus.CapturedUnknown);
						}
					}
				}
				return HandleExpressionResult(anonymousMethodExpression, variableStatusInfo, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitNamedExpression(NamedExpression namedExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(namedExpression, namedExpression.Expression.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitAsExpression(AsExpression asExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = asExpression.Expression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				NullValueStatus expressionResult;
				if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
				{
					expressionResult = NullValueStatus.DefinitelyNull;
				}
				else
				{
					CastResolveResult castResolveResult = analysis.context.Resolve(asExpression) as CastResolveResult;
					if (castResolveResult == null || castResolveResult.IsError || castResolveResult.Input.Type.Kind == TypeKind.Unknown || castResolveResult.Type.Kind == TypeKind.Unknown)
					{
						expressionResult = NullValueStatus.Unknown;
					}
					else
					{
						Conversion conversion = new CSharpConversions(analysis.context.Compilation).ExplicitConversion(castResolveResult.Input.Type, castResolveResult.Type);
						expressionResult = ((conversion == Conversion.None) ? NullValueStatus.DefinitelyNull : ((conversion != Conversion.IdentityConversion) ? NullValueStatus.PotentiallyNull : visitorResult.NullableReturnResult));
					}
				}
				return HandleExpressionResult(asExpression, visitorResult.Variables, expressionResult);
			}

			public override VisitorResult VisitCastExpression(CastExpression castExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = castExpression.Expression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				NullValueStatus nullValueStatus = (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull) ? NullValueStatus.DefinitelyNull : NullValueStatus.Unknown;
				VariableStatusInfo variableStatusInfo = visitorResult.Variables;
				CastResolveResult castResolveResult = analysis.context.Resolve(castExpression) as CastResolveResult;
				if (castResolveResult != null && !IsTypeNullable(castResolveResult.Type))
				{
					if (nullValueStatus == NullValueStatus.DefinitelyNull)
					{
						return HandleExpressionResult(castExpression, VisitorResult.ForException(visitorResult.Variables));
					}
					IdentifierExpression identifierExpression = CSharpUtil.GetInnerMostExpression(castExpression.Expression) as IdentifierExpression;
					if (identifierExpression != null)
					{
						NullValueStatus nullValueStatus2 = variableStatusInfo[identifierExpression.Identifier];
						if (nullValueStatus2 != NullValueStatus.CapturedUnknown && nullValueStatus2 != NullValueStatus.UnreachableOrInexistent && nullValueStatus2 != NullValueStatus.DefinitelyNotNull)
						{
							variableStatusInfo = variableStatusInfo.Clone();
							variableStatusInfo[identifierExpression.Identifier] = NullValueStatus.DefinitelyNotNull;
						}
					}
					nullValueStatus = NullValueStatus.DefinitelyNotNull;
				}
				return HandleExpressionResult(castExpression, variableStatusInfo, nullValueStatus);
			}

			public override VisitorResult VisitIsExpression(IsExpression isExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = isExpression.Expression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				return HandleExpressionResult(isExpression, visitorResult.Variables, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitDirectionExpression(DirectionExpression directionExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(directionExpression, directionExpression.Expression.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitCheckedExpression(CheckedExpression checkedExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(checkedExpression, checkedExpression.Expression.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitUncheckedExpression(UncheckedExpression uncheckedExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(uncheckedExpression, uncheckedExpression.Expression.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(thisReferenceExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitIndexerExpression(IndexerExpression indexerExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = indexerExpression.Target.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				data = visitorResult.Variables;
				foreach (Expression argument in indexerExpression.Arguments)
				{
					VisitorResult visitorResult2 = argument.AcceptVisitor(this, data);
					if (visitorResult2.ThrowsException)
					{
						return visitorResult2;
					}
					data = visitorResult2.Variables.Clone();
				}
				IdentifierExpression targetAsIdentifier = CSharpUtil.GetInnerMostExpression(indexerExpression.Target) as IdentifierExpression;
				if (targetAsIdentifier != null)
				{
					if (visitorResult.NullableReturnResult == NullValueStatus.DefinitelyNull)
					{
						return HandleExpressionResult(indexerExpression, VisitorResult.ForException(data));
					}
					if (!indexerExpression.Arguments.SelectMany((Expression argument) => argument.DescendantsAndSelf).OfType<IdentifierExpression>().Any((IdentifierExpression identifier) => identifier.Identifier == targetAsIdentifier.Identifier))
					{
						data = data.Clone();
						analysis.SetLocalVariableValue(data, targetAsIdentifier, NullValueStatus.DefinitelyNotNull);
					}
				}
				CSharpInvocationResolveResult cSharpInvocationResolveResult = analysis.context.Resolve(indexerExpression) as CSharpInvocationResolveResult;
				NullValueStatus expressionResult = (cSharpInvocationResolveResult != null && !IsTypeNullable(cSharpInvocationResolveResult.Type)) ? NullValueStatus.DefinitelyNotNull : NullValueStatus.Unknown;
				return HandleExpressionResult(indexerExpression, data, expressionResult);
			}

			public override VisitorResult VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(baseReferenceExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitTypeOfExpression(TypeOfExpression typeOfExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(typeOfExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitSizeOfExpression(SizeOfExpression sizeOfExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(sizeOfExpression, data, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = pointerReferenceExpression.Target.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				return HandleExpressionResult(pointerReferenceExpression, visitorResult.Variables, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitStackAllocExpression(StackAllocExpression stackAllocExpression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = stackAllocExpression.CountExpression.AcceptVisitor(this, data);
				if (visitorResult.ThrowsException)
				{
					return visitorResult;
				}
				return HandleExpressionResult(stackAllocExpression, visitorResult.Variables, NullValueStatus.DefinitelyNotNull);
			}

			public override VisitorResult VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression, VariableStatusInfo data)
			{
				return HandleExpressionResult(namedArgumentExpression, namedArgumentExpression.Expression.AcceptVisitor(this, data));
			}

			public override VisitorResult VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression, VariableStatusInfo data)
			{
				throw new NotImplementedException();
			}

			public override VisitorResult VisitQueryExpression(QueryExpression queryExpression, VariableStatusInfo data)
			{
				VariableStatusInfo variableStatusInfo = data.Clone();
				NullValueStatus? nullValueStatus = null;
				List<QueryClause> list = queryExpression.Clauses.ToList();
				List<int> source = (from item in list.Select((QueryClause clause, int i) => new
					{
						clause,
						i
					})
					where (!(item.clause is QueryFromClause) && !(item.clause is QueryJoinClause)) ? (item.clause is QueryContinuationClause) : true
					select item.i).ToList();
				Dictionary<int, VariableStatusInfo> dictionary = Enumerable.Range(0, list.Count).ToDictionary((int clauseIndex) => clauseIndex, (int clauseIndex) => new VariableStatusInfo());
				Dictionary<int, VariableStatusInfo> dictionary2 = Enumerable.Range(0, list.Count).ToDictionary((int clauseIndex) => clauseIndex, (int clauseIndex) => new VariableStatusInfo());
				VisitorResult visitorResult = null;
				int currentClauseIndex = 0;
				int? num = default(int?);
				while (true)
				{
					VisitorResult visitorResult2 = null;
					QueryClause queryClause = null;
					bool flag = false;
					if (currentClauseIndex >= list.Count)
					{
						flag = true;
					}
					else
					{
						queryClause = list[currentClauseIndex];
						dictionary[currentClauseIndex].ReceiveIncoming(data);
						visitorResult2 = queryClause.AcceptVisitor(this, data);
						data = visitorResult2.Variables;
						visitorResult = visitorResult2;
						if (visitorResult2.KnownBoolResult == false)
						{
							flag = true;
						}
						if (visitorResult2.ThrowsException)
						{
							break;
						}
						dictionary2[currentClauseIndex].ReceiveIncoming(data);
					}
					if (flag)
					{
						while (true)
						{
							num = source.LastOrDefault((int index) => index < currentClauseIndex);
							if (!num.HasValue)
							{
								break;
							}
							currentClauseIndex = num.Value + 1;
							if (!dictionary[currentClauseIndex].ReceiveIncoming(visitorResult.Variables))
							{
								num = null;
								break;
							}
						}
						if (!num.HasValue)
						{
							break;
						}
					}
					else
					{
						if (queryClause is QuerySelectClause)
						{
							variableStatusInfo.ReceiveIncoming(data);
							nullValueStatus = ((!nullValueStatus.HasValue) ? new NullValueStatus?(visitorResult2.EnumeratedValueResult) : new NullValueStatus?(VariableStatusInfo.CombineStatus(nullValueStatus.Value, visitorResult2.EnumeratedValueResult)));
						}
						int num2 = ++currentClauseIndex;
					}
				}
				VariableStatusInfo variableStatusInfo2 = new VariableStatusInfo();
				foreach (int item in from item in list.Select((QueryClause clause, int i) => new
					{
						clause,
						i
					})
					select new
					{
						item,
						item.clause
					} into _003C_003Eh__TransparentIdentifier0
					where (!(_003C_003Eh__TransparentIdentifier0.clause is QueryFromClause) && !(_003C_003Eh__TransparentIdentifier0.clause is QueryContinuationClause) && !(_003C_003Eh__TransparentIdentifier0.clause is QueryJoinClause) && !(_003C_003Eh__TransparentIdentifier0.clause is QuerySelectClause)) ? (_003C_003Eh__TransparentIdentifier0.clause is QueryWhereClause) : true
					select _003C_003Eh__TransparentIdentifier0.item.i)
				{
					variableStatusInfo2.ReceiveIncoming(dictionary2[item]);
				}
				return VisitorResult.ForEnumeratedValue(variableStatusInfo2, nullValueStatus ?? NullValueStatus.Unknown);
			}

			public override VisitorResult VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause, VariableStatusInfo data)
			{
				return IntroduceVariableFromEnumeratedValue(queryContinuationClause.Identifier, queryContinuationClause.PrecedingQuery, data);
			}

			private VisitorResult IntroduceVariableFromEnumeratedValue(string newVariable, Expression expression, VariableStatusInfo data)
			{
				VisitorResult visitorResult = expression.AcceptVisitor(this, data);
				VariableStatusInfo variableStatusInfo = visitorResult.Variables.Clone();
				variableStatusInfo[newVariable] = visitorResult.EnumeratedValueResult;
				return VisitorResult.ForValue(variableStatusInfo, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitQueryFromClause(QueryFromClause queryFromClause, VariableStatusInfo data)
			{
				return IntroduceVariableFromEnumeratedValue(queryFromClause.Identifier, queryFromClause.Expression, data);
			}

			public override VisitorResult VisitQueryJoinClause(QueryJoinClause queryJoinClause, VariableStatusInfo data)
			{
				VisitorResult visitorResult = IntroduceVariableFromEnumeratedValue(queryJoinClause.JoinIdentifier, queryJoinClause.InExpression, data);
				visitorResult = queryJoinClause.OnExpression.AcceptVisitor(this, visitorResult.Variables);
				visitorResult = queryJoinClause.EqualsExpression.AcceptVisitor(this, visitorResult.Variables);
				if (queryJoinClause.IsGroupJoin)
				{
					VariableStatusInfo variableStatusInfo = visitorResult.Variables.Clone();
					analysis.SetLocalVariableValue(variableStatusInfo, queryJoinClause.IntoIdentifierToken, NullValueStatus.DefinitelyNotNull);
					return VisitorResult.ForValue(variableStatusInfo, NullValueStatus.Unknown);
				}
				return visitorResult;
			}

			public override VisitorResult VisitQueryLetClause(QueryLetClause queryLetClause, VariableStatusInfo data)
			{
				VisitorResult visitorResult = queryLetClause.Expression.AcceptVisitor(this, data);
				string identifier = queryLetClause.Identifier;
				VariableStatusInfo variableStatusInfo = visitorResult.Variables.Clone();
				variableStatusInfo[identifier] = visitorResult.NullableReturnResult;
				return VisitorResult.ForValue(variableStatusInfo, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitQuerySelectClause(QuerySelectClause querySelectClause, VariableStatusInfo data)
			{
				VisitorResult visitorResult = querySelectClause.Expression.AcceptVisitor(this, data);
				return VisitorResult.ForEnumeratedValue(visitorResult.Variables, visitorResult.NullableReturnResult);
			}

			public override VisitorResult VisitQueryWhereClause(QueryWhereClause queryWhereClause, VariableStatusInfo data)
			{
				return VisitorResult.ForEnumeratedValue(queryWhereClause.Condition.AcceptVisitor(this, data).TruePathVariables, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitQueryOrderClause(QueryOrderClause queryOrderClause, VariableStatusInfo data)
			{
				foreach (QueryOrdering ordering in queryOrderClause.Orderings)
				{
					data = ordering.AcceptVisitor(this, data).Variables;
				}
				return VisitorResult.ForValue(data, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitQueryOrdering(QueryOrdering queryOrdering, VariableStatusInfo data)
			{
				return VisitorResult.ForValue(queryOrdering.Expression.AcceptVisitor(this, data).Variables, NullValueStatus.Unknown);
			}

			public override VisitorResult VisitQueryGroupClause(QueryGroupClause queryGroupClause, VariableStatusInfo data)
			{
				VisitorResult visitorResult = queryGroupClause.Projection.AcceptVisitor(this, data);
				data = visitorResult.Variables;
				data = queryGroupClause.Key.AcceptVisitor(this, data).Variables;
				return VisitorResult.ForEnumeratedValue(data, visitorResult.NullableReturnResult);
			}
		}

		private readonly BaseRefactoringContext context;

		private readonly NullAnalysisVisitor visitor;

		private List<NullAnalysisNode> allNodes;

		private readonly HashSet<PendingNode> nodesToVisit = new HashSet<PendingNode>();

		private Dictionary<Statement, NullAnalysisNode> nodeBeforeStatementDict;

		private Dictionary<Statement, NullAnalysisNode> nodeAfterStatementDict;

		private readonly Dictionary<Expression, NullValueStatus> expressionResult = new Dictionary<Expression, NullValueStatus>();

		private readonly IEnumerable<ParameterDeclaration> parameters;

		private readonly Statement rootStatement;

		private readonly CancellationToken cancellationToken;

		private int visits;

		public bool IsParametersAreUninitialized
		{
			get;
			set;
		}

		public int NodeVisits => visits;

		public NullValueAnalysis(BaseRefactoringContext context, MethodDeclaration methodDeclaration, CancellationToken cancellationToken)
			: this(context, methodDeclaration.Body, methodDeclaration.Parameters, cancellationToken)
		{
		}

		public NullValueAnalysis(BaseRefactoringContext context, Statement rootStatement, IEnumerable<ParameterDeclaration> parameters, CancellationToken cancellationToken)
		{
			if (rootStatement == null)
			{
				throw new ArgumentNullException("rootStatement");
			}
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			this.context = context;
			this.rootStatement = rootStatement;
			this.parameters = parameters;
			visitor = new NullAnalysisVisitor(this);
			this.cancellationToken = cancellationToken;
		}

		private bool SetLocalVariableValue(VariableStatusInfo data, AstNode identifierNode, string identifierName, NullValueStatus value)
		{
			if (context.Resolve(identifierNode) is LocalResolveResult && data[identifierName] != NullValueStatus.CapturedUnknown)
			{
				data[identifierName] = value;
				return true;
			}
			return false;
		}

		private bool SetLocalVariableValue(VariableStatusInfo data, IdentifierExpression identifierExpression, NullValueStatus value)
		{
			return SetLocalVariableValue(data, identifierExpression, identifierExpression.Identifier, value);
		}

		private bool SetLocalVariableValue(VariableStatusInfo data, Identifier identifier, NullValueStatus value)
		{
			return SetLocalVariableValue(data, identifier, identifier.Name, value);
		}

		private void SetupNode(NullAnalysisNode node)
		{
			foreach (ParameterDeclaration parameter in parameters)
			{
				ResolveResult resolveResult = context.Resolve(parameter.Type);
				node.VariableState[parameter.Name] = GetInitialVariableStatus(resolveResult);
			}
			nodesToVisit.Add(new PendingNode(node, node.VariableState));
		}

		private static bool IsTypeNullable(IType type)
		{
			if (type.IsReferenceType != true)
			{
				return type.FullName == "System.Nullable";
			}
			return true;
		}

		private NullValueStatus GetInitialVariableStatus(ResolveResult resolveResult)
		{
			TypeResolveResult typeResolveResult = resolveResult as TypeResolveResult;
			if (typeResolveResult == null)
			{
				return NullValueStatus.Error;
			}
			IType type = typeResolveResult.Type;
			if (!type.IsReferenceType.HasValue)
			{
				return NullValueStatus.Error;
			}
			if (!IsParametersAreUninitialized)
			{
				return NullValueStatus.DefinitelyNotNull;
			}
			if (!IsTypeNullable(type))
			{
				return NullValueStatus.DefinitelyNotNull;
			}
			return NullValueStatus.PotentiallyNull;
		}

		public void Analyze()
		{
			NullAnalysisGraphBuilder nullAnalysisGraphBuilder = new NullAnalysisGraphBuilder();
			allNodes = nullAnalysisGraphBuilder.BuildControlFlowGraph(rootStatement, cancellationToken).Cast<NullAnalysisNode>().ToList();
			nodeBeforeStatementDict = (from node in allNodes
				where (node.Type != ControlFlowNodeType.StartNode) ? (node.Type == ControlFlowNodeType.BetweenStatements) : true
				select node).ToDictionary((NullAnalysisNode node) => node.NextStatement);
			nodeAfterStatementDict = (from node in allNodes
				where (node.Type != ControlFlowNodeType.BetweenStatements) ? (node.Type == ControlFlowNodeType.EndNode) : true
				select node).ToDictionary((NullAnalysisNode node) => node.PreviousStatement);
			foreach (NullAnalysisNode allNode in allNodes)
			{
				if (allNode.Type == ControlFlowNodeType.StartNode && allNode.NextStatement == rootStatement)
				{
					SetupNode(allNode);
				}
			}
			while (nodesToVisit.Any())
			{
				PendingNode pendingNode = nodesToVisit.First();
				nodesToVisit.Remove(pendingNode);
				Visit(pendingNode);
			}
		}

		private void Visit(PendingNode nodeInfo)
		{
			cancellationToken.ThrowIfCancellationRequested();
			NullAnalysisNode nodeToVisit = nodeInfo.nodeToVisit;
			VariableStatusInfo variableStatusInfo = nodeInfo.statusInfo;
			visits++;
			if (visits > 100)
			{
				nodesToVisit.RemoveWhere((PendingNode candidate) => candidate.nodeToVisit == nodeInfo.nodeToVisit && candidate.pendingTryFinallyNodes.Equals(nodeInfo.pendingTryFinallyNodes) && candidate.nodeAfterFinally == nodeInfo.nodeAfterFinally);
				variableStatusInfo = nodeToVisit.VariableState;
			}
			Statement nextStatement = nodeToVisit.NextStatement;
			VariableStatusInfo variableStatusInfo2 = variableStatusInfo;
			VisitorResult visitorResult = null;
			if (nextStatement != null && (!(nextStatement is DoWhileStatement) || nodeToVisit.Type == ControlFlowNodeType.LoopCondition))
			{
				visitorResult = nextStatement.AcceptVisitor(visitor, variableStatusInfo);
				if (visitorResult == null)
				{
					Console.WriteLine("Failure in {0}", nextStatement);
					throw new InvalidOperationException();
				}
				variableStatusInfo2 = visitorResult.Variables;
			}
			if ((visitorResult == null || !visitorResult.ThrowsException) && nodeToVisit.Outgoing.Any())
			{
				TryCatchStatement tryCatchStatement = nextStatement as TryCatchStatement;
				foreach (ControlFlowEdge outgoingEdge in nodeToVisit.Outgoing)
				{
					VariableStatusInfo variableStatusInfo3 = variableStatusInfo2.Clone();
					if (nodeToVisit.Type == ControlFlowNodeType.EndNode)
					{
						BlockStatement blockStatement = nodeToVisit.PreviousStatement as BlockStatement;
						if (blockStatement != null)
						{
							foreach (VariableInitializer item in blockStatement.Statements.OfType<VariableDeclarationStatement>().SelectMany((VariableDeclarationStatement declaration) => declaration.Variables))
							{
								variableStatusInfo3[item.Name] = NullValueStatus.UnreachableOrInexistent;
							}
						}
					}
					if (tryCatchStatement != null)
					{
						if (outgoingEdge.To.NextStatement == tryCatchStatement.FinallyBlock)
						{
							foreach (IdentifierExpression item2 in tryCatchStatement.TryBlock.Descendants.OfType<IdentifierExpression>())
							{
								SetLocalVariableValue(variableStatusInfo3, item2, NullValueStatus.Unknown);
							}
						}
						else
						{
							CatchClause catchClause = tryCatchStatement.CatchClauses.FirstOrDefault((CatchClause candidateClause) => candidateClause.Body == outgoingEdge.To.NextStatement);
							if (catchClause != null)
							{
								SetLocalVariableValue(variableStatusInfo3, catchClause.VariableNameToken, NullValueStatus.DefinitelyNotNull);
								foreach (IdentifierExpression item3 in tryCatchStatement.TryBlock.Descendants.OfType<IdentifierExpression>())
								{
									SetLocalVariableValue(variableStatusInfo3, item3, NullValueStatus.Unknown);
								}
							}
						}
					}
					if (visitorResult != null)
					{
						switch (outgoingEdge.Type)
						{
						case ControlFlowEdgeType.ConditionTrue:
							if (visitorResult.KnownBoolResult == false)
							{
								continue;
							}
							variableStatusInfo3 = visitorResult.TruePathVariables;
							break;
						case ControlFlowEdgeType.ConditionFalse:
							if (visitorResult.KnownBoolResult == true)
							{
								continue;
							}
							variableStatusInfo3 = visitorResult.FalsePathVariables;
							break;
						}
					}
					if (outgoingEdge.IsLeavingTryFinally)
					{
						NullAnalysisNode nodeAfterFinally = (NullAnalysisNode)outgoingEdge.To;
						List<NullAnalysisNode> source = (from tryFinally in outgoingEdge.TryFinallyStatements
							select nodeBeforeStatementDict[tryFinally.FinallyBlock]).ToList();
						NullAnalysisNode nullAnalysisNode = source.First();
						ComparableList<NullAnalysisNode> pendingFinallyNodes = new ComparableList<NullAnalysisNode>(source.Skip(1));
						nullAnalysisNode.ReceiveIncoming(variableStatusInfo3);
						nodesToVisit.Add(new PendingNode(nullAnalysisNode, variableStatusInfo3, pendingFinallyNodes, nodeAfterFinally));
					}
					else
					{
						NullAnalysisNode nullAnalysisNode2 = (NullAnalysisNode)outgoingEdge.To;
						if (nullAnalysisNode2.ReceiveIncoming(variableStatusInfo3))
						{
							nodesToVisit.Add(new PendingNode(nullAnalysisNode2, variableStatusInfo3));
						}
					}
				}
				return;
			}
			ComparableList<NullAnalysisNode> pendingTryFinallyNodes = nodeInfo.pendingTryFinallyNodes;
			NullAnalysisNode nodeAfterFinally2 = nodeInfo.nodeAfterFinally;
			if (pendingTryFinallyNodes.Any())
			{
				NullAnalysisNode nullAnalysisNode3 = pendingTryFinallyNodes.First();
				if (nullAnalysisNode3.ReceiveIncoming(variableStatusInfo2))
				{
					nodesToVisit.Add(new PendingNode(nullAnalysisNode3, variableStatusInfo2, new ComparableList<NullAnalysisNode>(pendingTryFinallyNodes.Skip(1)), nodeInfo.nodeAfterFinally));
				}
				return;
			}
			if (nodeAfterFinally2 != null && nodeAfterFinally2.ReceiveIncoming(variableStatusInfo2))
			{
				nodesToVisit.Add(new PendingNode(nodeAfterFinally2, variableStatusInfo2));
				return;
			}
			TryCatchStatement tryCatchStatement2 = (nodeToVisit.PreviousStatement ?? nodeToVisit.NextStatement).GetParent<Statement>() as TryCatchStatement;
			if (tryCatchStatement2 != null)
			{
				NullAnalysisNode nullAnalysisNode4 = nodeAfterStatementDict[tryCatchStatement2];
				if (nullAnalysisNode4.ReceiveIncoming(variableStatusInfo2))
				{
					nodesToVisit.Add(new PendingNode(nullAnalysisNode4, variableStatusInfo2));
				}
			}
		}

		public NullValueStatus GetExpressionResult(Expression expr)
		{
			if (expr == null)
			{
				throw new ArgumentNullException("expr");
			}
			if (expressionResult.TryGetValue(expr, out NullValueStatus value))
			{
				return value;
			}
			return NullValueStatus.UnreachableOrInexistent;
		}

		public NullValueStatus GetVariableStatusBeforeStatement(Statement stmt, string variableName)
		{
			if (stmt == null)
			{
				throw new ArgumentNullException("stmt");
			}
			if (variableName == null)
			{
				throw new ArgumentNullException("variableName");
			}
			if (nodeBeforeStatementDict.TryGetValue(stmt, out NullAnalysisNode value))
			{
				return value.VariableState[variableName];
			}
			return NullValueStatus.UnreachableOrInexistent;
		}

		public NullValueStatus GetVariableStatusAfterStatement(Statement stmt, string variableName)
		{
			if (stmt == null)
			{
				throw new ArgumentNullException("stmt");
			}
			if (variableName == null)
			{
				throw new ArgumentNullException("variableName");
			}
			if (nodeAfterStatementDict.TryGetValue(stmt, out NullAnalysisNode value))
			{
				return value.VariableState[variableName];
			}
			return NullValueStatus.UnreachableOrInexistent;
		}
	}
}
