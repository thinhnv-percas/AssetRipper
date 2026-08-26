using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class UsingHelper
	{
		private sealed class UsingInfo : IComparable<UsingInfo>
		{
			public AstNode Node;

			public string Alias;

			public string Name;

			public bool IsAlias;

			public bool HasTypesFromOtherAssemblies;

			public bool IsSystem;

			public UsingInfo(AstNode node, BaseRefactoringContext context)
			{
				Tuple<AstType, string> importAndAlias = GetImportAndAlias(node);
				Node = node;
				Alias = importAndAlias.Item2;
				Name = importAndAlias.Item1.ToString();
				IsAlias = (Alias != null);
				HasTypesFromOtherAssemblies = ((((!node.Ancestors.Contains(context.RootNode)) ? new CSharpAstResolver(new CSharpResolver(context.Compilation), node).Resolve(importAndAlias.Item1) : context.Resolve(importAndAlias.Item1)) as NamespaceResolveResult)?.Namespace.ContributingAssemblies.Any((IAssembly a) => !a.IsMainAssembly) ?? false);
				IsSystem = (HasTypesFromOtherAssemblies && (Name == "System" || Name.StartsWith("System.", StringComparison.Ordinal)));
			}

			private static Tuple<AstType, string> GetImportAndAlias(AstNode node)
			{
				UsingDeclaration usingDeclaration = node as UsingDeclaration;
				if (usingDeclaration != null)
				{
					return Tuple.Create<AstType, string>(usingDeclaration.Import, null);
				}
				UsingAliasDeclaration usingAliasDeclaration = node as UsingAliasDeclaration;
				if (usingAliasDeclaration != null)
				{
					return Tuple.Create(usingAliasDeclaration.Import, usingAliasDeclaration.Alias);
				}
				throw new InvalidOperationException($"Invalid using node: {node}");
			}

			public int CompareTo(UsingInfo y)
			{
				if (IsAlias != y.IsAlias)
				{
					if (!IsAlias)
					{
						return -1;
					}
					return 1;
				}
				if (IsAlias)
				{
					return StringComparer.OrdinalIgnoreCase.Compare(Alias, y.Alias);
				}
				if (IsSystem != y.IsSystem)
				{
					if (!IsSystem)
					{
						return 1;
					}
					return -1;
				}
				return StringComparer.OrdinalIgnoreCase.Compare(Name, y.Name);
			}
		}

		public static void InsertUsingAndRemoveRedundantNamespaceUsage(RefactoringContext context, Script script, string ns)
		{
			InsertUsing(context, script, new UsingDeclaration(ns));
		}

		public static void InsertUsing(RefactoringContext context, Script script, AstNode newUsing)
		{
			UsingInfo usingInfo = new UsingInfo(newUsing, context);
			AstNode astNode = context.GetNode<NamespaceDeclaration>() ?? context.RootNode;
			AstNode astNode2 = astNode;
			while (astNode2 != null && !astNode2.Children.OfType<UsingDeclaration>().Any())
			{
				astNode2 = astNode2.Parent;
			}
			if (astNode2 == null)
			{
				astNode2 = ((script.FormattingOptions.UsingPlacement != 0) ? astNode : context.RootNode);
			}
			AstNode astNode3 = astNode2.Children.FirstOrDefault(IsUsingDeclaration);
			bool flag = false;
			AstNode insertionPoint;
			if (astNode3 == null)
			{
				insertionPoint = astNode2.GetChildrenByRole(SyntaxTree.MemberRole).SkipWhile(CanAppearBeforeUsings).FirstOrDefault();
			}
			else
			{
				insertionPoint = astNode3;
				while (IsUsingFollowing(ref insertionPoint) && usingInfo.CompareTo(new UsingInfo(insertionPoint, context)) > 0)
				{
					insertionPoint = insertionPoint.NextSibling;
				}
				if (!IsUsingDeclaration(insertionPoint))
				{
					insertionPoint = insertionPoint.PrevSibling;
					flag = true;
				}
			}
			if (insertionPoint != null)
			{
				if (flag)
				{
					script.InsertAfter(insertionPoint, newUsing);
				}
				else
				{
					script.InsertBefore(insertionPoint, newUsing);
				}
			}
		}

		private static bool IsUsingFollowing(ref AstNode insertionPoint)
		{
			AstNode astNode = insertionPoint;
			while (astNode != null && astNode.Role == Roles.NewLine)
			{
				astNode = astNode.NextSibling;
			}
			if (IsUsingDeclaration(astNode))
			{
				insertionPoint = astNode;
				return true;
			}
			return false;
		}

		private static bool IsUsingDeclaration(AstNode node)
		{
			if (!(node is UsingDeclaration))
			{
				return node is UsingAliasDeclaration;
			}
			return true;
		}

		private static bool CanAppearBeforeUsings(AstNode node)
		{
			if (node is ExternAliasDeclaration)
			{
				return true;
			}
			if (node is PreProcessorDirective)
			{
				return true;
			}
			if (node is NewLineNode)
			{
				return true;
			}
			Comment comment = node as Comment;
			if (comment != null)
			{
				return !comment.IsDocumentation;
			}
			return false;
		}

		public static IEnumerable<AstNode> SortUsingBlock(IEnumerable<AstNode> nodes, BaseRefactoringContext context)
		{
			return from _ in nodes
				select new UsingInfo(_, context) into _
				orderby _
				select _.Node;
		}
	}
}
