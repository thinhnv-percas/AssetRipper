using System;

namespace dnSpy_Console;

internal readonly struct ConsoleColorPair
{
	public ConsoleColor? Foreground { get; }

	public ConsoleColor? Background { get; }

	public ConsoleColorPair(ConsoleColor? foreground, ConsoleColor? background)
	{
		Foreground = foreground;
		Background = background;
	}
}
