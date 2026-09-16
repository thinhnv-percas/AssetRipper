using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D1E4", Offset = "0x73D1E4")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D1E4", Offset = "0x73D1E4")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D1E4", Offset = "0x73D1E4")]
	[Token(Token = "0x200000F")]
	public sealed class FilterProvider : IDisposable
	{
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x10")]
		internal World World;

		[Token(Token = "0x17000008")]
		public Filter All
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x15F7674", Offset = "0x15F7674", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.World;\n\treturn v0.Filter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				World world = World;
				return world.Filter;
			}
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x15F7680", Offset = "0x15F7680", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.World = 0;\n\treturn;\n")]
		public void Dispose()
		{
			World = null;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x15F7688", Offset = "0x15F7688", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FilterProvider()
		{
		}
	}
}
