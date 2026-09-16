using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EA28", Offset = "0x73EA28")]
	[Token(Token = "0x200002C")]
	public sealed class NoActionTargetsAttribute : Attribute
	{
		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xE52124", Offset = "0xE52124", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NoActionTargetsAttribute()
		{
		}
	}
}
