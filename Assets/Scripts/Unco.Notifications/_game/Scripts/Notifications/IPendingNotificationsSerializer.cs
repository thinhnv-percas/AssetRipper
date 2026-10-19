using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.Scripts.Notifications
{
	[Token(Token = "0x2000016")]
	public interface IPendingNotificationsSerializer
	{
		[Token(Token = "0x60000A8")]
		void Serialize(IList<PendingNotification> notifications);

		[Token(Token = "0x60000A9")]
		IList<IGameNotification> Deserialize(IGameNotificationsPlatform platform);
	}
}
