using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using System.Text;

namespace System.Net.Http.Headers;

internal static class HeaderUtilities
{
	private const string qualityName = "q";

	internal const string ConnectionClose = "close";

	internal static readonly TransferCodingHeaderValue TransferEncodingChunked = new TransferCodingHeaderValue("chunked");

	internal static readonly NameValueWithParametersHeaderValue ExpectContinue = new NameValueWithParametersHeaderValue("100-continue");

	internal const string BytesUnit = "bytes";

	internal static readonly Action<HttpHeaderValueCollection<string>, string> TokenValidator = ValidateToken;

	internal static void SetQuality(ObjectCollection<NameValueHeaderValue> parameters, double? value)
	{
		NameValueHeaderValue nameValueHeaderValue = NameValueHeaderValue.Find(parameters, "q");
		if (value.HasValue)
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			string value2 = value.Value.ToString("0.0##", NumberFormatInfo.InvariantInfo);
			if (nameValueHeaderValue != null)
			{
				nameValueHeaderValue.Value = value2;
			}
			else
			{
				parameters.Add(new NameValueHeaderValue("q", value2));
			}
		}
		else if (nameValueHeaderValue != null)
		{
			parameters.Remove(nameValueHeaderValue);
		}
	}

	internal static double? GetQuality(ObjectCollection<NameValueHeaderValue> parameters)
	{
		NameValueHeaderValue nameValueHeaderValue = NameValueHeaderValue.Find(parameters, "q");
		if (nameValueHeaderValue != null)
		{
			double result = 0.0;
			if (double.TryParse(nameValueHeaderValue.Value, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result))
			{
				return result;
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(null, System.SR.Format(System.SR.net_http_log_headers_invalid_quality, nameValueHeaderValue.Value), "GetQuality");
			}
		}
		return null;
	}

	internal static void CheckValidToken(string value, string parameterName)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentException(System.SR.net_http_argument_empty_string, parameterName);
		}
		if (HttpRuleParser.GetTokenLength(value, 0) != value.Length)
		{
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_headers_invalid_value, value));
		}
	}

	internal static void CheckValidComment(string value, string parameterName)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentException(System.SR.net_http_argument_empty_string, parameterName);
		}
		int length = 0;
		if (HttpRuleParser.GetCommentLength(value, 0, out length) != HttpParseResult.Parsed || length != value.Length)
		{
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_headers_invalid_value, value));
		}
	}

	internal static void CheckValidQuotedString(string value, string parameterName)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentException(System.SR.net_http_argument_empty_string, parameterName);
		}
		int length = 0;
		if (HttpRuleParser.GetQuotedStringLength(value, 0, out length) != HttpParseResult.Parsed || length != value.Length)
		{
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_headers_invalid_value, value));
		}
	}

	internal static bool AreEqualCollections<T>(ObjectCollection<T> x, ObjectCollection<T> y) where T : class
	{
		return AreEqualCollections(x, y, null);
	}

	internal static bool AreEqualCollections<T>(ObjectCollection<T> x, ObjectCollection<T> y, IEqualityComparer<T> comparer) where T : class
	{
		if (x == null)
		{
			if (y != null)
			{
				return y.Count == 0;
			}
			return true;
		}
		if (y == null)
		{
			return x.Count == 0;
		}
		if (x.Count != y.Count)
		{
			return false;
		}
		if (x.Count == 0)
		{
			return true;
		}
		bool[] array = new bool[x.Count];
		int num = 0;
		foreach (T item in x)
		{
			num = 0;
			bool flag = false;
			foreach (T item2 in y)
			{
				if (!array[num] && ((comparer == null && item.Equals(item2)) || (comparer != null && comparer.Equals(item, item2))))
				{
					array[num] = true;
					flag = true;
					break;
				}
				num++;
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	internal static int GetNextNonEmptyOrWhitespaceIndex(string input, int startIndex, bool skipEmptyValues, out bool separatorFound)
	{
		separatorFound = false;
		int num = startIndex + HttpRuleParser.GetWhitespaceLength(input, startIndex);
		if (num == input.Length || input[num] != ',')
		{
			return num;
		}
		separatorFound = true;
		num++;
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		if (skipEmptyValues)
		{
			while (num < input.Length && input[num] == ',')
			{
				num++;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
			}
		}
		return num;
	}

	internal static DateTimeOffset? GetDateTimeOffsetValue(string headerName, HttpHeaders store)
	{
		object parsedValues = store.GetParsedValues(headerName);
		if (parsedValues != null)
		{
			return (DateTimeOffset)parsedValues;
		}
		return null;
	}

	internal static TimeSpan? GetTimeSpanValue(string headerName, HttpHeaders store)
	{
		object parsedValues = store.GetParsedValues(headerName);
		if (parsedValues != null)
		{
			return (TimeSpan)parsedValues;
		}
		return null;
	}

	internal static bool TryParseInt32(string value, out int result)
	{
		return int.TryParse(value, NumberStyles.None, NumberFormatInfo.InvariantInfo, out result);
	}

	internal static bool TryParseInt64(string value, out long result)
	{
		return long.TryParse(value, NumberStyles.None, NumberFormatInfo.InvariantInfo, out result);
	}

	internal static string DumpHeaders(params HttpHeaders[] headers)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{\r\n");
		for (int i = 0; i < headers.Length; i++)
		{
			if (headers[i] == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, IEnumerable<string>> item in headers[i])
			{
				foreach (string item2 in item.Value)
				{
					stringBuilder.Append("  ");
					stringBuilder.Append(item.Key);
					stringBuilder.Append(": ");
					stringBuilder.Append(item2);
					stringBuilder.Append("\r\n");
				}
			}
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	internal static bool IsValidEmailAddress(string value)
	{
		try
		{
			MailAddressParser.ParseAddress(value);
			return true;
		}
		catch (FormatException ex)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(null, System.SR.Format(System.SR.net_http_log_headers_wrong_email_format, value, ex.Message), "IsValidEmailAddress");
			}
		}
		return false;
	}

	private static void ValidateToken(HttpHeaderValueCollection<string> collection, string value)
	{
		CheckValidToken(value, "item");
	}
}
