using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB78", Offset = "0x73EB78")]
	[Token(Token = "0x200003B")]
	public sealed class MatchElementTypeAttribute : Attribute
	{
		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x10")]
		private readonly string fieldName;

		[Token(Token = "0x1700004A")]
		public string FieldName
		{
			[Token(Token = "0x6000127")]
			[Address(RVA = "0xE51BB0", Offset = "0xE51BB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fieldName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FieldName;
			}
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xE51BB8", Offset = "0xE51BB8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.fieldName = fieldName;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MatchElementTypeAttribute(string fieldName)
		{
			this.fieldName = fieldName;
		}
	}
}
