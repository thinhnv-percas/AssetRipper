using System;
using System.IO;

namespace Org.Brotli.Dec
{
	public class BrotliInputStream : Stream
	{
		public const int DefaultInternalBufferSize = 16384;

		internal byte[] _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A;

		internal int _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A;

		internal readonly _0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A();

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override bool CanWrite => false;

		public BrotliInputStream(Stream source)
			: this(source, 16384, null)
		{
		}

		public BrotliInputStream(Stream source, int byteReadBufferSize)
			: this(source, byteReadBufferSize, null)
		{
		}

		public BrotliInputStream(Stream source, int byteReadBufferSize, byte[] customDictionary)
		{
			if (byteReadBufferSize <= 0)
			{
				throw new ArgumentException("Bad buffer size:" + byteReadBufferSize);
			}
			if (source == null)
			{
				throw new ArgumentException("source is null");
			}
			_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A = new byte[byteReadBufferSize];
			_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020 = 0;
			_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A = 0;
			try
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A, source);
			}
			catch (BrotliRuntimeException innerException)
			{
				throw new IOException("Brotli decoder initialization failed", innerException);
			}
			if (customDictionary != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A, customDictionary);
			}
		}

		public override void Close()
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A);
		}

		public override int ReadByte()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A >= _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020)
			{
				_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020 = Read(_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A, 0, _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Length);
				_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A = 0;
				if (_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020 == -1)
				{
					return -1;
				}
			}
			return _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A++] & 0xFF;
		}

		public override int Read(byte[] destBuffer, int destOffset, int destLen)
		{
			if (destOffset < 0)
			{
				throw new ArgumentException("Bad offset: " + destOffset);
			}
			if (destLen < 0)
			{
				throw new ArgumentException("Bad length: " + destLen);
			}
			if (destOffset + destLen > destBuffer.Length)
			{
				throw new ArgumentException("Buffer overflow: " + (destOffset + destLen) + " > " + destBuffer.Length);
			}
			if (destLen == 0)
			{
				return 0;
			}
			int num = Math.Max(_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020 - _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A, 0);
			if (num != 0)
			{
				num = Math.Min(num, destLen);
				Array.Copy(_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A, _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A, destBuffer, destOffset, num);
				_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A += num;
				destOffset += num;
				destLen -= num;
				if (destLen == 0)
				{
					return num;
				}
			}
			try
			{
				_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A = destBuffer;
				_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020 = destOffset;
				_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A = destLen;
				_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020 = 0;
				_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A(_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A);
				if (_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020 == 0)
				{
					return -1;
				}
				return _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020 + num;
			}
			catch (BrotliRuntimeException innerException)
			{
				throw new IOException("Brotli stream decoding failed", innerException);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override void Flush()
		{
		}
	}
}
