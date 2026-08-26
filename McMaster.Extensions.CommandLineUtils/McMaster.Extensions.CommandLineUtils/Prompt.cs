using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace McMaster.Extensions.CommandLineUtils;

public static class Prompt
{
	private class CursorState : IDisposable
	{
		private readonly bool _original;

		public CursorState()
		{
			try
			{
				_original = Console.CursorVisible;
			}
			catch
			{
				_original = true;
			}
			TrySetVisible(visible: true);
		}

		private void TrySetVisible(bool visible)
		{
			try
			{
				Console.CursorVisible = visible;
			}
			catch
			{
			}
		}

		public void Dispose()
		{
			TrySetVisible(_original);
		}
	}

	private const char Backspace = '\b';

	public static bool GetYesNo(string prompt, bool defaultAnswer, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
	{
		string text = (defaultAnswer ? "[Y/n]" : "[y/N]");
		while (true)
		{
			Write(prompt + " " + text, promptColor, promptBgColor);
			Console.Write(' ');
			string text2;
			using (ShowCursor())
			{
				text2 = Console.ReadLine()?.ToLower()?.Trim();
			}
			if (string.IsNullOrEmpty(text2))
			{
				break;
			}
			switch (text2)
			{
			case "n":
			case "no":
				return false;
			case "y":
			case "yes":
				return true;
			}
			Console.WriteLine("Invalid response '" + text2 + "'. Please answer 'y' or 'n' or CTRL+C to exit.");
		}
		return defaultAnswer;
	}

	public static string GetString(string prompt, string defaultValue = null, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
	{
		if (defaultValue != null)
		{
			prompt = prompt + " [" + defaultValue + "]";
		}
		Write(prompt, promptColor, promptBgColor);
		Console.Write(' ');
		string text;
		using (ShowCursor())
		{
			text = Console.ReadLine();
		}
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		return defaultValue;
	}

	public static string GetPassword(string prompt, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char item in ReadObfuscatedLine(prompt, promptColor, promptBgColor))
		{
			if (item == '\b')
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			else
			{
				stringBuilder.Append(item);
			}
		}
		return stringBuilder.ToString();
	}

	public static SecureString GetPasswordAsSecureString(string prompt, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
	{
		SecureString secureString = new SecureString();
		foreach (char item in ReadObfuscatedLine(prompt, promptColor, promptBgColor))
		{
			if (item == '\b')
			{
				secureString.RemoveAt(secureString.Length - 1);
			}
			else
			{
				secureString.AppendChar(item);
			}
		}
		secureString.MakeReadOnly();
		return secureString;
	}

	private static IEnumerable<char> ReadObfuscatedLine(string prompt, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
	{
		Write(prompt, promptColor, promptBgColor);
		Console.Write(' ');
		int readChars = 0;
		ConsoleKeyInfo key;
		do
		{
			using (ShowCursor())
			{
				key = Console.ReadKey(intercept: true);
			}
			if ((key.Modifiers & (ConsoleModifiers.Alt | ConsoleModifiers.Control)) != 0)
			{
				continue;
			}
			switch (key.Key)
			{
			case ConsoleKey.Enter:
				Console.WriteLine();
				break;
			case ConsoleKey.Backspace:
				if (readChars > 0)
				{
					Console.Write("\b \b");
					int num = readChars - 1;
					readChars = num;
					yield return '\b';
				}
				break;
			case ConsoleKey.Escape:
				while (readChars > 0)
				{
					Console.Write("\b \b");
					yield return '\b';
					int num = readChars - 1;
					readChars = num;
				}
				break;
			default:
				readChars++;
				Console.Write('*');
				yield return key.KeyChar;
				break;
			}
		}
		while (key.Key != ConsoleKey.Enter);
	}

	public static int GetInt(string prompt, int? defaultAnswer = null, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
	{
		int result;
		while (true)
		{
			Write(prompt, promptColor, promptBgColor);
			if (defaultAnswer.HasValue)
			{
				Write($" [{defaultAnswer.Value}]", promptColor, promptBgColor);
			}
			Console.Write(' ');
			string text;
			using (ShowCursor())
			{
				text = Console.ReadLine()?.ToLower()?.Trim();
			}
			if (string.IsNullOrEmpty(text))
			{
				if (defaultAnswer.HasValue)
				{
					return defaultAnswer.Value;
				}
				Console.WriteLine("Please enter a valid number or press CTRL+C to exit.");
			}
			else
			{
				if (int.TryParse(text, out result))
				{
					break;
				}
				Console.WriteLine("Invalid number '" + text + "'. Please enter a valid number or press CTRL+C to exit.");
			}
		}
		return result;
	}

	private static void Write(string value, ConsoleColor? foreground, ConsoleColor? background)
	{
		if (foreground.HasValue)
		{
			Console.ForegroundColor = foreground.Value;
		}
		if (background.HasValue)
		{
			Console.BackgroundColor = background.Value;
		}
		Console.Write(value);
		if (foreground.HasValue || background.HasValue)
		{
			Console.ResetColor();
		}
	}

	private static IDisposable ShowCursor()
	{
		return new CursorState();
	}
}
