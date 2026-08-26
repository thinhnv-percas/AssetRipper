using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace McMaster.Extensions.CommandLineUtils;

internal class ResponseFileParser
{
	public static IList<string> Parse(string filePath, ResponseFileHandling handling)
	{
		return handling switch
		{
			ResponseFileHandling.Disabled => new string[1] { filePath }, 
			ResponseFileHandling.ParseArgsAsSpaceSeparated => ParseAsSpaceSeparated(filePath), 
			ResponseFileHandling.ParseArgsAsLineSeparated => ParseAsLineSeparated(filePath), 
			_ => throw new ArgumentOutOfRangeException("handling"), 
		};
	}

	private static IList<string> ParseAsLineSeparated(string filePath)
	{
		string[] array = File.ReadAllLines(filePath);
		int count = ((array.Length != 0 && array[array.Length - 1].Length == 0) ? (array.Length - 1) : array.Length);
		return (from l in array.Take(count)
			where l != null && (l.Length == 0 || l[0] != '#')
			select l).ToList();
	}

	private static IList<string> ParseAsSpaceSeparated(string filePath)
	{
		string[] array = File.ReadAllLines(filePath);
		List<string> list = new List<string>(array.Length);
		StringBuilder stringBuilder = new StringBuilder();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length == 0 || text[0] == '#')
			{
				continue;
			}
			char? c = null;
			bool flag = false;
			for (int j = 0; j < text.Length; j++)
			{
				char c2 = text[j];
				if (c2 == '\\')
				{
					j++;
					if (j >= text.Length)
					{
						stringBuilder.Append('\\');
						break;
					}
					c2 = text[j];
					if (c2 != '"' && c2 != '\'')
					{
						stringBuilder.Append('\\');
					}
					stringBuilder.Append(c2);
				}
				else if (c == c2)
				{
					flag = true;
					c = null;
				}
				else if (c.HasValue)
				{
					stringBuilder.Append(c2);
				}
				else if (char.IsWhiteSpace(c2))
				{
					if ((stringBuilder.Length > 0) | flag)
					{
						flag = false;
						list.Add(stringBuilder.ToString());
						stringBuilder.Clear();
					}
				}
				else
				{
					switch (c2)
					{
					case '"':
						c = '"';
						break;
					case '\'':
						c = '\'';
						break;
					default:
						stringBuilder.Append(c2);
						break;
					}
				}
			}
			if ((stringBuilder.Length > 0 || c.HasValue) | flag)
			{
				list.Add(stringBuilder.ToString());
				stringBuilder.Clear();
			}
		}
		return list;
	}
}
