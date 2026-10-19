using Cpp2ILInjected;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000254")]
	public interface ITopGridCmdProcessor
	{
		[Token(Token = "0x6000A3B")]
		void Tick(float dt);

		[Token(Token = "0x6000A3C")]
		void ProcessCommands();
	}
}
