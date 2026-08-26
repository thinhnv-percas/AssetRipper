using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace System.Net.Http;

public class HttpResponseMessage : IDisposable
{
	private const HttpStatusCode defaultStatusCode = HttpStatusCode.OK;

	private HttpStatusCode _statusCode;

	private HttpResponseHeaders _headers;

	private string _reasonPhrase;

	private HttpRequestMessage _requestMessage;

	private Version _version;

	private HttpContent _content;

	private bool _disposed;

	public Version Version
	{
		get
		{
			return _version;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			CheckDisposed();
			_version = value;
		}
	}

	public HttpContent Content
	{
		get
		{
			return _content;
		}
		set
		{
			CheckDisposed();
			if (NetEventSource.IsEnabled)
			{
				if (value == null)
				{
					NetEventSource.ContentNull(this);
				}
				else
				{
					NetEventSource.Associate(this, value, "Content");
				}
			}
			_content = value;
		}
	}

	public HttpStatusCode StatusCode
	{
		get
		{
			return _statusCode;
		}
		set
		{
			if (value < (HttpStatusCode)0 || value > (HttpStatusCode)999)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			CheckDisposed();
			_statusCode = value;
		}
	}

	public string ReasonPhrase
	{
		get
		{
			if (_reasonPhrase != null)
			{
				return _reasonPhrase;
			}
			return HttpStatusDescription.Get(StatusCode);
		}
		set
		{
			if (value != null && ContainsNewLineCharacter(value))
			{
				throw new FormatException(System.SR.net_http_reasonphrase_format_error);
			}
			CheckDisposed();
			_reasonPhrase = value;
		}
	}

	public HttpResponseHeaders Headers
	{
		get
		{
			if (_headers == null)
			{
				_headers = new HttpResponseHeaders();
			}
			return _headers;
		}
	}

	public HttpRequestMessage RequestMessage
	{
		get
		{
			return _requestMessage;
		}
		set
		{
			CheckDisposed();
			if (value != null)
			{
				NetEventSource.Associate(this, value, "RequestMessage");
			}
			_requestMessage = value;
		}
	}

	public bool IsSuccessStatusCode
	{
		get
		{
			if (_statusCode >= HttpStatusCode.OK)
			{
				return _statusCode <= (HttpStatusCode)299;
			}
			return false;
		}
	}

	public HttpResponseMessage()
		: this(HttpStatusCode.OK)
	{
	}

	public HttpResponseMessage(HttpStatusCode statusCode)
	{
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Enter(this, statusCode, ".ctor");
		}
		if (statusCode < (HttpStatusCode)0 || statusCode > (HttpStatusCode)999)
		{
			throw new ArgumentOutOfRangeException("statusCode");
		}
		_statusCode = statusCode;
		_version = HttpUtilities.DefaultResponseVersion;
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Exit(this, null, ".ctor");
		}
	}

	public HttpResponseMessage EnsureSuccessStatusCode()
	{
		if (!IsSuccessStatusCode)
		{
			if (_content != null)
			{
				_content.Dispose();
			}
			throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_message_not_success_statuscode, (int)_statusCode, ReasonPhrase));
		}
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("StatusCode: ");
		stringBuilder.Append((int)_statusCode);
		stringBuilder.Append(", ReasonPhrase: '");
		stringBuilder.Append(ReasonPhrase ?? "<null>");
		stringBuilder.Append("', Version: ");
		stringBuilder.Append(_version);
		stringBuilder.Append(", Content: ");
		stringBuilder.Append((_content == null) ? "<null>" : _content.GetType().ToString());
		stringBuilder.Append(", Headers:\r\n");
		stringBuilder.Append(HeaderUtilities.DumpHeaders(_headers, (_content == null) ? null : _content.Headers));
		return stringBuilder.ToString();
	}

	private bool ContainsNewLineCharacter(string value)
	{
		foreach (char c in value)
		{
			if (c == '\r' || c == '\n')
			{
				return true;
			}
		}
		return false;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			if (_content != null)
			{
				_content.Dispose();
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
}
