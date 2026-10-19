using System;
using Cpp2ILInjected;

namespace Unco.SettingsSystem.Core
{
	[Flags]
	[Token(Token = "0x2000004")]
	public enum SettingsFlags
	{
		[Token(Token = "0x4000007")]
		Haptic = 1,
		[Token(Token = "0x4000008")]
		Sound = 2,
		[Token(Token = "0x4000009")]
		Music = 4,
		[Token(Token = "0x400000A")]
		QualityLow = 0,
		[Token(Token = "0x400000B")]
		QualityMid = 8,
		[Token(Token = "0x400000C")]
		QualityHigh = 0x10,
		[Token(Token = "0x400000D")]
		QualityMask = 0x18,
		[Token(Token = "0x400000E")]
		Notification = 0x20,
		[Token(Token = "0x400000F")]
		Initialized = 0x40
	}
}
