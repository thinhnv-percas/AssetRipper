using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000073")]
	public class LocalNotification : Notification
	{
		[Token(Token = "0x6000560")]
		[Address(RVA = "0xB55570", Offset = "0xB55570", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Notification::.ctor(this, notificationId, actionId, content, isForeground, isOpened);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LocalNotification(string notificationId, string actionId, NotificationContent content, bool isForeground, bool isOpened)
			: base(notificationId, actionId, content, isForeground, isOpened)
		{
		}
	}
}
