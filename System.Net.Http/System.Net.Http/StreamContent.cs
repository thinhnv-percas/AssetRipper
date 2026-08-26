using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class StreamContent : HttpContent
{
	private class ReadOnlyStream : DelegatingStream
	{
		public override bool CanWrite => false;

		public override int WriteTimeout
		{
			get
			{
				throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
			}
			set
			{
				throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
			}
		}

		public ReadOnlyStream(Stream innerStream)
			: base(innerStream)
		{
		}

		public override void Flush()
		{
			throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			throw new NotSupportedException(System.SR.net_http_content_readonly_stream);
		}
	}

	private const int DefaultBufferSize = 4096;

	private Stream _content;

	private int _bufferSize;

	private CancellationToken _cancellationToken;

	private bool _contentConsumed;

	private long _start;

	public StreamContent(Stream content)
		: this(content, 4096)
	{
	}

	public StreamContent(Stream content, int bufferSize)
		: this(content, bufferSize, CancellationToken.None)
	{
	}

	internal StreamContent(Stream content, CancellationToken cancellationToken)
		: this(content, 4096, cancellationToken)
	{
	}

	private StreamContent(Stream content, int bufferSize, CancellationToken cancellationToken)
	{
		if (content == null)
		{
			throw new ArgumentNullException("content");
		}
		if (bufferSize <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferSize");
		}
		_content = content;
		_bufferSize = bufferSize;
		_cancellationToken = cancellationToken;
		if (content.CanSeek)
		{
			_start = content.Position;
		}
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Associate(this, content, ".ctor");
		}
	}

	protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
	{
		PrepareContent();
		return StreamToStreamCopy.CopyAsync(_content, stream, _bufferSize, !_content.CanSeek, _cancellationToken);
	}

	protected internal override bool TryComputeLength(out long length)
	{
		if (_content.CanSeek)
		{
			length = _content.Length - _start;
			return true;
		}
		length = 0L;
		return false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_content.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override Task<Stream> CreateContentReadStreamAsync()
	{
		return Task.FromResult((Stream)new ReadOnlyStream(_content));
	}

	private void PrepareContent()
	{
		if (_contentConsumed)
		{
			if (!_content.CanSeek)
			{
				throw new InvalidOperationException(System.SR.net_http_content_stream_already_read);
			}
			_content.Position = _start;
		}
		_contentConsumed = true;
	}
}
