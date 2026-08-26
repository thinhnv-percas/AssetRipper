using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public class CSharpParameterCompletionEngine : CSharpCompletionEngineBase
	{
		internal IParameterCompletionDataFactory factory;

		public CSharpParameterCompletionEngine(IDocument document, ICompletionContextProvider completionContextProvider, IParameterCompletionDataFactory factory, IProjectContent content, CSharpTypeResolveContext ctx)
			: base(content, completionContextProvider, ctx)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			base.document = document;
			this.factory = factory;
		}

		public ExpressionResult GetIndexerBeforeCursor()
		{
			if (currentMember == null && currentType == null)
			{
				return null;
			}
			SyntaxTree syntaxTree = ParseStub("x]");
			AstNode nodeAt = syntaxTree.GetNodeAt(location, (AstNode n) => n is IndexerExpression);
			if (nodeAt is IndexerExpression)
			{
				AstNode target = ((IndexerExpression)nodeAt).Target;
				return new ExpressionResult(target, syntaxTree);
			}
			return null;
		}

		public ExpressionResult GetConstructorInitializerBeforeCursor()
		{
			if (currentMember == null && currentType == null)
			{
				return null;
			}
			SyntaxTree syntaxTree = ParseStub("a) {}", appendSemicolon: false);
			ConstructorInitializer nodeAt = syntaxTree.GetNodeAt<ConstructorInitializer>(location);
			if (nodeAt == null)
			{
				return null;
			}
			return new ExpressionResult(nodeAt, syntaxTree);
		}

		public ExpressionResult GetTypeBeforeCursor()
		{
			if (currentMember == null && currentType == null)
			{
				return null;
			}
			SyntaxTree syntaxTree = ParseStub("x> a");
			AstType nodeAt = syntaxTree.GetNodeAt<AstType>(location.Line, location.Column + 1);
			if (nodeAt == null)
			{
				return null;
			}
			return new ExpressionResult(nodeAt, syntaxTree);
		}

		public ExpressionResult GetMethodTypeArgumentInvocationBeforeCursor()
		{
			if (currentMember == null && currentType == null)
			{
				return null;
			}
			SyntaxTree syntaxTree = ParseStub("x>.A ()");
			MemberReferenceExpression nodeAt = syntaxTree.GetNodeAt<MemberReferenceExpression>(location.Line, location.Column + 1);
			if (nodeAt == null)
			{
				return null;
			}
			return new ExpressionResult(nodeAt, syntaxTree);
		}

		private IEnumerable<IMethod> CollectMethods(AstNode resolvedNode, MethodGroupResolveResult resolveResult)
		{
			MemberLookup memberLookup = new MemberLookup(ctx.CurrentTypeDefinition, Compilation.MainAssembly);
			bool flag = false;
			if ((resolvedNode is IdentifierExpression && currentMember != null && currentMember.IsStatic) || resolveResult.TargetResult is TypeResolveResult)
			{
				flag = true;
			}
			List<IMethod> methods = new List<IMethod>();
			foreach (IMethod method in resolveResult.Methods)
			{
				if (!method.IsConstructor && memberLookup.IsAccessible(method, allowProtectedAccess: true) && (!flag || method.IsStatic))
				{
					if (method.IsShadowing)
					{
						for (int i = 0; i < methods.Count; i++)
						{
							if (ParameterListComparer.Instance.Equals(methods[i].Parameters, method.Parameters))
							{
								methods.RemoveAt(i);
								i--;
							}
						}
					}
					methods.Add(method);
				}
			}
			foreach (IMethod item in methods)
			{
				yield return item;
			}
			foreach (IEnumerable<IMethod> eligibleExtensionMethod in resolveResult.GetEligibleExtensionMethods(substituteInferredTypes: true))
			{
				foreach (IMethod item2 in eligibleExtensionMethod)
				{
					if (!methods.Contains(item2))
					{
						yield return new ReducedExtensionMethod(item2);
					}
				}
			}
		}

		private IEnumerable<IProperty> GetAccessibleIndexers(IType type)
		{
			MemberLookup memberLookup = new MemberLookup(base.ctx.CurrentTypeDefinition, base.Compilation.MainAssembly);
			List<IProperty> list = new List<IProperty>();
			foreach (IProperty property in type.GetProperties())
			{
				if (property.IsIndexer && memberLookup.IsAccessible(property, allowProtectedAccess: true))
				{
					if (property.IsShadowing)
					{
						for (int i = 0; i < list.Count; i++)
						{
							if (ParameterListComparer.Instance.Equals(list[i].Parameters, property.Parameters))
							{
								list.RemoveAt(i);
								i--;
							}
						}
					}
					list.Add(property);
				}
			}
			return list;
		}

		public IParameterDataProvider GetParameterDataProvider(int offset, char completionChar)
		{
			if (offset <= 0 || completionChar == '\0')
			{
				return null;
			}
			SetOffset(offset);
			int startOffset;
			string text;
			if (currentMember == null && currentType == null)
			{
				startOffset = 0;
				text = document.Text;
			}
			else
			{
				Tuple<string, TextLocation> memberTextToCaret = GetMemberTextToCaret();
				text = memberTextToCaret.Item1;
				startOffset = document.GetOffset(memberTextToCaret.Item2);
			}
			Stack<int> parenStack = new Stack<int>();
			Stack<int> chevronStack = new Stack<int>();
			Stack<int> squareStack = new Stack<int>();
			Stack<int> bracketStack = new Stack<int>();
			MiniLexer lex = new MiniLexer(text);
			if (lex.Parse(delegate(char ch, int off)
			{
				if (lex.IsInString || lex.IsInChar || lex.IsInVerbatimString || lex.IsInSingleComment || lex.IsInMultiLineComment || lex.IsInPreprocessorDirective)
				{
					return false;
				}
				switch (ch)
				{
				case '(':
					parenStack.Push(startOffset + off);
					break;
				case ')':
					if (parenStack.Count == 0)
					{
						return true;
					}
					parenStack.Pop();
					break;
				case '<':
					chevronStack.Push(startOffset + off);
					break;
				case '>':
					if (chevronStack.Count == 0)
					{
						return false;
					}
					chevronStack.Pop();
					break;
				case '[':
					squareStack.Push(startOffset + off);
					break;
				case ']':
					if (squareStack.Count == 0)
					{
						return true;
					}
					squareStack.Pop();
					break;
				case '{':
					bracketStack.Push(startOffset + off);
					break;
				case '}':
					if (bracketStack.Count == 0)
					{
						return true;
					}
					bracketStack.Pop();
					break;
				}
				return false;
			}))
			{
				return null;
			}
			int num = -1;
			if (parenStack.Count > 0)
			{
				num = parenStack.Pop();
			}
			if (squareStack.Count > 0)
			{
				num = Math.Max(num, squareStack.Pop());
			}
			if (chevronStack.Count > 0)
			{
				num = Math.Max(num, chevronStack.Pop());
			}
			if (bracketStack.Count > 0 && bracketStack.Pop() > num)
			{
				return null;
			}
			if (num == -1)
			{
				return null;
			}
			SetOffset(num + 1);
			switch (document.GetCharAt(num))
			{
			case '(':
			{
				ExpressionResult indexerBeforeCursor = GetInvocationBeforeCursor(afterBracket: true) ?? GetConstructorInitializerBeforeCursor();
				if (indexerBeforeCursor == null)
				{
					return null;
				}
				if (indexerBeforeCursor.Node is ConstructorInitializer)
				{
					ConstructorInitializer constructorInitializer = (ConstructorInitializer)indexerBeforeCursor.Node;
					if (constructorInitializer.ConstructorInitializerType == ConstructorInitializerType.This)
					{
						return factory.CreateConstructorProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), base.ctx.CurrentTypeDefinition, constructorInitializer);
					}
					IType type = base.ctx.CurrentTypeDefinition.DirectBaseTypes.FirstOrDefault((IType bt) => bt.Kind != TypeKind.Interface);
					if (type == null)
					{
						return null;
					}
					return factory.CreateConstructorProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), type);
				}
				if (indexerBeforeCursor.Node is ObjectCreateExpression)
				{
					ExpressionResolveResult expressionResolveResult2 = ResolveExpression(((ObjectCreateExpression)indexerBeforeCursor.Node).Type);
					if (expressionResolveResult2.Result.Type.Kind == TypeKind.Unknown)
					{
						return null;
					}
					return factory.CreateConstructorProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), expressionResolveResult2.Result.Type);
				}
				if (indexerBeforeCursor.Node is Attribute)
				{
					ExpressionResolveResult expressionResolveResult3 = ResolveExpression(indexerBeforeCursor);
					if (expressionResolveResult3 == null || expressionResolveResult3.Result == null)
					{
						return null;
					}
					return factory.CreateConstructorProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), expressionResolveResult3.Result.Type);
				}
				ExpressionResolveResult expressionResolveResult4 = ResolveExpression(indexerBeforeCursor);
				if (expressionResolveResult4 == null || expressionResolveResult4.Result == null || expressionResolveResult4.Result.IsError)
				{
					return null;
				}
				ResolveResult result = expressionResolveResult4.Result;
				if (result is MethodGroupResolveResult)
				{
					return factory.CreateMethodDataProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), CollectMethods(indexerBeforeCursor.Node, result as MethodGroupResolveResult));
				}
				if (result is MemberResolveResult)
				{
					MemberResolveResult memberResolveResult = result as MemberResolveResult;
					if (memberResolveResult.Member is IMethod)
					{
						return factory.CreateMethodDataProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), new IMethod[1]
						{
							(IMethod)memberResolveResult.Member
						});
					}
				}
				if (result.Type.Kind == TypeKind.Delegate)
				{
					return factory.CreateDelegateDataProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), result.Type);
				}
				break;
			}
			case '<':
			{
				ExpressionResult indexerBeforeCursor = GetMethodTypeArgumentInvocationBeforeCursor();
				if (indexerBeforeCursor != null)
				{
					ExpressionResolveResult expressionResolveResult5 = ResolveExpression(indexerBeforeCursor);
					if (expressionResolveResult5 != null && expressionResolveResult5.Result is MethodGroupResolveResult && !expressionResolveResult5.Result.IsError)
					{
						return factory.CreateTypeParameterDataProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), CollectMethods(indexerBeforeCursor.Node, expressionResolveResult5.Result as MethodGroupResolveResult));
					}
				}
				indexerBeforeCursor = GetTypeBeforeCursor();
				if (indexerBeforeCursor == null || indexerBeforeCursor.Node.StartLocation.IsEmpty)
				{
					return null;
				}
				ExpressionResolveResult expressionResolveResult6 = ResolveExpression(indexerBeforeCursor);
				if (expressionResolveResult6 == null || expressionResolveResult6.Result == null || expressionResolveResult6.Result.IsError)
				{
					return null;
				}
				return factory.CreateTypeParameterDataProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), CollectAllTypes(expressionResolveResult6.Result.Type));
			}
			case '[':
			{
				ExpressionResult indexerBeforeCursor = GetIndexerBeforeCursor();
				if (indexerBeforeCursor == null)
				{
					return null;
				}
				if (indexerBeforeCursor.Node is ArrayCreateExpression)
				{
					return null;
				}
				ExpressionResolveResult expressionResolveResult = ResolveExpression(indexerBeforeCursor);
				if (expressionResolveResult == null || expressionResolveResult.Result == null || expressionResolveResult.Result.IsError)
				{
					return null;
				}
				return factory.CreateIndexerParameterDataProvider(document.GetOffset(indexerBeforeCursor.Node.StartLocation), expressionResolveResult.Result.Type, GetAccessibleIndexers(expressionResolveResult.Result.Type), indexerBeforeCursor.Node);
			}
			}
			return null;
		}

		private IEnumerable<IType> CollectAllTypes(IType baseType)
		{
			CSharpResolver state = GetState();
			for (ResolvedUsingScope i = state.CurrentUsingScope; i != null; i = i.Parent)
			{
				foreach (INamespace @using in i.Usings)
				{
					foreach (ITypeDefinition type in @using.Types)
					{
						if (type.TypeParameterCount > 0 && type.Name == baseType.Name)
						{
							yield return type;
						}
					}
				}
				foreach (ITypeDefinition type2 in i.Namespace.Types)
				{
					if (type2.TypeParameterCount > 0 && type2.Name == baseType.Name)
					{
						yield return type2;
					}
				}
			}
		}

		private List<string> GetUsedNamespaces()
		{
			ResolvedUsingScope resolvedUsingScope = base.ctx.CurrentUsingScope;
			List<string> list = new List<string>();
			while (resolvedUsingScope != null)
			{
				list.Add(resolvedUsingScope.Namespace.FullName);
				foreach (INamespace @using in resolvedUsingScope.Usings)
				{
					list.Add(@using.FullName);
				}
				resolvedUsingScope = resolvedUsingScope.Parent;
			}
			return list;
		}
	}
}
