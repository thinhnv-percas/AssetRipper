using System.Collections.Generic;

namespace System.Net.Http.Headers;

public sealed class HttpRequestHeaders : HttpHeaders
{
	private static readonly Dictionary<string, HttpHeaderParser> s_parserStore = CreateParserStore();

	private static readonly HashSet<string> s_invalidHeaders = CreateInvalidHeaders();

	private HttpGeneralHeaders _generalHeaders;

	private HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> _accept;

	private HttpHeaderValueCollection<NameValueWithParametersHeaderValue> _expect;

	private bool _expectContinueSet;

	private HttpHeaderValueCollection<EntityTagHeaderValue> _ifMatch;

	private HttpHeaderValueCollection<EntityTagHeaderValue> _ifNoneMatch;

	private HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> _te;

	private HttpHeaderValueCollection<ProductInfoHeaderValue> _userAgent;

	private HttpHeaderValueCollection<StringWithQualityHeaderValue> _acceptCharset;

	private HttpHeaderValueCollection<StringWithQualityHeaderValue> _acceptEncoding;

	private HttpHeaderValueCollection<StringWithQualityHeaderValue> _acceptLanguage;

	public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept
	{
		get
		{
			if (_accept == null)
			{
				_accept = new HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue>("Accept", this);
			}
			return _accept;
		}
	}

	public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset
	{
		get
		{
			if (_acceptCharset == null)
			{
				_acceptCharset = new HttpHeaderValueCollection<StringWithQualityHeaderValue>("Accept-Charset", this);
			}
			return _acceptCharset;
		}
	}

	public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding
	{
		get
		{
			if (_acceptEncoding == null)
			{
				_acceptEncoding = new HttpHeaderValueCollection<StringWithQualityHeaderValue>("Accept-Encoding", this);
			}
			return _acceptEncoding;
		}
	}

	public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage
	{
		get
		{
			if (_acceptLanguage == null)
			{
				_acceptLanguage = new HttpHeaderValueCollection<StringWithQualityHeaderValue>("Accept-Language", this);
			}
			return _acceptLanguage;
		}
	}

	public AuthenticationHeaderValue Authorization
	{
		get
		{
			return (AuthenticationHeaderValue)GetParsedValues("Authorization");
		}
		set
		{
			SetOrRemoveParsedValue("Authorization", value);
		}
	}

	public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect => ExpectCore;

	public bool? ExpectContinue
	{
		get
		{
			if (ExpectCore.IsSpecialValueSet)
			{
				return true;
			}
			if (_expectContinueSet)
			{
				return false;
			}
			return null;
		}
		set
		{
			if (value == true)
			{
				_expectContinueSet = true;
				ExpectCore.SetSpecialValue();
			}
			else
			{
				_expectContinueSet = value.HasValue;
				ExpectCore.RemoveSpecialValue();
			}
		}
	}

	public string From
	{
		get
		{
			return (string)GetParsedValues("From");
		}
		set
		{
			if (value == string.Empty)
			{
				value = null;
			}
			if (value != null && !HeaderUtilities.IsValidEmailAddress(value))
			{
				throw new FormatException(System.SR.net_http_headers_invalid_from_header);
			}
			SetOrRemoveParsedValue("From", value);
		}
	}

	public string Host
	{
		get
		{
			return (string)GetParsedValues("Host");
		}
		set
		{
			if (value == string.Empty)
			{
				value = null;
			}
			string host = null;
			if (value != null && HttpRuleParser.GetHostLength(value, 0, allowToken: false, out host) != value.Length)
			{
				throw new FormatException(System.SR.net_http_headers_invalid_host_header);
			}
			SetOrRemoveParsedValue("Host", value);
		}
	}

	public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch
	{
		get
		{
			if (_ifMatch == null)
			{
				_ifMatch = new HttpHeaderValueCollection<EntityTagHeaderValue>("If-Match", this);
			}
			return _ifMatch;
		}
	}

	public DateTimeOffset? IfModifiedSince
	{
		get
		{
			return HeaderUtilities.GetDateTimeOffsetValue("If-Modified-Since", this);
		}
		set
		{
			SetOrRemoveParsedValue("If-Modified-Since", value);
		}
	}

	public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch
	{
		get
		{
			if (_ifNoneMatch == null)
			{
				_ifNoneMatch = new HttpHeaderValueCollection<EntityTagHeaderValue>("If-None-Match", this);
			}
			return _ifNoneMatch;
		}
	}

	public RangeConditionHeaderValue IfRange
	{
		get
		{
			return (RangeConditionHeaderValue)GetParsedValues("If-Range");
		}
		set
		{
			SetOrRemoveParsedValue("If-Range", value);
		}
	}

	public DateTimeOffset? IfUnmodifiedSince
	{
		get
		{
			return HeaderUtilities.GetDateTimeOffsetValue("If-Unmodified-Since", this);
		}
		set
		{
			SetOrRemoveParsedValue("If-Unmodified-Since", value);
		}
	}

