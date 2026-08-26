using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class ReadOnlyInteropStream : Stream
{
	private readonly IStream _stream;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public unsafe override long Position
	{
		get
		{
			long result = default(long);
			_stream.Seek(0L, 1, (IntPtr)(&result));
			return result;
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public override long Length
	{
		get
		{
			_stream.Stat(out var pstatstg, 1);
			return pstatstg.cbSize;
		}
	}

	public ReadOnlyInteropStream(IStream stream)
	{
		_stream = stream;
	}

	public unsafe override int Read(byte[] buffer, int offset, int count)
	{
		int result = 0;
		_stream.Read(buffer, count, (IntPtr)(&result));
		return result;
	}

	public unsafe override long Seek(long offset, SeekOrigin origin)
	{
		long result = default(long);
		_stream.Seek(0L, (int)origin, (IntPtr)(&result));
		return result;
	}

	public override void Flush()
	{
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}
}
