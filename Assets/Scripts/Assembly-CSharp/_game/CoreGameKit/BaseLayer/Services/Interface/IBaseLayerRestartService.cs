using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Services.Interface
{
	[Token(Token = "0x200065F")]
	public interface IBaseLayerRestartService
	{
		[Token(Token = "0x6001AEF")]
		void Restart();

		[Token(Token = "0x6001AF0")]
		void RestartForDebug();
	}
}
