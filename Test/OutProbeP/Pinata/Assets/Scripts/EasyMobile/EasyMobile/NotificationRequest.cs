using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200007A")]
	public class NotificationRequest
	{
		[Token(Token = "0x40002D1")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x40002D2")]
		[FieldOffset(Offset = "0x18")]
		public NotificationContent content;

		[Token(Token = "0x40002D3")]
		[FieldOffset(Offset = "0x20")]
		public DateTime nextTriggerDate;

		[Token(Token = "0x40002D4")]
		[FieldOffset(Offset = "0x28")]
		public NotificationRepeat repeat;

		[Token(Token = "0x6000569")]
		[Address(RVA = "0xFCF9F8", Offset = "0xFCF9F8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.id = id;\n\tthis.content = content;\n\tthis.nextTriggerDate = nextTriggerDate;\n\tthis.repeat = repeat;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationRequest(string id, NotificationContent content, DateTime nextTriggerDate, NotificationRepeat repeat)
		{
			this.id = id;
			this.content = content;
			this.nextTriggerDate = nextTriggerDate;
			this.repeat = repeat;
		}
	}
}
