using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000012")]
	public class BoosterShopItemData : ShopItemData
	{
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x40")]
		public string BoosterId;

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x81D5A58", Offset = "0x81D5A58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public BoosterShopItemData()
		{
		}
	}
}
