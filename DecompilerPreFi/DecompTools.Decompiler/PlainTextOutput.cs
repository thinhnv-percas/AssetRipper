using System;
using System.IO;
using System.Reflection.Metadata;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler;

public sealed class PlainTextOutput : ITextOutput
{
	private readonly TextWriter writer;

	private int indent;

	private bool needsIndent;

	private int line = 1;

	private int column = 1;

	public TextLocation Location => new TextLocation(line, checked(column + (needsIndent ? indent : 0)));

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
		checked
		{
			indent++;
		}
	}

	public void Unindent()
	{
		checked
		{
			indent--;
		}
	}

	private void WriteIndent()
	{
		checked
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
	}

	public void Write(char ch)
	{
		WriteIndent();
		writer.Write(ch);
		checked
		{
			column++;
		}
	}

	public void Write(string text)
	{
		WriteIndent();
		writer.Write(text);
		checked
		{
			column += text.Length;
		}
	}

	public void WriteLine()
	{
		writer.WriteLine();
		needsIndent = true;
		checked
		{
			line++;
			column = 1;
		}
	}

	public void WriteReference(OpCodeInfo opCode)
	{
		Write(opCode.Name);
	}

	public void WriteReference(PEFile module, EntityHandle handle, string text, bool isDefinition = false)
	{
		Write(text);
	}

	public void WriteReference(IType type, string text, bool isDefinition = false)
	{
		Write(text);
	}

	public void WriteReference(IMember member, string text, bool isDefinition = false)
	{
		Write(text);
	}

	public void WriteLocalReference(string text, object reference, bool isDefinition = false)
	{
		Write(text);
	}

	void ITextOutput.MarkFoldStart(string collapsedText, bool defaultCollapsed)
	{
	}

	void ITextOutput.MarkFoldEnd()
	{
	}
}
