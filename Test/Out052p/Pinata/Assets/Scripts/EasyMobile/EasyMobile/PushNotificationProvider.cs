using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200007E")]
	public enum PushNotificationProvider
	{
		[Token(Token = "0x40002EE")]
		None = 0,
		[Token(Token = "0x40002EF")]
		OneSignal = 1,
		[Token(Token = "0x40002F0")]
		Firebase = 2
	}
}
