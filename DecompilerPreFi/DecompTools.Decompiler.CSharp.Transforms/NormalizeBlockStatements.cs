using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Transforms;

internal class NormalizeBlockStatements : DepthFirstAstVisitor, IAstTransform
{
	private TransformContext context;

	private static readonly PropertyDeclaration CalculatedGetterOnlyPropertyPattern = new PropertyDeclaration
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Modifiers = Modifiers.Any,
		Name = Pattern.AnyString,
		PrivateImplementationType = new AnyNodeOrNull(),
		ReturnType = new AnyNode(),
		Getter = new Accessor
		{
			Body = new BlockStatement
			{
				new ReturnStatement(new AnyNode("expression"))
			}
		}
	};

	private static readonly IndexerDeclaration CalculatedGetterOnlyIndexerPattern = new IndexerDeclaration
	{
		Attributes = { (AttributeSection)new Repeat(new AnyNode()) },
		Modifiers = Modifiers.Any,
		PrivateImplementationType = new AnyNodeOrNull(),
		Parameters = { (ParameterDeclaration)new Repeat(new AnyNode()) },
		ReturnType = new AnyNode(),
		Getter = new Accessor
		{
			Body = new BlockStatement
			{
				new ReturnStatement(new AnyNode("expression"))
			}
		}
	};

	public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
	{
		base.VisitIfElseStatement(ifElseStatement);
		DoTransform(ifElseStatement.TrueStatement, ifElseStatement);
		DoTransform(ifElseStatement.FalseStatement, ifElseStatement);
	}

	public override void VisitWhileStatement(WhileStatement whileStatement)
	{
		base.VisitWhileStatement(whileStatement);
		InsertBlock(whileStatement.EmbeddedStatement);
	}

	public override void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
	{
		base.VisitDoWhileStatement(doWhileStatement);
		InsertBlock(doWhileStatement.EmbeddedStatement);
	}

	public override void VisitForeachStatement(ForeachStatement foreachStatement)
	{
		base.VisitForeachStatement(foreachStatement);
		InsertBlock(foreachStatement.EmbeddedStatement);
	}

	public override void VisitForStatement(ForStatement forStatement)
	{
		base.VisitForStatement(forStatement);
		InsertBlock(forStatement.EmbeddedStatement);
	}

	public override void VisitFixedStatement(FixedStatement fixedStatement)
	{
		base.VisitFixedStatement(fixedStatement);
		InsertBlock(fixedStatement.EmbeddedStatement);
	}

	public override void VisitLockStatement(LockStatement lockStatement)
	{
		base.VisitLockStatement(lockStatement);
		InsertBlock(lockStatement.EmbeddedStatement);
	}

	public override void VisitUsingStatement(UsingStatement usingStatement)
	{
		base.VisitUsingStatement(usingStatement);
		DoTransform(usingStatement.EmbeddedStatement, usingStatement);
	}

	private void DoTransform(Statement statement, Statement parent)
	{
		if (statement.IsNull)
		{
			return;
		}
		if (context.Settings.AlwaysUseBraces)
		{
			if (!IsElseIf(statement, parent))
			{
				InsertBlock(statement);
			}
		}
		else if (statement is BlockStatement blockStatement && blockStatement.Statements.Count == 1 && IsAllowedAsEmbeddedStatement(Enumerable.First<Statement>((IEnumerable<Statement>)blockStatement.Statements), parent))
		{
			statement.ReplaceWith(Enumerable.First<Statement>((IEnumerable<Statement>)blockStatement.Statements).Detach());
		}
		else if (!IsAllowedAsEmbeddedStatement(statement, parent))
		{
			InsertBlock(statement);
		}
	}

	private bool IsElseIf(Statement statement, Statement parent)
	{
		return parent is IfElseStatement && statement.Role == IfElseStatement.FalseRole;
	}

	private static void InsertBlock(Statement statement)
	{
		if (!statement.IsNull && !(statement is BlockStatement))
		{
			BlockStatement blockStatement = new BlockStatement();
			statement.ReplaceWith(blockStatement);
			if (statement is EmptyStatement && !Enumerable.Any<AstNode>(statement.Children))
			{
				blockStatement.CopyAnnotationsFrom(statement);
			}
			else
			{
				blockStatement.Add(statement);
			}
		}
	}

	private bool IsAllowedAsEmbeddedStatement(Statement statement, Statement parent)
	{
		if (statement == null)
		{
			goto IL_00fe;
		}
		if (!(statement is IfElseStatement ifElseStatement))
		{
			if (!(statement is VariableDeclarationStatement variableDeclarationStatement))
			{
				if (!(statement is WhileStatement whileStatement))
				{
					if (!(statement is DoWhileStatement doWhileStatement))
					{
						if (!(statement is SwitchStatement switchStatement))
						{
							if (!(statement is ForeachStatement foreachStatement))
							{
								if (!(statement is ForStatement forStatement))
								{
									if (!(statement is LockStatement lockStatement))
									{
										if (!(statement is FixedStatement fixedStatement))
										{
											if (!(statement is UsingStatement usingStatement))
											{
												goto IL_00fe;
											}
											UsingStatement usingStatement2 = usingStatement;
											return parent is UsingStatement;
										}
										FixedStatement fixedStatement2 = fixedStatement;
									}
									else
									{
										LockStatement lockStatement2 = lockStatement;
									}
								}
								else
								{
									ForStatement forStatement2 = forStatement;
								}
							}
							else
							{
								ForeachStatement foreachStatement2 = foreachStatement;
							}
						}
						else
						{
							SwitchStatement switchStatement2 = switchStatement;
						}
					}
					else
					{
						DoWhileStatement doWhileStatement2 = doWhileStatement;
					}
				}
				else
				{
					WhileStatement whileStatement2 = whileStatement;
				}
			}
			else
			{
				VariableDeclarationStatement variableDeclarationStatement2 = variableDeclarationStatement;
			}
			return false;
		}
		IfElseStatement ifElseStatement2 = ifElseStatement;
		return parent is IfElseStatement && ifElseStatement2.Role == IfElseStatement.FalseRole;
		IL_00fe:
		return !(parent?.Parent is IfElseStatement);
	}

	void IAstTransform.Run(AstNode rootNode, TransformContext context)
	{
		this.context = context;
		rootNode.AcceptVisitor(this);
	}

	public override void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
	{
		if (context.Settings.UseExpressionBodyForCalculatedGetterOnlyProperties)
		{
			SimplifyPropertyDeclaration(propertyDeclaration);
		}
		base.VisitPropertyDeclaration(propertyDeclaration);
	}

	public override void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
	{
		if (context.Settings.UseExpressionBodyForCalculatedGetterOnlyProperties)
		{
			SimplifyIndexerDeclaration(indexerDeclaration);
		}
		base.VisitIndexerDeclaration(indexerDeclaration);
	}

	private void SimplifyPropertyDeclaration(PropertyDeclaration propertyDeclaration)
	{
		Match match = CalculatedGetterOnlyPropertyPattern.Match(propertyDeclaration);
		if (match.Success)
		{
			propertyDeclaration.ExpressionBody = Enumerable.Single<Expression>(match.Get<Expression>("expression")).Detach();
			propertyDeclaration.Getter.Remove();
		}
	}

	private void SimplifyIndexerDeclaration(IndexerDeclaration indexerDeclaration)
	{
		Match match = CalculatedGetterOnlyIndexerPattern.Match(indexerDeclaration);
		if (match.Success)
		{
			indexerDeclaration.ExpressionBody = Enumerable.Single<Expression>(match.Get<Expression>("expression")).Detach();
			indexerDeclaration.Getter.Remove();
		}
	}
}
