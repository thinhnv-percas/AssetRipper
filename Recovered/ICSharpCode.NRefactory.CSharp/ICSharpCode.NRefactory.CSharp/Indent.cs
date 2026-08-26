using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class Indent
	{
		private readonly CloneableStack<IndentType> indentStack = new CloneableStack<IndentType>();

		private readonly TextEditorOptions options;

		private int curIndent;

		private int extraSpaces;

		private string indentString;

		public int CurIndent => curIndent;

		public int Count => indentStack.Count;

		public int ExtraSpaces
		{
			get
			{
				return extraSpaces;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("ExtraSpaces >= 0 but was " + value);
				}
				extraSpaces = value;
				Update();
			}
		}

		public string IndentString => indentString;

		public Indent(TextEditorOptions options)
		{
			this.options = options;
			Reset();
		}

		private Indent(Indent engine)
		{
			indentStack = engine.indentStack.Clone();
			options = engine.options;
			curIndent = engine.curIndent;
			extraSpaces = engine.extraSpaces;
			indentString = engine.indentString;
		}

		public Indent Clone()
		{
			return new Indent(this);
		}

		public void Reset()
		{
			curIndent = 0;
			indentString = "";
			indentStack.Clear();
		}

		public void Push(IndentType type)
		{
			indentStack.Push(type);
			curIndent += GetIndent(type);
			Update();
		}

		public void Push(Indent indent)
		{
			foreach (IndentType item in indent.indentStack)
			{
				Push(item);
			}
		}

		public void Pop()
		{
			curIndent -= GetIndent(indentStack.Pop());
			Update();
		}

		public bool PopIf(IndentType type)
		{
			if (Count > 0 && Peek() == type)
			{
				Pop();
				return true;
			}
			return false;
		}

		public void PopWhile(IndentType type)
		{
			while (Count > 0 && Peek() == type)
			{
				Pop();
			}
		}

		public bool PopTry()
		{
			if (Count > 0)
			{
				Pop();
				return true;
			}
			return false;
		}

		public IndentType Peek()
		{
			return indentStack.Peek();
		}

		private int GetIndent(IndentType indentType)
		{
			switch (indentType)
			{
			case IndentType.Block:
				return options.IndentSize;
			case IndentType.DoubleBlock:
				return options.IndentSize * 2;
			case IndentType.Continuation:
			case IndentType.Alignment:
				return options.ContinuationIndent;
			case IndentType.Label:
				return options.LabelIndent;
			case IndentType.Empty:
				return 0;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void Update()
		{
			if (options.TabsToSpaces)
			{
				indentString = new string(' ', curIndent + ExtraSpaces);
			}
			else
			{
				indentString = new string('\t', curIndent / options.TabSize) + new string(' ', curIndent % options.TabSize) + new string(' ', ExtraSpaces);
			}
		}

		public override string ToString()
		{
			return $"[Indent: curIndent={curIndent}]";
		}

		public Indent GetIndentWithoutSpace()
		{
			Indent indent = new Indent(options);
			foreach (IndentType item in indentStack)
			{
				indent.Push(item);
			}
			return indent;
		}

		public static Indent ConvertFrom(string indentString, Indent correctIndent, TextEditorOptions options = null)
		{
			options = (options ?? TextEditorOptions.Default);
			Indent indent = new Indent(options);
			string source = string.Concat(from c in indentString
				where (c != ' ') ? (c == '\t') : true
				select c);
			Stack<IndentType> stack = new Stack<IndentType>(correctIndent.indentStack);
			foreach (char item in source.TakeWhile((char c) => c == '\t'))
			{
				char c = item;
				if (stack.Count > 0)
				{
					indent.Push(stack.Pop());
				}
				else
				{
					indent.Push(IndentType.Continuation);
				}
			}
			indent.ExtraSpaces = source.SkipWhile((char c) => c == '\t').TakeWhile((char c) => c == ' ').Count();
			return indent;
		}

		public void RemoveAlignment()
		{
			ExtraSpaces = 0;
			if (Count > 0 && Peek() == IndentType.Alignment)
			{
				Pop();
			}
		}

		public void SetAlignment(int i, bool forceSpaces = false)
		{
			int num = Math.Max(0, i);
			if (forceSpaces)
			{
				ExtraSpaces = num;
				return;
			}
			RemoveAlignment();
			Push(IndentType.Alignment);
		}
	}
}
