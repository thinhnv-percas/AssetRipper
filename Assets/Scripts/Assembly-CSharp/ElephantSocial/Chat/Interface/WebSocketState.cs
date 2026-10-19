using Cpp2ILInjected;

namespace ElephantSocial.Chat.Interface
{
	[Token(Token = "0x200092C")]
	public enum WebSocketState
	{
		[Token(Token = "0x4001EC8")]
		Connecting = 0,
		[Token(Token = "0x4001EC9")]
		Open = 1,
		[Token(Token = "0x4001ECA")]
		Closing = 2,
		[Token(Token = "0x4001ECB")]
		Closed = 3
	}
}
