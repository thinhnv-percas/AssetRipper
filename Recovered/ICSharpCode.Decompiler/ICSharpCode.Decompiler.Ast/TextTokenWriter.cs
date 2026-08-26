using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast
{
	public class TextTokenWriter : TokenWriter
	{
		private readonly ITextOutput output;

		private readonly DecompilerContext context;

		private readonly Stack<AstNode> nodeStack = new Stack<AstNode>();

		private int braceLevelWithinType = -1;

		private bool inDocumentationComment;

		private bool firstUsingDeclaration;

		private bool lastUsingDeclaration;

		private TextLocation? lastEndOfLine;

		public bool FoldBraces;

		private Stack<TextLocation> startLocations = new Stack<TextLocation>();

		private Stack<MethodDebugSymbols> symbolsStack = new Stack<MethodDebugSymbols>();

		public TextTokenWriter(ITextOutput output, DecompilerContext context)
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

		public override void WriteIdentifier(Identifier identifier)
		{
			if (identifier.IsVerbatim || CSharpOutputVisitor.IsKeyword(identifier.Name, identifier))
			{
				output.Write('@');
			}
			object currentDefinition = GetCurrentDefinition();
			if (currentDefinition != null)
			{
				output.WriteDefinition(identifier.Name, currentDefinition, isLocal: false);
				return;
			}
			object currentMemberReference = GetCurrentMemberReference();
			if (currentMemberReference != null)
			{
				output.WriteReference(identifier.Name, currentMemberReference);
				return;
			}
			currentDefinition = GetCurrentLocalDefinition();
			if (currentDefinition != null)
			{
				output.WriteDefinition(identifier.Name, currentDefinition);
				return;
			}
			currentMemberReference = GetCurrentLocalReference();
			if (currentMemberReference != null)
			{
				output.WriteReference(identifier.Name, currentMemberReference, isLocal: true);
				return;
			}
			if (firstUsingDeclaration)
			{
				output.MarkFoldStart("...", defaultCollapsed: true);
				firstUsingDeclaration = false;
			}
			output.Write(identifier.Name);
		}

		private MemberReference GetCurrentMemberReference()
		{
			AstNode astNode = nodeStack.Peek();
			MemberReference memberReference = astNode.Annotation<MemberReference>();
			if (memberReference == null && astNode.Role == Roles.TargetExpression && (astNode.Parent is InvocationExpression || astNode.Parent is ObjectCreateExpression))
			{
				memberReference = astNode.Parent.Annotation<MemberReference>();
			}
			if (astNode is IdentifierExpression && astNode.Role == Roles.TargetExpression && astNode.Parent is InvocationExpression && memberReference != null)
			{
				TypeDefinition typeDefinition = memberReference.DeclaringType.Resolve();
				if (typeDefinition != null && typeDefinition.IsDelegate())
				{
					return null;
				}
			}
			return FilterMemberReference(memberReference);
		}

		private MemberReference FilterMemberReference(MemberReference memberRef)
		{
			if (memberRef == null)
			{
				return null;
			}
			if (context.Settings.AutomaticEvents && memberRef is FieldDefinition)
			{
				FieldDefinition field = (FieldDefinition)memberRef;
				return field.DeclaringType.Events.FirstOrDefault((EventDefinition ev) => ev.Name == field.Name) ?? memberRef;
			}
			return memberRef;
		}

		private object GetCurrentLocalReference()
		{
			AstNode astNode = nodeStack.Peek();
			ILVariable iLVariable = astNode.Annotation<ILVariable>();
			if (iLVariable != null)
			{
				if (iLVariable.OriginalParameter != null)
				{
					return iLVariable.OriginalParameter;
				}
				return iLVariable;
			}
			GotoStatement gotoStatement = astNode as GotoStatement;
			if (gotoStatement != null)
			{
				MethodReference methodReference = (from nd in nodeStack
					select nd.Annotation<MethodReference>()).FirstOrDefault((MethodReference mr) => mr != null);
				if (methodReference != null)
				{
					return methodReference.ToString() + gotoStatement.Label;
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
			ParameterDefinition parameterDefinition = astNode.Annotation<ParameterDefinition>();
			if (parameterDefinition != null)
			{
				return parameterDefinition;
			}
			if (astNode is VariableInitializer || astNode is CatchClause || astNode is ForeachStatement)
			{
				ILVariable iLVariable = astNode.Annotation<ILVariable>();
				if (iLVariable != null)
				{
					if (iLVariable.OriginalParameter != null)
					{
						return iLVariable.OriginalParameter;
					}
					return iLVariable;
				}
			}
			LabelStatement labelStatement = astNode as LabelStatement;
			if (labelStatement != null)
			{
				MethodReference methodReference = (from nd in nodeStack
					select nd.Annotation<MethodReference>()).FirstOrDefault((MethodReference mr) => mr != null);
				if (methodReference != null)
				{
					return methodReference.ToString() + labelStatement.Label;
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
			AstNode astNode = nodeStack.Peek();
			if (astNode is Identifier)
			{
				astNode = astNode.Parent;
			}
			if (IsDefinition(astNode))
			{
				return astNode.Annotation<MemberReference>();
			}
			return null;
		}

		public override void WriteKeyword(Role role, string keyword)
		{
			if (role == ConstructorInitializer.ThisKeywordRole || role == ConstructorInitializer.BaseKeywordRole)
			{
				MemberReference currentMemberReference = GetCurrentMemberReference();
				if (currentMemberReference != null)
				{
					output.WriteReference(keyword, currentMemberReference);
					return;
				}
			}
			output.Write(keyword);
		}

		public override void WriteToken(Role role, string token)
		{
			MemberReference currentMemberReference = GetCurrentMemberReference();
			AstNode astNode = nodeStack.Peek();
			if (currentMemberReference != null && astNode.GetChildByRole(Roles.Identifier).IsNull)
			{
				output.WriteReference(token, currentMemberReference);
			}
			else
			{
				output.Write(token);
			}
		}

		public override void Space()
		{
			output.Write(' ');
		}

		public void OpenBrace(BraceStyle style)
		{
			if (braceLevelWithinType >= 0 || nodeStack.Peek() is TypeDeclaration)
			{
				braceLevelWithinType++;
			}
			if (nodeStack.OfType<BlockStatement>().Count() <= 1 || FoldBraces)
			{
				output.MarkFoldStart("...", braceLevelWithinType == 1);
			}
			output.WriteLine();
			output.WriteLine("{");
			output.Indent();
		}

		public void CloseBrace(BraceStyle style)
		{
			output.Unindent();
			output.Write('}');
			if (nodeStack.OfType<BlockStatement>().Count() <= 1 || FoldBraces)
			{
				output.MarkFoldEnd();
			}
			if (braceLevelWithinType >= 0)
			{
				braceLevelWithinType--;
			}
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
			lastEndOfLine = output.Location;
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
				if (inDocumentationComment && flag)
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
			output.Write(type);
			if (type == "new")
			{
				output.Write("()");
			}
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
			startLocations.Push(output.Location);
			if (node is EntityDeclaration && node.Annotation<MemberReference>() != null && node.GetChildByRole(Roles.Identifier).IsNull)
			{
				output.WriteDefinition("", node.Annotation<MemberReference>(), isLocal: false);
			}
			if (node.Annotation<MethodDebugSymbols>() != null)
			{
				symbolsStack.Push(node.Annotation<MethodDebugSymbols>());
				symbolsStack.Peek().StartLocation = startLocations.Peek();
			}
		}

		private bool IsUsingDeclaration(AstNode node)
		{
			if (!(node is UsingDeclaration))
			{
				return node is UsingAliasDeclaration;
			}
			return true;
		}

		public override void EndNode(AstNode node)
		{
			if (nodeStack.Pop() != node)
			{
				throw new InvalidOperationException();
			}
			TextLocation startLocation = startLocations.Pop();
			List<ILRange> list = node.Annotation<List<ILRange>>();
			if (symbolsStack.Count > 0 && list != null && list.Count > 0)
			{
				TextLocation endLocation = (!(node is Statement)) ? output.Location : (lastEndOfLine ?? output.Location);
				symbolsStack.Peek().SequencePoints.Add(new SequencePoint
				{
					ILRanges = ILRange.OrderAndJoin(list).ToArray(),
					StartLocation = startLocation,
					EndLocation = endLocation
				});
			}
			if (node.Annotation<MethodDebugSymbols>() != null)
			{
				symbolsStack.Peek().EndLocation = output.Location;
				output.AddDebugSymbols(symbolsStack.Pop());
			}
		}

		private static bool IsDefinition(AstNode node)
		{
			if (!(node is EntityDeclaration) && (!(node is VariableInitializer) || !(node.Parent is FieldDeclaration)))
			{
				return node is FixedVariableInitializer;
			}
			return true;
		}
	}
}
