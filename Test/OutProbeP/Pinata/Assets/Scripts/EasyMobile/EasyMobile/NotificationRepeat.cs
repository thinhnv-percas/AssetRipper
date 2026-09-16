using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000078")]
	public enum NotificationRepeat
	{
		[Token(Token = "0x40002CC")]
		None = 0,
		[Token(Token = "0x40002CD")]
		EveryMinute = 1,
		[Token(Token = "0x40002CE")]
		EveryHour = 2,
		[Token(Token = "0x40002CF")]
		EveryDay = 3,
		[Token(Token = "0x40002D0")]
		EveryWeek = 4
	}
}
