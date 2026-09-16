using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7449A8", Offset = "0x7449A8")]
	[Token(Token = "0x200004A")]
	public class MinMaxAttribute : MultiPropertyAttribute
	{
		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x10")]
		private float min;

		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x14")]
		private float max;

		[Token(Token = "0x600036C")]
		[Address(RVA = "0xE314B8", Offset = "0xE314B8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.min = min;\n\tthis.max = max;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MinMaxAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
