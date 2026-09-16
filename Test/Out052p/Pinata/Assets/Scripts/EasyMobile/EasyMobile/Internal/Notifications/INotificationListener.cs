using System;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Notifications
{
	[Token(Token = "0x20000E6")]
	internal interface INotificationListener
	{
		[Token(Token = "0x17000243")]
		string Name
		{
			[Token(Token = "0x6000875")]
			get;
		}

		[Token(Token = "0x17000244")]
		NativeNotificationHandler NativeNotificationFromForegroundHandler
		{
			[Token(Token = "0x6000876")]
			get;
		}

		[Token(Token = "0x17000245")]
		NativeNotificationHandler NativeNotificationFromBackgroundHandler
		{
			[Token(Token = "0x6000877")]
			get;
		}

		[Token(Token = "0x14000049")]
		event Action<LocalNotification> LocalNotificationOpened;

		[Token(Token = "0x1400004A")]
		event Action<RemoteNotification> RemoteNotificationOpened;
	}
}
