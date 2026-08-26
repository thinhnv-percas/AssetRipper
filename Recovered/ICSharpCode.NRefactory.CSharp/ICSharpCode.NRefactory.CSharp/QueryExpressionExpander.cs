using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class QueryExpressionExpander
	{
		private class Visitor : DepthFirstAstVisitor<AstNode>
		{
			internal IEnumerator<string> TransparentIdentifierNamePicker;

			public IDictionary<Identifier, AstNode> rangeVariables = new Dictionary<Identifier, AstNode>();

			public IDictionary<AstNode, Expression> expressions = new Dictionary<AstNode, Expression>();

			private Dictionary<string, Expression> activeRangeVariableSubstitutions = new Dictionary<string, Expression>();

			private List<Tuple<Identifier, List<string>>> currentTransparentType = new List<Tuple<Identifier, List<string>>>();

			private Expression currentResult;

			private bool eatSelect;

			protected override AstNode VisitChildren(AstNode node)
			{
				List<AstNode> list = null;
				int num = 0;
				foreach (AstNode child in node.Children)
				{
					AstNode astNode = child.AcceptVisitor(this);
					if (astNode != null)
					{
						list = (list ?? Enumerable.Repeat<AstNode>(null, num).ToList());
						list.Add(astNode);
					}
					else
					{
						list?.Add(null);
					}
					num++;
				}
				if (list == null)
				{
					return null;
				}
				AstNode astNode2 = node.Clone();
				num = 0;
				foreach (AstNode child2 in astNode2.Children)
				{
					if (list[num] != null)
					{
						child2.ReplaceWith(list[num]);
					}
					num++;
				}
				return astNode2;
			}

			private Expression MakeNestedMemberAccess(Expression target, IEnumerable<string> members)
			{
				return members.Aggregate(target, (Expression current, string m) => current.Member(m));
			}

			private Expression VisitNested(Expression node, ParameterDeclaration transparentParameter)
			{
				Dictionary<string, Expression> dictionary = activeRangeVariableSubstitutions;
				try
				{
					if (transparentParameter != null && currentTransparentType.Count > 1)
					{
						activeRangeVariableSubstitutions = new Dictionary<string, Expression>(activeRangeVariableSubstitutions);
						foreach (Tuple<Identifier, List<string>> item in currentTransparentType)
						{
							activeRangeVariableSubstitutions[item.Item1.Name] = MakeNestedMemberAccess(new IdentifierExpression(transparentParameter.Name), item.Item2);
						}
					}
					return (Expression)(node.AcceptVisitor(this) ?? node.Clone());
				}
				finally
				{
					activeRangeVariableSubstitutions = dictionary;
				}
			}

			private QueryClause GetNextQueryClause(QueryClause clause)
			{
				for (AstNode nextSibling = clause.NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
				{
					if (nextSibling.Role == QueryExpression.ClauseRole)
					{
						return (QueryClause)nextSibling;
					}
				}
				return null;
			}

			private void MapExpression(AstNode orig, Expression newExpr)
			{
				expressions[orig] = newExpr;
			}

			internal static IEnumerable<string> FallbackTransparentIdentifierNamePicker()
			{
				int currentTransparentParameter = 0;
				while (true)
				{
					CultureInfo invariantCulture = CultureInfo.InvariantCulture;
					object[] array = new object[1];
					int num = currentTransparentParameter;
					currentTransparentParameter = num + 1;
					array[0] = num;
					yield return string.Format(invariantCulture, "x{0}", array);
				}
			}

			private ParameterDeclaration CreateParameterForCurrentRangeVariable()
			{
				ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
				if (currentTransparentType.Count == 1)
				{
					Identifier child = (Identifier)currentTransparentType[0].Item1.Clone();
					if (!rangeVariables.ContainsKey(currentTransparentType[0].Item1))
					{
						rangeVariables[currentTransparentType[0].Item1] = parameterDeclaration;
					}
					parameterDeclaration.AddChild(child, Roles.Identifier);
				}
				else
				{
					if (!TransparentIdentifierNamePicker.MoveNext())
					{
						TransparentIdentifierNamePicker = FallbackTransparentIdentifierNamePicker().GetEnumerator();
						TransparentIdentifierNamePicker.MoveNext();
					}
					string current = TransparentIdentifierNamePicker.Current;
					parameterDeclaration.AddChild(Identifier.Create(current), Roles.Identifier);
				}
				return parameterDeclaration;
			}

			private LambdaExpression CreateLambda(IList<ParameterDeclaration> parameters, Expression body)
			{
				LambdaExpression lambdaExpression = new LambdaExpression();
				if (parameters.Count > 1)
				{
					lambdaExpression.AddChild(new CSharpTokenNode(TextLocation.Empty, Roles.LPar), Roles.LPar);
				}
				lambdaExpression.AddChild(parameters[0], Roles.Parameter);
				for (int i = 1; i < parameters.Count; i++)
				{
					lambdaExpression.AddChild(new CSharpTokenNode(TextLocation.Empty, Roles.Comma), Roles.Comma);
					lambdaExpression.AddChild(parameters[i], Roles.Parameter);
				}
				if (parameters.Count > 1)
				{
					lambdaExpression.AddChild(new CSharpTokenNode(TextLocation.Empty, Roles.RPar), Roles.RPar);
				}
				lambdaExpression.AddChild(body, LambdaExpression.BodyRole);
				return lambdaExpression;
			}

			private ParameterDeclaration CreateParameter(Identifier identifier)
			{
				ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
				parameterDeclaration.AddChild(identifier, Roles.Identifier);
				return parameterDeclaration;
			}

			private Expression AddMemberToCurrentTransparentType(ParameterDeclaration param, Identifier name, Expression value, bool namedExpression)
			{
				Expression expression = VisitNested(value, param);
				if (namedExpression)
				{
					expression = new NamedExpression(name.Name, VisitNested(value, param));
					if (!rangeVariables.ContainsKey(name))
					{
						rangeVariables[name] = ((NamedExpression)expression).NameToken;
					}
				}
				foreach (Tuple<Identifier, List<string>> item in currentTransparentType)
				{
					item.Item2.Insert(0, param.Name);
				}
				currentTransparentType.Add(Tuple.Create(name, new List<string>
				{
					name.Name
				}));
				return new AnonymousTypeCreateExpression(new IdentifierExpression(param.Name), expression);
			}

			private void AddFirstMemberToCurrentTransparentType(Identifier identifier)
			{
				currentTransparentType.Add(Tuple.Create(identifier, new List<string>()));
			}

			public override AstNode VisitQueryExpression(QueryExpression queryExpression)
			{
				List<Tuple<Identifier, List<string>>> list = currentTransparentType;
				Expression expression = currentResult;
				bool flag = eatSelect;
				try
				{
					currentTransparentType = new List<Tuple<Identifier, List<string>>>();
					currentResult = null;
					eatSelect = false;
					foreach (QueryClause clause in queryExpression.Clauses)
					{
						Expression expression2 = (Expression)clause.AcceptVisitor(this);
						MapExpression(clause, expression2 ?? currentResult);
						currentResult = expression2;
					}
					return currentResult;
				}
				finally
				{
					currentTransparentType = list;
					currentResult = expression;
					eatSelect = flag;
				}
			}

			public override AstNode VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
			{
				Expression result = VisitNested(queryContinuationClause.PrecedingQuery, null);
				AddFirstMemberToCurrentTransparentType(queryContinuationClause.IdentifierToken);
				return result;
			}

			private static bool NeedsToBeParenthesized(Expression expr)
			{
				UnaryOperatorExpression unaryOperatorExpression = expr as UnaryOperatorExpression;
				if (unaryOperatorExpression != null)
				{
					if (unaryOperatorExpression.Operator == UnaryOperatorType.PostIncrement || unaryOperatorExpression.Operator == UnaryOperatorType.PostDecrement)
					{
						return false;
					}
					return true;
				}
				if (expr is BinaryOperatorExpression || expr is ConditionalExpression || expr is AssignmentExpression)
				{
					return true;
				}
				return false;
			}

			private static Expression ParenthesizeIfNeeded(Expression expr)
			{
				if (!NeedsToBeParenthesized(expr))
				{
					return expr;
				}
				return new ParenthesizedExpression(expr.Clone());
			}

			public override AstNode VisitQueryFromClause(QueryFromClause queryFromClause)
			{
				if (currentResult == null)
				{
					AddFirstMemberToCurrentTransparentType(queryFromClause.IdentifierToken);
					if (queryFromClause.Type.IsNull)
					{
						return VisitNested(ParenthesizeIfNeeded(queryFromClause.Expression), null);
					}
					return VisitNested(ParenthesizeIfNeeded(queryFromClause.Expression), null).Invoke("Cast", new AstType[1]
					{
						queryFromClause.Type.Clone()
					}, new Expression[0]);
				}
				ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
				Expression expression = VisitNested(queryFromClause.Expression, parameterDeclaration);
				if (!queryFromClause.Type.IsNull)
				{
					expression = expression.Invoke("Cast", new AstType[1]
					{
						queryFromClause.Type.Clone()
					}, new Expression[0]);
				}
				LambdaExpression lambdaExpression = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration
				}, expression);
				Identifier identifier = (Identifier)queryFromClause.IdentifierToken.Clone();
				ParameterDeclaration parameterDeclaration2 = CreateParameterForCurrentRangeVariable();
				QuerySelectClause querySelectClause = GetNextQueryClause(queryFromClause) as QuerySelectClause;
				Expression body;
				if (querySelectClause != null)
				{
					body = VisitNested(querySelectClause.Expression, parameterDeclaration2);
					eatSelect = true;
				}
				else
				{
					body = AddMemberToCurrentTransparentType(parameterDeclaration2, queryFromClause.IdentifierToken, new IdentifierExpression(queryFromClause.Identifier), namedExpression: false);
				}
				ParameterDeclaration parameterDeclaration3 = CreateParameter(identifier);
				LambdaExpression lambdaExpression2 = CreateLambda(new ParameterDeclaration[2]
				{
					parameterDeclaration2,
					parameterDeclaration3
				}, body);
				rangeVariables[queryFromClause.IdentifierToken] = parameterDeclaration3;
				return currentResult.Invoke("SelectMany", lambdaExpression, lambdaExpression2);
			}

			public override AstNode VisitQueryLetClause(QueryLetClause queryLetClause)
			{
				ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
				Expression body = AddMemberToCurrentTransparentType(parameterDeclaration, queryLetClause.IdentifierToken, queryLetClause.Expression, namedExpression: true);
				LambdaExpression lambdaExpression = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration
				}, body);
				return currentResult.Invoke("Select", lambdaExpression);
			}

			public override AstNode VisitQueryWhereClause(QueryWhereClause queryWhereClause)
			{
				ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
				return currentResult.Invoke("Where", CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration
				}, VisitNested(queryWhereClause.Condition, parameterDeclaration)));
			}

			public override AstNode VisitQueryJoinClause(QueryJoinClause queryJoinClause)
			{
				Expression expression = null;
				Expression expression2 = VisitNested(queryJoinClause.InExpression, null);
				if (!queryJoinClause.Type.IsNull)
				{
					expression2 = expression2.Invoke("Cast", new AstType[1]
					{
						queryJoinClause.Type.Clone()
					}, EmptyList<Expression>.Instance);
				}
				ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
				LambdaExpression lambdaExpression = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration
				}, VisitNested(queryJoinClause.OnExpression, parameterDeclaration));
				ParameterDeclaration parameterDeclaration2 = CreateParameter(Identifier.Create(queryJoinClause.JoinIdentifier));
				LambdaExpression lambdaExpression2 = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration2
				}, VisitNested(queryJoinClause.EqualsExpression, null));
				ParameterDeclaration parameterDeclaration3 = CreateParameterForCurrentRangeVariable();
				QuerySelectClause querySelectClause = GetNextQueryClause(queryJoinClause) as QuerySelectClause;
				if (querySelectClause != null)
				{
					expression = VisitNested(querySelectClause.Expression, parameterDeclaration3);
					eatSelect = true;
				}
				if (queryJoinClause.IntoKeyword.IsNull)
				{
					if (expression == null)
					{
						expression = AddMemberToCurrentTransparentType(parameterDeclaration3, queryJoinClause.JoinIdentifierToken, new IdentifierExpression(queryJoinClause.JoinIdentifier), namedExpression: false);
					}
					LambdaExpression lambdaExpression3 = CreateLambda(new ParameterDeclaration[2]
					{
						parameterDeclaration3,
						CreateParameter(Identifier.Create(queryJoinClause.JoinIdentifier))
					}, expression);
					rangeVariables[queryJoinClause.JoinIdentifierToken] = parameterDeclaration2;
					return currentResult.Invoke("Join", expression2, lambdaExpression, lambdaExpression2, lambdaExpression3);
				}
				if (expression == null)
				{
					expression = AddMemberToCurrentTransparentType(parameterDeclaration3, queryJoinClause.IntoIdentifierToken, new IdentifierExpression(queryJoinClause.IntoIdentifier), namedExpression: false);
				}
				ParameterDeclaration parameterDeclaration4 = CreateParameter(Identifier.Create(queryJoinClause.IntoIdentifier));
				LambdaExpression lambdaExpression4 = CreateLambda(new ParameterDeclaration[2]
				{
					parameterDeclaration3,
					parameterDeclaration4
				}, expression);
				rangeVariables[queryJoinClause.IntoIdentifierToken] = parameterDeclaration4;
				return currentResult.Invoke("GroupJoin", expression2, lambdaExpression, lambdaExpression2, lambdaExpression4);
			}

			public override AstNode VisitQueryOrderClause(QueryOrderClause queryOrderClause)
			{
				Expression expression = currentResult;
				bool flag = true;
				foreach (QueryOrdering ordering in queryOrderClause.Orderings)
				{
					string methodName = flag ? ((ordering.Direction == QueryOrderingDirection.Descending) ? "OrderByDescending" : "OrderBy") : ((ordering.Direction == QueryOrderingDirection.Descending) ? "ThenByDescending" : "ThenBy");
					ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
					expression = expression.Invoke(methodName, CreateLambda(new ParameterDeclaration[1]
					{
						parameterDeclaration
					}, VisitNested(ordering.Expression, parameterDeclaration)));
					MapExpression(ordering, expression);
					flag = false;
				}
				return expression;
			}

			private bool IsSingleRangeVariable(Expression expr)
			{
				if (currentTransparentType.Count > 1)
				{
					return false;
				}
				Expression expression = ParenthesizedExpression.UnpackParenthesizedExpression(expr);
				if (expression is IdentifierExpression)
				{
					return ((IdentifierExpression)expression).Identifier == currentTransparentType[0].Item1.Name;
				}
				return false;
			}

			public override AstNode VisitQuerySelectClause(QuerySelectClause querySelectClause)
			{
				if (eatSelect)
				{
					eatSelect = false;
					return currentResult;
				}
				if (((QueryExpression)querySelectClause.Parent).Clauses.Count > 2 && IsSingleRangeVariable(querySelectClause.Expression))
				{
					return currentResult;
				}
				ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
				LambdaExpression lambdaExpression = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration
				}, VisitNested(querySelectClause.Expression, parameterDeclaration));
				return currentResult.Invoke("Select", lambdaExpression);
			}

			public override AstNode VisitQueryGroupClause(QueryGroupClause queryGroupClause)
			{
				ParameterDeclaration parameterDeclaration = CreateParameterForCurrentRangeVariable();
				LambdaExpression lambdaExpression = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration
				}, VisitNested(queryGroupClause.Key, parameterDeclaration));
				if (IsSingleRangeVariable(queryGroupClause.Projection))
				{
					return currentResult.Invoke("GroupBy", lambdaExpression);
				}
				ParameterDeclaration parameterDeclaration2 = CreateParameterForCurrentRangeVariable();
				LambdaExpression lambdaExpression2 = CreateLambda(new ParameterDeclaration[1]
				{
					parameterDeclaration2
				}, VisitNested(queryGroupClause.Projection, parameterDeclaration2));
				return currentResult.Invoke("GroupBy", lambdaExpression, lambdaExpression2);
			}

			public override AstNode VisitIdentifierExpression(IdentifierExpression identifierExpression)
			{
				activeRangeVariableSubstitutions.TryGetValue(identifierExpression.Identifier, out Expression value);
				return value?.Clone();
			}
		}

		public QueryExpressionExpansionResult ExpandQueryExpressions(AstNode node, IEnumerable<string> transparentIdentifierNamePicker)
		{
			Visitor visitor = new Visitor();
			visitor.TransparentIdentifierNamePicker = transparentIdentifierNamePicker.GetEnumerator();
			AstNode astNode = node.AcceptVisitor(visitor);
			if (astNode != null)
			{
				astNode.Freeze();
				return new QueryExpressionExpansionResult(astNode, visitor.rangeVariables, visitor.expressions);
			}
			return null;
		}

		public QueryExpressionExpansionResult ExpandQueryExpressions(AstNode node)
		{
			return ExpandQueryExpressions(node, Enumerable.Empty<string>());
		}
	}
}
