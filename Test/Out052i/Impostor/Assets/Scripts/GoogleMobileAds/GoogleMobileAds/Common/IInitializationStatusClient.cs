using System.Collections.Generic;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000027")]
	public interface IInitializationStatusClient
	{
		[Token(Token = "0x60001CD")]
		AdapterStatus getAdapterStatusForClassName(string className);

		[Token(Token = "0x60001CE")]
		Dictionary<string, AdapterStatus> getAdapterStatusMap();
	}
}
