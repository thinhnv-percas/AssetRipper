using System;
using System.IO;
using Unity.IO.Compression;

namespace @as
{
	public class StrSthData
	{
		internal int _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A;

		internal byte[] _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020;

		internal StrSth _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;

		internal StrSth toStrSth
		{
			get
			{
				if (_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A != null)
				{
					return _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;
				}
				if (_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020 != null)
				{
					lock (this)
					{
						if (_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A != null)
						{
							return _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;
						}
						StrSth strSth = new StrSth(0);
						using (MemoryStream stream = new MemoryStream(_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020))
						{
							using (GZipStream _0020 = new GZipStream(stream, CompressionMode.Decompress))
							{
								if (_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A == 0)
								{
									strSth.SthToStream(_0020);
								}
								if (_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A == 1)
								{
									strSth.Copy(_0020);
								}
							}
						}
						_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A = strSth;
						_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020 = null;
					}
				}
				GC.Collect();
				return _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;
			}
		}

		internal StrSthData(byte[] raw_buff)
		{
			_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A = 0;
			if (raw_buff != null)
			{
				if (raw_buff[0] == 68 && raw_buff[1] == 86 && raw_buff[2] == 88 && raw_buff[3] == 84 && raw_buff[4] == 82 && raw_buff[5] == 49)
				{
					_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A = 1;
				}
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
					{
						gZipStream.Write(raw_buff, 0, raw_buff.Length);
					}
					_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020 = memoryStream.ToArray();
				}
			}
		}
	}
}
