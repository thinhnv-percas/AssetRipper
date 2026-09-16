using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x741820", Offset = "0x741820")]
	[Token(Token = "0x200000F")]
	public class HideLabelAttribute : Attribute
	{
		[Token(Token = "0x600000A")]
		[Address(RVA = "0x167F138", Offset = "0x167F138", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HideLabelAttribute()
		{
		}
	}
}
