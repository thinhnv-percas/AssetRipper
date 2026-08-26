using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class HttpClient : HttpMessageInvoker
{
	private static readonly TimeSpan s_defaultTimeout = TimeSpan.FromSeconds(100.0);

	private static readonly TimeSpan s_maxTimeout = TimeSpan.FromMilliseconds(2147483647.0);

	private static readonly TimeSpan s_infiniteTimeout = System.Threading.Timeout.InfiniteTimeSpan;

	private const HttpCompletionOption defaultCompletionOption = HttpCompletionOption.ResponseContentRead;

	private volatile bool _operationStarted;

	private volatile bool _disposed;

	private CancellationTokenSource _pendingRequestsCts;

	private HttpRequestHeaders _defaultRequestHeaders;

	private Uri _baseAddress;

	private TimeSpan _timeout;

	private int _maxResponseContentBufferSize;

	public HttpRequestHeaders DefaultRequestHeaders
	{
		get
		{
			if (_defaultRequestHeaders == null)
			{
				_defaultRequestHeaders = new HttpRequestHeaders();
			}
			return _defaultRequestHeaders;
		}
	}

	public Uri BaseAddress
	{
		get
		{
			return _baseAddress;
		}
		set
		{
			CheckBaseAddress(value, "value");
			CheckDisposedOrStarted();
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.UriBaseAddress(this, value);
			}
			_baseAddress = value;
		}
	}

	public TimeSpan Timeout
	{
		get
		{
			return _timeout;
		}
		set
		{
			if (value != s_infiniteTimeout && (value <= TimeSpan.Zero || value > s_maxTimeout))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			CheckDisposedOrStarted();
			_timeout = value;
		}
	}

	public long MaxResponseContentBufferSize
	{
		get
		{
			return _maxResponseContentBufferSize;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("value", value, string.Format(CultureInfo.InvariantCulture, System.SR.net_http_content_buffersize_limit, int.MaxValue));
			}
			CheckDisposedOrStarted();
			_maxResponseContentBufferSize = (int)value;
		}
	}

	public HttpClient()
		: this(new HttpClientHandler())
	{
	}

	public HttpClient(HttpMessageHandler handler)
		: this(handler, disposeHandler: true)
	{
	}

	public HttpClient(HttpMessageHandler handler, bool disposeHandler)
		: base(handler, disposeHandler)
	{
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Enter(this, handler, ".ctor");
		}
		_timeout = s_defaultTimeout;
		_maxResponseContentBufferSize = int.MaxValue;
		_pendingRequestsCts = new CancellationTokenSource();
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Exit(this, null, ".ctor");
		}
	}

	public Task<string> GetStringAsync(string requestUri)
	{
		return GetStringAsync(CreateUri(requestUri));
	}

	public Task<string> GetStringAsync(Uri requestUri)
	{
		return GetStringAsyncCore(GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead));
	}

	private async Task<string> GetStringAsyncCore(Task<HttpResponseMessage> getTask)
	{
		using HttpResponseMessage responseMessage = await getTask.ConfigureAwait(continueOnCapturedContext: false);
		responseMessage.EnsureSuccessStatusCode();
		HttpContent content = responseMessage.Content;
		if (content != null)
		{
			return await content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		return string.Empty;
	}

	public Task<byte[]> GetByteArrayAsync(string requestUri)
	{
		return GetByteArrayAsync(CreateUri(requestUri));
	}

	public Task<byte[]> GetByteArrayAsync(Uri requestUri)
	{
		return GetByteArrayAsyncCore(GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead));
	}

	private async Task<byte[]> GetByteArrayAsyncCore(Task<HttpResponseMessage> getTask)
	{
		using HttpResponseMessage responseMessage = await getTask.ConfigureAwait(continueOnCapturedContext: false);
		responseMessage.EnsureSuccessStatusCode();
		HttpContent content = responseMessage.Content;
		if (content != null)
		{
			return await content.ReadAsByteArrayAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		return Array.Empty<byte>();
	}

	public Task<Stream> GetStreamAsync(string requestUri)
	{
		return GetStreamAsync(CreateUri(requestUri));
	}

	public Task<Stream> GetStreamAsync(Uri requestUri)
	{
		return FinishGetStreamAsync(GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead));
	}

	private async Task<Stream> FinishGetStreamAsync(Task<HttpResponseMessage> getTask)
	{
		HttpResponseMessage httpResponseMessage = await getTask.ConfigureAwait(continueOnCapturedContext: false);
		httpResponseMessage.EnsureSuccessStatusCode();
		HttpContent content = httpResponseMessage.Content;
		return (content == null) ? Stream.Null : (await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false));
	}

	public Task<HttpResponseMessage> GetAsync(string requestUri)
	{
		return GetAsync(CreateUri(requestUri));
	}

	public Task<HttpResponseMessage> GetAsync(Uri requestUri)
	{
		return GetAsync(requestUri, HttpCompletionOption.ResponseContentRead);
	}

	public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
	{
		return GetAsync(CreateUri(requestUri), completionOption);
	}

	public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
	{
		return GetAsync(requestUri, completionOption, CancellationToken.None);
	}

	public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
	{
		return GetAsync(CreateUri(requestUri), cancellationToken);
	}

	public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
	{
		return GetAsync(requestUri, HttpCompletionOption.ResponseContentRead, cancellationToken);
	}

	public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		return GetAsync(CreateUri(requestUri), completionOption, cancellationToken);
	}

	public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
	}

	public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
	{
		return PostAsync(CreateUri(requestUri), content);
	}

	public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
	{
		return PostAsync(requestUri, content, CancellationToken.None);
	}

	public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		return PostAsync(CreateUri(requestUri), content, cancellationToken);
	}

	public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
		httpRequestMessage.Content = content;
		return SendAsync(httpRequestMessage, cancellationToken);
	}

	public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
	{
		return PutAsync(CreateUri(requestUri), content);
	}

	public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
	{
		return PutAsync(requestUri, content, CancellationToken.None);
	}

	public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		return PutAsync(CreateUri(requestUri), content, cancellationToken);
	}

	public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);
		httpRequestMessage.Content = content;
		return SendAsync(httpRequestMessage, cancellationToken);
	}

	public Task<HttpResponseMessage> DeleteAsync(string requestUri)
	{
		return DeleteAsync(CreateUri(requestUri));
	}

	public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
	{
		return DeleteAsync(requestUri, CancellationToken.None);
	}

	public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
	{
		return DeleteAsync(CreateUri(requestUri), cancellationToken);
	}

	public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
	}

	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
	{
		return SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
	}

	public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		return SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
	}

	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
	{
		return SendAsync(request, completionOption, CancellationToken.None);
	}

	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		CheckDisposed();
		CheckRequestMessage(request);
		SetOperationStarted();
		PrepareRequestMessage(request);
		bool flag = _timeout != s_infiniteTimeout;
		bool disposeCts;
		CancellationTokenSource cancellationTokenSource;
		if (flag || cancellationToken.CanBeCanceled)
		{
			disposeCts = true;
			cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _pendingRequestsCts.Token);
			if (flag)
			{
				cancellationTokenSource.CancelAfter(_timeout);
			}
		}
		else
		{
			disposeCts = false;
			cancellationTokenSource = _pendingRequestsCts;
		}
		Task<HttpResponseMessage> sendTask = base.SendAsync(request, cancellationTokenSource.Token);
		if (completionOption != HttpCompletionOption.ResponseContentRead)
		{
			return FinishSendAsyncUnbuffered(sendTask, request, cancellationTokenSource, disposeCts);
		}
		return FinishSendAsyncBuffered(sendTask, request, cancellationTokenSource, disposeCts);
	}

	private async Task<HttpResponseMessage> FinishSendAsyncBuffered(Task<HttpResponseMessage> sendTask, HttpRequestMessage request, CancellationTokenSource cts, bool disposeCts)
	{
		HttpResponseMessage response = null;
		try
		{
			response = await sendTask.ConfigureAwait(continueOnCapturedContext: false);
			if (response == null)
			{
				throw new InvalidOperationException(System.SR.net_http_handler_noresponse);
			}
			if (response.Content != null)
			{
				await response.Content.LoadIntoBufferAsync(_maxResponseContentBufferSize).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.ClientSendCompleted(this, response, request);
			}
			return response;
		}
		catch (Exception e)
		{
			response?.Dispose();
			HandleFinishSendAsyncError(e, cts);
			throw;
		}
		finally
		{
			HandleFinishSendAsyncCleanup(cts, disposeCts);
		}
	}

	private async Task<HttpResponseMessage> FinishSendAsyncUnbuffered(Task<HttpResponseMessage> sendTask, HttpRequestMessage request, CancellationTokenSource cts, bool disposeCts)
	{
		try
		{
			HttpResponseMessage httpResponseMessage = await sendTask.ConfigureAwait(continueOnCapturedContext: false);
			if (httpResponseMessage == null)
			{
				throw new InvalidOperationException(System.SR.net_http_handler_noresponse);
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.ClientSendCompleted(this, httpResponseMessage, request);
			}
			return httpResponseMessage;
		}
		catch (Exception e)
		{
			HandleFinishSendAsyncError(e, cts);
			throw;
		}
		finally
		{
			HandleFinishSendAsyncCleanup(cts, disposeCts);
		}
	}

	private void HandleFinishSendAsyncError(Exception e, CancellationTokenSource cts)
	{
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Error(this, e, "HandleFinishSendAsyncError");
		}
		if (cts.IsCancellationRequested && e is HttpRequestException)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(this, $"Canceled", "HandleFinishSendAsyncError");
			}
			throw new OperationCanceledException(cts.Token);
		}
	}

	private void HandleFinishSendAsyncCleanup(CancellationTokenSource cts, bool disposeCts)
	{
		if (disposeCts)
		{
			cts.Dispose();
		}
	}

	public void CancelPendingRequests()
	{
		CheckDisposed();
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Enter(this, null, "CancelPendingRequests");
		}
		CancellationTokenSource cancellationTokenSource = Interlocked.Exchange(ref _pendingRequestsCts, new CancellationTokenSource());
		cancellationTokenSource.Cancel();
		cancellationTokenSource.Dispose();
		if (NetEventSource.IsEnabled)
		{
			NetEventSource.Exit(this, null, "CancelPendingRequests");
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			_pendingRequestsCts.Cancel();
			_pendingRequestsCts.Dispose();
		}
		base.Dispose(disposing);
	}

	private void SetOperationStarted()
	{
		if (!_operationStarted)
		{
			_operationStarted = true;
		}
	}

	private void CheckDisposedOrStarted()
	{
		CheckDisposed();
		if (_operationStarted)
		{
			throw new InvalidOperationException(System.SR.net_http_operation_started);
		}
	}

	private void CheckDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException(GetType().ToString());
		}
	}

	private static void CheckRequestMessage(HttpRequestMessage request)
	{
		if (!request.MarkAsSent())
		{
			throw new InvalidOperationException(System.SR.net_http_client_request_already_sent);
		}
	}

	private void PrepareRequestMessage(HttpRequestMessage request)
	{
		Uri uri = null;
		if (request.RequestUri == null && _baseAddress == null)
		{
			throw new InvalidOperationException(System.SR.net_http_client_invalid_requesturi);
		}
		if (request.RequestUri == null)
		{
			uri = _baseAddress;
		}
		else if (!request.RequestUri.IsAbsoluteUri)
		{
			if (_baseAddress == null)
			{
				throw new InvalidOperationException(System.SR.net_http_client_invalid_requesturi);
			}
			uri = new Uri(_baseAddress, request.RequestUri);
		}
		if (uri != null)
		{
			request.RequestUri = uri;
		}
		if (_defaultRequestHeaders != null)
		{
			request.Headers.AddHeaders(_defaultRequestHeaders);
		}
	}

	private static void CheckBaseAddress(Uri baseAddress, string parameterName)
	{
		if (!(baseAddress == null))
		{
			if (!baseAddress.IsAbsoluteUri)
			{
				throw new ArgumentException(System.SR.net_http_client_absolute_baseaddress_required, parameterName);
			}
			if (!HttpUtilities.IsHttpUri(baseAddress))
			{
				throw new ArgumentException(System.SR.net_http_client_http_baseaddress_required, parameterName);
			}
		}
	}

	private Uri CreateUri(string uri)
	{
		if (string.IsNullOrEmpty(uri))
		{
			return null;
		}
		return new Uri(uri, UriKind.RelativeOrAbsolute);
	}
}
