using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.Semantics;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class CombineQueryExpressions : IAstTransform
{
	private static readonly InvocationExpression castPattern = new InvocationExpression
	{
		Target = new MemberReferenceExpression
		{
			Target = new AnyNode("inExpr"),
			MemberName = "Cast",
			TypeArguments = { (AstType)new AnyNode("targetType") }
		}
	};

	private static readonly QuerySelectClause selectTransparentIdentifierPattern = new QuerySelectClause
	{
		Expression = new AnonymousTypeCreateExpression
		{
			Initializers = { (Expression)new Repeat(new Choice
			{
				new IdentifierExpression(Pattern.AnyString).WithName("expr"),
				new NamedExpression
				{
					Name = Pattern.AnyString,
					Expression = new AnyNode()
				}.WithName("expr")
			})
			{
				MinCount = 1
			} }
		}
	};

	public void Run(AstNode rootNode, TransformContext context)
	{
		if (context.Settings.QueryExpressions)
		{
			CombineQueries(rootNode, new Dictionary<string, object>());
		}
	}

	private void CombineQueries(AstNode node, Dictionary<string, object> letIdentifiers)
	{
		for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			CombineQueries(astNode, letIdentifiers);
		}
		if (!(node is QueryExpression queryExpression))
		{
			return;
		}
		QueryFromClause queryFromClause = (QueryFromClause)Enumerable.First<QueryClause>((IEnumerable<QueryClause>)queryExpression.Clauses);
		if (queryFromClause.Expression is QueryExpression queryExpression2)
		{
			if (TryRemoveTransparentIdentifier(queryExpression, queryFromClause, queryExpression2, letIdentifiers))
			{
				RemoveTransparentIdentifierReferences(queryExpression, letIdentifiers);
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
				queryFromClause.Type = Enumerable.Single<AstType>(match.Get<AstType>("targetType")).Detach();
				queryFromClause.Expression = Enumerable.Single<Expression>(match.Get<Expression>("inExpr")).Detach();
			}
		}
	}

	private bool IsTransparentIdentifier(string identifier)
	{
		return identifier.StartsWith("<>", StringComparison.Ordinal) && (identifier.Contains("TransparentIdentifier") || identifier.Contains("TranspIdent"));
	}

	private bool TryRemoveTransparentIdentifier(QueryExpression query, QueryFromClause fromClause, QueryExpression innerQuery, Dictionary<string, object> letClauses)
	{
		if (!IsTransparentIdentifier(fromClause.Identifier))
		{
			return false;
		}
		QuerySelectClause querySelectClause = Enumerable.Last<QueryClause>((IEnumerable<QueryClause>)innerQuery.Clauses) as QuerySelectClause;
		Match match = selectTransparentIdentifierPattern.Match(querySelectClause);
		if (!match.Success)
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
		foreach (Expression item in match.Get<Expression>("expr"))
		{
			Expression expression = item;
			Expression expression2 = expression;
			if (expression2 == null)
			{
				continue;
			}
			if (!(expression2 is IdentifierExpression identifierExpression))
			{
				if (expression2 is NamedExpression namedExpression)
				{
					NamedExpression namedExpression2 = namedExpression;
					if (namedExpression2.Expression is IdentifierExpression identifierExpression2 && namedExpression2.Name == identifierExpression2.Identifier)
					{
						letClauses[namedExpression2.Name] = identifierExpression2.Annotation<ILVariableResolveResult>();
						continue;
					}
					QueryLetClause queryLetClause = new QueryLetClause
					{
						Identifier = namedExpression2.Name,
						Expression = namedExpression2.Expression.Detach()
					};
					LetIdentifierAnnotation letIdentifierAnnotation = new LetIdentifierAnnotation();
					queryLetClause.AddAnnotation(letIdentifierAnnotation);
					letClauses[namedExpression2.Name] = letIdentifierAnnotation;
					query.Clauses.InsertAfter(existingItem, queryLetClause);
				}
			}
			else
			{
				IdentifierExpression identifierExpression3 = identifierExpression;
			}
		}
		return true;
	}

	private void RemoveTransparentIdentifierReferences(AstNode node, Dictionary<string, object> letClauses)
	{
		foreach (AstNode child in node.Children)
		{
			RemoveTransparentIdentifierReferences(child, letClauses);
		}
		if (node is MemberReferenceExpression { Target: IdentifierExpression target } memberReferenceExpression && IsTransparentIdentifier(target.Identifier))
		{
			IdentifierExpression identifierExpression = new IdentifierExpression(memberReferenceExpression.MemberName);
			memberReferenceExpression.TypeArguments.MoveTo(identifierExpression.TypeArguments);
			identifierExpression.CopyAnnotationsFrom(memberReferenceExpression);
			identifierExpression.RemoveAnnotations<MemberResolveResult>();
			if (letClauses.TryGetValue(memberReferenceExpression.MemberName, out var value))
			{
				identifierExpression.AddAnnotation(value);
			}
			memberReferenceExpression.ReplaceWith(identifierExpression);
		}
	}
}
