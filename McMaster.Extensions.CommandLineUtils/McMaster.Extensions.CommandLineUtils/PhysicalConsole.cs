using System;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

public class PhysicalConsole : IConsole
{
	public static IConsole Singleton { get; } = new PhysicalConsole();

	public TextWriter Error => Console.Error;

	public TextReader In => Console.In;

	public TextWriter Out => Console.Out;

	public bool IsInputRedirected => Console.IsInputRedirected;

	public bool IsOutputRedirected => Console.IsOutputRedirected;

	public bool IsErrorRedirected => Console.IsErrorRedirected;

	public ConsoleColor ForegroundColor
	{
		get
		{
			return Console.ForegroundColor;
		}
		set
		{
			Console.ForegroundColor = value;
		}
	}

	public ConsoleColor BackgroundColor
	{
		get
		{
			return Console.BackgroundColor;
		}
		set
		{
			Console.BackgroundColor = value;
		}
	}

	public event ConsoleCancelEventHandler CancelKeyPress
	{
		add
		{
			Console.CancelKeyPress += value;
		}
		remove
		{
			Console.CancelKeyPress -= value;
		}
	}

	public void ResetColor()
	{
		Console.ResetColor();
	}
}
