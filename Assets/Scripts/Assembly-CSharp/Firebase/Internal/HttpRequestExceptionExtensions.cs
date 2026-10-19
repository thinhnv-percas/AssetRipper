using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using Cpp2ILInjected;

namespace Firebase.Internal
{
	[Token(Token = "0x2000815")]
	internal static class HttpRequestExceptionExtensions
	{
		[Token(Token = "0x6002275")]
		[Address(RVA = "0x3DD4E98", Offset = "0x3DD4E98", Length = "0x204")]
		internal static HttpStatusCode? GetStatusCode(this HttpRequestException exception)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HttpRequestExceptionExtensions::GetStatusCode");
			return default;
		}
	}
}
