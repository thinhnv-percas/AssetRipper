using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.DiaSymReader;

internal sealed class ComStreamWrapper : IStream
{
	private readonly Stream _stream;

	internal ComStreamWrapper(Stream stream)
	{
		_stream = stream;
	}

	public void Commit(int grfCommitFlags)
	{
		_stream.Flush();
	}

	private static int TryReadAll(Stream stream, byte[] buffer, int offset, int count)
	{
		int num = 0;
		int i;
		for (i = 0; i < count; i += num)
		{
			num = stream.Read(buffer, offset + i, count - i);
			if (num == 0)
			{
				break;
			}
		}
		return i;
	}

	public unsafe void Read(byte[] pv, int cb, IntPtr pcbRead)
	{
		int num = TryReadAll(_stream, pv, 0, cb);
		if (pcbRead != IntPtr.Zero)
		{
			*(int*)(void*)pcbRead = num;
		}
	}

	public unsafe void Seek(long dlibMove, int origin, IntPtr plibNewPosition)
	{
		long num = _stream.Seek(dlibMove, (SeekOrigin)origin);
		if (plibNewPosition != IntPtr.Zero)
		{
			*(long*)(void*)plibNewPosition = num;
		}
	}

	public void SetSize(long libNewSize)
	{
		_stream.SetLength(libNewSize);
	}

	public void Stat(out STATSTG pstatstg, int grfStatFlag)
	{
		pstatstg = new STATSTG
		{
			cbSize = _stream.Length
		};
	}

	public unsafe void Write(byte[] pv, int cb, IntPtr pcbWritten)
	{
		_stream.Write(pv, 0, cb);
		if (pcbWritten != IntPtr.Zero)
		{
			*(int*)(void*)pcbWritten = cb;
		}
	}

	public void Clone(out IStream ppstm)
	{
		throw new NotSupportedException();
	}

	public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
	{
		throw new NotSupportedException();
	}

	public void LockRegion(long libOffset, long cb, int lockType)
	{
		throw new NotSupportedException();
	}

	public void Revert()
	{
		throw new NotSupportedException();
	}

	public void UnlockRegion(long libOffset, long cb, int lockType)
	{
		throw new NotSupportedException();
	}
}
