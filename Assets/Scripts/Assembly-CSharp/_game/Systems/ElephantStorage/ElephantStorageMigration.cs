using System;
using System.Collections;
using System.Collections.Generic;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using Unco.AdSystem;
using Unco.RealTimeSystem.Runtime;
using Unco.ResourceSystem;
using Unco.SettingsSystem.Core;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Data;

namespace _game.Systems.ElephantStorage
{
	[Token(Token = "0x2000782")]
	public static class ElephantStorageMigration
	{
		[Token(Token = "0x40018FB")]
		private const string OLD_DATA_ANCHOR_KEY = "level_progress_pref";

		[Token(Token = "0x6001F9E")]
		[Address(RVA = "0x3D92634", Offset = "0x3D92634", Length = "0x244")]
		public static void MigrateIfNeeded(GameStorage storage, IPlayerDataHandler dataHandler)
		{
			if (storage.MigrationDone)
			{
				return;
			}
			string value = PlayerPrefs.GetString("level_progress_pref", "");
			if (string.IsNullOrEmpty(value))
			{
				storage.MigrationDone = true;
				return;
			}
			MigrateHealth(storage.Health);
			MigrateBoosters(storage.Boosters);
			LevelProgressPref progress = storage.Progress;
			if (TryReadOldValue<object>("level_progress_pref", out var _))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ stack_-50_v3 (System.Object)+10]");
				progress.CurrentLevel = 0;
			}
			MigrateResources(storage.Resources);
			MigrateMonetization(storage.Monetization);
			SettingsStorageData settings = storage.Settings;
			if (TryReadOldValue<int>("Settings", out var value3))
			{
				settings.Flags = value3;
			}
			MigrateTutorials(storage.Tutorials);
			MigrateFlows(storage.Flows);
			MigrateShop(storage.Shop);
			MigrateRealTime(storage.RealTime);
			storage.MigrationDone = true;
			dataHandler.Save();
		}

		[Token(Token = "0x6001F9F")]
		[Address(RVA = "0x3D92878", Offset = "0x3D92878", Length = "0x174")]
		private static void MigrateHealth(HealthStorageData health)
		{
			if (TryReadOldValue<int>("health-controller.current-health", out var value))
			{
				health.CurrentHealth = value;
			}
			if (TryReadOldValue<float>("health-controller.infinite-duration", out var value2))
			{
				health.InfiniteDuration = value2;
			}
			if (TryReadOldValue<object>("health-controller.pending-health", out var value3))
			{
				health.PendingHealthTime = (string)value3;
			}
			if (TryReadOldValue<bool>("initial_infinite_acquired", out var value4))
			{
				health.InitialInfiniteAcquired = value4;
			}
		}

		[Token(Token = "0x6001FA0")]
		[Address(RVA = "0x3D929EC", Offset = "0x3D929EC", Length = "0x140")]
		private static void MigrateBoosters(BoosterSaveData boosters)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantStorageMigration::MigrateBoosters");
		}

		[Token(Token = "0x6001FA1")]
		[Address(RVA = "0x3D92B2C", Offset = "0x3D92B2C", Length = "0x98")]
		private static void MigrateProgress(LevelProgressPref progress)
		{
			if (TryReadOldValue<object>("level_progress_pref", out var _))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_-38_v2 (System.Object)+10]");
				progress.CurrentLevel = 0;
			}
		}

		[Token(Token = "0x6001FA2")]
		[Address(RVA = "0x3D92BC4", Offset = "0x3D92BC4", Length = "0x4A0")]
		private unsafe static void MigrateResources(ResourceStorageData resources)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantStorageMigration::MigrateResources");
		}

		[Token(Token = "0x6001FA3")]
		[Address(RVA = "0x3D93064", Offset = "0x3D93064", Length = "0x180")]
		private static void MigrateMonetization(MonetizationStorageData monetization)
		{
			if (TryReadOldValue<bool>("NoAdsPurchased", out var value))
			{
				monetization.NoAdsPurchased = value;
			}
			if (TryReadOldValue<int>("banner_first_install_day", out var value2))
			{
				monetization.BannerFirstInstallDay = value2;
			}
			if (TryReadOldValue<int>("interstitial_first_install_day", out var value3))
			{
				monetization.InterstitialFirstInstallDay = value3;
			}
			if (TryReadOldValue<int>("noads_offer_event_count", out var value4))
			{
				monetization.NoAdsOfferEventCount = value4;
			}
			if (TryReadOldValue<int>("noads_offer_show_count", out var value5))
			{
				monetization.NoAdsOfferShowCount = value5;
			}
		}

		[Token(Token = "0x6001FA4")]
		[Address(RVA = "0x3D931E4", Offset = "0x3D931E4", Length = "0x90")]
		private static void MigrateSettings(SettingsStorageData settings)
		{
			if (TryReadOldValue<int>("Settings", out var value))
			{
				settings.Flags = value;
			}
		}

		[Token(Token = "0x6001FA5")]
		[Address(RVA = "0x3D93274", Offset = "0x3D93274", Length = "0x610")]
		private static void MigrateTutorials(TutorialStorageData tutorials)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantStorageMigration::MigrateTutorials");
		}

		[Token(Token = "0x6001FA6")]
		[Address(RVA = "0x3D93884", Offset = "0x3D93884", Length = "0x280")]
		private static void MigrateFlows(FlowStorageData flows)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantStorageMigration::MigrateFlows");
		}

		[Token(Token = "0x6001FA7")]
		[Address(RVA = "0x3D93B04", Offset = "0x3D93B04", Length = "0xDC")]
		private static void MigrateShop(ShopStorageData shop)
		{
			if (TryReadOldValue<object>("IAPPurchaseHistory", out var value))
			{
				bool flag = value == null;
				bool flag2 = !flag;
				List<string> _003CPurchaseHistory_003Ek__BackingField = (List<string>)value;
				if (!flag2)
				{
					List<string> list = new List<string>();
					_003CPurchaseHistory_003Ek__BackingField = list;
				}
				shop.PurchaseHistory = _003CPurchaseHistory_003Ek__BackingField;
			}
		}

		[Token(Token = "0x6001FA8")]
		[Address(RVA = "0x3D93BE0", Offset = "0x3D93BE0", Length = "0xDC")]
		private static void MigrateRealTime(RealTimeStorageData realTime)
		{
			if (TryReadOldValue<object>("real-time-task-controller.recorded-timer-data", out var value))
			{
				bool flag = value == null;
				bool flag2 = !flag;
				List<RealTimerPref> _003CTimers_003Ek__BackingField = (List<RealTimerPref>)value;
				if (!flag2)
				{
					List<RealTimerPref> list = new List<RealTimerPref>();
					_003CTimers_003Ek__BackingField = list;
				}
				realTime.Timers = _003CTimers_003Ek__BackingField;
			}
		}

		[Token(Token = "0x6001FA9")]
		[Address(RVA = "0x48BC1AC", Offset = "0x48BC1AC", Length = "0x21C")]
		private static bool TryReadOldValue<T>(string key, out T value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantStorageMigration::TryReadOldValue");
			value = default;
			return default;
		}
	}
}
