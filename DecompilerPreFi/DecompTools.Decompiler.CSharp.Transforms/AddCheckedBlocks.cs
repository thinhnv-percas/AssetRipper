using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Transforms;

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
			return checked(a.Blocks + a.Expressions < b.Blocks + b.Expressions || (a.Blocks + a.Expressions == b.Blocks + b.Expressions && a.Blocks < b.Blocks));
		}

		public static bool operator >(Cost a, Cost b)
		{
			return checked(a.Blocks + a.Expressions > b.Blocks + b.Expressions || (a.Blocks + a.Expressions == b.Blocks + b.Expressions && a.Blocks > b.Blocks));
		}

		public static bool operator <=(Cost a, Cost b)
		{
			return checked(a.Blocks + a.Expressions < b.Blocks + b.Expressions || (a.Blocks + a.Expressions == b.Blocks + b.Expressions && a.Blocks <= b.Blocks));
		}

		public static bool operator >=(Cost a, Cost b)
		{
			return checked(a.Blocks + a.Expressions > b.Blocks + b.Expressions || (a.Blocks + a.Expressions == b.Blocks + b.Expressions && a.Blocks >= b.Blocks));
		}

		public static Cost operator +(Cost a, Cost b)
		{
			return checked(new Cost(a.Blocks + b.Blocks, a.Expressions + b.Expressions));
		}

		public override string ToString()
		{
			return $"[{Blocks} + {Expressions}]";
		}

		internal Cost WrapInCheckedExpr()
		{
			if (Expressions == 0)
			{
				return new Cost(Blocks, 1);
			}
			return new Cost(Blocks, checked(Expressions + 2));
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
			Statement statement = firstStatement.GetNextStatement();
			while (statement != lastStatement)
			{
				Statement nextStatement = statement.GetNextStatement();
				blockStatement.Add(statement.Detach());
				statement = nextStatement;
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

	public void Run(AstNode node, TransformContext context)
	{
		if (!(node is BlockStatement block))
		{
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				Run(astNode, context);
			}
		}
		else
		{
			Result resultFromBlock = GetResultFromBlock(block);
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
		InsertedNode insertedNode2 = null;
		Statement firstStatement = null;
		Cost cost3 = new Cost(0, 0);
		InsertedNode insertedNode3 = null;
		Cost cost4 = Cost.Infinite;
		InsertedNode insertedNode4 = null;
		Statement firstStatement2 = null;
		Statement statement = Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)block.Statements);
		while (true)
		{
			if (cost2 <= cost)
			{
				cost = cost2;
				insertedNode = insertedNode2 + new InsertedBlock(firstStatement, statement, isChecked: false);
			}
			if (cost4 <= cost3)
			{
				cost3 = cost4;
				insertedNode3 = insertedNode4 + new InsertedBlock(firstStatement2, statement, isChecked: true);
			}
			if (statement == null)
			{
				break;
			}
			if (cost + new Cost(1, 0) <= cost2)
			{
				cost2 = cost + new Cost(1, 0);
				insertedNode2 = insertedNode;
				firstStatement = statement;
			}
			if (cost3 + new Cost(1, 0) <= cost4)
			{
				cost4 = cost3 + new Cost(1, 0);
				insertedNode4 = insertedNode3;
				firstStatement2 = statement;
			}
			Result result = GetResult(statement);
			cost += result.CostInCheckedContext;
			insertedNode += result.NodesToInsertInCheckedContext;
			cost2 += result.CostInUncheckedContext;
			insertedNode2 += result.NodesToInsertInUncheckedContext;
			cost3 += result.CostInUncheckedContext;
			insertedNode3 += result.NodesToInsertInUncheckedContext;
			cost4 += result.CostInCheckedContext;
			insertedNode4 += result.NodesToInsertInCheckedContext;
			if (statement is LabelStatement)
			{
				cost2 = Cost.Infinite;
				cost4 = Cost.Infinite;
			}
			statement = statement.GetNextStatement();
		}
		return new Result
		{
			CostInCheckedContext = cost,
			NodesToInsertInCheckedContext = insertedNode,
			CostInUncheckedContext = cost3,
			NodesToInsertInUncheckedContext = insertedNode3
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
		if (node is Expression expression)
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
			if (!(expression.Parent is ExpressionStatement) && expression.Role.IsValid(Expression.Null))
			{
				Cost cost = result.CostInCheckedContext.WrapInCheckedExpr();
				Cost cost2 = result.CostInUncheckedContext.WrapInCheckedExpr();
				if (cost < result.CostInUncheckedContext)
				{
					result.CostInUncheckedContext = cost;
					result.NodesToInsertInUncheckedContext = result.NodesToInsertInCheckedContext + new InsertedExpression(expression, isChecked: true);
				}
				else if (cost2 < result.CostInCheckedContext)
				{
					result.CostInCheckedContext = cost2;
					result.NodesToInsertInCheckedContext = result.NodesToInsertInUncheckedContext + new InsertedExpression(expression, isChecked: false);
				}
			}
		}
		return result;
	}
}
