namespace System.Net.Http;

public class HttpMethod : IEquatable<HttpMethod>
{
	private readonly string _method;

	private int _hashcode;

	private static readonly HttpMethod s_getMethod = new HttpMethod("GET");

	private static readonly HttpMethod s_putMethod = new HttpMethod("PUT");

	private static readonly HttpMethod s_postMethod = new HttpMethod("POST");

	private static readonly HttpMethod s_deleteMethod = new HttpMethod("DELETE");

	private static readonly HttpMethod s_headMethod = new HttpMethod("HEAD");

	private static readonly HttpMethod s_optionsMethod = new HttpMethod("OPTIONS");

	private static readonly HttpMethod s_traceMethod = new HttpMethod("TRACE");

	public static HttpMethod Get => s_getMethod;

	public static HttpMethod Put => s_putMethod;

	public static HttpMethod Post => s_postMethod;

	public static HttpMethod Delete => s_deleteMethod;

	public static HttpMethod Head => s_headMethod;

	public static HttpMethod Options => s_optionsMethod;

	public static HttpMethod Trace => s_traceMethod;

	public string Method => _method;

	public HttpMethod(string method)
	{
		if (string.IsNullOrEmpty(method))
		{
			throw new ArgumentException(System.SR.net_http_argument_empty_string, "method");
		}
		if (HttpRuleParser.GetTokenLength(method, 0) != method.Length)
		{
			throw new FormatException(System.SR.net_http_httpmethod_format_error);
		}
		_method = method;
	}

	public bool Equals(HttpMethod other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)_method == other._method)
		{
			return true;
		}
		return string.Equals(_method, other._method, StringComparison.OrdinalIgnoreCase);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as HttpMethod);
	}

	public override int GetHashCode()
	{
		if (_hashcode == 0)
		{
			_hashcode = (IsUpperAscii(_method) ? _method.GetHashCode() : _method.ToUpperInvariant().GetHashCode());
		}
		return _hashcode;
	}

	public override string ToString()
	{
		return _method.ToString();
	}

	public static bool operator ==(HttpMethod left, HttpMethod right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		if ((object)right == null)
		{
			return (object)left == null;
		}
		return left.Equals(right);
	}

	public static bool operator !=(HttpMethod left, HttpMethod right)
	{
		return !(left == right);
	}

	private static bool IsUpperAscii(string value)
	{
		foreach (char c in value)
		{
			if (c < 'A' || c > 'Z')
			{
				return false;
			}
		}
		return true;
	}
}
