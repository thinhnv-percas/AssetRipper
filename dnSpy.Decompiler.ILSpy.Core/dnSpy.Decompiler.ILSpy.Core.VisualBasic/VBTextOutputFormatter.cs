using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.VB;
using ICSharpCode.NRefactory.VB.Ast;

namespace dnSpy.Decompiler.ILSpy.Core.VisualBasic;

internal sealed class VBTextOutputFormatter : IOutputFormatter
{
	private class DebugState
	{
		public List<ICSharpCode.NRefactory.VB.AstNode> Nodes = new List<ICSharpCode.NRefactory.VB.AstNode>();

		public List<ILSpan> ExtraILSpans = new List<ILSpan>();

		public int StartLocation;
	}

	private readonly IDecompilerOutput output;

	private readonly DecompilerContext context;

	private readonly Stack<ICSharpCode.NRefactory.VB.AstNode> nodeStack = new Stack<ICSharpCode.NRefactory.VB.AstNode>();

	private MethodDebugInfoBuilder currentMethodDebugInfoBuilder;

	private Stack<MethodDebugInfoBuilder> parentMethodDebugInfoBuilder = new Stack<MethodDebugInfoBuilder>();

	private List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>> multiMappings;

	private bool canPrintAccessor = true;

	private readonly Stack<DebugState> debugStack = new Stack<DebugState>();

	public int NextPosition => output.NextPosition;

	public VBTextOutputFormatter(IDecompilerOutput output, DecompilerContext context)
	{
		this.output = output ?? throw new ArgumentNullException("output");
		this.context = context ?? throw new ArgumentNullException("context");
	}

	public void StartNode(ICSharpCode.NRefactory.VB.AstNode node)
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

	public void EndNode(ICSharpCode.NRefactory.VB.AstNode node)
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
			output.AddDebugInfo(currentMethodDebugInfoBuilder.Create());
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

	public void WriteIdentifier(string identifier, object data, object extraData)
	{
		object currentDefinition = GetCurrentDefinition();
		if (currentDefinition != null)
		{
			output.Write(IdentifierEscaper.Escape(identifier), currentDefinition, DecompilerReferenceFlags.Definition, data);
			return;
		}
		object obj = ((object)GetCurrentMemberReference()) ?? ((object)(extraData as NamespaceReference));
		if (obj != null)
		{
			output.Write(IdentifierEscaper.Escape(identifier), obj, DecompilerReferenceFlags.None, data);
			return;
		}
		currentDefinition = GetCurrentLocalDefinition();
		if (currentDefinition != null)
		{
			output.Write(IdentifierEscaper.Escape(identifier), currentDefinition, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, data);
			return;
		}
		obj = GetCurrentLocalReference();
		if (obj != null)
		{
			output.Write(IdentifierEscaper.Escape(identifier), obj, DecompilerReferenceFlags.Local, data);
		}
		else
		{
			output.Write(IdentifierEscaper.Escape(identifier), data);
		}
	}

	private IMemberRef GetCurrentMemberReference()
	{
		ICSharpCode.NRefactory.VB.AstNode astNode = nodeStack.Peek();
		if (astNode.Annotation<ILVariable>() != null)
		{
			return null;
		}
		if (astNode.Role == ICSharpCode.NRefactory.VB.AstNode.Roles.Type && astNode.Parent is ObjectCreationExpression)
		{
			astNode = astNode.Parent;
		}
		IMemberRef memberRef = astNode.Annotation<IMemberRef>();
		if (memberRef == null && astNode is ICSharpCode.NRefactory.VB.Ast.Identifier)
		{
			astNode = astNode.Parent ?? astNode;
			memberRef = astNode.Annotation<IMemberRef>();
		}
		if (memberRef == null && astNode.Role == ICSharpCode.NRefactory.VB.AstNode.Roles.TargetExpression && (astNode.Parent is ICSharpCode.NRefactory.VB.Ast.InvocationExpression || astNode.Parent is ObjectCreationExpression))
		{
			memberRef = astNode.Parent.Annotation<IMemberRef>();
		}
		return memberRef;
	}

	private object GetCurrentLocalReference()
	{
		ICSharpCode.NRefactory.VB.AstNode astNode = nodeStack.Peek();
		ILVariable iLVariable = astNode.Annotation<ILVariable>();
		if (iLVariable == null && astNode.Parent is ICSharpCode.NRefactory.VB.Ast.IdentifierExpression)
		{
			iLVariable = astNode.Parent.Annotation<ILVariable>();
		}
		if (iLVariable != null)
		{
			return iLVariable.GetTextReferenceObject();
		}
		ICSharpCode.NRefactory.VB.Ast.Expression expression = (astNode.Parent?.Parent as GoToStatement)?.Label ?? (astNode.Parent?.Parent as LabelDeclarationStatement)?.Label;
		if (expression != null)
		{
			IMethod method = nodeStack.Select((ICSharpCode.NRefactory.VB.AstNode nd) => nd.Annotation<IMethod>()).FirstOrDefault((IMethod mr) => mr?.IsMethod ?? false);
			if (method != null)
			{
				return method.ToString() + expression;
			}
		}
		return null;
	}

