using System.IO;

internal class CustomStream : Stream
{
	internal Stream stream;

	public override bool CanRead => stream.CanRead;

	public override bool CanSeek => stream.CanSeek;

	public override bool CanWrite => stream.CanWrite;

	public override long Length => stream.Length;

	public override long Position
	{
		get
		{
			return stream.Position;
		}
		set
		{
			stream.Position = value;
		}
	}

	internal CustomStream(Stream input)
	{
		Reset(input);
	}

	internal void Reset(Stream input)
	{
		stream = input;
	}

	public override void Close()
	{
	}

	public void CustomClose()
	{
		stream?.Close();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return stream.Read(buffer, offset, count);
	}

	public override void Flush()
	{
		stream.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return stream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		stream.SetLength(Length);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		stream.Write(buffer, offset, count);
	}

	protected override void Dispose(bool disposing)
	{
	}
}
