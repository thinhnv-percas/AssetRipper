using System;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Notifications
{
	[Token(Token = "0x20000E9")]
	internal interface ILocalNotificationClient
	{
		[Token(Token = "0x600088B")]
		void Init(NotificationsSettings settings, INotificationListener listener);

		[Token(Token = "0x600088C")]
		bool IsInitialized();

		[Token(Token = "0x600088D")]
		void ScheduleLocalNotification(string id, DateTime triggerDate, NotificationContent content);

		[Token(Token = "0x600088E")]
		void ScheduleLocalNotification(string id, TimeSpan delay, NotificationContent content);

		[Token(Token = "0x600088F")]
		void ScheduleLocalNotification(string id, TimeSpan delay, NotificationContent content, NotificationRepeat repeat);

		[Token(Token = "0x6000890")]
		void GetPendingLocalNotifications(Action<NotificationRequest[]> callback);

		[Token(Token = "0x6000891")]
		void CancelPendingLocalNotification(string id);

		[Token(Token = "0x6000892")]
		void CancelAllPendingLocalNotifications();

		[Token(Token = "0x6000893")]
		void RemoveAllDeliveredNotifications();
	}
}
