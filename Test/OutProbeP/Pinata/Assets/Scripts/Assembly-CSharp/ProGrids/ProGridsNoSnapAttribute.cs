using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace ProGrids
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74CBB4", Offset = "0x74CBB4")]
	[Token(Token = "0x200004C")]
	public class ProGridsNoSnapAttribute : Attribute
	{
		[Token(Token = "0x6000225")]
		[Address(RVA = "0xAFFD28", Offset = "0xAFFD28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProGridsNoSnapAttribute()
		{
		}
	}
}
