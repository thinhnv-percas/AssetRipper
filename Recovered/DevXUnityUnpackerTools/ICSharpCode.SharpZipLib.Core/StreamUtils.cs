using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	public sealed class StreamUtils
	{
		public static void ReadFully(Stream stream, byte[] buffer)
		{
			ReadFully(stream, buffer, 0, buffer.Length);
		}

		public static void ReadFully(Stream stream, byte[] buffer, int offset, int count)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0 || offset > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			while (true)
			{
				if (count > 0)
				{
					int num = stream.Read(buffer, offset, count);
					if (num <= 0)
					{
						break;
					}
					offset += num;
					count -= num;
					continue;
				}
				return;
			}
			throw new EndOfStreamException();
		}

		public static void Copy(Stream source, Stream destination, byte[] buffer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (buffer.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}
			bool flag = true;
			while (flag)
			{
				int num = source.Read(buffer, 0, buffer.Length);
				if (num > 0)
				{
					destination.Write(buffer, 0, num);
					continue;
				}
				destination.Flush();
				flag = false;
			}
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(Stream _0020, Stream _0020_000A, byte[] _0020_0020, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020 _0020_000A_000A, TimeSpan _0020_000A_0020, object _0020_0020_000A, string _0020_0020_0020)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, _0020_0020_000A, _0020_0020_0020, -1L);
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(Stream _0020, Stream _0020_000A, byte[] _0020_0020, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020 _0020_000A_000A, TimeSpan _0020_000A_0020, object _0020_0020_000A, string _0020_0020_0020, long _0020_000A_000A_000A)
		{
			if (_0020 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (_0020_000A == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (_0020_0020 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (_0020_0020.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}
			if (_0020_000A_000A == null)
			{
				throw new ArgumentNullException("progressHandler");
			}
			bool flag = true;
			DateTime now = DateTime.Now;
			long num = 0L;
			long target = 0L;
			if (_0020_000A_000A_000A >= 0)
			{
				target = _0020_000A_000A_000A;
			}
			else if (_0020.CanSeek)
			{
				target = _0020.Length - _0020.Position;
			}
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 e = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(_0020_0020_0020, num, target);
			_0020_000A_000A(_0020_0020_000A, e);
			bool flag2 = true;
			while (flag)
			{
				int num2 = _0020.Read(_0020_0020, 0, _0020_0020.Length);
				if (num2 > 0)
				{
					num += num2;
					flag2 = false;
					_0020_000A.Write(_0020_0020, 0, num2);
				}
				else
				{
					_0020_000A.Flush();
					flag = false;
				}
				if (DateTime.Now - now > _0020_000A_0020)
				{
					flag2 = true;
					now = DateTime.Now;
					e = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(_0020_0020_0020, num, target);
					_0020_000A_000A(_0020_0020_000A, e);
					flag = e.ContinueRunning;
				}
			}
			if (!flag2)
			{
				e = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(_0020_0020_0020, num, target);
				_0020_000A_000A(_0020_0020_000A, e);
			}
		}

		internal StreamUtils()
		{
		}
	}
}
