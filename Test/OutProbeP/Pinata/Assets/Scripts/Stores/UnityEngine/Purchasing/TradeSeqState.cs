using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000019")]
	internal enum TradeSeqState
	{
		[Token(Token = "0x4000028")]
		PAY_FAILED = 0,
		[Token(Token = "0x4000029")]
		PAY_CONFIRM = 1,
		[Token(Token = "0x400002A")]
		ORDER_SUCCEED = 2,
		[Token(Token = "0x400002B")]
		PAY_INIT = 3,
		[Token(Token = "0x400002C")]
		PAY_SELECTED_CHANNEL = 4,
		[Token(Token = "0x400002D")]
		NOTKNOWN = 5
	}
}
