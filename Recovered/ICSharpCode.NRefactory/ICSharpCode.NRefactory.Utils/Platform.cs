using System;

namespace ICSharpCode.NRefactory.Utils
{
	public static class Platform
	{
		public static StringComparer FileNameComparer
		{
			get
			{
				PlatformID platform = Environment.OSVersion.Platform;
				if (platform == PlatformID.Unix || platform == PlatformID.MacOSX)
				{
					return StringComparer.Ordinal;
				}
				return StringComparer.OrdinalIgnoreCase;
			}
		}
	}
}
