using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.VB.Ast;

namespace ICSharpCode.NRefactory.VB;

public class OutputVisitor : IAstVisitor<object, object>
{
	private struct MethodRefs
	{
		public object MethodReference;

		public static MethodRefs Create()
		{
			return new MethodRefs
			{
				MethodReference = new object()
			};
		}
	}

	private enum LastWritten
	{
		Whitespace,
		Other,
		KeywordOrIdentifier
	}

	private struct BraceHelper
	{
		private readonly OutputVisitor owner;

		private readonly CodeBracesRangeFlags flags;

		private int leftStart;

		private int leftEnd;

		private BraceHelper(OutputVisitor owner, CodeBracesRangeFlags flags)
		{
			this.owner = owner;
			leftStart = owner.formatter.NextPosition;
			leftEnd = 0;
			this.flags = flags;
		}

		public static BraceHelper LeftParen(OutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken("(", AstNode.Roles.LPar, BoxedTextColor.Punctuation);
			result.leftEnd = owner.formatter.NextPosition;
			return result;
		}

		public void RightParen()
		{
			int nextPosition = owner.formatter.NextPosition;
			owner.WriteToken(")", AstNode.Roles.LPar, BoxedTextColor.Punctuation);
			int nextPosition2 = owner.formatter.NextPosition;
			owner.formatter.AddBracePair(leftStart, leftEnd, nextPosition, nextPosition2, flags);
		}

		public static BraceHelper LeftChevron(OutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken("<", AstNode.Roles.LChevron, BoxedTextColor.Punctuation);
			result.leftEnd = owner.formatter.NextPosition;
			return result;
		}

		public void RightChevron()
		{
			int nextPosition = owner.formatter.NextPosition;
			owner.WriteToken(">", AstNode.Roles.RChevron, BoxedTextColor.Punctuation);
			int nextPosition2 = owner.formatter.NextPosition;
			owner.formatter.AddBracePair(leftStart, leftEnd, nextPosition, nextPosition2, flags);
		}

		public static BraceHelper LeftBrace(OutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken("{", AstNode.Roles.LBrace, BoxedTextColor.Punctuation);
			result.leftEnd = owner.formatter.NextPosition;
			return result;
		}

		public void RightBrace()
		{
			int nextPosition = owner.formatter.NextPosition;
			owner.WriteToken("}", AstNode.Roles.RBrace, BoxedTextColor.Punctuation);
			int nextPosition2 = owner.formatter.NextPosition;
			owner.formatter.AddBracePair(leftStart, leftEnd, nextPosition, nextPosition2, flags);
		}

		public static BraceHelper LeftBracket(OutputVisitor owner, CodeBracesRangeFlags flags)
		{
			BraceHelper result = new BraceHelper(owner, flags);
			owner.WriteToken("[", AstNode.Roles.LBracket, BoxedTextColor.Punctuation);
			result.leftEnd = owner.formatter.NextPosition;
			return result;
		}

		public void RightBracket()
		{
			int nextPosition = owner.formatter.NextPosition;
			owner.WriteToken("]", AstNode.Roles.RBracket, BoxedTextColor.Punctuation);
			int nextPosition2 = owner.formatter.NextPosition;
			owner.formatter.AddBracePair(leftStart, leftEnd, nextPosition, nextPosition2, flags);
		}
	}

	private readonly IOutputFormatter formatter;

	private readonly VBFormattingOptions policy;

	private readonly Stack<AstNode> containerStack = new Stack<AstNode>();

	private readonly Stack<AstNode> positionStack = new Stack<AstNode>();

	private MethodRefs currentMethodRefs;

	private object currentTryReference;

	private object currentDoReference;

	private object currentForReference;

	private object currentWhileReference;

	private object currentSelectReference;

	private int lastEndBlockOffset;

	private int lastDeclarationOffset;

	private LastWritten lastWritten;

	private static readonly UTF8String stringMicrosoftVisualBasicCompilerServices = new UTF8String("Microsoft.VisualBasic.CompilerServices");

	private static readonly UTF8String stringStandardModuleAttribute = new UTF8String("StandardModuleAttribute");

