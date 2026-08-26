using System.Collections.Generic;

namespace System.Net.Http.Headers;

internal sealed class HttpGeneralHeaders
{
	private HttpHeaderValueCollection<string> _connection;

	private HttpHeaderValueCollection<string> _trailer;

	private HttpHeaderValueCollection<TransferCodingHeaderValue> _transferEncoding;

	private HttpHeaderValueCollection<ProductHeaderValue> _upgrade;

	private HttpHeaderValueCollection<ViaHeaderValue> _via;

	private HttpHeaderValueCollection<WarningHeaderValue> _warning;

	private HttpHeaderValueCollection<NameValueHeaderValue> _pragma;

	private HttpHeaders _parent;

	private bool _transferEncodingChunkedSet;

	private bool _connectionCloseSet;

	public CacheControlHeaderValue CacheControl
	{
		get
		{
			return (CacheControlHeaderValue)_parent.GetParsedValues("Cache-Control");
		}
		set
		{
			_parent.SetOrRemoveParsedValue("Cache-Control", value);
		}
	}

	public HttpHeaderValueCollection<string> Connection => ConnectionCore;

	public bool? ConnectionClose
	{
		get
		{
			if (_connection != null)
			{
				if (_connection.IsSpecialValueSet)
				{
					return true;
				}
			}
			else if (_parent.ContainsParsedValue("Connection", "close"))
			{
				return true;
			}
			if (_connectionCloseSet)
			{
				return false;
			}
			return null;
		}
		set
		{
			if (value == true)
			{
				_connectionCloseSet = true;
				ConnectionCore.SetSpecialValue();
			}
			else
			{
				_connectionCloseSet = value.HasValue;
				ConnectionCore.RemoveSpecialValue();
			}
		}
	}

	public DateTimeOffset? Date
	{
		get
		{
			return HeaderUtilities.GetDateTimeOffsetValue("Date", _parent);
		}
		set
		{
			_parent.SetOrRemoveParsedValue("Date", value);
		}
	}

	public HttpHeaderValueCollection<NameValueHeaderValue> Pragma
	{
		get
		{
			if (_pragma == null)
			{
				_pragma = new HttpHeaderValueCollection<NameValueHeaderValue>("Pragma", _parent);
			}
			return _pragma;
		}
	}

	public HttpHeaderValueCollection<string> Trailer
	{
		get
		{
			if (_trailer == null)
			{
				_trailer = new HttpHeaderValueCollection<string>("Trailer", _parent, HeaderUtilities.TokenValidator);
			}
			return _trailer;
		}
	}

	public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding => TransferEncodingCore;

	public bool? TransferEncodingChunked
	{
		get
		{
			if (_transferEncoding != null)
			{
				if (_transferEncoding.IsSpecialValueSet)
				{
					return true;
				}
			}
			else if (_parent.ContainsParsedValue("Transfer-Encoding", HeaderUtilities.TransferEncodingChunked))
			{
				return true;
			}
			if (_transferEncodingChunkedSet)
			{
				return false;
			}
			return null;
		}
		set
		{
			if (value == true)
			{
				_transferEncodingChunkedSet = true;
				TransferEncodingCore.SetSpecialValue();
			}
			else
			{
				_transferEncodingChunkedSet = value.HasValue;
				TransferEncodingCore.RemoveSpecialValue();
			}
		}
	}

	public HttpHeaderValueCollection<ProductHeaderValue> Upgrade
	{
		get
		{
			if (_upgrade == null)
			{
				_upgrade = new HttpHeaderValueCollection<ProductHeaderValue>("Upgrade", _parent);
			}
			return _upgrade;
		}
	}

	public HttpHeaderValueCollection<ViaHeaderValue> Via
	{
		get
		{
			if (_via == null)
			{
				_via = new HttpHeaderValueCollection<ViaHeaderValue>("Via", _parent);
			}
			return _via;
		}
	}

	public HttpHeaderValueCollection<WarningHeaderValue> Warning
	{
		get
		{
			if (_warning == null)
			{
				_warning = new HttpHeaderValueCollection<WarningHeaderValue>("Warning", _parent);
			}
			return _warning;
		}
	}

	private HttpHeaderValueCollection<string> ConnectionCore
	{
		get
		{
			if (_connection == null)
			{
				_connection = new HttpHeaderValueCollection<string>("Connection", _parent, "close", HeaderUtilities.TokenValidator);
			}
			return _connection;
		}
	}

	private HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncodingCore
	{
		get
		{
			if (_transferEncoding == null)
			{
				_transferEncoding = new HttpHeaderValueCollection<TransferCodingHeaderValue>("Transfer-Encoding", _parent, HeaderUtilities.TransferEncodingChunked);
			}
			return _transferEncoding;
		}
	}

	internal HttpGeneralHeaders(HttpHeaders parent)
	{
		_parent = parent;
	}

	internal static void AddParsers(Dictionary<string, HttpHeaderParser> parserStore)
	{
		parserStore.Add("Cache-Control", CacheControlHeaderParser.Parser);
		parserStore.Add("Connection", GenericHeaderParser.TokenListParser);
		parserStore.Add("Date", DateHeaderParser.Parser);
		parserStore.Add("Pragma", GenericHeaderParser.MultipleValueNameValueParser);
		parserStore.Add("Trailer", GenericHeaderParser.TokenListParser);
		parserStore.Add("Transfer-Encoding", TransferCodingHeaderParser.MultipleValueParser);
		parserStore.Add("Upgrade", GenericHeaderParser.MultipleValueProductParser);
		parserStore.Add("Via", GenericHeaderParser.MultipleValueViaParser);
		parserStore.Add("Warning", GenericHeaderParser.MultipleValueWarningParser);
	}

	internal static void AddKnownHeaders(HashSet<string> headerSet)
	{
		headerSet.Add("Cache-Control");
		headerSet.Add("Connection");
		headerSet.Add("Date");
		headerSet.Add("Pragma");
		headerSet.Add("Trailer");
		headerSet.Add("Transfer-Encoding");
		headerSet.Add("Upgrade");
		headerSet.Add("Via");
		headerSet.Add("Warning");
	}

	internal void AddSpecialsFrom(HttpGeneralHeaders sourceHeaders)
	{
		if (!TransferEncodingChunked.HasValue)
		{
			TransferEncodingChunked = sourceHeaders.TransferEncodingChunked;
		}
		if (!ConnectionClose.HasValue)
		{
			ConnectionClose = sourceHeaders.ConnectionClose;
		}
	}
}
