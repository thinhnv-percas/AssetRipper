using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB50", Offset = "0x73EB50")]
	[Token(Token = "0x2000039")]
	public sealed class HelpUrlAttribute : Attribute
	{
		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x10")]
		private readonly string url;

		[Token(Token = "0x17000049")]
		public string Url
		{
			[Token(Token = "0x6000124")]
			[Address(RVA = "0xE518DC", Offset = "0xE518DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.url;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Url;
			}
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xE518E4", Offset = "0xE518E4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.url = url;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HelpUrlAttribute(string url)
		{
			this.url = url;
		}
	}
}
