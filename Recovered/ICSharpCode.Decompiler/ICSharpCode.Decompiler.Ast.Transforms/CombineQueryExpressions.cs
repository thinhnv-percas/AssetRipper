using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using System;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class CombineQueryExpressions : IAstTransform
	{
		private readonly DecompilerContext context;

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
			Expression = new Choice
			{
				new AnonymousTypeCreateExpression
				{
					Initializers = 
					{
						new NamedExpression
						{
							Name = Pattern.AnyString,
							Expression = new IdentifierExpression(Pattern.AnyString)
						}.WithName("nae1"),
						new NamedExpression
						{
							Name = Pattern.AnyString,
							Expression = new AnyNode("nae2Expr")
						}.WithName("nae2")
					}
				},
				new AnonymousTypeCreateExpression
				{
					Initializers = 
					{
						(Expression)new NamedNode("identifier", new IdentifierExpression(Pattern.AnyString)),
						(Expression)new AnyNode("nae2Expr")
					}
				}
			}
		};

		public CombineQueryExpressions(DecompilerContext context)
		{
			this.context = context;
		}

		public void Run(AstNode compilationUnit)
		{
			if (context.Settings.QueryExpressions)
			{
				CombineQueries(compilationUnit);
			}
		}

		private void CombineQueries(AstNode node)
		{
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				CombineQueries(astNode);
			}
			QueryExpression queryExpression = node as QueryExpression;
			if (queryExpression == null)
			{
				return;
			}
			QueryFromClause queryFromClause = (QueryFromClause)queryExpression.Clauses.First();
			QueryExpression queryExpression2 = queryFromClause.Expression as QueryExpression;
			if (queryExpression2 != null)
			{
				if (TryRemoveTransparentIdentifier(queryExpression, queryFromClause, queryExpression2))
				{
					RemoveTransparentIdentifierReferences(queryExpression);
					return;
				}
				QueryContinuationClause queryContinuationClause = new QueryContinuationClause();
				queryContinuationClause.PrecedingQuery = queryExpression2.Detach();
				queryContinuationClause.Identifier = queryFromClause.Identifier;
				queryFromClause.ReplaceWith(queryContinuationClause);
			}
			else
			{
				Match match = castPattern.Match(queryFromClause.Expression);
				if (match.Success)
				{
					queryFromClause.Type = match.Get<AstType>("targetType").Single().Detach();
					queryFromClause.Expression = match.Get<Expression>("inExpr").Single().Detach();
				}
			}
		}

		private bool IsTransparentIdentifier(string identifier)
		{
			if (identifier.StartsWith("<>", StringComparison.Ordinal))
			{
				return identifier.Contains("TransparentIdentifier");
			}
			return false;
		}

		private bool TryRemoveTransparentIdentifier(QueryExpression query, QueryFromClause fromClause, QueryExpression innerQuery)
		{
			if (!IsTransparentIdentifier(fromClause.Identifier))
			{
				return false;
			}
			Match match = selectTransparentIdentifierPattern.Match(innerQuery.Clauses.Last());
			if (!match.Success)
			{
				return false;
			}
			QuerySelectClause querySelectClause = (QuerySelectClause)innerQuery.Clauses.Last();
			NamedExpression namedExpression = match.Get<NamedExpression>("nae1").SingleOrDefault();
			NamedExpression namedExpression2 = match.Get<NamedExpression>("nae2").SingleOrDefault();
			if (namedExpression != null && namedExpression.Name != ((IdentifierExpression)namedExpression.Expression).Identifier)
			{
				return false;
			}
			Expression expression = match.Get<Expression>("nae2Expr").Single();
			IdentifierExpression identifierExpression = expression as IdentifierExpression;
			if (identifierExpression != null && (namedExpression2 == null || namedExpression2.Name == identifierExpression.Identifier))
			{
				fromClause.Remove();
				querySelectClause.Remove();
				QueryClause existingItem = null;
				foreach (QueryClause clause in innerQuery.Clauses)
				{
					query.Clauses.InsertAfter(existingItem, existingItem = clause.Detach());
				}
			}
			else
			{
				fromClause.Remove();
				querySelectClause.Remove();
				QueryClause existingItem2 = null;
				foreach (QueryClause clause2 in innerQuery.Clauses)
				{
					query.Clauses.InsertAfter(existingItem2, existingItem2 = clause2.Detach());
				}
				string identifier;
				if (namedExpression2 != null)
				{
					identifier = namedExpression2.Name;
				}
				else if (expression is IdentifierExpression)
				{
					identifier = ((IdentifierExpression)expression).Identifier;
				}
				else
				{
					if (!(expression is MemberReferenceExpression))
					{
						throw new InvalidOperationException("Could not infer name from initializer in AnonymousTypeCreateExpression");
					}
					identifier = ((MemberReferenceExpression)expression).MemberName;
				}
				query.Clauses.InsertAfter(existingItem2, new QueryLetClause
				{
					Identifier = identifier,
					Expression = expression.Detach()
				});
			}
			return true;
		}

		private void RemoveTransparentIdentifierReferences(AstNode node)
		{
			foreach (AstNode child in node.Children)
			{
				RemoveTransparentIdentifierReferences(child);
			}
			MemberReferenceExpression memberReferenceExpression = node as MemberReferenceExpression;
			if (memberReferenceExpression != null)
			{
				IdentifierExpression identifierExpression = memberReferenceExpression.Target as IdentifierExpression;
				if (identifierExpression != null && IsTransparentIdentifier(identifierExpression.Identifier))
				{
					IdentifierExpression identifierExpression2 = new IdentifierExpression(memberReferenceExpression.MemberName);
					memberReferenceExpression.TypeArguments.MoveTo(identifierExpression2.TypeArguments);
					identifierExpression2.CopyAnnotationsFrom(memberReferenceExpression);
					identifierExpression2.RemoveAnnotations<PropertyDeclaration>();
					memberReferenceExpression.ReplaceWith(identifierExpression2);
				}
			}
		}
	}
}
