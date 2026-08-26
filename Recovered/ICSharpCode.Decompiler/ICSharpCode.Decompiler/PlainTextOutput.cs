using ICSharpCode.NRefactory;
using System;
using System.IO;

namespace ICSharpCode.Decompiler
{
	public sealed class PlainTextOutput : ITextOutput
	{
		private readonly TextWriter writer;

		private int indent;

		private bool needsIndent;

		private int line = 1;

		private int column = 1;

		public TextLocation Location => new TextLocation(line, column + (needsIndent ? indent : 0));

		public PlainTextOutput(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
		}

		public PlainTextOutput()
		{
			writer = new StringWriter();
		}

		public override string ToString()
		{
			return writer.ToString();
		}

		public void Indent()
		{
			indent++;
		}

		public void Unindent()
		{
			indent--;
		}

		private void WriteIndent()
		{
			if (needsIndent)
			{
				needsIndent = false;
				for (int i = 0; i < indent; i++)
				{
					writer.Write('\t');
				}
				column += indent;
			}
		}

		public void Write(char ch)
		{
			WriteIndent();
			writer.Write(ch);
			column++;
		}

		public void Write(string text)
		{
			WriteIndent();
			writer.Write(text);
			column += text.Length;
		}

		public void WriteLine()
		{
			writer.WriteLine();
			needsIndent = true;
			line++;
			column = 1;
		}

		public void WriteDefinition(string text, object definition, bool isLocal)
		{
			Write(text);
		}

		public void WriteReference(string text, object reference, bool isLocal)
		{
			Write(text);
		}

		void ITextOutput.MarkFoldStart(string collapsedText, bool defaultCollapsed)
		{
		}

		void ITextOutput.MarkFoldEnd()
		{
		}

		void ITextOutput.AddDebugSymbols(MethodDebugSymbols methodDebugSymbols)
		{
		}
	}
}
