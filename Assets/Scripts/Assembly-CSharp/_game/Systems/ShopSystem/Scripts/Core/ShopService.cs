using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Systems.ResourceSystem;
using Systems.ResourceSystem.IAPSystem.Scripts.Data;
using Systems.ShopSystem.Scripts.Core;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.Extensions;
using Unco.RemoteManagementSystem;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.RewardSystem.Distribution;
using Unco.RewardSystem.SimpleSequenceSystem;
using Unco.Utils;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.PaymentSystem.Flow;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x2000726")]
	public class ShopService
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000727")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40017F9")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40017FA")]
			public static Func<ShopItemRemote, ShopItemData> _003C_003E9__6_1;

			[Token(Token = "0x40017FB")]
			public static Func<ShopItemData, bool> _003C_003E9__6_2;

			[Token(Token = "0x40017FC")]
			public static Func<ShopItemData, bool> _003C_003E9__14_1;

			[Token(Token = "0x6001E34")]
			[Address(RVA = "0x3D83150", Offset = "0x3D83150", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001E35")]
			[Address(RVA = "0x3D831B4", Offset = "0x3D831B4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal ShopItemData _003COnPurchaseSucceed_003Eb__6_1(ShopItemRemote item)
			{
				LootDrop lootDrop = item.lootDrop;
				return lootDrop.ConvertToShopItemData("RestorePurchase");
			}

			internal bool _003COnPurchaseSucceed_003Eb__6_2(ShopItemData item)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ShopService._003C_003Ec::_003COnPurchaseSucceed_003Eb__6_2");
				return default;
			}

			internal bool _003CPurchaseGroup_003Eb__14_1(ShopItemData item)
			{
				bool flag = item == null;
				return !flag;
			}
		}

		[Token(Token = "0x40017F4")]
		[FieldOffset(Offset = "0x10")]
		private RemoteConfigManager _remoteConfigManager;

		[Token(Token = "0x40017F5")]
		[FieldOffset(Offset = "0x18")]
		internal ShopConfig _shopConfig;

		[Inject(false)]
		[Token(Token = "0x40017F6")]
		[FieldOffset(Offset = "0x20")]
		private IAPStoreService _iapStoreService;

		[Inject(false)]
		[Token(Token = "0x40017F7")]
		[FieldOffset(Offset = "0x28")]
		private PaymentFlowController _paymentFlowController;

		[Inject(false)]
		[Token(Token = "0x40017F8")]
		[FieldOffset(Offset = "0x30")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x6001E26")]
		[Address(RVA = "0x3D82470", Offset = "0x3D82470", Length = "0xF8")]
		public void Inject(RemoteConfigManager remoteConfigManager)
		{
			RemoteConfigManager remoteConfigManager2 = default(RemoteConfigManager);
			_remoteConfigManager = remoteConfigManager2;
			ShopConfig jsonWithNewton = _remoteConfigManager.GetJsonWithNewton<ShopConfig>(RemoteKey.shop_config);
			_shopConfig = jsonWithNewton;
			Action<UventPurchaseSucceed> observer = OnPurchaseSucceed;
			_eventBus.ListenEvent(observer);
		}

		[Token(Token = "0x6001E27")]
		[Address(RVA = "0x3D82568", Offset = "0x3D82568", Length = "0x374")]
		private void OnPurchaseSucceed(UventPurchaseSucceed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopService::OnPurchaseSucceed");
		}

		[Token(Token = "0x6001E28")]
		[Address(RVA = "0x3D828E4", Offset = "0x3D828E4", Length = "0xD0")]
		public List<string> GetActiveGroupKeys()
		{
			ShopConfig shopConfig = _shopConfig;
			Func<string, bool> predicate = IsGroupEnabled;
			IEnumerable<object> source = shopConfig.activeGroupKeys.Where((Func<object, bool>)predicate);
			return (List<string>)(object)source.ToList();
		}

		[Token(Token = "0x6001E29")]
		[Address(RVA = "0x3D829B4", Offset = "0x3D829B4", Length = "0xE0")]
		public List<string> GetOrderedGroupKeys(string layoutId)
		{
			string layoutId2 = default(string);
			List<string> orderedKeys = _shopConfig.GetOrderedKeys(layoutId2);
			Func<string, bool> predicate = IsGroupEnabled;
			IEnumerable<object> source = orderedKeys.Where((Func<object, bool>)predicate);
			return (List<string>)(object)source.ToList();
		}

		[Token(Token = "0x6001E2A")]
		[Address(RVA = "0x3D82A94", Offset = "0x3D82A94", Length = "0x1C")]
		public ShopLayoutConfig GetLayout(string layoutId)
		{
			return _shopConfig.GetLayout(layoutId);
		}

		[Token(Token = "0x6001E2B")]
		[Address(RVA = "0x3D82AB0", Offset = "0x3D82AB0", Length = "0x1C")]
		public ShopGroupRemote GetGroupConfig(string groupKey)
		{
			return _shopConfig.GetGroupConfig(groupKey);
		}

		[Token(Token = "0x6001E2C")]
		[Address(RVA = "0x3D7F8BC", Offset = "0x3D7F8BC", Length = "0x1C")]
		public ShopGroupRemote GetGroupConfigWithBundleId(string bundleId)
		{
			return _shopConfig.GetGroupConfigBundleId(bundleId);
		}

		[Token(Token = "0x6001E2D")]
		[Address(RVA = "0x3D82ACC", Offset = "0x3D82ACC", Length = "0x58")]
		public LimitedShopPref GetShopPref(string groupKey)
		{
			return new LimitedShopPref();
		}

		[Token(Token = "0x6001E2E")]
		[Address(RVA = "0x3D82B24", Offset = "0x3D82B24", Length = "0x20")]
		public void PurchaseItem(ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null)
		{
			_paymentFlowController.PayAndShowRewardUi(itemData, costData, onComplete, onFailed);
		}

		[Token(Token = "0x6001E2F")]
		[Address(RVA = "0x3D82C14", Offset = "0x3D82C14", Length = "0x2F4")]
		public void PurchaseGroup(ShopGroupRemote groupConfig, Action onComplete = null, Action onFailed = null)
		{
			ShopGroupRemote shopGroupRemote = groupConfig;
			Func<ShopItemRemote, ShopItemData> selector = delegate(ShopItemRemote item)
			{
				LootDrop lootDrop = item.lootDrop;
				ShopItemData item2 = lootDrop.ConvertToShopItemData("Shop");
				ShopGroupRemote shopGroupRemote3 = groupConfig;
				return UpgradeWithVisualKey(item2, shopGroupRemote3.groupKey);
			};
			IEnumerable<object> source = shopGroupRemote.shopItems.Select((Func<object, object>)selector);
			bool flag = _003C_003Ec._003C_003E9__14_1 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__14_1;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__14_1 = delegate(ShopItemData item)
				{
					bool flag3 = item == null;
					return !flag3;
				});
			}
			IEnumerable<object> source2 = source.Where(predicate);
			List<object> list = source2.ToList();
			if (list.Count != 0)
			{
				MultiPackData itemData = new MultiPackData("Shop", (List<ShopItemData>)(object)list);
				ShopGroupRemote shopGroupRemote2 = groupConfig;
				_paymentFlowController.PayAndShowRewardUi(itemData, shopGroupRemote2.costData, onComplete, onFailed);
			}
			else
			{
				onFailed?.Invoke();
			}
		}

		[Token(Token = "0x6001E30")]
		[Address(RVA = "0x3D82F10", Offset = "0x3D82F10", Length = "0x228")]
		private ShopItemData UpgradeWithVisualKey(ShopItemData item, string groupKey)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopService::UpgradeWithVisualKey");
			return default;
		}

		[Token(Token = "0x6001E31")]
		[Address(RVA = "0x3D83140", Offset = "0x3D83140", Length = "0x8")]
		private bool IsGroupEnabled(string groupKey)
		{
			return true;
		}

		[Token(Token = "0x6001E32")]
		[Address(RVA = "0x3D79FC8", Offset = "0x3D79FC8", Length = "0x1F8")]
		public string GetCostString(CostData costData)
		{
			object arg;
			string arg2;
			string format;
			if (costData.costType <= CostData.CostType.Custom)
			{
				if (costData.costType == CostData.CostType.Free)
				{
					return "FREE";
				}
				if (costData.costType != CostData.CostType.Rewarded)
				{
					goto IL_0197;
				}
				bool flag2;
				if (costData.amount != 9.218868437227405E+18)
				{
					bool flag = costData.amount < 1E-323;
					flag2 = !flag;
				}
				else
				{
					flag2 = true;
				}
				if (!flag2)
				{
					return "<sprite=\"ic_rewarded_flat\" index=0> Free";
				}
				double amount = costData.amount;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj = default(object);
				arg = obj;
				arg2 = "<sprite=\"ic_rewarded_flat\" index=0>";
				format = "{0} RewardedCounter/{1}";
			}
			else
			{
				if (costData.costType != CostData.CostType.Resource)
				{
					if (costData.costType == CostData.CostType.IAP)
					{
						return _iapStoreService.GetPriceString(costData.bundleId);
					}
					goto IL_0197;
				}
				string resourceIcon = SpriteAssetHelper.GetResourceIcon(costData.resourceType);
				double amount = costData.amount;
				int num2 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj2 = default(object);
				arg = obj2;
				arg2 = resourceIcon;
				format = "{0}{1}";
			}
			return string.Format(format, arg2, arg);
			IL_0197:
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			return costData.amount.ToString(invariantCulture);
		}

		[Token(Token = "0x6001E33")]
		[Address(RVA = "0x3D83148", Offset = "0x3D83148", Length = "0x8")]
		public ShopService()
		{
		}
	}
}
