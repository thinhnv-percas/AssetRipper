using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000023")]
	public static class ShopItemConverter
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000024")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000042")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000043")]
			public static Func<Assembly, IEnumerable<Type>> _003C_003E9__2_0;

			[Token(Token = "0x4000044")]
			public static Func<Type, bool> _003C_003E9__2_1;

			[Token(Token = "0x600008A")]
			[Address(RVA = "0x81D9568", Offset = "0x81D9568", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.RewardSystem.ShopItemConverter+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600008B")]
			[Address(RVA = "0x81D95CC", Offset = "0x81D95CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal IEnumerable<Type> _003CInitialize_003Eb__2_0(Assembly assembly)
			{
				if ((object)assembly != null)
				{
					return assembly.GetTypes();
				}
				NullReferenceException ex = new NullReferenceException();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @7C03E68 (inside Spine.Unity.Examples.SkeletonRagdoll2D+<Start>d__35::System.Collections.IEnumerator.get_Current +0x8)");
				IEnumerable<Type> result = default(IEnumerable<Type>);
				return result;
			}

			internal bool _003CInitialize_003Eb__2_1(Type t)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ShopItemConverter._003C_003Ec::_003CInitialize_003Eb__2_1");
				return default;
			}
		}

		[Token(Token = "0x4000040")]
		private static readonly Dictionary<string, IShopItemConverter> _converters;

		[Token(Token = "0x4000041")]
		private static bool _initialized;

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x81D8244", Offset = "0x81D8244", Length = "0xDF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001E;\nL_001E:\n\tv68 = v65._initialized == 0;\n\tif (v68) goto L_008F;\n\tgoto L_0434;\nL_008F:\n\tgoto L_0094;\n\tSystem.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::Clear(v194._converters);\n\tv277 = System.AppDomain::get_CurrentDomain();\n\tv283 = v277 == 0;\n\tif (v283) goto L_0439;\n\tv293 = System.AppDomain::GetAssemblies(v277);\n\tgoto L_00AB;\nL_00AB:\n\tv556 = v554.<>9__2_0 == 0;\n\tv557 = ~v556;\n\tv568 = v554.<>9__2_0;\n\tif (v557) goto L_00D4;\n\tgoto L_00B9;\nL_00B9:\n\tgoto L_00C1;\nL_00D4:\n\tv589 = System.Linq.Enumerable::SelectMany(v293, v568);\n\tgoto L_00DC;\nL_00DC:\n\tv615 = v613.<>9__2_1 == 0;\n\tv616 = ~v615;\n\tv434 = v613.<>9__2_1;\n\tif (v616) goto L_0105;\n\tgoto L_00EA;\nL_00EA:\n\tgoto L_00F2;\nL_0105:\n\tv760 = System.Linq.Enumerable::Where(v589, v434);\n\tv509 = v760 == 0;\n\tif (v509) goto L_043B;\n\tv671 = *([v760 @ X0_v27 (System.Collections.Generic.IEnumerable`1<System.Object>)]);\n\tv726 = *([v671 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+12E]);\n\tv673 = *([v671 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+12E]) == 0;\n\tif (v673) goto L_012B;\n\tv725 = *([v671 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+B0]) + 8;\n\tv725 = v725 + 0x10;\n\tv706 = v726 - 1;\n\tv686 = v726 != 1;\n\tv726 = v706;\n\tif (v686) goto L_0116;\nL_012B:\n\tv709 = System.Linq.Enumerable::Where(v760, System.Collections.Generic.IEnumerable`1<System.Type>);\n\tv758 = 0;\n\tv761 = v709;\n\tgoto L_0135;\nL_0130:\n\tv743 = *([v725 @ X10_v35]) << 4;\n\tv744 = v671 + v743;\n\tv761 = v744 + 0x138;\n\tv758 = Il2CppMethodInfo;\n\tv111 = v765;\n\tgoto L_0154;\nL_014C:\n\tUnityEngine.Debug::LogWarning(v1221);\nL_014E:\n\tv800 = v170 == 0;\n\tv111 = v170;\n\tif (v800) goto L_0435;\nL_0154:\n\tgoto L_017A;\n\tv508 = v170 == 0;\n\tif (v508) goto L_0437;\n\tgoto L_01AB;\n\tgoto L_01DE;\n\tv491 = v1075 == 0;\n\tif (v491) goto L_0329;\n\tv1214 = System.Reflection.MemberInfo::get_Name(v1075);\n\tv1221 = System.String::Concat(\"[ShopItemConverter] Converter \", v1214, \" has empty ConvertTargetLootType\");\n\tgoto L_014C;\nL_0201:\n\tgoto L_0206;\n\tv1228 = System.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::ContainsKey(v513._converters, v1203);\n\tv1232 = v1228 == 0;\n\tif (v1232) goto L_02B7;\n\t// 528 NewArr v1234 @ X0_v113 (System.String[]), typeof(System.String[]), 7\n\tv494 = v1234 == 0;\n\tif (v494) goto L_032F;\n\tv495 = v1234.Length == 0;\n\tif (v495) goto L_0331;\n\tv1234[0] = \"[ShopItemConverter] Duplicate converter for type '\";\n\tv497 = v1234.Length & -2;\n\tv368 = v497 == 0;\n\tif (v368) goto L_0335;\n\tv1234[1] = v1203;\n\tv1255 = v1234.Length < 2;\n\tv407 = ~v1255;\n\tv396 = v1234.Length - 2;\n\tv369 = v396 == 0;\n\tv1256 = ~v407;\n\tv315 = v1256 | v369;\n\tif (v315) goto L_0339;\n\tv1234[2] = \"'. Existing: \";\n\tgoto L_0247;\n\tv1282 = System.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::get_Item(v521._converters, v1203);\n\tv502 = v1282 == 0;\n\tif (v502) goto L_0341;\n\tv1290 = System.Object::GetType(v1282);\n\tv503 = v1290 == 0;\n\tif (v503) goto L_0345;\n\tv1296 = System.Reflection.MemberInfo::get_Name(v1290);\n\tv505 = v1234.Length & -4;\n\tv373 = v505 == 0;\n\tif (v373) goto L_0349;\n\tv1234[3] = v1296;\n\tv1308 = v1234.Length < 4;\n\tv413 = ~v1308;\n\tv399 = v1234.Length - 4;\n\tv375 = v399 == 0;\n\tv1309 = ~v413;\n\tv318 = v1309 | v375;\n\tif (v318) goto L_034D;\n\tv1234[4] = \", New: \";\n\tv506 = v1075 == 0;\n\tif (v506) goto L_034F;\n\tv1324 = System.Reflection.MemberInfo::get_Name(v1075);\n\tv1325 = v1234.Length < 5;\n\tv414 = ~v1325;\n\tv400 = v1234.Length - 5;\n\tv376 = v400 == 0;\n\tv1326 = ~v414;\n\tv319 = v1326 | v376;\n\tif (v319) goto L_0351;\n\tv1234[5] = v1324;\n\tv1330 = v1234.Length < 6;\n\tv415 = ~v1330;\n\tv401 = v1234.Length - 6;\n\tv377 = v401 == 0;\n\tv1331 = ~v415;\n\tv320 = v1331 | v377;\n\tif (v320) goto L_0353;\n\tv1234[6] = \". Using first registered.\";\n\tv1340 = System.String::Concat(v1234);\n\tgoto L_02B1;\nL_02B1:\n\tUnityEngine.Debug::LogWarning(v1340);\n\tgoto L_014E;\nL_02B7:\n\tgoto L_02BC;\n\tSystem.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::set_Item(v514._converters, v1203, v1094);\n\t// 710 NewArr v1251 @ X0_v79 (System.String[]), typeof(System.String[]), 5\n\tv496 = v1251 == 0;\n\tif (v496) goto L_0333;\n\tv498 = v1251.Length == 0;\n\tif (v498) goto L_0337;\n\tv1251[0] = \"[ShopItemConverter] Registered converter: \";\n\tv499 = v1075 == 0;\n\tif (v499) goto L_033B;\n\tv1273 = System.Reflection.MemberInfo::get_Name(v1075);\n\tv501 = v1251.Length & -2;\n\tv370 = v501 == 0;\n\tif (v370) goto L_033F;\n\tv1251[1] = v1273;\n\tv1283 = v1251.Length < 2;\n\tv409 = ~v1283;\n\tv397 = v1251.Length - 2;\n\tv371 = v397 == 0;\n\tv1284 = ~v409;\n\tv316 = v1284 | v371;\n\tif (v316) goto L_0343;\n\tv1251[2] = \" for type '\";\n\tv504 = v1251.Length & -4;\n\tv372 = v504 == 0;\n\tif (v372) goto L_0347;\n\tv1251[3] = v1203;\n\tv1297 = v1251.Length < 4;\n\tv412 = ~v1297;\n\tv398 = v1251.Length - 4;\n\tv374 = v398 == 0;\n\tv1298 = ~v412;\n\tv317 = v1298 | v374;\n\tif (v317) goto L_034B;\n\tv1251[4] = \"'\";\n\tv1312 = System.String::Concat(v1251);\n\tgoto L_0327;\nL_0327:\n\tUnityEngine.Debug::Log(v1312);\n\tgoto L_014E;\nL_0329:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_032B:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_032D:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_032F:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0331:\n\tv468 = new System.IndexOutOfRangeException();\n\tv294 = v468;\n\tgoto L_04C6;\nL_0333:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0335:\n\tv470 = new System.IndexOutOfRangeException();\n\tv294 = v470;\n\tgoto L_04C6;\nL_0337:\n\tv471 = new System.IndexOutOfRangeException();\n\tv294 = v471;\n\tgoto L_04C6;\nL_0339:\n\tv472 = new System.IndexOutOfRangeException();\n\tv294 = v472;\n\tgoto L_04C6;\nL_033B:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_033D:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_033F:\n\tv475 = new System.IndexOutOfRangeException();\n\tv294 = v475;\n\tgoto L_04C6;\nL_0341:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0343:\n\tv477 = new System.IndexOutOfRangeException();\n\tv294 = v477;\n\tgoto L_04C6;\nL_0345:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0347:\n\tv479 = new System.IndexOutOfRangeException();\n\tv294 = v479;\n\tgoto L_04C6;\nL_0349:\n\tv480 = new System.IndexOutOfRangeException();\n\tv294 = v480;\n\tgoto L_04C6;\nL_034B:\n\tv481 = new System.IndexOutOfRangeException();\n\tv294 = v481;\n\tgoto L_04C6;\nL_034D:\n\tv482 = new System.IndexOutOfRangeException();\n\tv294 = v482;\n\tgoto L_04C6;\nL_034F:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0351:\n\tv484 = new System.IndexOutOfRangeException();\n\tv294 = v484;\n\tgoto L_04C6;\nL_0353:\n\tv485 = new System.IndexOutOfRangeException();\n\tv294 = v485;\n\tgoto L_04C6;\nL_03BE:\n\tv900 = &v170 @ stack_-68_v5 (System.Collections.Generic.IEnumerator`1<System.Type>);\n\tv901 = *([v900 @ X8_v27]) == 0;\n\tif (v901) goto L_03F2;\n\tgoto L_03EE;\n\tgoto L_0404;\n\tgoto L_0434;\nL_0404:\n\tgoto L_0409;\n\tv1098 = System.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::get_Count(v535._converters);\n\tv103 = v1098;\n\tv1104 = 0xB7D5000 + 0x538;\n\tv1107 = \"il2cpp_vm_object_box\"(*([v1104 @ X8_v34 (System.Int32)+48]), &v103 @ stack_-90_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1137 = System.String::Format(\"[ShopItemConverter] Initialization complete. Registered {0} converters.\", v1107);\n\tgoto L_0426;\nL_0426:\n\tUnityEngine.Debug::Log(v1137);\nL_0434:\n\treturn;\nL_0435:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0437:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_0439:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_043B:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_043D:\n\tv489 = new System.OutOfMemoryException();\n\tv294 = v489;\n\tgoto L_04C6;\nL_043F:\n\tv294 = new System.NullReferenceException();\n\tgoto L_04C6;\nL_04BD:\n\tthrow System.NullReferenceException;\nL_04C6:\n\t// 12\n// ... truncated")]
		private static void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopItemConverter::Initialize");
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x4CAC370", Offset = "0x4CAC370", Length = "0x4CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tgoto L_0033;\nL_0033:\n\tv118 = 0xB294000 + 0x498;\n\tgoto L_003B;\nL_003B:\n\tv73 = v70._initialized == 0;\n\tif (v73) goto L_00C0;\n\t*([drop @ X2 (T&)]) = 0;\n\tv93 = Unco.RewardSystem.LootDrop::IsValid(lootDrop);\n\tv109 = v93 == 0;\n\tif (v109) goto L_00CD;\nL_0044:\n\tv149 = *([v118 @ X24_v7 (System.Int32)]);\n\tgoto L_004B;\n\tv171 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::TryGetValue(*([v151 @ X8_v20]), lootDrop.LootType, &v170 @ stack_-68_v9);\n\tv194 = ~v171;\n\tif (v194) goto L_0084;\n\tv243 = v170 == 0;\n\tif (v243) goto L_0111;\n\tv263 = Il2CppMethodInfo;\n\tv270 = *([v170 @ stack_-68_v9]);\n\tv419 = *([v270 @ X8_v41+12E]);\n\tv272 = *([v270 @ X8_v41+12E]) == 0;\n\tif (v272) goto L_0081;\n\tv418 = *([v270 @ X8_v41+B0]) + 8;\n\tv418 = v418 + 0x10;\n\tv397 = v419 - 1;\n\tv377 = v419 != 1;\n\tv419 = v397;\n\tif (v377) goto L_0068;\nL_0081:\n\tv399 = 0x220C5E0(v170, Il2CppClass<Unco.RewardSystem.IShopItemConverter>, *([v263 @ X23_v3 (Il2CppMethodInfo)+50]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, lootDrop.LootType, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00FE;\nL_0084:\n\tv275 = *([v118 @ X24_v7 (System.Int32)]);\n\tgoto L_008B;\n\tv403 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Keys(*([v181 @ X8_v27]));\n\tv434 = System.String::Join(\", \", v403);\n\tv234 = System.String::Concat(\"[ShopItemConverter] No converter found for LootDropType: '\", lootDrop.LootType, \"'. Available types: \", v434);\n\tgoto L_00E7;\n\tv371 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv118 = 0xB294000 + 0x498;\n\tgoto L_003B;\nL_00C0:\n\tgoto L_00C3;\nL_00C3:\n\tUnco.RewardSystem.ShopItemConverter::Initialize();\n\t*([drop @ X2 (T&)]) = 0;\n\tv121 = Unco.RewardSystem.LootDrop::IsValid(lootDrop);\n\tv161 = v121 == 0;\n\tv123 = ~v161;\n\tv118 = v118;\n\tif (v123) goto L_0044;\nL_00CD:\n\tv136 = lootDrop.LootType;\n\t// 212 Box v143 @ X0_v9 (System.Object), typeof(Unco.RewardSystem.LootDrop), &v136 @ stack_-60_v3 (System.String)\n\tv234 = System.String::Format(\"[ShopItemConverter] Invalid LootDrop: {0}\", v143);\n\tgoto L_00E7;\nL_0111:\n\tv282 = new System.NullReferenceException();\n\tgoto L_017B;\nL_0172:\n\tthrow System.NullReferenceException;\nL_017B:\n\t// 379 Interrupt\n\tv287 = 0x8BF5BF4(v282, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv405 = 0x8BF0368(v282, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v405, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_004B:\n\tv151 = *([v149 @ X0_v23+B8]);\n\tv153 = *([v151 @ X8_v20]) == 0;\n\tif (v153) goto L_0172;\nL_0068:\n\t;\n\tv424 = *([v418 @ X10_v5-8]) == Il2CppClass<Unco.RewardSystem.IShopItemConverter>;\n\tif (v424) goto L_00FE;\nL_00FE:\n\tv136 = lootDrop.LootType;\n\treturnVal3 = Unco.RewardSystem.IShopItemConverter::ConvertShopItemData(v170, &v136 @ stack_-60_v3 (System.String), sourceType, drop, customTransactionData);\n\treturn returnVal3;\nL_008B:\n\tv181 = *([v275 @ X0_v37+B8]);\n\tv179 = *([v181 @ X8_v27]) == 0;\n\tif (v179) goto L_0172;\nL_00E7:\n\tUnityEngine.Debug::LogWarning(v234);\n\treturn 0;\n")]
		public unsafe static bool TryConvertShopItemData<T>(LootDrop lootDrop, string sourceType, out T drop, string customTransactionData = "") where T : ShopItemData
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopItemConverter::TryConvertShopItemData");
			drop = default;
			return default;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x81D903C", Offset = "0x81D903C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = v50._initialized == 0;\n\tif (v53) goto L_005B;\n\tv109 = 0xB28D000 + 0x3C8;\n\tv71 = System.String::IsNullOrEmpty(lootType);\n\tv84 = ~v71;\n\tif (v84) goto L_0066;\nL_0027:\n\tgoto L_0032;\nL_0032:\n\tUnityEngine.Debug::LogError(\"[ShopItemConverter] Cannot register converter with empty lootType\");\n\treturn;\nL_005B:\n\tgoto L_005D;\nL_005D:\n\tUnco.RewardSystem.ShopItemConverter::Initialize();\n\tv109 = 0xB28D000 + 0x3C8;\n\tv93 = System.String::IsNullOrEmpty(lootType);\n\tv134 = ~v93;\n\tv95 = ~v134;\n\tif (v95) goto L_0027;\nL_0066:\n\tv110 = converter == 0;\n\tif (v110) goto L_0094;\n\tgoto L_0078;\nL_0078:\n\tSystem.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::set_Item(v141._converters, lootType, converter);\n\tv173 = System.String::Concat(\"[ShopItemConverter] Manually registered converter for type '\", lootType, \"'\");\n\tv182 = *([v109 @ X22_v2 (System.Int32)]);\n\tv177 = *([v182 @ X8_v14+E4]) == 0;\n\tif (v177) goto L_00AF;\n\tUnityEngine.Debug::Log(v173);\n\treturn;\nL_0094:\n\tgoto L_00A1;\nL_00A1:\n\tUnityEngine.Debug::LogError(\"[ShopItemConverter] Cannot register null converter\");\n\treturn;\nL_00AF:\n\tUnityEngine.Debug::Log(v173);\n\treturn;\n")]
		public static void RegisterConverter(string lootType, IShopItemConverter converter)
		{
			//IL_0110: Expected O, but got I4
			int num;
			if (_initialized)
			{
				num = 187224064 + 968;
				if (string.IsNullOrEmpty(lootType))
				{
					goto IL_0062;
				}
			}
			else
			{
				Initialize();
				num = 187224064 + 968;
				if (string.IsNullOrEmpty(lootType))
				{
					goto IL_0062;
				}
			}
			if (converter != null)
			{
				_converters[lootType] = converter;
				string message = "[ShopItemConverter] Manually registered converter for type '" + lootType + "'";
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X8_v14+E4]");
				if ((nint)0 != 0)
				{
					Debug.Log(message);
				}
				else
				{
					Debug.Log(message);
				}
			}
			else
			{
				Debug.LogError("[ShopItemConverter] Cannot register null converter");
			}
			return;
			IL_0062:
			Debug.LogError("[ShopItemConverter] Cannot register converter with empty lootType");
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x81D9244", Offset = "0x81D9244", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0014;\nL_0014:\n\tv46 = v43._initialized == 0;\n\tif (v46) goto L_0045;\n\tgoto L_0022;\nL_0022:\n\tv103 = System.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::get_Keys(v82._converters);\n\treturnVal2 = System.Linq.Enumerable::ToArray(v103);\n\treturn returnVal2;\nL_0045:\n\tgoto L_0046;\nL_0046:\n\tUnco.RewardSystem.ShopItemConverter::Initialize();\n\tgoto L_0022;\n")]
		public static string[] GetRegisteredTypes()
		{
			if (!_initialized)
			{
				Initialize();
			}
			IEnumerable<object> keys = _converters.Keys;
			return (string[])keys.ToArray();
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x81D934C", Offset = "0x81D934C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv52 = v49._initialized == 0;\n\tif (v52) goto L_0044;\n\tgoto L_002B;\nL_002B:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::ContainsKey(v87._converters, lootType);\n\treturn returnVal1;\nL_0044:\n\tgoto L_0045;\nL_0045:\n\tUnco.RewardSystem.ShopItemConverter::Initialize();\n\tgoto L_002B;\n")]
		public static bool HasConverter(string lootType)
		{
			if (!_initialized)
			{
				Initialize();
			}
			return _converters.ContainsKey(lootType);
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x81D9448", Offset = "0x81D9448", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv43._initialized = 0;\n\tUnco.RewardSystem.ShopItemConverter::Initialize();\n\treturn;\n")]
		public static void ForceReinitialize()
		{
			_initialized = false;
			Initialize();
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x81D94C4", Offset = "0x81D94C4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv62._initialized = 0;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, Unco.RewardSystem.IShopItemConverter>::.ctor(v49);\n\tv58._converters = v49;\n")]
		static ShopItemConverter()
		{
			Dictionary<string, IShopItemConverter> converters = new Dictionary<string, IShopItemConverter>();
			_converters = converters;
			_initialized = false;
		}
	}
}
