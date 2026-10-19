using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Scripts.Notifications
{
	[Token(Token = "0x2000017")]
	public class PendingNotification
	{
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x10")]
		public bool Reschedule;

		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x18")]
		public readonly IGameNotification Notification;

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x81B7DF4", Offset = "0x81B7DF4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = notification == 0;\n\tif (v15) goto L_001A;\n\tthis.Notification = notification;\n\treturn;\nL_001A:\n\tv18 = 0xB28B000 + 0x600;\n\tv52 = new v18();\n\tv54 = 0xB30E000 + 0xB0;\n\tSystem.ArgumentNullException::.ctor(v52, v54);\n\tthrow v52;\n")]
		public PendingNotification(IGameNotification notification)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PendingNotification::.ctor");
		}
	}
}
