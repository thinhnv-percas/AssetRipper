using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200003E")]
	public class LimitedShopItemPref
	{
		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x10")]
		public bool isEnabled;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x14")]
		public int leftAmount;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x18")]
		public string lootDataId;

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x3C67C64", Offset = "0x3C67C64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LimitedShopItemPref()
		{
		}
	}
}
