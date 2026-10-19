using System;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000022")]
	public static class RewardUtility
	{
		[Token(Token = "0x6000077")]
		[Address(RVA = "0x81D784C", Offset = "0x81D784C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv49 = System.String::IsNullOrEmpty(lootDrop.LootData);\n\tv53 = ~v49;\n\tif (v53) goto L_002B;\nL_0029:\n\treturn \"Invalid Reward\";\nL_002B:\n\tv82 = Unco.RewardSystem.RewardUtility::FormatAmount(lootDrop.Amount);\n\tv86 = Unco.RewardSystem.RewardUtility::GetItemDisplayName(lootDrop.LootType, lootDrop.LootData);\n\treturnVal2 = System.String::Concat(v82, \" \", v86);\n\treturn returnVal2;\nL_0017:\n\tv41 = System.String::IsNullOrEmpty(lootDrop.LootType);\n\tv45 = v41 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0029;\n")]
		public static string GetDisplayName(this LootDrop lootDrop)
		{
			if (string.IsNullOrEmpty(lootDrop.LootType) || string.IsNullOrEmpty(lootDrop.LootData))
			{
				return "Invalid Reward";
			}
			string text = FormatAmount(lootDrop.Amount);
			string itemDisplayName = GetItemDisplayName(lootDrop.LootType, lootDrop.LootData);
			return text + " " + itemDisplayName;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x81D7AC4", Offset = "0x81D7AC4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\treturnVal1 = Unco.RewardSystem.RewardUtility::AddSpacesToCamelCase(lootData);\n\treturn returnVal1;\nL_0030:\n\tv67 = System.String::op_Equality(lootType, \"booster\");\n\tv93 = System.String::Replace(lootData, 0x5F, 0x20);\n\treturnVal3 = Unco.RewardSystem.RewardUtility::ToTitleCase(v93);\n\treturn returnVal3;\nL_001D:\n\tv49 = System.String::op_Equality(lootType, \"resource\");\n\tv53 = v49 == 0;\n\tif (v53) goto L_0030;\n")]
		public static string GetItemDisplayName(string lootType, string lootData)
		{
			if (lootType == "resource")
			{
				return AddSpacesToCamelCase(lootData);
			}
			bool flag = lootType == "booster";
			string text = lootData.Replace('_', ' ');
			return ToTitleCase(text);
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x81D78F8", Offset = "0x81D78F8", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv61 = v34 < 0x49742400;\n\tv65 = v34 == v34;\n\tv68 = ~v65;\n\tv69 = v61 == v68;\n\tif (v69) goto L_0071;\n\tv85 = v34 < 0x447A0000;\n\tv89 = v34 == v34;\n\tv92 = ~v89;\n\tv93 = v85 == v92;\n\tif (v93) goto L_007D;\n\t// 69 NotImplemented \"Instruction FRINTZ not yet implemented.\"\n\tv109 = v34 - 0x447A0000;\n\t// 72 NotImplemented \"Instruction BSL not yet implemented.\"\n\tgoto L_0088;\n\tv74 = v34;\n\tv138 = 0xB7D5000 + 0x538;\n\tv141 = \"il2cpp_vm_object_box\"(*([v138 @ X8_v25 (System.Int32)+48]), &v74 @ stack_-24_v1 (System.Single), v21, v22, v23, v24, v25, v26, v34, 0xFFFFFFFFFFFFFF7F, v109, v29, v30, v31, v32, v33);\n\tv166 = 0xB312000 + 0xDE8;\n\tv151 = v141;\n\tgoto L_0093;\nL_005F:\n\tv73 = v34 / 0x4E6E6B28;\n\tv74 = v73;\n\tv76 = 0xB7D5000 + 0x538;\n\tv79 = \"il2cpp_vm_object_box\"(*([v76 @ X8_v6 (System.Int32)+78]), &v74 @ stack_-24_v1 (System.Single), v21, v22, v23, v24, v25, v26, v73, 0x4E6E6B28, v28, v29, v30, v31, v32, v33);\n\treturnVal1 = System.String::Format(\"{0:F1}B\", v79);\n\treturn returnVal1;\nL_0071:\n\tv95 = v34 / 0x49742400;\n\tv74 = v95;\n\tv98 = 0xB7D5000 + 0x538;\n\tv101 = \"il2cpp_vm_object_box\"(*([v98 @ X8_v11 (System.Int32)+78]), &v74 @ stack_-24_v1 (System.Single), v21, v22, v23, v24, v25, v26, v95, 0x49742400, v28, v29, v30, v31, v32, v33);\n\tv166 = 0xB312000 + 0xD80;\n\tv151 = v101;\n\tgoto L_0093;\nL_007D:\n\tv119 = v34 / 0x447A0000;\n\tv74 = v119;\n\tv122 = 0xB7D5000 + 0x538;\n\tv125 = \"il2cpp_vm_object_box\"(*([v122 @ X8_v16 (System.Int32)+78]), &v74 @ stack_-24_v1 (System.Single), v21, v22, v23, v24, v25, v26, v119, 0x447A0000, v28, v29, v30, v31, v32, v33);\n\tv166 = 0xB312000 + 0xD78;\n\tv151 = v125;\n\tgoto L_0093;\nL_0088:\n\tv74 = v34;\n\tv144 = 0xB7D5000 + 0x538;\n\tv147 = \"il2cpp_vm_object_box\"(*([v144 @ X8_v20 (System.Int32)+78]), &v74 @ stack_-24_v1 (System.Single), v21, v22, v23, v24, v25, v26, v34, 0xFFFFFFFFFFFFFF7F, v109, v29, v30, v31, v32, v33);\n\tv166 = 0xB312000 + 0xD68;\n\tv151 = v147;\nL_0022:\n\tv46 = v34 < 0x4E6E6B28;\n\tv50 = v34 == v34;\n\tv53 = ~v50;\n\tv54 = v46 == v53;\n\tif (v54) goto L_005F;\nL_0093:\n\treturnVal2 = System.String::Format(*([v166 @ X8_v9 (System.Int32)]), v151);\n\treturn returnVal2;\n")]
		public static string FormatAmount(float amount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUtility::FormatAmount");
			return default;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x81D7BD0", Offset = "0x81D7BD0", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv155 = \"[RewardUtility] Cannot parse empty string\";\n\tgoto L_0074;\nL_003A:\n\tv82 = System.String::Split(lootDropString, 0x3A, 0);\n\tv104 = v82.Length <= 2;\n\tif (v104) goto L_0069;\n\tv191 = System.Single::TryParse(v82[2], &v97 @ stack_-54_v6 (System.Single));\n\tv193 = v191 == 0;\n\tif (v193) goto L_0096;\n\treturnBuffer.Amount = 0f;\n\treturnBuffer.LootData = 0;\n\treturnBuffer.LootType = v82[0];\n\treturnBuffer.LootData = v82[1];\n\treturnBuffer.Amount = v97;\n\tgoto L_0083;\nL_0069:\n\tv155 = System.String::Concat(\"[RewardUtility] Invalid loot drop string format: \", lootDropString);\n\tgoto L_0074;\nL_0096:\n\tv155 = System.String::Concat(\"[RewardUtility] Invalid amount in loot drop string: \", v82[2]);\n\tgoto L_0074;\nL_0027:\n\tv58 = System.String::IsNullOrEmpty(lootDropString);\n\tv62 = ~v58;\n\tif (v62) goto L_003A;\nL_0074:\n\tUnityEngine.Debug::LogWarning(v155);\n\treturnBuffer.LootType = 0;\n\treturnBuffer.LootData = 0;\n\treturnBuffer.Amount = 0f;\nL_0083:\n\treturn returnBuffer;\n")]
		public static LootDrop ConvertStringToLootDrop(string lootDropString)
		{
			string message;
			LootDrop result2 = default(LootDrop);
			if (string.IsNullOrEmpty(lootDropString))
			{
				message = "[RewardUtility] Cannot parse empty string";
			}
			else
			{
				string[] array = lootDropString.Split(':');
				if (array.Length > 2)
				{
					if (float.TryParse(array[2], out var result))
					{
						result2.Amount = 0f;
						result2.LootData = null;
						result2.LootType = array[0];
						result2.LootData = array[1];
						result2.Amount = result;
						goto IL_0182;
					}
					message = "[RewardUtility] Invalid amount in loot drop string: " + array[2];
				}
				else
				{
					message = "[RewardUtility] Invalid loot drop string format: " + lootDropString;
				}
			}
			Debug.LogWarning(message);
			result2.LootType = null;
			result2.LootData = null;
			result2.Amount = 0f;
			goto IL_0182;
			IL_0182:
			return result2;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x81D7D8C", Offset = "0x81D7D8C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = lootDrop.Amount;\n\tv49 = 0xB7D5000 + 0x538;\n\tv52 = \"il2cpp_vm_object_box\"(*([v49 @ X8_v4 (System.Int32)+78]), &v47 @ stack_-34_v1 (System.Single), v27, v28, v29, v30, v31, v32, lootDrop.Amount, v34, v35, v36, v37, v38, v39, v40);\n\treturnVal1 = System.String::Format(\"{0}:{1}:{2}\", lootDrop.LootType, lootDrop.LootData, v52);\n\treturn returnVal1;\n")]
		public static string ConvertLootDropToString(LootDrop lootDrop)
		{
			float amount = lootDrop.Amount;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"{lootDrop.LootType}:{lootDrop.LootData}:{arg}";
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x81D7E18", Offset = "0x81D7E18", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv71 = System.String::Concat(\"[RewardUtility] GetIcon not implemented for \", lootDrop.LootType, \":\", lootDrop.LootData);\n\tgoto L_0032;\nL_0032:\n\tUnityEngine.Debug::LogWarning(v71);\n\treturn 0;\n")]
		public static Sprite GetIcon(LootDrop lootDrop)
		{
			string message = "[RewardUtility] GetIcon not implemented for " + lootDrop.LootType + ":" + lootDrop.LootData;
			Debug.LogWarning(message);
			return null;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x81D7B7C", Offset = "0x81D7B7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.RewardSystem.RewardUtility::AddSpacesToCamelCase(resourceType);\n\treturn returnVal1;\n")]
		private static string FormatResourceName(string resourceType)
		{
			return AddSpacesToCamelCase(resourceType);
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x81D8088", Offset = "0x81D8088", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.String::Replace(chestId, 0x5F, 0x20);\n\treturnVal2 = Unco.RewardSystem.RewardUtility::ToTitleCase(v11);\n\treturn returnVal2;\n")]
		private static string FormatChestName(string chestId)
		{
			string text = chestId.Replace('_', ' ');
			return ToTitleCase(text);
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x81D7B80", Offset = "0x81D7B80", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.String::Replace(boosterId, 0x5F, 0x20);\n\treturnVal2 = Unco.RewardSystem.RewardUtility::ToTitleCase(v11);\n\treturn returnVal2;\n")]
		private static string FormatBoosterName(string boosterId)
		{
			string text = boosterId.Replace('_', ' ');
			return ToTitleCase(text);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x81D7BA8", Offset = "0x81D7BA8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.String::Replace(name, 0x5F, 0x20);\n\treturnVal2 = Unco.RewardSystem.RewardUtility::ToTitleCase(v11);\n\treturn returnVal2;\n")]
		private static string FormatGenericName(string name)
		{
			string text = name.Replace('_', ' ');
			return ToTitleCase(text);
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x81D7ED0", Offset = "0x81D7ED0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\treturn text;\nL_002A:\n\tv63 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v63);\n\tv130 = System.String::get_Chars(text, 0);\n\tv136 = System.Text.StringBuilder::Append(v63, v130);\n\tv148 = text.Length < 2;\n\tif (v148) goto L_00A0;\n\tv151 = 0xB7D5000 + 0x538;\n\tv189 = 1;\n\tgoto L_0063;\nL_004E:\n\tv233 = System.String::get_Chars(text, v189);\n\tv172 = System.Text.StringBuilder::Append(v63, v233);\n\tv189 = v189 + 1;\n\tv153 = v189 >= text.Length;\n\tif (v153) goto L_00A0;\nL_0063:\n\tv196 = System.String::get_Chars(text, v189);\n\tv197 = *([v151 @ X22_v4 (System.Int32)+88]);\n\tv199 = *([v197 @ X8_v9+E4]) == 0;\n\tif (v199) goto L_0072;\n\tv201 = System.Char::IsUpper(v196);\n\tv205 = ~v201;\n\tif (v205) goto L_004E;\n\tgoto L_0075;\nL_0072:\n\tv208 = System.Char::IsUpper(v196);\n\tv224 = ~v208;\n\tif (v224) goto L_004E;\nL_0075:\n\tv237 = v189 - 1;\n\tv239 = System.String::get_Chars(text, v237);\n\tv229 = *([v151 @ X22_v4 (System.Int32)+88]);\n\tv241 = *([v229 @ X8_v10+E4]) == 0;\n\tif (v241) goto L_0089;\n\tv221 = System.Char::IsUpper(v239);\n\tv246 = v221 == 0;\n\tv225 = ~v246;\n\tif (v225) goto L_004E;\n\tgoto L_0091;\nL_0089:\n\tv222 = System.Char::IsUpper(v239);\n\tv249 = v222 == 0;\n\tv226 = ~v249;\n\tif (v226) goto L_004E;\nL_0091:\n\tv223 = System.Text.StringBuilder::Append(v63, 0x20);\n\tgoto L_004E;\nL_00A0:\n\tv111 = System.Text.StringBuilder::ToString(v111);\nL_00A0:\n\treturn v63;\nL_0018:\n\tv48 = System.String::IsNullOrEmpty(text);\n\tv50 = v48 == 0;\n\tif (v50) goto L_002A;\n")]
		private static string AddSpacesToCamelCase(string text)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUtility::AddSpacesToCamelCase");
			return default;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x81D80B0", Offset = "0x81D80B0", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv125 = System.String::Split(text, 0x20, 0);\n\tv233 = v125.Length < 1;\n\tif (v233) goto L_009B;\n\tv140 = v125 + 0x20;\n\tv142 = 0;\n\tgoto L_004B;\nL_003B:\n\t*([B79A000]) = v332;\nL_003E:\n\tv142 = v142 + 1;\n\tv242 = v142 >= v125.Length;\n\tif (v242) goto L_009B;\nL_004B:\n\tv136 = v142 << 3;\n\tv192 = v140 + v136;\n\tv180 = *([v192 @ X20_v7]);\n\tv145 = v180.Length < 1;\n\tif (v145) goto L_003E;\n\tv323 = System.String::get_Chars(v180, 0);\n\tgoto L_006A;\n\tv182 = System.String::Substring(*([v192 @ X20_v7]), 1);\n\tv334 = System.String::ToLower(v182);\n\tv332 = System.String::Concat(v328, v334);\n\tv336 = v142 < v125.Length;\n\tv309 = ~v336;\n\tv293 = ~v309;\n\tif (v293) goto L_003B;\n\tthrow System.IndexOutOfRangeException;\nL_009B:\n\tv104 = System.String::Join(\" \", v125);\n\tv111 = v104;\nL_0019:\n\tv49 = System.String::IsNullOrEmpty(text);\n\tv51 = v49 == 0;\n\tv52 = ~v51;\n\tv111 = text;\n\tif (v52) goto L_00A7;\nL_00A7:\n\treturn v111;\nL_006A:\n\tv326 = System.Char::ToUpper(v323);\n\tv128 = v326;\n\tv328 = System.Char::ToString(&v128 @ stack_-42_v6 (System.Char));\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string ToTitleCase(string text)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUtility::ToTitleCase");
			return default;
		}
	}
}
