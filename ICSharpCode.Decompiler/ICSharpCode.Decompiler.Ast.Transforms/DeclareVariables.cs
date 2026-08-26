using System.Collections.Generic;
using System.Linq;
using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Analysis;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class DeclareVariables : IAstTransformPoolObject, IAstTransform
{
	private sealed class VariableToDeclare
	{
		public AstType Type;

		public Modifiers Modifiers;

		public string Name;

		public ILVariable ILVariable;

		public AssignmentExpression ReplacedAssignment;

		public Statement InsertionPoint;
	}

	private DecompilerContext context;

	private CancellationToken cancellationToken;

	private readonly List<VariableToDeclare> variablesToDeclare = new List<VariableToDeclare>();

	public DeclareVariables(DecompilerContext context)
	{
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		this.context = context;
		cancellationToken = context.CancellationToken;
		variablesToDeclare.Clear();
	}

	public void Run(AstNode node)
	{
		Run(node, null);
		foreach (VariableToDeclare item in variablesToDeclare)
		{
			if (item.ReplacedAssignment == null)
			{
				BlockStatement blockStatement = (BlockStatement)item.InsertionPoint.Parent;
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement((item.ILVariable != null && item.ILVariable.IsParameter) ? BoxedTextColor.Parameter : BoxedTextColor.Local, item.Type.Clone(), item.Name);
				if (item.ILVariable != null)
				{
					variableDeclarationStatement.Variables.Single().AddAnnotation(item.ILVariable);
				}
				blockStatement.Statements.InsertBefore(item.InsertionPoint, variableDeclarationStatement);
			}
		}
		foreach (VariableToDeclare item2 in variablesToDeclare)
		{
			if (item2.ReplacedAssignment != null)
			{
				MethodDef methodDef = item2.ReplacedAssignment.Right.Annotation<IMethod>().ResolveMethodDef();
				bool flag = methodDef != null && methodDef.ReturnType.RemovePinnedAndModifiers().GetElementType() == ElementType.ByRef;
				bool flag2 = flag && DnlibExtensions.HasIsReadOnlyAttribute(methodDef.Parameters.ReturnParameter.ParamDef);
				VariableInitializer variableInitializer = new VariableInitializer((item2.ILVariable != null && item2.ILVariable.IsParameter) ? BoxedTextColor.Parameter : BoxedTextColor.Local, item2.Name, item2.ReplacedAssignment.Right.Detach()).CopyAnnotationsFrom(item2.ReplacedAssignment).WithAnnotation(item2.ILVariable);
				VariableDeclarationStatement variableDeclarationStatement2 = new VariableDeclarationStatement
				{
					Type = item2.Type.Clone(),
					Variables = { variableInitializer },
					Modifiers = item2.Modifiers
				};
				if (flag)
				{
					variableInitializer.Modifiers |= Modifiers.Ref;
				}
				if (flag2)
				{
					variableDeclarationStatement2.Modifiers |= Modifiers.Readonly;
				}
				if (item2.ReplacedAssignment.Parent is ExpressionStatement expressionStatement)
				{
					expressionStatement.ReplaceWith(variableDeclarationStatement2.CopyAnnotationsFrom(expressionStatement));
					variableDeclarationStatement2.AddAnnotation(expressionStatement.GetAllRecursiveILSpans());
				}
				else
				{
					variableDeclarationStatement2.AddAnnotation(item2.ReplacedAssignment.GetAllRecursiveILSpans());
					item2.ReplacedAssignment.ReplaceWith(variableDeclarationStatement2);
				}
			}
		}
		variablesToDeclare.Clear();
	}

	private void Run(AstNode node, DefiniteAssignmentAnalysis daa)
	{
		if (node is BlockStatement blockStatement)
		{
			List<VariableDeclarationStatement> list = blockStatement.Statements.TakeWhile((Statement stmt) => stmt is VariableDeclarationStatement).Cast<VariableDeclarationStatement>().ToList();
			if (list.Count > 0)
			{
				foreach (VariableDeclarationStatement item in list)
				{
					item.Remove();
				}
				if (daa == null)
				{
					daa = new DefiniteAssignmentAnalysis(blockStatement, cancellationToken);
				}
				foreach (VariableDeclarationStatement item2 in list)
				{
					VariableInitializer variableInitializer = item2.Variables.Single();
					string name = variableInitializer.Name;
					ILVariable v = variableInitializer.Annotation<ILVariable>();
					bool allowPassIntoLoops = variableInitializer.Annotation<DelegateConstruction.CapturedVariableAnnotation>() == null;
					DeclareVariableInBlock(daa, blockStatement, item2.Type, name, v, item2.Modifiers, allowPassIntoLoops);
				}
			}
		}
		for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			Run(astNode, daa);
		}
	}

	private void DeclareVariableInBlock(DefiniteAssignmentAnalysis daa, BlockStatement block, AstType type, string variableName, ILVariable v, Modifiers modifiers, bool allowPassIntoLoops)
	{
		Statement declarationPoint = null;
		bool flag = FindDeclarationPoint(daa, variableName, allowPassIntoLoops, block, out declarationPoint, cancellationToken);
		if (declarationPoint == null)
		{
			return;
		}
		if (flag)
		{
			foreach (Statement statement in block.Statements)
			{
				if ((!(statement is ForStatement forStatement) || forStatement.Initializers.Count != 1 || !TryConvertAssignmentExpressionIntoVariableDeclaration(forStatement.Initializers.Single(), type, variableName, modifiers)) && (!(statement is UsingStatement usingStatement) || !(usingStatement.ResourceAcquisition is AssignmentExpression) || !TryConvertAssignmentExpressionIntoVariableDeclaration((Expression)usingStatement.ResourceAcquisition, type, variableName, modifiers)))
				{
					if (statement is IfElseStatement ies)
					{
						foreach (AstNode item in IfElseChainChildren(ies))
						{
							if (item is BlockStatement block2)
							{
								DeclareVariableInBlock(daa, block2, type, variableName, v, modifiers, allowPassIntoLoops);
							}
						}
					}
					else
					{
						foreach (AstNode child in statement.Children)
						{
							if (child is BlockStatement block3)
							{
								DeclareVariableInBlock(daa, block3, type, variableName, v, modifiers, allowPassIntoLoops);
							}
							else if (HasNestedBlocks(child))
							{
								foreach (BlockStatement item2 in child.Children.OfType<BlockStatement>())
								{
									DeclareVariableInBlock(daa, item2, type, variableName, v, modifiers, allowPassIntoLoops);
								}
							}
						}
					}
				}
			}
			return;
		}
		if (!TryConvertAssignmentExpressionIntoVariableDeclaration(declarationPoint, type, variableName, modifiers))
		{
			variablesToDeclare.Add(new VariableToDeclare
			{
				Type = type,
				Name = variableName,
				ILVariable = v,
				InsertionPoint = declarationPoint,
				Modifiers = modifiers
			});
		}
	}

	private bool TryConvertAssignmentExpressionIntoVariableDeclaration(Statement declarationPoint, AstType type, string variableName, Modifiers modifiers)
	{
		if (declarationPoint is ExpressionStatement expressionStatement)
		{
			return TryConvertAssignmentExpressionIntoVariableDeclaration(expressionStatement.Expression, type, variableName, modifiers);
		}
		return false;
	}

	private bool TryConvertAssignmentExpressionIntoVariableDeclaration(Expression expression, AstType type, string variableName, Modifiers modifiers)
	{
		if (expression is AssignmentExpression { Operator: AssignmentOperatorType.Assign, Left: IdentifierExpression left } assignmentExpression && left.Identifier == variableName)
		{
			variablesToDeclare.Add(new VariableToDeclare
			{
				Type = type,
				Name = variableName,
				ILVariable = left.Annotation<ILVariable>(),
				ReplacedAssignment = assignmentExpression,
				Modifiers = modifiers
			});
			return true;
		}
		return false;
	}

	public static bool FindDeclarationPoint(DefiniteAssignmentAnalysis daa, VariableDeclarationStatement varDecl, BlockStatement block, out Statement declarationPoint, CancellationToken cancellationToken)
	{
		string name = varDecl.Variables.Single().Name;
		bool allowPassIntoLoops = varDecl.Variables.Single().Annotation<DelegateConstruction.CapturedVariableAnnotation>() == null;
		return FindDeclarationPoint(daa, name, allowPassIntoLoops, block, out declarationPoint, cancellationToken);
	}

	private static bool FindDeclarationPoint(DefiniteAssignmentAnalysis daa, string variableName, bool allowPassIntoLoops, BlockStatement block, out Statement declarationPoint, CancellationToken cancellationToken)
	{
		declarationPoint = null;
		foreach (Statement statement in block.Statements)
		{
			if (!UsesVariable(statement, variableName))
			{
				continue;
			}
			if (declarationPoint == null)
			{
				declarationPoint = statement;
			}
			if (!CanMoveVariableUseIntoSubBlock(statement, variableName, allowPassIntoLoops))
			{
				return false;
			}
			Statement nextStatement = statement.GetNextStatement();
			if (nextStatement != null)
			{
				daa.SetAnalyzedRange(nextStatement, block);
				daa.Analyze(variableName, cancellationToken);
				if (daa.UnassignedVariableUses.Count > 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	private static bool CanMoveVariableUseIntoSubBlock(Statement stmt, string variableName, bool allowPassIntoLoops)
	{
		if (!allowPassIntoLoops && (stmt is ForStatement || stmt is ForeachStatement || stmt is DoWhileStatement || stmt is WhileStatement))
		{
			return false;
		}
		if (stmt is ForStatement forStatement && forStatement.Initializers.Count == 1 && forStatement.Initializers.Single() is ExpressionStatement { Expression: AssignmentExpression { Operator: AssignmentOperatorType.Assign, Left: IdentifierExpression left } expression } && left.Identifier == variableName)
		{
			return !UsesVariable(expression.Right, variableName);
		}
		if (stmt is UsingStatement { ResourceAcquisition: AssignmentExpression { Operator: AssignmentOperatorType.Assign, Left: IdentifierExpression left2 } resourceAcquisition } && left2.Identifier == variableName)
		{
			return !UsesVariable(resourceAcquisition.Right, variableName);
		}
		if (stmt is IfElseStatement ies)
		{
			foreach (AstNode item in IfElseChainChildren(ies))
			{
				if (!(item is BlockStatement) && UsesVariable(item, variableName))
				{
					return false;
				}
			}
			return true;
		}
		for (AstNode astNode = stmt.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			if (!(astNode is BlockStatement) && UsesVariable(astNode, variableName))
			{
				if (!HasNestedBlocks(astNode))
				{
					return false;
				}
				for (AstNode astNode2 = astNode.FirstChild; astNode2 != null; astNode2 = astNode2.NextSibling)
				{
					if (!(astNode2 is BlockStatement) && UsesVariable(astNode2, variableName))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private static IEnumerable<AstNode> IfElseChainChildren(IfElseStatement ies)
	{
		IfElseStatement ifElseStatement;
		do
		{
			yield return ies.Condition;
			yield return ies.TrueStatement;
			ifElseStatement = ies;
			ies = ies.FalseStatement as IfElseStatement;
		}
		while (ies != null);
		if (!ifElseStatement.FalseStatement.IsNull)
		{
			yield return ifElseStatement.FalseStatement;
		}
	}

	private static bool HasNestedBlocks(AstNode node)
	{
		if (!(node is CatchClause))
		{
			return node is SwitchSection;
		}
		return true;
	}

	private static bool UsesVariable(AstNode node, string variableName)
	{
		if (node is IdentifierExpression identifierExpression && identifierExpression.Identifier == variableName)
		{
			return true;
		}
		if (node is FixedStatement fixedStatement)
		{
			foreach (VariableInitializer variable in fixedStatement.Variables)
			{
				if (variable.Name == variableName)
				{
					return false;
				}
			}
		}
		if (node is ForeachStatement foreachStatement && foreachStatement.VariableName == variableName)
		{
			return false;
		}
		if (node is UsingStatement { ResourceAcquisition: VariableDeclarationStatement resourceAcquisition })
		{
			foreach (VariableInitializer variable2 in resourceAcquisition.Variables)
			{
				if (variable2.Name == variableName)
				{
					return false;
				}
			}
		}
		if (node is CatchClause catchClause && catchClause.VariableName == variableName)
		{
			return false;
		}
		for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			if (UsesVariable(astNode, variableName))
			{
				return true;
			}
		}
		return false;
	}
}
