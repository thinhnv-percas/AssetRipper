using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

internal sealed class DeflateManagedStream : Stream
{
	internal const int DefaultBufferSize = 8192;

	private Stream _stream;

	private CompressionMode _mode;

	private bool _leaveOpen;

	private InflaterManaged _inflater;

	private System.IO.Compression.DeflaterManaged _deflater;

	private byte[] _buffer;

	private int _asyncOperations;

	private System.IO.Compression.IFileFormatWriter _formatWriter;

	private bool _wroteHeader;

	private bool _wroteBytes;

	public Stream BaseStream => _stream;

	public override bool CanRead
	{
		get
		{
			if (_stream == null)
			{
				return false;
			}
			if (_mode == CompressionMode.Decompress)
			{
				return _stream.CanRead;
			}
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (_stream == null)
			{
				return false;
			}
			if (_mode == CompressionMode.Compress)
			{
				return _stream.CanWrite;
			}
			return false;
		}
	}

	public override bool CanSeek => false;

	public override long Length
	{
		get
		{
			throw new NotSupportedException(System.SR.NotSupported);
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException(System.SR.NotSupported);
		}
		set
		{
			throw new NotSupportedException(System.SR.NotSupported);
		}
	}

	public DeflateManagedStream(Stream stream, CompressionMode mode)
		: this(stream, mode, leaveOpen: false)
	{
	}

