using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000048")]
	public class ShopBundleRemote
	{
		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x10")]
		public string bundleKey;

		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x18")]
		public ShopItemRemote[] shopItems;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x20")]
		public string bundleVisualName;

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x3C681C0", Offset = "0x3C681C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShopBundleRemote()
		{
		}
	}
}
