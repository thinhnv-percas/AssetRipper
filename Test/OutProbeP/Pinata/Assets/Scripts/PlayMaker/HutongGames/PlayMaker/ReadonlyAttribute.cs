using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EBC8", Offset = "0x73EBC8")]
	[Token(Token = "0x200003F")]
	public sealed class ReadonlyAttribute : Attribute
	{
		[Token(Token = "0x600012F")]
		[Address(RVA = "0xE521D0", Offset = "0xE521D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ReadonlyAttribute()
		{
		}
	}
}
