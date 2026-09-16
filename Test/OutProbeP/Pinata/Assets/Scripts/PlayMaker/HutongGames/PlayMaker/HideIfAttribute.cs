using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EA3C", Offset = "0x73EA3C")]
	[Token(Token = "0x200002D")]
	public sealed class HideIfAttribute : Attribute
	{
		[CompilerGenerated]
		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x10")]
		private string _003CTest_003Ek__BackingField;

		[Token(Token = "0x17000032")]
		public string Test
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0xE51910", Offset = "0xE51910", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Test>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Test;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0xE51918", Offset = "0xE51918", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Test>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTest_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xE51920", Offset = "0xE51920", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.<Test>k__BackingField = test;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HideIfAttribute(string test)
		{
			Test = test;
		}
	}
}
