using Cpp2ILInjected;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces
{
	[Token(Token = "0x20002D6")]
	public interface IMoldFillDisplayCleaner
	{
		[Token(Token = "0x6000C83")]
		void ClearAll();

		[Token(Token = "0x6000C84")]
		void RemoveOne(int key);
	}
}
