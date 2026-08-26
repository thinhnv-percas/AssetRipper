using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public abstract class HttpContent : IDisposable
{
	internal sealed class LimitMemoryStream : MemoryStream
	{
		private readonly int _maxSize;

		public int MaxSize => _maxSize;

		public LimitMemoryStream(int maxSize, int capacity)
			: base(capacity)
		{
			_maxSize = maxSize;
		}

		public byte[] GetSizedBuffer()
		{
			if (!TryGetBuffer(out var buffer) || buffer.Offset != 0 || buffer.Count != buffer.Array.Length)
			{
				return ToArray();
			}
			return buffer.Array;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			CheckSize(count);
			base.Write(buffer, offset, count);
		}

		public override void WriteByte(byte value)
		{
			CheckSize(1);
			base.WriteByte(value);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			CheckSize(count);
			return base.WriteAsync(buffer, offset, count, cancellationToken);
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			CheckSize(count);
			return base.BeginWrite(buffer, offset, count, callback, state);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			base.EndWrite(asyncResult);
		}

		public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			if (TryGetBuffer(out var buffer))
			{
				StreamHelpers.ValidateCopyToArgs(this, destination, bufferSize);
				long position = Position;
				long num = (Position = Length);
				long num2 = num - position;
				return destination.WriteAsync(buffer.Array, (int)(buffer.Offset + position), (int)num2, cancellationToken);
			}
			return base.CopyToAsync(destination, bufferSize, cancellationToken);
		}

		private void CheckSize(int countToAdd)
		{
			if (_maxSize - Length < countToAdd)
			{
				throw CreateOverCapacityException(_maxSize);
			}
		}
	}

	private HttpContentHeaders _headers;

	private MemoryStream _bufferedContent;

	private bool _disposed;

	private Task<Stream> _contentReadStream;

	private bool _canCalculateLength;

	internal const int MaxBufferSize = int.MaxValue;

	internal static readonly Encoding DefaultStringEncoding = Encoding.UTF8;

	private const int UTF8CodePage = 65001;

	private const int UTF8PreambleLength = 3;

	private const byte UTF8PreambleByte0 = 239;

	private const byte UTF8PreambleByte1 = 187;

	private const byte UTF8PreambleByte2 = 191;

	private const int UTF8PreambleFirst2Bytes = 61371;

	private const int UTF32CodePage = 12000;

	private const int UTF32PreambleLength = 4;

	private const byte UTF32PreambleByte0 = byte.MaxValue;

	private const byte UTF32PreambleByte1 = 254;

	private const byte UTF32PreambleByte2 = 0;

	private const byte UTF32PreambleByte3 = 0;

	private const int UTF32OrUnicodePreambleFirst2Bytes = 65534;

	private const int UnicodeCodePage = 1200;

	private const int UnicodePreambleLength = 2;

	private const byte UnicodePreambleByte0 = byte.MaxValue;

	private const byte UnicodePreambleByte1 = 254;

	private const int BigEndianUnicodeCodePage = 1201;

	private const int BigEndianUnicodePreambleLength = 2;

	private const byte BigEndianUnicodePreambleByte0 = 254;

	private const byte BigEndianUnicodePreambleByte1 = byte.MaxValue;

	private const int BigEndianUnicodePreambleFirst2Bytes = 65279;

	public HttpContentHeaders Headers
	{
		get
		{
			if (_headers == null)
			{
				_headers = new HttpContentHeaders(this);
			}
			return _headers;
		}
	}

	private bool IsBuffered => _bufferedContent != null;

	internal void SetBuffer(byte[] buffer, int offset, int count)
	{
		_bufferedContent = new MemoryStream(buffer, offset, count, writable: false, publiclyVisible: true);
	}

	internal bool TryGetBuffer(out ArraySegment<byte> buffer)
	{
		buffer = default(ArraySegment<byte>);
		if (_bufferedContent != null)
		{
			return _bufferedContent.TryGetBuffer(out buffer);
		}
		return false;
	}

	protected HttpContent()
	{
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Enter(this, null, ".ctor");
		}
		_canCalculateLength = true;
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Exit(this, null, ".ctor");
		}
	}

	public Task<string> ReadAsStringAsync()
	{
		CheckDisposed();
		return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (HttpContent s) => s.ReadBufferedContentAsString());
	}

	private string ReadBufferedContentAsString()
	{
		if (_bufferedContent.Length == 0L)
		{
			return string.Empty;
		}
		if (!TryGetBuffer(out var buffer))
		{
			buffer = new ArraySegment<byte>(_bufferedContent.ToArray());
		}
		return ReadBufferAsString(buffer, Headers);
	}

	internal static string ReadBufferAsString(ArraySegment<byte> buffer, HttpContentHeaders headers)
	{
		Encoding encoding = null;
		int preambleLength = -1;
		if (headers.ContentType != null && headers.ContentType.CharSet != null)
		{
			try
			{
				encoding = Encoding.GetEncoding(headers.ContentType.CharSet);
				preambleLength = GetPreambleLength(buffer, encoding);
			}
			catch (ArgumentException innerException)
			{
				throw new InvalidOperationException(System.SR.net_http_content_invalid_charset, innerException);
			}
		}
		if (encoding == null && !TryDetectEncoding(buffer, out encoding, out preambleLength))
		{
			encoding = DefaultStringEncoding;
			preambleLength = 0;
		}
		return encoding.GetString(buffer.Array, buffer.Offset + preambleLength, buffer.Count - preambleLength);
	}

	public Task<byte[]> ReadAsByteArrayAsync()
	{
		CheckDisposed();
		return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (HttpContent s) => s.ReadBufferedContentAsByteArray());
	}

	internal byte[] ReadBufferedContentAsByteArray()
	{
		return _bufferedContent.ToArray();
	}

	public Task<Stream> ReadAsStreamAsync()
	{
		CheckDisposed();
		if (_contentReadStream == null && TryGetBuffer(out var buffer))
		{
			_contentReadStream = Task.FromResult((Stream)new MemoryStream(buffer.Array, buffer.Offset, buffer.Count, writable: false));
		}
		if (_contentReadStream != null)
		{
			return _contentReadStream;
		}
		_contentReadStream = CreateContentReadStreamAsync();
		return _contentReadStream;
	}

	protected abstract Task SerializeToStreamAsync(Stream stream, TransportContext context);

	public Task CopyToAsync(Stream stream, TransportContext context)
	{
		CheckDisposed();
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		try
		{
			Task task = null;
			if (TryGetBuffer(out var buffer))
			{
				task = stream.WriteAsync(buffer.Array, buffer.Offset, buffer.Count);
			}
			else
			{
				task = SerializeToStreamAsync(stream, context);
				CheckTaskNotNull(task);
			}
			return CopyToAsyncCore(task);
		}
		catch (Exception ex) when (StreamCopyExceptionNeedsWrapping(ex))
		{
			return Task.FromException(GetStreamCopyException(ex));
		}
	}

	private static async Task CopyToAsyncCore(Task copyTask)
	{
		try
		{
			await copyTask.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex) when (StreamCopyExceptionNeedsWrapping(ex))
		{
			throw GetStreamCopyException(ex);
		}
	}

	public Task CopyToAsync(Stream stream)
	{
		return CopyToAsync(stream, null);
	}

	internal void CopyTo(Stream stream)
	{
		CopyToAsync(stream).Wait();
	}

	public Task LoadIntoBufferAsync()
	{
		return LoadIntoBufferAsync(2147483647L);
	}

	public Task LoadIntoBufferAsync(long maxBufferSize)
	{
		CheckDisposed();
		if (maxBufferSize > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException("maxBufferSize", maxBufferSize, string.Format(CultureInfo.InvariantCulture, System.SR.net_http_content_buffersize_limit, int.MaxValue));
		}
		if (IsBuffered)
		{
			return Task.CompletedTask;
		}
		Exception error = null;
		MemoryStream memoryStream = CreateMemoryStream(maxBufferSize, out error);
		if (memoryStream == null)
		{
			return Task.FromException(error);
		}
		try
		{
			Task task = SerializeToStreamAsync(memoryStream, null);
			CheckTaskNotNull(task);
			return LoadIntoBufferAsyncCore(task, memoryStream);
		}
		catch (Exception ex) when (StreamCopyExceptionNeedsWrapping(ex))
		{
			return Task.FromException(GetStreamCopyException(ex));
		}
	}

	private async Task LoadIntoBufferAsyncCore(Task serializeToStreamTask, MemoryStream tempBuffer)
	{
		try
		{
			await serializeToStreamTask.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			tempBuffer.Dispose();
			Exception streamCopyException = GetStreamCopyException(ex);
			if (streamCopyException != ex)
			{
				throw streamCopyException;
			}
			throw;
		}
		try
		{
			tempBuffer.Seek(0L, SeekOrigin.Begin);
			_bufferedContent = tempBuffer;
		}
		catch (Exception message)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(this, message, "LoadIntoBufferAsyncCore");
			}
			throw;
		}
	}

	protected virtual Task<Stream> CreateContentReadStreamAsync()
	{
		return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (Func<HttpContent, Stream>)((HttpContent s) => s._bufferedContent));
	}

	protected internal abstract bool TryComputeLength(out long length);

	internal long? GetComputedOrBufferLength()
	{
		CheckDisposed();
		if (IsBuffered)
		{
			return _bufferedContent.Length;
		}
		if (_canCalculateLength)
		{
			long length = 0L;
			if (TryComputeLength(out length))
			{
				return length;
			}
			_canCalculateLength = false;
		}
		return null;
	}

	private MemoryStream CreateMemoryStream(long maxBufferSize, out Exception error)
	{
		error = null;
		long? contentLength = Headers.ContentLength;
		if (contentLength.HasValue)
		{
			if (contentLength > maxBufferSize)
			{
				error = new HttpRequestException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_content_buffersize_exceeded, maxBufferSize));
				return null;
			}
			return new LimitMemoryStream((int)maxBufferSize, (int)contentLength.Value);
		}
		return new LimitMemoryStream((int)maxBufferSize, 0);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			if (_contentReadStream != null && _contentReadStream.Status == TaskStatus.RanToCompletion)
			{
				_contentReadStream.Result.Dispose();
				_contentReadStream = null;
			}
			if (IsBuffered)
			{
				_bufferedContent.Dispose();
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void CheckDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException(GetType().ToString());
		}
	}

	private void CheckTaskNotNull(Task task)
	{
		if (task == null)
		{
			InvalidOperationException ex = new InvalidOperationException(System.SR.net_http_content_no_task_returned);
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(this, ex, "CheckTaskNotNull");
			}
			throw ex;
		}
	}

	private static bool StreamCopyExceptionNeedsWrapping(Exception e)
	{
		if (!(e is IOException))
		{
			return e is ObjectDisposedException;
		}
		return true;
	}

	private static Exception GetStreamCopyException(Exception originalException)
	{
		if (!StreamCopyExceptionNeedsWrapping(originalException))
		{
			return originalException;
		}
		return new HttpRequestException(System.SR.net_http_content_stream_copy_error, originalException);
	}

	private static int GetPreambleLength(ArraySegment<byte> buffer, Encoding encoding)
	{
		byte[] array = buffer.Array;
		int offset = buffer.Offset;
		int count = buffer.Count;
		switch (encoding.CodePage)
		{
		case 65001:
			if (count < 3 || array[offset] != 239 || array[offset + 1] != 187 || array[offset + 2] != 191)
			{
				return 0;
			}
			return 3;
		case 12000:
			if (count < 4 || array[offset] != byte.MaxValue || array[offset + 1] != 254 || array[offset + 2] != 0 || array[offset + 3] != 0)
			{
				return 0;
			}
			return 4;
		case 1200:
			if (count < 2 || array[offset] != byte.MaxValue || array[offset + 1] != 254)
			{
				return 0;
			}
			return 2;
		case 1201:
			if (count < 2 || array[offset] != 254 || array[offset + 1] != byte.MaxValue)
			{
				return 0;
			}
			return 2;
		default:
		{
			byte[] preamble = encoding.GetPreamble();
			if (!BufferHasPrefix(buffer, preamble))
			{
				return 0;
			}
			return preamble.Length;
		}
		}
	}

	private static bool TryDetectEncoding(ArraySegment<byte> buffer, out Encoding encoding, out int preambleLength)
	{
		byte[] array = buffer.Array;
		int offset = buffer.Offset;
		int count = buffer.Count;
		if (count >= 2)
		{
			switch ((array[offset] << 8) | array[offset + 1])
			{
			case 61371:
				if (count >= 3 && array[offset + 2] == 191)
				{
					encoding = Encoding.UTF8;
					preambleLength = 3;
					return true;
				}
				break;
			case 65534:
				if (count >= 4 && array[offset + 2] == 0 && array[offset + 3] == 0)
				{
					encoding = Encoding.UTF32;
					preambleLength = 4;
				}
				else
				{
					encoding = Encoding.Unicode;
					preambleLength = 2;
				}
				return true;
			case 65279:
				encoding = Encoding.BigEndianUnicode;
				preambleLength = 2;
				return true;
			}
		}
		encoding = null;
		preambleLength = 0;
		return false;
	}

	private static bool BufferHasPrefix(ArraySegment<byte> buffer, byte[] prefix)
	{
		byte[] array = buffer.Array;
		if (prefix == null || array == null || prefix.Length > buffer.Count || prefix.Length == 0)
		{
			return false;
		}
		int num = 0;
		int num2 = buffer.Offset;
		while (num < prefix.Length)
		{
			if (prefix[num] != array[num2])
			{
				return false;
			}
			num++;
			num2++;
		}
		return true;
	}

	private static async Task<TResult> WaitAndReturnAsync<TState, TResult>(Task waitTask, TState state, Func<TState, TResult> returnFunc)
	{
		await waitTask.ConfigureAwait(continueOnCapturedContext: false);
		return returnFunc(state);
	}

	private static Exception CreateOverCapacityException(int maxBufferSize)
	{
		return new HttpRequestException(System.SR.Format(System.SR.net_http_content_buffersize_exceeded, maxBufferSize));
	}
}
