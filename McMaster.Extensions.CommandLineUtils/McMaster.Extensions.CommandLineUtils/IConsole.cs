using System;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

public interface IConsole
{
	TextWriter Out { get; }

	TextWriter Error { get; }

	TextReader In { get; }

	bool IsInputRedirected { get; }

	bool IsOutputRedirected { get; }

	bool IsErrorRedirected { get; }

	ConsoleColor ForegroundColor { get; set; }

	ConsoleColor BackgroundColor { get; set; }

	event ConsoleCancelEventHandler CancelKeyPress;

	void ResetColor();
}
