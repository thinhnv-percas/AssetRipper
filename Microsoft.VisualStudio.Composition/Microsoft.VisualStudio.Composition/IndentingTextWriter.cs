using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.VisualStudio.Composition;

internal class IndentingTextWriter : TextWriter
{
	internal struct CancelIndent : IDisposable
	{
		private readonly IndentingTextWriter writer;

		internal CancelIndent(IndentingTextWriter writer)
		{
			Requires.NotNull(writer, "writer");
			this.writer = writer;
		}

		public void Dispose()
		{
			if (writer != null)
			{
				writer.Unindent();
			}
		}
	}

	private const string Indentation = "    ";

	private readonly TextWriter inner;

	private readonly Stack<string> indentationStack = new Stack<string>();

	public override Encoding Encoding => inner.Encoding;

	internal IndentingTextWriter(TextWriter inner)
	{
		Requires.NotNull(inner, "inner");
		this.inner = inner;
	}

	internal static IndentingTextWriter Get(TextWriter writer)
	{
		Requires.NotNull(writer, "writer");
		return (writer as IndentingTextWriter) ?? new IndentingTextWriter(writer);
	}

	public override void WriteLine(string value)
	{
		foreach (string item in indentationStack)
		{
			inner.Write(item);
		}
		inner.WriteLine(value);
	}

	public override void Write(char value)
	{
		inner.Write(value);
	}

	internal CancelIndent Indent()
	{
		indentationStack.Push("    ");
		return new CancelIndent(this);
	}

	private void Unindent()
	{
		indentationStack.Pop();
	}
}
