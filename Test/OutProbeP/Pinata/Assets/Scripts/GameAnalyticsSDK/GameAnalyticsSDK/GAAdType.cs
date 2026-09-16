using Cpp2ILInjected;

namespace GameAnalyticsSDK
{
	[Token(Token = "0x2000007")]
	public enum GAAdType
	{
		[Token(Token = "0x400001E")]
		Undefined = 0,
		[Token(Token = "0x400001F")]
		Video = 1,
		[Token(Token = "0x4000020")]
		RewardedVideo = 2,
		[Token(Token = "0x4000021")]
		Playable = 3,
		[Token(Token = "0x4000022")]
		Interstitial = 4,
		[Token(Token = "0x4000023")]
		OfferWall = 5,
		[Token(Token = "0x4000024")]
		Banner = 6
	}
}
