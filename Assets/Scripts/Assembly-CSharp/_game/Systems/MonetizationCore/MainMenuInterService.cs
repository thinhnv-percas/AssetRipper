using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.AdSystem;
using Unco.RemoteManagementSystem;

namespace _game.Systems.MonetizationCore
{
	[Token(Token = "0x2000770")]
	public class MainMenuInterService : IDisposable
	{
		[Token(Token = "0x40018DF")]
		[FieldOffset(Offset = "0x10")]
		private NoAdsOfferConfig _config;

		[Token(Token = "0x40018E0")]
		[FieldOffset(Offset = "0x18")]
		private InterstitialAdService _interstitialAdService;

		[Token(Token = "0x40018E1")]
		[FieldOffset(Offset = "0x20")]
		private MonetizationStorageData _monetizationData;

		[Token(Token = "0x40018E2")]
		[FieldOffset(Offset = "0x28")]
		private bool _shouldShowOffer;

		[Inject(false)]
		[Token(Token = "0x40018E3")]
		[FieldOffset(Offset = "0x30")]
		private IAdManager _adManager;

		[Token(Token = "0x170002FB")]
		public bool ShouldShowOffer
		{
			[Token(Token = "0x6001F5E")]
			[Address(RVA = "0x3D8F104", Offset = "0x3D8F104", Length = "0x8")]
			get
			{
				return _shouldShowOffer;
			}
		}

		[Token(Token = "0x170002FC")]
		public bool HasShownInterstitial
		{
			[Token(Token = "0x6001F5F")]
			[Address(RVA = "0x3D8F10C", Offset = "0x3D8F10C", Length = "0x24")]
			get
			{
				MonetizationStorageData monetizationData = _monetizationData;
				bool flag = monetizationData.NoAdsOfferEventCount < 0;
				bool flag2 = monetizationData.NoAdsOfferEventCount == 0;
				int num = monetizationData.NoAdsOfferEventCount ^ monetizationData.NoAdsOfferEventCount;
				int num2 = monetizationData.NoAdsOfferEventCount & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001F60")]
		[Address(RVA = "0x3D8F130", Offset = "0x3D8F130", Length = "0x16C")]
		private void Construct(RemoteConfigManager remoteConfigManager, InterstitialAdService interstitialAdService, MonetizationStorageData monetizationData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MainMenuInterService::Construct");
		}

		[Token(Token = "0x6001F61")]
		[Address(RVA = "0x3D8F29C", Offset = "0x3D8F29C", Length = "0x44")]
		private void OnInterstitialShown()
		{
			MonetizationStorageData monetizationData = _monetizationData;
			int noAdsOfferEventCount = monetizationData.NoAdsOfferEventCount + 1;
			monetizationData.NoAdsOfferEventCount = noAdsOfferEventCount;
			if (CheckConditions())
			{
				_shouldShowOffer = true;
			}
		}

		[Token(Token = "0x6001F62")]
		[Address(RVA = "0x3D8F2E0", Offset = "0x3D8F2E0", Length = "0x124")]
		private bool CheckConditions()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MainMenuInterService::CheckConditions");
			return default;
		}

		[Token(Token = "0x6001F63")]
		[Address(RVA = "0x3D8F404", Offset = "0x3D8F404", Length = "0xB8")]
		public bool IsNoAdsPurchased()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MainMenuInterService::IsNoAdsPurchased");
			return default;
		}

		[Token(Token = "0x6001F64")]
		[Address(RVA = "0x3D8F4BC", Offset = "0x3D8F4BC", Length = "0x28")]
		public void ConsumeOffer()
		{
			_shouldShowOffer = false;
			MonetizationStorageData monetizationData = _monetizationData;
			int noAdsOfferShowCount = monetizationData.NoAdsOfferShowCount + 1;
			monetizationData.NoAdsOfferShowCount = noAdsOfferShowCount;
		}

		[Token(Token = "0x6001F65")]
		[Address(RVA = "0x3D8F4E4", Offset = "0x3D8F4E4", Length = "0x100")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MainMenuInterService::Dispose");
		}

		[Token(Token = "0x6001F66")]
		[Address(RVA = "0x3D8F5E4", Offset = "0x3D8F5E4", Length = "0x8")]
		public MainMenuInterService()
		{
		}
	}
}
