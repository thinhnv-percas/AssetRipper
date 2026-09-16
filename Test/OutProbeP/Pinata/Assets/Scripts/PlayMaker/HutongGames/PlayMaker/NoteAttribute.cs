using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EBA0", Offset = "0x73EBA0")]
	[Token(Token = "0x200003D")]
	public sealed class NoteAttribute : Attribute
	{
		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x10")]
		private readonly string text;

		[Token(Token = "0x1700004C")]
		public string Text
		{
			[Token(Token = "0x600012B")]
			[Address(RVA = "0xE5212C", Offset = "0xE5212C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.text;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Text;
			}
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xE52134", Offset = "0xE52134", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.text = text;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NoteAttribute(string text)
		{
			this.text = text;
		}
	}
}
