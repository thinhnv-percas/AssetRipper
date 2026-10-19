using Cpp2ILInjected;

namespace Unco.GameBootstrap.Config
{
	[Token(Token = "0x20007E5")]
	public enum LifetimeKind
	{
		[Token(Token = "0x4001A64")]
		Singleton = 0,
		[Token(Token = "0x4001A65")]
		Scoped = 1,
		[Token(Token = "0x4001A66")]
		Transient = 2
	}
}
