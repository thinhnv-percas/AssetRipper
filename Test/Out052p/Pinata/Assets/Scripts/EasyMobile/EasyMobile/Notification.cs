using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000072")]
	public class Notification
	{
		[Token(Token = "0x40002AA")]
		[FieldOffset(Offset = "0x10")]
		public readonly string id;

		[Token(Token = "0x40002AB")]
		[FieldOffset(Offset = "0x18")]
		public readonly string actionId;

		[Token(Token = "0x40002AC")]
		[FieldOffset(Offset = "0x20")]
		public readonly NotificationContent content;

		[Token(Token = "0x40002AD")]
		[FieldOffset(Offset = "0x28")]
		public readonly bool isAppInForeground;

		[Token(Token = "0x40002AE")]
		[FieldOffset(Offset = "0x29")]
		public readonly bool isOpened;

		[Token(Token = "0x600055F")]
		[Address(RVA = "0xFCF688", Offset = "0xFCF688", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.id = notificationId;\n\tthis.actionId = actionId;\n\tthis.content = content;\n\tthis.isAppInForeground = isForeground;\n\tthis.isOpened = isOpened;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Notification(string notificationId, string actionId, NotificationContent content, bool isForeground, bool isOpened)
		{
			id = notificationId;
			this.actionId = actionId;
			this.content = content;
			isAppInForeground = isForeground;
			this.isOpened = isOpened;
		}
	}
}
