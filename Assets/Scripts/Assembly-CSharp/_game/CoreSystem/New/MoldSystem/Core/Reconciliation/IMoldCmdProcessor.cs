using Cpp2ILInjected;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E0")]
	public interface IMoldCmdProcessor
	{
		[Token(Token = "0x6000CA9")]
		void ProcessCommands();

		[Token(Token = "0x6000CAA")]
		void Tick(float dt);
	}
}
