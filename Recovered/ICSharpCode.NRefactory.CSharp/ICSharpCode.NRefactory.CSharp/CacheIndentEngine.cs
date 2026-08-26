using ICSharpCode.NRefactory.Editor;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CacheIndentEngine : IStateMachineIndentEngine, IDocumentIndentEngine, ICloneable
	{
		private IStateMachineIndentEngine currentEngine;

		private Stack<IStateMachineIndentEngine> cachedEngines = new Stack<IStateMachineIndentEngine>();

		public IDocument Document => currentEngine.Document;

		public string ThisLineIndent => currentEngine.ThisLineIndent;

		public string NextLineIndent => currentEngine.NextLineIndent;

		public string CurrentIndent => currentEngine.CurrentIndent;

		public bool NeedsReindent => currentEngine.NeedsReindent;

		public int Offset => currentEngine.Offset;

		public TextLocation Location => currentEngine.Location;

		public bool EnableCustomIndentLevels
		{
			get
			{
				return currentEngine.EnableCustomIndentLevels;
			}
			set
			{
				currentEngine.EnableCustomIndentLevels = value;
			}
		}

		public bool IsInsidePreprocessorDirective => currentEngine.IsInsidePreprocessorDirective;

		public bool IsInsidePreprocessorComment => currentEngine.IsInsidePreprocessorComment;

		public bool IsInsideStringLiteral => currentEngine.IsInsideStringLiteral;

		public bool IsInsideVerbatimString => currentEngine.IsInsideVerbatimString;

		public bool IsInsideCharacter => currentEngine.IsInsideCharacter;

		public bool IsInsideString => currentEngine.IsInsideString;

		public bool IsInsideLineComment => currentEngine.IsInsideLineComment;

		public bool IsInsideMultiLineComment => currentEngine.IsInsideMultiLineComment;

		public bool IsInsideDocLineComment => currentEngine.IsInsideDocLineComment;

		public bool IsInsideComment => currentEngine.IsInsideComment;

		public bool IsInsideOrdinaryComment => currentEngine.IsInsideOrdinaryComment;

		public bool IsInsideOrdinaryCommentOrString => currentEngine.IsInsideOrdinaryCommentOrString;

		public bool LineBeganInsideVerbatimString => currentEngine.LineBeganInsideVerbatimString;

		public bool LineBeganInsideMultiLineComment => currentEngine.LineBeganInsideMultiLineComment;

		public CacheIndentEngine(IStateMachineIndentEngine decoratedEngine, int cacheRate = 2000)
		{
			currentEngine = decoratedEngine;
		}

		public CacheIndentEngine(CacheIndentEngine prototype)
		{
			currentEngine = prototype.currentEngine.Clone();
		}

		public void Push(char ch)
		{
			currentEngine.Push(ch);
		}

		public void Reset()
		{
			currentEngine.Reset();
			cachedEngines.Clear();
		}

		public void ResetEngineToPosition(int offset)
		{
			if (currentEngine.Offset <= offset)
			{
				return;
			}
			bool flag = false;
			while (cachedEngines.Count > 0)
			{
				IStateMachineIndentEngine stateMachineIndentEngine = cachedEngines.Peek();
				if (stateMachineIndentEngine.Offset <= offset)
				{
					currentEngine = stateMachineIndentEngine.Clone();
					flag = true;
					break;
				}
				cachedEngines.Pop();
			}
			if (!flag)
			{
				currentEngine.Reset();
			}
		}

		public void Update(int position)
		{
			if (currentEngine.Offset == position)
			{
				return;
			}
			if (currentEngine.Offset > position)
			{
				ResetEngineToPosition(position);
			}
			int num = (cachedEngines.Count == 0) ? 2000 : (cachedEngines.Peek().Offset + 2000);
			if (currentEngine.Offset + 1 == position)
			{
				char charAt = currentEngine.Document.GetCharAt(currentEngine.Offset);
				currentEngine.Push(charAt);
				if (currentEngine.Offset == num)
				{
					cachedEngines.Push(currentEngine.Clone());
				}
				return;
			}
			while (currentEngine.Offset < position)
			{
				int num2 = currentEngine.Offset + 2000;
				if (num2 > position)
				{
					num2 = position;
				}
				string text = currentEngine.Document.GetText(currentEngine.Offset, num2 - currentEngine.Offset);
				foreach (char ch in text)
				{
					currentEngine.Push(ch);
					if (currentEngine.Offset == num)
					{
						cachedEngines.Push(currentEngine.Clone());
						num += 2000;
					}
				}
			}
		}

		public IStateMachineIndentEngine GetEngine(int offset)
		{
			ResetEngineToPosition(offset);
			return currentEngine;
		}

		public IStateMachineIndentEngine Clone()
		{
			return new CacheIndentEngine(this);
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
