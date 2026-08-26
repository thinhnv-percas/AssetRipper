using System;
using System.IO;
using System.Text;

namespace DecompTools.Decompiler;

public class TextOutputWriter : TextWriter
{
	private readonly ITextOutput output;

	public override Encoding Encoding => Encoding.UTF8;

	public TextOutputWriter(ITextOutput output)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		this.output = output;
	}

	public override void Write(char value)
	{
		output.Write(value);
	}

	public override void Write(string value)
	{
		output.Write(value);
	}

	public override void WriteLine()
	{
		output.WriteLine();
	}
}
