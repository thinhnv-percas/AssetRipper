using System;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Flags]
	[Token(Token = "0x200007F")]
	public enum NotificationAuthOptions
	{
		[Token(Token = "0x40002F2")]
		Alert = 1,
		[Token(Token = "0x40002F3")]
		Badge = 2,
		[Token(Token = "0x40002F4")]
		Sound = 4
	}
}
