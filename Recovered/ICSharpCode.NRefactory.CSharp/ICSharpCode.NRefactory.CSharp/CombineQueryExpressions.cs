using ICSharpCode.NRefactory.PatternMatching;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CombineQueryExpressions
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

		private static readonly QuerySelectClause selectTransparentIdentifierPattern = new QuerySelectClause
		{
			Expression = new AnonymousTypeCreateExpression
			{
				Initializers = 
				{
					(Expression)new AnyNode("nae1"),
					(Expression)new AnyNode("nae2")
				}
			}
		};

		public string CombineQuery(AstNode node, AstNode rootQuery = null)
		{
			if (rootQuery == null)
			{
				rootQuery = node;
			}
			QueryExpression queryExpression = node as QueryExpression;
			if (queryExpression != null)
			{
				string text = null;
				foreach (QueryClause clause in queryExpression.Clauses)
				{
					QueryContinuationClause queryContinuationClause = clause as QueryContinuationClause;
					if (queryContinuationClause != null)
					{
						CombineQuery(queryContinuationClause.PrecedingQuery);
					}
					QueryFromClause queryFromClause = clause as QueryFromClause;
					if (queryFromClause != null)
					{
						text = CombineQuery(queryFromClause.Expression, rootQuery);
					}
				}
				QueryFromClause queryFromClause2 = (QueryFromClause)queryExpression.Clauses.First();
				QueryExpression queryExpression2 = queryFromClause2.Expression as QueryExpression;
				if (queryExpression2 != null)
				{
					text = (text ?? ((QueryFromClause)queryExpression2.Clauses.First()).Identifier);
					if (TryRemoveTransparentIdentifier(queryExpression, queryFromClause2, queryExpression2, text, out string transparentIdentifier))
					{
						RemoveTransparentIdentifierReferences(rootQuery, transparentIdentifier);
					}
					else if (queryFromClause2.Type.IsNull)
					{
						QueryContinuationClause queryContinuationClause2 = new QueryContinuationClause();
						queryContinuationClause2.PrecedingQuery = queryExpression2.Detach();
						queryContinuationClause2.Identifier = queryFromClause2.Identifier;
						queryFromClause2.ReplaceWith(queryContinuationClause2);
					}
					return transparentIdentifier;
				}
				Match match = castPattern.Match(queryFromClause2.Expression);
				if (match.Success)
				{
					queryFromClause2.Type = match.Get<AstType>("targetType").Single().Detach();
					queryFromClause2.Expression = match.Get<Expression>("inExpr").Single().Detach();
				}
			}
			return null;
		}

		private bool TryRemoveTransparentIdentifier(QueryExpression query, QueryFromClause fromClause, QueryExpression innerQuery, string continuationIdentifier, out string transparentIdentifier)
		{
			transparentIdentifier = fromClause.Identifier;
			Match match = selectTransparentIdentifierPattern.Match(innerQuery.Clauses.Last());
			if (!match.Success)
			{
				return false;
			}
			QuerySelectClause querySelectClause = (QuerySelectClause)innerQuery.Clauses.Last();
			Expression expr = match.Get<Expression>("nae1").SingleOrDefault();
			string text = ExtractExpressionName(ref expr);
			if (text == null)
			{
				return false;
			}
			Expression expr2 = match.Get<Expression>("nae2").SingleOrDefault();
			string nae2Name = ExtractExpressionName(ref expr2);
			if (nae2Name == null)
			{
				return false;
			}
			bool flag = true;
			IdentifierExpression identifierExpression = expr as IdentifierExpression;
			IdentifierExpression identifierExpression2 = expr2 as IdentifierExpression;
			if (identifierExpression != null && identifierExpression2 != null && identifierExpression.Identifier == text && identifierExpression2.Identifier == nae2Name)
			{
				flag = false;
			}
			if (text != continuationIdentifier)
			{
				if (!(nae2Name == continuationIdentifier))
				{
					return false;
				}
				string text2 = text;
				Expression expression = expr;
				text = nae2Name;
				expr = expr2;
				nae2Name = text2;
				expr2 = expression;
			}
			if (flag && innerQuery.Clauses.OfType<QueryFromClause>().Any((QueryFromClause from) => from.Identifier == nae2Name))
			{
				return false;
			}
			if (flag && innerQuery.Clauses.OfType<QueryJoinClause>().Any((QueryJoinClause join) => join.JoinIdentifier == nae2Name))
			{
				return false;
			}
			fromClause.Remove();
			querySelectClause.Remove();
			QueryClause existingItem = null;
			foreach (QueryClause clause in innerQuery.Clauses)
			{
				query.Clauses.InsertAfter(existingItem, existingItem = clause.Detach());
			}
			if (flag)
			{
				query.Clauses.InsertAfter(existingItem, new QueryLetClause
				{
					Identifier = nae2Name,
					Expression = expr2.Detach()
				});
			}
			return true;
		}

		private void RemoveTransparentIdentifierReferences(AstNode node, string transparentIdentifier)
		{
			foreach (AstNode child in node.Children)
			{
				RemoveTransparentIdentifierReferences(child, transparentIdentifier);
			}
			MemberReferenceExpression memberReferenceExpression = node as MemberReferenceExpression;
			if (memberReferenceExpression != null)
			{
				IdentifierExpression identifierExpression = memberReferenceExpression.Target as IdentifierExpression;
				if (identifierExpression != null && identifierExpression.Identifier == transparentIdentifier)
				{
					IdentifierExpression identifierExpression2 = new IdentifierExpression(memberReferenceExpression.MemberName);
					memberReferenceExpression.TypeArguments.MoveTo(identifierExpression2.TypeArguments);
					identifierExpression2.CopyAnnotationsFrom(memberReferenceExpression);
					identifierExpression2.RemoveAnnotations<PropertyDeclaration>();
					memberReferenceExpression.ReplaceWith(identifierExpression2);
				}
				else if (memberReferenceExpression.MemberName == transparentIdentifier)
				{
					Expression expression = memberReferenceExpression.Target.Detach();
					expression.CopyAnnotationsFrom(memberReferenceExpression);
					expression.RemoveAnnotations<PropertyDeclaration>();
					memberReferenceExpression.ReplaceWith(expression);
				}
			}
		}

		private string ExtractExpressionName(ref Expression expr)
		{
			NamedExpression namedExpression = expr as NamedExpression;
			if (namedExpression != null)
			{
				expr = namedExpression.Expression;
				return namedExpression.Name;
			}
			IdentifierExpression identifierExpression = expr as IdentifierExpression;
			if (identifierExpression != null)
			{
				return identifierExpression.Identifier;
			}
			return (expr as MemberReferenceExpression)?.MemberName;
		}
	}
}
