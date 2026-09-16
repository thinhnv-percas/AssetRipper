using Cpp2ILInjected;

namespace GameAnalyticsSDK
{
	[Token(Token = "0x2000008")]
	public enum GAAdError
	{
		[Token(Token = "0x4000026")]
		Undefined = 0,
		[Token(Token = "0x4000027")]
		Unknown = 1,
		[Token(Token = "0x4000028")]
		Offline = 2,
		[Token(Token = "0x4000029")]
		NoFill = 3,
		[Token(Token = "0x400002A")]
		InternalError = 4,
		[Token(Token = "0x400002B")]
		InvalidRequest = 5,
		[Token(Token = "0x400002C")]
		UnableToPrecache = 6
	}
}
