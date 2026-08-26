using System;
using System.Collections.Generic;
using dnSpy.Contracts.Text;

namespace dnSpy_Console;

internal sealed class ColorProvider
{
	private readonly Dictionary<TextColor, ConsoleColorPair> colors = new Dictionary<TextColor, ConsoleColorPair>();

	public void Add(TextColor color, ConsoleColor? foreground, ConsoleColor? background = null)
	{
		if (foreground.HasValue || background.HasValue)
		{
			colors[color] = new ConsoleColorPair(foreground, background);
		}
	}

	public ConsoleColorPair? GetColor(TextColor? color)
	{
		if (!color.HasValue)
		{
			return null;
		}
		ConsoleColorPair value;
		return colors.TryGetValue(color.Value, out value) ? new ConsoleColorPair?(value) : ((ConsoleColorPair?)null);
	}
}
