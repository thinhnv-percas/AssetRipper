using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB00", Offset = "0x73EB00")]
	[Token(Token = "0x2000035")]
	public sealed class CompoundArrayAttribute : Attribute
	{
		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x10")]
		private readonly string name;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x18")]
		private readonly string firstArrayName;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x20")]
		private readonly string secondArrayName;

		[Token(Token = "0x17000042")]
		public string Name
		{
			[Token(Token = "0x6000119")]
			[Address(RVA = "0x9D78A8", Offset = "0x9D78A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x17000043")]
		public string FirstArrayName
		{
			[Token(Token = "0x600011A")]
			[Address(RVA = "0x9D78B0", Offset = "0x9D78B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.firstArrayName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FirstArrayName;
			}
		}

		[Token(Token = "0x17000044")]
		public string SecondArrayName
		{
			[Token(Token = "0x600011B")]
			[Address(RVA = "0x9D78B8", Offset = "0x9D78B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.secondArrayName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SecondArrayName;
			}
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x9D78C0", Offset = "0x9D78C0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.name = name;\n\tthis.firstArrayName = firstArrayName;\n\tthis.secondArrayName = secondArrayName;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CompoundArrayAttribute(string name, string firstArrayName, string secondArrayName)
		{
			this.name = name;
			this.firstArrayName = firstArrayName;
			this.secondArrayName = secondArrayName;
		}
	}
}