	private static readonly HashSet<string> unconditionalKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"AddHandler", "AddressOf", "Alias", "And", "AndAlso", "As", "Boolean", "ByRef", "Byte", "ByVal",
		"Call", "Case", "Catch", "CBool", "CByte", "CChar", "CInt", "Class", "CLng", "CObj",
		"Const", "Continue", "CSByte", "CShort", "CSng", "CStr", "CType", "CUInt", "CULng", "CUShort",
		"Date", "Decimal", "Declare", "Default", "Delegate", "Dim", "DirectCast", "Do", "Double", "Each",
		"Else", "ElseIf", "End", "EndIf", "Enum", "Erase", "Error", "Event", "Exit", "False",
		"Finally", "For", "Friend", "Function", "Get", "GetType", "GetXmlNamespace", "Global", "GoSub", "GoTo",
		"Handles", "If", "Implements", "Imports", "In", "Inherits", "Integer", "Interface", "Is", "IsNot",
		"Let", "Lib", "Like", "Long", "Loop", "Me", "Mod", "Module", "MustInherit", "MustOverride",
		"MyBase", "MyClass", "Namespace", "Narrowing", "Next", "Not", "Nothing", "NotInheritable", "NotOverridable", "Object",
		"Of", "On", "Operator", "Option", "Optional", "Or", "OrElse", "Overloads", "Overridable", "Overrides",
		"ParamArray", "Partial", "Private", "Property", "Protected", "Public", "RaiseEvent", "ReadOnly", "ReDim", "REM",
		"RemoveHandler", "Resume", "Return", "SByte", "Select", "Set", "Shadows", "Shared", "Short", "Single",
		"Static", "Step", "Stop", "String", "Structure", "Sub", "SyncLock", "Then", "Throw", "To",
		"True", "Try", "TryCast", "TypeOf", "UInteger", "ULong", "UShort", "Using", "Variant", "Wend",
		"When", "While", "Widening", "With", "WithEvents", "WriteOnly", "Xor"
	};

	private static readonly HashSet<string> queryKeywords = new HashSet<string>();

	private bool isElseIfStatement;

	private object currentIfReference;

	private int elseIfStartPos;

	private void SaveDeclarationOffset()
	{
		lastDeclarationOffset = formatter.NextPosition;
	}

	public OutputVisitor(TextWriter textWriter, VBFormattingOptions formattingPolicy)
	{
		if (textWriter == null)
		{
			throw new ArgumentNullException("textWriter");
		}
		if (formattingPolicy == null)
		{
			throw new ArgumentNullException("formattingPolicy");
		}
		formatter = new TextWriterOutputFormatter(textWriter);
		policy = formattingPolicy;
	}

	public OutputVisitor(IOutputFormatter formatter, VBFormattingOptions formattingPolicy)
	{
		if (formatter == null)
		{
			throw new ArgumentNullException("formatter");
		}
		if (formattingPolicy == null)
		{
			throw new ArgumentNullException("formattingPolicy");
		}
		this.formatter = formatter;
		policy = formattingPolicy;
	}

	private static CodeBracesRangeFlags GetTypeBlockKind(AstNode node)
	{
		TypeDef typeDef = node.Annotation<TypeDef>();
		if (typeDef != null)
		{
			if (typeDef.IsInterface)
			{
				return CodeBracesRangeFlags.BlockKind_Interface;
			}
			if (typeDef.IsValueType)
			{
				return CodeBracesRangeFlags.BlockKind_ValueType;
			}
			if (IsModule(typeDef))
			{
				return CodeBracesRangeFlags.BlockKind_Module;
			}
		}
		return CodeBracesRangeFlags.BlockKind_Type;
	}

	private static bool IsModule(TypeDef type)
	{
		if (type != null && type.DeclaringType == null && type.IsSealed)
		{
			return type.IsDefined(stringMicrosoftVisualBasicCompilerServices, stringStandardModuleAttribute);
		}
		return false;
	}

	private bool MaybeNewLinesAfterUsings(AstNode node)
	{
		AstNode nextSibling = node.NextSibling;
		if (node is ImportsStatement && !(nextSibling is ImportsStatement))
		{
			for (int i = 0; i < 1; i++)
			{
				NewLine();
			}
			return true;
		}
		return false;
	}

	public object VisitCompilationUnit(ICSharpCode.NRefactory.VB.Ast.CompilationUnit compilationUnit, object data)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		foreach (AstNode child in compilationUnit.Children)
		{
			num++;
			child.AcceptVisitor(this, data);
			if (MaybeNewLinesAfterUsings(child) || child is ICSharpCode.NRefactory.VB.Ast.NamespaceDeclaration)
			{
				num2 = Math.Max(lastEndBlockOffset, lastDeclarationOffset);
				formatter.AddLineSeparator(num2);
				flag = true;
			}
			else
			{
				flag = false;
			}
		}
		if (!flag && num > 0)
		{
			int num3 = Math.Max(lastEndBlockOffset, lastDeclarationOffset);
			if (num3 != num2 && num3 != 0)
			{
				formatter.AddLineSeparator(num3);
			}
		}
		return null;
	}

	public object VisitBlockStatement(ICSharpCode.NRefactory.VB.Ast.BlockStatement blockStatement, object data)
	{
		NewLine();
		Indent();
		StartNode(blockStatement);
		foreach (ICSharpCode.NRefactory.VB.Ast.Statement item in (IEnumerable<ICSharpCode.NRefactory.VB.Ast.Statement>)blockStatement)
		{
			item.AcceptVisitor(this, data);
			NewLine();
		}
		Unindent();
		return EndNode(blockStatement);
	}

	public object VisitPatternPlaceholder(AstNode placeholder, Pattern pattern, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitTypeParameterDeclaration(ICSharpCode.NRefactory.VB.Ast.TypeParameterDeclaration typeParameterDeclaration, object data)
	{
		StartNode(typeParameterDeclaration);
		switch (typeParameterDeclaration.Variance)
		{
		case VarianceModifier.Covariant:
			WriteKeyword("Out");
			break;
		case VarianceModifier.Contravariant:
			WriteKeyword("In");
			break;
		default:
			throw new Exception("Invalid value for VarianceModifier");
		case VarianceModifier.Invariant:
			break;
		}
		WriteIdentifier(typeParameterDeclaration.NameToken);
		if (typeParameterDeclaration.Constraints.Any())
		{
			WriteKeyword("As");
			if (typeParameterDeclaration.Constraints.Count > 1)
			{
				BraceHelper braceHelper = BraceHelper.LeftBrace(this, CodeBracesRangeFlags.BraceKind_CurlyBraces);
				WriteCommaSeparatedList(typeParameterDeclaration.Constraints);
				braceHelper.RightBrace();
			}
			else
			{
				WriteCommaSeparatedList(typeParameterDeclaration.Constraints);
			}
		}
		SaveDeclarationOffset();
		return EndNode(typeParameterDeclaration);
	}

	public object VisitParameterDeclaration(ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration parameterDeclaration, object data)
	{
		StartNode(parameterDeclaration);
		WriteAttributes(parameterDeclaration.Attributes);
		WriteModifiers(parameterDeclaration.ModifierTokens);
		WriteIdentifier(parameterDeclaration.Name);
		if (!parameterDeclaration.Type.IsNull)
		{
			WriteKeyword("As");
			parameterDeclaration.Type.AcceptVisitor(this, data);
		}
		if (!parameterDeclaration.OptionalValue.IsNull)
		{
			Space();
			WriteToken("=", AstNode.Roles.Assign, BoxedTextColor.Operator);
			Space();
			parameterDeclaration.OptionalValue.AcceptVisitor(this, data);
		}
		SaveDeclarationOffset();
		return EndNode(parameterDeclaration);
	}

	public object VisitVBTokenNode(VBTokenNode vBTokenNode, object data)
	{
		if (vBTokenNode is VBModifierToken vBModifierToken)
		{
			StartNode(vBTokenNode);
			WriteKeyword(VBModifierToken.GetModifierName(vBModifierToken.Modifier));
			return EndNode(vBTokenNode);
		}
		throw new NotSupportedException("Should never visit individual tokens");
	}

	public object VisitAliasImportsClause(AliasImportsClause aliasImportsClause, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitAttribute(ICSharpCode.NRefactory.VB.Ast.Attribute attribute, object data)
	{
		StartNode(attribute);
		if (attribute.Target != AttributeTarget.None)
		{
			switch (attribute.Target)
			{
			case AttributeTarget.Assembly:
				WriteKeyword("Assembly");
				break;
			case AttributeTarget.Module:
				WriteKeyword("Module");
				break;
			default:
				throw new Exception("Invalid value for AttributeTarget");
			case AttributeTarget.None:
				break;
			}
			WriteToken(":", AstNode.Roles.Colon, BoxedTextColor.Punctuation);
			Space();
		}
		attribute.Type.AcceptVisitor(this, data);
		WriteCommaSeparatedListInParenthesis(attribute.Arguments, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(attribute);
	}

	public object VisitAttributeBlock(AttributeBlock attributeBlock, object data)
	{
		StartNode(attributeBlock);
		BraceHelper braceHelper = BraceHelper.LeftChevron(this, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		WriteCommaSeparatedList(attributeBlock.Attributes);
		braceHelper.RightChevron();
		if (attributeBlock.Parent is ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration)
		{
			Space();
		}
		else if (attributeBlock.Parent is ICSharpCode.NRefactory.VB.Ast.DelegateDeclaration && ((ICSharpCode.NRefactory.VB.Ast.DelegateDeclaration)attributeBlock.Parent).ReturnTypeAttributes.Contains(attributeBlock))
		{
			Space();
		}
		else if (attributeBlock.Parent is ICSharpCode.NRefactory.VB.Ast.MethodDeclaration && ((ICSharpCode.NRefactory.VB.Ast.MethodDeclaration)attributeBlock.Parent).ReturnTypeAttributes.Contains(attributeBlock))
		{
			Space();
		}
		else if (attributeBlock.Parent is ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration && ((ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration)attributeBlock.Parent).ReturnTypeAttributes.Contains(attributeBlock))
		{
			Space();
		}
		else if (attributeBlock.Parent is ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration && ((ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration)attributeBlock.Parent).ReturnTypeAttributes.Contains(attributeBlock))
		{
			Space();
		}
		else if (attributeBlock.Parent is ExternalMethodDeclaration && ((ExternalMethodDeclaration)attributeBlock.Parent).ReturnTypeAttributes.Contains(attributeBlock))
		{
			Space();
		}
		else
		{
			NewLine();
		}
		return EndNode(attributeBlock);
	}

	public object VisitImportsStatement(ImportsStatement importsStatement, object data)
	{
		StartNode(importsStatement);
		WriteKeyword("Imports", AstNode.Roles.Keyword);
		Space();
		WriteCommaSeparatedList(importsStatement.ImportsClauses);
		SaveDeclarationOffset();
		NewLine();
		return EndNode(importsStatement);
	}

	public object VisitMemberImportsClause(MemberImportsClause memberImportsClause, object data)
	{
		StartNode(memberImportsClause);
		memberImportsClause.Member.AcceptVisitor(this, data);
		return EndNode(memberImportsClause);
	}

	public object VisitNamespaceDeclaration(ICSharpCode.NRefactory.VB.Ast.NamespaceDeclaration namespaceDeclaration, object data)
	{
		StartNode(namespaceDeclaration);
		object reference = new object();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteKeyword("Namespace");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		bool flag = true;
		foreach (ICSharpCode.NRefactory.VB.Ast.Identifier identifier in namespaceDeclaration.Identifiers)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
			}
			identifier.AcceptVisitor(this, null);
			MaybeNewLinesAfterUsings(identifier);
		}
		NewLine();
		WriteMembers(namespaceDeclaration.Members);
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Namespace);
		WriteKeyword("End");
		WriteKeyword("Namespace");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		SaveDeclarationOffset();
		NewLine();
		return EndNode(namespaceDeclaration);
	}

	public object VisitOptionStatement(OptionStatement optionStatement, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitTypeDeclaration(ICSharpCode.NRefactory.VB.Ast.TypeDeclaration typeDeclaration, object data)
	{
		StartNode(typeDeclaration);
		WriteAttributes(typeDeclaration.Attributes);
		object reference = new object();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteModifiers(typeDeclaration.ModifierTokens);
		WriteClassTypeKeyword(typeDeclaration);
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		WriteIdentifier(typeDeclaration.Name);
		WriteTypeParameters(typeDeclaration.TypeParameters, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		NewLine();
		if (!typeDeclaration.InheritsType.IsNull)
		{
			Indent();
			WriteKeyword("Inherits");
			typeDeclaration.InheritsType.AcceptVisitor(this, data);
			Unindent();
			NewLine();
		}
		if (typeDeclaration.ImplementsTypes.Any())
		{
			Indent();
			WriteImplementsClause(typeDeclaration.ImplementsTypes, typeDeclaration.ClassType == ICSharpCode.NRefactory.VB.Ast.ClassType.Interface);
			Unindent();
			NewLine();
		}
		if (!typeDeclaration.InheritsType.IsNull || typeDeclaration.ImplementsTypes.Any())
		{
			NewLine();
		}
		WriteMembers(typeDeclaration.Members);
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, GetTypeBlockKind(typeDeclaration));
		WriteKeyword("End");
		WriteClassTypeKeyword(typeDeclaration);
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		SaveDeclarationOffset();
		NewLine();
		return EndNode(typeDeclaration);
	}

	private void WriteClassTypeKeyword(ICSharpCode.NRefactory.VB.Ast.TypeDeclaration typeDeclaration)
	{
		switch (typeDeclaration.ClassType)
		{
		case ICSharpCode.NRefactory.VB.Ast.ClassType.Class:
			WriteKeyword("Class");
			break;
		case ICSharpCode.NRefactory.VB.Ast.ClassType.Interface:
			WriteKeyword("Interface");
			break;
		case ICSharpCode.NRefactory.VB.Ast.ClassType.Struct:
			WriteKeyword("Structure");
			break;
		case ICSharpCode.NRefactory.VB.Ast.ClassType.Module:
			WriteKeyword("Module");
			break;
		default:
			throw new Exception("Invalid value for ClassType");
		}
	}

	public object VisitXmlNamespaceImportsClause(XmlNamespaceImportsClause xmlNamespaceImportsClause, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitEnumDeclaration(EnumDeclaration enumDeclaration, object data)
	{
		StartNode(enumDeclaration);
		WriteAttributes(enumDeclaration.Attributes);
		object reference = new object();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteModifiers(enumDeclaration.ModifierTokens);
		WriteKeyword("Enum");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		WriteIdentifier(enumDeclaration.Name);
		if (!enumDeclaration.UnderlyingType.IsNull)
		{
			Space();
			WriteKeyword("As");
			enumDeclaration.UnderlyingType.AcceptVisitor(this, data);
		}
		NewLine();
		Indent();
		foreach (ICSharpCode.NRefactory.VB.Ast.EnumMemberDeclaration member in enumDeclaration.Members)
		{
			member.AcceptVisitor(this, null);
		}
		Unindent();
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_ValueType);
		WriteKeyword("End");
		WriteKeyword("Enum");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		SaveDeclarationOffset();
		NewLine();
		return EndNode(enumDeclaration);
	}

	public object VisitEnumMemberDeclaration(ICSharpCode.NRefactory.VB.Ast.EnumMemberDeclaration enumMemberDeclaration, object data)
	{
		StartNode(enumMemberDeclaration);
		WriteAttributes(enumMemberDeclaration.Attributes);
		WriteIdentifier(enumMemberDeclaration.Name);
		if (!enumMemberDeclaration.Value.IsNull)
		{
			Space();
			WriteToken("=", AstNode.Roles.Assign, BoxedTextColor.Operator);
			Space();
			enumMemberDeclaration.Value.AcceptVisitor(this, data);
		}
		SaveDeclarationOffset();
		NewLine();
		return EndNode(enumMemberDeclaration);
	}

	public object VisitDelegateDeclaration(ICSharpCode.NRefactory.VB.Ast.DelegateDeclaration delegateDeclaration, object data)
	{
		StartNode(delegateDeclaration);
		WriteAttributes(delegateDeclaration.Attributes);
		WriteModifiers(delegateDeclaration.ModifierTokens);
		WriteKeyword("Delegate");
		if (delegateDeclaration.IsSub)
		{
			WriteKeyword("Sub");
		}
		else
		{
			WriteKeyword("Function");
		}
		WriteIdentifier(delegateDeclaration.Name);
		WriteTypeParameters(delegateDeclaration.TypeParameters, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		WriteCommaSeparatedListInParenthesis(delegateDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (!delegateDeclaration.IsSub)
		{
			Space();
			WriteKeyword("As");
			Space();
			WriteAttributes(delegateDeclaration.ReturnTypeAttributes);
			delegateDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		SaveDeclarationOffset();
		NewLine();
		return EndNode(delegateDeclaration);
	}

	public object VisitIdentifier(ICSharpCode.NRefactory.VB.Ast.Identifier identifier, object data)
	{
		StartNode(identifier);
		WriteIdentifier(identifier);
		WriteTypeCharacter(identifier.TypeCharacter, VisualBasicMetadataTextColorProvider.Instance.GetColor(identifier.Annotation<object>()));
		return EndNode(identifier);
	}

	public object VisitXmlIdentifier(XmlIdentifier xmlIdentifier, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitXmlLiteralString(XmlLiteralString xmlLiteralString, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitSimpleNameExpression(SimpleNameExpression simpleNameExpression, object data)
	{
		DebugExpression(simpleNameExpression);
		StartNode(simpleNameExpression);
		simpleNameExpression.Identifier.AcceptVisitor(this, data);
		WriteTypeArguments(simpleNameExpression.TypeArguments, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(simpleNameExpression);
	}

	public object VisitPrimitiveExpression(ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression primitiveExpression, object data)
	{
		DebugExpression(primitiveExpression);
		StartNode(primitiveExpression);
		if (lastWritten == LastWritten.KeywordOrIdentifier)
		{
			Space();
		}
		WritePrimitiveValue(primitiveExpression.Value);
		return EndNode(primitiveExpression);
	}

	public object VisitInstanceExpression(InstanceExpression instanceExpression, object data)
	{
		DebugExpression(instanceExpression);
		StartNode(instanceExpression);
		switch (instanceExpression.Type)
		{
		case InstanceExpressionType.Me:
			WriteKeyword("Me");
			break;
		case InstanceExpressionType.MyBase:
			WriteKeyword("MyBase");
			break;
		case InstanceExpressionType.MyClass:
			WriteKeyword("MyClass");
			break;
		default:
			throw new Exception("Invalid value for InstanceExpressionType");
		}
		return EndNode(instanceExpression);
	}

	public object VisitParenthesizedExpression(ICSharpCode.NRefactory.VB.Ast.ParenthesizedExpression parenthesizedExpression, object data)
	{
		DebugExpression(parenthesizedExpression);
		StartNode(parenthesizedExpression);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		parenthesizedExpression.Expression.AcceptVisitor(this, data);
		braceHelper.RightParen();
		return EndNode(parenthesizedExpression);
	}

	public object VisitGetTypeExpression(GetTypeExpression getTypeExpression, object data)
	{
		DebugExpression(getTypeExpression);
		StartNode(getTypeExpression);
		WriteKeyword("GetType");
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		getTypeExpression.Type.AcceptVisitor(this, data);
		braceHelper.RightParen();
		return EndNode(getTypeExpression);
	}

	public object VisitTypeOfIsExpression(TypeOfIsExpression typeOfIsExpression, object data)
	{
		DebugExpression(typeOfIsExpression);
		StartNode(typeOfIsExpression);
		WriteKeyword("TypeOf");
		typeOfIsExpression.TypeOfExpression.AcceptVisitor(this, data);
		WriteKeyword("Is");
		typeOfIsExpression.Type.AcceptVisitor(this, data);
		return EndNode(typeOfIsExpression);
	}

	public object VisitGetXmlNamespaceExpression(GetXmlNamespaceExpression getXmlNamespaceExpression, object data)
	{
		throw new NotImplementedException();
	}

	public object VisitMemberAccessExpression(MemberAccessExpression memberAccessExpression, object data)
	{
		DebugExpression(memberAccessExpression);
		StartNode(memberAccessExpression);
		memberAccessExpression.Target.AcceptVisitor(this, data);
		WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
		memberAccessExpression.MemberName.AcceptVisitor(this, data);
		WriteTypeArguments(memberAccessExpression.TypeArguments, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(memberAccessExpression);
	}

	public object VisitTypeReferenceExpression(ICSharpCode.NRefactory.VB.Ast.TypeReferenceExpression typeReferenceExpression, object data)
	{
		DebugExpression(typeReferenceExpression);
		StartNode(typeReferenceExpression);
		typeReferenceExpression.Type.AcceptVisitor(this, data);
		return EndNode(typeReferenceExpression);
	}

	public object VisitEventMemberSpecifier(EventMemberSpecifier eventMemberSpecifier, object data)
	{
		StartNode(eventMemberSpecifier);
		eventMemberSpecifier.Target.AcceptVisitor(this, data);
		WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
		eventMemberSpecifier.Member.AcceptVisitor(this, data);
		return EndNode(eventMemberSpecifier);
	}

	public object VisitInterfaceMemberSpecifier(InterfaceMemberSpecifier interfaceMemberSpecifier, object data)
	{
		StartNode(interfaceMemberSpecifier);
		interfaceMemberSpecifier.Target.AcceptVisitor(this, data);
		WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
		interfaceMemberSpecifier.Member.AcceptVisitor(this, data);
		return EndNode(interfaceMemberSpecifier);
	}

	public object VisitConstructorDeclaration(ICSharpCode.NRefactory.VB.Ast.ConstructorDeclaration constructorDeclaration, object data)
	{
		StartNode(constructorDeclaration);
		WriteAttributes(constructorDeclaration.Attributes);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		MethodDebugInfoBuilder methodDebugInfoBuilder = constructorDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = nextPosition;
		}
		WriteModifiers(constructorDeclaration.ModifierTokens);
		if (lastWritten != LastWritten.Whitespace)
		{
			Space();
		}
		DebugStart(constructorDeclaration);
		DebugHidden(constructorDeclaration.Body.HiddenStart);
		WriteKeyword("Sub");
		WriteKeyword("New");
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		DebugEnd(constructorDeclaration, addSelf: false);
		WriteCommaSeparatedListInParenthesis(constructorDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		WriteBlock(constructorDeclaration.Body);
		DebugStart(constructorDeclaration);
		DebugHidden(constructorDeclaration.Body.HiddenEnd);
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Constructor);
		WriteKeyword("End");
		WriteKeyword("Sub");
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = formatter.NextPosition;
		}
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		SaveDeclarationOffset();
		DebugEnd(constructorDeclaration, addSelf: false);
		NewLine();
		currentMethodRefs = methodRefs;
		return EndNode(constructorDeclaration);
	}

	public object VisitMethodDeclaration(ICSharpCode.NRefactory.VB.Ast.MethodDeclaration methodDeclaration, object data)
	{
		StartNode(methodDeclaration);
		WriteAttributes(methodDeclaration.Attributes);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		MethodDebugInfoBuilder methodDebugInfoBuilder = methodDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = nextPosition;
		}
		WriteModifiers(methodDeclaration.ModifierTokens);
		DebugStart(methodDeclaration);
		DebugHidden(methodDeclaration.Body.HiddenStart);
		if (methodDeclaration.IsSub)
		{
			WriteKeyword("Sub");
		}
		else
		{
			WriteKeyword("Function");
		}
		if (!methodDeclaration.Body.IsNull)
		{
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		}
		DebugEnd(methodDeclaration, addSelf: false);
		methodDeclaration.Name.AcceptVisitor(this, data);
		WriteTypeParameters(methodDeclaration.TypeParameters, CodeBracesRangeFlags.BraceKind_AngleBrackets);
		WriteCommaSeparatedListInParenthesis(methodDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (!methodDeclaration.IsSub && !methodDeclaration.ReturnType.IsNull)
		{
			Space();
			WriteKeyword("As");
			Space();
			WriteAttributes(methodDeclaration.ReturnTypeAttributes);
			methodDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		WriteHandlesClause(methodDeclaration.HandlesClause);
		WriteImplementsClause(methodDeclaration.ImplementsClause);
		if (!methodDeclaration.Body.IsNull)
		{
			WriteBlock(methodDeclaration.Body);
			DebugStart(methodDeclaration);
			DebugHidden(methodDeclaration.Body.HiddenEnd);
			nextPosition = (lastEndBlockOffset = formatter.NextPosition);
			formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Method);
			WriteKeyword("End");
			if (methodDeclaration.IsSub)
			{
				WriteKeyword("Sub");
			}
			else
			{
				WriteKeyword("Function");
			}
			if (methodDebugInfoBuilder != null)
			{
				methodDebugInfoBuilder.EndPosition = formatter.NextPosition;
			}
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
			DebugEnd(methodDeclaration, addSelf: false);
		}
		SaveDeclarationOffset();
		NewLine();
		currentMethodRefs = methodRefs;
		return EndNode(methodDeclaration);
	}

	public object VisitFieldDeclaration(ICSharpCode.NRefactory.VB.Ast.FieldDeclaration fieldDeclaration, object data)
	{
		StartNode(fieldDeclaration);
		WriteAttributes(fieldDeclaration.Attributes);
		WriteModifiers(fieldDeclaration.ModifierTokens);
		if (lastWritten != LastWritten.Whitespace)
		{
			Space();
		}
		DebugStart(fieldDeclaration);
		WriteCommaSeparatedList(fieldDeclaration.Variables);
		DebugEnd(fieldDeclaration);
		SaveDeclarationOffset();
		NewLine();
		return EndNode(fieldDeclaration);
	}

	public object VisitPropertyDeclaration(ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration propertyDeclaration, object data)
	{
		StartNode(propertyDeclaration);
		WriteAttributes(propertyDeclaration.Attributes);
		bool flag = !propertyDeclaration.Getter.Body.IsNull || !propertyDeclaration.Setter.Body.IsNull;
		object reference = new object();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteModifiers(propertyDeclaration.ModifierTokens);
		WriteKeyword("Property");
		if (flag)
		{
			formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		}
		WriteIdentifier(propertyDeclaration.Name);
		if (propertyDeclaration.Parameters.Any())
		{
			WriteCommaSeparatedListInParenthesis(propertyDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		if (!propertyDeclaration.ReturnType.IsNull)
		{
			Space();
			WriteKeyword("As");
			Space();
			WriteAttributes(propertyDeclaration.ReturnTypeAttributes);
			propertyDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		WriteImplementsClause(propertyDeclaration.ImplementsClause);
		if (flag)
		{
			NewLine();
			Indent();
			if (!propertyDeclaration.Getter.Body.IsNull)
			{
				propertyDeclaration.Getter.AcceptVisitor(this, data);
			}
			if (!propertyDeclaration.Setter.Body.IsNull)
			{
				propertyDeclaration.Setter.AcceptVisitor(this, data);
			}
			Unindent();
			nextPosition = (lastEndBlockOffset = formatter.NextPosition);
			formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Property);
			WriteKeyword("End");
			WriteKeyword("Property");
			formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		}
		SaveDeclarationOffset();
		if (propertyDeclaration.Variables.Any())
		{
			WriteCommaSeparatedList(propertyDeclaration.Variables);
		}
		NewLine();
		return EndNode(propertyDeclaration);
	}

	public object VisitPrimitiveType(ICSharpCode.NRefactory.VB.Ast.PrimitiveType primitiveType, object data)
	{
		StartNode(primitiveType);
		WriteKeyword(primitiveType.Keyword);
		return EndNode(primitiveType);
	}

	public object VisitQualifiedType(QualifiedType qualifiedType, object data)
	{
		StartNode(qualifiedType);
		qualifiedType.Target.AcceptVisitor(this, data);
		WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
		WriteIdentifier(qualifiedType.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(qualifiedType.NameToken.Annotation<object>() ?? qualifiedType.Annotation<object>()), null, qualifiedType.NameToken.Annotation<NamespaceReference>());
		WriteTypeArguments(qualifiedType.TypeArguments, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(qualifiedType);
	}

	public object VisitComposedType(ICSharpCode.NRefactory.VB.Ast.ComposedType composedType, object data)
	{
		StartNode(composedType);
		composedType.BaseType.AcceptVisitor(this, data);
		if (composedType.HasNullableSpecifier)
		{
			WriteToken("?", AstNode.Roles.QuestionMark, BoxedTextColor.Punctuation);
		}
		WriteArraySpecifiers(composedType.ArraySpecifiers);
		return EndNode(composedType);
	}

	public object VisitArraySpecifier(ICSharpCode.NRefactory.VB.Ast.ArraySpecifier arraySpecifier, object data)
	{
		StartNode(arraySpecifier);
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		for (int i = 0; i < arraySpecifier.Dimensions - 1; i++)
		{
			WriteToken(",", AstNode.Roles.Comma, BoxedTextColor.Punctuation);
		}
		braceHelper.RightParen();
		return EndNode(arraySpecifier);
	}

	public object VisitSimpleType(ICSharpCode.NRefactory.VB.Ast.SimpleType simpleType, object data)
	{
		StartNode(simpleType);
		if (simpleType.Identifier.Length != 0 || !ICSharpCode.NRefactory.CSharp.SimpleType.DummyTypeGenericParam.Equals(simpleType.Annotation<string>(), StringComparison.Ordinal))
		{
			WriteIdentifier(simpleType.Identifier, VisualBasicMetadataTextColorProvider.Instance.GetColor(simpleType.IdentifierToken.Annotation<object>() ?? simpleType.Annotation<object>()), null, simpleType.IdentifierToken.Annotation<NamespaceReference>());
		}
		WriteTypeArguments(simpleType.TypeArguments, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(simpleType);
	}

	private void StartNode(AstNode node)
	{
		if (positionStack.Count > 0)
		{
			WriteSpecialsUpToNode(node);
		}
		containerStack.Push(node);
		positionStack.Push(node.FirstChild);
		formatter.StartNode(node);
		for (AstNode astNode = node.FirstChild; astNode is Comment comment; astNode = astNode.NextSibling)
		{
			WriteComment(comment);
		}
	}

	private object EndNode(AstNode node)
	{
		AstNode start = positionStack.Pop();
		WriteSpecials(start, null);
		containerStack.Pop();
		formatter.EndNode(node);
		return null;
	}

	private void DebugStart(AstNode node)
	{
		formatter.DebugStart(node);
	}

	private void DebugHidden(object hiddenILSpans)
	{
		formatter.DebugHidden(hiddenILSpans);
	}

	private int DebugStart(AstNode node, string keyword)
	{
		return WriteKeyword(keyword, null, node);
	}

	private void DebugExpression(AstNode node)
	{
		formatter.DebugExpression(node);
	}

	private void DebugEnd(AstNode node, bool addSelf = true)
	{
		if (addSelf)
		{
			formatter.DebugExpression(node);
		}
		formatter.DebugEnd(node);
	}

	private void WriteSpecials(AstNode start, AstNode end)
	{
		for (AstNode astNode = start; astNode != end; astNode = astNode.NextSibling)
		{
			if (astNode.Role == AstNode.Roles.Comment)
			{
				astNode.AcceptVisitor(this, null);
			}
		}
	}

	private void WriteSpecialsUpToRole(Role role)
	{
		for (AstNode astNode = positionStack.Peek(); astNode != null; astNode = astNode.NextSibling)
		{
			if (astNode.Role == role)
			{
				WriteSpecials(positionStack.Pop(), astNode);
				positionStack.Push(astNode);
				break;
			}
		}
	}

	private void WriteSpecialsUpToNode(AstNode node)
	{
		for (AstNode astNode = positionStack.Peek(); astNode != null; astNode = astNode.NextSibling)
		{
			if (astNode == node)
			{
				WriteSpecials(positionStack.Pop(), astNode);
				positionStack.Push(astNode);
				break;
			}
		}
	}

	private void WriteSpecialsUpToRole(Role role, AstNode nextNode)
	{
		AstNode astNode = positionStack.Peek();
		while (astNode != null && astNode != nextNode)
		{
			if (astNode.Role == AstNode.Roles.Comma)
			{
				WriteSpecials(positionStack.Pop(), astNode);
				positionStack.Push(astNode);
				break;
			}
			astNode = astNode.NextSibling;
		}
	}

	private void Comma(AstNode nextNode, bool noSpaceAfterComma = false)
	{
		WriteSpecialsUpToRole(AstNode.Roles.Comma, nextNode);
		formatter.WriteToken(",", BoxedTextColor.Punctuation);
		lastWritten = LastWritten.Other;
		Space(!noSpaceAfterComma);
	}

	private void WriteCommaSeparatedList(IEnumerable<AstNode> list)
	{
		bool flag = true;
		foreach (AstNode item in list)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				Comma(item);
			}
			item.AcceptVisitor(this, null);
		}
	}

	private void WriteCommaSeparatedListInParenthesis(IEnumerable<AstNode> list, bool spaceWithin, CodeBracesRangeFlags flags)
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

	private void WriteCommaSeparatedListInBrackets(IEnumerable<ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration> list, bool spaceWithin)
	{
		BraceHelper braceHelper = BraceHelper.LeftBracket(this, CodeBracesRangeFlags.BraceKind_SquareBrackets);
		if (list.Any())
		{
			Space(spaceWithin);
			WriteCommaSeparatedList(list);
			Space(spaceWithin);
		}
		braceHelper.RightBracket();
	}

	private int WriteKeyword(string keyword, Role<VBTokenNode> tokenRole = null, AstNode node = null)
	{
		WriteSpecialsUpToRole(tokenRole ?? AstNode.Roles.Keyword);
		if (lastWritten == LastWritten.KeywordOrIdentifier)
		{
			formatter.Space();
		}
		int nextPosition = formatter.NextPosition;
		if (node != null)
		{
			DebugStart(node);
		}
		formatter.WriteKeyword(keyword);
		lastWritten = LastWritten.KeywordOrIdentifier;
		return nextPosition;
	}

	private void WriteIdentifier(ICSharpCode.NRefactory.VB.Ast.Identifier identifier, Role<ICSharpCode.NRefactory.VB.Ast.Identifier> identifierRole = null)
	{
		object obj = VisualBasicMetadataTextColorProvider.Instance.GetColor(identifier.Annotation<object>());
		if (BoxedTextColor.Keyword.Equals(obj))
		{
			ILVariable iLVariable = identifier.Annotation<ILVariable>();
			if ((iLVariable != null && iLVariable.IsParameter) || identifier.Parent is ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration)
			{
				obj = BoxedTextColor.Parameter;
			}
		}
		NamespaceReference extraData = identifier.Annotation<NamespaceReference>();
		WriteIdentifier(identifier.Name, obj, identifierRole, extraData);
	}

	private void WriteIdentifier(string identifier, object data, Role<ICSharpCode.NRefactory.VB.Ast.Identifier> identifierRole = null, object extraData = null)
	{
		WriteSpecialsUpToRole(identifierRole ?? AstNode.Roles.Identifier);
		if (lastWritten == LastWritten.KeywordOrIdentifier)
		{
			Space();
		}
		if (IsKeyword(identifier, containerStack.Peek()))
		{
			formatter.WriteIdentifier("[" + identifier + "]", data, extraData);
		}
		else
		{
			formatter.WriteIdentifier(identifier, data, extraData);
		}
		lastWritten = LastWritten.KeywordOrIdentifier;
	}

	private void WriteToken(string token, Role<VBTokenNode> tokenRole, object data)
	{
		WriteSpecialsUpToRole(tokenRole);
		formatter.WriteToken(token, data);
		lastWritten = LastWritten.Other;
	}

	private void WriteTypeCharacter(TypeCode typeCharacter, object data)
	{
		switch (typeCharacter)
		{
		case TypeCode.Int32:
			WriteToken("%", null, data);
			break;
		case TypeCode.Int64:
			WriteToken("&", null, data);
			break;
		case TypeCode.Single:
			WriteToken("!", null, data);
			break;
		case TypeCode.Double:
			WriteToken("#", null, data);
			break;
		case TypeCode.Decimal:
			WriteToken("@", null, data);
			break;
		case TypeCode.String:
			WriteToken("$", null, data);
			break;
		default:
			throw new Exception("Invalid value for TypeCode");
		case TypeCode.Empty:
		case TypeCode.Object:
		case TypeCode.DBNull:
		case TypeCode.Boolean:
		case TypeCode.Char:
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.UInt32:
		case TypeCode.UInt64:
		case TypeCode.DateTime:
			break;
		}
	}

	private void Space(bool addSpace = true)
	{
		if (addSpace)
		{
			formatter.Space();
			lastWritten = LastWritten.Whitespace;
		}
	}

	private void SpaceIfNeeded()
	{
		if (lastWritten != LastWritten.Whitespace)
		{
			Space();
		}
	}

	private void NewLine()
	{
		formatter.NewLine();
		lastWritten = LastWritten.Whitespace;
	}

	private void Indent()
	{
		formatter.Indent();
	}

	private void Unindent()
	{
		formatter.Unindent();
	}

	public static bool IsKeyword(string identifier, AstNode context)
	{
		if (identifier == "New")
		{
			if (context.PrevSibling is InstanceExpression)
			{
				return false;
			}
			return true;
		}
		if (unconditionalKeywords.Contains(identifier))
		{
			return true;
		}
		return false;
	}

	private void WriteTypeArguments(IEnumerable<ICSharpCode.NRefactory.VB.Ast.AstType> typeArguments, CodeBracesRangeFlags flags)
	{
		if (typeArguments.Any())
		{
			BraceHelper braceHelper = BraceHelper.LeftParen(this, flags);
			WriteKeyword("Of");
			WriteCommaSeparatedList(typeArguments);
			braceHelper.RightParen();
		}
	}

	private void WriteTypeParameters(IEnumerable<ICSharpCode.NRefactory.VB.Ast.TypeParameterDeclaration> typeParameters, CodeBracesRangeFlags flags)
	{
		if (typeParameters.Any())
		{
			BraceHelper braceHelper = BraceHelper.LeftParen(this, flags);
			WriteKeyword("Of");
			WriteCommaSeparatedList(typeParameters);
			braceHelper.RightParen();
		}
	}

	private void WriteModifiers(IEnumerable<VBModifierToken> modifierTokens)
	{
		foreach (VBModifierToken modifierToken in modifierTokens)
		{
			modifierToken.AcceptVisitor(this, null);
		}
	}

	private void WriteArraySpecifiers(IEnumerable<ICSharpCode.NRefactory.VB.Ast.ArraySpecifier> arraySpecifiers)
	{
		foreach (ICSharpCode.NRefactory.VB.Ast.ArraySpecifier arraySpecifier in arraySpecifiers)
		{
			arraySpecifier.AcceptVisitor(this, null);
		}
	}

	private void WriteQualifiedIdentifier(IEnumerable<ICSharpCode.NRefactory.VB.Ast.Identifier> identifiers)
	{
		bool flag = true;
		foreach (ICSharpCode.NRefactory.VB.Ast.Identifier identifier in identifiers)
		{
			if (flag)
			{
				flag = false;
				if (lastWritten == LastWritten.KeywordOrIdentifier)
				{
					formatter.Space();
				}
			}
			else
			{
				WriteSpecialsUpToRole(AstNode.Roles.Dot, identifier);
				formatter.WriteToken(".", BoxedTextColor.Operator);
				lastWritten = LastWritten.Other;
			}
			WriteSpecialsUpToNode(identifier);
			formatter.WriteIdentifier(identifier.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(identifier.Annotation<object>()));
			lastWritten = LastWritten.KeywordOrIdentifier;
		}
	}

	private void WriteEmbeddedStatement(ICSharpCode.NRefactory.VB.Ast.Statement embeddedStatement)
	{
		if (!embeddedStatement.IsNull)
		{
			if (embeddedStatement is ICSharpCode.NRefactory.VB.Ast.BlockStatement blockStatement)
			{
				VisitBlockStatement(blockStatement, null);
			}
			else
			{
				embeddedStatement.AcceptVisitor(this, null);
			}
		}
	}

	private void WriteBlock(ICSharpCode.NRefactory.VB.Ast.BlockStatement body)
	{
		if (body.IsNull)
		{
			NewLine();
			Indent();
			NewLine();
			Unindent();
		}
		else
		{
			VisitBlockStatement(body, null);
		}
	}

	private bool IsSameGroup(AstNode a, AstNode b)
	{
		if (a == null)
		{
			return true;
		}
		if (a is ICSharpCode.NRefactory.VB.Ast.FieldDeclaration)
		{
			return b is ICSharpCode.NRefactory.VB.Ast.FieldDeclaration;
		}
		return false;
	}

	private void WriteMembers(IEnumerable<AstNode> members)
	{
		Indent();
		bool flag = true;
		AstNode a = null;
		foreach (AstNode member in members)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				NewLine();
			}
			if (!IsSameGroup(a, member))
			{
				formatter.AddLineSeparator(Math.Max(lastEndBlockOffset, lastDeclarationOffset));
			}
			member.AcceptVisitor(this, null);
			a = member;
		}
		Unindent();
	}

	private void WriteAttributes(IEnumerable<AttributeBlock> attributes)
	{
		foreach (AttributeBlock attribute in attributes)
		{
			attribute.AcceptVisitor(this, null);
		}
	}

	private void WritePrivateImplementationType(ICSharpCode.NRefactory.VB.Ast.AstType privateImplementationType)
	{
		if (!privateImplementationType.IsNull)
		{
			privateImplementationType.AcceptVisitor(this, null);
			WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
		}
	}

	private void WriteImplementsClause(AstNodeCollection<InterfaceMemberSpecifier> implementsClause)
	{
		if (implementsClause.Any())
		{
			Space();
			WriteKeyword("Implements");
			WriteCommaSeparatedList(implementsClause);
		}
	}

	private void WriteImplementsClause(AstNodeCollection<ICSharpCode.NRefactory.VB.Ast.AstType> implementsClause, bool isInterface)
	{
		if (implementsClause.Any())
		{
			WriteKeyword(isInterface ? "Inherits" : "Implements");
			WriteCommaSeparatedList(implementsClause);
		}
	}

	private void WriteHandlesClause(AstNodeCollection<EventMemberSpecifier> handlesClause)
	{
		if (handlesClause.Any())
		{
			Space();
			WriteKeyword("Handles");
			WriteCommaSeparatedList(handlesClause);
		}
	}

	private void WritePrimitiveValue(object val)
	{
		if (val == null)
		{
			WriteKeyword("Nothing");
		}
		else if (val is bool)
		{
			if ((bool)val)
			{
				WriteKeyword("True");
			}
			else
			{
				WriteKeyword("False");
			}
		}
		else if (val is string)
		{
			int nextPosition = formatter.NextPosition;
			formatter.WriteToken("\"" + ConvertString(val.ToString()) + "\"", BoxedTextColor.String);
			int nextPosition2 = formatter.NextPosition;
			formatter.AddBracePair(nextPosition, nextPosition + 1, nextPosition2 - 1, nextPosition2, CodeBracesRangeFlags.BraceKind_DoubleQuotes);
			lastWritten = LastWritten.Other;
		}
		else if (val is char)
		{
			int nextPosition3 = formatter.NextPosition;
			formatter.WriteToken("\"" + ConvertCharLiteral((char)val) + "\"c", BoxedTextColor.Char);
			int nextPosition4 = formatter.NextPosition;
			formatter.AddBracePair(nextPosition3, nextPosition3 + 1, nextPosition4 - 2, nextPosition4, CodeBracesRangeFlags.BraceKind_DoubleQuotes);
			lastWritten = LastWritten.Other;
		}
		else if (val is decimal)
		{
			formatter.WriteToken(((decimal)val).ToString(NumberFormatInfo.InvariantInfo) + "D", BoxedTextColor.Number);
			lastWritten = LastWritten.Other;
		}
		else if (val is float f)
		{
			if (float.IsInfinity(f) || float.IsNaN(f))
			{
				WriteKeyword("Single");
				WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
				if (float.IsPositiveInfinity(f))
				{
					WriteIdentifier("PositiveInfinity", BoxedTextColor.LiteralField);
				}
				else if (float.IsNegativeInfinity(f))
				{
					WriteIdentifier("NegativeInfinity", BoxedTextColor.LiteralField);
				}
				else
				{
					WriteIdentifier("NaN", BoxedTextColor.LiteralField);
				}
			}
			else
			{
				formatter.WriteToken(f.ToString("R", NumberFormatInfo.InvariantInfo) + "F", BoxedTextColor.Number);
				lastWritten = LastWritten.Other;
			}
		}
		else if (val is double d)
		{
			if (double.IsInfinity(d) || double.IsNaN(d))
			{
				WriteKeyword("Double");
				WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
				if (double.IsPositiveInfinity(d))
				{
					WriteIdentifier("PositiveInfinity", BoxedTextColor.LiteralField);
				}
				else if (double.IsNegativeInfinity(d))
				{
					WriteIdentifier("NegativeInfinity", BoxedTextColor.LiteralField);
				}
				else
				{
					WriteIdentifier("NaN", BoxedTextColor.LiteralField);
				}
			}
			else
			{
				string text = d.ToString("R", NumberFormatInfo.InvariantInfo);
				if (text.IndexOf('.') < 0 && text.IndexOf('E') < 0)
				{
					text += ".0";
				}
				formatter.WriteToken(text, BoxedTextColor.Number);
				lastWritten = LastWritten.KeywordOrIdentifier;
			}
		}
		else if (val is IFormattable)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(((IFormattable)val).ToString(null, NumberFormatInfo.InvariantInfo));
			if (val is ushort || val is ulong)
			{
				stringBuilder.Append("U");
			}
			if (val is short || val is ushort)
			{
				stringBuilder.Append("S");
			}
			else if (val is uint)
			{
				stringBuilder.Append("UI");
			}
			else if (val is long || val is ulong)
			{
				stringBuilder.Append("L");
			}
			formatter.WriteToken(stringBuilder.ToString(), VisualBasicMetadataTextColorProvider.Instance.GetColor(val));
			lastWritten = LastWritten.KeywordOrIdentifier;
		}
		else
		{
			formatter.WriteToken(val.ToString(), VisualBasicMetadataTextColorProvider.Instance.GetColor(val));
			lastWritten = LastWritten.Other;
		}
	}

	private static string ConvertCharLiteral(char ch)
	{
		if (ch == '"')
		{
			return "\"\"";
		}
		return ch.ToString();
	}

	private static string ConvertString(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char ch in str)
		{
			stringBuilder.Append(ConvertCharLiteral(ch));
		}
		return stringBuilder.ToString();
	}

	public object VisitVariableIdentifier(VariableIdentifier variableIdentifier, object data)
	{
		StartNode(variableIdentifier);
		WriteIdentifier(variableIdentifier.Name);
		if (variableIdentifier.HasNullableSpecifier)
		{
			WriteToken("?", AstNode.Roles.QuestionMark, BoxedTextColor.Punctuation);
		}
		if (variableIdentifier.ArraySizeSpecifiers.Count > 0)
		{
			WriteCommaSeparatedListInParenthesis(variableIdentifier.ArraySizeSpecifiers, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		WriteArraySpecifiers(variableIdentifier.ArraySpecifiers);
		return EndNode(variableIdentifier);
	}

	public object VisitAccessor(ICSharpCode.NRefactory.VB.Ast.Accessor accessor, object data)
	{
		StartNode(accessor);
		WriteAttributes(accessor.Attributes);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		MethodDebugInfoBuilder methodDebugInfoBuilder = accessor.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = nextPosition;
		}
		WriteModifiers(accessor.ModifierTokens);
		DebugStart(accessor);
		DebugHidden(accessor.Body.HiddenStart);
		if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration.GetterRole)
		{
			WriteKeyword("Get");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration.SetterRole)
		{
			WriteKeyword("Set");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.EventDeclaration.AddHandlerRole)
		{
			WriteKeyword("AddHandler");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.EventDeclaration.RemoveHandlerRole)
		{
			WriteKeyword("RemoveHandler");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.EventDeclaration.RaiseEventRole)
		{
			WriteKeyword("RaiseEvent");
		}
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		DebugEnd(accessor, addSelf: false);
		if (accessor.Parameters.Any())
		{
			WriteCommaSeparatedListInParenthesis(accessor.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		WriteBlock(accessor.Body);
		DebugStart(accessor);
		DebugHidden(accessor.Body.HiddenEnd);
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Accessor);
		WriteKeyword("End");
		if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration.GetterRole)
		{
			WriteKeyword("Get");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration.SetterRole)
		{
			WriteKeyword("Set");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.EventDeclaration.AddHandlerRole)
		{
			WriteKeyword("AddHandler");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.EventDeclaration.RemoveHandlerRole)
		{
			WriteKeyword("RemoveHandler");
		}
		else if (accessor.Role == ICSharpCode.NRefactory.VB.Ast.EventDeclaration.RaiseEventRole)
		{
			WriteKeyword("RaiseEvent");
		}
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = formatter.NextPosition;
		}
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		SaveDeclarationOffset();
		DebugEnd(accessor, addSelf: false);
		NewLine();
		currentMethodRefs = methodRefs;
		return EndNode(accessor);
	}

	public object VisitLabelDeclarationStatement(LabelDeclarationStatement labelDeclarationStatement, object data)
	{
		DebugStart(labelDeclarationStatement);
		StartNode(labelDeclarationStatement);
		labelDeclarationStatement.Label.AcceptVisitor(this, data);
		WriteToken(":", AstNode.Roles.Colon, BoxedTextColor.Punctuation);
		DebugEnd(labelDeclarationStatement);
		return EndNode(labelDeclarationStatement);
	}

	public object VisitLocalDeclarationStatement(LocalDeclarationStatement localDeclarationStatement, object data)
	{
		StartNode(localDeclarationStatement);
		DebugStart(localDeclarationStatement);
		if (!(localDeclarationStatement.Parent is ICSharpCode.NRefactory.VB.Ast.UsingStatement) && localDeclarationStatement.ModifierToken != null && !localDeclarationStatement.ModifierToken.IsNull)
		{
			WriteModifiers(new VBModifierToken[1] { localDeclarationStatement.ModifierToken });
		}
		WriteCommaSeparatedList(localDeclarationStatement.Variables);
		DebugEnd(localDeclarationStatement);
		return EndNode(localDeclarationStatement);
	}

	public object VisitWithStatement(WithStatement withStatement, object data)
	{
		StartNode(withStatement);
		object reference = new object();
		int num = DebugStart(withStatement, "With");
		int start = num;
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		withStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(withStatement);
		withStatement.Body.AcceptVisitor(this, data);
		num = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Other);
		WriteKeyword("End");
		WriteKeyword("With");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		return EndNode(withStatement);
	}

	public object VisitSyncLockStatement(SyncLockStatement syncLockStatement, object data)
	{
		StartNode(syncLockStatement);
		object reference = new object();
		int num = DebugStart(syncLockStatement, "SyncLock");
		int start = num;
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		syncLockStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(syncLockStatement);
		syncLockStatement.Body.AcceptVisitor(this, data);
		num = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Lock);
		WriteKeyword("End");
		WriteKeyword("SyncLock");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		return EndNode(syncLockStatement);
	}

	public object VisitTryStatement(TryStatement tryStatement, object data)
	{
		StartNode(tryStatement);
		object reference = new object();
		object obj = currentTryReference;
		currentTryReference = reference;
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteKeyword("Try");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		tryStatement.Body.AcceptVisitor(this, data);
		foreach (CatchBlock catchBlock in tryStatement.CatchBlocks)
		{
			catchBlock.AcceptVisitor(this, data);
		}
		if (!tryStatement.FinallyBlock.IsNull)
		{
			nextPosition = formatter.NextPosition;
			formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Try);
			start = nextPosition;
			WriteKeyword("Finally");
			formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
			tryStatement.FinallyBlock.AcceptVisitor(this, data);
		}
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, tryStatement.FinallyBlock.IsNull ? CodeBracesRangeFlags.BlockKind_Try : CodeBracesRangeFlags.BlockKind_Finally);
		WriteKeyword("End");
		WriteKeyword("Try");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		currentTryReference = obj;
		return EndNode(tryStatement);
	}

	public object VisitCatchBlock(CatchBlock catchBlock, object data)
	{
		StartNode(catchBlock);
		int start = DebugStart(catchBlock, "Catch");
		formatter.AddHighlightedKeywordReference(currentTryReference, start, formatter.NextPosition);
		if (!catchBlock.ExceptionVariable.IsNull)
		{
			catchBlock.ExceptionVariable.AcceptVisitor(this, data);
		}
		if (!catchBlock.ExceptionType.IsNull)
		{
			WriteKeyword("As");
			catchBlock.ExceptionType.AcceptVisitor(this, data);
		}
		if (!catchBlock.WhenExpression.IsNull)
		{
			Space();
			start = formatter.NextPosition;
			WriteKeyword("When");
			formatter.AddHighlightedKeywordReference(currentTryReference, start, formatter.NextPosition);
			Space();
			catchBlock.WhenExpression.AcceptVisitor(this, data);
		}
		DebugEnd(catchBlock);
		NewLine();
		Indent();
		foreach (ICSharpCode.NRefactory.VB.Ast.Statement item in (IEnumerable<ICSharpCode.NRefactory.VB.Ast.Statement>)catchBlock)
		{
			item.AcceptVisitor(this, data);
			NewLine();
		}
		Unindent();
		return EndNode(catchBlock);
	}

	public object VisitExpressionStatement(ICSharpCode.NRefactory.VB.Ast.ExpressionStatement expressionStatement, object data)
	{
		StartNode(expressionStatement);
		DebugStart(expressionStatement);
		expressionStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(expressionStatement);
		return EndNode(expressionStatement);
	}

	public object VisitThrowStatement(ICSharpCode.NRefactory.VB.Ast.ThrowStatement throwStatement, object data)
	{
		StartNode(throwStatement);
		DebugStart(throwStatement, "Throw");
		throwStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(throwStatement);
		return EndNode(throwStatement);
	}

	public object VisitIfElseStatement(ICSharpCode.NRefactory.VB.Ast.IfElseStatement ifElseStatement, object data)
	{
		StartNode(ifElseStatement);
		object obj = currentIfReference;
		if (!isElseIfStatement)
		{
			currentIfReference = new object();
		}
		int num = DebugStart(ifElseStatement, isElseIfStatement ? "ElseIf" : "If");
		if (isElseIfStatement)
		{
			formatter.AddBlock(elseIfStartPos, num, CodeBracesRangeFlags.BlockKind_Conditional);
		}
		int start = num;
		isElseIfStatement = false;
		formatter.AddHighlightedKeywordReference(currentIfReference, num, formatter.NextPosition);
		ifElseStatement.Condition.AcceptVisitor(this, data);
		DebugEnd(ifElseStatement);
		Space();
		num = formatter.NextPosition;
		WriteKeyword("Then");
		formatter.AddHighlightedKeywordReference(currentIfReference, num, formatter.NextPosition);
		bool flag = ifElseStatement.Body is ICSharpCode.NRefactory.VB.Ast.BlockStatement;
		ifElseStatement.Body.AcceptVisitor(this, data);
		if (!ifElseStatement.ElseBlock.IsNull)
		{
			if (ifElseStatement.ElseBlock is ICSharpCode.NRefactory.VB.Ast.IfElseStatement)
			{
				isElseIfStatement = true;
				elseIfStartPos = start;
			}
			else
			{
				num = formatter.NextPosition;
				formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Conditional);
				start = num;
				WriteKeyword("Else");
				formatter.AddHighlightedKeywordReference(currentIfReference, num, formatter.NextPosition);
			}
			flag = ifElseStatement.ElseBlock is ICSharpCode.NRefactory.VB.Ast.BlockStatement;
			ifElseStatement.ElseBlock.AcceptVisitor(this, data);
			if (ifElseStatement.ElseBlock is ICSharpCode.NRefactory.VB.Ast.IfElseStatement)
			{
				start = elseIfStartPos;
			}
		}
		if (flag)
		{
			num = formatter.NextPosition;
			formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Conditional);
			lastEndBlockOffset = num;
			WriteKeyword("End");
			WriteKeyword("If");
			formatter.AddHighlightedKeywordReference(currentIfReference, num, formatter.NextPosition);
		}
		currentIfReference = obj;
		elseIfStartPos = start;
		return EndNode(ifElseStatement);
	}

	public object VisitReturnStatement(ICSharpCode.NRefactory.VB.Ast.ReturnStatement returnStatement, object data)
	{
		StartNode(returnStatement);
		int start = DebugStart(returnStatement, "Return");
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, start, formatter.NextPosition);
		returnStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(returnStatement);
		return EndNode(returnStatement);
	}

	public object VisitBinaryOperatorExpression(ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression binaryOperatorExpression, object data)
	{
		DebugExpression(binaryOperatorExpression);
		StartNode(binaryOperatorExpression);
		binaryOperatorExpression.Left.AcceptVisitor(this, data);
		Space();
		switch (binaryOperatorExpression.Operator)
		{
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.BitwiseAnd:
			WriteKeyword("And");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.BitwiseOr:
			WriteKeyword("Or");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LogicalAnd:
			WriteKeyword("AndAlso");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LogicalOr:
			WriteKeyword("OrElse");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ExclusiveOr:
			WriteKeyword("Xor");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.GreaterThan:
			WriteToken(">", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.GreaterThanOrEqual:
			WriteToken(">=", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Equality:
			WriteToken("=", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.InEquality:
			WriteToken("<>", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LessThan:
			WriteToken("<", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.LessThanOrEqual:
			WriteToken("<=", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Add:
			WriteToken("+", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Subtract:
			WriteToken("-", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Multiply:
			WriteToken("*", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Divide:
			WriteToken("/", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Modulus:
			WriteKeyword("Mod");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.DivideInteger:
			WriteToken("\\", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Power:
			WriteToken("*", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Concat:
			WriteToken("&", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ShiftLeft:
			WriteToken("<<", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ShiftRight:
			WriteToken(">>", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ReferenceEquality:
			WriteKeyword("Is");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.ReferenceInequality:
			WriteKeyword("IsNot");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.Like:
			WriteKeyword("Like");
			break;
		case ICSharpCode.NRefactory.VB.Ast.BinaryOperatorType.DictionaryAccess:
			WriteToken("!", ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		default:
			throw new Exception("Invalid value for BinaryOperatorType: " + binaryOperatorExpression.Operator);
		}
		Space();
		binaryOperatorExpression.Right.AcceptVisitor(this, data);
		return EndNode(binaryOperatorExpression);
	}

	public object VisitIdentifierExpression(ICSharpCode.NRefactory.VB.Ast.IdentifierExpression identifierExpression, object data)
	{
		DebugExpression(identifierExpression);
		StartNode(identifierExpression);
		identifierExpression.Identifier.AcceptVisitor(this, data);
		WriteTypeArguments(identifierExpression.TypeArguments, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(identifierExpression);
	}

	public object VisitAssignmentExpression(ICSharpCode.NRefactory.VB.Ast.AssignmentExpression assignmentExpression, object data)
	{
		DebugExpression(assignmentExpression);
		StartNode(assignmentExpression);
		assignmentExpression.Left.AcceptVisitor(this, data);
		Space();
		switch (assignmentExpression.Operator)
		{
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Assign:
			if (assignmentExpression.Parent is ICSharpCode.NRefactory.VB.Ast.Attribute)
			{
				WriteToken(":=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			}
			else
			{
				WriteToken("=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			}
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Add:
			WriteToken("+=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Subtract:
			WriteToken("-=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Multiply:
			WriteToken("*=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Divide:
			WriteToken("/=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.Power:
			WriteToken("^=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.DivideInteger:
			WriteToken("\\=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.ConcatString:
			WriteToken("&=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.ShiftLeft:
			WriteToken("<<=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.AssignmentOperatorType.ShiftRight:
			WriteToken(">>=", ICSharpCode.NRefactory.VB.Ast.AssignmentExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		default:
			throw new Exception("Invalid value for AssignmentOperatorType: " + assignmentExpression.Operator);
		}
		Space();
		assignmentExpression.Right.AcceptVisitor(this, data);
		return EndNode(assignmentExpression);
	}

	public object VisitInvocationExpression(ICSharpCode.NRefactory.VB.Ast.InvocationExpression invocationExpression, object data)
	{
		DebugExpression(invocationExpression);
		StartNode(invocationExpression);
		invocationExpression.Target.AcceptVisitor(this, data);
		WriteCommaSeparatedListInParenthesis(invocationExpression.Arguments, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		return EndNode(invocationExpression);
	}

	public object VisitArrayInitializerExpression(ICSharpCode.NRefactory.VB.Ast.ArrayInitializerExpression arrayInitializerExpression, object data)
	{
		DebugExpression(arrayInitializerExpression);
		StartNode(arrayInitializerExpression);
		BraceHelper braceHelper = BraceHelper.LeftBrace(this, CodeBracesRangeFlags.BraceKind_CurlyBraces);
		Space();
		WriteCommaSeparatedList(arrayInitializerExpression.Elements);
		Space();
		braceHelper.RightBrace();
		return EndNode(arrayInitializerExpression);
	}

	public object VisitArrayCreateExpression(ICSharpCode.NRefactory.VB.Ast.ArrayCreateExpression arrayCreateExpression, object data)
	{
		DebugExpression(arrayCreateExpression);
		StartNode(arrayCreateExpression);
		WriteKeyword("New");
		Space();
		arrayCreateExpression.Type.AcceptVisitor(this, data);
		if (arrayCreateExpression.Arguments.Any())
		{
			WriteCommaSeparatedListInParenthesis(arrayCreateExpression.Arguments, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		foreach (ICSharpCode.NRefactory.VB.Ast.ArraySpecifier additionalArraySpecifier in arrayCreateExpression.AdditionalArraySpecifiers)
		{
			additionalArraySpecifier.AcceptVisitor(this, data);
		}
		if (lastWritten != LastWritten.Whitespace)
		{
			Space();
		}
		if (arrayCreateExpression.Initializer.IsNull)
		{
			BraceHelper.LeftBrace(this, CodeBracesRangeFlags.BraceKind_CurlyBraces).RightBrace();
		}
		else
		{
			arrayCreateExpression.Initializer.AcceptVisitor(this, data);
		}
		return EndNode(arrayCreateExpression);
	}

	public object VisitObjectCreationExpression(ObjectCreationExpression objectCreationExpression, object data)
	{
		DebugExpression(objectCreationExpression);
		StartNode(objectCreationExpression);
		WriteKeyword("New");
		objectCreationExpression.Type.AcceptVisitor(this, data);
		WriteCommaSeparatedListInParenthesis(objectCreationExpression.Arguments, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (!objectCreationExpression.Initializer.IsNull)
		{
			Space();
			if (objectCreationExpression.Initializer.Elements.Any((ICSharpCode.NRefactory.VB.Ast.Expression x) => x is FieldInitializerExpression))
			{
				WriteKeyword("With");
			}
			else
			{
				WriteKeyword("From");
			}
			Space();
			objectCreationExpression.Initializer.AcceptVisitor(this, data);
		}
		return EndNode(objectCreationExpression);
	}

	public object VisitCastExpression(ICSharpCode.NRefactory.VB.Ast.CastExpression castExpression, object data)
	{
		DebugExpression(castExpression);
		StartNode(castExpression);
		switch (castExpression.CastType)
		{
		case CastType.DirectCast:
			WriteKeyword("DirectCast");
			break;
		case CastType.TryCast:
			WriteKeyword("TryCast");
			break;
		case CastType.CType:
			WriteKeyword("CType");
			break;
		case CastType.CBool:
			WriteKeyword("CBool");
			break;
		case CastType.CByte:
			WriteKeyword("CByte");
			break;
		case CastType.CChar:
			WriteKeyword("CChar");
			break;
		case CastType.CDate:
			WriteKeyword("CDate");
			break;
		case CastType.CDec:
			WriteKeyword("CDec");
			break;
		case CastType.CDbl:
			WriteKeyword("CDbl");
			break;
		case CastType.CInt:
			WriteKeyword("CInt");
			break;
		case CastType.CLng:
			WriteKeyword("CLng");
			break;
		case CastType.CObj:
			WriteKeyword("CObj");
			break;
		case CastType.CSByte:
			WriteKeyword("CSByte");
			break;
		case CastType.CShort:
			WriteKeyword("CShort");
			break;
		case CastType.CSng:
			WriteKeyword("CSng");
			break;
		case CastType.CStr:
			WriteKeyword("CStr");
			break;
		case CastType.CUInt:
			WriteKeyword("CUInt");
			break;
		case CastType.CULng:
			WriteKeyword("CULng");
			break;
		case CastType.CUShort:
			WriteKeyword("CUShort");
			break;
		default:
			throw new Exception("Invalid value for CastType");
		}
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		castExpression.Expression.AcceptVisitor(this, data);
		if (castExpression.CastType == CastType.CType || castExpression.CastType == CastType.DirectCast || castExpression.CastType == CastType.TryCast)
		{
			WriteToken(",", AstNode.Roles.Comma, BoxedTextColor.Punctuation);
			Space();
			castExpression.Type.AcceptVisitor(this, data);
		}
		braceHelper.RightParen();
		return EndNode(castExpression);
	}

	public object VisitComment(Comment comment, object data)
	{
		if (comment.IsDocumentationComment)
		{
			WriteComment(comment);
		}
		return null;
	}

	private void WriteComment(Comment comment)
	{
		formatter.WriteComment(comment.IsDocumentationComment, comment.Content, comment.References);
	}

	public object VisitEventDeclaration(ICSharpCode.NRefactory.VB.Ast.EventDeclaration eventDeclaration, object data)
	{
		StartNode(eventDeclaration);
		WriteAttributes(eventDeclaration.Attributes);
		object reference = new object();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteModifiers(eventDeclaration.ModifierTokens);
		if (eventDeclaration.IsCustom)
		{
			WriteKeyword("Custom");
		}
		WriteKeyword("Event");
		if (eventDeclaration.IsCustom)
		{
			formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		}
		WriteIdentifier(eventDeclaration.Name);
		if (!eventDeclaration.IsCustom && eventDeclaration.ReturnType.IsNull)
		{
			WriteCommaSeparatedListInParenthesis(eventDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		}
		if (!eventDeclaration.ReturnType.IsNull)
		{
			Space();
			WriteKeyword("As");
			eventDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		WriteImplementsClause(eventDeclaration.ImplementsClause);
		if (eventDeclaration.IsCustom)
		{
			NewLine();
			Indent();
			eventDeclaration.AddHandlerBlock.AcceptVisitor(this, data);
			eventDeclaration.RemoveHandlerBlock.AcceptVisitor(this, data);
			eventDeclaration.RaiseEventBlock.AcceptVisitor(this, data);
			Unindent();
			nextPosition = (lastEndBlockOffset = formatter.NextPosition);
			formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Event);
			WriteKeyword("End");
			WriteKeyword("Event");
			formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		}
		SaveDeclarationOffset();
		NewLine();
		return EndNode(eventDeclaration);
	}

	public object VisitUnaryOperatorExpression(ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression unaryOperatorExpression, object data)
	{
		DebugExpression(unaryOperatorExpression);
		StartNode(unaryOperatorExpression);
		switch (unaryOperatorExpression.Operator)
		{
		case ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Not:
			WriteKeyword("Not");
			break;
		case ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Minus:
			WriteToken("-", ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Plus:
			WriteToken("+", ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression.OperatorRole, BoxedTextColor.Operator);
			break;
		case ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.AddressOf:
			WriteKeyword("AddressOf");
			break;
		case ICSharpCode.NRefactory.VB.Ast.UnaryOperatorType.Await:
		{
			SpaceIfNeeded();
			int nextPosition = formatter.NextPosition;
			WriteKeyword("Await");
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
			break;
		}
		default:
			throw new Exception("Invalid value for UnaryOperatorType");
		}
		unaryOperatorExpression.Expression.AcceptVisitor(this, data);
		return EndNode(unaryOperatorExpression);
	}

	public object VisitFieldInitializerExpression(FieldInitializerExpression fieldInitializerExpression, object data)
	{
		DebugExpression(fieldInitializerExpression);
		StartNode(fieldInitializerExpression);
		if (fieldInitializerExpression.IsKey && fieldInitializerExpression.Parent is AnonymousObjectCreationExpression)
		{
			WriteKeyword("Key");
			Space();
		}
		WriteToken(".", AstNode.Roles.Dot, BoxedTextColor.Operator);
		fieldInitializerExpression.Identifier.AcceptVisitor(this, data);
		Space();
		WriteToken("=", AstNode.Roles.Assign, BoxedTextColor.Operator);
		Space();
		fieldInitializerExpression.Expression.AcceptVisitor(this, data);
		return EndNode(fieldInitializerExpression);
	}

	public object VisitNamedArgumentExpression(ICSharpCode.NRefactory.VB.Ast.NamedArgumentExpression namedArgumentExpression, object data)
	{
		DebugExpression(namedArgumentExpression);
		throw new NotImplementedException();
	}

	public object VisitConditionalExpression(ICSharpCode.NRefactory.VB.Ast.ConditionalExpression conditionalExpression, object data)
	{
		DebugExpression(conditionalExpression);
		StartNode(conditionalExpression);
		WriteKeyword("If");
		BraceHelper braceHelper = BraceHelper.LeftParen(this, CodeBracesRangeFlags.BraceKind_Parentheses);
		conditionalExpression.ConditionExpression.AcceptVisitor(this, data);
		WriteToken(",", AstNode.Roles.Comma, BoxedTextColor.Punctuation);
		Space();
		if (!conditionalExpression.TrueExpression.IsNull)
		{
			conditionalExpression.TrueExpression.AcceptVisitor(this, data);
			WriteToken(",", AstNode.Roles.Comma, BoxedTextColor.Punctuation);
			Space();
		}
		conditionalExpression.FalseExpression.AcceptVisitor(this, data);
		braceHelper.RightParen();
		return EndNode(conditionalExpression);
	}

	public object VisitWhileStatement(ICSharpCode.NRefactory.VB.Ast.WhileStatement whileStatement, object data)
	{
		StartNode(whileStatement);
		object reference = new object();
		object obj = currentWhileReference;
		currentWhileReference = reference;
		int num = DebugStart(whileStatement, "While");
		int start = num;
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		Space();
		whileStatement.Condition.AcceptVisitor(this, data);
		DebugEnd(whileStatement);
		whileStatement.Body.AcceptVisitor(this, data);
		num = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Loop);
		WriteKeyword("End");
		WriteKeyword("While");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		currentWhileReference = obj;
		return EndNode(whileStatement);
	}

	public object VisitExitStatement(ExitStatement exitStatement, object data)
	{
		StartNode(exitStatement);
		int start = DebugStart(exitStatement, "Exit");
		switch (exitStatement.ExitKind)
		{
		case ExitKind.Sub:
			WriteKeyword("Sub");
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, start, formatter.NextPosition);
			break;
		case ExitKind.Function:
			WriteKeyword("Function");
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, start, formatter.NextPosition);
			break;
		case ExitKind.Property:
			WriteKeyword("Property");
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, start, formatter.NextPosition);
			break;
		case ExitKind.Do:
			WriteKeyword("Do");
			formatter.AddHighlightedKeywordReference(currentDoReference, start, formatter.NextPosition);
			break;
		case ExitKind.For:
			WriteKeyword("For");
			formatter.AddHighlightedKeywordReference(currentForReference, start, formatter.NextPosition);
			break;
		case ExitKind.While:
			WriteKeyword("While");
			formatter.AddHighlightedKeywordReference(currentWhileReference, start, formatter.NextPosition);
			break;
		case ExitKind.Select:
			WriteKeyword("Select");
			formatter.AddHighlightedKeywordReference(currentSelectReference, start, formatter.NextPosition);
			break;
		case ExitKind.Try:
			WriteKeyword("Try");
			formatter.AddHighlightedKeywordReference(currentTryReference, start, formatter.NextPosition);
			break;
		default:
			throw new Exception("Invalid value for ExitKind");
		}
		DebugEnd(exitStatement);
		return EndNode(exitStatement);
	}

	public object VisitForStatement(ICSharpCode.NRefactory.VB.Ast.ForStatement forStatement, object data)
	{
		StartNode(forStatement);
		object reference = new object();
		object obj = currentForReference;
		currentForReference = reference;
		int num = DebugStart(forStatement, "For");
		int start = num;
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		Space();
		forStatement.Variable.AcceptVisitor(this, data);
		DebugEnd(forStatement, addSelf: false);
		num = DebugStart(forStatement, "To");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		forStatement.ToExpression.AcceptVisitor(this, data);
		DebugEnd(forStatement, addSelf: false);
		if (!forStatement.StepExpression.IsNull)
		{
			num = DebugStart(forStatement, "Step");
			formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
			Space();
			forStatement.StepExpression.AcceptVisitor(this, data);
			DebugEnd(forStatement, addSelf: false);
		}
		forStatement.Body.AcceptVisitor(this, data);
		num = formatter.NextPosition;
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Loop);
		WriteKeyword("Next");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		currentForReference = obj;
		return EndNode(forStatement);
	}

	public object VisitForEachStatement(ForEachStatement forEachStatement, object data)
	{
		StartNode(forEachStatement);
		DebugStart(forEachStatement);
		object reference = new object();
		object obj = currentForReference;
		currentForReference = reference;
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		WriteKeyword("For");
		WriteKeyword("Each");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		DebugHidden(forEachStatement.HiddenInitializer);
		DebugHidden(forEachStatement.Body.HiddenStart);
		DebugEnd(forEachStatement, addSelf: false);
		Space();
		DebugStart(forEachStatement);
		forEachStatement.Variable.AcceptVisitor(this, data);
		DebugHidden(forEachStatement.HiddenGetCurrentILSpans);
		DebugEnd(forEachStatement, addSelf: false);
		Space();
		DebugStart(forEachStatement);
		nextPosition = formatter.NextPosition;
		WriteKeyword("In");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		DebugHidden(forEachStatement.HiddenMoveNextILSpans);
		DebugEnd(forEachStatement, addSelf: false);
		Space();
		DebugStart(forEachStatement);
		forEachStatement.InExpression.AcceptVisitor(this, data);
		DebugHidden(forEachStatement.HiddenGetEnumeratorILSpans);
		DebugEnd(forEachStatement, addSelf: false);
		forEachStatement.Body.AcceptVisitor(this, data);
		DebugStart(forEachStatement);
		nextPosition = formatter.NextPosition;
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Loop);
		WriteKeyword("Next");
		formatter.AddHighlightedKeywordReference(reference, nextPosition, formatter.NextPosition);
		DebugHidden(forEachStatement.Body.HiddenEnd);
		DebugEnd(forEachStatement, addSelf: false);
		currentForReference = obj;
		return EndNode(forEachStatement);
	}

	public object VisitOperatorDeclaration(ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration operatorDeclaration, object data)
	{
		StartNode(operatorDeclaration);
		WriteAttributes(operatorDeclaration.Attributes);
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		MethodDebugInfoBuilder methodDebugInfoBuilder = operatorDeclaration.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = nextPosition;
		}
		WriteModifiers(operatorDeclaration.ModifierTokens);
		DebugStart(operatorDeclaration);
		DebugHidden(operatorDeclaration.Body.HiddenStart);
		bool flag = !operatorDeclaration.Body.IsNull || (operatorDeclaration.Body.HiddenEnd != null && operatorDeclaration.Body.HiddenEnd.Count > 0);
		WriteKeyword("Operator");
		if (flag)
		{
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		}
		Space();
		switch (operatorDeclaration.Operator)
		{
		case OverloadableOperatorType.Add:
		case OverloadableOperatorType.UnaryPlus:
			WriteToken("+", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.Subtract:
		case OverloadableOperatorType.UnaryMinus:
			WriteToken("-", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.Multiply:
			WriteToken("*", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.Divide:
			WriteToken("/", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.Modulus:
			WriteKeyword("Mod");
			break;
		case OverloadableOperatorType.Concat:
			WriteToken("&", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.Not:
			WriteKeyword("Not");
			break;
		case OverloadableOperatorType.BitwiseAnd:
			WriteKeyword("And");
			break;
		case OverloadableOperatorType.BitwiseOr:
			WriteKeyword("Or");
			break;
		case OverloadableOperatorType.ExclusiveOr:
			WriteKeyword("Xor");
			break;
		case OverloadableOperatorType.ShiftLeft:
			WriteToken("<<", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.ShiftRight:
			WriteToken(">>", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.GreaterThan:
			WriteToken(">", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.GreaterThanOrEqual:
			WriteToken(">=", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.Equality:
			WriteToken("=", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.InEquality:
			WriteToken("<>", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.LessThan:
			WriteToken("<", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.LessThanOrEqual:
			WriteToken("<=", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.IsTrue:
			WriteKeyword("IsTrue");
			break;
		case OverloadableOperatorType.IsFalse:
			WriteKeyword("IsFalse");
			break;
		case OverloadableOperatorType.Like:
			WriteKeyword("Like");
			break;
		case OverloadableOperatorType.Power:
			WriteToken("^", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		case OverloadableOperatorType.CType:
			WriteKeyword("CType");
			break;
		case OverloadableOperatorType.DivideInteger:
			WriteToken("\\", AstNode.Roles.Keyword, BoxedTextColor.Operator);
			break;
		default:
			throw new Exception("Invalid value for OverloadableOperatorType");
		}
		DebugEnd(operatorDeclaration, addSelf: false);
		WriteCommaSeparatedListInParenthesis(operatorDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (!operatorDeclaration.ReturnType.IsNull)
		{
			Space();
			WriteKeyword("As");
			Space();
			WriteAttributes(operatorDeclaration.ReturnTypeAttributes);
			operatorDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		if (flag)
		{
			WriteBlock(operatorDeclaration.Body);
			DebugStart(operatorDeclaration);
			DebugHidden(operatorDeclaration.Body.HiddenEnd);
			nextPosition = (lastEndBlockOffset = formatter.NextPosition);
			formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Operator);
			WriteKeyword("End");
			WriteKeyword("Operator");
			if (methodDebugInfoBuilder != null)
			{
				methodDebugInfoBuilder.EndPosition = formatter.NextPosition;
			}
			formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
			DebugEnd(operatorDeclaration, addSelf: false);
		}
		SaveDeclarationOffset();
		NewLine();
		return EndNode(operatorDeclaration);
	}

	public object VisitSelectStatement(SelectStatement selectStatement, object data)
	{
		StartNode(selectStatement);
		object reference = new object();
		object obj = currentSelectReference;
		currentSelectReference = reference;
		int num = DebugStart(selectStatement, "Select");
		int start = num;
		WriteKeyword("Case");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		selectStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(selectStatement);
		NewLine();
		Indent();
		foreach (CaseStatement @case in selectStatement.Cases)
		{
			@case.AcceptVisitor(this, data);
		}
		Unindent();
		DebugStart(selectStatement);
		DebugHidden(selectStatement.HiddenEnd);
		num = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Conditional);
		WriteKeyword("End");
		WriteKeyword("Select");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		DebugEnd(selectStatement, addSelf: false);
		currentSelectReference = obj;
		return EndNode(selectStatement);
	}

	public object VisitCaseStatement(CaseStatement caseStatement, object data)
	{
		DebugStart(caseStatement);
		StartNode(caseStatement);
		int nextPosition = formatter.NextPosition;
		WriteKeyword("Case");
		if (caseStatement.Clauses.Count == 1 && caseStatement.Clauses.First().Expression.IsNull)
		{
			WriteKeyword("Else");
			formatter.AddHighlightedKeywordReference(currentSelectReference, nextPosition, formatter.NextPosition);
		}
		else
		{
			formatter.AddHighlightedKeywordReference(currentSelectReference, nextPosition, formatter.NextPosition);
			Space();
			WriteCommaSeparatedList(caseStatement.Clauses);
		}
		DebugEnd(caseStatement, addSelf: false);
		caseStatement.Body.AcceptVisitor(this, data);
		return EndNode(caseStatement);
	}

	public object VisitSimpleCaseClause(SimpleCaseClause simpleCaseClause, object data)
	{
		StartNode(simpleCaseClause);
		DebugStart(simpleCaseClause);
		simpleCaseClause.Expression.AcceptVisitor(this, data);
		DebugEnd(simpleCaseClause);
		return EndNode(simpleCaseClause);
	}

	public object VisitRangeCaseClause(RangeCaseClause rangeCaseClause, object data)
	{
		StartNode(rangeCaseClause);
		DebugStart(rangeCaseClause);
		rangeCaseClause.Expression.AcceptVisitor(this, data);
		WriteKeyword("To");
		rangeCaseClause.ToExpression.AcceptVisitor(this, data);
		DebugEnd(rangeCaseClause);
		return EndNode(rangeCaseClause);
	}

	public object VisitComparisonCaseClause(ComparisonCaseClause comparisonCaseClause, object data)
	{
		StartNode(comparisonCaseClause);
		DebugStart(comparisonCaseClause);
		switch (comparisonCaseClause.Operator)
		{
		case ComparisonOperator.Equality:
			WriteToken("=", ComparisonCaseClause.OperatorRole, BoxedTextColor.Operator);
			break;
		case ComparisonOperator.InEquality:
			WriteToken("<>", ComparisonCaseClause.OperatorRole, BoxedTextColor.Operator);
			break;
		case ComparisonOperator.LessThan:
			WriteToken("<", ComparisonCaseClause.OperatorRole, BoxedTextColor.Operator);
			break;
		case ComparisonOperator.GreaterThan:
			WriteToken(">", ComparisonCaseClause.OperatorRole, BoxedTextColor.Operator);
			break;
		case ComparisonOperator.LessThanOrEqual:
			WriteToken("<=", ComparisonCaseClause.OperatorRole, BoxedTextColor.Operator);
			break;
		case ComparisonOperator.GreaterThanOrEqual:
			WriteToken(">=", ComparisonCaseClause.OperatorRole, BoxedTextColor.Operator);
			break;
		default:
			throw new Exception("Invalid value for ComparisonOperator");
		}
		Space();
		comparisonCaseClause.Expression.AcceptVisitor(this, data);
		DebugEnd(comparisonCaseClause);
		return EndNode(comparisonCaseClause);
	}

	public object VisitYieldStatement(YieldStatement yieldStatement, object data)
	{
		StartNode(yieldStatement);
		int start = DebugStart(yieldStatement, "Yield");
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, start, formatter.NextPosition);
		yieldStatement.Expression.AcceptVisitor(this, data);
		DebugEnd(yieldStatement);
		return EndNode(yieldStatement);
	}

	public object VisitVariableInitializer(ICSharpCode.NRefactory.VB.Ast.VariableInitializer variableInitializer, object data)
	{
		StartNode(variableInitializer);
		DebugStart(variableInitializer);
		variableInitializer.Identifier.AcceptVisitor(this, data);
		if (!variableInitializer.Type.IsNull)
		{
			if (lastWritten != LastWritten.Whitespace)
			{
				Space();
			}
			WriteKeyword("As");
			variableInitializer.Type.AcceptVisitor(this, data);
		}
		if (!variableInitializer.Expression.IsNull)
		{
			Space();
			WriteToken("=", AstNode.Roles.Assign, BoxedTextColor.Operator);
			Space();
			variableInitializer.Expression.AcceptVisitor(this, data);
		}
		DebugEnd(variableInitializer);
		return EndNode(variableInitializer);
	}

	public object VisitVariableDeclaratorWithTypeAndInitializer(VariableDeclaratorWithTypeAndInitializer variableDeclaratorWithTypeAndInitializer, object data)
	{
		StartNode(variableDeclaratorWithTypeAndInitializer);
		if (variableDeclaratorWithTypeAndInitializer.Parent is ICSharpCode.NRefactory.VB.Ast.PropertyDeclaration)
		{
			if (lastWritten != LastWritten.Whitespace)
			{
				Space();
			}
			WriteToken("=", AstNode.Roles.Assign, BoxedTextColor.Operator);
			Space();
			DebugStart(variableDeclaratorWithTypeAndInitializer);
			variableDeclaratorWithTypeAndInitializer.Initializer.AcceptVisitor(this, data);
		}
		else
		{
			if (lastWritten != LastWritten.Whitespace)
			{
				Space();
			}
			DebugStart(variableDeclaratorWithTypeAndInitializer);
			WriteCommaSeparatedList(variableDeclaratorWithTypeAndInitializer.Identifiers);
			if (lastWritten != LastWritten.Whitespace)
			{
				Space();
			}
			WriteKeyword("As");
			variableDeclaratorWithTypeAndInitializer.Type.AcceptVisitor(this, data);
			if (!variableDeclaratorWithTypeAndInitializer.Initializer.IsNull)
			{
				Space();
				WriteToken("=", AstNode.Roles.Assign, BoxedTextColor.Operator);
				Space();
				variableDeclaratorWithTypeAndInitializer.Initializer.AcceptVisitor(this, data);
			}
		}
		DebugEnd(variableDeclaratorWithTypeAndInitializer);
		return EndNode(variableDeclaratorWithTypeAndInitializer);
	}

	public object VisitVariableDeclaratorWithObjectCreation(VariableDeclaratorWithObjectCreation variableDeclaratorWithObjectCreation, object data)
	{
		StartNode(variableDeclaratorWithObjectCreation);
		if (lastWritten != LastWritten.Whitespace)
		{
			Space();
		}
		DebugStart(variableDeclaratorWithObjectCreation);
		WriteCommaSeparatedList(variableDeclaratorWithObjectCreation.Identifiers);
		if (lastWritten != LastWritten.Whitespace)
		{
			Space();
		}
		WriteKeyword("As");
		variableDeclaratorWithObjectCreation.Initializer.AcceptVisitor(this, data);
		DebugEnd(variableDeclaratorWithObjectCreation);
		return EndNode(variableDeclaratorWithObjectCreation);
	}

	public object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
	{
		StartNode(doLoopStatement);
		object reference = new object();
		object obj = currentDoReference;
		currentDoReference = reference;
		int num;
		if (doLoopStatement.ConditionType == ConditionType.DoUntil)
		{
			num = DebugStart(doLoopStatement, "Do");
			WriteKeyword("Until");
			doLoopStatement.Expression.AcceptVisitor(this, data);
			DebugEnd(doLoopStatement);
		}
		else if (doLoopStatement.ConditionType == ConditionType.DoWhile)
		{
			num = DebugStart(doLoopStatement, "Do");
			WriteKeyword("While");
			doLoopStatement.Expression.AcceptVisitor(this, data);
			DebugEnd(doLoopStatement);
		}
		else
		{
			num = formatter.NextPosition;
			WriteKeyword("Do");
		}
		int start = num;
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		doLoopStatement.Body.AcceptVisitor(this, data);
		if (doLoopStatement.ConditionType == ConditionType.LoopUntil)
		{
			num = DebugStart(doLoopStatement, "Loop");
			WriteKeyword("Until");
			doLoopStatement.Expression.AcceptVisitor(this, data);
			DebugEnd(doLoopStatement);
		}
		else if (doLoopStatement.ConditionType == ConditionType.LoopWhile)
		{
			num = DebugStart(doLoopStatement, "Loop");
			WriteKeyword("While");
			doLoopStatement.Expression.AcceptVisitor(this, data);
			DebugEnd(doLoopStatement);
		}
		else
		{
			num = formatter.NextPosition;
			WriteKeyword("Loop");
		}
		formatter.AddBlock(start, num, CodeBracesRangeFlags.BlockKind_Loop);
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		currentDoReference = obj;
		return EndNode(doLoopStatement);
	}

	public object VisitUsingStatement(ICSharpCode.NRefactory.VB.Ast.UsingStatement usingStatement, object data)
	{
		StartNode(usingStatement);
		object reference = new object();
		int num = DebugStart(usingStatement, "Using");
		int start = num;
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		DebugHidden(usingStatement.Body.HiddenStart);
		WriteCommaSeparatedList(usingStatement.Resources);
		DebugEnd(usingStatement, addSelf: false);
		usingStatement.Body.AcceptVisitor(this, data);
		DebugStart(usingStatement);
		DebugHidden(usingStatement.Body.HiddenEnd);
		num = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_Using);
		WriteKeyword("End");
		WriteKeyword("Using");
		formatter.AddHighlightedKeywordReference(reference, num, formatter.NextPosition);
		DebugEnd(usingStatement, addSelf: false);
		return EndNode(usingStatement);
	}

	public object VisitGoToStatement(GoToStatement goToStatement, object data)
	{
		StartNode(goToStatement);
		DebugStart(goToStatement, "GoTo");
		goToStatement.Label.AcceptVisitor(this, data);
		DebugEnd(goToStatement);
		return EndNode(goToStatement);
	}

	public object VisitSingleLineSubLambdaExpression(SingleLineSubLambdaExpression singleLineSubLambdaExpression, object data)
	{
		DebugExpression(singleLineSubLambdaExpression);
		StartNode(singleLineSubLambdaExpression);
		WriteModifiers(singleLineSubLambdaExpression.ModifierTokens);
		WriteKeyword("Sub");
		WriteCommaSeparatedListInParenthesis(singleLineSubLambdaExpression.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space();
		singleLineSubLambdaExpression.EmbeddedStatement.AcceptVisitor(this, data);
		return EndNode(singleLineSubLambdaExpression);
	}

	public object VisitSingleLineFunctionLambdaExpression(SingleLineFunctionLambdaExpression singleLineFunctionLambdaExpression, object data)
	{
		DebugExpression(singleLineFunctionLambdaExpression);
		StartNode(singleLineFunctionLambdaExpression);
		MethodDebugInfoBuilder methodDebugInfoBuilder = singleLineFunctionLambdaExpression.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = formatter.NextPosition;
		}
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		int nextPosition = formatter.NextPosition;
		WriteModifiers(singleLineFunctionLambdaExpression.ModifierTokens);
		WriteKeyword("Function");
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		WriteCommaSeparatedListInParenthesis(singleLineFunctionLambdaExpression.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		Space();
		singleLineFunctionLambdaExpression.EmbeddedExpression.AcceptVisitor(this, data);
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = formatter.NextPosition;
		}
		currentMethodRefs = methodRefs;
		return EndNode(singleLineFunctionLambdaExpression);
	}

	public object VisitMultiLineLambdaExpression(MultiLineLambdaExpression multiLineLambdaExpression, object data)
	{
		StartNode(multiLineLambdaExpression);
		int nextPosition = formatter.NextPosition;
		int start = nextPosition;
		MethodDebugInfoBuilder methodDebugInfoBuilder = multiLineLambdaExpression.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.StartPosition = nextPosition;
		}
		MethodRefs methodRefs = currentMethodRefs;
		currentMethodRefs = MethodRefs.Create();
		WriteModifiers(multiLineLambdaExpression.ModifierTokens);
		if (multiLineLambdaExpression.IsSub)
		{
			WriteKeyword("Sub");
		}
		else
		{
			WriteKeyword("Function");
		}
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		WriteCommaSeparatedListInParenthesis(multiLineLambdaExpression.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		multiLineLambdaExpression.Body.AcceptVisitor(this, data);
		nextPosition = (lastEndBlockOffset = formatter.NextPosition);
		formatter.AddBlock(start, formatter.NextPosition, CodeBracesRangeFlags.BlockKind_AnonymousMethod);
		WriteKeyword("End");
		if (multiLineLambdaExpression.IsSub)
		{
			WriteKeyword("Sub");
		}
		else
		{
			WriteKeyword("Function");
		}
		if (methodDebugInfoBuilder != null)
		{
			methodDebugInfoBuilder.EndPosition = formatter.NextPosition;
		}
		formatter.AddHighlightedKeywordReference(currentMethodRefs.MethodReference, nextPosition, formatter.NextPosition);
		currentMethodRefs = methodRefs;
		return EndNode(multiLineLambdaExpression);
	}

	public object VisitQueryExpression(ICSharpCode.NRefactory.VB.Ast.QueryExpression queryExpression, object data)
	{
		StartNode(queryExpression);
		foreach (QueryOperator queryOperator in queryExpression.QueryOperators)
		{
			queryOperator.AcceptVisitor(this, data);
		}
		return EndNode(queryExpression);
	}

	public object VisitContinueStatement(ICSharpCode.NRefactory.VB.Ast.ContinueStatement continueStatement, object data)
	{
		StartNode(continueStatement);
		int start = DebugStart(continueStatement, "Continue");
		switch (continueStatement.ContinueKind)
		{
		case ContinueKind.Do:
			WriteKeyword("Do");
			formatter.AddHighlightedKeywordReference(currentDoReference, start, formatter.NextPosition);
			break;
		case ContinueKind.For:
			WriteKeyword("For");
			formatter.AddHighlightedKeywordReference(currentForReference, start, formatter.NextPosition);
			break;
		case ContinueKind.While:
			WriteKeyword("While");
			formatter.AddHighlightedKeywordReference(currentWhileReference, start, formatter.NextPosition);
			break;
		default:
			throw new Exception("Invalid value for ContinueKind");
		}
		DebugEnd(continueStatement);
		return EndNode(continueStatement);
	}

	public object VisitExternalMethodDeclaration(ExternalMethodDeclaration externalMethodDeclaration, object data)
	{
		StartNode(externalMethodDeclaration);
		WriteAttributes(externalMethodDeclaration.Attributes);
		WriteModifiers(externalMethodDeclaration.ModifierTokens);
		WriteKeyword("Declare");
		switch (externalMethodDeclaration.CharsetModifier)
		{
		case CharsetModifier.Auto:
			WriteKeyword("Auto");
			break;
		case CharsetModifier.Unicode:
			WriteKeyword("Unicode");
			break;
		case CharsetModifier.Ansi:
			WriteKeyword("Ansi");
			break;
		default:
			throw new Exception("Invalid value for CharsetModifier");
		case CharsetModifier.None:
			break;
		}
		if (externalMethodDeclaration.IsSub)
		{
			WriteKeyword("Sub");
		}
		else
		{
			WriteKeyword("Function");
		}
		externalMethodDeclaration.Name.AcceptVisitor(this, data);
		WriteKeyword("Lib");
		Space();
		WritePrimitiveValue(externalMethodDeclaration.Library);
		Space();
		if (externalMethodDeclaration.Alias != null)
		{
			WriteKeyword("Alias");
			Space();
			WritePrimitiveValue(externalMethodDeclaration.Alias);
			Space();
		}
		WriteCommaSeparatedListInParenthesis(externalMethodDeclaration.Parameters, spaceWithin: false, CodeBracesRangeFlags.BraceKind_Parentheses);
		if (!externalMethodDeclaration.IsSub && !externalMethodDeclaration.ReturnType.IsNull)
		{
			Space();
			WriteKeyword("As");
			Space();
			WriteAttributes(externalMethodDeclaration.ReturnTypeAttributes);
			externalMethodDeclaration.ReturnType.AcceptVisitor(this, data);
		}
		SaveDeclarationOffset();
		NewLine();
		return EndNode(externalMethodDeclaration);
	}

	public static string ToVBNetString(ICSharpCode.NRefactory.VB.Ast.PrimitiveExpression primitiveExpression)
	{
		StringWriter stringWriter = new StringWriter();
		new OutputVisitor(stringWriter, new VBFormattingOptions()).WritePrimitiveValue(primitiveExpression.Value);
		return stringWriter.ToString();
	}

	public object VisitEmptyExpression(ICSharpCode.NRefactory.VB.Ast.EmptyExpression emptyExpression, object data)
	{
		DebugExpression(emptyExpression);
		StartNode(emptyExpression);
		return EndNode(emptyExpression);
	}

	public object VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpression anonymousObjectCreationExpression, object data)
	{
		DebugExpression(anonymousObjectCreationExpression);
		StartNode(anonymousObjectCreationExpression);
		WriteKeyword("New");
		WriteKeyword("With");
		BraceHelper braceHelper = BraceHelper.LeftBrace(this, CodeBracesRangeFlags.BraceKind_CurlyBraces);
		Space();
		WriteCommaSeparatedList(anonymousObjectCreationExpression.Initializer);
		Space();
		braceHelper.RightBrace();
		return EndNode(anonymousObjectCreationExpression);
	}

	public object VisitCollectionRangeVariableDeclaration(CollectionRangeVariableDeclaration collectionRangeVariableDeclaration, object data)
	{
		DebugExpression(collectionRangeVariableDeclaration);
		StartNode(collectionRangeVariableDeclaration);
		collectionRangeVariableDeclaration.Identifier.AcceptVisitor(this, data);
		if (!collectionRangeVariableDeclaration.Type.IsNull)
		{
			WriteKeyword("As");
			collectionRangeVariableDeclaration.Type.AcceptVisitor(this, data);
		}
		WriteKeyword("In");
		collectionRangeVariableDeclaration.Expression.AcceptVisitor(this, data);
		return EndNode(collectionRangeVariableDeclaration);
	}

	public object VisitFromQueryOperator(FromQueryOperator fromQueryOperator, object data)
	{
		DebugExpression(fromQueryOperator);
		StartNode(fromQueryOperator);
		WriteKeyword("From");
		WriteCommaSeparatedList(fromQueryOperator.Variables);
		return EndNode(fromQueryOperator);
	}

	public object VisitAggregateQueryOperator(AggregateQueryOperator aggregateQueryOperator, object data)
	{
		DebugExpression(aggregateQueryOperator);
		StartNode(aggregateQueryOperator);
		WriteKeyword("Aggregate");
		aggregateQueryOperator.Variable.AcceptVisitor(this, data);
		foreach (QueryOperator subQueryOperator in aggregateQueryOperator.SubQueryOperators)
		{
			subQueryOperator.AcceptVisitor(this, data);
		}
		WriteKeyword("Into");
		WriteCommaSeparatedList(aggregateQueryOperator.IntoExpressions);
		return EndNode(aggregateQueryOperator);
	}

	public object VisitSelectQueryOperator(SelectQueryOperator selectQueryOperator, object data)
	{
		DebugExpression(selectQueryOperator);
		StartNode(selectQueryOperator);
		WriteKeyword("Select");
		WriteCommaSeparatedList(selectQueryOperator.Variables);
		return EndNode(selectQueryOperator);
	}

	public object VisitDistinctQueryOperator(DistinctQueryOperator distinctQueryOperator, object data)
	{
		DebugExpression(distinctQueryOperator);
		StartNode(distinctQueryOperator);
		WriteKeyword("Distinct");
		return EndNode(distinctQueryOperator);
	}

	public object VisitWhereQueryOperator(WhereQueryOperator whereQueryOperator, object data)
	{
		DebugExpression(whereQueryOperator);
		StartNode(whereQueryOperator);
		WriteKeyword("Where");
		whereQueryOperator.Condition.AcceptVisitor(this, data);
		return EndNode(whereQueryOperator);
	}

	public object VisitPartitionQueryOperator(PartitionQueryOperator partitionQueryOperator, object data)
	{
		DebugExpression(partitionQueryOperator);
		StartNode(partitionQueryOperator);
		switch (partitionQueryOperator.Kind)
		{
		case PartitionKind.Take:
			WriteKeyword("Take");
			break;
		case PartitionKind.TakeWhile:
			WriteKeyword("Take");
			WriteKeyword("While");
			break;
		case PartitionKind.Skip:
			WriteKeyword("Skip");
			break;
		case PartitionKind.SkipWhile:
			WriteKeyword("Skip");
			WriteKeyword("While");
			break;
		default:
			throw new Exception("Invalid value for PartitionKind");
		}
		partitionQueryOperator.Expression.AcceptVisitor(this, data);
		return EndNode(partitionQueryOperator);
	}

	public object VisitOrderExpression(OrderExpression orderExpression, object data)
	{
		DebugExpression(orderExpression);
		StartNode(orderExpression);
		orderExpression.Expression.AcceptVisitor(this, data);
		switch (orderExpression.Direction)
		{
		case ICSharpCode.NRefactory.VB.Ast.QueryOrderingDirection.Ascending:
			WriteKeyword("Ascending");
			break;
		case ICSharpCode.NRefactory.VB.Ast.QueryOrderingDirection.Descending:
			WriteKeyword("Descending");
			break;
		default:
			throw new Exception("Invalid value for QueryExpressionOrderingDirection");
		case ICSharpCode.NRefactory.VB.Ast.QueryOrderingDirection.None:
			break;
		}
		return EndNode(orderExpression);
	}

	public object VisitOrderByQueryOperator(OrderByQueryOperator orderByQueryOperator, object data)
	{
		DebugExpression(orderByQueryOperator);
		StartNode(orderByQueryOperator);
		WriteKeyword("Order");
		WriteKeyword("By");
		WriteCommaSeparatedList(orderByQueryOperator.Expressions);
		return EndNode(orderByQueryOperator);
	}

	public object VisitLetQueryOperator(LetQueryOperator letQueryOperator, object data)
	{
		DebugExpression(letQueryOperator);
		StartNode(letQueryOperator);
		WriteKeyword("Let");
		WriteCommaSeparatedList(letQueryOperator.Variables);
		return EndNode(letQueryOperator);
	}

	public object VisitGroupByQueryOperator(GroupByQueryOperator groupByQueryOperator, object data)
	{
		DebugExpression(groupByQueryOperator);
		StartNode(groupByQueryOperator);
		WriteKeyword("Group");
		WriteCommaSeparatedList(groupByQueryOperator.GroupExpressions);
		WriteKeyword("By");
		WriteCommaSeparatedList(groupByQueryOperator.ByExpressions);
		WriteKeyword("Into");
		WriteCommaSeparatedList(groupByQueryOperator.IntoExpressions);
		return EndNode(groupByQueryOperator);
	}

	public object VisitJoinQueryOperator(JoinQueryOperator joinQueryOperator, object data)
	{
		DebugExpression(joinQueryOperator);
		StartNode(joinQueryOperator);
		WriteKeyword("Join");
		joinQueryOperator.JoinVariable.AcceptVisitor(this, data);
		if (!joinQueryOperator.SubJoinQuery.IsNull)
		{
			joinQueryOperator.SubJoinQuery.AcceptVisitor(this, data);
		}
		WriteKeyword("On");
		bool flag = true;
		foreach (JoinCondition joinCondition in joinQueryOperator.JoinConditions)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				WriteKeyword("And");
			}
			joinCondition.AcceptVisitor(this, data);
		}
		return EndNode(joinQueryOperator);
	}

	public object VisitJoinCondition(JoinCondition joinCondition, object data)
	{
		DebugExpression(joinCondition);
		StartNode(joinCondition);
		joinCondition.Left.AcceptVisitor(this, data);
		WriteKeyword("Equals");
		joinCondition.Right.AcceptVisitor(this, data);
		return EndNode(joinCondition);
	}

	public object VisitGroupJoinQueryOperator(GroupJoinQueryOperator groupJoinQueryOperator, object data)
	{
		DebugExpression(groupJoinQueryOperator);
		StartNode(groupJoinQueryOperator);
		WriteKeyword("Group");
		WriteKeyword("Join");
		groupJoinQueryOperator.JoinVariable.AcceptVisitor(this, data);
		if (!groupJoinQueryOperator.SubJoinQuery.IsNull)
		{
			groupJoinQueryOperator.SubJoinQuery.AcceptVisitor(this, data);
		}
		WriteKeyword("On");
		bool flag = true;
		foreach (JoinCondition joinCondition in groupJoinQueryOperator.JoinConditions)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				WriteKeyword("And");
			}
			joinCondition.AcceptVisitor(this, data);
		}
		WriteKeyword("Into");
		WriteCommaSeparatedList(groupJoinQueryOperator.IntoExpressions);
		return EndNode(groupJoinQueryOperator);
	}

	public object VisitAddRemoveHandlerStatement(AddRemoveHandlerStatement addRemoveHandlerStatement, object data)
	{
		DebugStart(addRemoveHandlerStatement);
		StartNode(addRemoveHandlerStatement);
		if (addRemoveHandlerStatement.IsAddHandler)
		{
			WriteKeyword("AddHandler");
		}
		else
		{
			WriteKeyword("RemoveHandler");
		}
		addRemoveHandlerStatement.EventExpression.AcceptVisitor(this, data);
		Comma(addRemoveHandlerStatement.DelegateExpression);
		addRemoveHandlerStatement.DelegateExpression.AcceptVisitor(this, data);
		DebugEnd(addRemoveHandlerStatement);
		return EndNode(addRemoveHandlerStatement);
	}
}