	internal DeflateManagedStream(Stream stream, bool leaveOpen, System.IO.Compression.IFileFormatReader reader)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (!stream.CanRead)
		{
			throw new ArgumentException(System.SR.NotSupported_UnreadableStream, "stream");
		}
		InitializeInflater(stream, leaveOpen, reader);
	}

	internal DeflateManagedStream(Stream stream, ZipArchiveEntry.CompressionMethodValues method)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (!stream.CanRead)
		{
			throw new ArgumentException(System.SR.NotSupported_UnreadableStream, "stream");
		}
		InitializeInflater(stream, leaveOpen: false, null, method);
	}

	public DeflateManagedStream(Stream stream, CompressionMode mode, bool leaveOpen)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		switch (mode)
		{
		case CompressionMode.Decompress:
			InitializeInflater(stream, leaveOpen);
			break;
		case CompressionMode.Compress:
			InitializeDeflater(stream, leaveOpen, CompressionLevel.Optimal);
			break;
		default:
			throw new ArgumentException(System.SR.ArgumentOutOfRange_Enum, "mode");
		}
	}

	public DeflateManagedStream(Stream stream, CompressionLevel compressionLevel)
		: this(stream, compressionLevel, leaveOpen: false)
	{
	}

	public DeflateManagedStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		InitializeDeflater(stream, leaveOpen, compressionLevel);
	}

	internal void InitializeInflater(Stream stream, bool leaveOpen, System.IO.Compression.IFileFormatReader reader = null, ZipArchiveEntry.CompressionMethodValues method = ZipArchiveEntry.CompressionMethodValues.Deflate)
	{
		if (!stream.CanRead)
		{
			throw new ArgumentException(System.SR.NotSupported_UnreadableStream, "stream");
		}
		_inflater = new InflaterManaged(reader, method == ZipArchiveEntry.CompressionMethodValues.Deflate64);
		_stream = stream;
		_mode = CompressionMode.Decompress;
		_leaveOpen = leaveOpen;
		_buffer = new byte[8192];
	}

	internal void InitializeDeflater(Stream stream, bool leaveOpen, CompressionLevel compressionLevel)
	{
		if (!stream.CanWrite)
		{
			throw new ArgumentException(System.SR.NotSupported_UnwritableStream, "stream");
		}
		_deflater = new System.IO.Compression.DeflaterManaged();
		_stream = stream;
		_mode = CompressionMode.Compress;
		_leaveOpen = leaveOpen;
		_buffer = new byte[8192];
	}

	internal void SetFileFormatWriter(System.IO.Compression.IFileFormatWriter writer)
	{
		if (writer != null)
		{
			_formatWriter = writer;
		}
	}

	public override void Flush()
	{
		EnsureNotDisposed();
	}

	public override Task FlushAsync(CancellationToken cancellationToken)
	{
		EnsureNotDisposed();
		if (!cancellationToken.IsCancellationRequested)
		{
			return Task.CompletedTask;
		}
		return Task.FromCanceled(cancellationToken);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException(System.SR.NotSupported);
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException(System.SR.NotSupported);
	}

	public override int Read(byte[] array, int offset, int count)
	{
		EnsureDecompressionMode();
		ValidateParameters(array, offset, count);
		EnsureNotDisposed();
		int num = offset;
		int num2 = count;
		while (true)
		{
			int num3 = _inflater.Inflate(array, num, num2);
			num += num3;
			num2 -= num3;
			if (num2 == 0 || _inflater.Finished())
			{
				break;
			}
			int num4 = _stream.Read(_buffer, 0, _buffer.Length);
			if (num4 <= 0)
			{
				break;
			}
			if (num4 > _buffer.Length)
			{
				throw new InvalidDataException(System.SR.GenericInvalidData);
			}
			_inflater.SetInput(_buffer, 0, num4);
		}
		return count - num2;
	}

	private void ValidateParameters(byte[] array, int offset, int count)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (array.Length - offset < count)
		{
			throw new ArgumentException(System.SR.InvalidArgumentOffsetCount);
		}
	}

	private void EnsureNotDisposed()
	{
		if (_stream == null)
		{
			ThrowStreamClosedException();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowStreamClosedException()
	{
		throw new ObjectDisposedException(null, System.SR.ObjectDisposed_StreamClosed);
	}

	private void EnsureDecompressionMode()
	{
		if (_mode != CompressionMode.Decompress)
		{
			ThrowCannotReadFromDeflateManagedStreamException();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowCannotReadFromDeflateManagedStreamException()
	{
		throw new InvalidOperationException(System.SR.CannotReadFromDeflateStream);
	}

	private void EnsureCompressionMode()
	{
		if (_mode != CompressionMode.Compress)
		{
			ThrowCannotWriteToDeflateManagedStreamException();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowCannotWriteToDeflateManagedStreamException()
	{
		throw new InvalidOperationException(System.SR.CannotWriteToDeflateStream);
	}

	public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback asyncCallback, object asyncState)
	{
		return System.Threading.Tasks.TaskToApm.Begin(ReadAsync(buffer, offset, count, CancellationToken.None), asyncCallback, asyncState);
	}

	public override int EndRead(IAsyncResult asyncResult)
	{
		return System.Threading.Tasks.TaskToApm.End<int>(asyncResult);
	}

	public override Task<int> ReadAsync(byte[] array, int offset, int count, CancellationToken cancellationToken)
	{
		EnsureDecompressionMode();
		if (_asyncOperations != 0)
		{
			throw new InvalidOperationException(System.SR.InvalidBeginCall);
		}
		ValidateParameters(array, offset, count);
		EnsureNotDisposed();
		if (cancellationToken.IsCancellationRequested)
		{
			return Task.FromCanceled<int>(cancellationToken);
		}
		Interlocked.Increment(ref _asyncOperations);
		Task<int> task = null;
		try
		{
			int num = _inflater.Inflate(array, offset, count);
			if (num != 0)
			{
				return Task.FromResult(num);
			}
			if (_inflater.Finished())
			{
				return Task.FromResult(0);
			}
			task = _stream.ReadAsync(_buffer, 0, _buffer.Length, cancellationToken);
			if (task == null)
			{
				throw new InvalidOperationException(System.SR.NotSupported_UnreadableStream);
			}
			return ReadAsyncCore(task, array, offset, count, cancellationToken);
		}
		finally
		{
			if (task == null)
			{
				Interlocked.Decrement(ref _asyncOperations);
			}
		}
	}

	private async Task<int> ReadAsyncCore(Task<int> readTask, byte[] array, int offset, int count, CancellationToken cancellationToken)
	{
		try
		{
			int num;
			while (true)
			{
				num = await readTask.ConfigureAwait(continueOnCapturedContext: false);
				EnsureNotDisposed();
				if (num <= 0)
				{
					return 0;
				}
				if (num > _buffer.Length)
				{
					throw new InvalidDataException(System.SR.GenericInvalidData);
				}
				cancellationToken.ThrowIfCancellationRequested();
				_inflater.SetInput(_buffer, 0, num);
				num = _inflater.Inflate(array, offset, count);
				if (num != 0 || _inflater.Finished())
				{
					break;
				}
				readTask = _stream.ReadAsync(_buffer, 0, _buffer.Length, cancellationToken);
				if (readTask == null)
				{
					throw new InvalidOperationException(System.SR.NotSupported_UnreadableStream);
				}
			}
			return num;
		}
		finally
		{
			Interlocked.Decrement(ref _asyncOperations);
		}
	}

	public override void Write(byte[] array, int offset, int count)
	{
		EnsureCompressionMode();
		ValidateParameters(array, offset, count);
		EnsureNotDisposed();
		DoMaintenance(array, offset, count);
		WriteDeflaterOutput();
		_deflater.SetInput(array, offset, count);
		WriteDeflaterOutput();
	}

	private void WriteDeflaterOutput()
	{
		while (!_deflater.NeedsInput())
		{
			int deflateOutput = _deflater.GetDeflateOutput(_buffer);
			if (deflateOutput > 0)
			{
				_stream.Write(_buffer, 0, deflateOutput);
			}
		}
	}

	private void DoMaintenance(byte[] array, int offset, int count)
	{
		if (count <= 0)
		{
			return;
		}
		_wroteBytes = true;
		if (_formatWriter != null)
		{
			if (!_wroteHeader)
			{
				byte[] header = _formatWriter.GetHeader();
				_stream.Write(header, 0, header.Length);
				_wroteHeader = true;
			}
			_formatWriter.UpdateWithBytesRead(array, offset, count);
		}
	}

	private void PurgeBuffers(bool disposing)
	{
		if (!disposing || _stream == null)
		{
			return;
		}
		Flush();
		if (_mode != CompressionMode.Compress)
		{
			return;
		}
		if (_wroteBytes)
		{
			WriteDeflaterOutput();
			bool flag;
			do
			{
				flag = _deflater.Finish(_buffer, out var bytesRead);
				if (bytesRead > 0)
				{
					_stream.Write(_buffer, 0, bytesRead);
				}
			}
			while (!flag);
		}
		else
		{
			int bytesRead2;
			while (!_deflater.Finish(_buffer, out bytesRead2))
			{
			}
		}
		if (_formatWriter != null && _wroteHeader)
		{
			byte[] footer = _formatWriter.GetFooter();
			_stream.Write(footer, 0, footer.Length);
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			PurgeBuffers(disposing);
		}
		finally
		{
			try
			{
				if (disposing && !_leaveOpen && _stream != null)
				{
					_stream.Dispose();
				}
			}
			finally
			{
				_stream = null;
				try
				{
					_deflater?.Dispose();
					_inflater?.Dispose();
				}
				finally
				{
					_deflater = null;
					_inflater = null;
					base.Dispose(disposing);
				}
			}
		}
	}

	public override Task WriteAsync(byte[] array, int offset, int count, CancellationToken cancellationToken)
	{
		EnsureCompressionMode();
		if (_asyncOperations != 0)
		{
			throw new InvalidOperationException(System.SR.InvalidBeginCall);
		}
		ValidateParameters(array, offset, count);
		EnsureNotDisposed();
		if (cancellationToken.IsCancellationRequested)
		{
			return Task.FromCanceled<int>(cancellationToken);
		}
		return WriteAsyncCore(array, offset, count, cancellationToken);
	}

	private async Task WriteAsyncCore(byte[] array, int offset, int count, CancellationToken cancellationToken)
	{
		Interlocked.Increment(ref _asyncOperations);
		try
		{
			await base.WriteAsync(array, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			Interlocked.Decrement(ref _asyncOperations);
		}
	}

	public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback asyncCallback, object asyncState)
	{
		return System.Threading.Tasks.TaskToApm.Begin(WriteAsync(buffer, offset, count, CancellationToken.None), asyncCallback, asyncState);
	}

	public override void EndWrite(IAsyncResult asyncResult)
	{
		System.Threading.Tasks.TaskToApm.End(asyncResult);
	}
}
