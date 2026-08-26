using System;
using System.IO;

namespace ImageMagick;

internal static class FileHelper
{
	public static string CheckForBaseDirectory(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return fileName;
		}
		if (fileName.Length < 2 || fileName[0] != '~')
		{
			return fileName;
		}
		return AppDomain.CurrentDomain.BaseDirectory + fileName.Substring(1);
	}

	public static string GetFullPath(string path)
	{
		Throw.IfNullOrEmpty("path", path);
		path = CheckForBaseDirectory(path);
		path = Path.GetFullPath(path);
		Throw.IfFalse("path", Directory.Exists(path), "Unable to find directory: {0}", path);
		return path;
	}
}