	private object GetCurrentLocalDefinition()
	{
		ICSharpCode.NRefactory.VB.AstNode astNode = nodeStack.Peek();
		if (astNode is ICSharpCode.NRefactory.VB.Ast.Identifier && astNode.Parent is CatchBlock)
		{
			astNode = astNode.Parent;
		}
		Parameter parameter = astNode.Annotation<Parameter>();
		if (parameter != null)
		{
			return parameter;
		}
		if (astNode is ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration)
		{
			astNode = ((ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration)astNode).Name;
			parameter = astNode.Annotation<Parameter>();
			if (parameter != null)
			{
				return parameter;
			}
		}
		if (astNode is VariableIdentifier)
		{
			ILVariable iLVariable = ((VariableIdentifier)astNode).Name.Annotation<ILVariable>();
			if (iLVariable != null)
			{
				return iLVariable.GetTextReferenceObject();
			}
			astNode = astNode.Parent ?? astNode;
		}
		if (astNode is VariableDeclaratorWithTypeAndInitializer || astNode is ICSharpCode.NRefactory.VB.Ast.VariableInitializer || astNode is CatchBlock || astNode is ForEachStatement)
		{
			ILVariable iLVariable2 = astNode.Annotation<ILVariable>();
			if (iLVariable2 != null)
			{
				return iLVariable2.GetTextReferenceObject();
			}
		}
		if (astNode is LabelDeclarationStatement labelDeclarationStatement)
		{
			IMethod method = nodeStack.Select((ICSharpCode.NRefactory.VB.AstNode nd) => nd.Annotation<IMethod>()).FirstOrDefault((IMethod mr) => mr?.IsMethod ?? false);
			if (method != null)
			{
				return method.ToString() + labelDeclarationStatement.Label;
			}
		}
		return null;
	}

	private object GetCurrentDefinition()
	{
		if (nodeStack == null || nodeStack.Count == 0)
		{
			return null;
		}
		ICSharpCode.NRefactory.VB.AstNode astNode = nodeStack.Peek();
		if (astNode is ICSharpCode.NRefactory.VB.Ast.ParameterDeclaration)
		{
			return null;
		}
		if (astNode is VariableIdentifier)
		{
			return ((VariableIdentifier)astNode).Name.Annotation<IMemberDef>();
		}
		if (IsDefinition(astNode))
		{
			return astNode.Annotation<IMemberRef>();
		}
		if (astNode is ICSharpCode.NRefactory.VB.Ast.Identifier)
		{
			astNode = astNode.Parent;
			if (IsDefinition(astNode))
			{
				return astNode.Annotation<IMemberRef>();
			}
		}
		return null;
	}

	public void WriteKeyword(string keyword)
	{
		IMemberRef currentMemberReference = GetCurrentMemberReference();
		ICSharpCode.NRefactory.VB.AstNode astNode = nodeStack.Peek();
		if (currentMemberReference != null && (astNode is ICSharpCode.NRefactory.VB.Ast.PrimitiveType || astNode is InstanceExpression))
		{
			output.Write(keyword, currentMemberReference, DecompilerReferenceFlags.None, BoxedTextColor.Keyword);
			return;
		}
		if (currentMemberReference != null && astNode is ICSharpCode.NRefactory.VB.Ast.ConstructorDeclaration && keyword == "New")
		{
			output.Write(keyword, currentMemberReference, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Keyword);
			return;
		}
		if (currentMemberReference != null && astNode is ICSharpCode.NRefactory.VB.Ast.Accessor)
		{
			switch (keyword)
			{
			case "Get":
			case "Set":
			case "AddHandler":
			case "RemoveHandler":
			case "RaiseEvent":
				if (canPrintAccessor)
				{
					output.Write(keyword, currentMemberReference, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Keyword);
				}
				else
				{
					output.Write(keyword, BoxedTextColor.Keyword);
				}
				canPrintAccessor = !canPrintAccessor;
				return;
			}
		}
		if (currentMemberReference != null && astNode is ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration && keyword == "Operator")
		{
			output.Write(keyword, currentMemberReference, DecompilerReferenceFlags.Definition, BoxedTextColor.Keyword);
		}
		else
		{
			output.Write(keyword, BoxedTextColor.Keyword);
		}
	}

