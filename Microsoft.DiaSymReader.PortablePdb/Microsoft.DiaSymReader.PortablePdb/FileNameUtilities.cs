namespace Microsoft.DiaSymReader.PortablePdb;

internal static class FileNameUtilities
{
	private const string DirectorySeparatorStr = "\\";

	private const char DirectorySeparatorChar = '\\';

	private const char AltDirectorySeparatorChar = '/';

	private const char VolumeSeparatorChar = ':';

	internal static int IndexOfFileName(string path)
	{
		if (path == null)
		{
			return -1;
		}
		for (int num = path.Length - 1; num >= 0; num--)
		{
			char c = path[num];
			if (c == '\\' || c == '/' || c == ':')
			{
				return num + 1;
			}
		}
		return 0;
	}

	internal static bool IsDirectorySeparator(char separator)
	{
		if (separator != '\\')
		{
			return separator == '/';
		}
		return true;
	}

	internal static string GetFileName(string path)
	{
		int num = IndexOfFileName(path);
		if (num > 0)
		{
			return path.Substring(num);
		}
		return path;
	}
}
