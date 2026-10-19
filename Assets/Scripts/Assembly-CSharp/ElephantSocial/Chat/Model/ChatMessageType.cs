using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000914")]
	public enum ChatMessageType
	{
		[Token(Token = "0x4001E70")]
		TEXT = 0,
		[Token(Token = "0x4001E71")]
		HELP = 1,
		[Token(Token = "0x4001E72")]
		REWARD = 2,
		[Token(Token = "0x4001E73")]
		JOIN_REQUEST = 3,
		[Token(Token = "0x4001E74")]
		JOIN_ACCEPT = 4,
		[Token(Token = "0x4001E75")]
		TEAM_UPDATES = 5,
		[Token(Token = "0x4001E76")]
		JOIN_REJECT = 6,
		[Token(Token = "0x4001E77")]
		KICK = 7
	}
}
