using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal sealed class StreamWrapper : IDisposable
{
	private const int BufferSize = 8192;

	private readonly byte[] _buffer;

	private unsafe readonly byte* _bufferStart;

	private readonly GCHandle _handle;

	private Stream _stream;

	private unsafe StreamWrapper(Stream stream)
	{
		_stream = stream;
		_buffer = new byte[8192];
		_handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
		_bufferStart = (byte*)_handle.AddrOfPinnedObject().ToPointer();
	}

	public static StreamWrapper CreateForReading(Stream stream)
	{
		Throw.IfFalse("stream", stream.CanRead, "The stream should be readable.");
		return new StreamWrapper(stream);
	}

	public static StreamWrapper CreateForWriting(Stream stream)
	{
		Throw.IfFalse("stream", stream.CanWrite, "The stream should be writeable.");
		return new StreamWrapper(stream);
	}

	public void Dispose()
	{
		if (_stream != null)
		{
			_handle.Free();
			_stream = null;
		}
	}

	public unsafe int Read(IntPtr data, UIntPtr count, IntPtr user_data)
	{
		int num = (int)(uint)count;
		if (num == 0)
		{
			return 0;
		}
		byte* p = (byte*)data.ToPointer();
		int num2 = 0;
		while (num > 0)
		{
			int count2 = Math.Min(num, 8192);
			try
			{
				count2 = _stream.Read(_buffer, 0, count2);
			}
			catch
			{
				return -1;
			}
			if (count2 == 0)
			{
				break;
			}
			num2 += count2;
			p = ReadBuffer(p, count2);
			num -= count2;
		}
		return num2;
	}

	public long Seek(long offset, IntPtr whence, IntPtr user_data)
	{
		try
		{
			return _stream.Seek(offset, (SeekOrigin)(int)whence);
		}
		catch
		{
			return -1L;
		}
	}

	public long Tell(IntPtr user_data)
	{
		return _stream.Position;
	}

	public unsafe int Write(IntPtr data, UIntPtr count, IntPtr user_data)
	{
		int num = (int)(uint)count;
		if (num == 0)
		{
			return 0;
		}
		byte* p = (byte*)data.ToPointer();
		while (num > 0)
		{
			int num2 = Math.Min(num, 8192);
			p = FillBuffer(p, num2);
			try
			{
				_stream.Write(_buffer, 0, num2);
			}
			catch
			{
				return -1;
			}
			num -= num2;
		}
		return (int)(uint)count;
	}

	private unsafe byte* FillBuffer(byte* p, int length)
	{
		byte* bufferStart = _bufferStart;
		while (length > 0)
		{
			*(bufferStart++) = *(p++);
			length--;
		}
		return p;
	}

	private unsafe byte* ReadBuffer(byte* p, int length)
	{
		byte* bufferStart = _bufferStart;
		while (length > 0)
		{
			*(p++) = *(bufferStart++);
			length--;
		}
		return p;
	}
}
