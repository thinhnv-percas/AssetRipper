using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ResourceSystem;

namespace Systems.ResourceSystem
{
	[Token(Token = "0x200002F")]
	public static class SpriteAssetHelper
	{
		[Token(Token = "0x4000063")]
		public const string Ad = "<sprite=\"ic_rewarded_flat\" index=0>";

		[Token(Token = "0x4000064")]
		public const string time = "<sprite=\"ic_time\" index=0>";

		[Token(Token = "0x4000065")]
		public const string energy = "<sprite=\"ic_resource_energy\" index=0>";

		[Token(Token = "0x4000066")]
		public const string coreKey = "<sprite=\"ic_shop_gun_bag_ticket\" index=0>";

		[Token(Token = "0x4000067")]
		public const string equipmentKey = "<sprite=\"ic_shop_gear_bag_ticket\" index=0>";

		[Token(Token = "0x4000068")]
		public const string softCurrency = "<sprite=\"ic_resource_coin\" index=0>";

		[Token(Token = "0x4000069")]
		public const string hardCurrency = "<sprite=\"ic_resource_core\" index=0>";

		[Token(Token = "0x400006A")]
		public const string commonCore = "<sprite=\"ic_resource_rankup\" index=0>";

		[Token(Token = "0x400006B")]
		public const string rareCore = "<sprite=\"ic_task_achievement_hammer\" index=0>";

		[Token(Token = "0x400006C")]
		public const string upArrow = "<sprite=\"ic_arrow_up\" index=0>";

		[Token(Token = "0x400006D")]
		public const string downArrow = "<sprite=\"ic_arrow_down\" index=0>";

		[Token(Token = "0x400006E")]
		public const string skullElite = "<sprite=\"ic_skull_elite\" index=0>";

		[Token(Token = "0x400006F")]
		public const string skull = "<sprite=\"ic_skull\" index=0>";

		[Token(Token = "0x4000070")]
		public const string shop_coin_1 = "<sprite=\"ic_resource_shop_coin_1\" index=0>";

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x3C674CC", Offset = "0x3C674CC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_0020:\n\tv54 = System.Enum::Parse(resourceType);\n\tgoto L_003F;\nL_FFFFFFFF:\n\tv88 = \"<sprite=\\\"ic_resource_coin\\\" index=0>\";\n\tgoto L_004F;\nL_FFFFFFFF:\n\tv88 = \"\";\nL_FFFFFFFF:\n\treturnVal1 = \"\";\n\tgoto L_005C;\nL_FFFFFFFF:\n\treturnVal1 = v88;\nL_001C:\n\tgoto L_0020;\nL_003F:\n\tv83 = v54 != 5;\n\tif (v83) goto L_FFFFFFFF;\nL_004F:\n\tv99 = v54 != -1;\n\tif (v99) goto L_FFFFFFFF;\nL_005C:\n\treturn returnVal1;\n")]
		public static string GetResourceIcon(string resourceType)
		{
			ResourceType resourceType2 = Enum.Parse<ResourceType>(resourceType);
			string result = ((resourceType2 != ResourceType.SoftCurrency) ? "" : "<sprite=\"ic_resource_coin\" index=0>");
			if (resourceType2 == ResourceType.None)
			{
				return "";
			}
			return result;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x3C67594", Offset = "0x3C67594", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_FFFFFFFF:\n\tv63 = \"<sprite=\\\"ic_resource_coin\\\" index=0>\";\n\tgoto L_0036;\nL_FFFFFFFF:\n\tv63 = \"\";\nL_FFFFFFFF:\n\treturnVal1 = \"\";\n\tgoto L_0043;\nL_FFFFFFFF:\n\treturnVal1 = v63;\nL_0026:\n\tv58 = resourceType != 5;\n\tif (v58) goto L_FFFFFFFF;\nL_0036:\n\tv74 = resourceType != -1;\n\tif (v74) goto L_FFFFFFFF;\nL_0043:\n\treturn returnVal1;\n")]
		public static string GetResourceIcon(ResourceType resourceType)
		{
			string result = ((resourceType != ResourceType.SoftCurrency) ? "" : "<sprite=\"ic_resource_coin\" index=0>");
			if (resourceType == ResourceType.None)
			{
				return "";
			}
			return result;
		}
	}
}
