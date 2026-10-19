using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.Utils;

namespace Unco.Notifications.Notifications
{
	[Token(Token = "0x2000026")]
	public interface IGameNotificationConfig
	{
		[Token(Token = "0x17000039")]
		List<Pair<string, int>> ComeBackTimes
		{
			[Token(Token = "0x60000FE")]
			get;
		}

		[Token(Token = "0x1700003A")]
		bool EnablePushNotifications
		{
			[Token(Token = "0x60000FF")]
			get;
		}

		[Token(Token = "0x1700003B")]
		bool IgnoreElephantNotifsIos
		{
			[Token(Token = "0x6000100")]
			get;
		}

		[Token(Token = "0x60000FD")]
		NotificationInfo GetNotificationInfo(string type);
	}
}
