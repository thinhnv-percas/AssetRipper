using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace ProGrids
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74CBEC", Offset = "0x74CBEC")]
	[Token(Token = "0x200004D")]
	public class ProGridsConditionalSnapAttribute : Attribute
	{
		[Token(Token = "0x6000226")]
		[Address(RVA = "0xAFFD20", Offset = "0xAFFD20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProGridsConditionalSnapAttribute()
		{
		}
	}
}
