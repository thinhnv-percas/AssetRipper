using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Analysis;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class DeclareVariables : IAstTransform
	{
		private sealed class VariableToDeclare
		{
			public AstType Type;

			public string Name;

			public ILVariable ILVariable;

			public AssignmentExpression ReplacedAssignment;

			public Statement InsertionPoint;
		}

		private readonly CancellationToken cancellationToken;

		private List<VariableToDeclare> variablesToDeclare = new List<VariableToDeclare>();

		public DeclareVariables(DecompilerContext context)
		{
			cancellationToken = context.CancellationToken;
		}

		public void Run(AstNode node)
		{
			Run(node, null);
			foreach (VariableToDeclare item in variablesToDeclare)
			{
				if (item.ReplacedAssignment == null)
				{
					BlockStatement obj = (BlockStatement)item.InsertionPoint.Parent;
					VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(item.Type.Clone(), item.Name);
					if (item.ILVariable != null)
					{
						variableDeclarationStatement.Variables.Single().AddAnnotation(item.ILVariable);
					}
					obj.Statements.InsertBefore(item.InsertionPoint, variableDeclarationStatement);
				}
			}
			foreach (VariableToDeclare item2 in variablesToDeclare)
			{
				if (item2.ReplacedAssignment != null)
				{
					VariableInitializer element = new VariableInitializer(item2.Name, item2.ReplacedAssignment.Right.Detach()).CopyAnnotationsFrom(item2.ReplacedAssignment).WithAnnotation(item2.ILVariable);
					VariableDeclarationStatement variableDeclarationStatement2 = new VariableDeclarationStatement
					{
						Type = item2.Type.Clone(),
						Variables = 
						{
							element
						}
					};
					ExpressionStatement expressionStatement = item2.ReplacedAssignment.Parent as ExpressionStatement;
					if (expressionStatement != null)
					{
						expressionStatement.ReplaceWith(variableDeclarationStatement2.CopyAnnotationsFrom(expressionStatement));
					}
					else
					{
						item2.ReplacedAssignment.ReplaceWith(variableDeclarationStatement2);
					}
				}
			}
			variablesToDeclare = null;
		}

		private void Run(AstNode node, DefiniteAssignmentAnalysis daa)
		{
			BlockStatement blockStatement = node as BlockStatement;
			if (blockStatement != null)
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
						DeclareVariableInBlock(daa, blockStatement, item2.Type, name, v, allowPassIntoLoops);
					}
				}
			}
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				Run(astNode, daa);
			}
		}

		private void DeclareVariableInBlock(DefiniteAssignmentAnalysis daa, BlockStatement block, AstType type, string variableName, ILVariable v, bool allowPassIntoLoops)
		{
			Statement declarationPoint = null;
			bool flag = FindDeclarationPoint(daa, variableName, allowPassIntoLoops, block, out declarationPoint);
			if (declarationPoint != null)
			{
				if (flag)
				{
					foreach (Statement statement in block.Statements)
					{
						ForStatement forStatement = statement as ForStatement;
						if (forStatement == null || forStatement.Initializers.Count != 1 || !TryConvertAssignmentExpressionIntoVariableDeclaration(forStatement.Initializers.Single(), type, variableName))
						{
							UsingStatement usingStatement = statement as UsingStatement;
							if (usingStatement == null || !(usingStatement.ResourceAcquisition is AssignmentExpression) || !TryConvertAssignmentExpressionIntoVariableDeclaration((Expression)usingStatement.ResourceAcquisition, type, variableName))
							{
								IfElseStatement ifElseStatement = statement as IfElseStatement;
								if (ifElseStatement != null)
								{
									foreach (AstNode item in IfElseChainChildren(ifElseStatement))
									{
										BlockStatement blockStatement = item as BlockStatement;
										if (blockStatement != null)
										{
											DeclareVariableInBlock(daa, blockStatement, type, variableName, v, allowPassIntoLoops);
										}
									}
								}
								else
								{
									foreach (AstNode child in statement.Children)
									{
										BlockStatement blockStatement2 = child as BlockStatement;
										if (blockStatement2 != null)
										{
											DeclareVariableInBlock(daa, blockStatement2, type, variableName, v, allowPassIntoLoops);
										}
										else if (HasNestedBlocks(child))
										{
											foreach (BlockStatement item2 in child.Children.OfType<BlockStatement>())
											{
												DeclareVariableInBlock(daa, item2, type, variableName, v, allowPassIntoLoops);
											}
										}
									}
								}
							}
						}
					}
				}
				else if (!TryConvertAssignmentExpressionIntoVariableDeclaration(declarationPoint, type, variableName))
				{
					variablesToDeclare.Add(new VariableToDeclare
					{
						Type = type,
						Name = variableName,
						ILVariable = v,
						InsertionPoint = declarationPoint
					});
				}
			}
		}

		private bool TryConvertAssignmentExpressionIntoVariableDeclaration(Statement declarationPoint, AstType type, string variableName)
		{
			ExpressionStatement expressionStatement = declarationPoint as ExpressionStatement;
			if (expressionStatement != null)
			{
				return TryConvertAssignmentExpressionIntoVariableDeclaration(expressionStatement.Expression, type, variableName);
			}
			return false;
		}

		private bool TryConvertAssignmentExpressionIntoVariableDeclaration(Expression expression, AstType type, string variableName)
		{
			AssignmentExpression assignmentExpression = expression as AssignmentExpression;
			if (assignmentExpression != null && assignmentExpression.Operator == AssignmentOperatorType.Assign)
			{
				IdentifierExpression identifierExpression = assignmentExpression.Left as IdentifierExpression;
				if (identifierExpression != null && identifierExpression.Identifier == variableName)
				{
					variablesToDeclare.Add(new VariableToDeclare
					{
						Type = type,
						Name = variableName,
						ILVariable = identifierExpression.Annotation<ILVariable>(),
						ReplacedAssignment = assignmentExpression
					});
					return true;
				}
			}
			return false;
		}

		public static bool FindDeclarationPoint(DefiniteAssignmentAnalysis daa, VariableDeclarationStatement varDecl, BlockStatement block, out Statement declarationPoint)
		{
			string name = varDecl.Variables.Single().Name;
			bool allowPassIntoLoops = varDecl.Variables.Single().Annotation<DelegateConstruction.CapturedVariableAnnotation>() == null;
			return FindDeclarationPoint(daa, name, allowPassIntoLoops, block, out declarationPoint);
		}

		private static bool FindDeclarationPoint(DefiniteAssignmentAnalysis daa, string variableName, bool allowPassIntoLoops, BlockStatement block, out Statement declarationPoint)
		{
			declarationPoint = null;
			foreach (Statement statement in block.Statements)
			{
				if (UsesVariable(statement, variableName))
				{
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
						daa.Analyze(variableName);
						if (daa.UnassignedVariableUses.Count > 0)
						{
							return false;
						}
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
			ForStatement forStatement = stmt as ForStatement;
			if (forStatement != null && forStatement.Initializers.Count == 1)
			{
				ExpressionStatement expressionStatement = forStatement.Initializers.Single() as ExpressionStatement;
				if (expressionStatement != null)
				{
					AssignmentExpression assignmentExpression = expressionStatement.Expression as AssignmentExpression;
					if (assignmentExpression != null && assignmentExpression.Operator == AssignmentOperatorType.Assign)
					{
						IdentifierExpression identifierExpression = assignmentExpression.Left as IdentifierExpression;
						if (identifierExpression != null && identifierExpression.Identifier == variableName)
						{
							return !UsesVariable(assignmentExpression.Right, variableName);
						}
					}
				}
			}
			UsingStatement usingStatement = stmt as UsingStatement;
			if (usingStatement != null)
			{
				AssignmentExpression assignmentExpression2 = usingStatement.ResourceAcquisition as AssignmentExpression;
				if (assignmentExpression2 != null && assignmentExpression2.Operator == AssignmentOperatorType.Assign)
				{
					IdentifierExpression identifierExpression2 = assignmentExpression2.Left as IdentifierExpression;
					if (identifierExpression2 != null && identifierExpression2.Identifier == variableName)
					{
						return !UsesVariable(assignmentExpression2.Right, variableName);
					}
				}
			}
			IfElseStatement ifElseStatement = stmt as IfElseStatement;
			if (ifElseStatement != null)
			{
				foreach (AstNode item in IfElseChainChildren(ifElseStatement))
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
				ies = (ies.FalseStatement as IfElseStatement);
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
			IdentifierExpression identifierExpression = node as IdentifierExpression;
			if (identifierExpression != null && identifierExpression.Identifier == variableName)
			{
				return true;
			}
			FixedStatement fixedStatement = node as FixedStatement;
			if (fixedStatement != null)
			{
				foreach (VariableInitializer variable in fixedStatement.Variables)
				{
					if (variable.Name == variableName)
					{
						return false;
					}
				}
			}
			ForeachStatement foreachStatement = node as ForeachStatement;
			if (foreachStatement != null && foreachStatement.VariableName == variableName)
			{
				return false;
			}
			UsingStatement usingStatement = node as UsingStatement;
			if (usingStatement != null)
			{
				VariableDeclarationStatement variableDeclarationStatement = usingStatement.ResourceAcquisition as VariableDeclarationStatement;
				if (variableDeclarationStatement != null)
				{
					foreach (VariableInitializer variable2 in variableDeclarationStatement.Variables)
					{
						if (variable2.Name == variableName)
						{
							return false;
						}
					}
				}
			}
			CatchClause catchClause = node as CatchClause;
			if (catchClause != null && catchClause.VariableName == variableName)
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
}
