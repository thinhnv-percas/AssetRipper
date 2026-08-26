using System;
using System.IO;

namespace ImageMagick;

internal sealed class Bytes
{
	private const int BufferSize = 8192;

	public byte[] Data { get; private set; }

	public int Length { get; private set; }

	public Bytes(Stream stream)
	{
		Throw.IfNull("stream", stream);
		SetData(stream);
	}

	private Bytes()
	{
	}

	public static Bytes FromStreamBuffer(Stream stream)
	{
		if (!(stream is MemoryStream dataWithMemoryStreamBuffer))
		{
			return null;
		}
		Bytes bytes = new Bytes();
		if (bytes.SetDataWithMemoryStreamBuffer(dataWithMemoryStreamBuffer))
		{
			return bytes;
		}
		return null;
	}

	private static void CheckLength(long length)
	{
		Throw.IfFalse("length", IsSupportedLength(length), "Streams with a length larger than 2147483591 are not supported, read from file instead.");
	}

	private static bool IsSupportedLength(long length)
	{
		return length <= int.MaxValue;
	}

	private void SetData(Stream stream)
	{
		if (stream is MemoryStream dataWithMemoryStream)
		{
			SetDataWithMemoryStream(dataWithMemoryStream);
			return;
		}
		Throw.IfFalse("stream", stream.CanRead, "The stream is not readable.");
		if (stream.CanSeek)
		{
			SetDataWithSeekableStream(stream);
			return;
		}
		byte[] buffer = new byte[8192];
		using MemoryStream memoryStream = new MemoryStream();
		int num;
		while ((num = stream.Read(buffer, 0, 8192)) != 0)
		{
			CheckLength(memoryStream.Length + num);
			memoryStream.Write(buffer, 0, num);
		}
		SetDataWithMemoryStream(memoryStream);
	}

	private void SetDataWithMemoryStream(MemoryStream memStream)
	{
		if (!SetDataWithMemoryStreamBuffer(memStream))
		{
			Data = memStream.ToArray();
			Length = Data.Length;
		}
	}

	private bool SetDataWithMemoryStreamBuffer(MemoryStream memStream)
	{
		if (!IsSupportedLength(memStream.Length))
		{
			return false;
		}
		try
		{
			Data = memStream.GetBuffer();
			Length = (int)memStream.Length;
			return true;
		}
		catch (UnauthorizedAccessException)
		{
		}
		return false;
	}

	private void SetDataWithSeekableStream(Stream stream)
	{
		CheckLength(stream.Length);
		Length = (int)stream.Length;
		Data = new byte[Length];
		int num = 0;
		int num2 = 0;
		while ((num2 = stream.Read(Data, num, Length - num)) != 0)
		{
			num += num2;
		}
	}
}
