using System;
using System.IO;
using System.Text;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler;

public class TextOutputWriter : TextWriter
{
	private readonly IDecompilerOutput output;

	public override Encoding Encoding => Encoding.UTF8;

	public TextOutputWriter(IDecompilerOutput output)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		this.output = output;
	}

	public override void Write(string value)
	{
		output.Write(value, BoxedTextColor.Text);
	}

	public override void WriteLine()
	{
		output.WriteLine();
	}
}
