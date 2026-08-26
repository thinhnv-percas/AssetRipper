using System;
using System.IO;
using System.Text;

namespace McMaster.Extensions.CommandLineUtils;

public class NullConsole : IConsole
{
	private sealed class NullTextWriter : TextWriter
	{
		public override Encoding Encoding => Encoding.Unicode;

		public override void Write(char value)
		{
		}
	}

	public static NullConsole Singleton { get; } = new NullConsole();

	public TextWriter Out { get; }

	public TextWriter Error { get; }

	public TextReader In { get; } = new StringReader(string.Empty);

	public bool IsInputRedirected => false;

	public bool IsOutputRedirected => false;

	public bool IsErrorRedirected => false;

	public ConsoleColor ForegroundColor { get; set; }

	public ConsoleColor BackgroundColor { get; set; }

	public event ConsoleCancelEventHandler CancelKeyPress
	{
		add
		{
		}
		remove
		{
		}
	}

	private NullConsole()
	{
		Error = (Out = new NullTextWriter());
	}

	public void ResetColor()
	{
	}
}
