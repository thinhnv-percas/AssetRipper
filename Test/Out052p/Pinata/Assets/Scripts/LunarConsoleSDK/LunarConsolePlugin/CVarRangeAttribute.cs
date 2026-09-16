using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73C7D0", Offset = "0x73C7D0")]
	[Token(Token = "0x2000009")]
	public sealed class CVarRangeAttribute : Attribute
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		public readonly float min;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x14")]
		public readonly float max;

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x13D584C", Offset = "0x13D584C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.min = min;\n\tthis.max = max;\n\treturn;\n\t*([X0]) = V0;\n\t*([X0+4]) = V1;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVarRangeAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
