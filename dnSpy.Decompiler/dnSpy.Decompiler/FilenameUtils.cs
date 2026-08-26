using System;
using System.Collections.Generic;
using System.IO;

namespace dnSpy.Decompiler;

public static class FilenameUtils
{
	private static readonly HashSet<string> ReservedFileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6",
		"COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7",
		"LPT8", "LPT9"
	};

	private static readonly HashSet<char> invalidFileNameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

	public static string CleanName(string text)
	{
		int num = text.IndexOf(':');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		num = text.IndexOf('`');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		text = text.Trim();
		char[] array = null;
		for (int i = 0; i < text.Length; i++)
		{
			if (invalidFileNameChars.Contains(text[i]))
			{
				if (array == null)
				{
					array = text.ToCharArray();
				}
				array[i] = '-';
			}
		}
		if (array != null)
		{
			text = new string(array);
		}
		if (ReservedFileNames.Contains(text))
		{
			text += "_";
		}
		return text;
	}

	internal static string GetRelativePath(string sourceDir, string destFile)
	{
		sourceDir = Path.GetFullPath(sourceDir);
		destFile = Path.GetFullPath(destFile);
		if (!Path.GetPathRoot(sourceDir).Equals(Path.GetPathRoot(destFile), StringComparison.OrdinalIgnoreCase))
		{
			return destFile;
		}
		List<string> pathNames = GetPathNames(sourceDir);
		List<string> pathNames2 = GetPathNames(Path.GetDirectoryName(destFile));
		string path = string.Empty;
		int i;
		for (i = 0; i < pathNames.Count && i < pathNames2.Count && pathNames[i].Equals(pathNames2[i], StringComparison.OrdinalIgnoreCase); i++)
		{
		}
		for (int j = i; j < pathNames.Count; j++)
		{
			path = Path.Combine(path, "..");
		}
		for (; i < pathNames2.Count; i++)
		{
			path = Path.Combine(path, pathNames2[i]);
		}
		return Path.Combine(path, Path.GetFileName(destFile));
	}

	private static List<string> GetPathNames(string path)
	{
		List<string> list = new List<string>();
		string pathRoot = Path.GetPathRoot(path);
		while (path != pathRoot)
		{
			list.Add(Path.GetFileName(path));
			path = Path.GetDirectoryName(path);
		}
		list.Add(pathRoot);
		list.Reverse();
		return list;
	}
}
