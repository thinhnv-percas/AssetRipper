using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200001C")]
	public static class RewardExtensions
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200001D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000031")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000032")]
			public static Func<ShopItemData, bool> _003C_003E9__1_1;

			[Token(Token = "0x4000033")]
			public static Func<LootDrop, bool> _003C_003E9__7_0;

			[Token(Token = "0x4000034")]
			public static Func<LootDrop, string> _003C_003E9__7_1;

			[Token(Token = "0x4000035")]
			public static Func<IGrouping<string, LootDrop>, string> _003C_003E9__7_2;

			[Token(Token = "0x4000036")]
			public static Func<IGrouping<string, LootDrop>, List<LootDrop>> _003C_003E9__7_3;

			[Token(Token = "0x4000037")]
			public static Func<LootDrop, bool> _003C_003E9__10_0;

			[Token(Token = "0x4000038")]
			public static Func<LootDrop, bool> _003C_003E9__11_0;

			[Token(Token = "0x4000039")]
			public static Func<LootDrop, int> _003C_003E9__12_0;

			[Token(Token = "0x6000064")]
			[Address(RVA = "0x81D74D8", Offset = "0x81D74D8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.RewardSystem.RewardExtensions+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000065")]
			[Address(RVA = "0x81D753C", Offset = "0x81D753C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CConvertToShopItemData_003Eb__1_1(ShopItemData item)
			{
				bool flag = item == null;
				return !flag;
			}

			internal bool _003CGroupByType_003Eb__7_0(LootDrop ld)
			{
				if (string.IsNullOrEmpty(ld.LootType))
				{
					return false;
				}
				bool flag = string.IsNullOrEmpty(ld.LootData);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}

			internal string _003CGroupByType_003Eb__7_1(LootDrop ld)
			{
				return ld.LootType;
			}

			internal string _003CGroupByType_003Eb__7_2(IGrouping<string, LootDrop> g)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RewardExtensions._003C_003Ec::_003CGroupByType_003Eb__7_2");
				return default;
			}

			internal List<LootDrop> _003CGroupByType_003Eb__7_3(IGrouping<string, LootDrop> g)
			{
				return g.ToList();
			}

			internal bool _003CAreValid_003Eb__10_0(LootDrop ld)
			{
				if (string.IsNullOrEmpty(ld.LootType))
				{
					return false;
				}
				bool flag = string.IsNullOrEmpty(ld.LootData);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}

			internal bool _003CValidOnly_003Eb__11_0(LootDrop ld)
			{
				if (string.IsNullOrEmpty(ld.LootType))
				{
					return false;
				}
				bool flag = string.IsNullOrEmpty(ld.LootData);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}

			internal int _003CSortByPriority_003Eb__12_0(LootDrop ld)
			{
				if (ld.LootType == "resource")
				{
					return 100;
				}
				if (ld.LootType == "booster")
				{
					return 2;
				}
				return 50;
			}
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x81D5F90", Offset = "0x81D5F90", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv68 = System.String::IsNullOrEmpty(lootDrop.LootData);\n\tv72 = ~v68;\n\tif (v72) goto L_0065;\nL_003B:\n\tv76 = lootDrop.LootType;\n\t// 64 Box v81 @ X0_v12 (System.Object), typeof(Unco.RewardSystem.LootDrop), &v76 @ stack_-60_v3 (System.String)\n\tv163 = System.String::Format(\"[RewardExtensions] Cannot convert invalid LootDrop: {0}\", v81);\n\tgoto L_004F;\nL_0065:\n\tgoto L_006B;\nL_006B:\n\tv76 = lootDrop.LootType;\n\tv122 = Unco.RewardSystem.ShopItemConverter::TryConvertShopItemData(&v76 @ stack_-60_v3 (System.String), sourceType, &v119 @ stack_-68_v4 (Unco.RewardSystem.ShopItemData), customTransactionData);\n\tv170 = ~v122;\n\tif (v170) goto L_0081;\n\treturn v119;\nL_0081:\n\tv76 = lootDrop.LootType;\n\t// 134 Box v192 @ X0_v22 (System.Object), typeof(Unco.RewardSystem.LootDrop), &v76 @ stack_-60_v3 (System.String)\n\tv163 = System.String::Format(\"[RewardExtensions] Failed to convert LootDrop: {0}\", v192);\n\tgoto L_004F;\nL_002E:\n\tv56 = System.String::IsNullOrEmpty(lootDrop.LootType);\n\tv61 = v56 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_003B;\nL_004F:\n\tUnityEngine.Debug::LogWarning(v163);\n\treturn 0;\n")]
		public unsafe static ShopItemData ConvertToShopItemData(this LootDrop lootDrop, string sourceType, string customTransactionData = "")
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardExtensions::ConvertToShopItemData");
			return default;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x81D66E4", Offset = "0x81D66E4", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv52.sourceType = sourceType;\n\tv52.customTransactionData = customTransactionData;\n\tv80 = lootDrops == 0;\n\tif (v80) goto L_009B;\n\tv135 = new System.Func`2<Unco.RewardSystem.LootDrop, Unco.RewardSystem.ShopItemData>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, Unco.RewardSystem.ShopItemData>::.ctor(v135, v52, Il2CppMethodInfo);\n\tv155 = System.Linq.Enumerable::Select(lootDrops, v135);\n\tgoto L_006C;\n\tgoto L_007A;\nL_008B:\n\tv194 = System.Linq.Enumerable::Where(v155, v190);\n\treturnVal3 = System.Linq.Enumerable::ToList(v194);\n\treturn returnVal3;\nL_009B:\n\tv139 = new System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>();\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::.ctor(v139);\n\treturn v139;\nL_0039:\n\tv52 = new Unco.RewardSystem.RewardExtensions+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v52);\nL_006C:\n\tv175 = v173.<>9__1_1 == 0;\n\tv176 = ~v175;\n\tv190 = v173.<>9__1_1;\n\tif (v176) goto L_008B;\nL_007A:\n\tv202 = new System.Func`2<Unco.RewardSystem.ShopItemData, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.ShopItemData, System.Boolean>::.ctor(v202, v197.<>9, Il2CppMethodInfo);\n\tv207.<>9__1_1 = v202;\n\tv190 = v202;\n")]
		public unsafe static List<ShopItemData> ConvertToShopItemData(this IEnumerable<LootDrop> lootDrops, string sourceType, string customTransactionData = "")
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardExtensions::ConvertToShopItemData");
			return default;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x81D6928", Offset = "0x81D6928", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.RewardSystem.LootEntry::GetRandomLootDrop(entry);\n\treturn returnVal1;\n")]
		public unsafe static LootDrop ToLootDrop(this LootEntry entry)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardExtensions::ToLootDrop");
			return default;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x81D692C", Offset = "0x81D692C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\treturnVal1 = System.String::op_Equality(lootDrop.LootType, \"resource\");\n\treturn returnVal1;\n")]
		public static bool IsResource(this LootDrop lootDrop)
		{
			return lootDrop.LootType == "resource";
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x81D6984", Offset = "0x81D6984", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\treturnVal1 = System.String::op_Equality(lootDrop.LootType, \"booster\");\n\treturn returnVal1;\n")]
		public static bool IsBooster(this LootDrop lootDrop)
		{
			return lootDrop.LootType == "booster";
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x81D69DC", Offset = "0x81D69DC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.Amount = 0f;\n\treturnBuffer.LootData = 0;\n\treturnBuffer.LootType = lootDrop.LootType;\n\treturnBuffer.LootData = lootDrop.LootData;\n\treturnBuffer.Amount = newAmount;\n\treturn returnBuffer;\n")]
		public static LootDrop WithAmount(this LootDrop lootDrop, float newAmount)
		{
			LootDrop result = default(LootDrop);
			result.Amount = 0f;
			result.LootData = null;
			result.LootType = lootDrop.LootType;
			result.LootData = lootDrop.LootData;
			result.Amount = newAmount;
			return result;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x81D6A3C", Offset = "0x81D6A3C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.Amount = 0f;\n\treturnBuffer.LootData = 0;\n\tv26 = lootDrop.Amount * multiplier;\n\treturnBuffer.LootType = lootDrop.LootType;\n\treturnBuffer.LootData = lootDrop.LootData;\n\treturnBuffer.Amount = v26;\n\treturn returnBuffer;\n")]
		public static LootDrop MultiplyAmount(this LootDrop lootDrop, float multiplier)
		{
			LootDrop result = default(LootDrop);
			result.Amount = 0f;
			result.LootData = null;
			float amount = lootDrop.Amount * multiplier;
			result.LootType = lootDrop.LootType;
			result.LootData = lootDrop.LootData;
			result.Amount = amount;
			return result;
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x81D6AA0", Offset = "0x81D6AA0", Length = "0x3BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tgoto L_0046;\nL_0046:\n\t;\n\tv100 = v65.<>9__7_0;\n\tv67 = v65.<>9__7_0 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0086;\n\tgoto L_006D;\nL_0050:\n\tv59 = new System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<Unco.RewardSystem.LootDrop>>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<Unco.RewardSystem.LootDrop>>::.ctor(v59);\n\treturn v59;\nL_006D:\n\tgoto L_0075;\nL_0086:\n\tv106 = System.Linq.Enumerable::Where(lootDrops, v100);\n\tgoto L_008D;\nL_008D:\n\t;\n\tv175 = v173.<>9__7_1 == 0;\n\tv176 = ~v175;\n\tv207 = v173.<>9__7_1;\n\tif (v176) goto L_00B9;\n\tgoto L_00A0;\nL_00A0:\n\tgoto L_00A8;\nL_00B9:\n\tv213 = System.Linq.Enumerable::GroupBy(v106, v207);\n\tgoto L_00C0;\nL_00C0:\n\tv342 = v241.<>9__7_2;\n\tv243 = v241.<>9__7_2 == 0;\n\tif (v243) goto L_00D8;\n\tgoto L_00C7;\nL_00C7:\n\t;\n\tv296 = v294.<>9__7_3 == 0;\n\tv297 = ~v296;\n\tv327 = v294.<>9__7_3;\n\tv341 = v342;\n\tif (v297) goto L_0122;\n\tgoto L_00FF;\nL_00D8:\n\tgoto L_00E0;\n\tv342 = v315;\n\tgoto L_00C7;\nL_00FF:\n\tgoto L_0107;\nL_0122:\n\treturnVal2 = System.Linq.Enumerable::ToDictionary(v213, v341, v327);\n\treturn returnVal2;\nL_003D:\n\tv47 = lootDrops == 0;\n\tif (v47) goto L_0050;\nL_0075:\n\tv170 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>::.ctor(v170, v165.<>9, Il2CppMethodInfo);\n\tv219.<>9__7_0 = v170;\n\tv100 = v170;\nL_00A8:\n\tv240 = new System.Func`2<Unco.RewardSystem.LootDrop, System.String>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.String>::.ctor(v240, v235.<>9, Il2CppMethodInfo);\n\tv273.<>9__7_1 = v240;\n\tv207 = v240;\nL_00E0:\n\tv315 = new System.Func`2<System.Linq.IGrouping`2<System.String, Unco.RewardSystem.LootDrop>, System.String>();\n\tSystem.Func`2<System.Linq.IGrouping`2<System.String, Unco.RewardSystem.LootDrop>, System.String>::.ctor(v315, v310.<>9, Il2CppMethodInfo);\n\tv363.<>9__7_2 = v315;\nL_0107:\n\tv375 = new System.Func`2<System.Linq.IGrouping`2<System.String, Unco.RewardSystem.LootDrop>, System.Collections.Generic.List`1<Unco.RewardSystem.LootDrop>>();\n\tSystem.Func`2<System.Linq.IGrouping`2<System.String, Unco.RewardSystem.LootDrop>, System.Collections.Generic.List`1<Unco.RewardSystem.LootDrop>>::.ctor(v375, v370.<>9, Il2CppMethodInfo);\n\tv381.<>9__7_3 = v375;\n\tv327 = v375;\n\tv341 = v342;\n")]
		public static Dictionary<string, List<LootDrop>> GroupByType(this IEnumerable<LootDrop> lootDrops)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardExtensions::GroupByType");
			return default;
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x81D6E5C", Offset = "0x81D6E5C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv51.lootType = lootType;\n\tv71 = lootDrops == 0;\n\tif (v71) goto L_0053;\n\tv79 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>::.ctor(v79, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::Where(lootDrops, v79);\n\treturn returnVal2;\nL_0053:\n\tgoto L_0054;\nL_0054:\n\tv125 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tv128 = *([v125 @ X0_v23 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]) & 1;\n\tv129 = v128 == 0;\n\tv141 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tif (v129) goto L_007C;\nL_005C:\n\tgoto L_0064;\nL_0064:\n\tgoto L_0071;\nL_0071:\n\treturn v109.Instance;\n\tv131 = System.Linq.Enumerable::Empty();\n\tv134 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tv147 = *([v134 @ X0_v15 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]) & 1;\n\tv148 = v147 == 0;\n\tv136 = ~v148;\n\tv141 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tif (v136) goto L_005C;\nL_007C:\n\tv144 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = *([v144 @ X0_v12+E4]) == 0;\n\tv151 = ~v165;\n\tif (v151) goto L_0064;\n\tgoto L_0089;\nL_0089:\n\tgoto L_0071;\nL_0026:\n\tv51 = new Unco.RewardSystem.RewardExtensions+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v51);\n")]
		public static IEnumerable<LootDrop> OfType(this IEnumerable<LootDrop> lootDrops, string lootType)
		{
			if (lootDrops != null)
			{
				Func<LootDrop, bool> predicate = (LootDrop ld) => ld.LootType == lootType;
				return lootDrops.Where(predicate);
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X0_v23 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X0_v12+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return global::System.Linq.Enumerable.Empty<LootDrop>();
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x4C61B6C", Offset = "0x4C61B6C", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tgoto L_0029;\n\tgoto L_0029;\n\tv48 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0038:\n\tv74 = new Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__DisplayClass9_0`1<T>>();\n\tv82 = Unco.RewardSystem.RewardExtensions+<>c__DisplayClass9_0`1<T>::.ctor(v74);\n\tv86 = 0x8BF6A1C(v61, resourceType, *([v55 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv92 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__DisplayClass9_0`1<T>>;\n\tv97 = 0x21C1058(v74, *([v92 @ X8_v12 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__DisplayClass9_0`1<T>>)+80]), v61, *([v55 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = lootDrops == 0;\n\tif (v100) goto L_FFFFFFFF;\n\tv154 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>::.ctor(v154, v74, Il2CppMethodInfo);\n\tv213 = System.Linq.Enumerable::Where(lootDrops, v154);\n\tv215 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tv218 = *([v215 @ X0_v18 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+135]) & 1;\n\tv219 = v218 == 0;\n\tif (v219) goto L_0077;\n\tgoto L_0069;\nL_0069:\n\tv229 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tv232 = *([v229 @ X0_v50 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+135]) & 1;\n\tv233 = v232 == 0;\nL_FFFFFFFF:\n\tv239 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\nL_FFFFFFFF:\n\tv249 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tif (v233) goto L_0085;\nL_006F:\n\tv245 = *([v239 @ X0_v48 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+B8]);\n\tv171 = *([v245 @ X8_v62 (Il2CppStaticFields<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+8]);\n\tv247 = *([v245 @ X8_v62 (Il2CppStaticFields<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+8]) == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_00C7;\n\tgoto L_008C;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_00CA;\nL_0077:\n\tv222 = 0x220C238(Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv238 = *([v222 @ X0_v47+E4]) == 0;\n\tv225 = ~v238;\n\tif (v225) goto L_0069;\n\tv240 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tv255 = *([v240 @ X0_v46 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+135]) & 1;\n\tv256 = v255 == 0;\n\tv242 = ~v256;\nL_FFFFFFFF:\n\tv239 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\nL_FFFFFFFF:\n\tv249 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tif (v242) goto L_006F;\nL_0085:\n\tv252 = 0x220C238(v249, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv269 = *([v252 @ X0_v43+B8]);\n\tv171 = *([v269 @ X8_v55+8]);\n\tv273 = *([v269 @ X8_v55+8]) == 0;\n\tv266 = ~v273;\n\tif (v266) goto L_00C7;\nL_008C:\n\tv279 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tv282 = *([v279 @ X0_v22 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+135]) & 1;\n\tv283 = v282 == 0;\n\tif (v283) goto L_00E2;\n\tgoto L_009C;\nL_009C:\n\tgoto L_00A3;\nL_00A3:\n\tv318 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Single>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Single>::.ctor(v318, v314.<>9, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv332 = Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>;\n\tgoto L_00B3;\nL_00B3:\n\tv333 = *([v332 @ X0_v31 (Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+B8]);\n\t*([v333 @ X8_v43 (Il2CppStaticFields<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>)+8]) = v318;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv171 = v318;\nL_00C7:\n\treturnVal2 = System.Linq.Enumerable::Sum(v213, v171);\nL_00CA:\n\tv173 = *([A4731E0]);\n\tv103 = *([v173 @ X9_v5]) != *([v25 @ X8_v2]);\n\tif (v103) goto L_00F1;\n\treturn returnVal2;\nL_00E2:\n\tv286 = 0x220C238(Il2CppClass<Unco.RewardSystem.RewardExtensions+<>c__9`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv303 = *([v286 @ X0_v26+E4]) == 0;\n\tv289 = ~v303;\n\tif (v289) goto L_009C;\n\tgoto L_00EF;\nL_00EF:\n\tgoto L_00A3;\nL_00F1:\n\tv150 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0029:\n\tv55 = Il2CppClass<T>;\n\tv59 = *([v55 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv60 = v59 & 0x1FFFFFFF0;\n\t// 46 StackAlloc v61 @ X23_v1 (System.Byte*), v60 @ X10_v2 (System.Int32)\n\tgoto L_0038;\n")]
		public unsafe static float GetResourceTotal<T>(this IEnumerable<LootDrop> lootDrops, T resourceType) where T : Enum
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardExtensions::GetResourceTotal");
			return default;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x81D7000", Offset = "0x81D7000", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tgoto L_0028;\nL_0028:\n\t;\n\tv126 = v70.<>9__10_0;\n\tv72 = v70.<>9__10_0 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0068;\n\tgoto L_0046;\nL_0039:\n\treturn 0;\nL_0046:\n\tgoto L_004E;\nL_0068:\n\treturnVal2 = System.Linq.Enumerable::All(lootDrops, v126);\n\treturn returnVal2;\nL_001F:\n\tv47 = lootDrops == 0;\n\tif (v47) goto L_0039;\nL_004E:\n\tv144 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>::.ctor(v144, v139.<>9, Il2CppMethodInfo);\n\tv149.<>9__10_0 = v144;\n\tv126 = v144;\n")]
		public static bool AreValid(this IEnumerable<LootDrop> lootDrops)
		{
			if (lootDrops != null)
			{
				Func<LootDrop, bool> predicate = _003C_003Ec._003C_003E9__10_0;
				if (_003C_003Ec._003C_003E9__10_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__10_0 = delegate(LootDrop ld)
					{
						if (string.IsNullOrEmpty(ld.LootType))
						{
							return false;
						}
						bool flag = string.IsNullOrEmpty(ld.LootData);
						return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
					});
				}
				return lootDrops.All(predicate);
			}
			return false;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x81D7138", Offset = "0x81D7138", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_002B;\nL_002B:\n\t;\n\tv104 = v66.<>9__11_0;\n\tv68 = v66.<>9__11_0 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0084;\n\tgoto L_0062;\nL_0037:\n\tgoto L_0038;\nL_0038:\n\tv71 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tv74 = *([v71 @ X0_v17 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]) & 1;\n\tv75 = v74 == 0;\n\tv129 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tif (v75) goto L_0090;\nL_0040:\n\tgoto L_0048;\nL_0048:\n\tgoto L_0055;\nL_0055:\n\treturn v188.Instance;\nL_0062:\n\tgoto L_006A;\nL_0084:\n\treturnVal1 = System.Linq.Enumerable::Where(lootDrops, v104);\n\treturn returnVal1;\n\tv77 = 0x220C2B8(Il2CppMethodInfo, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv122 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tv135 = *([v122 @ X0_v9 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]) & 1;\n\tv136 = v135 == 0;\n\tv124 = ~v136;\n\tv129 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tif (v124) goto L_0040;\nL_0090:\n\tv132 = 0x220C238(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv160 = *([v132 @ X0_v6+E4]) == 0;\n\tv146 = ~v160;\n\tif (v146) goto L_0048;\n\tgoto L_009D;\nL_009D:\n\tgoto L_0055;\nL_0022:\n\tv47 = lootDrops == 0;\n\tif (v47) goto L_0037;\nL_006A:\n\tv168 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Boolean>::.ctor(v168, v163.<>9, Il2CppMethodInfo);\n\tv211.<>9__11_0 = v168;\n\tv104 = v168;\n")]
		public static IEnumerable<LootDrop> ValidOnly(this IEnumerable<LootDrop> lootDrops)
		{
			if (lootDrops != null)
			{
				Func<LootDrop, bool> predicate = _003C_003Ec._003C_003E9__11_0;
				if (_003C_003Ec._003C_003E9__11_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__11_0 = delegate(LootDrop ld)
					{
						if (string.IsNullOrEmpty(ld.LootType))
						{
							return false;
						}
						bool flag2 = string.IsNullOrEmpty(ld.LootData);
						return (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
					});
				}
				return lootDrops.Where(predicate);
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v17 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X0_v6+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return global::System.Linq.Enumerable.Empty<LootDrop>();
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x81D7308", Offset = "0x81D7308", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_002B;\nL_002B:\n\t;\n\tv104 = v66.<>9__12_0;\n\tv68 = v66.<>9__12_0 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0084;\n\tgoto L_0062;\nL_0037:\n\tgoto L_0038;\nL_0038:\n\tv71 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tv74 = *([v71 @ X0_v17 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]) & 1;\n\tv75 = v74 == 0;\n\tv129 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tif (v75) goto L_0090;\nL_0040:\n\tgoto L_0048;\nL_0048:\n\tgoto L_0055;\nL_0055:\n\treturn v188.Instance;\nL_0062:\n\tgoto L_006A;\nL_0084:\n\treturnVal1 = System.Linq.Enumerable::OrderBy(lootDrops, v104);\n\treturn returnVal1;\n\tv77 = 0x220C2B8(Il2CppMethodInfo, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv122 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tv135 = *([v122 @ X0_v9 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]) & 1;\n\tv136 = v135 == 0;\n\tv124 = ~v136;\n\tv129 = Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>;\n\tif (v124) goto L_0040;\nL_0090:\n\tv132 = 0x220C238(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv160 = *([v132 @ X0_v6+E4]) == 0;\n\tv146 = ~v160;\n\tif (v146) goto L_0048;\n\tgoto L_009D;\nL_009D:\n\tgoto L_0055;\nL_0022:\n\tv47 = lootDrops == 0;\n\tif (v47) goto L_0037;\nL_006A:\n\tv168 = new System.Func`2<Unco.RewardSystem.LootDrop, System.Int32>();\n\tSystem.Func`2<Unco.RewardSystem.LootDrop, System.Int32>::.ctor(v168, v163.<>9, Il2CppMethodInfo);\n\tv211.<>9__12_0 = v168;\n\tv104 = v168;\n")]
		public static IEnumerable<LootDrop> SortByPriority(this IEnumerable<LootDrop> lootDrops)
		{
			if (lootDrops != null)
			{
				Func<LootDrop, int> keySelector = _003C_003Ec._003C_003E9__12_0;
				if (_003C_003Ec._003C_003E9__12_0 == null)
				{
					keySelector = (_003C_003Ec._003C_003E9__12_0 = delegate(LootDrop ld)
					{
						if (ld.LootType == "resource")
						{
							return 100;
						}
						return (ld.LootType == "booster") ? 2 : 50;
					});
				}
				return lootDrops.OrderBy(keySelector);
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v17 (Il2CppClass<System.Linq.EmptyEnumerable`1<Unco.RewardSystem.LootDrop>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X0_v6+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return global::System.Linq.Enumerable.Empty<LootDrop>();
		}
	}
}
