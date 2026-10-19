using Cpp2ILInjected;

namespace Unco.EventBusSystem.Runtime
{
	[Token(Token = "0x200000E")]
	public static class EventBusScopes
	{
		[Token(Token = "0x400001B")]
		public const string Global = "Global";

		[Token(Token = "0x400001C")]
		public const string UI = "UI";

		[Token(Token = "0x400001D")]
		public const string Level = "Level";

		[Token(Token = "0x400001E")]
		public const string Player = "Player";

		[Token(Token = "0x400001F")]
		public const string Network = "Network";

		[Token(Token = "0x4000020")]
		public const string Audio = "Audio";
	}
}
