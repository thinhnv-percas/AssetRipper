using ICSharpCode.NRefactory.Editor;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public sealed class NullIStateMachineIndentEngine : IStateMachineIndentEngine, IDocumentIndentEngine, ICloneable
	{
		private readonly IDocument document;

		private int offset;

		bool IStateMachineIndentEngine.IsInsidePreprocessorDirective => false;

		bool IStateMachineIndentEngine.IsInsidePreprocessorComment => false;

		bool IStateMachineIndentEngine.IsInsideStringLiteral => false;

		bool IStateMachineIndentEngine.IsInsideVerbatimString => false;

		bool IStateMachineIndentEngine.IsInsideCharacter => false;

		bool IStateMachineIndentEngine.IsInsideString => false;

		bool IStateMachineIndentEngine.IsInsideLineComment => false;

		bool IStateMachineIndentEngine.IsInsideMultiLineComment => false;

		bool IStateMachineIndentEngine.IsInsideDocLineComment => false;

		bool IStateMachineIndentEngine.IsInsideComment => false;

		bool IStateMachineIndentEngine.IsInsideOrdinaryComment => false;

		bool IStateMachineIndentEngine.IsInsideOrdinaryCommentOrString => false;

		bool IStateMachineIndentEngine.LineBeganInsideVerbatimString => false;

		bool IStateMachineIndentEngine.LineBeganInsideMultiLineComment => false;

		IDocument IDocumentIndentEngine.Document => document;

		string IDocumentIndentEngine.ThisLineIndent => "";

		string IDocumentIndentEngine.NextLineIndent => "";

		string IDocumentIndentEngine.CurrentIndent => "";

		bool IDocumentIndentEngine.NeedsReindent => false;

		int IDocumentIndentEngine.Offset => offset;

		TextLocation IDocumentIndentEngine.Location => TextLocation.Empty;

		public bool EnableCustomIndentLevels
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public NullIStateMachineIndentEngine(IDocument document)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			this.document = document;
		}

		public IStateMachineIndentEngine Clone()
		{
			return new NullIStateMachineIndentEngine(document)
			{
				offset = offset
			};
		}

		void IDocumentIndentEngine.Push(char ch)
		{
			offset++;
		}

		void IDocumentIndentEngine.Reset()
		{
			offset = 0;
		}

		void IDocumentIndentEngine.Update(int offset)
		{
			this.offset = offset;
		}

		IDocumentIndentEngine IDocumentIndentEngine.Clone()
		{
			return Clone();
		}

		object ICloneable.Clone()
		{
			return Clone();
		}
	}
}
