using System.Linq;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class IntroduceQueryExpressions : IAstTransformPoolObject, IAstTransform
{
	private DecompilerContext context;

	public IntroduceQueryExpressions(DecompilerContext context)
	{
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		this.context = context;
	}

	public void Run(AstNode compilationUnit)
	{
		if (!context.Settings.QueryExpressions)
		{
			return;
		}
		DecompileQueries(compilationUnit);
		foreach (QueryExpression item in compilationUnit.Descendants.OfType<QueryExpression>())
		{
			QueryFromClause queryFromClause = (QueryFromClause)item.Clauses.First();
			if (IsDegenerateQuery(item))
			{
				item.Clauses.Add(new QuerySelectClause
				{
					Expression = IdentifierExpression.Create(queryFromClause.Identifier, queryFromClause.IdentifierToken.Annotation<object>())
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
				queryExpression = queryFromClause.Expression as QueryExpression;
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
		{
			if (invocation.Arguments.Count != 1)
			{
				return null;
			}
			if (MatchSimpleLambda(invocation.Arguments.Single(), out var parameterName7, out var body7))
			{
				QueryExpression queryExpression5 = new QueryExpression();
				queryExpression5.Clauses.Add(new QueryFromClause
				{
					IdentifierToken = Identifier.Create(parameterName7).WithAnnotation(BoxedTextColor.Parameter),
					Expression = memberReferenceExpression.Target.Detach()
				});
				queryExpression5.Clauses.Add(new QuerySelectClause
				{
					Expression = body7.Detach()
				});
				return queryExpression5;
			}
			return null;
		}
		case "GroupBy":
		{
			string parameterName6;
			Expression body6;
			if (invocation.Arguments.Count == 2)
			{
				if (MatchSimpleLambda(invocation.Arguments.ElementAt(0), out var parameterName4, out var body4) && MatchSimpleLambda(invocation.Arguments.ElementAt(1), out var parameterName5, out var body5) && parameterName4 == parameterName5)
				{
					QueryExpression queryExpression3 = new QueryExpression();
					queryExpression3.Clauses.Add(new QueryFromClause
					{
						IdentifierToken = Identifier.Create(parameterName4).WithAnnotation(BoxedTextColor.Parameter),
						Expression = memberReferenceExpression.Target.Detach()
					});
					queryExpression3.Clauses.Add(new QueryGroupClause
					{
						Projection = body5.Detach(),
						Key = body4.Detach()
					});
					return queryExpression3;
				}
			}
			else if (invocation.Arguments.Count == 1 && MatchSimpleLambda(invocation.Arguments.Single(), out parameterName6, out body6))
			{
				QueryExpression queryExpression4 = new QueryExpression();
				queryExpression4.Clauses.Add(new QueryFromClause
				{
					IdentifierToken = Identifier.Create(parameterName6).WithAnnotation(BoxedTextColor.Parameter),
					Expression = memberReferenceExpression.Target.Detach()
				});
				queryExpression4.Clauses.Add(new QueryGroupClause
				{
					Projection = IdentifierExpression.Create(parameterName6, BoxedTextColor.Parameter),
					Key = body6.Detach()
				});
				return queryExpression4;
			}
			return null;
		}
		case "SelectMany":
		{
			if (invocation.Arguments.Count != 2)
			{
				return null;
			}
			if (!MatchSimpleLambda(invocation.Arguments.ElementAt(0), out var parameterName8, out var body8))
			{
				return null;
			}
			if (invocation.Arguments.ElementAt(1) is LambdaExpression lambdaExpression2 && lambdaExpression2.Parameters.Count == 2 && lambdaExpression2.Body is Expression)
			{
				ParameterDeclaration parameterDeclaration3 = lambdaExpression2.Parameters.ElementAt(0);
				ParameterDeclaration parameterDeclaration4 = lambdaExpression2.Parameters.ElementAt(1);
				if (parameterDeclaration3.Name == parameterName8)
				{
					QueryExpression queryExpression6 = new QueryExpression();
					queryExpression6.Clauses.Add(new QueryFromClause
					{
						IdentifierToken = Identifier.Create(parameterDeclaration3.Name).WithAnnotation(BoxedTextColor.Parameter),
						Expression = memberReferenceExpression.Target.Detach()
					});
					queryExpression6.Clauses.Add(new QueryFromClause
					{
						IdentifierToken = Identifier.Create(parameterDeclaration4.Name).WithAnnotation(BoxedTextColor.Parameter),
						Expression = body8.Detach()
					});
					queryExpression6.Clauses.Add(new QuerySelectClause
					{
						Expression = ((Expression)lambdaExpression2.Body).Detach()
					});
					return queryExpression6;
				}
			}
			return null;
		}
		case "Where":
		{
			if (invocation.Arguments.Count != 1)
			{
				return null;
			}
			if (MatchSimpleLambda(invocation.Arguments.Single(), out var parameterName3, out var body3))
			{
				QueryExpression queryExpression2 = new QueryExpression();
				queryExpression2.Clauses.Add(new QueryFromClause
				{
					IdentifierToken = Identifier.Create(parameterName3).WithAnnotation(BoxedTextColor.Parameter),
					Expression = memberReferenceExpression.Target.Detach()
				});
				queryExpression2.Clauses.Add(new QueryWhereClause
				{
					Condition = body3.Detach()
				});
				return queryExpression2;
			}
			return null;
		}
		case "OrderBy":
		case "OrderByDescending":
		case "ThenBy":
		case "ThenByDescending":
		{
			if (invocation.Arguments.Count != 1)
			{
				return null;
			}
			if (MatchSimpleLambda(invocation.Arguments.Single(), out var parameterName9, out var body9) && ValidateThenByChain(invocation, parameterName9))
			{
				QueryOrderClause queryOrderClause = new QueryOrderClause();
				InvocationExpression invocationExpression = invocation;
				while (memberReferenceExpression.MemberName == "ThenBy" || memberReferenceExpression.MemberName == "ThenByDescending")
				{
					queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
					{
						Expression = body9.Detach(),
						Direction = ((!(memberReferenceExpression.MemberName == "ThenBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
					});
					invocationExpression = (InvocationExpression)memberReferenceExpression.Target;
					memberReferenceExpression = (MemberReferenceExpression)invocationExpression.Target;
					MatchSimpleLambda(invocationExpression.Arguments.Single(), out parameterName9, out body9);
				}
				queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
				{
					Expression = body9.Detach(),
					Direction = ((!(memberReferenceExpression.MemberName == "OrderBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
				});
				QueryExpression queryExpression7 = new QueryExpression();
				queryExpression7.Clauses.Add(new QueryFromClause
				{
					IdentifierToken = Identifier.Create(parameterName9).WithAnnotation(BoxedTextColor.Parameter),
					Expression = memberReferenceExpression.Target.Detach()
				});
				queryExpression7.Clauses.Add(queryOrderClause);
				return queryExpression7;
			}
			return null;
		}
		case "Join":
		case "GroupJoin":
		{
			if (invocation.Arguments.Count != 4)
			{
				return null;
			}
			Expression target = memberReferenceExpression.Target;
			Expression node = invocation.Arguments.ElementAt(0);
			if (!MatchSimpleLambda(invocation.Arguments.ElementAt(1), out var parameterName, out var body))
			{
				return null;
			}
			if (!MatchSimpleLambda(invocation.Arguments.ElementAt(2), out var parameterName2, out var body2))
			{
				return null;
			}
			if (invocation.Arguments.ElementAt(3) is LambdaExpression lambdaExpression && lambdaExpression.Parameters.Count == 2 && lambdaExpression.Body is Expression)
			{
				ParameterDeclaration parameterDeclaration = lambdaExpression.Parameters.ElementAt(0);
				ParameterDeclaration parameterDeclaration2 = lambdaExpression.Parameters.ElementAt(1);
				if (parameterDeclaration.Name == parameterName && (parameterDeclaration2.Name == parameterName2 || memberReferenceExpression.MemberName == "GroupJoin"))
				{
					QueryExpression queryExpression = new QueryExpression();
					queryExpression.Clauses.Add(new QueryFromClause
					{
						IdentifierToken = Identifier.Create(parameterName).WithAnnotation(BoxedTextColor.Parameter),
						Expression = target.Detach()
					});
					QueryJoinClause queryJoinClause = new QueryJoinClause();
					queryJoinClause.JoinIdentifierToken = Identifier.Create(parameterName2).WithAnnotation(BoxedTextColor.Parameter);
					queryJoinClause.InExpression = node.Detach();
					queryJoinClause.OnExpression = body.Detach();
					queryJoinClause.EqualsExpression = body2.Detach();
					if (memberReferenceExpression.MemberName == "GroupJoin")
					{
						queryJoinClause.IntoIdentifierToken = Identifier.Create(parameterDeclaration2.Name).WithAnnotation(BoxedTextColor.Parameter);
					}
					queryExpression.Clauses.Add(queryJoinClause);
					queryExpression.Clauses.Add(new QuerySelectClause
					{
						Expression = ((Expression)lambdaExpression.Body).Detach()
					});
					return queryExpression;
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
		if (!(invocation.Target is MemberReferenceExpression memberReferenceExpression))
		{
			return false;
		}
		if (!MatchSimpleLambda(invocation.Arguments.Single(), out var parameterName, out var _))
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
		if (expr is LambdaExpression lambdaExpression && lambdaExpression.Parameters.Count == 1 && lambdaExpression.Body is Expression)
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
