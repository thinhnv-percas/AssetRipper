using System;
using System.IO;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public class TextWriterDecompilerOutput : IDecompilerOutput, IDisposable
{
	private readonly TextWriter writer;

	private readonly Indenter indenter;

	private bool addIndent = true;

	private int position;

	private static readonly char[] newLineArray = Environment.NewLine.ToCharArray();

	public virtual int Length => position;

	public virtual int NextPosition => position + (addIndent ? indenter.String.Length : 0);

	bool IDecompilerOutput.UsesCustomData => false;

	public TextWriterDecompilerOutput(TextWriter writer, Indenter indenter = null)
	{
		this.writer = writer ?? throw new ArgumentNullException("writer");
		this.indenter = indenter ?? new Indenter(4, 4, useTabs: true);
	}

	void IDecompilerOutput.AddCustomData<TData>(string id, TData data)
	{
	}

	public virtual void IncreaseIndent()
	{
		indenter.IncreaseIndent();
	}

	public virtual void DecreaseIndent()
	{
		indenter.DecreaseIndent();
	}

	public virtual void WriteLine()
	{
		char[] array = newLineArray;
		writer.Write(array);
		position += array.Length;
		addIndent = true;
	}

	private void AddIndent()
	{
		if (addIndent)
		{
			addIndent = false;
			string text = indenter.String;
			writer.Write(text);
			position += text.Length;
		}
	}

	private void AddText(string text, object color)
	{
		if (addIndent)
		{
			AddIndent();
		}
		writer.Write(text);
		position += text.Length;
	}

	private void AddText(string text, int index, int length, object color)
	{
		if (addIndent)
		{
			AddIndent();
		}
		if (index == 0 && length == text.Length)
		{
			writer.Write(text);
		}
		else
		{
			writer.Write(text.Substring(index, length));
		}
		position += length;
	}

	public virtual void Write(string text)
	{
		AddText(text, BoxedTextColor.Text);
	}

	public virtual void Write(string text, object color)
	{
		AddText(text, color);
	}

	public virtual void Write(string text, int index, int length, object color)
	{
		AddText(text, index, length, color);
	}

	public virtual void Write(string text, object reference, DecompilerReferenceFlags flags, object color)
	{
		AddText(text, color);
	}

	public virtual void Write(string text, int index, int length, object reference, DecompilerReferenceFlags flags, object color)
	{
		AddText(text, index, length, color);
	}

	public override string ToString()
	{
		return writer.ToString();
	}

	public void Dispose()
	{
		writer.Dispose();
	}
}
