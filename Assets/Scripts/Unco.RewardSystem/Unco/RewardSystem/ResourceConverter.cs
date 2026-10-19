using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ResourceSystem;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000009")]
	public class ResourceConverter : IShopItemConverter
	{
		[Token(Token = "0x17000004")]
		public string ConvertTargetLootType
		{
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x81D4B30", Offset = "0x81D4B30", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"resource\";\n")]
			get
			{
				return "resource";
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x4C60DC8", Offset = "0x4C60DC8", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0029;\n\tv49 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0029:\n\tgoto L_0030;\nL_0030:\n\treturnVal1 = System.Enum::TryParse(lootDrop.LootData, &v72 @ stack_-54_v2 (Unco.ResourceSystem.ResourceType));\n\tv76 = ~returnVal1;\n\tif (v76) goto L_006D;\n\tv82 = new Unco.RewardSystem.ResourceItemData();\n\tUnco.RewardSystem.ResourceItemData::.ctor(v82);\n\tv109 = v82 == 0;\n\tif (v109) goto L_007A;\n\tv82.ResourceType = v72;\n\tv82.sourceType = sourceType;\n\tv82.customTransactionData = customTransactionData;\n\tv82.Amount = lootDrop.Amount;\n\tgoto L_0059;\nL_006D:\n\t*([drop @ X3 (T&)]) = 0;\nL_007A:\n\tthrow v82;\nL_0059:\n\tv149 = 0x21C11D0(v82, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([drop @ X3 (T&)]) = v149;\n\tgoto L_0067;\nL_0067:\n\tv161 = 0x21C11D0(v82, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0079;\nL_0079:\n\treturn returnVal1;\n")]
		public bool ConvertShopItemData<T>(LootDrop lootDrop, string sourceType, out T drop, string customTransactionData = "") where T : ShopItemData
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceConverter::ConvertShopItemData");
			drop = default;
			return default;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x81D4B74", Offset = "0x81D4B74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ResourceConverter()
		{
		}
	}
}
