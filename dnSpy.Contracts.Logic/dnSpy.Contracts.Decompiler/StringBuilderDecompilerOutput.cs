using System;
using System.Text;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public class StringBuilderDecompilerOutput : IDecompilerOutput
{
	private readonly StringBuilder sb;

	private readonly Indenter indenter;

	private bool addIndent = true;

	public virtual int Length => sb.Length;

	public virtual int NextPosition => sb.Length + (addIndent ? indenter.String.Length : 0);

	bool IDecompilerOutput.UsesCustomData => false;

	public StringBuilderDecompilerOutput()
	{
		sb = new StringBuilder();
		indenter = new Indenter(4, 4, useTabs: true);
	}

	public StringBuilderDecompilerOutput(Indenter indenter)
	{
		sb = new StringBuilder();
		this.indenter = indenter ?? throw new ArgumentNullException("indenter");
	}

	public StringBuilderDecompilerOutput(StringBuilder stringBuilder, Indenter indenter = null)
	{
		if (stringBuilder == null)
		{
			throw new ArgumentNullException("stringBuilder");
		}
		stringBuilder.Clear();
		sb = stringBuilder;
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
		sb.AppendLine();
		addIndent = true;
	}

	private void AddIndent()
	{
		if (addIndent)
		{
			addIndent = false;
			sb.Append(indenter.String);
		}
	}

	private void AddText(string text, object color)
	{
		if (addIndent)
		{
			AddIndent();
		}
		sb.Append(text);
	}

	private void AddText(string text, int index, int length, object color)
	{
		if (addIndent)
		{
			AddIndent();
		}
		sb.Append(text, index, length);
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
		if (addIndent)
		{
			AddIndent();
		}
		AddText(text, color);
	}

	public virtual void Write(string text, int index, int length, object reference, DecompilerReferenceFlags flags, object color)
	{
		if (addIndent)
		{
			AddIndent();
		}
		AddText(text, index, length, color);
	}

	public string GetText()
	{
		return sb.ToString();
	}

	public override string ToString()
	{
		return sb.ToString();
	}
}
