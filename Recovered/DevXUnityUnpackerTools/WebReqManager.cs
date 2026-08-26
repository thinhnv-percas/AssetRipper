using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

internal class WebReqManager
{
	public class ExtendedWebClient : WebClient
	{
		private int _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = 600000;

		public int TimeoutMilliseconds
		{
			get
			{
				return _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A;
			}
			set
			{
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = value;
			}
		}

		public int TimeoutSeconds
		{
			set
			{
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = value * 1000;
			}
		}

		public ExtendedWebClient()
		{
		}

		public ExtendedWebClient(Uri address)
		{
			GetWebRequest(address);
		}

		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest webRequest = base.GetWebRequest(address);
			webRequest.Timeout = _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A;
			return webRequest;
		}
	}

	internal static bool _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020;

	static WebReqManager()
	{
		ServicePointManager.ServerCertificateValidationCallback = AlwaysGoodCertificate;
	}

	internal static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
	{
		return true;
	}

	internal static string MakeReq(string _0020, NameValueCollection _0020_000A)
	{
		try
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = true;
			WebClient client = GetClient();
			client.Encoding = Encoding.UTF8;
			return Encoding.UTF8.GetString(client.UploadValues(_0020, "POST", _0020_000A));
		}
		finally
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = false;
		}
	}

	internal static byte[] _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(string _0020, NameValueCollection _0020_000A)
	{
		try
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = true;
			WebClient client = GetClient();
			client.Encoding = Encoding.UTF8;
			return client.UploadValues(_0020, "POST", _0020_000A);
		}
		finally
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = false;
		}
	}

	internal static string MakeReq2(string _0020, string _0020_000A, int? _0020_0020 = default(int?))
	{
		return _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020(_0020, string.IsNullOrEmpty(_0020_000A) ? new byte[0] : Encoding.UTF8.GetBytes(_0020_000A), _0020_0020);
	}

	internal static string _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020(string _0020, byte[] _0020_000A, int? _0020_0020 = default(int?))
	{
		try
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = true;
			WebRequest webRequest = WebRequest.Create(_0020);
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.Proxy = WebRequest.DefaultWebProxy;
			if (_0020_0020.HasValue)
			{
				webRequest.Timeout = _0020_0020.Value * 1000;
			}
			using (Stream stream = webRequest.GetRequestStream())
			{
				stream.Write(_0020_000A, 0, _0020_000A.Length);
				stream.Close();
			}
			string result = null;
			using (WebResponse webResponse = webRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}
		finally
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = false;
		}
	}

	internal static string GetReq(string link)
	{
		try
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = true;
			return new WebClient
			{
				Proxy = WebRequest.DefaultWebProxy,
				Encoding = Encoding.UTF8
			}.DownloadString(link);
		}
		finally
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = false;
		}
	}

	internal static byte[] _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(string _0020)
	{
		try
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = true;
			return new WebClient
			{
				Proxy = WebRequest.DefaultWebProxy,
				Encoding = Encoding.UTF8
			}.DownloadData(_0020);
		}
		finally
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = false;
		}
	}

	internal static WebClient GetClient(int _0020 = 60)
	{
		return new ExtendedWebClient
		{
			TimeoutSeconds = _0020,
			Proxy = WebRequest.DefaultWebProxy
		};
	}
}