	public void WriteToken(string token, object data)
	{
		IMemberRef currentMemberReference = GetCurrentMemberReference();
		ICSharpCode.NRefactory.VB.AstNode astNode = nodeStack.Peek();
		bool flag = currentMemberReference != null && (astNode is ICSharpCode.NRefactory.VB.Ast.BinaryOperatorExpression || astNode is ICSharpCode.NRefactory.VB.Ast.UnaryOperatorExpression || astNode is ICSharpCode.NRefactory.VB.Ast.AssignmentExpression);
		if (!flag && astNode is ICSharpCode.NRefactory.VB.Ast.InvocationExpression && currentMemberReference is IMethod)
		{
			MethodDef methodDef = Resolve(currentMemberReference as IMethod);
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

	private static MethodDef Resolve(IMethod method)
	{
		if (method is MethodSpec)
		{
			method = ((MethodSpec)method).Method;
		}
		if (method is MemberRef)
		{
			return ((MemberRef)method).ResolveMethod();
		}
		return (MethodDef)method;
	}

	public void Space()
	{
		output.Write(" ", BoxedTextColor.Text);
	}

	public void Indent()
	{
		output.IncreaseIndent();
	}

	public void Unindent()
	{
		output.DecreaseIndent();
	}

	public void NewLine()
	{
		output.WriteLine();
	}

	public void WriteComment(bool isDocumentation, string content, CommentReference[] refs)
	{
		if (isDocumentation)
		{
			output.Write("'''", BoxedTextColor.XmlDocCommentDelimiter);
			output.WriteXmlDoc(content);
			output.WriteLine();
		}
		else
		{
			output.Write("'", BoxedTextColor.Comment);
			Write(content, refs);
			output.WriteLine();
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

	private static bool IsDefinition(ICSharpCode.NRefactory.VB.AstNode node)
	{
		if (!(node is ICSharpCode.NRefactory.VB.Ast.FieldDeclaration) && !(node is ICSharpCode.NRefactory.VB.Ast.ConstructorDeclaration) && !(node is ICSharpCode.NRefactory.VB.Ast.EventDeclaration) && !(node is ICSharpCode.NRefactory.VB.Ast.DelegateDeclaration) && !(node is ICSharpCode.NRefactory.VB.Ast.OperatorDeclaration) && !(node is MemberDeclaration) && !(node is ICSharpCode.NRefactory.VB.Ast.TypeDeclaration) && !(node is EnumDeclaration) && !(node is ICSharpCode.NRefactory.VB.Ast.EnumMemberDeclaration))
		{
			return node is ICSharpCode.NRefactory.VB.Ast.TypeParameterDeclaration;
		}
		return true;
	}

	public void DebugStart(ICSharpCode.NRefactory.VB.AstNode node)
	{
		debugStack.Push(new DebugState
		{
			StartLocation = output.NextPosition
		});
	}

	public void DebugHidden(object hiddenILSpans)
	{
		if (hiddenILSpans is IList<ILSpan> collection && debugStack.Count > 0)
		{
			debugStack.Peek().ExtraILSpans.AddRange(collection);
		}
	}

	public void DebugExpression(ICSharpCode.NRefactory.VB.AstNode node)
	{
		if (debugStack.Count > 0)
		{
			debugStack.Peek().Nodes.Add(node);
		}
	}

	public void DebugEnd(ICSharpCode.NRefactory.VB.AstNode node)
	{
		DebugState debugState = debugStack.Pop();
		if (currentMethodDebugInfoBuilder != null)
		{
			foreach (ILSpan item in ILSpan.OrderAndCompact(GetILSpans(debugState)))
			{
				currentMethodDebugInfoBuilder.Add(new SourceStatement(item, new TextSpan(debugState.StartLocation, output.NextPosition - debugState.StartLocation)));
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
				multiMapping.Item1.Add(new SourceStatement(item2, new TextSpan(debugState.StartLocation, output.NextPosition - debugState.StartLocation)));
			}
		}
	}

	private static IEnumerable<ILSpan> GetILSpans(DebugState state)
	{
		foreach (ICSharpCode.NRefactory.VB.AstNode node in state.Nodes)
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
		foreach (ILSpan extraILSpan in state.ExtraILSpans)
		{
			yield return extraILSpan;
		}
	}

	public void AddHighlightedKeywordReference(object reference, int start, int end)
	{
		if (reference != null)
		{
			output.AddSpanReference(reference, start, end, "HighlightRelatedKeywords");
		}
	}

	public void AddBracePair(int leftStart, int leftEnd, int rightStart, int rightEnd, CodeBracesRangeFlags flags)
	{
		output.AddBracePair(TextSpan.FromBounds(leftStart, leftEnd), TextSpan.FromBounds(rightStart, rightEnd), flags);
	}

	public void AddBlock(int start, int end, CodeBracesRangeFlags flags)
	{
		output.AddBracePair(new TextSpan(start, 0), new TextSpan(end, 0), flags);
	}

	public void AddLineSeparator(int position)
	{
		output.AddLineSeparator(position);
	}
}
