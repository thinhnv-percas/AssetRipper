using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class PatternHelper
	{
		private sealed class OptionalParenthesesPattern : Pattern
		{
			private readonly INode child;

			public OptionalParenthesesPattern(INode child)
			{
				this.child = child;
			}

			public override bool DoMatch(INode other, Match match)
			{
				INode other2 = ParenthesizedExpression.UnpackParenthesizedExpression(other as Expression);
				return child.DoMatch(other2, match);
			}
		}

		private sealed class OptionalBlockPattern : Pattern
		{
			private readonly INode child;

			public OptionalBlockPattern(INode child)
			{
				this.child = child;
			}

			public override bool DoMatch(INode other, Match match)
			{
				INode other2 = UnpackBlockStatement(other as Statement);
				return child.DoMatch(other2, match);
			}

			public static Statement UnpackBlockStatement(Statement stmt)
			{
				while (stmt is BlockStatement)
				{
					stmt = stmt.GetChildByRole(BlockStatement.StatementRole);
					if (stmt.GetNextSibling((AstNode s) => s.Role == BlockStatement.StatementRole) != null)
					{
						return null;
					}
				}
				return stmt;
			}
		}

		private sealed class NamedParameterDeclaration : ParameterDeclaration
		{
			private readonly string groupName;

			public string GroupName => groupName;

			public NamedParameterDeclaration(string groupName = null)
			{
				this.groupName = groupName;
			}

			public NamedParameterDeclaration(string groupName, AstType type, string name, ParameterModifier modifier = ParameterModifier.None)
				: base(type, name, modifier)
			{
				this.groupName = groupName;
			}

			protected internal override bool DoMatch(AstNode other, Match match)
			{
				match.Add(groupName, other);
				return base.DoMatch(other, match);
			}
		}

		public static Expression CommutativeOperator(Expression expr1, BinaryOperatorType op, Expression expr2)
		{
			return new Choice
			{
				new BinaryOperatorExpression(expr1, op, expr2),
				new BinaryOperatorExpression(expr2.Clone(), op, expr1.Clone())
			};
		}

		public static Expression CommutativeOperatorWithOptionalParentheses(Expression expr1, BinaryOperatorType op, Expression expr2)
		{
			return OptionalParentheses(CommutativeOperator(OptionalParentheses(expr1), op, OptionalParentheses(expr2)));
		}

		public static Expression OptionalParentheses(Expression expr)
		{
			return new OptionalParenthesesPattern(expr);
		}

		public static Statement EmbeddedStatement(Statement statement)
		{
			return new OptionalBlockPattern(statement);
		}

		public static ParameterDeclaration NamedParameter(string groupName)
		{
			return new NamedParameterDeclaration(groupName);
		}

		public static ParameterDeclaration NamedParameter(string groupName, AstType type, string name, ParameterModifier modifier = ParameterModifier.None)
		{
			return new NamedParameterDeclaration(groupName, type, name, modifier);
		}

		public static AstType AnyType(bool doesMatchNullTypes = false)
		{
			if (doesMatchNullTypes)
			{
				return new OptionalNode(new AnyNode());
			}
			return new AnyNode();
		}

		public static AstType AnyType(string groupName, bool doesMatchNullTypes = false)
		{
			if (doesMatchNullTypes)
			{
				return new OptionalNode(new AnyNode(groupName));
			}
			return new AnyNode(groupName);
		}
	}
}
