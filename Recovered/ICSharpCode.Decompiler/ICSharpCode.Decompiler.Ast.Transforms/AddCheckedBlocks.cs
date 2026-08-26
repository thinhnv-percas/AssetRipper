using ICSharpCode.NRefactory.CSharp;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class AddCheckedBlocks : IAstTransform
	{
		private sealed class CheckedUncheckedAnnotation
		{
			public bool IsChecked;
		}

		private struct Cost
		{
			public static readonly Cost Infinite = new Cost(1073741823, 1073741823);

			public readonly int Blocks;

			public readonly int Expressions;

			public Cost(int blocks, int expressions)
			{
				Blocks = blocks;
				Expressions = expressions;
			}

			public static bool operator <(Cost a, Cost b)
			{
				if (a.Blocks + a.Expressions >= b.Blocks + b.Expressions)
				{
					if (a.Blocks + a.Expressions == b.Blocks + b.Expressions)
					{
						return a.Blocks < b.Blocks;
					}
					return false;
				}
				return true;
			}

			public static bool operator >(Cost a, Cost b)
			{
				if (a.Blocks + a.Expressions <= b.Blocks + b.Expressions)
				{
					if (a.Blocks + a.Expressions == b.Blocks + b.Expressions)
					{
						return a.Blocks > b.Blocks;
					}
					return false;
				}
				return true;
			}

			public static bool operator <=(Cost a, Cost b)
			{
				if (a.Blocks + a.Expressions >= b.Blocks + b.Expressions)
				{
					if (a.Blocks + a.Expressions == b.Blocks + b.Expressions)
					{
						return a.Blocks <= b.Blocks;
					}
					return false;
				}
				return true;
			}

			public static bool operator >=(Cost a, Cost b)
			{
				if (a.Blocks + a.Expressions <= b.Blocks + b.Expressions)
				{
					if (a.Blocks + a.Expressions == b.Blocks + b.Expressions)
					{
						return a.Blocks >= b.Blocks;
					}
					return false;
				}
				return true;
			}

			public static Cost operator +(Cost a, Cost b)
			{
				return new Cost(a.Blocks + b.Blocks, a.Expressions + b.Expressions);
			}

			public override string ToString()
			{
				return $"[{Blocks} + {Expressions}]";
			}
		}

		private abstract class InsertedNode
		{
			public static InsertedNode operator +(InsertedNode a, InsertedNode b)
			{
				if (a == null)
				{
					return b;
				}
				if (b == null)
				{
					return a;
				}
				return new InsertedNodeList(a, b);
			}

			public abstract void Insert();
		}

		private class InsertedNodeList : InsertedNode
		{
			private readonly InsertedNode child1;

			private readonly InsertedNode child2;

			public InsertedNodeList(InsertedNode child1, InsertedNode child2)
			{
				this.child1 = child1;
				this.child2 = child2;
			}

			public override void Insert()
			{
				child1.Insert();
				child2.Insert();
			}
		}

		private class InsertedExpression : InsertedNode
		{
			private readonly Expression expression;

			private readonly bool isChecked;

			public InsertedExpression(Expression expression, bool isChecked)
			{
				this.expression = expression;
				this.isChecked = isChecked;
			}

			public override void Insert()
			{
				if (isChecked)
				{
					expression.ReplaceWith((Expression e) => new CheckedExpression
					{
						Expression = e
					});
				}
				else
				{
					expression.ReplaceWith((Expression e) => new UncheckedExpression
					{
						Expression = e
					});
				}
			}
		}

		private class ConvertCompoundAssignment : InsertedNode
		{
			private readonly Expression expression;

			private readonly bool isChecked;

			public ConvertCompoundAssignment(Expression expression, bool isChecked)
			{
				this.expression = expression;
				this.isChecked = isChecked;
			}

			public override void Insert()
			{
				AssignmentExpression assignmentExpression = expression.Annotation<ReplaceMethodCallsWithOperators.RestoreOriginalAssignOperatorAnnotation>().Restore(expression);
				expression.ReplaceWith(assignmentExpression);
				if (isChecked)
				{
					assignmentExpression.Right = new CheckedExpression
					{
						Expression = assignmentExpression.Right.Detach()
					};
				}
				else
				{
					assignmentExpression.Right = new UncheckedExpression
					{
						Expression = assignmentExpression.Right.Detach()
					};
				}
			}
		}

		private class InsertedBlock : InsertedNode
		{
			private readonly Statement firstStatement;

			private readonly Statement lastStatement;

			private readonly bool isChecked;

			public InsertedBlock(Statement firstStatement, Statement lastStatement, bool isChecked)
			{
				this.firstStatement = firstStatement;
				this.lastStatement = lastStatement;
				this.isChecked = isChecked;
			}

			public override void Insert()
			{
				BlockStatement blockStatement = new BlockStatement();
				Statement nextStatement;
				for (Statement statement = firstStatement.GetNextStatement(); statement != lastStatement; statement = nextStatement)
				{
					nextStatement = statement.GetNextStatement();
					blockStatement.Add(statement.Detach());
				}
				if (isChecked)
				{
					firstStatement.ReplaceWith(new CheckedStatement
					{
						Body = blockStatement
					});
				}
				else
				{
					firstStatement.ReplaceWith(new UncheckedStatement
					{
						Body = blockStatement
					});
				}
				blockStatement.Statements.InsertAfter(null, firstStatement);
			}
		}

		private class Result
		{
			public Cost CostInCheckedContext;

			public InsertedNode NodesToInsertInCheckedContext;

			public Cost CostInUncheckedContext;

			public InsertedNode NodesToInsertInUncheckedContext;
		}

		public static readonly object CheckedAnnotation = new CheckedUncheckedAnnotation
		{
			IsChecked = true
		};

		public static readonly object UncheckedAnnotation = new CheckedUncheckedAnnotation
		{
			IsChecked = false
		};

		public void Run(AstNode node)
		{
			BlockStatement blockStatement = node as BlockStatement;
			if (blockStatement == null)
			{
				for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
				{
					Run(astNode);
				}
			}
			else
			{
				Result resultFromBlock = GetResultFromBlock(blockStatement);
				if (resultFromBlock.NodesToInsertInUncheckedContext != null)
				{
					resultFromBlock.NodesToInsertInUncheckedContext.Insert();
				}
			}
		}

		private Result GetResultFromBlock(BlockStatement block)
		{
			Cost cost = new Cost(0, 0);
			InsertedNode insertedNode = null;
			Cost cost2 = Cost.Infinite;
			InsertedNode a = null;
			Statement firstStatement = null;
			Cost cost3 = new Cost(0, 0);
			InsertedNode insertedNode2 = null;
			Cost cost4 = Cost.Infinite;
			InsertedNode a2 = null;
			Statement firstStatement2 = null;
			Statement statement = block.Statements.FirstOrDefault();
			while (true)
			{
				if (cost2 <= cost)
				{
					cost = cost2;
					insertedNode = a + new InsertedBlock(firstStatement, statement, isChecked: false);
				}
				if (cost4 <= cost3)
				{
					cost3 = cost4;
					insertedNode2 = a2 + new InsertedBlock(firstStatement2, statement, isChecked: true);
				}
				if (statement == null)
				{
					break;
				}
				if (cost + new Cost(1, 0) <= cost2)
				{
					cost2 = cost + new Cost(1, 0);
					a = insertedNode;
					firstStatement = statement;
				}
				if (cost3 + new Cost(1, 0) <= cost4)
				{
					cost4 = cost3 + new Cost(1, 0);
					a2 = insertedNode2;
					firstStatement2 = statement;
				}
				Result result = GetResult(statement);
				cost += result.CostInCheckedContext;
				insertedNode += result.NodesToInsertInCheckedContext;
				cost2 += result.CostInUncheckedContext;
				a += result.NodesToInsertInUncheckedContext;
				cost3 += result.CostInUncheckedContext;
				insertedNode2 += result.NodesToInsertInUncheckedContext;
				cost4 += result.CostInCheckedContext;
				a2 += result.NodesToInsertInCheckedContext;
				statement = statement.GetNextStatement();
			}
			return new Result
			{
				CostInCheckedContext = cost,
				NodesToInsertInCheckedContext = insertedNode,
				CostInUncheckedContext = cost3,
				NodesToInsertInUncheckedContext = insertedNode2
			};
		}

		private Result GetResult(AstNode node)
		{
			if (node is BlockStatement)
			{
				return GetResultFromBlock((BlockStatement)node);
			}
			Result result = new Result();
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				Result result2 = GetResult(astNode);
				result.CostInCheckedContext += result2.CostInCheckedContext;
				result.NodesToInsertInCheckedContext += result2.NodesToInsertInCheckedContext;
				result.CostInUncheckedContext += result2.CostInUncheckedContext;
				result.NodesToInsertInUncheckedContext += result2.NodesToInsertInUncheckedContext;
			}
			Expression expression = node as Expression;
			if (expression != null)
			{
				CheckedUncheckedAnnotation checkedUncheckedAnnotation = expression.Annotation<CheckedUncheckedAnnotation>();
				if (checkedUncheckedAnnotation != null)
				{
					if (checkedUncheckedAnnotation.IsChecked)
					{
						result.CostInUncheckedContext += new Cost(10000, 0);
					}
					else
					{
						result.CostInCheckedContext += new Cost(10000, 0);
					}
				}
				if (expression.Parent is ExpressionStatement)
				{
					if (expression.Annotation<ReplaceMethodCallsWithOperators.RestoreOriginalAssignOperatorAnnotation>() != null)
					{
						if (result.CostInCheckedContext + new Cost(1, 1) < result.CostInUncheckedContext)
						{
							result.CostInUncheckedContext = result.CostInCheckedContext + new Cost(1, 1);
							result.NodesToInsertInUncheckedContext = result.NodesToInsertInCheckedContext + new ConvertCompoundAssignment(expression, isChecked: true);
						}
						else if (result.CostInUncheckedContext + new Cost(1, 1) < result.CostInCheckedContext)
						{
							result.CostInCheckedContext = result.CostInUncheckedContext + new Cost(1, 1);
							result.NodesToInsertInCheckedContext = result.NodesToInsertInUncheckedContext + new ConvertCompoundAssignment(expression, isChecked: false);
						}
					}
				}
				else if (expression.Role.IsValid(Expression.Null))
				{
					if (result.CostInCheckedContext + new Cost(0, 1) < result.CostInUncheckedContext)
					{
						result.CostInUncheckedContext = result.CostInCheckedContext + new Cost(0, 1);
						result.NodesToInsertInUncheckedContext = result.NodesToInsertInCheckedContext + new InsertedExpression(expression, isChecked: true);
					}
					else if (result.CostInUncheckedContext + new Cost(0, 1) < result.CostInCheckedContext)
					{
						result.CostInCheckedContext = result.CostInUncheckedContext + new Cost(0, 1);
						result.NodesToInsertInCheckedContext = result.NodesToInsertInUncheckedContext + new InsertedExpression(expression, isChecked: false);
					}
				}
			}
			return result;
		}
	}
}
