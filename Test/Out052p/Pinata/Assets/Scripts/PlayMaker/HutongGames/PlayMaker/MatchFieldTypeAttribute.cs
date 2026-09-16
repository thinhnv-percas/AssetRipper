using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB8C", Offset = "0x73EB8C")]
	[Token(Token = "0x200003C")]
	public sealed class MatchFieldTypeAttribute : Attribute
	{
		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x10")]
		private readonly string fieldName;

		[Token(Token = "0x1700004B")]
		public string FieldName
		{
			[Token(Token = "0x6000129")]
			[Address(RVA = "0xE51BE4", Offset = "0xE51BE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fieldName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FieldName;
			}
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xE51BEC", Offset = "0xE51BEC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.fieldName = fieldName;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MatchFieldTypeAttribute(string fieldName)
		{
			this.fieldName = fieldName;
		}
	}
}
