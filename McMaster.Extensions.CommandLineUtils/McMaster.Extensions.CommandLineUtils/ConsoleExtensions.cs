namespace McMaster.Extensions.CommandLineUtils;

public static class ConsoleExtensions
{
	public static IConsole WriteLine(this IConsole console)
	{
		console.Out.WriteLine();
		return console;
	}

	public static IConsole WriteLine(this IConsole console, string value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, string format, params object[] arg)
	{
		console.Out.WriteLine(format, arg);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, string format, object arg0)
	{
		console.Out.WriteLine(format, arg0);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, string format, object arg0, object arg1)
	{
		console.Out.WriteLine(format, arg0, arg1);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, string format, object arg0, object arg1, object arg2)
	{
		console.Out.WriteLine(format, arg0, arg1, arg2);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, ulong value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, bool value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, char value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, char[] buffer)
	{
		console.Out.WriteLine(buffer);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, char[] buffer, int index, int count)
	{
		console.Out.WriteLine(buffer, index, count);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, decimal value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, double value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, uint value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, int value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, object value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, float value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole WriteLine(this IConsole console, long value)
	{
		console.Out.WriteLine(value);
		return console;
	}

	public static IConsole Write(this IConsole console, string value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, string format, params object[] arg)
	{
		console.Out.Write(format, arg);
		return console;
	}

	public static IConsole Write(this IConsole console, string format, object arg0)
	{
		console.Out.Write(format, arg0);
		return console;
	}

	public static IConsole Write(this IConsole console, string format, object arg0, object arg1)
	{
		console.Out.Write(format, arg0, arg1);
		return console;
	}

	public static IConsole Write(this IConsole console, string format, object arg0, object arg1, object arg2)
	{
		console.Out.Write(format, arg0, arg1, arg2);
		return console;
	}

	public static IConsole Write(this IConsole console, uint value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, decimal value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, int value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, ulong value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, bool value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, char value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, char[] buffer)
	{
		console.Out.Write(buffer);
		return console;
	}

	public static IConsole Write(this IConsole console, char[] buffer, int index, int count)
	{
		console.Out.Write(buffer, index, count);
		return console;
	}

	public static IConsole Write(this IConsole console, double value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, long value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, object value)
	{
		console.Out.Write(value);
		return console;
	}

	public static IConsole Write(this IConsole console, float value)
	{
		console.Out.Write(value);
		return console;
	}
}
