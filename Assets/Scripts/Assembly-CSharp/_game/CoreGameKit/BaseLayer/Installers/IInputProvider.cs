using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x2000684")]
	public interface IInputProvider
	{
		[Token(Token = "0x6001BBE")]
		InputData GetInputState();

		[Token(Token = "0x6001BBF")]
		void SetEnabled(bool b);
	}
}
