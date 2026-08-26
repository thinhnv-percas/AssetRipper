using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class NamingHelper
	{
		private class VariableFinderVisitor : DepthFirstAstVisitor
		{
			public ISet<string> VariableNames = new HashSet<string>();

			public override void VisitVariableInitializer(VariableInitializer variableInitializer)
			{
				ProcessName(variableInitializer.Name);
				base.VisitVariableInitializer(variableInitializer);
			}

			public override void VisitQueryLetClause(QueryLetClause queryLetClause)
			{
				ProcessName(queryLetClause.Identifier);
				base.VisitQueryLetClause(queryLetClause);
			}

			public override void VisitQueryFromClause(QueryFromClause queryFromClause)
			{
				ProcessName(queryFromClause.Identifier);
				base.VisitQueryFromClause(queryFromClause);
			}

			public override void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
			{
				ProcessName(queryContinuationClause.Identifier);
				base.VisitQueryContinuationClause(queryContinuationClause);
			}

			private void ProcessName(string name)
			{
				if (!VariableNames.Contains(name))
				{
					VariableNames.Add(name);
				}
			}
		}

		private ISet<string> usedVariableNames;

		private RefactoringContext context;

		public NamingHelper(RefactoringContext context)
		{
			this.context = context;
			if (usedVariableNames == null)
			{
				VariableFinderVisitor variableFinderVisitor = new VariableFinderVisitor();
				context.GetNode<Statement>().AcceptVisitor(variableFinderVisitor);
				usedVariableNames = variableFinderVisitor.VariableNames;
			}
		}

		public static IEnumerable<string> GenerateNameProposals(AstType type)
		{
			if (type is PrimitiveType)
			{
				switch (((PrimitiveType)type).Keyword)
				{
				case "object":
					yield return "o";
					yield return "obj";
					break;
				case "bool":
					yield return "b";
					yield return "pred";
					break;
				case "double":
				case "float":
				case "decimal":
					yield return "d";
					yield return "f";
					yield return "m";
					break;
				case "char":
					yield return "c";
					break;
				default:
					yield return "i";
					yield return "j";
					yield return "k";
					break;
				}
				yield break;
			}
			string name;
			if (type is SimpleType)
			{
				name = ((SimpleType)type).Identifier;
			}
			else
			{
				if (!(type is MemberType))
				{
					yield break;
				}
				name = ((MemberType)type).MemberName;
			}
			List<string> list = WordParser.BreakWords(name);
			if (list.Count > 0)
			{
				list[0] = char.ToLower(list[0][0]).ToString() + list[0].Substring(1);
			}
			yield return string.Join("", list);
		}

		public string GenerateVariableName(AstType type, string baseName = null)
		{
			if (baseName == null)
			{
				foreach (string item in GenerateNameProposals(type))
				{
					baseName = (baseName ?? item);
					if (NameIsUnused(item))
					{
						usedVariableNames.Add(item);
						return item;
					}
				}
			}
			else if (NameIsUnused(baseName))
			{
				return baseName;
			}
			int num = 2;
			string text;
			do
			{
				text = baseName + num++;
			}
			while (!NameIsUnused(text));
			usedVariableNames.Add(text);
			return text;
		}

		private bool NameIsUnused(string name)
		{
			if (!usedVariableNames.Contains(name))
			{
				return LookupVariable(name) == null;
			}
			return false;
		}

		public string GenerateVariableName(IType type, string baseName = null)
		{
			AstType type2 = ToAstType(type);
			return GenerateVariableName(type2, baseName);
		}

		private AstType ToAstType(IType type)
		{
			switch (type.FullName)
			{
			case "System.Object":
				return new PrimitiveType("object");
			case "System.String":
				return new PrimitiveType("string");
			case "System.Boolean":
				return new PrimitiveType("bool");
			case "System.Char":
				return new PrimitiveType("char");
			case "System.SByte":
				return new PrimitiveType("sbyte");
			case "System.Byte":
				return new PrimitiveType("byte");
			case "System.Int16":
				return new PrimitiveType("short");
			case "System.UInt16":
				return new PrimitiveType("ushort");
			case "System.Int32":
				return new PrimitiveType("int");
			case "System.UInt32":
				return new PrimitiveType("uint");
			case "System.Int64":
				return new PrimitiveType("long");
			case "System.UInt64":
				return new PrimitiveType("ulong");
			case "System.Single":
				return new PrimitiveType("float");
			case "System.Double":
				return new PrimitiveType("double");
			case "System.Decimal":
				return new PrimitiveType("decimal");
			default:
				return new SimpleType(type.Name);
			}
		}

		private IVariable LookupVariable(string name)
		{
			BlockStatement node = context.GetNode<BlockStatement>();
			return (context.GetResolverStateAfter(node.RBraceToken.PrevSibling).ResolveSimpleName(name, new List<IType>()) as LocalResolveResult)?.Variable;
		}
	}
}
