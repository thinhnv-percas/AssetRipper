using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EAA0", Offset = "0x73EAA0")]
	[Token(Token = "0x2000032")]
	public sealed class ActionSection : Attribute
	{
		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x10")]
		private readonly string section;

		[Token(Token = "0x17000037")]
		public string Section
		{
			[Token(Token = "0x6000108")]
			[Address(RVA = "0x9D753C", Offset = "0x9D753C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.section;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Section;
			}
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x9D7544", Offset = "0x9D7544", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.section = section;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionSection(string section)
		{
			this.section = section;
		}
	}
}
