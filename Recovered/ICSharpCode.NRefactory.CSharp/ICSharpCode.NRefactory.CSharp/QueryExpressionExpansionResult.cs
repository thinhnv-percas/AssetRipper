using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class QueryExpressionExpansionResult
	{
		public AstNode AstNode
		{
			get;
			private set;
		}

		public IDictionary<Identifier, AstNode> RangeVariables
		{
			get;
			private set;
		}

		public IDictionary<AstNode, Expression> Expressions
		{
			get;
			private set;
		}

		public QueryExpressionExpansionResult(AstNode astNode, IDictionary<Identifier, AstNode> rangeVariables, IDictionary<AstNode, Expression> expressions)
		{
			AstNode = astNode;
			RangeVariables = rangeVariables;
			Expressions = expressions;
		}
	}
}
