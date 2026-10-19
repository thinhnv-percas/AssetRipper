using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200000E")]
	public sealed class EmptyShopItemData : ShopItemData
	{
		[Token(Token = "0x4000013")]
		private static EmptyShopItemData _instance;

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x81D4F34", Offset = "0x81D4F34", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB79A000;\n\tv14 = *([B79A0E6]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_001D;\n\tv44 = v17._instance;\n\tv19 = v17._instance == 0;\n\tv51 = Unco.RewardSystem.EmptyShopItemData;\n\tif (v19) goto L_0024;\nL_0018:\n\treturn v44;\nL_001D:\n\t*([v10 @ X19_v1+E6]) = 1;\n\tv44 = v43._instance;\n\tv57 = v43._instance == 0;\n\tv41 = ~v57;\n\tv51 = Unco.RewardSystem.EmptyShopItemData;\n\tif (v41) goto L_0018;\nL_0024:\n\tv55 = new v51();\n\tUnco.RewardSystem.EmptyShopItemData::.ctor(v55);\n\tv74._instance = v55;\n\treturn v55;\n")]
		public static EmptyShopItemData Get()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EmptyShopItemData::Get");
			return default;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x81D4FC8", Offset = "0x81D4FC8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = v47 == 0;\n\tif (v52) goto L_0047;\n\t// 42 MakeStruct v61 @ AGG81D5050_3_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 0, 0, 0, 0\n\tUnityEngine.Texture2D::SetPixel(v47, 0, 0, v61);\n\tUnityEngine.Texture2D::Apply(v47);\n\t// 55 MakeStruct v73 @ AGG81D5080_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, 1f, 1f\n\t// 56 MakeStruct v74 @ AGG81D5080_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tv75 = UnityEngine.Sprite::Create(v47, v73, v74);\n\tthis.icon = v75;\n\treturn;\nL_0047:\n\tthrow v47;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v47, 1, 1);\n")]
		private EmptyShopItemData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EmptyShopItemData::.ctor");
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81D50A4", Offset = "0x81D50A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this;\n")]
		public override ShopItemData Copy()
		{
			return this;
		}
	}
}
