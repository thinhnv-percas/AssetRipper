using System;
using System.IO;

namespace ImageMagick;

public static class MagickAnyCPU
{
	private static string _cacheDirectory = Path.GetTempPath();

	public static string CacheDirectory
	{
		get
		{
			return _cacheDirectory;
		}
		set
		{
			if (!Directory.Exists(value))
			{
				throw new InvalidOperationException("The specified directory does not exist.");
			}
			_cacheDirectory = value;
		}
	}

	public static bool HasSharedCacheDirectory { get; set; }

	internal static bool UsesDefaultCacheDirectory => _cacheDirectory == Path.GetTempPath();
}
