using Cpp2ILInjected;
using _game.CoreGameKit.MenuLayer;

namespace Unco.UiFactory.TabUiSystem.Interfaces
{
	[Token(Token = "0x200078E")]
	public interface ITabAction
	{
		[Token(Token = "0x6001FE3")]
		void OnSelectTab(HomeTabId baseId, HomeTabId from);

		[Token(Token = "0x6001FE4")]
		void OnDeselectTab(HomeTabId baseId, HomeTabId to);
	}
}
