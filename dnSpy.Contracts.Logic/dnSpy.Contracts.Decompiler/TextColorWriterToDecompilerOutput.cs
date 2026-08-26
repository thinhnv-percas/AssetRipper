using System;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public sealed class TextColorWriterToDecompilerOutput : IDecompilerOutput
{
	private readonly ITextColorWriter output;

	private readonly Indenter indenter;

	private int offset;

	private bool addIndent = true;

	private static readonly char[] newLineChars = new char[5] { '\r', '\n', '\u0085', '\u2028', '\u2029' };

	int IDecompilerOutput.Length => offset;

	int IDecompilerOutput.NextPosition => offset + (addIndent ? indenter.String.Length : 0);

	bool IDecompilerOutput.UsesCustomData => false;

	public static IDecompilerOutput Create(ITextColorWriter output)
	{
		return new TextColorWriterToDecompilerOutput(output);
	}

	private TextColorWriterToDecompilerOutput(ITextColorWriter output)
	{
		this.output = output;
		indenter = new Indenter(4, 4, useTabs: true);
		offset = 0;
	}

	void IDecompilerOutput.AddCustomData<TData>(string id, TData data)
	{
	}

	void IDecompilerOutput.IncreaseIndent()
	{
		indenter.IncreaseIndent();
	}

	void IDecompilerOutput.DecreaseIndent()
	{
		indenter.DecreaseIndent();
	}

	void IDecompilerOutput.Write(string text, int index, int length, object color)
	{
		if (index == 0 && text.Length == length)
		{
			((IDecompilerOutput)this).Write(text, color);
		}
		else
		{
			((IDecompilerOutput)this).Write(text.Substring(index, length), color);
		}
	}

	void IDecompilerOutput.Write(string text, object color)
	{
		if (addIndent)
		{
			string text2 = indenter.String;
			if (text2.Length != 0)
			{
				output.Write(BoxedTextColor.Text, text2);
			}
			offset += text2.Length;
		}
		output.Write(color, text);
		offset += text.Length;
		addIndent = text.LastIndexOfAny(newLineChars) == text.Length - 1;
	}

	void IDecompilerOutput.Write(string text, object reference, DecompilerReferenceFlags flags, object color)
	{
		((IDecompilerOutput)this).Write(text, color);
	}

	void IDecompilerOutput.Write(string text, int index, int length, object reference, DecompilerReferenceFlags flags, object color)
	{
		((IDecompilerOutput)this).Write(text, index, length, color);
	}

	void IDecompilerOutput.WriteLine()
	{
		((IDecompilerOutput)this).Write(Environment.NewLine, BoxedTextColor.Text);
	}
}
