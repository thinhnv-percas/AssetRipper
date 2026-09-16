using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000076")]
	public class NotificationCategoryGroup
	{
		[Token(Token = "0x40002BF")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x40002C0")]
		[FieldOffset(Offset = "0x18")]
		public string name;

		[Token(Token = "0x6000565")]
		[Address(RVA = "0xFCF734", Offset = "0xFCF734", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationCategoryGroup()
		{
		}
	}
}
