using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EAC8", Offset = "0x73EAC8")]
	[Token(Token = "0x2000034")]
	public sealed class CheckForComponentAttribute : Attribute
	{
		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x10")]
		private readonly Type type0;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x18")]
		private readonly Type type1;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x20")]
		private readonly Type type2;

		[Token(Token = "0x1700003F")]
		public Type Type0
		{
			[Token(Token = "0x6000113")]
			[Address(RVA = "0x9D77EC", Offset = "0x9D77EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type0;
			}
		}

		[Token(Token = "0x17000040")]
		public Type Type1
		{
			[Token(Token = "0x6000114")]
			[Address(RVA = "0x9D77F4", Offset = "0x9D77F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type1;
			}
		}

		[Token(Token = "0x17000041")]
		public Type Type2
		{
			[Token(Token = "0x6000115")]
			[Address(RVA = "0x9D77FC", Offset = "0x9D77FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type2;
			}
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x9D7804", Offset = "0x9D7804", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.type0 = type0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CheckForComponentAttribute(Type type0)
		{
			this.type0 = type0;
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x9D7830", Offset = "0x9D7830", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.type0 = type0;\n\tthis.type1 = type1;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CheckForComponentAttribute(Type type0, Type type1)
		{
			this.type0 = type0;
			this.type1 = type1;
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x9D7868", Offset = "0x9D7868", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.type0 = type0;\n\tthis.type1 = type1;\n\tthis.type2 = type2;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CheckForComponentAttribute(Type type0, Type type1, Type type2)
		{
			this.type0 = type0;
			this.type1 = type1;
			this.type2 = type2;
		}
	}
}
