using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Systems.ResourceSystem.IAPSystem.Scripts.Data;
using Systems.ShopSystem.Scripts.Core;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.InitializationSystem.Runtime;
using Unco.RemoteManagementSystem;
using Unco.RewardSystem;
using Unco.RewardSystem.Distribution;
using Unco.RewardSystem.SimpleSequenceSystem;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using _game.CoreGameKit.CoreSerivces.HoveringTextSystem;
using _game.CoreGameKit.Ui.Animations;
using _game.Systems.ElephantStorage;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.ShopSystem.Scripts.IAP;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200071D")]
	public class IAPStoreService : IDetailedStoreListener, IStoreListener, IInitializable
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200071E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40017D9")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40017DA")]
			public static Func<ShopItemRemote, LootDrop> _003C_003E9__18_0;

			[Token(Token = "0x40017DB")]
			public static Action<bool> _003C_003E9__34_0;

			[Token(Token = "0x40017DC")]
			public static Func<ShopItemData, bool> _003C_003E9__42_0;

			[Token(Token = "0x6001E14")]
			[Address(RVA = "0x3D81888", Offset = "0x3D81888", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001E15")]
			[Address(RVA = "0x3D818EC", Offset = "0x3D818EC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal LootDrop _003CGetPurchasedItems_003Eb__18_0(ShopItemRemote x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService._003C_003Ec::_003CGetPurchasedItems_003Eb__18_0");
				return default;
			}

			internal void _003CTryFirstInstallRestore_003Eb__34_0(bool success)
			{
				if (success)
				{
					PlayerPrefs.SetInt("iap_first_install_restore_done", 1);
					PlayerPrefs.Save();
				}
			}

			internal bool _003CDistributeRewardsForRecovery_003Eb__42_0(ShopItemData item)
			{
				bool flag = item == null;
				return !flag;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200071F")]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			[Token(Token = "0x40017DD")]
			[FieldOffset(Offset = "0x10")]
			public IAPStoreService _003C_003E4__this;

			[Token(Token = "0x40017DE")]
			[FieldOffset(Offset = "0x18")]
			public bool silent;

			[Token(Token = "0x40017DF")]
			[FieldOffset(Offset = "0x20")]
			public Action<bool> onCompleted;

			[Token(Token = "0x6001E19")]
			[Address(RVA = "0x3D7FEB0", Offset = "0x3D7FEB0", Length = "0x8")]
			public _003C_003Ec__DisplayClass20_0()
			{
			}
		}

		[Inject(false)]
		[Token(Token = "0x40017C9")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40017CA")]
		[FieldOffset(Offset = "0x18")]
		private RemoteConfigManager _remoteConfigManager;

		[Inject(true)]
		[Token(Token = "0x40017CB")]
		[FieldOffset(Offset = "0x20")]
		private HoveringTextController _hoveringTextController;

		[Inject(false)]
		[Token(Token = "0x40017CC")]
		[FieldOffset(Offset = "0x28")]
		private ShopService _shopService;

		[Inject(false)]
		[Token(Token = "0x40017CD")]
		[FieldOffset(Offset = "0x30")]
		private ShopStorageData _shopData;

		[Inject(false)]
		[Token(Token = "0x40017CE")]
		[FieldOffset(Offset = "0x38")]
		private IPlayerDataHandler _dataHandler;

		[Token(Token = "0x40017CF")]
		[FieldOffset(Offset = "0x40")]
		private bool _iapSuspended;

		[Token(Token = "0x40017D0")]
		[FieldOffset(Offset = "0x48")]
		private IStoreController _storeController;

		[Token(Token = "0x40017D1")]
		[FieldOffset(Offset = "0x50")]
		private IExtensionProvider _extensions;

		[Token(Token = "0x40017D2")]
		[FieldOffset(Offset = "0x58")]
		internal IAPDataStore _iapDataStore;

		[Token(Token = "0x40017D3")]
		[FieldOffset(Offset = "0x60")]
		private readonly List<string> _activePurchaseList;

		[Token(Token = "0x40017D4")]
		[FieldOffset(Offset = "0x68")]
		private readonly List<string> _lastRestoreBundleIds;

		[Token(Token = "0x40017D5")]
		[FieldOffset(Offset = "0x70")]
		private IAPShopEventArgs _iapShopEventArgs;

		[Token(Token = "0x40017D6")]
		[FieldOffset(Offset = "0x78")]
		private bool _verificationEnabled;

		[Token(Token = "0x40017D7")]
		[FieldOffset(Offset = "0x79")]
		private bool _verificationEnabledCache;

		[Token(Token = "0x40017D8")]
		private const string FirstInstallRestoreDoneKey = "iap_first_install_restore_done";

		[Token(Token = "0x170002E6")]
		public bool IsBlocked
		{
			[Token(Token = "0x6001E03")]
			[Address(RVA = "0x3D80454", Offset = "0x3D80454", Length = "0x8")]
			get
			{
				return _iapSuspended;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001DF6")]
		[Address(RVA = "0x3D7EF64", Offset = "0x3D7EF64", Length = "0x368")]
		public unsafe void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::Initialize");
		}

		[Token(Token = "0x6001DF7")]
		[Address(RVA = "0x3D7F2CC", Offset = "0x3D7F2CC", Length = "0x14")]
		private static ProductType MapProductType(IAPProductType type)
		{
			int num = (int)(type - 1);
			bool result = num == 0;
			if (type == IAPProductType.Subscription)
			{
				return (ProductType)type;
			}
			return result ? ProductType.NonConsumable : ProductType.Consumable;
		}

		[Token(Token = "0x6001DF8")]
		[Address(RVA = "0x3D7F2E0", Offset = "0x3D7F2E0", Length = "0x494")]
		public void Purchase(string bundleId, string sourceType)
		{
			//IL_0235: Expected O, but got I
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v4 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v2+E4]");
			Type type = (((nint)0 == 0) ? typeof(IAPStoreService) : typeof(IAPStoreService));
			if (InitializationManager.IsInitialized(type))
			{
				CostData product = _iapDataStore.GetProduct(bundleId);
				if (product != null)
				{
					IAPShopEventArgs iapShopEventArgs = new IAPShopEventArgs(bundleId, sourceType);
					_iapShopEventArgs = iapShopEventArgs;
					IEnumerable<LootDrop> purchasedItems = GetPurchasedItems(bundleId);
					UventPurchaseStarted args = UventPurchaseStarted.Create(_iapShopEventArgs, purchasedItems);
					_eventBus.InvokeEvent(args);
					if (IsBlocked)
					{
						IEnumerable<LootDrop> purchasedItems2 = GetPurchasedItems(bundleId);
						UventPurchaseFailed args2 = UventPurchaseFailed.Create(_iapShopEventArgs, purchasedItems2);
						_eventBus.InvokeEvent(args2);
					}
					else
					{
						List<string> activePurchaseList = _activePurchaseList;
						activePurchaseList.Add(bundleId);
						_storeController.InitiatePurchase(bundleId);
					}
				}
				else
				{
					string message = "[IAPStoreService] Product data not found for bundle id: " + bundleId;
					Debug.LogError(message);
					if ((object)_hoveringTextController != null)
					{
						_hoveringTextController.Display("Something went wrong");
					}
					UventIAPStoreProductNotFound args3 = new UventIAPStoreProductNotFound(bundleId, sourceType);
					_eventBus.InvokeEvent(args3);
				}
			}
			else
			{
				Debug.LogError("[IAPStoreService] IAP not initialized");
				if ((object)_hoveringTextController != null)
				{
					_hoveringTextController.Display("Something went wrong");
				}
				_eventBus.InvokeEvent<UventIAPStoreIsNotInitiazlied>();
			}
		}

		[Token(Token = "0x6001DF9")]
		[Address(RVA = "0x3D7F774", Offset = "0x3D7F774", Length = "0x148")]
		private IEnumerable<LootDrop> GetPurchasedItems(string bundleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::GetPurchasedItems");
			return default;
		}

		[Token(Token = "0x6001DFA")]
		[Address(RVA = "0x3D7F8D8", Offset = "0x3D7F8D8", Length = "0xC")]
		public void Restore()
		{
			Restore(silent: false);
		}

		[Token(Token = "0x6001DFB")]
		[Address(RVA = "0x3D7F8E4", Offset = "0x3D7F8E4", Length = "0x5CC")]
		private void Restore(bool silent, Action<bool> onCompleted = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::Restore");
		}

		[Token(Token = "0x6001DFC")]
		[Address(RVA = "0x3D7EF44", Offset = "0x3D7EF44", Length = "0x18")]
		public CostData GetProduct(string bundleId)
		{
			return _iapDataStore.GetProduct(bundleId);
		}

		[Token(Token = "0x6001DFD")]
		[Address(RVA = "0x3D7FEB8", Offset = "0x3D7FEB8", Length = "0x2A8")]
		public string GetPriceString(string bundleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::GetPriceString");
			return default;
		}

		[Token(Token = "0x6001DFE")]
		[Address(RVA = "0x3D80160", Offset = "0x3D80160", Length = "0x258")]
		public float GetPrice(string bundleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::GetPrice");
			return default;
		}

		[Token(Token = "0x6001DFF")]
		[Address(RVA = "0x3D803B8", Offset = "0x3D803B8", Length = "0x70")]
		public bool IsPurchased(string bundleId)
		{
			IAPDataStore iapDataStore = _iapDataStore;
			ShopStorageData shopData = iapDataStore._shopData;
			string item = default(string);
			return shopData.PurchaseHistory.Contains(item);
		}

		[Token(Token = "0x6001E00")]
		[Address(RVA = "0x3D80428", Offset = "0x3D80428", Length = "0x18")]
		public int HowManyTimesPurchased(string bundleId)
		{
			return _iapDataStore.HowManyTimesPurchased(bundleId);
		}

		[Token(Token = "0x6001E01")]
		[Address(RVA = "0x3D80440", Offset = "0x3D80440", Length = "0xC")]
		public void BlockPayments()
		{
			_iapSuspended = true;
		}

		[Token(Token = "0x6001E02")]
		[Address(RVA = "0x3D8044C", Offset = "0x3D8044C", Length = "0x8")]
		public void UnblockPayments()
		{
			_iapSuspended = false;
		}

		[Token(Token = "0x6001E04")]
		[Address(RVA = "0x3D8045C", Offset = "0x3D8045C", Length = "0x18")]
		public void AddPurchaseHistory(string bundleId)
		{
			_iapDataStore.AddPurchaseHistory(bundleId);
		}

		[Token(Token = "0x6001E05")]
		[Address(RVA = "0x3D80474", Offset = "0x3D80474", Length = "0x18")]
		public float TotalPurchaseHistory()
		{
			return _iapDataStore.TotalPurchaseHistory();
		}

		[Token(Token = "0x6001E06")]
		[Address(RVA = "0x3D8048C", Offset = "0x3D8048C", Length = "0x50")]
		public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
		{
			_storeController = controller;
			_extensions = extensions;
			this.InitSystem();
			TryFirstInstallRestore();
			RetryPendingVerifications();
		}

		[Token(Token = "0x6001E07")]
		[Address(RVA = "0x3D804DC", Offset = "0x3D804DC", Length = "0x13C")]
		private void TryFirstInstallRestore()
		{
			int num = PlayerPrefs.GetInt("iap_first_install_restore_done", 0);
			if (num == 1)
			{
				return;
			}
			Action<bool> onCompleted = _003C_003Ec._003C_003E9__34_0;
			if (_003C_003Ec._003C_003E9__34_0 == null)
			{
				Action<bool> action = (_003C_003Ec._003C_003E9__34_0 = delegate(bool success)
				{
					if (success)
					{
						PlayerPrefs.SetInt("iap_first_install_restore_done", 1);
						PlayerPrefs.Save();
					}
				});
				bool flag = this == null;
				bool flag2 = !flag;
				onCompleted = action;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			Restore(silent: true, onCompleted);
		}

		[Token(Token = "0x6001E08")]
		[Address(RVA = "0x3D80740", Offset = "0x3D80740", Length = "0xC8")]
		public void OnInitializeFailed(InitializationFailureReason error)
		{
			object arg = error;
			string message = $"[IAPStoreService] IAP init failed: {arg}";
			Debug.LogError(message);
		}

		[Token(Token = "0x6001E09")]
		[Address(RVA = "0x3D80808", Offset = "0x3D80808", Length = "0xD0")]
		public void OnInitializeFailed(InitializationFailureReason error, string message)
		{
			object arg = error;
			string message2 = $"[IAPStoreService] IAP init failed: {arg}:{message}";
			Debug.LogError(message2);
		}

		[Token(Token = "0x6001E0A")]
		[Address(RVA = "0x3D808D8", Offset = "0x3D808D8", Length = "0x5DC")]
		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::ProcessPurchase");
			return default;
		}

		[Token(Token = "0x6001E0B")]
		[Address(RVA = "0x3D8112C", Offset = "0x3D8112C", Length = "0x18")]
		public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
		{
			OnPurchaseFailed(product, failureDescription.reason);
		}

		[Token(Token = "0x6001E0C")]
		[Address(RVA = "0x3D81144", Offset = "0x3D81144", Length = "0x140")]
		public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::OnPurchaseFailed");
		}

		[Token(Token = "0x6001E0D")]
		[Address(RVA = "0x3D80618", Offset = "0x3D80618", Length = "0x128")]
		private void RetryPendingVerifications()
		{
			PendingPurchaseGuard.PendingPurchaseData[] allPending = PendingPurchaseGuard.GetAllPending();
			if (allPending.Length < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				PendingPurchaseGuard.PendingPurchaseData pendingPurchaseData = allPending[num];
				if (pendingPurchaseData.source == "RestorePurchase")
				{
					string key = "pending_iap_" + pendingPurchaseData.bundleId;
					PlayerPrefs.DeleteKey(key);
					PendingPurchaseGuard.RemoveFromIndex(pendingPurchaseData.bundleId);
					PlayerPrefs.Save();
					num++;
					if (num >= allPending.Length)
					{
						break;
					}
				}
				else
				{
					RetryVerification(allPending[num]);
					num++;
					if (num >= allPending.Length)
					{
						break;
					}
				}
			}
		}

		[Token(Token = "0x6001E0E")]
		[Address(RVA = "0x3D81284", Offset = "0x3D81284", Length = "0x1D8")]
		private void RetryVerification(PendingPurchaseGuard.PendingPurchaseData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::RetryVerification");
		}

		[Token(Token = "0x6001E0F")]
		[Address(RVA = "0x3D81464", Offset = "0x3D81464", Length = "0x21C")]
		private void DistributeRewardsForRecovery(string bundleId)
		{
			string bundleId2 = default(string);
			IEnumerable<LootDrop> purchasedItems = GetPurchasedItems(bundleId2);
			List<ShopItemData> source = purchasedItems.ConvertToShopItemData("RestorePurchase");
			bool flag = _003C_003Ec._003C_003E9__42_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__42_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__42_0 = delegate(ShopItemData item)
				{
					bool flag3 = item == null;
					return !flag3;
				});
			}
			IEnumerable<object> source2 = source.Where(predicate);
			List<object> list = source2.ToList();
			if (list.Count >= 1)
			{
				USequence uSequence = RewardDistributor.Distribute((IEnumerable<ShopItemData>)list, callOnPurchase: true, animateCurrency: false);
				Action value = RefreshCurrencyVisualizers;
				uSequence.OnComplete += value;
				uSequence.Start();
			}
		}

		[Token(Token = "0x6001E10")]
		[Address(RVA = "0x3D81680", Offset = "0x3D81680", Length = "0xE0")]
		private static void RefreshCurrencyVisualizers()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPStoreService::RefreshCurrencyVisualizers");
		}

		[Token(Token = "0x6001E11")]
		[Address(RVA = "0x3D80EBC", Offset = "0x3D80EBC", Length = "0x270")]
		private void VerifyPurchase(PurchaseEventArgs purchaseEvent, Action successAction, Action failAction, string source)
		{
			Product purchasedProduct = purchaseEvent.purchasedProduct;
			IapVerifyRequest.Builder builder = new IapVerifyRequest.Builder();
			Product product = purchasedProduct;
			ProductMetadata metadata = product.metadata;
			float value = (float)metadata.localizedPrice;
			IapVerifyRequest.Builder builder2 = builder.LocalPrice(value);
			Product product2 = purchasedProduct;
			ProductMetadata metadata2 = product2.metadata;
			IapVerifyRequest.Builder builder3 = builder2.LocalCurrency(metadata2.isoCurrencyCode);
			Product product3 = purchasedProduct;
			ProductMetadata metadata3 = product3.metadata;
			float value2 = (float)metadata3.localizedPrice;
			IapVerifyRequest.Builder builder4 = builder3.Price(value2);
			Product product4 = purchasedProduct;
			IapVerifyRequest.Builder builder5 = builder4.Receipt(product4.receipt);
			Product product5 = purchasedProduct;
			ProductDefinition definition = product5.definition;
			IapVerifyRequest.Builder builder6 = builder5.ProductId(definition.id);
			IapVerifyRequest.Builder builder7 = builder6.Source(source);
			IapVerifyRequest request = builder7.Build();
			Action<bool> callback = delegate(bool isVerified)
			{
				Action action;
				if (isVerified)
				{
					action = successAction;
					if (successAction == null)
					{
						return;
					}
				}
				else
				{
					if (source != "RestorePurchase")
					{
						Product product6 = purchasedProduct;
						ProductDefinition definition2 = product6.definition;
						string message = "[IAPStoreService] Purchase verification failed | source:" + source + " | bundleId:" + definition2.id;
						Debug.LogError(message);
					}
					action = failAction;
					if (failAction == null)
					{
						return;
					}
				}
				action();
			};
			Elephant.VerifyPurchase(request, callback);
		}

		[Token(Token = "0x6001E12")]
		[Address(RVA = "0x3D81768", Offset = "0x3D81768", Length = "0x60")]
		public PurchaseData GetReceipt(PurchaseEventArgs args)
		{
			PurchaseData purchaseData = new PurchaseData();
			purchaseData.quantity = 1;
			return purchaseData;
		}

		[Token(Token = "0x6001E13")]
		[Address(RVA = "0x3D817D8", Offset = "0x3D817D8", Length = "0xB0")]
		public IAPStoreService()
		{
			List<string> activePurchaseList = new List<string>();
			_activePurchaseList = activePurchaseList;
			List<string> lastRestoreBundleIds = new List<string>();
			_lastRestoreBundleIds = lastRestoreBundleIds;
		}
	}
}
