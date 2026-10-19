using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000013")]
	public readonly struct ResourceSnapshot
	{
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x0")]
		public readonly ResourceType ResourceType;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x8")]
		public readonly double Amount;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x10")]
		public readonly bool IsInfinite;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x18")]
		public readonly DateTime Timestamp;

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x81D11BC", Offset = "0x81D11BC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_0027:\n\tv62 = System.DateTime::get_UtcNow();\n\tthis.Timestamp = v62;\n\treturn;\nL_001D:\n\tthis.ResourceType = type;\n\tthis.Amount = amount;\n\tthis.IsInfinite = isInfinite;\n\tgoto L_0027;\n")]
		public ResourceSnapshot(ResourceType type, double amount, bool isInfinite)
		{
			ResourceType = type;
			Amount = amount;
			IsInfinite = isInfinite;
			DateTime utcNow = DateTime.UtcNow;
			Timestamp = utcNow;
		}
	}
}
