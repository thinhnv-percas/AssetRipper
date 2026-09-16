using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000064")]
	public class AdvertisingReportSystem : UpdateSystem
	{
		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x74B2A0", Offset = "0x74B2A0")]
		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEvent OnApplicationStart;

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x30")]
		public GlobalEvent OnBeforeSplashScreen;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x38")]
		public GlobalEvent OnAfterSplashScreen;

		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x74B2E8", Offset = "0x74B2E8")]
		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x40")]
		public GlobalEvent InterstitialCompleted;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x48")]
		public GlobalEvent RewardedCompleted;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x50")]
		public GlobalEvent RewardedSkipped;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x58")]
		public GlobalEvent NoInternet;

		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x74B330", Offset = "0x74B330")]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x60")]
		public GlobalEventInt OnSelectWeaponClick;

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x68")]
		public GlobalEventInt OnAmmoUpgradeClick;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x70")]
		public GlobalEventInt OnPowerUpgradeClick;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x78")]
		public GlobalEventInt OnBuyWeaponClick;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x80")]
		public GlobalEvent AttackSpeedUpgradeClick;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x88")]
		public GlobalEvent OfflineRewardUpgradeClick;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x90")]
		public GlobalEvent BonusGoldUpgradeClick;

		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x74B378", Offset = "0x74B378")]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x98")]
		public GlobalEvent TapToPlay;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0xA0")]
		public GlobalEventInt TapToComplete;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0xA8")]
		public GlobalEvent ShowMainMenu;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0xB0")]
		public GlobalEvent ShowWinScreen;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0xB8")]
		public GlobalEvent ShowLoseScreen;

		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x74B3C0", Offset = "0x74B3C0")]
		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0xC0")]
		public GlobalEventString SendAnalyticsEvent;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0xC8")]
		private Filter gameStateFilter;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0xD0")]
		private GameConfig config;

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0xCC2EB4", Offset = "0xCC2EB4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EED390]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202375A]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.gameStateFilter = v52;\n\tv58 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v58;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<GameStateComponent>();
			gameStateFilter = filter;
			GameConfig instance = GameConfig.Instance;
			config = instance;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0xCC2F2C", Offset = "0xCC2F2C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1F00790]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, data, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202375B]) = v41;\nL_0022:\n\tMorpeh.Globals.BaseGlobalEvent`1<System.String>::Publish(this.SendAnalyticsEvent, data);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void sendReport(string data)
		{
			SendAnalyticsEvent.Publish(data);
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0xCC2F94", Offset = "0xCC2F94", Length = "0xA14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1EE6680]);\n\tv35 = *([v34 @ X8_v154]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202375C]) = v54;\nL_0023:\n\tv63 = Morpeh.Filter::GetEnumerator(this.gameStateFilter);\n\tv169 = v63.world;\nL_0040:\n\tthis = 0x15F75B8(&v169 @ stack_-A0_v37 (Morpeh.World), 0, v257, v243, v40, v41, v42, v43, v63.world, v45, v46, v47, v48, v49, v50, v51);\n\tv327 = this & 1;\n\tv328 = v327 == 0;\n\tif (v328) goto L_026E;\n\tv212 = Il2CppMethodInfo;\n\tv538 = *([v378 @ stack_-78]);\n\tv257 = *([v212 @ X21_v41 (Il2CppMethodInfo)+48]);\n\tv434 = *([v538 @ X8_v48 (System.String)+126]) == 0;\n\tif (v434) goto L_006A;\n\tv694 = *([v538 @ X8_v48 (System.String)+B0]) + 8;\nL_0056:\n\tv699 = *([v694 @ X11_v44-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v699) goto L_006D;\n\tv693 = v693 + 1;\n\tv807 = v693 < *([v538 @ X8_v48 (System.String)+126]);\n\tv507 = ~v807;\n\tv694 = v694 + 0x10;\n\tv491 = ~v507;\n\tif (v491) goto L_0056;\nL_006A:\n\tthis = 0x8909C4(v378, Il2CppClass<Morpeh.IEntity>, v257, v243, v40, v41, v42, v43, v63.world, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0073;\nL_006D:\n\tv809 = *([v694 @ X11_v44]) + v257;\n\tv810 = v809 << 4;\n\tv538 = v538 + v810;\n\tthis = v538 + 0x130;\nL_0073:\n\tv826 = Morpeh.IEntity::GetComponent(*([this @ X0 (GBG.Pinata.ECS.Systems.AdvertisingReportSystem)+8]));\n\t*([v826 @ X0_v103 (GameStateComponent&)])(this, v378, v826, v257, v243, v40, v41, v42, v43, v63.world, v45, v46, v47, v48, v49, v50, v51);\n\tv538 = *([this @ X0 (GBG.Pinata.ECS.Systems.AdvertisingReportSystem)]);\n\tv892 = *([this @ X0 (GBG.Pinata.ECS.Systems.AdvertisingReportSystem)]) != 0x14;\n\tif (v892) goto L_FFFFFFFF;\n\tgoto L_0095;\nL_0095:\n\tv182 = v538 != 0;\n\tif (v182) goto L_FFFFFFFF;\n\tgoto L_009F;\nL_009F:\n\tv1134 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnApplicationStart);\n\tv1184 = v1134 == 0;\n\tif (v1184) goto L_00AC;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"UserExperience>Start>Application\");\nL_00AC:\n\tv1282 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnBeforeSplashScreen);\n\tv1330 = v1282 == 0;\n\tif (v1330) goto L_00B9;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"UserExperience>Start>SplashScreen\");\nL_00B9:\n\tv1429 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnAfterSplashScreen);\n\tv1478 = v1429 == 0;\n\tif (v1478) goto L_00C6;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"UserExperience>End>SplashScreen\");\nL_00C6:\n\tv1575 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.InterstitialCompleted);\n\tv1624 = v1575 == 0;\n\tif (v1624) goto L_00DA;\n\tv1678 = System.String::Concat(\"ADs>Interstitial>\", *([v538 @ X8_v48 (System.String)]), \">Completed\");\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v1678);\nL_00DA:\n\tv1730 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.RewardedCompleted);\n\tv1779 = v1730 == 0;\n\tif (v1779) goto L_00EC;\n\tv1830 = System.String::Concat(\"ADs>Rewarded>\", *([v538 @ X8_v48 (System.String)]), \">Completed\");\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v1830);\nL_00EC:\n\tv1882 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.RewardedSkipped);\n\tv1931 = v1882 == 0;\n\tif (v1931) goto L_00FE;\n\tv1982 = System.String::Concat(\"ADs>Rewarded>\", *([v538 @ X8_v48 (System.String)]), \">Skipped\");\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v1982);\nL_00FE:\n\tv2034 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.NoInternet);\n\tv2083 = v2034 == 0;\n\tif (v2083) goto L_0110;\n\tv2134 = System.String::Concat(\"ADs>Rewarded>\", *([v538 @ X8_v48 (System.String)]), \">NoInternet\");\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v2134);\nL_0110:\n\tv2157 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnSelectWeaponClick);\n\tv2159 = v2157 == 0;\n\tif (v2159) goto L_0135;\n\tv1370 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_BatchedChanges(this.OnSelectWeaponClick);\n\tv2180 = v1370._size == 0;\n\tv2167 = ~v2180;\n\tif (v2167) goto L_0122;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0122:\n\tv2192 = v1370._items;\n\tv2194 = v2192[0];\n\t// 295 Box v2196 @ X0_v225 (System.Object), typeof(System.Int32), &v2194 @ X8_v130 (System.Int32)\n\tv2201 = System.String::Format(\"Weapons>Weapon-{0}>Select\", v2196);\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v2201);\nL_0135:\n\tv2171 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnAmmoUpgradeClick);\n\tv2177 = v2171 == 0;\n\tif (v2177) goto L_015A;\n\tv1469 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_BatchedChanges(this.OnAmmoUpgradeClick);\n\tv2205 = v1469._size == 0;\n\tv2187 = ~v2205;\n\tif (v2187) goto L_0147;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0147:\n\tv2216 = v1469._items;\n\tv2218 = v2216[0];\n\t// 332 Box v2220 @ X0_v216 (System.Object), typeof(System.Int32), &v2218 @ X8_v125 (System.Int32)\n\tv2225 = System.String::Format(\"Weapons>Weapon-{0}>Upgraded\", v2220);\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v2225);\nL_015A:\n\tv2197 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnPowerUpgradeClick);\n\tv2203 = v2197 == 0;\n\tif (v2203) goto L_017F;\n\tv1615 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_BatchedChanges(this.OnPowerUpgradeClick);\n\tv2229 = v1615._size == 0;\n\tv2212 = ~v2229;\n\tif (v2212) goto L_016C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_016C:\n\tv2240 = v1615._items;\n\tv2242 = v2240[0];\n\t// 369 Box v2244 @ X0_v207 (System.Object), typeof(System.Int32), &v2242 @ X8_v120 (System.Int32)\n\tv2250 = System.String::Format(\"Weapons>Weapon-{0}>Upgraded\", v2244);\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v2250);\nL_017F:\n\tv2221 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OnBuyWeaponClick);\n\tv2227 = v2221 == 0;\n\tif (v2227) goto L_01A4;\n\tv1721 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_BatchedChanges(this.OnBuyWeaponClick);\n\tv2254 = v1721._size == 0;\n\tv2236 = ~v2254;\n\tif (v2236) goto L_0191;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0191:\n\tv2262 = v1721._items;\n\tv2264 = v2262[0];\n\t// 406 Box v2266 @ X0_v198 (System.Object), typeof(System.Int32), &v2264 @ X8_v115 (System.Int32)\n\tv2272 = System.String::Format(\"Weapons>Weapon-{0}>Buy\", v2266);\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v2272);\nL_01A4:\n\tv2246 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.AttackSpeedUpgradeClick);\n\tv2252 = v2246 == 0;\n\tif (v2252) goto L_01B1;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"Upgrades>AttackSpeed>Upgrade\");\nL_01B1:\n\tv2268 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.OfflineRewardUpgradeClick);\n\tv2274 = v2268 == 0;\n\tif (v2274) goto L_01BE;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"Upgrades>OfflineReward>Upgrade\");\nL_01BE:\n\tv2281 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.BonusGoldUpgradeClick);\n\tv2283 = v2281 == 0;\n\tif (v2283) goto L_01CB;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"Upgrades>BonusGold>Upgrade\");\nL_01CB:\n\tv2290 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.TapToPlay);\n\tv2292 = v2290 == 0;\n\tif (v2292) goto L_01F9;\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, \"UserExperience>Start>Level\");\n\tv1774 = this.config;\n\tv1874 = System.Collections.Generic.Dictionary`2<System.String, Morpeh.Globals.GlobalVariableInt>::get_Item(v1774.GlobalIntegers, \"Level\");\n\tv2319 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v1874);\n\t// 491 Box v2325 @ X0_v187 (System.Object), typeof(System.Int32), &v2319 @ X0_v185 (System.Int32)\n\tv2334 = System.String::Format(\"Levels>Level-{0}>Start\", v2325);\n\tGBG.Pinata.ECS.Systems.AdvertisingReportSystem::sendReport(this, v2334);\nL_01F9:\n\tv2303 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(thi\n// ... truncated")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_0044: Expected O, but got I
			//IL_0b13: Expected O, but got I
			//IL_007f: Expected O, but got I
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_0123: Expected O, but got I
			//IL_0132: Expected O, but got I
			//IL_00cb: Expected O, but got I
			//IL_0278: Expected O, but got I4
			//IL_02dc: Expected O, but got I4
			//IL_0340: Expected O, but got I4
			//IL_03a4: Expected O, but got I4
			World world = gameStateFilter.GetEnumerator().world;
			object obj = default(object);
			while (true)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				string text;
				if ((uint)((ulong)(long)(IntPtr)this & 1uL) != 0)
				{
					IntPtr intPtr = (IntPtr)0;
					text = (string)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ X21_v41 (Il2CppMethodInfo)+48]");
					string text2 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ X8_v48 (System.String)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00e4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ X8_v48 (System.String)+B0]");
					object obj2 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X11_v44-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ X8_v48 (System.String)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00e4;
					}
					object obj3 = obj2 + (long)(IntPtr)text2;
					int num3 = (int)((long)(IntPtr)obj3 << 4);
					text = (string)((long)(IntPtr)text + (long)num3);
					AdvertisingReportSystem advertisingReportSystem = (AdvertisingReportSystem)((long)(IntPtr)text + 304L);
					goto IL_0b02;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
				IL_0b02:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (GBG.Pinata.ECS.Systems.AdvertisingReportSystem)+8]");
				ref GameStateComponent component = ref ((IEntity)0).GetComponent<GameStateComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v826 @ X0_v103 (GameStateComponent&)] (should have been resolved before IL gen)");
				text = (string)(object)this;
				string text3 = (((IntPtr)this != (IntPtr)20) ? "Game" : "FinishedScreen");
				text = ((text != null) ? text3 : "MenuScreen");
				if (OnApplicationStart.IsPublished)
				{
					sendReport("UserExperience>Start>Application");
				}
				if (OnBeforeSplashScreen.IsPublished)
				{
					sendReport("UserExperience>Start>SplashScreen");
				}
				if (OnAfterSplashScreen.IsPublished)
				{
					sendReport("UserExperience>End>SplashScreen");
				}
				if (InterstitialCompleted.IsPublished)
				{
					string data = "ADs>Interstitial>" + text + ">Completed";
					sendReport(data);
					object obj4 = 0;
					string text2 = ">Completed";
				}
				if (RewardedCompleted.IsPublished)
				{
					string data2 = "ADs>Rewarded>" + text + ">Completed";
					sendReport(data2);
					object obj4 = 0;
					string text2 = ">Completed";
				}
				if (RewardedSkipped.IsPublished)
				{
					string data3 = "ADs>Rewarded>" + text + ">Skipped";
					sendReport(data3);
					object obj4 = 0;
					string text2 = ">Skipped";
				}
				if (NoInternet.IsPublished)
				{
					string data4 = "ADs>Rewarded>" + text + ">NoInternet";
					sendReport(data4);
					object obj4 = 0;
					string text2 = ">NoInternet";
				}
				if (OnSelectWeaponClick.IsPublished)
				{
					List<int> batchedChanges = OnSelectWeaponClick.BatchedChanges;
					if (batchedChanges.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items = batchedChanges._items;
					int num4 = items[0];
					object arg = num4;
					string data5 = $"Weapons>Weapon-{arg}>Select";
					sendReport(data5);
					string text2 = null;
				}
				if (OnAmmoUpgradeClick.IsPublished)
				{
					List<int> batchedChanges2 = OnAmmoUpgradeClick.BatchedChanges;
					if (batchedChanges2.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items2 = batchedChanges2._items;
					int num5 = items2[0];
					object arg2 = num5;
					string data6 = $"Weapons>Weapon-{arg2}>Upgraded";
					sendReport(data6);
					string text2 = null;
				}
				if (OnPowerUpgradeClick.IsPublished)
				{
					List<int> batchedChanges3 = OnPowerUpgradeClick.BatchedChanges;
					if (batchedChanges3.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items3 = batchedChanges3._items;
					int num6 = items3[0];
					object arg3 = num6;
					string data7 = $"Weapons>Weapon-{arg3}>Upgraded";
					sendReport(data7);
					string text2 = null;
				}
				if (OnBuyWeaponClick.IsPublished)
				{
					List<int> batchedChanges4 = OnBuyWeaponClick.BatchedChanges;
					if (batchedChanges4.Count == 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items4 = batchedChanges4._items;
					int num7 = items4[0];
					object arg4 = num7;
					string data8 = $"Weapons>Weapon-{arg4}>Buy";
					sendReport(data8);
					string text2 = null;
				}
				if (AttackSpeedUpgradeClick.IsPublished)
				{
					sendReport("Upgrades>AttackSpeed>Upgrade");
				}
				if (OfflineRewardUpgradeClick.IsPublished)
				{
					sendReport("Upgrades>OfflineReward>Upgrade");
				}
				if (BonusGoldUpgradeClick.IsPublished)
				{
					sendReport("Upgrades>BonusGold>Upgrade");
				}
				if (TapToPlay.IsPublished)
				{
					sendReport("UserExperience>Start>Level");
					GameConfig gameConfig = config;
					GlobalVariableInt globalVariableInt = ((Dictionary<string, GlobalVariableInt>)gameConfig.GlobalIntegers).get_Item("Level");
					int value = globalVariableInt.Value;
					object arg5 = value;
					string data9 = $"Levels>Level-{arg5}>Start";
					sendReport(data9);
					string text2 = null;
				}
				if (TapToComplete.IsPublished)
				{
					sendReport("UserExperience>Start>Play");
				}
				if (ShowMainMenu.IsPublished)
				{
					sendReport("UserExperience>Start>Menu");
				}
				if (ShowWinScreen.IsPublished)
				{
					sendReport("UserExperience>End>Level");
					GameConfig gameConfig2 = config;
					GlobalVariableInt globalVariableInt2 = ((Dictionary<string, GlobalVariableInt>)gameConfig2.GlobalIntegers).get_Item("Level");
					int value2 = globalVariableInt2.Value;
					object arg6 = value2;
					string data10 = $"Levels>Level-{arg6}>End>WinScreen";
					sendReport(data10);
					string text2 = null;
				}
				if (ShowLoseScreen.IsPublished)
				{
					sendReport("UserExperience>End>Level");
					GameConfig gameConfig3 = config;
					GlobalVariableInt globalVariableInt3 = ((Dictionary<string, GlobalVariableInt>)gameConfig3.GlobalIntegers).get_Item("Level");
					if ((object)globalVariableInt3 == null)
					{
						break;
					}
					int value3 = globalVariableInt3.Value;
					object arg7 = value3;
					string data11 = $"Levels>Level-{arg7}>End>LoseScreen";
					sendReport(data11);
					string text2 = null;
				}
				continue;
				IL_00e4:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0b02;
			}
			NullReferenceException ex = new NullReferenceException();
			string text4 = default(string);
			if ((IntPtr)text4 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				if ((object)this == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0xCC39A8", Offset = "0xCC39A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdvertisingReportSystem()
		{
		}
	}
}
