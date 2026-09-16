using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000074")]
	public class RemoteNotification : Notification
	{
		[Token(Token = "0x40002AF")]
		[FieldOffset(Offset = "0x30")]
		public readonly OneSignalNotificationPayload oneSignalPayload;

		[Token(Token = "0x40002B0")]
		[FieldOffset(Offset = "0x38")]
		public readonly FirebaseMessage firebasePayload;

		[Token(Token = "0x6000561")]
		[Address(RVA = "0xFD3A8C", Offset = "0xFD3A8C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.id = notificationId;\n\tthis.actionId = actionId;\n\tthis.content = content;\n\tthis.isAppInForeground = isForeground;\n\tthis.isOpened = isOpened;\n\tv34 = EasyMobile.EM_Settings::get_Notifications();\n\tv46 = v34.mPushNotificationService != 1;\n\tif (v46) goto L_0038;\n\tv61 = EasyMobile.OneSignalNotificationPayload::FromJSONDict(notificationId, content.userInfo);\n\tthis.oneSignalPayload = v61;\nL_0038:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RemoteNotification(string notificationId, string actionId, NotificationContent content, bool isForeground, bool isOpened)
		{
			id = notificationId;
			base.actionId = actionId;
			base.content = content;
			isAppInForeground = isForeground;
			base.isOpened = isOpened;
			NotificationsSettings notifications = EM_Settings.Notifications;
			if (notifications.PushNotificationService == PushNotificationProvider.OneSignal)
			{
				OneSignalNotificationPayload oneSignalNotificationPayload = OneSignalNotificationPayload.FromJSONDict(notificationId, content.userInfo);
				oneSignalPayload = oneSignalNotificationPayload;
			}
		}

		[Token(Token = "0x6000562")]
		[Address(RVA = "0xFD3B24", Offset = "0xFD3B24", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = EasyMobile.OneSignalNotificationPayload::ToNotificationContent(payload);\n\tSystem.Object::.ctor(this);\n\tthis.id = payload.notificationID;\n\tthis.actionId = actionId;\n\tthis.content = v33;\n\tthis.isAppInForeground = isForeground;\n\tthis.isOpened = isOpened;\n\tthis.oneSignalPayload = payload;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RemoteNotification(string actionId, OneSignalNotificationPayload payload, bool isForeground, bool isOpened)
		{
			NotificationContent notificationContent = payload.ToNotificationContent();
			id = payload.notificationID;
			base.actionId = actionId;
			content = notificationContent;
			isAppInForeground = isForeground;
			base.isOpened = isOpened;
			oneSignalPayload = payload;
		}

		[Token(Token = "0x6000563")]
		[Address(RVA = "0xFD3BAC", Offset = "0xFD3BAC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = EasyMobile.FirebaseMessage::ToNotificationContent(payload);\n\tSystem.Object::.ctor(this);\n\tthis.id = payload.<MessageId>k__BackingField;\n\tthis.actionId = actionId;\n\tthis.content = v34;\n\tthis.isAppInForeground = isForeground;\n\tthis.isOpened = isOpened;\n\tthis.firebasePayload = payload;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RemoteNotification(string actionId, FirebaseMessage payload, bool isForeground, bool isOpened)
		{
			NotificationContent notificationContent = payload.ToNotificationContent();
			id = payload.MessageId;
			base.actionId = actionId;
			content = notificationContent;
			isAppInForeground = isForeground;
			base.isOpened = isOpened;
			firebasePayload = payload;
		}
	}
}
