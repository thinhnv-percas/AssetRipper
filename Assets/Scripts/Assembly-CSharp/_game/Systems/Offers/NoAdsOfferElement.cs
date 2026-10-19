using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.AdSystem;
using Unco.ContainerSystem.Runtime;
using Unco.RemoteManagementSystem;
using _game.CoreGameKit.UiControllers;
using _game.Systems.MonetizationCore;

namespace _game.Systems.Offers
{
	[Token(Token = "0x2000760")]
	public class NoAdsOfferElement : OfferElement
	{
		[Token(Token = "0x40018A2")]
		[FieldOffset(Offset = "0x18")]
		private NoAdsOfferConfig _config;

		[Token(Token = "0x40018A3")]
		[FieldOffset(Offset = "0x20")]
		private InterstitialAdService _interstitialAdService;

		[Token(Token = "0x40018A4")]
		[FieldOffset(Offset = "0x28")]
		private MonetizationStorageData _monetizationData;

		[Token(Token = "0x40018A5")]
		[FieldOffset(Offset = "0x30")]
		private bool _conditionsMet;

		[Token(Token = "0x40018A6")]
		[FieldOffset(Offset = "0x38")]
		private Action _onComplete;

		[Inject(false)]
		[Token(Token = "0x40018A7")]
		[FieldOffset(Offset = "0x40")]
		private IAdManager _adManager;

		[Token(Token = "0x170002F6")]
		public bool WasShownAtLeastOnce
		{
			[Token(Token = "0x6001F19")]
			[Address(RVA = "0x3D8C57C", Offset = "0x3D8C57C", Length = "0x24")]
			get
			{
				MonetizationStorageData monetizationData = _monetizationData;
				bool flag = monetizationData.NoAdsOfferShowCount < 0;
				bool flag2 = monetizationData.NoAdsOfferShowCount == 0;
				int num = monetizationData.NoAdsOfferShowCount ^ monetizationData.NoAdsOfferShowCount;
				int num2 = monetizationData.NoAdsOfferShowCount & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x170002F7")]
		public bool IsExhausted
		{
			[Token(Token = "0x6001F1A")]
			[Address(RVA = "0x3D8C5A0", Offset = "0x3D8C5A0", Length = "0x1A4")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferElement::get_IsExhausted");
				return default;
			}
		}

		[Token(Token = "0x6001F15")]
		[Address(RVA = "0x3D8C178", Offset = "0x3D8C178", Length = "0x8")]
		public override OfferId GetOfferId()
		{
			return OfferId.NoAds;
		}

		[Inject(false)]
		[Token(Token = "0x6001F16")]
		[Address(RVA = "0x3D8C180", Offset = "0x3D8C180", Length = "0x16C")]
		private void Construct(RemoteConfigManager remoteConfigManager, InterstitialAdService interstitialAdService, MonetizationStorageData monetizationData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferElement::Construct");
		}

		[Token(Token = "0x6001F17")]
		[Address(RVA = "0x3D8C390", Offset = "0x3D8C390", Length = "0x44")]
		private void OnInterstitialShown()
		{
			MonetizationStorageData monetizationData = _monetizationData;
			int noAdsOfferEventCount = monetizationData.NoAdsOfferEventCount + 1;
			monetizationData.NoAdsOfferEventCount = noAdsOfferEventCount;
			if (CheckConditions())
			{
				_conditionsMet = true;
			}
		}

		[Token(Token = "0x6001F18")]
		[Address(RVA = "0x3D8C3D4", Offset = "0x3D8C3D4", Length = "0x1A8")]
		private bool CheckConditions()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferElement::CheckConditions");
			return default;
		}

		[Token(Token = "0x6001F1B")]
		[Address(RVA = "0x3D8C744", Offset = "0x3D8C744", Length = "0x190")]
		public override bool IsActive()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferElement::IsActive");
			return default;
		}

		[Token(Token = "0x6001F1C")]
		[Address(RVA = "0x3D8C8D4", Offset = "0x3D8C8D4", Length = "0x150")]
		public override void Trigger(Instancer instancer, Action onComplete)
		{
			_conditionsMet = false;
			MonetizationStorageData monetizationData = _monetizationData;
			int noAdsOfferShowCount = monetizationData.NoAdsOfferShowCount + 1;
			monetizationData.NoAdsOfferShowCount = noAdsOfferShowCount;
			_onComplete = onComplete;
			if (instancer.TryResolve<UiManager>(out var result))
			{
				NoAdsOfferUiController noAdsOfferUiController = result.Show<NoAdsOfferUiController>();
				Action onClose = OnUiClosed;
				noAdsOfferUiController.Initialize(isOffer: true, null, onClose);
			}
			else
			{
				onComplete?.Invoke();
			}
		}

		[Token(Token = "0x6001F1D")]
		[Address(RVA = "0x3D8CA24", Offset = "0x3D8CA24", Length = "0x44")]
		private void OnUiClosed()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferElement::OnUiClosed");
		}

		[Token(Token = "0x6001F1E")]
		[Address(RVA = "0x3D8CA68", Offset = "0x3D8CA68", Length = "0x100")]
		public override void DeInit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferElement::DeInit");
		}

		[Token(Token = "0x6001F1F")]
		[Address(RVA = "0x3D8CC0C", Offset = "0x3D8CC0C", Length = "0x8")]
		public NoAdsOfferElement()
		{
		}
	}
}
