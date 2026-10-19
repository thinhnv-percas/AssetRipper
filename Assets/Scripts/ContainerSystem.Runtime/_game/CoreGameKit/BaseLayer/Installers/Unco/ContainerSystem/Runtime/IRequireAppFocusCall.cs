using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x2000008")]
	public interface IRequireAppFocusCall
	{
		[Token(Token = "0x600000C")]
		void OnFocusChanged(bool focus);
	}
}
