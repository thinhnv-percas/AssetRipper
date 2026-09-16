using Cpp2ILInjected;

namespace GameAnalyticsSDK
{
	[Token(Token = "0x2000006")]
	public enum GAAdAction
	{
		[Token(Token = "0x4000016")]
		Undefined = 0,
		[Token(Token = "0x4000017")]
		Clicked = 1,
		[Token(Token = "0x4000018")]
		Show = 2,
		[Token(Token = "0x4000019")]
		FailedShow = 3,
		[Token(Token = "0x400001A")]
		RewardReceived = 4,
		[Token(Token = "0x400001B")]
		Request = 5,
		[Token(Token = "0x400001C")]
		Loaded = 6
	}
}
