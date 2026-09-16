using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EC2C", Offset = "0x73EC2C")]
	[Token(Token = "0x2000044")]
	public sealed class TooltipAttribute : Attribute
	{
		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x10")]
		private readonly string text;

		[Token(Token = "0x17000050")]
		public string Text
		{
			[Token(Token = "0x6000136")]
			[Address(RVA = "0xE53B6C", Offset = "0xE53B6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.text;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Text;
			}
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0xE53B74", Offset = "0xE53B74", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.text = text;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TooltipAttribute(string text)
		{
			this.text = text;
		}
	}
}
