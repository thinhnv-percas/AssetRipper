using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73C808", Offset = "0x73C808")]
	[Token(Token = "0x200000A")]
	public class CVarContainerAttribute : Attribute
	{
		[Token(Token = "0x6000039")]
		[Address(RVA = "0x13D52D4", Offset = "0x13D52D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVarContainerAttribute()
		{
		}
	}
}
