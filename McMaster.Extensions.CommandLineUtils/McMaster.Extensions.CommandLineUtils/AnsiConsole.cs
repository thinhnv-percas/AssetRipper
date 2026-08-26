using System;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

internal class AnsiConsole
{
	private int _boldRecursion;

	private bool _useConsoleColor;

	public TextWriter Writer { get; }

	public ConsoleColor OriginalForegroundColor { get; }

	private AnsiConsole(TextWriter writer, bool useConsoleColor)
	{
		Writer = writer;
		_useConsoleColor = useConsoleColor;
		if (_useConsoleColor)
		{
			OriginalForegroundColor = Console.ForegroundColor;
		}
	}

	public static AnsiConsole GetOutput(bool useConsoleColor)
	{
		return new AnsiConsole(Console.Out, useConsoleColor);
	}

	public static AnsiConsole GetError(bool useConsoleColor)
	{
		return new AnsiConsole(Console.Error, useConsoleColor);
	}

	private void SetColor(ConsoleColor color)
	{
		Console.ForegroundColor = (Console.ForegroundColor & ConsoleColor.DarkGray) | (color & ConsoleColor.Gray);
	}

	private void SetBold(bool bold)
	{
		_boldRecursion += (bold ? 1 : (-1));
		if (_boldRecursion <= 1 && (_boldRecursion != 1 || bold))
		{
			Console.ForegroundColor ^= ConsoleColor.DarkGray;
		}
	}

	public void WriteLine(string message)
	{
		if (!_useConsoleColor)
		{
			Writer.WriteLine(message);
			return;
		}
		int num = 0;
		while (true)
		{
			int num2 = message.IndexOf("\u001b[", num);
			if (num2 == -1)
			{
				string value = message.Substring(num);
				Writer.Write(value);
				break;
			}
			int num3 = num2 + 2;
			int i;
			for (i = num3; i != message.Length && message[i] >= ' ' && message[i] <= '?'; i++)
			{
			}
			string value2 = message.Substring(num, num2 - num);
			Writer.Write(value2);
			if (i == message.Length)
			{
				break;
			}
			char c = message[i];
			if (c == 'm' && int.TryParse(message.Substring(num3, i - num3), out var result))
			{
				switch (result)
				{
				case 1:
					SetBold(bold: true);
					break;
				case 22:
					SetBold(bold: false);
					break;
				case 30:
					SetColor(ConsoleColor.Black);
					break;
				case 31:
					SetColor(ConsoleColor.Red);
					break;
				case 32:
					SetColor(ConsoleColor.Green);
					break;
				case 33:
					SetColor(ConsoleColor.Yellow);
					break;
				case 34:
					SetColor(ConsoleColor.Blue);
					break;
				case 35:
					SetColor(ConsoleColor.Magenta);
					break;
				case 36:
					SetColor(ConsoleColor.Cyan);
					break;
				case 37:
					SetColor(ConsoleColor.Gray);
					break;
				case 39:
					SetColor(OriginalForegroundColor);
					break;
				}
			}
			num = i + 1;
		}
		Writer.WriteLine();
	}
}
