using System;
using System.IO;

namespace Unity.IO.Compression
{
	public class GZipStream : Stream
	{
		private DeflateStream _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020;

		public override bool CanRead
		{
			get
			{
				if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
				{
					return false;
				}
				return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.CanRead;
			}
		}

		public override bool CanWrite
		{
			get
			{
				if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
				{
					return false;
				}
				return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.CanWrite;
			}
		}

		public override bool CanSeek
		{
			get
			{
				if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
				{
					return false;
				}
				return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.CanSeek;
			}
		}

		public override long Length
		{
			get
			{
				throw new NotSupportedException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Not supported"));
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Not supported"));
			}
			set
			{
				throw new NotSupportedException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Not supported"));
			}
		}

		public Stream BaseStream
		{
			get
			{
				if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 != null)
				{
					return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.BaseStream;
				}
				return null;
			}
		}

		public GZipStream(Stream stream, CompressionMode mode)
			: this(stream, mode, leaveOpen: false)
		{
		}

		public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 = new DeflateStream(stream, mode, leaveOpen);
			_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(mode);
		}

		private void _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(CompressionMode _0020)
		{
			if (_0020 == CompressionMode.Compress)
			{
				IFileFormatWriter _00202 = new _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A();
				_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020._0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A(_00202);
			}
			else
			{
				IFileFormatReader _00203 = new _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020();
				_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020._0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(_00203);
			}
		}

		public override void Flush()
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Not supported"));
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Not supported"));
		}

		public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new InvalidOperationException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.BeginRead(array, offset, count, asyncCallback, asyncState);
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new InvalidOperationException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.EndRead(asyncResult);
		}

		public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new InvalidOperationException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.BeginWrite(array, offset, count, asyncCallback, asyncState);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new InvalidOperationException(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.EndWrite(asyncResult);
		}

		public override int Read(byte[] array, int offset, int count)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			return _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.Read(array, offset, count);
		}

		public override void Write(byte[] array, int offset, int count)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 == null)
			{
				throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020("Object disposed"));
			}
			_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.Write(array, offset, count);
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 != null)
				{
					_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020.Dispose();
				}
				_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 = null;
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
	}
}
