using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000070")]
	public enum FsmLogType
	{
		[Token(Token = "0x40002C4")]
		Info = 0,
		[Token(Token = "0x40002C5")]
		Warning = 1,
		[Token(Token = "0x40002C6")]
		Error = 2,
		[Token(Token = "0x40002C7")]
		Event = 3,
		[Token(Token = "0x40002C8")]
		Transition = 4,
		[Token(Token = "0x40002C9")]
		ExitState = 5,
		[Token(Token = "0x40002CA")]
		EnterState = 6,
		[Token(Token = "0x40002CB")]
		Break = 7,
		[Token(Token = "0x40002CC")]
		SendEvent = 8,
		[Token(Token = "0x40002CD")]
		Start = 9,
		[Token(Token = "0x40002CE")]
		Stop = 10
	}
}
