using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200001E")]
	public enum AdType
	{
		[Token(Token = "0x40000FA")]
		Banner = 0,
		[Token(Token = "0x40000FB")]
		Interstitial = 1,
		[Token(Token = "0x40000FC")]
		Rewarded = 2
	}
}
