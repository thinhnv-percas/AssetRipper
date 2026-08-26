using System;

namespace Microsoft.DiaSymReader.PortablePdb;

internal struct BlobWriter
{
	private byte[] _buffer;

	private int _position;

	public BlobWriter(int initialCapacity = 16)
	{
		_buffer = new byte[initialCapacity];
		_position = 0;
	}

	private void EnsureCapacity(int size)
	{
		if (_position + size > _buffer.Length)
		{
			Array.Resize(ref _buffer, Math.Min(_position + size, _buffer.Length * 2 + 1));
		}
	}

	public void Write(byte value)
	{
		EnsureCapacity(1);
		_buffer[_position] = value;
		_position++;
	}

	public void Write(byte b1, byte b2)
	{
		EnsureCapacity(2);
		_buffer[_position] = b1;
		_buffer[_position + 1] = b2;
		_position += 2;
	}

	public void Write(byte b1, byte b2, byte b3, byte b4)
	{
		EnsureCapacity(4);
		_buffer[_position] = b1;
		_buffer[_position + 1] = b2;
		_buffer[_position + 2] = b3;
		_buffer[_position + 3] = b4;
		_position += 4;
	}

	internal void Write(byte[] buffer)
	{
		Write(buffer, 0, buffer.Length);
	}

	internal void Write(byte[] buffer, int index, int length)
	{
		EnsureCapacity(length);
		Buffer.BlockCopy(buffer, index, _buffer, _position, length);
		_position += length;
	}

	public void WriteCompressedInteger(int value)
	{
		if (value <= 127)
		{
			Write((byte)value);
		}
		else if (value <= 16383)
		{
			Write((byte)(0x80 | (value >> 8)), (byte)value);
		}
		else
		{
			Write((byte)(0xC0 | (value >> 24)), (byte)(value >> 16), (byte)(value >> 8), (byte)value);
		}
	}

	public byte[] ToArray()
	{
		byte[] array = _buffer;
		Array.Resize(ref array, _position);
		_buffer = null;
		_position = -1;
		return array;
	}
}
