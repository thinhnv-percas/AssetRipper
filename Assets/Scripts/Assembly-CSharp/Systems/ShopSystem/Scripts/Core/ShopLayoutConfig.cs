using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000046")]
	public class ShopLayoutConfig
	{
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x10")]
		public string layoutId;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x18")]
		public List<string> orderedGroupKeys;

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x3C681B0", Offset = "0x3C681B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShopLayoutConfig()
		{
		}
	}
}
