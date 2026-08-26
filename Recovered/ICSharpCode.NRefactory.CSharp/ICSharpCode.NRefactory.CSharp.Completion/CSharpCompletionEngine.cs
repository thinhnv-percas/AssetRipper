using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public class CSharpCompletionEngine : CSharpCompletionEngineBase
	{
		[Flags]
		private enum TestEnum
		{
			EnumCaseName = 0x0,
			Flag1 = 0x1,
			Flag2 = 0x2,
			Flags = 0x3
		}

		private class IfVisitor : DepthFirstAstVisitor
		{
			private TextLocation loc;

			private ICompletionContextProvider completionContextProvider;

			public bool IsValid;

			private Stack<PreProcessorDirective> ifStack = new Stack<PreProcessorDirective>();

			public IfVisitor(TextLocation loc, ICompletionContextProvider completionContextProvider)
			{
				this.loc = loc;
				this.completionContextProvider = completionContextProvider;
				IsValid = true;
			}

			private void Check(string argument)
			{
				if (!argument.Any((char c) => !char.IsLetterOrDigit(c) && c != '_'))
				{
					IsValid &= completionContextProvider.ConditionalSymbols.Contains(argument);
				}
			}

			public override void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
			{
				if (preProcessorDirective.Type == PreProcessorDirectiveType.If)
				{
					ifStack.Push(preProcessorDirective);
				}
				else if (preProcessorDirective.Type == PreProcessorDirectiveType.Endif)
				{
					if (ifStack.Count == 0)
					{
						return;
					}
					PreProcessorDirective preProcessorDirective2 = ifStack.Pop();
					if (preProcessorDirective2.StartLocation < loc && loc < preProcessorDirective.EndLocation)
					{
						Check(preProcessorDirective2.Argument);
					}
				}
				base.VisitPreProcessorDirective(preProcessorDirective);
			}

			public void End()
			{
				while (ifStack.Count > 0)
				{
					Check(ifStack.Pop().Argument);
				}
			}
		}

		private class Category : CompletionCategory
		{
			public Category(string displayText, string icon)
				: base(displayText, icon)
			{
			}

			public override int CompareTo(CompletionCategory other)
			{
				return 0;
			}
		}

		internal ICompletionDataFactory factory;

		public bool AutoCompleteEmptyMatch;

		public bool AutoCompleteEmptyMatchOnCurlyBracket = true;

		public bool AutoSelect;

		public string DefaultCompletionString;

		public bool CloseOnSquareBrackets;

		public readonly List<IMethod> PossibleDelegates = new List<IMethod>();

		private static readonly DateTime curDate = DateTime.Now;

		private static Guid defaultGuid = Guid.NewGuid();

		private string[] validEnumBaseTypes = new string[8]
		{
			"byte",
			"sbyte",
			"short",
			"int",
			"long",
			"ushort",
			"uint",
			"ulong"
		};

		private static readonly List<string> commentTags = new List<string>(new string[20]
		{
			"c",
			"code",
			"example",
			"exception",
			"include",
			"list",
			"listheader",
			"item",
			"term",
			"description",
			"para",
			"param",
			"paramref",
			"permission",
			"remarks",
			"returns",
			"see",
			"seealso",
			"summary",
			"value"
		});

		private static string[] expressionLevelKeywords = new string[8]
		{
			"as",
			"is",
			"else",
			"out",
			"ref",
			"null",
			"delegate",
			"default"
		};

		private static string[] primitiveTypesKeywords = new string[16]
		{
			"void",
			"object",
			"bool",
			"byte",
			"sbyte",
			"char",
			"short",
			"int",
			"long",
			"ushort",
			"uint",
			"ulong",
			"float",
			"double",
			"decimal",
			"string"
		};

		private static string[] statementStartKeywords = new string[33]
		{
			"base",
			"new",
			"sizeof",
			"this",
			"true",
			"false",
			"typeof",
			"checked",
			"unchecked",
			"from",
			"break",
			"checked",
			"unchecked",
			"const",
			"continue",
			"do",
			"finally",
			"fixed",
			"for",
			"foreach",
			"goto",
			"if",
			"lock",
			"return",
			"stackalloc",
			"switch",
			"throw",
			"try",
			"unsafe",
			"using",
			"while",
			"yield",
			"catch"
		};

		private static string[] globalLevelKeywords = new string[15]
		{
			"namespace",
			"using",
			"extern",
			"public",
			"internal",
			"class",
			"interface",
			"struct",
			"enum",
			"delegate",
			"abstract",
			"sealed",
			"static",
			"unsafe",
			"partial"
		};

		private static string[] accessorModifierKeywords = new string[5]
		{
			"public",
			"internal",
			"protected",
			"private",
			"async"
		};

		private static string[] typeLevelKeywords = new string[27]
		{
			"public",
			"internal",
			"protected",
			"private",
			"async",
			"class",
			"interface",
			"struct",
			"enum",
			"delegate",
			"abstract",
			"sealed",
			"static",
			"unsafe",
			"partial",
			"const",
			"event",
			"extern",
			"fixed",
			"new",
			"operator",
			"explicit",
			"implicit",
			"override",
			"readonly",
			"virtual",
			"volatile"
		};

		private static string[] linqKeywords = new string[14]
		{
			"from",
			"where",
			"select",
			"group",
			"into",
			"orderby",
			"join",
			"let",
			"in",
			"on",
			"equals",
			"by",
			"ascending",
			"descending"
		};

		private static string[] parameterTypePredecessorKeywords = new string[3]
		{
			"out",
			"ref",
			"params"
		};

		public CSharpFormattingOptions FormattingPolicy
		{
			get;
			set;
		}

		public string EolMarker
		{
			get;
			set;
		}

		public string IndentString
		{
			get;
			set;
		}

		public bool AutomaticallyAddImports
		{
			get;
			set;
		}

		public bool IncludeKeywordsInCompletionList
		{
			get;
			set;
		}

		public EditorBrowsableBehavior EditorBrowsableBehavior
		{
			get;
			set;
		}

		public CompletionEngineCache CompletionEngineCache
		{
			get;
			set;
		}

		public static IEnumerable<string> CommentTags => commentTags;

		public CSharpCompletionEngine(IDocument document, ICompletionContextProvider completionContextProvider, ICompletionDataFactory factory, IProjectContent content, CSharpTypeResolveContext ctx)
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
			FormattingPolicy = FormattingOptionsFactory.CreateMono();
			EolMarker = Environment.NewLine;
			IncludeKeywordsInCompletionList = true;
			EditorBrowsableBehavior = EditorBrowsableBehavior.IncludeAdvanced;
			IndentString = "\t";
		}

		public bool TryGetCompletionWord(int offset, out int startPos, out int wordLength)
		{
			startPos = (wordLength = 0);
			int num;
			for (num = offset - 1; num >= 0; num--)
			{
				char charAt = document.GetCharAt(num);
				if (!char.IsLetterOrDigit(charAt) && charAt != '_')
				{
					break;
				}
			}
			if (num == -1)
			{
				return false;
			}
			for (num = (startPos = num + 1); num < document.TextLength; num++)
			{
				char charAt2 = document.GetCharAt(num);
				if (!char.IsLetterOrDigit(charAt2) && charAt2 != '_')
				{
					break;
				}
			}
			wordLength = num - startPos;
			return true;
		}

		public IEnumerable<ICompletionData> GetCompletionData(int offset, bool controlSpace)
		{
			AutoCompleteEmptyMatch = true;
			AutoSelect = true;
			DefaultCompletionString = null;
			SetOffset(offset);
			if (offset > 0)
			{
				char charAt = document.GetCharAt(offset - 1);
				bool isComplete = false;
				IEnumerable<ICompletionData> enumerable = MagicKeyCompletion(charAt, controlSpace, out isComplete) ?? Enumerable.Empty<ICompletionData>();
				if (!isComplete && controlSpace && char.IsWhiteSpace(charAt))
				{
					offset -= 2;
					while (offset >= 0 && char.IsWhiteSpace(document.GetCharAt(offset)))
					{
						offset--;
					}
					if (offset > 0)
					{
						IEnumerable<ICompletionData> enumerable2 = MagicKeyCompletion(document.GetCharAt(offset), controlSpace, out isComplete);
						if (enumerable2 != null)
						{
							HashSet<string> text = new HashSet<string>(from r in enumerable
								select r.CompletionText);
							enumerable = enumerable.Concat(from r in enumerable2
								where !text.Contains(r.CompletionText)
								select r);
						}
					}
				}
				return enumerable;
			}
			return Enumerable.Empty<ICompletionData>();
		}

		public IEnumerable<ICompletionData> GetImportCompletionData(int offset)
		{
			MemberLookup generalLookup = new MemberLookup(null, Compilation.MainAssembly);
			SetOffset(offset);
			List<INamespace> namespaces = new List<INamespace>();
			for (ResolvedUsingScope resolvedUsingScope = ctx.CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
			{
				namespaces.Add(resolvedUsingScope.Namespace);
				foreach (INamespace @using in resolvedUsingScope.Usings)
				{
					namespaces.Add(@using);
				}
			}
			foreach (ITypeDefinition type in Compilation.GetAllTypeDefinitions())
			{
				if (generalLookup.IsAccessible(type, allowProtectedAccess: false) && !namespaces.Any((INamespace n) => n.FullName == type.Namespace))
				{
					bool useFullName = false;
					foreach (INamespace item in namespaces)
					{
						if (item.GetTypeDefinition(type.Name, type.TypeParameterCount) != null)
						{
							useFullName = true;
							break;
						}
					}
					yield return factory.CreateImportCompletionData(type, useFullName, addForTypeCreation: false);
				}
			}
		}

		private IEnumerable<string> GenerateNameProposals(AstType type)
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
			List<string> names = WordParser.BreakWords(name);
			StringBuilder possibleName = new StringBuilder();
			for (int i = 0; i < names.Count; i++)
			{
				possibleName.Length = 0;
				for (int j = i; j < names.Count; j++)
				{
					if (!string.IsNullOrEmpty(names[j]))
					{
						if (j == i)
						{
							names[j] = char.ToLower(names[j][0]).ToString() + names[j].Substring(1);
						}
						possibleName.Append(names[j]);
					}
				}
				yield return possibleName.ToString();
			}
		}

		private IEnumerable<ICompletionData> HandleMemberReferenceCompletion(ExpressionResult expr)
		{
			if (expr == null)
			{
				return null;
			}
			if (expr.Node is PrimitiveExpression)
			{
				PrimitiveExpression primitiveExpression = (PrimitiveExpression)expr.Node;
				if (!(primitiveExpression.Value is string) && !(primitiveExpression.Value is char) && !primitiveExpression.LiteralValue.Contains('.'))
				{
					AutoSelect = false;
				}
			}
			ExpressionResolveResult expressionResolveResult = ResolveExpression(expr);
			if (expressionResolveResult == null)
			{
				return null;
			}
			if (expr.Node is AstType)
			{
				if (expr.Node.AncestorsAndSelf.TakeWhile((AstNode n) => n is AstType).Any((AstNode m) => m.Role == NamespaceDeclaration.NamespaceNameRole))
				{
					return null;
				}
				if (expr.Node.Parent != null && expr.Node.Parent.Parent is CatchClause)
				{
					return HandleCatchClauseType(expr);
				}
				return CreateTypeAndNamespaceCompletionData(location, expressionResolveResult.Result, expr.Node, expressionResolveResult.Resolver);
			}
			return CreateCompletionData(location, expressionResolveResult.Result, expr.Node, expressionResolveResult.Resolver);
		}

		private bool IsInPreprocessorDirective()
		{
			MiniLexer miniLexer = new MiniLexer(GetMemberTextToCaret().Item1);
			miniLexer.Parse();
			return miniLexer.IsInPreprocessorDirective;
		}

		private IEnumerable<ICompletionData> HandleObjectInitializer(SyntaxTree unit, AstNode n)
		{
			AstNode parent = n.Parent;
			while (parent != null && !(parent is ObjectCreateExpression))
			{
				parent = parent.Parent;
			}
			ArrayInitializerExpression arrayInitializerExpression = n.Parent as ArrayInitializerExpression;
			if (arrayInitializerExpression == null)
			{
				return null;
			}
			if (arrayInitializerExpression.IsSingleElement)
			{
				arrayInitializerExpression = (ArrayInitializerExpression)arrayInitializerExpression.Parent;
			}
			if (parent != null)
			{
				CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
				ExpressionResolveResult expressionResolveResult = ResolveExpression(parent);
				IType type = null;
				if (expressionResolveResult.Result is DynamicInvocationResolveResult)
				{
					IMethod method = (((DynamicInvocationResolveResult)expressionResolveResult.Result).Target as MethodGroupResolveResult).Methods.FirstOrDefault();
					if (method != null)
					{
						type = method.DeclaringType;
					}
				}
				else
				{
					type = expressionResolveResult?.Result.Type;
				}
				if (type != null && type.Kind != TypeKind.Unknown)
				{
					AstNode astNode = null;
					if (arrayInitializerExpression.Elements.Count > 1)
					{
						astNode = arrayInitializerExpression.Elements.First();
						if (astNode is ArrayInitializerExpression && ((ArrayInitializerExpression)astNode).IsSingleElement)
						{
							astNode = ((ArrayInitializerExpression)astNode).Elements.FirstOrDefault();
						}
					}
					if (astNode != null && !(astNode is NamedExpression))
					{
						AddContextCompletion(completionDataWrapper, GetState(), n);
						return completionDataWrapper.Result;
					}
					MemberLookup memberLookup = new MemberLookup(base.ctx.CurrentTypeDefinition, base.Compilation.MainAssembly);
					IType type2 = ReflectionHelper.ToTypeReference(typeof(IList)).Resolve(base.Compilation);
					IType type3 = ReflectionHelper.ToTypeReference(typeof(IList<>)).Resolve(base.Compilation);
					bool allowProtectedAccess = base.ctx.CurrentTypeDefinition != null && type.GetDefinition() != null && base.ctx.CurrentTypeDefinition.IsDerivedFrom(type.GetDefinition());
					foreach (IMember member in type.GetMembers((IUnresolvedMember m) => m.SymbolKind == SymbolKind.Field))
					{
						IField field = member as IField;
						if ((field == null || (!field.IsReadOnly && !field.IsConst)) && memberLookup.IsAccessible(member, allowProtectedAccess))
						{
							ICompletionData completionData = completionDataWrapper.AddMember(member);
							if (completionData != null)
							{
								completionData.DisplayFlags |= DisplayFlags.NamedArgument;
							}
						}
					}
					foreach (IProperty member2 in type.GetMembers((IUnresolvedMember m) => m.SymbolKind == SymbolKind.Property))
					{
						if ((member2.CanSet && memberLookup.IsAccessible(member2.Setter, allowProtectedAccess)) || (member2.CanGet && memberLookup.IsAccessible(member2.Getter, allowProtectedAccess) && member2.ReturnType.GetDefinition() != null && (member2.ReturnType.GetDefinition().IsDerivedFrom(type2.GetDefinition()) || member2.ReturnType.GetDefinition().IsDerivedFrom(type3.GetDefinition()))))
						{
							ICompletionData completionData2 = completionDataWrapper.AddMember(member2);
							if (completionData2 != null)
							{
								completionData2.DisplayFlags |= DisplayFlags.NamedArgument;
							}
						}
					}
					if (astNode != null && astNode is NamedExpression)
					{
						return completionDataWrapper.Result;
					}
					if (type.Kind != TypeKind.Array && type2 != null)
					{
						ITypeDefinition definition = type.GetDefinition();
						if (definition != null && !definition.IsDerivedFrom(type2.GetDefinition()) && !definition.IsDerivedFrom(type3.GetDefinition()))
						{
							return completionDataWrapper.Result;
						}
					}
					AddContextCompletion(completionDataWrapper, GetState(), n);
					return completionDataWrapper.Result;
				}
			}
			return null;
		}

		private IEnumerable<ICompletionData> GenerateNumberFormatitems(bool isFloatingPoint)
		{
			yield return factory.CreateFormatItemCompletionData("D", "decimal", 123);
			yield return factory.CreateFormatItemCompletionData("D5", "decimal", 123);
			yield return factory.CreateFormatItemCompletionData("C", "currency", 123);
			yield return factory.CreateFormatItemCompletionData("C0", "currency", 123);
			yield return factory.CreateFormatItemCompletionData("E", "exponential", 12300.0);
			yield return factory.CreateFormatItemCompletionData("E2", "exponential", 1.234);
			yield return factory.CreateFormatItemCompletionData("e2", "exponential", 1.234);
			yield return factory.CreateFormatItemCompletionData("F", "fixed-point", 123.45);
			yield return factory.CreateFormatItemCompletionData("F1", "fixed-point", 123.45);
			yield return factory.CreateFormatItemCompletionData("G", "general", 1.23E+56);
			yield return factory.CreateFormatItemCompletionData("g2", "general", 1.23E+56);
			yield return factory.CreateFormatItemCompletionData("N", "number", 12345.68);
			yield return factory.CreateFormatItemCompletionData("N1", "number", 12345.68);
			yield return factory.CreateFormatItemCompletionData("P", "percent", 12.34);
			yield return factory.CreateFormatItemCompletionData("P1", "percent", 12.34);
			yield return factory.CreateFormatItemCompletionData("R", "round-trip", 0.1230000001);
			yield return factory.CreateFormatItemCompletionData("X", "hexadecimal", 1234);
			yield return factory.CreateFormatItemCompletionData("x8", "hexadecimal", 1234);
			yield return factory.CreateFormatItemCompletionData("0000", "custom", 123);
			yield return factory.CreateFormatItemCompletionData("####", "custom", 123);
			yield return factory.CreateFormatItemCompletionData("##.###", "custom", 1.23);
			yield return factory.CreateFormatItemCompletionData("##.000", "custom", 1.23);
			yield return factory.CreateFormatItemCompletionData("## 'items'", "custom", 12);
		}

		private IEnumerable<ICompletionData> GenerateDateTimeFormatitems()
		{
			yield return factory.CreateFormatItemCompletionData("D", "long date", curDate);
			yield return factory.CreateFormatItemCompletionData("d", "short date", curDate);
			yield return factory.CreateFormatItemCompletionData("F", "full date long", curDate);
			yield return factory.CreateFormatItemCompletionData("f", "full date short", curDate);
			yield return factory.CreateFormatItemCompletionData("G", "general long", curDate);
			yield return factory.CreateFormatItemCompletionData("g", "general short", curDate);
			yield return factory.CreateFormatItemCompletionData("M", "month", curDate);
			yield return factory.CreateFormatItemCompletionData("O", "ISO 8601", curDate);
			yield return factory.CreateFormatItemCompletionData("R", "RFC 1123", curDate);
			yield return factory.CreateFormatItemCompletionData("s", "sortable", curDate);
			yield return factory.CreateFormatItemCompletionData("T", "long time", curDate);
			yield return factory.CreateFormatItemCompletionData("t", "short time", curDate);
			yield return factory.CreateFormatItemCompletionData("U", "universal full", curDate);
			yield return factory.CreateFormatItemCompletionData("u", "universal sortable", curDate);
			yield return factory.CreateFormatItemCompletionData("Y", "year month", curDate);
			yield return factory.CreateFormatItemCompletionData("yy-MM-dd", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("yyyy MMMMM dd", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("yy-MMM-dd ddd", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("yyyy-M-d dddd", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("hh:mm:ss t z", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("hh:mm:ss tt zz", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("HH:mm:ss tt zz", "custom", curDate);
			yield return factory.CreateFormatItemCompletionData("HH:m:s tt zz", "custom", curDate);
		}

		private IEnumerable<ICompletionData> GenerateEnumFormatitems()
		{
			yield return factory.CreateFormatItemCompletionData("G", "string value", TestEnum.EnumCaseName);
			yield return factory.CreateFormatItemCompletionData("F", "flags value", TestEnum.Flags);
			yield return factory.CreateFormatItemCompletionData("D", "integer value", TestEnum.Flags);
			yield return factory.CreateFormatItemCompletionData("X", "hexadecimal", TestEnum.Flags);
		}

		private IEnumerable<ICompletionData> GenerateTimeSpanFormatitems()
		{
			yield return factory.CreateFormatItemCompletionData("c", "invariant", new TimeSpan(0, 1, 23, 456));
			yield return factory.CreateFormatItemCompletionData("G", "general long", new TimeSpan(0, 1, 23, 456));
			yield return factory.CreateFormatItemCompletionData("g", "general short", new TimeSpan(0, 1, 23, 456));
		}

		private IEnumerable<ICompletionData> GenerateGuidFormatitems()
		{
			yield return factory.CreateFormatItemCompletionData("N", "digits", defaultGuid);
			yield return factory.CreateFormatItemCompletionData("D", "hypens", defaultGuid);
			yield return factory.CreateFormatItemCompletionData("B", "braces", defaultGuid);
			yield return factory.CreateFormatItemCompletionData("P", "parentheses", defaultGuid);
		}

		private int GetFormatItemNumber()
		{
			int num = 0;
			for (int num2 = offset - 2; num2 > 0; num2--)
			{
				char charAt = document.GetCharAt(num2);
				if (charAt == '{')
				{
					return num;
				}
				if (!char.IsDigit(charAt))
				{
					break;
				}
				num = num * 10 + charAt - 48;
			}
			return -1;
		}

		private IEnumerable<ICompletionData> HandleStringFormatItems()
		{
			int formatItemNumber = GetFormatItemNumber();
			if (formatItemNumber < 0)
			{
				return Enumerable.Empty<ICompletionData>();
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = offset;
			while (num < document.TextLength)
			{
				char charAt = document.GetCharAt(num);
				stringBuilder.Append(charAt);
				num++;
				if (charAt == ';')
				{
					break;
				}
			}
			SyntaxTree syntaxTree = ParseStub(stringBuilder.ToString(), appendSemicolon: false);
			InvocationExpression nodeAt = syntaxTree.GetNodeAt<InvocationExpression>(location);
			if (nodeAt != null && ResolveExpression(new ExpressionResult(nodeAt, syntaxTree)).Result is InvocationResolveResult)
			{
				int num2 = formatItemNumber + 1;
				if (num2 < nodeAt.Arguments.Count)
				{
					ExpressionResolveResult expressionResolveResult = ResolveExpression(new ExpressionResult(nodeAt.Arguments.ElementAt(num2), syntaxTree));
					if (expressionResolveResult != null)
					{
						IEnumerable<ICompletionData> formatCompletionData = GetFormatCompletionData(expressionResolveResult.Result.Type);
						if (formatCompletionData != null)
						{
							return formatCompletionData;
						}
						if (!expressionResolveResult.Result.Type.IsKnownType(KnownTypeCode.Object))
						{
							return Enumerable.Empty<ICompletionData>();
						}
					}
				}
			}
			return HandleStringFormatItemsFallback();
		}

		private IEnumerable<ICompletionData> HandleStringFormatItemsFallback()
		{
			SyntaxTree syntaxTree = ParseStub("a}\");", appendSemicolon: false);
			InvocationExpression nodeAt = syntaxTree.GetNodeAt<InvocationExpression>(location);
			if (nodeAt == null)
			{
				return Enumerable.Empty<ICompletionData>();
			}
			CSharpInvocationResolveResult cSharpInvocationResolveResult = ResolveExpression(new ExpressionResult(nodeAt, syntaxTree)).Result as CSharpInvocationResolveResult;
			if (cSharpInvocationResolveResult == null)
			{
				return Enumerable.Empty<ICompletionData>();
			}
			if (FormatStringHelper.TryGetFormattingParameters(cSharpInvocationResolveResult, nodeAt, out Expression _, out IList<Expression> _, null))
			{
				return GenerateNumberFormatitems(isFloatingPoint: false).Concat(GenerateDateTimeFormatitems()).Concat(GenerateTimeSpanFormatitems()).Concat(GenerateEnumFormatitems())
					.Concat(GenerateGuidFormatitems());
			}
			return Enumerable.Empty<ICompletionData>();
		}

		private IEnumerable<ICompletionData> GetFormatCompletionData(IType type)
		{
			if (type.Namespace != "System")
			{
				return null;
			}
			switch (type.Name)
			{
			case "Int64":
			case "UInt64":
			case "Int32":
			case "UInt32":
			case "Int16":
			case "UInt16":
			case "Byte":
			case "SByte":
				return GenerateNumberFormatitems(isFloatingPoint: false);
			case "Single":
			case "Double":
			case "Decimal":
				return GenerateNumberFormatitems(isFloatingPoint: true);
			case "Enum":
				return GenerateEnumFormatitems();
			case "DateTime":
				return GenerateDateTimeFormatitems();
			case "TimeSpan":
				return GenerateTimeSpanFormatitems();
			case "Guid":
				return GenerateGuidFormatitems();
			default:
				return null;
			}
		}

		private IEnumerable<ICompletionData> HandleToStringFormatItems()
		{
			SyntaxTree syntaxTree = ParseStub("\");", appendSemicolon: false);
			InvocationExpression nodeAt = syntaxTree.GetNodeAt<InvocationExpression>(location);
			if (nodeAt == null)
			{
				return Enumerable.Empty<ICompletionData>();
			}
			InvocationResolveResult invocationResolveResult = ResolveExpression(new ExpressionResult(nodeAt, syntaxTree)).Result as InvocationResolveResult;
			if (invocationResolveResult == null)
			{
				return Enumerable.Empty<ICompletionData>();
			}
			if (invocationResolveResult.Member.Name == "ToString")
			{
				return GetFormatCompletionData(invocationResolveResult.Member.DeclaringType ?? SpecialType.UnknownType) ?? Enumerable.Empty<ICompletionData>();
			}
			return Enumerable.Empty<ICompletionData>();
		}

		private IEnumerable<ICompletionData> MagicKeyCompletion(char completionChar, bool controlSpace, out bool isComplete)
		{
			isComplete = false;
			int i;
			string text;
			switch (completionChar)
			{
			case ':':
			{
				MiniLexer miniLexer = new MiniLexer(GetMemberTextToCaret().Item1);
				miniLexer.Parse();
				if (miniLexer.IsInSingleComment || miniLexer.IsInChar || miniLexer.IsInMultiLineComment || miniLexer.IsInPreprocessorDirective)
				{
					return Enumerable.Empty<ICompletionData>();
				}
				if (miniLexer.IsInString || miniLexer.IsInVerbatimString)
				{
					return HandleStringFormatItems();
				}
				return HandleMemberReferenceCompletion(GetExpressionBeforeCursor());
			}
			case '"':
			{
				MiniLexer miniLexer = new MiniLexer(GetMemberTextToCaret().Item1);
				miniLexer.Parse();
				if (miniLexer.IsInSingleComment || miniLexer.IsInChar || miniLexer.IsInMultiLineComment || miniLexer.IsInPreprocessorDirective)
				{
					return Enumerable.Empty<ICompletionData>();
				}
				if (miniLexer.IsInString || miniLexer.IsInVerbatimString)
				{
					return HandleToStringFormatItems();
				}
				return Enumerable.Empty<ICompletionData>();
			}
			case '.':
				if (IsInsideCommentStringOrDirective())
				{
					return Enumerable.Empty<ICompletionData>();
				}
				return HandleMemberReferenceCompletion(GetExpressionBeforeCursor());
			case '#':
				if (!IsInPreprocessorDirective())
				{
					return null;
				}
				return GetDirectiveCompletionData();
			case '<':
				if (IsInsideDocComment())
				{
					return GetXmlDocumentationCompletionData();
				}
				if (controlSpace)
				{
					return DefaultControlSpaceItems(ref isComplete);
				}
				return null;
			case '>':
				if (!IsInsideDocComment())
				{
					if (offset > 2 && document.GetCharAt(offset - 2) == '-' && !IsInsideCommentStringOrDirective())
					{
						return HandleMemberReferenceCompletion(GetExpressionBeforeCursor());
					}
					return null;
				}
				return null;
			case '(':
			{
				if (IsInsideCommentStringOrDirective())
				{
					return null;
				}
				ExpressionResult invocationBeforeCursor = GetInvocationBeforeCursor(afterBracket: true);
				if (invocationBeforeCursor == null)
				{
					if (controlSpace)
					{
						return DefaultControlSpaceItems(ref isComplete, invocationBeforeCursor);
					}
					return null;
				}
				if (invocationBeforeCursor.Node is TypeOfExpression)
				{
					return CreateTypeList();
				}
				ExpressionResolveResult expressionResolveResult2 = ResolveExpression(invocationBeforeCursor);
				if (expressionResolveResult2 == null)
				{
					return null;
				}
				MethodGroupResolveResult methodGroupResolveResult = expressionResolveResult2.Result as MethodGroupResolveResult;
				if (methodGroupResolveResult != null)
				{
					return CreateParameterCompletion(methodGroupResolveResult, expressionResolveResult2.Resolver, invocationBeforeCursor.Node, invocationBeforeCursor.Unit, 0, controlSpace);
				}
				if (controlSpace)
				{
					return DefaultControlSpaceItems(ref isComplete, invocationBeforeCursor);
				}
				return null;
			}
			case '=':
				if (!controlSpace)
				{
					return null;
				}
				return DefaultControlSpaceItems(ref isComplete);
			case ',':
				GetParameterCompletionCommandOffset(out int _);
				return null;
			case ' ':
			{
				i = offset;
				text = GetPreviousToken(ref i, allowLineChange: false);
				if (IsInsideCommentStringOrDirective())
				{
					return null;
				}
				ExpressionResult expressionAt = GetExpressionAt(offset);
				if (controlSpace && expressionAt != null && expressionAt.Node is VariableDeclarationStatement && text != "new")
				{
					VariableDeclarationStatement variableDeclarationStatement = expressionAt.Node as VariableDeclarationStatement;
					CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
					if (variableDeclarationStatement.Variables.Count != 1)
					{
						return DefaultControlSpaceItems(ref isComplete, expressionAt, controlSpace);
					}
					foreach (string item in GenerateNameProposals(variableDeclarationStatement.Type))
					{
						if (item.Length > 0)
						{
							completionDataWrapper.Result.Add(factory.CreateLiteralCompletionData(item.ToString()));
						}
					}
					AutoSelect = false;
					AutoCompleteEmptyMatch = false;
					isComplete = true;
					return completionDataWrapper.Result;
				}
				if (text == "=")
				{
					int i2 = i;
					string previousToken = GetPreviousToken(ref i2, allowLineChange: false);
					switch (previousToken)
					{
					case "=":
					case "+":
					case "-":
					case "!":
						text = previousToken + text;
						i = i2;
						break;
					}
				}
				switch (text)
				{
				case "(":
				case ",":
					if (GetParameterCompletionCommandOffset(out int cpos))
					{
						int num = GetCurrentParameterIndex(cpos - 1, offset) - 1;
						if (num < 0)
						{
							return null;
						}
						ExpressionResult invocationBeforeCursor = GetInvocationBeforeCursor(text == "(");
						if (invocationBeforeCursor == null)
						{
							return null;
						}
						ExpressionResolveResult expressionResolveResult2 = ResolveExpression(invocationBeforeCursor);
						if (expressionResolveResult2 == null)
						{
							return null;
						}
						MethodGroupResolveResult methodGroupResolveResult = expressionResolveResult2.Result as MethodGroupResolveResult;
						if (methodGroupResolveResult != null)
						{
							return CreateParameterCompletion(methodGroupResolveResult, expressionResolveResult2.Resolver, invocationBeforeCursor.Node, invocationBeforeCursor.Unit, num, controlSpace);
						}
						return null;
					}
					break;
				case "=":
				case "==":
				case "!=":
				{
					GetPreviousToken(ref i, allowLineChange: false);
					ExpressionResult expressionAt2 = GetExpressionAt(i);
					if (expressionAt2 == null)
					{
						return null;
					}
					ExpressionResolveResult expressionResolveResult = ResolveExpression(expressionAt2);
					if (expressionResolveResult == null)
					{
						return null;
					}
					if (expressionResolveResult.Result.Type.Kind == TypeKind.Enum)
					{
						CompletionDataWrapper completionDataWrapper4 = new CompletionDataWrapper(this);
						AddContextCompletion(completionDataWrapper4, expressionResolveResult.Resolver, expressionAt2.Node);
						AddEnumMembers(completionDataWrapper4, expressionResolveResult.Result.Type, expressionResolveResult.Resolver);
						AutoCompleteEmptyMatch = false;
						return completionDataWrapper4.Result;
					}
					return null;
				}
				case "+=":
				case "-=":
				{
					int tokenIndex = i;
					GetPreviousToken(ref i, allowLineChange: false);
					ExpressionResult expressionAt2 = GetExpressionAt(i);
					if (expressionAt2 == null)
					{
						return null;
					}
					ExpressionResolveResult expressionResolveResult = ResolveExpression(expressionAt2);
					if (expressionResolveResult == null)
					{
						return null;
					}
					MemberResolveResult memberResolveResult = expressionResolveResult.Result as MemberResolveResult;
					if (memberResolveResult != null)
					{
						IEvent @event = memberResolveResult.Member as IEvent;
						if (@event == null)
						{
							return null;
						}
						IType returnType = @event.ReturnType;
						if (returnType.Kind != TypeKind.Delegate)
						{
							return null;
						}
						CompletionDataWrapper completionDataWrapper3 = new CompletionDataWrapper(this);
						if (currentType != null)
						{
							foreach (IMethod method in base.ctx.CurrentTypeDefinition.Methods)
							{
								if (MatchDelegate(returnType, method))
								{
									completionDataWrapper3.AddMember(method);
								}
							}
						}
						if (text == "+=")
						{
							AddDelegateHandlers(completionDataWrapper3, returnType, addSemicolon: true, addDefault: true, GuessEventHandlerMethodName(tokenIndex, (currentType == null) ? null : currentType.Name));
						}
						return completionDataWrapper3.Result;
					}
					return null;
				}
				case ":":
					if (currentMember == null)
					{
						text = GetPreviousToken(ref i, allowLineChange: false);
						text = GetPreviousToken(ref i, allowLineChange: false);
						if (text == "enum")
						{
							return HandleEnumContext();
						}
						CompletionDataWrapper completionDataWrapper2 = new CompletionDataWrapper(this);
						AddTypesAndNamespaces(completionDataWrapper2, GetState(), null, delegate(IType t)
						{
							if (currentType != null && currentType.ReflectionName.Equals(t.ReflectionName))
							{
								return null;
							}
							ITypeDefinition definition = t.GetDefinition();
							return (definition != null && t.Kind != TypeKind.Interface && (definition.IsSealed || definition.IsStatic)) ? null : t;
						});
						return completionDataWrapper2.Result;
					}
					return null;
				}
				IEnumerable<ICompletionData> enumerable = HandleKeywordCompletion(i, text);
				if (enumerable != null || !controlSpace)
				{
					return enumerable;
				}
				break;
			}
			}
			if (IsInsideCommentStringOrDirective())
			{
				i = offset;
				text = GetPreviousToken(ref i, allowLineChange: false);
				if (IsInPreprocessorDirective() && ((text.Length == 1 && char.IsLetter(completionChar)) | controlSpace))
				{
					while (text != null && document.GetCharAt(i - 1) != '#')
					{
						text = GetPreviousToken(ref i, allowLineChange: false);
					}
					if (text != null)
					{
						return HandleKeywordCompletion(i, text);
					}
				}
				return null;
			}
			char c = (offset > 2) ? document.GetCharAt(offset - 2) : ';';
			char c2 = (offset < document.TextLength) ? document.GetCharAt(offset) : ' ';
			if (((!char.IsWhiteSpace(c2) && ";,.[](){}+-*/%^?:&|~!<>=".IndexOf(c2) < 0) || (!char.IsWhiteSpace(c) && ";,.[](){}+-*/%^?:&|~!<>=".IndexOf(c) < 0)) && !controlSpace)
			{
				return null;
			}
			if (IsInLinqContext(offset))
			{
				if (!controlSpace && !char.IsLetter(completionChar) && completionChar != '_')
				{
					return null;
				}
				i = offset;
				text = GetPreviousToken(ref i, allowLineChange: false);
				if (!char.IsWhiteSpace(completionChar) && !linqKeywords.Contains(text))
				{
					text = GetPreviousToken(ref i, allowLineChange: false);
				}
				if (linqKeywords.Contains(text))
				{
					if (text == "from")
					{
						return null;
					}
					return DefaultControlSpaceItems(ref isComplete);
				}
				CompletionDataWrapper completionDataWrapper5 = new CompletionDataWrapper(this);
				AddKeywords(completionDataWrapper5, linqKeywords);
				return completionDataWrapper5.Result;
			}
			if (currentType != null && currentType.Kind == TypeKind.Enum)
			{
				if (!char.IsLetter(completionChar))
				{
					return null;
				}
				return HandleEnumContext();
			}
			CompletionDataWrapper completionDataWrapper6 = new CompletionDataWrapper(this);
			ExpressionResult expressionAtCursor = GetExpressionAtCursor();
			if (!char.IsLetter(completionChar) && completionChar != '_' && (!controlSpace || expressionAtCursor == null))
			{
				if (!controlSpace)
				{
					return null;
				}
				return HandleAccessorContext() ?? DefaultControlSpaceItems(ref isComplete, expressionAtCursor);
			}
			if (expressionAtCursor != null)
			{
				if (expressionAtCursor.Node is TypeParameterDeclaration)
				{
					return null;
				}
				if (expressionAtCursor.Node is MemberReferenceExpression)
				{
					return HandleMemberReferenceCompletion(new ExpressionResult(((MemberReferenceExpression)expressionAtCursor.Node).Target, expressionAtCursor.Unit));
				}
				if (expressionAtCursor.Node is Identifier)
				{
					if (expressionAtCursor.Node.Parent is GotoStatement)
					{
						return null;
					}
					if (!controlSpace)
					{
						return null;
					}
					return DefaultControlSpaceItems(ref isComplete, expressionAtCursor);
				}
				if (expressionAtCursor.Node is VariableInitializer && location <= ((VariableInitializer)expressionAtCursor.Node).NameToken.EndLocation)
				{
					if (!controlSpace)
					{
						return null;
					}
					return HandleAccessorContext() ?? DefaultControlSpaceItems(ref isComplete, expressionAtCursor);
				}
				if (expressionAtCursor.Node is CatchClause && ((CatchClause)expressionAtCursor.Node).VariableNameToken.IsInside(location))
				{
					return null;
				}
				if (expressionAtCursor.Node is AstType && expressionAtCursor.Node.Parent is CatchClause)
				{
					return HandleCatchClauseType(expressionAtCursor);
				}
				ParameterDeclaration parameterDeclaration = expressionAtCursor.Node as ParameterDeclaration;
				if (parameterDeclaration != null && parameterDeclaration.Parent is LambdaExpression)
				{
					return null;
				}
			}
			i = offset - 1;
			text = GetPreviousToken(ref i, allowLineChange: false);
			switch (text)
			{
			case "class":
			case "interface":
			case "struct":
			case "enum":
			case "namespace":
				return null;
			default:
			{
				IEnumerable<ICompletionData> enumerable2 = HandleKeywordCompletion(i, text);
				if (enumerable2 != null)
				{
					return enumerable2;
				}
				if (((!char.IsWhiteSpace(c2) && ";,.[](){}+-*/%^?:&|~!<>=".IndexOf(c2) < 0) || (!char.IsWhiteSpace(c) && ";,.[](){}+-*/%^?:&|~!<>=".IndexOf(c) < 0)) && controlSpace)
				{
					return DefaultControlSpaceItems(ref isComplete, expressionAtCursor);
				}
				int i3 = i;
				string previousToken2 = GetPreviousToken(ref i3, allowLineChange: false);
				if (previousToken2 == "delegate")
				{
					return null;
				}
				if (expressionAtCursor == null && !string.IsNullOrEmpty(text) && !IsInsideCommentStringOrDirective() && (previousToken2 == ";" || previousToken2 == "{" || previousToken2 == "}"))
				{
					char c3 = text[text.Length - 1];
					if (char.IsLetterOrDigit(c3) || c3 == '_' || text == ">")
					{
						return HandleKeywordCompletion(i, text);
					}
				}
				if (expressionAtCursor == null)
				{
					IEnumerable<ICompletionData> enumerable3 = HandleAccessorContext();
					if (enumerable3 != null)
					{
						return enumerable3;
					}
					return DefaultControlSpaceItems(ref isComplete, null, controlSpace);
				}
				AstNode astNode = expressionAtCursor.Node;
				if (astNode.Parent is NamedArgumentExpression)
				{
					astNode = astNode.Parent;
				}
				if (astNode != null && astNode.Parent is AnonymousTypeCreateExpression)
				{
					AutoSelect = false;
				}
				if (astNode is IdentifierExpression && astNode.Parent is AnonymousTypeCreateExpression)
				{
					return null;
				}
				if (astNode is IdentifierExpression)
				{
					ForeachStatement foreachStatement = astNode.GetPrevNode() as ForeachStatement;
					while (foreachStatement != null && foreachStatement.EmbeddedStatement is ForeachStatement)
					{
						foreachStatement = (ForeachStatement)foreachStatement.EmbeddedStatement;
					}
					if (foreachStatement != null && foreachStatement.InExpression.IsNull)
					{
						if (IncludeKeywordsInCompletionList)
						{
							completionDataWrapper6.AddCustom("in");
						}
						return completionDataWrapper6.Result;
					}
				}
				if (astNode is IdentifierExpression && astNode.Parent is ArrayInitializerExpression && !(astNode.Parent.Parent is ArrayCreateExpression))
				{
					IEnumerable<ICompletionData> enumerable4 = HandleObjectInitializer(expressionAtCursor.Unit, astNode);
					if (enumerable4 != null)
					{
						return enumerable4;
					}
				}
				if ((astNode != null && astNode.Parent is InvocationExpression) || (astNode.Parent is ParenthesizedExpression && astNode.Parent.Parent is InvocationExpression))
				{
					if (astNode.Parent is ParenthesizedExpression)
					{
						astNode = astNode.Parent;
					}
					InvocationExpression invocationExpression = (InvocationExpression)astNode.Parent;
					ExpressionResolveResult expressionResolveResult3 = ResolveExpression(invocationExpression.Target);
					MethodGroupResolveResult methodGroupResolveResult2 = (expressionResolveResult3 != null) ? (expressionResolveResult3.Result as MethodGroupResolveResult) : null;
					if (methodGroupResolveResult2 != null)
					{
						int num2 = 0;
						using (IEnumerator<Expression> enumerator3 = invocationExpression.Arguments.GetEnumerator())
						{
							while (enumerator3.MoveNext() && enumerator3.Current != astNode)
							{
								num2++;
							}
						}
						foreach (IMethod method2 in methodGroupResolveResult2.Methods)
						{
							if (num2 < method2.Parameters.Count && method2.Parameters[num2].Type.Kind == TypeKind.Delegate)
							{
								AutoSelect = false;
								AutoCompleteEmptyMatch = false;
							}
							foreach (IParameter parameter in method2.Parameters)
							{
								completionDataWrapper6.AddNamedParameterVariable(parameter);
							}
						}
						num2++;
						foreach (IEnumerable<IMethod> eligibleExtensionMethod in methodGroupResolveResult2.GetEligibleExtensionMethods(substituteInferredTypes: true))
						{
							foreach (IMethod item2 in eligibleExtensionMethod)
							{
								if (num2 < item2.Parameters.Count && item2.Parameters[num2].Type.Kind == TypeKind.Delegate)
								{
									AutoSelect = false;
									AutoCompleteEmptyMatch = false;
								}
							}
						}
					}
				}
				if (astNode != null && astNode.Parent is ObjectCreateExpression)
				{
					ResolveResult resolveResult = ResolveExpression(astNode.Parent)?.Result;
					if (resolveResult != null)
					{
						foreach (IMethod constructor in resolveResult.Type.GetConstructors())
						{
							foreach (IParameter parameter2 in constructor.Parameters)
							{
								completionDataWrapper6.AddVariable(parameter2);
							}
						}
					}
				}
				if (astNode is IdentifierExpression)
				{
					BinaryOperatorExpression binaryOperatorExpression = astNode.Parent as BinaryOperatorExpression;
					Expression expression = null;
					if (binaryOperatorExpression != null && binaryOperatorExpression.Right == astNode && (binaryOperatorExpression.Operator == BinaryOperatorType.Equality || binaryOperatorExpression.Operator == BinaryOperatorType.InEquality))
					{
						expression = binaryOperatorExpression.Left;
					}
					if (expression != null)
					{
						ExpressionResolveResult expressionResolveResult = ResolveExpression(expression);
						if (expressionResolveResult != null && expressionResolveResult.Result.Type.Kind == TypeKind.Enum)
						{
							CompletionDataWrapper completionDataWrapper7 = new CompletionDataWrapper(this);
							AddContextCompletion(completionDataWrapper7, expressionResolveResult.Resolver, expression);
							AddEnumMembers(completionDataWrapper7, expressionResolveResult.Result.Type, expressionResolveResult.Resolver);
							AutoCompleteEmptyMatch = false;
							return completionDataWrapper7.Result;
						}
					}
				}
				if (astNode is Identifier && astNode.Parent is ForeachStatement)
				{
					if (controlSpace)
					{
						return DefaultControlSpaceItems(ref isComplete);
					}
					return null;
				}
				if (astNode is ArrayInitializerExpression)
				{
					ArrayCreateExpression arrayCreateExpression = astNode.Parent as ArrayCreateExpression;
					if (arrayCreateExpression != null && arrayCreateExpression.Type.IsNull)
					{
						return DefaultControlSpaceItems(ref isComplete);
					}
					ExpressionResolveResult expressionResolveResult4 = ResolveExpression(astNode.Parent);
					IdentifierExpression nodeAt = expressionAtCursor.Unit.GetNodeAt<IdentifierExpression>(location);
					if (nodeAt != null && nodeAt.Parent != null && nodeAt.Parent.Parent != null && nodeAt.Identifier != "a" && nodeAt.Parent.Parent is NamedExpression)
					{
						return DefaultControlSpaceItems(ref isComplete);
					}
					if (expressionResolveResult4 != null && expressionResolveResult4.Result.Type.Kind != TypeKind.Unknown)
					{
						foreach (IProperty property in expressionResolveResult4.Result.Type.GetProperties())
						{
							if (property.IsPublic)
							{
								ICompletionData completionData = completionDataWrapper6.AddMember(property);
								if (completionData != null)
								{
									completionData.DisplayFlags |= DisplayFlags.NamedArgument;
								}
							}
						}
						foreach (IField field in expressionResolveResult4.Result.Type.GetFields())
						{
							if (field.IsPublic)
							{
								ICompletionData completionData2 = completionDataWrapper6.AddMember(field);
								if (completionData2 != null)
								{
									completionData2.DisplayFlags |= DisplayFlags.NamedArgument;
								}
							}
						}
						return completionDataWrapper6.Result;
					}
					return DefaultControlSpaceItems(ref isComplete);
				}
				if (IsAttributeContext(astNode))
				{
					if (currentType == null)
					{
						completionDataWrapper6.AddCustom("assembly");
						completionDataWrapper6.AddCustom("module");
						completionDataWrapper6.AddCustom("type");
					}
					else
					{
						completionDataWrapper6.AddCustom("param");
						completionDataWrapper6.AddCustom("field");
						completionDataWrapper6.AddCustom("property");
						completionDataWrapper6.AddCustom("method");
						completionDataWrapper6.AddCustom("event");
					}
					completionDataWrapper6.AddCustom("return");
				}
				if (astNode is MemberType)
				{
					ExpressionResolveResult expressionResolveResult = ResolveExpression(((MemberType)astNode).Target);
					return CreateTypeAndNamespaceCompletionData(location, expressionResolveResult.Result, ((MemberType)astNode).Target, expressionResolveResult.Resolver);
				}
				CSharpResolver resolver;
				if (astNode != null)
				{
					resolver = new CSharpResolver(base.ctx);
					List<AstNode> list = new List<AstNode>();
					list.Add(astNode);
					if (astNode.Parent is Attribute)
					{
						list.Add(astNode.Parent);
					}
					CSharpAstResolver resolver2 = base.CompletionContextProvider.GetResolver(resolver, expressionAtCursor.Unit);
					resolver2.ApplyNavigator(new NodeListResolveVisitorNavigator(list));
					try
					{
						resolver = resolver2.GetResolverStateBefore(astNode);
					}
					catch (Exception)
					{
						resolver = GetState();
					}
					if (astNode.Parent is Attribute)
					{
						ExpressionResolveResult expressionResolveResult5 = ResolveExpression(astNode.Parent);
						if (expressionResolveResult5 != null)
						{
							AddAttributeProperties(completionDataWrapper6, expressionResolveResult5.Result);
						}
					}
				}
				else
				{
					resolver = GetState();
				}
				offset--;
				AddContextCompletion(completionDataWrapper6, resolver, expressionAtCursor.Node);
				return completionDataWrapper6.Result;
			}
			}
		}

		private IEnumerable<ICompletionData> HandleCatchClauseType(ExpressionResult identifierStart)
		{
			Func<IType, IType> typePred = (IType type) => type.GetAllBaseTypes().Any((IType t) => t.ReflectionName == "System.Exception") ? type : null;
			if (identifierStart.Node.Parent is CatchClause)
			{
				CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
				AddTypesAndNamespaces(completionDataWrapper, GetState(), identifierStart.Node, typePred, (IMember m) => false);
				return completionDataWrapper.Result;
			}
			ExpressionResolveResult expressionResolveResult = ResolveExpression(identifierStart);
			return CreateCompletionData(location, expressionResolveResult.Result, identifierStart.Node, expressionResolveResult.Resolver, typePred);
		}

		private IEnumerable<ICompletionData> HandleEnumContext()
		{
			SyntaxTree syntaxTree = ParseStub("a", appendSemicolon: false);
			if (syntaxTree == null)
			{
				return null;
			}
			TypeDeclaration nodeAt = syntaxTree.GetNodeAt<TypeDeclaration>(location);
			if (nodeAt == null || nodeAt.ClassType != ClassType.Enum)
			{
				syntaxTree = ParseStub("a {}", appendSemicolon: false);
				if (syntaxTree.GetNodeAt<AstType>(location) != null)
				{
					CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
					AddKeywords(completionDataWrapper, validEnumBaseTypes);
					return completionDataWrapper.Result;
				}
			}
			EnumMemberDeclaration nodeAt2 = syntaxTree.GetNodeAt<EnumMemberDeclaration>(location);
			if (nodeAt2 != null && nodeAt2.NameToken.EndLocation < location)
			{
				if (currentMember == null && currentType != null)
				{
					foreach (IUnresolvedMember member in currentType.Members)
					{
						if (member.Region.Begin < location && (currentMember == null || member.Region.Begin > currentMember.Region.Begin))
						{
							currentMember = member;
						}
					}
				}
				bool isComplete = false;
				return DefaultControlSpaceItems(ref isComplete);
			}
			Attribute nodeAt3 = syntaxTree.GetNodeAt<Attribute>(location);
			if (nodeAt3 != null)
			{
				CompletionDataWrapper completionDataWrapper2 = new CompletionDataWrapper(this);
				CSharpResolver resolverStateBefore = base.CompletionContextProvider.GetResolver(GetState(), syntaxTree).GetResolverStateBefore(nodeAt3);
				AddContextCompletion(completionDataWrapper2, resolverStateBefore, nodeAt3);
				return completionDataWrapper2.Result;
			}
			return null;
		}

		private bool IsInLinqContext(int offset)
		{
			string previousToken;
			while ((previousToken = GetPreviousToken(ref offset, allowLineChange: true)) != null && !IsInsideCommentStringOrDirective())
			{
				if (previousToken == "from")
				{
					return !IsInsideCommentStringOrDirective(offset);
				}
				if (previousToken == ";" || previousToken == "{")
				{
					return false;
				}
			}
			return false;
		}

		private IEnumerable<ICompletionData> HandleAccessorContext()
		{
			AstNode astNode = ParseStub("get; }", appendSemicolon: false).GetNodeAt(location, (AstNode cn) => !(cn is CSharpTokenNode));
			if (astNode is Accessor)
			{
				astNode = astNode.Parent;
			}
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			if (astNode is PropertyDeclaration || astNode is IndexerDeclaration)
			{
				if (IncludeKeywordsInCompletionList)
				{
					completionDataWrapper.AddCustom("get");
					completionDataWrapper.AddCustom("set");
					AddKeywords(completionDataWrapper, accessorModifierKeywords);
				}
			}
			else
			{
				if (!(astNode is CustomEventDeclaration))
				{
					return null;
				}
				if (IncludeKeywordsInCompletionList)
				{
					completionDataWrapper.AddCustom("add");
					completionDataWrapper.AddCustom("remove");
				}
			}
			return completionDataWrapper.Result;
		}

		private IEnumerable<ICompletionData> DefaultControlSpaceItems(ref bool isComplete, ExpressionResult xp = null, bool controlSpace = true)
		{
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			if (offset >= document.TextLength)
			{
				offset = document.TextLength - 1;
			}
			while (offset > 1 && char.IsWhiteSpace(document.GetCharAt(offset)))
			{
				offset--;
			}
			location = document.GetLocation(offset);
			if (xp == null)
			{
				xp = GetExpressionAtCursor();
			}
			AstNode astNode;
			ExpressionResolveResult expressionResolveResult;
			SyntaxTree syntaxTree;
			if (xp != null)
			{
				astNode = xp.Node;
				expressionResolveResult = ResolveExpression(astNode);
				syntaxTree = xp.Unit;
			}
			else
			{
				syntaxTree = ParseStub("foo", appendSemicolon: false);
				astNode = syntaxTree.GetNodeAt(location.Line, location.Column + 2, (AstNode n) => (!(n is Expression) && !(n is AstType) && !(n is NamespaceDeclaration)) ? (n is Attribute) : true);
				expressionResolveResult = ResolveExpression(astNode);
			}
			IfVisitor ifVisitor = new IfVisitor(location, base.CompletionContextProvider);
			syntaxTree.AcceptVisitor(ifVisitor);
			ifVisitor.End();
			if (!ifVisitor.IsValid)
			{
				return null;
			}
			NamespaceDeclaration namespaceDeclaration = astNode as NamespaceDeclaration;
			if (namespaceDeclaration != null)
			{
				AstType namespaceName = namespaceDeclaration.NamespaceName;
				if (namespaceName != null && location < namespaceName.EndLocation)
				{
					return null;
				}
			}
			if (astNode is Identifier && astNode.Parent is ForeachStatement)
			{
				ForeachStatement foreachStatement = (ForeachStatement)astNode.Parent;
				foreach (string item in GenerateNameProposals(foreachStatement.VariableType))
				{
					if (item.Length > 0)
					{
						completionDataWrapper.Result.Add(factory.CreateLiteralCompletionData(item.ToString()));
					}
				}
				AutoSelect = false;
				AutoCompleteEmptyMatch = false;
				isComplete = true;
				return completionDataWrapper.Result;
			}
			if (astNode is Identifier && astNode.Parent is ParameterDeclaration)
			{
				if (!controlSpace)
				{
					return null;
				}
				ParameterDeclaration parameterDeclaration = astNode.Parent as ParameterDeclaration;
				if (parameterDeclaration != null)
				{
					foreach (string item2 in GenerateNameProposals(parameterDeclaration.Type))
					{
						if (item2.Length > 0)
						{
							completionDataWrapper.Result.Add(factory.CreateLiteralCompletionData(item2.ToString()));
						}
					}
					AutoSelect = false;
					AutoCompleteEmptyMatch = false;
					isComplete = true;
					return completionDataWrapper.Result;
				}
			}
			ParameterDeclaration parameterDeclaration2 = astNode as ParameterDeclaration;
			if (parameterDeclaration2 != null && parameterDeclaration2.Parent is LambdaExpression)
			{
				return null;
			}
			ArrayInitializerExpression arrayInitializerExpression = (astNode != null) ? (astNode.Parent as ArrayInitializerExpression) : null;
			if (arrayInitializerExpression != null)
			{
				IEnumerable<ICompletionData> enumerable = HandleObjectInitializer(syntaxTree, arrayInitializerExpression);
				if (enumerable != null)
				{
					return enumerable;
				}
			}
			CSharpResolver cSharpResolver = null;
			if (expressionResolveResult != null)
			{
				cSharpResolver = expressionResolveResult.Resolver;
			}
			if (cSharpResolver == null)
			{
				if (astNode != null)
				{
					cSharpResolver = GetState();
					try
					{
						Console.WriteLine(cSharpResolver.LocalVariables.Count());
					}
					catch (Exception arg)
					{
						Console.WriteLine("E!!!" + arg);
					}
				}
				else
				{
					cSharpResolver = GetState();
				}
			}
			if (astNode is Attribute)
			{
				ResolveResult resolved = base.CompletionContextProvider.GetResolver(cSharpResolver, syntaxTree).Resolve(astNode);
				AddAttributeProperties(completionDataWrapper, resolved);
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("foo) => {}");
				ParameterDeclaration nodeAt = syntaxTree.GetNodeAt<ParameterDeclaration>(location.Line, location.Column);
				if (nodeAt != null)
				{
					ResolveResult resolveResult = ((syntaxTree != null) ? base.CompletionContextProvider.GetResolver(GetState(), syntaxTree) : null).Resolve(nodeAt.Type);
					if (resolveResult != null && !resolveResult.IsError)
					{
						return null;
					}
				}
			}
			AddContextCompletion(completionDataWrapper, cSharpResolver, astNode);
			return completionDataWrapper.Result;
		}

		private static void AddAttributeProperties(CompletionDataWrapper wrapper, ResolveResult resolved)
		{
			if (resolved != null && resolved.Type.Kind != TypeKind.Unknown)
			{
				foreach (IProperty property in resolved.Type.GetProperties((IUnresolvedProperty p) => p.Accessibility == Accessibility.Public))
				{
					ICompletionData completionData = wrapper.AddMember(property);
					if (completionData != null)
					{
						completionData.DisplayFlags |= DisplayFlags.NamedArgument;
					}
				}
				foreach (IField field in resolved.Type.GetFields((IUnresolvedField p) => p.Accessibility == Accessibility.Public))
				{
					ICompletionData completionData2 = wrapper.AddMember(field);
					if (completionData2 != null)
					{
						completionData2.DisplayFlags |= DisplayFlags.NamedArgument;
					}
				}
				foreach (IMethod constructor in resolved.Type.GetConstructors((IUnresolvedMethod p) => p.Accessibility == Accessibility.Public))
				{
					foreach (IParameter parameter in constructor.Parameters)
					{
						wrapper.AddNamedParameterVariable(parameter);
					}
				}
			}
		}

		private void AddContextCompletion(CompletionDataWrapper wrapper, CSharpResolver state, AstNode node)
		{
			int i = offset - 1;
			bool flag = node == null && state.CurrentTypeDefinition == null && GetPreviousToken(ref i, allowLineChange: true) == "delegate";
			if (state != null && !(node is AstType))
			{
				foreach (IVariable localVariable in state.LocalVariables)
				{
					if (!localVariable.Region.IsInside(location.Line, location.Column - 1))
					{
						wrapper.AddVariable(localVariable);
					}
				}
			}
			if (state.CurrentMember is IParameterizedMember && !(node is AstType))
			{
				foreach (IParameter parameter2 in ((IParameterizedMember)state.CurrentMember).Parameters)
				{
					wrapper.AddVariable(parameter2);
				}
			}
			if (state.CurrentMember is IMethod)
			{
				foreach (ITypeParameter typeParameter in ((IMethod)state.CurrentMember).TypeParameters)
				{
					wrapper.AddTypeParameter(typeParameter);
				}
			}
			Func<IType, IType> typePred = null;
			if (IsAttributeContext(node))
			{
				IType attribute = base.Compilation.FindType(KnownTypeCode.Attribute);
				typePred = ((IType t) => (!t.GetAllBaseTypeDefinitions().Any((ITypeDefinition bt) => bt.Equals(attribute))) ? null : t);
			}
			if (node != null && node.Role == Roles.BaseType)
			{
				typePred = delegate(IType t)
				{
					ITypeDefinition definition = t.GetDefinition();
					return (definition != null && t.Kind != TypeKind.Interface && (definition.IsSealed || definition.IsStatic)) ? null : t;
				};
			}
			if (((node != null && !(node is NamespaceDeclaration)) || state.CurrentTypeDefinition != null) | flag)
			{
				AddTypesAndNamespaces(wrapper, state, node, typePred);
				wrapper.Result.Add(factory.CreateLiteralCompletionData("global"));
			}
			if (!(node is AstType))
			{
				if (currentMember != null || node is Expression)
				{
					AddKeywords(wrapper, statementStartKeywords);
					if (base.LanguageVersion.Major >= 5)
					{
						AddKeywords(wrapper, new string[1]
						{
							"await"
						});
					}
					AddKeywords(wrapper, expressionLevelKeywords);
					if (node == null || node is TypeDeclaration)
					{
						AddKeywords(wrapper, typeLevelKeywords);
					}
				}
				else if (currentType != null)
				{
					AddKeywords(wrapper, typeLevelKeywords);
				}
				else if (!flag && !(node is Attribute))
				{
					AddKeywords(wrapper, globalLevelKeywords);
				}
				IUnresolvedProperty unresolvedProperty = currentMember as IUnresolvedProperty;
				if (unresolvedProperty != null && unresolvedProperty.Setter != null && unresolvedProperty.Setter.Region.IsInside(location))
				{
					wrapper.AddCustom("value");
				}
				if (currentMember is IUnresolvedEvent)
				{
					wrapper.AddCustom("value");
				}
				if (IsInSwitchContext(node) && IncludeKeywordsInCompletionList)
				{
					wrapper.AddCustom("case");
				}
			}
			else if (((AstType)node).Parent is ParameterDeclaration)
			{
				AddKeywords(wrapper, parameterTypePredecessorKeywords);
			}
			if ((node != null || state.CurrentTypeDefinition != null) | flag)
			{
				AddKeywords(wrapper, primitiveTypesKeywords);
			}
			if (currentMember != null && (node is IdentifierExpression || node is SimpleType) && (node.Parent is ExpressionStatement || node.Parent is ForeachStatement || node.Parent is UsingStatement) && IncludeKeywordsInCompletionList)
			{
				wrapper.AddCustom("var");
				wrapper.AddCustom("dynamic");
			}
			wrapper.Result.AddRange(factory.CreateCodeTemplateCompletionData());
			if (node != null && node.Role == Roles.Argument)
			{
				ExpressionResolveResult expressionResolveResult = ResolveExpression(node.Parent);
				CSharpInvocationResolveResult cSharpInvocationResolveResult = (expressionResolveResult != null) ? (expressionResolveResult.Result as CSharpInvocationResolveResult) : null;
				if (cSharpInvocationResolveResult != null)
				{
					int num = 0;
					using (IEnumerator<AstNode> enumerator4 = (from c in node.Parent.Children
						where c.Role == Roles.Argument
						select c).GetEnumerator())
					{
						while (enumerator4.MoveNext() && enumerator4.Current != node)
						{
							num++;
						}
					}
					IParameter parameter = (num < cSharpInvocationResolveResult.Member.Parameters.Count) ? cSharpInvocationResolveResult.Member.Parameters[num] : null;
					if (parameter != null && parameter.Type.Kind == TypeKind.Enum)
					{
						AddEnumMembers(wrapper, parameter.Type, state);
					}
				}
			}
			if (node is Expression)
			{
				AstNode astNode = node;
				while (astNode.Parent != null)
				{
					astNode = astNode.Parent;
				}
				foreach (IType validType in TypeGuessing.GetValidTypes(base.CompletionContextProvider.GetResolver(state, astNode), (Expression)node))
				{
					if (validType.Kind == TypeKind.Enum)
					{
						AddEnumMembers(wrapper, validType, state);
					}
					else if (validType.Kind == TypeKind.Delegate)
					{
						AddDelegateHandlers(wrapper, validType, addSemicolon: false);
						AutoSelect = false;
						AutoCompleteEmptyMatch = false;
					}
				}
			}
			if (node != null && node.Parent is ParameterDeclaration && node.Parent.PrevSibling != null && node.Parent.PrevSibling.Role == Roles.LPar && IncludeKeywordsInCompletionList)
			{
				wrapper.AddCustom("this");
			}
		}

		private static bool IsInSwitchContext(AstNode node)
		{
			AstNode astNode = node;
			while (astNode != null && !(astNode is EntityDeclaration))
			{
				if (astNode is SwitchStatement)
				{
					return true;
				}
				if (astNode is BlockStatement)
				{
					return false;
				}
				astNode = astNode.Parent;
			}
			return false;
		}

		private static bool ListEquals(List<INamespace> curNamespaces, List<INamespace> oldNamespaces)
		{
			if (oldNamespaces == null || curNamespaces.Count != oldNamespaces.Count)
			{
				return false;
			}
			for (int i = 0; i < curNamespaces.Count; i++)
			{
				if (curNamespaces[i].FullName != oldNamespaces[i].FullName)
				{
					return false;
				}
			}
			return true;
		}

		private void AddTypesAndNamespaces(CompletionDataWrapper wrapper, CSharpResolver state, AstNode node, Func<IType, IType> typePred = null, Predicate<IMember> memberPred = null, Action<ICompletionData, IType> callback = null, bool onlyAddConstructors = false)
		{
			MemberLookup lookup = new MemberLookup(base.ctx.CurrentTypeDefinition, base.Compilation.MainAssembly);
			if (currentType != null)
			{
				for (ITypeDefinition typeDefinition = base.ctx.CurrentTypeDefinition; typeDefinition != null; typeDefinition = typeDefinition.DeclaringTypeDefinition)
				{
					foreach (IType nestedType in typeDefinition.GetNestedTypes())
					{
						if (lookup.IsAccessible(nestedType.GetDefinition(), allowProtectedAccess: true) && (!onlyAddConstructors || nestedType.GetConstructors().Any((IMethod c) => lookup.IsAccessible(c, allowProtectedAccess: true))))
						{
							if (typePred == null)
							{
								if (onlyAddConstructors)
								{
									wrapper.AddConstructors(nestedType, showFullName: false, IsAttributeContext(node));
								}
								else
								{
									wrapper.AddType(nestedType, showFullName: false, IsAttributeContext(node));
								}
							}
							else
							{
								IType type2 = typePred(nestedType);
								if (type2 != null)
								{
									ICompletionData completionData = onlyAddConstructors ? wrapper.AddConstructors(type2, showFullName: false, IsAttributeContext(node)) : wrapper.AddType(type2, showFullName: false, IsAttributeContext(node));
									if (completionData != null)
									{
										callback?.Invoke(completionData, type2);
									}
								}
							}
						}
					}
				}
				if (currentMember != null && !(node is AstType))
				{
					ITypeDefinition typeDefinition2 = base.ctx.CurrentTypeDefinition;
					if (typeDefinition2 == null && currentType != null)
					{
						typeDefinition2 = base.Compilation.MainAssembly.GetTypeDefinition(currentType.FullTypeName);
					}
					if (typeDefinition2 != null)
					{
						bool allowProtectedAccess = true;
						foreach (IMember member in typeDefinition2.GetMembers((IUnresolvedMember m) => !currentMember.IsStatic || m.IsStatic))
						{
							if ((!(member is IMethod) || !(((IMethod)member).FullName == "System.Object.Finalize")) && member.SymbolKind != SymbolKind.Operator && !member.IsExplicitInterfaceImplementation && lookup.IsAccessible(member, allowProtectedAccess) && (memberPred == null || memberPred(member)))
							{
								wrapper.AddMember(member);
							}
						}
						for (ITypeDefinition declaringTypeDefinition = typeDefinition2.DeclaringTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
						{
							foreach (IMember member2 in declaringTypeDefinition.GetMembers((IUnresolvedMember m) => m.IsStatic))
							{
								if (memberPred == null || memberPred(member2))
								{
									wrapper.AddMember(member2);
								}
							}
						}
					}
				}
				if (base.ctx.CurrentTypeDefinition != null)
				{
					foreach (ITypeParameter typeParameter in base.ctx.CurrentTypeDefinition.TypeParameters)
					{
						wrapper.AddTypeParameter(typeParameter);
					}
				}
			}
			ResolvedUsingScope currentUsingScope = base.ctx.CurrentUsingScope;
			for (ResolvedUsingScope resolvedUsingScope = currentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
			{
				foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
				{
					wrapper.AddAlias(usingAlias.Key);
				}
				foreach (string externAlias in resolvedUsingScope.ExternAliases)
				{
					wrapper.AddAlias(externAlias);
				}
				foreach (INamespace @using in resolvedUsingScope.Usings)
				{
					foreach (ITypeDefinition type8 in @using.Types)
					{
						if (lookup.IsAccessible(type8, allowProtectedAccess: false))
						{
							object type4;
							if (typePred == null)
							{
								IType type3 = type8;
								type4 = type3;
							}
							else
							{
								type4 = typePred(type8);
							}
							IType type5 = (IType)type4;
							if ((!onlyAddConstructors || type5 == null || type5.GetConstructors().Any((IMethod c) => lookup.IsAccessible(c, allowProtectedAccess: true))) && type5 != null)
							{
								ICompletionData completionData2 = onlyAddConstructors ? wrapper.AddConstructors(type5, showFullName: false, IsAttributeContext(node)) : wrapper.AddType(type5, showFullName: false, IsAttributeContext(node));
								if (completionData2 != null)
								{
									callback?.Invoke(completionData2, type8);
								}
							}
						}
					}
				}
				foreach (ITypeDefinition type9 in resolvedUsingScope.Namespace.Types)
				{
					if (lookup.IsAccessible(type9, allowProtectedAccess: false))
					{
						object type6;
						if (typePred == null)
						{
							IType type3 = type9;
							type6 = type3;
						}
						else
						{
							type6 = typePred(type9);
						}
						IType type7 = (IType)type6;
						if ((!onlyAddConstructors || type7 == null || type7.GetConstructors().Any((IMethod c) => lookup.IsAccessible(c, allowProtectedAccess: true))) && type7 != null)
						{
							ICompletionData completionData3 = onlyAddConstructors ? wrapper.AddConstructors(type7, showFullName: false, IsAttributeContext(node)) : wrapper.AddType(type7, showFullName: false, IsAttributeContext(node));
							if (completionData3 != null)
							{
								callback?.Invoke(completionData3, type9);
							}
						}
					}
				}
			}
			for (ResolvedUsingScope resolvedUsingScope2 = currentUsingScope; resolvedUsingScope2 != null; resolvedUsingScope2 = resolvedUsingScope2.Parent)
			{
				foreach (INamespace childNamespace in resolvedUsingScope2.Namespace.ChildNamespaces)
				{
					wrapper.AddNamespace(lookup, childNamespace);
				}
			}
			if (node is AstType && node.Parent is Constraint && IncludeKeywordsInCompletionList)
			{
				wrapper.AddCustom("new()");
			}
			if (!AutomaticallyAddImports)
			{
				return;
			}
			state = GetState();
			List<INamespace> list = new List<INamespace>();
			for (ResolvedUsingScope resolvedUsingScope3 = base.ctx.CurrentUsingScope; resolvedUsingScope3 != null; resolvedUsingScope3 = resolvedUsingScope3.Parent)
			{
				list.Add(resolvedUsingScope3.Namespace);
				foreach (INamespace using2 in resolvedUsingScope3.Usings)
				{
					list.Add(using2);
				}
			}
			ICompletionData[] array;
			if (CompletionEngineCache != null && ListEquals(list, CompletionEngineCache.namespaces))
			{
				array = CompletionEngineCache.importCompletion;
			}
			else
			{
				List<ICompletionData> list2 = new List<ICompletionData>();
				Dictionary<string, Dictionary<string, ICompletionData>> dictionary = new Dictionary<string, Dictionary<string, ICompletionData>>();
				foreach (ITypeDefinition type in base.Compilation.GetTopLevelTypeDefinitons())
				{
					if (lookup.IsAccessible(type, allowProtectedAccess: false) && !list.Any((INamespace n) => n.FullName == type.Namespace))
					{
						bool useFullName = false;
						foreach (INamespace item2 in list)
						{
							if (item2.GetTypeDefinition(type.Name, type.TypeParameterCount) != null)
							{
								useFullName = true;
								break;
							}
						}
						if (!onlyAddConstructors || type.GetConstructors().Any((IMethod c) => lookup.IsAccessible(c, allowProtectedAccess: true)))
						{
							ICompletionData completionData4 = factory.CreateImportCompletionData(type, useFullName, onlyAddConstructors);
							if (!dictionary.TryGetValue(type.Name, out Dictionary<string, ICompletionData> value))
							{
								value = new Dictionary<string, ICompletionData>();
								dictionary.Add(type.Name, value);
							}
							if (!value.TryGetValue(type.Namespace, out ICompletionData value2))
							{
								list2.Add(completionData4);
								value.Add(type.Namespace, completionData4);
							}
							else
							{
								value2.AddOverload(completionData4);
							}
						}
					}
				}
				array = list2.ToArray();
				if (CompletionEngineCache != null)
				{
					CompletionEngineCache.namespaces = list;
					CompletionEngineCache.importCompletion = array;
				}
			}
			ICompletionData[] array2 = array;
			foreach (ICompletionData item in array2)
			{
				wrapper.Result.Add(item);
			}
		}

		private IEnumerable<ICompletionData> HandleKeywordCompletion(int wordStart, string word)
		{
			if (IsInsideCommentStringOrDirective())
			{
				if (IsInPreprocessorDirective() && (word == "if" || word == "elif") && wordStart > 0 && document.GetCharAt(wordStart - 1) == '#')
				{
					return factory.CreatePreProcessorDefinesCompletionData();
				}
				return null;
			}
			switch (word)
			{
			case "namespace":
				return null;
			case "using":
			{
				if (currentType != null)
				{
					return null;
				}
				CompletionDataWrapper completionDataWrapper4 = new CompletionDataWrapper(this);
				AddTypesAndNamespaces(completionDataWrapper4, GetState(), null, (IType t) => null);
				return completionDataWrapper4.Result;
			}
			case "case":
				return CreateCaseCompletionData(location);
			case "is":
			case "as":
			{
				if (currentType == null)
				{
					return null;
				}
				IType type = null;
				ExpressionResult expressionAt = GetExpressionAt(wordStart);
				if (expressionAt != null)
				{
					AstNode parent = expressionAt.Node.Parent;
					if (parent is VariableInitializer)
					{
						parent = parent.Parent;
					}
					VariableDeclarationStatement variableDeclarationStatement = parent as VariableDeclarationStatement;
					if (variableDeclarationStatement != null)
					{
						ExpressionResolveResult expressionResolveResult2 = (!variableDeclarationStatement.Type.IsVar()) ? ResolveExpression(parent) : null;
						if (expressionResolveResult2 != null)
						{
							type = expressionResolveResult2.Result.Type;
						}
					}
				}
				CompletionDataWrapper completionDataWrapper2 = new CompletionDataWrapper(this);
				ITypeDefinition def = type?.GetDefinition();
				AddTypesAndNamespaces(completionDataWrapper2, GetState(), null, (IType t) => (t.GetDefinition() != null && def != null && !t.GetDefinition().IsDerivedFrom(def)) ? null : t, (IMember m) => false);
				AddKeywords(completionDataWrapper2, primitiveTypesKeywords);
				return completionDataWrapper2.Result;
			}
			case "override":
			{
				int num = wordStart;
				int i = wordStart;
				for (int k = 0; k < 3; num = i, k++)
				{
					switch (GetPreviousToken(ref i, allowLineChange: true))
					{
					case "public":
					case "protected":
					case "private":
					case "internal":
					case "sealed":
						continue;
					case "static":
						return null;
					}
					break;
				}
				if (!IsLineEmptyUpToEol())
				{
					return null;
				}
				if (currentType != null && (currentType.Kind == TypeKind.Class || currentType.Kind == TypeKind.Struct))
				{
					string text2 = document.GetText(num, wordStart - num);
					return GetOverrideCompletionData(currentType, text2);
				}
				return null;
			}
			case "partial":
			{
				int num = wordStart;
				int i = wordStart;
				for (int j = 0; j < 3; num = i, j++)
				{
					switch (GetPreviousToken(ref i, allowLineChange: true))
					{
					case "public":
					case "protected":
					case "private":
					case "internal":
					case "sealed":
						continue;
					case "static":
						return null;
					}
					break;
				}
				if (!IsLineEmptyUpToEol())
				{
					return null;
				}
				CSharpResolver state = GetState();
				if (state.CurrentTypeDefinition != null && (state.CurrentTypeDefinition.Kind == TypeKind.Class || state.CurrentTypeDefinition.Kind == TypeKind.Struct))
				{
					string text = document.GetText(num, wordStart - num);
					return GetPartialCompletionData(state.CurrentTypeDefinition, text);
				}
				return null;
			}
			case "public":
			case "protected":
			case "private":
			case "internal":
			case "sealed":
			case "static":
			{
				IEnumerable<ICompletionData> enumerable = HandleAccessorContext();
				if (enumerable != null)
				{
					return enumerable;
				}
				return null;
			}
			case "new":
			{
				int offset = base.offset - 4;
				IType type2 = null;
				ExpressionResult newExpressionAt = GetNewExpressionAt(offset);
				if (newExpressionAt == null)
				{
					return null;
				}
				type2 = TypeGuessing.GetValidTypes(base.CompletionContextProvider.GetResolver(GetState(), newExpressionAt.Node.Ancestors.FirstOrDefault((AstNode n) => (!(n is EntityDeclaration)) ? (n is SyntaxTree) : true)), newExpressionAt.Node).FirstOrDefault();
				return CreateConstructorCompletionData(type2);
			}
			case "yield":
			{
				CompletionDataWrapper completionDataWrapper3 = new CompletionDataWrapper(this);
				DefaultCompletionString = "return";
				if (IncludeKeywordsInCompletionList)
				{
					completionDataWrapper3.AddCustom("break");
					completionDataWrapper3.AddCustom("return");
				}
				return completionDataWrapper3.Result;
			}
			case "in":
			{
				CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
				ExpressionResult expressionAtCursor = GetExpressionAtCursor();
				if (expressionAtCursor == null)
				{
					return null;
				}
				ExpressionResolveResult expressionResolveResult = ResolveExpression(expressionAtCursor);
				AddContextCompletion(completionDataWrapper, (expressionResolveResult != null) ? expressionResolveResult.Resolver : GetState(), expressionAtCursor.Node);
				return completionDataWrapper.Result;
			}
			default:
				return null;
			}
		}

		private bool IsLineEmptyUpToEol()
		{
			IDocumentLine lineByNumber = document.GetLineByNumber(location.Line);
			for (int i = offset; i < lineByNumber.EndOffset; i++)
			{
				if (!char.IsWhiteSpace(document.GetCharAt(i)))
				{
					return false;
				}
			}
			return true;
		}

		private string GetLineIndent(int lineNr)
		{
			IDocumentLine lineByNumber = document.GetLineByNumber(lineNr);
			for (int i = lineByNumber.Offset; i < lineByNumber.EndOffset; i++)
			{
				if (!char.IsWhiteSpace(document.GetCharAt(i)))
				{
					return document.GetText(lineByNumber.Offset, i - lineByNumber.Offset);
				}
			}
			return "";
		}

		private IEnumerable<ICompletionData> CreateConstructorCompletionData(IType hintType)
		{
			CompletionDataWrapper wrapper = new CompletionDataWrapper(this);
			CSharpResolver state = GetState();
			Func<IType, IType> typePred = null;
			Action<ICompletionData, IType> callback = null;
			Category inferredTypesCategory = new Category("Inferred Types", null);
			Category derivedTypesCategory = new Category("Derived Types", null);
			if (hintType != null && (hintType.Kind != TypeKind.TypeParameter || IsTypeParameterInScope(hintType)))
			{
				if (hintType.Kind != TypeKind.Unknown)
				{
					MemberLookup lookup = new MemberLookup(base.ctx.CurrentTypeDefinition, base.Compilation.MainAssembly);
					callback = delegate(ICompletionData data, IType t)
					{
						if (hintType.GetDefinition() != null && t.GetDefinition() != null && t.GetDefinition().IsDerivedFrom(hintType.GetDefinition()))
						{
							data.CompletionCategory = derivedTypesCategory;
						}
					};
					typePred = delegate(IType t)
					{
						if (t.Kind == TypeKind.Interface && hintType.Kind != TypeKind.Array)
						{
							return null;
						}
						if (t.GetConstructors().Any())
						{
							bool isProtectedAllowed = currentType != null && currentType.Resolve(base.ctx).GetDefinition().IsDerivedFrom(t.GetDefinition());
							if (!t.GetConstructors().Any((IMethod m) => lookup.IsAccessible(m, isProtectedAllowed)))
							{
								return null;
							}
						}
						ITypeDefinition definition = t.GetDefinition();
						ITypeDefinition definition2 = hintType.GetDefinition();
						if (definition != null && definition2 != null && definition.IsDerivedFrom(definition2))
						{
							ICompletionData completionData3 = wrapper.AddType(t, showFullName: true);
							if (completionData3 != null)
							{
								completionData3.CompletionCategory = inferredTypesCategory;
							}
						}
						IType type3 = new TypeInference(base.Compilation)
						{
							Algorithm = TypeInferenceAlgorithm.ImprovedReturnAllResults
						}.FindTypeInBounds(new IType[1]
						{
							t
						}, new IType[1]
						{
							hintType
						});
						if (type3 != SpecialType.UnknownType)
						{
							ICompletionData completionData4 = wrapper.AddType(type3, showFullName: true);
							if (completionData4 != null)
							{
								completionData4.CompletionCategory = inferredTypesCategory;
							}
							return null;
						}
						return t;
					};
					if (hintType.Kind != TypeKind.Interface || hintType.Kind == TypeKind.Array)
					{
						ICompletionData completionData = wrapper.AddType(hintType, showFullName: true);
						if (completionData != null)
						{
							DefaultCompletionString = completionData.DisplayText;
							completionData.CompletionCategory = derivedTypesCategory;
						}
					}
					if (hintType is ParameterizedType && hintType.TypeParameterCount == 1 && hintType.FullName == "System.Collections.Generic.IEnumerable")
					{
						IType type = ((ParameterizedType)hintType).TypeArguments.FirstOrDefault();
						if (type.Kind != TypeKind.TypeParameter)
						{
							ArrayType type2 = new ArrayType(base.ctx.Compilation, type);
							wrapper.AddType(type2, showFullName: true);
						}
					}
				}
				else
				{
					ICompletionData completionData2 = wrapper.AddType(hintType, showFullName: true);
					if (completionData2 != null)
					{
						DefaultCompletionString = completionData2.DisplayText;
						completionData2.CompletionCategory = derivedTypesCategory;
					}
				}
			}
			AddTypesAndNamespaces(wrapper, state, null, typePred, (IMember m) => false, callback, onlyAddConstructors: true);
			if (hintType == null || hintType == SpecialType.UnknownType)
			{
				AddKeywords(wrapper, from k in primitiveTypesKeywords
					where k != "void"
					select k);
			}
			CloseOnSquareBrackets = true;
			AutoCompleteEmptyMatch = true;
			AutoCompleteEmptyMatchOnCurlyBracket = false;
			return wrapper.Result;
		}

		private bool IsTypeParameterInScope(IType hintType)
		{
			string reflectionName = (hintType as ITypeParameter).Owner.ReflectionName;
			if (currentMember != null && reflectionName == currentMember.ReflectionName)
			{
				return true;
			}
			for (IUnresolvedTypeDefinition unresolvedTypeDefinition = currentType; unresolvedTypeDefinition != null; unresolvedTypeDefinition = unresolvedTypeDefinition.DeclaringTypeDefinition)
			{
				if (reflectionName == unresolvedTypeDefinition.ReflectionName)
				{
					return true;
				}
			}
			return false;
		}

		private IEnumerable<ICompletionData> GetOverrideCompletionData(IUnresolvedTypeDefinition type, string modifiers)
		{
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			List<IMember> alreadyInserted = new List<IMember>();
			int num = offset;
			int i = num;
			for (int j = 0; j < 3; j++)
			{
				switch (GetPreviousToken(ref i, allowLineChange: true))
				{
				case "public":
				case "protected":
				case "private":
				case "internal":
				case "sealed":
				case "override":
				case "partial":
				case "async":
					num = i;
					break;
				case "static":
					return null;
				}
			}
			AddVirtuals(alreadyInserted, completionDataWrapper, modifiers, type.Resolve(base.ctx), num);
			return completionDataWrapper.Result;
		}

		private IEnumerable<ICompletionData> GetPartialCompletionData(ITypeDefinition type, string modifiers)
		{
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			int num = offset;
			int i = num;
			for (int j = 0; j < 3; j++)
			{
				switch (GetPreviousToken(ref i, allowLineChange: true))
				{
				case "public":
				case "protected":
				case "private":
				case "internal":
				case "sealed":
				case "override":
				case "partial":
				case "async":
					num = i;
					break;
				case "static":
					return null;
				}
			}
			List<IUnresolvedMethod> list = new List<IUnresolvedMethod>();
			foreach (IUnresolvedTypeDefinition part in type.Parts)
			{
				foreach (IUnresolvedMethod method in part.Methods)
				{
					if (method.BodyRegion.IsEmpty && GetImplementation(type, method) == null)
					{
						list.Add(method);
					}
				}
			}
			foreach (IUnresolvedMethod item in list)
			{
				completionDataWrapper.Add(factory.CreateNewPartialCompletionData(num, item.DeclaringTypeDefinition, item));
			}
			return completionDataWrapper.Result;
		}

		private IMethod GetImplementation(ITypeDefinition type, IUnresolvedMethod method)
		{
			foreach (IMethod method2 in type.Methods)
			{
				if (method2.Name == method.Name && method2.Parameters.Count == method.Parameters.Count && ((!method2.BodyRegion.IsEmpty) ? true : false))
				{
					return method2;
				}
			}
			return null;
		}

		protected virtual void AddVirtuals(List<IMember> alreadyInserted, CompletionDataWrapper col, string modifiers, IType curType, int declarationBegin)
		{
			if (curType != null)
			{
				foreach (IMember i in curType.GetMembers().Reverse())
				{
					if ((curType.Kind == TypeKind.Interface || i.IsOverridable) && (!(i is IMethod) || !(i.Name == "Finalize")))
					{
						ICompletionData completionData = factory.CreateNewOverrideCompletionData(declarationBegin, currentType, i);
						if (!curType.GetMembers().Any((IMember cm) => SignatureComparer.Ordinal.Equals(cm, i) && cm.DeclaringTypeDefinition == curType.GetDefinition()) && !alreadyInserted.Any((IMember cm) => SignatureComparer.Ordinal.Equals(cm, i)))
						{
							alreadyInserted.Add(i);
							completionData.CompletionCategory = col.GetCompletionCategory(i.DeclaringTypeDefinition);
							col.Add(completionData);
						}
					}
				}
			}
		}

		private void AddKeywords(CompletionDataWrapper wrapper, IEnumerable<string> keywords)
		{
			if (IncludeKeywordsInCompletionList)
			{
				foreach (string keyword in keywords)
				{
					if (!wrapper.Result.Any((ICompletionData data) => data.DisplayText == keyword))
					{
						wrapper.AddCustom(keyword);
					}
				}
			}
		}

		public string GuessEventHandlerMethodName(int tokenIndex, string surroundingTypeName)
		{
			List<string> list = new List<string>();
			string text = GetPreviousToken(ref tokenIndex, allowLineChange: false);
			string previousToken = GetPreviousToken(ref tokenIndex, allowLineChange: false);
			if (previousToken != ".")
			{
				if (surroundingTypeName == null)
				{
					text = "Handle" + text;
				}
				else
				{
					list.Add(surroundingTypeName);
				}
			}
			while (previousToken == ".")
			{
				previousToken = GetPreviousToken(ref tokenIndex, allowLineChange: false);
				if (previousToken == "this")
				{
					if (list.Count == 0)
					{
						if (surroundingTypeName == null)
						{
							text = "Handle" + text;
						}
						else
						{
							list.Add(surroundingTypeName);
						}
					}
				}
				else if (previousToken != null)
				{
					string text2 = previousToken.Trim();
					if (text2.Length == 0)
					{
						break;
					}
					list.Insert(0, text2);
				}
				previousToken = GetPreviousToken(ref tokenIndex, allowLineChange: false);
			}
			if (!string.IsNullOrEmpty(text))
			{
				list.Add(text);
			}
			previousToken = string.Join("_", list.ToArray());
			string text3 = previousToken;
			foreach (char c in text3)
			{
				if (!char.IsLetterOrDigit(c) && c != '_')
				{
					previousToken = "";
					break;
				}
			}
			return previousToken;
		}

		private bool MatchDelegate(IType delegateType, IMethod method)
		{
			if (method.SymbolKind != SymbolKind.Method)
			{
				return false;
			}
			IMethod delegateInvokeMethod = delegateType.GetDelegateInvokeMethod();
			if (delegateInvokeMethod == null || delegateInvokeMethod.Parameters.Count != method.Parameters.Count)
			{
				return false;
			}
			for (int i = 0; i < delegateInvokeMethod.Parameters.Count; i++)
			{
				if (!delegateInvokeMethod.Parameters[i].Type.Equals(method.Parameters[i].Type))
				{
					return false;
				}
			}
			return true;
		}

		private string AddDelegateHandlers(CompletionDataWrapper completionList, IType delegateType, bool addSemicolon = true, bool addDefault = true, string optDelegateName = null)
		{
			IMethod delegateInvokeMethod = delegateType.GetDelegateInvokeMethod();
			PossibleDelegates.Add(delegateInvokeMethod);
			string lineIndent = GetLineIndent(location.Line);
			string text = EolMarker + lineIndent + "}" + (addSemicolon ? ";" : "");
			if (addDefault && !completionList.AnonymousDelegateAdded)
			{
				completionList.AnonymousDelegateAdded = true;
				ICompletionData completionData = completionList.Result.FirstOrDefault((ICompletionData cd) => cd.DisplayText == "delegate");
				if (completionData != null)
				{
					completionList.Result.Remove(completionData);
				}
				completionList.AddCustom("delegate", "Creates anonymous delegate.", "delegate {" + EolMarker + lineIndent + IndentString + "|" + text).DisplayFlags |= DisplayFlags.MarkedBold;
				if (base.LanguageVersion.Major >= 5)
				{
					completionList.AddCustom("async delegate", "Creates anonymous async delegate.", "async delegate {" + EolMarker + lineIndent + IndentString + "|" + text).DisplayFlags |= DisplayFlags.MarkedBold;
				}
			}
			StringBuilder sb = new StringBuilder("(");
			StringBuilder sbWithoutTypes = new StringBuilder("(");
			TypeSystemAstBuilder typeSystemAstBuilder = new TypeSystemAstBuilder(GetState());
			for (int i = 0; i < delegateInvokeMethod.Parameters.Count; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
					sbWithoutTypes.Append(", ");
				}
				ParameterDeclaration parameterDeclaration = typeSystemAstBuilder.ConvertParameter(delegateInvokeMethod.Parameters[i]);
				if (parameterDeclaration.ParameterModifier == ParameterModifier.Params)
				{
					parameterDeclaration.ParameterModifier = ParameterModifier.None;
				}
				sb.Append(parameterDeclaration.ToString(FormattingPolicy));
				sbWithoutTypes.Append(delegateInvokeMethod.Parameters[i].Name);
			}
			sb.Append(")");
			sbWithoutTypes.Append(")");
			string text2 = sb.ToString();
			if (!completionList.HasAnonymousDelegateAdded(text2))
			{
				completionList.AddAnonymousDelegateAdded(text2);
				completionList.AddCustom("delegate" + text2, "Creates anonymous delegate.", "delegate" + text2 + " {" + EolMarker + lineIndent + IndentString + "|" + text).DisplayFlags |= DisplayFlags.MarkedBold;
				if (base.LanguageVersion.Major >= 5)
				{
					completionList.AddCustom("async delegate" + text2, "Creates anonymous async delegate.", "async delegate" + text2 + " {" + EolMarker + lineIndent + IndentString + "|" + text).DisplayFlags |= DisplayFlags.MarkedBold;
				}
				if (!completionList.Result.Any((ICompletionData data) => data.DisplayText == sb.ToString()))
				{
					completionList.AddCustom(text2, "Creates typed lambda expression.", text2 + " => |" + (addSemicolon ? ";" : "")).DisplayFlags |= DisplayFlags.MarkedBold;
					if (base.LanguageVersion.Major >= 5)
					{
						completionList.AddCustom("async " + text2, "Creates typed async lambda expression.", "async " + text2 + " => |" + (addSemicolon ? ";" : "")).DisplayFlags |= DisplayFlags.MarkedBold;
					}
					if (!delegateInvokeMethod.Parameters.Any((IParameter p) => (!p.IsOut) ? p.IsRef : true) && !completionList.Result.Any((ICompletionData data) => data.DisplayText == sbWithoutTypes.ToString()))
					{
						completionList.AddCustom(sbWithoutTypes.ToString(), "Creates lambda expression.", sbWithoutTypes + " => |" + (addSemicolon ? ";" : "")).DisplayFlags |= DisplayFlags.MarkedBold;
						if (base.LanguageVersion.Major >= 5)
						{
							completionList.AddCustom("async " + sbWithoutTypes, "Creates async lambda expression.", "async " + sbWithoutTypes + " => |" + (addSemicolon ? ";" : "")).DisplayFlags |= DisplayFlags.MarkedBold;
						}
					}
				}
			}
			string delegateMethodName = optDelegateName ?? ("Handle" + delegateType.Name);
			ICompletionData completionData2 = factory.CreateEventCreationCompletionData(delegateMethodName, delegateType, null, text2, currentMember, currentType);
			completionData2.DisplayFlags |= DisplayFlags.MarkedBold;
			completionList.Add(completionData2);
			return sb.ToString();
		}

		private bool IsAccessibleFrom(IEntity member, ITypeDefinition calledType, IMember currentMember, bool includeProtected)
		{
			if (currentMember == null)
			{
				if (!member.IsStatic)
				{
					return member.IsPublic;
				}
				return true;
			}
			if (member.IsPublic || (calledType != null && calledType.Kind == TypeKind.Interface && !member.IsProtected))
			{
				return true;
			}
			if (member.DeclaringTypeDefinition != null)
			{
				if (member.DeclaringTypeDefinition.Kind == TypeKind.Interface)
				{
					return IsAccessibleFrom(member.DeclaringTypeDefinition, calledType, currentMember, includeProtected);
				}
				if (member.IsProtected && (!member.DeclaringTypeDefinition.IsProtectedOrInternal || includeProtected))
				{
					return includeProtected;
				}
			}
			if (member.IsInternal || member.IsProtectedAndInternal || member.IsProtectedOrInternal)
			{
				bool flag = true;
				if (!member.IsProtectedAndInternal)
				{
					return flag;
				}
				return includeProtected && flag;
			}
			if (!(currentMember is IType) && (currentMember.DeclaringTypeDefinition == null || member.DeclaringTypeDefinition == null))
			{
				return false;
			}
			for (ITypeDefinition declaringTypeDefinition = currentMember.DeclaringTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
			{
				if (declaringTypeDefinition.ReflectionName == currentMember.DeclaringType.ReflectionName)
				{
					return true;
				}
			}
			if (currentMember.DeclaringTypeDefinition != null)
			{
				return member.DeclaringTypeDefinition.FullName == currentMember.DeclaringTypeDefinition.FullName;
			}
			return false;
		}

		private static bool IsAttributeContext(AstNode node)
		{
			AstNode astNode = node;
			while (astNode is AstType)
			{
				astNode = astNode.Parent;
			}
			return astNode is Attribute;
		}

		private IEnumerable<ICompletionData> CreateTypeAndNamespaceCompletionData(TextLocation location, ResolveResult resolveResult, AstNode resolvedNode, CSharpResolver state)
		{
			if (resolveResult == null || resolveResult.IsError)
			{
				return null;
			}
			Expression parent = resolvedNode.GetParent<Expression>();
			SyntaxTree syntaxTree = parent?.GetParent<SyntaxTree>();
			CSharpAstResolver cSharpAstResolver = (syntaxTree != null) ? base.CompletionContextProvider.GetResolver(state, syntaxTree) : null;
			IType type = (parent != null && cSharpAstResolver != null) ? TypeGuessing.GetValidTypes(cSharpAstResolver, parent).FirstOrDefault() : null;
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			MemberLookup memberLookup = new MemberLookup(base.ctx.CurrentTypeDefinition, base.Compilation.MainAssembly);
			if (resolveResult is NamespaceResolveResult)
			{
				NamespaceResolveResult namespaceResolveResult = (NamespaceResolveResult)resolveResult;
				if (!(resolvedNode.Parent is UsingDeclaration) && (resolvedNode.Parent == null || !(resolvedNode.Parent.Parent is UsingDeclaration)))
				{
					foreach (ITypeDefinition type2 in namespaceResolveResult.Namespace.Types)
					{
						if ((type == null || type.Kind == TypeKind.Array || type2.Kind != TypeKind.Interface) && memberLookup.IsAccessible(type2, allowProtectedAccess: false))
						{
							completionDataWrapper.AddType(type2, showFullName: false, IsAttributeContext(resolvedNode));
						}
					}
				}
				foreach (INamespace childNamespace in namespaceResolveResult.Namespace.ChildNamespaces)
				{
					completionDataWrapper.AddNamespace(memberLookup, childNamespace);
				}
			}
			else if (resolveResult is TypeResolveResult)
			{
				foreach (IType nestedType in resolveResult.Type.GetNestedTypes())
				{
					if (type == null || type.Kind == TypeKind.Array || nestedType.Kind != TypeKind.Interface)
					{
						ITypeDefinition definition = nestedType.GetDefinition();
						if (definition == null || memberLookup.IsAccessible(definition, allowProtectedAccess: false))
						{
							completionDataWrapper.AddType(nestedType, showFullName: false);
						}
					}
				}
			}
			return completionDataWrapper.Result;
		}

		private IEnumerable<ICompletionData> CreateTypeList()
		{
			foreach (ITypeDefinition type in Compilation.RootNamespace.Types)
			{
				yield return factory.CreateTypeCompletionData(type, showFullName: false, isInAttributeContext: false, addForTypeCreation: false);
			}
			foreach (INamespace childNamespace in Compilation.RootNamespace.ChildNamespaces)
			{
				yield return factory.CreateNamespaceCompletionData(childNamespace);
			}
		}

		private void CreateParameterForInvocation(CompletionDataWrapper result, IMethod method, CSharpResolver state, int parameter, HashSet<string> addedEnums, HashSet<string> addedDelegates)
		{
			if (method.Parameters.Count <= parameter)
			{
				return;
			}
			IType type = method.Parameters[parameter].Type;
			if (type.Kind == TypeKind.Enum)
			{
				if (!addedEnums.Contains(type.ReflectionName))
				{
					addedEnums.Add(type.ReflectionName);
					AddEnumMembers(result, type, state);
				}
			}
			else if (type.Kind == TypeKind.Delegate && !addedDelegates.Contains(type.ReflectionName))
			{
				AddDelegateHandlers(result, type, addSemicolon: false, addDefault: true, "Handle" + method.Parameters[parameter].Type.Name + method.Parameters[parameter].Name);
			}
		}

		private IEnumerable<ICompletionData> CreateParameterCompletion(MethodGroupResolveResult resolveResult, CSharpResolver state, AstNode invocation, SyntaxTree unit, int parameter, bool controlSpace)
		{
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			HashSet<string> hashSet = new HashSet<string>();
			HashSet<string> hashSet2 = new HashSet<string>();
			foreach (IMethod method in resolveResult.Methods)
			{
				CreateParameterForInvocation(completionDataWrapper, method, state, parameter, hashSet, hashSet2);
			}
			foreach (IEnumerable<IMethod> eligibleExtensionMethod in resolveResult.GetEligibleExtensionMethods(substituteInferredTypes: true))
			{
				foreach (IMethod item in eligibleExtensionMethod)
				{
					if (!resolveResult.Methods.Contains(item))
					{
						CreateParameterForInvocation(completionDataWrapper, new ReducedExtensionMethod(item), state, parameter, hashSet, hashSet2);
					}
				}
			}
			foreach (IMethod method2 in resolveResult.Methods)
			{
				if (parameter < method2.Parameters.Count && method2.Parameters[parameter].Type.Kind == TypeKind.Delegate)
				{
					AutoSelect = false;
					AutoCompleteEmptyMatch = false;
				}
				foreach (IParameter parameter2 in method2.Parameters)
				{
					completionDataWrapper.AddNamedParameterVariable(parameter2);
				}
			}
			if (!controlSpace)
			{
				if (hashSet.Count + hashSet2.Count == 0)
				{
					return Enumerable.Empty<ICompletionData>();
				}
				AutoCompleteEmptyMatch = false;
				AutoSelect = false;
			}
			AddContextCompletion(completionDataWrapper, state, invocation);
			return completionDataWrapper.Result;
		}

		private void AddEnumMembers(CompletionDataWrapper completionList, IType resolvedType, CSharpResolver state)
		{
			if (resolvedType.Kind == TypeKind.Enum)
			{
				ICompletionData completionData = completionList.AddEnumMembers(resolvedType, state);
				if (completionData != null)
				{
					DefaultCompletionString = completionData.DisplayText;
				}
			}
		}

		private IEnumerable<ICompletionData> CreateCompletionData(TextLocation location, ResolveResult resolveResult, AstNode resolvedNode, CSharpResolver state, Func<IType, IType> typePred = null)
		{
			if (resolveResult == null)
			{
				return null;
			}
			MemberLookup memberLookup = new MemberLookup(base.ctx.CurrentTypeDefinition, base.Compilation.MainAssembly);
			if (resolveResult is NamespaceResolveResult)
			{
				NamespaceResolveResult namespaceResolveResult = (NamespaceResolveResult)resolveResult;
				CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
				foreach (ITypeDefinition type5 in namespaceResolveResult.Namespace.Types)
				{
					if (memberLookup.IsAccessible(type5, allowProtectedAccess: false))
					{
						object type2;
						if (typePred == null)
						{
							IType type = type5;
							type2 = type;
						}
						else
						{
							type2 = typePred(type5);
						}
						IType type3 = (IType)type2;
						if (type3 != null)
						{
							completionDataWrapper.AddType(type3, showFullName: false);
						}
					}
				}
				foreach (INamespace childNamespace in namespaceResolveResult.Namespace.ChildNamespaces)
				{
					completionDataWrapper.AddNamespace(memberLookup, childNamespace);
				}
				return completionDataWrapper.Result;
			}
			IType type4 = resolveResult.Type;
			if (type4.Namespace == "System" && type4.Name == "Void")
			{
				return null;
			}
			if (resolvedNode.Parent is PointerReferenceExpression && type4 is PointerType)
			{
				resolveResult = new OperatorResolveResult(((PointerType)type4).ElementType, ExpressionType.Extension, resolveResult);
			}
			CompletionDataWrapper completionDataWrapper2 = new CompletionDataWrapper(this);
			bool flag = false;
			if (resolveResult is LocalResolveResult && resolvedNode is IdentifierExpression)
			{
				LocalResolveResult localResolveResult = (LocalResolveResult)resolveResult;
				flag = (localResolveResult.Variable.Name == localResolveResult.Type.Name);
			}
			if (resolveResult is TypeResolveResult && type4.Kind == TypeKind.Enum)
			{
				foreach (IField field2 in type4.GetFields())
				{
					if (memberLookup.IsAccessible(field2, allowProtectedAccess: false))
					{
						completionDataWrapper2.AddMember(field2);
					}
				}
				return completionDataWrapper2.Result;
			}
			bool allowProtectedAccess = memberLookup.IsProtectedAccessAllowed(resolveResult);
			bool flag2 = resolveResult is TypeResolveResult;
			if (resolveResult is MemberResolveResult && resolvedNode is IdentifierExpression)
			{
				MemberResolveResult memberResolveResult = (MemberResolveResult)resolveResult;
				flag = (memberResolveResult.Member.Name == memberResolveResult.Type.Name);
				if (state.IsVariableReferenceWithSameType(resolveResult, ((IdentifierExpression)resolvedNode).Identifier, out TypeResolveResult trr) && currentMember != null && (memberResolveResult.Member.IsStatic ^ currentMember.IsStatic))
				{
					flag2 = true;
					if (trr.Type.Kind == TypeKind.Enum)
					{
						foreach (IField field3 in trr.Type.GetFields())
						{
							if (memberLookup.IsAccessible(field3, allowProtectedAccess: false))
							{
								completionDataWrapper2.AddMember(field3);
							}
						}
						return completionDataWrapper2.Result;
					}
				}
				for (ResolvedUsingScope resolvedUsingScope = base.ctx.CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
				{
					foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
					{
						if (usingAlias.Key == memberResolveResult.Member.Name)
						{
							foreach (ICompletionData item in CreateCompletionData(location, usingAlias.Value, resolvedNode, state))
							{
								if (item is IEntityCompletionData && ((IEntityCompletionData)item).Entity is IMember)
								{
									completionDataWrapper2.AddMember((IMember)((IEntityCompletionData)item).Entity);
								}
								else
								{
									completionDataWrapper2.Add(item);
								}
							}
						}
					}
				}
			}
			if (resolveResult is TypeResolveResult && (resolvedNode is IdentifierExpression || resolvedNode is MemberReferenceExpression))
			{
				flag = true;
			}
			if (resolvedNode.Annotation<ObjectCreateExpression>() == null)
			{
				foreach (IEntity accessibleMember in memberLookup.GetAccessibleMembers(resolveResult))
				{
					if (accessibleMember.SymbolKind != SymbolKind.Indexer && accessibleMember.SymbolKind != SymbolKind.Operator && accessibleMember.SymbolKind != SymbolKind.Constructor && accessibleMember.SymbolKind != SymbolKind.Destructor && (!(resolvedNode is BaseReferenceExpression) || !accessibleMember.IsAbstract))
					{
						if (accessibleMember is IType && ((resolveResult is TypeResolveResult) | flag))
						{
							if (memberLookup.IsAccessible(accessibleMember, allowProtectedAccess))
							{
								completionDataWrapper2.AddType((IType)accessibleMember, showFullName: false);
							}
						}
						else
						{
							bool flag3 = accessibleMember.IsStatic;
							if (!(!flag && flag3) || resolveResult is TypeResolveResult)
							{
								IField field = accessibleMember as IField;
								if (field != null)
								{
									flag3 |= field.IsConst;
								}
								if ((flag3 || !flag2) && (!(accessibleMember is IMethod) || !(((IMethod)accessibleMember).FullName == "System.Object.Finalize")) && accessibleMember.SymbolKind != SymbolKind.Operator && accessibleMember is IMember)
								{
									completionDataWrapper2.AddMember((IMember)accessibleMember);
								}
							}
						}
					}
				}
			}
			if (!((resolveResult is TypeResolveResult) | flag))
			{
				foreach (List<IMethod> extensionMethod in state.GetExtensionMethods(type4))
				{
					foreach (IMethod item2 in extensionMethod)
					{
						if (memberLookup.IsAccessible(item2, allowProtectedAccess))
						{
							completionDataWrapper2.AddMember(new ReducedExtensionMethod(item2));
						}
					}
				}
			}
			return completionDataWrapper2.Result;
		}

		private IEnumerable<ICompletionData> CreateCaseCompletionData(TextLocation location)
		{
			SyntaxTree syntaxTree = ParseStub("a: break;");
			if (syntaxTree == null)
			{
				return null;
			}
			SwitchStatement nodeAt = syntaxTree.GetNodeAt<SwitchStatement>(location);
			if (nodeAt == null)
			{
				return null;
			}
			int offset = document.GetOffset(nodeAt.Expression.StartLocation);
			ExpressionResult expressionAt = GetExpressionAt(offset);
			if (expressionAt == null)
			{
				return null;
			}
			ExpressionResolveResult expressionResolveResult = ResolveExpression(expressionAt);
			if (expressionResolveResult == null || expressionResolveResult.Result.Type.Kind != TypeKind.Enum)
			{
				return null;
			}
			CompletionDataWrapper completionDataWrapper = new CompletionDataWrapper(this);
			AddEnumMembers(completionDataWrapper, expressionResolveResult.Result.Type, expressionResolveResult.Resolver);
			AutoCompleteEmptyMatch = false;
			return completionDataWrapper.Result;
		}

		private ExpressionResult GetExpressionBeforeCursor()
		{
			SyntaxTree syntaxTree;
			if (currentMember == null)
			{
				syntaxTree = ParseStub("a", appendSemicolon: false);
				MemberType nodeAt = syntaxTree.GetNodeAt<MemberType>(location);
				if (nodeAt == null)
				{
					syntaxTree = ParseStub("a;", appendSemicolon: false);
					nodeAt = syntaxTree.GetNodeAt<MemberType>(location);
				}
				if (nodeAt == null)
				{
					syntaxTree = ParseStub("A a;", appendSemicolon: false);
					nodeAt = syntaxTree.GetNodeAt<MemberType>(location);
				}
				if (nodeAt != null)
				{
					return new ExpressionResult(nodeAt.Target, syntaxTree);
				}
			}
			syntaxTree = ParseStub("ToString()", appendSemicolon: false);
			AstNode nodeAt2 = syntaxTree.GetNodeAt(location);
			if (nodeAt2 is EntityDeclaration || (syntaxTree.GetNodeAt<Expression>(location) == null && syntaxTree.GetNodeAt<MemberType>(location) == null))
			{
				syntaxTree = ParseStub("a");
				nodeAt2 = syntaxTree.GetNodeAt(location);
			}
			if (nodeAt2 is EntityDeclaration || (syntaxTree.GetNodeAt<Expression>(location) == null && syntaxTree.GetNodeAt<MemberType>(location) == null))
			{
				syntaxTree = ParseStub("a};");
			}
			MemberReferenceExpression nodeAt3 = syntaxTree.GetNodeAt<MemberReferenceExpression>(location);
			if (currentMember == null && currentType == null)
			{
				if (nodeAt3 != null)
				{
					return new ExpressionResult(nodeAt3.Target, syntaxTree);
				}
				return null;
			}
			if (nodeAt3 == null)
			{
				MemberType nodeAt4 = syntaxTree.GetNodeAt<MemberType>(location);
				if (nodeAt4 != null)
				{
					return new ExpressionResult(nodeAt4.Target, syntaxTree);
				}
				PointerReferenceExpression nodeAt5 = syntaxTree.GetNodeAt<PointerReferenceExpression>(location);
				if (nodeAt5 != null)
				{
					return new ExpressionResult(nodeAt5.Target, syntaxTree);
				}
			}
			if (nodeAt3 == null)
			{
				syntaxTree = ParseStub("A a;", appendSemicolon: false);
				MemberType nodeAt6 = syntaxTree.GetNodeAt<MemberType>(location);
				if (nodeAt6 != null)
				{
					return new ExpressionResult(nodeAt6.Target, syntaxTree);
				}
			}
			AstNode astNode = null;
			if (nodeAt3 != null)
			{
				astNode = nodeAt3.Target;
			}
			else
			{
				Expression expression = syntaxTree.GetNodeAt<TypeReferenceExpression>(location);
				MemberType memberType = (expression != null) ? (((TypeReferenceExpression)expression).Type as MemberType) : null;
				if (memberType == null)
				{
					memberType = syntaxTree.GetNodeAt<MemberType>(location);
					if (memberType != null)
					{
						if (memberType.Parent is ObjectCreateExpression)
						{
							AstType astType = memberType.Target.Clone();
							memberType.ReplaceWith(astType);
							astNode = astType;
							goto IL_0295;
						}
						expression = syntaxTree.GetNodeAt<Expression>(location);
						if (expression == null)
						{
							expression = new TypeReferenceExpression(memberType.Clone());
							memberType.Parent.AddChild(expression, Roles.Expression);
						}
						if (expression is ObjectCreateExpression)
						{
							astNode = memberType.Target.Clone();
							astNode.AddAnnotation(new ObjectCreateExpression());
						}
					}
				}
				if (memberType == null)
				{
					return null;
				}
				if (astNode == null)
				{
					astNode = memberType.Target.Clone();
				}
				expression.ReplaceWith(astNode);
			}
			goto IL_0295;
			IL_0295:
			return new ExpressionResult(astNode, syntaxTree);
		}

		private ExpressionResult GetExpressionAtCursor()
		{
			SyntaxTree syntaxTree = ParseStub("a");
			SyntaxTree syntaxTree2 = syntaxTree;
			AstNode astNode = syntaxTree.GetNodeAt(location, (AstNode n) => (!(n is IdentifierExpression)) ? (n is MemberReferenceExpression) : true);
			if (astNode == null)
			{
				astNode = syntaxTree.GetNodeAt<AstType>(location.Line, location.Column - 1);
			}
			if (astNode == null)
			{
				astNode = syntaxTree.GetNodeAt<Identifier>(location.Line, location.Column - 1);
			}
			if (astNode == null && syntaxTree.GetNodeAt<EmptyStatement>(location.Line, location.Column) != null)
			{
				syntaxTree2 = (syntaxTree = ParseStub("a();", appendSemicolon: false));
				astNode = syntaxTree.GetNodeAt<InvocationExpression>(location.Line, location.Column + 1);
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("()");
				astNode = syntaxTree.GetNodeAt<IdentifierExpression>(location.Line, location.Column - 1);
				if (astNode == null)
				{
					astNode = syntaxTree.GetNodeAt<MemberType>(location.Line, location.Column - 1);
				}
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("a", appendSemicolon: false);
				astNode = syntaxTree.GetNodeAt(location, (AstNode n) => (!(n is IdentifierExpression) && !(n is MemberReferenceExpression)) ? (n is CatchClause) : true);
			}
			if (astNode == null)
			{
				astNode = syntaxTree2.GetNodeAt<SwitchStatement>(location.Line, location.Column - 1);
				syntaxTree = syntaxTree2;
			}
			if (astNode == null)
			{
				Statement statement = syntaxTree2.GetNodeAt<BlockStatement>(location)?.Statements.LastOrDefault();
				ForStatement forStatement = (statement != null) ? (statement.PrevSibling as ForStatement) : null;
				if (forStatement != null && forStatement.EmbeddedStatement.IsNull)
				{
					astNode = forStatement;
					IdentifierExpression identifierExpression = new IdentifierExpression("stub");
					forStatement.EmbeddedStatement = new BlockStatement
					{
						Statements = 
						{
							(Statement)new ExpressionStatement(identifierExpression)
						}
					};
					astNode = identifierExpression;
					syntaxTree = syntaxTree2;
				}
			}
			if (astNode == null)
			{
				ForeachStatement nodeAt = syntaxTree2.GetNodeAt<ForeachStatement>(location.Line, location.Column - 3);
				if (nodeAt != null && nodeAt.EmbeddedStatement.IsNull)
				{
					nodeAt.VariableNameToken = Identifier.Create("stub");
					astNode = nodeAt.VariableNameToken;
					syntaxTree = syntaxTree2;
				}
			}
			if (astNode == null)
			{
				astNode = syntaxTree2.GetNodeAt<VariableInitializer>(location.Line, location.Column - 1);
				syntaxTree = syntaxTree2;
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub(">", appendSemicolon: false, "{}");
				astNode = syntaxTree.GetNodeAt<TypeParameterDeclaration>(location.Line, location.Column - 1);
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("> ()", appendSemicolon: false, "{}");
				astNode = syntaxTree.GetNodeAt<TypeParameterDeclaration>(location.Line, location.Column - 1);
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("a", appendSemicolon: false);
				astNode = syntaxTree.GetNodeAt<AnonymousTypeCreateExpression>(location.Line, location.Column);
				if (astNode != null)
				{
					astNode = (syntaxTree.GetNodeAt<Expression>(location.Line, location.Column) ?? astNode);
				}
				if (astNode == null)
				{
					astNode = syntaxTree.GetNodeAt<AstType>(location.Line, location.Column);
				}
			}
			if (astNode == null)
			{
				syntaxTree = ParseStub("foo) => {}", appendSemicolon: false);
				astNode = syntaxTree.GetNodeAt<ParameterDeclaration>(location.Line, location.Column);
			}
			if (astNode == null)
			{
				return null;
			}
			return new ExpressionResult(astNode, syntaxTree);
		}

		private ExpressionResult GetExpressionAt(int offset)
		{
			CSharpParser cSharpParser = new CSharpParser();
			Tuple<string, TextLocation> memberTextToCaret = GetMemberTextToCaret();
			int closingBrackets = 0;
			int generatedLines = 0;
			StringBuilder stringBuilder = CreateWrapper("a;", appendSemicolon: false, "", memberTextToCaret.Item1, memberTextToCaret.Item2, ref closingBrackets, ref generatedLines);
			SyntaxTree syntaxTree = cSharpParser.Parse(stringBuilder.ToString());
			TextLocation location = document.GetLocation(offset);
			TextLocation location2 = new TextLocation(location.Line - memberTextToCaret.Item2.Line + generatedLines + 1, location.Column);
			AstNode nodeAt = syntaxTree.GetNodeAt(location2, (AstNode n) => (!(n is Expression)) ? (n is VariableDeclarationStatement) : true);
			if (nodeAt == null)
			{
				return null;
			}
			return new ExpressionResult(nodeAt, syntaxTree);
		}

		private ExpressionResult GetNewExpressionAt(int offset)
		{
			CSharpParser cSharpParser = new CSharpParser();
			Tuple<string, TextLocation> memberTextToCaret = GetMemberTextToCaret();
			int closingBrackets = 0;
			int generatedLines = 0;
			StringBuilder stringBuilder = CreateWrapper("a ();", appendSemicolon: false, "", memberTextToCaret.Item1, memberTextToCaret.Item2, ref closingBrackets, ref generatedLines);
			SyntaxTree syntaxTree = cSharpParser.Parse(stringBuilder.ToString());
			TextLocation location = document.GetLocation(offset);
			TextLocation location2 = new TextLocation(location.Line - memberTextToCaret.Item2.Line + generatedLines + 1, location.Column);
			AstNode nodeAt = syntaxTree.GetNodeAt(location2, (AstNode n) => n is Expression);
			if (nodeAt == null)
			{
				stringBuilder = CreateWrapper("a ()", appendSemicolon: false, "", memberTextToCaret.Item1, memberTextToCaret.Item2, ref closingBrackets, ref generatedLines);
				syntaxTree = cSharpParser.Parse(stringBuilder.ToString());
				nodeAt = syntaxTree.GetNodeAt(location2, (AstNode n) => n is Expression);
				if (nodeAt == null)
				{
					return null;
				}
			}
			return new ExpressionResult(nodeAt, syntaxTree);
		}

		private string GetPreviousToken(ref int i, bool allowLineChange)
		{
			if (i <= 0)
			{
				return null;
			}
			char charAt;
			do
			{
				charAt = document.GetCharAt(--i);
			}
			while (i > 0 && char.IsWhiteSpace(charAt) && (allowLineChange || charAt != '\n'));
			if (i == 0)
			{
				return null;
			}
			if (!char.IsLetterOrDigit(charAt))
			{
				return new string(charAt, 1);
			}
			int num = i + 1;
			do
			{
				charAt = document.GetCharAt(i - 1);
				if (!char.IsLetterOrDigit(charAt) && charAt != '_')
				{
					break;
				}
				i--;
			}
			while (i > 0);
			return document.GetText(i, num - i);
		}

		private IEnumerable<ICompletionData> GetDirectiveCompletionData()
		{
			yield return factory.CreateLiteralCompletionData("if");
			yield return factory.CreateLiteralCompletionData("else");
			yield return factory.CreateLiteralCompletionData("elif");
			yield return factory.CreateLiteralCompletionData("endif");
			yield return factory.CreateLiteralCompletionData("define");
			yield return factory.CreateLiteralCompletionData("undef");
			yield return factory.CreateLiteralCompletionData("warning");
			yield return factory.CreateLiteralCompletionData("error");
			yield return factory.CreateLiteralCompletionData("pragma");
			yield return factory.CreateLiteralCompletionData("line");
			yield return factory.CreateLiteralCompletionData("line hidden");
			yield return factory.CreateLiteralCompletionData("line default");
			yield return factory.CreateLiteralCompletionData("region");
			yield return factory.CreateLiteralCompletionData("endregion");
		}

		private string GetLastClosingXmlCommentTag()
		{
			IDocumentLine documentLine = document.GetLineByNumber(location.Line);
			string text;
			int num;
			while (true)
			{
				text = document.GetText(documentLine);
				if (!text.Trim().StartsWith("///", StringComparison.Ordinal))
				{
					return null;
				}
				num = Math.Min(location.Column - 1, text.Length - 1) - 1;
				while (num > 0 && text[num] != '<')
				{
					num--;
					if (text[num] == '/')
					{
						num = -1;
						break;
					}
				}
				if (num >= 0 || documentLine.PreviousLine == null)
				{
					break;
				}
				documentLine = documentLine.PreviousLine;
			}
			if (num >= 0)
			{
				int i;
				for (i = num; i + 1 < text.Length && text[i] != '>' && !char.IsWhiteSpace(text[i]); i++)
				{
				}
				string text2 = (i - num - 1 > 0) ? text.Substring(num + 1, i - num - 1) : null;
				if (!string.IsNullOrEmpty(text2) && commentTags.IndexOf(text2) >= 0)
				{
					return text2;
				}
			}
			return null;
		}

		private IEnumerable<ICompletionData> GetXmlDocumentationCompletionData()
		{
			string lastClosingXmlCommentTag = GetLastClosingXmlCommentTag();
			if (lastClosingXmlCommentTag != null)
			{
				yield return factory.CreateLiteralCompletionData("/" + lastClosingXmlCommentTag + ">");
			}
			yield return factory.CreateXmlDocCompletionData("c", "Set text in a code-like font");
			yield return factory.CreateXmlDocCompletionData("code", "Set one or more lines of source code or program output");
			yield return factory.CreateXmlDocCompletionData("example", "Indicate an example");
			yield return factory.CreateXmlDocCompletionData("exception", "Identifies the exceptions a method can throw", "exception cref=\"|\"></exception");
			yield return factory.CreateXmlDocCompletionData("include", "Includes comments from a external file", "include file=\"|\" path=\"\"");
			yield return factory.CreateXmlDocCompletionData("inheritdoc", "Inherit documentation from a base class or interface", "inheritdoc/");
			yield return factory.CreateXmlDocCompletionData("list", "Create a list or table", "list type=\"|\"");
			yield return factory.CreateXmlDocCompletionData("listheader", "Define the heading row");
			yield return factory.CreateXmlDocCompletionData("item", "Defines list or table item");
			yield return factory.CreateXmlDocCompletionData("term", "A term to define");
			yield return factory.CreateXmlDocCompletionData("description", "Describes a list item");
			yield return factory.CreateXmlDocCompletionData("para", "Permit structure to be added to text");
			yield return factory.CreateXmlDocCompletionData("param", "Describe a parameter for a method or constructor", "param name=\"|\"");
			yield return factory.CreateXmlDocCompletionData("paramref", "Identify that a word is a parameter name", "paramref name=\"|\"/");
			yield return factory.CreateXmlDocCompletionData("permission", "Document the security accessibility of a member", "permission cref=\"|\"");
			yield return factory.CreateXmlDocCompletionData("remarks", "Describe a type");
			yield return factory.CreateXmlDocCompletionData("returns", "Describe the return value of a method");
			yield return factory.CreateXmlDocCompletionData("see", "Specify a link", "see cref=\"|\"/");
			yield return factory.CreateXmlDocCompletionData("seealso", "Generate a See Also entry", "seealso cref=\"|\"/");
			yield return factory.CreateXmlDocCompletionData("summary", "Describe a member of a type");
			yield return factory.CreateXmlDocCompletionData("typeparam", "Describe a type parameter for a generic type or method");
			yield return factory.CreateXmlDocCompletionData("typeparamref", "Identify that a word is a type parameter name");
			yield return factory.CreateXmlDocCompletionData("value", "Describe a property");
		}
	}
}
