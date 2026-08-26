using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler;

public class TextTokenWriter : TokenWriter
{
	private readonly ITextOutput output;

	private readonly DecompilerSettings settings;

	private readonly IDecompilerTypeSystem typeSystem;

	private readonly Stack<AstNode> nodeStack = new Stack<AstNode>();

	private int braceLevelWithinType = -1;

	private bool inDocumentationComment = false;

	private bool firstUsingDeclaration;

	private bool lastUsingDeclaration;

	public bool FoldBraces = false;

	public bool ExpandMemberDefinitions = false;

	public TextTokenWriter(ITextOutput output, DecompilerSettings settings, IDecompilerTypeSystem typeSystem)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		if (settings == null)
		{
			throw new ArgumentNullException("settings");
		}
		if (typeSystem == null)
		{
			throw new ArgumentNullException("typeSystem");
		}
		this.output = output;
		this.settings = settings;
		this.typeSystem = typeSystem;
	}

	public override void WriteIdentifier(Identifier identifier)
	{
		if (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier))
		{
			output.Write('@');
		}
		ISymbol currentDefinition = GetCurrentDefinition();
		string text = TextWriterTokenWriter.EscapeIdentifier(identifier.Name);
		ISymbol symbol = currentDefinition;
		ISymbol symbol2 = symbol;
		if (symbol2 != null)
		{
			if (symbol2 is IType type)
			{
				IType type2 = type;
				output.WriteReference(type2, text, isDefinition: true);
				return;
			}
			if (symbol2 is IMember member)
			{
				IMember member2 = member;
				output.WriteReference(member2, text, isDefinition: true);
				return;
			}
		}
		ISymbol currentMemberReference = GetCurrentMemberReference();
		ISymbol symbol3 = currentMemberReference;
		ISymbol symbol4 = symbol3;
		if (symbol4 != null)
		{
			if (symbol4 is IType type3)
			{
				IType type4 = type3;
				output.WriteReference(type4, text);
				return;
			}
			if (symbol4 is IMember member3)
			{
				IMember member4 = member3;
				output.WriteReference(member4, text);
				return;
			}
		}
		object currentLocalDefinition = GetCurrentLocalDefinition();
		if (currentLocalDefinition != null)
		{
			output.WriteLocalReference(text, currentLocalDefinition, isDefinition: true);
			return;
		}
		object currentLocalReference = GetCurrentLocalReference();
		if (currentLocalReference != null)
		{
			output.WriteLocalReference(text, currentLocalReference);
			return;
		}
		if (firstUsingDeclaration)
		{
			output.MarkFoldStart("...", defaultCollapsed: true);
			firstUsingDeclaration = false;
		}
		output.Write(text);
	}

	private ISymbol GetCurrentMemberReference()
	{
		AstNode astNode = nodeStack.Peek();
		ISymbol symbol = astNode.GetSymbol();
		if (symbol == null && astNode.Role == Roles.TargetExpression && astNode.Parent is InvocationExpression)
		{
			symbol = astNode.Parent.GetSymbol();
		}
		if (symbol != null && astNode.Role == Roles.Type && astNode.Parent is ObjectCreateExpression)
		{
			symbol = astNode.Parent.GetSymbol();
		}
		if (astNode is IdentifierExpression && astNode.Role == Roles.TargetExpression && astNode.Parent is InvocationExpression && symbol is IMember { DeclaringType: { Kind: TypeKind.Delegate } })
		{
			return null;
		}
		return FilterMember(symbol);
	}

	private ISymbol FilterMember(ISymbol symbol)
	{
		if (symbol == null)
		{
			return null;
		}
		return symbol;
	}

	private object GetCurrentLocalReference()
	{
		AstNode astNode = nodeStack.Peek();
		ILVariable iLVariable = astNode.Annotation<ILVariableResolveResult>()?.Variable;
		if (iLVariable != null)
		{
			return iLVariable;
		}
		LetIdentifierAnnotation letIdentifierAnnotation = astNode.Annotation<LetIdentifierAnnotation>();
		if (letIdentifierAnnotation != null)
		{
			return letIdentifierAnnotation;
		}
		if (astNode is GotoStatement gotoStatement)
		{
			IMethod method = Enumerable.FirstOrDefault<IMethod>(Enumerable.Select<AstNode, IMethod>((IEnumerable<AstNode>)nodeStack, (Func<AstNode, IMethod>)((AstNode nd) => nd.GetSymbol() as IMethod)), (Func<IMethod, bool>)((IMethod mr) => mr != null));
			if (method != null)
			{
				return string.Concat(method, gotoStatement.Label);
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
		if (astNode is ParameterDeclaration || astNode is VariableInitializer || astNode is CatchClause || astNode is ForeachStatement)
		{
			ILVariable iLVariable = astNode.Annotation<ILVariableResolveResult>()?.Variable;
			if (iLVariable != null)
			{
				return iLVariable;
			}
		}
		if (astNode is QueryLetClause)
		{
			LetIdentifierAnnotation letIdentifierAnnotation = astNode.Annotation<LetIdentifierAnnotation>();
			if (letIdentifierAnnotation != null)
			{
				return letIdentifierAnnotation;
			}
		}
		if (astNode is LabelStatement labelStatement)
		{
			IMethod method = Enumerable.FirstOrDefault<IMethod>(Enumerable.Select<AstNode, IMethod>((IEnumerable<AstNode>)nodeStack, (Func<AstNode, IMethod>)((AstNode nd) => nd.GetSymbol() as IMethod)), (Func<IMethod, bool>)((IMethod mr) => mr != null));
			if (method != null)
			{
				return string.Concat(method, labelStatement.Label);
			}
		}
		return null;
	}

	private ISymbol GetCurrentDefinition()
	{
		if (nodeStack == null || nodeStack.Count == 0)
		{
			return null;
		}
		AstNode node = nodeStack.Peek();
		if (node is Identifier)
		{
			node = node.Parent;
		}
		if (IsDefinition(ref node))
		{
			return node.GetSymbol();
		}
		return null;
	}

	public override void WriteKeyword(Role role, string keyword)
	{
		if ((role == ConstructorInitializer.ThisKeywordRole || role == ConstructorInitializer.BaseKeywordRole) && nodeStack.Peek() is ConstructorInitializer node && node.GetSymbol() is IMember member)
		{
			output.WriteReference(member, keyword);
		}
		else
		{
			output.Write(keyword);
		}
	}

	public override void WriteToken(Role role, string token)
	{
		checked
		{
			if (!(token == "{"))
			{
				if (token == "}")
				{
					output.Write('}');
					if (role == Roles.RBrace)
					{
						if (Enumerable.Count<BlockStatement>(Enumerable.OfType<BlockStatement>((IEnumerable)nodeStack)) <= 1 || FoldBraces)
						{
							output.MarkFoldEnd();
						}
						if (braceLevelWithinType >= 0)
						{
							braceLevelWithinType--;
						}
					}
					return;
				}
				ISymbol currentMemberReference = GetCurrentMemberReference();
				AstNode astNode = nodeStack.Peek();
				if (currentMemberReference != null && astNode.GetChildByRole(Roles.Identifier).IsNull)
				{
					ISymbol symbol = currentMemberReference;
					ISymbol symbol2 = symbol;
					if (symbol2 == null)
					{
						return;
					}
					if (!(symbol2 is IType type))
					{
						if (symbol2 is IMember member)
						{
							IMember member2 = member;
							output.WriteReference(member2, token);
						}
					}
					else
					{
						IType type2 = type;
						output.WriteReference(type2, token);
					}
				}
				else
				{
					output.Write(token);
				}
			}
			else if (role != Roles.LBrace)
			{
				output.Write("{");
			}
			else
			{
				if (braceLevelWithinType >= 0 || nodeStack.Peek() is TypeDeclaration)
				{
					braceLevelWithinType++;
				}
				if (Enumerable.Count<BlockStatement>(Enumerable.OfType<BlockStatement>((IEnumerable)nodeStack)) <= 1 || FoldBraces)
				{
					output.MarkFoldStart("...", !ExpandMemberDefinitions && braceLevelWithinType == 1);
				}
				output.Write("{");
			}
		}
	}

	public override void Space()
	{
		output.Write(' ');
	}

	public override void Indent()
	{
		output.Indent();
	}

	public override void Unindent()
	{
		output.Unindent();
	}

	public override void NewLine()
	{
		if (lastUsingDeclaration)
		{
			output.MarkFoldEnd();
			lastUsingDeclaration = false;
		}
		output.WriteLine();
	}

	public override void WriteComment(CommentType commentType, string content)
	{
		switch (commentType)
		{
		case CommentType.SingleLine:
			output.Write("//");
			output.WriteLine(content);
			break;
		case CommentType.MultiLine:
			output.Write("/*");
			output.Write(content);
			output.Write("*/");
			break;
		case CommentType.Documentation:
		{
			bool flag = !(nodeStack.Peek().NextSibling is Comment);
			if (!inDocumentationComment && !flag)
			{
				inDocumentationComment = true;
				output.MarkFoldStart("///" + content, defaultCollapsed: true);
			}
			output.Write("///");
			output.Write(content);
			if (inDocumentationComment & flag)
			{
				inDocumentationComment = false;
				output.MarkFoldEnd();
			}
			output.WriteLine();
			break;
		}
		default:
			output.Write(content);
			break;
		}
	}

	public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
	{
		output.Write('#');
		output.Write(type.ToString().ToLowerInvariant());
		if (!string.IsNullOrEmpty(argument))
		{
			output.Write(' ');
			output.Write(argument);
		}
		output.WriteLine();
	}

	public override void WritePrimitiveValue(object value, string literalValue = null)
	{
		new TextWriterTokenWriter(new TextOutputWriter(output)).WritePrimitiveValue(value, literalValue);
	}

	public override void WritePrimitiveType(string type)
	{
		switch (type)
		{
		case "new":
			output.Write(type);
			output.Write("()");
			return;
		case "bool":
		case "byte":
		case "sbyte":
		case "short":
		case "ushort":
		case "int":
		case "uint":
		case "long":
		case "ulong":
		case "float":
		case "double":
		case "decimal":
		case "char":
		case "string":
		case "object":
		{
			AstNode astNode = nodeStack.Peek();
			ISymbol symbol = ((astNode.Role != Roles.Type || !(astNode.Parent is ObjectCreateExpression)) ? nodeStack.Peek().GetSymbol() : astNode.Parent.GetSymbol());
			if (symbol == null)
			{
				break;
			}
			ISymbol symbol2 = symbol;
			ISymbol symbol3 = symbol2;
			if (symbol3 == null)
			{
				return;
			}
			if (!(symbol3 is IType type2))
			{
				if (symbol3 is IMember member)
				{
					IMember member2 = member;
					output.WriteReference(member2, type);
				}
			}
			else
			{
				IType type3 = type2;
				output.WriteReference(type3, type);
			}
			return;
		}
		}
		output.Write(type);
	}

	public override void StartNode(AstNode node)
	{
		if (nodeStack.Count == 0)
		{
			if (IsUsingDeclaration(node))
			{
				firstUsingDeclaration = !IsUsingDeclaration(node.PrevSibling);
				lastUsingDeclaration = !IsUsingDeclaration(node.NextSibling);
			}
			else
			{
				firstUsingDeclaration = false;
				lastUsingDeclaration = false;
			}
		}
		nodeStack.Push(node);
	}

	private bool IsUsingDeclaration(AstNode node)
	{
		return node is UsingDeclaration || node is UsingAliasDeclaration;
	}

	public override void EndNode(AstNode node)
	{
		if (nodeStack.Pop() != node)
		{
			throw new InvalidOperationException();
		}
	}

	private static bool IsDefinition(ref AstNode node)
	{
		if (node is EntityDeclaration)
		{
			return true;
		}
		if (node is VariableInitializer && node.Parent is FieldDeclaration)
		{
			node = node.Parent;
			return true;
		}
		if (node is FixedVariableInitializer)
		{
			return true;
		}
		return false;
	}
}