	public int? MaxForwards
	{
		get
		{
			object parsedValues = GetParsedValues("Max-Forwards");
			if (parsedValues != null)
			{
				return (int)parsedValues;
			}
			return null;
		}
		set
		{
			SetOrRemoveParsedValue("Max-Forwards", value);
		}
	}

	public AuthenticationHeaderValue ProxyAuthorization
	{
		get
		{
			return (AuthenticationHeaderValue)GetParsedValues("Proxy-Authorization");
		}
		set
		{
			SetOrRemoveParsedValue("Proxy-Authorization", value);
		}
	}

	public RangeHeaderValue Range
	{
		get
		{
			return (RangeHeaderValue)GetParsedValues("Range");
		}
		set
		{
			SetOrRemoveParsedValue("Range", value);
		}
	}

	public Uri Referrer
	{
		get
		{
			return (Uri)GetParsedValues("Referer");
		}
		set
		{
			SetOrRemoveParsedValue("Referer", value);
		}
	}

	public HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE
	{
		get
		{
			if (_te == null)
			{
				_te = new HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue>("TE", this);
			}
			return _te;
		}
	}

	public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent
	{
		get
		{
			if (_userAgent == null)
			{
				_userAgent = new HttpHeaderValueCollection<ProductInfoHeaderValue>("User-Agent", this);
			}
			return _userAgent;
		}
	}

	private HttpHeaderValueCollection<NameValueWithParametersHeaderValue> ExpectCore
	{
		get
		{
			if (_expect == null)
			{
				_expect = new HttpHeaderValueCollection<NameValueWithParametersHeaderValue>("Expect", this, HeaderUtilities.ExpectContinue);
			}
			return _expect;
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

	internal HttpRequestHeaders()
	{
		_generalHeaders = new HttpGeneralHeaders(this);
		SetConfiguration(s_parserStore, s_invalidHeaders);
	}

	private static Dictionary<string, HttpHeaderParser> CreateParserStore()
	{
		Dictionary<string, HttpHeaderParser> dictionary = new Dictionary<string, HttpHeaderParser>(StringComparer.OrdinalIgnoreCase);
		dictionary.Add("Accept", MediaTypeHeaderParser.MultipleValuesParser);
		dictionary.Add("Accept-Charset", GenericHeaderParser.MultipleValueStringWithQualityParser);
		dictionary.Add("Accept-Encoding", GenericHeaderParser.MultipleValueStringWithQualityParser);
		dictionary.Add("Accept-Language", GenericHeaderParser.MultipleValueStringWithQualityParser);
		dictionary.Add("Authorization", GenericHeaderParser.SingleValueAuthenticationParser);
		dictionary.Add("Expect", GenericHeaderParser.MultipleValueNameValueWithParametersParser);
		dictionary.Add("From", GenericHeaderParser.MailAddressParser);
		dictionary.Add("Host", GenericHeaderParser.HostParser);
		dictionary.Add("If-Match", GenericHeaderParser.MultipleValueEntityTagParser);
		dictionary.Add("If-Modified-Since", DateHeaderParser.Parser);
		dictionary.Add("If-None-Match", GenericHeaderParser.MultipleValueEntityTagParser);
		dictionary.Add("If-Range", GenericHeaderParser.RangeConditionParser);
		dictionary.Add("If-Unmodified-Since", DateHeaderParser.Parser);
		dictionary.Add("Max-Forwards", Int32NumberHeaderParser.Parser);
		dictionary.Add("Proxy-Authorization", GenericHeaderParser.SingleValueAuthenticationParser);
		dictionary.Add("Range", GenericHeaderParser.RangeParser);
		dictionary.Add("Referer", UriHeaderParser.RelativeOrAbsoluteUriParser);
		dictionary.Add("TE", TransferCodingHeaderParser.MultipleValueWithQualityParser);
		dictionary.Add("User-Agent", ProductInfoHeaderParser.MultipleValueParser);
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
		headerSet.Add("Accept");
		headerSet.Add("Accept-Charset");
		headerSet.Add("Accept-Encoding");
		headerSet.Add("Accept-Language");
		headerSet.Add("Authorization");
		headerSet.Add("Expect");
		headerSet.Add("From");
		headerSet.Add("Host");
		headerSet.Add("If-Match");
		headerSet.Add("If-Modified-Since");
		headerSet.Add("If-None-Match");
		headerSet.Add("If-Range");
		headerSet.Add("If-Unmodified-Since");
		headerSet.Add("Max-Forwards");
		headerSet.Add("Proxy-Authorization");
		headerSet.Add("Range");
		headerSet.Add("Referer");
		headerSet.Add("TE");
		headerSet.Add("User-Agent");
	}

	internal override void AddHeaders(HttpHeaders sourceHeaders)
	{
		base.AddHeaders(sourceHeaders);
		HttpRequestHeaders httpRequestHeaders = sourceHeaders as HttpRequestHeaders;
		_generalHeaders.AddSpecialsFrom(httpRequestHeaders._generalHeaders);
		if (!ExpectContinue.HasValue)
		{
			ExpectContinue = httpRequestHeaders.ExpectContinue;
		}
	}
}
