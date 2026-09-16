using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EC40", Offset = "0x73EC40")]
	[Token(Token = "0x2000045")]
	public sealed class UIHintAttribute : Attribute
	{
		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x10")]
		private readonly UIHint hint;

		[Token(Token = "0x17000051")]
		public UIHint Hint
		{
			[Token(Token = "0x6000138")]
			[Address(RVA = "0xE53BA0", Offset = "0xE53BA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.hint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Hint;
			}
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xE53BA8", Offset = "0xE53BA8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.hint = hint;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UIHintAttribute(UIHint hint)
		{
			this.hint = hint;
		}
	}
}
