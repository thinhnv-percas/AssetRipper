using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public abstract class Script : IDisposable
	{
		internal struct Segment : ISegment
		{
			private readonly int offset;

			private readonly int length;

			public int Offset => offset;

			public int Length => length;

			public int EndOffset => Offset + Length;

			public Segment(int offset, int length)
			{
				this.offset = offset;
				this.length = length;
			}

			public override string ToString()
			{
				return $"[Script.Segment: Offset={Offset}, Length={Length}, EndOffset={EndOffset}]";
			}
		}

		public enum InsertPosition
		{
			Start,
			Before,
			After,
			End
		}

		private sealed class SegmentTrackingTokenWriter : TextWriterTokenWriter
		{
			internal List<KeyValuePair<AstNode, Segment>> NewSegments = new List<KeyValuePair<AstNode, Segment>>();

			private readonly Stack<int> startOffsets = new Stack<int>();

			private readonly StringWriter stringWriter;

			public SegmentTrackingTokenWriter(StringWriter stringWriter)
				: base(stringWriter)
			{
				this.stringWriter = stringWriter;
			}

			public override void WriteIdentifier(Identifier identifier)
			{
				int length = stringWriter.GetStringBuilder().Length;
				int num = length + (identifier.Name ?? "").Length + (identifier.IsVerbatim ? 1 : 0);
				NewSegments.Add(new KeyValuePair<AstNode, Segment>(identifier, new Segment(length, num - length)));
				base.WriteIdentifier(identifier);
			}

			public override void StartNode(AstNode node)
			{
				base.StartNode(node);
				startOffsets.Push(stringWriter.GetStringBuilder().Length);
			}

			public override void EndNode(AstNode node)
			{
				int num = startOffsets.Pop();
				int length = stringWriter.GetStringBuilder().Length;
				NewSegments.Add(new KeyValuePair<AstNode, Segment>(node, new Segment(num, length - num)));
				base.EndNode(node);
			}
		}

		protected class NodeOutput
		{
			private string text;

			private readonly List<KeyValuePair<AstNode, Segment>> newSegments;

			private int trimmedLength;

			public string Text => text;

			internal NodeOutput(string text, List<KeyValuePair<AstNode, Segment>> newSegments)
			{
				this.text = text;
				this.newSegments = newSegments;
			}

			public void TrimStart()
			{
				int num = 0;
				while (true)
				{
					if (num < text.Length)
					{
						char c = text[num];
						if (c != ' ' && c != '\t')
						{
							break;
						}
						num++;
						continue;
					}
					return;
				}
				if (num > 0)
				{
					text = text.Substring(num);
					trimmedLength = num;
				}
			}

			public void RegisterTrackedSegments(Script script, int insertionOffset)
			{
				foreach (KeyValuePair<AstNode, Segment> newSegment in newSegments)
				{
					int offset = insertionOffset + newSegment.Value.Offset - trimmedLength;
					ISegment value = script.CreateTrackedSegment(offset, newSegment.Value.Length);
					script.segmentsForInsertedNodes.Add(newSegment.Key, value);
				}
			}
		}

		public enum NewTypeContext
		{
			CurrentNamespace,
			UnitTests
		}

		private readonly CSharpFormattingOptions formattingOptions;

		private readonly TextEditorOptions options;

		private readonly Dictionary<AstNode, ISegment> segmentsForInsertedNodes = new Dictionary<AstNode, ISegment>();

		private List<AstNode> nodesToFormat = new List<AstNode>();

		public CSharpFormattingOptions FormattingOptions => formattingOptions;

		public TextEditorOptions Options => options;

		protected Script(CSharpFormattingOptions formattingOptions, TextEditorOptions options)
		{
			if (formattingOptions == null)
			{
				throw new ArgumentNullException("formattingOptions");
			}
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			this.formattingOptions = formattingOptions;
			this.options = options;
		}

		public abstract int GetCurrentOffset(int originalDocumentOffset);

		public abstract int GetCurrentOffset(TextLocation originalDocumentLocation);

		protected abstract ISegment CreateTrackedSegment(int offset, int length);

		public ISegment GetSegment(AstNode node)
		{
			if (segmentsForInsertedNodes.TryGetValue(node, out ISegment value))
			{
				return value;
			}
			if (node.StartLocation.IsEmpty || node.EndLocation.IsEmpty)
			{
				throw new InvalidOperationException("Trying to get the position of a node that is not part of the original document and was not inserted");
			}
			int currentOffset = GetCurrentOffset(node.StartLocation);
			int currentOffset2 = GetCurrentOffset(node.EndLocation);
			return new Segment(currentOffset, currentOffset2 - currentOffset);
		}

		public abstract void Replace(int offset, int length, string newText);

		public void InsertText(int offset, string newText)
		{
			Replace(offset, 0, newText);
		}

		public void RemoveText(int offset, int length)
		{
			Replace(offset, length, "");
		}

		public void InsertBefore(AstNode node, AstNode newNode)
		{
			int currentOffset = GetCurrentOffset(new TextLocation(node.StartLocation.Line, 1));
			NodeOutput nodeOutput = OutputNode(GetIndentLevelAt(currentOffset), newNode);
			string text = nodeOutput.Text;
			if (!(newNode is Expression) && !(newNode is AstType))
			{
				text += Options.EolMarker;
			}
			InsertText(currentOffset, text);
			nodeOutput.RegisterTrackedSegments(this, currentOffset);
			CorrectFormatting(node, newNode);
		}

		public void InsertAfter(AstNode node, AstNode newNode)
		{
			int indentLevel = IndentLevelFor(node);
			NodeOutput nodeOutput = OutputNode(indentLevel, newNode);
			string newText = PrefixFor(node, newNode) + nodeOutput.Text;
			int currentOffset = GetCurrentOffset(node.EndLocation);
			InsertText(currentOffset, newText);
			nodeOutput.RegisterTrackedSegments(this, currentOffset);
			CorrectFormatting(node, newNode);
		}

		private int IndentLevelFor(AstNode node)
		{
			if (!DoesInsertingAfterRequireNewline(node))
			{
				return 0;
			}
			return GetIndentLevelAt(GetCurrentOffset(new TextLocation(node.StartLocation.Line, 1)));
		}

		private bool DoesInsertingAfterRequireNewline(AstNode node)
		{
			if (node is Expression)
			{
				return false;
			}
			if (node is AstType)
			{
				return false;
			}
			if (node is ParameterDeclaration)
			{
				return false;
			}
			CSharpTokenNode cSharpTokenNode = node as CSharpTokenNode;
			if (cSharpTokenNode != null && cSharpTokenNode.Role == Roles.LPar)
			{
				return false;
			}
			return true;
		}

		private string PrefixFor(AstNode node, AstNode newNode)
		{
			if (DoesInsertingAfterRequireNewline(node))
			{
				return Options.EolMarker;
			}
			if (newNode is ParameterDeclaration && node is ParameterDeclaration)
			{
				return ", ";
			}
			return string.Empty;
		}

		public void AddTo(BlockStatement bodyStatement, AstNode newNode)
		{
			int currentOffset = GetCurrentOffset(bodyStatement.LBraceToken.EndLocation);
			NodeOutput nodeOutput = OutputNode(1 + GetIndentLevelAt(currentOffset), newNode, startWithNewLine: true);
			InsertText(currentOffset, nodeOutput.Text);
			nodeOutput.RegisterTrackedSegments(this, currentOffset);
			CorrectFormatting(null, newNode);
		}

		public void AddTo(TypeDeclaration typeDecl, EntityDeclaration entityDecl)
		{
			int currentOffset = GetCurrentOffset(typeDecl.LBraceToken.EndLocation);
			NodeOutput nodeOutput = OutputNode(1 + GetIndentLevelAt(currentOffset), entityDecl, startWithNewLine: true);
			InsertText(currentOffset, nodeOutput.Text);
			nodeOutput.RegisterTrackedSegments(this, currentOffset);
			CorrectFormatting(null, entityDecl);
		}

		public void ChangeModifier(EntityDeclaration entity, Modifiers modifiers)
		{
			MethodDeclaration methodDeclaration = new MethodDeclaration();
			methodDeclaration.Modifiers = modifiers;
			int num;
			int currentOffset;
			if (entity.ModifierTokens.Any())
			{
				num = GetCurrentOffset(entity.ModifierTokens.First().StartLocation);
				currentOffset = GetCurrentOffset(entity.ModifierTokens.Last().GetNextSibling((AstNode s) => s.Role != Roles.NewLine && s.Role != Roles.Whitespace).StartLocation);
			}
			else
			{
				AstNode astNode = entity.FirstChild;
				while (astNode.NodeType == NodeType.Whitespace || astNode.Role == EntityDeclaration.AttributeRole || astNode.Role == Roles.NewLine)
				{
					astNode = astNode.NextSibling;
				}
				num = (currentOffset = GetCurrentOffset(astNode.StartLocation));
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (CSharpModifierToken modifierToken in methodDeclaration.ModifierTokens)
			{
				stringBuilder.Append(modifierToken.ToString());
				stringBuilder.Append(' ');
			}
			Replace(num, currentOffset - num, stringBuilder.ToString());
		}

		public void ChangeModifier(ParameterDeclaration param, ParameterModifier modifier)
		{
			AstNode astNode = param.FirstChild;
			Func<AstNode, bool> func = (AstNode s) => (s.Role != ParameterDeclaration.RefModifierRole && s.Role != ParameterDeclaration.OutModifierRole && s.Role != ParameterDeclaration.ParamsModifierRole) ? (s.Role == ParameterDeclaration.ThisModifierRole) : true;
			if (!func(astNode))
			{
				astNode = astNode.GetNextSibling(func);
			}
			int num;
			int currentOffset;
			if (astNode != null)
			{
				num = GetCurrentOffset(astNode.StartLocation);
				currentOffset = GetCurrentOffset(astNode.GetNextSibling((AstNode s) => s.Role != Roles.NewLine && s.Role != Roles.Whitespace).StartLocation);
			}
			else
			{
				num = (currentOffset = GetCurrentOffset(param.Type.StartLocation));
			}
			string newText;
			switch (modifier)
			{
			case ParameterModifier.None:
				newText = "";
				break;
			case ParameterModifier.Ref:
				newText = "ref ";
				break;
			case ParameterModifier.Out:
				newText = "out ";
				break;
			case ParameterModifier.Params:
				newText = "params ";
				break;
			case ParameterModifier.This:
				newText = "this ";
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			Replace(num, currentOffset - num, newText);
		}

		public void ChangeBaseTypes(TypeDeclaration type, IEnumerable<AstType> baseTypes)
		{
			TypeDeclaration typeDeclaration = new TypeDeclaration();
			typeDeclaration.BaseTypes.AddRange(baseTypes);
			StringBuilder stringBuilder = new StringBuilder();
			int num;
			int currentOffset;
			if (type.BaseTypes.Any())
			{
				num = GetCurrentOffset(type.ColonToken.StartLocation);
				currentOffset = GetCurrentOffset(type.BaseTypes.Last().EndLocation);
			}
			else
			{
				stringBuilder.Append(' ');
				num = ((!type.TypeParameters.Any()) ? (currentOffset = GetCurrentOffset(type.NameToken.EndLocation)) : (currentOffset = GetCurrentOffset(type.RChevronToken.EndLocation)));
			}
			if (typeDeclaration.BaseTypes.Any())
			{
				stringBuilder.Append(": ");
				stringBuilder.Append(string.Join(", ", typeDeclaration.BaseTypes));
			}
			Replace(num, currentOffset - num, stringBuilder.ToString());
			FormatText(type);
		}

		public void AddAttribute(EntityDeclaration entity, AttributeSection attr)
		{
			AstNode astNode = entity.FirstChild;
			while (astNode.NodeType == NodeType.Whitespace || astNode.Role == Roles.Attribute)
			{
				astNode = astNode.NextSibling;
			}
			InsertBefore(astNode, attr);
		}

		public virtual Task Link(params AstNode[] nodes)
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			taskCompletionSource.SetResult(null);
			return taskCompletionSource.Task;
		}

		public virtual Task Link(IEnumerable<AstNode> nodes)
		{
			return Link(nodes.ToArray());
		}

		public void Replace(AstNode node, AstNode replaceWith)
		{
			ISegment segment = GetSegment(node);
			int offset = segment.Offset;
			int indentLevel = 0;
			if (!(replaceWith is Expression) && !(replaceWith is AstType))
			{
				indentLevel = GetIndentLevelAt(offset);
			}
			NodeOutput nodeOutput = OutputNode(indentLevel, replaceWith);
			nodeOutput.TrimStart();
			Replace(offset, segment.Length, nodeOutput.Text);
			nodeOutput.RegisterTrackedSegments(this, offset);
			CorrectFormatting(node, node);
		}

		private void CorrectFormatting(AstNode node, AstNode newNode)
		{
			if (!(node is Identifier) && !(node is IdentifierExpression) && !(node is CSharpTokenNode) && !(node is AstType))
			{
				if (node == null || node.Parent is BlockStatement)
				{
					nodesToFormat.Add(newNode);
				}
				else
				{
					nodesToFormat.Add((node.Parent != null && (node.Parent is Statement || node.Parent is Expression || node.Parent is VariableInitializer)) ? node.Parent : newNode);
				}
			}
		}

		public abstract void Remove(AstNode node, bool removeEmptyLine = true);

		public void RemoveAttribute(Attribute attr)
		{
			AttributeSection attributeSection = (AttributeSection)attr.Parent;
			if (attributeSection.Attributes.Count == 1)
			{
				Remove(attributeSection);
				return;
			}
			AttributeSection attributeSection2 = (AttributeSection)attributeSection.Clone();
			int num = 0;
			using (IEnumerator<Attribute> enumerator = attributeSection.Attributes.GetEnumerator())
			{
				while (enumerator.MoveNext() && enumerator.Current != attr)
				{
					num++;
				}
			}
			attributeSection2.Attributes.Remove(attributeSection2.Attributes.ElementAt(num));
			Replace(attributeSection, attributeSection2);
		}

		public abstract void FormatText(IEnumerable<AstNode> nodes);

		public void FormatText(params AstNode[] nodes)
		{
			FormatText((IEnumerable<AstNode>)nodes);
		}

		public virtual void Select(AstNode node)
		{
		}

		public virtual void Select(TextLocation start, TextLocation end)
		{
		}

		public virtual void Select(int startOffset, int endOffset)
		{
		}

		public virtual Task<Script> InsertWithCursor(string operation, InsertPosition defaultPosition, IList<AstNode> nodes)
		{
			throw new NotImplementedException();
		}

		public virtual Task<Script> InsertWithCursor(string operation, ITypeDefinition parentType, Func<Script, RefactoringContext, IList<AstNode>> nodeCallback)
		{
			throw new NotImplementedException();
		}

		public Task<Script> InsertWithCursor(string operation, InsertPosition defaultPosition, params AstNode[] nodes)
		{
			return InsertWithCursor(operation, defaultPosition, (IList<AstNode>)nodes);
		}

		public Task<Script> InsertWithCursor(string operation, ITypeDefinition parentType, Func<Script, RefactoringContext, AstNode> nodeCallback)
		{
			return InsertWithCursor(operation, parentType, (Script s, RefactoringContext ctx) => new AstNode[1]
			{
				nodeCallback(s, ctx)
			});
		}

		protected virtual int GetIndentLevelAt(int offset)
		{
			return 0;
		}

		protected NodeOutput OutputNode(int indentLevel, AstNode node, bool startWithNewLine = false)
		{
			StringWriter stringWriter = new StringWriter();
			SegmentTrackingTokenWriter segmentTrackingTokenWriter = new SegmentTrackingTokenWriter(stringWriter)
			{
				Indentation = indentLevel,
				IndentationString = (Options.TabsToSpaces ? new string(' ', Options.IndentSize) : "\t")
			};
			stringWriter.NewLine = Options.EolMarker;
			if (startWithNewLine)
			{
				segmentTrackingTokenWriter.NewLine();
			}
			CSharpOutputVisitor visitor = new CSharpOutputVisitor(segmentTrackingTokenWriter, formattingOptions);
			node.AcceptVisitor(visitor);
			return new NodeOutput(stringWriter.ToString().TrimEnd(), segmentTrackingTokenWriter.NewSegments);
		}

		public virtual void Rename(ISymbol symbol, string name = null)
		{
		}

		public virtual void DoGlobalOperationOn(IEnumerable<IEntity> entities, Action<RefactoringContext, Script, IEnumerable<AstNode>> callback, string operationDescription = null)
		{
		}

		public virtual void Dispose()
		{
			FormatText(nodesToFormat);
		}

		public virtual void CreateNewType(AstNode newType, NewTypeContext context = NewTypeContext.CurrentNamespace)
		{
		}
	}
}
