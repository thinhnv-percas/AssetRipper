using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000010")]
	public enum Module
	{
		[Token(Token = "0x400007E")]
		None = -1,
		[Token(Token = "0x400007F")]
		Advertising = 0,
		[Token(Token = "0x4000080")]
		GameServices = 1,
		[Token(Token = "0x4000081")]
		Gif = 2,
		[Token(Token = "0x4000082")]
		InAppPurchasing = 3,
		[Token(Token = "0x4000083")]
		NativeApis = 4,
		[Token(Token = "0x4000084")]
		Notifications = 5,
		[Token(Token = "0x4000085")]
		Privacy = 6,
		[Token(Token = "0x4000086")]
		Sharing = 7,
		[Token(Token = "0x4000087")]
		Utilities = 8
	}
}
