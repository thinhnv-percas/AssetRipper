using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class HttpClientHandler : HttpMessageHandler
{
	private class RequestState
	{
		internal HttpWebRequest webRequest;

		internal TaskCompletionSource<HttpResponseMessage> tcs;

		internal CancellationToken cancellationToken;

		internal HttpRequestMessage requestMessage;

		internal Stream requestStream;

		internal WindowsIdentity identity;
	}

	private class WebExceptionWrapperStream : DelegatingStream
	{
		internal WebExceptionWrapperStream(Stream innerStream)
			: base(innerStream)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			try
			{
				return base.Read(buffer, offset, count);
			}
			catch (WebException innerException)
			{
				throw new IOException(System.SR.net_http_io_read, innerException);
			}
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			try
			{
				return base.BeginRead(buffer, offset, count, callback, state);
			}
			catch (WebException innerException)
			{
				throw new IOException(System.SR.net_http_io_read, innerException);
			}
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			try
			{
				return base.EndRead(asyncResult);
			}
			catch (WebException innerException)
			{
				throw new IOException(System.SR.net_http_io_read, innerException);
			}
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			try
			{
				return await base.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (WebException innerException)
			{
				throw new IOException(System.SR.net_http_io_read, innerException);
			}
		}

		public override int ReadByte()
		{
			try
			{
				return base.ReadByte();
			}
			catch (WebException innerException)
			{
				throw new IOException(System.SR.net_http_io_read, innerException);
			}
		}
	}

	private static readonly Action<object> s_onCancel = OnCancel;

	private readonly Action<object> _startRequest;

	private readonly AsyncCallback _getRequestStreamCallback;

	private readonly AsyncCallback _getResponseCallback;

	private volatile bool _operationStarted;

	private volatile bool _disposed;

	private long _maxRequestContentBufferSize;

	private int _maxResponseHeadersLength;

	private CookieContainer _cookieContainer;

	private bool _useCookies;

	private DecompressionMethods _automaticDecompression;

	private IWebProxy _proxy;

	private bool _useProxy;

	private ICredentials _defaultProxyCredentials;

	private bool _preAuthenticate;

	private bool _useDefaultCredentials;

	private ICredentials _credentials;

	private bool _allowAutoRedirect;

	private int _maxAutomaticRedirections;

	private string _connectionGroupName;

	private ClientCertificateOption _clientCertOptions;

	private X509Certificate2Collection _clientCertificates;

	private IDictionary<string, object> _properties;

	private int _maxConnectionsPerServer;

	private Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> _serverCertificateCustomValidationCallback;

	public bool AllowAutoRedirect
	{
		get
		{
			return _allowAutoRedirect;
		}
		set
		{
			CheckDisposedOrStarted();
			_allowAutoRedirect = value;
		}
	}

	public DecompressionMethods AutomaticDecompression
	{
		get
		{
			return _automaticDecompression;
		}
		set
		{
			CheckDisposedOrStarted();
			_automaticDecompression = value;
		}
	}

	public bool CheckCertificateRevocationList
	{
		get
		{
			throw new PlatformNotSupportedException();
		}
		set
		{
			CheckDisposedOrStarted();
			throw new PlatformNotSupportedException();
		}
	}

	public ClientCertificateOption ClientCertificateOptions
	{
		get
		{
			return _clientCertOptions;
		}
		set
		{
			if (value != ClientCertificateOption.Manual && value != ClientCertificateOption.Automatic)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			CheckDisposedOrStarted();
			_clientCertOptions = value;
		}
	}

	public X509CertificateCollection ClientCertificates
	{
		get
		{
			if (_clientCertOptions != ClientCertificateOption.Manual)
			{
				throw new InvalidOperationException(System.SR.Format(System.SR.net_http_invalid_enable_first, "ClientCertificateOptions", "Manual"));
			}
			if (_clientCertificates == null)
			{
				_clientCertificates = new X509Certificate2Collection();
			}
			return _clientCertificates;
		}
	}

	public CookieContainer CookieContainer
	{
		get
		{
			return _cookieContainer;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!UseCookies)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_invalid_enable_first, "UseCookies", "true"));
			}
			CheckDisposedOrStarted();
			_cookieContainer = value;
		}
	}

	public ICredentials Credentials
	{
		get
		{
			return _credentials;
		}
		set
		{
			CheckDisposedOrStarted();
			_credentials = value;
		}
	}

	public ICredentials DefaultProxyCredentials
	{
		get
		{
			return _defaultProxyCredentials;
		}
		set
		{
			CheckDisposedOrStarted();
			_defaultProxyCredentials = value;
		}
	}

	public int MaxAutomaticRedirections
	{
		get
		{
			return _maxAutomaticRedirections;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			CheckDisposedOrStarted();
			_maxAutomaticRedirections = value;
		}
	}

	public int MaxConnectionsPerServer
	{
		get
		{
			return _maxConnectionsPerServer;
		}
		set
		{
			if (value < 1)
			{
				throw new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.net_http_value_must_be_greater_than, 0));
			}
			CheckDisposedOrStarted();
			_maxConnectionsPerServer = value;
		}
	}

	public long MaxRequestContentBufferSize
	{
		get
		{
			return _maxRequestContentBufferSize;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("value", value, string.Format(CultureInfo.InvariantCulture, System.SR.net_http_content_buffersize_limit, int.MaxValue));
			}
			CheckDisposedOrStarted();
			_maxRequestContentBufferSize = value;
		}
	}

	public int MaxResponseHeadersLength
	{
		get
		{
			return _maxResponseHeadersLength;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			CheckDisposedOrStarted();
			_maxResponseHeadersLength = value;
		}
	}

	public bool PreAuthenticate
	{
		get
		{
			return _preAuthenticate;
		}
		set
		{
			CheckDisposedOrStarted();
			_preAuthenticate = value;
		}
	}

	public IDictionary<string, object> Properties
	{
		get
		{
			if (_properties == null)
			{
				_properties = new Dictionary<string, object>();
			}
			return _properties;
		}
	}

	public IWebProxy Proxy
	{
		get
		{
			return _proxy;
		}
		[SecuritySafeCritical]
		set
		{
			if (!UseProxy && value != null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_invalid_enable_first, "UseProxy", "true"));
			}
			CheckDisposedOrStarted();
			ExceptionHelper.WebPermissionUnrestricted.Demand();
			_proxy = value;
		}
	}

	public static Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> DangerousAcceptAnyServerCertificateValidator { get; } = (HttpRequestMessage _003Cp0_003E, X509Certificate2 _003Cp1_003E, X509Chain _003Cp2_003E, SslPolicyErrors _003Cp3_003E) => true;

	public Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> ServerCertificateCustomValidationCallback
	{
		get
		{
			return _serverCertificateCustomValidationCallback;
		}
		set
		{
			CheckDisposedOrStarted();
			_serverCertificateCustomValidationCallback = value;
		}
	}

	public SslProtocols SslProtocols
	{
		get
		{
			throw new PlatformNotSupportedException();
		}
		set
		{
			CheckDisposedOrStarted();
			throw new PlatformNotSupportedException();
		}
	}

	public virtual bool SupportsAutomaticDecompression => true;

	public virtual bool SupportsProxy => true;

	public virtual bool SupportsRedirectConfiguration => true;

	public bool UseCookies
	{
		get
		{
			return _useCookies;
		}
		set
		{
			CheckDisposedOrStarted();
			_useCookies = value;
		}
	}

	public bool UseDefaultCredentials
	{
		get
		{
			return _useDefaultCredentials;
		}
		set
		{
			CheckDisposedOrStarted();
			_useDefaultCredentials = value;
		}
	}

	public bool UseProxy
	{
		get
		{
			return _useProxy;
		}
		set
		{
			CheckDisposedOrStarted();
			_useProxy = value;
		}
	}

	public HttpClientHandler()
	{
		_startRequest = StartRequest;
		_getRequestStreamCallback = GetRequestStreamCallback;
		_getResponseCallback = GetResponseCallback;
		_connectionGroupName = RuntimeHelpers.GetHashCode(this).ToString(NumberFormatInfo.InvariantInfo);
		_allowAutoRedirect = true;
		_maxRequestContentBufferSize = 2147483647L;
		_automaticDecompression = DecompressionMethods.None;
		_cookieContainer = new CookieContainer();
		_credentials = null;
		_maxAutomaticRedirections = 50;
		_preAuthenticate = false;
		_proxy = null;
		_useProxy = true;
		_useCookies = true;
		_useDefaultCredentials = false;
		_clientCertOptions = ClientCertificateOption.Manual;
		_maxResponseHeadersLength = HttpWebRequest.DefaultMaximumResponseHeadersLength;
		_defaultProxyCredentials = null;
		_clientCertificates = null;
		_properties = null;
		_maxConnectionsPerServer = ServicePointManager.DefaultConnectionLimit;
		_serverCertificateCustomValidationCallback = null;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			ServicePointManager.CloseConnectionGroups(_connectionGroupName);
		}
		base.Dispose(disposing);
	}

	private HttpWebRequest CreateAndPrepareWebRequest(HttpRequestMessage request)
	{
		HttpWebRequest httpWebRequest = null;
		httpWebRequest = ((request.Content == null) ? new HttpWebRequest(request.RequestUri, returnResponseOnFailureStatusCode: true, _connectionGroupName, null) : new HttpWebRequest(request.RequestUri, returnResponseOnFailureStatusCode: true, _connectionGroupName, request.Content.CopyTo));
		if (Logging.On)
		{
			Logging.Associate(Logging.Http, request, httpWebRequest);
		}
		httpWebRequest.Method = request.Method.Method;
		httpWebRequest.ProtocolVersion = request.Version;
		SetDefaultOptions(httpWebRequest);
		SetConnectionOptions(httpWebRequest, request);
		SetServicePointOptions(httpWebRequest, request);
		SetRequestHeaders(httpWebRequest, request);
		SetContentHeaders(httpWebRequest, request);
		httpWebRequest.ServicePoint.ConnectionLimit = _maxConnectionsPerServer;
		httpWebRequest.MaximumResponseHeadersLength = _maxResponseHeadersLength;
		if (ClientCertificateOptions == ClientCertificateOption.Manual && _clientCertificates != null && _clientCertificates.Count > 0)
		{
			httpWebRequest.ClientCertificates = _clientCertificates;
		}
		if (_serverCertificateCustomValidationCallback != null)
		{
			httpWebRequest.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
		}
		if (_defaultProxyCredentials != null && _useProxy && _proxy == null && httpWebRequest.Proxy != null)
		{
			httpWebRequest.Proxy.Credentials = _defaultProxyCredentials;
		}
		InitializeWebRequest(request, httpWebRequest);
		return httpWebRequest;
	}

	private bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		return _serverCertificateCustomValidationCallback(null, (X509Certificate2)certificate, chain, sslPolicyErrors);
	}

	internal virtual void InitializeWebRequest(HttpRequestMessage request, HttpWebRequest webRequest)
	{
	}

	private void SetDefaultOptions(HttpWebRequest webRequest)
	{
		webRequest.Timeout = -1;
		webRequest.AllowAutoRedirect = _allowAutoRedirect;
		webRequest.AutomaticDecompression = _automaticDecompression;
		webRequest.PreAuthenticate = _preAuthenticate;
		if (_useDefaultCredentials)
		{
			webRequest.UseDefaultCredentials = true;
		}
		else
		{
			webRequest.Credentials = _credentials;
		}
		if (_allowAutoRedirect)
		{
			webRequest.MaximumAutomaticRedirections = _maxAutomaticRedirections;
		}
		if (_useProxy)
		{
			if (_proxy != null)
			{
				webRequest.Proxy = _proxy;
			}
		}
		else
		{
			webRequest.Proxy = null;
		}
		if (_useCookies)
		{
			webRequest.CookieContainer = _cookieContainer;
		}
		if (_clientCertOptions == ClientCertificateOption.Automatic && ComNetOS.IsWin7orLater)
		{
			X509CertificateCollection x509CertificateCollection = UnsafeNclNativeMethods.NativePKI.FindClientCertificates();
			if (x509CertificateCollection.Count > 0)
			{
				webRequest.ClientCertificates = x509CertificateCollection;
			}
		}
	}

	private static void SetConnectionOptions(HttpWebRequest webRequest, HttpRequestMessage request)
	{
		if (request.Version <= HttpVersion.Version10)
		{
			bool keepAlive = false;
			foreach (string item in request.Headers.Connection)
			{
				if (string.Compare(item, "Keep-Alive", StringComparison.OrdinalIgnoreCase) == 0)
				{
					keepAlive = true;
					break;
				}
			}
			webRequest.KeepAlive = keepAlive;
		}
		else if (request.Headers.ConnectionClose == true)
		{
			webRequest.KeepAlive = false;
		}
	}

	private void SetServicePointOptions(HttpWebRequest webRequest, HttpRequestMessage request)
	{
		HttpRequestHeaders headers = request.Headers;
		ServicePoint servicePoint = null;
		bool? expectContinue = headers.ExpectContinue;
		if (expectContinue.HasValue)
		{
			servicePoint = webRequest.ServicePoint;
			servicePoint.Expect100Continue = expectContinue.Value;
		}
	}

	private static void SetRequestHeaders(HttpWebRequest webRequest, HttpRequestMessage request)
	{
		WebHeaderCollection headers = webRequest.Headers;
		HttpRequestHeaders headers2 = request.Headers;
		bool flag = headers2.Contains("Host");
		bool flag2 = headers2.Contains("Expect");
		bool flag3 = headers2.Contains("Transfer-Encoding");
		bool flag4 = headers2.Contains("Connection");
		if (flag)
		{
			string host = headers2.Host;
			if (host != null)
			{
				webRequest.Host = host;
			}
		}
		if (flag2)
		{
			string headerStringWithoutSpecial = headers2.Expect.GetHeaderStringWithoutSpecial();
			if (!string.IsNullOrEmpty(headerStringWithoutSpecial) || !headers2.Expect.IsSpecialValueSet)
			{
				headers.AddInternal("Expect", headerStringWithoutSpecial);
			}
		}
		if (flag3)
		{
			string headerStringWithoutSpecial2 = headers2.TransferEncoding.GetHeaderStringWithoutSpecial();
			if (!string.IsNullOrEmpty(headerStringWithoutSpecial2) || !headers2.TransferEncoding.IsSpecialValueSet)
			{
				headers.AddInternal("Transfer-Encoding", headerStringWithoutSpecial2);
			}
		}
		if (flag4)
		{
			string headerStringWithoutSpecial3 = headers2.Connection.GetHeaderStringWithoutSpecial();
			if (!string.IsNullOrEmpty(headerStringWithoutSpecial3) || !headers2.Connection.IsSpecialValueSet)
			{
				headers.AddInternal("Connection", headerStringWithoutSpecial3);
			}
		}
		foreach (KeyValuePair<string, string> headerString in request.Headers.GetHeaderStrings())
		{
			string key = headerString.Key;
			if ((!flag || !AreEqual("Host", key)) && (!flag2 || !AreEqual("Expect", key)) && (!flag3 || !AreEqual("Transfer-Encoding", key)) && (!flag4 || !AreEqual("Connection", key)))
			{
				headers.AddInternal(headerString.Key, headerString.Value);
			}
		}
	}

	private static void SetContentHeaders(HttpWebRequest webRequest, HttpRequestMessage request)
	{
		if (request.Content == null)
		{
			return;
		}
		HttpContentHeaders headers = request.Content.Headers;
		if (headers.Contains("Content-Length"))
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content.Headers)
			{
				if (string.Compare("Content-Length", header.Key, StringComparison.OrdinalIgnoreCase) != 0)
				{
					webRequest.Headers.AddInternal(header.Key, string.Join(", ", header.Value));
				}
			}
			return;
		}
		foreach (KeyValuePair<string, IEnumerable<string>> header2 in request.Content.Headers)
		{
			webRequest.Headers.AddInternal(header2.Key, string.Join(", ", header2.Value));
		}
	}

	protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request", System.SR.net_http_handler_norequest);
		}
		CheckDisposed();
		if (Logging.On)
		{
			Logging.Enter(Logging.Http, this, "SendAsync", request);
		}
		SetOperationStarted();
		TaskCompletionSource<HttpResponseMessage> taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
		RequestState requestState = new RequestState();
		requestState.tcs = taskCompletionSource;
		requestState.cancellationToken = cancellationToken;
		requestState.requestMessage = request;
		try
		{
			cancellationToken.Register(state: requestState.webRequest = CreateAndPrepareWebRequest(request), callback: s_onCancel);
			if (ExecutionContext.IsFlowSuppressed())
			{
				IWebProxy webProxy = null;
				if (_useProxy)
				{
					webProxy = _proxy ?? WebRequest.DefaultWebProxy;
				}
				if (UseDefaultCredentials || Credentials != null || (webProxy != null && webProxy.Credentials != null))
				{
					SafeCaptureIdenity(requestState);
				}
			}
			Task.Factory.StartNew(_startRequest, requestState);
		}
		catch (Exception e)
		{
			HandleAsyncException(requestState, e);
		}
		if (Logging.On)
		{
			Logging.Exit(Logging.Http, this, "SendAsync", taskCompletionSource.Task);
		}
		return taskCompletionSource.Task;
	}

	private void StartRequest(object obj)
	{
		RequestState requestState = obj as RequestState;
		try
		{
			if (requestState.requestMessage.Content != null)
			{
				PrepareAndStartContentUpload(requestState);
				return;
			}
			requestState.webRequest.ContentLength = 0L;
			StartGettingResponse(requestState);
		}
		catch (Exception e)
		{
			HandleAsyncException(requestState, e);
		}
	}

	private void PrepareAndStartContentUpload(RequestState state)
	{
		HttpContent requestContent = state.requestMessage.Content;
		try
		{
			if (state.requestMessage.Headers.TransferEncodingChunked == true)
			{
				state.webRequest.SendChunked = true;
				StartGettingRequestStream(state);
				return;
			}
			long? contentLength = requestContent.Headers.ContentLength;
			if (contentLength.HasValue)
			{
				state.webRequest.ContentLength = contentLength.Value;
				StartGettingRequestStream(state);
				return;
			}
			if (_maxRequestContentBufferSize == 0L)
			{
				throw new HttpRequestException(System.SR.net_http_handler_nocontentlength);
			}
			requestContent.LoadIntoBufferAsync(_maxRequestContentBufferSize).ContinueWithStandard(delegate(Task task)
			{
				if (task.IsFaulted)
				{
					HandleAsyncException(state, task.Exception.GetBaseException());
					return;
				}
				try
				{
					contentLength = requestContent.Headers.ContentLength;
					state.webRequest.ContentLength = contentLength.Value;
					StartGettingRequestStream(state);
				}
				catch (Exception e2)
				{
					HandleAsyncException(state, e2);
				}
			});
		}
		catch (Exception e)
		{
			HandleAsyncException(state, e);
		}
	}

	private void StartGettingRequestStream(RequestState state)
	{
		if (state.identity != null)
		{
			using (state.identity.Impersonate())
			{
				state.webRequest.BeginGetRequestStream(_getRequestStreamCallback, state);
				return;
			}
		}
		state.webRequest.BeginGetRequestStream(_getRequestStreamCallback, state);
	}

	private void GetRequestStreamCallback(IAsyncResult ar)
	{
		RequestState state = ar.AsyncState as RequestState;
		try
		{
			TransportContext context = null;
			Stream stream = state.webRequest.EndGetRequestStream(ar, out context);
			state.requestStream = stream;
			state.requestMessage.Content.CopyToAsync(stream, context).ContinueWithStandard(delegate(Task task)
			{
				try
				{
					if (task.IsFaulted)
					{
						HandleAsyncException(state, task.Exception.GetBaseException());
					}
					else if (task.IsCanceled)
					{
						state.tcs.TrySetCanceled();
					}
					else
					{
						state.requestStream.Close();
						StartGettingResponse(state);
					}
				}
				catch (Exception e2)
				{
					HandleAsyncException(state, e2);
				}
			});
		}
		catch (Exception e)
		{
			HandleAsyncException(state, e);
		}
	}

	private void StartGettingResponse(RequestState state)
	{
		if (state.identity != null)
		{
			using (state.identity.Impersonate())
			{
				state.webRequest.BeginGetResponse(_getResponseCallback, state);
				return;
			}
		}
		state.webRequest.BeginGetResponse(_getResponseCallback, state);
	}

	private void GetResponseCallback(IAsyncResult ar)
	{
		RequestState requestState = ar.AsyncState as RequestState;
		try
		{
			HttpWebResponse webResponse = requestState.webRequest.EndGetResponse(ar) as HttpWebResponse;
			requestState.tcs.TrySetResult(CreateResponseMessage(webResponse, requestState.requestMessage));
		}
		catch (Exception e)
		{
			HandleAsyncException(requestState, e);
		}
	}

	private HttpResponseMessage CreateResponseMessage(HttpWebResponse webResponse, HttpRequestMessage request)
	{
		HttpResponseMessage httpResponseMessage = new HttpResponseMessage(webResponse.StatusCode);
		httpResponseMessage.ReasonPhrase = webResponse.StatusDescription;
		httpResponseMessage.Version = webResponse.ProtocolVersion;
		httpResponseMessage.RequestMessage = request;
		httpResponseMessage.Content = new StreamContent(new WebExceptionWrapperStream(webResponse.GetResponseStream()));
		request.RequestUri = webResponse.ResponseUri;
		WebHeaderCollection headers = webResponse.Headers;
		HttpContentHeaders headers2 = httpResponseMessage.Content.Headers;
		HttpResponseHeaders headers3 = httpResponseMessage.Headers;
		if (webResponse.ContentLength >= 0)
		{
			headers2.ContentLength = webResponse.ContentLength;
		}
		for (int i = 0; i < headers.Count; i++)
		{
			string key = headers.GetKey(i);
			if (string.Compare(key, "Content-Length", StringComparison.OrdinalIgnoreCase) != 0)
			{
				string[] values = headers.GetValues(i);
				if (!headers3.TryAddWithoutValidation(key, values))
				{
					bool flag = headers2.TryAddWithoutValidation(key, values);
				}
			}
		}
		return httpResponseMessage;
	}

	private void HandleAsyncException(RequestState state, Exception e)
	{
		if (Logging.On)
		{
			Logging.Exception(Logging.Http, this, "SendAsync", e);
		}
		if (state.cancellationToken.IsCancellationRequested)
		{
			state.tcs.TrySetCanceled();
		}
		else if (e is WebException || e is IOException)
		{
			state.tcs.TrySetException(new HttpRequestException(System.SR.net_http_client_execution_error, e));
		}
		else
		{
			state.tcs.TrySetException(e);
		}
	}

	private static void OnCancel(object state)
	{
		HttpWebRequest httpWebRequest = state as HttpWebRequest;
		httpWebRequest.Abort();
	}

	private void SetOperationStarted()
	{
		if (!_operationStarted)
		{
			_operationStarted = true;
		}
	}

	private void CheckDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
	}

	internal void CheckDisposedOrStarted()
	{
		CheckDisposed();
		if (_operationStarted)
		{
			throw new InvalidOperationException(System.SR.net_http_operation_started);
		}
	}

	private static bool AreEqual(string x, string y)
	{
		return string.Compare(x, y, StringComparison.OrdinalIgnoreCase) == 0;
	}

	[SecuritySafeCritical]
	[SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.ControlPrincipal)]
	private void SafeCaptureIdenity(RequestState state)
	{
		state.identity = WindowsIdentity.GetCurrent();
	}
}
