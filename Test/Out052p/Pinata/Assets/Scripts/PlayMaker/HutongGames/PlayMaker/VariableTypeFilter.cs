using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EBF0", Offset = "0x73EBF0")]
	[Token(Token = "0x2000041")]
	public sealed class VariableTypeFilter : Attribute
	{
		[Token(Token = "0x6000132")]
		[Address(RVA = "0xE53C08", Offset = "0xE53C08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VariableTypeFilter()
		{
		}
	}
}
