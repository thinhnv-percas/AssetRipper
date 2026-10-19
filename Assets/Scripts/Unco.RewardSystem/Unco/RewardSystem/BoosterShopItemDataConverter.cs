using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000013")]
	public class BoosterShopItemDataConverter : IShopItemConverter
	{
		[Token(Token = "0x17000009")]
		public string ConvertTargetLootType
		{
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x81D5A60", Offset = "0x81D5A60", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"booster\";\n")]
			get
			{
				return "booster";
			}
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x47F6E7C", Offset = "0x47F6E7C", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tgoto L_001F;\n\tv45 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001F:\n\tv54 = new Unco.RewardSystem.BoosterShopItemData();\n\tUnco.RewardSystem.BoosterShopItemData::.ctor(v54);\n\tv59 = v54 == 0;\n\tif (v59) goto L_0061;\n\tv54.BoosterId = lootDrop.LootData;\n\tv54.sourceType = sourceType;\n\tv54.customTransactionData = customTransactionData;\n\tv54.Amount = lootDrop.Amount;\n\tgoto L_0044;\nL_0061:\n\tthrow v54;\nL_0044:\n\tv114 = 0x21C11D0(v54, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([drop @ X3 (T&)]) = v114;\n\tgoto L_0052;\nL_0052:\n\tv126 = 0x21C11D0(v54, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn 1;\n")]
		public bool ConvertShopItemData<T>(LootDrop lootDrop, string sourceType, out T drop, string customTransactionData = "") where T : ShopItemData
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterShopItemDataConverter::ConvertShopItemData");
			drop = default;
			return default;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81D5AA4", Offset = "0x81D5AA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public BoosterShopItemDataConverter()
		{
		}
	}
}
