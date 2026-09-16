using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7449BC", Offset = "0x7449BC")]
	[Token(Token = "0x200004B")]
	public class MultiDelayed : MultiPropertyAttribute
	{
		[Token(Token = "0x600036D")]
		[Address(RVA = "0xE314F0", Offset = "0xE314F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MultiDelayed()
		{
		}
	}
}
