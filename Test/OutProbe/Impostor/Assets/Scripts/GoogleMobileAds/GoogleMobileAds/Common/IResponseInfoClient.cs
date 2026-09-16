using Cpp2ILInjected;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x200002A")]
	public interface IResponseInfoClient
	{
		[Token(Token = "0x60001EC")]
		string GetMediationAdapterClassName();

		[Token(Token = "0x60001ED")]
		string GetResponseId();
	}
}
