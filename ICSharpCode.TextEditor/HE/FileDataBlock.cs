using System;

namespace HE;

internal sealed class FileDataBlock : DataBlock
{
	private long _length;

	private long _fileOffset;

	internal long FileOffset => _fileOffset;

	internal override long Length => _length;

	internal FileDataBlock(long fileOffset, long length)
	{
		_fileOffset = fileOffset;
		_length = length;
	}

	internal void SetFileOffset(long value)
	{
		_fileOffset = value;
	}

	internal void RemoveBytesFromEnd(long count)
	{
		if (count > _length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		_length -= count;
	}

	internal void RemoveBytesFromStart(long count)
	{
		if (count > _length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		_fileOffset += count;
		_length -= count;
	}

	internal override void RemoveBytes(long position, long count)
	{
		if (position > _length)
		{
			throw new ArgumentOutOfRangeException("position");
		}
		if (position + count > _length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		long fileOffset = _fileOffset;
		long num = _length - count - position;
		long fileOffset2 = _fileOffset + position + count;
		if (position > 0 && num > 0)
		{
			_fileOffset = fileOffset;
			_length = position;
			_map.AddAfter(this, new FileDataBlock(fileOffset2, num));
		}
		else if (position > 0)
		{
			_fileOffset = fileOffset;
			_length = position;
		}
		else
		{
			_fileOffset = fileOffset2;
			_length = num;
		}
	}
}
