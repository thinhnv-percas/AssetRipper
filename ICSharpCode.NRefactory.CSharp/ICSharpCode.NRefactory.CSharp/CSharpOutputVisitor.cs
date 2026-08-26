using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class CSharpOutputVisitor : IAstVisitor
{
	private struct MethodRefs
	{
		public object MethodReference;

		public object AwaitReference;

		public static MethodRefs Create()
		{
			return new MethodRefs
			{
				MethodReference = new object(),
				AwaitReference = new object()
			};
		}
	}

	private struct BraceHelper
	{
		private readonly CSharpOutputVisitor owner;

		private readonly CodeBracesRangeFlags flags;

		private int leftStart;

		private int leftEnd;

		private BraceHelper(CSharpOutputVisitor owner, CodeBracesRangeFlags flags)
		{
			this.owner = owner;
			leftStart = owner.writer.GetLocation() ?? 0;
			leftEnd = 0;
			this.flags = flags;
		}

		public static BraceHelper LeftParen(CSharpOutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken(Roles.LPar, BoxedTextColor.Punctuation);
			result.leftEnd = owner.writer.GetLocation() ?? 0;
			return result;
		}

		public void RightParen()
		{
			int rightStart = owner.writer.GetLocation() ?? 0;
			owner.WriteToken(Roles.RPar, BoxedTextColor.Punctuation);
			int rightEnd = owner.writer.GetLocation() ?? 0;
			if (flags != CodeBracesRangeFlags.BraceKind_None)
			{
				owner.writer.AddBracePair(leftStart, leftEnd, rightStart, rightEnd, flags);
			}
		}

		public static BraceHelper LeftChevron(CSharpOutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken(Roles.LChevron, BoxedTextColor.Punctuation);
			result.leftEnd = owner.writer.GetLocation() ?? 0;
			return result;
		}

		public void RightChevron()
		{
			int rightStart = owner.writer.GetLocation() ?? 0;
			owner.WriteToken(Roles.RChevron, BoxedTextColor.Punctuation);
			int rightEnd = owner.writer.GetLocation() ?? 0;
			if (flags != CodeBracesRangeFlags.BraceKind_None)
			{
				owner.writer.AddBracePair(leftStart, leftEnd, rightStart, rightEnd, flags);
			}
		}

		public static BraceHelper LeftBrace(CSharpOutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken(Roles.LBrace, BoxedTextColor.Punctuation);
			result.leftEnd = owner.writer.GetLocation() ?? 0;
			return result;
		}

		public void RightBrace()
		{
			int num = owner.writer.GetLocation() ?? 0;
			owner.lastBraceOffset = num;
			owner.WriteToken(Roles.RBrace, BoxedTextColor.Punctuation);
			int rightEnd = owner.writer.GetLocation() ?? 0;
			if (flags != CodeBracesRangeFlags.BraceKind_None)
			{
				owner.writer.AddBracePair(leftStart, leftEnd, num, rightEnd, flags);
			}
		}

		public static BraceHelper LeftBracket(CSharpOutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken(Roles.LBracket, BoxedTextColor.Punctuation);
			result.leftEnd = owner.writer.GetLocation() ?? 0;
			return result;
		}

		public void RightBracket()
		{
			int rightStart = owner.writer.GetLocation() ?? 0;
			owner.WriteToken(Roles.RBracket, BoxedTextColor.Punctuation);
			int rightEnd = owner.writer.GetLocation() ?? 0;
			if (flags != CodeBracesRangeFlags.BraceKind_None)
			{
				owner.writer.AddBracePair(leftStart, leftEnd, rightStart, rightEnd, flags);
			}
		}
	}

	protected readonly TokenWriter writer;

	protected readonly CSharpFormattingOptions policy;

	protected readonly Stack<AstNode> containerStack = new Stack<AstNode>();

	private CancellationToken cancellationToken;

	private const int CANCEL_CHECK_LOOP_COUNT = 100;

	private int lastBraceOffset;

	private int lastDeclarationOffset;

	private MethodRefs currentMethodRefs;

	private object currentIfReference;

	private object currentLoopReference;

	private object currentSwitchReference;

	private object currentTryReference;

	private object currentBreakReference;

	private int elseIfStart = -1;

	protected bool isAtStartOfLine = true;

	private bool HACK_disableSemicolonNewLine;

	private static readonly HashSet<string> unconditionalKeywords = new HashSet<string>
	{
		"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
		"class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum",
		"event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto",
		"if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
		"new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
		"readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
		"struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
		"unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
	};

	private static readonly HashSet<string> queryKeywords = new HashSet<string>
	{
		"from", "where", "join", "on", "equals", "into", "let", "orderby", "ascending", "descending",
		"select", "group", "by"
	};

	private int lastBlockStatementEndOffset;

	private void SaveDeclarationOffset()
	{
		lastDeclarationOffset = writer.GetLocation() ?? 0;
	}

	private void SaveDeclarationOffset(int offset)
	{
		lastDeclarationOffset = offset;
	}

	private static CodeBracesRangeFlags GetTypeBlockKind(AstNode node)
	{
		TypeDef typeDef = node.Annotation<TypeDef>();
		if (typeDef != null)
		{
			if (typeDef.IsInterface)
			{
				return CodeBracesRangeFlags.InterfaceBraces;
			}
			if (typeDef.IsValueType)
			{
				return CodeBracesRangeFlags.ValueTypeBraces;
			}
		}
		return CodeBracesRangeFlags.TypeBraces;
	}

	public CSharpOutputVisitor(TextWriter textWriter, CSharpFormattingOptions formattingPolicy)
	{
		if (textWriter == null)
		{
			throw new ArgumentNullException("textWriter");
		}
		if (formattingPolicy == null)
		{
			throw new ArgumentNullException("formattingPolicy");
		}
		writer = TokenWriter.Create(textWriter);
		policy = formattingPolicy;
		cancellationToken = default(CancellationToken);
	}

	public CSharpOutputVisitor(TokenWriter writer, CSharpFormattingOptions formattingPolicy, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (formattingPolicy == null)
		{
			throw new ArgumentNullException("formattingPolicy");
		}
		this.writer = new InsertSpecialsDecorator(new InsertRequiredSpacesDecorator(writer));
		policy = formattingPolicy;
		this.cancellationToken = cancellationToken;
	}

	protected virtual void StartNode(AstNode node)
	{
		containerStack.Push(node);
		writer.StartNode(node);
	}

	protected virtual void EndNode(AstNode node)
	{
		containerStack.Pop();
		writer.EndNode(node);
	}

	private void DebugStart(AstNode node, int? start = null)
	{
		writer.DebugStart(node, start);
	}

	private void DebugStartReference(AstNode node, TokenRole role, object reference, ref int keywordStartIndex)
	{
		int start = ((keywordStartIndex >= 0) ? keywordStartIndex : (writer.GetLocation() ?? 0));
		keywordStartIndex = -1;
		WriteKeyword(role, node);
		int end = writer.GetLocation() ?? 0;
		writer.AddHighlightedKeywordReference(reference, start, end);
	}

	private void DebugHidden(AstNode hiddenNode)
	{
		writer.DebugHidden(hiddenNode);
	}

	private void DebugExpression(AstNode node)
	{
		writer.DebugExpression(node);
	}

	private void SemicolonDebugEnd(AstNode node)
	{
		Semicolon(node);
	}

	private void DebugEnd(AstNode node, bool addSelf = true)
	{
		DebugEnd(node, null, addSelf);
	}

	private void DebugEnd(AstNode node, int? end, bool addSelf = true)
	{
		if (addSelf)
		{
			writer.DebugExpression(node);
		}
		writer.DebugEnd(node, end);
	}

	protected virtual void Comma(AstNode nextNode, bool noSpaceAfterComma = false)
	{
		Space(policy.SpaceBeforeBracketComma);
		writer.WriteTokenPunctuation(Roles.Comma, ",");
		Space(!noSpaceAfterComma && policy.SpaceAfterBracketComma);
	}

	protected virtual void OptionalComma(AstNode pos)
	{
		while (pos != null && pos.NodeType == NodeType.Whitespace)
		{
			pos = pos.NextSibling;
		}
		if (pos != null && pos.Role == Roles.Comma)
		{
			Comma(null, noSpaceAfterComma: true);
		}
	}

	protected virtual void OptionalSemicolon(AstNode pos)
	{
		while (pos != null && pos.NodeType == NodeType.Whitespace)
		{
			pos = pos.PrevSibling;
		}
		if (pos != null && pos.Role == Roles.Semicolon)
		{
			Semicolon();
		}
	}

	protected virtual void WriteCommaSeparatedList(IEnumerable<AstNode> list)
	{
		bool flag = true;
		int num = 0;
		foreach (AstNode item in list)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (flag)
			{
				flag = false;
			}
			else
			{
				Comma(item);
			}
			item.AcceptVisitor(this);
		}
	}

	protected virtual void WriteCommaSeparatedListInParenthesis(IEnumerable<AstNode> list, bool spaceWithin, CodeBracesRangeFlags flags)
	{
		BraceHelper braceHelper = BraceHelper.LeftParen(this, flags);
		if (list.Any())
		{
			Space(spaceWithin);
			WriteCommaSeparatedList(list);
			Space(spaceWithin);
		}
		braceHelper.RightParen();
	}

	protected virtual void WriteCommaSeparatedListInBrackets(IEnumerable<ParameterDeclaration> list, bool spaceWithin, CodeBracesRangeFlags flags)
	{
		BraceHelper braceHelper = BraceHelper.LeftBracket(this, flags);
		if (list.Any())
		{
			Space(spaceWithin);
			WriteCommaSeparatedList(list);
			Space(spaceWithin);
		}
		braceHelper.RightBracket();
	}

	protected virtual void WriteCommaSeparatedListInBrackets(IEnumerable<Expression> list, CodeBracesRangeFlags flags)
	{
		BraceHelper braceHelper = BraceHelper.LeftBracket(this, flags);
		if (list.Any())
		{
			Space(policy.SpacesWithinBrackets);
			WriteCommaSeparatedList(list);
			Space(policy.SpacesWithinBrackets);
		}
		braceHelper.RightBracket();
	}

	private void WriteKeywordReference(TokenRole tokenRole)
	{
		WriteKeywordReference(tokenRole, new object());
	}

	private void WriteKeywordReference(TokenRole tokenRole, object reference)
	{
		int start = writer.GetLocation() ?? 0;
		WriteKeyword(tokenRole);
		int end = writer.GetLocation() ?? 0;
		writer.AddHighlightedKeywordReference(reference, start, end);
	}

	private void WriteKeywordReferences(TokenRole tokenRole1, TokenRole tokenRole2, object reference)
	{
		int start = writer.GetLocation() ?? 0;
		WriteKeyword(tokenRole1);
		WriteKeyword(tokenRole2);
		int end = writer.GetLocation() ?? 0;
		writer.AddHighlightedKeywordReference(reference, start, end);
	}

	protected virtual void WriteKeyword(TokenRole tokenRole, AstNode node = null)
	{
		WriteKeywordIdentifier(tokenRole.Token, tokenRole, node, isId: false);
	}

	protected virtual void WriteKeyword(string token, Role tokenRole = null, AstNode node = null)
	{
		WriteKeywordIdentifier(token, tokenRole, node, isId: false);
	}

	private void WriteKeywordIdentifier(TokenRole tokenRole)
	{
		WriteKeywordIdentifier(tokenRole.Token, tokenRole);
	}

	private void WriteKeywordIdentifier(string token, Role tokenRole, AstNode node = null, bool isId = true)
	{
		if (node != null)
		{
			DebugStart(node);
		}
		if (isId)
		{
			writer.WriteIdentifier(Identifier.Create(token), BoxedTextColor.Keyword);
		}
		else
		{
			writer.WriteKeyword(tokenRole, token);
		}
		isAtStartOfLine = false;
	}

	protected virtual void WriteIdentifier(Identifier identifier)
	{
		WriteIdentifier(identifier, (identifier.AnnotationVT<TextColor>() ?? TextColor.Text).Box());
	}

	private void WriteIdentifier(Identifier identifier, object data)
	{
		writer.WriteIdentifier(identifier, data);
		isAtStartOfLine = false;
	}

	protected virtual void WriteIdentifier(string identifier, object data)
	{
		AstType.Create(identifier, data).AcceptVisitor(this);
		isAtStartOfLine = false;
	}

	protected void WriteTokenOperatorOrKeyword(string token, Role tokenRole)
	{
		object data = (char.IsLetter(token[0]) ? BoxedTextColor.Keyword : BoxedTextColor.Operator);
		WriteToken(token, tokenRole, data);
	}

	protected virtual void WriteToken(TokenRole tokenRole, object data)
	{
		WriteToken(tokenRole.Token, tokenRole, data);
	}

	protected virtual void WriteToken(string token, Role tokenRole, object data)
	{
		writer.WriteToken(tokenRole, token, data);
		isAtStartOfLine = false;
	}

	protected virtual void Semicolon(AstNode node = null)
	{
		Role role = containerStack.Peek().Role;
		if (role != ForStatement.InitializerRole && role != ForStatement.IteratorRole && role != UsingStatement.ResourceAcquisitionRole)
		{
			WriteToken(Roles.Semicolon, BoxedTextColor.Punctuation);
			if (node != null)
			{
				DebugEnd(node);
			}
			if (!HACK_disableSemicolonNewLine)
			{
				NewLine();
			}
		}
		else if (node != null)
		{
			DebugEnd(node);
		}
	}

	protected virtual void Space(bool addSpace = true)
	{
		if (addSpace)
		{
			writer.Space();
		}
	}

	protected virtual void NewLine()
	{
		writer.NewLine();
		isAtStartOfLine = true;
	}

	private BraceHelper OpenBrace(BraceStyle style, CodeBracesRangeFlags flags)
	{
		int? start;
		int? end;
		return OpenBrace(style, flags, out start, out end);
	}

	private void CloseBrace(BraceStyle style, BraceHelper braceHelper, bool saveDeclOffset)
	{
		CloseBrace(style, braceHelper, out var _, out var _, saveDeclOffset);
	}

	private BraceHelper OpenBrace(BraceStyle style, CodeBracesRangeFlags flags, out int? start, out int? end)
	{
		BraceHelper result;
		switch (style)
		{
		case BraceStyle.DoNotChange:
			if (!isAtStartOfLine)
			{
				writer.Space();
			}
			start = writer.GetLocation();
			result = BraceHelper.LeftBrace(this, flags);
			end = writer.GetLocation();
			if (!isAtStartOfLine)
			{
				writer.Space();
			}
			return result;
		case BraceStyle.EndOfLine:
		case BraceStyle.BannerStyle:
			if (!isAtStartOfLine)
			{
				writer.Space();
			}
			start = writer.GetLocation();
			result = BraceHelper.LeftBrace(this, flags);
			end = writer.GetLocation();
			break;
		case BraceStyle.EndOfLineWithoutSpace:
			start = writer.GetLocation();
			result = BraceHelper.LeftBrace(this, flags);
			end = writer.GetLocation();
			break;
		case BraceStyle.NextLine:
			if (!isAtStartOfLine)
			{
				NewLine();
			}
			start = writer.GetLocation();
			result = BraceHelper.LeftBrace(this, flags);
			end = writer.GetLocation();
			break;
		case BraceStyle.NextLineShifted:
			NewLine();
			writer.Indent();
			start = writer.GetLocation();
			result = BraceHelper.LeftBrace(this, flags);
			end = writer.GetLocation();
			NewLine();
			return result;
		case BraceStyle.NextLineShifted2:
			NewLine();
			writer.Indent();
			start = writer.GetLocation();
			result = BraceHelper.LeftBrace(this, flags);
			end = writer.GetLocation();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		writer.Indent();
		NewLine();
		return result;
	}

	private void CloseBrace(BraceStyle style, BraceHelper braceHelper, out int? start, out int? end, bool saveDeclOffset)
	{
		switch (style)
		{
		case BraceStyle.DoNotChange:
			writer.Space();
			start = writer.GetLocation();
			braceHelper.RightBrace();
			SaveDeclarationOffset();
			end = writer.GetLocation();
			isAtStartOfLine = false;
			break;
		case BraceStyle.EndOfLine:
		case BraceStyle.EndOfLineWithoutSpace:
		case BraceStyle.NextLine:
			writer.Unindent();
			start = writer.GetLocation();
			braceHelper.RightBrace();
			SaveDeclarationOffset();
			end = writer.GetLocation();
			isAtStartOfLine = false;
			break;
		case BraceStyle.NextLineShifted:
		case BraceStyle.BannerStyle:
			start = writer.GetLocation();
			braceHelper.RightBrace();
			SaveDeclarationOffset();
			end = writer.GetLocation();
			isAtStartOfLine = false;
			writer.Unindent();
			break;
		case BraceStyle.NextLineShifted2:
			writer.Unindent();
			start = writer.GetLocation();
			braceHelper.RightBrace();
			SaveDeclarationOffset();
			end = writer.GetLocation();
			isAtStartOfLine = false;
			writer.Unindent();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public static bool IsKeyword(string identifier, AstNode context)
	{
		if (unconditionalKeywords.Contains(identifier))
		{
			return true;
		}
		foreach (AstNode ancestor in context.Ancestors)
		{
			if (ancestor is QueryExpression && queryKeywords.Contains(identifier))
			{
				return true;
			}
			if (identifier == "await")
			{
				if (ancestor is LambdaExpression)
				{
					return ((LambdaExpression)ancestor).IsAsync;
				}
				if (ancestor is AnonymousMethodExpression)
				{
					return ((AnonymousMethodExpression)ancestor).IsAsync;
				}
				if (ancestor is EntityDeclaration)
				{
					return (((EntityDeclaration)ancestor).Modifiers & Modifiers.Async) == Modifiers.Async;
				}
			}
		}
		return false;
	}

	protected virtual void WriteTypeArguments(IEnumerable<AstType> typeArguments, CodeBracesRangeFlags flags)
	{
		if (typeArguments.Any())
		{
			BraceHelper braceHelper = BraceHelper.LeftChevron(this, flags);
			WriteCommaSeparatedList(typeArguments);
			braceHelper.RightChevron();
		}
	}

	public virtual void WriteTypeParameters(IEnumerable<TypeParameterDeclaration> typeParameters, CodeBracesRangeFlags flags)
	{
		if (typeParameters.Any())
		{
			BraceHelper braceHelper = BraceHelper.LeftChevron(this, flags);
			WriteCommaSeparatedList(typeParameters);
			braceHelper.RightChevron();
		}
	}

	protected virtual void WriteModifiers(IEnumerable<CSharpModifierToken> modifierTokens, AstNode nextNode)
	{
		int num = 0;
		foreach (CSharpModifierToken modifierToken in modifierTokens)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			modifierToken.AcceptVisitor(this);
			writer.Space();
		}
		if (nextNode != null)
		{
			writer.WriteSpecialsUpToNode(nextNode);
		}
	}

	protected virtual void WriteQualifiedIdentifier(IEnumerable<Identifier> identifiers)
	{
		bool flag = true;
		int num = 0;
		foreach (Identifier identifier in identifiers)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (flag)
			{
				flag = false;
			}
			else
			{
				writer.WriteTokenOperator(Roles.Dot, ".");
			}
			writer.WriteIdentifier(identifier, CSharpMetadataTextColorProvider.Instance.GetColor(identifier.Annotation<object>()));
		}
	}

	protected virtual void WriteEmbeddedStatement(Statement embeddedStatement)
	{
		if (embeddedStatement.IsNull)
		{
			NewLine();
			return;
		}
		if (embeddedStatement is BlockStatement blockStatement)
		{
			VisitBlockStatement(blockStatement);
			return;
		}
		NewLine();
		writer.Indent();
		embeddedStatement.AcceptVisitor(this);
		writer.Unindent();
	}

	protected virtual void WriteMethodBody(BlockStatement body)
	{
		if (body.IsNull)
		{
			SaveDeclarationOffset();
			Semicolon();
		}
		else
		{
			VisitBlockStatement(body);
			SaveDeclarationOffset(lastBlockStatementEndOffset);
		}
	}

	protected virtual void WriteAttributes(IEnumerable<AttributeSection> attributes)
	{
		int num = 0;
		foreach (AttributeSection attribute in attributes)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			attribute.AcceptVisitor(this);
		}
	}

	protected virtual void WritePrivateImplementationType(AstType privateImplementationType)
	{
		if (!privateImplementationType.IsNull)
		{
			privateImplementationType.AcceptVisitor(this);
			WriteToken(Roles.Dot, BoxedTextColor.Operator);
		}
	}

	public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
	{
		DebugExpression(anonymousMethodExpression);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		StartNode(anonymousMethodExpression);
		MethodDebugInfoBuilder methodDebugInfoBuilder = anonymousMethodExpression.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		if (anonymousMethodExpression.IsAsync)
		{
			int start = writer.GetLocation() ?? 0;
			WriteKeyword(AnonymousMethodExpression.AsyncModifierRole);
			writer.AddHighlightedKeywordReference(currentMethodRefs.AwaitReference, start, writer.GetLocation() ?? 0);
			Space();
		}
		WriteKeyword(AnonymousMethodExpression.DelegateKeywordRole);
		if (anonymousMethodExpression.HasParameterList)
		{
			Space(policy.SpaceBeforeMethodDeclarationParentheses);
			WriteCommaSeparatedListInParenthesis(anonymousMethodExpression.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		anonymousMethodExpression.Body.AcceptVisitor(this);
		if (methodDebugInfoBuilder != null && !methodDebugInfoBuilder.EndPosition.HasValue)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(anonymousMethodExpression);
	}

	public virtual void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
	{
		DebugExpression(undocumentedExpression);
		StartNode(undocumentedExpression);
		switch (undocumentedExpression.UndocumentedExpressionType)
		{
		case UndocumentedExpressionType.ArgListAccess:
		case UndocumentedExpressionType.ArgList:
			WriteKeyword(UndocumentedExpression.ArglistKeywordRole);
			break;
		case UndocumentedExpressionType.MakeRef:
			WriteKeyword(UndocumentedExpression.MakerefKeywordRole);
			break;
		case UndocumentedExpressionType.RefType:
			WriteKeyword(UndocumentedExpression.ReftypeKeywordRole);
			break;
		case UndocumentedExpressionType.RefValue:
			WriteKeyword(UndocumentedExpression.RefvalueKeywordRole);
			break;
		}
		if (undocumentedExpression.Arguments.Count > 0)
		{
			Space(policy.SpaceBeforeMethodCallParentheses);
			WriteCommaSeparatedListInParenthesis(undocumentedExpression.Arguments, policy.SpaceWithinMethodCallParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		EndNode(undocumentedExpression);
	}

	public virtual void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
	{
		DebugExpression(arrayCreateExpression);
		StartNode(arrayCreateExpression);
		WriteKeyword(ArrayCreateExpression.NewKeywordRole);
		arrayCreateExpression.Type.AcceptVisitor(this);
		if (arrayCreateExpression.Arguments.Count > 0)
		{
			WriteCommaSeparatedListInBrackets(arrayCreateExpression.Arguments, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		}
		int num = 0;
		foreach (ArraySpecifier additionalArraySpecifier in arrayCreateExpression.AdditionalArraySpecifiers)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			additionalArraySpecifier.AcceptVisitor(this);
		}
		arrayCreateExpression.Initializer.AcceptVisitor(this);
		EndNode(arrayCreateExpression);
	}

	public virtual void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
	{
		DebugExpression(arrayInitializerExpression);
		StartNode(arrayInitializerExpression);
		if (arrayInitializerExpression.Elements.Count == 1 && IsObjectOrCollectionInitializer(arrayInitializerExpression.Parent) && !CanBeConfusedWithObjectInitializer(arrayInitializerExpression.Elements.Single()) && arrayInitializerExpression.LBraceToken.IsNull)
		{
			arrayInitializerExpression.Elements.Single().AcceptVisitor(this);
		}
		else
		{
			PrintInitializerElements(arrayInitializerExpression.Elements, CodeBracesRangeFlags.OtherBlockBraces);
		}
		EndNode(arrayInitializerExpression);
	}

	protected bool CanBeConfusedWithObjectInitializer(Expression expr)
	{
		if (expr is AssignmentExpression assignmentExpression)
		{
			return assignmentExpression.Operator == AssignmentOperatorType.Assign;
		}
		return false;
	}

	protected bool IsObjectOrCollectionInitializer(AstNode node)
	{
		if (!(node is ArrayInitializerExpression))
		{
			return false;
		}
		if (node.Parent is ObjectCreateExpression)
		{
			return node.Role == ObjectCreateExpression.InitializerRole;
		}
		if (node.Parent is NamedExpression)
		{
			return node.Role == Roles.Expression;
		}
		return false;
	}

	protected virtual void PrintInitializerElements(AstNodeCollection<Expression> elements, CodeBracesRangeFlags flags)
	{
		BraceStyle style = ((policy.ArrayInitializerWrapping != Wrapping.WrapAlways) ? BraceStyle.EndOfLine : BraceStyle.NextLine);
		BraceHelper braceHelper = OpenBrace(style, flags);
		bool flag = true;
		AstNode astNode = null;
		int num = 0;
		foreach (Expression element in elements)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (flag)
			{
				flag = false;
			}
			else
			{
				Comma(element, noSpaceAfterComma: true);
				NewLine();
			}
			astNode = element;
			element.AcceptVisitor(this);
		}
		if (astNode != null)
		{
			OptionalComma(astNode.NextSibling);
		}
		NewLine();
		CloseBrace(style, braceHelper, saveDeclOffset: false);
	}

	public virtual void VisitAsExpression(AsExpression asExpression)
	{
		DebugExpression(asExpression);
		StartNode(asExpression);
		asExpression.Expression.AcceptVisitor(this);
		Space();
		WriteKeyword(AsExpression.AsKeywordRole);
		Space();
		asExpression.Type.AcceptVisitor(this);
		EndNode(asExpression);
	}

	public virtual void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
	{
		DebugExpression(assignmentExpression);
		StartNode(assignmentExpression);
		assignmentExpression.Left.AcceptVisitor(this);
		Space(policy.SpaceAroundAssignment);
		WriteToken(AssignmentExpression.GetOperatorRole(assignmentExpression.Operator), BoxedTextColor.Operator);
		Space(policy.SpaceAroundAssignment);
		assignmentExpression.Right.AcceptVisitor(this);
		EndNode(assignmentExpression);
	}

	public virtual void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
	{
		DebugExpression(baseReferenceExpression);
		StartNode(baseReferenceExpression);
		WriteKeyword("base", baseReferenceExpression.Role);
		EndNode(baseReferenceExpression);
	}

	public virtual void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
	{
		DebugExpression(binaryOperatorExpression);
		StartNode(binaryOperatorExpression);
		binaryOperatorExpression.Left.AcceptVisitor(this);
		bool addSpace;
		switch (binaryOperatorExpression.Operator)
		{
		case BinaryOperatorType.BitwiseAnd:
		case BinaryOperatorType.BitwiseOr:
		case BinaryOperatorType.ExclusiveOr:
			addSpace = policy.SpaceAroundBitwiseOperator;
			break;
		case BinaryOperatorType.ConditionalAnd:
		case BinaryOperatorType.ConditionalOr:
			addSpace = policy.SpaceAroundLogicalOperator;
			break;
		case BinaryOperatorType.GreaterThan:
		case BinaryOperatorType.GreaterThanOrEqual:
		case BinaryOperatorType.LessThan:
		case BinaryOperatorType.LessThanOrEqual:
			addSpace = policy.SpaceAroundRelationalOperator;
			break;
		case BinaryOperatorType.Equality:
		case BinaryOperatorType.InEquality:
			addSpace = policy.SpaceAroundEqualityOperator;
			break;
		case BinaryOperatorType.Add:
		case BinaryOperatorType.Subtract:
			addSpace = policy.SpaceAroundAdditiveOperator;
			break;
		case BinaryOperatorType.Multiply:
		case BinaryOperatorType.Divide:
		case BinaryOperatorType.Modulus:
			addSpace = policy.SpaceAroundMultiplicativeOperator;
			break;
		case BinaryOperatorType.ShiftLeft:
		case BinaryOperatorType.ShiftRight:
			addSpace = policy.SpaceAroundShiftOperator;
			break;
		case BinaryOperatorType.NullCoalescing:
			addSpace = true;
			break;
		default:
			throw new NotSupportedException("Invalid value for BinaryOperatorType");
		}
		Space(addSpace);
		WriteToken(BinaryOperatorExpression.GetOperatorRole(binaryOperatorExpression.Operator), BoxedTextColor.Operator);
		Space(addSpace);
		binaryOperatorExpression.Right.AcceptVisitor(this);
		EndNode(binaryOperatorExpression);
	}

	public virtual void VisitCastExpression(CastExpression castExpression)
	{
		DebugExpression(castExpression);
		StartNode(castExpression);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinCastParentheses);
		castExpression.Type.AcceptVisitor(this);
		Space(policy.SpacesWithinCastParentheses);
		braceHelper.RightParen();
		Space(policy.SpaceAfterTypecast);
		castExpression.Expression.AcceptVisitor(this);
		EndNode(castExpression);
	}

	public virtual void VisitCheckedExpression(CheckedExpression checkedExpression)
	{
		DebugExpression(checkedExpression);
		StartNode(checkedExpression);
		WriteKeywordReference(CheckedExpression.CheckedKeywordRole);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinCheckedExpressionParantheses);
		checkedExpression.Expression.AcceptVisitor(this);
		Space(policy.SpacesWithinCheckedExpressionParantheses);
		braceHelper.RightParen();
		EndNode(checkedExpression);
	}

	public virtual void VisitConditionalExpression(ConditionalExpression conditionalExpression)
	{
		DebugExpression(conditionalExpression);
		StartNode(conditionalExpression);
		if (conditionalExpression.TrueExpression is DirectionExpression)
		{
			WriteKeyword(DirectionExpression.RefKeywordRole);
			Space();
		}
		conditionalExpression.Condition.AcceptVisitor(this);
		Space(policy.SpaceBeforeConditionalOperatorCondition);
		WriteToken(ConditionalExpression.QuestionMarkRole, BoxedTextColor.Operator);
		Space(policy.SpaceAfterConditionalOperatorCondition);
		conditionalExpression.TrueExpression.AcceptVisitor(this);
		Space(policy.SpaceBeforeConditionalOperatorSeparator);
		WriteToken(ConditionalExpression.ColonRole, BoxedTextColor.Operator);
		Space(policy.SpaceAfterConditionalOperatorSeparator);
		conditionalExpression.FalseExpression.AcceptVisitor(this);
		EndNode(conditionalExpression);
	}

	public virtual void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
	{
		DebugExpression(defaultValueExpression);
		StartNode(defaultValueExpression);
		WriteKeyword(DefaultValueExpression.DefaultKeywordRole);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinTypeOfParentheses);
		defaultValueExpression.Type.AcceptVisitor(this);
		Space(policy.SpacesWithinTypeOfParentheses);
		braceHelper.RightParen();
		EndNode(defaultValueExpression);
	}

	public virtual void VisitDirectionExpression(DirectionExpression directionExpression)
	{
		DebugExpression(directionExpression);
		StartNode(directionExpression);
		switch (directionExpression.FieldDirection)
		{
		case FieldDirection.Out:
			WriteKeyword(DirectionExpression.OutKeywordRole);
			Space();
			break;
		case FieldDirection.Ref:
			WriteKeyword(DirectionExpression.RefKeywordRole);
			Space();
			break;
		default:
			throw new NotSupportedException("Invalid value for FieldDirection");
		case FieldDirection.In:
			break;
		}
		directionExpression.Expression.AcceptVisitor(this);
		EndNode(directionExpression);
	}

	public virtual void VisitIdentifierExpression(IdentifierExpression identifierExpression)
	{
		DebugExpression(identifierExpression);
		StartNode(identifierExpression);
		WriteIdentifier(identifierExpression.IdentifierToken, CSharpMetadataTextColorProvider.Instance.GetColor(identifierExpression.IdentifierToken.Annotation<object>()));
		WriteTypeArguments(identifierExpression.TypeArguments, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		EndNode(identifierExpression);
	}

	public virtual void VisitIndexerExpression(IndexerExpression indexerExpression)
	{
		DebugExpression(indexerExpression);
		StartNode(indexerExpression);
		indexerExpression.Target.AcceptVisitor(this);
		Space(policy.SpaceBeforeMethodCallParentheses);
		WriteCommaSeparatedListInBrackets(indexerExpression.Arguments, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		EndNode(indexerExpression);
	}

	public virtual void VisitInvocationExpression(InvocationExpression invocationExpression)
	{
		DebugExpression(invocationExpression);
		StartNode(invocationExpression);
		invocationExpression.Target.AcceptVisitor(this);
		Space(policy.SpaceBeforeMethodCallParentheses);
		WriteCommaSeparatedListInParenthesis(invocationExpression.Arguments, policy.SpaceWithinMethodCallParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		EndNode(invocationExpression);
	}

	public virtual void VisitIsExpression(IsExpression isExpression)
	{
		DebugExpression(isExpression);
		StartNode(isExpression);
		isExpression.Expression.AcceptVisitor(this);
		Space();
		WriteKeyword(IsExpression.IsKeywordRole);
		isExpression.Type.AcceptVisitor(this);
		EndNode(isExpression);
	}

	public virtual void VisitLambdaExpression(LambdaExpression lambdaExpression)
	{
		DebugExpression(lambdaExpression);
		StartNode(lambdaExpression);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		MethodDebugInfoBuilder methodDebugInfoBuilder = lambdaExpression.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		if (lambdaExpression.IsAsync)
		{
			int start = writer.GetLocation() ?? 0;
			WriteKeyword(LambdaExpression.AsyncModifierRole);
			writer.AddHighlightedKeywordReference(currentMethodRefs.AwaitReference, start, writer.GetLocation() ?? 0);
			Space();
		}
		if (LambdaNeedsParenthesis(lambdaExpression))
		{
			WriteCommaSeparatedListInParenthesis(lambdaExpression.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		else
		{
			lambdaExpression.Parameters.Single().AcceptVisitor(this);
		}
		Space();
		WriteToken(LambdaExpression.ArrowRole, BoxedTextColor.Operator);
		Space();
		StartNode(lambdaExpression.Body);
		DebugStart(lambdaExpression.Body);
		lambdaExpression.Body.AcceptVisitor(this);
		DebugEnd(lambdaExpression.Body);
		EndNode(lambdaExpression.Body);
		if (methodDebugInfoBuilder != null && !methodDebugInfoBuilder.EndPosition.HasValue)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(lambdaExpression);
	}

	protected bool LambdaNeedsParenthesis(LambdaExpression lambdaExpression)
	{
		if (lambdaExpression.Parameters.Count != 1)
		{
			return true;
		}
		ParameterDeclaration parameterDeclaration = lambdaExpression.Parameters.Single();
		if (parameterDeclaration.Type.IsNull)
		{
			return parameterDeclaration.ParameterModifier != ParameterModifier.None;
		}
		return true;
	}

	public virtual void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
	{
		DebugExpression(memberReferenceExpression);
		StartNode(memberReferenceExpression);
		memberReferenceExpression.Target.AcceptVisitor(this);
		WriteToken(Roles.Dot, BoxedTextColor.Operator);
		WriteIdentifier(memberReferenceExpression.MemberNameToken, CSharpMetadataTextColorProvider.Instance.GetColor(memberReferenceExpression.MemberNameToken.Annotation<object>() ?? memberReferenceExpression.Annotation<object>()));
		WriteTypeArguments(memberReferenceExpression.TypeArguments, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		EndNode(memberReferenceExpression);
	}

	public virtual void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
	{
		DebugExpression(namedArgumentExpression);
		StartNode(namedArgumentExpression);
		WriteIdentifier(namedArgumentExpression.NameToken);
		WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		Space();
		namedArgumentExpression.Expression.AcceptVisitor(this);
		EndNode(namedArgumentExpression);
	}

	public virtual void VisitNamedExpression(NamedExpression namedExpression)
	{
		DebugExpression(namedExpression);
		StartNode(namedExpression);
		WriteIdentifier(namedExpression.NameToken);
		Space();
		WriteToken(Roles.Assign, BoxedTextColor.Operator);
		Space();
		namedExpression.Expression.AcceptVisitor(this);
		EndNode(namedExpression);
	}

	public virtual void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
	{
		DebugExpression(nullReferenceExpression);
		StartNode(nullReferenceExpression);
		writer.WritePrimitiveValue(null);
		EndNode(nullReferenceExpression);
	}

	public virtual void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
	{
		DebugExpression(objectCreateExpression);
		StartNode(objectCreateExpression);
		WriteKeyword(ObjectCreateExpression.NewKeywordRole);
		objectCreateExpression.Type.AcceptVisitor(this);
		bool flag = objectCreateExpression.Arguments.Any() || objectCreateExpression.Initializer.IsNull;
		if (!objectCreateExpression.LParToken.IsNull)
		{
			flag = true;
		}
		if (flag)
		{
			Space(policy.SpaceBeforeMethodCallParentheses);
			WriteCommaSeparatedListInParenthesis(objectCreateExpression.Arguments, policy.SpaceWithinMethodCallParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		objectCreateExpression.Initializer.AcceptVisitor(this);
		EndNode(objectCreateExpression);
	}

	public virtual void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
	{
		DebugExpression(anonymousTypeCreateExpression);
		StartNode(anonymousTypeCreateExpression);
		WriteKeyword(AnonymousTypeCreateExpression.NewKeywordRole);
		PrintInitializerElements(anonymousTypeCreateExpression.Initializers, CodeBracesRangeFlags.OtherBlockBraces);
		EndNode(anonymousTypeCreateExpression);
	}

	public virtual void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
	{
		DebugExpression(parenthesizedExpression);
		StartNode(parenthesizedExpression);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinParentheses);
		parenthesizedExpression.Expression.AcceptVisitor(this);
		Space(policy.SpacesWithinParentheses);
		braceHelper.RightParen();
		EndNode(parenthesizedExpression);
	}

	public virtual void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
	{
		DebugExpression(pointerReferenceExpression);
		StartNode(pointerReferenceExpression);
		pointerReferenceExpression.Target.AcceptVisitor(this);
		WriteToken(PointerReferenceExpression.ArrowRole, BoxedTextColor.Operator);
		WriteIdentifier(pointerReferenceExpression.MemberNameToken, CSharpMetadataTextColorProvider.Instance.GetColor(pointerReferenceExpression.MemberNameToken.Annotation<object>()));
		WriteTypeArguments(pointerReferenceExpression.TypeArguments, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		EndNode(pointerReferenceExpression);
	}

	public virtual void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
	{
		DebugExpression(primitiveExpression);
		StartNode(primitiveExpression);
		writer.WritePrimitiveValue(primitiveExpression.Value, BoxedTextColor.Text, primitiveExpression.UnsafeLiteralValue);
		EndNode(primitiveExpression);
	}

	public virtual void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
	{
		DebugExpression(sizeOfExpression);
		StartNode(sizeOfExpression);
		WriteKeyword(SizeOfExpression.SizeofKeywordRole);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinSizeOfParentheses);
		sizeOfExpression.Type.AcceptVisitor(this);
		Space(policy.SpacesWithinSizeOfParentheses);
		braceHelper.RightParen();
		EndNode(sizeOfExpression);
	}

	public virtual void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
	{
		DebugExpression(stackAllocExpression);
		StartNode(stackAllocExpression);
		WriteKeyword(StackAllocExpression.StackallocKeywordRole);
		stackAllocExpression.Type.AcceptVisitor(this);
		WriteCommaSeparatedListInBrackets(new Expression[1] { stackAllocExpression.CountExpression }, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		EndNode(stackAllocExpression);
	}

	public virtual void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
	{
		DebugExpression(thisReferenceExpression);
		StartNode(thisReferenceExpression);
		WriteKeyword("this", thisReferenceExpression.Role);
		EndNode(thisReferenceExpression);
	}

	public virtual void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
	{
		DebugExpression(typeOfExpression);
		StartNode(typeOfExpression);
		WriteKeyword(TypeOfExpression.TypeofKeywordRole);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinTypeOfParentheses);
		typeOfExpression.Type.AcceptVisitor(this);
		Space(policy.SpacesWithinTypeOfParentheses);
		braceHelper.RightParen();
		EndNode(typeOfExpression);
	}

	public virtual void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
	{
		DebugExpression(typeReferenceExpression);
		StartNode(typeReferenceExpression);
		typeReferenceExpression.Type.AcceptVisitor(this);
		EndNode(typeReferenceExpression);
	}

	public virtual void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
	{
		DebugExpression(unaryOperatorExpression);
		StartNode(unaryOperatorExpression);
		UnaryOperatorType unaryOperatorType = unaryOperatorExpression.Operator;
		TokenRole operatorRole = UnaryOperatorExpression.GetOperatorRole(unaryOperatorType);
		switch (unaryOperatorType)
		{
		case UnaryOperatorType.Await:
		{
			int start = writer.GetLocation() ?? 0;
			WriteKeyword(operatorRole);
			writer.AddHighlightedKeywordReference(currentMethodRefs.AwaitReference, start, writer.GetLocation() ?? 0);
			break;
		}
		default:
			WriteToken(operatorRole, BoxedTextColor.Operator);
			break;
		case UnaryOperatorType.PostIncrement:
		case UnaryOperatorType.PostDecrement:
			break;
		}
		unaryOperatorExpression.Expression.AcceptVisitor(this);
		if (unaryOperatorType == UnaryOperatorType.PostIncrement || unaryOperatorType == UnaryOperatorType.PostDecrement)
		{
			WriteToken(operatorRole, BoxedTextColor.Operator);
		}
		EndNode(unaryOperatorExpression);
	}

	public virtual void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
	{
		DebugExpression(uncheckedExpression);
		StartNode(uncheckedExpression);
		WriteKeywordReference(UncheckedExpression.UncheckedKeywordRole);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinCheckedExpressionParantheses);
		uncheckedExpression.Expression.AcceptVisitor(this);
		Space(policy.SpacesWithinCheckedExpressionParantheses);
		braceHelper.RightParen();
		EndNode(uncheckedExpression);
	}

	public virtual void VisitQueryExpression(QueryExpression queryExpression)
	{
		DebugExpression(queryExpression);
		StartNode(queryExpression);
		bool flag = queryExpression.Parent is QueryClause && !(queryExpression.Parent is QueryContinuationClause);
		if (flag)
		{
			writer.Indent();
			NewLine();
		}
		bool flag2 = true;
		int num = 0;
		foreach (QueryClause clause in queryExpression.Clauses)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (flag2)
			{
				flag2 = false;
			}
			else if (!(clause is QueryContinuationClause))
			{
				NewLine();
			}
			clause.AcceptVisitor(this);
		}
		if (flag)
		{
			writer.Unindent();
		}
		EndNode(queryExpression);
	}

	public virtual void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
	{
		DebugExpression(queryContinuationClause);
		StartNode(queryContinuationClause);
		queryContinuationClause.PrecedingQuery.AcceptVisitor(this);
		Space();
		WriteKeyword(QueryContinuationClause.IntoKeywordRole);
		Space();
		WriteIdentifier(queryContinuationClause.IdentifierToken);
		EndNode(queryContinuationClause);
	}

	public virtual void VisitQueryFromClause(QueryFromClause queryFromClause)
	{
		DebugExpression(queryFromClause);
		StartNode(queryFromClause);
		WriteKeyword(QueryFromClause.FromKeywordRole);
		queryFromClause.Type.AcceptVisitor(this);
		Space();
		WriteIdentifier(queryFromClause.IdentifierToken);
		Space();
		WriteKeyword(QueryFromClause.InKeywordRole);
		Space();
		queryFromClause.Expression.AcceptVisitor(this);
		EndNode(queryFromClause);
	}

	public virtual void VisitQueryLetClause(QueryLetClause queryLetClause)
	{
		DebugExpression(queryLetClause);
		StartNode(queryLetClause);
		WriteKeyword(QueryLetClause.LetKeywordRole);
		Space();
		WriteIdentifier(queryLetClause.IdentifierToken);
		Space(policy.SpaceAroundAssignment);
		WriteToken(Roles.Assign, BoxedTextColor.Operator);
		Space(policy.SpaceAroundAssignment);
		queryLetClause.Expression.AcceptVisitor(this);
		EndNode(queryLetClause);
	}

	public virtual void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
	{
		DebugExpression(queryWhereClause);
		StartNode(queryWhereClause);
		WriteKeyword(QueryWhereClause.WhereKeywordRole);
		Space();
		queryWhereClause.Condition.AcceptVisitor(this);
		EndNode(queryWhereClause);
	}

	public virtual void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
	{
		DebugExpression(queryJoinClause);
		StartNode(queryJoinClause);
		WriteKeyword(QueryJoinClause.JoinKeywordRole);
		queryJoinClause.Type.AcceptVisitor(this);
		Space();
		WriteIdentifier(queryJoinClause.JoinIdentifierToken, CSharpMetadataTextColorProvider.Instance.GetColor(queryJoinClause.JoinIdentifierToken.Annotation<object>()));
		Space();
		WriteKeyword(QueryJoinClause.InKeywordRole);
		Space();
		queryJoinClause.InExpression.AcceptVisitor(this);
		Space();
		WriteKeyword(QueryJoinClause.OnKeywordRole);
		Space();
		queryJoinClause.OnExpression.AcceptVisitor(this);
		Space();
		WriteKeyword(QueryJoinClause.EqualsKeywordRole);
		Space();
		queryJoinClause.EqualsExpression.AcceptVisitor(this);
		if (queryJoinClause.IsGroupJoin)
		{
			Space();
			WriteKeyword(QueryJoinClause.IntoKeywordRole);
			WriteIdentifier(queryJoinClause.IntoIdentifierToken, CSharpMetadataTextColorProvider.Instance.GetColor(queryJoinClause.IntoIdentifierToken.Annotation<object>()));
		}
		EndNode(queryJoinClause);
	}

	public virtual void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
	{
		DebugExpression(queryOrderClause);
		StartNode(queryOrderClause);
		WriteKeyword(QueryOrderClause.OrderbyKeywordRole);
		Space();
		WriteCommaSeparatedList(queryOrderClause.Orderings);
		EndNode(queryOrderClause);
	}

	public virtual void VisitQueryOrdering(QueryOrdering queryOrdering)
	{
		DebugExpression(queryOrdering);
		StartNode(queryOrdering);
		queryOrdering.Expression.AcceptVisitor(this);
		switch (queryOrdering.Direction)
		{
		case QueryOrderingDirection.Ascending:
			Space();
			WriteKeyword(QueryOrdering.AscendingKeywordRole);
			break;
		case QueryOrderingDirection.Descending:
			Space();
			WriteKeyword(QueryOrdering.DescendingKeywordRole);
			break;
		}
		EndNode(queryOrdering);
	}

	public virtual void VisitQuerySelectClause(QuerySelectClause querySelectClause)
	{
		DebugExpression(querySelectClause);
		StartNode(querySelectClause);
		WriteKeyword(QuerySelectClause.SelectKeywordRole);
		Space();
		querySelectClause.Expression.AcceptVisitor(this);
		EndNode(querySelectClause);
	}

	public virtual void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
	{
		DebugExpression(queryGroupClause);
		StartNode(queryGroupClause);
		WriteKeyword(QueryGroupClause.GroupKeywordRole);
		Space();
		queryGroupClause.Projection.AcceptVisitor(this);
		Space();
		WriteKeyword(QueryGroupClause.ByKeywordRole);
		Space();
		queryGroupClause.Key.AcceptVisitor(this);
		EndNode(queryGroupClause);
	}

	public virtual void VisitAttribute(Attribute attribute)
	{
		StartNode(attribute);
		attribute.Type.AcceptVisitor(this);
		if (attribute.Arguments.Count != 0 || !attribute.GetChildByRole(Roles.LPar).IsNull)
		{
			Space(policy.SpaceBeforeMethodCallParentheses);
			WriteCommaSeparatedListInParenthesis(attribute.Arguments, policy.SpaceWithinMethodCallParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		EndNode(attribute);
	}

	public virtual void VisitAttributeSection(AttributeSection attributeSection)
	{
		StartNode(attributeSection);
		BraceHelper braceHelper = BraceHelper.LeftBracket(this, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		if (!string.IsNullOrEmpty(attributeSection.AttributeTarget))
		{
			WriteKeyword(attributeSection.AttributeTarget, Roles.Identifier);
			WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
			Space();
		}
		WriteCommaSeparatedList(attributeSection.Attributes);
		braceHelper.RightBracket();
		if (attributeSection.Parent is ParameterDeclaration || attributeSection.Parent is TypeParameterDeclaration || (attributeSection.Parent is Accessor && HACK_disableSemicolonNewLine))
		{
			Space();
		}
		else
		{
			NewLine();
		}
		EndNode(attributeSection);
	}

	public virtual void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
	{
		StartNode(delegateDeclaration);
		WriteAttributes(delegateDeclaration.Attributes);
		WriteModifiers(delegateDeclaration.ModifierTokens, delegateDeclaration.ReturnType);
		WriteKeyword(Roles.DelegateKeyword);
		delegateDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WriteIdentifier(delegateDeclaration.NameToken);
		WriteTypeParameters(delegateDeclaration.TypeParameters, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		Space(policy.SpaceBeforeDelegateDeclarationParentheses);
		WriteCommaSeparatedListInParenthesis(delegateDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		int num = 0;
		foreach (Constraint constraint in delegateDeclaration.Constraints)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			constraint.AcceptVisitor(this);
		}
		SaveDeclarationOffset();
		Semicolon();
		EndNode(delegateDeclaration);
	}

	public virtual void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
	{
		StartNode(namespaceDeclaration);
		WriteKeyword(Roles.NamespaceKeyword);
		namespaceDeclaration.NamespaceName.AcceptVisitor(this);
		BraceHelper braceHelper = OpenBrace(policy.NamespaceBraceStyle, CodeBracesRangeFlags.NamespaceBraces);
		int num = 0;
		int num2 = -1;
		foreach (AstNode member in namespaceDeclaration.Members)
		{
			num2++;
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (num2 > 0)
			{
				writer.AddLineSeparator(Math.Max(lastBraceOffset, lastDeclarationOffset));
			}
			member.AcceptVisitor(this);
			MaybeNewLinesAfterUsings(member);
		}
		CloseBrace(policy.NamespaceBraceStyle, braceHelper, saveDeclOffset: true);
		OptionalSemicolon(namespaceDeclaration.LastChild);
		NewLine();
		EndNode(namespaceDeclaration);
	}

	public virtual void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
	{
		StartNode(typeDeclaration);
		WriteAttributes(typeDeclaration.Attributes);
		WriteModifiers(typeDeclaration.ModifierTokens, typeDeclaration.NameToken);
		BraceStyle style;
		switch (typeDeclaration.ClassType)
		{
		case ClassType.Enum:
			WriteKeyword(Roles.EnumKeyword);
			style = policy.EnumBraceStyle;
			break;
		case ClassType.Interface:
			WriteKeyword(Roles.InterfaceKeyword);
			style = policy.InterfaceBraceStyle;
			break;
		case ClassType.Struct:
			WriteKeyword(Roles.StructKeyword);
			style = policy.StructBraceStyle;
			break;
		default:
			WriteKeyword(Roles.ClassKeyword);
			style = policy.ClassBraceStyle;
			break;
		}
		WriteIdentifier(typeDeclaration.NameToken);
		WriteTypeParameters(typeDeclaration.TypeParameters, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		if (typeDeclaration.BaseTypes.Any())
		{
			Space();
			WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
			Space();
			WriteCommaSeparatedList(typeDeclaration.BaseTypes);
		}
		int num = 0;
		foreach (Constraint constraint in typeDeclaration.Constraints)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			constraint.AcceptVisitor(this);
		}
		BraceHelper braceHelper = OpenBrace(style, GetTypeBlockKind(typeDeclaration));
		if (typeDeclaration.ClassType == ClassType.Enum)
		{
			bool flag = true;
			AstNode astNode = null;
			num = 0;
			foreach (EntityDeclaration member in typeDeclaration.Members)
			{
				if (num-- <= 0)
				{
					cancellationToken.ThrowIfCancellationRequested();
					num = 100;
				}
				if (flag)
				{
					flag = false;
				}
				else
				{
					Comma(member, noSpaceAfterComma: true);
					NewLine();
				}
				astNode = member;
				member.AcceptVisitor(this);
			}
			if (astNode != null)
			{
				OptionalComma(astNode.NextSibling);
			}
			NewLine();
		}
		else
		{
			bool flag2 = true;
			num = 0;
			AstNode a = null;
			foreach (EntityDeclaration member2 in typeDeclaration.Members)
			{
				if (num-- <= 0)
				{
					cancellationToken.ThrowIfCancellationRequested();
					num = 100;
				}
				if (!flag2)
				{
					for (int i = 0; i < policy.MinimumBlankLinesBetweenMembers; i++)
					{
						NewLine();
					}
				}
				flag2 = false;
				if (!IsSameGroup(a, member2))
				{
					writer.AddLineSeparator(Math.Max(lastBraceOffset, lastDeclarationOffset));
				}
				member2.AcceptVisitor(this);
				a = member2;
			}
		}
		CloseBrace(style, braceHelper, saveDeclOffset: true);
		OptionalSemicolon(typeDeclaration.LastChild);
		NewLine();
		EndNode(typeDeclaration);
	}

	private bool IsSameGroup(AstNode a, AstNode b)
	{
		if (a == null)
		{
			return true;
		}
		if (a is FieldDeclaration)
		{
			return b is FieldDeclaration;
		}
		return false;
	}

	public virtual void VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
	{
		StartNode(usingAliasDeclaration);
		WriteKeyword(UsingAliasDeclaration.UsingKeywordRole);
		WriteIdentifier(usingAliasDeclaration.GetChildByRole(UsingAliasDeclaration.AliasRole), BoxedTextColor.Text);
		Space(policy.SpaceAroundEqualityOperator);
		WriteToken(Roles.Assign, BoxedTextColor.Operator);
		Space(policy.SpaceAroundEqualityOperator);
		usingAliasDeclaration.Import.AcceptVisitor(this);
		SaveDeclarationOffset();
		Semicolon();
		EndNode(usingAliasDeclaration);
	}

	public virtual void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
	{
		StartNode(usingDeclaration);
		WriteKeyword(UsingDeclaration.UsingKeywordRole);
		usingDeclaration.Import.AcceptVisitor(this);
		SaveDeclarationOffset();
		Semicolon();
		EndNode(usingDeclaration);
	}

	public virtual void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
	{
		StartNode(externAliasDeclaration);
		WriteKeyword(Roles.ExternKeyword);
		Space();
		WriteKeyword(Roles.AliasKeyword);
		Space();
		WriteIdentifier(externAliasDeclaration.NameToken);
		SaveDeclarationOffset();
		Semicolon();
		EndNode(externAliasDeclaration);
	}

	public virtual void VisitBlockStatement(BlockStatement blockStatement)
	{
		StartNode(blockStatement);
		MethodDebugInfoBuilder methodDebugInfoBuilder = null;
		BraceStyle style;
		CodeBracesRangeFlags flags;
		if (blockStatement.Parent is AnonymousMethodExpression || blockStatement.Parent is LambdaExpression)
		{
			style = policy.AnonymousMethodBraceStyle;
			flags = CodeBracesRangeFlags.AnonymousMethodBraces;
			methodDebugInfoBuilder = blockStatement.Parent.Annotation<MethodDebugInfoBuilder>();
		}
		else if (blockStatement.Parent is ConstructorDeclaration)
		{
			style = policy.ConstructorBraceStyle;
			flags = CodeBracesRangeFlags.ConstructorBraces;
		}
		else if (blockStatement.Parent is DestructorDeclaration)
		{
			style = policy.DestructorBraceStyle;
			flags = CodeBracesRangeFlags.DestructorBraces;
		}
		else if (blockStatement.Parent is OperatorDeclaration)
		{
			style = policy.MethodBraceStyle;
			flags = CodeBracesRangeFlags.OperatorBraces;
		}
		else if (blockStatement.Parent is MethodDeclaration)
		{
			style = policy.MethodBraceStyle;
			flags = CodeBracesRangeFlags.MethodBraces;
		}
		else if (blockStatement.Parent is Accessor)
		{
			flags = CodeBracesRangeFlags.AccessorBraces;
			style = ((blockStatement.Parent.Role == PropertyDeclaration.GetterRole) ? policy.PropertyGetBraceStyle : ((blockStatement.Parent.Role == PropertyDeclaration.SetterRole) ? policy.PropertySetBraceStyle : ((blockStatement.Parent.Role == CustomEventDeclaration.AddAccessorRole) ? policy.EventAddBraceStyle : ((blockStatement.Parent.Role != CustomEventDeclaration.RemoveAccessorRole) ? policy.StatementBraceStyle : policy.EventRemoveBraceStyle))));
		}
		else if (blockStatement.Parent is ForeachStatement || blockStatement.Parent is ForStatement || blockStatement.Parent is DoWhileStatement || blockStatement.Parent is WhileStatement)
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.LoopBraces;
		}
		else if (blockStatement.Parent is IfElseStatement)
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.ConditionalBraces;
		}
		else if (blockStatement.Parent is TryCatchStatement)
		{
			style = policy.StatementBraceStyle;
			TryCatchStatement tryCatchStatement = (TryCatchStatement)blockStatement.Parent;
			flags = ((tryCatchStatement.TryBlock == blockStatement) ? CodeBracesRangeFlags.TryBraces : ((tryCatchStatement.FinallyBlock != blockStatement) ? CodeBracesRangeFlags.OtherBlockBraces : CodeBracesRangeFlags.FinallyBraces));
		}
		else if (blockStatement.Parent is CatchClause)
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.CatchBraces;
		}
		else if (blockStatement.Parent is LockStatement)
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.LockBraces;
		}
		else if (blockStatement.Parent is UsingStatement)
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.UsingBraces;
		}
		else if (blockStatement.Parent is FixedStatement)
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.FixedBraces;
		}
		else
		{
			style = policy.StatementBraceStyle;
			flags = CodeBracesRangeFlags.OtherBlockBraces;
		}
		BraceHelper braceHelper = OpenBrace(style, flags, out var start, out var end);
		if (blockStatement.HiddenStart != null)
		{
			DebugStart(blockStatement, start);
			DebugHidden(blockStatement.HiddenStart);
			DebugEnd(blockStatement, end);
		}
		int num = 0;
		foreach (Statement statement in blockStatement.Statements)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			statement.AcceptVisitor(this);
		}
		EndNode(blockStatement);
		lastBlockStatementEndOffset = writer.GetLocation() ?? 0;
		CloseBrace(style, braceHelper, out start, out end, saveDeclOffset: false);
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = end;
		}
		if (blockStatement.HiddenEnd != null)
		{
			DebugStart(blockStatement, start);
			DebugHidden(blockStatement.HiddenEnd);
			DebugEnd(blockStatement, end);
		}
		if (!(blockStatement.Parent is Expression))
		{
			NewLine();
		}
	}

	public virtual void VisitBreakStatement(BreakStatement breakStatement)
	{
		StartNode(breakStatement);
		DebugStart(breakStatement);
		WriteKeywordReference(BreakStatement.BreakKeywordRole, currentBreakReference);
		SemicolonDebugEnd(breakStatement);
		EndNode(breakStatement);
	}

	public virtual void VisitCheckedStatement(CheckedStatement checkedStatement)
	{
		DebugExpression(checkedStatement);
		StartNode(checkedStatement);
		WriteKeywordReference(CheckedStatement.CheckedKeywordRole);
		checkedStatement.Body.AcceptVisitor(this);
		EndNode(checkedStatement);
	}

	public virtual void VisitContinueStatement(ContinueStatement continueStatement)
	{
		StartNode(continueStatement);
		DebugStart(continueStatement);
		WriteKeywordReference(ContinueStatement.ContinueKeywordRole, currentLoopReference);
		SemicolonDebugEnd(continueStatement);
		EndNode(continueStatement);
	}

	public virtual void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
	{
		StartNode(doWhileStatement);
		object obj = currentLoopReference;
		currentLoopReference = new object();
		object obj2 = currentBreakReference;
		currentBreakReference = currentLoopReference;
		WriteKeywordReference(DoWhileStatement.DoKeywordRole, currentLoopReference);
		WriteEmbeddedStatement(doWhileStatement.EmbeddedStatement);
		DebugStart(doWhileStatement);
		WriteKeywordReference(DoWhileStatement.WhileKeywordRole, currentLoopReference);
		Space(policy.SpaceBeforeWhileParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinWhileParentheses);
		doWhileStatement.Condition.AcceptVisitor(this);
		Space(policy.SpacesWithinWhileParentheses);
		braceHelper.RightParen();
		SemicolonDebugEnd(doWhileStatement);
		currentLoopReference = obj;
		currentBreakReference = obj2;
		EndNode(doWhileStatement);
	}

	public virtual void VisitEmptyStatement(EmptyStatement emptyStatement)
	{
		DebugExpression(emptyStatement);
		StartNode(emptyStatement);
		Semicolon();
		EndNode(emptyStatement);
	}

	public virtual void VisitExpressionStatement(ExpressionStatement expressionStatement)
	{
		StartNode(expressionStatement);
		DebugStart(expressionStatement);
		expressionStatement.Expression.AcceptVisitor(this);
		SemicolonDebugEnd(expressionStatement);
		EndNode(expressionStatement);
	}

	public virtual void VisitFixedStatement(FixedStatement fixedStatement)
	{
		StartNode(fixedStatement);
		WriteKeyword(FixedStatement.FixedKeywordRole);
		Space(policy.SpaceBeforeUsingParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinUsingParentheses);
		DebugStart(fixedStatement);
		fixedStatement.Type.AcceptVisitor(this);
		Space();
		WriteCommaSeparatedList(fixedStatement.Variables);
		DebugEnd(fixedStatement);
		Space(policy.SpacesWithinUsingParentheses);
		braceHelper.RightParen();
		WriteEmbeddedStatement(fixedStatement.EmbeddedStatement);
		EndNode(fixedStatement);
	}

	public virtual void VisitForeachStatement(ForeachStatement foreachStatement)
	{
		StartNode(foreachStatement);
		object obj = currentLoopReference;
		currentLoopReference = new object();
		object obj2 = currentBreakReference;
		currentBreakReference = currentLoopReference;
		DebugStart(foreachStatement);
		WriteKeywordReference(ForeachStatement.ForeachKeywordRole, currentLoopReference);
		DebugHidden(foreachStatement.HiddenInitializer);
		DebugEnd(foreachStatement, addSelf: false);
		Space(policy.SpaceBeforeForeachParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinForeachParentheses);
		DebugStart(foreachStatement);
		foreachStatement.VariableType.AcceptVisitor(this);
		Space();
		WriteIdentifier(foreachStatement.VariableNameToken);
		DebugHidden(foreachStatement.HiddenGetCurrentNode);
		DebugEnd(foreachStatement, addSelf: false);
		Space();
		DebugStart(foreachStatement);
		WriteKeyword(ForeachStatement.InKeywordRole);
		DebugHidden(foreachStatement.HiddenMoveNextNode);
		DebugEnd(foreachStatement, addSelf: false);
		Space();
		DebugStart(foreachStatement);
		foreachStatement.InExpression.AcceptVisitor(this);
		DebugHidden(foreachStatement.HiddenGetEnumeratorNode);
		DebugEnd(foreachStatement, addSelf: false);
		Space(policy.SpacesWithinForeachParentheses);
		braceHelper.RightParen();
		WriteEmbeddedStatement(foreachStatement.EmbeddedStatement);
		currentLoopReference = obj;
		currentBreakReference = obj2;
		EndNode(foreachStatement);
	}

	public virtual void VisitForStatement(ForStatement forStatement)
	{
		StartNode(forStatement);
		object obj = currentLoopReference;
		currentLoopReference = new object();
		object obj2 = currentBreakReference;
		currentBreakReference = currentLoopReference;
		WriteKeywordReference(ForStatement.ForKeywordRole, currentLoopReference);
		Space(policy.SpaceBeforeForParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinForParentheses);
		bool flag = !forStatement.Initializers.Any() && !forStatement.Iterators.Any();
		DebugStart(forStatement);
		WriteCommaSeparatedList(forStatement.Initializers);
		if (!flag)
		{
			Space(policy.SpaceBeforeForSemicolon);
		}
		WriteToken(Roles.Semicolon, BoxedTextColor.Punctuation);
		DebugEnd(forStatement, addSelf: false);
		if (!flag)
		{
			Space(policy.SpaceAfterForSemicolon);
		}
		DebugStart(forStatement);
		forStatement.Condition.AcceptVisitor(this);
		DebugEnd(forStatement, addSelf: false);
		if (!flag)
		{
			Space(policy.SpaceBeforeForSemicolon);
		}
		WriteToken(Roles.Semicolon, BoxedTextColor.Punctuation);
		if (forStatement.Iterators.Any())
		{
			Space(policy.SpaceAfterForSemicolon);
			DebugStart(forStatement);
			WriteCommaSeparatedList(forStatement.Iterators);
			DebugEnd(forStatement, addSelf: false);
		}
		Space(policy.SpacesWithinForParentheses);
		braceHelper.RightParen();
		WriteEmbeddedStatement(forStatement.EmbeddedStatement);
		currentLoopReference = obj;
		currentBreakReference = obj2;
		EndNode(forStatement);
	}

	public virtual void VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
	{
		StartNode(gotoCaseStatement);
		DebugStart(gotoCaseStatement);
		WriteKeywordReferences(GotoCaseStatement.GotoKeywordRole, GotoCaseStatement.CaseKeywordRole, currentSwitchReference);
		Space();
		gotoCaseStatement.LabelExpression.AcceptVisitor(this);
		SemicolonDebugEnd(gotoCaseStatement);
		EndNode(gotoCaseStatement);
	}

	public virtual void VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
	{
		StartNode(gotoDefaultStatement);
		DebugStart(gotoDefaultStatement);
		WriteKeywordReferences(GotoDefaultStatement.GotoKeywordRole, GotoDefaultStatement.DefaultKeywordRole, currentSwitchReference);
		SemicolonDebugEnd(gotoDefaultStatement);
		EndNode(gotoDefaultStatement);
	}

	public virtual void VisitGotoStatement(GotoStatement gotoStatement)
	{
		StartNode(gotoStatement);
		DebugStart(gotoStatement);
		WriteKeyword(GotoStatement.GotoKeywordRole);
		WriteIdentifier(gotoStatement.GetChildByRole(Roles.Identifier), BoxedTextColor.Label);
		SemicolonDebugEnd(gotoStatement);
		EndNode(gotoStatement);
	}

	public virtual void VisitIfElseStatement(IfElseStatement ifElseStatement)
	{
		StartNode(ifElseStatement);
		object obj = currentIfReference;
		if (elseIfStart < 0)
		{
			currentIfReference = new object();
		}
		DebugStartReference(ifElseStatement, IfElseStatement.IfKeywordRole, currentIfReference, ref elseIfStart);
		Space(policy.SpaceBeforeIfParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinIfParentheses);
		ifElseStatement.Condition.AcceptVisitor(this);
		Space(policy.SpacesWithinIfParentheses);
		braceHelper.RightParen();
		DebugEnd(ifElseStatement);
		WriteEmbeddedStatement(ifElseStatement.TrueStatement);
		if (!ifElseStatement.FalseStatement.IsNull)
		{
			if (ifElseStatement.FalseStatement is IfElseStatement)
			{
				elseIfStart = writer.GetLocation() ?? 0;
				WriteKeyword(IfElseStatement.ElseKeywordRole);
				Space();
				ifElseStatement.FalseStatement.AcceptVisitor(this);
			}
			else
			{
				WriteKeywordReference(IfElseStatement.ElseKeywordRole, currentIfReference);
				WriteEmbeddedStatement(ifElseStatement.FalseStatement);
			}
		}
		currentIfReference = obj;
		EndNode(ifElseStatement);
	}

	public virtual void VisitLabelStatement(LabelStatement labelStatement)
	{
		DebugExpression(labelStatement);
		StartNode(labelStatement);
		WriteIdentifier(labelStatement.GetChildByRole(Roles.Identifier), BoxedTextColor.Label);
		WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		bool flag = false;
		for (AstNode nextSibling = labelStatement.NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
		{
			if (nextSibling.Role == labelStatement.Role)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			WriteToken(Roles.Semicolon, BoxedTextColor.Punctuation);
		}
		NewLine();
		EndNode(labelStatement);
	}

	public virtual void VisitLockStatement(LockStatement lockStatement)
	{
		StartNode(lockStatement);
		DebugStart(lockStatement);
		WriteKeywordReference(LockStatement.LockKeywordRole);
		Space(policy.SpaceBeforeLockParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinLockParentheses);
		lockStatement.Expression.AcceptVisitor(this);
		Space(policy.SpacesWithinLockParentheses);
		braceHelper.RightParen();
		DebugEnd(lockStatement);
		WriteEmbeddedStatement(lockStatement.EmbeddedStatement);
		EndNode(lockStatement);
	}

	public virtual void VisitReturnStatement(ReturnStatement returnStatement)
	{
		StartNode(returnStatement);
		DebugStart(returnStatement);
		WriteKeywordReference(ReturnStatement.ReturnKeywordRole, currentMethodRefs.MethodReference);
		if (!returnStatement.Expression.IsNull)
		{
			Space();
			returnStatement.Expression.AcceptVisitor(this);
		}
		SemicolonDebugEnd(returnStatement);
		EndNode(returnStatement);
	}

	public virtual void VisitSwitchStatement(SwitchStatement switchStatement)
	{
		StartNode(switchStatement);
		DebugStart(switchStatement);
		object obj = currentSwitchReference;
		currentSwitchReference = new object();
		object obj2 = currentBreakReference;
		currentBreakReference = currentSwitchReference;
		WriteKeywordReference(SwitchStatement.SwitchKeywordRole, currentSwitchReference);
		Space(policy.SpaceBeforeSwitchParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinSwitchParentheses);
		switchStatement.Expression.AcceptVisitor(this);
		Space(policy.SpacesWithinSwitchParentheses);
		braceHelper.RightParen();
		DebugEnd(switchStatement);
		braceHelper = OpenBrace(policy.StatementBraceStyle, CodeBracesRangeFlags.BraceKind_CurlyBraces);
		if (!policy.IndentSwitchBody)
		{
			writer.Unindent();
		}
		int num = 0;
		foreach (SwitchSection switchSection in switchStatement.SwitchSections)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			switchSection.AcceptVisitor(this);
		}
		if (!policy.IndentSwitchBody)
		{
			writer.Indent();
		}
		CloseBrace(policy.StatementBraceStyle, braceHelper, out var start, out var end, saveDeclOffset: false);
		if (switchStatement.HiddenEnd != null)
		{
			DebugStart(switchStatement, start);
			DebugHidden(switchStatement.HiddenEnd);
			DebugEnd(switchStatement, end);
		}
		currentSwitchReference = obj;
		currentBreakReference = obj2;
		NewLine();
		EndNode(switchStatement);
	}

	public virtual void VisitSwitchSection(SwitchSection switchSection)
	{
		StartNode(switchSection);
		bool flag = true;
		int num = 0;
		foreach (CaseLabel caseLabel in switchSection.CaseLabels)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (!flag)
			{
				NewLine();
			}
			caseLabel.AcceptVisitor(this);
			flag = false;
		}
		bool flag2 = switchSection.Statements.Count == 1 && switchSection.Statements.Single() is BlockStatement;
		if (policy.IndentCaseBody && !flag2)
		{
			writer.Indent();
		}
		if (!flag2)
		{
			NewLine();
		}
		num = 0;
		foreach (Statement statement in switchSection.Statements)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			statement.AcceptVisitor(this);
		}
		if (policy.IndentCaseBody && !flag2)
		{
			writer.Unindent();
		}
		EndNode(switchSection);
	}

	public virtual void VisitCaseLabel(CaseLabel caseLabel)
	{
		DebugExpression(caseLabel);
		StartNode(caseLabel);
		if (caseLabel.Expression.IsNull)
		{
			WriteKeywordReference(CaseLabel.DefaultKeywordRole, currentSwitchReference);
		}
		else
		{
			WriteKeywordReference(CaseLabel.CaseKeywordRole, currentSwitchReference);
			Space();
			caseLabel.Expression.AcceptVisitor(this);
		}
		WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		EndNode(caseLabel);
	}

	public virtual void VisitThrowStatement(ThrowStatement throwStatement)
	{
		StartNode(throwStatement);
		DebugStart(throwStatement);
		WriteKeyword(ThrowStatement.ThrowKeywordRole);
		if (!throwStatement.Expression.IsNull)
		{
			Space();
			throwStatement.Expression.AcceptVisitor(this);
		}
		SemicolonDebugEnd(throwStatement);
		EndNode(throwStatement);
	}

	public virtual void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
	{
		StartNode(tryCatchStatement);
		object obj = currentTryReference;
		currentTryReference = new object();
		WriteKeywordReference(TryCatchStatement.TryKeywordRole, currentTryReference);
		tryCatchStatement.TryBlock.AcceptVisitor(this);
		int num = 0;
		foreach (CatchClause catchClause in tryCatchStatement.CatchClauses)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			catchClause.AcceptVisitor(this);
		}
		if (!tryCatchStatement.FinallyBlock.IsNull)
		{
			WriteKeywordReference(TryCatchStatement.FinallyKeywordRole, currentTryReference);
			tryCatchStatement.FinallyBlock.AcceptVisitor(this);
		}
		currentTryReference = obj;
		EndNode(tryCatchStatement);
	}

	public virtual void VisitCatchClause(CatchClause catchClause)
	{
		StartNode(catchClause);
		bool flag = !catchClause.Condition.IsNull;
		DebugStart(catchClause);
		WriteKeywordReference(CatchClause.CatchKeywordRole, currentTryReference);
		if (!catchClause.Type.IsNull)
		{
			Space(policy.SpaceBeforeCatchParentheses);
			BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
			Space(policy.SpacesWithinCatchParentheses);
			catchClause.Type.AcceptVisitor(this);
			if (!string.IsNullOrEmpty(catchClause.VariableName))
			{
				Space();
				WriteIdentifier(catchClause.VariableNameToken);
			}
			Space(policy.SpacesWithinCatchParentheses);
			braceHelper.RightParen();
		}
		DebugEnd(catchClause);
		if (flag)
		{
			Space();
			DebugStart(catchClause.Condition);
			WriteKeywordReference(CatchClause.WhenKeywordRole, currentTryReference);
			Space(policy.SpaceBeforeIfParentheses);
			BraceHelper braceHelper2 = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
			Space(policy.SpacesWithinIfParentheses);
			catchClause.Condition.AcceptVisitor(this);
			Space(policy.SpacesWithinIfParentheses);
			braceHelper2.RightParen();
			DebugEnd(catchClause.Condition);
		}
		catchClause.Body.AcceptVisitor(this);
		EndNode(catchClause);
	}

	public virtual void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
	{
		DebugExpression(uncheckedStatement);
		StartNode(uncheckedStatement);
		WriteKeywordReference(UncheckedStatement.UncheckedKeywordRole);
		uncheckedStatement.Body.AcceptVisitor(this);
		EndNode(uncheckedStatement);
	}

	public virtual void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
	{
		DebugExpression(unsafeStatement);
		StartNode(unsafeStatement);
		WriteKeyword(UnsafeStatement.UnsafeKeywordRole);
		unsafeStatement.Body.AcceptVisitor(this);
		EndNode(unsafeStatement);
	}

	public virtual void VisitUsingStatement(UsingStatement usingStatement)
	{
		StartNode(usingStatement);
		WriteKeywordReference(UsingStatement.UsingKeywordRole);
		Space(policy.SpaceBeforeUsingParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinUsingParentheses);
		DebugStart(usingStatement);
		usingStatement.ResourceAcquisition.AcceptVisitor(this);
		DebugEnd(usingStatement);
		Space(policy.SpacesWithinUsingParentheses);
		braceHelper.RightParen();
		WriteEmbeddedStatement(usingStatement.EmbeddedStatement);
		EndNode(usingStatement);
	}

	public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
	{
		StartNode(variableDeclarationStatement);
		DebugStart(variableDeclarationStatement);
		WriteModifiers(variableDeclarationStatement.GetChildrenByRole(VariableDeclarationStatement.ModifierRole), variableDeclarationStatement.Type);
		variableDeclarationStatement.Type.AcceptVisitor(this);
		Space();
		WriteCommaSeparatedList(variableDeclarationStatement.Variables);
		SemicolonDebugEnd(variableDeclarationStatement);
		EndNode(variableDeclarationStatement);
	}

	public virtual void VisitWhileStatement(WhileStatement whileStatement)
	{
		StartNode(whileStatement);
		DebugStart(whileStatement);
		object obj = currentLoopReference;
		currentLoopReference = new object();
		object obj2 = currentBreakReference;
		currentBreakReference = currentLoopReference;
		WriteKeywordReference(WhileStatement.WhileKeywordRole, currentLoopReference);
		Space(policy.SpaceBeforeWhileParentheses);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space(policy.SpacesWithinWhileParentheses);
		whileStatement.Condition.AcceptVisitor(this);
		Space(policy.SpacesWithinWhileParentheses);
		braceHelper.RightParen();
		DebugEnd(whileStatement);
		WriteEmbeddedStatement(whileStatement.EmbeddedStatement);
		currentLoopReference = obj;
		currentBreakReference = obj2;
		EndNode(whileStatement);
	}

	public virtual void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
	{
		StartNode(yieldBreakStatement);
		DebugStart(yieldBreakStatement);
		WriteKeywordReferences(YieldBreakStatement.YieldKeywordRole, YieldBreakStatement.BreakKeywordRole, currentMethodRefs.MethodReference);
		SemicolonDebugEnd(yieldBreakStatement);
		EndNode(yieldBreakStatement);
	}

	public virtual void VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
	{
		StartNode(yieldReturnStatement);
		DebugStart(yieldReturnStatement);
		WriteKeywordReferences(YieldReturnStatement.YieldKeywordRole, YieldReturnStatement.ReturnKeywordRole, currentMethodRefs.MethodReference);
		Space();
		yieldReturnStatement.Expression.AcceptVisitor(this);
		SemicolonDebugEnd(yieldReturnStatement);
		EndNode(yieldReturnStatement);
	}

	public virtual void VisitAccessor(Accessor accessor)
	{
		StartNode(accessor);
		MethodDebugInfoBuilder methodDebugInfoBuilder = accessor.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		WriteAttributes(accessor.Attributes);
		WriteModifiers(accessor.ModifierTokens, accessor.Body);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		bool isNull = accessor.Body.IsNull;
		if (isNull)
		{
			DebugStart(accessor);
		}
		if (accessor.Role == PropertyDeclaration.GetterRole)
		{
			WriteKeywordIdentifier(PropertyDeclaration.GetKeywordRole);
		}
		else if (accessor.Role == PropertyDeclaration.SetterRole)
		{
			WriteKeywordIdentifier(PropertyDeclaration.SetKeywordRole);
		}
		else if (accessor.Role == CustomEventDeclaration.AddAccessorRole)
		{
			WriteKeywordIdentifier(CustomEventDeclaration.AddKeywordRole);
		}
		else if (accessor.Role == CustomEventDeclaration.RemoveAccessorRole)
		{
			WriteKeywordIdentifier(CustomEventDeclaration.RemoveKeywordRole);
		}
		if (isNull)
		{
			SaveDeclarationOffset();
			SemicolonDebugEnd(accessor);
		}
		else
		{
			WriteMethodBody(accessor.Body);
		}
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(accessor);
	}

	public virtual void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
	{
		StartNode(constructorDeclaration);
		MethodDebugInfoBuilder methodDebugInfoBuilder = constructorDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		WriteAttributes(constructorDeclaration.Attributes);
		WriteModifiers(constructorDeclaration.ModifierTokens, constructorDeclaration.NameToken);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		TypeDeclaration typeDeclaration = constructorDeclaration.Parent as TypeDeclaration;
		MethodDef methodDef = constructorDeclaration.Annotation<MethodDef>();
		object data = ((methodDef == null) ? BoxedTextColor.Type : CSharpMetadataTextColorProvider.Instance.GetColor(methodDef.DeclaringType));
		if (typeDeclaration != null && typeDeclaration.Name != constructorDeclaration.Name)
		{
			WriteIdentifier((Identifier)typeDeclaration.NameToken.Clone(), data);
		}
		else
		{
			WriteIdentifier(constructorDeclaration.NameToken);
		}
		Space(policy.SpaceBeforeConstructorDeclarationParentheses);
		WriteCommaSeparatedListInParenthesis(constructorDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (!constructorDeclaration.Initializer.IsNull)
		{
			Space();
			constructorDeclaration.Initializer.AcceptVisitor(this);
		}
		WriteMethodBody(constructorDeclaration.Body);
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(constructorDeclaration);
	}

	public virtual void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
	{
		StartNode(constructorInitializer);
		WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		Space();
		DebugStart(constructorInitializer);
		if (constructorInitializer.ConstructorInitializerType == ConstructorInitializerType.This)
		{
			WriteKeyword(ConstructorInitializer.ThisKeywordRole);
		}
		else
		{
			WriteKeyword(ConstructorInitializer.BaseKeywordRole);
		}
		Space(policy.SpaceBeforeMethodCallParentheses);
		WriteCommaSeparatedListInParenthesis(constructorInitializer.Arguments, policy.SpaceWithinMethodCallParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		DebugEnd(constructorInitializer);
		EndNode(constructorInitializer);
	}

	public virtual void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
	{
		StartNode(destructorDeclaration);
		MethodDebugInfoBuilder methodDebugInfoBuilder = destructorDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		WriteAttributes(destructorDeclaration.Attributes);
		WriteModifiers(destructorDeclaration.ModifierTokens, destructorDeclaration.NameToken);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		WriteToken(DestructorDeclaration.TildeRole, BoxedTextColor.Operator);
		TypeDeclaration typeDeclaration = destructorDeclaration.Parent as TypeDeclaration;
		MethodDef methodDef = destructorDeclaration.Annotation<MethodDef>();
		object data = ((methodDef == null) ? BoxedTextColor.Type : CSharpMetadataTextColorProvider.Instance.GetColor(methodDef.DeclaringType));
		if (typeDeclaration != null && typeDeclaration.Name != destructorDeclaration.Name)
		{
			WriteIdentifier((Identifier)typeDeclaration.NameToken.Clone(), data);
		}
		else
		{
			WriteIdentifier(destructorDeclaration.NameToken, data);
		}
		Space(policy.SpaceBeforeConstructorDeclarationParentheses);
		BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses).RightParen();
		WriteMethodBody(destructorDeclaration.Body);
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(destructorDeclaration);
	}

	public virtual void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
	{
		StartNode(enumMemberDeclaration);
		WriteAttributes(enumMemberDeclaration.Attributes);
		WriteModifiers(enumMemberDeclaration.ModifierTokens, enumMemberDeclaration.NameToken);
		WriteIdentifier(enumMemberDeclaration.NameToken);
		if (!enumMemberDeclaration.Initializer.IsNull)
		{
			Space(policy.SpaceAroundAssignment);
			WriteToken(Roles.Assign, BoxedTextColor.Operator);
			Space(policy.SpaceAroundAssignment);
			enumMemberDeclaration.Initializer.AcceptVisitor(this);
		}
		SaveDeclarationOffset();
		EndNode(enumMemberDeclaration);
	}

	public virtual void VisitEventDeclaration(EventDeclaration eventDeclaration)
	{
		StartNode(eventDeclaration);
		WriteAttributes(eventDeclaration.Attributes);
		WriteModifiers(eventDeclaration.ModifierTokens, eventDeclaration.ReturnType);
		WriteKeyword(EventDeclaration.EventKeywordRole);
		eventDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WriteCommaSeparatedList(eventDeclaration.Variables);
		SaveDeclarationOffset();
		Semicolon();
		EndNode(eventDeclaration);
	}

	public virtual void VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
	{
		StartNode(customEventDeclaration);
		WriteAttributes(customEventDeclaration.Attributes);
		WriteModifiers(customEventDeclaration.ModifierTokens, customEventDeclaration.ReturnType);
		WriteKeyword(CustomEventDeclaration.EventKeywordRole);
		customEventDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WritePrivateImplementationType(customEventDeclaration.PrivateImplementationType);
		WriteIdentifier(customEventDeclaration.NameToken);
		BraceHelper braceHelper = OpenBrace(policy.EventBraceStyle, CodeBracesRangeFlags.EventBraces);
		int num = 0;
		foreach (AstNode child in customEventDeclaration.Children)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (child.Role == CustomEventDeclaration.AddAccessorRole || child.Role == CustomEventDeclaration.RemoveAccessorRole)
			{
				child.AcceptVisitor(this);
			}
		}
		CloseBrace(policy.EventBraceStyle, braceHelper, saveDeclOffset: true);
		NewLine();
		EndNode(customEventDeclaration);
	}

	public virtual void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
	{
		StartNode(fieldDeclaration);
		WriteAttributes(fieldDeclaration.Attributes);
		WriteModifiers(fieldDeclaration.ModifierTokens, fieldDeclaration.ReturnType);
		DebugStart(fieldDeclaration);
		fieldDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WriteCommaSeparatedList(fieldDeclaration.Variables);
		SaveDeclarationOffset();
		SemicolonDebugEnd(fieldDeclaration);
		EndNode(fieldDeclaration);
	}

	public virtual void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
	{
		StartNode(fixedFieldDeclaration);
		WriteAttributes(fixedFieldDeclaration.Attributes);
		WriteModifiers(fixedFieldDeclaration.ModifierTokens, fixedFieldDeclaration.ReturnType);
		WriteKeyword(FixedFieldDeclaration.FixedKeywordRole);
		Space();
		fixedFieldDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WriteCommaSeparatedList(fixedFieldDeclaration.Variables);
		SaveDeclarationOffset();
		Semicolon();
		EndNode(fixedFieldDeclaration);
	}

	public virtual void VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
	{
		DebugExpression(fixedVariableInitializer);
		StartNode(fixedVariableInitializer);
		WriteIdentifier(fixedVariableInitializer.NameToken);
		if (!fixedVariableInitializer.CountExpression.IsNull)
		{
			BraceHelper braceHelper = BraceHelper.LeftBracket(this, CodeBracesRangeFlags.BraceKind_SquareBrackets);
			Space(policy.SpacesWithinBrackets);
			fixedVariableInitializer.CountExpression.AcceptVisitor(this);
			Space(policy.SpacesWithinBrackets);
			braceHelper.RightBracket();
		}
		EndNode(fixedVariableInitializer);
	}

	public virtual void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
	{
		StartNode(indexerDeclaration);
		WriteAttributes(indexerDeclaration.Attributes);
		WriteModifiers(indexerDeclaration.ModifierTokens, indexerDeclaration.ReturnType);
		indexerDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WritePrivateImplementationType(indexerDeclaration.PrivateImplementationType);
		WriteKeyword(IndexerDeclaration.ThisKeywordRole);
		Space(policy.SpaceBeforeMethodDeclarationParentheses);
		WriteCommaSeparatedListInBrackets(indexerDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		BraceHelper braceHelper = OpenBrace(policy.PropertyBraceStyle, CodeBracesRangeFlags.PropertyBraces);
		int num = 0;
		foreach (AstNode child in indexerDeclaration.Children)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (child.Role == IndexerDeclaration.GetterRole || child.Role == IndexerDeclaration.SetterRole)
			{
				child.AcceptVisitor(this);
			}
		}
		CloseBrace(policy.PropertyBraceStyle, braceHelper, saveDeclOffset: true);
		NewLine();
		EndNode(indexerDeclaration);
	}

	public virtual void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
	{
		StartNode(methodDeclaration);
		MethodDebugInfoBuilder methodDebugInfoBuilder = methodDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		WriteAttributes(methodDeclaration.Attributes);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		WriteModifiers(methodDeclaration.ModifierTokens, methodDeclaration.ReturnType);
		methodDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WritePrivateImplementationType(methodDeclaration.PrivateImplementationType);
		WriteIdentifier(methodDeclaration.NameToken);
		WriteTypeParameters(methodDeclaration.TypeParameters, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		Space(policy.SpaceBeforeMethodDeclarationParentheses);
		WriteCommaSeparatedListInParenthesis(methodDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		int num = 0;
		foreach (Constraint constraint in methodDeclaration.Constraints)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			constraint.AcceptVisitor(this);
		}
		WriteMethodBody(methodDeclaration.Body);
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(methodDeclaration);
	}

	public virtual void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
	{
		StartNode(operatorDeclaration);
		MethodDebugInfoBuilder methodDebugInfoBuilder = operatorDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = writer.GetLocation();
		}
		WriteAttributes(operatorDeclaration.Attributes);
		WriteModifiers(operatorDeclaration.ModifierTokens, operatorDeclaration.ReturnType);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		if (operatorDeclaration.OperatorType == OperatorType.Explicit)
		{
			WriteKeyword(OperatorDeclaration.ExplicitRole);
		}
		else if (operatorDeclaration.OperatorType == OperatorType.Implicit)
		{
			WriteKeyword(OperatorDeclaration.ImplicitRole);
		}
		else
		{
			operatorDeclaration.ReturnType.AcceptVisitor(this);
		}
		WriteKeywordIdentifier(OperatorDeclaration.OperatorKeywordRole);
		Space();
		if (operatorDeclaration.OperatorType == OperatorType.Explicit || operatorDeclaration.OperatorType == OperatorType.Implicit)
		{
			operatorDeclaration.ReturnType.AcceptVisitor(this);
		}
		else
		{
			WriteTokenOperatorOrKeyword(OperatorDeclaration.GetToken(operatorDeclaration.OperatorType), OperatorDeclaration.GetRole(operatorDeclaration.OperatorType));
		}
		Space(policy.SpaceBeforeMethodDeclarationParentheses);
		WriteCommaSeparatedListInParenthesis(operatorDeclaration.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
		WriteMethodBody(operatorDeclaration.Body);
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = writer.GetLocation();
		}
		currentMethodRefs = methodRefs;
		EndNode(operatorDeclaration);
	}

	public virtual void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
	{
		StartNode(parameterDeclaration);
		WriteAttributes(parameterDeclaration.Attributes);
		switch (parameterDeclaration.ParameterModifier)
		{
		case ParameterModifier.In:
			WriteKeyword(ParameterDeclaration.InModifierRole);
			break;
		case ParameterModifier.Ref:
			WriteKeyword(ParameterDeclaration.RefModifierRole);
			break;
		case ParameterModifier.Out:
			WriteKeyword(ParameterDeclaration.OutModifierRole);
			break;
		case ParameterModifier.Params:
			WriteKeyword(ParameterDeclaration.ParamsModifierRole);
			break;
		case ParameterModifier.This:
			WriteKeyword(ParameterDeclaration.ThisModifierRole);
			break;
		}
		parameterDeclaration.Type.AcceptVisitor(this);
		if (!parameterDeclaration.Type.IsNull && !string.IsNullOrEmpty(parameterDeclaration.Name))
		{
			Space();
		}
		if (!string.IsNullOrEmpty(parameterDeclaration.Name))
		{
			WriteIdentifier(parameterDeclaration.NameToken);
		}
		if (!parameterDeclaration.DefaultExpression.IsNull)
		{
			Space(policy.SpaceAroundAssignment);
			WriteToken(Roles.Assign, BoxedTextColor.Operator);
			Space(policy.SpaceAroundAssignment);
			parameterDeclaration.DefaultExpression.AcceptVisitor(this);
		}
		SaveDeclarationOffset();
		EndNode(parameterDeclaration);
	}

	public virtual void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
	{
		StartNode(propertyDeclaration);
		WriteAttributes(propertyDeclaration.Attributes);
		WriteModifiers(propertyDeclaration.ModifierTokens, propertyDeclaration.ReturnType);
		propertyDeclaration.ReturnType.AcceptVisitor(this);
		Space();
		WritePrivateImplementationType(propertyDeclaration.PrivateImplementationType);
		WriteIdentifier(propertyDeclaration.NameToken);
		BraceStyle style = policy.PropertyBraceStyle;
		if ((propertyDeclaration.Getter.IsNull || propertyDeclaration.Getter.Body.IsNull) && (propertyDeclaration.Setter.IsNull || propertyDeclaration.Setter.Body.IsNull))
		{
			style = BraceStyle.DoNotChange;
			HACK_disableSemicolonNewLine = true;
		}
		BraceHelper braceHelper = OpenBrace(style, CodeBracesRangeFlags.PropertyBraces);
		int num = 0;
		int num2 = 0;
		foreach (AstNode child in propertyDeclaration.Children)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			if (child.Role == IndexerDeclaration.GetterRole || child.Role == IndexerDeclaration.SetterRole)
			{
				if (num2++ > 0 && HACK_disableSemicolonNewLine)
				{
					writer.Space();
				}
				child.AcceptVisitor(this);
			}
		}
		HACK_disableSemicolonNewLine = false;
		CloseBrace(style, braceHelper, saveDeclOffset: true);
		if (propertyDeclaration.Variables.Any())
		{
			propertyDeclaration.Variables.AcceptVisitor(this);
			WriteToken(Roles.Semicolon, BoxedTextColor.Punctuation);
		}
		NewLine();
		EndNode(propertyDeclaration);
	}

	public virtual void VisitVariableInitializer(VariableInitializer variableInitializer)
	{
		StartNode(variableInitializer);
		bool flag = variableInitializer.Parent is PropertyDeclaration;
		if (!flag)
		{
			WriteIdentifier(variableInitializer.NameToken);
		}
		if (!variableInitializer.Initializer.IsNull)
		{
			Space(policy.SpaceAroundAssignment);
			WriteToken(Roles.Assign, BoxedTextColor.Operator);
			Space(policy.SpaceAroundAssignment);
			if (flag)
			{
				DebugStart(variableInitializer);
			}
			WriteModifiers(variableInitializer.GetChildrenByRole(VariableInitializer.ModifierRole), null);
			variableInitializer.Initializer.AcceptVisitor(this);
			if (flag)
			{
				DebugEnd(variableInitializer);
			}
		}
		EndNode(variableInitializer);
	}

	private bool MaybeNewLinesAfterUsings(AstNode node)
	{
		AstNode nextSibling = node.NextSibling;
		while (nextSibling is WhitespaceNode || nextSibling is NewLineNode)
		{
			nextSibling = nextSibling.NextSibling;
		}
		if ((node is UsingDeclaration || node is UsingAliasDeclaration) && !(nextSibling is UsingDeclaration) && !(nextSibling is UsingAliasDeclaration))
		{
			for (int i = 0; i < policy.MinimumBlankLinesAfterUsings; i++)
			{
				NewLine();
			}
			return true;
		}
		return false;
	}

	public virtual void VisitSyntaxTree(SyntaxTree syntaxTree)
	{
		int num = 0;
		bool flag = false;
		int num2 = 0;
		int num3 = 0;
		foreach (AstNode child in syntaxTree.Children)
		{
			num2++;
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			child.AcceptVisitor(this);
			if (MaybeNewLinesAfterUsings(child) || child is NamespaceDeclaration)
			{
				num3 = Math.Max(lastBraceOffset, lastDeclarationOffset);
				writer.AddLineSeparator(num3);
				flag = true;
			}
			else
			{
				flag = false;
			}
		}
		if (!flag && num2 > 0)
		{
			int num4 = Math.Max(lastBraceOffset, lastDeclarationOffset);
			if (num4 != num3 && num4 != 0)
			{
				writer.AddLineSeparator(num4);
			}
		}
	}

	public virtual void VisitSimpleType(SimpleType simpleType)
	{
		StartNode(simpleType);
		if (simpleType.Identifier.Length != 0 || !SimpleType.DummyTypeGenericParam.Equals(simpleType.Annotation<string>(), StringComparison.Ordinal))
		{
			WriteIdentifier(simpleType.IdentifierToken, CSharpMetadataTextColorProvider.Instance.GetColor(simpleType.IdentifierToken.Annotation<object>() ?? simpleType.Annotation<object>()));
		}
		WriteTypeArguments(simpleType.TypeArguments, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		EndNode(simpleType);
	}

	public virtual void VisitMemberType(MemberType memberType)
	{
		StartNode(memberType);
		memberType.Target.AcceptVisitor(this);
		if (memberType.IsDoubleColon)
		{
			WriteToken(Roles.DoubleColon, BoxedTextColor.Operator);
		}
		else
		{
			WriteToken(Roles.Dot, BoxedTextColor.Operator);
		}
		WriteIdentifier(memberType.MemberNameToken, CSharpMetadataTextColorProvider.Instance.GetColor(memberType.MemberNameToken.Annotation<object>() ?? memberType.Annotation<object>()));
		WriteTypeArguments(memberType.TypeArguments, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		EndNode(memberType);
	}

	public virtual void VisitComposedType(ComposedType composedType)
	{
		StartNode(composedType);
		composedType.BaseType.AcceptVisitor(this);
		if (composedType.HasNullableSpecifier)
		{
			WriteToken(ComposedType.NullableRole, BoxedTextColor.Operator);
		}
		int num = 0;
		for (int i = 0; i < composedType.PointerRank; i++)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			WriteToken(ComposedType.PointerRole, BoxedTextColor.Operator);
		}
		num = 0;
		foreach (ArraySpecifier arraySpecifier in composedType.ArraySpecifiers)
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			arraySpecifier.AcceptVisitor(this);
		}
		EndNode(composedType);
	}

	public virtual void VisitArraySpecifier(ArraySpecifier arraySpecifier)
	{
		StartNode(arraySpecifier);
		BraceHelper braceHelper = BraceHelper.LeftBracket(this, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		int num = 0;
		foreach (CSharpTokenNode item in arraySpecifier.GetChildrenByRole(Roles.Comma))
		{
			if (num-- <= 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				num = 100;
			}
			writer.WriteTokenPunctuation(Roles.Comma, ",");
		}
		braceHelper.RightBracket();
		EndNode(arraySpecifier);
	}

	public virtual void VisitPrimitiveType(PrimitiveType primitiveType)
	{
		StartNode(primitiveType);
		writer.WritePrimitiveType(primitiveType.Keyword);
		EndNode(primitiveType);
	}

	public virtual void VisitComment(Comment comment)
	{
		writer.StartNode(comment);
		writer.WriteComment(comment.CommentType, comment.Content, comment.References);
		writer.EndNode(comment);
	}

	public virtual void VisitNewLine(NewLineNode newLineNode)
	{
	}

	public virtual void VisitWhitespace(WhitespaceNode whitespaceNode)
	{
	}

	public virtual void VisitText(TextNode textNode)
	{
	}

	public virtual void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
	{
		writer.StartNode(preProcessorDirective);
		writer.WritePreProcessorDirective(preProcessorDirective.Type, preProcessorDirective.Argument);
		writer.EndNode(preProcessorDirective);
	}

	public virtual void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
	{
		StartNode(typeParameterDeclaration);
		WriteAttributes(typeParameterDeclaration.Attributes);
		switch (typeParameterDeclaration.Variance)
		{
		case VarianceModifier.Covariant:
			WriteKeyword(TypeParameterDeclaration.OutVarianceKeywordRole);
			break;
		case VarianceModifier.Contravariant:
			WriteKeyword(TypeParameterDeclaration.InVarianceKeywordRole);
			break;
		default:
			throw new NotSupportedException("Invalid value for VarianceModifier");
		case VarianceModifier.Invariant:
			break;
		}
		WriteIdentifier(typeParameterDeclaration.NameToken);
		SaveDeclarationOffset();
		EndNode(typeParameterDeclaration);
	}

	public virtual void VisitConstraint(Constraint constraint)
	{
		StartNode(constraint);
		Space();
		WriteKeyword(Roles.WhereKeyword);
		constraint.TypeParameter.AcceptVisitor(this);
		Space();
		WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		Space();
		WriteCommaSeparatedList(constraint.BaseTypes);
		EndNode(constraint);
	}

	public virtual void VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
	{
		if (cSharpTokenNode is CSharpModifierToken cSharpModifierToken)
		{
			if (cSharpModifierToken.Modifier == Modifiers.Async)
			{
				writer.WriteSpecialsUpToNode(cSharpTokenNode);
			}
			int start = writer.GetLocation() ?? 0;
			WriteKeyword(CSharpModifierToken.GetModifierName(cSharpModifierToken.Modifier), cSharpTokenNode.Role);
			if (cSharpModifierToken.Modifier == Modifiers.Async)
			{
				writer.AddHighlightedKeywordReference(currentMethodRefs.AwaitReference, start, writer.GetLocation() ?? 0);
			}
			return;
		}
		throw new NotSupportedException("Should never visit individual tokens");
	}

	public virtual void VisitIdentifier(Identifier identifier)
	{
		WriteIdentifier(identifier, CSharpMetadataTextColorProvider.Instance.GetColor(identifier.Annotation<object>()));
	}

	void IAstVisitor.VisitNullNode(AstNode nullNode)
	{
	}

	void IAstVisitor.VisitErrorNode(AstNode errorNode)
	{
		StartNode(errorNode);
		EndNode(errorNode);
	}

	public virtual void VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
	{
		StartNode(placeholder);
		VisitNodeInPattern(pattern);
		EndNode(placeholder);
	}

	private void VisitAnyNode(AnyNode anyNode)
	{
		if (!string.IsNullOrEmpty(anyNode.GroupName))
		{
			WriteIdentifier(anyNode.GroupName, BoxedTextColor.Text);
			WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		}
	}

	private void VisitBackreference(Backreference backreference)
	{
		WriteKeyword("backreference");
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		WriteIdentifier(backreference.ReferencedGroupName, BoxedTextColor.Text);
		braceHelper.RightParen();
	}

	private void VisitIdentifierExpressionBackreference(IdentifierExpressionBackreference identifierExpressionBackreference)
	{
		WriteKeyword("identifierBackreference");
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		WriteIdentifier(identifierExpressionBackreference.ReferencedGroupName, BoxedTextColor.Text);
		braceHelper.RightParen();
	}

	private void VisitChoice(Choice choice)
	{
		WriteKeyword("choice");
		Space();
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		NewLine();
		writer.Indent();
		foreach (INode item in (IEnumerable<INode>)choice)
		{
			VisitNodeInPattern(item);
			if (item != choice.Last())
			{
				WriteToken(Roles.Comma, BoxedTextColor.Punctuation);
			}
			NewLine();
		}
		writer.Unindent();
		braceHelper.RightParen();
	}

	private void VisitNamedNode(NamedNode namedNode)
	{
		if (!string.IsNullOrEmpty(namedNode.GroupName))
		{
			WriteIdentifier(namedNode.GroupName, BoxedTextColor.Text);
			WriteToken(Roles.Colon, BoxedTextColor.Punctuation);
		}
		VisitNodeInPattern(namedNode.ChildNode);
	}

	private void VisitRepeat(Repeat repeat)
	{
		WriteKeyword("repeat");
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (repeat.MinCount != 0 || repeat.MaxCount != int.MaxValue)
		{
			WriteIdentifier(repeat.MinCount.ToString(), BoxedTextColor.Number);
			WriteToken(Roles.Comma, BoxedTextColor.Punctuation);
			WriteIdentifier(repeat.MaxCount.ToString(), BoxedTextColor.Number);
			WriteToken(Roles.Comma, BoxedTextColor.Punctuation);
		}
		VisitNodeInPattern(repeat.ChildNode);
		braceHelper.RightParen();
	}

	private void VisitOptionalNode(OptionalNode optionalNode)
	{
		WriteKeyword("optional");
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		VisitNodeInPattern(optionalNode.ChildNode);
		braceHelper.RightParen();
	}

	private void VisitNodeInPattern(INode childNode)
	{
		if (childNode is AstNode)
		{
			((AstNode)childNode).AcceptVisitor(this);
		}
		else if (childNode is IdentifierExpressionBackreference)
		{
			VisitIdentifierExpressionBackreference((IdentifierExpressionBackreference)childNode);
		}
		else if (childNode is Choice)
		{
			VisitChoice((Choice)childNode);
		}
		else if (childNode is AnyNode)
		{
			VisitAnyNode((AnyNode)childNode);
		}
		else if (childNode is Backreference)
		{
			VisitBackreference((Backreference)childNode);
		}
		else if (childNode is NamedNode)
		{
			VisitNamedNode((NamedNode)childNode);
		}
		else if (childNode is OptionalNode)
		{
			VisitOptionalNode((OptionalNode)childNode);
		}
		else if (childNode is Repeat)
		{
			VisitRepeat((Repeat)childNode);
		}
		else
		{
			TextWriterTokenWriter.PrintPrimitiveValue(childNode);
		}
	}

	public virtual void VisitDocumentationReference(DocumentationReference documentationReference)
	{
		StartNode(documentationReference);
		if (!documentationReference.DeclaringType.IsNull)
		{
			documentationReference.DeclaringType.AcceptVisitor(this);
			if (documentationReference.SymbolKind != SymbolKind.TypeDefinition)
			{
				WriteToken(Roles.Dot, BoxedTextColor.Operator);
			}
		}
		switch (documentationReference.SymbolKind)
		{
		case SymbolKind.Indexer:
			WriteKeyword(IndexerDeclaration.ThisKeywordRole);
			break;
		case SymbolKind.Operator:
		{
			OperatorType operatorType = documentationReference.OperatorType;
			switch (operatorType)
			{
			case OperatorType.Explicit:
				WriteKeyword(OperatorDeclaration.ExplicitRole);
				break;
			case OperatorType.Implicit:
				WriteKeyword(OperatorDeclaration.ImplicitRole);
				break;
			}
			WriteKeyword(OperatorDeclaration.OperatorKeywordRole);
			Space();
			if (operatorType == OperatorType.Explicit || operatorType == OperatorType.Implicit)
			{
				documentationReference.ConversionOperatorReturnType.AcceptVisitor(this);
			}
			else
			{
				WriteTokenOperatorOrKeyword(OperatorDeclaration.GetToken(operatorType), OperatorDeclaration.GetRole(operatorType));
			}
			break;
		}
		default:
			WriteIdentifier(documentationReference.GetChildByRole(Roles.Identifier), BoxedTextColor.Text);
			break;
		case SymbolKind.TypeDefinition:
			break;
		}
		WriteTypeArguments(documentationReference.TypeArguments, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		if (documentationReference.HasParameterList)
		{
			Space(policy.SpaceBeforeMethodDeclarationParentheses);
			if (documentationReference.SymbolKind == SymbolKind.Indexer)
			{
				WriteCommaSeparatedListInBrackets(documentationReference.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_SquareBrackets);
			}
			else
			{
				WriteCommaSeparatedListInParenthesis(documentationReference.Parameters, policy.SpaceWithinMethodDeclarationParentheses, CodeBracesRangeFlags.BraceKind_Parentheses);
			}
		}
		EndNode(documentationReference);
	}

	public static string ConvertString(string text)
	{
		return TextWriterTokenWriter.ConvertString(text);
	}
}
