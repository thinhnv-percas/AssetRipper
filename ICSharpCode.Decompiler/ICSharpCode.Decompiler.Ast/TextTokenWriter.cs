using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast;

public class TextTokenWriter : TokenWriter
{
	private class DebugState
	{
		public List<AstNode> Nodes = new List<AstNode>();

		public int StartSpan;
	}

	private readonly IDecompilerOutput output;

	private readonly DecompilerContext context;

	private readonly Stack<AstNode> nodeStack = new Stack<AstNode>();

	private int braceLevelWithinType = -1;

	public bool FoldBraces;

	private MethodDebugInfoBuilder currentMethodDebugInfoBuilder;

	private Stack<MethodDebugInfoBuilder> parentMethodDebugInfoBuilder = new Stack<MethodDebugInfoBuilder>();

	private List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>> multiMappings;

	private readonly Stack<DebugState> debugStack = new Stack<DebugState>();

	public TextTokenWriter(IDecompilerOutput output, DecompilerContext context)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		this.output = output;
		this.context = context;
	}

	public override void WriteIdentifier(Identifier identifier, object data)
	{
		if (BoxedTextColor.Text.Equals(data))
		{
			MetadataTextColorProvider metadataTextColorProvider = context.MetadataTextColorProvider;
			TextColor? textColor = identifier.AnnotationVT<TextColor>();
			data = metadataTextColorProvider.GetColor(textColor.HasValue ? ((object)textColor.GetValueOrDefault()) : identifier.Annotation<object>());
		}
		string text = IdentifierEscaper.Escape(identifier.Name);
		if (!BoxedTextColor.Keyword.Equals(data) && (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier)))
		{
			text = "@" + text;
		}
		object currentDefinition = GetCurrentDefinition(identifier);
		if (currentDefinition != null)
		{
			output.Write(text, currentDefinition, DecompilerReferenceFlags.Definition, data);
			return;
		}
		object obj = ((object)GetCurrentMemberReference()) ?? ((object)identifier.Annotation<NamespaceReference>());
		if (obj != null)
		{
			output.Write(text, obj, DecompilerReferenceFlags.None, data);
			return;
		}
		currentDefinition = GetCurrentLocalDefinition();
		if (currentDefinition != null)
		{
			output.Write(text, currentDefinition, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, data);
			return;
		}
		obj = GetCurrentLocalReference();
		if (obj != null)
		{
			output.Write(text, obj, DecompilerReferenceFlags.Local, data);
			return;
		}
		if (identifier.Annotation<IdentifierFormatted>() != null)
		{
			text = identifier.Name;
		}
		output.Write(text, data);
	}

	private IMemberRef GetCurrentMemberReference()
	{
		AstNode astNode = nodeStack.Peek();
		IMemberRef memberRef = astNode.Annotation<IMemberRef>();
		if (astNode is IndexerDeclaration)
		{
			memberRef = null;
		}
		if ((astNode is SimpleType || astNode is MemberType) && astNode.Parent is ObjectCreateExpression)
		{
			TypeDef typeDef = (memberRef as IType).Resolve();
			if (typeDef == null || !typeDef.IsDelegate)
			{
				memberRef = astNode.Parent.Annotation<IMemberRef>() ?? memberRef;
			}
		}
		if (memberRef == null && astNode.Role == Roles.TargetExpression && (astNode.Parent is InvocationExpression || astNode.Parent is ObjectCreateExpression))
		{
			memberRef = astNode.Parent.Annotation<IMemberRef>();
		}
		if (astNode is IdentifierExpression && astNode.Role == Roles.TargetExpression && astNode.Parent is InvocationExpression && memberRef != null)
		{
			TypeDef typeDef2 = memberRef.DeclaringType.Resolve();
			if (typeDef2 != null && typeDef2.IsDelegate)
			{
				return null;
			}
		}
		return FilterMemberReference(memberRef);
	}

	private IMemberRef FilterMemberReference(IMemberRef memberRef)
	{
		if (memberRef == null)
		{
			return null;
		}
		if (context.Settings.AutomaticEvents && memberRef is FieldDef)
		{
			FieldDef fieldDef = (FieldDef)memberRef;
			IMemberRef memberRef2 = fieldDef.DeclaringType.FindEvent(fieldDef.Name);
			return memberRef2 ?? memberRef;
		}
		return memberRef;
	}

	private object GetCurrentLocalReference()
	{
		AstNode astNode = nodeStack.Peek();
		ILVariable iLVariable = astNode.Annotation<ILVariable>();
		if (iLVariable != null)
		{
			return iLVariable.GetTextReferenceObject();
		}
		if (astNode is GotoStatement gotoStatement)
		{
			IMethod method = nodeStack.Select((AstNode nd) => nd.Annotation<IMethod>()).FirstOrDefault((IMethod mr) => mr?.IsMethod ?? false);
			if (method != null)
			{
				return method.ToString() + gotoStatement.Label;
			}
		}
		return null;
	}

	private object GetCurrentLocalDefinition()
	{
		AstNode astNode = nodeStack.Peek();
		if (astNode is Identifier && astNode.Parent != null)
		{
			astNode = astNode.Parent;
		}
		Parameter parameter = astNode.Annotation<Parameter>();
		if (parameter != null)
		{
			return parameter;
		}
		if (astNode is VariableInitializer || astNode is CatchClause || astNode is ForeachStatement)
		{
			ILVariable iLVariable = astNode.Annotation<ILVariable>();
			if (iLVariable != null)
			{
				return iLVariable.GetTextReferenceObject();
			}
		}
		if (astNode is LabelStatement labelStatement)
		{
			IMethod method = nodeStack.Select((AstNode nd) => nd.Annotation<IMethod>()).FirstOrDefault((IMethod mr) => mr?.IsMethod ?? false);
			if (method != null)
			{
				return method.ToString() + labelStatement.Label;
			}
		}
		return null;
	}

	private object GetCurrentDefinition(Identifier identifier)
	{
		if (nodeStack != null && nodeStack.Count != 0)
		{
			object definition = GetDefinition(nodeStack.Peek());
			if (definition != null)
			{
				return definition;
			}
		}
		return GetDefinition(identifier);
	}

	private object GetDefinition(AstNode node)
	{
		if (node is Identifier)
		{
			node = node.Parent;
			if (node is VariableInitializer)
			{
				node = node.Parent;
			}
		}
		if (IsDefinition(node))
		{
			return node.Annotation<IMemberRef>();
		}
		return null;
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		WriteKeyword(keyword);
	}

	private void WriteKeyword(string keyword)
	{
		IMemberRef memberRef = GetCurrentMemberReference();
		AstNode astNode = nodeStack.Peek();
		if (astNode is IndexerDeclaration)
		{
			memberRef = astNode.Annotation<PropertyDef>();
		}
		if (keyword != "async" && memberRef != null && (astNode is PrimitiveType || astNode is ConstructorInitializer || astNode is BaseReferenceExpression || astNode is ThisReferenceExpression || astNode is ObjectCreateExpression || astNode is AnonymousMethodExpression))
		{
			output.Write(keyword, memberRef, (keyword == "new") ? DecompilerReferenceFlags.Hidden : DecompilerReferenceFlags.None, BoxedTextColor.Keyword);
		}
		else if (memberRef != null && astNode is IndexerDeclaration && keyword == "this")
		{
			output.Write(keyword, memberRef, DecompilerReferenceFlags.Definition, BoxedTextColor.Keyword);
		}
		else
		{
			output.Write(keyword, BoxedTextColor.Keyword);
		}
	}

	public override void WriteToken(Role role, string token, object data)
	{
		IMemberRef currentMemberReference = GetCurrentMemberReference();
		AstNode astNode = nodeStack.Peek();
		bool flag = currentMemberReference != null && (astNode is BinaryOperatorExpression || astNode is UnaryOperatorExpression || astNode is AssignmentExpression || astNode is IndexerExpression);
		if (!flag && astNode is InvocationExpression && currentMemberReference is IMethod)
		{
			MethodDef methodDef = (currentMemberReference as IMethod).Resolve();
			if (methodDef != null && methodDef.DeclaringType != null && methodDef.DeclaringType.IsDelegate)
			{
				flag = true;
			}
		}
		if (flag)
		{
			output.Write(token, currentMemberReference, DecompilerReferenceFlags.None, data);
		}
		else
		{
			output.Write(token, data);
		}
	}

	public override void Space()
	{
		output.Write(" ", BoxedTextColor.Text);
	}

	public void OpenBrace(BraceStyle style, out int? start, out int? end)
	{
		if (braceLevelWithinType >= 0 || nodeStack.Peek() is TypeDeclaration)
		{
			braceLevelWithinType++;
		}
		output.WriteLine();
		start = output.NextPosition;
		output.Write("{", BoxedTextColor.Punctuation);
		end = output.NextPosition;
		output.WriteLine();
		output.IncreaseIndent();
	}

	public void CloseBrace(BraceStyle style, out int? start, out int? end)
	{
		output.DecreaseIndent();
		start = output.NextPosition;
		output.Write("}", BoxedTextColor.Punctuation);
		end = output.NextPosition;
		if (braceLevelWithinType >= 0)
		{
			braceLevelWithinType--;
		}
	}

	public override void Indent()
	{
		output.IncreaseIndent();
	}

	public override void Unindent()
	{
		output.DecreaseIndent();
	}

	public override void NewLine()
	{
		output.WriteLine();
	}

	public override void WriteComment(CommentType commentType, string content, CommentReference[] refs)
	{
		switch (commentType)
		{
		case CommentType.SingleLine:
			output.Write("//", BoxedTextColor.Comment);
			Write(content, refs);
			output.WriteLine();
			break;
		case CommentType.MultiLine:
			output.Write("/*", BoxedTextColor.Comment);
			Write(content, refs);
			output.Write("*/", BoxedTextColor.Comment);
			break;
		case CommentType.Documentation:
		{
			bool flag = !(nodeStack.Peek().NextSibling is Comment);
			output.Write("///", BoxedTextColor.XmlDocCommentDelimiter);
			output.WriteXmlDoc(content);
			output.WriteLine();
			break;
		}
		default:
			Write(content, refs);
			break;
		}
	}

	private void Write(string content, CommentReference[] refs)
	{
		if (refs == null)
		{
			output.Write(content, BoxedTextColor.Comment);
			return;
		}
		int num = 0;
		for (int i = 0; i < refs.Length; i++)
		{
			CommentReference commentReference = refs[i];
			string text = content.Substring(num, commentReference.Length);
			num += commentReference.Length;
			if (commentReference.Reference == null)
			{
				output.Write(text, BoxedTextColor.Comment);
			}
			else
			{
				output.Write(text, commentReference.Reference, commentReference.IsLocal ? DecompilerReferenceFlags.Local : DecompilerReferenceFlags.None, BoxedTextColor.Comment);
			}
		}
	}

	public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
	{
		output.Write("#", BoxedTextColor.Text);
		output.Write(type.ToString().ToLowerInvariant(), BoxedTextColor.Text);
		if (!string.IsNullOrEmpty(argument))
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write(argument, BoxedTextColor.Text);
		}
		output.WriteLine();
	}

	public override void WritePrimitiveValue(object value, object data = null, string literalValue = null)
	{
		int column = 0;
		TextWriterTokenWriter.WritePrimitiveValue(value, data, literalValue, ref column, WritePrimitiveValueCore, WriteToken);
	}

	private void WritePrimitiveValueCore(string text, object color)
	{
		if (color == BoxedTextColor.String || color == BoxedTextColor.Char)
		{
			int nextPosition = output.NextPosition;
			output.Write(text, color);
			int nextPosition2 = output.NextPosition;
			output.AddBracePair(new TextSpan(nextPosition, 1), new TextSpan(nextPosition2 - 1, 1), CodeBracesRangeFlags.BraceKind_SingleQuotes);
		}
		else
		{
			output.Write(text, color);
		}
	}

	public override void WritePrimitiveType(string type)
	{
		WriteKeyword(type);
		if (type == "new")
		{
			int nextPosition = output.NextPosition;
			output.Write("(", BoxedTextColor.Punctuation);
			int nextPosition2 = output.NextPosition;
			output.Write(")", BoxedTextColor.Punctuation);
			output.AddBracePair(new TextSpan(nextPosition, 1), new TextSpan(nextPosition2, 1), CodeBracesRangeFlags.BraceKind_Parentheses);
		}
	}

	public override void StartNode(AstNode node)
	{
		nodeStack.Push(node);
		MethodDebugInfoBuilder methodDebugInfoBuilder = node.Annotation<MethodDebugInfoBuilder>();
		if (methodDebugInfoBuilder != null)
		{
			parentMethodDebugInfoBuilder.Push(currentMethodDebugInfoBuilder);
			currentMethodDebugInfoBuilder = methodDebugInfoBuilder;
		}
		List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>> list = node.Annotation<List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>>>();
		if (list != null)
		{
			multiMappings = list;
		}
	}

	public override void EndNode(AstNode node)
	{
		if (nodeStack.Pop() != node)
		{
			throw new InvalidOperationException();
		}
		if (node.Annotation<MethodDebugInfoBuilder>() != null)
		{
			if (context.CalculateILSpans)
			{
				foreach (string usingNamespace in context.UsingNamespaces)
				{
					currentMethodDebugInfoBuilder.Scope.Imports.Add(ImportInfo.CreateNamespace(usingNamespace));
				}
			}
			if (parentMethodDebugInfoBuilder.Peek() != currentMethodDebugInfoBuilder)
			{
				output.AddDebugInfo(currentMethodDebugInfoBuilder.Create());
			}
			currentMethodDebugInfoBuilder = parentMethodDebugInfoBuilder.Pop();
		}
		List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>> list = node.Annotation<List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>>>();
		if (list == null || list != multiMappings)
		{
			return;
		}
		foreach (Tuple<MethodDebugInfoBuilder, List<ILSpan>> item in list)
		{
			output.AddDebugInfo(item.Item1.Create());
		}
		multiMappings = null;
	}

	private static bool IsDefinition(AstNode node)
	{
		if (!(node is EntityDeclaration) && (!(node is VariableInitializer) || !(node.Parent is FieldDeclaration)) && !(node is FixedVariableInitializer))
		{
			return node is TypeParameterDeclaration;
		}
		return true;
	}

	public override void DebugStart(AstNode node, int? start)
	{
		debugStack.Push(new DebugState
		{
			StartSpan = (start ?? output.NextPosition)
		});
	}

	public override void DebugHidden(AstNode hiddenNode)
	{
		if (hiddenNode != null && !hiddenNode.IsNull && debugStack.Count > 0)
		{
			debugStack.Peek().Nodes.AddRange(hiddenNode.DescendantsAndSelf);
		}
	}

	public override void DebugExpression(AstNode node)
	{
		if (debugStack.Count > 0)
		{
			debugStack.Peek().Nodes.Add(node);
		}
	}

	public override void DebugEnd(AstNode node, int? end)
	{
		DebugState debugState = debugStack.Pop();
		if (currentMethodDebugInfoBuilder != null)
		{
			foreach (ILSpan item in ILSpan.OrderAndCompact(GetILSpans(debugState)))
			{
				currentMethodDebugInfoBuilder.Add(new SourceStatement(item, new TextSpan(debugState.StartSpan, (end ?? output.NextPosition) - debugState.StartSpan)));
			}
			return;
		}
		if (multiMappings == null)
		{
			return;
		}
		foreach (Tuple<MethodDebugInfoBuilder, List<ILSpan>> multiMapping in multiMappings)
		{
			foreach (ILSpan item2 in ILSpan.OrderAndCompact(multiMapping.Item2))
			{
				multiMapping.Item1.Add(new SourceStatement(item2, new TextSpan(debugState.StartSpan, (end ?? output.NextPosition) - debugState.StartSpan)));
			}
		}
	}

	private static IEnumerable<ILSpan> GetILSpans(DebugState state)
	{
		foreach (AstNode node in state.Nodes)
		{
			foreach (object annotation in node.Annotations)
			{
				if (!(annotation is IList<ILSpan> list))
				{
					continue;
				}
				foreach (ILSpan item in list)
				{
					yield return item;
				}
			}
		}
	}

	public override int? GetLocation()
	{
		return output.NextPosition;
	}

	public override void AddHighlightedKeywordReference(object reference, int start, int end)
	{
		if (reference != null)
		{
			output.AddSpanReference(reference, start, end, "HighlightRelatedKeywords");
		}
	}

	public override void AddBracePair(int leftStart, int leftEnd, int rightStart, int rightEnd, CodeBracesRangeFlags flags)
	{
		output.AddBracePair(TextSpan.FromBounds(leftStart, leftEnd), TextSpan.FromBounds(rightStart, rightEnd), flags);
	}

	public override void AddLineSeparator(int position)
	{
		output.AddLineSeparator(position);
	}
}
