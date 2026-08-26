#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class DeclareVariables : IAstTransform
{
	[DebuggerDisplay("level = {level}, nextNode = {nextNode}")]
	private struct InsertionPoint
	{
		internal int level;

		internal AstNode nextNode;

		internal InsertionPoint Up()
		{
			return new InsertionPoint
			{
				level = checked(level - 1),
				nextNode = nextNode.Parent
			};
		}

		internal InsertionPoint UpTo(int targetLevel)
		{
			InsertionPoint result = this;
			checked
			{
				while (result.level > targetLevel)
				{
					result.nextNode = result.nextNode.Parent;
					result.level--;
				}
				return result;
			}
		}
	}

	[DebuggerDisplay("VariableToDeclare(Name={Name})")]
	private class VariableToDeclare
	{
		public readonly ILVariable ILVariable;

		public bool DefaultInitialization;

		public int SourceOrder;

		public InsertionPoint InsertionPoint;

		public IdentifierExpression FirstUse;

		public VariableToDeclare ReplacementDueToCollision;

		public IType Type => ILVariable.Type;

		public string Name => ILVariable.Name;

		public bool RemovedDueToCollision => ReplacementDueToCollision != null;

		public VariableToDeclare(ILVariable variable, bool defaultInitialization, InsertionPoint insertionPoint, IdentifierExpression firstUse, int sourceOrder)
		{
			ILVariable = variable;
			DefaultInitialization = defaultInitialization;
			InsertionPoint = insertionPoint;
			FirstUse = firstUse;
			SourceOrder = sourceOrder;
		}
	}

	private readonly Dictionary<ILVariable, VariableToDeclare> variableDict = new Dictionary<ILVariable, VariableToDeclare>();

	private TransformContext context;

	private List<(InsertionPoint InsertionPoint, BlockContainer Scope)> scopeTracking = new List<(InsertionPoint, BlockContainer)>();

	public void Run(AstNode rootNode, TransformContext context)
	{
		try
		{
			if (this.context != null)
			{
				throw new InvalidOperationException("Reentrancy in DeclareVariables?");
			}
			this.context = context;
			variableDict.Clear();
			EnsureExpressionStatementsAreValid(rootNode);
			FindInsertionPoints(rootNode, 0);
			ResolveCollisions();
			InsertVariableDeclarations(context);
			UpdateAnnotations(rootNode);
		}
		finally
		{
			this.context = null;
			variableDict.Clear();
		}
	}

	public void Analyze(AstNode rootNode)
	{
		variableDict.Clear();
		FindInsertionPoints(rootNode, 0);
		ResolveCollisions();
	}

	public AstNode GetDeclarationPoint(ILVariable variable)
	{
		VariableToDeclare variableToDeclare = variableDict[variable];
		while (variableToDeclare.ReplacementDueToCollision != null)
		{
			variableToDeclare = variableToDeclare.ReplacementDueToCollision;
		}
		return variableToDeclare.InsertionPoint.nextNode;
	}

	public void ClearAnalysisResults()
	{
		variableDict.Clear();
	}

	private void EnsureExpressionStatementsAreValid(AstNode rootNode)
	{
		foreach (ExpressionStatement item in Enumerable.OfType<ExpressionStatement>((IEnumerable)rootNode.DescendantsAndSelf))
		{
			if (!IsValidInStatementExpression(item.Expression))
			{
				ILFunction iLFunction = Enumerable.First<ILFunction>(Enumerable.SelectMany<AstNode, ILFunction>(item.Ancestors, (Func<AstNode, IEnumerable<ILFunction>>)((AstNode a) => Enumerable.OfType<ILFunction>((IEnumerable)a.Annotations))), (Func<ILFunction, bool>)((ILFunction f) => f.Parent == null));
				IType type = item.Expression.GetResolveResult().Type;
				ILVariable iLVariable = iLFunction.RegisterVariable(VariableKind.StackSlot, type, AssignVariableNames.GenerateVariableName(iLFunction, type, Enumerable.FirstOrDefault<ILInstruction>(Enumerable.Where<ILInstruction>(Enumerable.OfType<ILInstruction>((IEnumerable)item.Expression.Annotations), (Func<ILInstruction, bool>)AssignVariableNames.IsSupportedInstruction))));
				item.Expression = new AssignmentExpression(new IdentifierExpression(iLVariable.Name).WithRR(new ILVariableResolveResult(iLVariable, iLVariable.Type)), item.Expression.Detach());
			}
		}
	}

	private static bool IsValidInStatementExpression(Expression expr)
	{
		if (expr != null)
		{
			InvocationExpression invocationExpression;
			ObjectCreateExpression objectCreateExpression;
			AssignmentExpression assignmentExpression;
			ErrorExpression errorExpression;
			if ((invocationExpression = expr as InvocationExpression) != null || (objectCreateExpression = expr as ObjectCreateExpression) != null || (assignmentExpression = expr as AssignmentExpression) != null || (errorExpression = expr as ErrorExpression) != null)
			{
				return true;
			}
			if (expr is UnaryOperatorExpression unaryOperatorExpression)
			{
				UnaryOperatorExpression unaryOperatorExpression2 = unaryOperatorExpression;
				switch (unaryOperatorExpression2.Operator)
				{
				case UnaryOperatorType.Increment:
				case UnaryOperatorType.Decrement:
				case UnaryOperatorType.PostIncrement:
				case UnaryOperatorType.PostDecrement:
				case UnaryOperatorType.Await:
					return true;
				case UnaryOperatorType.NullConditionalRewrap:
					return IsValidInStatementExpression(unaryOperatorExpression2.Expression);
				default:
					return false;
				}
			}
		}
		return false;
	}

	private void FindInsertionPoints(AstNode node, int nodeLevel)
	{
		BlockContainer blockContainer = node.Annotation<BlockContainer>();
		if (blockContainer != null && (blockContainer.EntryPoint.IncomingEdgeCount > 1 || blockContainer.Parent is ILFunction))
		{
			scopeTracking.Add((new InsertionPoint
			{
				level = nodeLevel,
				nextNode = node
			}, blockContainer));
		}
		else
		{
			blockContainer = null;
		}
		checked
		{
			try
			{
				for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
				{
					FindInsertionPoints(astNode, nodeLevel + 1);
				}
				if (!(node is IdentifierExpression identifierExpression) || !(identifierExpression.GetResolveResult() is ILVariableResolveResult iLVariableResolveResult) || !VariableNeedsDeclaration(iLVariableResolveResult.Variable.Kind))
				{
					return;
				}
				ILVariable variable = iLVariableResolveResult.Variable;
				int num = scopeTracking.Count - 1;
				InsertionPoint insertionPoint;
				if (variable.CaptureScope != null && num > 0 && variable.CaptureScope != scopeTracking[num].Scope)
				{
					while (num > 0 && scopeTracking[num].Scope != variable.CaptureScope)
					{
						num--;
					}
					insertionPoint = scopeTracking[num + 1].InsertionPoint;
				}
				else
				{
					insertionPoint = new InsertionPoint
					{
						level = nodeLevel,
						nextNode = identifierExpression
					};
					if (variable.HasInitialValue)
					{
						while (num >= 0)
						{
							if (scopeTracking[num].Scope.EntryPoint.IncomingEdgeCount > 1)
							{
								insertionPoint = scopeTracking[num].InsertionPoint;
							}
							else if (scopeTracking[num].Scope.Parent is ILFunction)
							{
								break;
							}
							num--;
						}
					}
				}
				if (variableDict.TryGetValue(variable, out var value))
				{
					value.InsertionPoint = FindCommonParent(value.InsertionPoint, insertionPoint);
					return;
				}
				value = new VariableToDeclare(variable, variable.HasInitialValue, insertionPoint, identifierExpression, variableDict.Count);
				variableDict.Add(iLVariableResolveResult.Variable, value);
			}
			finally
			{
				if (blockContainer != null)
				{
					scopeTracking.RemoveAt(scopeTracking.Count - 1);
				}
			}
		}
	}

	private bool VariableNeedsDeclaration(VariableKind kind)
	{
		if ((uint)(kind - 1) <= 2u || (uint)(kind - 5) <= 2u)
		{
			return false;
		}
		return true;
	}

	private InsertionPoint FindCommonParent(InsertionPoint oldPoint, InsertionPoint newPoint)
	{
		oldPoint = oldPoint.UpTo(newPoint.level);
		newPoint = newPoint.UpTo(oldPoint.level);
		Debug.Assert(newPoint.level == oldPoint.level);
		while (oldPoint.nextNode.Parent != newPoint.nextNode.Parent)
		{
			oldPoint = oldPoint.Up();
			newPoint = newPoint.Up();
		}
		return oldPoint;
	}

	private void ResolveCollisions()
	{
		MultiDictionary<string, VariableToDeclare> multiDictionary = new MultiDictionary<string, VariableToDeclare>();
		foreach (VariableToDeclare value in variableDict.Values)
		{
			AssignmentExpression assignment;
			while (!(value.InsertionPoint.nextNode.Parent is BlockStatement) && (!(value.InsertionPoint.nextNode.Parent is ForStatement forStatement) || value.InsertionPoint.nextNode != Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)forStatement.Initializers) || !IsMatchingAssignment(value, out assignment)))
			{
				value.InsertionPoint = value.InsertionPoint.Up();
			}
			foreach (VariableToDeclare item in multiDictionary[value.Name])
			{
				if (item.RemovedDueToCollision)
				{
					continue;
				}
				InsertionPoint insertionPoint = item.InsertionPoint.UpTo(value.InsertionPoint.level);
				InsertionPoint insertionPoint2 = value.InsertionPoint.UpTo(item.InsertionPoint.level);
				Debug.Assert(insertionPoint.level == insertionPoint2.level);
				if (insertionPoint.nextNode.Parent == insertionPoint2.nextNode.Parent)
				{
					item.ReplacementDueToCollision = value;
					if (item.SourceOrder < value.SourceOrder)
					{
						value.InsertionPoint = insertionPoint;
						value.SourceOrder = item.SourceOrder;
						value.FirstUse = item.FirstUse;
					}
					else
					{
						value.InsertionPoint = insertionPoint2;
					}
					value.DefaultInitialization |= item.DefaultInitialization;
				}
			}
			multiDictionary.Add(value.Name, value);
		}
	}

	private bool IsMatchingAssignment(VariableToDeclare v, out AssignmentExpression assignment)
	{
		assignment = v.InsertionPoint.nextNode as AssignmentExpression;
		if (assignment == null)
		{
			assignment = (v.InsertionPoint.nextNode as ExpressionStatement)?.Expression as AssignmentExpression;
			if (assignment == null)
			{
				return false;
			}
		}
		return assignment.Operator == AssignmentOperatorType.Assign && assignment.Left is IdentifierExpression identifierExpression && identifierExpression.Identifier == v.Name && identifierExpression.TypeArguments.Count == 0;
	}

	private void InsertVariableDeclarations(TransformContext context)
	{
		List<(AstNode, AstNode)> list = new List<(AstNode, AstNode)>();
		foreach (var (v, variableToDeclare2) in variableDict)
		{
			if (variableToDeclare2.RemovedDueToCollision)
			{
				continue;
			}
			DirectionExpression dirExpr;
			if (IsMatchingAssignment(variableToDeclare2, out var assignment))
			{
				AstType type = ((!context.Settings.AnonymousTypes || !variableToDeclare2.Type.ContainsAnonymousType()) ? context.TypeSystemAstBuilder.ConvertType(variableToDeclare2.Type) : new SimpleType("var"));
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(type, variableToDeclare2.Name, assignment.Right.Detach());
				VariableInitializer variableInitializer = Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)variableDeclarationStatement.Variables);
				variableInitializer.AddAnnotation(assignment.Left.GetResolveResult());
				foreach (object item in Enumerable.Concat<object>(assignment.Left.Annotations, assignment.Annotations))
				{
					if (!(item is ResolveResult))
					{
						variableInitializer.AddAnnotation(item);
					}
				}
				list.Add((variableToDeclare2.InsertionPoint.nextNode, variableDeclarationStatement));
			}
			else if (CanBeDeclaredAsOutVariable(variableToDeclare2, out dirExpr))
			{
				AstType type2 = ((!context.Settings.AnonymousTypes || !variableToDeclare2.Type.ContainsAnonymousType()) ? context.TypeSystemAstBuilder.ConvertType(variableToDeclare2.Type) : new SimpleType("var"));
				string name = ((!context.Settings.Discards || variableToDeclare2.ILVariable.LoadCount != 0 || variableToDeclare2.ILVariable.StoreCount != 0 || variableToDeclare2.ILVariable.AddressCount != 1) ? variableToDeclare2.Name : "_");
				OutVarDeclarationExpression outVarDeclarationExpression = new OutVarDeclarationExpression(type2, name);
				outVarDeclarationExpression.Variable.AddAnnotation(new ILVariableResolveResult(v));
				outVarDeclarationExpression.CopyAnnotationsFrom(dirExpr);
				list.Add((dirExpr, outVarDeclarationExpression));
			}
			else
			{
				Expression initializer = null;
				AstType astType = context.TypeSystemAstBuilder.ConvertType(variableToDeclare2.Type);
				if (variableToDeclare2.DefaultInitialization)
				{
					initializer = new DefaultValueExpression(astType.Clone());
				}
				VariableDeclarationStatement variableDeclarationStatement2 = new VariableDeclarationStatement(astType, variableToDeclare2.Name, initializer);
				Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)variableDeclarationStatement2.Variables).AddAnnotation(new ILVariableResolveResult(v));
				Debug.Assert(variableToDeclare2.InsertionPoint.nextNode.Role == BlockStatement.StatementRole);
				variableToDeclare2.InsertionPoint.nextNode.Parent.InsertChildBefore(variableToDeclare2.InsertionPoint.nextNode, variableDeclarationStatement2, BlockStatement.StatementRole);
			}
		}
		foreach (var (astNode, newNode) in list)
		{
			astNode.ReplaceWith(newNode);
		}
	}

	private bool CanBeDeclaredAsOutVariable(VariableToDeclare v, out DirectionExpression dirExpr)
	{
		dirExpr = v.FirstUse.Parent as DirectionExpression;
		if (dirExpr == null || dirExpr.FieldDirection != FieldDirection.Out)
		{
			return false;
		}
		if (!context.Settings.OutVariables)
		{
			return false;
		}
		if (v.DefaultInitialization)
		{
			return false;
		}
		for (AstNode astNode = v.FirstUse; astNode != null; astNode = astNode.Parent)
		{
			if (astNode.Role == Roles.EmbeddedStatement)
			{
				return false;
			}
			AstNode astNode2 = astNode;
			AstNode astNode3 = astNode2;
			if (astNode3 != null)
			{
				IfElseStatement ifElseStatement;
				ExpressionStatement expressionStatement;
				if ((ifElseStatement = astNode3 as IfElseStatement) != null || (expressionStatement = astNode3 as ExpressionStatement) != null)
				{
					return astNode == v.InsertionPoint.nextNode;
				}
				if (astNode3 is Statement)
				{
					return false;
				}
			}
		}
		return false;
	}

	private void UpdateAnnotations(AstNode rootNode)
	{
		foreach (AstNode descendant in rootNode.Descendants)
		{
			AstNode astNode = descendant;
			AstNode astNode2 = astNode;
			if (astNode2 == null)
			{
				continue;
			}
			ILVariable iLVariable;
			if (!(astNode2 is IdentifierExpression identifierExpression))
			{
				if (!(astNode2 is VariableInitializer variableInitializer))
				{
					continue;
				}
				VariableInitializer vi = variableInitializer;
				iLVariable = vi.GetILVariable();
			}
			else
			{
				IdentifierExpression expr = identifierExpression;
				iLVariable = expr.GetILVariable();
			}
			if (iLVariable == null || !VariableNeedsDeclaration(iLVariable.Kind))
			{
				continue;
			}
			VariableToDeclare variableToDeclare = variableDict[iLVariable];
			if (variableToDeclare.RemovedDueToCollision)
			{
				while (variableToDeclare.RemovedDueToCollision)
				{
					variableToDeclare = variableToDeclare.ReplacementDueToCollision;
				}
				descendant.RemoveAnnotations<ILVariableResolveResult>();
				descendant.AddAnnotation(new ILVariableResolveResult(variableToDeclare.ILVariable, variableToDeclare.Type));
			}
		}
	}
}
