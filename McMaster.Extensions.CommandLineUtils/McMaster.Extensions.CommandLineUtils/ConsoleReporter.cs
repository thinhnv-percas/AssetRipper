using System;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

public class ConsoleReporter : IReporter
{
	private object _writeLock = new object();

	protected IConsole Console { get; }

	public bool IsVerbose { get; set; }

	public bool IsQuiet { get; set; }

	public ConsoleReporter(IConsole console)
		: this(console, verbose: false, quiet: false)
	{
	}

	public ConsoleReporter(IConsole console, bool verbose, bool quiet)
	{
		Console = console ?? throw new ArgumentNullException("console");
		IsVerbose = verbose;
		IsQuiet = quiet;
	}

	protected virtual void WriteLine(TextWriter writer, string message, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor = null)
	{
		lock (_writeLock)
		{
			if (foregroundColor.HasValue)
			{
				Console.ForegroundColor = foregroundColor.Value;
			}
			if (backgroundColor.HasValue)
			{
				Console.BackgroundColor = backgroundColor.Value;
			}
			writer.WriteLine(message);
			if (foregroundColor.HasValue)
			{
				Console.ResetColor();
			}
		}
	}

	public virtual void Error(string message)
	{
		WriteLine(Console.Error, message, ConsoleColor.Red);
	}

	public virtual void Warn(string message)
	{
		WriteLine(Console.Out, message, ConsoleColor.Yellow);
	}

	public virtual void Output(string message)
	{
		if (!IsQuiet)
		{
			WriteLine(Console.Out, message, null);
		}
	}

	public virtual void Verbose(string message)
	{
		if (IsVerbose)
		{
			WriteLine(Console.Out, message, ConsoleColor.DarkGray);
		}
	}
}
