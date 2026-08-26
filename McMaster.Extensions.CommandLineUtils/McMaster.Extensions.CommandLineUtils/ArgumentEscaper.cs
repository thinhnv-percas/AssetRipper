using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMaster.Extensions.CommandLineUtils;

public static class ArgumentEscaper
{
	public static string EscapeAndConcatenate(IEnumerable<string> args)
	{
		return string.Join(" ", args.Select(EscapeSingleArg));
	}

	private static string EscapeSingleArg(string arg)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = ContainsWhitespace(arg);
		bool flag2 = flag || IsSurroundedWithQuotes(arg);
		if (flag)
		{
			stringBuilder.Append('"');
		}
		for (int i = 0; i < arg.Length; i++)
		{
			int num = 0;
			for (; i < arg.Length && arg[i] == '\\'; i++)
			{
				num++;
			}
			if ((i == arg.Length) & flag2)
			{
				stringBuilder.Append('\\', 2 * num);
			}
			else if (i == arg.Length)
			{
				stringBuilder.Append('\\', num);
			}
			else if (arg[i] == '"')
			{
				stringBuilder.Append('\\', 2 * num + 1);
				stringBuilder.Append('"');
			}
			else
			{
				stringBuilder.Append('\\', num);
				stringBuilder.Append(arg[i]);
			}
		}
		if (flag)
		{
			stringBuilder.Append('"');
		}
		return stringBuilder.ToString();
	}

	private static bool IsSurroundedWithQuotes(string argument)
	{
		if (argument.Length <= 1)
		{
			return false;
		}
		if (argument[0] == '"')
		{
			return argument[argument.Length - 1] == '"';
		}
		return false;
	}

	private static bool ContainsWhitespace(string argument)
	{
		return argument.IndexOfAny(new char[3] { ' ', '\t', '\n' }) >= 0;
	}
}
