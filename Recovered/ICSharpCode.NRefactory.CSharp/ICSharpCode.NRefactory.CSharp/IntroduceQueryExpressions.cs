using ICSharpCode.NRefactory.PatternMatching;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class IntroduceQueryExpressions
	{
		private static readonly InvocationExpression castPattern = new InvocationExpression
		{
			Target = new MemberReferenceExpression
			{
				Target = new AnyNode("inExpr"),
				MemberName = "Cast",
				TypeArguments = 
				{
					(AstType)new AnyNode("targetType")
				}
			}
		};

		private int id = 1;

		public Expression ConvertFluentToQuery(Expression node)
		{
			node = node.Clone();
			ExpressionStatement expressionStatement = new ExpressionStatement();
			expressionStatement.Expression = node;
			DecompileQueries(node);
			foreach (QueryExpression item in expressionStatement.Descendants.OfType<QueryExpression>())
			{
				QueryFromClause queryFromClause = (QueryFromClause)item.Clauses.First();
				if (IsDegenerateQuery(item))
				{
					string identifier2 = queryFromClause.Identifier;
					item.Clauses.Add(new QuerySelectClause
					{
						Expression = new IdentifierExpression(identifier2)
					});
				}
				if (queryFromClause.Type.IsNull)
				{
					QueryExpression queryExpression = queryFromClause.Expression as QueryExpression;
					while (IsDegenerateQuery(queryExpression))
					{
						QueryFromClause innerFromClause = (QueryFromClause)queryExpression.Clauses.First();
						if (queryFromClause.Identifier != innerFromClause.Identifier && !innerFromClause.Identifier.StartsWith("<>"))
						{
							break;
						}
						queryFromClause.Remove();
						foreach (Identifier item2 in from identifier in queryExpression.Descendants.OfType<Identifier>()
							where identifier.Name == innerFromClause.Identifier
							select identifier)
						{
							item2.ReplaceWith(queryFromClause.IdentifierToken.Clone());
						}
						QueryClause existingItem = null;
						foreach (QueryClause clause in queryExpression.Clauses)
						{
							item.Clauses.InsertAfter(existingItem, existingItem = clause.Detach());
						}
						queryFromClause = innerFromClause;
						queryExpression = (queryFromClause.Expression as QueryExpression);
					}
				}
			}
			return expressionStatement.Expression.Clone();
		}

		private bool IsDegenerateQuery(QueryExpression query)
		{
			if (query == null)
			{
				return false;
			}
			QueryClause queryClause = query.Clauses.LastOrDefault();
			if (!(queryClause is QuerySelectClause))
			{
				return !(queryClause is QueryGroupClause);
			}
			return false;
		}

		private void DecompileQueries(AstNode node)
		{
			QueryExpression queryExpression = DecompileQuery(node as InvocationExpression);
			if (queryExpression != null)
			{
				node.ReplaceWith(queryExpression);
			}
		}

		private Expression ExtractQuery(MemberReferenceExpression mre)
		{
			Expression expression = mre.Target.Clone();
			return DecompileQuery(expression as InvocationExpression) ?? expression;
		}

		private QueryExpression DecompileQuery(InvocationExpression invocation)
		{
			if (invocation == null)
			{
				return null;
			}
			MemberReferenceExpression memberReferenceExpression = invocation.Target as MemberReferenceExpression;
			if (memberReferenceExpression == null)
			{
				return null;
			}
			switch (memberReferenceExpression.MemberName)
			{
			case "Select":
				if (invocation.Arguments.Count != 1)
				{
					return null;
				}
				if (MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName8, out Expression body8))
				{
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName8,
								Expression = ExtractQuery(memberReferenceExpression)
							},
							(QueryClause)new QuerySelectClause
							{
								Expression = body8.Detach()
							}
						}
					};
				}
				return null;
			case "Cast":
				if (invocation.Arguments.Count == 0 && memberReferenceExpression.TypeArguments.Count == 1)
				{
					AstType node = memberReferenceExpression.TypeArguments.First();
					QueryExpression queryExpression2 = new QueryExpression();
					string identifier = GenerateVariableName();
					queryExpression2.Clauses.Add(new QueryFromClause
					{
						Identifier = identifier,
						Expression = ExtractQuery(memberReferenceExpression),
						Type = node.Detach()
					});
					return queryExpression2;
				}
				return null;
			case "GroupBy":
			{
				string parameterName7;
				Expression body7;
				if (invocation.Arguments.Count == 2)
				{
					string parameterName5;
					string parameterName6;
					if (MatchSimpleLambda(invocation.Arguments.ElementAt(0), out parameterName5, out Expression body5) && MatchSimpleLambda(invocation.Arguments.ElementAt(1), out parameterName6, out Expression body6) && parameterName5 == parameterName6)
					{
						return new QueryExpression
						{
							Clauses = 
							{
								(QueryClause)new QueryFromClause
								{
									Identifier = parameterName5,
									Expression = ExtractQuery(memberReferenceExpression)
								},
								(QueryClause)new QueryGroupClause
								{
									Projection = body6.Detach(),
									Key = body5.Detach()
								}
							}
						};
					}
				}
				else if (invocation.Arguments.Count == 1 && MatchSimpleLambda(invocation.Arguments.Single(), out parameterName7, out body7))
				{
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName7,
								Expression = ExtractQuery(memberReferenceExpression)
							},
							(QueryClause)new QueryGroupClause
							{
								Projection = new IdentifierExpression(parameterName7),
								Key = body7.Detach()
							}
						}
					};
				}
				return null;
			}
			case "SelectMany":
			{
				if (invocation.Arguments.Count != 2)
				{
					return null;
				}
				if (!MatchSimpleLambda(invocation.Arguments.ElementAt(0), out string _, out Expression body3))
				{
					return null;
				}
				LambdaExpression lambdaExpression2 = invocation.Arguments.ElementAt(1) as LambdaExpression;
				if (lambdaExpression2 != null && lambdaExpression2.Parameters.Count == 2 && lambdaExpression2.Body is Expression)
				{
					ParameterDeclaration parameterDeclaration = lambdaExpression2.Parameters.ElementAt(0);
					ParameterDeclaration parameterDeclaration2 = lambdaExpression2.Parameters.ElementAt(1);
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterDeclaration.Name,
								Expression = ExtractQuery(memberReferenceExpression)
							},
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterDeclaration2.Name,
								Expression = body3.Detach()
							},
							(QueryClause)new QuerySelectClause
							{
								Expression = ((Expression)lambdaExpression2.Body).Detach()
							}
						}
					};
				}
				return null;
			}
			case "Where":
				if (invocation.Arguments.Count != 1)
				{
					return null;
				}
				if (MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName9, out Expression body9))
				{
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName9,
								Expression = ExtractQuery(memberReferenceExpression)
							},
							(QueryClause)new QueryWhereClause
							{
								Condition = body9.Detach()
							}
						}
					};
				}
				return null;
			case "OrderBy":
			case "OrderByDescending":
			case "ThenBy":
			case "ThenByDescending":
				if (invocation.Arguments.Count != 1)
				{
					return null;
				}
				if (MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName4, out Expression body4) && ValidateThenByChain(invocation, parameterName4))
				{
					QueryOrderClause queryOrderClause = new QueryOrderClause();
					while (memberReferenceExpression.MemberName == "ThenBy" || memberReferenceExpression.MemberName == "ThenByDescending")
					{
						queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
						{
							Expression = body4.Detach(),
							Direction = ((!(memberReferenceExpression.MemberName == "ThenBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
						});
						InvocationExpression invocationExpression = (InvocationExpression)memberReferenceExpression.Target;
						memberReferenceExpression = (MemberReferenceExpression)invocationExpression.Target;
						MatchSimpleLambda(invocationExpression.Arguments.Single(), out parameterName4, out body4);
					}
					queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
					{
						Expression = body4.Detach(),
						Direction = ((!(memberReferenceExpression.MemberName == "OrderBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
					});
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName4,
								Expression = ExtractQuery(memberReferenceExpression)
							},
							(QueryClause)queryOrderClause
						}
					};
				}
				return null;
			case "Join":
			case "GroupJoin":
			{
				if (invocation.Arguments.Count != 4)
				{
					return null;
				}
				Expression target = memberReferenceExpression.Target;
				Expression expression = invocation.Arguments.ElementAt(0);
				if (!MatchSimpleLambda(invocation.Arguments.ElementAt(1), out string parameterName, out Expression body))
				{
					return null;
				}
				if (!MatchSimpleLambda(invocation.Arguments.ElementAt(2), out string parameterName2, out Expression body2))
				{
					return null;
				}
				LambdaExpression lambdaExpression = invocation.Arguments.ElementAt(3) as LambdaExpression;
				if (lambdaExpression != null && lambdaExpression.Parameters.Count == 2 && lambdaExpression.Body is Expression)
				{
					ParameterDeclaration p3 = lambdaExpression.Parameters.ElementAt(0);
					ParameterDeclaration p2 = lambdaExpression.Parameters.ElementAt(1);
					QueryExpression queryExpression = new QueryExpression();
					queryExpression.Clauses.Add(new QueryFromClause
					{
						Identifier = parameterName,
						Expression = target.Detach()
					});
					QueryJoinClause queryJoinClause = new QueryJoinClause();
					queryJoinClause.JoinIdentifier = parameterName2;
					queryJoinClause.InExpression = expression.Detach();
					Match match = castPattern.Match(expression);
					if (match.Success)
					{
						Expression inExpression = match.Get<Expression>("inExpr").Single().Detach();
						queryJoinClause.Type = match.Get<AstType>("targetType").Single().Detach();
						queryJoinClause.InExpression = inExpression;
					}
					queryJoinClause.OnExpression = body.Detach();
					queryJoinClause.EqualsExpression = body2.Detach();
					if (memberReferenceExpression.MemberName == "GroupJoin")
					{
						queryJoinClause.IntoIdentifier = p2.Name;
					}
					queryExpression.Clauses.Add(queryJoinClause);
					Expression expression2 = ((Expression)lambdaExpression.Body).Detach();
					if (p3.Name != parameterName)
					{
						foreach (Identifier item in from id in expression2.Descendants.OfType<Identifier>()
							where id.Name == p3.Name
							select id)
						{
							item.Name = parameterName;
						}
					}
					if (p2.Name != parameterName2 && memberReferenceExpression.MemberName != "GroupJoin")
					{
						foreach (Identifier item2 in from id in expression2.Descendants.OfType<Identifier>()
							where id.Name == p2.Name
							select id)
						{
							item2.Name = parameterName2;
						}
					}
					queryExpression.Clauses.Add(new QuerySelectClause
					{
						Expression = expression2
					});
					return queryExpression;
				}
				return null;
			}
			default:
				return null;
			}
		}

		private string GenerateVariableName()
		{
			return "<>" + id++;
		}

		private bool ValidateThenByChain(InvocationExpression invocation, string expectedParameterName)
		{
			if (invocation == null || invocation.Arguments.Count != 1)
			{
				return false;
			}
			MemberReferenceExpression memberReferenceExpression = invocation.Target as MemberReferenceExpression;
			if (memberReferenceExpression == null)
			{
				return false;
			}
			if (!MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName, out Expression _))
			{
				return false;
			}
			if (parameterName != expectedParameterName)
			{
				return false;
			}
			if (memberReferenceExpression.MemberName == "OrderBy" || memberReferenceExpression.MemberName == "OrderByDescending")
			{
				return true;
			}
			if (memberReferenceExpression.MemberName == "ThenBy" || memberReferenceExpression.MemberName == "ThenByDescending")
			{
				return ValidateThenByChain(memberReferenceExpression.Target as InvocationExpression, expectedParameterName);
			}
			return false;
		}

		private bool MatchSimpleLambda(Expression expr, out string parameterName, out Expression body)
		{
			LambdaExpression lambdaExpression = expr as LambdaExpression;
			if (lambdaExpression != null && lambdaExpression.Parameters.Count == 1 && lambdaExpression.Body is Expression)
			{
				ParameterDeclaration parameterDeclaration = lambdaExpression.Parameters.Single();
				if (parameterDeclaration.ParameterModifier == ParameterModifier.None)
				{
					parameterName = parameterDeclaration.Name;
					body = (Expression)lambdaExpression.Body;
					return true;
				}
			}
			parameterName = null;
			body = null;
			return false;
		}
	}
}
