using System.Collections.Generic;

namespace System.Net.Http.Headers;

public sealed class HttpResponseHeaders : HttpHeaders
{
	private static readonly Dictionary<string, HttpHeaderParser> s_parserStore = CreateParserStore();

	private static readonly HashSet<string> s_invalidHeaders = CreateInvalidHeaders();

	private HttpGeneralHeaders _generalHeaders;

	private HttpHeaderValueCollection<string> _acceptRanges;

	private HttpHeaderValueCollection<AuthenticationHeaderValue> _wwwAuthenticate;

	private HttpHeaderValueCollection<AuthenticationHeaderValue> _proxyAuthenticate;

	private HttpHeaderValueCollection<ProductInfoHeaderValue> _server;

	private HttpHeaderValueCollection<string> _vary;

	public HttpHeaderValueCollection<string> AcceptRanges
	{
		get
		{
			if (_acceptRanges == null)
			{
				_acceptRanges = new HttpHeaderValueCollection<string>("Accept-Ranges", this, HeaderUtilities.TokenValidator);
			}
			return _acceptRanges;
		}
	}

	public TimeSpan? Age
	{
		get
		{
			return HeaderUtilities.GetTimeSpanValue("Age", this);
		}
		set
		{
			SetOrRemoveParsedValue("Age", value);
		}
	}

	public EntityTagHeaderValue ETag
	{
		get
		{
			return (EntityTagHeaderValue)GetParsedValues("ETag");
		}
		set
		{
			SetOrRemoveParsedValue("ETag", value);
		}
	}

	public Uri Location
	{
		get
		{
			return (Uri)GetParsedValues("Location");
		}
		set
		{
			SetOrRemoveParsedValue("Location", value);
		}
	}

	public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate
	{
		get
		{
			if (_proxyAuthenticate == null)
			{
				_proxyAuthenticate = new HttpHeaderValueCollection<AuthenticationHeaderValue>("Proxy-Authenticate", this);
			}
			return _proxyAuthenticate;
		}
	}

	public RetryConditionHeaderValue RetryAfter
	{
		get
		{
			return (RetryConditionHeaderValue)GetParsedValues("Retry-After");
		}
		set
		{
			SetOrRemoveParsedValue("Retry-After", value);
		}
	}

	public HttpHeaderValueCollection<ProductInfoHeaderValue> Server
	{
		get
		{
			if (_server == null)
			{
				_server = new HttpHeaderValueCollection<ProductInfoHeaderValue>("Server", this);
			}
			return _server;
		}
	}

	public HttpHeaderValueCollection<string> Vary
	{
		get
		{
			if (_vary == null)
			{
				_vary = new HttpHeaderValueCollection<string>("Vary", this, HeaderUtilities.TokenValidator);
			}
			return _vary;
		}
	}

	public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate
	{
		get
		{
			if (_wwwAuthenticate == null)
			{
				_wwwAuthenticate = new HttpHeaderValueCollection<AuthenticationHeaderValue>("WWW-Authenticate", this);
			}
			return _wwwAuthenticate;
		}
	}

	public CacheControlHeaderValue CacheControl
	{
		get
		{
			return _generalHeaders.CacheControl;
		}
		set
		{
			_generalHeaders.CacheControl = value;
		}
	}

	public HttpHeaderValueCollection<string> Connection => _generalHeaders.Connection;

	public bool? ConnectionClose
	{
		get
		{
			return _generalHeaders.ConnectionClose;
		}
		set
		{
			_generalHeaders.ConnectionClose = value;
		}
	}

	public DateTimeOffset? Date
	{
		get
		{
			return _generalHeaders.Date;
		}
		set
		{
			_generalHeaders.Date = value;
		}
	}

	public HttpHeaderValueCollection<NameValueHeaderValue> Pragma => _generalHeaders.Pragma;

	public HttpHeaderValueCollection<string> Trailer => _generalHeaders.Trailer;

	public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding => _generalHeaders.TransferEncoding;

	public bool? TransferEncodingChunked
	{
		get
		{
			return _generalHeaders.TransferEncodingChunked;
		}
		set
		{
			_generalHeaders.TransferEncodingChunked = value;
		}
	}

	public HttpHeaderValueCollection<ProductHeaderValue> Upgrade => _generalHeaders.Upgrade;

	public HttpHeaderValueCollection<ViaHeaderValue> Via => _generalHeaders.Via;

	public HttpHeaderValueCollection<WarningHeaderValue> Warning => _generalHeaders.Warning;

	internal HttpResponseHeaders()
	{
		_generalHeaders = new HttpGeneralHeaders(this);
		SetConfiguration(s_parserStore, s_invalidHeaders);
	}

	private static Dictionary<string, HttpHeaderParser> CreateParserStore()
	{
		Dictionary<string, HttpHeaderParser> dictionary = new Dictionary<string, HttpHeaderParser>(StringComparer.OrdinalIgnoreCase);
		dictionary.Add("Accept-Ranges", GenericHeaderParser.TokenListParser);
		dictionary.Add("Age", TimeSpanHeaderParser.Parser);
		dictionary.Add("ETag", GenericHeaderParser.SingleValueEntityTagParser);
		dictionary.Add("Location", UriHeaderParser.RelativeOrAbsoluteUriParser);
		dictionary.Add("Proxy-Authenticate", GenericHeaderParser.MultipleValueAuthenticationParser);
		dictionary.Add("Retry-After", GenericHeaderParser.RetryConditionParser);
		dictionary.Add("Server", ProductInfoHeaderParser.MultipleValueParser);
		dictionary.Add("Vary", GenericHeaderParser.TokenListParser);
		dictionary.Add("WWW-Authenticate", GenericHeaderParser.MultipleValueAuthenticationParser);
		HttpGeneralHeaders.AddParsers(dictionary);
		return dictionary;
	}

	private static HashSet<string> CreateInvalidHeaders()
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HttpContentHeaders.AddKnownHeaders(hashSet);
		return hashSet;
	}

	internal static void AddKnownHeaders(HashSet<string> headerSet)
	{
		headerSet.Add("Accept-Ranges");
		headerSet.Add("Age");
		headerSet.Add("ETag");
		headerSet.Add("Location");
		headerSet.Add("Proxy-Authenticate");
		headerSet.Add("Retry-After");
		headerSet.Add("Server");
		headerSet.Add("Vary");
		headerSet.Add("WWW-Authenticate");
	}

	internal override void AddHeaders(HttpHeaders sourceHeaders)
	{
		base.AddHeaders(sourceHeaders);
		HttpResponseHeaders httpResponseHeaders = sourceHeaders as HttpResponseHeaders;
		_generalHeaders.AddSpecialsFrom(httpResponseHeaders._generalHeaders);
	}
}
