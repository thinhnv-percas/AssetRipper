using System;
using System.Collections;
using Cpp2ILInjected;

namespace _game.Scripts.Notifications
{
	[Token(Token = "0x2000014")]
	public interface IGameNotificationsPlatform
	{
		[Token(Token = "0x14000004")]
		event Action<IGameNotification> NotificationReceived;

		[Token(Token = "0x600009B")]
		IEnumerator RequestNotificationPermission();

		[Token(Token = "0x600009C")]
		IGameNotification CreateNotification();

		[Token(Token = "0x600009D")]
		void ScheduleNotification(IGameNotification gameNotification);

		[Token(Token = "0x600009E")]
		void CancelNotification(int notificationId);

		[Token(Token = "0x600009F")]
		void DismissNotification(int notificationId);

		[Token(Token = "0x60000A0")]
		void CancelAllScheduledNotifications();

		[Token(Token = "0x60000A1")]
		void DismissAllDisplayedNotifications();

		[Token(Token = "0x60000A2")]
		IGameNotification GetLastNotification();

		[Token(Token = "0x60000A3")]
		void OnForeground();

		[Token(Token = "0x60000A4")]
		void OnBackground();
	}
	[Token(Token = "0x2000015")]
	public interface IGameNotificationsPlatform<TNotificationType> : IGameNotificationsPlatform where TNotificationType : IGameNotification
	{
		[Token(Token = "0x60000A5")]
		new TNotificationType CreateNotification();

		[Token(Token = "0x60000A6")]
		void ScheduleNotification(TNotificationType notification);

		[Token(Token = "0x60000A7")]
		new TNotificationType GetLastNotification();
	}
}
