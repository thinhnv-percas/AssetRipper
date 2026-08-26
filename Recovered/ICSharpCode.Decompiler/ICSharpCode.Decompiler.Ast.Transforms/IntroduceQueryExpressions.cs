using ICSharpCode.NRefactory.CSharp;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class IntroduceQueryExpressions : IAstTransform
	{
		private readonly DecompilerContext context;

		public IntroduceQueryExpressions(DecompilerContext context)
		{
			this.context = context;
		}

		public void Run(AstNode compilationUnit)
		{
			if (context.Settings.QueryExpressions)
			{
				DecompileQueries(compilationUnit);
				foreach (QueryExpression item in compilationUnit.Descendants.OfType<QueryExpression>())
				{
					QueryFromClause queryFromClause = (QueryFromClause)item.Clauses.First();
					if (IsDegenerateQuery(item))
					{
						item.Clauses.Add(new QuerySelectClause
						{
							Expression = new IdentifierExpression(queryFromClause.Identifier)
						});
					}
					QueryExpression queryExpression = queryFromClause.Expression as QueryExpression;
					while (IsDegenerateQuery(queryExpression))
					{
						QueryFromClause queryFromClause2 = (QueryFromClause)queryExpression.Clauses.First();
						if (queryFromClause.Identifier != queryFromClause2.Identifier)
						{
							break;
						}
						queryFromClause.Remove();
						QueryClause existingItem = null;
						foreach (QueryClause clause in queryExpression.Clauses)
						{
							item.Clauses.InsertAfter(existingItem, existingItem = clause.Detach());
						}
						queryFromClause = queryFromClause2;
						queryExpression = (queryFromClause.Expression as QueryExpression);
					}
				}
			}
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
			for (AstNode astNode = (queryExpression ?? node).FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				DecompileQueries(astNode);
			}
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
				if (MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName7, out Expression body7))
				{
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName7,
								Expression = memberReferenceExpression.Target.Detach()
							},
							(QueryClause)new QuerySelectClause
							{
								Expression = body7.Detach()
							}
						}
					};
				}
				return null;
			case "GroupBy":
			{
				string parameterName6;
				Expression body6;
				if (invocation.Arguments.Count == 2)
				{
					string parameterName4;
					string parameterName5;
					if (MatchSimpleLambda(invocation.Arguments.ElementAt(0), out parameterName4, out Expression body4) && MatchSimpleLambda(invocation.Arguments.ElementAt(1), out parameterName5, out Expression body5) && parameterName4 == parameterName5)
					{
						return new QueryExpression
						{
							Clauses = 
							{
								(QueryClause)new QueryFromClause
								{
									Identifier = parameterName4,
									Expression = memberReferenceExpression.Target.Detach()
								},
								(QueryClause)new QueryGroupClause
								{
									Projection = body5.Detach(),
									Key = body4.Detach()
								}
							}
						};
					}
				}
				else if (invocation.Arguments.Count == 1 && MatchSimpleLambda(invocation.Arguments.Single(), out parameterName6, out body6))
				{
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName6,
								Expression = memberReferenceExpression.Target.Detach()
							},
							(QueryClause)new QueryGroupClause
							{
								Projection = new IdentifierExpression(parameterName6),
								Key = body6.Detach()
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
				if (!MatchSimpleLambda(invocation.Arguments.ElementAt(0), out string parameterName8, out Expression body8))
				{
					return null;
				}
				LambdaExpression lambdaExpression2 = invocation.Arguments.ElementAt(1) as LambdaExpression;
				if (lambdaExpression2 != null && lambdaExpression2.Parameters.Count == 2 && lambdaExpression2.Body is Expression)
				{
					ParameterDeclaration parameterDeclaration3 = lambdaExpression2.Parameters.ElementAt(0);
					ParameterDeclaration parameterDeclaration4 = lambdaExpression2.Parameters.ElementAt(1);
					if (parameterDeclaration3.Name == parameterName8)
					{
						return new QueryExpression
						{
							Clauses = 
							{
								(QueryClause)new QueryFromClause
								{
									Identifier = parameterDeclaration3.Name,
									Expression = memberReferenceExpression.Target.Detach()
								},
								(QueryClause)new QueryFromClause
								{
									Identifier = parameterDeclaration4.Name,
									Expression = body8.Detach()
								},
								(QueryClause)new QuerySelectClause
								{
									Expression = ((Expression)lambdaExpression2.Body).Detach()
								}
							}
						};
					}
				}
				return null;
			}
			case "Where":
				if (invocation.Arguments.Count != 1)
				{
					return null;
				}
				if (MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName3, out Expression body3))
				{
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName3,
								Expression = memberReferenceExpression.Target.Detach()
							},
							(QueryClause)new QueryWhereClause
							{
								Condition = body3.Detach()
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
				if (MatchSimpleLambda(invocation.Arguments.Single(), out string parameterName9, out Expression body9) && ValidateThenByChain(invocation, parameterName9))
				{
					QueryOrderClause queryOrderClause = new QueryOrderClause();
					while (memberReferenceExpression.MemberName == "ThenBy" || memberReferenceExpression.MemberName == "ThenByDescending")
					{
						queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
						{
							Expression = body9.Detach(),
							Direction = ((!(memberReferenceExpression.MemberName == "ThenBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
						});
						InvocationExpression invocationExpression = (InvocationExpression)memberReferenceExpression.Target;
						memberReferenceExpression = (MemberReferenceExpression)invocationExpression.Target;
						MatchSimpleLambda(invocationExpression.Arguments.Single(), out parameterName9, out body9);
					}
					queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
					{
						Expression = body9.Detach(),
						Direction = ((!(memberReferenceExpression.MemberName == "OrderBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
					});
					return new QueryExpression
					{
						Clauses = 
						{
							(QueryClause)new QueryFromClause
							{
								Identifier = parameterName9,
								Expression = memberReferenceExpression.Target.Detach()
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
				Expression node = invocation.Arguments.ElementAt(0);
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
					ParameterDeclaration parameterDeclaration = lambdaExpression.Parameters.ElementAt(0);
					ParameterDeclaration parameterDeclaration2 = lambdaExpression.Parameters.ElementAt(1);
					if (parameterDeclaration.Name == parameterName && (parameterDeclaration2.Name == parameterName2 || memberReferenceExpression.MemberName == "GroupJoin"))
					{
						QueryExpression obj = new QueryExpression
						{
							Clauses = 
							{
								(QueryClause)new QueryFromClause
								{
									Identifier = parameterName,
									Expression = target.Detach()
								}
							}
						};
						QueryJoinClause queryJoinClause = new QueryJoinClause
						{
							JoinIdentifier = parameterName2,
							InExpression = node.Detach(),
							OnExpression = body.Detach(),
							EqualsExpression = body2.Detach()
						};
						if (memberReferenceExpression.MemberName == "GroupJoin")
						{
							queryJoinClause.IntoIdentifier = parameterDeclaration2.Name;
						}
						obj.Clauses.Add(queryJoinClause);
						obj.Clauses.Add(new QuerySelectClause
						{
							Expression = ((Expression)lambdaExpression.Body).Detach()
						});
						return obj;
					}
				}
				return null;
			}
			default:
				return null;
			}
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
