using System;
using System.IO;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace dnSpy_Console;

internal sealed class ConsoleColorizerOutput : IDecompilerOutput
{
	private readonly ColorProvider colorProvider;

	private readonly TextWriter writer;

	private readonly Indenter indenter;

	private bool addIndent = true;

	private int position;

	private static readonly char[] newLineArray = Environment.NewLine.ToCharArray();

	public int Length => position;

	public int NextPosition => position + (addIndent ? indenter.String.Length : 0);

	bool IDecompilerOutput.UsesCustomData => false;

	public ConsoleColorizerOutput(TextWriter writer, ColorProvider colorProvider, Indenter indenter)
	{
		this.writer = writer ?? throw new ArgumentNullException("writer");
		this.colorProvider = colorProvider ?? throw new ArgumentNullException("colorProvider");
		this.indenter = indenter ?? throw new ArgumentNullException("indenter");
	}

	void IDecompilerOutput.AddCustomData<TData>(string id, TData data)
	{
	}

	public void IncreaseIndent()
	{
		indenter.IncreaseIndent();
	}

	public void DecreaseIndent()
	{
		indenter.DecreaseIndent();
	}

	public void WriteLine()
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
		ConsoleColorPair? color2 = colorProvider.GetColor(color as TextColor?);
		if (color2.HasValue)
		{
			if (color2.Value.Foreground.HasValue)
			{
				Console.ForegroundColor = color2.Value.Foreground.Value;
			}
			if (color2.Value.Background.HasValue)
			{
				Console.BackgroundColor = color2.Value.Background.Value;
			}
			writer.Write(text);
			Console.ResetColor();
		}
		else
		{
			writer.Write(text);
		}
		position += text.Length;
	}

	private void AddText(string text, int index, int length, object color)
	{
		if (index == 0 && length == text.Length)
		{
			AddText(text, color);
		}
		else
		{
			AddText(text.Substring(index, length), color);
		}
	}

	public void Write(string text, object color)
	{
		AddText(text, color);
	}

	public void Write(string text, int index, int length, object color)
	{
		AddText(text, index, length, color);
	}

	public void Write(string text, object reference, DecompilerReferenceFlags flags, object color)
	{
		AddText(text, color);
	}

	public void Write(string text, int index, int length, object reference, DecompilerReferenceFlags flags, object color)
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
