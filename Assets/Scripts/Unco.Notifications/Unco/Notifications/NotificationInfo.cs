using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Notifications
{
	[Serializable]
	[Token(Token = "0x200001D")]
	public class NotificationInfo
	{
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x10")]
		public string Title;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x18")]
		public string Body;

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x81BA718", Offset = "0x81BA718", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NotificationInfo()
		{
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x81BA720", Offset = "0x81BA720", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Title = title;\n\tthis.Body = body;\n\treturn;\n")]
		public NotificationInfo(string title, string body)
		{
			Title = title;
			Body = body;
		}
	}
}
