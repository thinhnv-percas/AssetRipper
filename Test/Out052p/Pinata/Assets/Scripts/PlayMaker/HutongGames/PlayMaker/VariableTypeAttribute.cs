using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EBDC", Offset = "0x73EBDC")]
	[Token(Token = "0x2000040")]
	public sealed class VariableTypeAttribute : Attribute
	{
		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x10")]
		private readonly VariableType type;

		[Token(Token = "0x1700004E")]
		public VariableType Type
		{
			[Token(Token = "0x6000130")]
			[Address(RVA = "0xE53BD4", Offset = "0xE53BD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type;
			}
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xE53BDC", Offset = "0xE53BDC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.type = type;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VariableTypeAttribute(VariableType type)
		{
			this.type = type;
		}
	}
}
