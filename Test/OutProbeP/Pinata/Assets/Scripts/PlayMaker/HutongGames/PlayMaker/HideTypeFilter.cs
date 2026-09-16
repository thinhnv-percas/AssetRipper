using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB64", Offset = "0x73EB64")]
	[Token(Token = "0x200003A")]
	public sealed class HideTypeFilter : Attribute
	{
		[Token(Token = "0x6000126")]
		[Address(RVA = "0xE5194C", Offset = "0xE5194C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HideTypeFilter()
		{
		}
	}
}
