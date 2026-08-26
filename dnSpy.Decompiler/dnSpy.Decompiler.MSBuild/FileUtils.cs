using System.IO;

namespace dnSpy.Decompiler.MSBuild;

internal static class FileUtils
{
	private static readonly char[] dirSepChars = new char[2]
	{
		Path.DirectorySeparatorChar,
		Path.AltDirectorySeparatorChar
	};

	public static string GetFilename(string name)
	{
		int num = name.LastIndexOfAny(dirSepChars);
		if (num >= 0)
		{
			name = name.Substring(num + 1);
		}
		return name;
	}

	public static string GetExtension(string name)
	{
		int num = name.LastIndexOf('.');
		if (num < 0)
		{
			return string.Empty;
		}
		return name.Substring(num);
	}

	public static string GetFileNameWithoutExtension(string name)
	{
		int num = name.LastIndexOfAny(new char[2]
		{
			Path.DirectorySeparatorChar,
			Path.AltDirectorySeparatorChar
		});
		if (num >= 0)
		{
			name = name.Substring(num);
		}
		num = name.LastIndexOf('.');
		if (num < 0)
		{
			return name;
		}
		return name.Substring(0, num);
	}

	public static string RemoveExtension(string name)
	{
		int num = name.LastIndexOf('.');
		if (num < 0)
		{
			return name;
		}
		return name.Substring(0, num);
	}
}
