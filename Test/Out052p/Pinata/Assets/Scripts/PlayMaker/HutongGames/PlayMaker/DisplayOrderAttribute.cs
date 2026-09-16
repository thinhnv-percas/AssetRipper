using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB14", Offset = "0x73EB14")]
	[Token(Token = "0x2000036")]
	public sealed class DisplayOrderAttribute : Attribute
	{
		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x10")]
		private readonly int index;

		[Token(Token = "0x17000045")]
		public int Index
		{
			[Token(Token = "0x600011D")]
			[Address(RVA = "0x9D82D8", Offset = "0x9D82D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.index;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Index;
			}
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x9D82E0", Offset = "0x9D82E0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.index = orderIndex;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DisplayOrderAttribute(int orderIndex)
		{
			index = orderIndex;
		}
	}
}
