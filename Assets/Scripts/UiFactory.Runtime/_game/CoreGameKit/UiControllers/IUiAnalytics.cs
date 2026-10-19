using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000014")]
	public interface IUiAnalytics
	{
		[Token(Token = "0x6000067")]
		void TrackUiShow(Type uiControllerType, bool sendToAnalytics = true);

		[Token(Token = "0x6000068")]
		void TrackUiHide(Type uiControllerType, bool sendToAnalytics = true);
	}
}
