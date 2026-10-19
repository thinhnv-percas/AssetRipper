using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000015")]
	public class HealthShopItemData : ShopItemData
	{
		[Token(Token = "0x1700000A")]
		[field: Token(Token = "0x4000026")]
		[field: FieldOffset(Offset = "0x40")]
		public HealthRewardType HealthRewardType
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x81D5AAC", Offset = "0x81D5AAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.HealthRewardType;\n")]
			get;
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x81D5AB4", Offset = "0x81D5AB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.HealthRewardType = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700000B")]
		public float Duration
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x81D5ABC", Offset = "0x81D5ABC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Amount;\n")]
			get
			{
				return (float)Amount;
			}
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x81D5AC8", Offset = "0x81D5AC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HealthShopItemData()
		{
		}
	}
}
