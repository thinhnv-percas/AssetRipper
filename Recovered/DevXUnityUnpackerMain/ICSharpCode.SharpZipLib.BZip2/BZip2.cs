using ICSharpCode.SharpZipLib.Core;
using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.BZip2
{
	public class BZip2
	{
		public static void Decompress(Stream inStream, Stream outStream, bool isStreamOwner)
		{
			if (inStream == null || outStream == null)
			{
				throw new Exception(_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020._0020_0020_000A_0020_0020_0020_0020_000A_0020_0020);
			}
			try
			{
				using (_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A _0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A = new _0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A(inStream))
				{
					_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.IsStreamOwner = isStreamOwner;
					StreamUtils.Copy(_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A, outStream, new byte[4096]);
				}
			}
			finally
			{
				if (isStreamOwner)
				{
					outStream.Close();
				}
			}
		}

		public static void Compress(Stream inStream, Stream outStream, bool isStreamOwner, int level)
		{
			if (inStream == null || outStream == null)
			{
				throw new Exception(_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020._0020_0020_000A_0020_0020_0020_0020_000A_0020_0020);
			}
			try
			{
				using (_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A _0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A = new _0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A(outStream, level))
				{
					_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A.IsStreamOwner = isStreamOwner;
					StreamUtils.Copy(inStream, _0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A, new byte[4096]);
				}
			}
			finally
			{
				if (isStreamOwner)
				{
					inStream.Close();
				}
			}
		}
	}
}
