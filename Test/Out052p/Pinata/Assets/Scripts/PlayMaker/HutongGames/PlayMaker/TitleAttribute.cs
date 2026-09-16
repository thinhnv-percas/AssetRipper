using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EC18", Offset = "0x73EC18")]
	[Token(Token = "0x2000043")]
	public sealed class TitleAttribute : Attribute
	{
		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x10")]
		private readonly string text;

		[Token(Token = "0x1700004F")]
		public string Text
		{
			[Token(Token = "0x6000134")]
			[Address(RVA = "0xE53B38", Offset = "0xE53B38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.text;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Text;
			}
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0xE53B40", Offset = "0xE53B40", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.text = text;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TitleAttribute(string text)
		{
			this.text = text;
		}
	}
}
