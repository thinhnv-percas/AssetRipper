using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7449E4", Offset = "0x7449E4")]
	[Token(Token = "0x200004D")]
	public class MultiRange : MultiPropertyAttribute
	{
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x10")]
		private float min;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x14")]
		private float max;

		[Token(Token = "0x600036F")]
		[Address(RVA = "0xE314F8", Offset = "0xE314F8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.min = min;\n\tthis.max = max;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MultiRange(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
