using System;
using Cpp2ILInjected;

namespace Unco.TimeTaskSystem.Runtime
{
	[Flags]
	[Token(Token = "0x2000007")]
	public enum TimerFlags : byte
	{
		[Token(Token = "0x4000007")]
		None = 0,
		[Token(Token = "0x4000008")]
		Active = 1,
		[Token(Token = "0x4000009")]
		Paused = 2,
		[Token(Token = "0x400000A")]
		HasInterval = 4,
		[Token(Token = "0x400000B")]
		CountsDown = 8,
		[Token(Token = "0x400000C")]
		Loop = 0x10
	}
}
