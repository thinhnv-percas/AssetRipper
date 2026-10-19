using Cpp2ILInjected;

namespace _game.Systems.ElephantStorage
{
	[Token(Token = "0x2000787")]
	public interface IPlayerDataHandler
	{
		[Token(Token = "0x6001FD0")]
		void Load(GameStorage storage);

		[Token(Token = "0x6001FD1")]
		void Save();
	}
}
