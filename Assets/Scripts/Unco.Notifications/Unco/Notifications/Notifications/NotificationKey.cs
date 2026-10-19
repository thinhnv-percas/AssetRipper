using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;

namespace Unco.Notifications.Notifications
{
	[Serializable]
	[Token(Token = "0x2000027")]
	public class NotificationKey
	{
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x10")]
		public List<NotificationInfo> NotificationInfos;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x18")]
		public string Key;

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x81BE540", Offset = "0x81BE540", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\treturnVal1 = Unco.Extensions.ListExtension::GetRandom(this.NotificationInfos);\n\treturn returnVal1;\n")]
		public NotificationInfo GetRandomInfo()
		{
			return NotificationInfos.GetRandom();
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x81BE698", Offset = "0x81BE698", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NotificationKey()
		{
		}
	}
}
