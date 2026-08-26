using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class IntroduceQueryExpressions : IAstTransform
{
	private class ApplyAnnotationVisitor : DepthFirstAstVisitor<AstNode>
	{
		private LetIdentifierAnnotation annotation;

		private string identifier;

		public ApplyAnnotationVisitor(LetIdentifierAnnotation annotation, string identifier)
		{
			this.annotation = annotation;
			this.identifier = identifier;
		}

		public override AstNode VisitIdentifier(Identifier identifier)
		{
			if (identifier.Name == this.identifier)
			{
				identifier.AddAnnotation(annotation);
			}
			return identifier;
		}
	}

	public void Run(AstNode rootNode, TransformContext context)
	{
		if (!context.Settings.QueryExpressions)
		{
			return;
		}
		DecompileQueries(rootNode);
		foreach (QueryExpression item in Enumerable.OfType<QueryExpression>((IEnumerable)rootNode.Descendants))
		{
			QueryFromClause queryFromClause = (QueryFromClause)Enumerable.First<QueryClause>((IEnumerable<QueryClause>)item.Clauses);
			if (IsDegenerateQuery(item))
			{
				item.Clauses.Add(new QuerySelectClause
				{
					Expression = new IdentifierExpression(queryFromClause.Identifier).CopyAnnotationsFrom(queryFromClause)
				});
			}
			QueryExpression queryExpression = queryFromClause.Expression as QueryExpression;
			while (IsDegenerateQuery(queryExpression))
			{
				QueryFromClause queryFromClause2 = (QueryFromClause)Enumerable.First<QueryClause>((IEnumerable<QueryClause>)queryExpression.Clauses);
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
		QueryClause queryClause = Enumerable.LastOrDefault<QueryClause>((IEnumerable<QueryClause>)query.Clauses);
		return !(queryClause is QuerySelectClause) && !(queryClause is QueryGroupClause);
	}

	private void DecompileQueries(AstNode node)
	{
		QueryExpression queryExpression = DecompileQuery(node as InvocationExpression);
		if (queryExpression != null)
		{
			node.ReplaceWith(queryExpression);
		}
		AstNode astNode = (queryExpression ?? node).FirstChild;
		while (astNode != null)
		{
			AstNode nextSibling = astNode.NextSibling;
			DecompileQueries(astNode);
			astNode = nextSibling;
		}
	}

	private QueryExpression DecompileQuery(InvocationExpression invocation)
	{
		if (invocation == null)
		{
			return null;
		}
		MemberReferenceExpression memberReferenceExpression = invocation.Target as MemberReferenceExpression;
		if (memberReferenceExpression == null || IsNullConditional(memberReferenceExpression.Target))
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
			if (MatchSimpleLambda(Enumerable.Single<Expression>((IEnumerable<Expression>)invocation.Arguments), out var parameter10, out var body9))
			{
				QueryExpression queryExpression7 = new QueryExpression();
				queryExpression7.Clauses.Add(MakeFromClause(parameter10, memberReferenceExpression.Target.Detach()));
				queryExpression7.Clauses.Add(new QuerySelectClause
				{
					Expression = WrapExpressionInParenthesesIfNecessary(body9.Detach(), parameter10.Name)
				});
				return queryExpression7;
			}
			return null;
		}
		case "GroupBy":
		{
			ParameterDeclaration parameter9;
			Expression body8;
			if (invocation.Arguments.Count == 2)
			{
				if (MatchSimpleLambda(Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 0), out var parameter7, out var body6) && MatchSimpleLambda(Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 1), out var parameter8, out var body7) && parameter7.Name == parameter8.Name)
				{
					QueryExpression queryExpression5 = new QueryExpression();
					queryExpression5.Clauses.Add(MakeFromClause(parameter7, memberReferenceExpression.Target.Detach()));
					queryExpression5.Clauses.Add(new QueryGroupClause
					{
						Projection = body7.Detach(),
						Key = body6.Detach()
					});
					return queryExpression5;
				}
			}
			else if (invocation.Arguments.Count == 1 && MatchSimpleLambda(Enumerable.Single<Expression>((IEnumerable<Expression>)invocation.Arguments), out parameter9, out body8))
			{
				QueryExpression queryExpression6 = new QueryExpression();
				queryExpression6.Clauses.Add(MakeFromClause(parameter9, memberReferenceExpression.Target.Detach()));
				queryExpression6.Clauses.Add(new QueryGroupClause
				{
					Projection = new IdentifierExpression(parameter9.Name).CopyAnnotationsFrom(parameter9),
					Key = body8.Detach()
				});
				return queryExpression6;
			}
			return null;
		}
		case "SelectMany":
		{
			if (invocation.Arguments.Count != 2)
			{
				return null;
			}
			if (!MatchSimpleLambda(Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 0), out var parameter3, out var body3))
			{
				return null;
			}
			if (IsNullConditional(body3))
			{
				return null;
			}
			if (Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 1) is LambdaExpression lambdaExpression2 && lambdaExpression2.Parameters.Count == 2 && lambdaExpression2.Body is Expression)
			{
				ParameterDeclaration parameterDeclaration3 = Enumerable.ElementAt<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)lambdaExpression2.Parameters, 0);
				ParameterDeclaration parameter4 = Enumerable.ElementAt<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)lambdaExpression2.Parameters, 1);
				if (parameterDeclaration3.Name == parameter3.Name)
				{
					QueryExpression queryExpression2 = new QueryExpression();
					queryExpression2.Clauses.Add(MakeFromClause(parameterDeclaration3, memberReferenceExpression.Target.Detach()));
					queryExpression2.Clauses.Add(MakeFromClause(parameter4, body3.Detach()));
					queryExpression2.Clauses.Add(new QuerySelectClause
					{
						Expression = WrapExpressionInParenthesesIfNecessary(((Expression)lambdaExpression2.Body).Detach(), parameter3.Name)
					});
					return queryExpression2;
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
			if (MatchSimpleLambda(Enumerable.Single<Expression>((IEnumerable<Expression>)invocation.Arguments), out var parameter6, out var body5))
			{
				QueryExpression queryExpression4 = new QueryExpression();
				queryExpression4.Clauses.Add(MakeFromClause(parameter6, memberReferenceExpression.Target.Detach()));
				queryExpression4.Clauses.Add(new QueryWhereClause
				{
					Condition = body5.Detach()
				});
				return queryExpression4;
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
			if (MatchSimpleLambda(Enumerable.Single<Expression>((IEnumerable<Expression>)invocation.Arguments), out var parameter5, out var body4) && ValidateThenByChain(invocation, parameter5.Name))
			{
				QueryOrderClause queryOrderClause = new QueryOrderClause();
				InvocationExpression invocationExpression = invocation;
				while (memberReferenceExpression.MemberName == "ThenBy" || memberReferenceExpression.MemberName == "ThenByDescending")
				{
					queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
					{
						Expression = body4.Detach(),
						Direction = ((!(memberReferenceExpression.MemberName == "ThenBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
					});
					invocationExpression = (InvocationExpression)memberReferenceExpression.Target;
					memberReferenceExpression = (MemberReferenceExpression)invocationExpression.Target;
					MatchSimpleLambda(Enumerable.Single<Expression>((IEnumerable<Expression>)invocationExpression.Arguments), out parameter5, out body4);
				}
				queryOrderClause.Orderings.InsertAfter(null, new QueryOrdering
				{
					Expression = body4.Detach(),
					Direction = ((!(memberReferenceExpression.MemberName == "OrderBy")) ? QueryOrderingDirection.Descending : QueryOrderingDirection.None)
				});
				QueryExpression queryExpression3 = new QueryExpression();
				queryExpression3.Clauses.Add(MakeFromClause(parameter5, memberReferenceExpression.Target.Detach()));
				queryExpression3.Clauses.Add(queryOrderClause);
				return queryExpression3;
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
			Expression expression = Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 0);
			if (IsNullConditional(expression))
			{
				return null;
			}
			if (!MatchSimpleLambda(Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 1), out var parameter, out var body))
			{
				return null;
			}
			if (!MatchSimpleLambda(Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 2), out var parameter2, out var body2))
			{
				return null;
			}
			if (Enumerable.ElementAt<Expression>((IEnumerable<Expression>)invocation.Arguments, 3) is LambdaExpression lambdaExpression && lambdaExpression.Parameters.Count == 2 && lambdaExpression.Body is Expression)
			{
				ParameterDeclaration parameterDeclaration = Enumerable.ElementAt<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)lambdaExpression.Parameters, 0);
				ParameterDeclaration parameterDeclaration2 = Enumerable.ElementAt<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)lambdaExpression.Parameters, 1);
				if (parameterDeclaration.Name == parameter.Name && (parameterDeclaration2.Name == parameter2.Name || memberReferenceExpression.MemberName == "GroupJoin"))
				{
					QueryExpression queryExpression = new QueryExpression();
					queryExpression.Clauses.Add(MakeFromClause(parameter, target.Detach()));
					QueryJoinClause queryJoinClause = new QueryJoinClause();
					queryJoinClause.JoinIdentifier = parameter2.Name;
					queryJoinClause.InExpression = expression.Detach();
					queryJoinClause.OnExpression = body.Detach();
					queryJoinClause.EqualsExpression = body2.Detach();
					if (memberReferenceExpression.MemberName == "GroupJoin")
					{
						queryJoinClause.IntoIdentifier = parameterDeclaration2.Name;
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

	private QueryFromClause MakeFromClause(ParameterDeclaration parameter, Expression body)
	{
		QueryFromClause queryFromClause = new QueryFromClause
		{
			Identifier = parameter.Name,
			Expression = body
		};
		queryFromClause.CopyAnnotationsFrom(parameter);
		return queryFromClause;
	}

	private bool IsNullConditional(Expression target)
	{
		return target is UnaryOperatorExpression unaryOperatorExpression && unaryOperatorExpression.Operator == UnaryOperatorType.NullConditional;
	}

	private Expression WrapExpressionInParenthesesIfNecessary(Expression expression, string parameterName)
	{
		if (expression is IdentifierExpression identifierExpression && parameterName.Equals(identifierExpression.Identifier, StringComparison.Ordinal))
		{
			return new ParenthesizedExpression(expression);
		}
		return expression;
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
		if (!MatchSimpleLambda(Enumerable.Single<Expression>((IEnumerable<Expression>)invocation.Arguments), out var parameter, out var _))
		{
			return false;
		}
		if (parameter.Name != expectedParameterName)
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

	private bool MatchSimpleLambda(Expression expr, out ParameterDeclaration parameter, out Expression body)
	{
		LambdaExpression lambdaExpression = ((!(expr is CastExpression castExpression)) ? (expr as LambdaExpression) : (castExpression.Expression as LambdaExpression));
		if (lambdaExpression != null && lambdaExpression.Parameters.Count == 1 && lambdaExpression.Body is Expression)
		{
			ParameterDeclaration parameterDeclaration = Enumerable.Single<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)lambdaExpression.Parameters);
			if (parameterDeclaration.ParameterModifier == ParameterModifier.None)
			{
				parameter = parameterDeclaration;
				body = (Expression)lambdaExpression.Body;
				return true;
			}
		}
		parameter = null;
		body = null;
		return false;
	}
}
