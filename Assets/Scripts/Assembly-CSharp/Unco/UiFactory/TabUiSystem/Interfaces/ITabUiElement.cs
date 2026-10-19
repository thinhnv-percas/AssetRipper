using Cpp2ILInjected;
using _game.CoreGameKit.MenuLayer;

namespace Unco.UiFactory.TabUiSystem.Interfaces
{
	[Token(Token = "0x2000790")]
	public interface ITabUiElement
	{
		[Token(Token = "0x17000311")]
		HomeTabId TabUiId
		{
			[Token(Token = "0x6001FE6")]
			get;
		}

		[Token(Token = "0x6001FE7")]
		void OnSelectTab(HomeTabId from);

		[Token(Token = "0x6001FE8")]
		void OnDeselectTab(HomeTabId to);
	}
}
