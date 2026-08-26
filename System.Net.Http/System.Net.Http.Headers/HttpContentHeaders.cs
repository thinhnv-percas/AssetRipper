using System.Collections.Generic;

namespace System.Net.Http.Headers;

public sealed class HttpContentHeaders : HttpHeaders
{
	private static readonly Dictionary<string, HttpHeaderParser> s_parserStore = CreateParserStore();

	private static readonly HashSet<string> s_invalidHeaders = CreateInvalidHeaders();

	private readonly HttpContent _parent;

	private bool _contentLengthSet;

	private HttpHeaderValueCollection<string> _allow;

	private HttpHeaderValueCollection<string> _contentEncoding;

	private HttpHeaderValueCollection<string> _contentLanguage;

	public ICollection<string> Allow
	{
		get
		{
			if (_allow == null)
			{
				_allow = new HttpHeaderValueCollection<string>("Allow", this, HeaderUtilities.TokenValidator);
			}
			return _allow;
		}
	}

	public ContentDispositionHeaderValue ContentDisposition
	{
		get
		{
			return (ContentDispositionHeaderValue)GetParsedValues("Content-Disposition");
		}
		set
		{
			SetOrRemoveParsedValue("Content-Disposition", value);
		}
	}

	public ICollection<string> ContentEncoding
	{
		get
		{
			if (_contentEncoding == null)
			{
				_contentEncoding = new HttpHeaderValueCollection<string>("Content-Encoding", this, HeaderUtilities.TokenValidator);
			}
			return _contentEncoding;
		}
	}

	public ICollection<string> ContentLanguage
	{
		get
		{
			if (_contentLanguage == null)
			{
				_contentLanguage = new HttpHeaderValueCollection<string>("Content-Language", this, HeaderUtilities.TokenValidator);
			}
			return _contentLanguage;
		}
	}

	public long? ContentLength
	{
		get
		{
			object parsedValues = GetParsedValues("Content-Length");
			if (!_contentLengthSet && parsedValues == null)
			{
				long? computedOrBufferLength = _parent.GetComputedOrBufferLength();
				if (computedOrBufferLength.HasValue)
				{
					SetParsedValue("Content-Length", computedOrBufferLength.Value);
				}
				return computedOrBufferLength;
			}
			if (parsedValues == null)
			{
				return null;
			}
			return (long)parsedValues;
		}
		set
		{
			SetOrRemoveParsedValue("Content-Length", value);
			_contentLengthSet = true;
		}
	}

	public Uri ContentLocation
	{
		get
		{
			return (Uri)GetParsedValues("Content-Location");
		}
		set
		{
			SetOrRemoveParsedValue("Content-Location", value);
		}
	}

	public byte[] ContentMD5
	{
		get
		{
			return (byte[])GetParsedValues("Content-MD5");
		}
		set
		{
			SetOrRemoveParsedValue("Content-MD5", value);
		}
	}

	public ContentRangeHeaderValue ContentRange
	{
		get
		{
			return (ContentRangeHeaderValue)GetParsedValues("Content-Range");
		}
		set
		{
			SetOrRemoveParsedValue("Content-Range", value);
		}
	}

	public MediaTypeHeaderValue ContentType
	{
		get
		{
			return (MediaTypeHeaderValue)GetParsedValues("Content-Type");
		}
		set
		{
			SetOrRemoveParsedValue("Content-Type", value);
		}
	}

	public DateTimeOffset? Expires
	{
		get
		{
			return HeaderUtilities.GetDateTimeOffsetValue("Expires", this);
		}
		set
		{
			SetOrRemoveParsedValue("Expires", value);
		}
	}

	public DateTimeOffset? LastModified
	{
		get
		{
			return HeaderUtilities.GetDateTimeOffsetValue("Last-Modified", this);
		}
		set
		{
			SetOrRemoveParsedValue("Last-Modified", value);
		}
	}

	internal HttpContentHeaders(HttpContent parent)
	{
		_parent = parent;
		SetConfiguration(s_parserStore, s_invalidHeaders);
	}

	private static Dictionary<string, HttpHeaderParser> CreateParserStore()
	{
		Dictionary<string, HttpHeaderParser> dictionary = new Dictionary<string, HttpHeaderParser>(11, StringComparer.OrdinalIgnoreCase);
		dictionary.Add("Allow", GenericHeaderParser.TokenListParser);
		dictionary.Add("Content-Disposition", GenericHeaderParser.ContentDispositionParser);
		dictionary.Add("Content-Encoding", GenericHeaderParser.TokenListParser);
		dictionary.Add("Content-Language", GenericHeaderParser.TokenListParser);
		dictionary.Add("Content-Length", Int64NumberHeaderParser.Parser);
		dictionary.Add("Content-Location", UriHeaderParser.RelativeOrAbsoluteUriParser);
		dictionary.Add("Content-MD5", ByteArrayHeaderParser.Parser);
		dictionary.Add("Content-Range", GenericHeaderParser.ContentRangeParser);
		dictionary.Add("Content-Type", MediaTypeHeaderParser.SingleValueParser);
		dictionary.Add("Expires", DateHeaderParser.Parser);
		dictionary.Add("Last-Modified", DateHeaderParser.Parser);
		return dictionary;
	}

	private static HashSet<string> CreateInvalidHeaders()
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HttpRequestHeaders.AddKnownHeaders(hashSet);
		HttpResponseHeaders.AddKnownHeaders(hashSet);
		HttpGeneralHeaders.AddKnownHeaders(hashSet);
		return hashSet;
	}

	internal static void AddKnownHeaders(HashSet<string> headerSet)
	{
		headerSet.Add("Allow");
		headerSet.Add("Content-Disposition");
		headerSet.Add("Content-Encoding");
		headerSet.Add("Content-Language");
		headerSet.Add("Content-Length");
		headerSet.Add("Content-Location");
		headerSet.Add("Content-MD5");
		headerSet.Add("Content-Range");
		headerSet.Add("Content-Type");
		headerSet.Add("Expires");
		headerSet.Add("Last-Modified");
	}
}
